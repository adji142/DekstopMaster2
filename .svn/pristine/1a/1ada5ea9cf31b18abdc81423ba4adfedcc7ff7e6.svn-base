using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;


namespace ISA.Finance.Register
{
    public partial class frmCollectorBrowser : ISA.Finance.BaseForm
    {
        DataTable dtHeader = new DataTable();
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                if (dtHeader.Rows.Count > 0)
                {
                    dataGridHeader.DataSource = dtHeader;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void RefreshRowDataHeader(string  RowID_)
        {
            try
            {
                DataTable dtRefresh;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, RowID_));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }
                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "CollectorID", RowID_.ToString());
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
           
        }


        public void FindGridHeader(string ColoumName_, string Value_)
        {
            dataGridHeader.FindRow(ColoumName_, Value_);
        }


        public frmCollectorBrowser()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count>0)
            {
                string RowID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Collector_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Money, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshRowDataHeader(RowID_);
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count==0)
            {
                return;
            }
            string RowID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();
            string NamaCollector_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            Double BatasOD_ = Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["BatasOD"].Value);
            Register.frmCollectorUpdate ifrmChild = new Register.frmCollectorUpdate(this, RowID_,NamaCollector_,BatasOD_);
            ifrmChild.ShowDialog();
        }

        private void frmCollectorBrowser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadData();
            dataGridHeader.Focus();
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridHeader.SelectedCells.Count>0)
            {
                cmdDelete.PerformClick();
            }
        }
    }
}
