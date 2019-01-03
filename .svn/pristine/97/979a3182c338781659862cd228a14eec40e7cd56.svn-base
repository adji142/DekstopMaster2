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
    public partial class FrmBudgetPembelian : ISA.Trading.BaseForm
    {
        DateTime _fromDate, _toDate;

        public FrmBudgetPembelian()
        {
            InitializeComponent();
        }

        private void FrmBudgetPembelian_Load(object sender, EventArgs e)
        {
            _fromDate = DateTime.Now;
            _toDate = DateTime.Now;
            rangeDateBoxTglBP.FromDate = _fromDate;
            rangeDateBoxTglBP.ToDate = _toDate;
            rangeDateBoxTglBP.Focus();
            customGridViewBudgetPembelian.AutoGenerateColumns = true;
            BrowseBudgetPembelian();
        }

        public void BrowseBudgetPembelian()
        {

            _fromDate = (DateTime)rangeDateBoxTglBP.FromDate;
            _toDate = (DateTime)rangeDateBoxTglBP.ToDate;

            DataTable dtBudgetPembelian = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_BudgetPembelian_List"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
            db.Commands[0].Parameters.Add(new Parameter("@Gudang",SqlDbType.VarChar,GlobalVar.Gudang)) ;
            db.Commands[0].Parameters.Add(new Parameter("@Cabang",SqlDbType.VarChar,GlobalVar.CabangID)) ;
            dtBudgetPembelian = db.Commands[0].ExecuteDataTable();
            customGridViewBudgetPembelian.DataSource = dtBudgetPembelian ;
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            BrowseBudgetPembelian();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Master.FrmBudgetPembelianAddEdit ifrmChild = new Master.FrmBudgetPembelianAddEdit(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (customGridViewBudgetPembelian.SelectedCells.Count > 0)
            {

                Guid rowID = (Guid)customGridViewBudgetPembelian.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.FrmBudgetPembelianAddEdit ifrmChild = new Master.FrmBudgetPembelianAddEdit(this, rowID );
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();


            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void customGridViewBudgetPembelian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void FindRow(string columnName, string value)
        {
            customGridViewBudgetPembelian.FindRow(columnName, value);
        }

        private void rangeDateBoxTglBP_Load(object sender, EventArgs e)
        {

        }
    }
}
