using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls.Dialog
{
    public partial class frmFilterDialog : ISA.Controls.BaseForm
    {
        public string FindValue
        {
            get { return txtFind.Text; }          
        }

        public bool IsFind
        {
            get 
            {
                if (rdoFind.Checked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public frmFilterDialog()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdOK.PerformClick();
            }
        }
    }
}
