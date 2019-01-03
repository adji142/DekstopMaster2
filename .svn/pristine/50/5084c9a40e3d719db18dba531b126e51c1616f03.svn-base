using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.GL
{
    public partial class frmPerkiraanKoneksiArusKasUpdate : ISA.Finance.BaseForm
    {
        public string NoPerkiraan
        {
            get
            {
                return txtNoPerkiraan.Text;
            }
            set
            {
                txtNoPerkiraan.Text = value;
            }
        }

        public string Keterangan
        {
            get
            {
                return txtKeterangan.Text;
            }
            set
            {
                txtKeterangan.Text = value;
            }
        }

        public frmPerkiraanKoneksiArusKasUpdate(string noPerkiraan, string keterangan)
        {
            InitializeComponent();
            txtNoPerkiraan.Text = noPerkiraan;
            txtKeterangan.Text = keterangan;
        }

        private void frmPerkiraanKoneksiArusKasUpdate_Load(object sender, EventArgs e)
        {
            txtKeterangan.CharacterCasing = CharacterCasing.Normal;
        }

        private void cmdSave_Click(object sender, EventArgs e)
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
