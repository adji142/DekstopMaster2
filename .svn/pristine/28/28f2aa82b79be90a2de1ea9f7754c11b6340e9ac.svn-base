using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.ArusStock
{
    public partial class frmBarangKembaliKePenjualanHistory2 : ISA.Toko.BaseForm
    {
        DataTable dtP = new DataTable();

        public frmBarangKembaliKePenjualanHistory2()
        {
            InitializeComponent();
        }

        public frmBarangKembaliKePenjualanHistory2(DataTable dt)
        {
            InitializeComponent();
            dtP = dt.Copy();
        }

        public DataTable GetDT
        {
            get {
                return dtP.DefaultView.ToTable();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter && gvHistory.SelectedCells.Count == 1)
            {
                string RowID_ = gvHistory.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                dtP.DefaultView.RowFilter = "RowID='" + RowID_ + "'";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmBarangKembaliKePenjualanHistory2_Load(object sender, EventArgs e)
        {
            gvHistory.AutoGenerateColumns = false;
            gvHistory.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvHistory.DataSource = dtP.DefaultView;
            
           
        }
    }
}
