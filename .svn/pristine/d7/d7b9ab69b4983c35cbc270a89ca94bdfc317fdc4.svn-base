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
    public partial class frmHistoryReturJualBrowser : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        DateTime _fromDate, _toDate;

        public frmHistoryReturJualBrowser(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate;
        }

        private void frmHistoryReturJualBrowser_Load(object sender, EventArgs e)
        {
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            RefreshDataReturJual();
        }

        public void RefreshDataReturJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromTglGudang", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toTglGudang", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cCabang = new DataColumn("Cabang", Type.GetType("System.String"));
                cCabang.Expression = "Cabang1 + ' ' + Cabang2";
                dtHeader.Columns.Add(cCabang);
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    dataGridHeader.Focus();
                    RefreshDataReturJualDetail();
                    lblStokDanToko.Text = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                }
                else
                {
                    dataGridDetail.DataSource = null;
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
                DataTable dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cJmlHrg = new DataColumn("JmlHrg", Type.GetType("System.Double"));
                cJmlHrg.Expression = "QtyTerima * HrgJual";
                dtDetail.Columns.Add(cJmlHrg);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
