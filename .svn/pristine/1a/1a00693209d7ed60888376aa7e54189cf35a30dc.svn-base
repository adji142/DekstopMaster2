using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.Pembelian
{
    public partial class frmNotaBeliDetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode _formMode;
        DataTable dtNotaDetail, dtNota;
        Guid _rowID, _headerID, _OrderPembelianDetailRowID;
        DataRow _historyOrderRow;

        public frmNotaBeliDetailUpdate(Form caller, Guid rowID, enumFormMode formMode)
        {
            InitializeComponent();
            _formMode = formMode;
            if (_formMode == enumFormMode.New)
            {
                _headerID = rowID;
            }
            else
            {
                _rowID = rowID;
            }
            this.Caller = caller;
        }

        private void frmNotaBeliDetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Pembelian Detail";
            this.Text = "Pembelian";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == enumFormMode.Update)
                    {
                        dtNotaDetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtNotaDetail = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dtNota = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));                        
                        dtNota = db.Commands[0].ExecuteDataTable();
                    }
                }

                if (_formMode == enumFormMode.Update)
                {
                    lookupStock.BarangID = dtNotaDetail.Rows[0]["BarangID"].ToString();
                    lookupStock.NamaStock = dtNotaDetail.Rows[0]["NamaBarang"].ToString();
                    txtSatuan.Text = dtNotaDetail.Rows[0]["Satuan"].ToString();
                    txtQtyNota.Text = dtNotaDetail.Rows[0]["QtyNota"].ToString();
                    txtHargaBeli.Text = double.Parse(dtNotaDetail.Rows[0]["HrgBeli"].ToString()).ToString("#,##0.00");
                    txtJumlah.Text = (Convert.ToDouble(Tools.isNull(dtNotaDetail.Rows[0]["QtyNota"], "0").ToString()) *
                                      Convert.ToDouble(Tools.isNull(dtNotaDetail.Rows[0]["HrgBeli"], "0").ToString())).ToString();
                    txtCatatan.Text = dtNotaDetail.Rows[0]["Catatan"].ToString();
                    txtNoRq.Text = dtNotaDetail.Rows[0]["NoRequest"].ToString();
                    txtTglRq.Text = string.Format("{0:dd-MMM-yyyy}", dtNotaDetail.Rows[0]["TglRequest"].ToString());
                    txtQtyDO.Text = Tools.isNull(dtNotaDetail.Rows[0]["QtyDo"], "0").ToString();
                    txtQtyReal.Text = Tools.isNull(dtNotaDetail.Rows[0]["QtyRealisasi"], "0").ToString();
                    txtQtyBO.Text = Tools.isNull(dtNotaDetail.Rows[0]["QtyBo"], "0").ToString();
                    _OrderPembelianDetailRowID = new Guid(Tools.isNull(dtNotaDetail.Rows[0]["OrderPembelianDetailRowID"], Guid.Empty).ToString());

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
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                string csql = "";
                switch (_formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        csql = "usp_NotaPembelianDetail_INSERT";
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, txtQtyNota.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            //db.Commands[0].Parameters.Add(new Parameter("@koreksiID",SqlDbType.VarChar,""));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@OrderPembelianDetailRowID", SqlDbType.UniqueIdentifier, _OrderPembelianDetailRowID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        Clear();         
                        break;
                    case enumFormMode.Update:
                        csql = "usp_NotaPembelianDetail_UPDATE";
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["HeaderRecID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyRequest"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyDO"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, dtNotaDetail.Rows[0]["QtySuratJalan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, txtQtyNota.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, dtNotaDetail.Rows[0]["TglTerima"]));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
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
                        break;
                }
                /*
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(csql));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, txtQtyNota.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, txtHargaBeli.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@koreksiID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Data telah disimpan");
                Clear();  
                */
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor =  Cursors.Default;
            }        
        }


        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (lookupStock.BarangID == "[Code]" || lookupStock.BarangID == "")
            {
                errorProvider1.SetError(lookupStock, "Barang tidak boleh kosong");
                valid = false;
            }
            return valid;
        }

        private void Clear()
        {
            lookupStock.BarangID = "[Code]";
            lookupStock.NamaStock = "";
            txtSatuan.Text = "";
            txtQtyNota.Text = "0";
            txtCatatan.Text = "";
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            string _KodeBarang = Tools.isNull(lookupStock.BarangID,"").ToString();
            txtSatuan.Text = lookupStock.Satuan;
            if (_KodeBarang != "")
            GetDataOrderPembelian(_KodeBarang);
        }

        private void GetDataOrderPembelian(string _KdBarang)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryOrderPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, _KdBarang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    lookupStock.Focus();
                    return;
                }
                else if (dt.Rows.Count == 1)
                {
                    _historyOrderRow = dt.Rows[0];
                }
                else
                {
                    ShowHistoryOrderDialogForm(dt);
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

            if (_historyOrderRow == null)
            {
                MessageBox.Show("Tidak ada data yang dipilih");
                return;
            }

            txtNoRq.Text = Tools.isNull(_historyOrderRow["NoRequest"], "0").ToString();
            txtTglRq.Text = string.Format("{0:dd-MMM-yyyy}", _historyOrderRow["TglRequest"]);
            txtQtyDO.Text = Tools.isNull(_historyOrderRow["QtyDO"], "0").ToString();
            txtQtyReal.Text = Tools.isNull(_historyOrderRow["QtyRealisasi"], "0").ToString();
            txtQtyBO.Text = Tools.isNull(_historyOrderRow["QtyBO"], "0").ToString();
            _OrderPembelianDetailRowID = new Guid(Tools.isNull(_historyOrderRow["OrderPembelianDetailRowID"], Guid.Empty).ToString());
        }

        private void ShowHistoryOrderDialogForm(DataTable dt)
        {
            frmHistoryOrderPembelianBrowse ifrmDialog = new frmHistoryOrderPembelianBrowse(dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetHistoryOrderDialogResult(ifrmDialog);
            }
        }

        private void GetHistoryOrderDialogResult(frmHistoryOrderPembelianBrowse dialogForm)
        {
            _historyOrderRow = dialogForm.SelecetedRow;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotaBeliDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaBeliBrowser)
                {
                    frmNotaBeliBrowser formCaller = (frmNotaBeliBrowser)this.Caller;
                    formCaller.RefreshDataNotaBeliDetail();
                    formCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }

        private void txtQtyNota_Leave(object sender, EventArgs e)
        {
            txtJumlah.Text = (Convert.ToDouble(Tools.isNull(txtQtyNota.Text, "0").ToString()) *
                              Convert.ToDouble(Tools.isNull(txtHargaBeli.Text, "0").ToString())).ToString();
        }

        private void txtHargaBeli_Leave(object sender, EventArgs e)
        {
            txtJumlah.Text = (Convert.ToDouble(Tools.isNull(txtQtyNota.Text, "0").ToString()) *
                              Convert.ToDouble(Tools.isNull(txtHargaBeli.Text, "0").ToString())).ToString();
        }
    }
}
