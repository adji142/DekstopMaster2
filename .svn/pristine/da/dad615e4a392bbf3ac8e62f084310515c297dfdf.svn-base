using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;
using ISA.Pin;
using System.Security.Cryptography;

namespace ISA.Finance.Kasir
{
    public partial class frmPenerimaanTunaiPIN : ISA.Finance.BaseForm
    {
        Guid _RowID, _RowIDInden, _RowIDIndenDetail;
        int _Bagian;
        String publickey;
        DateTime _TglKasir;
        DateTime _TglTerima;
        string _RecordIDInden, _RecordIDIndenDetail, _Kasir, _NoBukti, _CollectorID, _NamaCollector, _Acc, _Nominal;
        

        public frmPenerimaanTunaiPIN(Form caller, Guid RowID)
        {
            _RowID = RowID;
            _Bagian = PinId.Bagian.Penjualan;
            Caller = caller;
            InitializeComponent();
        }

        public frmPenerimaanTunaiPIN(Form caller, Guid RowID, String publickey, DateTime tgltrm_)
        {
            _RowID = RowID;
            _Bagian = PinId.Bagian.Penjualan;
            _TglTerima = tgltrm_;
            Caller = caller;
            InitializeComponent();

        }

        private void frmPenerimaanTunaiPIN_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                _RowIDInden = Guid.NewGuid();
                _RowIDIndenDetail = Guid.NewGuid();
                _RecordIDInden = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                //_RecordIDIndenDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                _TglKasir = _TglTerima;     // GlobalVar.DateOfServer;
                _Kasir = SecurityManager.UserName;
                _NoBukti = Numerator.BookNumerator("IND");
                _CollectorID = Tools.isNull(dt.Rows[0]["CollectorID"], "").ToString();
                _NamaCollector = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                _Acc = "";
                _Nominal = dt.Rows[0]["Nominal"].ToString();


                txtPublicKey.Text = Tools.isNull(dt.Rows[0]["PublicKey"], "").ToString();


                if (_NamaCollector == "VIA")
                {

                    DataTable dtAppSet;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PENERIMAAN TUNAI"));
                        dtAppSet = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtAppSet.Rows.Count > 0)
                    {
                        if (dtAppSet.Rows[0]["Value"].ToString() == "1")
                        {
                            MD5 md5Hash = MD5.Create();

                            string _PIN = key.GetMd5Hash(md5Hash, txtPublicKey.Text);
                            txtPin.Text = _PIN;
                        }
                    }

                }
                /*pin dilepas*/
                if (GlobalVar.Gudang == "2808")
                {
                    MD5 md5Hash = MD5.Create();

                    string _PIN = key.GetMd5Hash(md5Hash, txtPublicKey.Text);
                    txtPin.Text = _PIN;
                }
                else
                {
                    MD5 md5Hash = MD5.Create();

                    string _PIN = key.GetMd5Hash(md5Hash, txtPublicKey.Text);
                    txtPin.Text = _PIN;

                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

             MD5 md5Hash = MD5.Create();
            // if (ISA.Pin.key.cek(txtPublicKey.Text, txtPin.Text, _Bagian))
             if (ISA.Pin.key.VerifyMd5Hash(md5Hash, txtPublicKey.Text, txtPin.Text))
            {

               

                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalIsiPin", SqlDbType.DateTime, GlobalVar.DateOfServer));
                        //db.Commands[0].Parameters.Add(new Parameter("@TanggalIsiPin", SqlDbType.DateTime, _TglTerima));
                        db.Commands[0].Parameters.Add(new Parameter("@Pin", SqlDbType.VarChar, txtPin.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDInden", SqlDbType.UniqueIdentifier, _RowIDInden));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
            else
            {
                MessageBox.Show("PIN yang anda masukan salah, silahkan Ulangi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPin.Text = "";
                txtPin.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            Link2Inden();
            Link2BKM();
            FormClose();
            MessageBox.Show("PIN yang anda masukan benar","Informasi",MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void FormClose()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Kasir.frmPenerimaanTunai frmCaller = (Kasir.frmPenerimaanTunai)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow(_RowID);
            }
        }

        private void Link2Inden()
        {
            try
            {
                _RecordIDIndenDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_Link2Inden"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDInden", SqlDbType.UniqueIdentifier, _RowIDInden));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDIndenDetail", SqlDbType.UniqueIdentifier, _RowIDIndenDetail));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordIDInden", SqlDbType.VarChar, _RecordIDInden));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordIDIndenDetail", SqlDbType.VarChar, _RecordIDIndenDetail));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, GlobalVar.DateOfServer));
                    db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, _Kasir));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, _NoBukti));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _CollectorID));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, _NamaCollector));
                    db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@RpCash", SqlDbType.Money, _Nominal));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }            
        }

        private void Link2BKM()
        {
            string _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"].ToString();
            string noBKM = Numerator.BookNumerator("BKM");

            String HRecordID = BKM.GetRecordIDBukti(_RecordIDInden, "IND");

            using (Database db = new Database(GlobalVar.DBName))
            //BKM.AddHeader(db, _RowIDInden, _RowIDInden, BKM.GetRecordIDBukti(_RecordIDInden, "IND"), noBKM, "K", "IND", GlobalVar.DateOfServer, _NamaCollector, "", "", SecurityManager.UserName, "");
            BKM.AddHeader(db, _RowIDInden, _RowIDInden, HRecordID, noBKM, "K", "IND", GlobalVar.DateOfServer, _NamaCollector, "", "", SecurityManager.UserName, "");
            //BKM.AddHeader(db, _RowIDInden, _RowIDInden, HRecordID, noBKM, "K", "IND", _TglTerima, _NamaCollector, "", "", SecurityManager.UserName, "");

            using (Database db = new Database(GlobalVar.DBName))
            //    BKM.AddDetail(db, _RowIDIndenDetail, _RowIDInden, _RecordIDInden, BKM.GetRecordIDBukti(_RecordIDIndenDetail, "IND"), "", "", "", "", _noPerk, "PENERIMAAN BELUM IDENTIFIKASI (" + _NoBukti + ")", _Nominal);            
                BKM.AddDetail(db, _RowIDIndenDetail, _RowIDInden, _RecordIDInden, HRecordID, "", "", "", "", _noPerk, "PENERIMAAN BELUM IDENTIFIKASI (" + _NoBukti + ")", _Nominal);            
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
