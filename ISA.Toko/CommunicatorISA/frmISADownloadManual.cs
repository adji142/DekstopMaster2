using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using ISA.DAL;
using System.IO;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmISADownloadManual : ISA.Toko.BaseForm
    {
        int counter = 0;

        public frmISADownloadManual()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            string _paths = string.Empty;

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = GlobalVar.DbfDownload;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _paths = openFileDialog1.FileName;
                    label1.Text = _paths;
                    if (MessageBox.Show("Download Data ini " + openFileDialog1.FileNames[0].ToString() + " ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataSet ds = ReadData(_paths);

                        

                        lblStatus.Text = "Upload data to ISA ....";
                       
                        refreshForm();                        

                        ProcessTable(ds);
                        
                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                }
            }
        }

        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void ProcessTable(DataSet ds)
        {
            counter = 0;
            pbSyncUpload.Value = 0;
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                ImportData(dt);
                pbSyncUpload.Value = counter;
                lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
            pbSyncUpload.Value = pbSyncUpload.Maximum;
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
    }
}
