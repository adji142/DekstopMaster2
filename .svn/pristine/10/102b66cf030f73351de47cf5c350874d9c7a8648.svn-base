using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;


namespace ISA.Trading.CommunicatorISA
{
    public partial class AntarGudangDownload : ISA.Trading.BaseForm
    {

        DataSet ds = new DataSet();
        DataSet dsAntarGudang = new DataSet();
        DataSet dsAntarGudangDetail = new DataSet();
        int counter1 = 0;
        int counter2 = 0;
        
        int maxAntarGudang =0;
        int maxAntarGudangDetail = 0;

        public AntarGudangDownload()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectFile()
        {
            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("AG-"))
            {
               ReadData(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Antar Gudang");
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


        private void ProcessTable(DataSet dspt,string tableName)
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
                            db.Commands.Add(db.CreateCommand("psp_Tools_DOWNLOAD_AntarGudang_ISA"));
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
            

            ProcessTable(ds, "AntarGudang");

            foreach (DataRow dr1 in dsAntarGudang.Tables[0].Rows)
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = maxAntarGudang;
                

                progressBar1.Increment(1);
                

                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + maxAntarGudang.ToString("#,##0");
                

                refreshForm(); 
            }

            ProcessTable(ds, "AntarGudangDetail");

            foreach(DataRow dr2 in dsAntarGudangDetail.Tables[0].Rows)
            {
                counter2++;
                progressBar2.Minimum = 0;
                progressBar2.Maximum = maxAntarGudangDetail;

                progressBar2.Increment(1);

                lblDownloadStatus2.Text = counter2.ToString("#,##0") + "/" + maxAntarGudangDetail.ToString("#,##0");
                refreshForm();
            }

            MessageBox.Show(Messages.Confirm.DownloadSuccess);

        }



        private void LoadAntarGudang()
        {            

            try
            {
                string XmlData = ds.Tables["AntarGudang"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsAntarGudang.ReadXml(sr);

                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = dsAntarGudang.Tables[0];
                maxAntarGudang = dsAntarGudang.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Antar Gudang");
                SelectFile();
            }

            
        }

        private void LoadAntarGudangDetail()
        {            

            try
            {
                string XmlData = ds.Tables["AntarGudangDetail"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsAntarGudangDetail.ReadXml(sr);

                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = dsAntarGudangDetail.Tables[0];
                maxAntarGudangDetail = dsAntarGudangDetail.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Antar Gudang");
                SelectFile();
            }

            
        }

        private void AntarGudangDownload_Load(object sender, EventArgs e)
        {
            SelectFile();

            LoadAntarGudang();
            LoadAntarGudangDetail();                                         
        }
    }
}
