using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Pin
{
    public partial class frmPinVerification : Form
    {
        private string key;
        private string description;

        private bool isValid = false;
        public bool IsValid
        {
            get { return this.isValid; }
        }

        public string ValidPin
        {
            get { return this.txtPin.Text; }
        }

        public frmPinVerification(string key,  string description)
        {
            this.isValid = false;
            this.key = key;
            this.description = description;

            InitializeComponent();
        }

        private void frmPinVerification_Load(object sender, EventArgs e)
        {
            txtKey.Text = this.key;
            lblKet.Text = this.description;
            cmdYes.Enabled = false;

            txtPin.Focus();
        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            cmdYes.Enabled = txtPin.Text != string.Empty;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (ISA.Pin.Generator.VerifyPin(this.key, txtPin.Text))
            {
                this.isValid = true;

                MessageBox.Show("PIN benar.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                this.isValid = false;
                MessageBox.Show("PIN yang Anda masukan salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdYes.Focus();
        }
    }
}
