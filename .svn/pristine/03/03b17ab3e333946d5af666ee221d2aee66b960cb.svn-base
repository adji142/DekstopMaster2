using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.Penjualan
{
    public partial class frmRiwayatJualHeader : ISA.Trading.BaseForm
    {
        DataTable _dt;
        bool _acak;
        string _format;

        public frmRiwayatJualHeader(Form acaller, DataTable dt, bool acak)
        {
            InitializeComponent();
            _dt = dt;
            _acak = acak;
            this.Caller = Caller;
        }
        
        private void frmRiwayatJualHeader_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _dt;
            lblToko.Text = "TOKO: " + _dt.Rows[0]["NamaToko"].ToString() + ",  " + _dt.Rows[0]["Alamat"].ToString();
            lblBarang.Text = _dt.Rows[0]["NamaBarang"].ToString();            
        }
       
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                lblBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
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
        }
    }
}
