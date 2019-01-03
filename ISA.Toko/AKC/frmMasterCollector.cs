using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.AKC
{
    public partial class frmMasterCollector : ISA.Controls.BaseForm
    {

        DataTable dtCollector = new DataTable();

        private void deleteData()
        {
            string _collID = DGVCollection.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();
            string _nama = DGVCollection.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();

            if (MessageBox.Show("Hapus Collector " + _nama + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _collID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    /*
                    DataRowView dv = (DataRowView)DGVCollection.SelectedCells[0].OwningRow.DataBoundItem;
                    DataRow dr = dv.Row;
                    dr.Delete();
                    DGVCollection.RefreshEdit();
                    DGVCollection.Focus();
                    dtCollector.AcceptChanges();
                    int i = 0;
                    int n = 0;
                    i = DGVCollection.SelectedCells[0].RowIndex;
                    n = DGVCollection.SelectedCells[0].ColumnIndex;
                    if (DGVCollection.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            DGVCollection.CurrentCell = DGVCollection.Rows[0].Cells[n];
                            DGVCollection.RefreshEdit();
                        }
                        else
                        {
                            DGVCollection.CurrentCell = DGVCollection.Rows[i - 1].Cells[n];
                            DGVCollection.RefreshEdit();
                        }
                    }
                     */
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        public void RefreshRowData(string _collectorID)
        {
            /*
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _collectorID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    DGVCollection.RefreshDataRow(dtRefresh.Rows[0], "CollectorID", _collectorID);
                    DGVCollection.FindRow("CollectorID", _collectorID);
                    dtCollector.AcceptChanges();
                    DGVCollection.Focus();
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
             */
            RefreshDataCollector();
            DGVCollection.FindRow("CollectorID", _collectorID);
        }

        public void RefreshDataCollector()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
               // dtCollector = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST"));
                    dtCollector = db.Commands[0].ExecuteDataTable();

                }

               // dtCollector.DefaultView.Sort = "Nama";
                DGVCollection.DataSource = dtCollector.DefaultView;


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


        public frmMasterCollector()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AKC.frmCollectorUpdate ifrmChild = new AKC.frmCollectorUpdate(this);
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGVCollection.Rows.Count > 0)
            {
                string collID = DGVCollection.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();

                AKC.frmCollectorUpdate ifrmChild = new AKC.frmCollectorUpdate(this, collID);
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.ShowDialog();
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DGVCollection.SelectedCells.Count > 0)
            {
                deleteData();
                RefreshDataCollector();
            }
        }

        private void frmMasterCollection_Load(object sender, EventArgs e)
        {
            this.Title = "Collector";
            this.Text = "AKC";
            DGVCollection.AutoGenerateColumns = false;
            DGVCollection.ReadOnly = true;
            RefreshDataCollector();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
