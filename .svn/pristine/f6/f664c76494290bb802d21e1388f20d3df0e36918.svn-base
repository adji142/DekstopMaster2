using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Penjualan
{
    public partial class frmPPCBrowse : ISA.Toko.BaseForm
    {

        DataRow _selectedRow;
        DataTable _dataTabel;
        Guid _doID;
        string _htrID;

        public frmPPCBrowse(Form caller, DataTable dt, Guid doID, string htrID)
        {
            InitializeComponent();
            _dataTabel = dt;
            _doID = doID;
            _htrID = htrID;
            dataGridView1.DataSource = _dataTabel;
            this.Caller = caller;
        }

        private void frmPPCBrowser_Load(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                _selectedRow = _dataTabel.Rows[rowIndex];

                Penjualan.frmPPCUpdate ifrmChild = new Penjualan.frmPPCUpdate(this.Caller, _selectedRow, _doID, _htrID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();

                this.Close();
            }
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
