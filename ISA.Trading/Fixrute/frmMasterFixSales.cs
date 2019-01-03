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
    public partial class frmMasterFixSales : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        public frmMasterFixSales()
        {
            InitializeComponent();
        }

        private void frmMasterFixSales_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        public void RefreshData()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixSales"));
                dt = db.Commands[0].ExecuteDataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["idrec"].ToString() == "L")
                    {
                        dt.Rows[i]["idrec"] = 1;
                    }
                    else
                    {
                        dt.Rows[i]["idrec"] = 0;
                    }
                }
                customGridView1.DataSource = dt;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Fixrute.frmMasterFixSalesUpdate ifrmChild = new Fixrute.frmMasterFixSalesUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
            //RefreshData();
        }

        public void FindRowHeader(Guid RowID)
        {
            //HeaderRowID = RowID;
      
            customGridView1.FindRow("RowID", RowID.ToString());
        }


        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Fixrute.frmMasterFixSalesUpdate ifrmChild = new frmMasterFixSalesUpdate(this, RowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
            //RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            hapusData();
            RefreshData();
        }

        public void hapusData()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string NamaSalaes = customGridView1.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
                if (MessageBox.Show("Hapus Data : " + NamaSalaes + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixSales_delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
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

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmdEdit.PerformClick();
            }
        }
    }
}
