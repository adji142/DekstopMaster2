using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Pembelian
{
    public partial class frmBrgDiterimaSupplierUpdate : ISA.Trading.BaseForm
    {
        Guid _rowID;
        DataTable dtRetur;
        bool skip = false;
        public frmBrgDiterimaSupplierUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmBrgDiterimaSupplierUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Barang diterima Supplier";
            this.Text = "Retur Pembelian";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRetur = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtRetur = db.Commands[0].ExecuteDataTable();
                }

                txtPemasok.Text = dtRetur.Rows[0]["Pemasok"].ToString();
                txtNoMPR.Text = dtRetur.Rows[0]["NoMPR"].ToString();
                txtTglKeluar.DateValue = (DateTime)dtRetur.Rows[0]["TglKeluar"];
                txtNoRetur.Text = dtRetur.Rows[0]["NoRetur"].ToString();
                if (dtRetur.Rows[0]["TglRetur"].ToString() == "")
                {
                    txtTglRetur.DateValue = DateTime.Now;

                }
                else
                {
                    txtTglRetur.DateValue = (DateTime)dtRetur.Rows[0]["TglRetur"];
                    //GlobalVar.LastClosingDate = (DateTime)txtTglRetur.DateValue;
                    //if ((DateTime)txtTglRetur.DateValue <= GlobalVar.LastClosingDate)
                    //{
                    //    txtTglRetur.ReadOnly=true;
                    //    txtPenerima.ReadOnly = true;
                    //    skip = true;
                    //}
                }
                txtPengirim.Text = dtRetur.Rows[0]["Pengirim"].ToString();
                txtTglKirim.DateValue = (DateTime)dtRetur.Rows[0]["TglKirim"];
                if (dtRetur.Rows[0]["Penerima"].ToString() == "")
                {
                    txtPenerima.Text = SecurityManager.UserID;
                }
                else
                {
                    txtPenerima.Text = dtRetur.Rows[0]["Penerima"].ToString();
                }

                txtNoRetur.Focus();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default; 
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; 
            }

            try
            {
                GlobalVar.LastClosingDate = (DateTime)txtTglRetur.DateValue;
                //if ((DateTime)txtTglRetur.DateValue <= GlobalVar.LastClosingDate && skip==false)
                //{
                //    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                //}
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelian_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtRetur.Rows[0]["ReturID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, txtNoRetur.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRetur", SqlDbType.DateTime, txtTglRetur.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, dtRetur.Rows[0]["Pemasok"]));
                    db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, txtPenerima.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dtRetur.Rows[0]["noMPR"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, dtRetur.Rows[0]["TglKeluar"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, dtRetur.Rows[0]["Pengirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, dtRetur.Rows[0]["TglKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtRetur.Rows[0]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtRetur.Rows[0]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data telah disimpan");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtNoRetur.Text == "")
            {
                errorProvider1.SetError(txtNoRetur, "Nomor nota retur tidak boleh kosong");
                valid = false;
            }
            if (txtTglRetur.Text == "")
            {
                errorProvider1.SetError(txtTglRetur, "Tanggal nota retur tidak boleh kosong");
                valid = false;
            }
            if (txtPenerima.Text == "")
            {
                errorProvider1.SetError(txtPenerima, "Penerima tidak boleh kosong");
                valid = false;
            }
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBrgDiterimaSupplierUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBrgDiterimaSupplierBrowser)
                {
                    frmBrgDiterimaSupplierBrowser formCaller = (frmBrgDiterimaSupplierBrowser)this.Caller;
                    formCaller.RefreshDataReturBeli();
                    formCaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }
    }
}
