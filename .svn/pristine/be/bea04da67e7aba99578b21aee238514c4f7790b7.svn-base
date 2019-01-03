using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.Pin;
using System.Security.Cryptography;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.pin
{
    public partial class frmPinMd5 : ISA.Controls.BaseForm
    {
        Form _caller;
        Guid _rowID;
        Guid _detailRowID;
        string _pinKey;
        int _bagian;
        string _keterangan;


        public frmPinMd5()
        {
            InitializeComponent();
        }

        public frmPinMd5(Form caller, Guid rowID, string kodeGudang, int bagian, string keterangan)
        {
            this.Caller = caller;
            _rowID = rowID;
            _bagian = bagian;
            _pinKey = GetKey(_rowID.ToString(), kodeGudang, _bagian);
            _keterangan = keterangan;
            InitializeComponent();
            if (bagian == 26)
                txtKet.Text = "(26) Nominal nota beda dengan Pembayaran.";
            else if(bagian == 29)
                txtKet.Text = "(29) ADJ Piutang.";
            else if (bagian == 31)
                txtKet.Text = "(31) Kredit Nota.";

        }

        public Form Caller
        {
            get
            {
                return _caller;
            }

            set
            {
                _caller = value;
            }
        }

        private string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            string x = kodeGudang.ToString().Trim().Substring(2,2)+noAjuan.ToString().Trim().PadLeft(2,'0')+
                       rowID.Replace("-", string.Empty).ToUpper();
            return x;
        }

        private void frmPinMd5_Load(object sender, EventArgs e)
        {
            txtKet.Text = _keterangan;
            if (this.Caller is Finance.PJ3.frmPJ3Browse)
            {
                if (_bagian == PinId.Bagian.KPJ)
                {
                    label1.Visible = true;
                    txtNoAcc.Visible = true;
                }
                else
                {
                    label1.Visible = false;
                    txtNoAcc.Visible = false;
                }
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            if (ISA.Pin.key.VerifyMd5Hash(md5Hash, _pinKey, txtPin.Text))
            {
                if (this.Caller is Kasir.frmPembayaranTunaiUpdate)
                {
                    MessageBox.Show("PIN berhasil");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (this.Caller is Piutang.frmKartuPiutangDetailUpdate)
                {
                    MessageBox.Show("PIN berhasil");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (this.Caller is Finance.DKNForm.frmDebetKreditNotaBrowse)
                {
                    MessageBox.Show("PIN berhasil");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (this.Caller is Kasir.frmVoucherTitipanGiro)
                {
                    MessageBox.Show("PIN berhasil");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (this.Caller is Finance.PJ3.frmPJ3Browse)
                {
                    if (_bagian == PinId.Bagian.KPJ)
                    {
                        if (txtNoAcc.Text == "")
                        {
                            MessageBox.Show("No Acc masih kosong.");
                            this.DialogResult = DialogResult.No;
                            //return;
                        }
                        else
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_UPDATE_ACC"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, txtNoAcc.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();
                                db.Commands[0].ExecuteNonQuery();
                            }
                            MessageBox.Show("Pin Benar");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
        }
    }
}
