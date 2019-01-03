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
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Piutang
{
    public partial class frmTokoHistory : ISA.Finance.BaseForm
    {
        int _PrevGrid1 = -1;
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
#region Procedure
        public void RefreshToko()
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
                dt.DefaultView.Sort = "NamaToko ASc";
                dtHeader.Dispose();
                dtHeader = dt.DefaultView.ToTable().Copy();
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefresDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
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


        public void RefresDetail(string KodeToko_)
        {
            try
            {
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TokoKasus_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.DefaultView.Sort = "RecordID ASC";
                dataGridDetail.DataSource = dt.DefaultView;
                //if (dt.Rows.Count > 0)
                //{
                //    dtDetail.Dispose();
                //    dt.DefaultView.Sort = "RecordID ASC";
                //    dtDetail = dt.DefaultView.ToTable().Copy();
                //    dataGridDetail.DataSource = dtDetail;
                //}
                //else
                //{
                //    dataGridDetail.DataSource = null;//dt.DefaultView;
                //}

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

        public void FindGridDetail(string ColoumName, string ColoumValue)
        {
            dataGridDetail.FindRow(ColoumName, ColoumValue);
        }

        public void RefreshRowDetail(Guid RowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_TokoKasus_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
            }
        }
#endregion

        public frmTokoHistory()
        {
            InitializeComponent();
        }

        private void frmTokoHistory_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dataGridHeader.AutoGenerateColumns = false;
            dataGridHeader.VirtualMode = true;
            RefreshToko();
        }

        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].RowIndex != _PrevGrid1)
                {
                    RefresDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
                }
                _PrevGrid1 = dataGridHeader.SelectedCells[0].RowIndex;
            }
            else
            {
                _PrevGrid1 = -1;
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridDetail.RowCount>0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                Guid RowID_ = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_TokoKasus_Delete]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    RefresDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
                }

            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count>0)
            {
                Guid RowID_= (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Piutang.frmTokoHistoryDetailUpdate ifrmChild = new Piutang.frmTokoHistoryDetailUpdate(this,RowID_,"Update");
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                Piutang.frmTokoHistoryDetailUpdate ifrmChild = new Piutang.frmTokoHistoryDetailUpdate(this, dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString());
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();
            }
        }

       
    }
}
