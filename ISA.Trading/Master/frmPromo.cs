using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmPromo : ISA.Trading.BaseForm
    {
        public frmPromo()
        {
            InitializeComponent();
        }

        private void frmPromo_Load(object sender, EventArgs e)
        {
            DataGridViewPromo.AutoGenerateColumns = true;
            BrowsePromo();
        }
        public void BrowsePromo()
        {
            DataTable dtPromo = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_HistoryPromo_LIST"));
            dtPromo = db.Commands[0].ExecuteDataTable();
            DataGridViewPromo.DataSource = dtPromo;
        }

        private void commandButtonAdd_Click(object sender, EventArgs e)
        {
            Master.frmPromoAddEdit ifrmChild = new Master.frmPromoAddEdit(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void commandButtonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridViewPromo.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)DataGridViewPromo.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmPromoAddEdit ifrmChild = new Master.frmPromoAddEdit(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();


            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }
    }
}
