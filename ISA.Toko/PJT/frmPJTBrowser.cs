using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PJT
{
    public partial class frmPJTBrowser : ISA.Toko.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        DataTable dtHeader, dtDetail;

        public frmPJTBrowser()
        {
            InitializeComponent();
        }

        private void frmPJTBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Penjualan Tunai";
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
            PJT.frmPJTUpdate ifrmChild2 = new PJT.frmPJTUpdate(this, rowID);
            ifrmChild2.ShowDialog();
            dataGridHeader.FindRow("RowID", rowID.ToString());
        }

        private void IsiQtyNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    // Proses memindahkan QtySJ ke QtyNota
                    for (int i = 0; i < dataGridDetail.RowCount; i++)
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

                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
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

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {            
            switch(e.KeyCode)
            {
                case Keys.Space:
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
                    LinkPJTKeAPI();
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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void cmdLinkAPI_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
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

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataNotaJualDetail();
            }
        }
    }
}
