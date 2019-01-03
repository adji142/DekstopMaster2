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



namespace ISA.Finance.Piutang
{
    public partial class frmPlafon : ISA.Finance.BaseForm
    {
        DataTable dtDetail = new DataTable();
        DataTable dtHeader = new DataTable();
        int _PrevGrid = -1;

#region Procedure
        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "NamaToko ASC";
                dtHeader.Dispose();
                dtHeader = dt.DefaultView.ToTable().Copy();
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                 //   RefreshDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value);
                }
                else
                {
                    dataGridDetail.DataSource = null;
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

        public void RefreshDetail(string KodeToko_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_detailPlafon_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Tanggal ASC";
                    dtDetail.Dispose();
                    dtDetail = dt.DefaultView.ToTable().Copy();
                    dataGridDetail.DataSource = dtDetail;
                }
                else
                {
                    dataGridDetail.DataSource = null;
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

        public void FindGridHeader(string ColoumName_, string Value_)
        {
            dataGridHeader.FindRow(ColoumName_, Value_);
        }

#endregion

        public frmPlafon()
        {
            InitializeComponent();
        }

        private void frmPlafon_Load(object sender, EventArgs e)
        {
            lblToko.Text = "";
            this.WindowState = FormWindowState.Maximized;
            RefreshHeader();
        }

        private void frmPlafon_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (e.KeyCode == Keys.F12)
                {
                    Piutang.frmPlafonRefresh ifrmChild = new Piutang.frmPlafonRefresh(this, dtHeader, dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();
                }
            }
        }

        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].RowIndex != _PrevGrid)
                {
                    RefreshDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
                    lblToko.Text =
                    dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                }
                _PrevGrid = dataGridHeader.SelectedCells[0].RowIndex;
            }
            else
            {
                _PrevGrid = -1;
            }

        }
    }
}
