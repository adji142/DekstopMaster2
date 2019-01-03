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
    public partial class frmLookupBrowse : ISA.Toko.BaseForm
    {
        public frmLookupBrowse()
        {
            InitializeComponent();
        }

        private void frmLookUpBrowse_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
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
            Master.frmLookupUpdate ifrmChild = new Master.frmLookupUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string _lookupCode = dataGridView1.SelectedCells[0].OwningRow.Cells["LookupCode"].Value.ToString();
                string _lookupType = dataGridView1.SelectedCells[0].OwningRow.Cells["LookupType"].Value.ToString();
                Master.frmLookupUpdate ifrmChild = new Master.frmLookupUpdate(this, _lookupCode, _lookupType);
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
                string _lookupCode = dataGridView1.SelectedCells[0].OwningRow.Cells["LookupCode"].Value.ToString();
                string _lookupType = dataGridView1.SelectedCells[0].OwningRow.Cells["LookupType"].Value.ToString();
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Lookup_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@lookupCode", SqlDbType.VarChar, _lookupCode));
                        db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, _lookupType));
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
