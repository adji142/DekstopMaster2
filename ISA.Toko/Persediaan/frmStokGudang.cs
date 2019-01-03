using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Toko.DataTemplates;

namespace ISA.Toko.Persediaan
{
    public partial class frmStokGudang : ISA.Toko.BaseForm
    {
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
        
        int prevGrid1Row = -1;
        string Gudang_ = string.Empty;

#region "Var & Procedure"
       
        Boolean Finish,Finish2;

        private void FillDetail()
            {
            lblNamaStok.Text=dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }

        private void RefreshHeader()
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    dtHeader=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_gudang_LIST"));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    dataGridHeader.DataSource = dtHeader;
                    }
                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
                }
            }

        public void RefreshDetail(string like)
        {
            try
                {

                this.Cursor=Cursors.WaitCursor;
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    Gudang_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                using (Database db = new Database())
                {
                  
                        dtDetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_vwStokGudang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang_));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, like));

                        dtDetail = db.Commands[0].ExecuteDataTable();
                      
                    
                  }
                        dataGridDetail.DataSource = dtDetail;
                }
            }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
               
                }
        }
       
        public void RefreshDetail()
        {
            try
                {
                  Gudang_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                        {
                            dtDetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_vwStokGudang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang_));

                        dtDetail = db.Commands[0].ExecuteDataTable();
                        dataGridDetail.DataSource = dtDetail;
                      
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

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptStokGudang.rdlc", rptParams, dt, "dsOpname_Data1");
            ifrmReport.Show();

            }

        private void PrintOut()
            {
            try
                {
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        string gudangID = dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_vwStokGudang_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, gudangID));

                            dt = db.Commands[0].ExecuteDataTable();
                            DisplayReport(dt);
                        }
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
#endregion


        public frmStokGudang()
        {
            InitializeComponent();
        }

        private void StokGudang_Load(object sender, EventArgs e)
        {
            
            Finish=false;
            Finish2=false;
            label1.Text="Stok Gudang " + DateTime.Now.ToString("dd/MM/yyyy");
            dataGridHeader.AutoGenerateColumns=false;
            dataGridDetail.AutoGenerateColumns=false;
            lblNamaStok.Text="";
            RefreshHeader();

            Finish=true;
            Finish2=true;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Finish2=false;
            //if (txtSearch.Text != "")
            //{
                RefreshDetail(txtSearch.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Nama stok " + Messages.Error.InputRequired);
            //    txtSearch.Focus();
            //}
            //if (dtDetail != null)
            //{
            //    dtDetail.DefaultView.RowFilter = "NamaStok LIKE '" + txtSearch.Text.Replace("'","''") + "%'";
            //}
           
            
            
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    cmdSearch.PerformClick();
                //}
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridDetail.Rows.Count>0)
            {

                switch (e.KeyCode)
                {
                case Keys.F1:
                    PrintOut();
                	break;
                case Keys.F11:
                    if (!SecurityManager.IsAuditor())
                    {
                        if (dataGridHeader.SelectedCells.Count > 0 && dataGridDetail.SelectedCells.Count > 0)
                        {
                            string gudangID = dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                            string barangID = dataGridDetail.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                            if (MessageBox.Show(string.Format(Messages.Question.AskCalculateBarang, barangID), "Calculate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Recalculation(gudangID, barangID);
                                // add by ferry to make refresh.
                                RefreshDetail(txtSearch.Text);
                                dataGridDetail.FindRow("BarangID", barangID);
                                MessageBox.Show("Recalculation telah selesai");
                            }

                        }
                    }
                    break;
                }
            }
        }

        private void dataGridHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
                        //activate row on header which contain initGudang
            for (int i = 0; i < dataGridHeader.Rows.Count; i++)
            {
                if (dataGridHeader.Rows[i].Cells["GudangID"].Value.ToString() == GlobalVar.Gudang)
                {
                    dataGridHeader.Rows[i].Selected = true;
                    dataGridHeader.CurrentCell = dataGridHeader.Rows[i].Cells[0];
                    //RefreshDetail();
                }
            }
        }

        private void dataGridHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Finish && dataGridHeader.SelectedCells.Count > 0)
            {               
                if (Finish2)
                {
                    Finish2 = false;
                    //RefreshDetail();
                    Finish2 = true;
                }

            }
        }

        private void Recalculation(string gudangID)
        {
            Persediaan.frmRecalculateStokGudang ifrmChild = new Persediaan.frmRecalculateStokGudang(this,dtDetail.DefaultView.ToTable(),gudangID);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void Recalculation(string gudangID, string barangID)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                    db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, gudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();                    
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

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    cmdSearch.PerformClick();
            //}
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridDetail.Rows.Count > 0)
            {

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        PrintOut();
                        break;
                    case Keys.F11:
                        if (!SecurityManager.IsAuditor())
                        {
                            if (dataGridHeader.SelectedCells.Count > 0 && dataGridDetail.SelectedCells.Count > 0)
                            {
                                string gudangID = dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                                //string barangID = dataGridDetail.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                                Recalculation(gudangID);
                                 
                                

                            }
                        }
                        break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtDetail.Rows.Count>0 && dataGridDetail.RowCount>0 && txtSearch.Text.Trim()!="")
            {
                DataTable dtDetailTemp = new DataTable();
                dtDetailTemp = dtDetail.Copy();
                DataView dvDetailTemp = new DataView();
                dtDetailTemp.DefaultView.RowFilter = "NamaStok LIKE '" + txtSearch.Text.Trim() + "%'";
                dvDetailTemp = dtDetailTemp.DefaultView;
                dataGridDetail.DataSource = dvDetailTemp.ToTable();
            }
            else if (dtDetail.Rows.Count > 0 && dataGridDetail.RowCount > 0 && txtSearch.Text.Trim() == "")
            {
                dataGridDetail.DataSource = dtDetail;
                dataGridDetail.Refresh();
            }
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.Rows.Count > 0 && Finish && dtDetail.Rows.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString() == Gudang_)
                {
                    dataGridDetail.DataSource = dtDetail;

                }
                else
                {
                    dataGridDetail.DataSource = null;
                }
            }
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (Finish2 && dataGridHeader.SelectedCells.Count > 0 && dataGridDetail.SelectedCells.Count > 0)
            {
                    FillDetail();
            }
            else
            {
                lblNamaStok.Text = "";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearch.PerformClick();
                dataGridDetail.Select();
                dataGridDetail.Focus();
            }
        }
    }
}
