using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Piutang
{
    public partial class frmVwKoreksi : ISA.Toko.BaseForm
    {

#region "Procedure"
        DataTable dt = new DataTable("Koreksi");
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
#endregion

        public frmVwKoreksi(DataTable dt_)
        {
            dt = dt_;
            InitializeComponent();
        }

        public frmVwKoreksi()
        {
            InitializeComponent();
        }

        private void frmVwKoreksi_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = false;

            customGridView1.DataSource = dt;

            customGridView1.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }


        private void customGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void customGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
