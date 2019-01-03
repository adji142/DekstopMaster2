using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.RJ3
{
    public partial class frmRJ3Browser : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        DataTable dtDetail, dtHeader;
        DateTime _fromDate, _toDate;
        bool _acak;


        public frmRJ3Browser()
        {
            InitializeComponent();
        }

        private void frmRJ3Browser_Load(object sender, EventArgs e)
        {
            _acak = true;
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _toDate = DateTime.Now;
            rgbTglGudang.FromDate = _fromDate;
            rgbTglGudang.ToDate = _toDate;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataReturJual();
        }

        private void rgbTglGudang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataReturJual()
        {
            _fromDate = (DateTime)rgbTglGudang.FromDate;
            _toDate = (DateTime)rgbTglGudang.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST_FILTER_TglGudang")); //HR, 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dtHeader.DefaultView.Sort = "NoNotaRetur";
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDataReturJualDetail();
                    lblStokDanToko.Text = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                }
                else
                {
                    dataGridDetail.DataSource = null;
                    RefreshLabel();
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

        public void RefreshDataReturJualDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid _headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //HR, 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cJmlHrg = new DataColumn("JmlHrg", Type.GetType("System.Double"));
                cJmlHrg.Expression = "QtyTerima * HrgJual";
                dtDetail.Columns.Add(cJmlHrg);
                dtDetail.DefaultView.Sort = "RecordID";
                dataGridDetail.DataSource = dtDetail;

                RefreshLabel();
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

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }*/

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        /*Tampilkan histori rur penjualan*/
                        RJ3.frmHistoryReturJualBrowser ifrmChild = new RJ3.frmHistoryReturJualBrowser(_fromDate, _toDate);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                }
            }
            else
            {
                if (dataGridHeader.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }

                switch (e.KeyCode)
                {                    
                    case Keys.Space:
                        /* Spacebar untuk proses RJ3 */
                        if (!SecurityManager.IsAuditor())
                        {
                            ProsesRJ3();
                        }
                        break;
                    case Keys.F12:
                        /* F12 untuk proses batal RJ3 */
                        BatalRJ3();
                        break;
                    case Keys.F9:
                        AcakTampilHrg();
                        break;
                }
            }
        }

        private void ProsesRJ3()
        {
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim() != "")
            {
                MessageBox.Show("Nota retur sudah dilink ke piutang...!");
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() == "")
            {
                MessageBox.Show("Belum buat nota retur");
                return;
            }

            // Proses RJ3
            if (dataGridDetail.DataSource != null && int.Parse(lblJmlQtyTerima.Text) == 0)
            {
                try
                {
                    if ((dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNotaRetur"].Value.ToString() == "") && (DateTime.Today <= GlobalVar.LastClosingDate))
                    {
                        throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    else if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNotaRetur"].Value.ToString() != "")
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNotaRetur"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNotaRetur"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                    }
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        for (int i = 0; i < dataGridDetail.RowCount; i++)
                        {
                            string kodeRetur = dataGridDetail.Rows[i].Cells["KodeRetur"].Value.ToString().Trim();

                            if (kodeRetur == "1")
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE"));//HR, 16032013
                                db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["NotaJualDetailID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtDetail.DefaultView[i]["ReturID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, dtDetail.DefaultView[i]["NotaJualDetailRecID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeRetur"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dtDetail.DefaultView[i]["QtyMemo"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                db.Commands[i].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                                /**/
                                db.Commands[i].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                                /**/
                                // Copy QtyGudang ke QtyTerima //
                                //db.Commands[i].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                //db.Commands[i].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTolak"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan1"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan2"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dtDetail.DefaultView[i]["Kategori"]));
                                //db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoACC"]));
                                db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            }
                            else
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanTarikanDetail_UPDATE")); //hr, 16032013
                                db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtDetail.DefaultView[i]["ReturID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaAsal", SqlDbType.VarChar, dtDetail.DefaultView[i]["NotaAsal"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeRetur"]));
                                db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeSales"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dtDetail.DefaultView[i]["QtyMemo"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                // Copy QtyGudang ke QtyTerima //
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTolak"]));
                                db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                                db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan1"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan2"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dtDetail.DefaultView[i]["Kategori"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoACC"]));
                                db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            }
                        }
                        // Hanya updated sync flag di header
                        int _nextIndex = db.Commands.Count;
                        int _headerIndex = dataGridHeader.SelectedCells[0].OwningRow.Index;
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_UPDATE")); //hr, 16032013
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtHeader.DefaultView[_headerIndex]["RowID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang2"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["ReturID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoMPR"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoNotaRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoTolak"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglMPR"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglNotaRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["KodeToko"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglTolak"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Pengambilan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglPengambilan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglGudang"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["BagPenjualan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Penerima"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["LinkID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtHeader.DefaultView[_headerIndex]["isClosed"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["NPrint"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglRQRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        for (int j = 0; j < db.Commands.Count; j++)
                        {
                            db.Commands[j].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    RefreshDataReturJualDetail();
                    Guid _headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                    RJ3.frmRJ3Update ifrmChild = new RJ3.frmRJ3Update(this, _headerID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show(); 
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            } // Isi qty terima selesai

                
        }

        private void BatalRJ3()
        {
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString() != "")
            {
                MessageBox.Show("Nota retur sudah dilink ke piutang...!");
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() == "")
            {
                MessageBox.Show("Belum buat nota retur");
                return;
            }

            // Proses batal RJ3
            if (dataGridDetail.DataSource != null && int.Parse(lblJmlQtyTerima.Text) != 0)
            {
                if (int.Parse(lblJmlQtyTerima.Text) == 0)
                {
                    MessageBox.Show("Belum pernah RJ3");
                    return;
                }
                try
                {


                    if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNotaRetur"].Value <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    this.Cursor = Cursors.WaitCursor;
                    int _jmlDetail = dataGridDetail.RowCount;
                    using (Database db = new Database())
                    {
                        for (int i = 0; i < _jmlDetail; i++)
                        {
                            Guid detailRowID = (Guid)dataGridDetail.Rows[i].Cells["DetailRowID"].Value;
                            string kodeRetur = dataGridDetail.Rows[i].Cells["KodeRetur"].Value.ToString();

                            if (kodeRetur == "1")
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE")); //heri 16032013
                                db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["NotaJualDetailID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtDetail.DefaultView[i]["ReturID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, dtDetail.DefaultView[i]["NotaJualDetailRecID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeRetur"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dtDetail.DefaultView[i]["QtyMemo"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                // QtyTerima di rubah 0 lagi //
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTolak"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan1"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan2"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dtDetail.DefaultView[i]["Kategori"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoACC"]));
                                db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            }
                            else
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanTarikanDetail_UPDATE"));//cek 16032013
                                db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtDetail.DefaultView[i]["ReturID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@notaAsal", SqlDbType.VarChar, dtDetail.DefaultView[i]["NotaAsal"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeRetur"]));
                                db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeSales"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dtDetail.DefaultView[i]["QtyMemo"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTarik"]));
                                // QtyTerima di rubah 0 lagi //
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dtDetail.DefaultView[i]["QtyGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dtDetail.DefaultView[i]["QtyTolak"]));
                                db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                                db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan1"]));
                                db.Commands[i].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan2"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dtDetail.DefaultView[i]["Kategori"]));
                                db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                                db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoACC"]));
                                db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            }
                        }
                        // Hanya updated sync flag di header
                        int _nextIndex = db.Commands.Count;
                        int _headerIndex = dataGridHeader.SelectedRows[0].Index;
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_UPDATE"));//cek 16032013
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtHeader.DefaultView[_headerIndex]["RowID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["ReturID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoMPR"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoNotaRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoTolak"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglMPR"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglNotaRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["KodeToko"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglTolak"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Pengambilan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglPengambilan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglGudang"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["BagPenjualan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Penerima"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["LinkID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtHeader.DefaultView[_headerIndex]["isClosed"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["NPrint"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglRQRetur"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        for (int j = 0; j < db.Commands.Count; j++)
                        {
                            db.Commands[j].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    RefreshDataReturJualDetail();
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

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F11:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        if (dataGridDetail.RowCount > 0)
                        {
                            string notaRecID = dataGridDetail.SelectedCells[0].OwningRow.Cells["ReturID"].Value.ToString();

                            if (Tools.Left(notaRecID, 3) != GlobalVar.PerusahaanID)
                            {
                                MessageBox.Show("Nota Dari Cabang Lain!!!" + System.Environment.NewLine + Tools.Left(notaRecID, 3));
                                return;
                            }

                            Guid _returDetailID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                            RJ3.frmKoreksiReturJualBrowser ifrmChild = new RJ3.frmKoreksiReturJualBrowser(this, _returDetailID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    break;
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            ProsesRJ3();
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                lblStokDanToko.Text = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
            }
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblStokDanToko.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridDetail.RowCount > 0)
            {
                if (dataGridDetail.Rows[e.RowIndex].Cells["KoreksiID"].Value.ToString()!="")
                {
                     for (int i = 0; i < dataGridDetail.ColumnCount; i++)
                    {
                    dataGridDetail.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Blue;
                    }
                }
               
            }
            dataGridDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlNettoAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Isi Acak
            double harga = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgJual"].Value.ToString());
            double jumlah = double.Parse(Tools.isNull(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrg"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridDetail.Rows[e.RowIndex].Cells["JmlNetto"].Value, 0).ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Value = Tools.GetAntiNumeric(jumlah.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlNettoAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));
        }

        private void AcakTampilHrg()
        {
            bool normal = true;

            dataGridDetail.Columns["HrgJual"].DefaultCellStyle.Format = "#,##0";
            dataGridDetail.Columns["JmlHrg"].DefaultCellStyle.Format = "#,##0";
            dataGridDetail.Columns["JmlNetto"].DefaultCellStyle.Format = "#,##0";

            normal = !_acak;
            dataGridDetail.Columns["HrgJual"].Visible = _acak;
            dataGridDetail.Columns["JmlHrg"].Visible = _acak;
            dataGridDetail.Columns["JmlNetto"].Visible = _acak;

            //acak
            dataGridDetail.Columns["HrgJualAck"].Visible = normal;
            dataGridDetail.Columns["JmlHrgAck"].Visible = normal;
            dataGridDetail.Columns["JmlNettoAck"].Visible = normal;
            _acak = normal;

            RefreshLabel();
        }

        public void RefreshLabel()
        {
            int _jmlQtyTerima = 0;
            double _jmlHrg = 0, _jmlNet = 0;

            if (dataGridDetail.RowCount > 0)
            {
                _jmlHrg = double.Parse(dtDetail.Compute("SUM(JmlHrg)", string.Empty).ToString());
                _jmlNet = double.Parse(dtDetail.Compute("SUM(HrgNetto)", string.Empty).ToString());
                _jmlQtyTerima = int.Parse(dtDetail.Compute("SUM(QtyTerima)", string.Empty).ToString());
            }

            lblJmlQtyTerima.Text = _jmlQtyTerima.ToString();

            if (_acak)
            {
                lblJmlHrgKotor.Text = Tools.GetAntiNumeric(_jmlHrg.ToString("#,##0"));
                lblJmlHrgBersih.Text = Tools.GetAntiNumeric(_jmlNet.ToString("#,##0")); 
            }
            else
            {
                lblJmlHrgKotor.Text = _jmlHrg.ToString("#,##0");
                lblJmlHrgBersih.Text = _jmlNet.ToString("#,##0");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                    lblStokDanToko.Text = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                    RefreshDataReturJualDetail();
            }
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblStokDanToko.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
        }
    }
}
