using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.ArusStock
{
    public partial class frmAntarGudang_RiwayatAG_Browse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;

        public frmAntarGudang_RiwayatAG_Browse(DateTime fromDate,DateTime todate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = todate;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAntarGudang_RiwayatAG_Browse_Load(object sender, EventArgs e)
        {

        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            RefreshDataAG();
        }


        private void RefreshDataAG()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_LIST_RiwayatAG"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridHeader.DataSource = dt;
                }
                if (dt.Rows.Count == 0)
                {
                    dataGridDetail.DataSource = null;
                }
                else
                {
                    dataGridHeader.Focus();
                    RefreshDataAGDetail();
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


        private void RefreshDataAGDetail()
        {
            try
            {
                Guid _HeaderIDD = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridDetail.DataSource = dt;
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


        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataAGDetail();
            }
            else
            {
                dataGridDetail.DataSource = null;
            }
        }
    }
}
