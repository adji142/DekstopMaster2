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
    public partial class frmPosUpload : ISA.Trading.BaseForm
    {
        DataSet dsResult = new DataSet();
        int jumlahTable = 39;
        int uploadTable = 0;
        int counter = 0;

        public frmPosUpload()
        {
            InitializeComponent();
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
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "POS-"+GlobalVar.Gudang+" " + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
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


        private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using(Database db = new Database())
            {

                #region Toko
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Toko"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Toko";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Toko";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region StatusToko
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_StatusToko"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "StatusToko";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "StatusToko";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Sales
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Sales"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Sales";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Sales";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Stok
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Stok"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Stok";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Stok";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Expedisi
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Expedisi"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Expedisi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Expedisi";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[4].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Pemasok
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Pemasok"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Pemasok";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Pemasok";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[5].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region OpnameHistory
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_OpnameHistory"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OpnameHistory";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "OpnameHistory";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[6].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion




                #region Mutasi
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Mutasi"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Mutasi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Mutasi";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[7].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region MutasiDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_MutasiDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "MutasiDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "MutasiDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[8].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region AntarGudang
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_AntarGudang"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudang";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Antar Gudang";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[9].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region AntarGudangDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_AntarGudangDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudangDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Antar Gudang Detail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[10].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region Peminjaman
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Peminjaman"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Peminjaman";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Peminjaman";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[11].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region PeminjamanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_PeminjamanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PeminjamanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PeminjamanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[12].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region Pengembalian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Pengembalian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Pengembalian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Pengembalian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[13].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region PengembalianDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_PengembalianDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PengembalianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PengembalianDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[14].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region OrderPembelian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_OrderPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "OrderPembelian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[15].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region OrderPembelianDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_OrderPembelianDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "OrderPembelianDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[16].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region NotaPembelian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_NotaPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPembelian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[17].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region NotaPembelianDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_NotaPembelianDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPembelianDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[18].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPembelian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ReturPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPembelian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[19].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region ReturPembelianDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ReturPembelianDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPembelianDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[20].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KoreksiPembelian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_KoreksiPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Koreksi Pembelian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[21].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KoreksiReturPembelian
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_KoreksiReturPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiReturPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Koreksi Retur Pembelian";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[22].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region OrderPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_OrderPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "OrderPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[23].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region OrderPenjualanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_OrderPenjualanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "OrderPenjualanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[24].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Kompensasi
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_Kompensasi"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Kompensasi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Kompensasi";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[25].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region NotaPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_NotaPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[26].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region NotaPenjualanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_NotaPenjualanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "NotaPenjualanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[27].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ReturPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[28].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region ReturPenjualanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ReturPenjualanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[29].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;


            
                #endregion


                #region PenjualanPotongan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_PenjualanPotongan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PenjualanPotongan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PenjualanPotongan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[30].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KoreksiPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_KoreksiPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Koreksi Penjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[31].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion
                


                #region KoreksiReturPenjualan
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_KoreksiReturPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Koreksi Retur Penjualan";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[32].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion                                                                                                              



                #region RekapKoli
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_RekapKoli"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoli";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "RekapKoli";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[33].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region RekapKoliDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_RekapKoliDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoliDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "RekapKoliDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[34].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region RekapKoliSubDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_RekapKoliSubDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoliSubDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "RekapKoliSubDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[35].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion
                                                                                                                                               
#region ReturPenjualanTarikanDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ReturPenjualanTarikanDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanTarikanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPenjualanTarikanDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[36].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
#endregion

                #region ReturPembelianManualDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("[psp_POS_UPLOAD_ISA_ReturPembelianManualDetail]"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelianManualDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ReturPembelianManualDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[37].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion

                #region ClosingStokSaldo
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_ISA_ClosingStokSaldo"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ClosingStokSaldo";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "ClosingStokSaldo";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[38].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion
            }

            return ds;

        }


        private void frmPosUpload_Load(object sender, EventArgs e)
        {
            rgbTanggal.FromDate = DateTime.Now.Date;
            rgbTanggal.ToDate = DateTime.Now.Date;
            //txtTujuan.Text = LookupInfo.GetValue("FTP", "FTP_COCKPIT");

            if (SecurityManager.IsManager() || SecurityManager.IsAdministrator())
                cmdStartUpload.Enabled = true;
            else
                cmdStartUpload.Enabled = false;

        }
    }
}
