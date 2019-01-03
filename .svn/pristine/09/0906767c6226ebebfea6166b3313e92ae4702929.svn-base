using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmBuktiTransferMasukDetailUpdate : ISA.Toko.BaseForm
    {
        Guid _RowIDTransferBank, _rowIDTransferBankDetail, _rowIDBank;
        string _RecordIDTransferBankDetail, _TitiPerkiraan, _BankID, _NamaBank, _Nomor, _nip, _jp, _RecordIDTransferBank, _cmbJU, _noreff, _NoBBK, _reff, _recordIDTransferBank2;
        DateTime _TglTransfer;
        Double _Nominal, _Total;
        enum enumFormMode { New, Update };
        enumFormMode formMode;


        public frmBuktiTransferMasukDetailUpdate()
        {
            InitializeComponent();
        }

        public frmBuktiTransferMasukDetailUpdate(Form Caller, string RecordIDTransferBank, Guid rowIDTransferBank, string BankID, double total, string nip, string jp, string cmbJU,string noreff)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _RowIDTransferBank = rowIDTransferBank;           
            _nip = nip;
            _jp = jp;
            _recordIDTransferBank2 = RecordIDTransferBank;
            _cmbJU = cmbJU;
            _Total = total;
            _BankID = BankID;
            _noreff = noreff;
            this.Caller = Caller;
        }


        public frmBuktiTransferMasukDetailUpdate(Form caller, Guid rowIDTransferBankDetail, Guid rowIDTransferBank, string recordIDTransferBank)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowIDTransferBankDetail = rowIDTransferBankDetail;
            _RowIDTransferBank = rowIDTransferBank;
            _recordIDTransferBank2 = recordIDTransferBank;                  
            this.Caller = caller;
        }

        public frmBuktiTransferMasukDetailUpdate(Form caller,Guid rowIDDetail,Guid rowIDHeader,string reff,string jp,string noreff,string recordIDHeader)
        {
            //InitializeComponent();
            //formMode = enumFormMode.Update;
            //_rowIDDet = rowIDDetail;
            //_rowIDHeader = rowIDHeader;            
            //_reff = reff;
            //_jp = jp;
            //_noreff = noreff;
            //_HRecordIDNew = recordIDHeader;
            //this.Caller = caller;
        }

        private void frmBuktiTransferMasukDetailUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
            case enumFormMode.New:

                    DataTable dt1 = new DataTable();

                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TransferBank_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDTransferBank));
                        dt1 = db.Commands[0].ExecuteDataTable();
                    }
                    txtNoPerkiraan.Text = (Perkiraan.GetPerkiraanKoneksiDetail("PK")).Rows[0]["NoPerkiraan"].ToString();
                    dbTglBank.Text = ((DateTime)dt1.Rows[0]["TglBBM"]).ToString("dd-MM-yyyy");
                    dbTglTransfer.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    _RecordIDTransferBank = Tools.isNull(dt1.Rows[0]["RecordID"], "").ToString();
                    _rowIDBank = (Guid)Tools.isNull(dt1.Rows[0]["RowIDBank"], "");
                    _NoBBK = Tools.isNull(dt1.Rows[0]["NoBBM"], "").ToString();
            	break;

            case enumFormMode.Update:

                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_LIST"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                    dt = db.Commands[0].ExecuteDataTable();
                    dbTglBank.Text = ((DateTime)dt.Rows[0]["TglBank"]).ToString("dd/MM/yyyy");
                    txtNamaBank.Text = dt.Rows[0]["KeBank"].ToString().Trim();
                    txtNomorTransfer.Text = dt.Rows[0]["Nomor"].ToString();
                    dbTglTransfer.Text = ((DateTime)dt.Rows[0]["TglTransfer"]).ToString("dd/MM/yyyy");
                    ntbTransfer.Text = dt.Rows[0]["Nominal"].ToString().Trim();
                }

                    break;
            }
        }

        private void InsertBuktiTransferMasuk(Database db)
        {
            try
            {
                _rowIDTransferBankDetail = Guid.NewGuid();
                _RecordIDTransferBankDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                _TitiPerkiraan = txtNoPerkiraan.Text;
                _NamaBank = txtNamaBank.Text;
                _Nomor = txtNomorTransfer.Text;
                _Nominal = ntbTransfer.GetDoubleValue;
                _TglTransfer = (DateTime)dbTglTransfer.DateValue;
                

               
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferMasukDetail_INSERT"));
                    //db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDTransferBank));
                    //db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDTransferBankDetail));
                    //db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, _BankID));
                    //db.Commands[0].Parameters.Add(new Parameter("@TitiPerkiraan", SqlDbType.VarChar, _TitiPerkiraan));
                    //db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@TglTransfer", SqlDbType.DateTime, _TglTransfer));                    
                    //db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, _NamaBank));
                    //db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, _Nomor));
                    //db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _Nominal));
                    //db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@MainPiut", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@SubPiut", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, string.Empty));
                    //db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //db.Commands[0].ExecuteNonQuery();
                   
                    Class.TransferBank.addDetail(db,
                            _rowIDTransferBankDetail,
                            _RowIDTransferBank,
                            _RecordIDTransferBankDetail,
                            _RecordIDTransferBank,
                            string.Empty,
                            string.Empty,
                            _NamaBank,
                            string.Empty,
                            _Nomor,
                            _TglTransfer,
                            _Nominal.ToString(),
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            _BankID,
                            string.Empty,
                            _TitiPerkiraan);

                
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void UpdateTransferMasuk(Database db)
        {
            
            try
            {
                _NamaBank = txtNamaBank.Text;
                _Nomor = txtNomorTransfer.Text;
                _Nominal = ntbTransfer.GetDoubleValue;
                _TglTransfer = (DateTime)dbTglTransfer.DateValue;

                //using (Database db = new Database(GlobalVar.DBFinance))
                //{
                //    db.Commands.Add(db.CreateCommand("usp_BuktiTransferMasukDetail_UPDATE"));
                //    db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));                    
                //    db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, _NamaBank));
                //    db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, _Nomor));
                //    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _Nominal));
                //    db.Commands[0].Parameters.Add(new Parameter("@TglTransfer", SqlDbType.DateTime, _TglTransfer));
                //    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                //    db.Commands[0].ExecuteNonQuery();
                //}

                db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, _NamaBank));
                db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, _Nomor));
                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _Nominal));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
            
        }

        //private void InsertPinjaman(Database db)
        //{


        //    //using (Database db = new Database(GlobalVar.DBFinance))
        //    //{
        //    //    _RecordIDTransferBank = _RecordIDTransferBank.Substring(0, 22) + "1";

        //    //    Class.BBK.AddPinjamanPegawai(
        //    //                             db,
        //    //                             _RowIDTransferBank,
        //    //                             _RecordIDTransferBank,
        //    //                             _nip,
        //    //                             _TglTransfer,
        //    //                             _cmbJU,
        //    //                             _noreff,
        //    //                             string.Empty,
        //    //                             string.Empty,
        //    //                             0,
        //    //                             _Nominal + _Total,
        //    //                             _jp);    
        //    //}

        //    Class.TransferBank.AddPinjamanPegawai(
        //                    db,
        //                    _RowIDTransferBank,
        //                    _recordIDTransferBank2,
        //                    _nip,
        //                    _TglTransfer,
        //                    _cmbJU,
        //                    _noreff,
        //                    string.Empty,
        //                    string.Empty,
        //                    0,
        //                    _Nominal + _Total,
        //                    _jp);
            
        //}

        private void UpdatePinjaman(Database db)
        {

            //using (Database db = new Database(GlobalVar.DBFinance))
            //{
            //    Class.BBK.UpdatePinjamanPegawai(
            //        db,
            //        _RowIDTransferBank,
            //        _RecordIDTransferBank,
            //        string.Empty
            //        );
            //}

            Class.TransferBank.UpdatePinjamanPegawai(db, _RowIDTransferBank, _recordIDTransferBank2, string.Empty);
        }

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (txtNamaBank.Text == "")
            {
                errorProvider1.SetError(txtNamaBank, "Nama Bank Harus Diisi");
                valid = false;
            }

            if (txtNomorTransfer.Text == "")
            {
                errorProvider1.SetError(txtNomorTransfer, "Nomor Transaksi Harus Diisi");
                valid = false;
            }

            if (ntbTransfer.Text == "0")
            {
                errorProvider1.SetError(ntbTransfer, "Nominal Transfer Harus Diisi");
                valid = false;
            }

            if (dbTglTransfer.Text == "")
            {
                errorProvider1.SetError(dbTglTransfer, "Tanggal Transfer Harus Diisi");
                valid = false;
            }

            return valid;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }

            if (MessageBox.Show("Data Sudah Benar ?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }


            using(Database db = new Database(GlobalVar.DBFinance))
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        db.Commands.Clear();
                        db.BeginTransaction();                        
                        InsertBuktiTransferMasuk(db);

                        UpdatePinjaman(db);

                        db.Commands.Clear();
                        Class.Bank.AddBankDetail(db,
                            _rowIDTransferBankDetail,
                            Guid.Empty,
                            _NoBBK,
                            _Nomor,
                            _rowIDBank,
                            _RecordIDTransferBank,
                            _TglTransfer,
                            "BBM",
                            "TRANSFER KE: " + string.Empty,
                            "IDR",
                            _Nominal.ToString(),
                            "0",
                            (DateTime)dbTglBank.DateValue,
                            (DateTime)dbTglTransfer.DateValue,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            _TitiPerkiraan,
                            _BankID,
                            _RecordIDTransferBankDetail);
                        db.CommitTransaction();


                        this.Close();
                        break;

                    case enumFormMode.Update:

                        db.Commands.Clear();
                        db.BeginTransaction();
                        UpdateTransferMasuk(db);
                        UpdatePinjaman(db);

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_BankDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, _Nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBank));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();

                        this.Close();
                        break;
                }

            }

            
        }

       

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuktiTransferMasukDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_rowIDTransferBankDetail.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                if (this.Caller is Kasir.frmBuktiTransferKeluarUpdate)
                {
                    Kasir.frmBuktiTransferKeluarUpdate frmCaller1 = (Kasir.frmBuktiTransferKeluarUpdate)this.Caller;
                    frmCaller1.RefreshRowData(_rowIDTransferBankDetail);
                    if (formMode == enumFormMode.New)
                    {
                        frmCaller1.FindRowData("RowIDDetail",_rowIDTransferBankDetail.ToString());
                    }

                }
            }
        }


     
    }
}
