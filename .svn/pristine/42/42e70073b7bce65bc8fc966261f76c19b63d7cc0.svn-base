using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.RJ3
{
    public partial class frmKoreksiReturJualBrowser : ISA.Toko.BaseForm
    {
        Guid _retJualDetailID;
        DataTable dtRetJualDetail;
        bool _acak;
        string _format; 

        public frmKoreksiReturJualBrowser(Form caller, Guid retJualDetailID)
        {
            InitializeComponent();
            _retJualDetailID = retJualDetailID;
            this.Caller = caller;
        }

        private void frmKoreksiReturJualBrowser_Load(object sender, EventArgs e)
        {
            _acak = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Focus();
            RefreshDataKoreksiReturJual();
        }

        public void RefreshDataKoreksiReturJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtKoreksi = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KoreksiReturPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@returJualDetailID", SqlDbType.UniqueIdentifier, _retJualDetailID));

                    dtKoreksi = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dtKoreksi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                MessageBox.Show("Sudah ada koreksi," + System.Environment.NewLine
                        + "tidak bisa buat koreksi lagi!");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRetJualDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _retJualDetailID));
                    dtRetJualDetail = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // sedang dalam pengerjaan
            RJ3.frmKoreksiReturJualUpdate ifrmChild = new RJ3.frmKoreksiReturJualUpdate(this, dtRetJualDetail);
            ifrmChild.ShowDialog();
            if (ifrmChild.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridView1.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString() != "")
            {
                MessageBox.Show("DATA SUDAH LINK !, TIDAK BISA DIHAPUS...");
                return;
            }
            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    GlobalVar.LastClosingDate=(DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKoreksi"].Value;
                    if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKoreksi"].Value <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(String.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KoreksiReturPenjualan_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show("Record telah dihapus");
                    this.RefreshDataKoreksiReturJual();
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
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format currency
            if (!_acak)
                _format = "#,##0.00";
            else
                _format = "XXXXXX";

            dataGridView1.Rows[e.RowIndex].Cells["HrgJual"].Style.Format = _format;
            dataGridView1.Rows[e.RowIndex].Cells["Potongan"].Style.Format = _format;
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksi"].Style.Format = _format;
        }

        private void AcakTampilHrg()
        {
            if (_acak)
            {
                _format = "#,##0.00";
                _acak = false;
            }
            else
            {
                _format = "XXXXXX";
                _acak = true;
            }
            dataGridView1.Columns["HrgJual"].DefaultCellStyle.Format = _format;
            dataGridView1.Columns["Potongan"].DefaultCellStyle.Format = _format;
            dataGridView1.Columns["HrgJualKoreksi"].DefaultCellStyle.Format = _format;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
