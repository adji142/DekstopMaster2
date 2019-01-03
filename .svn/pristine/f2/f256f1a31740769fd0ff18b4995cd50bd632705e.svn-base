using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;
using ISA.Trading;

namespace ISA.Trading.Gudang
{
    public partial class frmPO : ISA.Trading.BaseForm
    {

        DataTable dtH;
        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;
        public frmPO()
        {
            InitializeComponent();
        }

        private void frmPO_Load(object sender, EventArgs e)
        {
            gvPOD.AutoGenerateColumns = false;
            gvPOH.AutoGenerateColumns = false;

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = " dd,MMMM,yyyy";
            dtpFrom.ShowUpDown = true;

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = " dd,MMMM,yyyy";
            dtpTo.ShowUpDown = true;

            RefreshHeader();
         
        }
        public void RefreshHeader()
        {

            //MessageBox.Show(dtpFrom.Value.ToString());
            //MessageBox.Show(dtpTo.Value.ToString());
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_POHeader_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtpFrom.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtpTo.Value));
                    dtH = db.Commands[0].ExecuteDataTable();
                }
                gvPOH.DataSource = dtH;
                if (dtH.Rows.Count > 0 && gvPOH.SelectedCells.Count > 0 )
                {
                    Guid HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    RefreshDetail(HeaderID_);

                }
                else
                {
                    //dtD.Clear();
                    //gvPOD.DataSource = dtD;
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

        private void RefreshDetail(Guid headerRowID)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PODetail_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRowID", SqlDbType.UniqueIdentifier, headerRowID));
                    //db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTxt2.DateValue.Value));
                    dtH = db.Commands[0].ExecuteDataTable();
                }
                gvPOD.DataSource = dtH;
                
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

        private void customGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPOH_SelectionRowChanged(object sender, EventArgs e)
        {
            if (gvPOH.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                RefreshDetail(HeaderID_);
                
            }
        }

        private void gvPOH_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        Gudang.frmPOAdd ifrmChild = new frmPOAdd(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                        

                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {
                            string RowID_ = gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                            DataTable dtH = new DataTable();
                            dtH = dtH.Copy();
                            //dtH.DefaultView.RowFilter = "RowID='" + RowID_ + "'";

                            Gudang.frmPODetailAdd ifrmChild = new frmPODetailAdd();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        } 
                    }

                    break;
            }
        }

        private void gvPOD_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
