using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.ArusStock
{
    public partial class frmPeminjamanUpdate : ISA.Trading.BaseForm
    {
        #region "Var & Procedure"

        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID;
        string _recID, _noBukti;

        string docNoDO = "NOMOR_MEMO_PINJAMAN_BARANG";
        int iNomor;

        #endregion
     
        public frmPeminjamanUpdate(Form caller)
        {
            formMode = enumFormMode.New;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmPeminjamanUpdate(Form caller, Guid rowID)
        {
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmPeminjamanUpdate()
        {
            InitializeComponent();
        }

        private void frmPeminjamanUpdate_Load(object sender, EventArgs e)
        {      
           try
           {
           
           using (Database db = new Database())
               {
                   DataTable dtPD = new DataTable();
                   db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                   dtPD = db.Commands[0].ExecuteDataTable();
                   cmbPenSales.ValueMember = "Nama";
                   cmbPenSales.DisplayMember = "Nama";
                   cmbPenSales.DataSource = dtPD;
               }

           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
           
           switch (formMode)
           {
            case enumFormMode.New:
                DateTime tmpDate;
                tglPinjam.DateValue = DateTime.Now;
                tmpDate = (DateTime)tglPinjam.DateValue;
                MaxTglPinjam.DateValue = tmpDate.AddDays(14);
               
                DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                string depan = string.Empty; //Tools.GeneralInitial();
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                iNomor++;
                _noBukti = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                txtNoBukti.Text = _noBukti;
                dtNum.Dispose();

                rbBengkel.Checked = true;
           	    break;

           case enumFormMode.Update:
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Peminjaman_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                        tglPinjam.DateValue = (DateTime)dt.Rows[0]["TglKeluar"];
                        MaxTglPinjam.DateValue = (DateTime)dt.Rows[0]["TglBatas"];
                        cmbPenSales.SelectedValue = dt.Rows[0]["StaffPenjualan"];
                        txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        lookupSales.NamaSales = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                        lookupSales.SalesID = Tools.isNull(dt.Rows[0]["KodeSales"], "").ToString();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            break;
           }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //txtNoBukti.Text = cmbPenSales.Text;
              
               if (lookupSales.SalesID=="")
               {
                   lookupSales.Focus();
                   return;
               }

               if (!valid())
               {
                   MaxTglPinjam.Focus();
                   return;
               }
            switch (formMode)
            {
            case enumFormMode.New:
                   try
                   {
                       GlobalVar.LastClosingDate = (DateTime)tglPinjam.DateValue;
                       if ((DateTime)tglPinjam.DateValue <= GlobalVar.LastClosingDate)
                       {
                           throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                       }
                       this.Cursor = Cursors.WaitCursor;
                        _recID = Tools.CreateFingerPrint();
                        _rowID = Guid.NewGuid();
                       using (Database db = new Database())
                       {


                           DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                           int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                           iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                           iNomor++;
                           string depan = Tools.GeneralInitial();
                           string belakang = dtNum.Rows[0]["Belakang"].ToString();
                       

                       DataTable dt = new DataTable();
                       db.Commands.Add(db.CreateCommand("usp_Peminjaman_INSERT"));

                       db.Commands[0].Parameters.Add(new Parameter("@RowID ", SqlDbType.UniqueIdentifier,_rowID));
                       db.Commands[0].Parameters.Add(new Parameter("@NoBukti ", SqlDbType.VarChar,txtNoBukti.Text));
                       db.Commands[0].Parameters.Add(new Parameter("@RecordID ", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                       db.Commands[0].Parameters.Add(new Parameter("@TglKeluar ", SqlDbType.DateTime,tglPinjam.DateValue));
                       db.Commands[0].Parameters.Add(new Parameter("@TglBatas  ", SqlDbType.DateTime, MaxTglPinjam.DateValue));
                       db.Commands[0].Parameters.Add(new Parameter("@StaffPenjualan", SqlDbType.VarChar,cmbPenSales.Text));
                       db.Commands[0].Parameters.Add(new Parameter("@Catatan ", SqlDbType.VarChar,txtCatatan.Text));
                       db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar,lookupSales.SalesID));
                       db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
                       db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));

                       db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                       db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                       db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                       db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                       db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                       db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                       db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                       db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                       db.BeginTransaction();
                       db.Commands[0].ExecuteNonQuery();
                       db.Commands[1].ExecuteNonQuery();
                       db.CommitTransaction();
                       db.Dispose();

                       
                       this.DialogResult = DialogResult.OK;
                       iNomor++;

                       _noBukti = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                       txtNoBukti.Text = _noBukti;

                       lookupSales.SalesID = "";
                       lookupSales.NamaSales = "";
                       txtCatatan.Text = "";

                       this.Close();
                       }
                       
                   }
                   catch (System.Exception ex)
                   {
                       Error.LogError(ex);
                   }
                   finally
                   {
                       this.Cursor = Cursors.Default;
                   }
            	break;

            case enumFormMode.Update:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)tglPinjam.DateValue;
                        if ((DateTime)tglPinjam.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                     this.Cursor = Cursors.WaitCursor;
                     using (Database db = new Database())
                     {
                         DataTable dt = new DataTable();
                         db.Commands.Add(db.CreateCommand("usp_Peminjaman_UPDATE"));
                         db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_rowID));
                         db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, tglPinjam.DateValue));
                         db.Commands[0].Parameters.Add(new Parameter("@TglBatas", SqlDbType.DateTime, tglPinjam.DateValue));
                         db.Commands[0].Parameters.Add(new Parameter("@StaffPenjualan", SqlDbType.VarChar, cmbPenSales.Text));
                         db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar,lookupSales.SalesID));
                         db.Commands[0].Parameters.Add(new Parameter("@Catatan",SqlDbType.VarChar,txtCatatan.Text));
                         db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        
                         db.Commands[0].ExecuteNonQuery();
                        
                         this.DialogResult = DialogResult.OK;
                         cmdClose.PerformClick();
                     }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                                             
                    
                break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPeminjamanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPeminjaman)
                {
                    ArusStock.frmPeminjaman frmCaller = (ArusStock.frmPeminjaman)this.Caller;
                    frmCaller.RefreshHeader();
                    frmCaller.FindHeader("RowID", _rowID.ToString());
                }
            }
        }

        private void txtCatatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                cmdSave.PerformClick();
            }
        }

        private void tglPinjam_Leave(object sender, EventArgs e)
        {
            DateTime tmpDate;
          
            tmpDate = (DateTime)tglPinjam.DateValue;
            MaxTglPinjam.DateValue = tmpDate.AddDays(14);
            
           
            
        }

        private void lookupSales_Leave(object sender, EventArgs e)
            {
            if (lookupSales.NamaSales=="")
            {
            lookupSales.SalesID="";
            }
            }

        private void MaxTglPinjam_Validating(object sender, CancelEventArgs e)
        {

            if (!valid())
            {
                MaxTglPinjam.Focus();
                return;
            }
        }

        private bool valid()
        {
            bool val;
            val = true;

            DateTime tmpDate;
            DateTime maxDate;
            tmpDate = (DateTime)tglPinjam.DateValue;
            maxDate = tmpDate.AddDays(14);

            //if (MaxTglPinjam.DateValue > maxDate.Date)
            //{
            //    errorProvider1.SetError(MaxTglPinjam, "Maksimal Peminjaman adalah 14 hari");
                
            //    val = false;
            //}

            if (MaxTglPinjam.DateValue<tglPinjam.DateValue  )
            {
                errorProvider1.SetError(MaxTglPinjam, "Tanggal Penembalian Lebih Kecil Dari tanggal Pinjam");
                
                val = false;
            }


            return val;
        }

        private void rbSales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSales.Checked)
            {
                txtNoPol.Text = string.Empty;
                txtNoPol.Enabled = false;
                txtNoPol.ReadOnly = true;
            }
        }

        private void rbBengkel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBengkel.Checked)
            {
                txtNoPol.Enabled = true;
                txtNoPol.ReadOnly = false;
            }
        }

        private void txtNoPol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNoPol.Text != "")
                {
                    SearchNoPol();
                }
                else
                {
                    txtNoPol.Text = string.Empty;
                }
            }
        }

        private void SearchNoPol()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bklCust_Search"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNoPol.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtNoPol.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                    }
                    else
                    {
                        ShowDialogForm(txtNoPol.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            ISA.Trading.Controls.frmLookupSpm ifrmDialog = new ISA.Trading.Controls.frmLookupSpm(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtNoPol.Focus();
            }
        }

        private void GetDialogResult(ISA.Trading.Controls.frmLookupSpm dialogForm)
        {
            txtNoPol.Text = dialogForm.nopol;
        }

    }
}
