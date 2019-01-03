using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.FTP;


namespace ISA.Toko.CommunicatorISA
{
    public partial class frmAntarGudangUpload : ISA.Toko.BaseForm
    {
        DataSet dsResult = new DataSet();
            DateTime Date;            
            int counter1 = 0;
            int counter2 = 0;
            int maxAntarGudang = 0;
            int maxAntarGudangDetail = 0;

        public frmAntarGudangUpload()
        {
            InitializeComponent();
        }

        private void frmAntarGudangUpload_Load(object sender, EventArgs e)
        {

            txtGudangAsal.Text = GlobalVar.Gudang;
            txtGudangAsal.ReadOnly = true;
            Date = DateTime.Now;
            txtTahun.Text = DateTime.Now.Year.ToString();
            cboBulan.Text = DateTime.Now.Month.ToString();            
            dataGridHeader.AutoGenerateColumns = true;
            dataGridDetail.AutoGenerateColumns = true;
            cboBulan.Focus();

        }


        public void RefreshData()
        {
            HeaderprogressBar.Value = 0;
            DetailprogressBar.Value = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dss = new DataSet();
                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Date));
                    db.Commands[0].Parameters.Add(new Parameter("@drGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    dss = db.Commands[0].ExecuteDataSet();

                    dataGridHeader.DataSource = dss.Tables[0];
                    dataGridDetail.DataSource = dss.Tables[1];


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

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }


        private DataSet GetSyncData()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_AntarGudang_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Date));
                db.Commands[0].Parameters.Add(new Parameter("@drGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudang";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter1++;
                    HeaderprogressBar.Minimum = 0;
                    HeaderprogressBar.Maximum = ds.Tables[0].Rows.Count;


                    HeaderprogressBar.Increment(1);
                }


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_AntarGudangDetail_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Date));
                db.Commands[0].Parameters.Add(new Parameter("@drGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudangDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    counter2++;
                    DetailprogressBar.Minimum = 0;
                    DetailprogressBar.Maximum = ds.Tables[1].Rows.Count;


                    DetailprogressBar.Increment(1);
                }


            }
            return ds;
        }


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (lookupGudang.GudangID == "")
            {
                lookupGudang.Focus();
                return;
            }
            Date = new DateTime(Convert.ToInt32(txtTahun.Text), Convert.ToInt32(cboBulan.Text), 1);
            GetSyncData();
            RefreshData();
        }
                

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupGudang_SelectData(object sender, EventArgs e)
        {
            if (lookupGudang.GudangID == GlobalVar.Gudang)
            {
                MessageBox.Show("Gudang Tujuan Tidak Boleh Sama Dengan Gudang Asal !");
                this.DialogResult = DialogResult.OK;
                lookupGudang.NamaGudang = "";
                lookupGudang.GudangID = "";
                lookupGudang.Focus();
                return;
            }

            if (Tools.Left(lookupGudang.GudangID.ToString(), 2) != GlobalVar.CabangID)
            {
                MessageBox.Show("Hanya Antar Cabang !");
                this.DialogResult = DialogResult.OK;
                lookupGudang.NamaGudang = "";
                lookupGudang.GudangID = "";
                lookupGudang.Focus();
                return;
            }
        }

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim() == "")
            {
                lookupGudang.GudangID = "";
                lookupGudang.KodeCabang = "";
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {

                    string pathString = @"c:\temp\upload";

                    if (!System.IO.Directory.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }

                    string Target = lookupGudang.GudangID;

                    // string fileOuput =  FtpEngine.UploadDirectory + "\\" + "AG-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                    string fileOuput = pathString + "\\" + "AG-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                    ds.WriteXml(fileOuput);

                    MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);

                } 
                    //if (FTP.FtpEngine.Upload(Target, fileOuput))
                    //{
                        
                    //    MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                    //}
                    //}
                    //else
                    //{
                    //    MessageBox.Show(Messages.Confirm.UploadFailed);
                    //}
                
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
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

        private void lookupGudang_Load(object sender, EventArgs e)
        {

        }



    }
}
