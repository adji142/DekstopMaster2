using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;


namespace ISA.Trading.PO
{
    public partial class frmJadwalDownload : ISA.Trading.BaseForm
    {
        DataSet ds = new DataSet();
        DataSet dsJadwalPo = new DataSet();
        int counter1 = 0;
        int maxJadwalPo = 0;


        public frmJadwalDownload()
        {
            InitializeComponent();
        }

        private void frmJadwalDownload_Load(object sender, EventArgs e)
        {
            SelectFile();
            LoadJadwalPO();
        }
        private void SelectFile()
        {
            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("Jadwal_PO-"))
            {
                ReadData(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Jadwal PO");
                SelectFile();
            }
        }

        private DataSet ReadData(string file)
        {
            ds.ReadXml(file);
            return ds;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void ProcessTable(DataSet dspt, string tableName)
        {
            Download(dspt.Tables[tableName]);
        }

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void Download(DataTable dt)
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
                            db.Commands.Add(db.CreateCommand("psp_Tools_DOWNLOAD_JadwalPO"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            ProcessTable(ds, "RefilPO_Jadwal");

            foreach (DataRow dr1 in dsJadwalPo.Tables[0].Rows)
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = maxJadwalPo;
                progressBar1.Increment(1);
                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + maxJadwalPo.ToString("#,##0");
                refreshForm();
            }
            MessageBox.Show(Messages.Confirm.DownloadSuccess);
        }

        private void LoadJadwalPO()
        {

            try
            {
                string XmlData = ds.Tables["RefilPO_Jadwal"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsJadwalPo.ReadXml(sr);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dsJadwalPo.Tables[0];
                maxJadwalPo = dsJadwalPo.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Jadwal PO");
                SelectFile();
            }

        }

    }
}
