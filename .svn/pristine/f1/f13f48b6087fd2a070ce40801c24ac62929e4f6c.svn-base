using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmTargetKotaBrowse : ISA.Toko.BaseForm
    {
        Guid rowID;
        string _Kota, _TglAktif;
        DateTime _DateFrom, _DateTo;

        public frmTargetKotaBrowse()
        {
            InitializeComponent();
        }

        private void frmTargetKota_Load(object sender, EventArgs e)
        {
            _DateFrom = DateTime.Now;
            _DateTo = DateTime.Now;
            rangeDateBox1.FromDate = _DateFrom;
            rangeDateBox1.ToDate = _DateTo;
            getKota();

            if ((rangeDateBox1.FromDate != null) && (rangeDateBox1.ToDate != null)) //&& (lookupSales1.SalesID == ""))
            {
                cgvTargetKota.AutoGenerateColumns = false;
                BindData();
            }
        }

        private void getKota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Kota_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //dt.Rows.Add("");
                dt.DefaultView.Sort = "Kota ASC";
                cmbKota.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbKota.DataSource = dt;
                cmbKota.DisplayMember = "Kota";
                cmbKota.ValueMember = "Kota";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        public void BindData()
        {
            _DateFrom = rangeDateBox1.FromDate.Value;
            _DateTo = rangeDateBox1.ToDate.Value;
            _Kota = cmbKota.SelectedValue.ToString();

            DataTable dt = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("usp_HistoryTargetKota_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _DateFrom));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _DateTo));
            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, _Kota));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
            dt = db.Commands[0].ExecuteDataTable();
            cgvTargetKota.DataSource = dt;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cmbKota.SelectedValue.ToString() == "")
            {
                return;
            }
            _Kota = cmbKota.SelectedValue.ToString();
            Master.frmTargetKotaUpdate ifrmChild = new Master.frmTargetKotaUpdate(this, _Kota);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (cgvTargetKota.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)cgvTargetKota.SelectedCells[0].OwningRow.Cells["ColRowID"].Value;
                _Kota = cmbKota.SelectedValue.ToString();
                Master.frmTargetKotaUpdate ifrmChild = new Master.frmTargetKotaUpdate(this, rowID, _Kota);
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
            cgvTargetKota.FindRow(columnName, value);
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
                    db.Commands.Add(db.CreateCommand("usp_HistoryTargetKota_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.VarChar, _rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    cgvTargetKota.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    cgvTargetKota.RefreshEdit();
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
