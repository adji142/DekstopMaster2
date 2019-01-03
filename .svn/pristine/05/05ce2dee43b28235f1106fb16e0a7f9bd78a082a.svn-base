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
    public partial class frmTargetSalesDownload : ISA.Controls.BaseForm
    {
        DataTable tblHeader;
        DataTable tblDetail;

        Guid _RowIDHeader;
        Guid _RowIDDetail;
        
        public frmTargetSalesDownload()
        {
            InitializeComponent();
        }

        public frmTargetSalesDownload(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void frmTargetSalesDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\dbfmatch.zip tidak ada");
                return;
            }

            string fileNameH = "TSlstmp.dbf";
            string fileNameD = "TTokotmp.dbf";

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

                    dataGridView1.DataSource = tblHeader;
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
            //else
            //{
            //    MessageBox.Show("File " + fileNameH + " tidak ada");
            //    return;
            //}

            if (File.Exists(fileNameD))
            {
                try
                {
                    tblDetail = Foxpro.ReadFile(fileNameD);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblDetail.Columns.Add(newcol);

                    dataGridView2.DataSource = tblDetail;
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
            //else
            //{
            //    MessageBox.Show("File " + fileNameD + " tidak ada");
            //    return;
            //}
        }

        private void ExtractFile(string fileName)
        {
            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
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
                    DownloadTargetSales();
                    DownloadTargetToko();

                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    
                    Master.frmTargetSales frm = new Master.frmTargetSales();
                    frm = (Master.frmTargetSales)Caller;
                    frm.BindData();
                    string _KodeSales = Tools.isNull(tblDetail.Rows[0]["SalesID"], "").ToString();
                    frm.RefreshDataTargetToko();

                    this.DialogResult = DialogResult.OK;
                    this.Close();

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

        private void DownloadTargetSales()
        {
            int counter = 0;
            int result = 0;
            DataTable dtResult = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_DOWNLOAD"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    if (Tools.isNull(dr["kd_gdg"], "").ToString() == GlobalVar.Gudang)
                    {
                        _RowIDHeader = Guid.NewGuid();
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr["SalesID"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, Tools.isNull(dr["TglAktif"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NomFB2", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["NomFB2"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NomFA", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["NomFA"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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
                    }
                }
            }

        }


        private void DownloadTargetToko()
        {
            int counter = 0;
            int result2 = 0;
            DataTable dtResult2 = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryTargetToko_DOWNLOAD"));
                foreach (DataRow dr in tblDetail.Rows)
                {
                    if (Tools.isNull(dr["kd_gdg"], "").ToString() == GlobalVar.Gudang)
                    {
                        _RowIDDetail = Guid.NewGuid();
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDDetail));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tmt", SqlDbType.DateTime, Tools.isNull(dr["tmt"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TargetBE", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["Targetbe"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@TargetFA", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["Targetfa"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["SalesID"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        result2 = db.Commands[0].ExecuteNonQuery();

                        if (result2 == 1 || result2 == 0)
                        {
                            dr["cUploaded"] = true;
                            counter++;
                            progressBar2.Increment(1);
                            lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblDetail.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
