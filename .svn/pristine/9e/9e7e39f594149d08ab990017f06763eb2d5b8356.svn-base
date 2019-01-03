using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PJ3
{
    public partial class frmHistoryPenjualanBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        DateTime _fromDate, _toDate;

        public frmHistoryPenjualanBrowser(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate;
        }

        private void frmHistoryPenjualanBrowser_Load(object sender, EventArgs e)
        {
            dataGridNotaJual.AutoGenerateColumns = false;
            dataGridNotaJualDetail.AutoGenerateColumns = false;
            lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Extended;
            this.Text = "";
            this.Title = "History Penjualan";
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            RefreshDataNotaJual();
        }

        private void RefreshDataNotaJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_RiwayatJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridNotaJual.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    dataGridNotaJualDetail.DataSource = null;
                }
                else
                {
                    dataGridNotaJual.Focus();
                    RefreshDataNotaJualDetail();
                    lblStokDanToko.Text = dataGridNotaJual.Rows[0].Cells["NamaToko"].Value.ToString();                    
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
            Guid _headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridNotaJualDetail.DataSource = dt;
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

        private void dataGridNotaJual_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJual.SelectedCells.Count > 0)
            {
                    RefreshDataNotaJualDetail();
                    lblStokDanToko.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                
            }
            else
            {
                dataGridNotaJualDetail.DataSource = null;
                lblStokDanToko.Text = "";
            }
        }

        private void dataGridNotaJualDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJualDetail.SelectedCells.Count != 0)
            {
                lblStokDanToko.Text = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblStokDanToko.Text = "";
            }
        }
    }
}
