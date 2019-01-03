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
    public partial class frmPerusahaanBrowse : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();


        public frmPerusahaanBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerusahaanBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    gvPerusahaan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Data Perusahaan sudah ada, tidak bisa ditambah");
                return;
            }
            Master.frmPerusahaan ifrmChild = new Master.frmPerusahaan(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (gvPerusahaan.SelectedCells.Count > 0)
            {
                Guid _RowID = new Guid(Tools.isNull(gvPerusahaan.SelectedCells[0].OwningRow.Cells["RowID"].Value,Guid.Empty).ToString());
                Master.frmPerusahaan ifrmChild = new Master.frmPerusahaan(this, _RowID);
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
        }
    }
}
