using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.DKNForm
{
    public partial class frmBankasalUpdate : ISA.Controls.BaseForm
    {
        string _namaBank;
        string _lokasi;
        DataTable dt = new DataTable();

        public string NamaBank
        {
            get
            {
                return _namaBank;
            }
            set
            {
                _namaBank = value;
            }
        }

        public string Lokasi
        {
            get
            {
                return _lokasi;
            }
            set
            {
                _lokasi = value;
            }
        }


        private IList<Bankasal> _bankasalList = new List<Bankasal>();
        public IList<Bankasal> BankAsalList
        {
            get { return _bankasalList; }
        }

        public frmBankasalUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (lookupBankAsal1.NamaBank == "")
            {
                MessageBox.Show("Tidak ada Bank yang dipilih.");
                return;
            }
            if (this.Caller is DKNForm.frmDownloadDKNExecute)
            {
                _namaBank = lookupBankAsal1.NamaBank;
                _lokasi = lookupBankAsal1.Lokasi;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public class Bankasal
        {
            public string NamaBankAsal { get; set; }
            public string Lokasi { get; set; }
        }

        private void frmBankasalUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
