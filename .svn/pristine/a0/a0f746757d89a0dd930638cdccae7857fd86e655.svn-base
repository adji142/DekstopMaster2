using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Fixrute
{
    public partial class frmKunjunganSalesman : ISA.Toko.BaseForm
    {
        DataTable dtData, dtSearch;
        public frmKunjunganSalesman()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SalesOrder_List"));
                dtData = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtData;
            }
        }

        private void Search()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SalesOrder_Search"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtpTo.Value));
                dtSearch = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtSearch;
            }
        }

        private void frmKunjunganSalesman_Load(object sender, EventArgs e)
        {
            //RefreshData();
            Search();
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
    }
}
