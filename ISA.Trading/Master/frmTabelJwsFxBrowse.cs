using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.Master
{
    public partial class frmTabelJwsFxBrowse : ISA.Controls.BaseForm
    {
        public frmTabelJwsFxBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.frmTabelJwJsFxUpdate ifrmChild = new frmTabelJwJsFxUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
