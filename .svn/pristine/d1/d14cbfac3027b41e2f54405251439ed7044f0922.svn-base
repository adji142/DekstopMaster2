using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ISA.Toko.Class;
using System.Diagnostics;

namespace ISA.Toko.Communicator
{
    public partial class frmDODownload : ISA.Toko.BaseForm
    {
        DataTable tblHeader;
        DataTable tblDetail;

        DataTable dtProcess;
        DataTable dtNothing;
        DataTable dtSdhDownload;
        DataTable dtKodeToko;


        public enum enDownloadType
        {
            Data00,
            Data11
        }

        enDownloadType _downloadType;

        public frmDODownload(enDownloadType downloadType)
        {
            InitializeComponent();
            _downloadType = downloadType;
        }

        public void Download00()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            DataTable dtb = new DataTable();

            dtProcess = tblHeader.Clone();
            dtNothing = tblHeader.Clone();
            dtSdhDownload = tblHeader.Clone();
            dtKodeToko = tblHeader.Clone();

            int result = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_DOWNLOAD_11"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    if (dr["C1"].ToString().Trim() != GlobalVar.Gudang && dr["C2"].ToString().Trim() + dr["C3"].ToString().Trim() == GlobalVar.Gudang)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@idhtr", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@no_acc", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        db.BeginTransaction();
                        dtResult = db.Commands[0].ExecuteDataTable();
                        if (dtResult.Rows.Count == 1)
                        {
                            result = int.Parse(dtResult.Rows[0]["Result"].ToString());
                        }

                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();

                        if (result == 0)
                        {
                            dtProcess.ImportRow(dr);
                            DataRow[] orderDetails = tblDetail.Select("idhtr='" + dr["idhtr"].ToString() + "'");

                            if (orderDetails.Length == 0)
                            {
                                MessageBox.Show(String.Format(Messages.Confirm.NoDetailData, dr["no_do"].ToString()));
                            }

                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_DOWNLOAD_11"));
                            foreach (DataRow drd in orderDetails)
                            {
                                db.Commands[1].Parameters.Clear();
                                db.Commands[1].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(drd["idrec"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(drd["catatan"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@j_do", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@noacc", SqlDbType.VarChar, Tools.isNull(drd["noacc"], "").ToString().Trim()));
                                db.Commands[1].ExecuteNonQuery();

                                drd["cUploaded"] = true;
                                counter++;
                                progressBar2.Increment(1);
                                lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }
                        }
                        else if (result == 1)
                        {
                            dtKodeToko.ImportRow(dr);
                        }
                        else
                        {
                            dtSdhDownload.ImportRow(dr);
                        }
                        db.CommitTransaction();
                    }
                    
                }
            }
        }

        public void Download11()
        {
            int counter1 = 0;
            int counter2 = 0;
            DataTable dtResult = new DataTable();

            dtProcess = tblHeader.Clone();
            dtNothing = tblHeader.Clone();

            int result = 0;

            //DO HEADERS
            foreach (DataRow dr in tblHeader.Rows)
            {
                dr["cUploaded"] = true;
                counter1++;
                progressBar1.Increment(1);
                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                this.Refresh();
                this.Invalidate();
                Application.DoEvents();

                dtProcess.ImportRow(dr);


                //DO DETAILS

                DataRow[] orderDetails = tblDetail.Select("idhtr='" + dr["idhtr"].ToString() + "'");

                if (orderDetails.Length == 0)
                {
                    MessageBox.Show(String.Format(Messages.Confirm.NoDetailData, dr["no_do"].ToString()));
                }

                Database db = new Database();
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_DOWNLOAD_11"));
                foreach (DataRow drd in orderDetails)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(drd["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(drd["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@jdo", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], 0).ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@noacc", SqlDbType.VarChar, Tools.isNull(drd["no_acc"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual", SqlDbType.Int, double.Parse(Tools.isNull(drd["h_jual"], 0).ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    drd["cUploaded"] = true;
                    counter2++;
                    progressBar2.Increment(1);
                    lblDownloadStatus2.Text = counter2.ToString("#,##0") + "/" + tblDetail.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
            string directory = "C:\\Temp\\Download\\HasilUpload.txt";
            if (File.Exists(directory))
            {
                Process.Start(directory);
            }
        }

        private bool UnzipFile(string sourceZIPFileName, string FileName1, string FileName2)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload; // +"\\" + sourceZIPFileName;
            string zipFile = GlobalVar.DbfDownload + "\\" + sourceZIPFileName + ".ZIP";
            if (File.Exists(zipFile))
            {
                if (File.Exists(FileName1))
                {
                    File.Delete(FileName1);
                }

                if (File.Exists(FileName2))
                {
                    File.Delete(FileName2);
                }

                Zip.UnZipFiles(zipFile, extractFileLocation, false);
                this.Title = zipFile;
                //this.Text = title;
                //cmdDownload.Enabled = true;
                retVal = true;
            }
            else
            {
                this.Title = "File " + zipFile + " tidak ada.";

                //cmdDownload.Enabled = false;
                MessageBox.Show("File: " + zipFile + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void frmDODownload11_Load(object sender, EventArgs e)
        {
            string fileNameH = "htjtmp.DBF";
            string fileNameD = "dtjtmp.DBF";
            string fileZIPName = "DBFMATCH";
            
       
            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;

            if (UnzipFile(fileZIPName, fileNameH, fileNameD))
            {
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
                dataGridView1.AutoGenerateColumns = true;
                dataGridView2.AutoGenerateColumns = true;
            }
        }

        private void DisplayReport()
        {                        
            List<ReportParameter> rptParams = new List<ReportParameter>();            
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();
            pTable.Add(dtProcess);
            pTable.Add(dtNothing);
            pDatasetName.Add("dsOrderPenjualan_Data");
            pDatasetName.Add("dsOrderPenjualan_Data1");
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptDODownload.rdlc", rptParams, pTable, pDatasetName);

            ifrmReport.Show();

        }

        private void ExtractFile(string fileName)
        {
            
           // ZipFile file = new ZipFile(fileName);
            

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Data, Make Sure you put dbfmatch.zip in valid path !!!");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    switch (_downloadType)
                    {
                        case enDownloadType.Data00:
                            Download00();
                            break;
                        case enDownloadType.Data11:
                            Download11();
                            break;
                    }

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
