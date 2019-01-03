using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Penjualan
{
    public partial class frmCetakDO : ISA.Toko.BaseForm
    {
        public int Result
        {
            get
            {
                if (rdbCopy.Checked == true)
                    return 1;
                else
                    return 2;
            }
        }

        public frmCetakDO()
        {
            InitializeComponent();
        }

        private void frmCetakDO_Load(object sender, EventArgs e)
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
