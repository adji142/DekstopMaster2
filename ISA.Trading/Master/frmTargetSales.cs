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

namespace ISA.Trading.Master
{
    public partial class frmTargetSales : ISA.Trading.BaseForm
    {
        Guid rowID;     
        string _SalesID, _KodeSales;
        DateTime _DateFrom, _DateTo;

        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();

        public frmTargetSales()
        {
            InitializeComponent();
        }

        private void frmTargetSales_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            dt = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_LIST"));
            dt = db.Commands[0].ExecuteDataTable();
            cgvTargetSls.DataSource = dt;

            _KodeSales = Tools.isNull(cgvTargetSls.SelectedCells[0].OwningRow.Cells["KodeSales"].Value, "").ToString();
            RefreshDataTargetToko();

        }

        private void cmdBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }


        private void cmdBtnADD_Click_1(object sender, EventArgs e)
        {
            //if (lookupSales1.SalesID == "")
            //{
            //    return;
            //}

            //Master.frmTargetSalesUpdate ifrmChild = new Master.frmTargetSalesUpdate(this, lookupSales1.SalesID, lookupSales1.NamaSales);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void cmdBtnEDIT_Click(object sender, EventArgs e)
        {
            //if (cgvTargetSls.SelectedCells.Count > 0)
            //{
            //    Guid rowID = (Guid)cgvTargetSls.SelectedCells[0].OwningRow.Cells["ColRowID"].Value;
            //    Master.frmTargetSalesUpdate ifrmChild = new Master.frmTargetSalesUpdate(this, rowID, lookupSales1.SalesID, lookupSales1.NamaSales);
            //    ifrmChild.MdiParent = Program.MainForm;
            //    Program.MainForm.RegisterChild(ifrmChild);
            //    ifrmChild.Show();
            //}
            //else
            //{
            //    MessageBox.Show(Messages.Error.RowNotSelected);
            //}
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshDataTargetToko()
        {
            try
            {
                dtt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryTargetToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                    dtt = db.Commands[0].ExecuteDataTable();
                    gvTargetToko.DataSource = dtt;
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

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Communicator.frmTargetSalesDownload ifrmChild = new Communicator.frmTargetSalesDownload(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cgvTargetSls_SelectionRowChanged(object sender, EventArgs e)
        {
            if (cgvTargetSls.SelectedCells.Count > 0)
            {
                _KodeSales = Tools.isNull(cgvTargetSls.SelectedCells[0].OwningRow.Cells["KodeSales"].Value, "").ToString();
                RefreshDataTargetToko();
                txtTrgBE.Text = dtt.Compute("SUM(TargetBE)", string.Empty).ToString();
                txtTrgFA.Text = dtt.Compute("SUM(TargetFA)", string.Empty).ToString();

            }

        }

    }
}
