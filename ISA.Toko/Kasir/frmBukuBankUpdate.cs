using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;
using System.Data.SqlTypes;

namespace ISA.Toko.Kasir
{
    public partial class frmBukuBankUpdate : ISA.Toko.BaseForm
    {
        enum enumFrmMode { New, Update };
        enum enumUpdateMode {Header, Detail};
        enumFrmMode frmMode;
        enumUpdateMode updateMode;
        Guid rowID, rowIDDetail, rowIDBank2;
        string kdTransaksi, nmTransaksi, dk, noPerkiraan, nobbk, nobgch, bankID, namaBank, bankID2;
        public event EventHandler SelectData, SelectData2;
        DataTable dtBank;
        DataTable dtBankLookup;

        string  keterangan, debet, kredit;
        DateTime tglBank, tglRK;


        public frmBukuBankUpdate(Form caller)
        {
            //NEW Header
            InitializeComponent();
            this.Caller = caller;
            frmMode = enumFrmMode.New;
            updateMode = enumUpdateMode.Header;
            
        }

        
        public frmBukuBankUpdate(Form caller, Guid rowID, DataTable dtBankLookup)
        {

            // NEW DETAIL
            InitializeComponent();
            this.Caller = caller;
            frmMode = enumFrmMode.New;
            updateMode = enumUpdateMode.Detail;
            this.rowID = rowID;
            this.dtBankLookup = dtBankLookup.Copy();
        }

        public frmBukuBankUpdate(Form caller, Guid rowID)
        {

            // UPDATE HEADER

            InitializeComponent();
            this.Caller = caller;
            frmMode = enumFrmMode.Update;
            updateMode = enumUpdateMode.Header;
            this.rowID = rowID;
        }

        public frmBukuBankUpdate(Form caller, Guid rowID, Guid rowIDDetail, string noBBK, string noBGCH, DateTime tglBank, DateTime tglRK, string Keterangan, string Debet, string Kredit)
        {
            InitializeComponent();
            this.Caller = caller;
            frmMode = enumFrmMode.Update;
            updateMode = enumUpdateMode.Detail;
            this.rowID = rowID;
            this.rowIDDetail = rowIDDetail;
            this.nobbk = noBBK;
            this.nobgch = noBGCH;
            this.tglBank = tglBank;
            this.tglRK = tglRK;
            this.keterangan = Keterangan;
            this.debet = Debet;
            this.kredit = Kredit;
        }


        private void frmBukuBankUpdate_Load(object sender, EventArgs e)
        {
            this.Title = updateMode == enumUpdateMode.Header ? this.Title + " Header" : " Detail";
            this.Title = frmMode == enumFrmMode.New ? this.Title + " Insert" : " Update";

            if (updateMode == enumUpdateMode.Header)
            {
                
                if (frmMode == enumFrmMode.New)
                {
                    clearDetail();
                    clearHeader();
                    gbDetailBank.Enabled = false;
                }
                else
                {
                    clearDetail();
                    isiHeader();
                    gbDetailBank.Enabled = false;
                }
            }
            else
            {
                clearHeader();
                clearDetail();
                isiHeader();
                gbHeaderBank.Enabled = false;
                if (frmMode == enumFrmMode.New)
                {


                    lookupTransaksiDialog();
                    tbTglBank.DateValue = DateTime.Today;
                    tbTglRK.DateValue = DateTime.Today;
                    tbTglRK.SelectAll();
                    tbNomor.Text = nobbk;
                    tbKeterangan.Text = nmTransaksi + " (" + nobgch + ")";

                    tbSaldoAkhir.Text = tbSaldoAwal.Text = dtBank.Rows[0]["Saldo"].ToString();

                    if (dk == "D")
                    {
                        tbKredit.Enabled = false;
                    }
                    else
                    {
                        tbDebet.Enabled = false;
                    }
                    
                }
                else
                {
                    tbNomor.Text = nobbk;
                    tbTglBank.DateValue = tglBank;
                    tbTglRK.DateValue = tglRK;
                    tbKeterangan.Text = keterangan;
                    tbSaldoAwal.Text = (Convert.ToDouble(tbSaldo.Text)+Convert.ToDouble(kredit)-Convert.ToDouble(debet)).ToString();
                    tbSaldoAkhir.Text = tbSaldo.Text;
                    tbDebet.Text = debet;
                    tbKredit.Text = kredit;
                }
            }
        }

        private void lookupTransaksiDialog()
        {
            frmLookupTransaksiBank ifrmDialog = new frmLookupTransaksiBank();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
                getNo();                                               
            }
            else
            {
                this.Close();
            }
        }

        private void GetDialogResult(frmLookupTransaksiBank dialogForm)
        {
            this.kdTransaksi = dialogForm.KdTransaksi;
            this.nmTransaksi = dialogForm.NmTransaksi;
            this.dk = dialogForm.dk;
            this.noPerkiraan = dialogForm.noPerkiraan;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }

            if (noPerkiraan == "")
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    noPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();
                }
            }

            if (kdTransaksi == "BM1")
            {
                LookupBankDialog();
            }
            
        }

        private void LookupBankDialog()
        {
            frmLookupBank ifrmDialog = new frmLookupBank(dtBankLookup,rowID.ToString());
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                this.rowIDBank2 = ifrmDialog.RowIDBank2;
                this.bankID2 = ifrmDialog.BankID2;

                if (this.SelectData2 != null)
                {
                    this.SelectData2(this, new EventArgs());
                }

            }
            else
            {
                this.Close();
            }
        }
        private void getNo()
        {
            
            try
            {
                if (kdTransaksi == "KM1")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBK");
                    nobgch = Numerator.GetNextNumerator("BKM");
                }
                else if (kdTransaksi == "KK1")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBM");
                    nobgch = Numerator.GetNextNumerator("BKK");
                }
                else if (kdTransaksi == "BM1")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBK");
                    nobgch = Numerator.GetNextNumerator("BBM");
                }
                else if (kdTransaksi == "BK2")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBK");
                    nobgch = nobbk;
                }
                else if (kdTransaksi == "BM2")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBM");
                    nobgch = nobbk;
                }
                else if (kdTransaksi == "BBM")
                {
                    nobbk = Numerator.GetNextNumeratorNew("BBM");
                    nobgch = nobbk;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void isiHeader()
        {
            try
            {
                dtBank=new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_getBank"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtBank = db.Commands[0].ExecuteDataTable();
                
                }
                bankID = dtBank.Rows[0]["BankID"].ToString();
                namaBank = dtBank.Rows[0]["NamaBank"].ToString();

                tbAlamat1.Text = dtBank.Rows[0]["Alamat1"].ToString();
                tbAlamat2.Text = dtBank.Rows[0]["Alamat2"].ToString();
                tbCheque.Text = dtBank.Rows[0]["NoCheck"].ToString();
                tbCusService.Text = dtBank.Rows[0]["CService"].ToString();
                tbJenisRek.Text = dtBank.Rows[0]["JRek"].ToString();
                tbKota.Text = dtBank.Rows[0]["Kota"].ToString();
                tbLimitSaldo.Text = dtBank.Rows[0]["Limit"].ToString();
                tbNamaBank.Text = dtBank.Rows[0]["NamaBank"].ToString();
                tbNoAccount.Text = dtBank.Rows[0]["NoAccount"].ToString();
                tbNoPerkiraan.Text = dtBank.Rows[0]["NoPerkiraan"].ToString();
                tbNoTerakhirBG.Text = dtBank.Rows[0]["NoGiro"].ToString();
                tbPerkiraanTP.Text = dtBank.Rows[0]["MainPerkiraan"].ToString();
                tbTelepon.Text = dtBank.Rows[0]["Telp"].ToString();                
                tbSaldo.Text = dtBank.Rows[0]["Saldo"].ToString();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }     
        }

        private void clearHeader()
        {
            tbNamaBank.Clear();
            tbNoAccount.Clear();
            tbNoPerkiraan.Clear();
            tbPerkiraanTP.Clear();
            tbSaldo.Clear();
            tbJenisRek.Clear();
            tbAlamat1.Clear();
            tbAlamat2.Clear();
            tbCheque.Clear();
            tbCusService.Clear();
            tbKota.Clear();
            tbLimitSaldo.Clear();
            tbNoTerakhirBG.Clear();
            tbTelepon.Clear();
            
        }

        private void clearDetail()
        {
            tbTglBank.Clear();
            tbTglRK.Clear();
            tbSaldoAwal.Clear();
            tbSaldoAkhir.Clear();
            tbNomor.Clear();
            tbKredit.Clear();
            tbDebet.Clear();
            tbKeterangan.Clear();
        }

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (updateMode == enumUpdateMode.Header)
            {
                if (tbNamaBank.Text == "")
                {
                    errorProvider1.SetError(tbNamaBank, "Nama Bank Harus Diisi");
                    valid = false;
                }

                if (tbJenisRek.Text == "")
                {
                    errorProvider1.SetError(tbJenisRek, "Jenis Rekening Harus Diisi");
                    valid = false;
                }

                if (tbNoAccount.Text == "")
                {
                    errorProvider1.SetError(tbNoAccount, "Nomor Account Bank Harus Diisi");
                    valid = false;
                }
            }
            else
            {
                if (tbTglRK.Text == "")
                {
                    errorProvider1.SetError(tbTglRK, "Tanggal RK Harus Diisi");
                    valid = false;
                }

                if (tbKeterangan.Text == "")
                {
                    errorProvider1.SetError(tbKeterangan, "Keterangan Harus Diisi");
                    valid = false;
                }

                if (frmMode == enumFrmMode.New)
                {
                    if (tbDebet.Enabled == true && tbDebet.Text == "0")
                    {
                        errorProvider1.SetError(tbDebet, "Debet Harus Diisi");
                        valid = false;
                    }

                    if (tbKredit.Enabled == true && tbKredit.Text == "0")
                    {
                        errorProvider1.SetError(tbKredit, "Kredit Harus Diisi");
                        valid = false;
                    }
                }
                else
                {
                    if (tbDebet.Text == "0" && tbKredit.Text == "0")
                    {
                        errorProvider1.SetError(tbKredit, "Debet / Kredit Harus Diisi");
                        valid = false;
                    }
                }
            }

            return valid;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            if (updateMode == enumUpdateMode.Header)
            {
                if (frmMode == enumFrmMode.New)
                {
                    try
                    {
                        Guid _RowID = Guid.NewGuid();
                        string _BankID=Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        using(Database db=new Database(GlobalVar.DBFinance))
                        {
                            Bank.addBank(db, _RowID,_BankID, tbJenisRek.Text, tbNamaBank.Text, "", tbNoAccount.Text, tbAlamat1.Text, tbAlamat2.Text, tbKota.Text, tbTelepon.Text, tbCusService.Text, tbNoTerakhirBG.Text, tbCheque.Text, "", "IDR", tbSaldo.Text, tbLimitSaldo.Text, (DateTime)SqlDateTime.Null, "", "", "", "", tbNoPerkiraan.Text, tbPerkiraanTP.Text);

                        }
                        frmBukuBankBrowse frm = new frmBukuBankBrowse();
                        frm = (frmBukuBankBrowse)Caller;
                        frm.HeaderRefresh(_RowID);
                        frm.HeaderFindRow("RowIDH", _RowID.ToString());
                        this.Close();
                        
                    }
                    catch(Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    //SAVE UPDATE HEADER
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@JRek", SqlDbType.VarChar, tbJenisRek.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, tbNamaBank.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, tbNoAccount.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat1", SqlDbType.VarChar, tbAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat2", SqlDbType.VarChar, tbAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, tbKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, tbTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@CService", SqlDbType.VarChar, tbCusService.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, tbNoTerakhirBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoCheck", SqlDbType.VarChar, tbCheque.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, tbSaldo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Limit", SqlDbType.Money, tbLimitSaldo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, tbNoPerkiraan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@MainPerkiraan", SqlDbType.VarChar, tbPerkiraanTP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }
                        frmBukuBankBrowse frm = new frmBukuBankBrowse();
                        frm = (frmBukuBankBrowse)Caller;
                        frm.HeaderRefresh(rowID);
                        frm.HeaderFindRow("RowIDH", rowID.ToString());
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                if (frmMode == enumFrmMode.New)
                {
                    //SAVE NEW DETAIL
                    DateTime _Tanggal = (DateTime)tbTglBank.DateValue;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    rowIDDetail =Guid.NewGuid();
                    string recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    try
                    {
                        DateTime tglBank=(DateTime)tbTglBank.DateValue;
                        DateTime tglRK=(DateTime)tbTglRK.DateValue;
                        if (kdTransaksi == "KM1")
                        {
                            nobbk = Numerator.BookNumeratorNew("BBK");
                            nobgch = Numerator.BookNumerator("BKM");
                            string recordIDBKM = recordID.TrimEnd() + "B";
                            string recordIDBKMDetail = recordIDBKM;
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();

                                Bank.AddBankDetail(db, rowIDDetail, Guid.Empty, nobbk, nobgch, rowID, "", tglBank, "BBK", tbKeterangan.Text, "IDR", tbDebet.Text, tbKredit.Text, tglBank, tglRK, "", "", "", "", noPerkiraan,bankID,recordID.TrimEnd()+"T");

                                BKM.AddHeader(db, rowIDDetail, rowIDDetail, recordIDBKM, nobgch, "", "BNK", tglBank, "Mutasi Dari " + namaBank, "", "", SecurityManager.UserName, "");
                                BKM.AddDetail(db, Guid.NewGuid(), rowIDDetail, recordIDBKMDetail, recordIDBKM, "", "", "", "", noPerkiraan, tbKeterangan.Text, tbKredit.Text);
                                db.CommitTransaction();
                            }

                            

                        }
                        else if (kdTransaksi == "KK1")
                        {
                            nobbk = Numerator.BookNumeratorNew("BBM");
                            nobgch = Numerator.BookNumerator("BKK");


                            string recordIDBKK = recordID.TrimEnd() + "B";
                            string recordIDBKKDetail = recordIDBKK;
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();

                                Bank.AddBankDetail(db, rowIDDetail, Guid.Empty, nobbk, nobgch, rowID, "", tglBank, "BBM", tbKeterangan.Text, "IDR", tbDebet.Text, tbKredit.Text, tglBank, tglRK, "", "", "", "", noPerkiraan, bankID, recordID.TrimEnd() + "T");

                                BKK.AddHeader(db, rowIDDetail, rowIDDetail, recordIDBKK, nobgch, "", "BNK", tglBank, "Mutasi Ke " + namaBank, "", "", SecurityManager.UserName, "");
                                BKK.AddDetail(db, Guid.NewGuid(), rowIDDetail, recordIDBKKDetail, recordIDBKK, "", "", "", "", noPerkiraan, tbKeterangan.Text, tbDebet.Text);
                                db.CommitTransaction();
                            }
                        }
                        else if (kdTransaksi == "BM1")
                        {
                            nobbk = Numerator.BookNumeratorNew("BBK");
                            nobgch = Numerator.BookNumerator("BBM");
                            string noBBKBank2, noBGCHBank2;
                            Guid LinkRowID = Guid.NewGuid() ;
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();

                                Bank.AddBankDetail(db, rowIDDetail, LinkRowID, nobbk, nobgch, rowID, "", tglBank, "BBK", tbKeterangan.Text, "IDR", tbDebet.Text, tbKredit.Text, tglBank, tglRK, "", "", "", "", noPerkiraan, bankID, recordID.TrimEnd() + "T");

                                noBBKBank2 = nobgch;
                                noBGCHBank2 = nobbk;
                                Bank.AddBankDetail(db, LinkRowID, rowIDDetail, noBBKBank2, noBGCHBank2, rowIDBank2, "", tglBank, "BBM", "Mutasi Bank, No : " + noBGCHBank2, "IDR", tbKredit.Text, tbDebet.Text, tglBank, tglRK, "", "", "", "", noPerkiraan, bankID2, recordID.TrimEnd() + "M");
                                db.CommitTransaction();
                            }
                        }
                        else if (kdTransaksi == "BK2")
                        {
                            nobbk = Numerator.BookNumeratorNew("BBK");
                            nobgch = nobbk;

                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();

                                Bank.AddBankDetail(db, rowIDDetail, Guid.Empty, nobbk, nobgch, rowID, "", tglBank, "BBK", tbKeterangan.Text, "IDR", tbDebet.Text, tbKredit.Text, tglBank, tglRK, "", "", "", "", noPerkiraan, bankID, recordID.TrimEnd() + "T");
                                
                                db.CommitTransaction();
                            }
                        }
                        else if (kdTransaksi == "BM2" || kdTransaksi == "BBM")
                        {
                            nobbk = Numerator.BookNumeratorNew("BBM");
                            nobgch = nobbk;

                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();

                                Bank.AddBankDetail(db, rowIDDetail, Guid.Empty, nobbk, nobgch, rowID, "", tglBank, "BBM", tbKeterangan.Text, "IDR", tbDebet.Text, tbKredit.Text, tglBank, tglRK, "", "", "", "", noPerkiraan, bankID, recordID.TrimEnd() + "T");
                                                                
                                db.CommitTransaction();
                            }
                        }

                        

                        frmBukuBankBrowse frm = new frmBukuBankBrowse();
                        frm = (frmBukuBankBrowse)Caller;
                        frm.HeaderRefresh(rowID);
                        frm.HeaderFindRow("RowIDH", rowID.ToString());
                        frm.DetailRefresh(rowIDDetail);
                        frm.DetailFindRow("RowID", rowIDDetail.ToString());
                        this.Close();

                        bool isPrinted = LookupInfoValue.CekPrintBukuBank();
                        if (isPrinted)
                        {
                            frm.cetakLaporan();
                        }

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    //SAVE UPDATE DETAIL
                    try
                    {
                        
                        tglRK = (DateTime)tbTglBank.DateValue;
                        keterangan = tbKeterangan.Text;
                        debet = tbDebet.Text;
                        kredit = tbKredit.Text;



                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            
                            db.Commands.Add(db.CreateCommand("usp_BankDetail_RELASI_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, nobgch.Substring(0, 3)));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID2", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, rowIDDetail));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBKK2", SqlDbType.VarChar, nobbk));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBGCH2", SqlDbType.VarChar, nobgch));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRK2", SqlDbType.DateTime, tglRK));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan2", SqlDbType.VarChar, keterangan));
                            db.Commands[0].Parameters.Add(new Parameter("@debet2", SqlDbType.Money, debet));
                            db.Commands[0].Parameters.Add(new Parameter("@kredit2", SqlDbType.Money, kredit));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();

                        }

                        frmBukuBankBrowse frm = new frmBukuBankBrowse();
                        frm = (frmBukuBankBrowse)Caller;
                        frm.HeaderRefresh(rowID);
                        frm.HeaderFindRow("RowIDH", rowID.ToString());
                        frm.DetailRefresh(rowIDDetail);
                        frm.DetailFindRow("RowID", rowIDDetail.ToString());
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDebet_TextChanged(object sender, EventArgs e)
        {
            if (tbDebet.Text == "")
            {
                tbDebet.Text = "0";
                tbDebet.SelectAll();
            }
            
            double saldoAwal, debet, kredit;
            kredit = Convert.ToDouble(tbKredit.Text);
            debet = Convert.ToDouble(tbDebet.Text);
            saldoAwal = Convert.ToDouble(tbSaldoAwal.Text);

            if (frmMode == enumFrmMode.New)               
                saldoAwal += debet;
            else
                saldoAwal = saldoAwal - kredit + debet;

            tbSaldoAkhir.Text = saldoAwal.ToString();
            
        }

        private void tbKredit_TextChanged(object sender, EventArgs e)
        {
            if (tbKredit.Text == "")
            {
                tbKredit.Text = "0";
                tbKredit.SelectAll();
            }
            double saldoAwal, kredit, debet;
            debet = Convert.ToDouble(tbDebet.Text);
            kredit = Convert.ToDouble(tbKredit.Text);
            saldoAwal = Convert.ToDouble(tbSaldoAwal.Text);
            
            if (frmMode == enumFrmMode.New)
                saldoAwal -= kredit;
            else
                saldoAwal = saldoAwal - kredit + debet;
                
            tbSaldoAkhir.Text = saldoAwal.ToString();
            
        }

    



    }
}
