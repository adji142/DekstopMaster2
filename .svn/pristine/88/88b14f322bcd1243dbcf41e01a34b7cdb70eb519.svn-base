using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Data.SqlClient;
//using ISA.Trading.Class;

using System.Data.SqlClient;
//using ISA.Trading.Class;


namespace ISA.Finance.Tac
{
    public partial class frmTAC : ISA.Controls.BaseForm
    {
        DataSet dsData = new DataSet();
        DataSet dsData2= new DataSet();
        DataTable dt = new DataTable();
        List<string> files = new List<string>();
        SqlDataReader drt;
        int uploadTable = 0;
        int jumlahTable = 32;
        string TacWil = string.Empty;
        string wilx = string.Empty;
        string wiln = string.Empty;

        public frmTAC()
        {
            InitializeComponent();
        }

        private void frmTAC_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            #region GetdataWilayah
            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    using (Database db = new Database(GlobalVar.DBName))
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_Wilayah_LIST"));
            //        dt = db.Commands[0].ExecuteDataTable();
            //        if (dt.Rows.Count > 0)
            //            TacWil = "1";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            #endregion

            #region Get data Toko
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tac_GetDataPiutang"));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            #endregion

            if (dsData.Tables.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Counter.Text = "";
                this.refreshForm();

                int tblupl = 0, tblupd = 0;

                #region 0.Updated TokoTac
                try
                {
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "TokoTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr in dsData.Tables[0].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_TokoTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@idToko", SqlDbType.VarChar, Tools.isNull(dr["TokoID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, Tools.isNull(dr["NamaToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["Alamat"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, Tools.isNull(dr["Daerah"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, Tools.isNull(dr["Propinsi"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@noTelp", SqlDbType.VarChar, Tools.isNull(dr["Telp"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@idWil", SqlDbType.VarChar, Tools.isNull(dr["WilID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@pngJwb", SqlDbType.VarChar, Tools.isNull(dr["PenanggungJawab"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@kd_Toko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@piutang_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["PiutangB"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@piutang_j", SqlDbType.Money, double.Parse(Tools.isNull(dr["PiutangJ"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["Plafon"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@to_jual", SqlDbType.Money, double.Parse(Tools.isNull(dr["ToJual"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@to_retpot", SqlDbType.Money, double.Parse(Tools.isNull(dr["ToRetPot"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@jkw_kredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["JangkaWaktuKredit"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@tgl1st", SqlDbType.DateTime, dr["Tgl1st"]));
                                db.Commands[0].Parameters.Add(new Parameter("@exist", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["Exist"], false).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["StatusAktif"], false).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@idclass", SqlDbType.VarChar, Tools.isNull(dr["ClassID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.Bit, int.Parse("0")));
                                db.Commands[0].Parameters.Add(new Parameter("@hari_krm", SqlDbType.Int, int.Parse(Tools.isNull(dr["HariKirim"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@grade", SqlDbType.VarChar, Tools.isNull(dr["Grade"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@plafon_1st", SqlDbType.Money, double.Parse(Tools.isNull(dr["Plafon1st"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, Tools.isNull(dr["Flag"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@hari_sls", SqlDbType.Int, int.Parse(Tools.isNull(dr["HariSales"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@cab2", SqlDbType.VarChar, Tools.isNull(dr["Cabang2"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@alm_rumah", SqlDbType.VarChar, Tools.isNull(dr["AlamatRumah"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@pengelola", SqlDbType.VarChar, Tools.isNull(dr["Pengelola"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@tgl_lahir", SqlDbType.DateTime, dr["TglLahir"]));
                                db.Commands[0].Parameters.Add(new Parameter("@hp", SqlDbType.VarChar, Tools.isNull(dr["HP"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, Tools.isNull(dr["Status"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@th_berdiri", SqlDbType.VarChar, Tools.isNull(dr["ThnBerdiri"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@lruko", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["StatusRuko"], false).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@jml_cabang", SqlDbType.Int, int.Parse(Tools.isNull(dr["JmlCabang"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@jml_sales", SqlDbType.Int, int.Parse(Tools.isNull(dr["JmlSales"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@kinerja", SqlDbType.VarChar, Tools.isNull(dr["Kinerja"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@reff_sls", SqlDbType.VarChar, Tools.isNull(dr["RefSales"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@reff_col", SqlDbType.VarChar, Tools.isNull(dr["RefCollector"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@reff_spv", SqlDbType.VarChar, Tools.isNull(dr["RefSupervisor"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@plf_survey", SqlDbType.Money, double.Parse(Tools.isNull(dr["PlafonSurvey"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@bdg_usaha", SqlDbType.VarChar, Tools.isNull(dr["BidangUsaha"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, Tools.isNull(dr["fax"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@bangunan", SqlDbType.VarChar, Tools.isNull(dr["bangunan"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@habis_kontrak", SqlDbType.DateTime, dr["habis_kontrak"]));
                                db.Commands[0].Parameters.Add(new Parameter("@jenis_produk", SqlDbType.VarChar, Tools.isNull(dr["jenis_produk"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, Tools.isNull(dr["nama_pemilik"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@jenis_kelamin", SqlDbType.VarChar, Tools.isNull(dr["jenis_kelamin"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@tempat_lhr", SqlDbType.VarChar, Tools.isNull(dr["tempat_lhr"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, Tools.isNull(dr["email"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@no_rekening", SqlDbType.VarChar, Tools.isNull(dr["no_rekening"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@nama_bank", SqlDbType.VarChar, Tools.isNull(dr["nama_bank"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, Tools.isNull(dr["no_member"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@hobi", SqlDbType.VarChar, Tools.isNull(dr["hobi"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@no_npwp", SqlDbType.VarChar, Tools.isNull(dr["no_npwp"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@mediaByr", SqlDbType.VarChar, Tools.isNull(dr["MediaByr"], "").ToString().Trim()));
                                //db.Commands[0].Parameters.Add(new Parameter("@Angsuran", SqlDbType.Money, Double.Parse(Tools.isNull(dr["Angsuran"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@ketBayar", SqlDbType.VarChar, Tools.isNull(dr["KetBayar"], "").ToString().Trim()));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                            //nCounter += 1;
                            //Counter.Text = nCounter.ToString();
                            //this.Refresh();
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
                #endregion

                #region  1.Update KartuPiutangTac
                try
                {
                    if (dsData.Tables[1].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "KartuPiutangTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr1 in dsData.Tables[1].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_KartuPiutangTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr1["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr1["KPID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr1["KodeToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr1["KodeSales"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr1["TglTransaksi"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@TglLink", SqlDbType.DateTime, Tools.isNull(dr1["TglLink"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, Tools.isNull(dr1["NoTransaksi"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr1["Status"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktu", SqlDbType.Int, int.Parse(Tools.isNull(dr1["JangkaWaktu"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, Tools.isNull(dr1["TglJatuhTempo"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr1["Uraian"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, int.Parse(Tools.isNull(dr1["Cicil"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr1["TransactionType"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, int.Parse("0").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr1["HariKirim"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr1["HariSales"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@KeteranganTagih", SqlDbType.VarChar, Tools.isNull(dr1["KeteranganTagih"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Saldo", SqlDbType.Int, double.Parse(Tools.isNull(dr1["Saldo"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr1["NamaToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr1["WilID"], "").ToString().Trim()));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion

                #region  2.Update KartuPiutangDetailTac
                try
                {
                    if (dsData.Tables[2].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "KartuPiutangDetailTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr2 in dsData.Tables[2].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetailTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr2["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dr2["HeaderID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr2["RecordID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr2["KPID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr2["TglTransaksi"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, Tools.isNull(dr2["KodeTransaksi"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, double.Parse(Tools.isNull(dr2["Debet"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, double.Parse(Tools.isNull(dr2["Kredit"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@TglJTGiro", SqlDbType.DateTime, Tools.isNull(dr2["TglJTGiro"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr2["Uraian"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, int.Parse("0").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, Tools.isNull(dr2["NoBuktiKasMasuk"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, Tools.isNull(dr2["NoGiro"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr2["Bank"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, Tools.isNull(dr2["NoAcc"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Int, Tools.isNull(dr2["isClosed"], 0)));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion

                #region  3.Update SalesTac
                try
                {
                    if (dsData.Tables[3].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "SalesTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr3 in dsData.Tables[3].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_SalesTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr3["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr3["SalesID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, Tools.isNull(dr3["NamaSales"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, Tools.isNull(dr3["RecID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr3["TglLahir"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr3["Alamat"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Money, double.Parse(Tools.isNull(dr3["Target"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Money, double.Parse(Tools.isNull(dr3["BatasOD"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, Tools.isNull(dr3["TglMasuk"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr3["TglKeluar"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr3["KodeGudang"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, int.Parse("0").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion

                #region  4.Update StatusTokoTac
                try
                {
                    if (dsData.Tables[4].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "StatusTokoTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr4 in dsData.Tables[4].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_StatusTokoTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr4["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, Tools.isNull(dr4["CabangID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr4["KodeToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, Tools.isNull(dr4["TglAktif"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr4["Status"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr4["RecordID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr4["Keterangan"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, int.Parse("1".ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@KStatus", SqlDbType.VarChar, Tools.isNull(dr4["KStatus"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Roda", SqlDbType.VarChar, Tools.isNull(dr4["Roda"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr4["WilID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.DateTime, Tools.isNull(dr4["TglAktif"], null)));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion

                #region  5.Update PlafonTokoTac
                try
                {
                    if (dsData.Tables[5].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "TokoPlafonTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr5 in dsData.Tables[5].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_TokoPlafonTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr5["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr5["KodeToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr5["WilID"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, Tools.isNull(dr5["Tanggal"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_fb", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_fb"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_fx", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_fx"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_fa", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_fa"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_kb", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_kb"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_kh", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_kh"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_kv", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_kv"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Plf_kg", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Plf_kg"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Max_credit", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Max_credit"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Max_fb", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Max_fb"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Max_fx", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Max_fx"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Max_fa", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Max_fa"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Tmptoko", SqlDbType.Money, Double.Parse(Tools.isNull(dr5["Tmptoko"], 0).ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, 1));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  6.Update AccountTokoTac
                try
                {
                    if (dsData.Tables[6].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "AccountTokoTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr6 in dsData.Tables[6].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_AccountTokoTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr6["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr6["KodeToko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, Tools.isNull(dr6["NoAccount"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }

                #endregion


                #region  7.Update BarcodeNotaTac
                try
                {
                    if (dsData.Tables[7].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "BarcodeNotaTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr7 in dsData.Tables[7].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_BarcodeNotaTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr7["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@NotaRowID", SqlDbType.UniqueIdentifier, dr7["NotaRowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, Tools.isNull(dr7["Barcode"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, Tools.isNull(dr7["CreatedBy"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@CreatedTime", SqlDbType.DateTime, Tools.isNull(dr7["CreatedTime"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr7["LastUpdatedBy"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, Tools.isNull(dr7["LastUpdatedTime"], DBNull.Value)));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }

                #endregion


                #region Update BarcodeNotaDetailTac
                try
                {
                    if (dsData.Tables[8].Rows.Count > 0)
                    {
                        foreach (DataRow dr8 in dsData.Tables[8].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_BarcodeNotaDetailTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr8["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dr8["HeaderID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@TglScan", SqlDbType.DateTime, Tools.isNull(dr8["TglScan"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr8["Keterangan"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, Tools.isNull(dr8["CreatedBy"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@CreatedTime", SqlDbType.DateTime, Tools.isNull(dr8["CreatedTime"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }

                #endregion


                #region  9.Update PinCounter
                try
                {
                    if (dsData.Tables[9].Rows.Count > 0)
                    {
                        tblupd += 1;
                        label1.Text = "PinCounterTac";
                        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                        lblProgress.Text = "Updating..";
                        this.refreshForm();

                        foreach (DataRow dr9 in dsData.Tables[9].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PinCounterTac_UPDATE"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr9["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr9["Kode"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, Tools.isNull(dr9["Nama"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@FlagPin", SqlDbType.Int, int.Parse(Tools.isNull(dr9["FlagPin"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse("1")));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }

                #endregion


                #region  10.Update GiroTolakTac
                //try
                //{
                //    if (dsData.Tables[10].Rows.Count > 0)
                //    {
                //        tblupd += 1;
                //        label1.Text = "GiroTolakTac";
                //        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                //        lblProgress.Text = "Updating..";
                //        this.refreshForm();

                //        foreach (DataRow dr10 in dsData.Tables[10].Rows)
                //        {
                //            string cAudit = "";
                //            if (dr10["Audit"].ToString() == "false")
                //                cAudit = "0";
                //            else
                //                cAudit = "1";
                //            using (Database db = new Database(GlobalVar.DBName))
                //            {
                //                db.Commands.Add(db.CreateCommand("usp_GiroTolakTac_UPDATE"));
                //                db.Commands[0].Parameters.Clear();
                //                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr10["RowID"]));
                //                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr10["RecordID"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@KartuPiutangID", SqlDbType.UniqueIdentifier, dr10["KartuPiutangID"]));
                //                db.Commands[0].Parameters.Add(new Parameter("@KpID", SqlDbType.VarChar, Tools.isNull(dr10["KPID"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr10["KodeToko"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr10["Status"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr10["Alasan"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr10["TglGiro"], DBNull.Value)));
                //                db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, Tools.isNull(dr10["CbgJt"], DBNull.Value)));
                //                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr10["Uraian"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, double.Parse(Tools.isNull(dr10["Debet"], "0").ToString())));
                //                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr10["KodeSales"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoBkm", SqlDbType.VarChar, Tools.isNull(dr10["NoBkm"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoBg", SqlDbType.VarChar, Tools.isNull(dr10["NoBg"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr10["Bank"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, Tools.isNull(dr10["NoAcc"], "").ToString().Trim()));
                //                //db.Commands[0].Parameters.Add(new Parameter("@Audit", SqlDbType.Bit, int.Parse(cAudit.ToString())));
                //                db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, Tools.isNull(dr10["KetTagih"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr10["LastUpdatedBy"], "").ToString().Trim()));
                //                db.Commands[0].ExecuteNonQuery();
                //                db.CommitTransaction();
                //            }
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    //this.Cursor = Cursors.Default;
                //}
                #endregion


                #region  11.Update GiroTolakTac
                //try
                //{
                //    if (dsData.Tables[11].Rows.Count > 0)
                //    {
                //        tblupd += 1;
                //        label1.Text = "GiroTolakTac";
                //        lblUpload.Text = tblupd.ToString().Trim() + "/10";
                //        lblProgress.Text = "Updating..";
                //        this.refreshForm();

                //        foreach (DataRow dr11 in dsData.Tables[11].Rows)
                //        {
                //            using (Database db = new Database(GlobalVar.DBName))
                //            {
                //                db.Commands.Add(db.CreateCommand("usp_GiroTolakDetailTac_UPDATE"));
                //                db.Commands[0].Parameters.Clear();
                //                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr11["RowID"]));
                //                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dr11["HeaderID"]));
                //                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr11["RecordID"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr11["HRecordID"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.DateTime, Tools.isNull(dr11["TglBayar"], DBNull.Value)));
                //                db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, Tools.isNull(dr11["KodeBayar"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, double.Parse(Tools.isNull(dr11["Kredit"], "0").ToString())));
                //                db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, Tools.isNull(dr11["CbgJt"], DBNull.Value)));
                //                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr11["Uraian"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoBkm", SqlDbType.VarChar, Tools.isNull(dr11["NoBkm"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoBg", SqlDbType.VarChar, Tools.isNull(dr11["NoBg"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr11["Bank"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, Tools.isNull(dr11["NoAcc"], "").ToString().Trim()));
                //                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr11["LastUpdatedBy"], "").ToString().Trim()));
                //                db.Commands[0].ExecuteNonQuery();
                //                db.CommitTransaction();
                //            }
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    //this.Cursor = Cursors.Default;
                //}
                #endregion


                #region  0.Upload TokoTac
                try
                {
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "TokoTac";
                        string TableName = "TokoTac";

                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[0].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'TokoTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                        files.Add(Physical);

                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("TokoID", "idtoko", Foxpro.enFoxproTypes.Char, 7));
                        fields.Add(new Foxpro.DataStruct("NamaToko", "namatoko", Foxpro.enFoxproTypes.Char, 31));
                        fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
                        fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("Daerah", "daerah", Foxpro.enFoxproTypes.Char, 25));
                        fields.Add(new Foxpro.DataStruct("Propinsi", "propinsi", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("Telp", "notelp", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 8));
                        fields.Add(new Foxpro.DataStruct("PenanggungJawab", "pngjwb", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("PiutangB", "piutang_b", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("PiutangJ", "piutang_j", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("Plafon", "plafon", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("ToJual", "to_jual", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("ToRetPot", "to_retpot", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("JangkaWaktuKredit", "jkw_kredit", Foxpro.enFoxproTypes.Numeric, 3));
                        fields.Add(new Foxpro.DataStruct("Tgl1st", "tgl1st", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("Exist", "exist", Foxpro.enFoxproTypes.Logical, 1));
                        fields.Add(new Foxpro.DataStruct("StatusAktif", "lpasif", Foxpro.enFoxproTypes.Logical, 1));
                        fields.Add(new Foxpro.DataStruct("ClassID", "idclass", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 73));
                        fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("HariKirim", "hari_krm", Foxpro.enFoxproTypes.Numeric, 2));
                        fields.Add(new Foxpro.DataStruct("Grade", "grade", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("Plafon1st", "plafon_1st", Foxpro.enFoxproTypes.Numeric, 10));
                        fields.Add(new Foxpro.DataStruct("Flag", "flag", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("HariSales", "hari_sls", Foxpro.enFoxproTypes.Numeric, 5));
                        fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("AlamatRumah", "alm_rumah", Foxpro.enFoxproTypes.Char, 60));
                        fields.Add(new Foxpro.DataStruct("Pengelola", "pengelola", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("TglLahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("HP", "hp", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("Status", "status", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("ThnBerdiri", "th_berdiri", Foxpro.enFoxproTypes.Char, 4));
                        fields.Add(new Foxpro.DataStruct("StatusRuko", "lruko", Foxpro.enFoxproTypes.Logical, 1));
                        fields.Add(new Foxpro.DataStruct("JmlCabang", "jml_cabang", Foxpro.enFoxproTypes.Numeric, 2));
                        fields.Add(new Foxpro.DataStruct("JmlSales", "jml_sales", Foxpro.enFoxproTypes.Numeric, 2));
                        fields.Add(new Foxpro.DataStruct("Kinerja", "kinerja", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("RefSales", "reff_sls", Foxpro.enFoxproTypes.Char, 35));
                        fields.Add(new Foxpro.DataStruct("RefCollector", "reff_col", Foxpro.enFoxproTypes.Char, 35));
                        fields.Add(new Foxpro.DataStruct("RefSupervisor", "reff_spv", Foxpro.enFoxproTypes.Char, 35));
                        fields.Add(new Foxpro.DataStruct("PlafonSurvey", "plf_survey", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("BidangUsaha", "bdg_usaha", Foxpro.enFoxproTypes.Char, 10));
                        //--------
                        fields.Add(new Foxpro.DataStruct("Fax", "Fax", Foxpro.enFoxproTypes.Char, 25));
                        fields.Add(new Foxpro.DataStruct("bangunan", "bangunan", Foxpro.enFoxproTypes.Char, 15));
                        fields.Add(new Foxpro.DataStruct("habis_kontrak", "hbs_kont", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("jenis_produk", "produk", Foxpro.enFoxproTypes.Char, 25));
                        fields.Add(new Foxpro.DataStruct("nama_pemilik", "pemilik", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("jenis_kelamin", "kelamin", Foxpro.enFoxproTypes.Char, 10));
                        fields.Add(new Foxpro.DataStruct("tempat_lhr", "tempat_lhr", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("email", "email", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("no_rekening", "norekening", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("nama_bank", "nama_bank", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("no_member", "no_member", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("hobi", "hobi", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("no_npwp", "no_npwp", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("mediabyr", "mediabyr", Foxpro.enFoxproTypes.Char, 10));
                        fields.Add(new Foxpro.DataStruct("angsuran", "angsuran", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("ketbayar", "ketbayar", Foxpro.enFoxproTypes.Char, 40));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));
                        ////--
                        fields.Add(new Foxpro.DataStruct("KodePos", "kd_pos", Foxpro.enFoxproTypes.Char, 5));
                        fields.Add(new Foxpro.DataStruct("Bentrok", "bentrok", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("no_toko", "no_toko", Foxpro.enFoxproTypes.Char, 7));
                        fields.Add(new Foxpro.DataStruct("exp_norm", "exp_norm", Foxpro.enFoxproTypes.Char, 3));
                        fields.Add(new Foxpro.DataStruct("cab", "cab", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("cab1", "cab1", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("l_edit", "l_edit", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("idrec_post", "idrec_post", Foxpro.enFoxproTypes.Char, 23));

                        //fields.Add(new Foxpro.DataStruct("plafon", "plafon", Foxpro.enFoxproTypes.Numeric, 14));
                        //fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_Toko"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  1.Upload KartuPiutangTac
                try
                {
                    if (dsData.Tables[1].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "KartuPiutangTac";
                        string TableName = "KartuPiutangTac";

                        label1.Text = TableName;
                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[1].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'KartuPiutangTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("kpid", "id_kp", Foxpro.enFoxproTypes.Char, 23));
                        fields.Add(new Foxpro.DataStruct("kodetoko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("kodesales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                        fields.Add(new Foxpro.DataStruct("tgltransaksi", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("TglLink", "tgl_link", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("notransaksi", "no_tr", Foxpro.enFoxproTypes.Char, 7));
                        fields.Add(new Foxpro.DataStruct("status", "status", Foxpro.enFoxproTypes.Char, 8));
                        fields.Add(new Foxpro.DataStruct("jangkawaktu", "jk_waktu", Foxpro.enFoxproTypes.Numeric, 3));
                        fields.Add(new Foxpro.DataStruct("tgljatuhtempo", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
                        fields.Add(new Foxpro.DataStruct("cicil", "cicil", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("transactiontype", "id_tr", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("syncflag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("harikirim", "hari_krm", Foxpro.enFoxproTypes.Numeric, 2));
                        fields.Add(new Foxpro.DataStruct("harisales", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                        fields.Add(new Foxpro.DataStruct("keterangantagih", "ket_tagih", Foxpro.enFoxproTypes.Char, 15));
                        fields.Add(new Foxpro.DataStruct("lastupdatedby", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lastupdatedtime", "lut", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("Saldo", "Saldo", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("NamaToko", "NamaToko", Foxpro.enFoxproTypes.Char, 31));
                        fields.Add(new Foxpro.DataStruct("WilID", "WilID", Foxpro.enFoxproTypes.Char, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_KartuPiutang"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  2.Upload KartuPiutangDetailTac
                try
                {
                    if (dsData.Tables[2].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "KartuPiutangDetailTac";    // +GlobalVar.CabangID;
                        string TableName = "KartuPiutangDetailTac";
                        this.Cursor = Cursors.WaitCursor;

                        label1.Text = TableName;
                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[2].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'KartuPiutangDetailTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("HeaderID", "HeaderID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("RecordID", "RecordID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("KPID", "KPID", Foxpro.enFoxproTypes.Char, 23));
                        fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("KodeTransaksi", "kd_trans", Foxpro.enFoxproTypes.Char, 3));
                        fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 13));
                        fields.Add(new Foxpro.DataStruct("TglJTGiro", "cbg_jt", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
                        fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("NoBuktiKasMasuk", "no_bkm", Foxpro.enFoxproTypes.Char, 10));
                        fields.Add(new Foxpro.DataStruct("NoGiro", "NoGiro", Foxpro.enFoxproTypes.Char, 10));
                        fields.Add(new Foxpro.DataStruct("Bank", "Bank", Foxpro.enFoxproTypes.Char, 32));
                        fields.Add(new Foxpro.DataStruct("NoAcc", "NoAcc", Foxpro.enFoxproTypes.Char, 32));
                        fields.Add(new Foxpro.DataStruct("isClosed", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                        fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_KartuPiutangDetail"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  3.Upload SalesTac
                try
                {
                    if (dsData.Tables[3].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "SalesTac";
                        string TableName = "SalesTac";
                        this.Cursor = Cursors.WaitCursor;

                        label1.Text = TableName;
                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[3].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'SalesTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("SalesID", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                        fields.Add(new Foxpro.DataStruct("NamaSales", "nm_sales", Foxpro.enFoxproTypes.Char, 23));
                        fields.Add(new Foxpro.DataStruct("RecID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                        fields.Add(new Foxpro.DataStruct("TglLahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("Target", "target", Foxpro.enFoxproTypes.Numeric, 16));
                        fields.Add(new Foxpro.DataStruct("BatasOD", "batas_od", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("TglMasuk", "tgl_masuk", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("SalesID", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("NamaSales", "namatoko", Foxpro.enFoxproTypes.Char, 31));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_Sales"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  4.Upload StatusTokoTac
                try
                {
                    if (dsData.Tables[4].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "StatusTokoTac";
                        string TableName = "StatusTokoTac";
                        this.Cursor = Cursors.WaitCursor;
                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[4].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'StatusTokoTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("c1", "c1", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("tmt", "tmt", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("sts", "sts", Foxpro.enFoxproTypes.Char, 2));
                        fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
                        fields.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 30));
                        fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("ksts", "ksts", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("rd", "rd", Foxpro.enFoxproTypes.Char, 1));
                        fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 8));
                        fields.Add(new Foxpro.DataStruct("tmt_pasif", "tmt_pasif", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_StatusToko"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  5.Upload TokoPlafonTac
                try
                {
                    if (dsData.Tables[5].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "TokoPlafonTac";
                        string TableName = "TokoPlafonTac";

                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[5].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'TokoPlafonTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 8));
                        fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("plf_fb", "plf_fb", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_fx", "plf_fx", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_fa", "plf_fa", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_kb", "plf_kb", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_kh", "plf_kh", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_kv", "plf_kv", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("plf_kg", "plf_kg", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("max_credit", "max_credit", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("max_fb", "max_fb", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("max_fx", "max_fx", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("max_fa", "max_fa", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("tmptoko", "tmptoko", Foxpro.enFoxproTypes.Numeric, 14));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_TokoPlafon"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  6.Upload AccountTokoTac
                try
                {
                    if (dsData.Tables[6].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "AccountTokoTac";
                        string TableName = "AccountTokoTac";
                        this.Cursor = Cursors.WaitCursor;

                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[6].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'AccountTokoTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("KodeToko", "KodeToko", Foxpro.enFoxproTypes.Char, 19));
                        fields.Add(new Foxpro.DataStruct("NoAccount", "NoAccount", Foxpro.enFoxproTypes.Char, 15));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_AccountToko"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  7.Upload BarcodeNotaTac
                try
                {
                    if (dsData.Tables[7].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "BarcodeNotaTac";
                        string TableName = "BarcodeNotaTac";
                        this.Cursor = Cursors.WaitCursor;

                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[7].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'BarcodeNotaTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("NotaRowID", "NotaID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("Barcode", "Barcode", Foxpro.enFoxproTypes.Char, 35));
                        fields.Add(new Foxpro.DataStruct("CreatedBy", "CBy", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("CreatedTime", "CTime", Foxpro.enFoxproTypes.DateTime, 8));
                        fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_BarcodeNota"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region Upload BarcodeNotaDetailTac
                //try
                //{
                //    if (dsData.Tables[8].Rows.Count > 0)
                //    {
                //        SqlDataReader drr;
                //        string FileName = "BarcodeNotaDetailTac";

                //        string TableName = "BarcodeNotadetailTac";
                //        label1.Text = TableName;

                //        this.Cursor = Cursors.WaitCursor;

                //        pbSyncUpload.Value = 0;
                //        lblProgress.Text = "Data 'BarcodeNotaDetailTac' is Uploading...";
                //        refreshForm();
                //        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //        files.Add(Physical);

                //        if (File.Exists(Physical))
                //        {
                //            File.Delete(Physical);
                //        }

                //        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                //        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("HeaderID", "HeaderID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("TglScan", "TglScan", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("CreatedBy", "CreatedBy", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("CreatedTime", "CreatedTime", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                //        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                //        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                //        using (Database db = new Database(GlobalVar.DBName))
                //        {
                //            db.Commands.Add(db.CreateCommand("usp_Tac_UPLOAD_BarcodeNotaDetailTac"));
                //            db.Open();
                //            drr = db.Commands[0].ExecuteReader();
                //            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                //            db.Close();
                //            lblProgress.Text = "";
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    this.Cursor = Cursors.Default;
                //}
                #endregion


                #region  9.Upload PinCounterTac
                try
                {
                    if (dsData.Tables[9].Rows.Count > 0)
                    {
                        SqlDataReader drr;
                        string FileName = "PinCounterTac";
                        string TableName = "PinCounterTac";
                        this.Cursor = Cursors.WaitCursor;

                        tblupl += 1;
                        label1.Text = TableName;
                        Counter.Text = dsData.Tables[9].Rows.Count.ToString();
                        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                        lblProgress.Text = "Data 'PinCounterTac' is Uploading...";
                        pbSyncUpload.Value = 0;
                        refreshForm();

                        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                        files.Add(Physical);
                        if (File.Exists(Physical))
                        {
                            File.Delete(Physical);
                        }

                        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("Kode", "Kode", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("Nama", "Nama", Foxpro.enFoxproTypes.Char, 50));
                        fields.Add(new Foxpro.DataStruct("FlagPin", "FlagPin", Foxpro.enFoxproTypes.Numeric, 1));
                        fields.Add(new Foxpro.DataStruct("SyncFlag", "SyncFlag", Foxpro.enFoxproTypes.Numeric, 1));
                        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tac_Upload_PinCounter"));
                            db.Open();
                            drr = db.Commands[0].ExecuteReader();
                            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                            db.Close();
                            lblProgress.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //this.Cursor = Cursors.Default;
                }
                #endregion


                #region  10.Upload GiroTolakTac
                //try
                //{
                //    if (dsData.Tables[10].Rows.Count > 0)
                //    {
                //        SqlDataReader drr;
                //        string FileName = "GiroTolakTac";
                //        string TableName = "GiroTolakTac";
                //        this.Cursor = Cursors.WaitCursor;

                //        tblupl += 1;
                //        label1.Text = TableName;
                //        Counter.Text = dsData.Tables[10].Rows.Count.ToString();
                //        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                //        lblProgress.Text = "Data 'GiroTolakTac' is Uploading...";
                //        pbSyncUpload.Value = 0;
                //        refreshForm();

                //        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                //        files.Add(Physical);
                //        if (File.Exists(Physical))
                //        {
                //            File.Delete(Physical);
                //        }

                //        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                //        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("RecordID", "RecordID", Foxpro.enFoxproTypes.Char, 23));
                //        fields.Add(new Foxpro.DataStruct("KpiutID", "KpiutID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("KPID", "KPID", Foxpro.enFoxproTypes.Char, 23));
                //        fields.Add(new Foxpro.DataStruct("KodeToko", "KodeToko", Foxpro.enFoxproTypes.Char, 19));
                //        fields.Add(new Foxpro.DataStruct("Status", "Status", Foxpro.enFoxproTypes.Char, 8));
                //        fields.Add(new Foxpro.DataStruct("Alasan", "Alasan", Foxpro.enFoxproTypes.Char, 43));
                //        fields.Add(new Foxpro.DataStruct("TglGiro", "TglGiro", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("CbgJt", "CbgJt", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 43));
                //        fields.Add(new Foxpro.DataStruct("Debet", "Debet", Foxpro.enFoxproTypes.Numeric, 14));
                //        fields.Add(new Foxpro.DataStruct("KodeSales", "KdSales", Foxpro.enFoxproTypes.Char, 11));
                //        fields.Add(new Foxpro.DataStruct("SyncFlag", "SyncFlag", Foxpro.enFoxproTypes.Numeric, 1));
                //        fields.Add(new Foxpro.DataStruct("NoBkm", "NoBkm", Foxpro.enFoxproTypes.Char, 5));
                //        fields.Add(new Foxpro.DataStruct("NoBg", "NoBg", Foxpro.enFoxproTypes.Char, 10));
                //        fields.Add(new Foxpro.DataStruct("Bank", "Bank", Foxpro.enFoxproTypes.Char, 15));
                //        fields.Add(new Foxpro.DataStruct("NoAcc", "NoAcc", Foxpro.enFoxproTypes.Char, 15));
                //        fields.Add(new Foxpro.DataStruct("Audit", "Audit", Foxpro.enFoxproTypes.Logical, 1));
                //        fields.Add(new Foxpro.DataStruct("KetTagih", "KetTagih", Foxpro.enFoxproTypes.Char, 10));
                //        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                //        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                //        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                //        using (Database db = new Database(GlobalVar.DBName))
                //        {
                //            db.Commands.Add(db.CreateCommand("usp_Tac_Upload_GiroTolak"));
                //            db.Open();
                //            drr = db.Commands[0].ExecuteReader();
                //            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                //            db.Close();
                //            lblProgress.Text = "";
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    //this.Cursor = Cursors.Default;
                //}
                #endregion


                #region  11.Upload GiroTolakDetailTac
                //try
                //{
                //    if (dsData.Tables[11].Rows.Count > 0)
                //    {
                //        SqlDataReader drr;
                //        string FileName = "GiroTolakDetailTac";
                //        string TableName = "GiroTolakDetailTac";
                //        this.Cursor = Cursors.WaitCursor;

                //        tblupl += 1;
                //        label1.Text = TableName;
                //        Counter.Text = dsData.Tables[11].Rows.Count.ToString();
                //        lblUpload.Text = tblupl.ToString().Trim() + "/9";
                //        lblProgress.Text = "Data 'GiroTolakDetailTac' is Uploading...";
                //        pbSyncUpload.Value = 0;
                //        refreshForm();

                //        string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                //        files.Add(Physical);
                //        if (File.Exists(Physical))
                //        {
                //            File.Delete(Physical);
                //        }

                //        List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                //        fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("HeaderID", "HeaderID", Foxpro.enFoxproTypes.Char, 50));
                //        fields.Add(new Foxpro.DataStruct("RecordID", "RecordID", Foxpro.enFoxproTypes.Char, 23));
                //        fields.Add(new Foxpro.DataStruct("HRecodID", "HRecodID", Foxpro.enFoxproTypes.Char, 23));
                //        fields.Add(new Foxpro.DataStruct("TglBayar", "TglBayar", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("KodeBayar", "KdBayar", Foxpro.enFoxproTypes.Char, 3));
                //        fields.Add(new Foxpro.DataStruct("Kredit", "Kredit", Foxpro.enFoxproTypes.Numeric, 14));
                //        fields.Add(new Foxpro.DataStruct("CbgJt", "CbgJt", Foxpro.enFoxproTypes.DateTime, 8));
                //        fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 43));
                //        fields.Add(new Foxpro.DataStruct("NoBkm", "NoBkm", Foxpro.enFoxproTypes.Char, 5));
                //        fields.Add(new Foxpro.DataStruct("NoBg", "NoBg", Foxpro.enFoxproTypes.Char, 10));
                //        fields.Add(new Foxpro.DataStruct("Bank", "Bank", Foxpro.enFoxproTypes.Char, 15));
                //        fields.Add(new Foxpro.DataStruct("NoAcc", "NoAcc", Foxpro.enFoxproTypes.Char, 15));
                //        fields.Add(new Foxpro.DataStruct("SyncFlag", "SyncFlag", Foxpro.enFoxproTypes.Numeric, 1));
                //        fields.Add(new Foxpro.DataStruct("lub", "lub", Foxpro.enFoxproTypes.Char, 20));
                //        fields.Add(new Foxpro.DataStruct("lut", "lut", Foxpro.enFoxproTypes.DateTime, 8));

                //        List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();

                //        using (Database db = new Database(GlobalVar.DBName))
                //        {
                //            db.Commands.Add(db.CreateCommand("usp_Tac_Upload_GiroTolakDetail"));
                //            db.Open();
                //            drr = db.Commands[0].ExecuteReader();
                //            Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, drr, index, this, pbSyncUpload, lblUploadCount);
                //            db.Close();
                //            lblProgress.Text = "";
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    //this.Cursor = Cursors.Default;
                //}
                #endregion

                
                #region Update Pelunasan KartuPiutangDetail
                //if (dsData.Tables[1].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dsData.Tables[1].Rows)
                //    {
                //        using (Database db = new Database(GlobalVar.DBName))
                //        {
                //            db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_TAC_UPDATE"));
                //            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dr["RowID"] ));
                //            db.Commands[0].ExecuteNonQuery();
                //            db.CommitTransaction();
                //        }
                //    }
                //}
                #endregion


                DialogResult jawab = MessageBox.Show("Update Detail Piutang dengan Pelunasan ?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (jawab == DialogResult.Yes)
                {
                    UpdatePelunasan();
                }


                this.Cursor = Cursors.WaitCursor;
                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Tac_Report"));
                        dsData = db.Commands[0].ExecuteDataSet();
                        if (dsData.Tables.Count > 0)
                            DisplayReport();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Proses Tac Selesai..");
            }
        }


        private void UpdatePelunasan()
        {
            //Get Data KartuPiutangTac
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_GetDataPiutangTac_LIST"));
                    dsData2 = db.Commands[0].ExecuteDataSet();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


            //Update KartuPiutangdetail
            if (dsData2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dru in dsData2.Tables[0].Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_TAC_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dru["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, txtGudang.Text));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                }
            }



            //Get Data TokoTac
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_GetDataTokoTac_LIST"));
                    dsData2 = db.Commands[0].ExecuteDataSet();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


            //Update Toko
            if (dsData2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drt in dsData2.Tables[0].Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Toko_TAC_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, drt["RowID"]));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                }
            }

            this.Cursor = Cursors.Default;
            MessageBox.Show("Proses Update Pelunasan Selesai..");

        }



        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapTac());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LapTac";
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


        private ExcelPackage LapTac()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "TAC";
            ex.Workbook.Properties.SetCustomPropertyValue("TAC", "1147");

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
            ws.Cells[1, 2].Value = "TRANSFER ANTAR CABANG (TAC)";
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
                ws.Cells[rowx, 3].Value = Tools.isNull(dr["TokoID"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr["KodeToko"], "");
                ws.Cells[rowx, 5].Value = Tools.isNull(dr["NamaToko"], "");
                ws.Cells[rowx, 6].Value = Tools.isNull(dr["Alamat"], "");
                ws.Cells[rowx, 7].Value = Tools.isNull(dr["Kota"], "");
                ws.Cells[rowx, 8].Value = Tools.isNull(dr["WilID"], "");
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
                no2 += 1;
                ws2.Cells[rowx2, 2].Value = no2.ToString();
                ws2.Cells[rowx2, 3].Value = Tools.isNull(dr0["NoTransaksi"], "");
                ws2.Cells[rowx2, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglTransaksi"], ""));
                ws2.Cells[rowx2, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglLink"], ""));
                ws2.Cells[rowx2, 6].Value = Tools.isNull(dr0["JangkaWaktu"], 0);
                ws2.Cells[rowx2, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 7].Value = Tools.isNull(dr0["HariSales"], 0);
                ws2.Cells[rowx2, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglJatuhTempo"], ""));
                ws2.Cells[rowx2, 9].Value = Tools.isNull(dr0["TransactionType"], "");
                ws2.Cells[rowx2,10].Value = Tools.isNull(dr0["KodeSales"], "");
                ws2.Cells[rowx2,11].Value = Tools.isNull(dr0["KodeToko"], "");
                ws2.Cells[rowx2,12].Value = Tools.isNull(dr0["NamaToko"], "");
                ws2.Cells[rowx2,13].Value = Tools.isNull(dr0["WilID"], "");
                ws2.Cells[rowx2,14].Value = Tools.isNull(dr0["Saldo"], 0);
                ws2.Cells[rowx2,14].Style.Numberformat.Format = "#,##;(#,##);0";
                rowx2++;
                Saldo = Saldo + Convert.ToDouble(Tools.isNull(dr0["Saldo"], 0));
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

            foreach (DataRow dr0 in dsData.Tables[2].Rows)
            {
                no3 += 1;
                ws3.Cells[rowx3, 2].Value = no3.ToString();
                ws3.Cells[rowx3, 3].Value = Tools.isNull(dr0["SalesID"], "");
                ws3.Cells[rowx3, 4].Value = Tools.isNull(dr0["NamaSales"], "");
                ws3.Cells[rowx3, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglMasuk"], ""));
                ws3.Cells[rowx3, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglKeluar"], ""));
                rowx3++;
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



        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void DownloadCount()
        {
            uploadTable++;
            lblUpload.Text = uploadTable.ToString() + "/" + jumlahTable.ToString();
        }

        private void cmdWilayah_Click(object sender, EventArgs e)
        {
            Tac.frmWilayah ifrmChild = new Tac.frmWilayah();
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tac.frmKota ifrmChild = new Tac.frmKota();
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;

        }

        private void cmdToko_Click(object sender, EventArgs e)
        {
            Tac.frmToko ifrmChild = new Tac.frmToko();
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tac_Report"));
                    dsData = db.Commands[0].ExecuteDataSet();
                    if (dsData.Tables.Count > 0)
                        DisplayReport();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            DialogResult jawab = MessageBox.Show("Update Detail Piutang dengan Pelunasan ?","Konfirmasi", MessageBoxButtons.YesNo);
            if (jawab == DialogResult.Yes)
            {
                UpdatePelunasan();
            }
        }

        private void cmdLaporan_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tac_Report"));
                    dsData = db.Commands[0].ExecuteDataSet();
                    if (dsData.Tables.Count > 0)
                        DisplayReport();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void cmdSales_Click(object sender, EventArgs e)
        {
            Tac.frmSales ifrmChild = new Tac.frmSales();
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;

        }

        private void cmdPlafon_Click(object sender, EventArgs e)
        {
            DialogResult jawab = MessageBox.Show("Update Plafon Toko ?","Konfirmasi", MessageBoxButtons.YesNo);
            if (jawab == DialogResult.Yes)
            {

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Refresh_Plafon"));
                        dsData = db.Commands[0].ExecuteDataSet();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

                try
                {
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr3 in dsData.Tables[0].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PlafonToko_05_Update"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr3["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, Tools.isNull(dr3["Plf_fb"],0)));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();

                                MessageBox.Show(Tools.isNull(dr3["Plf_fb"],0).ToString());
                            }
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
                    MessageBox.Show("Proses Selesai..");
                }
            }

        }
    }
}
