using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.Penjualan
{
    public partial class frmHistoryPenjualanPotonganBrowser : ISA.Controls.BaseForm
    {
        DataRow _selectedRow;
        DataTable _dataTabel;

        public DataRow SelecetedRow
        {
            get
            {
                return _selectedRow;
            }
        }

        public frmHistoryPenjualanPotonganBrowser(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _dataTabel = dt;
            dataGridView1.DataSource = _dataTabel;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmHistoryPenjualanPotonganBrowser_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                int rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                _selectedRow = _dataTabel.Rows[rowIndex];
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ConfirmSelect();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
