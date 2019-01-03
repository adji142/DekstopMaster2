using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmDownloMasterData : ISA.Toko.BaseForm
    {
        DataSet dsXML = new DataSet();
        string _FileName;
        int _Count = 0;

        public frmDownloMasterData()
        {
            InitializeComponent();
        }

        private void frmDownloMasterData_Load(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void SelectFile()
        {
            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("TokoUpload-"))
            {
                dsXML = ReadData(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Toko");
                SelectFile();
            }
        }

        private DataSet ReadData(string file)
        {
            DataSet ds = new DataSet();

            ds.ReadXml(file);
            return ds;
        }


        public void RefreshStatus(string status)
        {
            lblCtr.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = status;            
            pbDownload.Value = 0;
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            try
            {                

                DownloadToko(dsXML.Tables["Toko"]);
                DownloadToko(dsXML.Tables["StatusToko"]);

                

                MessageBox.Show(Messages.Confirm.DownloadSuccess);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Toko");
            }

        }


        private void DownloadToko(DataTable dt)
        {
            RefreshStatus("Downloading Toko...");

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

                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = dt.Rows.Count;
                    pbDownload.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/2";

        }


        private void DownloadStatusToko(DataTable dt)
        {
            RefreshStatus("Downloading StatusToko...");

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

                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = dt.Rows.Count;
                    pbDownload.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/2";

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
