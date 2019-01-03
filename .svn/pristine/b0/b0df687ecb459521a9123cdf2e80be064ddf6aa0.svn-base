using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmTargetSales : ISA.Toko.BaseForm
    {
        Guid rowID;     
        string _SalesID;
        DateTime _DateFrom, _DateTo;

        public frmTargetSales()
        {
            InitializeComponent();
        }

        private void frmTargetSales_Load(object sender, EventArgs e)
        {      
            _DateFrom = DateTime.Now;
            _DateTo = DateTime.Now;
            rangeDateBox1.FromDate = _DateFrom;
            rangeDateBox1.ToDate = _DateTo;
            
            if ((rangeDateBox1.FromDate != null) && (rangeDateBox1.ToDate != null) && (lookupSales1.SalesID == "")) 
            {
                cgvTargetSls.AutoGenerateColumns = false;
                BindData();
            }
        }

        public void BindData()
        {
            _DateFrom = rangeDateBox1.FromDate.Value;
            _DateTo = rangeDateBox1.ToDate.Value;
            _SalesID = lookupSales1.SalesID;

            DataTable dt = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _DateFrom));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _DateTo));
            if (_SalesID != "")
            {
                db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, _SalesID));
            }
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
            dt = db.Commands[0].ExecuteDataTable();
            cgvTargetSls.DataSource = dt;
        }

        private void cmdBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }


        private void cmdBtnADD_Click_1(object sender, EventArgs e)
        {
            if (lookupSales1.SalesID == "")
            {
                Master.frmTargetSalesUpdate ifrmChild = new Master.frmTargetSalesUpdate(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
                return;
            }
            else
            {
                Master.frmTargetSalesUpdate ifrmChild = new Master.frmTargetSalesUpdate(this, lookupSales1.SalesID, lookupSales1.NamaSales);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cmdBtnEDIT_Click(object sender, EventArgs e)
        {
            if (cgvTargetSls.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)cgvTargetSls.SelectedCells[0].OwningRow.Cells["ColRowID"].Value;
                Master.frmTargetSalesUpdate ifrmChild = new Master.frmTargetSalesUpdate(this, rowID, lookupSales1.SalesID, lookupSales1.NamaSales);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        public void FindBrowse1(string columnName, string value)
        {
            cgvTargetSls.FindRow(columnName, value);
        }

        public void RefreshBrowse1(string _rowID)
        {
           
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.VarChar, _rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }
                if (dtRefresh.Rows.Count > 0)
                {
                    cgvTargetSls.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    cgvTargetSls.RefreshEdit();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cgvTargetSls_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NRFormat = "###,###,##0";
            cgvTargetSls.Columns["tokoOA"].DefaultCellStyle.Format = NRFormat;
            cgvTargetSls.Columns["OmsetNetto"].DefaultCellStyle.Format = NRFormat;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
