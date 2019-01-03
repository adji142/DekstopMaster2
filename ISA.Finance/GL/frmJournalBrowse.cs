using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;

using System.Globalization;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Finance.GL
{
    public partial class frmJournalBrowse : ISA.Finance.BaseForm
    {
        int prevRow = -1;
        enum SelectedGrid { Header, Detail };
        SelectedGrid selectGrid = new SelectedGrid();
        public frmJournalBrowse()
        {
            InitializeComponent();
        }

        private void frmJournalBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.Date;
            rangeDateBox1.ToDate = DateTime.Now.Date; 
            //RefreshHeader();
            //RefreshDetail();
        }

        private void RefreshHeader()
        {
            DataTable dt = new DataTable();           
            using (Database db = new Database(GlobalVar.DBName))
            {
                dt = Journal.ListHeader(db,(DateTime) rangeDateBox1.FromDate, (DateTime) rangeDateBox1.ToDate);
            }
            dt.DefaultView.Sort = "Tanggal,NoReff";
            customGridView1.DataSource = dt.DefaultView;
            //string RowID_ = "";
            //RowID_ = Tools.isNull(dt.Rows[0]["RowID"], "").ToString();
            //MessageBox.Show(RowID_.ToString());
        }

        public void RefreshRowHeader(string rowID)
        {

            Guid _rowID = new Guid(rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtRefresh = Journal.GetHeader(db, _rowID);
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    //customGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    RefreshHeader();
                    RefreshDetail();
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

        private void RefreshDetail()
        {
            DataTable dt = new DataTable();
            Guid headerID;


            if (customGridView1.SelectedCells.Count > 0)
            {
                headerID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells[7].Value.ToString());
                //headerID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
            }
            else
            {
                headerID = new Guid();
            }
            using (Database db = new Database(GlobalVar.DBName))
            {
                dt = Journal.ListDetail(db, headerID);
            }

            dt.DefaultView.Sort = "DK, RecordID, NoPerkiraan";
            customGridView2.DataSource = dt.DefaultView;
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {

            
        }

        public void FindRow(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
            //RefreshDetail();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (selectGrid==SelectedGrid.Header)
            {
                if (customGridView1.SelectedCells.Count > 0)
                {
                    DateTime tglJournal = (DateTime)customGridView1.SelectedCells[0].OwningRow.Cells["hTanggal"].Value;
                    string kodeGudang = customGridView1.SelectedCells[0].OwningRow.Cells["hKodeGudang"].Value.ToString();
                    string periode = tglJournal.ToString("yyyyMM");
                    if (!Class.PeriodeClosing.IsGLClosed(periode, kodeGudang))
                    {
                        Guid rowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            Journal.DeleteHeader(db, rowID);
                        }
                    }

                }
            }
            else 
            {
                MessageBox.Show("Hapus Detail Melalui Form Edit Header.");
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            GL.frmJournalUpdate ifrmChild = new GL.frmJournalUpdate(this );
            ifrmChild.MdiParent = this.MdiParent;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                string recID = customGridView1.SelectedCells[0].OwningRow.Cells["hRecordID"].Value.ToString();

                GL.frmJournalUpdate ifrmChild = new GL.frmJournalUpdate(this, rowID, recID);
                ifrmChild.MdiParent = this.MdiParent;
                ifrmChild.Show();
                ifrmChild.WindowState = FormWindowState.Maximized;
            }
        }

        private void customGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == customGridView1.Columns["hSyncFlag"].Index)
            {
                if (customGridView1.Rows[e.RowIndex].Cells["hDebet"].Value.ToString() != customGridView1.Rows[e.RowIndex].Cells["hKredit"].Value.ToString())
                {
                    customGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    customGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }



        private void customGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int nSubj=0;
                int.TryParse (customGridView2.Rows[e.RowIndex].Cells["dNSubJournal"].Value.ToString(), out nSubj);
               
                if (nSubj >0)
                {
                    customGridView2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void cmdSubJournal_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid _jid = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                GL.frmSubJournalBrowse ifrmChild = new GL.frmSubJournalBrowse(_jid);
                ifrmChild.MdiParent = this.MdiParent;
                ifrmChild.Show();
                ifrmChild.WindowState = FormWindowState.Maximized;
            }
        }

        private void customGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdAdd_Click(sender, new EventArgs());
                        break;
                    case Keys.E:
                        MessageBox.Show("Grid2");
                        cmdEdit_Click(sender, new EventArgs());
                        break;
                    case Keys.D:
                        cmdDelete_Click(sender, new EventArgs());
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        cmdAdd_Click(sender, new EventArgs());
                        break;
                    case Keys.Space :
                        cmdEdit_Click(sender, new EventArgs());
                        break;
                    case Keys.Delete :
                        cmdDelete_Click(sender, new EventArgs());
                        break;
                }
            }
        }

        private void customGridView1_Enter(object sender, EventArgs e)
        {
            selectGrid = SelectedGrid.Header;
            customGridView1_SelectionChanged(sender, e);
        }

        private void customGridView2_Enter(object sender, EventArgs e)
        {
            selectGrid = SelectedGrid.Detail;
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                RefreshDetail();
            }
            
        }
    }
}
