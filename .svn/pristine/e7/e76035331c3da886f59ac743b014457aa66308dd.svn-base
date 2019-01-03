using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmTargetToko : ISA.Trading.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtTargetToko = new DataTable();
        DataTable dtHistTargetToko = new DataTable();

        public frmTargetToko()
        {
            InitializeComponent();
        }

        private void frmTargetToko_Load(object sender, EventArgs e)
        {
            {
                dataGridToko.AutoGenerateColumns = true;
                BrowseTargetToko();
            }
            
        }

        public void BrowseTargetToko()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    dtTargetToko = db.Commands[0].ExecuteDataTable();
                }
                dataGridToko.DataSource = dtTargetToko;
                
                if (dtTargetToko.Rows.Count == 0)
                {
                    dataGridTargetToko.DataSource = null;
                }
                else
                {
                    BrowseTargetTokoDetail();
                    dataGridToko.Focus();
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

        public void BrowseTargetTokoDetail()
        {

            Guid RowIdToko = (Guid)dataGridToko.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryTargetToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIdToko", SqlDbType.UniqueIdentifier, RowIdToko));
                    dtHistTargetToko = db.Commands[0].ExecuteDataTable();                    
                }
                dataGridTargetToko.DataSource = dtHistTargetToko;

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

        private void commandButton3_Click(object sender, EventArgs e)
        {
            BrowseTargetToko();
        }
        
        private void dataGridToko_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                BrowseTargetTokoDetail();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {            
            /*
            if (dataGridToko.SelectedCells.Count > 0)ok
            {
                MessageBox.Show("test");
                Master.frmTargetTokoAddEdit ifrmChild = new Master.frmTargetTokoAddEdit(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();

            }
            */
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    break;
                case enumSelectedGrid.DetailSelected:

                    string _RowID =  dataGridToko.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    DataRow[] dr = dtTargetToko.Select("RowID='"+_RowID+"'");
                    Master.frmTargetTokoAddEdit ifrmChild = new Master.frmTargetTokoAddEdit(this, dr[0]);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
            }


        }

        private void dataGridTargetToko_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridToko_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridToko_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    dataGridTargetToko.Focus();
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    break;
            
            }
        }

        private void dataGridTargetToko_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    dataGridToko.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;

            }
        }

        public void FindRow(string columnName, string value)
        {
            dataGridTargetToko.FindRow(columnName, value);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (dataGridTargetToko.SelectedCells.Count > 0)
            {
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        break;
                    case enumSelectedGrid.DetailSelected:
                        string _RowID = dataGridToko.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                        DataRow[] dr = dtTargetToko.Select("RowID='" + _RowID + "'");
                        string _RowID2 = dataGridTargetToko.SelectedCells[0].OwningRow.Cells["RowIDTargetToko"].Value.ToString();
                        DataRow[] dr2 = dtHistTargetToko.Select("RowID='" + _RowID2 + "'");
                        Master.frmTargetTokoAddEdit ifrmChild = new Master.frmTargetTokoAddEdit(this, dr[0], dr2[0]);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }
        
    }
}
