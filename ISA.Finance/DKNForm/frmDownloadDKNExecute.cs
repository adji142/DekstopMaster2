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

namespace ISA.Finance.DKNForm
{
    public partial class frmDownloadDKNExecute : ISA.Finance.BaseForm
    {
        DataTable dtDKN;
        DataTable dtSdhDownload;
        Guid BankAsalRowID, BankTujuanRowID;

        public event EventHandler SelectData;

        string NamaBankTujuan = "";
        string BankIDTujuan = "";
        string noRekening = "";
        string IndenInput = "true";

        int prevRow=-1;
        public frmDownloadDKNExecute()
        {
            InitializeComponent();
        }
        public frmDownloadDKNExecute(DataTable dt)
        {
            InitializeComponent();
            dtDKN = dt;
        }

        private void frmDownloadDKNExecute_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = true;
            customGridView1.DataSource = dtDKN;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtp = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@mdl", SqlDbType.VarChar, "STK"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrn", SqlDbType.VarChar, "IND"));
                    dtp = db.Commands[0].ExecuteDataTable();
                    if (dtp.Rows.Count > 0)
                    {
                        lookupPerkiraan1.NoPerkiraan = dtp.Rows[0]["NoPerkiraan"].ToString();
                        lookupPerkiraan1.NamaPerkiraan = dtp.Rows[0]["Uraian"].ToString();
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

        private void lookupPerkiraan1_SelectData(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DataRowView drv = (DataRowView) customGridView1.SelectedCells[0].OwningRow.DataBoundItem;
                drv.Row["no_perk"] = lookupPerkiraan1.NoPerkiraan;
            }
        }

        private void cmdTolak_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DataRowView drv = (DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem;
                drv.Row["lTolak"] = !(bool)drv.Row["lTolak"];
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool bank = true;
            foreach (DataGridViewRow row in customGridView1.Rows)
            {
                if (Tools.isNull(row.Cells[Bankasal.Name].Value,"").ToString() == "")
                {
                    bank = false;
                }
                string curIDhead = row.Cells[Idhead.Name].Value.ToString();
            }

            if (bank == false)
            {
                MessageBox.Show("Nama Bank Asal masih ada yang kosong.");
                return;
            }
            Download();
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow != customGridView1.SelectedCells[0].RowIndex)
                {
                    lookupPerkiraan1.NoPerkiraan = customGridView1.SelectedCells[0].OwningRow.Cells["no_perk"].Value.ToString();
                    lookupPerkiraan1.NamaPerkiraan = "";
                    prevRow = customGridView1.SelectedCells[0].RowIndex;
                }
            }
        }

        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            dtSdhDownload = dtDKN.Clone();
            DataTable dt = new DataTable();
            int result = 0;

            #region Cek IndenInput paycol
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dta = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "identifikasi_input"));
                    dta = db.Commands[0].ExecuteDataTable();
                    if (dta.Rows.Count > 0)
                    {
                        IndenInput = Tools.isNull(dta.Rows[0]["value"], "true").ToString();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            #endregion

            #region GetBankAsal
            ///*Getdata bank asal*/
            //string LokasiBank = lookupBankAsal1.Lokasi;
            //string NamaBankAsal = lookupBankAsal1.NamaBank;
            //try
            //{
            //    DataTable dtb = new DataTable(GlobalVar.DBName);
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database(GlobalVar.DBName))
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_BankKota_LIST"));
            //        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, NamaBankAsal));
            //        db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, LokasiBank));
            //        dtb = db.Commands[0].ExecuteDataTable();
            //        if (dtb.Rows.Count > 0)
            //        {
            //            BankAsalRowID = new Guid(dtb.Rows[0]["RowID"].ToString());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Bank Kota tidak ada.");
            //            return;
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            #endregion

            #region insert dkn
            string prevIDhead = "";
            Guid jHeader = Guid.NewGuid();
            string jRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            DataTable dtHI = Class.Perkiraan.GetPerkiraanKoneksiDetail("HI11");
            double sumHI = 0;
            string uraian = "";
            string InitGudang = GlobalVar.Gudang;

            progressBar1.Maximum = customGridView1.Rows.Count;

            foreach (DataGridViewRow row in customGridView1.Rows)
            {
                string GudangTujuan = Tools.isNull(row.Cells[Cabang.Name].Value, "").ToString();
                if (GudangTujuan.ToString().Trim() == InitGudang.ToString().Trim())
                {
                    string curIDhead = row.Cells[Idhead.Name].Value.ToString();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.BeginTransaction();
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_DKN_Download"));
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(row.Cells[Hrowid.Name].Value.ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, new Guid(row.Cells[Dtrowid.Name].Value.ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(row.Cells[Idhead.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(row.Cells[Iddetail.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, Tools.isNull(row.Cells[No_Dkn.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(row.Cells[DK.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(row.Cells[Cabang.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, Tools.isNull(row.Cells[Cd.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(row.Cells[Src.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefTipe", SqlDbType.Int, Tools.isNull(row.Cells[Reftipe.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefNoBukti", SqlDbType.Char, Tools.isNull(row.Cells[Nobuktipu.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, new Guid(row.Cells[Refrowid.Name].Value.ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.Char, Tools.isNull(row.Cells[No_perk.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.Char, Tools.isNull(row.Cells[Uraian.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, double.Parse(Tools.isNull(row.Cells[Jumlah.Name].Value, "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Tolak", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.Char, Tools.isNull(row.Cells[Alasan.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.Char, Tools.isNull(row.Cells[Dari.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@Nprint", SqlDbType.Int, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(row.Cells[Updateby.Name].Value, "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.Date, DateTime.Parse(Tools.isNull(row.Cells[Updatetime.Name].Value, "").ToString())));
                        db.Commands[0].ExecuteNonQuery();

                        #region jurnal
                        ///*Hapus Data Lama GL dulu*/
                        //if (prevIDhead != curIDhead)
                        //{
                        //    db.Commands.Clear();
                        //    db.Commands.Add(db.CreateCommand("psp_DKN_Download_DeleteJournal"));
                        //    db.Commands[0].Parameters.Clear();
                        //    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, curIDhead.ToString()));
                        //    db.Commands[0].ExecuteNonQuery();
                        //}

                        //bool tolak = Convert.ToBoolean(row.Cells[Ltolak.Name].Value);
                        //if (!tolak)
                        //{
                        //    string cd = row.Cells[DK.Name].Value.ToString();
                        //    string noDKNPerk = ""; //row.Cells[No_Dkn.Name].Value.ToString().Trim();
                        //    string namaDKNPerk = "";
                        //    if (noDKNPerk != "")
                        //    {
                        //        DataTable dtPerk = Class.Perkiraan.GetPerkiraan(noDKNPerk);
                        //        if (dtPerk.Rows.Count > 0)
                        //        {
                        //            namaDKNPerk = dtPerk.Rows[0]["NamaPerkiraan"].ToString();
                        //        }
                        //    }
                        //    else
                        //    {
                        //        namaDKNPerk = "";
                        //    }

                        //    /*Header*/
                        //    if (prevIDhead != curIDhead)
                        //    {
                        //        /*create data baru*/
                        //        sumHI = 0;
                        //        jHeader = Guid.NewGuid();
                        //        jRecID = row.Cells[Idhead.Name].Value.ToString();
                        //        DateTime tglJournal = Convert.ToDateTime(row.Cells[Tanggal.Name].Value.ToString());
                        //        string noReff = Tools.isNull(row.Cells[No_Dkn.Name].Value, "").ToString();
                        //        uraian = "LINK HUTANG HI " + noReff;
                        //        Class.Journal.AddHeader(db, jHeader, jRecID, tglJournal, noReff, uraian, "DKN", GlobalVar.Gudang, false);
                        //        prevIDhead = curIDhead;
                        //    }

                        //    /*Debet*/
                        //    Guid jdRowID = Guid.NewGuid();
                        //    string jdRecID = row.Cells[Iddetail.Name].Value.ToString();
                        //    string noPerk = noDKNPerk;
                        //    string dk = "";
                        //    string jdUraian1 = Tools.isNull(row.Cells[Uraian.Name].Value, "").ToString();
                        //    double debet = 0;
                        //    double kredit = 0;
                        //    if (cd == "D")
                        //    {
                        //        dk = "D";
                        //        debet = Convert.ToDouble(row.Cells[Jumlah.Name].Value);
                        //        sumHI -= Convert.ToDouble(row.Cells[Jumlah.Name].Value); ;
                        //    }
                        //    else
                        //    {
                        //        dk = "K";
                        //        kredit = Convert.ToDouble(row.Cells[Jumlah.Name].Value);
                        //        sumHI += Convert.ToDouble(row.Cells[Jumlah.Name].Value);
                        //    }
                        //    Class.Journal.AddDetail(db, jdRowID, jHeader, jdRecID, jRecID, noPerk, jdUraian1, debet, kredit, dk);

                        //    /*INSERT LAWAN*/
                        //    Guid jdRowIDL = Guid.NewGuid();
                        //    string jdRecIDL = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        //    string noPerkL = dtHI.Rows[0]["NoPerkiraan"].ToString();
                        //    string dkL = "";
                        //    string jdUraian1L = Tools.isNull(row.Cells[Uraian.Name].Value, "").ToString();
                        //    double debetL = 0;
                        //    double kreditL = 0;
                        //    if (sumHI > 0)
                        //    {
                        //        dkL = "D";
                        //        debetL = Convert.ToDouble(sumHI);
                        //    }
                        //    else
                        //    {
                        //        dkL = "K";
                        //        kreditL = Math.Abs(sumHI);
                        //    }
                        //    Class.Journal.AddDetail(db, jdRowIDL, jHeader, jdRecIDL, jRecID, noPerkL, jdUraian1L, debetL, kreditL, dkL);
                        //    sumHI = 0;
                        //}
                        db.CommitTransaction();
                        #endregion

                    }
                }

                #region GetBankTujuan
                /*Getdata bank tujuan*/
                NamaBankTujuan = "";
                BankIDTujuan = "";
                noRekening = Tools.isNull(row.Cells[Norekeningd.Name].Value, "").ToString();
                try
                {
                    DataTable dtb = new DataTable(GlobalVar.DBName);
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_NoRekeningBank_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, noRekening));
                        dtb = db.Commands[0].ExecuteDataTable();
                        if (dtb.Rows.Count > 0)
                        {
                            NamaBankTujuan = Tools.isNull(dtb.Rows[0]["NamaBank"], "").ToString();
                            BankIDTujuan = Tools.isNull(dtb.Rows[0]["BankID"], "").ToString();
                            BankTujuanRowID = new Guid(Tools.isNull(dtb.Rows[0]["RowID"], "").ToString());
                        }
                        else
                        {
                            MessageBox.Show("Bank Tujuan tidak ada.");
                            return;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                #endregion

                #region link data KN ditutup jika Paycoll jalan
                if (IndenInput == "true")
                {
                    try
                    {
                        frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
                        Guid headerRowID = new Guid(Tools.isNull(row.Cells[Hrowid.Name].Value, Guid.Empty).ToString());
                        Guid detailRowID = new Guid(Tools.isNull(row.Cells[Dtrowid.Name].Value, Guid.Empty).ToString());
                        string noDKN = Tools.isNull(row.Cells[No_Dkn.Name].Value, "").ToString();
                        string recordID = Tools.isNull(row.Cells[Idhead.Name].Value, "").ToString();
                        string recordIDD = Tools.isNull(row.Cells[Iddetail.Name].Value, "").ToString();
                        string updateBy = Tools.isNull(row.Cells[Updateby.Name].Value, "").ToString();
                        string noBukti = Tools.isNull(row.Cells[Nobuktipu.Name].Value, "").ToString();
                        string noPerkiraan = Tools.isNull(row.Cells[No_perk.Name].Value, "").ToString();
                        string namaBankAsal = Tools.isNull(row.Cells[Bankasal.Name].Value, "").ToString();
                        string lokasiBankAsal = Tools.isNull(row.Cells[Lokasi.Name].Value, "").ToString();
                        double RpTrf = double.Parse(Tools.isNull(row.Cells[Jumlah.Name].Value, "0").ToString());
                        DateTime LastUpdatedTime = DateTime.Parse(Tools.isNull(row.Cells[Updatetime.Name].Value, DateTime.Now).ToString());

                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("psp_DKN_LINK"));
                            db.Commands[0].Parameters.Add(new Parameter("@NomorKN", SqlDbType.VarChar, noDKN));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@detailRowID", SqlDbType.UniqueIdentifier, detailRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, recordID));
                            db.Commands[0].Parameters.Add(new Parameter("@RecIDDetail", SqlDbType.VarChar, recordIDD));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, GlobalVar.DateOfServer));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, updateBy));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBukti));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
                            db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, noDKN));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaBankAsal", SqlDbType.VarChar, namaBankAsal));
                            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lokasiBankAsal));
                            db.Commands[0].Parameters.Add(new Parameter("@BankAsalRowID", SqlDbType.UniqueIdentifier, BankAsalRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRekenig", SqlDbType.VarChar, noRekening));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaBankTujuan", SqlDbType.VarChar, NamaBankTujuan));
                            db.Commands[0].Parameters.Add(new Parameter("@BankIDTujuan", SqlDbType.VarChar, BankIDTujuan));
                            db.Commands[0].Parameters.Add(new Parameter("@BankTujuanRowID", SqlDbType.UniqueIdentifier, BankTujuanRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RpTrf", SqlDbType.Money, RpTrf));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, updateBy));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, LastUpdatedTime));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    /*endlink.........*/
                }
                #endregion
            }

            /*Perkiraan HI Last Check*/
            if (sumHI != 0)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    Guid jdRowID = Guid.NewGuid();
                    string jdRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    string noPerk = dtHI.Rows[0]["NoPerkiraan"].ToString();
                    string dk = "";
                    string jdUraian1 = uraian;//dtHI.Rows[0]["Uraian"].ToString();
                    double debet = 0;
                    double kredit = 0;
                    if (sumHI > 0)
                    {
                        dk = "D";
                        debet = sumHI;
                    }
                    else
                    {
                        dk = "K";
                        kredit = Math.Abs(sumHI);
                    }
                    Class.Journal.AddDetail(db, jdRowID, jHeader, jdRecID, jRecID, noPerk, jdUraian1, debet, kredit, dk);
                    sumHI = 0;
                }
            }
            MessageBox.Show(Messages.Confirm.ProcessFinished);
            #endregion

        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DKNForm.frmBankasalUpdate ifrmChild = new DKNForm.frmBankasalUpdate(this);
                ifrmChild.ShowDialog();
                if (ifrmChild.DialogResult == DialogResult.OK)
                {
                    customGridView1.SelectedCells[0].OwningRow.Cells["Bankasal"].Value = ifrmChild.NamaBank;
                    customGridView1.SelectedCells[0].OwningRow.Cells["Lokasi"].Value = ifrmChild.Lokasi;
                }
            }
        }

    }
}
