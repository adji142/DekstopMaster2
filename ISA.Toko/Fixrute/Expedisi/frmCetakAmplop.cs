using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Ekspedisi
{
    public partial class frmCetakAmplop : ISA.Toko.BaseForm
    {
        public string Shift
        {
            get
            {
                if (rdbShift1.Checked == true)
                    return "1";
                else
                    return "2";
            }
        }

        public string Bayar
        {
            get 
            {
                if (rdbKredit.Checked == true)
                    return "K";
                else
                    return "T";
            }
        }

        public frmCetakAmplop()
        {
            InitializeComponent();
        }

        private void frmCetakAmplop_Load(object sender, EventArgs e)
        {
            rdbShift1.Checked = true;
            rdbKredit.Checked = true;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
