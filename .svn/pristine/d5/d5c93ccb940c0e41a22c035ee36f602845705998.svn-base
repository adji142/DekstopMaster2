using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Bonus
{
    public partial class frmTabulasiBarangBrowser : ISA.Trading.BaseForm
    {
        string stokGroupID;

        public frmTabulasiBarangBrowser()
        {
            InitializeComponent();
        }

        private void frmTabulasiBarangBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Tabulasi Barang";
            this.Text = "Bonus";
            stokGroupID = "";
            dataGridStokGroup.AutoGenerateColumns = false;
            dataGridPeriodeGroup.AutoGenerateColumns = false;
            dataGridStokDetail.AutoGenerateColumns = false;
            RefreshDataStokGroup();
        }

        public void RefreshDataStokGroup()
        {
            try 
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtStokGroup = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokGroup_LIST"));
                    dtStokGroup = db.Commands[0].ExecuteDataTable();
                }
                dataGridStokGroup.DataSource = dtStokGroup;

                if (dataGridStokGroup.SelectedCells.Count > 0)
                {
                    stokGroupID = dataGridStokGroup.SelectedCells[0].OwningRow.Cells["StokGroup"].Value.ToString();
                    RefreshDataPeriodeGroup();
                    RefreshDataStokDetail();
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

        public void RefreshDataPeriodeGroup()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt =  new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PeriodeGroup_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, stokGroupID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPeriodeGroup.DataSource = dt;
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

        public void RefreshDataStokDetail()
        { 
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt =  new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StokDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, stokGroupID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridStokDetail.DataSource = dt;
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridStokGroup_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridStokGroup.SelectedCells.Count > 0)
            {
                stokGroupID = dataGridStokGroup.SelectedCells[0].OwningRow.Cells["StokGroup"].Value.ToString();
                RefreshDataPeriodeGroup();
                RefreshDataStokDetail();
            }
        }
    }
}
