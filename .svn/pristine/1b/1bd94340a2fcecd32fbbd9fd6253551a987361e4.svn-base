using System;
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
    public partial class frmAntarGudangDetailUpdate : ISA.Toko.BaseForm
    {

    #region "Var & Procedure"
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        int VBefore = 0;
        Guid _RowID,_HeaderID;
        string _TransactionID;
        string _DrGudang;

        public frmAntarGudangDetailUpdate(Form caller,Guid RowID, Guid HeaderID)
        {
            this.Caller = caller;
            _RowID = RowID;
            formMode = enumFormMode.Update;
            InitializeComponent();
            _HeaderID = HeaderID;
        }

        public frmAntarGudangDetailUpdate(Form caller,Guid RowID,string RecordID)
        {
            this.Caller = caller;
            _HeaderID = RowID;
            _TransactionID = RecordID;

            formMode = enumFormMode.New;
            InitializeComponent();
        }


    #endregion

        public frmAntarGudangDetailUpdate()
        {
            InitializeComponent();
        }

        private void frmAntarGudangDetailUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
            case enumFormMode.New:
                txtQtyTerima.Enabled=false;
            	break;
            case enumFormMode.Update:
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        lookupStock.NamaStock = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                        lookupStock.BarangID = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                        txtQtyDO.Text = Tools.isNull(dt.Rows[0]["QtyDO"], "0").ToString();
                        txtQtyKirim.Text = Tools.isNull(dt.Rows[0]["QtyKirim"], "0").ToString();
                        txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        txtQtyTerima.Text = Tools.isNull(dt.Rows[0]["QtyTerima"], "0").ToString();
                        _DrGudang = Tools.isNull(dt.Rows[0]["DrGudang"], "").ToString();
                        VBefore = txtQtyKirim.GetIntValue;
                    }

                    if (string.Compare(_DrGudang, GlobalVar.Gudang) != 0)
                    {
                        txtQtyTerima.Text = txtQtyKirim.Text;
                        lookupStock.Enabled = false;
                        //txtQtyDO.ReadOnly = true;
                        txtQtyDO.Enabled = false;
                        //txtQtyKirim.ReadOnly = true;
                        txtQtyKirim.Enabled = false;
                        //txtQtyTerima.ReadOnly = true;
                        txtQtyTerima.Enabled  = false;
                    }
                    else
                    {
                        //txtQtyTerima.ReadOnly = true;
                        txtQtyTerima.Enabled  = false;
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
          switch (formMode)
          {
          case enumFormMode.New:
                  try
                      {    
                          this.Cursor = Cursors.WaitCursor;
                          if (lookupStock.BarangID=="")
                          {
                              lookupStock.Focus();
                              return;
                          }

                        if (txtQtyDO.GetIntValue<=0 || txtQtyKirim.GetIntValue<0)
                        {
                            txtQtyDO.Focus();
                            return;
                        }

#region "Stok Minus Lock New"
                       
                        using (Stock st = new Stock())
                        {
                            st.AddList(lookupStock.BarangID, "", txtQtyKirim.GetIntValue);
                           // pass = st.Pass();
                            if (!st.Pass())
                            {
                                MessageBox.Show("Tidak Bisa Proses,\n nilai transaksi menyebabkan stok minus! ", "Warning");
                                st.ReportMinus();

                                if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    st.PrintOutMinus();
                                }

                                txtQtyKirim.Focus();
                                txtQtyKirim.SelectAll();
                                return;
                            }
                        }
#endregion
                        
                          using (Database db = new Database())
                          {
                              DataTable dt = new DataTable();
                              db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_Insert"));
                              db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                              db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier,_HeaderID));
                              db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                              db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar,_TransactionID));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, txtQtyDO.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyKirim", SqlDbType.Int, txtQtyKirim.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, txtQtyTerima.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                              db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar,txtCatatan.Text ));
                              db.Commands[0].Parameters.Add(new Parameter("@Ongkos", SqlDbType.Int, 0));
                              db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                              dt = db.Commands[0].ExecuteDataTable();

                              if (dt.Rows.Count > 0)
                              {
                                  MessageBox.Show("Kode barang:" + lookupStock.BarangID + " tidak bisa diinput dua kali");
                                  lookupStock.Focus();
                                  return;
                              }

                          }

                          using (Database db = new Database())
                          {
                              db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                              db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                              db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                              db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                              db.Commands[0].ExecuteNonQuery();
                          }
                          this.DialogResult = DialogResult.OK;
                          if (this.DialogResult == DialogResult.OK)
                          {
                              if (this.Caller is frmAntarGudang)
                              {
                                  ArusStock.frmAntarGudang frmcaller = (ArusStock.frmAntarGudang)this.Caller;
                                  frmcaller.RefreshDetail();
                                  frmcaller.FindDetail("RowIDD", _RowID.ToString());
                              }
                          }
                          cmdClose.PerformClick();
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
                          this.Cursor = Cursors.WaitCursor;
#region "Stok Minus Lock Update"
                          if (_DrGudang==GlobalVar.Gudang)
                      {
                          using (Stock st = new Stock())
                          {
                              st.AddList(lookupStock.BarangID, "", txtQtyKirim.GetIntValue - VBefore);
                              // pass = st.Pass();
                              if (!st.Pass())
                              {
                                  MessageBox.Show("Tidak Bisa Proses ", "Warning");
                                  st.ReportMinus();

                                  if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                  {
                                      st.PrintOutMinus();
                                  }

                                  txtQtyKirim.Focus();
                                  txtQtyKirim.SelectAll();
                                  return;
                              }
                          }

                      }
                         



#endregion
                
                          using (Database db = new Database())
                          {
                              DataTable dt = new DataTable();
                              db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_Update"));
                              db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowID));
                              db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, txtQtyDO.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyKirim", SqlDbType.Int, txtQtyKirim.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, txtQtyTerima.GetIntValue));
                              db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                              db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                  			  db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                              dt = db.Commands[0].ExecuteDataTable();
                              if (dt.Rows.Count > 0)
                              {
                                  MessageBox.Show("Kode barang:" + lookupStock.BarangID + " tidak bisa diinput dua kali");
                                  lookupStock.Focus();
                                  return;
                              }
                          }

                          using (Database db = new Database())
                          {
                              db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                              db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                              db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
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

          this.DialogResult = DialogResult.OK;

          if (formMode == enumFormMode.New)
          {
              //MessageBox.Show("Data telah tersimpan");
              lookupStock.NamaStock = "";
              lookupStock.BarangID = "";
              txtCatatan.Text = "";
              txtQtyDO.Text = "0";
              txtQtyKirim.Text = "0";
              txtQtyTerima.Text = "0";
          } 
          else
          {
              cmdClose.PerformClick();
          }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAntarGudangDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmAntarGudang )
                {
                    ArusStock.frmAntarGudang frmcaller = (ArusStock.frmAntarGudang)this.Caller;
                    frmcaller.RefreshDetail();
                    frmcaller.FindDetail("RowIDD", _RowID.ToString());
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

        //private void txtQtyDO_Leave(object sender, EventArgs e)
        //{
        //    txtQtyKirim.Text = txtQtyDO.Text;
        //}

        private void lookupStock_Leave(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    if (lookupStock.NamaStock == "")
                    {
                        lookupStock.BarangID = "";
                    }
                    break;
                case enumFormMode.Update:
                    
                    break;

            }
        }

        private void txtQtyDO_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
