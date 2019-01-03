using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using ISA.DAL;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmUploadHPPA : ISA.Toko.BaseForm
    {

        int counter = 0;
        DataSet dsResult = new DataSet();

        public frmUploadHPPA()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                
                refreshForm();
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    
                    refreshForm();
                    
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "HPPA-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
                    
                    refreshForm();
                    if (FTP.FtpEngine.Upload(lookupGudang1.GudangID, fileOuput))
                    {                        
                        refreshForm();                        
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

        private void frmUploadHPPA_Load(object sender, EventArgs e)
        {
            lookupGudang1.GudangID = string.Empty;
            customGridView1.AutoGenerateColumns = true;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }


        private void RefreshData()
        {
            progressBar1.Value = 0;

            try
            {

                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("usp_HistoryHPPA_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));                    
                    dsResult = db.Commands[0].ExecuteDataSet();

                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        customGridView1.DataSource = dsResult.Tables[0];
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

                              
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_ISA_UPLOAD_HISTORYHPPA"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "HistoryHPPA";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter++;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = ds.Tables[0].Rows.Count;
                    progressBar1.Increment(1);
                }
            }
            return ds;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
