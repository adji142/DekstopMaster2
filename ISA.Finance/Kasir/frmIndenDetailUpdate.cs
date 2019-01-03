using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.DAL;
using ISA.Finance.Class;
using ISA.Common;

namespace ISA.Finance.Kasir
{
    public partial class frmIndenDetailUpdate : ISA.Finance.BaseForm
    {
        string cara = "", RpCash = "0", RpTrn = "0", RpGiro = "0", RpCrd = "0", RpDbt = "0", ket = "", bankID = "", namaBanki="", noAcc = "", NamaBank = "", Lokasi = "", noBGC = "", namaCollector, noBukti, collectorID;
        SqlDateTime tglGiro = SqlDateTime.Null, tglRK = SqlDateTime.Null, tglJTempo = SqlDateTime.Null;
        DateTime tglInden;
        Guid RowID, HeaderID, rowIDBankTujuan, RowIDOrderPenjualan,rowIDdetail;
        String RecordID, HRecordID;
        bool _isFromPiutang;
        double _rpsisa = 0;
        Guid _rowidPK;
        String _nip;
        int formWidth = 0;
        int formLeftLocation = 0;
        string mode = "";
        Guid RowIDDO = Guid.Empty;

        private bool _isEnable = false;

        //jika dari piutang gak boleh close dari tombol close pojok kanan, karena harus buka form inden
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams myCp = base.CreateParams;
                if (_isFromPiutang == true)
                {
                    myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                }
                return myCp;

            }

        }

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

        public frmIndenDetailUpdate(Form caller, Guid HeaderID, String HRecordID, string namaCollector, DateTime tglInden, string noBukti, string collectorID, Guid RowIDdetail, Guid RowIDOrderPenjualan)
        {
            InitializeComponent();
            this.Caller = caller;
            this.HeaderID = HeaderID;
            this.HRecordID = HRecordID.TrimEnd();
            this.namaCollector = namaCollector;
            this.tglInden = tglInden;
            this.noBukti = noBukti;
            this.collectorID = collectorID;
            this.rowIDdetail = RowIDdetail;
            mode = "Edit";
            this.RowIDDO = RowIDOrderPenjualan;
        }

        public frmIndenDetailUpdate(Form caller, Guid HeaderID, String HRecordID, string namaCollector, DateTime tglInden, string noBukti, string collectorID, bool isFromPiutang, double RpSisa, Guid RowIDPK, String nip)
        {
            InitializeComponent();
            this.Caller = caller;
            this.HeaderID = HeaderID;
            this.HRecordID = HRecordID.TrimEnd();
            this.namaCollector = namaCollector;
            this.tglInden = tglInden;
            this.noBukti = noBukti;
            this.collectorID = collectorID;
            _isFromPiutang = isFromPiutang;
            _rpsisa = RpSisa;
            _nip = nip;
            _rowidPK = RowIDPK;
        }

        

        private void cbCara_SelectedIndexChanged(object sender, EventArgs e)
        {
            setForm();
        }

        private void setForm()
        {
            clearForm();
            if (mode != "Edit")
            {
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
                    PnlScanGiro.Visible = false;
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
                    PnlScanGiro.Visible = false;
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
                    PnlScanGiro.Visible = true;
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
                    PnlScanGiro.Visible = false;
                }
            }
            else
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
                PnlScanGiro.Visible = false;
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

            if (cbCara.Text == "GIRO")
            {
                if (lookupAccountToko1.Enabled == true && lookupAccountToko1.NoAccount == "")
                {
                    errorProvider1.SetError(lookupAccountToko1, "Account Toko tidak boleh kosong");
                    valid = false;
                }
            }

            if ((tbTglGiro.Enabled == true) && (tbTglJTempo.Enabled == true) && tbTglGiro.Text != "" && tbTglJTempo.Text != "") 
            {
                
                if ((DateTime)tbTglJTempo.DateValue < (DateTime)tbTglGiro.DateValue)
                {
                    errorProvider1.SetError(tbTglJTempo, "Tanggal Jatuh Tempo Tidak Boleh Lebih Kecil Dari Tanggal Giro");
                    valid = false;
                }
            }

            if (cbCara.Text == "TRN" && tbTglRK.Enabled == true && tbTglRK.Text != "") // (v) 13-06-2013
            {
                DateTime _TglRK = (DateTime)tbTglRK.DateValue;
                string kodeGudang = GlobalVar.Gudang; ;
                string periode = _TglRK.ToString("yyyyMM");

                if (Class.PeriodeClosing.IsGLClosed(periode, kodeGudang))  // (v) 04-06-2013
                {
                    errorProvider1.SetError(tbTglRK, "Sudah Closing GL!");
                    valid = false;
                }
                if (_TglRK > GlobalVar.DateOfServer) // (v) 30-05-2013 -- 04-06-2013
                {
                    errorProvider1.SetError(tbTglRK, "Tanggal RK tidak boleh melebihi tanggal " + GlobalVar.DateOfServer.ToString("dd-MMM-yyyy"));
                    valid = false;
                }
            }

            if (tbKet.Text == "")
            {
                errorProvider1.SetError(tbKet, "TextBox keterangan harus diisi dengan informasi nama toko penyetor uang. Silahkan diisi.");
                valid = false;
            }

            return valid;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            
            bool isCashAllowed = LookupInfoValue.CekIndenTunai();

            if (cbSOinden.Checked == true)
            {
                if (RowIDOrderPenjualan == Guid.Empty)
                {
                    MessageBox.Show("SO/DO belum dipilih");
                    lookupSO1.Focus();
                    return;
                }
            }
            else
            {
                RowIDOrderPenjualan = Guid.Empty;
            }

            if (!isCashAllowed)
            {
                if (!_isFromPiutang)
                {
                    if (cbCara.Text == "CASH")
                    {
                        MessageBox.Show("Input Cash dari Menu Penerimaan Tunai", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (mode != "Edit")
            {
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
                    /*cegatan Transfer hanya untuk biaya operasional*/
                    if (GlobalVar.Gudang != "2803")
                    {
                        string cBankTujuan = lookupBankTujuan.BankID;
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataTable dtb = new DataTable(GlobalVar.DBName);
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_BankTujuan_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, cBankTujuan));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaAccount", SqlDbType.VarChar, "BANK OPERASIONAL"));
                                dtb = db.Commands[0].ExecuteDataTable();
                            }
                            if (dtb.Rows.Count == 0)
                            {
                                MessageBox.Show("Transfer Bank hanya digunakan untuk biaya Operasional");
                                return;
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
                    /*end cegatan-----------------------------------------*/

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

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.BeginTransaction();
                        addIndenDetail(db);
                        db.CommitTransaction();
                    }

                    if (_isFromPiutang == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                        frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                        frm.IndenRowRefresh(HeaderID);
                        frm.IndenDetailRowRefresh(RowID);
                        frm.IndenDetailFindRow("RowIDID", RowID.ToString());
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_IndenDetail_SOInden_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowIDdetail));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDOrderPenjualan", SqlDbType.UniqueIdentifier, RowIDOrderPenjualan));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                    frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                    frm.IndenRowRefresh(HeaderID);
                    frm.IndenDetailRowRefresh(rowIDdetail);
                    frm.IndenDetailFindRow("RowIDID", rowIDdetail.ToString());
                    this.Close();

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
                if (RowIDOrderPenjualan != Guid.Empty)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDOrderPenjualan", SqlDbType.UniqueIdentifier, RowIDOrderPenjualan));
                }

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
                        string noBKM = Numerator.BookNumerator("BKM");
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
                        noBBK = Numerator.BookNumerator("BBM");
                        TransferBank.addHeader(db, _RowID, HeaderID, recordIDTB, tglInden, noBBK, "M", "", "IND. No " + noBukti, "", "",SecurityManager.UserName, "");
                    }
                    else
                    {
                        _RowID = (Guid)dtCekRelasi.Rows[0][0];
                        noBBK = dtCekRelasi.Rows[0][1].ToString();
                    }
                    TransferBank.addDetail(db, RowID, _RowID, RecordID, recordIDTB, collectorID, namaCollector, NamaBank, Lokasi, noAcc, (DateTime)tglRK, RpTrn, "", "", "", "", bankID, _noPerk, "");
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
            //jika dari TSL Piutang Karyawan, buka form IndenDetail
            if (_isFromPiutang == true)
            {
                if (MessageBox.Show("Batalkan Inputan Piutang Karyawan ?", "Informasi", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PinjamanPegawaiBukti_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowidPK));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Inden_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                    // frmUtang = (frmPiutangKaryawan)this.Caller;

                    frmUtang.RefreshPegawai(_nip);
                    frmUtang.FindRowPegawsai("NIP", _nip);
                    frmUtang.RefreshPiutang();
                    //frmUtang.FindRowPiutang("RowID", _rowIDPK.ToString());

                }
                else
                {
                    return;
                }
            }
            this.Close();
        }

        private void frmIndenDetailUpdate_Load(object sender, EventArgs e)
        {
            //string appSetVal = Class.AppSetting.GetValue("PENERIMAAN_TUNAI");
            //if (appSetVal != string.Empty || appSetVal != "false")
            //{
            //    try
            //    {
            //        if (Convert.ToInt32(appSetVal) == 1)
            //            cbCara.Items.Remove("CASH");
            //    }
            //    catch { };
            //}

            cbCara.Text = cbCara.Items[0].ToString();
            lblGiroPT.Text = string.Empty;

            if (_isFromPiutang == true)
            {
                cbCara.Items.Add("CASH");
                cbCara.Text = "CASH";
                cbCara.Enabled = false;
                tbNominal.Text = _rpsisa.ToString();
                tbNominal.Enabled = false;
            }
            formWidth = this.Width;
            formLeftLocation = this.Left;

            if (mode == "Edit" && _isFromPiutang == false)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtIndDetail = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_IndenDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowIDdetail));
                        dtIndDetail = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtIndDetail.Rows.Count > 0)
                    {
                        string _chbg = Tools.isNull(dtIndDetail.Rows[0]["CHBG"], "").ToString();
                        if (_chbg == "T") {cbCara.Text = "TRN";}
                        tbNominal.Text = Tools.isNull(dtIndDetail.Rows[0]["RpTrf"], "0").ToString();
                        lookupBankTujuan.NamaBank = Tools.isNull(dtIndDetail.Rows[0]["NamaBankTujuan"], "").ToString();
                        lookupBankTujuan.BankID = Tools.isNull(dtIndDetail.Rows[0]["BankID"], "").ToString();
                        tbTglRK.Text = string.Format("{0:dd/MM/yyyy}", Tools.isNull(dtIndDetail.Rows[0]["TglTrf"], null));
                        lookupBankAsal1.NamaBank = Tools.isNull(dtIndDetail.Rows[0]["NamaBank"], "").ToString();
                        lookupBankAsal1.Lokasi = Tools.isNull(dtIndDetail.Rows[0]["Lokasi"], "").ToString();
                        tbKet.Text = Tools.isNull(dtIndDetail.Rows[0]["Ket"], "").ToString();
                        RowIDOrderPenjualan = new Guid(Tools.isNull(dtIndDetail.Rows[0]["RowIDOrderPenjualan"], "").ToString());
                        if (RowIDOrderPenjualan != Guid.Empty) 
                        { 
                            cbSOinden.Checked = true;
                            lookupSO1.NoDO = Tools.isNull(dtIndDetail.Rows[0]["NoDO"], "").ToString();
                            tbToko.Text = Tools.isNull(dtIndDetail.Rows[0]["NamaToko"], "").ToString();
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
            //int i = 0;
            //using (Database db = new Database(GlobalVar.DBName))
            //{
            //    db.Commands.Add(db.CreateCommand("[fsp_GiroPT]"));
            //    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupAccountToko1.KodeToko));
            //    i = Convert.ToInt32(db.Commands[0].ExecuteScalar());
            //}
            //if (i>0)
            //{
            //    PT = true;
            //}
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

        private void cbCara_Leave(object sender, EventArgs e)
        {
            if (cbCara.Text.Trim() == "CASH")
            {
                MessageBox.Show("Identifikasi pembayaran tunai memalui menu PENERIMAAN TUNAI");
                cbCara.Focus();
                return;
            }
        }

        private void lookupSO1_SelectData(object sender, EventArgs e)
        {
            tbToko.Text = lookupSO1.NamaToko;
            tbNominal.Text = lookupSO1.RpNet;
            RowIDOrderPenjualan = lookupSO1.RowID;
        }

        private void cbSOinden_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSOinden.Checked == true)
            {
                lookupSO1.Enabled = true;
            }
            else
            {
                lookupSO1.NoDO = "";
                tbToko.Text = "";
                RowIDOrderPenjualan = Guid.Empty;
                lookupSO1.Enabled = false;
            }
        }  

        

    }
}
