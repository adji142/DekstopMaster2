using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.FTP;

namespace ISA.Finance.Kasir
{
    public partial class frmKasirUploadDownloadISA : ISA.Finance.BaseForm
    {

        DataSet dsResult = new DataSet();
        int jumlahTable = 24;
        int uploadTable = 0;
        int counter = 0;

        public frmKasirUploadDownloadISA()
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
                    string Target = lookupGudang1.GudangID;
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "KASIR-" +GlobalVar.PerusahaanID + " "+ DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
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


        private void UploadCount()
        {
            uploadTable++;
            lblUpload.Text = uploadTable.ToString() + "/" + jumlahTable.ToString();
            pbSyncUpload.Minimum = 0;
            pbSyncUpload.Maximum = jumlahTable;
            pbSyncUpload.Increment(1);
        }

        private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database(GlobalVar.DBName))
            {

                /*
                #region TokoToSales
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_TokoToSales"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "TokoToSales";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "TokoToSales";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion

                */
                #region Staff
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Staff"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Staff";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Staff";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Bank
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Bank"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Bank";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Bank";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Kasbon
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Kasbon"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Kasbon";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Kasbon";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region Inden
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Inden"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Inden";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Inden";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region VoucherJournal
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_VoucherJournal"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "VoucherJournal";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "VoucherJournal";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[4].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KartuPiutang
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_KartuPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KartuPiutang";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "KartuPiutang";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[5].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region TransferBank
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_TransferBank"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "TransferBank";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "TransferBank";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[6].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region IndenDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_IndenDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "IndenDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "IndenDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[7].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region VoucherJournalDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_VoucherJournalDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "VoucherJournalDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "VoucherJournalDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[8].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region BBM
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_BBM"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "BBM";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "BBM";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[9].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region Giro
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Giro"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Giro";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Giro";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[10].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region TransferBankDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_TransferBankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "TransferBankDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "TransferBankDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[11].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region BankDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_BankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "BankDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "BankDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[12].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region Bukti
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_Bukti"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Bukti";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "Bukti";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[13].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region BuktiDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_BuktiDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "BuktiDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "BuktiDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[14].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region PinjamanPegawai
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_PinjamanPegawai"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PinjamanPegawai";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "PinjamanPegawai";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[15].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region IndenSubDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_IndenSubDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "IndenSubDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "IndenSubDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[16].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion



                #region GiroTolak
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_GiroTolak"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "GiroTolak";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "GiroTolak";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[17].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region IndenSuperDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_IndenSuperDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "IndenSuperDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "IndenSuperDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[18].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region KartuPiutangDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_KartuPiutangDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KartuPiutangDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "KartuPiutangDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[19].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region GiroTolakDetail
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_GiroTolakDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "GiroTolakDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "GiroTolakDetail";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[20].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion


                #region BBK
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_BBK"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "BBK";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "BBK";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[21].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion
               

                                                                                                                                                                                                                             
                #region GiroInternal
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NEW_ISA_KASIR_UPLOAD_GiroInternal"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "GiroInternal";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                label1.Text = "GiroInternal";
                UploadCount();
                foreach (DataRow dr1 in ds.Tables[22].Rows)
                {
                    counter++;
                    lblUploadCount.Text = counter.ToString();
                }
                counter = 0;
                #endregion

                                                                
                

            }

            return ds;

        }

        private void frmKasirUploadDownloadISA_Load(object sender, EventArgs e)
        {
            rgbTanggal.FromDate = DateTime.Now.Date;
            rgbTanggal.ToDate = DateTime.Now.Date;
            lookupGudang1.GudangID = string.Empty;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
