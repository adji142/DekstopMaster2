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
    public partial class frmTargetCollection : ISA.Trading.BaseForm
    {
        public frmTargetCollection()
        {
            InitializeComponent();
        }
        
        private void frmTargetCollection_Load(object sender, EventArgs e)
        {
            rgbPeriode.FromDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            rgbPeriode.ToDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, DateTime.DaysInMonth(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month));
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_TargetCollection_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rgbPeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rgbPeriode.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmTargetCollectionUpdate ifrmChild = new Master.frmTargetCollectionUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmTargetCollectionUpdate ifrmChild = new Master.frmTargetCollectionUpdate(this, _RowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
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
            customGridView1.FindRow(columnName, value);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
            customGridView1.Focus();
        }

    }
}
