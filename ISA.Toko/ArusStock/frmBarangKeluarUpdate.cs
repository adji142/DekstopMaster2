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
    public partial class frmBarangKeluarUpdate : ISA.Toko.BaseForm
    {
        Guid _RowID;

        int _qtyKembali;

        public frmBarangKeluarUpdate(Form caller, Guid RowID)
        {
            _RowID = RowID;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmBarangKeluarUpdate()
        {
            InitializeComponent();
        }

        private void frmBarangKeluarUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        txtNamaBarang.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                        txtKodeBarang.Text = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                        txtQtyPinjam.Text = Tools.isNull(dt.Rows[0]["QtyMemo"], "").ToString();
                        txtQtyKelGud.Text = Tools.isNull(dt.Rows[0]["QtyKeluarGudang"], "").ToString();
                        _qtyKembali = Int32.Parse(Tools.isNull(dt.Rows[0]["QtyKembali"], "0").ToString());
                        txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                        txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
                {
                txtQtyKelGud.Focus();
                this.Cursor = Cursors.Default;
                }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBarangKeluarUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBarangKeluar)
                {
                    ArusStock.frmBarangKeluar frmCaller = (ArusStock.frmBarangKeluar)this.Caller;
                    frmCaller.RefreshDetail();
                    frmCaller.FindDetail("RowIDD", _RowID.ToString());
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            if (Int32.Parse(txtQtyKelGud.Text) < 0 )
            {
                txtQtyKelGud.Focus();
                return;
            }

            if (Int32.Parse(txtQtyKelGud.Text) > Int32.Parse(txtQtyPinjam.Text))
            {
                txtQtyKelGud.Focus();
                return;
            }

            try
            {

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier,_RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, txtKodeBarang.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, txtQtyPinjam.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int,txtQtyKelGud.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].ExecuteNonQuery();

                    //MessageBox.Show("Data telah diUpdate");
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
        }

        private void txtCatatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                cmdSave.PerformClick();
            }
        }
    }
}
