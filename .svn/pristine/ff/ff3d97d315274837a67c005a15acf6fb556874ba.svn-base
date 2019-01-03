using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.ArusStock
{
    public partial class frmBarangKembaliKePenjualanHistory : ISA.Toko.BaseForm
    {
        public frmBarangKembaliKePenjualanHistory()
        {
            InitializeComponent();
        }

        public void loadPinjaman(DataTable dt)
        {
            gvHistory.AutoGenerateColumns = false;
            gvHistory.DataSource = dt;
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void frmBarangKembaliKePenjualanHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
