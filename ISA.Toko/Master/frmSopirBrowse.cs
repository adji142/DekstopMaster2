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
    public partial class frmSopirBrowse : ISA.Toko.BaseForm
    {
        public frmSopirBrowse()
        {
            InitializeComponent();
        }

        private void frmSopirBrowse_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_Sopir_List"));
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
            Master.frmSopirUpdate ifrmChild = new Master.frmSopirUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowid = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                Master.frmSopirUpdate ifrmChild = new Master.frmSopirUpdate(this, rowid);
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
                string rowid = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                string sopirKernet = dataGridView1.SelectedCells[0].OwningRow.Cells["sk"].Value.ToString();
                if (MessageBox.Show("Hapus sopir: " + rowid + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Sopir_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("Nama", SqlDbType.VarChar, rowid));
                            db.Commands[0].Parameters.Add(new Parameter("sk", SqlDbType.VarChar, sopirKernet));
                            dt = db.Commands[0].ExecuteDataTable();

                            db.Close();
                            db.Dispose();
                        }
                        MessageBox.Show("Data sudah dihapus.");
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
            {
                DeleteData();
            }
        } 

       

       

       
    }
}
