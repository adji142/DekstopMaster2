using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance.Kasir
{
    public partial class frmPJTBrowser : ISA.Finance.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        DataTable dtHeader, dtDetail;

        public frmPJTBrowser()
        {
            InitializeComponent();
        }

        private void frmPJTBrowserISA_Load(object sender, EventArgs e)
        {
            this.Text = "PJT";
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglNota.FromDate = DateTime.Today;
            rgbTglNota.ToDate = DateTime.Today;
            RefreshDataNotaJual();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataNotaJual();
        }

        private void rgbTglNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataNotaJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_TglSuratJalan"));
                    //db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_TglSuratJalan2"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglNota.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDataNotaJualDetail();
                }
                else
                {
                    dataGridDetail.DataSource = null;
                }
                
                dataGridHeader.Focus();
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

        public void RefreshRowDataNotaJual(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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

        private void RefreshDataNotaJualDetail()
        {
            try
            {
                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dtDetail;

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

        private void LinkPJTKeAPI()
        {
            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Kasir.frmPJTUpdate ifrmChild2 = new Kasir.frmPJTUpdate(this, rowID);
            ifrmChild2.ShowDialog();
            dataGridHeader.FindRow("RowID", rowID.ToString());
        }

        private void IsiQtyNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                int i = 0;
                using (Database db = new Database())
                {
                    // Proses memindahkan QtySJ ke QtyNota
                    for (i = 0; i < dataGridDetail.RowCount; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE"));

                        db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetail.DefaultView[i]["HtrID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DOID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DODetailID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                        // Copy QtySJ ke QtyNota
                        db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc1"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc2"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc3"]));
                        db.Commands[i].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetail.DefaultView[i]["DiscFormula"]));
                        db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, dtDetail.DefaultView[i]["QtyKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAwal"]));
                        db.Commands[i].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAkhir"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["KetKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }
                    //update Nota Penjualan -> isi tglterima, edit transactiontype, edit harikirim=0
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_PJT_UPDATE"));
                    db.Commands[i].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));

                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                RefreshDataNotaJualDetail();
                RefreshRowDataNotaJual(headerID.ToString());
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

        private void BatalIsiQtyNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                int i = 0;
                using (Database db = new Database())
                {
                    // Proses memindahkan QtySJ ke QtyNota
                    for (i = 0; i < dataGridDetail.RowCount; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE"));

                        db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetail.DefaultView[i]["HtrID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DOID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DODetailID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                        // Copy QtySJ ke QtyNota
                        db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc1"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc2"]));
                        db.Commands[i].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc3"]));
                        db.Commands[i].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetail.DefaultView[i]["DiscFormula"]));
                        db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, dtDetail.DefaultView[i]["QtyKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAwal"]));
                        db.Commands[i].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAkhir"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["KetKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }
                    //update Nota Penjualan -> isi tglterima, edit transactiontype, edit harikirim=0
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_PJT_REUPDATE"));
                    db.Commands[i].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));

                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                RefreshDataNotaJualDetail();
                RefreshRowDataNotaJual(headerID.ToString());
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
        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataNotaJualDetail();
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {            
            switch(e.KeyCode)
            {
                case Keys.Space:
                    //if (SecurityManager.IsAOperator())
                    //{
                    //    MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                    //    return;
                    //}
                    //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim() != "")
                    //{
                    //    MessageBox.Show("Data Sudah di LINK..!!!", "WARNING");
                    //    return;
                    //}
                    //if (SecurityManager.IsAOperator())
                    //{
                    //    MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                    //    return;
                    //}
                    //LinkPJTKeAPI();
                    //cmdLinkAPI.PerformClick();
                    button1.PerformClick();
                    break;
                case Keys.F10:
                    if (SecurityManager.IsAOperator())
                    {
                        MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                        return;
                    }
                    if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim() != "")
                    {
                        MessageBox.Show("Data Sudah di LINK..!!!", "WARNING");
                        return;
                    }
                    if (SecurityManager.IsAOperator())
                    {
                        MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                        return;
                    }
                    IsiQtyNota();
                    break;
            }
        }

        


        private void cmdLinkAPI_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TunaiKredit"].Value.ToString().Trim() == "T")
                {
                    MessageBox.Show("Link Transaksi Tunai menggunakan menu PENJUALAN TUNAI kasir.");
                    return;
                }
                if (SecurityManager.IsAOperator())
                {
                    MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                    return;
                }
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim() != "")
                {
                    MessageBox.Show("Data Sudah di LINK..!!!", "WARNING");
                    return;
                }
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString().Trim() != GlobalVar.CabangID)
                {
                    MessageBox.Show("Link PJT Ke API hanya dapat dilakukan untuk nota cabang " + GlobalVar.CabangID);
                    return;
                }
                LinkPJTKeAPI();
            }
        }

        private void cmdIsiQtyNota_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                IsiQtyNota();
            }
        }

        private void cmdBatalQtyNota_Click(object sender, EventArgs e)
        {
            //link id harus masih kosong, d header
            // tglnota null, qtynota=0/

            //ga jadi... (-_-!)
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridHeader_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridHeader.Rows[e.RowIndex].Cells["LinkID"].Value.ToString() != "")
            {
                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TunaiKredit"].Value.ToString().Trim() != "T")
                {
                    MessageBox.Show("Hanya Transaksi Tunai yang bisa diLink mwnggunakan menu ini.");
                    return;
                }
                if (SecurityManager.IsAOperator())
                {
                    MessageBox.Show("HARUS LEVEL OPERATOR...", "WARNING");
                    return;
                }
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim() != "")
                {
                    MessageBox.Show("Data Sudah di LINK..!!!", "WARNING");
                    return;
                }
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString().Trim() != GlobalVar.Gudang)
                {
                    MessageBox.Show("Link PJT Ke API hanya dapat dilakukan untuk nota cabang " + GlobalVar.CabangID);
                    return;
                }
                LinkPJTKeAPI();
            }

        }
    }
}
