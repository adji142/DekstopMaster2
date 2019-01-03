using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;


namespace ISA.Finance.DKNForm
{
    public partial class frmDKNupdate : ISA.Controls.BaseForm
    {
        enum enumModus { New, Update };
        enum enumBrow { Header, Detail };
        enumModus Modus;
        enumBrow Brow;
        
        Guid _HeaderID, _DetailID;
        Guid _BankKotaRowID, _BankTujuanRowID;

        string _BankIDasal, _BankIDtujuan;
        string noBukti, CollectorID = "", NamaCollector = "", _IsiPin = "";
        string _KodeToko = "",_Lokasi = "";
        string _pinKey = "";
        string _RecID = "";
        string _RecIDDetail = "";
        string _refRecordID = "";
        
        DataTable dtPerkiraan;
        DataTable dtBankKota;

        public event EventHandler SelectData;

        public frmDKNupdate()
        {
            InitializeComponent();
        }

        public frmDKNupdate(Form Caller)
        {
            InitializeComponent();
            Modus = enumModus.New;
            Brow = enumBrow.Header;
            this.Caller = Caller;
        }

        public frmDKNupdate(Form Caller, Guid HeaderID)
        {
            InitializeComponent();
            Modus = enumModus.Update;
            Brow = enumBrow.Header;
            _HeaderID = HeaderID;
            this.Caller = Caller;
        }
        public frmDKNupdate(Form Caller, Guid HeaderID, Guid DetailID, string RecID, string RecIDDetail)
        {
            InitializeComponent();
            Brow = enumBrow.Detail;
            if (DetailID == Guid.Empty) Modus = enumModus.New;
            else Modus = enumModus.Update;
            _HeaderID = HeaderID;
            _DetailID = DetailID;
            _RecID = RecID;
            _RecIDDetail = RecIDDetail;
            this.Caller = Caller;
        }
        public frmDKNupdate(Form Caller, Guid HeaderID, Guid DetailID, string RecID, string RecIDDetail, string IsiPin, string pinKey)
        {
            InitializeComponent();
            Brow = enumBrow.Detail;
            if (DetailID == Guid.Empty) Modus = enumModus.New;
            else Modus = enumModus.Update;
            _HeaderID = HeaderID;
            _DetailID = DetailID;
            _IsiPin = IsiPin;
            _pinKey = pinKey;
            _RecID = RecID;
            _RecIDDetail = RecIDDetail;
            this.Caller = Caller;
        }


        private void frmDKNupdate_Load(object sender, EventArgs e)
        {
            if (Modus == enumModus.New)
            {
                txtNoDKN.Enabled = false;
                txtNoDKN.ReadOnly = true;
            }
            else
            {
                RefreshHeader();
                RefreshDetail();
                if (_IsiPin == "1")
                {
                    txtNoDKN.Enabled = true;
                    txtNoDKN.ReadOnly = false;
                }
            }
        }

        private void RefreshHeader()
        {
            if (Modus == enumModus.New)
            {
                dateDKN.DateValue = DateTime.Today;
                txtGudang.Text = GlobalVar.Gudang;
            }
            else
            {
                frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
                dateDKN.DateValue = Convert.ToDateTime(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                txtNoDKN.Text = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value.ToString();
                txtGudang.Text = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString();
                optDebet.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "D";
                optKredit.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "K";
                _RecID = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                if (Tools.isNull(_pinKey, "").ToString() != "")
                {
                    txtNoDKN.Enabled = true;
                    txtNoDKN.ReadOnly = false;
                }
            }
        }

        private void RefreshDetail()
        {
            frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
            if (Modus == enumModus.New)
            {
                txtPerkiraan.NoPerkiraan = "";
                txtUraian.Text = "";
                numJumlah.Text = Convert.ToString(0);
            }
            else
            {
                txtPerkiraan.NoPerkiraan = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["No_perk"].Value, "").ToString();
                txtUraian.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                numJumlah.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                _RecIDDetail = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();
                if (txtPerkiraan.NoPerkiraan != "" && txtPerkiraan.NoPerkiraan != "[CODE]")
                {
                    dtPerkiraan = Class.Perkiraan.GetPerkiraan(txtPerkiraan.NoPerkiraan);
                    DataRow dr = dtPerkiraan.Rows[0];
                    txtPerkiraan.NamaPerkiraan = dr["NamaPerkiraan"].ToString();
                }
                else
                {
                    txtPerkiraan.NamaPerkiraan = "";
                }
                txtCollector.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                txtCollectorID.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["KodeKolektor"].Value.ToString();

                lookupBankTujuan.NamaBank = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["NamaBankTujuan"].Value.ToString();
                lookupBankTujuan.BankID = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["BankIDTujuan"].Value.ToString();

                lookupBankAsal1.NamaBank = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString();
                lookupBankAsal1.Lokasi = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Lokasi"].Value.ToString();

                lookupToko1.NamaToko = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                lookupToko1.KodeToko = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();

                _BankKotaRowID = new Guid(Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["BankKotaRowID"].Value, Guid.Empty).ToString());
                lookupBankTujuan.RowID = new Guid(Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["BankTujuanRowID"].Value, Guid.Empty).ToString());

                if (_IsiPin == "1")
                {
                    dateDKN.ReadOnly = true; dateDKN.TabStop = false;
                    txtNoDKN.Enabled = true; txtNoDKN.ReadOnly = false; txtNoDKN.TabStop = true;
                    txtGudang.Enabled = false; txtGudang.TabStop = false;
                    optDebet.Enabled = false; optDebet.TabStop = false;
                    optKredit.Enabled = false; optKredit.TabStop = false;
                    txtPerkiraan.Enabled = false; txtPerkiraan.TabStop = false;
                    txtUraian.ReadOnly = true; txtUraian.TabStop = false;
                    numJumlah.ReadOnly = true; numJumlah.TabStop = false;
                    txtCollector.ReadOnly = true; txtCollector.TabStop = false;
                    //lookupBankAsal.Enabled = false; lookupBankAsal.TabStop = false;
                }
            }
        }

        private void GetDialogResult(Kasir.frmLookupCollector dialogForm)
        {
            this.CollectorID = dialogForm.KodeCollector;
            this.NamaCollector = dialogForm.NamaCollector;
            txtCollector.Text = NamaCollector;
            txtCollectorID.Text = dialogForm.KodeCollector;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCollector_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Kasir.frmLookupCollector ifrmDialog = new ISA.Finance.Kasir.frmLookupCollector(txtCollector.Text);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            DateTime Tanggal = DateTime.Parse(dateDKN.DateValue.ToString());
            if (Tanggal <= DateTime.Today.AddDays(DateTime.Today.Day * -1))
            {
                MessageBox.Show("Tidak boleh Input Transaksi Mundur.");
                dateDKN.Focus();
                return;
            }

            if (txtNoDKN.Text == "")
            {
                MessageBox.Show("Nomor KN harus diisi.");
                txtNoDKN.Focus();
                return;
            }

            _BankTujuanRowID = lookupBankTujuan.RowID;
            _BankIDtujuan = lookupBankTujuan.BankID;
            _KodeToko = lookupToko1.KodeToko;
            _Lokasi = lookupBankAsal1.Lokasi;

            GetDataBankKota();
            if (_IsiPin == "")
            {
                InsertDataHeader();
                InsertDataDetail();
            }

            if (_IsiPin == "1")
            {
                UpdateDKN();
            }

            if (this.Caller is Finance.DKNForm.frmDebetKreditNotaBrowse)
            {
                Finance.DKNForm.frmDebetKreditNotaBrowse frmcaller = (Finance.DKNForm.frmDebetKreditNotaBrowse)this.Caller;
                frmcaller.UpdateFlagPinKN(_HeaderID, _DetailID);
                frmcaller.UpdateFlagLinkID(_HeaderID, _DetailID);
                frmcaller.RefreshDkn();
                frmcaller.RefreshDknDetail();
                frmcaller.FindHeader("RowID", _HeaderID.ToString());
                frmcaller.FindDetail("RowIDD", _DetailID.ToString());
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void GetDataBankKota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dtBK = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_BankKota_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, lookupBankAsal1.NamaBank));
                    db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lookupBankAsal1.Lokasi));
                    dtBankKota = db.Commands[0].ExecuteDataTable();
                    if (dtBankKota.Rows.Count > 0)
                    {
                        _BankKotaRowID = new Guid(dtBankKota.Rows[0]["RowID"].ToString());
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
        }

        private void InsertDataHeader()
        {
            frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
            if (Modus == enumModus.New)
            {
                _HeaderID = Guid.NewGuid();
                _RecID = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 1);
            }
            DateTime TglBukti = Convert.ToDateTime(dateDKN.DateValue);
            string Cabang = txtGudang.Text;
            string DK = "";
            if (optDebet.Checked) DK = "D"; else DK = "K";

            using (Database db = new Database(GlobalVar.DBName))
            {
                //if (Modus == enumModus.Update) RowIDDKN = _HeaderID;
                DKN.DKNInsert(db, _HeaderID, _RecID, DK, "MAN", "B", "DKN", TglBukti, Cabang, "", _HeaderID);
            }
            frmCaller.RefreshDkn();

        }

        private void InsertDataDetail()
        {
            frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
            if (_IsiPin == "")
            {
                string NoPerkiraan = txtPerkiraan.NoPerkiraan;
                string Uraian = txtUraian.Text;
                Double Jumlah = Convert.ToDouble(numJumlah.Text);
                string KodeKolektor = txtCollectorID.Text;
                string Kolektor = txtCollector.Text;

                if (Modus == enumModus.New)
                {
                    _DetailID = Guid.NewGuid();
                    _RecIDDetail = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 1);
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    DKN.DKNDetailInsert(db, _DetailID, _HeaderID, _RecID, NoPerkiraan, Uraian, Jumlah, _DetailID, _RecIDDetail, KodeKolektor, _BankIDtujuan, _BankTujuanRowID, _BankKotaRowID, _KodeToko);
                }
                frmCaller.RefreshDknDetail();
            }
        }

        private void UpdateDKN()
        {
            try
            {
                frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
                //string HRecordID = Tools.isNull(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value, "").ToString();
                string CollectorID = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["KodeKolektor"].Value, "").ToString();
                string NamaCollector = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Nama"].Value, "").ToString();
                string noBuktiKasir = Numerator.BookNumerator("IND");
                string NomorKN = Tools.isNull(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value, "").ToString();
                string NoPerkiraan = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["No_perk"].Value, "").ToString();

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_DKN_LINK"));
                    db.Commands[0].Parameters.Add(new Parameter("@NomorKN", SqlDbType.VarChar, txtNoDKN.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, _RecID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecIDDetail", SqlDbType.VarChar, _RecIDDetail));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBuktiKasir));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan));
                    //db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                    //db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
                    db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, NomorKN));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
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
        }


        private void cmdCLOSE_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateDKN_Validating(object sender, CancelEventArgs e)
        {
            DateTime Tanggal = DateTime.Parse(dateDKN.DateValue.ToString());
            if (Tanggal <= DateTime.Today.AddDays(DateTime.Today.Day * -1))
            {
                MessageBox.Show("Tidak boleh Input Transaksi Mundur.");
                dateDKN.Focus();
                return;
            }
        }
    }
}
