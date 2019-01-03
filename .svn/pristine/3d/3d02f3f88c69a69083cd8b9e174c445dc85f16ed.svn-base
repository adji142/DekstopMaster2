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
    public partial class frmUserBrowse : ISA.Toko.BaseForm
    {
        public frmUserBrowse()
        {
            InitializeComponent();
        }

        private void frmUserBrowse_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_User_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Administrasi.frmUserUpdate ifrmChild = new Administrasi.frmUserUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["UserID"].Value.ToString();
            Administrasi.frmUserUpdate ifrmChild = new Administrasi.frmUserUpdate(this, rowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["UserID"].Value.ToString();
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_User_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, rowID));
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
