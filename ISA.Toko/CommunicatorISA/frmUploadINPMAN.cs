using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using ISA.DAL;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.FTP;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmUploadINPMAN : ISA.Toko.BaseForm
    {
        int counter = 0;
        DataSet dsResult = new DataSet();
       
        ErrorProvider err = new ErrorProvider();
        public frmUploadINPMAN()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    string Target = txtTarget.Text;
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "INPMAN-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
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


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }


        //private void ZipFile(List<string> files)
        //{
        //    string fileZipName = GlobalVar.DbfUpload + "\\" + ZipName + ".zip";

        //    if (File.Exists(fileZipName))
        //    {
        //        File.Delete(fileZipName);
        //    }

        //    Zip.ZipFiles(files, fileZipName);

        //    foreach (string str in files)
        //    {
        //        if (File.Exists(str))
        //        {
        //            File.Delete(str);
        //        }
        //    }
        //}

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadINPMAN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime (DateTime.Now.Year, DateTime.Now.Month,1);
            rangeDateBox1.ToDate = ((DateTime) rangeDateBox1.FromDate).AddMonths(1).AddDays(-1);
            txtTarget.Text = AppSetting.GetValue("PUSAT_11");
        }

        private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "INPMAN";
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


    }
}
