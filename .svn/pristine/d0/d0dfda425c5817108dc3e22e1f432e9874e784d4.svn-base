using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Kasir
{
    public partial class frmKasirDownloadISA : ISA.Finance.BaseForm
    {
        int counter = 0;
        string folderInbox = FTP.FtpEngine.InboxDirectory;
        DataTable fileList;
        bool loaded = false;

        public frmKasirDownloadISA()
        {
            InitializeComponent();
        }

        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }


        private void frmKasirDownloadISA_Shown(object sender, EventArgs e)
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



                fileList.DefaultView.RowFilter = "FileName LIKE '%" + "KASIR" + "%'";



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
            lblProgress.Text = "DELETING DATA ...";
            for(int i = ds.Tables.Count -1; i >=0;i--)
            {
                counter++;
                refreshForm();
                ds.Tables[i].DefaultView.RowFilter = "METHOD='DELETE'";
                DownloadData(ds.Tables[i]);
                progressBar1.Value = counter;
                refreshForm();
            }

            counter = 0;
            progressBar1.Value = 0;
            lblProgress.Text = "UPDATING DATA ...";
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                refreshForm();
                dt.DefaultView.RowFilter = "METHOD='UPDATE'";
                DownloadData(dt);
                progressBar1.Value = counter;
                refreshForm();
            }
            progressBar1.Value = progressBar1.Maximum;
            lblProgress.Text = "COMPLETED";
        }


        private void DownloadData(DataTable dt)
        {


            using (Database db = new Database(GlobalVar.DBName))
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_DOWNLOAD_DIRECTOR_KASIR_ISA"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                }
            }

        }

    }
}
