using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDownloadVAccDOPos : ISA.Trading.BaseForm
    {
        int counter = 0;
        string folderInbox = FTP.FtpEngine.InboxDirectory;
        DataTable fileList;
        bool loaded = false;

        public frmDownloadVAccDOPos()
        {
            InitializeComponent();
        }


        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    bool success = false;
                    string fileName = customGridView1.SelectedCells[0].OwningRow.Cells["FileName"].Value.ToString();
                    DataRow rowItem = fileList.Rows.Find(fileName);
                    if (rowItem != null)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        refreshForm();

                        double downloadSize = FTP.FtpEngine.Download(folderInbox, fileName);
                        if (downloadSize != 0)
                        {
                            success = FTP.FtpEngine.Delete(folderInbox, fileName);
                            if (success)
                            {
                                rowItem.Delete();

                                DataSet ds = ReadData(FTP.FtpEngine.DownloadDirectory + "\\" + fileName);

                                refreshForm();
                                ProcessTable(ds);

                                MessageBox.Show(Messages.Confirm.DownloadSuccess);
                            }
                            ReadFileList();
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


        private void ReadFileList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                fileList = FTP.FtpEngine.GetFileList(folderInbox);



                fileList.DefaultView.RowFilter = "FileName LIKE '%" + "VACCDO" + "%'";



                fileList.DefaultView.Sort = "FileName";
                customGridView1.DataSource = fileList.DefaultView.ToTable();
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

        private void ProcessTable(DataSet ds)
        {
            counter = 0;
            progressBar1.Value = 0;
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                refreshForm();
                DownloadData(dt);
                progressBar1.Value = counter;
                refreshForm();
            }
            progressBar1.Value = progressBar1.Maximum;
        }


        private void DownloadData(DataTable dt)
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
                            db.Commands.Add(db.CreateCommand("psp_DOWNLOAD_DIRECTOR_VACCDO"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                }
            }

        }



        private void frmDownloadVAccDOPos_Shown(object sender, EventArgs e)
        {
            if (!loaded)
            {
                //lblStatus.Text = "Get FTP Info ...";
                refreshForm();
                ReadFileList();
                loaded = true;
            }
        }

        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
