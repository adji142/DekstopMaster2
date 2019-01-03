using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmIndenUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, update };
        enumFormMode formMode;
        Guid RowIDI;
        Guid _rowIDPK;

        DataTable dtIndenRow;
        string noBukti, CollectorID = "", RpCash, RpTrf, RpGiro, RpCrd, RpDbt, Acc, NamaCollector = "", _nip;
        DateTime TglKasir;
        bool _isFromPiutang = false;
        double _rpsisa = 0;
        string _recID;

        public event EventHandler SelectData;

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

        public frmIndenUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
            this.Text = "Tambah Inden";
        }

        public frmIndenUpdate(Form caller, bool isFromPiutang, Double RpSisa, Guid RowIDPK, String NIP)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
            _isFromPiutang = isFromPiutang;
            this.Text = "Tambah Inden";
            _rpsisa = RpSisa;
            _rowIDPK = RowIDPK;
            _nip = NIP;
        }

        public frmIndenUpdate(Form caller, bool isFromPiutang, Double RpSisa, Guid RowIDPK, String NIP, String _recordID)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
            _isFromPiutang = isFromPiutang;
            this.Text = "Tambah Inden";
            _rpsisa = RpSisa;
            _rowIDPK = RowIDPK;
            _nip = NIP;
            _recID = _recordID;
        }

        public frmIndenUpdate(Form caller, Guid RowIDI, DataTable dtInden)
        {
            InitializeComponent();
            this.Caller = caller;
            this.RowIDI = RowIDI;
            formMode = enumFormMode.update;
            this.Text = "Edit Inden";
            dtIndenRow = dtInden.Copy();
            
        }

        private void frmIndenUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                tbTanggal.DateValue = DateTime.Today;
                tbTanggal.Focus();
                tbTanggal.SelectAll();
            }
            else
            {
                dtIndenRow.DefaultView.RowFilter = @"RowID='" + RowIDI.ToString() + "'";

                tbNoBukti.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["NoBukti"].ToString();
                tbTanggal.DateValue = (DateTime)dtIndenRow.DefaultView.ToTable().Rows[0]["TglKasir"];
                tbCollector.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["NamaCollector"].ToString();
                tbTunai.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpCash"].ToString();
                tbTransfer.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpTrf"].ToString();
                tbGiro.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpGiro"].ToString();
                tbCrd.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpCrd"].ToString();
                tbDbt.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpDbt"].ToString();
                tbKasir.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["Kasir"].ToString();
                tbMengetahui.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["Acc"].ToString();
                CollectorID = dtIndenRow.DefaultView.ToTable().Rows[0]["CollectorID"].ToString();
            }
        }

        private void clearForm()
        {
            tbNoBukti.Clear();
            tbTanggal.Clear();
            tbCollector.Clear();
            tbCrd.Clear();
            tbDbt.Clear();
            tbGiro.Clear();
            tbKasir.Clear();
            tbMengetahui.Clear();
            tbTransfer.Clear();
            tbTunai.Clear();
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
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDPK));
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            #region lama
            //try
            //{
            //    TglKasir = (DateTime)tbTanggal.DateValue;
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database(GlobalVar.DBName))
            //    {
            //        db.Commands.Add(db.CreateCommand("fsp_IsClosingKasir"));
            //        db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, TglKasir));
            //        object cek = db.Commands[0].ExecuteScalar();
            //        if (cek.ToString() == "True")
            //        {
            //            MessageBox.Show("Sudau Closing Kasir.");
            //            tbTanggal.Focus();
            //            return;
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

            try
            {
                if (tbTanggal.DateValue.ToString() != "" && tbCollector.Text != "")
                {
                    TglKasir = (DateTime)tbTanggal.DateValue;
                    Acc = tbMengetahui.Text;
                    NamaCollector = tbCollector.Text;
                    if (formMode == enumFormMode.New)
                    {
                        
                        if (PeriodeClosing.IsKasirClosed(TglKasir))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                        noBukti = Numerator.BookNumerator("IND");
                        //if (_isFromPiutang)
                        //    RowIDI = _rowIDPK;
                        //else
                        //    RowIDI = Guid.NewGuid();

                        string RecordIDI;
                        RowIDI = Guid.NewGuid();
                        if (_isFromPiutang)
                            RecordIDI = _recID;
                        else
                            RecordIDI = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Inden_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, TglKasir));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBukti));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
                            db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, Acc));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }

                        if (_isFromPiutang == true)
                        {
                            frmIndenDetailUpdate frm = new frmIndenDetailUpdate(this, RowIDI, RecordIDI, NamaCollector, TglKasir, noBukti, CollectorID, true, _rpsisa, _rowIDPK, _nip);
                            frm.ShowDialog();

                            this.Close();
                        }
                        else
                        {
                            frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                            frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                            frm.IndenRefresh();
                            frm.IndenFindRow("RowIDI", RowIDI.ToString());
                            this.Close();
                        }
                    }


                    else
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Inden_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, TglKasir));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
                            db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, Acc));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }

                        frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                        frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                        frm.IndenRefresh();
                        frm.IndenFindRow("RowIDI", RowIDI.ToString());
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Error.InputRequired);
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void lookupCollectorDialog()
        {
            frmLookupCollector ifrmDialog = new frmLookupCollector(tbCollector.Text);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmLookupCollector dialogForm)
        {
            this.CollectorID = dialogForm.KodeCollector;
            this.NamaCollector = dialogForm.NamaCollector;
            tbCollector.Text = NamaCollector;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }

        }

        private void tbCollector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lookupCollectorDialog();
            }
        }

        private void tbTanggal_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    TglKasir = (DateTime)tbTanggal.DateValue;
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database(GlobalVar.DBName))
            //    {
            //        db.Commands.Add(db.CreateCommand("fsp_IsClosingKasir"));
            //        db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, TglKasir));
            //        object cek = db.Commands[0].ExecuteScalar();
            //        if (cek.ToString() == "True")
            //        {
            //            MessageBox.Show("Sudau Closing Kasir.");
            //            tbTanggal.Focus();
            //            return;
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

        }

    }
}
