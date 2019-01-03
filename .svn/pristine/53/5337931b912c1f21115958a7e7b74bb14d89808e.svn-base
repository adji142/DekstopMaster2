using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Pin
{
    public partial class frmPinGenerator : Form
    {
        public frmPinGenerator()
        {
            InitializeComponent();
        }

        private void frmPinGenerator_Load(object sender, EventArgs e)
        {
            cmdYes.Enabled = false;

            txtKey.Focus();
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            cmdYes.Enabled = txtKey.Text != string.Empty;

            if (cmdYes.Enabled)
            {
                txtPin.Text = Generator.CreatePin(txtKey.Text);
            }
            else
            {
                txtPin.Text = string.Empty;
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            txtPin.Text = Generator.CreatePin(txtKey.Text);
        }

        private void txtKet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmdYes.Enabled)
                cmdYes.Focus();
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtKet.Focus();
        }

    }
}
