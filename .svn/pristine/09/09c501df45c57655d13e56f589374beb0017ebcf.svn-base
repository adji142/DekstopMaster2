using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.FTP;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmUploadVcAccDOPos : ISA.Trading.BaseForm
    {
        public frmUploadVcAccDOPos()
        {
            InitializeComponent();
        }

        private void frmUploadVcAccDOPos_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.Date;
            rangeDateBox1.ToDate = DateTime.Now.Date;            
            gridVCAccDOPos.AutoGenerateColumns = true;            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            DataTable dt = new DataTable();
            progressBar1.Value = 0;            

            try
            {

                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("usp_VCACCDO_POS_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cPerusahaan", SqlDbType.VarChar, txtPOS.Text));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        gridVCAccDOPos.DataSource = dt;                        
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada");
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
                db.Commands.Add(db.CreateCommand("psp_VCACCDO_POS_Upload_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                db.Commands[0].Parameters.Add(new Parameter("@cPerusahaan", SqlDbType.VarChar, txtPOS.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {                    
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = ds.Tables[0].Rows.Count;


                    progressBar1.Increment(1);
                }
                


            }
            return ds;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    string Target = "09JKT_DEV";
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "VACCDOPOS-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);

                    if (FTP.FtpEngine.Upload(Target, fileOuput))
                    {

                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.UploadFailed);
                    }
                }
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
