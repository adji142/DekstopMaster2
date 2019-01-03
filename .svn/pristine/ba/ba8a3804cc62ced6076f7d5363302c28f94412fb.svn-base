using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA.DAL;
using ISA.Pin;

namespace ISA.Finance.pin
{
    public partial class frmPinHarian : Form
    {
        Form _caller;
        int _bagian;
        DateTime _tanggal;
        string _keterangan;
        Guid _rowID;

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

        public frmPinHarian(Form caller, Guid rowID, int bagian, DateTime tanggal, string keterangan)
        {
            this.Caller = caller;
            this._rowID = rowID;
            this._bagian = bagian;
            this._tanggal = tanggal;
            this._keterangan = keterangan;

            InitializeComponent();
        }

        public frmPinHarian(Form caller, int bagian, DateTime tanggal, string keterangan)
        {
            this.Caller = caller;
            this._bagian = bagian;
            this._tanggal = tanggal;
            this._keterangan = keterangan;

            InitializeComponent();
        }

        public frmPinHarian()
        {
            InitializeComponent();
        }

        private void frmPinHarian_Load(object sender, EventArgs e)
        {
            txtKet.Text = _keterangan;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.ToString().Length != 7)
            {
                MessageBox.Show("Pin Yang anda masukan salah, silhakan Ulangi");
                txtPin.Text = "";

                return;
            }
            string baseCode = string.Empty;
            int multiplier = 1;
            
            if (this._bagian == Class.IdPIN.Bagian.CetakRegister)
            {
                baseCode = key.BaseCode.CetakRegister;
                multiplier = 19;
            }
            //pin 3 lapis register
            if (this._bagian == Class.IdPIN.Bagian.CetakRegisterSPV)
            {
                baseCode = key.BaseCode.CetakRegisterSPV;
                multiplier = 22;
            }
            if (this._bagian == Class.IdPIN.Bagian.CetakRegisterSupport)
            {
                baseCode = key.BaseCode.CetakRegisterSupport;
                multiplier = 23;
            }
            if (this._bagian == Class.IdPIN.Bagian.CetakRegisterPKP)
            {
                baseCode = key.BaseCode.CetakRegisterPKP;
                multiplier = 24;
            }
            //
            if (this._bagian == Class.IdPIN.Bagian.ClosingRegister)
            {
                baseCode = key.BaseCode.ClosingRegister;
                multiplier = 20;
            }
            if (this._bagian == Class.IdPIN.Bagian.PinRegisterBySales)
            {
                baseCode = key.BaseCode.FilterBySales;
                multiplier = 21;
            }

            string dailyPin = ISA.Pin.key.CreateDailyPin(this._tanggal, GlobalVar.Gudang, baseCode, multiplier);
            if (txtPin.Text == dailyPin)
            {
                if (this._bagian == Class.IdPIN.Bagian.CetakRegister || this._bagian == Class.IdPIN.Bagian.CetakRegisterSPV || this._bagian == Class.IdPIN.Bagian.CetakRegisterSupport || this._bagian == Class.IdPIN.Bagian.CetakRegisterPKP)
                {
                    //pin 3 Cetak Register
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_TagihanUpdatePin"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, txtPin.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Pin Benar, Data Akan Tercetak");
                            //update counter
                            if (this.Caller is Register.frmRegisterBrowser)
                            {
                                Register.frmRegisterBrowser frmCaller = (Register.frmRegisterBrowser)this.Caller;
                                frmCaller.UpdateCounter();
                                this.Close();
                            }
                        }
                    }
                }

                if (this._bagian == Class.IdPIN.Bagian.ClosingRegister)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_TagihanClosing"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        MessageBox.Show("Pin Benar, Proses Closing Sudah Selesai");
                    }                    
                }

                if (this._bagian == Class.IdPIN.Bagian.PinRegisterBySales)
                {
                    if (this.Caller is Register.frmRegisterUpdate)
                    {
                        Register.frmRegisterUpdate frmCaller = (Register.frmRegisterUpdate)this.Caller;
                        frmCaller.AfterPIN();
                        this.Close();
                    }
                }

                this.Close();

            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
        }
    }
}
