using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Communicator
{
    public partial class frmPinKasbon : ISA.Controls.BaseForm
    {
        string _publicKey = "";
        string _nip = "0";
        string _nomor = "0";

        public frmPinKasbon()
        {
            InitializeComponent();
        }

        public frmPinKasbon(Form _caller,string nip,string Nomor)
        {
            InitializeComponent();
            this.Caller = _caller;
            _nip = nip;
            _nomor = Nomor;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPinKasbon_Load(object sender, EventArgs e)
        {
            createPublicKey();
        }


        private void createPublicKey()
        {
            ///_publicKey = ISA.Pin.Generator.CreateKey(GlobalVar.Gudang, Convert.ToInt32(_nip.ToString()+_nomor), DateTime.Now);
            _publicKey = ISA.Pin.Generator.CreateKey(GlobalVar.Gudang, Convert.ToInt32(_nip.ToString()), DateTime.Now);
            txtPublicKey.Text = _publicKey;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            cekPIN();

        }

        public void cekPIN()
        {
            string _pin = txtPIN.Text;
            if (ISA.Pin.Generator.VerifyPin(_publicKey, _pin))
            {
                insertPIN();
            }
            else
            {
                MessageBox.Show("PIN Salah");
                return;
            }
        }

        private void insertPIN()
        {
            MessageBox.Show("PIN Benar.");
            //insertLog("PIN", "Sukses", "Public Key " + _publicKey + " dengan PIN " + txtPIN.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
