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
    public partial class frmDebetKreditNotaUpdate : ISA.Finance.BaseForm
    {
        enum enumModus { New, Update };
        enum enumBrow { Header, Detail };
        enumModus Modus;
        enumBrow Brow;
        Guid _HeaderID, _DetailID;
        Guid _BankKotaRowID, _BankTujuanRowID;
        string _BankIDasal, _BankIDtujuan;
        DataTable dtPerkiraan;
        string noBukti, CollectorID = "", NamaCollector = "", _IsiPin = "";

        public event EventHandler SelectData;

        public frmDebetKreditNotaUpdate(Form Caller)
        {
            InitializeComponent();
            Modus = enumModus.New;
            Brow = enumBrow.Header;
            this.Caller = Caller;
        }
        public frmDebetKreditNotaUpdate(Form Caller, Guid HeaderID)
        {
            InitializeComponent();
            Modus = enumModus.Update;
            Brow = enumBrow.Header;
            _HeaderID = HeaderID;
            this.Caller = Caller;
        }
        public frmDebetKreditNotaUpdate(Form Caller, Guid HeaderID, Guid DetailID)
        {
            InitializeComponent();
            Brow = enumBrow.Detail;
            if (DetailID == Guid.Empty) Modus = enumModus.New;
            else Modus = enumModus.Update;
            _HeaderID = HeaderID;
            _DetailID = DetailID;
            this.Caller = Caller;
        }
        public frmDebetKreditNotaUpdate(Form Caller, Guid HeaderID, Guid DetailID, string IsiPin)
        {
            InitializeComponent();
            Brow = enumBrow.Detail;
            if (DetailID == Guid.Empty) Modus = enumModus.New;
            else Modus = enumModus.Update;
            _HeaderID = HeaderID;
            _DetailID = DetailID;
            _IsiPin = IsiPin;
            this.Caller = Caller;
        }

        private void frmDebetKreditNotaUpdate_Load(object sender, EventArgs e)
        {
            IsiComboCabang();
            RefreshHeader();
            RefreshDetail();
        }
        #region Functions
        private void RefreshHeader()
        {
            if (Brow == enumBrow.Header && Modus == enumModus.New)
            {
                dateDKN.DateValue = DateTime.Today;
                cboCabang.Text = "";
            }
            else
            {
                frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
                dateDKN.DateValue = Convert.ToDateTime(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                txtNoDKN.Text = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value.ToString();
                cboCabang.SelectedValue = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString();
                optDebet.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "D";
                optKredit.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "K";
            }
            dateDKN.Enabled = Brow == enumBrow.Header;
            txtNoDKN.Enabled = Brow == enumBrow.Header;
            cboCabang.Enabled = Brow == enumBrow.Header;
            optDebet.Enabled = Brow == enumBrow.Header;
            optKredit.Enabled = Brow == enumBrow.Header;

            txtPerkiraan.Enabled = Brow == enumBrow.Detail;
            txtUraian.Enabled = Brow == enumBrow.Detail;
            numJumlah.Enabled = Brow == enumBrow.Detail;
            txtCollector.Enabled = Brow == enumBrow.Detail;
            lookupBankAsal1.Enabled = Brow == enumBrow.Detail;
            lookupBankTujuan.Enabled = Brow == enumBrow.Detail;
        }

        private void RefreshDetail()
        {
            frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
            if (Brow == enumBrow.Header || Modus == enumModus.New)
            {
                txtPerkiraan.NoPerkiraan = "";
                txtUraian.Text = "";
                numJumlah.Text = Convert.ToString(0);
            }
            else
            {
                txtPerkiraan.NoPerkiraan = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["No_perk"].Value,"").ToString();
                txtUraian.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                numJumlah.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
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
                
                _BankKotaRowID = new Guid(Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["BankKotaRowID"].Value,Guid.Empty).ToString());
                lookupBankTujuan.RowID = new Guid(Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["BankTujuanRowID"].Value, Guid.Empty).ToString());

                if (_IsiPin == "1")
                {
                    dateDKN.ReadOnly = true; dateDKN.TabStop = false;
                    txtNoDKN.Enabled = true; txtNoDKN.ReadOnly = false; txtNoDKN.TabStop = true;
                    cboCabang.Enabled = false; cboCabang.TabStop = false;
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
        private void IsiComboCabang()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKNCabang_LIST"));
                cboCabang.DataSource = db.Commands[0].ExecuteDataTable();
                cboCabang.DisplayMember = "KodeCabang";
                cboCabang.ValueMember = "KodeCabang";
            }
        }
        #endregion

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            _BankTujuanRowID = lookupBankTujuan.RowID;
            _BankIDtujuan = lookupBankTujuan.BankID;
            string _KodeToko = lookupToko1.KodeToko;
            string lokasi = lookupBankAsal1.Lokasi;
            string bankID = lookupBankTujuan.BankID;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dtBK = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_BankKota_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, lookupBankAsal1.NamaBank));
                    db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lookupBankAsal1.Lokasi));
                    dtBK = db.Commands[0].ExecuteDataTable();
                    if (dtBK.Rows.Count > 0)
                    {
                        _BankKotaRowID = new Guid(dtBK.Rows[0]["RowID"].ToString());
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

            frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
            if (Brow == enumBrow.Header)
            {
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial,1);
                DateTime TglBukti = Convert.ToDateTime(dateDKN.DateValue);
                string Cabang = cboCabang.SelectedValue.ToString();
                string DK = "";
                if (optDebet.Checked) DK = "D"; else DK = "K";

                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (Modus == enumModus.Update) RowID = _HeaderID;
                    DKN.DKNInsert(db, RowID, RecordID, DK, "MAN", "B", "DKN", TglBukti, Cabang, "", RowID);
                }
                frmCaller.RefreshDkn();
            }
            else
            {
                if (_IsiPin == "")
                {
                    string NoPerkiraan = txtPerkiraan.NoPerkiraan;
                    string Uraian = txtUraian.Text;
                    string HRecordID = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                    string refRecordID = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 1);
                    Guid refRowID = Guid.NewGuid();
                    Double Jumlah = Convert.ToDouble(numJumlah.Text);
                    string KodeKolektor = txtCollectorID.Text;
                    string Kolektor = txtCollector.Text;
                    Guid rowIDdetail;

                    if (Modus == enumModus.New)
                        rowIDdetail = Guid.NewGuid();
                    else
                        rowIDdetail = _DetailID;

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        if (Modus == enumModus.Update) refRowID = _DetailID;
                        DKN.DKNDetailInsert(db, rowIDdetail, _HeaderID, HRecordID, NoPerkiraan, Uraian, Jumlah, refRowID, refRecordID, KodeKolektor, bankID, _BankTujuanRowID, _BankKotaRowID, _KodeToko );
                    }
                    frmCaller.RefreshDknDetail();
                }
                else
                {
                    UpdateDKN();
                }
            }
            this.Close();
        }

        private void UpdateDKN()
        {
            try
            {
                frmDebetKreditNotaBrowse frmCaller = (frmDebetKreditNotaBrowse)this.Caller;
                string HRecordID = Tools.isNull(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value,"").ToString();
                string CollectorID = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["KodeKolektor"].Value, "").ToString();
                string NamaCollector = Tools.isNull(frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Nama"].Value, "").ToString();
                string noBuktiKasir = Numerator.BookNumerator("IND");
                string NomorKN = Tools.isNull(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value, "").ToString();

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_DKN_LINK"));
                    db.Commands[0].Parameters.Add(new Parameter("@NomorKN", SqlDbType.VarChar, txtNoDKN.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@HrecordID", SqlDbType.VarChar, HRecordID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBuktiKasir));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCollector_KeyDown(object sender, KeyEventArgs e)
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

    }
}
