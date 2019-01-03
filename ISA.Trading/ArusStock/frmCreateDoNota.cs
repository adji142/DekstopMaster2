using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.ArusStock
{
    public partial class frmCreateDoNota : ISA.Controls.BaseForm
    {
        public frmCreateDoNota(Form caller)
        {
            this.Caller = caller;
            //formMode = enumFormMode.New;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
