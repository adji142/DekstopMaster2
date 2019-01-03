using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Common;

namespace ISA.Encryptyor
{
    public partial class frmEncryptor : Form
    {
        public frmEncryptor()
        {
            InitializeComponent();
        }

        private void cmdEncrypt_Click(object sender, EventArgs e)
        {
            textBox1.Text = Tools.EncodePassword(textBox1.Text);
        }

        private void cmdDecrypt_Click(object sender, EventArgs e)
        {
            textBox1.Text = Tools.DecodePassword(textBox1.Text);
        }

    }
}
