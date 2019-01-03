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


namespace ISA.Toko.LapKpl
{
    public partial class frmTargetSalesBrowserDetailUpdate : ISA.Toko.BaseForm
    {

#region "Function"
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _RowID;
        string _KodeSales;

        public frmTargetSalesBrowserDetailUpdate(Form caller, Guid RowID,string KodeSales)
        {
            this.Caller = caller;
            _RowID = RowID;
            _KodeSales = KodeSales;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        public frmTargetSalesBrowserDetailUpdate(Form caller,string KodeSales)
        {
            this.Caller = caller;
            _KodeSales = KodeSales;
            formMode = enumFormMode.New;
            InitializeComponent();
        }


#endregion
       

        public frmTargetSalesBrowserDetailUpdate()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

           
                LapKpl.frmTargetSalesBrowser frmcaller = (LapKpl.frmTargetSalesBrowser)this.Caller;
                frmcaller.RefreshDataDetail(_KodeSales);
                
                frmcaller.FindDetail(_RowID.ToString());
                string tes = _RowID.ToString();
         
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            double rpBiaya = 0;
            if (txtBiaya.Text.Trim() != "")
            {
                rpBiaya = txtBiaya.GetDoubleValue;
            }

          switch (formMode)
          {
          case enumFormMode.New:
                  try
                  {
                      using (Database db = new Database())
                      {
                          _RowID=Guid.NewGuid();
                          db.Commands.Add(db.CreateCommand("[usp_TargetSales_INSERT]"));
                          db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowID ));
                          db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                          db.Commands[0].Parameters.Add(new Parameter("@Tgltarget", SqlDbType.DateTime, tglTarget.DateValue));
                          db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                          db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, ""));
                          db.Commands[0].Parameters.Add(new Parameter("@Nota_B", SqlDbType.Money,txtNotaB.GetDoubleValue));
                          db.Commands[0].Parameters.Add(new Parameter("@Nota_E", SqlDbType.Money, txtNotaE.GetDoubleValue));
                          db.Commands[0].Parameters.Add(new Parameter("@NToko", SqlDbType.Int,txtToko.GetIntValue));
                          db.Commands[0].Parameters.Add(new Parameter("@NItem", SqlDbType.Int,txtItem.GetIntValue));
                          db.Commands[0].Parameters.Add(new Parameter("@Biaya", SqlDbType.Money,rpBiaya));
                          db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.DateTime,SqlDateTime.Null));
                          db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                          db.Commands[0].ExecuteNonQuery();


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
          	break;
          case enumFormMode.Update:
            try
            {
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_TargetSales_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgltarget", SqlDbType.DateTime, tglTarget.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Nota_B", SqlDbType.Money, txtNotaB.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Nota_E", SqlDbType.Money, txtNotaE.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NToko", SqlDbType.Int, txtToko.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NItem", SqlDbType.Int, txtItem.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Biaya", SqlDbType.Money, txtBiaya.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

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
            break;
          }

          cmdCancel.PerformClick();
        }

        private void frmTargetSalesBrowserDetailUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
            case enumFormMode.New:
                    tglTarget.DateValue = DateTime.Now;
            	break;
            case enumFormMode.Update:
                    try
                    {
                         DataTable dt = new DataTable();

                         using (Database db = new Database())
                         {

                             db.Commands.Add(db.CreateCommand("[usp_TargetSales_LIST]"));
                             db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                             dt = db.Commands[0].ExecuteDataTable();

                             if (dt.Rows.Count > 0)
                             {

                                 tglTarget.DateValue = (DateTime)dt.Rows[0]["Tgltarget"];
                                 txtBiaya.Text = Tools.isNull(dt.Rows[0]["Biaya"], "0").ToString();
                                 txtItem.Text = Tools.isNull(dt.Rows[0]["NItem"], "0").ToString();
                                 txtNotaB.Text = Tools.isNull(dt.Rows[0]["Nota_B"], "0").ToString();
                                 txtNotaE.Text = Tools.isNull(dt.Rows[0]["Nota_E"], "0").ToString();
                                 txtToko.Text = Tools.isNull(dt.Rows[0]["NToko"], "0").ToString();

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

        private bool ValidateInput()
        {
            bool valid = true;

            if (tglTarget.Text.Trim() == "")
            {
                errorProvider1.SetError(tglTarget, "Tanggal harus di isi");
                valid = false;
            }
            if (txtNotaB.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNotaB, "Target Nota B harus di isi");
                valid = false;
            }
            if (txtNotaE.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNotaE, "Target Nota E di isi");
                valid = false;
            }
            if (txtToko.Text.Trim() == "")
            {
                errorProvider1.SetError(txtToko, "Target Toko harus di isi");
                valid = false;
            }
            if (txtItem.Text.Trim() == "")
            {
                errorProvider1.SetError(txtItem, "Terget Item harus di isi");
                valid = false;
            }
            return valid;
        }

      
    }
}
