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
    public partial class frmBukaGiroDetailUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update, Pencairan };
        enumFormMode formMode;
        Guid _rowIDBBK,_rowIDGiroIn,_rowIDBank,_GiroID;
        string _Penerima, _BankID, _bbkRecID, _noBBK, _namaBank, _NoGiro, _CairTolak, _VTA, _kepada, _keperluan, _NoPerkiraan,_GC;
        double _nominal;
        DateTime _TglGiro, _TglJTempo, _TglCair, _TglBBK;
        Boolean _isFromBrowse;

        public frmBukaGiroDetailUpdate()
        {
            InitializeComponent();
        }

        public frmBukaGiroDetailUpdate(Form caller, Guid RowIDBBK,string Penerima, string bankID,Boolean isFromBrowse, DateTime tglBBK)
        {
            _rowIDBBK = RowIDBBK;
            _Penerima = Penerima;
            _BankID = bankID;
            _isFromBrowse = isFromBrowse;           
            formMode = enumFormMode.New;
            _TglBBK = tglBBK;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmBukaGiroDetailUpdate(Form caller, Guid RowIDBBK, Guid RowIDGiroIn, Guid GiroID, string Penerima, string bankID, Boolean isFromBrowse, DateTime tglBBK)
        {
            _rowIDBBK = RowIDBBK;
            _Penerima = Penerima;
            _rowIDGiroIn = RowIDGiroIn;
            _GiroID = GiroID;
            _BankID = bankID;
            _TglBBK = tglBBK;
            _isFromBrowse = isFromBrowse;
            formMode = enumFormMode.Update;
            this.Caller = caller;
            InitializeComponent();
        }
        public frmBukaGiroDetailUpdate(Form caller, Guid RowIDBBK, Guid RowIDGiroIn, Guid GiroID, string Penerima, string bankID, Boolean isFromBrowse, DateTime tglBBK,int flag)
        {
            _rowIDBBK = RowIDBBK;
            _Penerima = Penerima;
            _rowIDGiroIn = RowIDGiroIn;
            _GiroID = GiroID;
            _BankID = bankID;
            _TglBBK = tglBBK;
            _isFromBrowse = isFromBrowse;
            formMode = enumFormMode.Pencairan;
            this.Caller = caller;
            InitializeComponent();
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetInfoBank()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Bank_LIST"));

                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, _BankID));
                dt = db.Commands[0].ExecuteDataTable();
                _rowIDBank = (Guid)dt.Rows[0]["RowID"];
                _namaBank = dt.Rows[0]["NamaBank"].ToString();
            }



        }

        private void GetInfoBBK()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {

                dt =  Class.BBK.ListBBK(db, _rowIDBBK);                         
                _bbkRecID = dt.Rows[0]["bbkRecordID"].ToString();
                _noBBK = dt.Rows[0]["NoBBK"].ToString();
                
            }


            
        }
        

        private void AddGiroInternal()
        {
            GetInfoBank();
            GetInfoBBK();

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                _rowIDGiroIn = Guid.NewGuid();
                _GiroID = Guid.NewGuid();
                string GiroRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                string IndRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                

                if (rdoGiro.Checked)
                {
                    _GC = "G";
                }
                else if (rdoCheque.Checked)
                {
                    _GC = "C";
                }

                if (cbCT.Text == "T")
                    GiroRecID = GiroRecID.Trim() + "T";

                _NoGiro = txtNo.Text;
                _CairTolak = cbCT.Text;
                _VTA = txtMU.Text;
                _nominal = ntbNominal.GetDoubleValue;
                _kepada = txtPenerima.Text;
                _keperluan = txtUraian.Text;
                _NoPerkiraan = txtNoPerk.Text;

                db.BeginTransaction();
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_INSERT"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                db.Commands[0].Parameters.Add(new Parameter("@BBKID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                db.Commands[0].Parameters.Add(new Parameter("@BBKRecID", SqlDbType.VarChar, _bbkRecID));
                db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, _namaBank));
                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, _BankID));
                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                db.Commands[0].Parameters.Add(new Parameter("@GiroRecID", SqlDbType.VarChar, GiroRecID));
                db.Commands[0].Parameters.Add(new Parameter("@IndRecID", SqlDbType.VarChar, IndRecID));
                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@GC", SqlDbType.VarChar, _GC));
                db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, _NoGiro));
                db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, dbTglGiro.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@TglJth", SqlDbType.DateTime, dbTglJTTempo.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, _CairTolak));
                db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, dbTglCair.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, _VTA));
                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, _kepada));
                db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, _keperluan));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerkiraan));                
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));                              
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, _CairTolak));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BankDetail_INSERT"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _GiroID));
                db.Commands[0].Parameters.Add(new Parameter("@LinkTransferBankID", SqlDbType.UniqueIdentifier, Guid.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _rowIDBank));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, GiroRecID));
                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _BankID));
                db.Commands[0].Parameters.Add(new Parameter("@RegID", SqlDbType.VarChar, _bbkRecID));
                db.Commands[0].Parameters.Add(new Parameter("@TglTran", SqlDbType.DateTime, dbTglGiro.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, _noBBK));
                db.Commands[0].Parameters.Add(new Parameter("@JnsTran", SqlDbType.VarChar, "BBK"));
                db.Commands[0].Parameters.Add(new Parameter("@NoBGCH", SqlDbType.VarChar, _NoGiro));
                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, _keperluan));
                db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, _VTA));
                db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, 0));
                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, _nominal));
                db.Commands[0].Parameters.Add(new Parameter("@TglBank", SqlDbType.DateTime, dbTglGiro.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@TglRK", SqlDbType.DateTime, dbTglCair.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@LinkRK", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, string.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerkiraan));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBank));                
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();
            }
        }


        private void UpdateGiroInternal()
        {
            

            if (rdoGiro.Checked)
            {
                _GC = "G";
            }
            else if (rdoCheque.Checked)
            {
                _GC = "C";
            }

    
            using(Database db = new Database(GlobalVar.DBFinance))
            {
                db.BeginTransaction();
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                db.Commands[0].Parameters.Add(new Parameter("@GC", SqlDbType.VarChar, _GC));
                db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, txtNo.Text));
                db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, dbTglGiro.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@TglJth", SqlDbType.DateTime, dbTglJTTempo.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, cbCT.Text));
                db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, dbTglCair.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, ntbNominal.GetDoubleValue));
                db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, _Penerima));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, cbCT.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, _Penerima));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BankDetail_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _GiroID));
                db.Commands[0].Parameters.Add(new Parameter("@TglTran", SqlDbType.DateTime, dbTglGiro.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@NoBGCH", SqlDbType.VarChar, txtNo.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, ntbNominal.GetDoubleValue));
                db.Commands[0].Parameters.Add(new Parameter("@TglRK", SqlDbType.DateTime, dbTglCair.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtUraian.Text));
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

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (dbTglGiro.Text == "")
            {
                errorProvider1.SetError(dbTglGiro, "Tanggal Giro Harus Diisi");
                valid = false;
            }

            if (dbTglCair.Text == "")
            {
                errorProvider1.SetError(dbTglCair, "Tanggal Cair Harus Diisi");
                valid = false;
            }
            if (dbTglJTTempo.Text == "")
            {
                errorProvider1.SetError(dbTglJTTempo, "Tanggal Jatuh Tempo Harus Diisi");
                valid = false;
            }
            if (txtNo.Text == "")
            {
                errorProvider1.SetError(txtNo, "Nomor Giro Harus Diisi");
                valid = false;
            }
            if (ntbNominal.Text == "" || ntbNominal.Text == "0")
            {
                errorProvider1.SetError(ntbNominal, "Nominal Giro Harus Diisi");
                valid = false;
            }
            if (cbCT.Text == "" || (cbCT.Text != "C" && cbCT.Text != "T"))
            {
                errorProvider1.SetError(cbCT, "Tanggal Giro Harus Diisi");
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

            

            try
            {

                if (MessageBox.Show("Data Sudah Benar ?","",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                if ((DateTime)dbTglJTTempo.DateValue < _TglBBK)
                {
                    MessageBox.Show("Tanggal Jatuh Tempo Tidak Boleh Kurang Dari " + String.Format("{0:dd-MMM-yyy}", _TglBBK));
                    dbTglJTTempo.Focus();
                    return;
                }
                if ((DateTime)dbTglCair.DateValue < _TglBBK)
                {
                    MessageBox.Show("Tanggal Cair Tidak Boleh Kurang Dari " + String.Format("{0:dd-MMM-yyy}", _TglBBK));
                    dbTglCair.Focus();
                    return;
                }
                switch (formMode)
                {
                case enumFormMode.New:
                        AddGiroInternal();
                        string newNumber = Numerator.BookNumerator("GIROIN");
                        this.Close();
                	break;
                case enumFormMode.Update:
                    UpdateGiroInternal();
                    Numerator.BookNumerator("GIROIN");
                    this.Close();
                        break;
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetInfoGiroInternal()
        {
            DataTable dt = new DataTable();
            using(Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST_ByRowID"));

                db.Commands[0].Parameters.Add(new Parameter("@RowIDGiroIn", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                dt = db.Commands[0].ExecuteDataTable();
            }

            _GC = Tools.isNull(dt.Rows[0]["GC"], "").ToString();
            _TglGiro = (DateTime)Tools.isNull(dt.Rows[0]["TglGiro"], DBNull.Value);
            _TglJTempo = (DateTime)Tools.isNull(dt.Rows[0]["TglJth"], DBNull.Value);
            _TglCair = (DateTime)Tools.isNull(dt.Rows[0]["TglCair"], DBNull.Value);
            _NoPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
            _nominal = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Nominal"], "0"));
            _kepada = Tools.isNull(dt.Rows[0]["Kepada"], "").ToString();
            _NoGiro = Tools.isNull(dt.Rows[0]["NoGiro"], "").ToString();
            _CairTolak = Tools.isNull(dt.Rows[0]["CairTolak"], "").ToString();
             

        }

        private void frmBukaGiroDetailUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {                  
                dbTglGiro.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                dbTglJTTempo.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                //dbTglCair.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                dbTglCair.Text = "";
                dbTglCair.Enabled= false;
                cbCT.Text = "C";
                txtNoPerk.Visible = false;
                txtUraian.Text = "";
                cbCT.Enabled = false;
                
                txtPenerima.Text = _Penerima;
            }
            else if (formMode == enumFormMode.Update)
            {
                GetInfoGiroInternal();
                GetInfoBank();

                if(_GC == "G")
                {
                    rdoGiro.Checked = true;
                    rdoCheque.Checked = false;
                }
                else if (_GC == "C")
                {
                    rdoCheque.Checked = true;
                    rdoGiro.Checked = false;
                }

                dbTglGiro.Text = _TglGiro.ToString("dd-MM-yyyy");
                txtNo.Text = _NoGiro;
                ntbNominal.Text = _nominal.ToString("#,##0");
                txtPenerima.Text = _Penerima;
                dbTglJTTempo.Text = _TglJTempo.ToString("dd-MM-yyyy");
                cbCT.Text = _CairTolak;
                dbTglCair.Text = _TglCair.ToString("dd-MM-yyyy");
                

            }
            else if(formMode == enumFormMode.Pencairan)
            {
                GetInfoGiroInternal();
                GetInfoBank();

                if (_GC == "G")
                {
                    rdoGiro.Checked = true;
                    rdoCheque.Checked = false;
                }
                else if (_GC == "C")
                {
                    rdoCheque.Checked = true;
                    rdoGiro.Checked = false;
                }
                rdoCheque.Enabled = false;
                rdoGiro.Enabled = false;
                dbTglGiro.Text = _TglGiro.ToString("dd-MM-yyyy");
                dbTglCair.Enabled = false;
                txtNo.Text = _NoGiro;
                txtNo.Enabled = false;
                ntbNominal.Text = _nominal.ToString("#,##0");
                ntbNominal.Enabled = false;
                txtPenerima.Text = _Penerima;
                txtPenerima.Enabled = false;
                dbTglJTTempo.Text = _TglJTempo.ToString("dd-MM-yyyy");
                dbTglJTTempo.Enabled = false;
                cbCT.Text = _CairTolak;
                dbTglCair.Text = _TglCair.ToString("dd-MM-yyyy");
                dbTglCair.Enabled = false;
            }
          //  txtNoPerk.Text = "210202090001";
         //   txtMU.Text = "IDR";
           // txtUraian.Text = "HUTANG USAHA HI";
            
        }
        
        private void txtUraian_Validated(object sender, EventArgs e)
        {
            if (txtUraian.Text.Trim() != string.Empty)
            {
                txtNoPerk.Text = "210202090001";
             
            }
            else
            {
                txtNoPerk.Text = "F";
            }    
        }

        private void frmBukaGiroDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_rowIDGiroIn != Guid.Empty)
            {
                if (_isFromBrowse == true)
                {
                    frmBukaGiro frm = new frmBukaGiro();
                    frm = (frmBukaGiro)this.Caller;
                    frm.RefreshBBK(_rowIDBBK);
                    frm.RefreshGiroInternal(_rowIDGiroIn);
                    frm.FindRowGiroIn("RowIDGiroIn", _rowIDGiroIn.ToString());
                }
                else if (_isFromBrowse == false)
                {
                    frmBuktiBankKeluar frm = new frmBuktiBankKeluar();
                    frm = (frmBuktiBankKeluar)this.Caller;
                    frm.RefreshGiroInternalOnDetail(_rowIDGiroIn);
                    frm.FindRowGiroInternalOnDetail("RowIDGiroIn", _rowIDGiroIn.ToString());

                }
                
            }
         
        }
        private void txtNo_Click(object sender, EventArgs e)
        {
            txtNo.Text = Numerator.NumeratorList("GIROIN");
        }
    }
}
