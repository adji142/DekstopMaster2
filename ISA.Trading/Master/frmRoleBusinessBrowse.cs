using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmRoleBusinessBrowse : ISA.Trading.BaseForm
    {
        public frmRoleBusinessBrowse()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_RoleBusiness_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Error.LogError(ex);
            }
        }

        private void frmRoleBusinessBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.frmRoleBusinessUpdate  ifrmChild = new Master.frmRoleBusinessUpdate (this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string roleID = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleID"].Value.ToString();
                Master.frmRoleBusinessUpdate ifrmChild = new Master.frmRoleBusinessUpdate(this, roleID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string roleID = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleID"].Value.ToString();
                    using (Database db = new Database())
                    {
                        db.Open();

                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_RoleBusiness_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, roleID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    MessageBox.Show("Record telah dihapus");
                    this.RefreshData();
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
