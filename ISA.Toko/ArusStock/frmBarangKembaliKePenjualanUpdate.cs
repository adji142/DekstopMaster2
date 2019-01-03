using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Master;
using System.Data.SqlTypes;

namespace ISA.Toko.ArusStock
{
    public partial class frmBarangKembaliKePenjualanUpdate : ISA.Toko.BaseForm
    {


#region "Var & Function or Procedure"
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID;
        string _noBukti;
        DateTime _TglKembaliGudang;
        string ada;
        string docNoDO = "NOMOR_BUKTI_PENGEMBALIAN_BARANG";
        int iNomor;


        public frmBarangKembaliKePenjualanUpdate(Form caller,Guid RowID)
        {
            formMode = enumFormMode.Update;
            _rowID = RowID;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmBarangKembaliKePenjualanUpdate(Form caller)
        {
            formMode = enumFormMode.New;
            this.Caller = caller;
            InitializeComponent();
        }

#endregion
        public frmBarangKembaliKePenjualanUpdate()
        {
            InitializeComponent();
        }

        private void frmBarangKembaliKePenjualanUpdate_Load(object sender, EventArgs e)
        {
          switch (formMode)
          {
          case enumFormMode.New:
               try
               {
                   tglKembali.DateValue = DateTime.Now;

                   DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                   int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                   iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                   string depan = string.Empty; //Tools.GeneralInitial();
                   string belakang = dtNum.Rows[0]["Belakang"].ToString();
                   iNomor++;

                  _noBukti = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                  txtNoPengembalian.Text = _noBukti;
                   dtNum.Dispose();
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

                       db.Commands.Add(db.CreateCommand("usp_Pengembalian_LIST"));
                       db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                       dt = db.Commands[0].ExecuteDataTable();

                       if (dt.Rows.Count > 0)
                       {
                           lookupSales.NamaSales = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                           lookupSales.SalesID = Tools.isNull(dt.Rows[0]["KodeSales"], "").ToString();
                           txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                           txtNoPengembalian.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                           tglKembali.DateValue = (DateTime)dt.Rows[0]["TglKembaliPenjualan"];
                           
                           ada="";
                           ada=Tools.isNull(dt.Rows[0]["TglKembaliGudang"], "").ToString();
                             if (ada!="")
                             {
                             _TglKembaliGudang=(DateTime)dt.Rows[0]["TglKembaliGudang"];// Convert.ToDateTime(Dates);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupSales.SalesID=="")
            {
            lookupSales.Focus();
            return;
            }

            switch (formMode)
            {
            case enumFormMode.New:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)tglKembali.DateValue;
                        if ((DateTime)tglKembali.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                       
                        using (Database db = new Database())
                        {


                            DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                            int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                            //int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                            string depan = Tools.GeneralInitial();
                            string belakang = dtNum.Rows[0]["Belakang"].ToString();


                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Pengembalian_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@RowID ", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoPengembalian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKembaliPj", SqlDbType.DateTime, tglKembali.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKembaliGdg", SqlDbType.DateTime,SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan ", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
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
                            txtNoPengembalian.Text = _noBukti;

                           lookupSales.SalesID = "";
                            lookupSales.NamaSales = "";
                            txtCatatan.Text = "";
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pengembalian_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglPengembalianPJ", SqlDbType.DateTime, tglKembali.DateValue));
                    
                    if (ada!="")
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@TglPengembalianGdg", SqlDbType.DateTime, _TglKembaliGudang));
                    }
                    else
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@TglPengembalianGdg", SqlDbType.DateTime,SqlDateTime.Null));
                    }

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

        private void txtCatatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                cmdSave.PerformClick();
            }
        }

        private void frmBarangKembaliKePenjualanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBarangKembaliKePenjualan)
                {
                    ArusStock.frmBarangKembaliKePenjualan frmcaller = (ArusStock.frmBarangKembaliKePenjualan)this.Caller;
                    frmcaller.RefreshHeader();
                    frmcaller.FindHeader("rowid", _rowID.ToString());
                }
            }
        }

        private void lookupSales_Leave(object sender, EventArgs e)
            {
            if (lookupSales.NamaSales=="")
            {
            lookupSales.SalesID="";
            }
            }
    }
}
