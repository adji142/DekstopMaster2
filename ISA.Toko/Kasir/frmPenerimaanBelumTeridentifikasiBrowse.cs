using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Common;
using ISA.Toko.Class;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ISA.Toko.Kasir
{
    public partial class frmPenerimaanBelumTeridentifikasiBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectMode { Inden, IndenDetail, IndenSubDetail, IndenSuperDetail};
        enumSelectMode selectMode;
        DateTime _fromDate, _toDate;
        DataTable dtInden = new DataTable();
        DataTable dtIndenDetail = new DataTable();
        DataTable dtIndenSubDetail = new DataTable();
        DataTable dtIndenSuperDetail = new DataTable();
        Guid _RowIDI, _RowIDID, _RowIDISD, _RowIDISPD;
        string _KodeCollector = string.Empty;
        public frmPenerimaanBelumTeridentifikasiBrowse()
        {
            InitializeComponent();
        }

        private void frmPenerimaanBelumTeridentifikasiBrowse_Load(object sender, EventArgs e)
        {
            //tbRangeTanggal.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //tbRangeTanggal.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            tbRangeTanggal.FromDate = DateTime.Today;
            tbRangeTanggal.ToDate = DateTime.Today;
            IndenRefresh();
        }
        
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            IndenRefresh();
            
        }

        public void IndenRefresh()
        {
            _fromDate = (DateTime)tbRangeTanggal.FromDate;
            _toDate = (DateTime)tbRangeTanggal.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtInden = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Inden_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtInden = db.Commands[0].ExecuteDataTable();
                }

                if (dtInden.Rows.Count > 0)
                {
                    dtInden.DefaultView.Sort = "Tglkasir, NoBukti";
                    dgInden.DataSource = dtInden.DefaultView;

                    tbTotalCash.Text = dtInden.Compute("Sum(RpCash)", string.Empty).ToString();
                    tbTotalTransfer.Text = dtInden.Compute("Sum(RpTrf)", string.Empty).ToString();
                    tbTotalGiro.Text = dtInden.Compute("Sum(RpGiro)", string.Empty).ToString();
                    tbTotalCreditCard.Text = dtInden.Compute("Sum(RpCrd)", string.Empty).ToString();
                    tbTotalDebetCard.Text = dtInden.Compute("Sum(RpDbt)", string.Empty).ToString();

                    //IndenDetailRefresh();
                    
                }
                else
                {
                    dtIndenDetail.Clear();
                    dtIndenSubDetail.Clear();
                    dtIndenSuperDetail.Clear();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                dgInden.Focus();
                selectMode = enumSelectMode.Inden;
                dgInden.DataSource = dtInden.DefaultView;
                dgIndenDetail.DataSource = dtIndenDetail.DefaultView;
                dgIndenSubDetail.DataSource = dtIndenSubDetail.DefaultView;
                dgIndenSuperDetail.DataSource = dtIndenSuperDetail.DefaultView;
            }
        }

        public void IndenDetailRefresh()
        {
            _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtIndenDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDI));
                    dtIndenDetail = db.Commands[0].ExecuteDataTable();
                }


                if (dtIndenDetail.Rows.Count > 0)
                {
                    dtIndenDetail.DefaultView.Sort = "RecordID";
                    dgIndenDetail.DataSource = dtIndenDetail.DefaultView;
                    //IndenSubDetailRefresh();
                }
                else
                {
                    dtIndenSubDetail.Clear();
                    dtIndenSuperDetail.Clear();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                dgIndenDetail.DataSource = dtIndenDetail.DefaultView;
                dgIndenSubDetail.DataSource = dtIndenSubDetail.DefaultView;
                dgIndenSuperDetail.DataSource = dtIndenSuperDetail.DefaultView;
            }
        }

        public void IndenSubDetailRefresh()
        {
            _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtIndenSubDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenSubDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDID));
                    dtIndenSubDetail = db.Commands[0].ExecuteDataTable();
                }


                if (dtIndenSubDetail.Rows.Count > 0)
                {
                    dtIndenSubDetail.DefaultView.Sort = "RecordID";
                    dgIndenSubDetail.DataSource = dtIndenSubDetail.DefaultView;
                    //IndenSuperDetailRefresh();

                }
                else
                {

                    dtIndenSuperDetail.Clear();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;

                dgIndenSubDetail.DataSource = dtIndenSubDetail.DefaultView;
                dgIndenSuperDetail.DataSource = dtIndenSuperDetail.DefaultView;

            }
        }

        public void IndenSuperDetailRefresh()
        {
            _RowIDISD = (Guid)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RowIDISD"].Value;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtIndenSuperDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDISD));
                    dtIndenSuperDetail = db.Commands[0].ExecuteDataTable();
                }


                
                    dtIndenSuperDetail.DefaultView.Sort = "RecordID";
                    dgIndenSuperDetail.DataSource = dtIndenSuperDetail.DefaultView;

                
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

        public void IndenFindRow(string column, string value)
        {
            dgInden.FindRow(column, value);
            IndenDetailRefresh();
            dgInden.Focus();
            selectMode = enumSelectMode.Inden;
        }

        public void IndenDetailFindRow(string column, string value)
        {
            dgIndenDetail.FindRow(column, value);
            IndenSubDetailRefresh();
            dgIndenDetail.Focus();
            selectMode = enumSelectMode.IndenDetail;
        }

        public void IndenSubDetailFindRow(string column, string value)
        {
            dgIndenSubDetail.FindRow(column, value);
            IndenSuperDetailRefresh();
            dgIndenSubDetail.Focus();
            selectMode = enumSelectMode.IndenSubDetail;
        }

        public void IndenSuperDetailFindRow(string column, string value)
        {
            dgIndenSuperDetail.FindRow(column, value);
            dgIndenSuperDetail.Focus();
            selectMode = enumSelectMode.IndenSuperDetail;
        }

        public void IndenRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                dtResult = Inden.ListRowInden(db, RowID);
            }
            dgInden.RefreshDataRow(dtResult.Rows[0],"RowID",RowID.ToString());
        }

        public void IndenDetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                dtResult = Inden.ListRowIndenDetail(db, RowID);
            }
            dgIndenDetail.RefreshDataRow(dtResult.Rows[0],"RowID",RowID.ToString());
            

        }

        public void IndenSubDetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                dtResult = Inden.ListRowIndenSubDetail(db, RowID);
            }
            dgIndenSubDetail.RefreshDataRow(dtResult.Rows[0],"RowID",RowID.ToString());
        }

        public void IndenSuperDetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                dtResult = Inden.ListRowIndenSuperDetail(db, RowID);
            }
            dgIndenSuperDetail.RefreshDataRow(dtResult.Rows[0],"RowID",RowID.ToString());
        }
        
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Inden)
            {
                frmIndenUpdate frm = new frmIndenUpdate(this);
                frm.ShowDialog();
            }
            else if (selectMode == enumSelectMode.IndenDetail)
            {
                try
                {

                    DateTime _Tanggal = (DateTime)dgInden.SelectedCells[0].OwningRow.Cells["TglKasir"].Value;
                    if (_Tanggal.Date != GlobalVar.DateOfServer.Date)
                    {
                        KotakPesan.Warning("Tanggal kasir tidak sama dengan tanggal server. Tidak bisa isi data. Silahkan input transaksi baru dengan tanggal Kasir hari ini.");
                        return;
                    }
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    String _RecordIDI = dgInden.SelectedCells[0].OwningRow.Cells["RecordIDI"].Value.ToString();
                    String _namaCollector = dgInden.SelectedCells[0].OwningRow.Cells["NamaCollector"].Value.ToString();
                    DateTime _tglInden = (DateTime)dgInden.SelectedCells[0].OwningRow.Cells["TglKasir"].Value;
                    string _noBukti = dgInden.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                    string _collectorID = dgInden.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();
                    frmIndenDetailUpdate frm = new frmIndenDetailUpdate(this, _RowIDI, _RecordIDI, _namaCollector, _tglInden, _noBukti, _collectorID);
                    frm.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (selectMode == enumSelectMode.IndenSubDetail)
            {

                if (dgIndenDetail.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)dgInden.SelectedCells[0].OwningRow.Cells["TglKasir"].Value;
                    if (!SecurityManager.IsManager())
                    {
                        if ((DateTime.Today - _Tanggal).Days > 3)
                        {
                            MessageBox.Show("Sudah lebih dari 3 hari dari Identiikasi kasir, hubungi manager.");
                            return;
                        }
                    }
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                    _KodeCollector = dgInden.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();
                    string _RecordIDID = dgIndenDetail.SelectedCells[0].OwningRow.Cells["RecordIDID"].Value.ToString();
                    double teridentifikasi = 0;
                    string chbg = dgIndenDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString();
                    if(dtIndenSubDetail.Rows.Count>0)
                        teridentifikasi = Convert.ToDouble(dtIndenSubDetail.Compute("Sum(RpNominal)", string.Empty));
                    
                    if (chbg == " " || chbg == "")
                    {
                        teridentifikasi = Convert.ToDouble(dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpCashID"].Value.ToString()) - teridentifikasi;
                        chbg = "KAS";
                    }
                    else if (chbg == "T")
                    {
                        teridentifikasi = Convert.ToDouble(dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpTrfID"].Value.ToString()) - teridentifikasi;
                        chbg = "TRN";
                    }
                    else if (chbg == "C" || chbg == "G" || chbg == "S")
                    {
                        teridentifikasi = Convert.ToDouble(dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpGiroID"].Value.ToString()) - teridentifikasi;
                        chbg = "BGC";
                    }
                    else if (chbg == "R")
                    {
                        teridentifikasi = Convert.ToDouble(dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpCrdID"].Value.ToString()) - teridentifikasi;
                        chbg = "CRD";
                    }
                    else if (chbg == "D")
                    {
                        teridentifikasi = Convert.ToDouble(dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpDbtID"].Value.ToString()) - teridentifikasi;
                        chbg = "DBT";
                    }
                    if (teridentifikasi > 0)
                    {
                        frmIndenSubDetailUpdate frm = new frmIndenSubDetailUpdate(this, teridentifikasi, _RowIDID, _RowIDI, _RecordIDID, chbg, _Tanggal,_KodeCollector);
                        frm.ShowDialog(); 
                    }
                    
                }

            }
            else
            {
                if (dgIndenSubDetail.SelectedCells.Count > 0)
                {
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                    _RowIDISD = (Guid)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RowIDISD"].Value;
                    string kodeToko = dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    string noReg = dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["NoReg"].Value.ToString();
                    string chbg = dgIndenDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString();
                    string noBukti=dgInden.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                    string noBPP=dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["NoBPP"].Value.ToString();
                    string noACC=dgIndenDetail.SelectedCells[0].OwningRow.Cells["NoAccID"].Value.ToString();
                    string noGiro=dgIndenDetail.SelectedCells[0].OwningRow.Cells["Nomor"].Value.ToString();   
                    string namaBank=dgIndenDetail.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString();
                    string RpInden = (Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RpNominal"].Value) - Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value)).ToString();
                    string hRecordID = dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RecordIDISD"].Value.ToString();
                    string totalNominal = "0";
                    DateTime tglBPP = (DateTime)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["TglBPP"].Value;
                    DataTable dtNota = dtIndenSuperDetail.Copy();
                    DateTime tglJTGiro=(DateTime)SqlDateTime.Null;

                    if (chbg == " " || chbg == "")
                    {
                        chbg = "KAS";
                        tglJTGiro = (DateTime)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["TglBPP"].Value;
                        totalNominal = String.Format("{0:0}",dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpCashID"].Value);
                    }
                    else if (chbg == "T")
                    {
                        chbg = "TRN";
                        tglJTGiro = (DateTime)dgIndenDetail.SelectedCells[0].OwningRow.Cells["TglTrf"].Value;
                        totalNominal = String.Format("{0:0}",dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpTrfID"].Value);
                    }
                    else if (chbg == "C" || chbg == "G" || chbg == "S")
                    {
                        chbg = "BGC";
                        tglJTGiro = (DateTime)dgIndenDetail.SelectedCells[0].OwningRow.Cells["TglJT"].Value;
                        totalNominal = String.Format("{0:0}",dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpGiroID"].Value);
                    }
                    else if (chbg == "R")
                    {
                        chbg = "CRD";
                        tglJTGiro = (DateTime)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["TglBPP"].Value;
                        totalNominal = String.Format("{0:0}",dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpCrdID"].Value);
                    }
                    else if (chbg == "D")
                    {
                        chbg = "DBT";
                        tglJTGiro = (DateTime)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["TglBPP"].Value;
                        totalNominal = String.Format("{0:0}",dgIndenDetail.SelectedCells[0].OwningRow.Cells["RpDbtID"].Value);
                    }

                    if (RpInden != "0")
                    {
                        frmIndenSuperDetailUpdate frm = new frmIndenSuperDetailUpdate(this,dtNota, kodeToko, noReg, _RowIDI, _RowIDID, _RowIDISD, tglJTGiro, chbg, noBukti, noBPP, noGiro, noACC, namaBank, RpInden, hRecordID, totalNominal, tglBPP);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Inden)
            {
                _RowIDI= (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                frmIndenUpdate frm = new frmIndenUpdate(this,_RowIDI,dtInden);
                frm.ShowDialog();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Inden)
            {
                if (dtIndenDetail.Rows.Count > 0)
                {
                    MessageBox.Show("Tidak bisa delete data Inden, \n Masih ada data Inden detail.");
                    return;
                }

                if (dgInden.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Controls.Messages.Error.RowNotSelected);
                    return;
                }

                DateTime _Tanggal = (DateTime)dgInden.SelectedCells[0].OwningRow.Cells["TglKasir"].Value;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                           DeleteData(db, "usp_Inden_DELETE", _RowIDI, "@RowID");
                        }
                    }
                    catch (SqlException exs)
                    {
                        Error.LogError(exs);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    #region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = dgInden.SelectedCells[0].RowIndex;
                    n = dgInden.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgInden.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtInden.AcceptChanges();
                    dgInden.Focus();
                    dgInden.RefreshEdit();
                    if (dgInden.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgInden.CurrentCell = dgInden.Rows[0].Cells[n];
                            dgInden.RefreshEdit();
                        }
                        else
                        {
                            dgInden.CurrentCell = dgInden.Rows[i - 1].Cells[n];
                            dgInden.RefreshEdit();
                        }

                    }
                    #endregion
                }
            }
            else if (selectMode == enumSelectMode.IndenDetail)
            {
                if (dtIndenSubDetail.Rows.Count > 0)
                {
                    MessageBox.Show("Tidak bisa delete data Inden detail, \n Masih ada data Inden subdetail");
                    return;
                }

                if (dgIndenDetail.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Controls.Messages.Error.RowNotSelected);
                    return;
                }
                DateTime _Tanggal = (DateTime)dgInden.SelectedCells[0].OwningRow.Cells["TglKasir"].Value;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                    string chbg = dgIndenDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString();
                    DataTable dtCekHeader;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.BeginTransaction();
                            

                            if (chbg == " " || chbg == "")
                            {
                                dtCekHeader = new DataTable();
                                //cek detail yang headeridnya sama, jika hanya ada 1 detail, maka hapus header
                                dtCekHeader = Inden.CekRelasiInden("BuktiDetail", "HeaderID", _RowIDI.ToString(), "", "");
                                //delete detail
                                DeleteData(db, "usp_BuktiDetail_DELETE", _RowIDID, "@RowID");
                                //delete header
                                if(dtCekHeader.Rows.Count<=1)
                                    DeleteData(db, "usp_Bukti_DELETE", _RowIDI, "@RowID");
                            }
                            else if (chbg == "T")
                            {
                                //cek detail yang headeridnya sama, jika hanya ada 1 detail, maka hapus header
                                dtCekHeader = Inden.CekRelasiInden("TransferBankDetail", "HeaderID", _RowIDI.ToString(), "", "");
                                //delete detail
                                DeleteData(db, "usp_TransferBankDetail_DELETE", _RowIDID, "@RowID");
                                //delete header
                                if (dtCekHeader.Rows.Count<=1)
                                    DeleteData(db, "usp_TransferBank_DELETE", _RowIDI, "@RowID");

                                //delete bankdetail
                                Guid rowIDBank = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDBankTujuan"].Value;

                                Bank.DeleteBankDetail(db, _RowIDID, rowIDBank, Guid.Empty, "000", "");
                            }
                            else if (chbg == "R" || chbg == "D")
                            {
                                DataTable dtGiro = new DataTable();
                                dtGiro = Giro.CekGiro_Voucher_Titip(_RowIDID);

                                DeleteData(db, "usp_Giro_DELETE", _RowIDID, "@GiroID");

                                //JIKA TIDAK ADA GIRO YANG MEMILIKI VOUCHERID YG SAMA, VOUCHERJOURNAL DI HAPUS
                                if ((int)dtGiro.Rows[0]["JumlahV"] == 1)
                                    DeleteData(db, "usp_VoucherJournal_DELETE", (Guid)dtGiro.Rows[0]["VoucherID"], "@RowID");


                                //JIKA TIDAK ADA GIRO YANG MEMILIKI TITIPID YG SAMA, VOUCHERJOURNAL DI HAPUS
                                if ((int)dtGiro.Rows[0]["JumlahT"] == 1)
                                    DeleteData(db, "usp_VoucherJournal_DELETE", (Guid)dtGiro.Rows[0]["TitipID"], "@RowID");

                            }
                            else
                            {
                                DataTable dtGiro = new DataTable();
                                dtGiro = Giro.CekGiro_Voucher_Titip(_RowIDID);

                                DeleteData(db, "usp_Giro_DELETE", _RowIDID, "@GiroID");

                                //JIKA TIDAK ADA GIRO YANG MEMILIKI VOUCHERID YG SAMA, VOUCHERJOURNAL DI HAPUS
                                if ((int)dtGiro.Rows[0]["JumlahV"] == 1)
                                    DeleteData(db, "usp_VoucherJournal_DELETE", (Guid)dtGiro.Rows[0]["VoucherID"], "@RowID");
                            }

                            DeleteData(db, "usp_IndenDetail_DELETE", _RowIDID, "@RowID");
                            db.CommitTransaction();
                        }

                        IndenRowRefresh(_RowIDI);
                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = dgIndenDetail.SelectedCells[0].RowIndex;
                        n = dgIndenDetail.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dgIndenDetail.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        dtIndenDetail.AcceptChanges();
                        dgIndenDetail.Focus();
                        dgIndenDetail.RefreshEdit();
                        if (dgIndenDetail.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dgIndenDetail.CurrentCell = dgIndenDetail.Rows[0].Cells[n];
                                dgIndenDetail.RefreshEdit();
                            }
                            else
                            {
                                dgIndenDetail.CurrentCell = dgIndenDetail.Rows[i - 1].Cells[n];
                                dgIndenDetail.RefreshEdit();
                            }

                        }
                        #endregion
                    }
                    catch (SqlException exs)
                    {
                        Error.LogError(exs);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else if (selectMode == enumSelectMode.IndenSubDetail)
            {
                if (dtIndenSuperDetail.Rows.Count > 0)
                {
                    MessageBox.Show("Tidak bisa delete data Inden subdetail, \n Masih ada data Inden superdetail.");
                    return;
                }

                if (dgIndenSubDetail.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Controls.Messages.Error.RowNotSelected);
                    return;
                }

                DateTime _Tanggal = (DateTime)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["TglKasirISD"].Value;
                if (PeriodeClosing.IsPJTClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                    _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                    _RowIDISD = (Guid)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RowIDISD"].Value;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            DeleteData(db, "usp_IndenSubDetail_DELETE", _RowIDISD, "@RowID");
                        }

                        IndenRowRefresh(_RowIDI);
                        IndenDetailRowRefresh(_RowIDID);
                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = dgIndenSubDetail.SelectedCells[0].RowIndex;
                        n = dgIndenSubDetail.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dgIndenSubDetail.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        dtIndenSubDetail.AcceptChanges();
                        dgIndenSubDetail.Focus();
                        dgIndenSubDetail.RefreshEdit();
                        if (dgIndenSubDetail.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dgIndenSubDetail.CurrentCell = dgIndenSubDetail.Rows[0].Cells[n];
                                dgIndenSubDetail.RefreshEdit();
                            }
                            else
                            {
                                dgIndenSubDetail.CurrentCell = dgIndenSubDetail.Rows[i - 1].Cells[n];
                                dgIndenSubDetail.RefreshEdit();
                            }

                        }
                        #endregion
                    }
                    catch (SqlException exs)
                    {
                        Error.LogError(exs);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                if (dgIndenSuperDetail.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Controls.Messages.Error.RowNotSelected);
                    return;
                }
                DateTime _Tanggal = (DateTime)dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["TglInden"].Value;
                if (PeriodeClosing.IsPJTClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                _RowIDISD = (Guid)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RowIDISD"].Value;
                _RowIDISPD = (Guid)dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["RowIDISSD"].Value;
                if (Journal.CekInden(_RowIDISPD).Rows.Count > 0)
                {
                    MessageBox.Show("Tidak boleh delete, sudah link GL.");
                    return;
                }
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    
                    string _RefISSD = dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["RefISSD"].Value.ToString();
                    string cairtolak = "";
                    try
                    {
                        //SELAIN CASH DAN TRANSFER HARUS CEK CAIRTOLAK GIRO
                        if (_RefISSD != "KAS" && _RefISSD != "TRN")
                        {
                            cairtolak = Giro.CekGiro_CairTolak(_RowIDID);

                            if (cairtolak != "" && cairtolak != " ")
                            {
                                MessageBox.Show("Giro sudah sampai tahap cair/tolak, tidak boleh hapus inden super detail!");
                                return;
                            }
                        }

                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.BeginTransaction();
                            //delete kpd
                            DeleteData(db, "usp_KartuPiutangDetail_DELETE", _RowIDISPD, "@RowID");
                            //delete girotolakdetail
                            DeleteData(db, "usp_GiroTolakDetail_DELETE", _RowIDISPD, "@RowID");
                            //delete tagihansubdetail
                            DeleteData(db, "usp_TagihanSubDetail_DELETE", _RowIDISPD, "@RowID");
                            //UPDATE TAGIHANDETAIL ??

                            //delete indensuperdetail
                            DeleteData(db, "usp_IndenSuperDetail_DELETE", _RowIDISPD, "@RowID");
                            db.CommitTransaction();
                        }

                        IndenRowRefresh(_RowIDI);
                        IndenDetailRowRefresh(_RowIDID);
                        IndenSubDetailRowRefresh(_RowIDISD);
                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = dgIndenSuperDetail.SelectedCells[0].RowIndex;
                        n = dgIndenSuperDetail.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dgIndenSuperDetail.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        dtIndenSuperDetail.AcceptChanges();
                        dgIndenSuperDetail.Focus();
                        dgIndenSuperDetail.RefreshEdit();
                        if (dgIndenSuperDetail.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dgIndenSuperDetail.CurrentCell = dgIndenSuperDetail.Rows[0].Cells[n];
                                dgIndenSuperDetail.RefreshEdit();
                            }
                            else
                            {
                                dgIndenSuperDetail.CurrentCell = dgIndenSuperDetail.Rows[i - 1].Cells[n];
                                dgIndenSuperDetail.RefreshEdit();
                            }

                        }
                        #endregion
                    }
                    catch (SqlException exs)
                    {
                        Error.LogError(exs);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void DeleteData(Database db, string namaSP, Guid RowID, string namaParameter)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand(namaSP));
            db.Commands[0].Parameters.Add(new Parameter(namaParameter, SqlDbType.UniqueIdentifier, RowID));
            
            db.Commands[0].ExecuteNonQuery();
        }

        private void cmdDetailPiutang_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.IndenSuperDetail)
            {
                
                if (dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["KPID"].Value.ToString() != "")
                {
                    Guid kpid = (Guid)dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["KPID"].Value;
                    string kprecid = dgIndenSuperDetail.SelectedCells[0].OwningRow.Cells["KPrecID"].Value.ToString() ;
                    try
                    {
                        DataTable dtDetailPiut = new DataTable();
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, kpid));
                            dtDetailPiut = db.Commands[0].ExecuteDataTable();
                        }

                        frmIndenDetailPiutangBrowse frm = new frmIndenDetailPiutangBrowse(this, dtDetailPiut);
                        frm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void cmdCetakBukti_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Inden)
            {
                int cprint = 0, gprint = 0, tprint = 0, rprint=0, dprint=0;
                int c = 0, g = 0, t = 0, r = 0, d = 0;
                
                if (dgInden.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Controls.Messages.Error.RowNotSelected);
                    return;
                }

                if (dtIndenDetail.Rows.Count == 0)
                    return;


                _RowIDI = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                DataTable dtCetak, dtCash, dtTrn, dtGiro, dtCrd, dtDbt;
                try
                {
                    dtCetak = new DataTable();
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakBuktiInden"));
                        db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, _RowIDI));
                        dtCetak = db.Commands[0].ExecuteDataTable();
                    }


                    foreach (DataRow dr in dtCetak.Rows)
                    {
                        if (dr["chbg"].ToString() == " ")
                        {
                            cprint = (int)dr["nprint"];
                            c++;
                        }
                        else if (dr["chbg"].ToString() == "T")
                        {
                            tprint = (int)dr["nprint"];
                            t++;
                        }
                        else if (dr["chbg"].ToString() == "R")
                        {
                            rprint = (int)dr["nprint"];
                            r++;
                        }
                        else if (dr["chbg"].ToString() == "D")
                        {
                            dprint = (int)dr["nprint"];
                            d++;
                        }
                        else
                        {
                            gprint = (int)dr["nprint"];
                            g++;
                        }
                    }



                    if (c > 0)
                    {
                        dtCash = new DataTable();
                        dtCash = dtCetak.Copy();
                        dtCash.DefaultView.RowFilter = "chbg=' '";
                        if (cprint > 0) 
                        {
                            if (SecurityManager.IsManager() || SecurityManager.AskPasswordManager() == true)
                            {
                               cetakBKM(dtCash.DefaultView.ToTable());
                            }
                        }
                        else
                        {
                             cetakBKM(dtCash.DefaultView.ToTable());
                        }
                    }

                    if (t > 0)
                    {
                        dtTrn = new DataTable();
                        dtTrn = dtCetak.Copy();
                        dtTrn.DefaultView.RowFilter = "chbg='T'";
                        if (tprint > 0)
                        {
                            if (SecurityManager.IsManager() || SecurityManager.AskPasswordManager() == true)
                            {
                                cetakTrn(dtTrn.DefaultView.ToTable());
                            }
                        }
                        else
                        {
                            cetakTrn(dtTrn.DefaultView.ToTable());
                        }
                    }

                    if (r > 0)
                    {
                        dtCrd = new DataTable();
                        dtCrd = dtCetak.Copy();
                        dtCrd.DefaultView.RowFilter = "chbg='R'";
                        if (rprint > 0)
                        {
                            if (SecurityManager.IsManager() || SecurityManager.AskPasswordManager() == true)
                            {
                                //update nprint, cetak
                            }
                        }
                        else
                        {
                            //update nprint, cetak
                        }
                    }
                    if (d > 0)
                    {
                        dtDbt = new DataTable();
                        dtDbt = dtCetak.Copy();
                        dtDbt.DefaultView.RowFilter = "chbg='D'";
                        if (dprint > 0)
                        {
                            if (SecurityManager.IsManager() || SecurityManager.AskPasswordManager() == true)
                            {
                                //update nprint, cetak
                            }
                        }
                        else
                        {
                            //update nprint, cetak
                        }
                    }
                    if (g > 0)
                    {
                        dtGiro = new DataTable();
                        dtGiro = dtCetak.Copy();
                        dtGiro.DefaultView.RowFilter = "chbg IN ('G','C','S')";
                        if (gprint > 0)
                        {
                            if (SecurityManager.IsManager() || SecurityManager.AskPasswordManager() == true)
                            {
                                cetakGiro(dtGiro.DefaultView.ToTable());
                            }
                        }
                        else
                        {
                            cetakGiro(dtGiro.DefaultView.ToTable());
                        }
                    }


                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        #region CETAK CASH
        private void cetakBKM(DataTable dtBKM)
        { 
            int i=0;
            double total=0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan;

            Guid _RowID = (Guid)dtBKM.Rows[0]["RowID"];
            _Terima = dtBKM.Rows[0]["terima"].ToString();
            _NoBukti = dtBKM.Rows[0]["noHeader"].ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}",dtBKM.Rows[0]["tanggal"]);
            _Kasir = dtBKM.Rows[0]["kasir"].ToString();
            _mengetahui = dtBKM.Rows[0]["mengetahui"].ToString();
            _pembukuan = dtBKM.Rows[0]["pembukuan"].ToString();

            BuildString lap = new BuildString();
            lap.Initialize();

            lap.PageLLine(33);
            lap.LeftMargin(1);
            lap.FontCPI(12);
            lap.LineSpacing("1/6");
            lap.DoubleWidth(true);
            lap.PROW(true, 1, "[BUKTI KAS MASUK]");
            lap.DoubleWidth(false);

            lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Di Terima Dari : ".PadRight(41) +
                lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                _Tanggal).PadRight(30) + ("Hal : 1/1" ).PadRight(11) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(41) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                foreach (DataRow dr in dtBKM.Rows)
                {
                    jumlah = Convert.ToDouble(dr["nominal"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + dr["noDetail"].ToString().Trim().PadRight(10) + dr["uraian"].ToString().ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    total += Convert.ToDouble(dr["nominal"].ToString());
                    i++;
                }
                if (i < 10)
                {
                    for (int j = 0; j < 10 - i; j++)
                    {
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                    }
                }
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                    total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penerima") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Terima.Trim()) + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                lap.Eject();

                using (Database db = new Database("ISADBDepoFinance"))
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBukti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                lap.SendToPrinter("laporanPS.txt");
        }
        #endregion



        #region CETAK TRANSFER
        private void cetakTrn(DataTable dtTrn)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan;

            Guid _RowID = (Guid)dtTrn.Rows[0]["RowID"];
            _Terima = dtTrn.Rows[0]["terima"].ToString().Trim();
            _NoBukti = dtTrn.Rows[0]["noHeader"].ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}", dtTrn.Rows[0]["tanggal"]);
            _Kasir = dtTrn.Rows[0]["kasir"].ToString();
            _mengetahui = dtTrn.Rows[0]["mengetahui"].ToString();
            _pembukuan = dtTrn.Rows[0]["pembukuan"].ToString();

            BuildString lap = new BuildString();
            lap.Initialize();

            lap.PageLLine(33);
            lap.LeftMargin(1);
            lap.FontCPI(12);
            lap.LineSpacing("1/6");
            lap.DoubleWidth(true);

            lap.PROW(true, 1, "[Bukti Bank Masuk]");
            lap.DoubleWidth(false);


            lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Diterima Dari: ".PadRight(41) +
                lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41).Substring(0,41) + lap.PrintVerticalLine() + ("Tanggal : " +
                _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(41) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(10, "Nomor") + lap.PadCenter(20, "Asal Transfer") + lap.SPACE(1)
                + lap.PadCenter(11, "Bank") + lap.PadCenter(13, "Tgl. Bank") + lap.PadCenter(13, "Tgl. Trf")
                + lap.PadCenter(15, "Nilai Transfer") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

            foreach (DataRow dr in dtTrn.Rows)
            {
                jumlah = Convert.ToDouble(dr["nominal"].ToString());

                lap.PROW(true, 1, lap.PrintVerticalLine() + dr["noDetail"].ToString().Trim().PadRight(10) + dr["uraian"].ToString().Trim().ToUpper().PadRight(20).Substring(0, 20) + lap.SPACE(1)
                    + dr["bank"].ToString().PadRight(11).Substring(0, 11) + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["tgl1"]))
                    + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["tgl2"])) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());

                total += Convert.ToDouble(dr["nominal"].ToString());
                i++;
            }
            if (i < 10)
            {
                for (int j = 0; j < 10 - i; j++)
                {
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                }
            }
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penyetor") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _pembukuan) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _mengetahui)
                + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" +
                lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
            lap.PROW(true, 1, String.Format("{0:yyyyMMddhh:mm:ss}", DateTime.Now) + " " + SecurityManager.UserName);
            lap.Eject();
            using (Database db = new Database("ISADBDepoFinance"))
            {
                db.Commands.Add(db.CreateCommand("usp_TransferBank_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)dtTrn.Rows[0]["nprint"]+1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("laporanPS.txt");
        }
        #endregion



        #region CETAK GIRO
        private void cetakGiro(DataTable dtGiro)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan;

            Guid _RowID = (Guid)dtGiro.Rows[0]["RowID"];
            _Terima = dtGiro.Rows[0]["terima"].ToString().Trim();
            _NoBukti = dtGiro.Rows[0]["noHeader"].ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}",dtGiro.Rows[0]["tanggal"]);
            _Kasir = dtGiro.Rows[0]["kasir"].ToString();
            _mengetahui = dtGiro.Rows[0]["mengetahui"].ToString();
            _pembukuan = dtGiro.Rows[0]["pembukuan"].ToString();

            BuildString lap = new BuildString();
            lap.Initialize();

            lap.PageLLine(33);
            lap.LeftMargin(1);
            lap.FontCPI(12);
            lap.LineSpacing("1/6");
            lap.DoubleWidth(true);
            lap.PROW(true, 1, "[VOUCHER TERIMA PG]");
            lap.DoubleWidth(false);

            lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Di Terima Dari : ".PadRight(41) +
                lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41).Substring(0,41) + lap.PrintVerticalLine() + ("Tanggal : " +
                _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(41) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(3, "") + lap.PadCenter(8, "No. Giro") + lap.PadCenter(20, "Asal Giro") + lap.SPACE(1)
                + lap.PadCenter(10, "Bank Asal") + lap.PadCenter(13, "Tgl. Giro") + lap.PadCenter(13, "Tgl. J/Tempo")
                + lap.PadCenter(15, "Nilai Giro Rp") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

            foreach (DataRow dr in dtGiro.Rows)
            {
                jumlah = Convert.ToDouble(dr["nominal"].ToString());

                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(3, dtGiro.Rows[i]["CHBG"].ToString()) + dtGiro.Rows[i]["noDetail"].ToString().Trim().PadRight(8) + dtGiro.Rows[i]["uraian"].ToString().Trim().ToUpper().PadRight(20).Substring(0, 20)
                        + lap.SPACE(1) + dtGiro.Rows[i]["bank"].ToString().Trim().PadRight(10).Substring(0, 10) + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["tgl1"]))
                        + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["tgl2"])) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                total += Convert.ToDouble(dr["nominal"].ToString());
                i++;
            }
            if (i < 10)
            {
                for (int j = 0; j < 10 - i; j++)
                {
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                }
            }
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

            lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penyetor") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _pembukuan.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _mengetahui.Trim())
                + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" +
                lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
            lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
            lap.Eject();

            using (Database db = new Database("ISADBDepoFinance"))
            {
                db.Commands.Add(db.CreateCommand("usp_VoucherJournal_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)dtGiro.Rows[0]["nprint"] + 1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("laporanPS.txt");
        }
        #endregion

        private void dgIndenDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                string chbg = dgIndenDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString();
                if (chbg == "C" || chbg == "G" || chbg == "S")
                {
                    string cairtolak = Giro.CekGiro_CairTolak(_RowIDID);

                    if (cairtolak != "" && cairtolak != " ")
                    {
                        MessageBox.Show("Giro sudah sampai tahap cair/tolak, tidak boleh edit tanggal j.tempo!");
                        return;
                    }
                    DateTime _tglJT = (DateTime)dgIndenDetail.SelectedCells[0].OwningRow.Cells["TglJT"].Value;
                    _RowIDID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                    frmIndenDetail_UPDATE_TglJT ifrmchild = new frmIndenDetail_UPDATE_TglJT(this, _tglJT, _RowIDID);
                    ifrmchild.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cmdDelete_Click(sender, e);
            }
        }

        private void dgInden_SelectionChanged(object sender, EventArgs e)
        {
            if (dgInden.SelectedCells.Count > 0)
            {
                    IndenDetailRefresh();           
            }
        }

        private void dgIndenDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgIndenDetail.SelectedCells.Count > 0)
            {
                IndenSubDetailRefresh();
            }
        }

        private void dgIndenSubDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgIndenSubDetail.SelectedCells.Count > 0)
            {
                IndenSuperDetailRefresh();

                
            }
        }

        private void dgInden_Enter(object sender, EventArgs e)
        {
            selectMode = enumSelectMode.Inden;
            cmdEdit.Enabled = false;
            dgInden_SelectionChanged(sender, e);
            cmdCetakBukti.Enabled = true;
            cmdIdentNonNota.Enabled = false;
        }

        private void dgIndenDetail_Enter(object sender, EventArgs e)
        {
            dgIndenDetail.Focus();
            selectMode = enumSelectMode.IndenDetail;
            cmdEdit.Enabled = false;
            dgIndenDetail_SelectionChanged(sender, e);
            cmdCetakBukti.Enabled = false;
            cmdIdentNonNota.Enabled = false;
        }

        private void dgIndenSubDetail_Enter(object sender, EventArgs e)
        {
            dgIndenSubDetail.Focus();
            selectMode = enumSelectMode.IndenSubDetail;
            cmdEdit.Enabled = false;
            dgIndenSubDetail_SelectionChanged(sender, e);
            cmdCetakBukti.Enabled = false;
            cmdIdentNonNota.Enabled = false;
        }

        private void dgIndenSuperDetail_Enter(object sender, EventArgs e)
        {
            selectMode = enumSelectMode.IndenSuperDetail;
            cmdEdit.Enabled = false;
            cmdCetakBukti.Enabled = false;
            if (dgIndenSubDetail.Rows.Count > 0)
            {
                double nominalInden = Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RpNominal"].Value);
                double nominalBayar = Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value);
                if (nominalInden > nominalBayar)
                    cmdIdentNonNota.Enabled = true;
                else
                    cmdIdentNonNota.Enabled = false;
            }
        }

        private void dgInden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete_Click(sender, e);
            }
        }

        private void dgIndenSubDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete_Click(sender, e);
            }
        }

        private void dgIndenSuperDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete_Click(sender, e);
            }
        }

        private void dgIndenDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgIndenDetail.Rows.Count > 0)
            {
                int cash = 0, trf = 0, giro = 0, crd = 0, dbt = 0;
                cash = Convert.ToInt32(dgIndenDetail.Rows[e.RowIndex].Cells["sisaCash"].Value);
                trf = Convert.ToInt32(dgIndenDetail.Rows[e.RowIndex].Cells["sisaTrf"].Value);
                giro = Convert.ToInt32(dgIndenDetail.Rows[e.RowIndex].Cells["sisaGiro"].Value);
                crd = Convert.ToInt32(dgIndenDetail.Rows[e.RowIndex].Cells["sisaCrd"].Value);
                dbt = Convert.ToInt32(dgIndenDetail.Rows[e.RowIndex].Cells["sisaDbt"].Value);

                if (cash > 0 || trf > 0 || giro > 0 || crd > 0 || dbt > 0)
                {
                    for (int i = 0; i < 29; i++)
                    {
                        dgIndenDetail.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    for (int i = 0; i < 29; i++)
                    {
                        dgIndenDetail.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dgIndenSuperDetail_Leave(object sender, EventArgs e)
        {
            //cmdIdentNonNota.Enabled = false;
        }

        private void cmdIdentNonNota_Click(object sender, EventArgs e)
        {
            if (dgIndenSubDetail.Rows.Count > 0)
            {
                double nominalInden = Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RpNominal"].Value);
                double nominalBayar = Convert.ToDouble(dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value);
                double nominalSisa = nominalInden - nominalBayar;
                Guid _IndenSubDetailID = (Guid)dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RowIDISD"].Value;
                Guid _IndenDetailID = (Guid)dgIndenDetail.SelectedCells[0].OwningRow.Cells["RowIDID"].Value;
                Guid _IndenID = (Guid)dgInden.SelectedCells[0].OwningRow.Cells["RowIDI"].Value;
                string _IndenSubDetailRecID = dgIndenSubDetail.SelectedCells[0].OwningRow.Cells["RecordIDISD"].Value.ToString();
                string _chbg = dgIndenDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString();

                if (_chbg == " " || _chbg == "")
                {
                    _chbg = "KAS";
                }
                else if (_chbg == "T")
                {
                    _chbg = "TRN";
                }
                else if (_chbg == "C" || _chbg == "G" || _chbg == "S")
                {
                    _chbg = "BGC";
                }
                else if (_chbg == "R")
                {
                    _chbg = "CRD";
                }
                else if (_chbg == "D")
                {
                    _chbg = "DBT";
                }
                frmIndenSuperDetail_NonNota_UPDATE frm = new frmIndenSuperDetail_NonNota_UPDATE(this, _IndenSubDetailID, _IndenID, _IndenDetailID, _IndenSubDetailRecID, _chbg, nominalSisa);
                frm.ShowDialog();
            }
        }

        private void frmPenerimaanBelumTeridentifikasiBrowse_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
