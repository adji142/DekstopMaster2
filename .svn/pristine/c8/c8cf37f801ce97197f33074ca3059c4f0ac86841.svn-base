using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using ISA.DAL;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmDownloadMasterDataFTP : ISA.Toko.BaseForm
    {
        DataTable fileList;
        int counter = 0;
        bool loaded = false;

        public frmDownloadMasterDataFTP()
        {
            InitializeComponent();
        }

        private void frmDownloadMasterDataFTP_Load(object sender, EventArgs e)
        {

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (gridListOfFile.SelectedCells.Count > 0)
            {
                try
                {
                    bool success = false;
                    string fileName = gridListOfFile.SelectedCells[0].OwningRow.Cells["FileName"].Value.ToString();
                    DataRow rowItem = fileList.Rows.Find(fileName);     
             
                    if (rowItem != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        lblStatus.Text = "Download file from FTP ...";
                        refreshForm();

                        double downloadSize = FTP.FtpEngine.Download(FTP.FtpEngine.InboxDirectory, fileName);
                        if (downloadSize == (double)rowItem["FileSize"] && downloadSize != 0)
                        {
                            success = FTP.FtpEngine.Delete(FTP.FtpEngine.InboxDirectory, fileName);
                            if (success)
                            {
                                rowItem.Delete();

                                DataSet ds = ReadData(FTP.FtpEngine.DownloadDirectory + "\\" + fileName);

                                lblDownload.Text = "0/" + ds.Tables.Count.ToString("#,##0");

                                lblStatus.Text = "Downloading Data....";
                                pbDownload.Minimum = 0;
                                pbDownload.Maximum = ds.Tables.Count;
                                refreshForm();
                                counter = 0;

                                ProcessTable(ds, "Toko");
                                ProcessTable(ds, "StatusToko");
                                


                                MessageBox.Show(Messages.Confirm.DownloadSuccess);
                            }
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.FailDownload);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }


        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }


        private void ReadFileList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                fileList = FTP.FtpEngine.GetFileList(FTP.FtpEngine.InboxDirectory);
                
                fileList.DefaultView.RowFilter = "FileName LIKE 'TokoUpload-%'";
                
                gridListOfFile.DataSource = fileList.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("450"))
                {
                    ex = new Exception("No File available", ex);
                }
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ProcessTable(DataSet ds, string tableName)
        {
            counter++;
            lblStatus.Text = "Download " + tableName;
            ImportData(ds.Tables[tableName]);
            pbDownload.Value = counter;
            lblDownload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
            refreshForm();
        }


        private void ImportData(DataTable dt)
        {
            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_MASTER_DOWNLOAD_ISA_DIRECTOR"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadMasterDataFTP_Shown(object sender, EventArgs e)
        {
            if (!loaded)
            {
                refreshForm();
                lblStatus.Text = "Get FTP Info ...";
                ReadFileList();
                loaded = true;
            }
        }
    }
}
