using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Administrasi
{
    public partial class frmSecurityRightsBrowse : ISA.Toko.BaseForm
    {
        public frmSecurityRightsBrowse()
        {
            InitializeComponent();
        }

        private void frmSecurityRightsBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_SecurityRights_LIST"));
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

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRightsUpdate ifrmChild = new Administrasi.frmSecurityRightsUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RightID"].Value.ToString();
                Administrasi.frmSecurityRightsUpdate ifrmChild = new Administrasi.frmSecurityRightsUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RightID"].Value.ToString();
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityRights_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rightID", SqlDbType.VarChar, rowID));
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
