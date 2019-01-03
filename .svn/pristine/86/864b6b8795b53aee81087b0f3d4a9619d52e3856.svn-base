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
    public partial class frmEntryKunjunganCollector : ISA.Toko.BaseForm
    {
        public frmEntryKunjunganCollector()
        {
            InitializeComponent();
        }

        DataTable dtGrid = new DataTable();

        private void  deleteData(){

            Guid _rowID = (Guid) DGVKunjunganCollector.SelectedCells[0].OwningRow.Cells["ROWID"].Value ;
            string _nama = DGVKunjunganCollector.SelectedCells[0].OwningRow.Cells["nm_coll"].Value.ToString();
            string _toko = DGVKunjunganCollector.SelectedCells[0].OwningRow.Cells["namatoko"].Value.ToString();

            if (MessageBox.Show("Hapus Kunjungan Collector " + _nama + " dengan toko "+ _toko +"?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@ROWID", SqlDbType.UniqueIdentifier , _rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        public void RefreshGridFindRow(Guid _rowID)
        {
            RefreshDataGrid();
            DGVKunjunganCollector.FindRow("ROWID", _rowID.ToString());
        }

        private void RefreshDataGrid()
        {
  
            try
            {
                this.Cursor = Cursors.WaitCursor;
               // dtCollector = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglStart", SqlDbType.DateTime, txtDate1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglEnd", SqlDbType.DateTime, txtDate2.DateValue));
                    dtGrid = db.Commands[0].ExecuteDataTable();

                }

                dtGrid.DefaultView.Sort = "nm_coll";
                DGVKunjunganCollector.DataSource = dtGrid.DefaultView;


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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AKC.frmKunjunganCollectorUpdate ifrmChild = new AKC.frmKunjunganCollectorUpdate(this);
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGVKunjunganCollector.SelectedCells.Count > 0)
            {
                Guid _rowID = (Guid) DGVKunjunganCollector.SelectedCells[0].OwningRow.Cells["ROWID"].Value ;

                
                AKC.frmKunjunganCollectorUpdate ifrmChild = new AKC.frmKunjunganCollectorUpdate(this , _rowID);
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DGVKunjunganCollector.SelectedCells.Count > 0)
            {
                deleteData();
                RefreshDataGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntryKunjunganCollector_Load(object sender, EventArgs e)
        {
            this.Title = "Kunjungan Collector";
            this.Text = "AKC";
            txtDate2.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtDate1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            DGVKunjunganCollector.AutoGenerateColumns = false;
            DGVKunjunganCollector.ReadOnly = true;
            RefreshDataGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
