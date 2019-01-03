using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;

namespace ISA.Trading.Pembelian
{
    public partial class frmBrgDiterimaGdgUpdate : ISA.Trading.BaseForm
    {
        DataTable dtNotaBeli;
        Guid _rowID;

        public frmBrgDiterimaGdgUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmBrgDiterimaGdgUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Barang diterima Gudang";
            this.Text = "Pembelian";

            try
            {
                this.Cursor = Cursors.Default;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtNotaBeli = db.Commands[0].ExecuteDataTable();
                }

                txtTglTerima.DateValue = DateTime.Now;
                txtPemasok.Text = dtNotaBeli.Rows[0]["Pemasok"].ToString();
                txtNoSJ.Text = dtNotaBeli.Rows[0]["NoSuratJalan"].ToString();
                if (dtNotaBeli.Rows[0]["TglSuratJalan"]!=System.DBNull.Value)
                    txtTglSJ.DateValue = (DateTime)dtNotaBeli.Rows[0]["TglSuratJalan"];
                txtNoNota.Text = dtNotaBeli.Rows[0]["NoNota"].ToString();
                txtTglNota.DateValue = (DateTime)dtNotaBeli.Rows[0]["TglNota"];
                txtExpedisi.Text = dtNotaBeli.Rows[0]["Expedisi"].ToString();
                txtPPN.Text = dtNotaBeli.Rows[0]["PPN"].ToString();
                txtHrKredit.Text = dtNotaBeli.Rows[0]["HariKredit"].ToString();
                txtDisc1.Text = dtNotaBeli.Rows[0]["Disc1"].ToString();
                txtDisc2.Text = dtNotaBeli.Rows[0]["Disc2"].ToString();
                txtDisc3.Text = dtNotaBeli.Rows[0]["Disc3"].ToString();
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
            try
            {
                GlobalVar.LastClosingDate = (DateTime)txtTglTerima.DateValue;
                if ((DateTime)txtTglTerima.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                this.Cursor = Cursors.Default;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNotaBeli.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, dtNotaBeli.Rows[0]["NoRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, dtNotaBeli.Rows[0]["TglRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noDO", SqlDbType.VarChar, dtNotaBeli.Rows[0]["NoDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTransaksi", SqlDbType.DateTime, dtNotaBeli.Rows[0]["TglTransaksi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, dtNotaBeli.Rows[0]["NoNota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dtNotaBeli.Rows[0]["TglNota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, dtNotaBeli.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dtNotaBeli.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTglTerima.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, dtNotaBeli.Rows[0]["Disc1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, dtNotaBeli.Rows[0]["Disc2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, dtNotaBeli.Rows[0]["Disc3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtNotaBeli.Rows[0]["DiscFormula"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, dtNotaBeli.Rows[0]["HariKredit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, dtNotaBeli.Rows[0]["PPN"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, dtNotaBeli.Rows[0]["Pemasok"]));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, dtNotaBeli.Rows[0]["Expedisi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, dtNotaBeli.Rows[0]["Cabang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtNotaBeli.Rows[0]["Catatan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtNotaBeli.Rows[0]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteDataTable();
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Data telah disimpan");
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

        private void txtTglTerima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSAVE.PerformClick();
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmBrgDiterimaGdgUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBrgDiterimaGdgBrowser)
                {
                    frmBrgDiterimaGdgBrowser formCaller = (frmBrgDiterimaGdgBrowser)this.Caller;
                    formCaller.RefreshDataNotaBeli();
                    formCaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }
    }
}
