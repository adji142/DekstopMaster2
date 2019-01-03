using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmBKKUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _recordID, _recordIDDetail, _Kepada, _noBukti, _Lampiran, _NamaPegawai, _Nip,_jp;
        bool _isFromPiutang = false;
        DateTime _Tanggal;
        DataTable dtBKKDetail;
        enum enumDetailMode { New, Update };
        enumDetailMode detailMode;
        Guid _rowIDDetail;
        double totalPiutang = 0;
        bool linkPembelian = false;
        string _uraian="", _nominal="";
        Guid _rowIDPembelian;
        public frmBKKUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmBKKUpdate(Form caller, string uraian, string nominal, Guid RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            linkPembelian = true;
            _uraian = uraian;
            _nominal = nominal;
            _rowIDPembelian = RowID;
        }

        public frmBKKUpdate(Form caller, bool isFromPiutang,string namaPegawai,string nip,string jp)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaPegawai = namaPegawai;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
            _jp = jp;
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

        public frmBKKUpdate(Form caller, Guid _rowID, string _recordID, string _Kepada, string _noBukti, DateTime _Tanggal, string _Lampiran,string jp,bool isFromPiutang,string nip)
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
            _Nip = nip;
        }

        private void frmBKKUpdate_Load(object sender, EventArgs e)
        {
            if (_isFromPiutang == true)
            {
                cmdPrint.Enabled = false;
            }
            //new
            if (formMode == enumFormMode.New)
            {
                if(_isFromPiutang == true)
                {
                    lookupStafAdm1.Kode = _NamaPegawai;
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
                lookupStafAdm1.Kode = _Kepada;
                tbNoBKK.Text = _noBukti;
                tbTanggal.DateValue = _Tanggal;
                tbLampiran.Text = _Lampiran;
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
                    DataTable dtPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("PK");
                    tbUraian.Text = dtPerkiraan.Rows[0]["uraian"].ToString();
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                tbUraian.Text = "";
                
            }

            if(linkPembelian)
            {
                if (dgDetailBKK.Rows.Count > 0)
                {
                    MessageBox.Show("BKK dr Nota Pembelian tidah bisa mempunyai 2 detail");
                    return;
                }
                tbUraian.Text = _uraian;
                tbJumlah.Text = _nominal;
                tbAcc.Text = "";
                tbJumlah.Enabled=false;
            }
            else
            {
            tbJumlah.Text = "0";
            tbAcc.Text = "";
            }
            gbBKKUpdate.Enabled = true;
            gbUpdateDetailBKK.Visible = true;
            gbUpdateDetailBKK.Top = 100;
            gbUpdateDetailBKK.Left = 200;
            detailMode = enumDetailMode.New;
            tbUraian.Focus();

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            if (linkPembelian)
            {
                if (dgDetailBKK.Rows.Count > 0)
                {
                    try
                    {
                      
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelian_UpdateLink"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDPembelian));
                            db.Commands[0].Parameters.Add(new Parameter("@rowIDBKK", SqlDbType.UniqueIdentifier, _rowID));                            
                            db.Commands[0].ExecuteNonQuery();
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

                    Pembelian.frmBrgDiterimaGdgBrowser frmBeli = new Pembelian.frmBrgDiterimaGdgBrowser();
                    frmBeli = (Pembelian.frmBrgDiterimaGdgBrowser)this.Caller;
                    frmBeli.RefreshDataNotaBeliByID(_rowIDPembelian.ToString());
                    
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
                using (Database db = new Database(GlobalVar.DBFinance))
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
            if (total > 0)
                tbTerbilang.Text = Tools.Terbilang(total);

        }

        private void tbKepada_Leave(object sender, EventArgs e)
        {
            
            string src = "";
            if (lookupStafAdm1.Kode != "" & lookupStafAdm1.Kode != "[CODE]")
            {
                _Tanggal = (DateTime)tbTanggal.DateValue;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing! Tidak Bisa Tambah Data.");
                    return;
                }
                if (MessageBox.Show("Data Akan Disimpan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (formMode == enumFormMode.New)
                    {
                        _recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                        if (_isFromPiutang != true)
                            src = "OUT";
                        else
                            src = "PIK";

                        
                        _recordID = BKK.GetRecordIDBukti(_recordID, src);

                        _rowID=Guid.NewGuid();

                        //_noBukti = Tools.AutoNumbering("NoBukti", "ISADbDepoFinance.dbo.Bukti");
                        _noBukti = Numerator.BookNumerator("BKK");
                         try
                        {                          
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();
                                BKK.AddHeader(db, _rowID,_rowID,_recordID, _noBukti, "", src ,_Tanggal , lookupStafAdm1.Kode, "", "", SecurityManager.UserName, "");
                                
                                if(_isFromPiutang == true)
                                    BKK.AddPinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, "", string.Empty, totalPiutang, 0, _jp);
                                db.CommitTransaction();
                                
                            }

                            tbNoBKK.Text = _noBukti;
                            _Kepada = lookupStafAdm1.Kode;
                            cmdAdd.Enabled = true;
                            cmdEdit.Enabled = true;
                            cmdDelete.Enabled = true;
                            cmdPrint.Enabled = true;
                            dgDetailBKK.Enabled = true;

                            if(linkPembelian)
                            {
                                //cmdAdd.Enabled = false;
                            }
                            else if (_isFromPiutang != true)
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

                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.Commands.Add(db.CreateCommand("usp_Bukti_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, lookupStafAdm1.Kode));
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
                    cmdAdd.PerformClick();
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            totalPiutang = tbJumlah.GetDoubleValue + tbTotal.GetDoubleValue;
            if ((tbUraian.Text != "") && (tbJumlah.Text != ""))
            {
                try
                {
                    if (detailMode == enumDetailMode.New)
                    {
                        _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        _rowIDDetail = Guid.NewGuid();
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            if (linkPembelian)
                            {
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, "".Trim().Equals("") ? "?" : "", tbUraian.Text, tbJumlah.Text);
                            }
                            else if (_isFromPiutang == false)
                            {
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, "".Trim().Equals("")? "?":"", tbUraian.Text, tbJumlah.Text);

                               
                                frmBKKBrowse frm = new frmBKKBrowse();
                                frm = (frmBKKBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                                frm.FindRowDetail("RowIDD", _rowIDDetail.ToString());

                                

                            }
                            else
                            {
                                db.BeginTransaction();
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", tbAcc.Text, "", tbUraian.Text, tbJumlah.Text);
                                BKK.UpdatePinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKK", _noBukti, tbUraian.Text, string.Empty, _jp);
                                db.CommitTransaction();

                                Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                                frmUtang = (frmPiutangKaryawan)this.Caller;

                                frmUtang.RefreshPegawai(_Nip);
                                frmUtang.FindRowPegawsai("NIP", _Nip);
                                //frmUtang.RefreshPiutang(_rowID);
                                frmUtang.RefreshPiutang();
                                frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                                                           

                            }

                            tbUraian.Text = "";
                            
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
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            if (linkPembelian)
                            {
                                BKK.UpdateBuktiDetail(db, _rowIDDetail, "", tbUraian.Text, tbJumlah.Text);
                            }
                            else if (_isFromPiutang == false)
                            {
                                BKK.UpdateBuktiDetail(db, _rowIDDetail, "", tbUraian.Text, tbJumlah.Text);
                                frmBKKBrowse frm = new frmBKKBrowse();
                                frm = (frmBKKBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                            }
                            else
                            {
                                db.BeginTransaction();
                                BKK.UpdateBuktiDetail(db, _rowIDDetail, "", tbUraian.Text, tbJumlah.Text);
                                BKK.UpdatePinjamanPegawai(db,_rowID,_recordID,_Nip,_Tanggal,"BKK",_noBukti,tbUraian.Text,string.Empty,_jp);
                                db.CommitTransaction();

                                Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                                frmUtang = (frmPiutangKaryawan)this.Caller;
                                frmUtang.RefreshPegawai(_Nip);
                                frmUtang.FindRowPegawsai("NIP", _Nip);
                                frmUtang.RefreshPiutang(_rowID);
                                frmUtang.FindRowPiutang("RowID", _rowID.ToString());
                             
                            }

                                                        


                            tbUraian.Text = "";
                            //"" = "?";
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
                tbUraian.Text = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                //"" = dgDetailBKK.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
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

                    
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        if (linkPembelian)
                        {
                            BKK.DeleteBuktiDetail(db, _rowIDDetail);
                        }
                        else if (_isFromPiutang == false)
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
                            frmUtang.RefreshPiutang(_rowID);
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

        
    }
}
