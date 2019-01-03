using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Penjualan
{
    public partial class frmCetakNotaRetur : ISA.Toko.BaseForm
    {
        public int Result
        {
            get
            {
                if (rdbCopy.Checked == true)
                    return 2;
                else
                    return 9;
            }
        }

        public frmCetakNotaRetur()
        {
            InitializeComponent();
        }

        private void frmCetakNotaRetur_Load(object sender, EventArgs e)
        {
            rdbCopy.Checked = true;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
