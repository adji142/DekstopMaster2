using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.IO;

namespace ISA.Finance.Kasir
{
    public partial class frmBPPDownload : ISA.Finance.BaseForm
    {
        DataTable dtBPP,dtBPPDetail = new DataTable();
        public frmBPPDownload()
        {
            InitializeComponent();
        }

        private void ExtractFile(string fileName)
        {

            Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void frmBPPDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\BPP"+GlobalVar.Gudang+".zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\BPP"+GlobalVar.Gudang+".zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\BPP" + GlobalVar.Gudang + ".zip tidak ada");
                return;
            }

            string fileName = "BPPtmp.dbf";
            string fileName2 = "BPPDetailtmp.dbf";


            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            fileName2 = GlobalVar.DbfDownload + "\\" + fileName2;

            if (File.Exists(fileName))
            {
                try
                {
                    dtBPP = Foxpro.ReadFile(fileName);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dtBPP.Columns.Add(newcol);

                    dataGridView2.DataSource = dtBPP;
                    dtBPP.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dtBPP.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileName + " tidak ada");
                return;
            }

            if (File.Exists(fileName2))
            {
                try
                {
                    dtBPPDetail = Foxpro.ReadFile(fileName2);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dtBPPDetail.Columns.Add(newcol);

                    dataGridView1.DataSource = dtBPPDetail;
                    dtBPPDetail.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = dtBPPDetail.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileName2 + " tidak ada");
                return;
            }
        }

        private void cmbDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0 || dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tidak Ada Data yang di download");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download BPP ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Download();
                   

                    //this.Close();
                    if (this.Caller is Kasir.frmBPPBrowse)
                    {
                        Kasir.frmBPPBrowse frmCaller = (Kasir.frmBPPBrowse)this.Caller;
                        frmCaller.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void Download()
        {
            try
            {
                int counter = 0;
                DataTable dtResult = new DataTable();

                int result, result2 = 0;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BPPHeader_Download"));

                    foreach (DataRow dr in dtBPP.Rows)
                    {
                        string KodeGudang = Tools.isNull(dr["GdgID"], "").ToString();
                        //if (KodeGudang == GlobalVar.Gudang)
                        //{
                        Guid _RowID = new Guid(dr["RowID"].ToString());
                            //add parameters
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBPPAwal", SqlDbType.VarChar, Tools.isNull(dr["NoBPPA"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, Tools.isNull(dr["KodeCol"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Tools.isNull(dr["GdgID"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@BanyakLembar", SqlDbType.Int, dr["Lembar"]));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            

                            db.BeginTransaction();

                            result = db.Commands[0].ExecuteNonQuery();


                            if (result == 1 || result == 0)
                            {

                                //grid and form status
                                dr["cUploaded"] = true;
                                counter++;
                                progressBar1.Increment(1);
                                //lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }

                            //DO DETAILS

                            DataRow[] orderDetails = dtBPPDetail.Select("HID='" + dr["RowID"].ToString() + "'");

                            if (orderDetails.Length == 0)
                            {
                                MessageBox.Show(String.Format(Messages.Confirm.NoDetailData));
                            }

                            db.Commands.Add(db.CreateCommand("usp_BPPDetail_Download"));
                            foreach (DataRow drd in orderDetails)
                            {
                                Guid _RowIDDetail = new Guid(drd["RowID"].ToString());
                                //if (drd["TglNota"].ToString() != "")
                                //{
                                //    DateTime tgbpp = Convert.ToDateTime(drd["TgNota"]);
                                //}
                                //if (tgbpp == null)
                                //{

                                //}
                                //add parameters
                                db.Commands[1].Parameters.Clear();
                                db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDDetail));
                                db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[1].Parameters.Add(new Parameter("@NoBPP", SqlDbType.VarChar, Tools.isNull(drd["BPP"], "").ToString().Trim()));
                                if (drd["TgBPP"].ToString() != "")
                                {
                                    db.Commands[1].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, Tools.isNull(Convert.ToDateTime(drd["TgBPP"]), null)));
                                }
                                db.Commands[1].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(drd["NmToko"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@IdWIll", SqlDbType.VarChar, Tools.isNull(drd["IdWIll"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(drd["NNota"], "").ToString().Trim()));
                                if (drd["TgNota"].ToString() != "")
                                {
                                    db.Commands[1].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, Tools.isNull(Convert.ToDateTime(drd["TgNota"]), null)));
                                }
                                db.Commands[1].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["RpNota"], "0").ToString().Trim())));
                                db.Commands[1].Parameters.Add(new Parameter("@JenisPembayaran", SqlDbType.VarChar, Tools.isNull(drd["JP"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["RpByr"], "0").ToString().Trim())));
                                db.Commands[1].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(drd["Ktrngn"], "0").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@FlagAudit", SqlDbType.Bit, Tools.isNull(Convert.ToInt32(drd["FlagA"]), 0)));
                                db.Commands[1].Parameters.Add(new Parameter("@KetAudit", SqlDbType.VarChar, Tools.isNull(drd["KetA"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                result2 = db.Commands[1].ExecuteNonQuery();

                                //grid and form status
                                if (result2 == 0 || result2 == 1)
                                {
                                    drd["cUploaded"] = true;
                                    counter++;
                                    progressBar2.Increment(1);
                                    //lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                                    this.Refresh();
                                    this.Invalidate();
                                    Application.DoEvents();
                                }

                            }

                            db.CommitTransaction();
                            MessageBox.Show(Messages.Confirm.DownloadSuccess);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
