using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;
using System.Data.SqlTypes;

namespace ISA.Toko.ArusStock
{
    public partial class frmAntarGudangUpdate : ISA.Toko.BaseForm
    {

    #region "Var & Procedure"
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _RowID;
        int i;
        string docNoDO = "NOMOR_ANTAR_GUDANG";
        string _NoAG, _KodeCabang, dr1, dr2, ke1, ke2, _Date,_DrGudang,_KeGudang,_KirimTerimaID;
        DateTime _Dates;
        int iNomor;

        private void FillCBO()
            {
            using (Database db = new Database())
                {
                DataTable dtPD=new DataTable();
                DataTable dtPD2=new DataTable();
                DataTable dtPD3=new DataTable();
                DataTable dtPD4=new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Checker_LIST"));
                dtPD=db.Commands[0].ExecuteDataTable();
                dtPD2=db.Commands[0].ExecuteDataTable();
                dtPD3=db.Commands[0].ExecuteDataTable();
                dtPD4=db.Commands[0].ExecuteDataTable();

                cboDrChecker1.ValueMember="FirstName";
                cboDrChecker1.DisplayMember="FirstName";
                cboDrChecker1.DataSource=dtPD;

                cboDrChecker2.ValueMember="FirstName";
                cboDrChecker2.DisplayMember="FirstName";
                cboDrChecker2.DataSource=dtPD2;

                cboKeChecker1.ValueMember="FirstName";
                cboKeChecker1.DisplayMember="FirstName";
                cboKeChecker1.DataSource=dtPD3;

                cboKeChecker2.ValueMember="FirstName";
                cboKeChecker2.DisplayMember="FirstName";
                cboKeChecker2.DataSource=dtPD4;

                }
            }

        public frmAntarGudangUpdate(Form caller,Guid RowID)
        {
            this.Caller = caller;
            _RowID = RowID;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        public frmAntarGudangUpdate(Form caller)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();
        }

    #endregion

        public frmAntarGudangUpdate()
        {
            InitializeComponent();
        }

        private void frmAntarGudangUpdate_Load(object sender, EventArgs e)
        {
            i = 0;
            FillCBO();
            txtDrGudang.Enabled = false;
            txtNoAG.Enabled= false;
            lookupGudang.ByPassCheckInitCab = true;
         switch (formMode)
         {
         case enumFormMode.New:
                 try
                 {
                     tglKirim.DateValue = DateTime.Now;

                     DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                     int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                     iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                     string depan = Tools.GeneralInitial();
                     string belakang = dtNum.Rows[0]["Belakang"].ToString();
                     iNomor++;

                    _NoAG = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                    txtNoAG.Text = _NoAG;
                    txtDrGudang.Text = GlobalVar.Gudang;

                     dtNum.Dispose();

                     tglTerima.Enabled = false;
                     txtPenerima.Enabled = false;
                     cboKeChecker1.Enabled = false;
                     cboKeChecker2.Enabled = false;

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
                DataTable dt = new DataTable();
                
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_RowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        lookupGudang.NamaGudang=Tools.isNull(dt.Rows[0]["NamaGudang"], "").ToString();
                        txtNoAG.Text = Tools.isNull(dt.Rows[0]["NoAG"],"").ToString();
                        _KodeCabang = Tools.isNull(dt.Rows[0]["KodeCabang"], "").ToString();
                        tglKirim.DateValue = (DateTime)dt.Rows[0]["TglKirim"];

                        _Date= Tools.isNull(dt.Rows[0]["TglTerima"],"").ToString();
                        if (_Date == "")
                        {
                            tglTerima.Enabled = true;
                        }
                        else
                        {
                            tglTerima.Enabled = false;
                        }

                        if (string.Compare(_Date,"")!=0)
                        {
                         _Dates = (DateTime)dt.Rows[0]["TglTerima"];
                        
                        }

                        txtDrGudang.Text=_DrGudang=Tools.isNull(dt.Rows[0]["DrGudang"], "").ToString();
                        lookupGudang.GudangID=_KeGudang=Tools.isNull(dt.Rows[0]["KeGudang"], "").ToString();
                        txtPengirim.Text=Tools.isNull(dt.Rows[0]["Pengirim"], "").ToString();
                        txtPenerima.Text=Tools.isNull(dt.Rows[0]["Penerima"], "").ToString();
                        txtCatatan.Text=Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        _KirimTerimaID=Tools.isNull(dt.Rows[0]["KirimTerimaID"], "").ToString();
                        cboDrChecker1.SelectedValue = dr1 = Tools.isNull(dt.Rows[0]["DrCheck1"], "").ToString();
                        cboDrChecker2.SelectedValue = dr2 = Tools.isNull(dt.Rows[0]["DrCheck2"], "").ToString();
                        cboKeChecker1.SelectedValue = ke1 = Tools.isNull(dt.Rows[0]["KeCheck1"], "").ToString();
                        cboKeChecker2.SelectedValue = ke2 = Tools.isNull(dt.Rows[0]["KeCheck2"], "").ToString();

                        cboDrChecker1.Text = dr1;
                        cboDrChecker2.Text = dr2;
                        cboKeChecker1.Text = ke1;
                        cboKeChecker2.Text = ke1;

                        if (lookupGudang.GudangID == GlobalVar.Gudang)
                        {
                            //Program KodeGudang = KeGudang  
                            //Gudang Dapat Mengedit Value Terima ,Pengirm
                            i = 0;
                            lookupGudang.Enabled= false;
                            tglKirim.Enabled = false;
                            txtPengirim.Enabled = false;
                            cboDrChecker1.Enabled = false;
                            cboDrChecker2.Enabled = false;
                            tglTerima.DateValue =DateTime.Now;
                        }
                        else
                        {
                            i = 1;
                            tglTerima.Enabled = false;
                            txtPenerima.Enabled = false;
                            cboKeChecker1.Enabled = false;
                            cboKeChecker2.Enabled = false;
                            tglTerima.DateValue = null;
                        } 
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
            if (lookupGudang.GudangID=="")
            {
                lookupGudang.Focus();
                return;
            }
            switch (formMode)
            {
            case enumFormMode.New:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)tglKirim.DateValue;
                        if ((DateTime)tglKirim.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                       
                        using (Database db = new Database())
                        {
                            DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                            int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                            //int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                            string depan = Tools.GeneralInitial();
                            //string belakang = dtNum.Rows[0]["Belakang"].ToString();
                            string belakang = "";

                            _RowID = Guid.NewGuid();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_AntarGudang_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID ", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID ", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@DrGudang ", SqlDbType.VarChar, txtDrGudang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KeGudang ", SqlDbType.VarChar, lookupGudang.GudangID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKirim ", SqlDbType.DateTime, tglKirim.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerima ", SqlDbType.DateTime,SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, txtPengirim.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NoAG", SqlDbType.VarChar, txtNoAG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar,cboDrChecker1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar,cboDrChecker2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar,""));
                            db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar,""));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan ", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NoKendaraan", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaSopir", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, ""));
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

                            MessageBox.Show("Data telah tersimpan");
                            this.DialogResult = DialogResult.OK;
                            iNomor++;

                            _NoAG = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                            txtNoAG.Text = _NoAG;

                            lookupGudang.GudangID = "";
                            lookupGudang.NamaGudang = "";
                            txtCatatan.Text = "";
                            txtPengirim.Text = "";
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

            case enumFormMode.Update:

                    switch (i)
                    {
                    case 1:

                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)tglKirim.DateValue;
                                if ((DateTime)tglKirim.DateValue <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar,lookupGudang.GudangID));
                                    db.Commands[0].Parameters.Add(new Parameter("@DrGudang", SqlDbType.VarChar, _DrGudang));
                                    if (tglKirim.DateValue.HasValue)
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, tglKirim.DateValue));
                                    } 
                                    else
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, SqlDateTime.Null));
                                    }
                                    
                                    db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, txtPengirim.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar, cboDrChecker1.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, cboDrChecker2.Text));

                                    if (_Date!="")
                                    {
                                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, tglTerima.DateValue));
                                    }
                                    else
                                    {
                                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime,SqlDateTime.Null));
                                    }
                                    
                                    db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, txtPenerima.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, ke1));
                                    db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, ke2));
                                    db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, _KirimTerimaID));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                MessageBox.Show("Data telah diUpdate");
                                this.DialogResult = DialogResult.OK;
                                cmdClose.PerformClick();
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

                       
                    case 0:
                        if ((DateTime)tglTerima.DateValue < (DateTime)tglKirim.DateValue)
                        {
                            MessageBox.Show("Tanggal Terima harus lebih besar atau sama dengan tanggal kirim");
                            return;
                        }

                        try
                        {
                            if (tglTerima.DateValue.HasValue)
                            {
                                GlobalVar.LastClosingDate = (DateTime)tglTerima.DateValue;
                                if ((DateTime)tglTerima.DateValue <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                            }

                            this.Cursor = Cursors.WaitCursor;
                            string _IDkirimTerima = string.Empty;
                            if (txtDrGudang.Text != GlobalVar.Gudang)
                            {
                                _IDkirimTerima=txtDrGudang.Text;
                            }else
                            {
                                _IDkirimTerima = _KirimTerimaID;
                            }
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_AntarGudang_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                if (tglTerima.DateValue.HasValue)
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, tglTerima.DateValue));
                                }
                                else
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                                }
                               
                                db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, txtPenerima.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, cboKeChecker1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, cboKeChecker2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, _IDkirimTerima));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.Commands[0].Parameters.Add(new Parameter("@DrGudang", SqlDbType.VarChar, txtDrGudang.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, _KeGudang));
                                db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, tglKirim.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, txtPengirim.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar,dr1));
                                db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, dr2));
                                db.Commands[0].ExecuteNonQuery();
                               
                            }
                            MessageBox.Show("Data telah diUpdate");
                            this.DialogResult = DialogResult.OK;
                            cmdClose.PerformClick();
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
            	break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAntarGudangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmAntarGudang)
                {
                    ArusStock.frmAntarGudang frmcaller = (ArusStock.frmAntarGudang)this.Caller;
                    frmcaller.RefreshHeader();
                    frmcaller.RefreshDetail();
                    frmcaller.FindHeader("RowID", _RowID.ToString());
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

        private void lookupGudang_SelectData(object sender, EventArgs e)
        {
            if (Tools.Left(lookupGudang.GudangID.ToString(),2)!= GlobalVar.CabangID)
            {
                MessageBox.Show("Hanya Bisa AntarCabang");
                this.DialogResult = DialogResult.OK;
                lookupGudang.GudangID = "";
                lookupGudang.NamaGudang = "";
                lookupGudang.Focus();
                return;
            }

            if (lookupGudang.GudangID == GlobalVar.Gudang)
            {
                MessageBox.Show("Tujuan Dan Asal Gudang tidak boleh Sama");
                this.DialogResult = DialogResult.OK;
                lookupGudang.GudangID = "";
                lookupGudang.NamaGudang = "";
                lookupGudang.Focus();
                return;
            }
        }

        private void lookupGudang_Leave(object sender, EventArgs e)
            {
            if (lookupGudang.NamaGudang=="")
            {
            lookupGudang.GudangID="";
            }
            }
    }
}
