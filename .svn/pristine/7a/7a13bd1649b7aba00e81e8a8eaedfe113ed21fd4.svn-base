using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmVoucherGiroMasukBrowse : ISA.Finance.BaseForm
    {
        DataTable dtHeader, dtDetail;
        public frmVoucherGiroMasukBrowse()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

        }

        private void HeaderRefresh()
        {
            try
            {
                dtHeader = new DataTable();
                DataTable dtPG = new DataTable();
                DataTable dtCC = new DataTable();
                DataTable dtDB = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtPG = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "PG");
                    dtCC = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "CC");
                    dtDB = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "DB");
                }
                dtHeader = dtPG;
                dtHeader.Merge(dtCC);
                dtHeader.Merge(dtDB);
                if (dtHeader.Rows.Count > 0)
                {
                    dtHeader.DefaultView.Sort = "TglVoucher";
                    gridHeader.DataSource = dtHeader.DefaultView.ToTable();
                    DetailRefresh();
                    gridHeader.Focus();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DetailRefresh()
        {
            Guid RowIDHeader=(Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            try
            {
                dtDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtDetail = Giro.ListByVoucherID(db, RowIDHeader);
                }

                if (dtHeader.Rows.Count > 0)
                {
                    dtDetail.DefaultView.Sort = "GiroRecID";
                    gridDetail.DataSource = dtDetail.DefaultView.ToTable();
                    //gridDetail.Focus();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void frmVoucherGiroMasukBrowse_Load(object sender, EventArgs e)
        {
            //tbTanggal.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //tbTanggal.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            tbTanggal.FromDate = DateTime.Today;
            tbTanggal.ToDate = DateTime.Today;
            HeaderRefresh();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            HeaderRefresh();
        }

        private void gridHeader_Click(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
                DetailRefresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
