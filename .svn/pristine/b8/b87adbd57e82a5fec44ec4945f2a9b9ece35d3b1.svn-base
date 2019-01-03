using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Controls
{
    public partial class LookupPerkiraanKoneksi : UserControl
    {
        string _kode, header="";

        public event EventHandler SelectData;

        public string NoPerkiraan
        {
            get
            {
                return lblLookup.Text;
            }
            set
            {
                lblLookup.Text = value;
            }
        }

        public string NamaPerkiraan
        {
            get
            {
                return txtLookup.Text;
            }
            set
            {
                txtLookup.Text = value;
            }
        }

        public string Header
        {
           
            set
            {
                header = value;
            }
        }

        [Browsable(true)] public string Kode
        {
            get
            {
                return _kode;
            }
            set
            {
                _kode = value;
            }
        }

        public LookupPerkiraanKoneksi()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            if (header == "")
            {
                frmPerkiraanKoneksiLookup ifrmDialog = new frmPerkiraanKoneksiLookup(this.Kode);

                ifrmDialog.ShowDialog();

                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
            else
            {
                frmPerkiraanKoneksiLookup ifrmDialog = new frmPerkiraanKoneksiLookup(this.Kode,header);

                ifrmDialog.ShowDialog();

                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
        }

        private void GetDialogResult(frmPerkiraanKoneksiLookup dialogForm)
        {
            this.NoPerkiraan = dialogForm.NoPerkiraan;
            this.NamaPerkiraan = dialogForm.NamaPerkiraan;
            
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void txtLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (this.NoPerkiraan=="" || this.NoPerkiraan =="[CODE]" || this.NoPerkiraan=="?"))
            {
                ShowDialogForm();
            }
        }

    }
}
