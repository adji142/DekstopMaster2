using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ISA.Pin;


using ISA.DAL;

namespace ISA.Toko.Pin
{
    public partial class frmPinMd5 : Form
    {
        Form _caller;
        Guid _rowID;
        Guid _detailRowID;
        string _pinKey;
        int _bagian;
        string _keterangan;

        public frmPinMd5(Form caller, Guid rowID, string kodeGudang, int bagian, string keterangan)
        {
            this.Caller = caller;
            _rowID = rowID;
            _bagian = bagian;

            _pinKey = Tools.GetKey(_rowID.ToString(), kodeGudang, _bagian);

            _keterangan = keterangan;

            InitializeComponent();
        }

        public frmPinMd5(Form caller, Guid rowID, Guid detailRowID, string kodeGudang, int bagian, string keterangan)
        {
            this.Caller = caller;
            _rowID = rowID;
            _detailRowID = detailRowID;
            _bagian = bagian;

            _pinKey = Tools.GetKey(_detailRowID.ToString(), kodeGudang, _bagian);

            _keterangan = keterangan;

            InitializeComponent();
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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (txtPin.Text == string.Empty)
            {
                MessageBox.Show("Pin harus diisi.");
                return;
            }

            MD5 md5Hash = MD5.Create();
            if (ISA.Pin.key.VerifyMd5Hash(md5Hash, _pinKey, txtPin.Text))
            {
                if (this.Caller is Penjualan.frmNotaJualBrowser)
                {
                    if (_bagian != PinId.Bagian.Harga)
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, _bagian));
                            db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("DO sudah diACC, silahkan insert kembali di Browse Nota");
                }

                if (this.Caller is Penjualan.frmNotaReturJualBrowse)
                {

                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE_RowID"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtPin.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                        db.Commands[0].ExecuteNonQuery();

                        MessageBox.Show("Retur sudah diACC, silahkan insert kembali di Browse Nota Retur");
                    }

                }

                if (this.Caller is Penjualan.TabelDO)
                {
                    if (_bagian != PinId.Bagian.Harga)
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, _bagian));
                            db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Pin Benar");
                    }
                    else
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPDATE_ACC"));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Pin Benar");
                    }
                }

                if (this.Caller is Penjualan.frmNotaJualUpdate)
                {
                    if (_bagian == PinId.Bagian.Harga)
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPDATE_ACC"));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _detailRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, _pinKey));
                    db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, txtPin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, _bagian));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.Text, txtKet.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
         }

        private void frmPinMd5_Load(object sender, EventArgs e)
        {
            txtKet.Text = _keterangan;
        }

        private void frmPinMd5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.TabelDO)
            {
                if (_bagian != PinId.Bagian.Harga)
                {
                    Penjualan.TabelDO frmCaller = (Penjualan.TabelDO)this.Caller;
                    frmCaller.RefreshDataDO();
                    try
                    {
                        frmCaller.FindHeader("RowID", _rowID.ToString());
                    }
                    catch { };
                }
                else
                {
                    Penjualan.TabelDO frm = (Penjualan.TabelDO)Caller;
                    frm.RefreshDataDetailDO();
                }
            }
            else if (this.Caller is Penjualan.frmNotaJualBrowser)
            {
                Penjualan.frmNotaJualBrowser frmCaller = (Penjualan.frmNotaJualBrowser)this.Caller;
                frmCaller.RefreshDataDO();
            }
            else if (this.Caller is Penjualan.frmNotaReturJualBrowse)
            {
                Penjualan.frmNotaReturJualBrowse frmCaller = (Penjualan.frmNotaReturJualBrowse)this.Caller;
                frmCaller.RefreshDataReturJual();
            }
            else if (this.Caller is Penjualan.frmNotaJualUpdate)
            {
                Penjualan.frmNotaJualUpdate frmCaller = (Penjualan.frmNotaJualUpdate)this.Caller;
                frmCaller.RefreshDataNota();
            }
        }
    }
}
