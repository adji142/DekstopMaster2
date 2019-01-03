using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Fixrute
{
    public partial class frmKunjunganSalesman : ISA.Trading.BaseForm
    {
        DataTable dtData, dtSearch;
        public frmKunjunganSalesman()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            int bln = DateTime.Now.Month;
            int thn = DateTime.Now.Year;
            DateTime D1 = new DateTime(thn, bln, 1);
            rdbTanggal.FromDate = D1;
            rdbTanggal.ToDate = GlobalVar.DateTimeOfServer;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SalesOrder_List"));
                dtData = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtData;
            }
        }

        public void Search()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SalesOrder_Search"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTanggal.ToDate));
                dtSearch = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtSearch;
            }
        }

        private void frmKunjunganSalesman_Load(object sender, EventArgs e)
        {
            int thn = GlobalVar.DateTimeOfServer.Year;
            int bln = GlobalVar.DateTimeOfServer.Month;
            DateTime D1 = new DateTime(thn, bln, 1);
            rdbTanggal.FromDate = D1;
            rdbTanggal.ToDate = GlobalVar.DateTimeOfServer;
            cmdSearch.PerformClick();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Fixrute.frmKunjunganSalesmanUpdate ifrmChild = new frmKunjunganSalesmanUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid _row = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //string _sales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            Fixrute.frmKunjunganSalesmanUpdate ifrmChild = new frmKunjunganSalesmanUpdate(this, _row);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string NamaToko = customGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                if (MessageBox.Show("Hapus Data : " + NamaToko + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SalesOrder_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Data telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            hapusData();
            //RefreshData();
            Search();
        }

        public void FindHeader(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Fixrute.frmkunjungansalesdownload ifrmdialog = new Fixrute.frmkunjungansalesdownload();
            ifrmdialog.ShowDialog();
            if (ifrmdialog.DialogResult == DialogResult.OK) {
                DateTime start = ifrmdialog.startdate;
                DateTime end = ifrmdialog.Enddate;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_gethasilkunjungansalesSF"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglAwal", SqlDbType.Date, start));
                    db.Commands[0].Parameters.Add(new Parameter("@tglAkhir", SqlDbType.Date, end));
                    db.Commands[0].ExecuteDataSet();
                }
                cmdSearch.PerformClick();
            }
        }
    }
}
