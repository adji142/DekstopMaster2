using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmBKKUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _recordID, _recordIDDetail, _Kepada, _noBukti, _Lampiran, _NamaPegawai, _Nip,_jp, _keteranganlain, _KeteranganJaminan;
        bool _isFromPiutang = false;
        DateTime _Tanggal;
        DataTable dtBKKDetail;
        enum enumDetailMode { New, Update };
        enumDetailMode detailMode;
        Guid _rowIDDetail;
        double totalPiutang = 0;
        double _rpsisa = 0;
        Guid _kpid;
        DateTime _tgljthtempopelunasan;
        int keluar = 0;
        string _recIDPiutangKaryawan;
        string imgBase64;

        public frmBKKUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, bool isFromPiutang, string namaPegawai, string nip, string jp, string jaminan)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaPegawai = namaPegawai;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
            _jp = jp;
            _KeteranganJaminan = jaminan;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, bool isFromPiutang, string namaPegawai, string nip, string jp, double rpsisa, DateTime tgljttempo, Guid KPID, string keteranganlain)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaPegawai = namaPegawai;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
            _jp = jp;
            _rpsisa = rpsisa;
            _tgljthtempopelunasan = tgljttempo;
            _kpid = KPID;
            _keteranganlain = keteranganlain;
            //_rowID = KPID;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, bool isFromPiutang,string namaPegawai,string nip,string jp, double rpsisa, DateTime tgljttempo, Guid KPID, string keteranganlain, string keteranganJaminan)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaPegawai = namaPegawai;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
            _jp = jp;
            _rpsisa = rpsisa;
            _tgljthtempopelunasan = tgljttempo;
            _kpid = KPID;
            _keteranganlain = keteranganlain;
            _KeteranganJaminan = keteranganJaminan;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, bool isFromPiutang, string noBKK)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _isFromPiutang = isFromPiutang;
            _noBukti = noBKK;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, Guid _rowID, string _recordID, string _Kepada, string _noBukti, DateTime _Tanggal, string _Lampiran, string jp, bool isFromPiutang, string nip, string _AttachmentBKK)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            this._rowID = _rowID;
            this._recordID = _recordID;
            this._Kepada = _Kepada;
            this._noBukti = _noBukti;
            this._Tanggal = _Tanggal;
            this._Lampiran = _Lampiran;
            _jp = jp;
            _isFromPiutang = isFromPiutang;
            this.picPreview.Image = Base64ToImage(_AttachmentBKK);
            //string _noData = noData;
        }

        public frmBKKUpdate(Form caller, Guid _rowID, string _recordID, string _Kepada, string _noBukti, DateTime _Tanggal, string _Lampiran, string jp, bool isFromPiutang, string nip)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            this._rowID = _rowID;
            this._recordID = _recordID;
            this._Kepada = _Kepada;
            this._noBukti = _noBukti;
            this._Tanggal = _Tanggal;
            this._Lampiran = _Lampiran;
            //_KeteranganJaminan = KeteranganJaminan;
            _jp = jp;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
        }


        private void frmBKKUpdate_Load(object sender, EventArgs e)
        {
            //tbTanggal.Enabled = SecurityManager.IsTax();
            if (_isFromPiutang == true)
            {
                cmdPrint.Enabled = false;
                tbKepada.ReadOnly = true;
                tbKepada.Focus();
            }
            //new
            if (formMode == enumFormMode.New)
            {
                if(_isFromPiutang == true)
                {
                    tbKepada.Text = _NamaPegawai;
                }

                tbNoBKK.Text = "";
                tbTanggal.DateValue = DateTime.Now;
                tbLampiran.Text = "0";
                cmdAdd.Enabled = false;
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
                dgDetailBKK.Enabled = false;


            }
            else if (formMode == enumFormMode.Update)
            {
                tbKepada.Text = _Kepada;
                tbNoBKK.Text = _noBukti;
                tbTanggal.DateValue = _Tanggal;
                tbLampiran.Text = _Lampiran;
                lblImage.Visible = false;
                DetailRefresh();
                refreshTerbilang();

            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (_isFromPiutang == true)
            {
                try
                {
                    DataTable dtPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("");
                    //tbUraian.NamaPerkiraan = dtPerkiraan.Rows[0]["uraian"].ToString();
                    //tbUraian.NoPerkiraan = dtPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                tbUraian.NamaPerkiraan = "";
                tbUraian.NoPerkiraan = "?";
            }
            tbJumlah.Text = _rpsisa.ToString();    // "0";
            tbAcc.Text = "";
            gbBKKUpdate.Enabled = true;
            gbUpdateDetailBKK.Visible = true;
            gbUpdateDetailBKK.Top = 100;
            gbUpdateDetailBKK.Left = 200;
            detailMode = enumDetailMode.New;
            txtUraian.Text = "";
            tbUraian.Focus();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            //jika dari TSL Piutang Karyawan, buka form Inden
            if (_jp == "2" || _jp == "5")
            {
                if (dgDetailBKK.Rows.Count > 0)
                {
                    if (MessageBox.Show("Selesai isi BKK dan Melanjutkan Buat Inden ?", "Informasi", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        frmIndenUpdate frm = new frmIndenUpdate(this, true, _rpsisa, _rowID, _Nip, _recIDPiutangKaryawan);
                        frm.ShowDialog();

                        Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                        frmUtang = (frmPiutangKaryawan)this.Caller;

                        frmUtang.RefreshPegawai(_Nip);
                        frmUtang.FindRowPegawsai("NIP", _Nip);
                        //frmUtang.RefreshPiutang(_rowID);
                        frmUtang.RefreshPiutang();
                        frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                        keluar = 1;

                    }
                    else
                    {
                        if (MessageBox.Show("Batalkan Inputan Piutang Karyawan " + tbKepada.Text + " ?", "Informasi", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PinjamanPegawaiBukti_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                            frmUtang = (frmPiutangKaryawan)this.Caller;

                            frmUtang.RefreshPegawai(_Nip);
                            frmUtang.FindRowPegawsai("NIP", _Nip);
                            //frmUtang.RefreshPiutang(_rowID);
                            frmUtang.RefreshPiutang();
                            frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                            keluar = 1;
                            this.Close();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Batalkan Inputan Piutang Karyawan " + tbKepada.Text + " ?", "Informasi", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_PinjamanPegawaiBukti_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                        frmUtang = (frmPiutangKaryawan)this.Caller;

                        frmUtang.RefreshPegawai(_Nip);
                        frmUtang.FindRowPegawsai("NIP", _Nip);
                        //frmUtang.RefreshPiutang(_rowID);
                        frmUtang.RefreshPiutang();
                        frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                        keluar = 1;
                        this.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }

                }
            }

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            gbBKKUpdate.Enabled = true;
            gbUpdateDetailBKK.Visible = false;
        }

        public void DetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKM.ListDetailperRow(RowID);
            if (dgDetailBKK.Rows.Count == 0)
            {
                dtBKKDetail = dtResult.Copy();
                dtBKKDetail.DefaultView.Sort = "RecordID";
                dgDetailBKK.DataSource = dtBKKDetail.DefaultView;
            }
            else
            dgDetailBKK.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }
        public void FindRowDetail(string column, string value)
        {
            dgDetailBKK.FindRow(column, value);
        }

        private void DetailRefresh()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtBKKDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    dtBKKDetail = BKK.ListDetail(db,_rowID);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtBKKDetail.DefaultView.Sort = "RecordID";
                dgDetailBKK.DataSource = dtBKKDetail.DefaultView;

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

        private void refreshTerbilang()
        {
            double total = 0;
            if (dtBKKDetail.Rows.Count > 0)
            {
                total = Convert.ToDouble(dtBKKDetail.Compute("Sum(Jumlah)", string.Empty).ToString());
                tbLampiran.Text = dtBKKDetail.Rows.Count.ToString();
            }
            tbTotal.Text = total.ToString();
            if (total > 0) {
                tbTerbilang.Text = ISA.Common.Tools.Terbilang(total);
            }
            if (dtBKKDetail.Rows.Count < 1)
            {
                tbTerbilang.Text = "";
            }

        }

        private void tbKepada_Leave(object sender, EventArgs e)
        {
            string src = "";
            if ((tbKepada.Text != "") && (tbKepada.Text != _Kepada))
            {
                _Tanggal = (DateTime)tbTanggal.DateValue;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing! Tidak Bisa Tambah Data.");
                    return;
                }

                if (imgBase64 != null)
                {
                    if (MessageBox.Show("Data Akan Disimpan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (formMode == enumFormMode.New)
                        {
                            ////tambahan
                            if (_isFromPiutang)
                            {
                                if (_jp == "2" || _jp == "5")
                                {
                                    try
                                    {
                                        DataTable dtc = new DataTable();
                                        using (Database db = new Database(GlobalVar.DBName))
                                        {
                                            db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_LIST"));
                                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _kpid));
                                            db.Commands[0].Parameters.Add(new Parameter("@Nip", SqlDbType.VarChar, _Nip));
                                            dtc = db.Commands[0].ExecuteDataTable();
                                        }
                                        if (dtc.Rows.Count > 0)
                                        {
                                            MessageBox.Show("Data sudah dinput.");
                                            return;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Error.LogError(ex);
                                    }
                                }
                                else
                                {
                                    _keteranganlain = "";
                                }
                            }
                            else
                            {
                                _keteranganlain = "";
                            }

                            if (_isFromPiutang != true)
                                src = "OUT";
                            else
                                src = "PIK";

                            //_recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                            string _rcid = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                            _recordID = BKK.GetRecordIDBukti(_rcid, src);

                            if (_isFromPiutang)
                            {
                                if (_recordID.Length > 0 && !string.IsNullOrEmpty(_Nip))
                                {
                                    _recIDPiutangKaryawan = _recordID.Replace(_recordID.Substring(22, 1), _jp);
                                }
                            }

                            if (_isFromPiutang)
                            {
                                if (_jp == "2" || _jp == "5")
                                    _rowID = _kpid;
                                else
                                    _rowID = Guid.NewGuid();
                            }
                            else
                            {
                                _rowID = Guid.NewGuid();
                            }
                            //_rowID = Guid.NewGuid();

                            _noBukti = Numerator.BookNumerator("BKK");
                            try
                            {
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.BeginTransaction();
                                    BKK.AddHeader(db, _rowID, _rowID, _recordID, _noBukti, "", src, _Tanggal, tbKepada.Text, "", "", SecurityManager.UserName, " ", imgBase64);

                                    if (_isFromPiutang == true)
                                        BKK.AddPinjamanPegawai(db, _rowID, _recIDPiutangKaryawan, _Nip, _Tanggal, "BKK", _noBukti, "", _keteranganlain, totalPiutang, 0, _jp);
                                    //BKK.AddPinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, "", _keteranganlain, totalPiutang, 0, _jp);
                                    //BKK.AddPinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, "", string.Empty, totalPiutang, 0, _jp);
                                    db.CommitTransaction();

                                }

                                tbNoBKK.Text = _noBukti;
                                _Kepada = tbKepada.Text;
                                cmdAdd.Enabled = true;
                                cmdEdit.Enabled = true;
                                cmdDelete.Enabled = true;
                                cmdPrint.Enabled = true;
                                dgDetailBKK.Enabled = true;

                                if (_isFromPiutang != true)
                                {
                                    frmBKKBrowse frm = new frmBKKBrowse();
                                    frm = (frmBKKBrowse)this.Caller;
                                    frm.HeaderRowRefresh(_rowID);
                                    frm.FindRowHeader("RowID", _rowID.ToString());
                                }
                                else
                                {
                                    Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                                    frmUtang = (frmPiutangKaryawan)this.Caller;

                                    frmUtang.RefreshPegawai(_Nip);
                                    frmUtang.FindRowPegawsai("NIP", _Nip);
                                    frmUtang.RefreshPiutang(_rowID);
                                    frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                                }

                                dtBKKDetail = new DataTable();
                                dgDetailBKK.DataSource = dtBKKDetail.DefaultView;
                                dgDetailBKK.Focus();
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                        else if (formMode == enumFormMode.Update)
                        {
                            try
                            {
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Bukti_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, tbKepada.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                frmBKKBrowse frm = new frmBKKBrowse();
                                frm = (frmBKKBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                dgDetailBKK.Focus();

                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Attachment belum ditambahkan !!");
                    return;
                }                 
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (tbUraian.NoPerkiraan == "" || tbUraian.NoPerkiraan == "?")
            {
                MessageBox.Show("No Perkiraan masih kosong.");
                return;
            }

            totalPiutang = tbJumlah.GetDoubleValue + tbTotal.GetDoubleValue;
            if ((tbUraian.NoPerkiraan != "") && (tbUraian.NoPerkiraan != "?") && (tbJumlah.Text != ""))
            {
                try
                {
                    if (detailMode == enumDetailMode.New)
                    {
                        _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        _rowIDDetail = Guid.NewGuid();
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            if (_isFromPiutang == false)
                            {
                                //BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, tbUraian.NoPerkiraan.Trim().Equals("")? "?":tbUraian.NoPerkiraan, tbUraian.NamaPerkiraan, tbJumlah.Text);
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, tbUraian.NoPerkiraan.Trim().Equals("") ? "?" : tbUraian.NoPerkiraan, txtUraian.Text, tbJumlah.Text);
                                frmBKKBrowse frm = new frmBKKBrowse();
                                frm = (frmBKKBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                                frm.FindRowDetail("RowIDD", _rowIDDetail.ToString());
                            }
                            else
                            {
                                db.BeginTransaction();
                                //BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, tbUraian.NoPerkiraan, tbUraian.NamaPerkiraan, tbJumlah.Text);
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, tbUraian.NoPerkiraan, txtUraian.Text, tbJumlah.Text);
                                //BKK.UpdatePinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, tbUraian.NamaPerkiraan, string.Empty, _jp);
                                BKK.UpdatePinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, txtUraian.Text, _keteranganlain, _jp);
                                db.CommitTransaction();

                                Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                                frmUtang = (frmPiutangKaryawan)this.Caller;

                                frmUtang.RefreshPegawai(_Nip);
                                frmUtang.FindRowPegawsai("NIP", _Nip);
                                //frmUtang.RefreshPiutang(_rowID);
                                frmUtang.RefreshPiutang();
                                frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                            }

                            tbUraian.NamaPerkiraan = "";
                            tbUraian.NoPerkiraan = "?";
                            tbJumlah.Text = "0";
                            tbAcc.Text = "";
                            DetailRowRefresh(_rowIDDetail);
                            FindRowDetail("rowID", _rowIDDetail.ToString());
                            refreshTerbilang();

                            gbBKKUpdate.Enabled = true;
                            gbUpdateDetailBKK.Visible = false;
                            dgDetailBKK.Focus();
                            
                        }
                    }
                    else if (detailMode == enumDetailMode.Update)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {

                            if (_isFromPiutang == false)
                            {
                                BKK.UpdateBuktiDetail(db, _rowIDDetail, tbUraian.NoPerkiraan, tbUraian.NamaPerkiraan, tbJumlah.Text);
                                frmBKKBrowse frm = new frmBKKBrowse();
                                frm = (frmBKKBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                            }
                            else
                            {
                                db.BeginTransaction();
                                BKK.UpdateBuktiDetail(db, _rowIDDetail, tbUraian.NoPerkiraan, tbUraian.NamaPerkiraan, tbJumlah.Text);
                                BKK.UpdatePinjamanPegawai(db,_rowID,_recordID,_Nip,_Tanggal,"BKK",_noBukti,tbUraian.NamaPerkiraan,string.Empty,_jp);
                                db.CommitTransaction();

                                Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                                frmUtang = (frmPiutangKaryawan)this.Caller;
                                frmUtang.RefreshPegawai(_Nip);
                                frmUtang.FindRowPegawsai("NIP", _Nip);
                                frmUtang.RefreshPiutang(_rowID);
                                frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                             
                            }

                            tbUraian.NamaPerkiraan = "";
                            tbUraian.NoPerkiraan = "?";
                            tbJumlah.Text = "0";
                            DetailRowRefresh(_rowIDDetail);
                            refreshTerbilang();
                            

                            gbBKKUpdate.Enabled = true;
                            gbUpdateDetailBKK.Visible = false;
                        }

                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgDetailBKK.SelectedCells.Count > 0)
            {
                txtUraian.Text = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                tbUraian.NamaPerkiraan = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                tbUraian.NoPerkiraan = dgDetailBKK.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
                tbJumlah.Text = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                _rowIDDetail = (Guid)dgDetailBKK.SelectedCells[0].OwningRow.Cells["rowID"].Value;
                gbBKKUpdate.Enabled = true;
                gbUpdateDetailBKK.Visible = true;
                detailMode = enumDetailMode.Update;
                tbUraian.Focus();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            frmBKKBrowse frm = new frmBKKBrowse();
            frm = (frmBKKBrowse)this.Caller;
            frm.cetakLaporan();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dgDetailBKK.SelectedCells.Count > 0 && MessageBox.Show("Data akan dihapus?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _rowIDDetail = (Guid)dgDetailBKK.SelectedCells[0].OwningRow.Cells["rowID"].Value;
                try
                {

                    
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        if (_isFromPiutang == false)
                        {
                            BKK.DeleteBuktiDetail(db, _rowIDDetail);
                            frmBKKBrowse frm = new frmBKKBrowse();
                            frm = (frmBKKBrowse)this.Caller;
                            frm.HeaderRowRefresh(_rowID);
                            frm.FindRowDetail("RowIDD",_rowIDDetail.ToString());
                            frm.DetailDeleteRefresh();
                        }
                        else
                        {
                            db.BeginTransaction();
                            BKK.DeleteBuktiDetail(db, _rowIDDetail);
                            BKK.UpdateUraianPinjaman(db, _rowID);
                            db.CommitTransaction();

                            Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                            frmUtang = (frmPiutangKaryawan)this.Caller;
                            frmUtang.RefreshPegawai(_Nip);
                            frmUtang.FindRowPegawsai("NIP", _Nip);
                            //frmUtang.RefreshPiutang(_rowID);
                            frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                        

                        }

                        
                    }
#region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = dgDetailBKK.SelectedCells[0].RowIndex;
                    n = dgDetailBKK.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgDetailBKK.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtBKKDetail.AcceptChanges();
                    dgDetailBKK.Focus();
                    dgDetailBKK.RefreshEdit();
                    if (dgDetailBKK.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgDetailBKK.CurrentCell = dgDetailBKK.Rows[0].Cells[n];
                            dgDetailBKK.RefreshEdit();
                        }
                        else
                        {
                            dgDetailBKK.CurrentCell = dgDetailBKK.Rows[i - 1].Cells[n];
                            dgDetailBKK.RefreshEdit();
                        }

                    }
#endregion
                   
                    //Korban editan
                   // DetailRefresh();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    
                    refreshTerbilang();
                
                }

            }
        }

        private void dgDetailBKK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdAdd_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Space)
            {
                cmdEdit_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cmdDelete_Click(sender, e);
            }
        }

        private void gbUpdateDetailBKK_Enter(object sender, EventArgs e)
        {

        }

        private void frmBKKUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (keluar == 0)
            {
                if (_isFromPiutang)
                {
                    if (_jp == "2" || _jp == "5")
                    {
                        cmdExit.PerformClick();
                    }
                }
                //else
                //{
                //    Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                //    frmUtang = (frmPiutangKaryawan)this.Caller;
                //    frmUtang.EnabledBehind();
                //}
            }
            //else
            //{
            //    Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
            //    frmUtang = (frmPiutangKaryawan)this.Caller;
            //    frmUtang.EnabledBehind();
            //}
        }

        private void frmBKKUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_isFromPiutang)
                {
                    cmdExit.PerformClick();
                }
            }
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            try
            {
                OFD.Filter = "File Gambar (*.JPEG, *.jpg, *.bmp, *.gif, *.png)|*.JPEG; *.jpg; *.bmp; *.gif; *.png";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string strFilename = OFD.SafeFileName;
                    string strPathName = OFD.FileName;

                    System.IO.FileInfo fileSize = new System.IO.FileInfo(strPathName);

                    if (fileSize.Length > 1048576)
                    {
                        MessageBox.Show("Ukuran file terlalu besar. Maksimal 1 MB");
                    }
                    else
                    {
                        imgBase64 = Base64FromImage(strPathName);
                        string strUser = SecurityManager.UserID;
                        if (formMode == enumFormMode.Update)
                        {

                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_Bukti_AttachmentBKK"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@AttachmentBKK", SqlDbType.VarChar, imgBase64));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, strUser));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            frmBKKBrowse frm = new frmBKKBrowse();
                            frm = (frmBKKBrowse)this.Caller;
                            frm.HeaderRowRefresh(_rowID);

                        }
                        lblFile.Text = "*" + strFilename;

                        Image img = Base64ToImage(imgBase64);
                        picPreview.Image = img;
                        lblImage.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR ATTACHMENT FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbKepada_TextChanged(object sender, EventArgs e)
        {

        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private string Base64FromImage(string PathImage)
        {
            string strResult = string.Empty;
            using (Image img = Image.FromFile(PathImage))
            {
                using (System.IO.MemoryStream m = new System.IO.MemoryStream())
                {
                    img.Save(m, img.RawFormat);
                    byte[] bit = m.ToArray();

                    strResult = Convert.ToBase64String(bit);
                }
            }
            return strResult;
        }
    }
}
