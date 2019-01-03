using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDownloadDataISA : ISA.Trading.BaseForm
    {
        int counter = 0;
        string  _Data;
        string initDir = FTP.FtpEngine.InboxDirectory;
        DataTable fileList;
        bool loaded = false;
        

        public frmDownloadDataISA()
        {
            InitializeComponent();
        }

        private void frmDownloadDataISA_Load(object sender, EventArgs e)
        {            
            cboxData.Text = "ALL";
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        lblStatus.Text = "Download file from FTP ...";
                        refreshForm();

                        double downloadSize = FTP.FtpEngine.Download(initDir, fileName);
                        if (downloadSize != 0)
                        {
                            success = FTP.FtpEngine.Delete(initDir, fileName);
                            if (success)
                            {
                                rowItem.Delete();

                                DataSet ds = ReadData(FTP.FtpEngine.DownloadDirectory + "\\" + fileName);

                                lblStatus.Text = "Upload data to ISA ....";
                                refreshForm();
                                ProcessTable(ds);
                                if (cboxData.Text.ToUpper().Equals("RSOPAC"))
                                {
                                    LinkNota(ds);
                                } 

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


        private void ProcessTable(DataSet ds)
        {
            pbDownload.Maximum = ds.Tables.Count * 2;
            counter = 0;
            pbDownload.Value = 0;
            lblProgress.Text = "DELETING DATA ...";
            for (int i = ds.Tables.Count - 1; i >= 0; i--)
            {
                counter++;
                lblStatus.Text = "Download " + ds.Tables[i].TableName;
                refreshForm();
                ds.Tables[i].DefaultView.RowFilter = "METHOD='DELETE'";
                ImportData(ds.Tables[i]);
                pbDownload.Value = counter;
                lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
            lblProgress.Text = "UPDATING DATA ...";
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                dt.DefaultView.RowFilter = "METHOD='UPDATE'";
                ImportData(dt);
                pbDownload.Value = counter;
                lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
            pbDownload.Value = pbDownload.Maximum;
        }


        private void ImportData(DataTable dt)
        {
            using (Database db = new Database())
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_SYNC_DOWNLOAD_DIRECTOR"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private void ReadFileList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                fileList = FTP.FtpEngine.GetFileList(initDir);


                if (!string.IsNullOrEmpty(_Data))
                {
                    fileList.DefaultView.RowFilter = "FileName LIKE '%" + _Data + "%'";
                }


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


        private void frmDownloadDataISA_Shown(object sender, EventArgs e)
        {
            if (!loaded)
            {
                //lblStatus.Text = "Get FTP Info ...";
                refreshForm();
                ReadFileList();
                loaded = true;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            switch (cboxData.Text)
            {
                case "ALL":
                    _Data = string.Empty;
                    break;
                case "Antar Gudang":
                    _Data = "AG-";

                    break;
                case "DO Antar Cabang":
                    _Data = "OPJ-";

                    break;
                case "Nota Antar Cabang":
                    _Data = "NPJ-";

                    break;
                case "POS":
                    _Data = "POS-";

                    break;
                case "Potongan":
                    _Data = "POT-";

                    break;
                case "HPPA":
                    _Data = "HPPA-";

                    break;
                case "Nota Pembelian Antar Cabang":
                    _Data = "NPB-";

                    break;
            }


            if (!string.IsNullOrEmpty(cboxData.Text))
            {
                ReadFileList();
            }
        }


        private void LinkNota(DataSet ds)
        {



            lblProgress.Text = "Link DATA ...";
            foreach (DataTable dt in ds.Tables)
            {

                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                Linkss(dt);

            }
            pbDownload.Value = pbDownload.Maximum;
        }


        private void Linkss(DataTable dt)
        {
            using (Database db = new Database())
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            if (dr["TableName"].ToString().ToUpper().Equals("NOTAPENJUALAN-RSOPAC"))
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("[psp_SYNC_DOWNLOAD_NotaPenjualan_RSOPAC_LINK]"));
                                db.Commands[0].Parameters.Add(new Parameter("@Doc", SqlDbType.NText, dr["XmlData"].ToString()));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
