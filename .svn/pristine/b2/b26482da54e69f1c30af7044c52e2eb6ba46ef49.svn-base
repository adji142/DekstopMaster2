using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.LapKpl
{
    public partial class frmTargetSalesBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        #region "Function"
        string _KodeSales;
    
        Guid _RowIDd;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        public void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                }
                else
                {
                    dataGridView2.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    string salesID = dataGridView1.SelectedCells[0].OwningRow.Cells["KDSales"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_TargetSales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, _KodeSales));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataDetail(string _SalesID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                   

                    db.Commands.Add(db.CreateCommand("usp_TargetSales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, _SalesID));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void FeelDetail()
        {
            _RowIDd = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RowIDd"].Value;
            _KodeSales = dataGridView1.SelectedCells[0].OwningRow.Cells["KDSales"].Value.ToString();
        }
        #endregion
        public frmTargetSalesBrowser()
        {
            InitializeComponent();
        }

        private void frmTargetSalesBrowser_Load(object sender, EventArgs e)
        {
            _KodeSales = "";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            RefreshData();
            selectedGrid = enumSelectedGrid.HeaderSelected;
            dataGridView1.Focus();
            //_RowIDd = Guid.NewGuid();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
           if (selectedGrid!=enumSelectedGrid.DetailSelected)
                 {
                     return;
                 }

                    if (_KodeSales=="")
                    {
                        return;
                    }
                    LapKpl.frmTargetSalesBrowserDetailUpdate ifrmChild = new LapKpl.frmTargetSalesBrowserDetailUpdate(this,_KodeSales);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
           
           
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
                 if (selectedGrid!=enumSelectedGrid.DetailSelected)
                 {
                     return;
                 }
               
                    if (dataGridView2.SelectedCells.Count == 0)
                    {
                        return;
                    }
                    LapKpl.frmTargetSalesBrowserDetailUpdate ifrmChild = new LapKpl.frmTargetSalesBrowserDetailUpdate(this,_RowIDd,_KodeSales);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                
            
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.DetailSelected:
                    if (dataGridView2.SelectedCells.Count==0)
                    {
                        return;
                    }
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                               
                                db.Commands.Add(db.CreateCommand("usp_TargetSales_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowIDd));
                                db.Commands[0].ExecuteNonQuery();
                            }
                              RefreshDataDetail();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            if (dataGridView2.SelectedCells.Count > 0)
            {
                FeelDetail();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        public void FindDetail( string value)
        {
            dataGridView2.Refresh();
            dataGridView2.FindRow("RowIDd", value);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                FeelDetail();
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView2.Rows.Count>0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        cmdDelete.PerformClick();
                	break;
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                if (e.KeyCode==Keys.Insert)
                {
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    cmdAdd.PerformClick();
                }
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                    _KodeSales = dataGridView1.SelectedCells[0].OwningRow.Cells["KDSales"].Value.ToString();
                    RefreshDataDetail();
            }
        }

      
    }
}
