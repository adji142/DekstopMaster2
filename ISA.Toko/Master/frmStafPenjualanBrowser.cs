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
    public partial class frmStafPenjualanBrowser : ISA.Toko.BaseForm
    {
        public frmStafPenjualanBrowser()
        {
            InitializeComponent();
        }
                
        private void frmStafPenjualanBrowser_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
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
            Master.frmStafPenjualanUpdate ifrmChild = new Master.frmStafPenjualanUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmStafPenjualanUpdate ifrmChild = new Master.frmStafPenjualanUpdate(this, rowID);
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
                Guid rowID =new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                if (MessageBox.Show("Hapus " + dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString() + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, rowID));
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
