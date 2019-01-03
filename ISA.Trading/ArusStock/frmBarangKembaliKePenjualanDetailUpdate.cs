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
    public partial class frmBarangKembaliKePenjualanDetailUpdate : ISA.Trading.BaseForm
    {
        #region "Var & Function or Procedure"
        public enum enumFormMode { New, Update };
        //enumFormMode formMode;
        DataTable dt = new DataTable();
        Guid _HeaderID,_PeminjamanID, _RowID ;
        string _KodeSales, _TransactionID, _NoPinjam, _IDPinjam;
        int _Sisa;

        public frmBarangKembaliKePenjualanDetailUpdate(Form caller, Guid RowIDPengembalian, string RecordIDPengembalian,string KodeSales)
        {
            _HeaderID = RowIDPengembalian;
            _TransactionID = RecordIDPengembalian;
            _KodeSales = KodeSales;
            //formMode = enumFormMode.New;
            this.Caller = caller;
            InitializeComponent();
        }

#endregion

        public frmBarangKembaliKePenjualanDetailUpdate()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBarangKembaliKePenjualanDetailUpdate_Load(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtQTy.Text=="" || txtQTy.GetIntValue < 1)
            {
                txtQTy.Focus();
                return;
            }

            if (lookupStock.BarangID=="")
            {
                lookupStock.Focus();
                return;
            }

            if (txtQTy.GetIntValue> _Sisa)
            {
                MessageBox.Show("Jumlah pengembalian(" + txtQTy.Text + ") lebih besar dari sisa(" + _Sisa + ")");
                txtQTy.SelectAll();
                txtQTy.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _RowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengembalianDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier,_HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@PeminjamanID", SqlDbType.UniqueIdentifier, _PeminjamanID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, _TransactionID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPinjam", SqlDbType.VarChar, _NoPinjam));
                    db.Commands[0].Parameters.Add(new Parameter("@IDPinjam", SqlDbType.VarChar, _IDPinjam));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyKembali", SqlDbType.Int,txtQTy.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar,txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                    db.Commands[0].ExecuteNonQuery();

                    MessageBox.Show("Data telah di Simpan");
                    this.DialogResult = DialogResult.OK;
                    lookupStock.NamaStock = "";
                    lookupStock.BarangID = "";
                    txtSatuan.Text = "";
                    txtCatatan.Text = "";
                    txtQTy.Text = "";
                    lookupStock.Focus();
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

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST_2"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar,_KodeSales));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, 0));
                    dt = db.Commands[0].ExecuteDataTable();
                }

#region DataFound
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        _NoPinjam = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                        _IDPinjam = Tools.isNull(dt.Rows[0]["RecordID"], "").ToString();
                        _PeminjamanID = (Guid)dt.Rows[0]["RowID"];
                        _Sisa = int.Parse(Tools.isNull(dt.Rows[0]["Sisa"], "").ToString());
                        txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString(); // lookupStock.Satuan;
                    }


                    if (dt.Rows.Count > 1)
                    {
                        ArusStock.frmBarangKembaliKePenjualanHistory2 frmHistory = new frmBarangKembaliKePenjualanHistory2(dt);
                        frmHistory.ShowDialog();
                        if (frmHistory.DialogResult == DialogResult.OK)
                        {
                            _NoPinjam = Tools.isNull(frmHistory.GetDT.Rows[0]["NoBukti"], "").ToString();
                            _IDPinjam = Tools.isNull(frmHistory.GetDT.Rows[0]["RecordID"], "").ToString();
                            _PeminjamanID = (Guid)frmHistory.GetDT.Rows[0]["RowID"];
                            _Sisa = int.Parse(Tools.isNull(frmHistory.GetDT.Rows[0]["Sisa"], "").ToString());
                            txtSatuan.Text = Tools.isNull(frmHistory.GetDT.Rows[0]["Satuan"], "").ToString(); // lookupStock.Satuan;
                        }
                        else
                        {
                            lookupStock.BarangID = "";
                            lookupStock.NamaStock = "";
                            MessageBox.Show("Tidak ada Pinjaman");
                        }
                    }
                }
#endregion

#region DataNotFound
#endregion
               
                else
                {
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST_2"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, 0));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count > 1)
                    {
                        ArusStock.frmBarangKembaliKePenjualanHistory2 frmHistory = new frmBarangKembaliKePenjualanHistory2(dt);
                        frmHistory.ShowDialog();
                        if (frmHistory.DialogResult == DialogResult.OK)
                        {
                            _NoPinjam = Tools.isNull(frmHistory.GetDT.Rows[0]["NoBukti"], "").ToString();
                            _IDPinjam = Tools.isNull(frmHistory.GetDT.Rows[0]["RecordID"], "").ToString();
                            _PeminjamanID = (Guid)frmHistory.GetDT.Rows[0]["RowID"];
                            _Sisa = int.Parse(Tools.isNull(frmHistory.GetDT.Rows[0]["Sisa"], "").ToString());
                            txtSatuan.Text = Tools.isNull(frmHistory.GetDT.Rows[0]["Satuan"], "").ToString(); // lookupStock.Satuan;
                        }
                        else
                        {
                            lookupStock.BarangID = "";
                            lookupStock.NamaStock = "";
                            MessageBox.Show("Tidak ada Pinjaman");
                        }
                    }else
                    {
                        lookupStock.BarangID = "";
                        lookupStock.NamaStock = "";
                        MessageBox.Show("Tidak ada Pinjaman");
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


          

        }

        private void frmBarangKembaliKePenjualanDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBarangKembaliKePenjualan)
                {                   
                    ArusStock.frmBarangKembaliKePenjualan frmcaller = (ArusStock.frmBarangKembaliKePenjualan)this.Caller;
                    frmcaller.RefreshHeader();
                    frmcaller.FindHeader("rowID", _HeaderID.ToString());
                    frmcaller.FindDetail("rowidD", _RowID.ToString());
                }
            }
        }

        private void lookupStock_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(lookupStock.BarangID))
            ////{
            //    ArusStock.frmBarangKembaliKePenjualanHistory frmHistory = new frmBarangKembaliKePenjualanHistory();
            //    frmHistory.loadPinjaman(dt);
            //    frmHistory.ShowDialog();
            //}
        }
    }
}
