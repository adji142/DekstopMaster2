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
    public partial class frmBrgDiterimaGdgDetailUpdate : ISA.Trading.BaseForm
    {
        DataTable dtNotaDetail;
        DateTime _tglTerima;
        Guid _rowID, _OrderPembelianDetailRowID;

        public frmBrgDiterimaGdgDetailUpdate(Form caller, Guid rowID, DateTime tglTerima)
        {
            InitializeComponent();
            _rowID = rowID;
            _tglTerima = tglTerima;
            this.Caller = caller;
        }

        private void frmBrgDiterimaGdgDetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Barang diterima Gudang Detail";
            this.Text = "Pembelian";

            try
            {
                this.Cursor = Cursors.Default;
                dtNotaDetail =  new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtNotaDetail = db.Commands[0].ExecuteDataTable();
                }

                txtKodeBarang.Text = dtNotaDetail.Rows[0]["BarangID"].ToString();
                txtNamaBarang.Text = dtNotaDetail.Rows[0]["NamaBarang"].ToString();
                txtSatuan.Text = dtNotaDetail.Rows[0]["Satuan"].ToString();
                txtQtySJ.Text = dtNotaDetail.Rows[0]["QtySuratJalan"].ToString();
                txtQtyNota.Text = dtNotaDetail.Rows[0]["QtyNota"].ToString();
                txtHrgBeli.Text = dtNotaDetail.Rows[0]["HrgBeli"].ToString();
                txtJmlHrgBeli.Text = dtNotaDetail.Rows[0]["JmlHrgBeli"].ToString();
                txtDisc1.Text = dtNotaDetail.Rows[0]["Disc1"].ToString();
                txtDisc2.Text = dtNotaDetail.Rows[0]["Disc2"].ToString();
                txtDisc3.Text = dtNotaDetail.Rows[0]["Disc3"].ToString();
                txtJmlHrgNet.Text = dtNotaDetail.Rows[0]["JmlHrgNet"].ToString();
                txtPPN.Text = dtNotaDetail.Rows[0]["PPN"].ToString();
                _OrderPembelianDetailRowID = new Guid(Tools.isNull(dtNotaDetail.Rows[0]["OrderPembelianDetailRowID"], Guid.Empty).ToString());


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
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[0]["HeaderID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["HeaderRecID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, txtQtySJ.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyNota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtNotaDetail.Rows[0]["Catatan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, _tglTerima));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, dtNotaDetail.Rows[0]["HrgBeli"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, dtNotaDetail.Rows[0]["HrgPokok"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, dtNotaDetail.Rows[0]["HPPSolo"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtNotaDetail.Rows[0]["Pot"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtNotaDetail.Rows[0]["DiscFormula"]));
                    db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, dtNotaDetail.Rows[0]["PPN"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtNotaDetail.Rows[0]["KodeGudang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@OrderPembelianDetailRowID", SqlDbType.UniqueIdentifier, _OrderPembelianDetailRowID));
                    db.Commands[0].ExecuteNonQuery();
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

        private void txtQtySJ_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmBrgDiterimaGdgDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBrgDiterimaGdgBrowser)
                {
                    frmBrgDiterimaGdgBrowser formCaller = (frmBrgDiterimaGdgBrowser)this.Caller;
                    formCaller.RefreshDataNotaBeliDetail();
                    formCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }
    }
}
