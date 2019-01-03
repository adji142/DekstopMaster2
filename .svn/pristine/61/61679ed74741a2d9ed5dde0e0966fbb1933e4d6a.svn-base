using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Pembelian
{
    public partial class frmPembelianFilterBarangBrowser : ISA.Toko.BaseForm
    {
        DateTime _fromDate, _toDate;
        string _format;
        bool _acak = true;

        public frmPembelianFilterBarangBrowser(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate; 
            lblNamaBarang.Text = "";
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            lookupStock.Focus();
        }

        private void frmPembelian_FilterBarangBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Pembelian"; 
            this.Text = "Nota Pembelian (Barang diterima Gudang), Periode " + _fromDate.ToShortDateString()
                         + " s/d " + _toDate.ToShortDateString();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            lookupStock.Focus();
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            RefreshDataNotaBeli();
        }

        public void RefreshDataNotaBeli()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridDetail.DataSource = null;
                }
                else
                {
                    RefreshDataNotaBeliDetail();
                    dataGridHeader.Focus();
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

        public void RefreshDataNotaBeliDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridDetail.DataSource = dtDetail;
                }

                if (dtDetail.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                }
                else
                {
                    lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
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

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    dataGridDetail.Focus();
                    break;
            }
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    dataGridHeader.Focus();
                    break;
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format currency
            if (!_acak)
                _format = "#,##0.00";
            else
                _format = "XXXXXX";

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Style.Format = _format;
            dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Style.Format = _format;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format currency
            if (!_acak)
                _format = "#,##0.00";
            else
                _format = "XXXXXX";

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = _format;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeli"].Style.Format = _format;
            dataGridDetail.Rows[e.RowIndex].Cells["HPP"].Style.Format = _format;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPP"].Style.Format = _format;
        }

        private void AcakTampilHrg()
        {
            if (_acak)
            {
                _format = "#,##0.00";
                _acak = false;
            }
            else
            {
                _format = "XXXXXX";
                _acak = true;
            }

            dataGridHeader.Columns["RpBeli"].DefaultCellStyle.Format = _format;
            dataGridHeader.Columns["RpNet"].DefaultCellStyle.Format = _format;

            dataGridDetail.Columns["HrgBeli"].DefaultCellStyle.Format = _format;
            dataGridDetail.Columns["JmlHrgBeli"].DefaultCellStyle.Format = _format;
            dataGridDetail.Columns["HPP"].DefaultCellStyle.Format = _format;
            dataGridDetail.Columns["JmlHPP"].DefaultCellStyle.Format = _format;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataNotaBeliDetail();
            }
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblNamaBarang.Text = "";
            }
        }
    }
}
