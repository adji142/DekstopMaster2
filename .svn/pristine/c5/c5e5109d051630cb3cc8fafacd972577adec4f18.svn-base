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
    public partial class frmGiroCairTolakBatal_Header_Update : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };        
        enumFormMode formMode;
        Guid _rowID;

        public frmGiroCairTolakBatal_Header_Update(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;

        }

        public frmGiroCairTolakBatal_Header_Update(Form caller, Guid rowIDHeader)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowIDHeader;
            this.Caller = caller;

        }

        public frmGiroCairTolakBatal_Header_Update()
        {
            InitializeComponent();
        }

        private void LoadDataUpdate()
        {
            DataTable dt = new DataTable();
            using(Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_BBM_GiroTolakCair_ShowForUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            txtTglBBM.Text = Tools.isNull(((DateTime)dt.Rows[0]["TglBBM"]).ToString("dd/MM/yyyy"), "").ToString();
            txtNoBBM.Text = Tools.isNull(dt.Rows[0]["NoBBM"], "").ToString();
            lookupBank1.BankID = Tools.isNull(dt.Rows[0]["BankID"], "").ToString();
            lookupBank1.NamaBank = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
            numGiro.Text = Tools.isNull(dt.Rows[0]["RpGiro"], "").ToString();
            numCair.Text = Tools.isNull(dt.Rows[0]["RpCair"], "").ToString();
            numTolak.Text = Tools.isNull(dt.Rows[0]["RpTolak"], "").ToString();
            txtKasir.Text = Tools.isNull(dt.Rows[0]["Kasir"], "").ToString();
            lookupStafAdm1.Kode = Tools.isNull(dt.Rows[0]["Dibukukan"], "").ToString();
            lookupStafAdm2.Kode = Tools.isNull(dt.Rows[0]["Diketahui"], "").ToString();
            lookupStafAdm3.Kode = Tools.isNull(dt.Rows[0]["Penyetor"], "").ToString();

        }

        private void frmGiroCairTolakBatal_Header_Update_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
            case enumFormMode.New:
                    lblJudul.Text = "TAMBAH DATA";
                    txtTglBBM.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                    txtKasir.ReadOnly = true;
                    txtKasir.Enabled = false;
                    txtKasir.Text = SecurityManager.UserName;
                    numCair.ReadOnly = true;
                    numGiro.ReadOnly = true;
                    numTolak.ReadOnly = true;
            	break;
                case enumFormMode.Update:
                lblJudul.Text = "EDIT DATA";
                LoadDataUpdate();
                txtKasir.ReadOnly = true;
                txtKasir.Enabled = false;               
                numCair.ReadOnly = true;
                numGiro.ReadOnly = true;
                numTolak.ReadOnly = true;
                    break;
            }
        }

        private void AddBBMGiroCairTolakBatal()
        {
          _rowID = Guid.NewGuid();
          string recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
          string noBBM = Numerator.BookNumerator("BBM");
          string bankID = lookupBank1.BankID;
          string diBukukan = lookupStafAdm1.Kode;
          string diKetahui = lookupStafAdm2.Kode;
          string kasir = txtKasir.Text;
          string penyetor = lookupStafAdm3.Kode;
          double nominalGiro = numGiro.GetDoubleValue;
          double nominalCair = numCair.GetDoubleValue;
          double nominalTolak = numTolak.GetDoubleValue;

           try
           {
               using(Database db = new Database(GlobalVar.DBFinance))
               {
                   Class.BBM.AddBBM(db,
                       _rowID,
                       recordID,
                       txtTglBBM.DateValue.Value,
                       noBBM,
                       bankID,
                       diBukukan,
                       diKetahui,
                       kasir,
                       penyetor,
                       nominalGiro,
                       nominalCair,
                       nominalTolak);

                   this.Close();
               }
           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
         
        }

        private void UpdateBBMGiroCairTolakBatal()
        {

            string noBBM = txtNoBBM.Text;
            string bankID = lookupBank1.BankID;
            string diBukukan = lookupStafAdm1.Kode;
            string diKetahui = lookupStafAdm2.Kode;
            string kasir = txtKasir.Text;
            string penyetor = lookupStafAdm3.Kode;
            double nominalGiro = numGiro.GetDoubleValue;
            double nominalCair = numCair.GetDoubleValue;
            double nominalTolak = numTolak.GetDoubleValue;

            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    Class.BBM.UpdateBBM(db,
                        _rowID,                                                                        
                        bankID,
                        diBukukan,
                        diKetahui,                        
                        penyetor);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupBank1.BankID == "" || lookupBank1.BankID == "[CODE]")
            {
                MessageBox.Show("Bank Harus Diisi.");
                lookupBank1.Focus();
                return;
            }
            if (MessageBox.Show("Data Akan Disimpan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if(formMode == enumFormMode.New)
                {
                    DateTime _Tanggal = (DateTime)txtTglBBM.DateValue;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    AddBBMGiroCairTolakBatal();
                }
                else if (formMode ==  enumFormMode.Update)
                {
                    UpdateBBMGiroCairTolakBatal();
                }

                
            }
        }

        private void frmGiroCairTolakBatal_Header_Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_rowID != Guid.Empty)
            {
                if (this.Caller is Kasir.frmGiroCairTolakBatal)
                {
                    Kasir.frmGiroCairTolakBatal frmCaller = (Kasir.frmGiroCairTolakBatal)this.Caller;
                    frmCaller.RefreshBBM();
                    frmCaller.findRowBBM("RowID", _rowID.ToString());
                }
            }
          
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

 


        

    

   


     
    }
}
