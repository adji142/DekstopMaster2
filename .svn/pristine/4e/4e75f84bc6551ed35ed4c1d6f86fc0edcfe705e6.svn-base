using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class frmNotaJualDetailLookUp : ISA.Controls.BaseForm
    {
        Guid _rowID;
        DateTime _tglNota;
        string _noNota;

        public Guid RowID
        {
            get
            {
                return _rowID;
            }
        }

        public DateTime TgNota
        {
            get
            {
                return _tglNota;
            }
        }

        public string NoNota
        {
            get
            {
                return _noNota;
            }
        }

        public frmNotaJualDetailLookUp(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        private void frmNotaJualDetailLookUp_Load(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                _rowID = new Guid(dataGridView1.SelectedRows[0].Cells["RowID"].Value.ToString());
                _noNota = dataGridView1.SelectedRows[0].Cells["noNota"].Value.ToString();
                _tglNota = (DateTime)dataGridView1.SelectedRows[0].Cells["TglNota"].Value;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count == 1)
            {
                ConfirmSelect();
            }
        }
    }
}
