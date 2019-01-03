using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Penjualan
{
    public partial class frmCetakNota : ISA.Toko.BaseForm
    {
        int nCetak = 0;
        public int Result
        {
            get
            {
                if (rdbCopy.Checked == true && rdbDotmatrix.Checked == true)
                    return 1;
                else if (rdbRevisi.Checked == true && rdbDotmatrix.Checked == true)
                    return 2;
                else if (rdbCopy.Checked == true && rdbInkjet.Checked == true)
                    return 3;
                else if (nCetak==0 &&  rdbDotmatrix.Checked == true)
                    return 5;
                else if (nCetak==0 && rdbInkjet.Checked==true)
                    return 6;
               else
                    return 4;
            }
        }

        public frmCetakNota()
        {
            InitializeComponent();
           // this.Caller = caller;
        }
        public frmCetakNota(Form caller, int nprint)
        {
            InitializeComponent();
            this.Caller = caller;
            nCetak = nprint;

        }

        private void frmCetakNota_Load(object sender, EventArgs e)
        {
            if (nCetak == 0)
            {
                rdbCopy.Visible = false;
                rdbRevisi.Visible = false;
                label1.Visible = false;
                groupBox1.Visible = false;
                //rdbDotmatrix.Checked = true;
                rdbInkjet.Checked = true;
            }
            else
            {
                rdbCopy.Visible = true;
                rdbRevisi.Visible = true;
                label1.Visible = true;
                groupBox1.Visible = true;
                rdbCopy.Checked = true;
                rdbInkjet.Checked = true;
            }
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

        private void rdbRevisi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbCopy_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
