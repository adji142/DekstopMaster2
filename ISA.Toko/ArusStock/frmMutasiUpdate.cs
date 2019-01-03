using System;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;

namespace ISA.Toko.ArusStock
{
    public partial class frmMutasiUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _NomorMutasi, _type;

        int iNomor;

        string docNoDO = "NOMOR_MUTASI";


        public void RefreshNoMutasi()
        {
            txtNomorMutasi.Text = _NomorMutasi;
            txtNomorMutasi.Refresh();
        }

        public frmMutasiUpdate()
        {
            InitializeComponent();
        }

        public frmMutasiUpdate(Form caller)
        {
            formMode = enumFormMode.New;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmMutasiUpdate(Form caller,Guid rowID)
        {
            formMode=enumFormMode.Update;
            this.Caller=caller;
            _rowID=rowID;
            InitializeComponent();
        }

        private void frmUpdateMutasiHeader_Load(object sender, EventArgs e)
        {
            //cmbType.Items.Add("Tunggal");
            cmbType.Items.Add("Seimbang");
            cmbType.SelectedItem = "Seimbang";
            cmbType.Enabled = false;
            txtTglMutasi.Focus();
            switch (formMode)
            {
                case enumFormMode.Update:
                    try
                        {

                        DataTable dt=new DataTable();
                        using (Database db = new Database())
                            {

                            db.Commands.Add(db.CreateCommand("usp_Mutasi_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_rowID));
                            dt=db.Commands[0].ExecuteDataTable();
                            }
                        if(dt.Rows.Count>0)
                            {
                            txtNomorMutasi.Text =Tools.isNull(dt.Rows[0]["NomorMutasi"], "").ToString();
                            txtKeterangan.Text =Tools.isNull(dt.Rows[0]["KeteranganMutasi"], "").ToString();
                            txtTglMutasi.DateValue=(DateTime)dt.Rows[0]["TglMutasi"];
                            _type=Tools.isNull(dt.Rows[0]["TipeMutasi"], "").ToString();

                            //if (string.Compare(_type, "T") != 0)
                            //    cmbType.SelectedItem = "Seimbang";
                            //else
                            //    cmbType.SelectedItem = "Tunggal";
                            }
                        }
                    catch(System.Exception ex)
                        {
                        Error.LogError(ex);
                        }
                    break;

                case enumFormMode.New:
                    try
                    {
                        DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                        int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                        iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                        string depan = Tools.GeneralInitial();
                        string belakang = dtNum.Rows[0]["Belakang"].ToString();
                        iNomor++;

                        txtNomorMutasi.ReadOnly = true;
                        _NomorMutasi = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                        dtNum.Dispose();
                        RefreshNoMutasi();
                        txtTglMutasi.DateValue = DateTime.Now;
                        cmbType.SelectedItem = "Seimbang";
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Keterangan tidak boleh kosong");
                txtKeterangan.Focus();
                return;
            }
            
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)txtTglMutasi.DateValue;
                        if ((DateTime)txtTglMutasi.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        RefreshNoMutasi();
                        DataTable dtNum_ = Tools.GetGeneralNumerator(docNoDO);
                        int lebar_ = int.Parse(dtNum_.Rows[0]["Lebar"].ToString());
                        int iNomor_ = int.Parse(dtNum_.Rows[0]["Nomor"].ToString());
                        string depan_ = Tools.GeneralInitial();
                        string belakang_ = dtNum_.Rows[0]["Belakang"].ToString();
                        iNomor_++;
                        string strNoMutasi = Tools.FormatNumerator(iNomor_, lebar_, depan_, belakang_);
                        txtNomorMutasi.Text = strNoMutasi;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Mutasi_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@NomorMutasi", SqlDbType.VarChar,strNoMutasi));
                            db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar,Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMutasi", SqlDbType.DateTime,txtTglMutasi.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KeteranganMutasi", SqlDbType.VarChar,txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LAudit", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TipeMutasi", SqlDbType.VarChar,cmbType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan_));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang_));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor_));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar_));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                            db.Dispose();
                            dtNum_.Dispose();
                            txtKeterangan.Text = "";
                            iNomor++;
                           
                            _NomorMutasi = Tools.FormatNumerator(iNomor, lebar_, depan_, belakang_);
                            RefreshNoMutasi();

                            this.DialogResult=DialogResult.OK;
                            CloseForm();
                            this.Close();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)txtTglMutasi.DateValue;
                        if ((DateTime)txtTglMutasi.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        using (Database db = new Database())
                        {
                            //_rowID = ;

                            db.Commands.Add(db.CreateCommand("usp_Mutasi_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMutasi", SqlDbType.DateTime, txtTglMutasi.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KeteranganMutasi", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TipeMutasi", SqlDbType.VarChar,cmbType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            CloseForm();
                            cmdClose.PerformClick();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    
                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CloseForm();
            this.Close();
        }

        private void txtKeterangan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSave.PerformClick();
            }
        }

        private void frmUpdateMutasiHeader_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMutasi)
                {
                    frmMutasi frmCaller = (frmMutasi)this.Caller;
                    frmCaller.RefreshDataMutasi();
                    frmCaller.FindHeader("RowID", _rowID.ToString());
                }
            }
        }

        private void txtTglMutasi_KeyPress(object sender, KeyPressEventArgs e)
            {
            if(e.KeyChar==13)
                {
                cmbType.Focus();
                }
            }
    }
}
