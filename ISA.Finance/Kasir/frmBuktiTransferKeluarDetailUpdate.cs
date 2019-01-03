using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmBuktiTransferKeluarDetailUpdate : ISA.Finance.BaseForm
    {

        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _recordIDTransferBank = string.Empty;
        string _recordIDTransferBank2;
        string _recordIDTransferBankDetail = string.Empty;        
        string _NoBBK = string.Empty;
        string _BankID = string.Empty;
        string _nip = string.Empty;
        string _jp = string.Empty;
        string _reff;
        string _noreff;
        string _cmbJU;
        double _Total;
        Guid _rowIDTransferBank,_rowIDTransferBankDetail,_rowIDBank;
        bool _isFromPiutang;

        DataTable dt;
        public frmBuktiTransferKeluarDetailUpdate(Form Caller, string recordIDTransferBank, Guid rowIDTransferBank, double total, bool isFromPiutang, string nip, string jp, string cmbJU, string noreff,string bankID)
        {

            InitializeComponent();
            formMode = enumFormMode.New;
            _rowIDTransferBank = rowIDTransferBank;
            _isFromPiutang = isFromPiutang;
            _nip = nip;
            _jp = jp;
            _recordIDTransferBank2 = recordIDTransferBank;
            _cmbJU = cmbJU;
            _Total = total;
            _noreff = noreff;
            _BankID = bankID ;
            this.Caller = Caller;                     
            
            
        }

        public frmBuktiTransferKeluarDetailUpdate (Form caller, Guid rowIDTransferBankDetail,Guid rowIDTransferBank,string recordIDTransferBank, bool isFromPiutang,string reff, string noreff,string jp)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowIDTransferBankDetail = rowIDTransferBankDetail;
            _rowIDTransferBank = rowIDTransferBank;
            _isFromPiutang = isFromPiutang;
            _reff = reff;
            _jp = jp;
            _noreff = noreff;
            _recordIDTransferBank2 = recordIDTransferBank;
            this.Caller = caller;
        }

        public frmBuktiTransferKeluarDetailUpdate(Form Caller, string recordIDDetail)
        {
            //InitializeComponent();
            //formMode = enumFormMode.Update;
            //_RecordIDDet = recordIDDetail;
            //this.Caller = Caller;
        }
        

        public frmBuktiTransferKeluarDetailUpdate()
        {
            InitializeComponent();
        }

        private void frmBuktiTransferKeluarDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluarShowForUpdate"));
                        db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    cmdNoPerk.Text = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                    cmdUtkPembayaran.Text = Tools.isNull(dt.Rows[0]["AsalTransfer"], "").ToString();
                    _rowIDBank = (Guid)Tools.isNull(dt.Rows[0]["RowIDBank"], "");
                    cmdTglTransfer.Text = ((DateTime)dt.Rows[0]["TglTransfer"]).ToString("dd-MM-yyyy");
                    cmdTransferDari.Text = Tools.isNull(dt.Rows[0]["BankAsal"], "").ToString();
                    cmdTransferKe.Text = Tools.isNull(dt.Rows[0]["KeBank"], "").ToString();
                    cmdTglBank.Text = ((DateTime)dt.Rows[0]["TglBank"]).ToString("dd-MM-yyyy");
                    cmdNmrTransfer.Text = Tools.isNull(dt.Rows[0]["Nomor"], "").ToString();
                    cmdNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
                    
                    

                }

                else if (formMode == enumFormMode.New)
                {
                    dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TransferBank_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBank));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    cmdTglTransfer.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                    cmdTransferDari.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                    _recordIDTransferBank = Tools.isNull(dt.Rows[0]["RecordID"], "").ToString();
                    _NoBBK = Tools.isNull(dt.Rows[0]["NoBBM"], "").ToString();
                    //_rowIDBank = new Guid(Tools.isNull(dt.Rows[0]["RowIDBank"], Guid.Empty ).ToString());
                    _rowIDBank = new Guid(dt.Rows[0]["RowIDBank"].ToString());
                    cmdTglBank.Text = ((DateTime)dt.Rows[0]["TglBBM"]).ToString("dd-MM-yyyy");                    
                                        
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUtkPembayaran_Validated(object sender, EventArgs e)
        {
            if(cmdUtkPembayaran.Text.Trim() != string.Empty)
            {
                if (_isFromPiutang == true)
                {
                    try
                    {
                        DataTable dtPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("");
                        lblKeterangan.Text = dtPerkiraan.Rows[0]["uraian"].ToString();
                        cmdNoPerk.Text = dtPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    try
                    {
                        DataTable dtPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("HI11");
                        lblKeterangan.Text = dtPerkiraan.Rows[0]["uraian"].ToString();
                        cmdNoPerk.Text = dtPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                
                lblKeterangan.Visible = true;
            }
            else
            {
                cmdNoPerk.Text = string.Empty;
                lblKeterangan.Text = string.Empty;
                lblKeterangan.Visible = false;
            }            

        }

        private void AddTransferKeluar()
        {
            _rowIDTransferBankDetail = Guid.NewGuid();
            _recordIDTransferBankDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            string titiPerkiraan = cmdNoPerk.Text;
            string asalTransfer = cmdUtkPembayaran.Text;
            DateTime tglTransfer = DateTime.Now.Date;
            string bankAsal = cmdTransferDari.Text;
            string namaBank = cmdTransferKe.Text;
            string nomor = cmdNmrTransfer.Text;
            double nominal = cmdNominal.GetDoubleValue;
            string kodeToko = string.Empty;
            string lokasi = string.Empty;
            string mainTitip = string.Empty;
            string subTitip = string.Empty;
            string mainPiut = string.Empty;
            string subPiut = string.Empty;
            string noPerkiraan = string.Empty;            

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {

                    if (_isFromPiutang == false)
                    {
                        db.BeginTransaction();                        
                        Class.TransferBank.addDetail(db,
                            _rowIDTransferBankDetail,
                            _rowIDTransferBank,
                            _recordIDTransferBankDetail,
                            _recordIDTransferBank,
                            string.Empty,
                            asalTransfer,
                            namaBank,
                            string.Empty,
                            nomor,
                            tglTransfer,
                            nominal.ToString(),
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            _BankID,
                            string.Empty,
                            titiPerkiraan);

                        
                        Class.Bank.AddBankDetail(db,
                            _rowIDTransferBankDetail,
                            Guid.Empty,
                            _NoBBK,
                            nomor,
                            _rowIDBank,
                            _recordIDTransferBank,
                            (DateTime)cmdTglTransfer.DateValue,
                            "BBK",
                            "TRANSFER KE: " + asalTransfer,
                            "IDR",
                            "0",
                            nominal.ToString(),
                            (DateTime)cmdTglBank.DateValue,
                            (DateTime)cmdTglTransfer.DateValue,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            titiPerkiraan,
                            _BankID,
                            _recordIDTransferBankDetail);
                        db.CommitTransaction();

                    }
                    else
                    {
                        db.BeginTransaction();
                        Class.TransferBank.addDetail(db,
                            _rowIDTransferBankDetail,
                            _rowIDTransferBank,
                            _recordIDTransferBankDetail,
                            _recordIDTransferBank,
                            string.Empty,
                            asalTransfer,
                            namaBank,
                            string.Empty,
                            nomor,
                            tglTransfer,
                            nominal.ToString(),
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            _BankID,
                            string.Empty,
                            titiPerkiraan);

                        db.Commands.Clear();
                        Class.TransferBank.UpdatePinjamanPegawai(db, _rowIDTransferBank, _recordIDTransferBank2, asalTransfer);

                        Class.Bank.AddBankDetail(db,
                            _rowIDTransferBankDetail,
                            Guid.Empty,
                            _NoBBK,
                            nomor,
                            _rowIDBank,
                            _recordIDTransferBank,
                            (DateTime)cmdTglTransfer.DateValue,
                            "BBK",
                            "TRANSFER KE: " + asalTransfer,
                            "IDR",
                            "0",
                            nominal.ToString(),
                            (DateTime)cmdTglBank.DateValue,
                            (DateTime)cmdTglTransfer.DateValue,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            titiPerkiraan,
                            _BankID,
                            _recordIDTransferBankDetail);
                        db.CommitTransaction();
               
                        
                    }

                }
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void UpdateTransaksi()
        {
            string titiPerkiraan = cmdNoPerk.Text;
            string asalTransfer = cmdUtkPembayaran.Text;            
            string bankAsal = cmdTransferDari.Text;
            string namaBank = cmdTransferKe.Text;
            string nomor = cmdNmrTransfer.Text;
            double nominal = cmdNominal.GetDoubleValue;
            string kodeToko = string.Empty;
            string lokasi = string.Empty;
            string mainTitip = string.Empty;
            string subTitip = string.Empty;
            string mainPiut = string.Empty;
            string subPiut = string.Empty;
            string noPerkiraan = string.Empty;


            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {

                    if (_isFromPiutang == false)
                    {
                        
                        db.Commands.Clear();
                        db.BeginTransaction();
                        db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                        db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, asalTransfer));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, namaBank));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, nomor));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_BankDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));                        
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBank));                        
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();

                    }
                    else
                    {
                        db.Commands.Clear();
                        db.BeginTransaction();
                        db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                        db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, asalTransfer));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, namaBank));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, nomor));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();


                        db.Commands.Clear();
                        Class.TransferBank.UpdatePinjamanPegawai(db, _rowIDTransferBank,_recordIDTransferBank2, asalTransfer);

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_BankDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDTransferBankDetail));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBank));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();

                    }

                }

                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }            

        }

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (cmdNmrTransfer.Text == "")
            {
                errorProvider1.SetError(cmdNmrTransfer, "Nomor Transfer Harus Diisi");
                valid = false;
            }

            if (cmdNominal.Text == "0")
            {
                errorProvider1.SetError(cmdNominal, "Nominal Harus Diisi");
                valid = false;
            }

            if (cmdUtkPembayaran.Text == "")
            {
                errorProvider1.SetError(cmdUtkPembayaran, "Untuk Pembayaran Harus Diisi");
                valid = false;
            }

            if (cmdTransferKe.Text == "")
            {
                errorProvider1.SetError(cmdTransferKe, "Nama Bank Harus Diisi");
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
                   
           switch (formMode)
                {
                   case enumFormMode.New:

                        AddTransferKeluar();

                   break;
                   case enumFormMode.Update:
                   UpdateTransaksi();
                   break;
                    }
                 
                   
                           
            
        }

        private void frmBuktiTransferKeluarDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_rowIDTransferBankDetail.ToString() != "00000000-0000-0000-0000-000000000000")
            {

                if (this.Caller is Kasir.frmBuktiTransferKeluar)
                {
                    Kasir.frmBuktiTransferKeluar frmCaller = (Kasir.frmBuktiTransferKeluar)this.Caller;

                    if (formMode == enumFormMode.New)
                    {
                        frmCaller.RefreshRowBuktiTransfer(_rowIDTransferBank);
                        frmCaller.RefreshRowBuktiTransferDetail(_rowIDTransferBankDetail);
                        frmCaller.FindRowDetail("RowIDDetail", _rowIDTransferBankDetail.ToString());

                    }
                    else if (formMode == enumFormMode.Update)
                    {
                        frmCaller.RefreshRowBuktiTransfer(_rowIDTransferBank);
                        frmCaller.RefreshRowBuktiTransferDetail(_rowIDTransferBankDetail);
                    }


                }
                else if (this.Caller is Kasir.frmBuktiTransferKeluarUpdate)
                {
                    Kasir.frmBuktiTransferKeluarUpdate frmCaller2 = (Kasir.frmBuktiTransferKeluarUpdate)this.Caller;
                    if (formMode == enumFormMode.New)
                    {
                        frmCaller2.RefreshRowData(_rowIDTransferBankDetail);
                        frmCaller2.FindRowData("RowIDDetail", _rowIDTransferBankDetail.ToString());
                    }
                    else if (formMode == enumFormMode.Update)
                    {
                        frmCaller2.RefreshRowData(_rowIDTransferBankDetail);
                    }

                }

            }
        }                       
        
    
    }
}
