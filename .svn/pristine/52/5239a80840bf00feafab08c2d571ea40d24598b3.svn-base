using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;
using System.Data.SqlClient;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Globalization;
using ISA.Finance.Class;


namespace ISA.Finance.Tac
{
    public partial class frmTACdownload : ISA.Controls.BaseForm
    {
        string fileZIPName = string.Empty;
        int ctr = 0;
        protected DataTable
        TokoDt,
        KartuPiutangDt,
        KartuPiutangDetailDt,
        SalesDt,
        StatusTokoDt,
        PlafonDt,
        AccountTokoDt,
        BarcodeNotaDt,
        GiroTolakDt,
        GiroTolakDetailDt;

        DataSet dsData = new DataSet();
        DataSet dsw; 
        //string Depo = "SUKABUMI";
        //string Depo = "BALI";
        string versi = "1";
        string Depo = "PATI";
        string wilx = "";
        string wiln = "";
        string cIdwil = "";


        public frmTACdownload()
        {
            InitializeComponent();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTACdownload_Load(object sender, EventArgs e)
        {

        }

        public void RefreshStatus(string status, int ctr)
        {
            LabelStatus.Text = status;
            lblCtr.Text = ctr.ToString().Trim() + "/ 10";
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            //if (lblPath.Text == "Path")
            //{
            //    MessageBox.Show("Pilih Lokasi File..!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (MessageBox.Show("Proses Download ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                ctr = 0;
                try
                {
                    fileZIPName = GlobalVar.DbfDownload+"\\DATATAC.ZIP";    // lblPath.Text;
                    UnzipFile();
                    TokoDownload_Load();
                    KartuPiutangDownload_Load();
                    KartuPiutangDetailDownload_Load();
                    SalesDownload_Load();
                    StatusTokoDownload_Load();
                    PlafonTokoDownload_Load();
                    AccountTokoDownload_Load();
                    BarcodeNotaDownload_Load();
                    GiroTolakDownload_Load();
                    GiroTolakDetailDownload_Load();

                    DisplayReport();
                    ////ExecDelete();

                    if (Directory.Exists(GlobalVar.DbfDownload + "\\TacDownloadtmp"))
                    {
                        string[] files = Directory.GetFiles(GlobalVar.DbfDownload + "\\TacDownloadtmp");
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                    }
                    MessageBox.Show("TAC Download Selesai");
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                    LabelStatus.Text = "";
                }
            }
        }


        private bool UnzipFile()
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\TacDownloadtmp";

            if (!Directory.Exists(extractFileLocation))
            {
                Directory.CreateDirectory(extractFileLocation);
            }
            else
            {
                string[] files = Directory.GetFiles(extractFileLocation);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }


            if (File.Exists(fileZIPName))
            {
                Zip.UnZipFiles(fileZIPName, extractFileLocation, false);
                retVal = true;
            }
            else
            {
                //pbSyncDownload.Enabled = false;
                MessageBox.Show("File: " + fileZIPName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Pos Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }


        private void ExecDelete()
        {
            string depan = GlobalVar.DbfDownload + "\\TacDownloadtmp\\";
            string belakang = "Tmp" + GlobalVar.CabangID + ".DBF";
            string fileName;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fileName = "TokoTac.dbf"; TableDelete(fileName, "Toko", "KodeToko", "kd_toko");
                fileName = "KartuPiutangTac.dbf"; TableDelete(fileName, "KartuPiutang", "RowID", "RowID");
                fileName = "KartuPiutangDetailTac.dbf"; TableDelete(fileName, "KartuPiutangDetail", "RowID", "RowID");
                fileName = "SalesTac.dbf"; TableDelete(fileName, "Sales", "SalesID", "kd_sales");
                fileName = "StatusTokoTac"; TableDelete(fileName, "StatusToko", "RowID", "RowID");
                fileName = "PlafonTac.dbf"; TableDelete(fileName, "TokoPlafon", "KodeToko", "Kd_toko");
                fileName = "AccountTokoTac.dbf"; TableDelete(fileName, "AccountToko", "KodeToko", "Kd_toko");
                fileName = "BarcodeNotaTac.dbf"; TableDelete(fileName, "BarcodeNota", "RowID", "RowID");
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


        private void TableDelete(string fileName, string tableName, string isaColName, string foxproColName)
        {
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TAC_DELETE_TABLE"));
                foreach (DataRow dr in dt.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }



        #region  0.Download Tokotac04
        private void TokoDownload04_Load()
        {
            string fileName = "TacDownloadtmp\\TokoTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Toko Tac", ctr);
            this.Refresh();
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        TokoDt = Foxpro.ReadFile(fileName);
                        dsData.Tables.Add(TokoDt);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TokoDt.Rows.Count;
                        DownloadTokoTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        TokoDt.Dispose();
                    }
                }
            }
        }
        #endregion




        #region  0.Download Tokotac
        private void TokoDownload_Load()
        {
            string fileName = "TacDownloadtmp\\TokoTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Toko Tac",ctr);
            this.Refresh();
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        TokoDt = Foxpro.ReadFile(fileName);
                        dsData.Tables.Add(TokoDt);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TokoDt.Rows.Count;
                        DownloadTokoTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        TokoDt.Dispose();
                    }
                }
            }
        }


        public void DownloadTokoTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_Toko_TAC"));
                foreach (DataRow dr in TokoDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    string Bangunan_ = "", produk_ = "", pemilik_ = "", kelamin_ = "", tempatlhr_ = "", email_ = "",
                           norekening_ = "", banktac_, nomember_ = "", hobi_ = "", no_npwp_ = "", mediabyr_ = "",
                           ketbayar_ = "", lub_ = "MANAGER", fax_ = "";
                    int angsuran_ = 0;
                    DateTime? hbskont_ = null, lut_ = null;

                    RowID_ = new Guid(dr["RowID"].ToString());
                    fax_ = Tools.isNull(dr["Fax"], "").ToString();
                    Bangunan_ = Tools.isNull(dr["Bangunan"], "").ToString();
                    produk_ = Tools.isNull(dr["Produk"], "").ToString();
                    pemilik_ = Tools.isNull(dr["Pemilik"], "").ToString();
                    kelamin_ = Tools.isNull(dr["Kelamin"], "").ToString();
                    tempatlhr_ = Tools.isNull(dr["Tempat_lhr"], "").ToString();
                    email_ = Tools.isNull(dr["Email"], "").ToString();
                    norekening_ = Tools.isNull(dr["Norekening"], "").ToString();
                    banktac_ = Tools.isNull(dr["Nama_bank"], "").ToString();
                    nomember_ = Tools.isNull(dr["No_member"], "").ToString();
                    hobi_ = Tools.isNull(dr["Hobi"], "").ToString();
                    no_npwp_ = Tools.isNull(dr["No_npwp"], "").ToString();
                    mediabyr_ = Tools.isNull(dr["Mediabyr"], "").ToString();
                    angsuran_ = Convert.ToInt32(Tools.isNull(dr["Angsuran"], "0").ToString());
                    ketbayar_ = Tools.isNull(dr["Ketbayar"], "").ToString();
                    lub_ = Tools.isNull(dr["Lub"], "").ToString();
                    lut_ = Convert.ToDateTime(Tools.isNull(dr["Lut"], "").ToString());

                    if (versi == "1")
                    {
                        if (cekIdwil.Checked)
                        {
                            wilx = Tools.isNull(dr["idwil"], "").ToString();
                            int Pnj = wilx.ToString().Trim().Length;

                            /*cek lagi untuk depo yg punya lebar wilid = 8*/
                            if (Pnj <= 7)
                                wiln = wil.Text.ToString().Trim() + wilx.Substring(1, 6);
                            else
                                wiln = wil.Text.ToString().Trim() + wilx.Substring(1, 7);


                            this.Cursor = Cursors.WaitCursor;
                            DataSet dsw = new DataSet();
                            try
                            {
                                using (Database db1 = new Database(GlobalVar.DBName))
                                {
                                    db1.Commands.Add(db.CreateCommand("usp_Tac_GetDataIdwil"));
                                    db1.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                    db1.Commands[0].Parameters.Add(new Parameter("@Idwil", SqlDbType.VarChar, wiln));
                                    dsw = db1.Commands[0].ExecuteDataSet();
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }

                            if (dsw.Tables[1].Rows.Count > 0 && dsw.Tables[0].Rows.Count > 0)
                            {
                                String wilt = Tools.isNull(dsw.Tables[1].Rows[0]["WilID"], "").ToString();
                                int Pnjt = wilt.ToString().Trim().Length;
                                if (Pnj <= 7)
                                {
                                    string cWil = dsw.Tables[0].Rows[0]["WilID"].ToString().Trim();
                                    int nWil = int.Parse(cWil.Substring(3, 4)) + 1;
                                    wiln = wil.Text.ToString().Trim() + cWil.Substring(1, 1) + "-" + nWil.ToString().PadLeft(4, '0');
                                }
                                else
                                {
                                    string cWil = dsw.Tables[0].Rows[0]["WilID"].ToString().Trim();
                                    string cWil8 = Tools.isNull(dsw.Tables[0].Rows[0]["WilID"].ToString().Trim().Substring(7,1),"").ToString();
                                    int nWil = int.Parse(cWil.Substring(3, 4)) + 1;
                                    wiln = wil.Text.ToString().Trim() + cWil.Substring(2, 1) + "-" + nWil.ToString().PadLeft(4, '0')+cWil8;
                                }
                            }
                        }
                        else
                        {
                            wilx = Tools.isNull(dr["idwil"], "").ToString();
                            wiln = wilx;
                        }
                    }

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@idToko", SqlDbType.VarChar, Tools.isNull(dr["idtoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, Tools.isNull(dr["NamaToko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["Alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, Tools.isNull(dr["Daerah"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, Tools.isNull(dr["Propinsi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@noTelp", SqlDbType.VarChar, Tools.isNull(dr["notelp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@idWil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@pngJwb", SqlDbType.VarChar, Tools.isNull(dr["pngjwb"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@kd_Toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@piutang_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["Piutang_B"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@piutang_j", SqlDbType.Money, double.Parse(Tools.isNull(dr["Piutang_J"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["Plafon"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@to_jual", SqlDbType.Money, double.Parse(Tools.isNull(dr["To_Jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@to_retpot", SqlDbType.Money, double.Parse(Tools.isNull(dr["To_RetPot"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@jkw_kredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["Jkw_Kredit"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@tgl1st", SqlDbType.DateTime, Tools.isNull(dr["Tgl1st"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@exist", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["Exist"], false).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lpasif"], false).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@idclass", SqlDbType.VarChar, Tools.isNull(dr["idclass"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.Bit, int.Parse("0")));
                        db.Commands[0].Parameters.Add(new Parameter("@hari_krm", SqlDbType.Int, int.Parse(Tools.isNull(dr["Hari_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@grade", SqlDbType.VarChar, Tools.isNull(dr["Grade"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@plafon_1st", SqlDbType.Money, double.Parse(Tools.isNull(dr["Plafon_1st"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, Tools.isNull(dr["Flag"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@hari_sls", SqlDbType.Int, int.Parse(Tools.isNull(dr["Hari_sls"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@cab2", SqlDbType.VarChar, Tools.isNull(dr["Cab2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@alm_rumah", SqlDbType.VarChar, Tools.isNull(dr["alm_rumah"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@pengelola", SqlDbType.VarChar, Tools.isNull(dr["Pengelola"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tgl_lahir", SqlDbType.DateTime, Tools.isNull(dr["Tgl_Lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@hp", SqlDbType.VarChar, Tools.isNull(dr["HP"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, Tools.isNull(dr["Status"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@th_berdiri", SqlDbType.VarChar, Tools.isNull(dr["Th_Berdiri"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@lruko", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lruko"], false).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@jml_cabang", SqlDbType.Int, int.Parse(Tools.isNull(dr["Jml_Cabang"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@jml_sales", SqlDbType.Int, int.Parse(Tools.isNull(dr["Jml_Sales"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@kinerja", SqlDbType.VarChar, Tools.isNull(dr["Kinerja"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@reff_sls", SqlDbType.VarChar, Tools.isNull(dr["Reff_sls"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@reff_col", SqlDbType.VarChar, Tools.isNull(dr["Reff_col"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@reff_spv", SqlDbType.VarChar, Tools.isNull(dr["Reff_spv"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_survey", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_survey"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@bdg_usaha", SqlDbType.VarChar, Tools.isNull(dr["bdg_usaha"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, fax_));
                        db.Commands[0].Parameters.Add(new Parameter("@bangunan", SqlDbType.VarChar, Bangunan_));
                        db.Commands[0].Parameters.Add(new Parameter("@habis_kontrak", SqlDbType.DateTime, DBNull.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@jenis_produk", SqlDbType.VarChar, produk_));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, pemilik_));
                        db.Commands[0].Parameters.Add(new Parameter("@jenis_kelamin", SqlDbType.VarChar, kelamin_));
                        db.Commands[0].Parameters.Add(new Parameter("@tempat_lhr", SqlDbType.VarChar, tempatlhr_));
                        db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, email_));
                        db.Commands[0].Parameters.Add(new Parameter("@no_rekening", SqlDbType.VarChar, norekening_));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_bank", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, nomember_));
                        db.Commands[0].Parameters.Add(new Parameter("@hobi", SqlDbType.VarChar, hobi_));
                        db.Commands[0].Parameters.Add(new Parameter("@no_npwp", SqlDbType.VarChar, no_npwp_));
                        db.Commands[0].Parameters.Add(new Parameter("@mediaByr", SqlDbType.VarChar, mediabyr_));
                        db.Commands[0].Parameters.Add(new Parameter("@Angsuran", SqlDbType.Money, angsuran_));
                        db.Commands[0].Parameters.Add(new Parameter("@ketBayar", SqlDbType.VarChar, ketbayar_));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].Parameters.Add(new Parameter("@wilx", SqlDbType.VarChar, wilx));
                        //db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, Tools.isNull(dr["tanggal"], DBNull.Value)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  1.Download KartuPiutangTac
        private void KartuPiutangDownload_Load()
        {
            string fileName = "TacDownloadtmp\\KartuPiutangTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading KartuPiutang Tac", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        KartuPiutangDt = Foxpro.ReadFile(fileName);
                        dsData.Tables.Add(KartuPiutangDt);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = KartuPiutangDt.Rows.Count;
                        DownloadKartuPiutangTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        KartuPiutangDt.Dispose();
                    }
                }
            }
        }


        public void DownloadKartuPiutangTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_KartuPiutang_TAC"));
                foreach (DataRow dr in KartuPiutangDt.Rows)
                {
                    //Guid RowID_ = new Guid(dr["RowID"].ToString());
                    Guid RowID_ = Guid.NewGuid();
                    string status_ = "OPEN", namatoko_ = "", wilid_ = "", lub_ = "MANAGER";
                    int saldo_ = Convert.ToInt32(Tools.isNull(dr["Saldo"], "").ToString());
                    //int saldo_ = Convert.ToInt32(Tools.isNull(dr["Rp_sisa"], "").ToString());
                    double cicil_ = 0;
                    DateTime? tgltr_ = Convert.ToDateTime(Tools.isNull(dr["tgl_tr"], null));
                    DateTime? tgllink_ = Convert.ToDateTime(Tools.isNull(dr["tgl_tr"], null));
                    DateTime? tgljt_ = Convert.ToDateTime(Tools.isNull(dr["tgl_jt"], null));

                    RowID_ = new Guid(dr["RowID"].ToString());
                    tgllink_ = Convert.ToDateTime(Tools.isNull(dr["tgl_tr"], null).ToString());
                    status_ = Tools.isNull(dr["Status"], "").ToString().Trim();
                    saldo_ = Convert.ToInt32(Tools.isNull(dr["Saldo"], "").ToString());
                    namatoko_ = Tools.isNull(dr["Namatoko"], "").ToString().Trim();
                    cicil_ = Convert.ToDouble(Tools.isNull(dr["Cicil"], "0").ToString());
                    lub_ = Tools.isNull(dr["Lub"], "").ToString();
                    tgljt_ = Convert.ToDateTime(Tools.isNull(dr["tgl_jt"], null).ToString());
                    tgltr_ = Convert.ToDateTime(Tools.isNull(dr["tgl_tr"], null).ToString());

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@kpid", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, tgltr_));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLink", SqlDbType.DateTime, tgllink_ ));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTransaki", SqlDbType.VarChar, Tools.isNull(dr["no_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, status_));
                        db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktu", SqlDbType.Money, double.Parse(Tools.isNull(dr["jk_waktu"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, tgljt_));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Money, cicil_));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Money, double.Parse(Tools.isNull(dr["hari_krm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Money, double.Parse(Tools.isNull(dr["hari_sls"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganTagih", SqlDbType.VarChar, Tools.isNull(dr["ket_tagih"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  2.Download KartuPiutangDetailTac
        private void KartuPiutangDetailDownload_Load()
        {
            string fileName = "TacDownloadtmp\\KartuPiutangDetailTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading KartuPiutangDetail Tac", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        KartuPiutangDetailDt = Foxpro.ReadFile(fileName);
                        dsData.Tables.Add(KartuPiutangDetailDt);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = KartuPiutangDetailDt.Rows.Count;
                        DownloadKartuPiutangDetailTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        KartuPiutangDetailDt.Dispose();
                    }
                }
            }
        }


        public void DownloadKartuPiutangDetailTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_KartuPiutangDetail_TAC"));
                foreach (DataRow dr in KartuPiutangDetailDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    Guid HeaderID_ = Guid.NewGuid();
                    string kpid_ = Tools.isNull(dr["kpid"], "").ToString().Trim();
                    string recID_ = Tools.isNull(dr["RecordID"], "").ToString().Trim();
                    string nobg_ = Tools.isNull(dr["NoGiro"], "").ToString().Trim();
                    string lub_ = Tools.isNull(dr["Lub"], "").ToString();
                    string noacc_ = Tools.isNull(dr["NoAcc"], "").ToString().Trim();

                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataTable dbh = new DataTable();
                        using (Database db1 = new Database(GlobalVar.DBName))
                        {
                            db1.Commands.Add(db.CreateCommand("usp_Tac_GetHeaderID"));
                            db1.Commands[0].Parameters.Add(new Parameter("@KpID", SqlDbType.VarChar, kpid_));
                            dbh = db1.Commands[0].ExecuteDataTable();
                            HeaderID_ = new Guid(Tools.isNull(dbh.Rows[0]["RowID"],null).ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    RowID_ = new Guid(dr["RowID"].ToString().Trim());
                    HeaderID_ = new Guid(dr["HeaderID"].ToString().Trim());
                    recID_ = dr["RecordID"].ToString().Trim();
                    nobg_ = dr["Nogiro"].ToString().Trim();
                    lub_ = Tools.isNull(dr["Lub"], "").ToString();
                    noacc_ = Tools.isNull(dr["Noacc"], "").ToString();

                    string cAudit = dr["laudit"].ToString().Trim();
                    string cClosed = "";

                    if (cAudit == "false")
                        cClosed = "0";
                    else
                        cClosed = "1";


                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recID_));
                        db.Commands[0].Parameters.Add(new Parameter("@Kpid", SqlDbType.VarChar, kpid_));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_tr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, Tools.isNull(dr["kd_trans"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, double.Parse(Tools.isNull(dr["debet"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, double.Parse(Tools.isNull(dr["kredit"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJtGiro", SqlDbType.DateTime, Tools.isNull(dr["cbg_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, Tools.isNull(dr["no_bkm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, nobg_));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["Bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noacc_));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, double.Parse(cClosed)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "MANAGER"));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  3.Download SalesTac
        private void SalesDownload_Load()
        {
            string fileName = "TacDownloadtmp\\salestac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Sales Tac", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        SalesDt = Foxpro.ReadFile(fileName);
                        dsData.Tables.Add(SalesDt);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = SalesDt.Rows.Count;
                        DownloadSalesTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        SalesDt.Dispose();
                    }
                }
            }
        }


        public void DownloadSalesTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_Sales_TAC"));
                foreach (DataRow dr in SalesDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    string lub_ = "MANAGER";

                    RowID_ = new Guid(dr["RowID"].ToString());
                    lub_ = Tools.isNull(dr["Lub"], "").ToString().Trim();

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, Tools.isNull(dr["nm_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Money, double.Parse(Tools.isNull(dr["target"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Money, double.Parse(Tools.isNull(dr["Batas_od"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, Tools.isNull(dr["tgl_masuk"],DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"],DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  4.Download StatusTokoTac
        private void StatusTokoDownload_Load()
        {
            string fileName = "TacDownloadtmp\\StatusTokoTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Status Toko", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        StatusTokoDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = StatusTokoDt.Rows.Count;
                        DownloadStatusTokoTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        StatusTokoDt.Dispose();
                    }
                }
            }
        }


        public void DownloadStatusTokoTac()
        {
           using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_StatusToko_TAC"));
                foreach (DataRow dr in StatusTokoDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    string lub_ = "MANAGER";

                    RowID_ = new Guid(dr["RowID"].ToString());
                    lub_ = Tools.isNull(dr["Lub"], "").ToString().Trim();

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@cabangid", SqlDbType.VarChar, Tools.isNull(dr["c1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglaktif", SqlDbType.DateTime, Tools.isNull(dr["tmt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, Tools.isNull(dr["sts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@recordid", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@kstatus", SqlDbType.VarChar, Tools.isNull(dr["ksts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@roda", SqlDbType.VarChar, Tools.isNull(dr["rd"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@wilid", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglpasif", SqlDbType.DateTime, Tools.isNull(dr["tmt_pasif"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  5.Download TokoPlafonTac
        private void PlafonTokoDownload_Load()
        {
            string fileName = "TacDownloadtmp\\TokoPlafonTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Plafon Toko",ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        PlafonDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = PlafonDt.Rows.Count;
                        DownloadPlafonTokoTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        PlafonDt.Dispose();
                    }
                }
            }
        }


        public void DownloadPlafonTokoTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_TokoPlafon_TAC"));
                foreach (DataRow dr in PlafonDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    string lub_ = "MANAGER";

                    RowID_ = new Guid(dr["RowID"].ToString());
                    lub_ = Tools.isNull(dr["Lub"], "").ToString().Trim();

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, Tools.isNull(dr["tanggal"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_fb"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fx", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_fx"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fa", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_fa"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kb", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_kb"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kh", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_kh"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kv", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_kv"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kg", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_kg"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@max_credit", SqlDbType.Money, double.Parse(Tools.isNull(dr["max_credit"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fb", SqlDbType.Money, double.Parse(Tools.isNull(dr["max_fb"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fx", SqlDbType.Money, double.Parse(Tools.isNull(dr["max_fx"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fa", SqlDbType.Money, double.Parse(Tools.isNull(dr["max_fa"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@tmptoko", SqlDbType.Money, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  6.Download AccountTokoTac
        private void AccountTokoDownload_Load()
        {
            string fileName = "TacDownloadtmp\\AccountTokoTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading Account Toko", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        AccountTokoDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = AccountTokoDt.Rows.Count;
                        DownloadAccountTokoTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        AccountTokoDt.Dispose();
                    }
                }
            }
        }


        public void DownloadAccountTokoTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_AccountToko_TAC"));
                foreach (DataRow dr in AccountTokoDt.Rows)
                {
                    Guid RowID_ = new Guid(dr["RowID"].ToString());
                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, Tools.isNull(dr["Noaccount"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["lub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, Tools.isNull(dr["lut"], DBNull.Value)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  7.Download BarcodeNotaTac
        private void BarcodeNotaDownload_Load()
        {
            string fileName = "TacDownloadtmp\\BarcodeNotaTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading BarcodeNota", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        BarcodeNotaDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = BarcodeNotaDt.Rows.Count;
                        DownloadBarcodeNotaTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        BarcodeNotaDt.Dispose();
                    }
                }
            }
        }


        public void DownloadBarcodeNotaTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_BarcodeNota_TAC"));
                foreach (DataRow dr in BarcodeNotaDt.Rows)
                {
                    Guid RowID_ = new Guid(dr["RowID"].ToString());
                    Guid NotaRowID_ = new Guid(dr["NotaID"].ToString());
                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaRowID", SqlDbType.UniqueIdentifier, NotaRowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, Tools.isNull(dr["Barcode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, Tools.isNull(dr["CBy"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedTime", SqlDbType.DateTime, Tools.isNull(dr["CTime"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["lub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, Tools.isNull(dr["lut"], DBNull.Value)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  8.Download GiroTolakTac
        private void GiroTolakDownload_Load()
        {
            string fileName = "TacDownloadtmp\\GiroTolakTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading GiroTolak", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        GiroTolakDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = GiroTolakDt.Rows.Count;
                        DownloadGiroTolakTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        GiroTolakDt.Dispose();
                    }
                }
            }
        }


        public void DownloadGiroTolakTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_GiroTolak_TAC"));
                foreach (DataRow dr in GiroTolakDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    Guid KpiutID_ = Guid.NewGuid();

                    string kpid_ = Tools.isNull(dr["idkp"], "").ToString().Trim();
                    string recID_ = Tools.isNull(dr["idrec"], "").ToString().Trim();
                    string lub_ = "MANAGER";
                    string kdtoko_ = Tools.isNull(dr["kd_toko"], "").ToString().Trim();
                    string status_ = "OPEN";
                    string kdsales_ = Tools.isNull(dr["kd_sales"], "").ToString().Trim();
                    string nobkm_ = Tools.isNull(dr["no_bkm"], "").ToString().Trim();
                    string nobg_ = Tools.isNull(dr["no_bg"], "").ToString().Trim();
                    string noAcc_ = Tools.isNull(dr["no_acc"], "").ToString().Trim();
                    string ketTagih_ = Tools.isNull(dr["Ket_tagih"], "").ToString().Trim();
                    string uraian_ = Tools.isNull(dr["Uraian"], "-").ToString().Trim();

                    DateTime tglgiro_ = Convert.ToDateTime(Tools.isNull(dr["tgl_giro"], null).ToString());
                    DateTime cbgjt_ = Convert.ToDateTime(Tools.isNull(dr["cbg_jt"], null).ToString());

                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataTable dbt = new DataTable();
                        using (Database db1 = new Database(GlobalVar.DBName))
                        {
                            db1.Commands.Add(db1.CreateCommand("usp_Tac_GetKpiutID"));
                            db1.Commands[0].Parameters.Add(new Parameter("@KpID", SqlDbType.VarChar, kpid_.ToString().Trim()));
                            dbt = db1.Commands[0].ExecuteDataTable();
                            KpiutID_ = new Guid(Tools.isNull(dbt.Rows[0]["RowID"], null).ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    RowID_ = new Guid(dr["RowID"].ToString());
                    KpiutID_ = new Guid(dr["KpiutID"].ToString());
                    recID_ = Tools.isNull(dr["RecordID"], "").ToString().Trim();
                    kpid_ = Tools.isNull(dr["KPID"], "").ToString().Trim();
                    lub_ = Tools.isNull(dr["Lub"], "").ToString().Trim();
                    kdtoko_ = Tools.isNull(dr["KodeToko"], "").ToString().Trim();
                    status_ = Tools.isNull(dr["Status"], "").ToString().Trim();
                    tglgiro_ = Convert.ToDateTime(Tools.isNull(dr["TglGiro"], null));
                    cbgjt_ = Convert.ToDateTime(Tools.isNull(dr["cbgjt"], null));
                    kdsales_ = Tools.isNull(dr["Kdsales"], "").ToString().Trim();
                    nobkm_ = Tools.isNull(dr["NoBkm"], "").ToString().Trim();
                    nobg_ = Tools.isNull(dr["NoBg"], "").ToString().Trim();
                    noAcc_ = Tools.isNull(dr["NoAcc"], "").ToString().Trim();
                    ketTagih_ = Tools.isNull(dr["KetTagih"], "").ToString().Trim();
                    uraian_ = Tools.isNull(dr["Uraian"], "-").ToString().Trim();

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recID_));
                        db.Commands[0].Parameters.Add(new Parameter("@KartuPiutangID", SqlDbType.UniqueIdentifier, KpiutID_));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, kpid_));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdtoko_));
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, status_));
                        db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["Alasan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, tglgiro_));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, cbgjt_));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian_));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, double.Parse(Tools.isNull(dr["Debet"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, kdsales_));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBkm", SqlDbType.VarChar, nobkm_));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBg", SqlDbType.VarChar, nobg_));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["Bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc_));
                        db.Commands[0].Parameters.Add(new Parameter("@Audit", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, ketTagih_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region  9.Download GiroTolakDetailTac
        private void GiroTolakDetailDownload_Load()
        {
            string fileName = "TacDownloadtmp\\GiroTolakDetailTac.dbf";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            ctr++;
            RefreshStatus("Downloading GiroTolakDetail", ctr);
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        GiroTolakDetailDt = Foxpro.ReadFile(fileName);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = GiroTolakDetailDt.Rows.Count;
                        DownloadGiroTolakDetailTac();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        GiroTolakDetailDt.Dispose();
                    }
                }
            }
        }


        public void DownloadGiroTolakDetailTac()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Download_GiroTolakDetail_TAC"));
                foreach (DataRow dr in GiroTolakDetailDt.Rows)
                {
                    Guid RowID_ = Guid.NewGuid();
                    Guid HeaderID_ = RowID_;

                    string HRecID_ = Tools.isNull(dr["Idrec"], "").ToString().Trim();
                    string DRecID_ = Tools.isNull(dr["Dstamp"], "").ToString().Trim();
                    string Kdbyr_ = Tools.isNull(dr["Kd_bayar"], "").ToString().Trim();
                    string NoBkm_ = Tools.isNull(dr["No_bkm"], "").ToString().Trim();
                    string NoBg_ = Tools.isNull(dr["No_bg"], "").ToString().Trim();
                    string NoAcc_ = Tools.isNull(dr["No_acc"], "").ToString().Trim();
                    string Lub_ = "MANAGER";

                    DateTime Tglbyr_ = Convert.ToDateTime(Tools.isNull(dr["tgl_byr"], null).ToString());
                    DateTime? CbgJt_ = null;

                    if (Tools.isNull(dr["Cbg_jt"], "").ToString() != "")
                        CbgJt_ = (DateTime?)dr["Cbg_jt"];

                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataTable dbd = new DataTable();
                        using (Database db1 = new Database(GlobalVar.DBName))
                        {
                            db1.Commands.Add(db1.CreateCommand("usp_Tac_GetHeaderIDGT"));
                            db1.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, HRecID_));
                            dbd = db1.Commands[0].ExecuteDataTable();
                            HeaderID_ = new Guid(Tools.isNull(dbd.Rows[0]["RowID"],null).ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    RowID_ = new Guid(dr["RowID"].ToString());
                    HeaderID_ = new Guid(dr["HeaderID"].ToString());
                    HRecID_ = Tools.isNull(dr["HRecordID"], "").ToString().Trim();
                    DRecID_ = Tools.isNull(dr["RecordID"], "").ToString().Trim();
                    Tglbyr_ = Convert.ToDateTime(Tools.isNull(dr["Tglbayar"], null).ToString());
                    Kdbyr_ = Tools.isNull(dr["KdBayar"], "").ToString().Trim();
                    CbgJt_ = Convert.ToDateTime(Tools.isNull(dr["CbgJt"], null).ToString());
                    NoBkm_ = Tools.isNull(dr["NoBkm"], "").ToString().Trim();
                    NoBg_ = Tools.isNull(dr["Nobg"], "").ToString().Trim();
                    NoAcc_ = Tools.isNull(dr["NoAcc"], "").ToString().Trim();
                    Lub_ = Tools.isNull(dr["Lub"], "").ToString().Trim();

                    progressBar1.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, DRecID_));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecID_));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.DateTime, Tglbyr_));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, Kdbyr_));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, double.Parse(Tools.isNull(dr["Kredit"], 0).ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, CbgJt_));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBkm", SqlDbType.VarChar, NoBkm_));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBg", SqlDbType.VarChar, NoBg_));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["Bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, NoAcc_));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Lub_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion
        

        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapDownloadTac());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LapDownloadTac";
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage LapDownloadTac()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Download TAC";
            ex.Workbook.Properties.SetCustomPropertyValue("Download TAC", "1147");

            #region sheet 1 : Toko Tac
            ex.Workbook.Worksheets.Add("Toko");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 40;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 60;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;

            // Title
            ws.Cells[1, 2].Value = "DOWNLOAD TRANSFER ANTAR CABANG (TAC)";
            ws.Cells[1, 2].Style.Font.Bold = true;
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer); // + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[3, 2].Style.Font.Bold = true;
            ws.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Header
            ws.Cells[4, 2].Value = " NO ";
            ws.Cells[4, 3].Value = " IDTOKO ";
            ws.Cells[4, 4].Value = " KODE TOKO ";
            ws.Cells[4, 5].Value = " NAMA TOKO ";
            ws.Cells[4, 6].Value = " ALAMAT ";
            ws.Cells[4, 7].Value = " KOTA ";
            ws.Cells[4, 8].Value = " IDWIL ";

            int MaxCol = 8;
            int rowz = 4;
            int rowx = rowz + 1;
            int no = 0;
            double JmlD = 0, JmlK = 0;

            ws.Cells[4, 2, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[4, 2, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[4, 2, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 2, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                no += 1;
                ws.Cells[rowx, 2].Value = no.ToString();
                ws.Cells[rowx, 3].Value = Tools.isNull(dr["idtoko"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr["Kd_Toko"], "");
                ws.Cells[rowx, 5].Value = Tools.isNull(dr["NamaToko"], "");
                ws.Cells[rowx, 6].Value = Tools.isNull(dr["Alamat"], "");
                ws.Cells[rowx, 7].Value = Tools.isNull(dr["Kota"], "");
                ws.Cells[rowx, 8].Value = Tools.isNull(dr["idwil"], "");
                rowx++;
            }

            //ws.Cells[rowx, 2].Value = "Jumlah";
            //ws.Cells[rowx, 2].Style.Font.Bold = true;
            //ws.Cells[rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[rowx, 4].Value = Tools.isNull(JmlD, 0);
            //ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[rowx, 4].Style.Font.Bold = true;
            //ws.Cells[rowx, 5].Value = Tools.isNull(JmlK, 0);
            //ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[rowx, 5].Style.Font.Bold = true;

            var border = ws.Cells[rowz + 1, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowz, 2, rowz, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region sheet 2 : KartuPiutang Tac
            ex.Workbook.Worksheets.Add("KartuPiutang");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            // Width
            ws2.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 10;
            ws2.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws2.Cells[1, 5].Worksheet.Column(5).Width = 15;
            ws2.Cells[1, 6].Worksheet.Column(6).Width = 6;
            ws2.Cells[1, 7].Worksheet.Column(7).Width = 6;
            ws2.Cells[1, 8].Worksheet.Column(8).Width = 15;
            ws2.Cells[1, 9].Worksheet.Column(9).Width = 5;
            ws2.Cells[1, 10].Worksheet.Column(10).Width = 17;
            ws2.Cells[1, 11].Worksheet.Column(11).Width = 23;
            ws2.Cells[1, 12].Worksheet.Column(12).Width = 40;
            ws2.Cells[1, 13].Worksheet.Column(13).Width = 10;
            ws2.Cells[1, 14].Worksheet.Column(14).Width = 15;

            ws2.Cells[1, 2].Value = "KARTU PIUTANG TAC";
            ws2.Cells[1, 2].Style.Font.Bold = true;
            ws2.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);    // +" s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws2.Cells[3, 2].Style.Font.Bold = true;
            ws2.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2].Value = " NO ";
            ws2.Cells[4, 3].Value = " NO TRANSAKSI ";
            ws2.Cells[4, 4].Value = " TGL TRANSAKSI ";
            ws2.Cells[4, 5].Value = " TGL TERIMA ";
            ws2.Cells[4, 6].Value = " JW ";
            ws2.Cells[4, 7].Value = " JS ";
            ws2.Cells[4, 8].Value = " TGL JT TEMPO ";
            ws2.Cells[4, 9].Value = " TRANS TYPE ";
            ws2.Cells[4, 10].Value = " KODE SALES ";
            ws2.Cells[4, 11].Value = " KODE TOKO ";
            ws2.Cells[4, 12].Value = " NAMA TOKO ";
            ws2.Cells[4, 13].Value = " IDWIL ";
            ws2.Cells[4, 14].Value = " SALDO PIUTANG ";

            int MaxCol2 = 14;
            rowz = 4;
            int rowx2 = rowz + 1;
            int no2 = 0;
            Double Saldo = 0;

            ws2.Cells[4, 2, 4, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[4, 2, 4, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            double Nominal = 0;

            foreach (DataRow dr0 in dsData.Tables[1].Rows)
            {
                DateTime? tgllink_ = null;
                double nSaldo_ = 0;
                string kdtoko_ = "";
                string nmtoko_ = "";
                string wilid_ = "";

                if (GlobalVar.Gudang == "2828" || GlobalVar.Gudang == "0401")
                {
                    nSaldo_ = Convert.ToDouble(Tools.isNull(dr0["Rp_sisa"], "0").ToString());
                    kdtoko_ = Tools.isNull(dr0["kd_toko"], "").ToString();

                    DataTable dbt = new DataTable();
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        using (Database db1 = new Database(GlobalVar.DBName))
                        {
                            db1.Commands.Add(db1.CreateCommand("usp_Tac_GetDataToko"));
                            db1.Commands[0].Parameters.Add(new Parameter("@Kdtoko", SqlDbType.VarChar, kdtoko_));
                            dbt = db1.Commands[0].ExecuteDataTable();
                            if (dbt.Rows.Count > 0)
                            {
                                nmtoko_ = Tools.isNull(dbt.Rows[0]["Namatoko"], "").ToString();
                                wilid_ = Tools.isNull(dbt.Rows[0]["Wilid"], "").ToString();
                            }
                        }
                    }
                    catch (Exception ex1)
                    {
                        Error.LogError(ex1);
                    }

                    if (Tools.isNull(dr0["Tgl_tr"], "").ToString() != "")
                        tgllink_ = (DateTime?)dr0["Tgl_tr"];
                    else
                        tgllink_ = null;


                }
                else
                {
                    nSaldo_ = Convert.ToDouble(Tools.isNull(dr0["Saldo"], "0").ToString());
                    if (Tools.isNull(dr0["Tgl_link"], "").ToString() != "")
                        tgllink_ = (DateTime?)dr0["Tgl_link"];
                    else
                        tgllink_ = null;
                }

                no2 += 1;
                ws2.Cells[rowx2, 2].Value = no2.ToString();
                ws2.Cells[rowx2, 3].Value = Tools.isNull(dr0["No_tr"], "");
                ws2.Cells[rowx2, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["Tgl_tr"], ""));
                ws2.Cells[rowx2, 5].Value = string.Format("{0:dd-MMM-yyyy}", tgllink_);
                ws2.Cells[rowx2, 6].Value = Tools.isNull(dr0["Jk_Waktu"], 0);
                ws2.Cells[rowx2, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 7].Value = Tools.isNull(dr0["Hari_sls"], 0);
                ws2.Cells[rowx2, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["Tgl_jt"], ""));
                ws2.Cells[rowx2, 9].Value = Tools.isNull(dr0["id_tr"], "");
                ws2.Cells[rowx2, 10].Value = Tools.isNull(dr0["Kd_Sales"], "");
                ws2.Cells[rowx2, 11].Value = Tools.isNull(dr0["Kd_Toko"], "");
                ws2.Cells[rowx2, 12].Value = nmtoko_;// Tools.isNull(dr0["NamaToko"], "");
                ws2.Cells[rowx2, 13].Value = wilid_;// Tools.isNull(dr0["WilID"], "");
                ws2.Cells[rowx2, 14].Value = nSaldo_;// Tools.isNull(dr0["Saldo"], 0);
                ws2.Cells[rowx2, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                rowx2++;
                Saldo = Saldo + nSaldo_;// Convert.ToDouble(Tools.isNull(dr0["Saldo"], 0));
            }

            ws2.Cells[rowx2, 13].Value = "Jumlah";
            ws2.Cells[rowx2, 13].Style.Font.Bold = true;
            ws2.Cells[rowx2, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[rowx2, 14].Value = Tools.isNull(Saldo, 0);
            ws2.Cells[rowx2, 14].Style.Font.Bold = true;
            ws2.Cells[rowx2, 14].Style.Numberformat.Format = "#,##;(#,##);0";

            var border2 = ws2.Cells[rowz + 1, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.None;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowz, 2, rowz, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowx2, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.Thin;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, 2, rowx2, 2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style = ExcelBorderStyle.Thin;
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, MaxCol2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region sheet 3 : Sales Tac
            ex.Workbook.Worksheets.Add("Sales");
            ExcelWorksheet ws3 = ex.Workbook.Worksheets[3];

            // Width
            ws3.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws3.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws3.Cells[1, 3].Worksheet.Column(3).Width = 17;
            ws3.Cells[1, 4].Worksheet.Column(4).Width = 40;
            ws3.Cells[1, 5].Worksheet.Column(5).Width = 15;
            ws3.Cells[1, 6].Worksheet.Column(6).Width = 15;

            ws3.Cells[1, 2].Value = "SALES TAC";
            ws3.Cells[1, 2].Style.Font.Bold = true;
            ws3.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws3.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);    // +" s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws3.Cells[3, 2].Style.Font.Bold = true;
            ws3.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws3.Cells[4, 2].Value = " NO ";
            ws3.Cells[4, 3].Value = " KODE SALES ";
            ws3.Cells[4, 4].Value = " NAMA SALES ";
            ws3.Cells[4, 5].Value = " TGL MASUK ";
            ws3.Cells[4, 6].Value = " TGL KELUAR ";

            int MaxCol3 = 6;
            rowz = 4;
            int rowx3 = rowz + 1;
            int no3 = 0;

            ws3.Cells[4, 2, 4, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws3.Cells[4, 2, 4, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            if (dsData.Tables.Count >= 3)
            {
                foreach (DataRow dr0 in dsData.Tables[3].Rows)
                {
                    no3 += 1;
                    ws3.Cells[rowx3, 2].Value = no3.ToString();
                    ws3.Cells[rowx3, 3].Value = Tools.isNull(dr0["kd_sales"], "");
                    ws3.Cells[rowx3, 4].Value = Tools.isNull(dr0["Nm_Sales"], "");
                    ws3.Cells[rowx3, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["Tgl_Masuk"], ""));
                    ws3.Cells[rowx3, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["Tgl_Keluar"], ""));
                    rowx3++;
                }
            }
            var border3 = ws3.Cells[rowz + 1, 2, rowx3, MaxCol3].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style = ExcelBorderStyle.None;
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;

            border3 = ws3.Cells[rowz, 2, rowz, MaxCol3].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;

            border3 = ws3.Cells[rowx3, 2, rowx3, MaxCol3].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style = ExcelBorderStyle.Thin;
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.None;

            border3 = ws3.Cells[rowx3, 2, rowx3, 2].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style = ExcelBorderStyle.Thin;
            border3.Right.Style = ExcelBorderStyle.None;

            border3 = ws3.Cells[rowx3, MaxCol3, rowx3, MaxCol3].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            return ex;
        }

        private void cekIdwil_CheckedChanged(object sender, EventArgs e)
        {
            if (cekIdwil.Checked)
                wil.Enabled = true;
            else
                wil.Enabled = false;
        }



    }
}
