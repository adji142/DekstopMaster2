using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Kasir
{
    public partial class frmLookupDetailTransfer : ISA.Toko.BaseForm
    {
        public frmLookupDetailTransfer(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void frmLookupDetailTransfer_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupBank1.BankID == "" || lookupBank1.BankID == "[CODE]")
            {
                MessageBox.Show("Transfer ke bank belum diisi");
                return;
            }
            if (tbBankDari.Text == "")
            {
                MessageBox.Show("Transfer dari bank belum diisi");
                return;
            }
            if (tbNomor.Text == "")
            {
                MessageBox.Show("Nomor belum diisi");
                return;
            }
            frmKasbonUpdate frm = new frmKasbonUpdate();
            frm = (frmKasbonUpdate)Caller;
            frm.DetailTransfer(lookupBank1.BankID, tbBankDari.Text, tbNomor.Text);
            this.Close();
        }

       
    }
}
