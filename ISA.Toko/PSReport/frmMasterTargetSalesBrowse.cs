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
    public partial class frmMasterTargetSalesBrowse : ISA.Toko.BaseForm
    {
        DataTable dtTarget;
        public frmMasterTargetSalesBrowse()
        {
            InitializeComponent();
        }

        private void frmMasterTargetSalesBrowse_Load(object sender, EventArgs e)
        {
            RefreshTarget();
        }

        public void RefreshTarget()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TabelTargetSales_List"));
                dtTarget = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtTarget;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            PSReport.frmMasterTargetSalesUpdate ifrmChild = new frmMasterTargetSalesUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid _row = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            PSReport.frmMasterTargetSalesUpdate ifrmChild = new frmMasterTargetSalesUpdate(this, _row);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show("Record ini mau dihapus?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TabelTargetSales_Delete"));
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
            RefreshTarget();
        }
    }
}
