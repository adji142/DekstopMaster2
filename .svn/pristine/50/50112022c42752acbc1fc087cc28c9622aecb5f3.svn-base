using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;


namespace ISA.Trading.Fixrute
{
    public partial class frmMasterOutletBaruDownload : ISA.Trading.BaseForm
    {

        DataSet ds = new DataSet();
        DataSet dsFix_tokoob = new DataSet();
        int counter1 = 0;
        int maxOutletBaru = 0;

        public frmMasterOutletBaruDownload()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectFile()
        {
            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains("MasterOutletBaru-"))
            {
               ReadData(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Master Outlet");
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
                            db.Commands.Add(db.CreateCommand("psp_FixNewOutlet_Download"));
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
            ProcessTable(ds, "Fix_tokoob");

            foreach (DataRow dr1 in dsFix_tokoob.Tables[0].Rows) 
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = maxOutletBaru; 
                progressBar1.Increment(1);

                lblDownloadStatus1.Text = counter1.ToString("#,##0") + "/" + maxOutletBaru.ToString("#,##0");
                refreshForm(); 
            }

            MessageBox.Show(Messages.Confirm.DownloadSuccess);

        }



        private void LoadOutletBaru()
        {            

            try
            {
                string XmlData = ds.Tables["Fix_tokoob"].Rows[0]["XmlData"].ToString();

                StringReader sr = new StringReader(XmlData);
                dsFix_tokoob.ReadXml(sr); 

                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = dsFix_tokoob.Tables[0];
                maxOutletBaru = dsFix_tokoob.Tables[0].Rows.Count;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Refill PO");
                SelectFile();
            }

            
        }


        private void frmMasterOutletBaruDownload_Load(object sender, EventArgs e)
        {
            SelectFile();
            LoadOutletBaru();                                        
        }
    }
}
