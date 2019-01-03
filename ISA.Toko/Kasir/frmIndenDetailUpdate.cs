using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.DAL;
using ISA.Toko.Class;
using ISA.Common;

namespace ISA.Toko.Kasir
{
    public partial class frmIndenDetailUpdate : ISA.Toko.BaseForm
    {
        string cara = "", RpCash = "0", RpTrn = "0", RpGiro = "0", RpCrd = "0", RpDbt = "0", ket = "", bankID = "", namaBanki="", noAcc = "", NamaBank = "", Lokasi = "", noBGC = "", namaCollector, noBukti, collectorID;
        SqlDateTime tglGiro = SqlDateTime.Null, tglRK = SqlDateTime.Null, tglJTempo = SqlDateTime.Null;
        DateTime tglInden;
        Guid RowID, HeaderID, rowIDBankTujuan;
        String RecordID, HRecordID;

        public frmIndenDetailUpdate(Form caller, Guid HeaderID, String HRecordID, string namaCollector, DateTime tglInden, string noBukti, string collectorID)
        {
            InitializeComponent();
            this.Caller = caller;
            this.HeaderID = HeaderID;
            this.HRecordID = HRecordID.TrimEnd();
            this.namaCollector = namaCollector;
            this.tglInden = tglInden;
            this.noBukti = noBukti;
            this.collectorID = collectorID;
        }

        

        private void cbCara_SelectedIndexChanged(object sender, EventArgs e)
        {
            setForm();
        }

        private void setForm()
        {
            clearForm();
            if (cbCara.Text == "CASH")
            {
                tbNominal.Enabled = true;
                tbKet.Enabled = true;

                tbJenisGiro.Enabled = false;
                lookupBankAsal1.Enabled = false;
                lookupAccountToko1.Enabled = false;
                lookupBankTujuan.Enabled = false;
                tbTglGiro.Enabled = false;
                tbNoBGC.Enabled = false;
                tbTglJTempo.Enabled = false;
                tbTglRK.Enabled = false;
            }
            else if (cbCara.Text == "TRN")
            {
                tbNominal.Enabled = true;
                tbKet.Enabled = true;
                lookupBankTujuan.Enabled = true;
                lookupBankAsal1.Enabled = true;
                lookupAccountToko1.Enabled = true;
                tbTglRK.Enabled = true;

                tbTglGiro.Enabled = false;
                tbNoBGC.Enabled = false;
                tbTglJTempo.Enabled = false;
                tbJenisGiro.Enabled = false;
            }
            else if (cbCara.Text == "GIRO")
            {
                tbJenisGiro.Enabled = true;
                tbNominal.Enabled = true;
                tbKet.Enabled = true;
                lookupBankAsal1.Enabled = true;
                lookupAccountToko1.Enabled = true;
                tbTglGiro.Enabled = true;
                tbTglGiro.DateValue = DateTime.Today;
                tbNoBGC.Enabled = true;
                tbTglJTempo.Clear();
                tbTglJTempo.Enabled = true;

                lookupBankTujuan.Enabled = false;
                tbTglRK.Enabled = false;
                tbJenisGiro.Focus();
            }
            else if (cbCara.Text == "CRD" || cbCara.Text == "DBT")
            {
                tbTglGiro.DateValue = DateTime.Today;
                if (cbCara.Text == "CRD")
                {
                    
                    tbTglJTempo.DateValue = DateTime.Today.AddDays(3);
                }
                else
                {
                    tbTglJTempo.DateValue = DateTime.Today.AddDays(1);
                }

                tbNominal.Enabled = true;
                tbKet.Enabled = true;
                lookupBankAsal1.Enabled = true;
                tbNoBGC.Enabled = true;
                lookupBankTujuan.Enabled = true;

                tbTglJTempo.Enabled = false;
                tbTglRK.Enabled = false;
                tbTglGiro.Enabled = false;
                lookupAccountToko1.Enabled = false;
                tbJenisGiro.Enabled = false;
            }
        }

        private void clearForm()
        {
            tbNominal.Clear();
            tbKet.Clear();
            lookupBankAsal1.Clear();
            tbNoBGC.Clear();
            lookupBankTujuan.Clear();

            tbTglJTempo.Clear();
            tbTglRK.Clear();
            tbTglGiro.Clear();
            lookupAccountToko1.Clear();
            tbJenisGiro.Clear();
            lblGiroPT.Text = string.Empty;
            //cbCara.SelectedIndex = 0;
        }

        private void tbJenisGiro_TextChanged(object sender, EventArgs e)
        {
            
            if (tbJenisGiro.Text!="" && tbJenisGiro.Text != "C" && tbJenisGiro.Text != "G" && tbJenisGiro.Text != "S")
            {
                MessageBox.Show("Isian Salah!");
                tbJenisGiro.Focus();
                tbJenisGiro.SelectAll();
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (cbCara.Text != cbCara.Items[0].ToString() && cbCara.Text != cbCara.Items[1].ToString() && cbCara.Text != cbCara.Items[2].ToString() && cbCara.Text != cbCara.Items[3].ToString() && cbCara.Text != cbCara.Items[4].ToString())
            {
                errorProvider1.SetError(cbCara, "Cara harus sesuai dengan pilihan yang tersedia");
                valid = false;
            }
            if (tbJenisGiro.Enabled == true && (tbJenisGiro.Text != "C" && tbJenisGiro.Text != "G" && tbJenisGiro.Text != "S"))
            {
                errorProvider1.SetError(tbJenisGiro, "Jenis Giro Harus C / G / S");
                valid = false;
            }
            if (tbNominal.Text == "" || tbNominal.Text == "0")
            {
                errorProvider1.SetError(tbNominal, "Nominal tidak boleh kosong");
                valid = false;
            }
            if (lookupBankTujuan.Enabled == true && (lookupBankTujuan.BankID == "[CODE]" || lookupBankTujuan.BankID == ""))
            {
                errorProvider1.SetError(lookupBankTujuan, "Bank Tujuan tidak boleh kosong");
                valid = false;
            }

            if (lookupBankAsal1.Enabled == true && cbCara.Text!="TRN" && (lookupBankAsal1.Lokasi == "[LOKASI]" || lookupBankAsal1.Lokasi == ""))
            {
                errorProvider1.SetError(lookupBankAsal1, "Bank Asal tidak boleh kosong");
                valid = false;
            }

            if (lookupBankAsal1.Enabled == true && cbCara.Text == "TRN" && lookupBankAsal1.Lokasi == "[LOKASI]")
            {
                lookupBankAsal1.Lokasi = "";
                lookupBankAsal1.NamaBank = "-";
            }

            if (tbNoBGC.Enabled == true && tbNoBGC.Text == "")
            {
                errorProvider1.SetError(tbNoBGC, "No BGC tidak boleh kosong");
                valid = false;
            }

            if (tbTglJTempo.Enabled == true && tbTglJTempo.Text == "")
            {
                errorProvider1.SetError(tbTglJTempo, "Tanggal Jatuh Tempo tidak boleh kosong");
                valid = false;
            }
            if (tbTglRK.Enabled == true && tbTglRK.Text == "")
            {
                errorProvider1.SetError(tbTglRK, "Tanggal Transfer tidak boleh kosong");
                valid = false;
            }
            if (tbTglGiro.Enabled == true && tbTglGiro.Text == "")
            {
                errorProvider1.SetError(tbTglGiro, "Tanggal Giro tidak boleh kosong");
                valid = false;
            }

            if (lookupAccountToko1.Enabled == true && lookupAccountToko1.NoAccount == "" )
            {
                errorProvider1.SetError(lookupAccountToko1, "Account Toko tidak boleh kosong");
                valid = false;
            }

            if ((tbTglGiro.Enabled == true) && (tbTglJTempo.Enabled == true) && tbTglGiro.Text != "" && tbTglJTempo.Text != "") 
            {
                
                if ((DateTime)tbTglJTempo.DateValue < (DateTime)tbTglGiro.DateValue)
                {
                    errorProvider1.SetError(tbTglJTempo, "Tanggal Jatuh Tempo Tidak Boleh Lebih Kecil Dari Tanggal Giro");
                    valid = false;
                }
            }
                
            return valid;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            //if (GlobalVar.Gudang != "2803")
            //{
                bool isCashAllowed = LookupInfoValue.CekIndenTunai();
                //if (!isCashAllowed)
                //{
                //    if (cbCara.Text == "CASH")
                //    {
                //        MessageBox.Show("Input Cash dari Menu Penerimaan Tunai", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
            //}

            if (!ValidateInput())
                return;

                cara = cbCara.Text;
                if (cara == "CASH")
                {
                    cara = "";
                    RpCash = tbNominal.Text;
                    ket = tbKet.Text;
                }
                else if (cara == "TRN")
                {
                    cara = "T";
                    RpTrn = tbNominal.Text;
                    ket = tbKet.Text;
                    bankID = lookupBankTujuan.BankID;
                    NamaBank = lookupBankAsal1.NamaBank;
                    Lokasi = lookupBankAsal1.Lokasi;
                    noAcc = lookupAccountToko1.NoAccount;
                    tglRK = (DateTime)tbTglRK.DateValue;
                    rowIDBankTujuan = lookupBankTujuan.RowID;
                }
                else if (cara == "GIRO")
                {
                    RpGiro = tbNominal.Text;
                    ket = tbKet.Text;
                    NamaBank = lookupBankAsal1.NamaBank;
                    Lokasi = lookupBankAsal1.Lokasi;
                    noAcc = lookupAccountToko1.NoAccount;
                    tglGiro = (DateTime)tbTglGiro.DateValue;
                    tglJTempo = (DateTime)tbTglJTempo.DateValue;
                    noBGC = tbNoBGC.Text;
                    cara = tbJenisGiro.Text;
                }
                else if (cara == "CRD")
                {
                    RpCrd = tbNominal.Text;
                    ket = tbKet.Text;
                    cara = "R";
                    NamaBank = lookupBankAsal1.NamaBank;
                    Lokasi = lookupBankAsal1.Lokasi;
                    tglGiro = (DateTime)tbTglGiro.DateValue;
                    tglJTempo = (DateTime)tbTglJTempo.DateValue;
                    noBGC = tbNoBGC.Text;
                    bankID = lookupBankTujuan.BankID;
                    namaBanki = lookupBankTujuan.NamaBank;
                }

                else if (cara == "DBT")
                {
                    RpDbt = tbNominal.Text;
                    ket = tbKet.Text;
                    cara = "D";
                    NamaBank = lookupBankAsal1.NamaBank;
                    Lokasi = lookupBankAsal1.Lokasi;
                    tglGiro = (DateTime)tbTglGiro.DateValue;
                    tglJTempo = (DateTime)tbTglJTempo.DateValue;
                    noBGC = tbNoBGC.Text;
                    bankID = lookupBankTujuan.BankID;
                    namaBanki = lookupBankTujuan.NamaBank;
                }


                    RowID = Guid.NewGuid();
                    RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                
                    try
                    {
                        
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.BeginTransaction();
                            addIndenDetail(db);
                            db.CommitTransaction();
                        }

                        frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                        frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                        frm.IndenRowRefresh(HeaderID);
                        frm.IndenDetailRowRefresh(RowID);
                        frm.IndenDetailFindRow("RowIDID", RowID.ToString());
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                
        }

        private void addIndenDetail(
            Database db
            )
        {
            DataTable dtCekRelasi = new DataTable();
            db.Commands.Clear();

            
                db.Commands.Add(db.CreateCommand("usp_IndenDetail_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
                db.Commands[0].Parameters.Add(new Parameter("@TglTrf", SqlDbType.DateTime, tglRK));
                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, bankID));
                db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, NamaBank));
                db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Lokasi));
                db.Commands[0].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, cara));
                db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, noBGC));
                db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, tglGiro));
                db.Commands[0].Parameters.Add(new Parameter("@TglJt", SqlDbType.DateTime, tglJTempo));
                db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, ket));
                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc));
                db.Commands[0].Parameters.Add(new Parameter("@RpCash", SqlDbType.Money, RpCash));
                db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, RpGiro));
                db.Commands[0].Parameters.Add(new Parameter("@RpTrf", SqlDbType.Money, RpTrn));
                db.Commands[0].Parameters.Add(new Parameter("@RpCrd", SqlDbType.Money, RpCrd));
                db.Commands[0].Parameters.Add(new Parameter("@RpDbt", SqlDbType.Money, RpDbt));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                if (cara == "")
                {
                    string _noPerk;
                    _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();
                    dtCekRelasi = Inden.CekRelasiInden("Bukti", "SrcID", HeaderID.ToString(), "", "").Copy();
                    Guid _RowID= new Guid();
                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        _RowID = HeaderID;
                        //string noBKM = Tools.AutoNumbering("NoBukti", "ISADbDepoFinance.Dbo.Bukti");
                        string noBKM =Numerator.BookNumerator("BKM");
                        BKM.AddHeader(db, _RowID, HeaderID, BKM.GetRecordIDBukti(HRecordID, "IND"), noBKM, "K", "IND", tglInden, namaCollector, "", noAcc, SecurityManager.UserName, "");
                    }
                    else
                    {
                        _RowID = (Guid)dtCekRelasi.Rows[0][0];
                    }
                    BKM.AddDetail(db, RowID, _RowID, RecordID, BKM.GetRecordIDBukti(HRecordID, "IND"), "", "", "", noAcc, _noPerk, "PENERIMAAN BELUM IDENTIFIKASI (" + noBukti + ")", RpCash);
                }
                else if (cara == "T")
                {
                    string recordIDTB = HRecordID + "I";
                    string noBBK = "";
                    string _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();
                    Guid _RowID = new Guid();

                    

                    dtCekRelasi = Inden.CekRelasiInden("TransferBank", "SrcID", HeaderID.ToString(), "", "").Copy();

                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        _RowID = HeaderID;
                        noBBK = Tools.AutoNumbering("NoBBM", "ISADbDepoFinance.dbo.TransferBank");
                           // Numerator.BookNumerator("BBM");
                        TransferBank.addHeader(db, _RowID, HeaderID, recordIDTB, tglInden, noBBK, "M", "", "IND. No " + noBukti, "", "",SecurityManager.UserName, "");
                    }
                    else
                    {
                        _RowID = (Guid)dtCekRelasi.Rows[0][0];
                        noBBK = dtCekRelasi.Rows[0][1].ToString();
                    }
                    TransferBank.addDetail(db, RowID, _RowID, RecordID, recordIDTB, collectorID, namaCollector, NamaBank, Lokasi, noAcc, (DateTime)tglRK, RpTrn, "", "", "", "", bankID, _noPerk, "", lookupBankTujuan.BankID);
                    Bank.AddBankDetail(db, RowID, Guid.Empty, noBBK, noAcc, rowIDBankTujuan, "", tglInden, "BBM", "TRANSFER DARI : " + namaCollector + " (BANK TRANSFER)", "IDR", RpTrn, "0", DateTime.Today, (DateTime)tglRK, "", "", "", "", _noPerk, bankID, RecordID);
    
                }
                else if (cara == "G" || cara == "C" || cara == "S")
                {
                    string recordIDVJ ="";
                    Guid _VJRowID=new Guid() ;


                    string noVoucher = Numerator.BookNumerator("VPG");
                    string _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();
                    dtCekRelasi = new DataTable();
                    dtCekRelasi = Inden.CekRelasiInden("VoucherJournal", "RefRowID", HeaderID.ToString(), "PG", "").Copy();


                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        recordIDVJ = HRecordID + "I";
                        _VJRowID = Guid.NewGuid();

                        VoucherJournal.AddHeader(db, _VJRowID, HeaderID, recordIDVJ, "PG", tglInden, noVoucher,
                            "PENERIMAAN GIRO IND. NO " + noBukti, "", "", "", "", "", "", "", 0, true);
                    }
                    else
                    {
                        recordIDVJ = dtCekRelasi.Rows[0][1].ToString();
                        _VJRowID = (Guid)dtCekRelasi.Rows[0][0];
                    }
                    //VoucherJournal.AddDetail(db, RowID, _VJRowID, RecordID, recordIDVJ, "", "", "", noBGC, _noPerk, namaCollector, 
                    //    Convert.ToDouble(RpGiro), 0, true);

                    Giro.Add(db, RowID, _VJRowID, Guid.Empty, Guid.Empty, recordIDVJ, "", "", RecordID, "", NamaBank, Lokasi, 
                        cara, noBGC, (DateTime)tglGiro, (DateTime)tglJTempo, Convert.ToDouble(RpGiro), "", SqlDateTime.Null, 
                        "", "", "", "", "", "", _noPerk, SqlDateTime.Null, true, noAcc, "");

                }
                else if (cara == "R")
                {
                    string recordIDVPG = "", noVoucherPG = "", noVoucherTT = "";
                    string recordIDVTT = "";

                    Guid _VJRowIDPG = new Guid();
                    Guid _VJRowIDTT = new Guid();


                    
                    string _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();

                    //VOUCHER PENERIMAAN CRD
                    dtCekRelasi = Inden.CekRelasiInden("VoucherJournal", "RefRowID", HeaderID.ToString(), "CRD", "").Copy();


                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        recordIDVPG = HRecordID + "R";
                        _VJRowIDPG = Guid.NewGuid();
                        noVoucherPG = Numerator.BookNumerator("VPG");
                        VoucherJournal.AddHeader(db, _VJRowIDPG, HeaderID, recordIDVPG, "CC", tglInden, noVoucherPG,
                            "PENERIMAAN CREDIT CARD IND. NO " + noBukti, "", "", "", "", "", "", "", 0, true);
                    }
                    else
                    {
                        recordIDVPG = dtCekRelasi.Rows[0][1].ToString();
                        _VJRowIDPG = (Guid)dtCekRelasi.Rows[0][0];
                    }
                    //VoucherJournal.AddDetail(db, RowID, _VJRowID, RecordID, recordIDVJ, "", "", "", noBGC, _noPerk, namaCollector, 
                    //    Convert.ToDouble(RpGiro), 0, true);



                    //VOUCHER TITIP CRD
                    dtCekRelasi=new DataTable();

                    dtCekRelasi = Inden.CekRelasiInden("VoucherJournal", "RefRowID", HeaderID.ToString(), "TT", bankID).Copy();


                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        recordIDVTT = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial).TrimEnd() + "R";
                        _VJRowIDTT = Guid.NewGuid();
                        noVoucherTT = Numerator.BookNumerator("VTG");

                        VoucherJournal.AddHeader(db, _VJRowIDTT, HeaderID, recordIDVTT, "TT", tglInden, noVoucherTT,
                                "OTOMATIS TITIP DR CRD", "", "", "", "", "", bankID, namaBanki, 0, true);
                    }
                    else
                    {
                        recordIDVTT = dtCekRelasi.Rows[0][1].ToString();
                        _VJRowIDTT = (Guid)dtCekRelasi.Rows[0][0];
                    }
                    
                    //INSERT TABLE GIRO
                    Giro.Add(db, RowID, _VJRowIDPG, Guid.Empty, _VJRowIDTT, recordIDVPG, "", recordIDVTT, RecordID, "", NamaBank, Lokasi,
                        cara, noBGC, (DateTime)tglGiro, (DateTime)tglJTempo, Convert.ToDouble(RpCrd), "", (DateTime)SqlDateTime.Null,
                        "", "", "", "", bankID, namaBanki, _noPerk, tglInden, true, noAcc, "");
                }
                else if (cara == "D")
                {
                    string recordIDVPG = "", noVoucherPG = "", noVoucherTT = "";
                    string recordIDVTT = "";

                    Guid _VJRowIDPG = new Guid();
                    Guid _VJRowIDTT = new Guid();



                    string _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();

                    //VOUCHER PENERIMAAN CRD
                    dtCekRelasi = Inden.CekRelasiInden("VoucherJournal", "RefRowID", HeaderID.ToString(), "DBT", "").Copy();


                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        recordIDVPG = HRecordID + "D";
                        _VJRowIDPG = Guid.NewGuid();
                        noVoucherPG = Numerator.BookNumerator("VPG");
                        VoucherJournal.AddHeader(db, _VJRowIDPG, HeaderID, recordIDVPG, "DB", tglInden, noVoucherPG,
                            "PENERIMAAN DEBIT CARD IND. NO " + noBukti, "", "", "", "", "", "", "", 0, true);
                    }
                    else
                    {
                        recordIDVPG = dtCekRelasi.Rows[0][1].ToString();
                        _VJRowIDPG = (Guid)dtCekRelasi.Rows[0][0];
                    }
                    //VoucherJournal.AddDetail(db, RowID, _VJRowID, RecordID, recordIDVJ, "", "", "", noBGC, _noPerk, namaCollector, 
                    //    Convert.ToDouble(RpGiro), 0, true);



                    //VOUCHER TITIP CRD
                    dtCekRelasi = new DataTable();

                    dtCekRelasi = Inden.CekRelasiInden("VoucherJournal", "RefRowID", HeaderID.ToString(), "TT", bankID).Copy();


                    if (dtCekRelasi.Rows.Count == 0)
                    {
                        recordIDVTT = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial).TrimEnd() + "D";
                        _VJRowIDTT = Guid.NewGuid();
                        noVoucherTT = Numerator.BookNumerator("VTG");

                        VoucherJournal.AddHeader(db, _VJRowIDTT, HeaderID, recordIDVTT, "TT", tglInden, noVoucherTT,
                                "OTOMATIS TITIP DR DBT", "", "", "", "", "", bankID, namaBanki, 0, true);
                    }
                    else
                    {
                        recordIDVTT = dtCekRelasi.Rows[0][1].ToString();
                        _VJRowIDTT = (Guid)dtCekRelasi.Rows[0][0];
                    }

                    //INSERT TABLE GIRO
                    Giro.Add(db, RowID, _VJRowIDPG, Guid.Empty, _VJRowIDTT, recordIDVPG, "", recordIDVTT, RecordID, "", NamaBank, Lokasi,
                        cara, noBGC, (DateTime)tglGiro, (DateTime)tglJTempo, Convert.ToDouble(RpDbt), "", (DateTime)SqlDateTime.Null,
                        "", "", "", "", bankID, namaBanki, _noPerk, tglInden, true, noAcc, "");
                }
            
        }

        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIndenDetailUpdate_Load(object sender, EventArgs e)
        {
            cbCara.Text = cbCara.Items[0].ToString();
            lblGiroPT.Text = string.Empty;
        }

        private void lookupAccountToko1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupAccountToko1.KodeToko != "" && lookupAccountToko1.KodeToko != "[CODE]" && lookupAccountToko1.KodeToko!=null)
            {
                if (cbCara.Text.ToUpper().Equals("GIRO") && tbJenisGiro.Text.ToUpper().Equals("G"))
                {
                   if (ISGiroPT())
                   {
                       lblGiroPT.Text = "GIRO PT";
                   }else
                   {
                       lblGiroPT.Text = "";
                   }
                }
                else
                {
                    lblGiroPT.Text = "";
                }

            }else
            {
                lblGiroPT.Text = "";
            }
        }

        private bool  ISGiroPT()
        {
            bool PT = false;
            int i = 0;
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("[fsp_GiroPT]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupAccountToko1.KodeToko));
                i = Convert.ToInt32(db.Commands[0].ExecuteScalar());
            }
            if (i>0)
            {
                PT = true;
            }
            return PT;
        }

        private void lookupAccountToko1_SelectData(object sender, EventArgs e)
        {
            if (lookupAccountToko1.KodeToko != "" && lookupAccountToko1.KodeToko != "[CODE]" && lookupAccountToko1.KodeToko!=null)
            {
                if (cbCara.Text.ToUpper().Equals("GIRO") && tbJenisGiro.Text.ToUpper().Equals("G"))
                {
                    if (ISGiroPT())
                    {
                        lblGiroPT.Text = "GIRO PT";
                    }
                    else
                    {
                        lblGiroPT.Text = "";
                    }
                }
                else
                {
                    lblGiroPT.Text = "";
                }
            }
            else
            {
                lblGiroPT.Text = "";
            }
           
        }

        private void cbCara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool ketemu = false;
                int i = 0;
                while (ketemu != true && i<=4)
                {
                    string cara=cbCara.Items[i].ToString();
                    if (cara.Contains(cbCara.Text.Trim().ToUpper()))
                    {
                        cbCara.SelectedIndex = i;
                        ketemu = true;
                    }
                    else
                        i++;
                }
            }
        }









        

        

    }
}
