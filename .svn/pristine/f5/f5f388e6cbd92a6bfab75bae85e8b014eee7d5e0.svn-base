using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISA.Controls
{
    public partial class FolderBrowserTextBox : UserControl
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        public new string Text
        {
            get
            {
                return txtFolder.Text;
            }
            set
            {
                txtFolder.Text = value;
            }
        }

        public FolderBrowserTextBox()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists (txtFolder.Text ))
            {
                dialog.SelectedPath = txtFolder.Text;                
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {                
                txtFolder.Text = dialog.SelectedPath;
            }
        }
    }
}
