using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Penjualan
{
    public partial class frmDOFilterBarangBrowser : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        bool _acak;
        string _format;
        DateTime _fromDate, _toDate;

        public frmDOFilterBarangBrowser(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate;
        }

        public frmDOFilterBarangBrowser(DateTime fromDate, DateTime toDate, Form caller)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate;
            this.Caller = caller;
        }


        private void frmDOFilterBarangBrowse_Load(object sender, EventArgs e)
        {
            this.Title = "Order Penjualan";
            this.Text = "Penjualan (DO), Periode " + _fromDate.ToShortDateString()
                        + " s/d " + _toDate.ToShortDateString();
            _acak = true;
            dataGridDO.AutoGenerateColumns = false;
            dataGridDetailDO.AutoGenerateColumns = false;
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
           
            RefreshDataDO();
        }

        public void RefreshDataDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDO = new DataTable();
                using (Database db = new Database())
                {

                    if (this.Caller is frmBOBrowser)
                    {
                        db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_LIST_BO_item]"));//udah cek heri
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_LIST]")); //udah cek heri
                    }
                   
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtDO = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                dtDO.Columns.Add(cNoDOAndFlag);
                dataGridDO.DataSource = dtDO;

                if (dataGridDO.SelectedCells.Count > 0)
                {
                    RefreshDataDetailDO();
                    dataGridDO.Focus();
                }
                else
                {
                    dataGridDetailDO.DataSource = null;
                    MessageBox.Show("Tidak ada transaksi dengan barang tersebut.....");
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

        public void RefreshDataDetailDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtDetailDO = new DataTable();
                    Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    if (this.Caller is frmBOBrowser)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID_BO_ITEM"));//cek by heri
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID")); // udah cek heri
                    }

                    
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();

                    dataGridDetailDO.DataSource = dtDetailDO;
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

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    dataGridDetailDO.Focus();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Enter:
                    if (this.Caller is frmBOBrowser)
                    {

                        if (dataGridDO.SelectedCells.Count > 0)
                            this.Close();
                    }
                    break;
            }
        }

        private void dataGridDetailDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    dataGridDO.Focus();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void dataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format currency
            if (!_acak)
                _format = "#,##0.00";
            else
                _format = "XXXXXX";

            dataGridDO.Rows[e.RowIndex].Cells["RpJual"].Style.Format = _format;
            dataGridDO.Rows[e.RowIndex].Cells["RpPot"].Style.Format = _format;
            dataGridDO.Rows[e.RowIndex].Cells["RpNet"].Style.Format = _format;
            dataGridDO.Rows[e.RowIndex].Cells["RpNet3"].Style.Format = _format;
        }

        private void dataGridDetailDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format currency
            string _format;
            if (!_acak)
                _format = "#,##0.00";
            else
                _format = "XXXXXX";

            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgBMK"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgJual"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHarga"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["Pot"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlPot"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgNet"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HPPSolo"].Style.Format = _format;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHPP"].Style.Format = _format;
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
            dataGridDO.Columns["RpJual"].DefaultCellStyle.Format = _format;
            dataGridDO.Columns["RpPot"].DefaultCellStyle.Format = _format;
            dataGridDO.Columns["RpNet"].DefaultCellStyle.Format = _format;
            dataGridDO.Columns["RpNet3"].DefaultCellStyle.Format = _format;

            dataGridDetailDO.Columns["HrgBMK"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["HrgJual"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["JmlHarga"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["Pot"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["JmlPot"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["HrgNet"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["HPPSolo"].DefaultCellStyle.Format = _format;
            dataGridDetailDO.Columns["JmlHPP"].DefaultCellStyle.Format = _format;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                    RefreshDataDetailDO();
            }
        }

        private void lookupStock_Load(object sender, EventArgs e)
        {

        }

        private void dataGridDO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Caller is frmBOBrowser)
            {

                if (dataGridDO.SelectedCells.Count > 0)
                    this.Close();
            }
        }

        private void frmDOFilterBarangBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is frmBOBrowser)
            {
                if (dataGridDO.SelectedCells.Count > 0)
                {
                    Guid rowId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[this.RowID.Name].Value;

                    Penjualan.frmBOBrowser frmCaller = (Penjualan.frmBOBrowser)this.Caller;
                    try
                    {
                        frmCaller.FindHeader("RowID", rowId.ToString());
                    }
                    catch { };
                }
            }
        }
    }
}
