using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Expedisi
{
    public partial class frmNotaLookupForRekapKoli : ISA.Toko.BaseForm
    {
        Guid _notaID;

        public frmNotaLookupForRekapKoli(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        public Guid NotaJualID
        {
            get
            {
                return _notaID;
            }
        }

        private void frmNotaLookupForRekapKoli_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Focus();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            _notaID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["NotaID"].Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
