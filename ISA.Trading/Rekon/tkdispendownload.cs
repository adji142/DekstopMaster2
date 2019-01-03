using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;

namespace ISA.Trading.Rekon
{
    public partial class tkdispendownload : ISA.Trading.BaseForm
    {
        DataSet ds = new DataSet();
        DataSet dstokodispen = new DataSet();

        int counter1 = 0;
        
        int maxtokodispen =0;
    
        public tkdispendownload()
        {
            InitializeComponent();
        }

        private void SelectFile()
        {
            openFileDialog1.InitialDirectory = "C:/temp/download"; //LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
  
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("TKD-"))
            {
                ReadData(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Toko Dispensasi");
      //          SelectFile();
            }
        }

        private DataSet ReadData(string file)
        {
            ds.ReadXml(file);
            return ds;
        }


        private void ProcessTable(DataSet dspt, string tableName)
        {
            Download(dspt.Tables[tableName]);
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
                            db.Commands.Add(db.CreateCommand("psp_Tools_DOWNLOAD_TokoDispen_ISA"));
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
  
            ProcessTable(ds, "tokodispen");

            foreach (DataRow dr1 in dstokodispen.Tables[0].Rows)
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = maxtokodispen;

                progressBar1.Increment(1);

                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + maxtokodispen.ToString("#,##0");


                refreshForm(); 
            }

            MessageBox.Show(Messages.Confirm.DownloadSuccess);

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tkdispendownload_Load(object sender, EventArgs e)
        {
            try
            {
                SelectFile();
                string XmlData = ds.Tables["tokodispen"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dstokodispen.ReadXml(sr);

                customGridView1.AutoGenerateColumns = true;
                customGridView1.DataSource = dstokodispen.Tables[0];
                maxtokodispen = dstokodispen.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Toko Dispensasi");
                SelectFile();
            }

        }

        private void refreshForm()
        {
            this.Refresh();
          //  this.Invalidate();
            Application.DoEvents();
        }

    }
}
