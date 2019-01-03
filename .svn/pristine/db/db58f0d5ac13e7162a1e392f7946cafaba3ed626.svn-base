using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Piutang
{
    public partial class frmVwKPiutang : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable("KPiutang");
        DataRow _selectedRow;

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                int rowIndex = customGridView1.SelectedCells[0].OwningRow.Index;
                _selectedRow = dt.Rows[rowIndex];
            }
        }

        public DataRow SelecetedRow
        {
            get
            {
                return _selectedRow;
            }
        }

        public frmVwKPiutang(DataTable dt_)
        {
            dt = dt_;

            InitializeComponent();
        }

        public frmVwKPiutang()
        {
            InitializeComponent();
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void frmVwKPiutang_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = false;

            customGridView1.DataSource = dt;

            customGridView1.Focus();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
