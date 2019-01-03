using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Pin;

using ISA.DAL;

namespace ISA.Finance.pin
{
    public partial class frmPinFinance : Form
    {
        int _bagian, _modulId, _MingguKe, _periode;
        DateTime _tanggal;
        string _keterangan;
        Form _caller;
        Guid _RowID;

        public frmPinFinance(Form caller, int periodePin, int bagian, int modulId, int MingguKe, DateTime tanggal, string keterangan)
        {
            this._bagian = bagian;
            this._modulId = modulId;
            this._MingguKe = MingguKe;
            this._keterangan = keterangan;
            this._tanggal = tanggal;
            this._periode = periodePin;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmPinFinance(Form caller, int periodePin, int bagian, int modulId, Guid RowID, DateTime tanggal)
        {
            this._bagian = bagian;
            this._modulId = modulId;
            this._RowID = RowID;
            
            this._tanggal = tanggal;
            this._periode = periodePin;
            this.Caller = caller;
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

        private void frmPinReg_Load(object sender, EventArgs e)
        {
            string cabang = GlobalVar.Gudang;
            string kodeCabang;
            if (cabang == "2811") { kodeCabang = "11"; }
            else if (cabang == "2802") { kodeCabang = "02"; }
            else if (cabang == "2803") { kodeCabang = "03"; }
            else if (cabang == "2804") { kodeCabang = "04"; }
            else if (cabang == "2805") { kodeCabang = "05"; }
            else if (cabang == "2806") { kodeCabang = "06"; }
            else if (cabang == "2807") { kodeCabang = "07"; }
            else if (cabang == "2808") { kodeCabang = "08"; }
            else if (cabang == "2809") { kodeCabang = "09"; }
            else if (cabang == "2810") { kodeCabang = "10"; }
            else if (cabang == "2812") { kodeCabang = "12"; }
            else if (cabang == "2813") { kodeCabang = "13"; }
            else if (cabang == "2814") { kodeCabang = "14"; }
            else if (cabang == "2815") { kodeCabang = "15"; }
            else if (cabang == "2816") { kodeCabang = "16"; }
            else if (cabang == "2817") { kodeCabang = "17"; }
            else if (cabang == "2818") { kodeCabang = "18"; }
            else if (cabang == "2819") { kodeCabang = "19"; }
            else if (cabang == "2820") { kodeCabang = "20"; }
            else { kodeCabang = "99"; }

            Random rnd = new Random();
            int angkaAcak = rnd.Next(100, 999);
            txtKet.Text = this._keterangan;
            txtKey.Text = kodeCabang + _modulId + angkaAcak.ToString();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.ToString().Length != 8)
            {
                MessageBox.Show("Pin Yang anda masukan salah, silhakan Ulangi");
                txtPin.Text = "";

                return;
            }

            if (ISA.Pin.key.cek(txtKey.Text, txtPin.Text, _bagian))
            {
                //GlobalVar.pinResult = true;

                if (this.Caller is Register.frmRegisterBrowser)
                {
                    if (_bagian == 9)
                    {
                    //pin 1 f8 closing
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TagihanClosing"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _RowID));
                            dt = db.Commands[0].ExecuteDataTable();

                            MessageBox.Show("Pin Benar, Proses Closing Sudah Selesai");
                        }
                    }



                    if (_bagian == 10)
                    {
                        //pin 2 delete detail
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TagihanDeleteDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _RowID));
                            dt = db.Commands[0].ExecuteDataTable();

                            MessageBox.Show("Pin Benar, Data Sudah Terhapus");
                        }
                    }

                    else
                    {
                        //pin 3 Cetak Register
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TagihanUpdatePin"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, txtPin.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Pin Benar, Data Akan Tercetak");
                        }
                    }
                   
                }
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, txtKey.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, txtPin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, _bagian));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.Text, txtKet.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }


                if (this.Caller is Kasir.frmPembayaranTunaiUpdate)
                {
                    this.DialogResult = DialogResult.OK;
                }


                /* if (this.Caller is Penjualan.frmNotaJualBrowser)
                 {
                     using (Database db = new Database())
                     {
                         DataTable dt = new DataTable();
                         db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                         db.Commands[0].Parameters.Add(new Parameter("@DOHeaderID", SqlDbType.UniqueIdentifier, _RowID));
                         dt = db.Commands[0].ExecuteDataTable();
                         db.Commands[0].ExecuteNonQuery();

                         MessageBox.Show("DO sudah diACC, silahkan insert kembali di Browse Nota");
                     }

                 }

                 if (this.Caller is Penjualan.frmNotaReturJualBrowse)
                 {

                     using (Database db = new Database())
                     {
                         DataTable dt = new DataTable();
                         db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE_RowID"));
                         db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                         db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtPin.Text.Substring(0, 6)));
                         db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                         dt = db.Commands[0].ExecuteDataTable();
                         db.Commands[0].ExecuteNonQuery();

                         MessageBox.Show("Retur sudah diACC, silahkan insert kembali di Browse Nota Retur");
                     }

                 }



                 

                 //if (GlobalVar.pinResult)
                 //{
                 //    using (Database db = new Database())
                 //    {

                 //        db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                 //        db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, _modulId));
                 //        db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, _MingguKe));
                 //        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime2, _tanggal));
                 //        db.Commands[0].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, txtKey.Text));
                 //        db.Commands[0].Parameters.Add(new Parameter("@PINEntered", SqlDbType.VarChar, txtPin.Text));
                 //        db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, _periode));
                 //        db.Commands[0].ExecuteDataTable();

                 //    }

                 //} */

                this.Close();

            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
        }


        private void frmPinFinance_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Register.frmRegisterBrowser)
            {
                Register.frmRegisterBrowser frmCaller = (Register.frmRegisterBrowser)this.Caller;
                frmCaller.RefreshHeader(frmCaller.rangeDateBox1.FromDate.Value, frmCaller.rangeDateBox1.ToDate.Value);
            }
            //if (this.Caller is Penjualan.frmNotaJualBrowser)
            //{
            //    Penjualan.frmNotaJualBrowser frmCaller = (Penjualan.frmNotaJualBrowser)this.Caller;
            //    frmCaller.RefreshDataDO();

            //}
        }

    }
}
