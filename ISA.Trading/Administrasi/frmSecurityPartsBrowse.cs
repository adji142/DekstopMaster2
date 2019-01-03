using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.Administrasi
{
    public partial class frmSecurityPartsBrowse : ISA.Trading.BaseForm
    {
        string _appID = "";

        public frmSecurityPartsBrowse(string appID)
        {
            InitializeComponent();
            _appID = appID;
            txtApplicationID.Text = appID;
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_SecurityParts_LIST"));
                    if (_appID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, _appID));
                    }
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {            
            Administrasi.frmSecurityPartsUpdate ifrmChild = new Administrasi.frmSecurityPartsUpdate(this, _appID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["PartID"].Value.ToString();
                Administrasi.frmSecurityPartsUpdate ifrmChild = new Administrasi.frmSecurityPartsUpdate(this, rowID, _appID);                
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
                    string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["PartID"].Value.ToString();
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityParts_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@partID", SqlDbType.VarChar, rowID));
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

        private void frmSecurityPartsBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                string rowID = dataGridView1.Rows[e.RowIndex].Cells["PartID"].Value.ToString();
                Administrasi.frmSecurityPartsRolesBrowse ifrmChild = new Administrasi.frmSecurityPartsRolesBrowse(rowID);
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
