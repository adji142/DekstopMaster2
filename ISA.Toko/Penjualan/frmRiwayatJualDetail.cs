using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Penjualan
{
    public partial class frmRiwayatJualDetail : ISA.Toko.BaseForm
    {
        DataTable _dt;
        bool _acak;
        string _format;

        public frmRiwayatJualDetail(Form caller, DataTable dt, bool acak)
        {
            InitializeComponent();
            _dt = dt;
            _acak = acak;
            this.Caller = caller;
        }

        private void frmRiwayatJualDetail_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _dt;
            lblToko.Text = "TOKO: " + _dt.Rows[0]["NamaToko"].ToString() + ",  " + _dt.Rows[0]["Alamat"].ToString();
            lblBarang.Text = "BARANG: " + _dt.Rows[0]["NamaBarang"].ToString();      
        }
       
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
