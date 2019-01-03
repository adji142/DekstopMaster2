using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;
using ISA.Controls;


namespace ISA.Bengkel.Transaksi
{
    public partial class frmPembelianBrowser : ISA.Bengkel.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, Detail1Selected, Detail2Selected, Detail3Selected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        DataTable dtHeader, dtDetail1;
        
        public frmPembelianBrowser()
        {
            InitializeComponent();
        }  

        private void frmPembelianBrowser_Load(object sender, EventArgs e)
        {
            dgvHeader.AutoGenerateColumns = false;
            rgbTglPembelian.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglPembelian.ToDate = DateTime.Now;
            rgbTglPembelian.Focus();                           
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataPembelian();
        }

        private void rgbTglRQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataPembelian()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeli_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglPembelian.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglPembelian.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dgvHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    dgvDetail1.DataSource = null;
                }
                else
                {
                    RefreshDataPembelianDetail();
                    dgvHeader.Focus();
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

        public void RefreshDataPembelianDetail()
        {
            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));                    
                dtDetail1 = db.Commands[0].ExecuteDataTable();
                dgvDetail1.DataSource = dtDetail1;
            }                                
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                Guid headerID;
                ISA.Bengkel.BaseForm ifrmChild;

                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        ifrmChild = new frmPembelianUpdate(this);
                        ifrmChild.ShowDialog();
                        break;
                    case enumSelectedGrid.Detail1Selected:                   
                        headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        ifrmChild = new frmPembelianDetailUpdate(this, headerID, FormTools.enumFormMode.New);
                        ifrmChild.ShowDialog(); 
                        break;                   
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

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (!CekAddEditDel())
            {
                return;
            }
            Guid rowID;

            try
            {
                this.Cursor = Cursors.WaitCursor;
            
                ISA.Bengkel.BaseForm ifrmChild;

                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        ifrmChild = new frmPembelianUpdate(this, rowID);
                        ifrmChild.ShowDialog();
                        break;
                    case enumSelectedGrid.Detail1Selected:                                         
                        rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        ifrmChild = new frmPembelianDetailUpdate(this, rowID, FormTools.enumFormMode.Update);
                        ifrmChild.ShowDialog();
                        break;                   
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

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (!CekAddEditDel())
            {
                return;
            }
            Guid rowID;
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
                            if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(ISA.Controls.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }

                            this.Cursor = Cursors.WaitCursor;
                            rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands.Add(db.CreateCommand("usp_bkl_dtransj_DELETE"));
                                db.Commands[1].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands.Add(db.CreateCommand("usp_bkl_djual_DELETE"));
                                db.Commands[2].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands.Add(db.CreateCommand("usp_bkl_service_DELETE"));
                                db.Commands[3].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                                db.BeginTransaction();
                                db.Commands[0].ExecuteNonQuery();
                                db.Commands[1].ExecuteNonQuery();
                                db.Commands[2].ExecuteNonQuery();
                                db.Commands[3].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                            MessageBox.Show("Record telah dihapus");
                            RefreshDataPembelian();
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
                    break;
                case enumSelectedGrid.Detail1Selected:                   
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            } 
                            MessageBox.Show("Record telah dihapus");

                            //Refresh Data
                            RefreshGridAfterDelete(dgvDetail1);
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
                    break;               
            }
        }

        private bool CekAddEditDel()
        {
            bool cek = true; 

            if (!FormTools.IsRowSelected(dgvHeader))
            {
                cek = false;
                goto SelesaiCek;
            }

            SelesaiCek:
            return cek;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{                
            //    case Keys.F3:
            //        if (dgvHeader.SelectedCells.Count == 0)
            //        {
            //            MessageBox.Show(Messages.Error.RowNotSelected);
            //            return;
            //        }
            //        LaporanOrderHarian();
            //        break;                
            //    case Keys.Tab:
            //        dgvDetail1.Focus();
            //        selectedGrid = enumSelectedGrid.Detail1Selected;
            //        break;
            //}
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Tab:
            //        dgvHeader.Focus();
            //        selectedGrid = enumSelectedGrid.HeaderSelected;
            //        break;
            //    case Keys.L:
            //        //CTRL + Shift + L
            //        if (e.Shift && e.Control)
            //        {
            //            GridList_PembelianDetail();
            //        }
            //        break;
            //}
        }

        private void GridList_PembelianDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtDetail1.Rows.Count > 0)
                {
                    //List<ReportParameter> rptParams = new List<ReportParameter>();
                    //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    //rptParams.Add(new ReportParameter("Gudang", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("NoACC", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("Supplier", dataGridHeader.SelectedCells[0].OwningRow.Cells["Supplier"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("TglRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("M", dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderSyncFlag"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("RpEstJual", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHrgJual"].Value.ToString()));
                    ////rptParams.Add(new ReportParameter("Item", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));
                    //rptParams.Add(new ReportParameter("RpEstHPP", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHPP"].Value.ToString()));
                    ////rptParams.Add(new ReportParameter("RpEstTerima", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));

                    //frmReportViewer ifrmReport = new frmReportViewer("gridDetailPembelian.rdlc", rptParams, dtDetail, "dsPembelian_Data");
                    //ifrmReport.Show();
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
        
        /* Laporan order harian */

        private void LaporanOrderHarian()
        {
            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PembelianHarian"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                    return;
                }
                else
                {
                    DisplayReport(dt);
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
        
        private void DisplayReport(DataTable dt)
        {
            DateTime tgl = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
            //construct parameter
            string periode;
            periode = tgl.ToShortDateString();
            //List<ReportParameter> rptParams = new List<ReportParameter>();

            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("rptOrderHarian.rdlc", rptParams, dt, "dsPembelian_Data");
            //ifrmReport.Show();

        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }       

        public void FindRow(FormTools.detailIndex idx, string columnName, string value)
        {
            switch(idx)
            {
                case FormTools.detailIndex.detail1:
                    dgvDetail1.FindRow(columnName, value);
                    break;
            }                       
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (FormTools.IsRowSelected(dgvHeader))
            {                            
                RefreshDataPembelianDetail();
            }
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dgvDetail1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail1Selected;
        }

        private void dgvDetail2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail2Selected;
        }

        private void dgvDetail3_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail3Selected;
        }

        private void RefreshGridAfterDelete(Controls.CustomGridView dgv)
        {
            int i = 0;
            int n = 0;
            i = dgv.SelectedCells[0].RowIndex;
            n = dgv.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)dgv.SelectedCells[0].OwningRow.DataBoundItem;

            DataRow dr = dv.Row;

            dr.Delete();
            dtDetail1.AcceptChanges();
            dgv.Focus();
            dgv.RefreshEdit();
            if (dgv.RowCount > 0)
            {
                if (i == 0)
                {
                    dgv.CurrentCell = dgv.Rows[0].Cells[n];
                }
                else
                {
                    dgv.CurrentCell = dgv.Rows[i - 1].Cells[n];
                }

            }

        }

    }
}
