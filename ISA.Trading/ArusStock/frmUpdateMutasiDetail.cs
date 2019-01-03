using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Master;

namespace ISA.Trading.ArusStock
{
    public partial class frmUpdateMutasiDetail : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        //Detail
        Guid _headerID,_rowID;
        string    _kodeBarang, _MutasiID;
        string _typeMutasi;
        int ctr = 0;

        Guid[] newGuid = new Guid[2];
        int[] qtyMutasi = new int[2];
        string[] kodeBarang = new string[2];
        string[] keterangan = new string[2];
        
        public frmUpdateMutasiDetail(Form caller, Guid RowIDHeader, string MutasiID, string TypeMutasi)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = RowIDHeader;
            _MutasiID = MutasiID;
            _typeMutasi = TypeMutasi;
            this.Caller = caller; 
        }

        public frmUpdateMutasiDetail(Form caller, Guid rowID, string TypeMutasi)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _typeMutasi = TypeMutasi;
            this.Caller = caller;

            //if (_typeMutasi == "S")
            //{ 
                
            //}
        }

        private void frmUpdateMutasiDetail_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.Update:
                    try
                    {

                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {

                            db.Commands.Add(db.CreateCommand("usp_MutasiDetail_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            lookupStock1.NamaStock = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                            lookupStock1.BarangID = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                            txtsatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                            txtJumlah.Text = Tools.isNull(dt.Rows[0]["QtyMutasi"], "").ToString();
                            txtCatatan.Text =  Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                            txtKdGdg.Text = Tools.isNull(dt.Rows[0]["Gudang"], "").ToString();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;

                case enumFormMode.New:
                    txtKdGdg.Text = GlobalVar.Gudang;
                    break;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void lookupStock1_SelectData(object sender, EventArgs e)
        {
            _kodeBarang = lookupStock1.BarangID;
            txtsatuan.Text = lookupStock1.Satuan;   
        }

        private void InsertDataTypeTunggal()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    //_rowID = ;
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_MutasiDetail_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
                    db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, _MutasiID));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyMutasi", SqlDbType.Int, txtJumlah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock1.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@kdGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Kode Barang: " + lookupStock1.BarangID + " tidak dapat diinput lebih dari satu kali");
                        lookupStock1.ResetAll();
                        return;
                    }
                    txtCatatan.Text = "";
                    this.DialogResult = DialogResult.OK;
                    CloseForm();
                    cmdCancel.PerformClick();
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
        }
        private void InsertDataTypeSeimbang()
        {
            if (ctr < 2)
            {
                if (kodeBarang[0] == lookupStock1.BarangID && ctr==1)
                {
                    MessageBox.Show("Kode Barang: " + lookupStock1.BarangID + " tidak dapat diinput lebih dari satu kali");
                    lookupStock1.Focus();
                    return;
                }    

                newGuid[ctr] = Guid.NewGuid();
                qtyMutasi[ctr] = txtJumlah.GetIntValue;
                kodeBarang[ctr] = lookupStock1.BarangID;
                keterangan[ctr] = txtCatatan.Text;

                txtJumlah.Text = "-" + txtJumlah.Text;
                txtCatatan.Text = string.Empty;
                lookupStock1.ResetAll();

                txtJumlah.Enabled = false;

                ctr++;

                if (ctr == 2)
                {
                    #region "Stok Minus Lock New"

                    using (Stock st = new Stock())
                    {
                        st.AddList(kodeBarang[1], "", Math.Abs(qtyMutasi[1]));
                        // pass = st.Pass();
                        if (!st.Pass())
                        {
                            MessageBox.Show("Tidak Bisa Proses,\n nilai transaksi menyebabkan stok minus! ", "Warning");
                            st.ReportMinus();

                            if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                st.PrintOutMinus();
                            }

                            this.DialogResult = DialogResult.No;
                            cmdCancel.PerformClick();
                            return;
                        }
                    }



#endregion
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            //_rowID = ;


                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_MutasiDetail_Insert"));

                            for (int i = 0; i <= 1; i++)
                            {
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newGuid[i]));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
                                db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, _MutasiID));
                                db.Commands[0].Parameters.Add(new Parameter("@QtyMutasi", SqlDbType.Int, qtyMutasi[i]));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang[i]));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan[i]));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@kdGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                dt = db.Commands[0].ExecuteDataTable();
                            }

                            this.DialogResult = DialogResult.OK;
                            CloseForm();
                            cmdCancel.PerformClick();
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
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupStock1.BarangID=="")
            {
                lookupStock1.Focus();
                return;
            }

            if (txtJumlah.Text=="0")
            {
                txtJumlah.Focus();
                return;
            }
           
            switch (formMode)
            {
            case enumFormMode.New:
                    if (_typeMutasi == "T")
                    {
                        InsertDataTypeTunggal();
                    }
                    else
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CekMutasiDetail_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock1.BarangID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode Barang: " + lookupStock1.BarangID + " tidak dapat diinput lebih dari satu kali");
                                lookupStock1.ResetAll();
                                return;
                            }
                            InsertDataTypeSeimbang();
                        }
                    }
            	break;

            case enumFormMode.Update:
                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_MutasiDetail_Update"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyMutasi", SqlDbType.Int, txtJumlah.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock1.BarangID));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtCatatan.Text));


                        db.Commands[0].ExecuteNonQuery();
                        this.DialogResult = DialogResult.OK;
                        CloseForm();
                        cmdCancel.PerformClick();
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

        private void frmUpdateMutasiDetail_FormClosed(object sender, FormClosedEventArgs e)
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
                    frmCaller.FindHeader("RowID", _headerID.ToString());
                    frmCaller.FindDetail("RowIDD", _rowID.ToString());
                }
            }
        }

        private void txtCatatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmdSave.PerformClick();
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtCatatan.Focus();
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
        }

        private void lookupStock1_Load(object sender, EventArgs e)
        {
        }
    }
}
