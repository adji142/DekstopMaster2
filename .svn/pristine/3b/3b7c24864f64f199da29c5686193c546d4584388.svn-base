using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Trading;
using ISA.DAL;

namespace ISA.Trading.Administrasi
{
    public partial class frmSecurityRolesBrowse : ISA.Trading.BaseForm
    {
        public frmSecurityRolesBrowse()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_SecurityRoles_LIST"));
                    if (cboRoleType.Text != "All")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, cboRoleType.Text));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
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


        private void frmSecurityRolesBrowse_Load(object sender, EventArgs e)
        {
            if (cboRoleType.Items.Count > 0)
            {
                cboRoleType.SelectedIndex = 0;
            }
            dataGridView1.AutoGenerateColumns = false;
            RefreshData();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleID"].Value.ToString();
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityRoles_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@roleID", SqlDbType.VarChar, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleID"].Value.ToString();
                Administrasi.frmSecurityRolesUpdate ifrmChild = new Administrasi.frmSecurityRolesUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRolesUpdate ifrmChild = new Administrasi.frmSecurityRolesUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                string rowID = dataGridView1.Rows[e.RowIndex].Cells["RoleID"].Value.ToString();
                Administrasi.frmSecurityRolesUsersBrowse ifrmChild = new Administrasi.frmSecurityRolesUsersBrowse(rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
