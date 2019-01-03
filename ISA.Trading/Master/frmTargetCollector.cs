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
    public partial class frmTargetCollector : ISA.Trading.BaseForm
    {
        Guid rowID;
        string _CollectorID;
        DateTime _DateFrom, _DateTo;

        public frmTargetCollector()
        {
            InitializeComponent();
        }

        private void GetCollector()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //dt.Rows.Add("");
                dt.DefaultView.Sort = "Nama ASC";
                cmbCollector.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCollector.DataSource = dt;
                cmbCollector.DisplayMember = "Nama";
                cmbCollector.ValueMember = "Kode";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmTargetCollector_Load(object sender, EventArgs e)
        {
            _DateFrom = DateTime.Now;
            _DateTo = DateTime.Now;
            rangeDateBox1.FromDate = _DateFrom;
            rangeDateBox1.ToDate = _DateTo;
            GetCollector();

            if ((rangeDateBox1.FromDate != null) && (rangeDateBox1.ToDate != null) && (cmbCollector.Text != null))
            {
                cgvGridCollector.AutoGenerateColumns = false;
                BindData();
            }
        }

        public void BindData()
        {
            _DateFrom = rangeDateBox1.FromDate.Value;
            _DateTo = rangeDateBox1.ToDate.Value;
            _CollectorID = cmbCollector.SelectedValue.ToString();
            DataTable dt = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_HistoryTargetCollector_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _DateFrom));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _DateTo));
            db.Commands[0].Parameters.Add(new Parameter("@CollID", SqlDbType.VarChar, _CollectorID));
            dt = db.Commands[0].ExecuteDataTable();
            cgvGridCollector.DataSource = dt;

        }

        private void cmdBtnADD_Click(object sender, EventArgs e)
        {
            if (cmbCollector.SelectedValue.ToString() == "")
            {
                return;
            }
            string _namaColl = cmbCollector.Text;
            Master.frmTargetCollectorUpdate ifrmChild = new Master.frmTargetCollectorUpdate(this, cmbCollector.SelectedValue.ToString(),_namaColl);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdBtnEDIT_Click(object sender, EventArgs e)
        {
            if (cmbCollector.SelectedValue.ToString() == "")
            {
                return;
            }
            string _namaColl = cmbCollector.Text;
            if (cgvGridCollector.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)cgvGridCollector.SelectedCells[0].OwningRow.Cells["ColRowID"].Value;
                Master.frmTargetCollectorUpdate ifrmChild = new Master.frmTargetCollectorUpdate(this, rowID, cmbCollector.SelectedValue.ToString(), _namaColl);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdBtnSearch_Click(object sender, EventArgs e)
        {
            cgvGridCollector.AutoGenerateColumns = false;
            BindData();
        }

        public void FindBrowse1(string columnName, string value)
        {
            cgvGridCollector.FindRow(columnName, value);
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
                    db.Commands.Add(db.CreateCommand("usp_HistoryTargetCollector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.VarChar, _rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    cgvGridCollector.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    cgvGridCollector.RefreshEdit();
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

    }


}
