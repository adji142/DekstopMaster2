using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Debug
{
    public partial class frmContoh : ISA.Trading.BaseForm
    {
        public frmContoh()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContoh_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        public void RefreshData()
        {
            customGridView1.AutoGenerateColumns = true;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));                
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Debug.frmContohEdit ifrmChild = new Debug.frmContohEdit(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
                Debug.frmContohEdit ifrmChild = new Debug.frmContohEdit(this,rowID);
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
            delete();
        }

        private void delete()
        {
            string rowId = customGridView1.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
            if (MessageBox.Show("Hapus Cabang ID " + rowId + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try 
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Cabang_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, rowId));
                        dt = db.Commands[0].ExecuteDataTable();

                    }

                    MessageBox.Show("Data Telah Dihapus");
                    this.RefreshData();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            Debug.frmRptContohToko ifrmChild = new Debug.frmRptContohToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
