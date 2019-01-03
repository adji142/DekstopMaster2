using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmUnitKerjaBrowser : ISA.Toko.BaseForm
    {
        public frmUnitKerjaBrowser()
        {
            InitializeComponent();
        }
                
        private void frmUnitKerjaBrowser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[usp_UnitKerja_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.frmUnitKerjaUpdate ifrmChild = new Master.frmUnitKerjaUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmUnitKerjaUpdate ifrmChild = new Master.frmUnitKerjaUpdate(this, rowID);
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
            DeleteData();   
        }

        private void DeleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                if (MessageBox.Show("Hapus " + rowID + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Guid _rowID = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_UnitKerja_INSERTUPDATEDELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@mau", SqlDbType.Int, 3));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                        }
                        MessageBox.Show("Record sudah dihapus.");
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            { DeleteData(); }
        } 
    }
}
