using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.ArusStock
{
    public partial class frmPeminjamanDetailUpdate : ISA.Toko.BaseForm
    {
        #region "Var & Procedure"
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID,_headerID;
        string  _TransactionID;
        int _qtyKeluarGudang;


        public frmPeminjamanDetailUpdate(Form caller, Guid rowIDPenjualan, string recordIDPenjualan)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            _headerID = rowIDPenjualan;
            _TransactionID = recordIDPenjualan;
            
            InitializeComponent();
        }

        public frmPeminjamanDetailUpdate(Form caller, Guid rowID, Guid rowIDPenjualan)
        {
            this.Caller = caller;
            _rowID = rowID;
            _headerID = rowIDPenjualan;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }
        #endregion

        public frmPeminjamanDetailUpdate()
        {
            InitializeComponent();
        }

        private void frmPeminjamanDetailUpdate_Load(object sender, EventArgs e)
        {
          switch (formMode)
          {
          case enumFormMode.New:

          	break;
          case enumFormMode.Update:
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        lookupStock.NamaStock = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                        lookupStock.BarangID = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                        txtQtyPinjam.Text = Tools.isNull(dt.Rows[0]["QtyMemo"], "0").ToString();
                        txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                        txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        _qtyKeluarGudang = Int32.Parse(Tools.isNull(dt.Rows[0]["QtyKeluarGudang"],"0").ToString());

                        
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

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lookupStock.Satuan;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPeminjamanDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPeminjaman)
                {
                    ArusStock.frmPeminjaman frmCaller = (ArusStock.frmPeminjaman)this.Caller;
                    frmCaller.RefreshDetail();
                    frmCaller.FindDetail("RowIDD", _rowID.ToString());
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            if (lookupStock.BarangID=="")
            {
                lookupStock.Focus();
                return;
            }

            if (Convert.ToInt32(txtQtyPinjam.Text)<=0 || txtQtyPinjam.Text=="" )
            {
                txtQtyPinjam.Focus();
                return;
            }


            switch (formMode)
            {
            case enumFormMode.New:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_INSERT"));
                            _rowID = Guid.NewGuid();
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar,_TransactionID));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar,lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, txtQtyPinjam.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar,txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit,0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                           
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode barang: " + lookupStock.BarangID + " tidak bisa diinput dua kali");
                                lookupStock.Focus();
                                return;
                            }

                            this.DialogResult = DialogResult.OK;
                           
                                if (this.Caller is frmPeminjaman)
                                {
                                    ArusStock.frmPeminjaman frmCaller = (ArusStock.frmPeminjaman)this.Caller;
                                    frmCaller.RefreshDetail();
                                    frmCaller.FindDetail("RowIDD", _rowID.ToString());
                                }
                            


                            lookupStock.NamaStock = "";
                            lookupStock.BarangID = "";
                            txtQtyPinjam.Text = "";
                            txtSatuan.Text = "";
                            txtCatatan.Text = "";
                            lookupStock.Focus();
                            //this.DialogResult = DialogResult.OK;


                            //this.Close();
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
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, _qtyKeluarGudang));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int,txtQtyPinjam.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar,txtCatatan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                     
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Kode barang: " + lookupStock.BarangID + " tidak bisa diinput dua kali");
                            lookupStock.Focus();
                            return;
                        }

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
            if (e.KeyChar==13)
            {
                cmdSave.PerformClick();
            }
        }

        private void txtQtyPinjam_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar==13)
            {
            txtCatatan.Focus();
            }
            }

        private void lookupStock_Leave(object sender, EventArgs e)
            {
            if (lookupStock.NamaStock=="")
            {
            lookupStock.BarangID="";
            }
            }
    }
}
