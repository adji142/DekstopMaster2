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
    public partial class frmExpedisiBrowse : ISA.Toko.BaseForm
    {
        public frmExpedisiBrowse()
        {
            InitializeComponent();
        }

        private void frmExpedisiBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Expedisi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaExpedisi", SqlDbType.VarChar, txtSearch.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmExpedisiUpdate ifrmChild = new Master.frmExpedisiUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();  
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeExpedisi"].Value.ToString();
                Master.frmExpedisiUpdate ifrmChild = new Master.frmExpedisiUpdate(this, rowID);
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
            DeleteData();
        }


        private void DeleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeExpedisi"].Value.ToString();
                if (MessageBox.Show("Hapus kode expedisi: " + rowID + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Expedisi_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExpedisi", SqlDbType.VarChar, rowID));
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
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
