using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Penjualan
{
    public partial class frmNumeratorBrowse : ISA.Trading.BaseForm
    {
        public frmNumeratorBrowse()
        {
            InitializeComponent();
        }

        public void Refreshdata()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void frmNumeratorBrowse_Load(object sender, EventArgs e)
        {
            Refreshdata();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Penjualan.frmNumeratorUpdate   ifrmChild = new Penjualan.frmNumeratorUpdate (this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string doc = dataGridView1.SelectedCells[0].OwningRow.Cells["Doc"].Value.ToString();
                Penjualan.frmNumeratorUpdate  ifrmChild = new Penjualan.frmNumeratorUpdate (this, doc);
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
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["Doc"].Value.ToString();
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Numerator_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.Refreshdata();
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
