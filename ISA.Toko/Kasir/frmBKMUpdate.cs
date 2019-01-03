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
    public partial class frmBKMUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _recordID,_recordIDDetail,  _Terima, _noBukti, _Lampiran, _NamaPegawai, _Nip, _jp;
        bool _isFromPiutang = false;
        DateTime _Tanggal;
        DataTable dtBKMDetail;
        enum enumDetailMode { New, Update };
        enumDetailMode detailMode;
        Guid _rowIDDetail;
        double totalPiutang = 0;
        public frmBKMUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmBKMUpdate(Form caller, bool isFromPiutang,string namaPegawai,string nip,string jp)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaPegawai = namaPegawai;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;
            _jp = jp;
            this.Caller = caller;
        }

        public frmBKMUpdate(Form caller, Guid _rowID, string _recordID, string _Terima, string _noBukti, DateTime _Tanggal, string _Lampiran, string jp, bool isFromPiutang, string nip)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            this._rowID = _rowID;
            this._recordID = _recordID;
            this._Terima = _Terima;
            this._noBukti = _noBukti;
            this._Tanggal = _Tanggal;
            this._Lampiran = _Lampiran;
            _jp = jp;
            _isFromPiutang = isFromPiutang;
            _Nip = nip;

        }

        

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            tbUraian.Text = "";
            tbJumlah.Text = "0";
            gbBKMUpdate.Enabled = true;
            gbUpdateDetailBKM.Visible = true;
            tbUraian.Focus();
            gbUpdateDetailBKM.Top = 100;
            gbUpdateDetailBKM.Left = 200;
            detailMode = enumDetailMode.New;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            gbBKMUpdate.Enabled = true;
            gbUpdateDetailBKM.Visible = false;
           
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBKMUpdate_Load(object sender, EventArgs e)
        {
            if (_isFromPiutang == true)
            {
                cmdPrint.Enabled = false;
            }
            else
            {
                cmdPrint.Enabled = true;
            }
            //new
            if (formMode == enumFormMode.New)
            {
                if (_isFromPiutang == true)
                {
                    lookupStafAdm1.Kode = _NamaPegawai;
                }

                tbNoBKM.Text = "";
                tbTanggal.DateValue = DateTime.Now;
                tbLampiran.Text = "0";
                cmdAdd.Enabled = false;
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
                dgDetailBKM.Enabled = false;
                   
                
            }
            else if (formMode == enumFormMode.Update)
            {
                lookupStafAdm1.Kode = _Terima;
                tbNoBKM.Text = _noBukti;
                tbTanggal.DateValue = _Tanggal;
                tbLampiran.Text = _Lampiran;
                DetailRefresh();
                refreshTerbilang();

            }

            
        }

        private void DetailRefresh()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtBKMDetail = new DataTable();
                using (Database db = new Database("ISADBDepoFinance"))
                {
                    db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                    dtBKMDetail = db.Commands[0].ExecuteDataTable();

                    dtBKMDetail = BKM.ListDetail(db, _rowID);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtBKMDetail.DefaultView.Sort = "RecordID";
                dgDetailBKM.DataSource = dtBKMDetail.DefaultView;

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

        public void DetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKM.ListDetailperRow(RowID);
            if(dgDetailBKM.Rows.Count==0)
            {
                dtBKMDetail=dtResult.Copy();
                dtBKMDetail.DefaultView.Sort="RecordID";
                dgDetailBKM.DataSource = dtBKMDetail.DefaultView;
            }
            else
                dgDetailBKM.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }

        private void refreshTerbilang()
        {
            double total=0;
            if (dtBKMDetail.Rows.Count > 0)
            {
                total = Convert.ToDouble(dtBKMDetail.Compute("Sum(Jumlah)", string.Empty).ToString());
                tbLampiran.Text = dtBKMDetail.Rows.Count.ToString();
            }
            tbTotal.Text = total.ToString();
            if(total>0)
                tbTerbilang.Text = Tools.Terbilang(total);
            
        }

        private void tbTerima_Leave(object sender, EventArgs e)
        {
            
            string src = "";
            if (lookupStafAdm1.Kode != "" & lookupStafAdm1.Kode != "[CODE]")
            {
                _Tanggal = (DateTime)tbTanggal.DateValue;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (MessageBox.Show("Data Akan Disimpan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (formMode == enumFormMode.New)
                    {
                        _recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        if (_isFromPiutang != true)
                            src = "IN";
                        else
                            src = "PIK";
                        
                        _recordID = BKM.GetRecordIDBukti(_recordID, src);

                       // _noBukti = Numerator.BookNumerator("BKM");
                        _noBukti = Tools.AutoNumbering("NoBukti", "ISADbDepoFinance.dbo.Bukti");
                        _rowID=Guid.NewGuid();
                        try
                        {     
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                BKM.AddHeader(db, _rowID,_rowID, _recordID, _noBukti, "",src, _Tanggal, lookupStafAdm1.Kode, "", "", SecurityManager.UserName, "");
                                
                                if (_isFromPiutang == true)
                                    BKM.AddPinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKM", _noBukti, "", string.Empty, 0, totalPiutang, _jp);
                            }

                            tbNoBKM.Text = _noBukti;
                            //_Terima = tbTerima.Text;
                            cmdAdd.Enabled = true;
                            cmdEdit.Enabled = true;
                            cmdDelete.Enabled = true;
                            cmdPrint.Enabled = true;
                            dgDetailBKM.Enabled = true;

                            if (_isFromPiutang != true)
                            {
                                frmBKMBrowse frm = new frmBKMBrowse();
                                frm = (frmBKMBrowse)this.Caller;
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

                            dtBKMDetail = new DataTable();
                            dgDetailBKM.DataSource = dtBKMDetail.DefaultView;
                            dgDetailBKM.Focus();
                            
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
                            frmBKMBrowse frm = new frmBKMBrowse();
                            frm = (frmBKMBrowse)this.Caller;
                            frm.HeaderRowRefresh(_rowID);
                            frm.FindRowHeader("RowID", _rowID.ToString());
                            dgDetailBKM.Focus();
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
            if((tbUraian.Text!="")&&(tbJumlah.Text!=""))
            {
                try
                {
                    if (detailMode == enumDetailMode.New)
                    {
                        _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        _rowIDDetail = Guid.NewGuid();
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {

                            if (_isFromPiutang == false)
                            {
                                BKM.AddDetail(db, _rowIDDetail,_rowID, _recordIDDetail, _recordID, "", "", "", "", "", tbUraian.Text, tbJumlah.Text);
                                frmBKMBrowse frm = new frmBKMBrowse();
                                frm = (frmBKMBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                                frm.FindRowDetail("RowIDD", _rowIDDetail.ToString());
                            }
                            else
                            {

                                BKM.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", "", "", tbUraian.Text, tbJumlah.Text);
                                BKM.UpdatePinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKM", _noBukti, tbUraian.Text, string.Empty, _jp);

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
                            

                            gbBKMUpdate.Enabled = true;
                            gbUpdateDetailBKM.Visible = false;
                            dgDetailBKM.Focus();

                        }
                    }
                    else if (detailMode == enumDetailMode.Update)
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {


                            if (_isFromPiutang == false)
                            {
                                BKM.UpdateBuktiDetail(db, _rowIDDetail, "", tbUraian.Text, tbJumlah.Text);
                                frmBKMBrowse frm = new frmBKMBrowse();
                                frm = (frmBKMBrowse)this.Caller;
                                frm.HeaderRowRefresh(_rowID);
                                frm.DetailRowRefresh(_rowIDDetail);
                                frm.FindRowDetail("RowIDD", _rowIDDetail.ToString());
                            }
                            else
                            {
                                BKM.UpdateBuktiDetail(db, _rowIDDetail, "", tbUraian.Text, tbJumlah.Text);
                                BKM.UpdatePinjamanPegawai(db, _rowID, _recordID, _Nip, _Tanggal, "BKM", _noBukti, tbUraian.Text, string.Empty, _jp);

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

                            gbBKMUpdate.Enabled = true;
                            gbUpdateDetailBKM.Visible = false;
                        }

                    }

                }
                catch(Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            frmBKMBrowse frm = new frmBKMBrowse();
            frm = (frmBKMBrowse)this.Caller;
            frm.cetakLaporan();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgDetailBKM.SelectedCells.Count > 0)
            {
                tbUraian.Text = dgDetailBKM.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                //"" = dgDetailBKM.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
                tbJumlah.Text = dgDetailBKM.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                _rowIDDetail=(Guid)dgDetailBKM.SelectedCells[0].OwningRow.Cells["rowID"].Value;
                gbBKMUpdate.Enabled = true;
                gbUpdateDetailBKM.Visible = true;
                detailMode = enumDetailMode.Update;
                tbUraian.Focus();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dgDetailBKM.SelectedCells.Count > 0 && MessageBox.Show("Data akan dihapus?","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                _rowIDDetail = (Guid)dgDetailBKM.SelectedCells[0].OwningRow.Cells["rowID"].Value;

                try
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        if (_isFromPiutang == false)
                        {
                            BKM.DeleteBuktiDetail(db, _rowIDDetail);
                            frmBKMBrowse frm = new frmBKMBrowse();
                            frm = (frmBKMBrowse)this.Caller;
                            frm.HeaderRowRefresh(_rowID);
                            frm.FindRowDetail("RowIDD", _rowIDDetail.ToString());
                            frm.DetailDeleteRefresh();
                        }
                        else
                        {
                            BKM.DeleteBuktiDetail(db, _rowIDDetail);
                            BKM.UpdateUraianPinjaman(db, _rowID);
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
                    i = dgDetailBKM.SelectedCells[0].RowIndex;
                    n = dgDetailBKM.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgDetailBKM.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtBKMDetail.AcceptChanges();
                    dgDetailBKM.Focus();
                    dgDetailBKM.RefreshEdit();
                    if (dgDetailBKM.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgDetailBKM.CurrentCell = dgDetailBKM.Rows[0].Cells[n];
                            dgDetailBKM.RefreshEdit();
                        }
                        else
                        {
                            dgDetailBKM.CurrentCell = dgDetailBKM.Rows[i - 1].Cells[n];
                            dgDetailBKM.RefreshEdit();
                        }

                    }
                    #endregion
                   
                    //DetailRefresh();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DetailRefresh();
                    refreshTerbilang();
                    
                }

            }
        }

        private void dgDetailBKM_KeyDown(object sender, KeyEventArgs e)
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
