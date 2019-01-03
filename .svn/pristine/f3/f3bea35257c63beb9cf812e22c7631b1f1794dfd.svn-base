using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;


namespace ISA.Toko.PO
{
    public partial class PODownload : ISA.Toko.BaseForm
    {

        DataSet ds = new DataSet();
        DataSet dsRefillPO = new DataSet();
        DataSet dsRefillPODetail = new DataSet();
        int counter1 = 0;
        int counter2 = 0;

        int maxRefillPO = 0;
        int maxRefillPODetail = 0;

        public PODownload()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectFile()
        {
            //openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            //if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("PO"))
            //{
            //   ReadData(openFileDialog1.FileName);
            //}
            //else
            //{
            //    MessageBox.Show("Data yang Anda Pilih Bukan Data Refilll PO");
            //    SelectFile();
            //}

            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadData(openFileDialog1.FileName);
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
                            db.Commands.Add(db.CreateCommand("psp_Tools_DOWNLOAD_RefillPO"));
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

            ProcessTable(ds, "RefilPO");

            foreach (DataRow dr1 in dsRefillPO.Tables[0].Rows) 
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = maxRefillPO; 
                

                progressBar1.Increment(1);


                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + maxRefillPO.ToString("#,##0");
                

                refreshForm(); 
            }

            ProcessTable(ds, "RefilPODetail");

            foreach (DataRow dr2 in dsRefillPODetail.Tables[0].Rows)
            {
                counter2++;
                progressBar2.Minimum = 0;
                progressBar2.Maximum = maxRefillPODetail; 

                progressBar2.Increment(1);

                lblDownloadStatus2.Text = counter2.ToString("#,##0") + "/" + maxRefillPODetail.ToString("#,##0");
                refreshForm();
            }

            MessageBox.Show(Messages.Confirm.DownloadSuccess);

        }



        private void LoadRefillPO()
        {            

            try
            {
                string XmlData = ds.Tables["RefilPO"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsRefillPO.ReadXml(sr); 

                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = dsRefillPO.Tables[0];
                maxRefillPO = dsRefillPO.Tables[0].Rows.Count;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Refill PO");
                SelectFile();
            }

            
        }

        private void LoadRefillPODetail()
        {            

            try
            {
                string XmlData = ds.Tables["RefilPODetail"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsRefillPODetail.ReadXml(sr); 

                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = dsRefillPODetail.Tables[0];
                maxRefillPODetail = dsRefillPODetail.Tables[0].Rows.Count; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Refill PO");
                SelectFile();
            }
        }

        private void PODownload_Load(object sender, EventArgs e)
        {
            SelectFile();

            LoadRefillPO();
            LoadRefillPODetail();                                         
        }
    }
}
