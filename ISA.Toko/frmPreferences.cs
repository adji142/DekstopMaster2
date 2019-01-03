using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISA.Toko
{
    public partial class frmPreferences : ISA.Toko.BaseForm
    {
        public frmPreferences()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtDbfUpload.Text))
                {
                    Directory.CreateDirectory(txtDbfUpload.Text);
                }
                if (!Directory.Exists(txtDbfDownload.Text))
                {
                    Directory.CreateDirectory(txtDbfDownload.Text);
                }
                if (!Directory.Exists(txtSASFoxpro.Text))
                {
                    Directory.CreateDirectory(txtSASFoxpro.Text);
                }

                Properties.Settings.Default.DBFUpload =  txtDbfUpload.Text;
                Properties.Settings.Default.DBFDownload = txtDbfDownload.Text;
                Properties.Settings.Default.SASdb = txtSASFoxpro.Text;
                Properties.Settings.Default.Save();
                GlobalVar.DbfUpload = txtDbfUpload.Text;
                GlobalVar.DbfDownload = txtDbfDownload.Text;
                GlobalVar.SASFoxpro = txtSASFoxpro.Text;
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {            
            txtDbfUpload.Text = Properties.Settings.Default.DBFUpload;            
            txtDbfDownload.Text = Properties.Settings.Default.DBFDownload;
            txtSASFoxpro.Text = Properties.Settings.Default.SASdb;
        }
    }
}
