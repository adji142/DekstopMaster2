using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PSReport
{
    public partial class frmMasterTargetPerSales : ISA.Toko.BaseForm
    {
        DataTable dtSales, dtTargetSales;
        public frmMasterTargetPerSales()
        {
            InitializeComponent();
        }

        private void frmMasterTargetPerSales_Load(object sender, EventArgs e)
        {
            RefreshSales();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshSales()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));
                dtSales = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dtSales;
            if (dtSales.Rows.Count > 0 && customGridView1.SelectedCells.Count > 0)
            {
                string KodeSales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                RefreshTargetSales(KodeSales);

            }
        }

        public void RefreshTargetSales(string KodeSales)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TargetPersales_List"));
                db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, KodeSales));
                dtTargetSales = db.Commands[0].ExecuteDataTable();
            }
            customGridView2.DataSource = dtTargetSales;
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string KodeSales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                RefreshTargetSales(KodeSales);

            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string namaSales = customGridView1.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            string kodesales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            PSReport.frmMasterTargetPersalesUpdate ifrmChild = new frmMasterTargetPersalesUpdate(this,namaSales,kodesales);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            string namaSales = customGridView1.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            string kodesales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            Guid RowID = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
            PSReport.frmMasterTargetPersalesUpdate ifrmChild = new frmMasterTargetPersalesUpdate(this, namaSales, kodesales, RowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {
            Guid RowID_ = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
            if (MessageBox.Show("Record ini mau dihapus?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_TabelTargetPerSales_Delete"));
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            hapusData();
            string KodeSales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            RefreshTargetSales(KodeSales);
        }

        //private void customGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //}

    }
}
