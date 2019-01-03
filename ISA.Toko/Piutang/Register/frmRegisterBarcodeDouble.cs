using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ISA.DAL;
using ISA.Common;

namespace ISA.Toko.Register
{
    public partial class frmRegisterBarcodeDouble : ISA.Controls.BaseForm
    {
        DataTable _dtNota = new DataTable();

        private string _kpRecId = string.Empty;
        public string KpRecId
        {
            get { return _kpRecId; }
        }

        public frmRegisterBarcodeDouble(DataTable dtNota)
        {
            this.DialogResult = DialogResult.Cancel;

            _dtNota = dtNota;

            InitializeComponent();
        }

        private void frmRegisterBarcodeDouble_Load(object sender, EventArgs e)
        {
            dgvNota.AutoGenerateColumns = false;
            dgvNota.DataSource = _dtNota;
            dgvNota.Select();
            dgvNota.Focus();
        }

        private void dgvNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdYes_Click(sender, new EventArgs());
        }

        private void dgvNota_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdYes_Click(sender, new EventArgs());
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dgvNota.SelectedCells.Count > 0)
            {
                _kpRecId = dgvNota.SelectedCells[0].OwningRow.Cells[this.KPRecID.Name].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
