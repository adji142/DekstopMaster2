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
    public partial class frmRightsBrowse : ISA.Trading.BaseForm
    {
        public frmRightsBrowse()
        {
            InitializeComponent();
        }

        private void frmRightsBrowse_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_Rights_LIST"));
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
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.frmRightsUpdate  ifrmChild = new Master.frmRightsUpdate (this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rightID = dataGridView1.SelectedCells[0].OwningRow.Cells["RightID"].Value.ToString();
                Master.frmRightsUpdate ifrmChild = new Master.frmRightsUpdate(this, rightID);
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
                    string rightID = dataGridView1.SelectedCells[0].OwningRow.Cells["RightID"].Value.ToString();
                    using (Database db = new Database())
                    {
                        db.Open();

                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Rights_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, rightID));
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
