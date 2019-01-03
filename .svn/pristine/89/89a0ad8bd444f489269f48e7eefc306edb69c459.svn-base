using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;

using ICSharpCode.SharpZipLib.Zip;


namespace ISA.Trading.Communicator
{
    public partial class frmAntarGudangDownload_MatachingAGdariHO : ISA.Controls.BaseForm
    {
        DataTable tblHeader;
        DataTable tblDetail;

        DataTable tblStok;
        DataTable tblStokPart;

        Guid _RowIDHeader;
        Guid _RowID;
        String _RecordIDHeader;
        Guid _RowIDStok;

        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            int result2 = 0;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Antargudang_Matching_Download"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    string KodeGudang = Tools.isNull(dr["Dr_gud"], "").ToString();
                    if (KodeGudang == GlobalVar.Gudang)
                    {
                        _RecordIDHeader = Tools.isNull(dr["idhkrmagud"], "").ToString().Trim();
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["Tgl_trm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.BeginTransaction();
                        result = db.Commands[0].ExecuteNonQuery();

                        if (result == 1 || result == 0)
                        {
                            dr["cUploaded"] = true;
                            counter++;
                            progressBar1.Increment(1);
                            lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }

                        DataRow[] orderDetails = tblDetail.Select("idhkrmagud='" + dr["idhkrmagud"].ToString() + "'");
                        if (orderDetails.Length == 0)
                        {
                            MessageBox.Show(Messages.Confirm.NoDetailData);
                        }

                        db.Commands.Add(db.CreateCommand("usp_AntargudangDetail_Matching_Download"));
                        foreach (DataRow drd in orderDetails)
                        {
                            db.Commands[1].Parameters.Clear();
                            db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Iddkrmagud"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@Kodebarang", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["qty_krm"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserInitial));
                            result2 = db.Commands[1].ExecuteNonQuery();

                            if (result2 == 0 || result2 == 1)
                            {
                                drd["cUploaded"] = true;
                                counter++;
                                progressBar2.Increment(1);
                                lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }
                        }
                        db.CommitTransaction();
                    }
                }
            }
        }


        public frmAntarGudangDownload_MatachingAGdariHO()
        {
            InitializeComponent();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download AntarGudang ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    Download();
                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
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


        private void frmAntarGudangDownload_MatachingAGdariHO_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\AG2801.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\AG2801.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\AG2801.zip tidak ada");
                return;
            }
           
            string fileNameH = "Haghotmp.dbf";
            string fileNameD = "Daghotmp.dbf";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;

            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView2.DataSource = tblHeader;
                    lblDownloadStatus1.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    this.Title = fileNameH;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            { 
                MessageBox.Show("File " + fileNameH + " tidak ada");
                return;
            }

            if (File.Exists(fileNameD))
            {
                try
                {
                    tblDetail = Foxpro.ReadFile(fileNameD);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblDetail.Columns.Add(newcol);

                    dataGridView3.DataSource = tblDetail;
                    lblDownloadStatus2.Text = "0/" + tblDetail.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = tblDetail.Rows.Count;
                    this.Title = fileNameD;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameD + " tidak ada");
                return;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
