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
    public partial class frmUploadRSOPAC : ISA.Toko.BaseForm
    { 

        DataSet dsResult = new DataSet();
        int jumlahTable = 9; 
        int uploadTable = 0;
        int counter = 0;

        public frmUploadRSOPAC()
        {
            InitializeComponent();
        }

        private void frmUploadRSOPAC_Load(object sender, EventArgs e)
        {
            rgbTanggal.FromDate = DateTime.Now.Date;
            rgbTanggal.ToDate = DateTime.Now.Date;

            if (SecurityManager.IsManager() || SecurityManager.IsAdministrator())
                cmdStartUpload.Enabled = true;
            else
                cmdStartUpload.Enabled = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadCount()
        {
            uploadTable++;
            lblUpload.Text = uploadTable.ToString() + "/" + jumlahTable.ToString();
            pbSyncUpload.Minimum = 0;
            pbSyncUpload.Maximum = jumlahTable;
            pbSyncUpload.Increment(1);
        }

        private void cmdStartUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    string Target = lookupGudang1.GudangID;
                   // string fileOuput = FtpEngine.UploadDirectory + "\\" + "RSOPAC-" + GlobalVar.Gudang + " " + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    string fileOuput = FtpEngine.UploadDirectory+"\\RSOPAC-" + GlobalVar.Gudang +lookupGudang1.GudangID+ " " + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);

                    //if (FTP.FtpEngine.Upload(Target, fileOuput))
                    //{

                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(Messages.Confirm.UploadFailed);
                    //}
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
        
        private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {

                #region NotaPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_NotaPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region NotaPenjualanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_NotaPenjualanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPenjualanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KoreksiPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_KoreksiPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "KoreksiPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region PenjualanPotongan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_PenjualanPotongan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PenjualanPotongan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PenjualanPotongan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region PenjualanPotonganDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_PenjualanPotonganDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PenjualanPotonganDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PenjualanPotonganDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[4].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_ReturPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[5].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPenjualanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_ReturPenjualanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[6].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPenjualanTarikanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_ReturPenjualanTarikanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanTarikanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualanTarikanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[7].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KoreksiReturPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_RSOPAC_UPLOAD_ISA_KoreksiReturPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang1.GudangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "KoreksiReturPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[8].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion
            }

            return ds;

        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
