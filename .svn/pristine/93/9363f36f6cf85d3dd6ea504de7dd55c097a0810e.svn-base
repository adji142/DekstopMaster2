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
    public partial class frmPengajuanBonusBrowser : ISA.Trading.BaseForm
    {
        public frmPengajuanBonusBrowser()
        {
            InitializeComponent();
        }

        private void frmPengajuanBonusBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Pengajuan Bonus";
            this.Text = "Bonus";
            lblNamaBrg.Text = "";
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglSJ.Focus();
        }

        private void rgbTglSJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataHeader();
        }

        private void RefreshDataHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCBonusSales_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dt;
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                }
                else
                {
                    lblNamaBrg.Text = "";
                }
                dataGridHeader.Focus();
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

        private void RefreshDataDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCBonusSalesDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dt;
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

        private void dataGridDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblNamaBrg.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
            else
            {
                lblNamaBrg.Text = "";
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataDetail();
            }
        }

    }
}
