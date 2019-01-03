using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Pembelian
{
    public partial class frmDOBeliDetailUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode _formMode;
        DataTable dtDODetail, dtDO;
        Guid _rowID, _headerID;
        // variable Histories
        #region VarHistories
        double _hisHarga=0.0, _rata2JualPerbualn=0.0;
        int _HisQty=0;
        Int32 _HargaBeli;
        String _HisSuplier = "", _HisNoRequest ="", _HisSalesman="", _HisNoNota;
        DateTime _HisTglNotaPem , _HisTglTerima, _HisTglOrder;
        #endregion
        public frmDOBeliDetailUpdate(Form caller, Guid rowID, enumFormMode formMode)
        {
            InitializeComponent();
            _formMode = formMode;
            if (_formMode == enumFormMode.Update)
            {
                _rowID = rowID;
            }
            else
            {
                _headerID = rowID;
            }
            this.Caller = caller;
        }

        private void frmDOBeliDetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Order Pembelian Detail";
            this.Text = "Pembelian";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == enumFormMode.Update)
                    {
                        dtDODetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtDODetail = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dtDO = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_OrderPembelian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));                  

                        dtDO = db.Commands[0].ExecuteDataTable();
                    }
                }

                if (_formMode == enumFormMode.Update)
                {
                    lookupStock.BarangID = dtDODetail.Rows[0]["BarangID"].ToString();
                    lookupStock.NamaStock = dtDODetail.Rows[0]["NamaBarang"].ToString();
                    txtSatuan.Text = dtDODetail.Rows[0]["Satuan"].ToString();
                    txtIsiKoli.Text = dtDODetail.Rows[0]["IsiKoli"].ToString();
                    txtQtyBO.Text = dtDODetail.Rows[0]["QtyBO"].ToString();
                    txtQtyOrder.Text = dtDODetail.Rows[0]["QtyTambahan"].ToString();
                    txtJmlQtyRQ.Text = dtDODetail.Rows[0]["QtyRequest"].ToString();
                    txtQtyAkhir.Text = dtDODetail.Rows[0]["LastQty"].ToString();
                    txtQtyJual.Text = dtDODetail.Rows[0]["QtyJual"].ToString();
                    txtKet.Text = dtDODetail.Rows[0]["Keterangan"].ToString();
                   TxtHarga.Text = dtDODetail.Rows[0]["harga"].ToString();
                   TxtRpTotal.Text = dtDODetail.Rows[0]["rpTotal"].ToString();
                    txtQtyOrder.Focus();
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

        private void txtQtyTambahan_Validating(object sender, CancelEventArgs e)
        {
            int qtyRQ = txtQtyBO.GetIntValue + txtQtyOrder.GetIntValue;
            txtJmlQtyRQ.Text = qtyRQ.ToString();

            if ((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) > txtQtyMax.GetIntValue)
            {
                MessageBox.Show("Nilai Order " + lookupStock.NamaStock + " Melebihi batas Stok Maksimum." + System.Environment.NewLine +
                    "Kelebihan " + ((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMax.GetIntValue).ToString()
                    );

            }

            if ((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) < txtQtyMin.GetIntValue)
            {
                MessageBox.Show("Nilai Order " + lookupStock.NamaStock + " Kurang dari  Stok Minimum ." + System.Environment.NewLine +
                   "Kekurangan " + ((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMin.GetIntValue).ToString()
                   );
            }

        }

        private bool CekInputBarang()
        {
            DataTable dt;
            bool retVal=false;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekBarangSudahInput"));
                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDO.Rows[0]["RowID"]));
                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    retVal = true;
                }
            }

            return retVal;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
           

            if (!ValidateInput())
            {
                return;
            }

            if( _formMode == enumFormMode.New)
            {
                if (CekInputBarang())
                {
                    MessageBox.Show("Barang ID:" + lookupStock.BarangID + " sudah diinput");
                    return;
                }
            }
            
            if ((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) > txtQtyMax.GetIntValue  && (string.IsNullOrEmpty(txtKet.Text)))
            {
                MessageBox.Show("Nilai Order "+lookupStock.NamaStock + " Melebihi batas Stok Maksimum." + System.Environment.NewLine +
                    "Kelebihan "+((txtQtyOrder.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMax.GetIntValue).ToString()+ System.Environment.NewLine +
                    "Harus isi alasan di keterangan");
                txtKet.Focus();
                return;
            }
            
            if (TxtHarga.GetDoubleValue > _hisHarga)
            {
                Double selisih = (TxtHarga.GetDoubleValue - _hisHarga);
                DialogResult dialogResult = MessageBox.Show("Harga beli lebih mahal RP " + selisih.ToString("#,##0.00") + " dari harga beli terakhir. \r\n pakah anda ingin melanjutkan.?", "Perhatian", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    TxtHarga.Focus();
                    return;
                }
            }
            if (TxtHarga.GetDoubleValue < _hisHarga)
            {
                Double selisih = ( _hisHarga - TxtHarga.GetDoubleValue );
                DialogResult dialogResult = MessageBox.Show("Harga beli lebih Murah RP " + selisih.ToString("#,##0.00") + " dari harga beli terakhir. \r\n pakah anda ingin melanjutkan.?", "Perhatian", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    TxtHarga.Focus();
                    return;
                }
            }

            /* 
            if ( (txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) < txtQtyMin.GetIntValue)
            {
                MessageBox.Show("Nilai Order " + lookupStock.NamaStock + " Kurang dari  Stok Minimum ." + System.Environment.NewLine +
                   "Kekurangan " + ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMin.GetIntValue).ToString()
                   );
            }
            */
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch(_formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDO.Rows[0]["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtDO.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyBO", SqlDbType.Int, txtQtyBO.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTambahan", SqlDbType.Int, txtQtyOrder.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, txtQtyJual.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyAkhir", SqlDbType.Int, txtQtyAkhir.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKet.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@HARGA", SqlDbType.Money, double.Parse(TxtHarga.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        Clear();
                        lookupStock.Focus();
                        
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDODetail.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDODetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtDODetail.Rows[0]["HeaderRecID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, dtDODetail.Rows[0]["QtyDO"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyBO", SqlDbType.Int, txtQtyBO.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTambahan", SqlDbType.Int, txtQtyOrder.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, txtQtyJual.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@HARGA", SqlDbType.Money, double.Parse(TxtHarga.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyAkhir", SqlDbType.Int, txtQtyAkhir.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKet.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDODetail.Rows[0]["KodeGudang"]));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDODetail.Rows[0]["Catatan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Close();
                frmDOBeliBrowser formCaller = (frmDOBeliBrowser)this.Caller;
                formCaller.opendetail();

            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (lookupStock.BarangID == "[CODE]" || lookupStock.BarangID == "")
            {
                errorProvider1.SetError(lookupStock, "Barang tidak boleh kosong");
                valid = false;
            }

            //if (txtQtyTambahan.GetIntValue==0)
            //{
            //    errorProvider1.SetError(txtQtyTambahan, "Tidak Boleh 0");
            //    valid = false;
            //}
            return valid;
        }

        private void Clear()
        {
            lookupStock.BarangID = "[Code]";
            lookupStock.NamaStock = "";
            txtSatuan.Text = "";
            txtIsiKoli.Text = "";
            txtQtyBO.Text = "0";
            txtQtyOrder.Text = "0";
            txtJmlQtyRQ.Text = "0";
            txtQtyAkhir.Text = "0";
            txtQtyJual.Text = "0";
            txtKet.Text = "";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDOBeliDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmDOBeliBrowser)
                {
                    frmDOBeliBrowser formCaller = (frmDOBeliBrowser)this.Caller;
                    formCaller.RefreshDataOrderPembelian();
                    formCaller.FindHeader("HeaderRowID", _headerID.ToString());
                    formCaller.RefreshDataOrderPembelianDetail();
                    formCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lookupStock.Satuan;
            txtIsiKoli.Text = lookupStock.IsiKoli.ToString();
            if (lookupStock.BarangID != "" && lookupStock.BarangID != "[CODE]")
            {
                HistoryBarang(lookupStock.BarangID);
                 
                 txtQtyAkhir.Text = QtyAkhir(lookupStock.BarangID).ToString();
                 txtQtyJual.Text = AvgJual(lookupStock.BarangID).ToString();
                 StokMax(lookupStock.BarangID);
            }
            GetHistorry();
            
        }

        public Double GetDataHargaBeli(String _barangID)
        {
            
                Double HargaBeli = 0;
                DataTable dtHPP = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_HistoryHPP_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHPP = db.Commands[0].ExecuteDataTable();
                    
                }
                if (dtHPP.Rows.Count > 0) {
                    HargaBeli = Convert.ToDouble(dtHPP.Rows[0]["HPP"].ToString());
                }
            return HargaBeli;
           
        }

        private void RiwayatPengambilanTerakhir(String BarangId) 
        {
            using (Database db = new Database())
            {
               
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangId", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                
            }
        
        }

        private void lookupStock_Leave(object sender, EventArgs e)
        {
            
        }

        private void HistoryBarang(string KodeBarang_)
        {
            try
            {
                 this.Cursor = Cursors.WaitCursor;
                 DataTable dtM = new DataTable();
                 using (Database db = new Database())
                 {
                     db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_Chek"));
                     db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, KodeBarang_));
                     db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                     dtM = db.Commands[0].ExecuteDataTable();
                 }
                if (dtM.Rows.Count>0)
                {
                    string msg = "Ada Order yg Belum terpenuhi " +
                              System.Environment.NewLine + "Tgl Request Terakhir : " + Tools.isNull(dtM.Rows[0]["TglRequest"], "").ToString() +
                              System.Environment.NewLine + "NoRequest : " + Tools.isNull(dtM.Rows[0]["NoRequest"], "").ToString() +
                              System.Environment.NewLine + "Q.Rq : " + Tools.isNull(dtM.Rows[0]["QtyTotal"], "").ToString() +
                              System.Environment.NewLine + "Q.Terima : " + "0";//Tools.isNull(dtM.Rows[0]["QtyAkhir"], "").ToString();
                    MessageBox.Show(msg);
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

        private int AvgJual(string KodeBarang_)
        {
                
                int val = 0;
                DataTable dtM = new DataTable();
                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("usp_GetQtyAVGJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, KodeBarang_));
                    val = Convert.ToInt32(Tools.isNull(db.Commands[0].ExecuteScalar(),"0").ToString());
                }

                return val;
        }

        private void StokMax(string KodeBarang_)
        {

            
            DataTable dtM = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[usp_GetStokMax]"));
                db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, KodeBarang_));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));

                dtM = db.Commands[0].ExecuteDataTable();
            }
            if (dtM.Rows.Count>0)
            {
                txtQtyMax.Text = dtM.Rows[0]["QtyMax"].ToString();
                txtQtyMin.Text = dtM.Rows[0]["QtyMax"].ToString();
            }
            else
            {
                txtQtyMax.Text = "0";
                txtQtyMin.Text = "0";
            }
            
        }

        private int QtyAkhir(string KodeBarang_)
        {
          
            int val = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_CekStokRealTime]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang_));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));


                dt = db.Commands[0].ExecuteDataTable();

            }

            val = Convert.ToInt32(dt.Rows[0]["QtyAkhir"].ToString());
           

            return val;
        }

        private void lookupStock_Validated(object sender, EventArgs e)
        {
            if (lookupStock.BarangID != "" && lookupStock.BarangID != "[CODE]")
            {
                txtQtyAkhir.Text = QtyAkhir(lookupStock.BarangID).ToString();
                txtQtyJual.Text = AvgJual(lookupStock.BarangID).ToString();
                StokMax(lookupStock.BarangID);
            }
        }

        private void txtQtyTambahan_Validated(object sender, EventArgs e)
        {
            if (txtQtyOrder.GetIntValue < 1) {
                txtQtyOrder.Text = "1";
            }
            TxtRpTotal.Text = (txtQtyOrder.GetIntValue * TxtHarga.GetIntValue).ToString();
        }

        private void TxtHarga_Validated(object sender, EventArgs e)
        {
            if (TxtHarga.GetIntValue < 0)
            {
                TxtHarga.Text = "0";
            }
            TxtRpTotal.Text = (txtQtyOrder.GetIntValue * TxtHarga.GetIntValue).ToString();
        }

        private void TxtHarga_Enter(object sender, EventArgs e)
        {
            if (lookupStock.BarangID == "" || lookupStock.BarangID == "[CODE]")
            { 
                MessageBox.Show("Harap memilih Barang Terlebih dahulu.");
                lookupStock.Focus();
                return;
            }
           
        }

        private void GetHistorry()
        {
            try
            {
                
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_orderpembelian_cek_notapembelian_GetRata2Jual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, lookupStock.BarangID));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                if (dt.Rows.Count > 0)
                {
                    _HisSuplier = dt.Rows[0]["Pemasok"].ToString();
                   if(String.Empty != dt.Rows[0]["TglNota"].ToString()) _HisTglNotaPem =  Convert.ToDateTime(dt.Rows[0]["TglNota"].ToString());
                    _hisHarga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["HrgBeli"].ToString(),0.0));
                    _HisQty = (Int32)Tools.isNull(dt.Rows[0]["QtyRequest"],0);
                    _rata2JualPerbualn = (Double)Tools.isNull(dt.Rows[0]["AVGJual"], 0.0);

                    _HisNoRequest = dt.Rows[0]["NoRequest"].ToString();
                    _HisNoNota = dt.Rows[0]["NoNota"].ToString();
                    _HisSalesman = dt.Rows[0]["Salesman"].ToString();
                    if (String.Empty != dt.Rows[0]["TglRequest"].ToString()) _HisTglOrder = Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString());
                    if (String.Empty != dt.Rows[0]["TglTerima"].ToString()) _HisTglTerima = Convert.ToDateTime(dt.Rows[0]["TglTerima"].ToString());

                    String _SHisTglNotaPem = _HisTglNotaPem < Convert.ToDateTime("2001-12-12") ? "" : _HisTglNotaPem.ToString("dd MMM yyyy");
                    String _SHisTglTerima = _HisTglTerima < Convert.ToDateTime("2001-12-12") ? "" : _HisTglTerima.ToString("dd MMM yyyy");
                    MessageBox.Show(" Nama Supplier \t : " + _HisSuplier +
                        ",\r\nHarga \t\t : " + _hisHarga.ToString("###,##0") +
                        ",\r\nQty \t\t : " + _HisQty.ToString("###,##0") +
                        ",\r\n\r\nNama Salesman \t : " + _HisSalesman +
                        ",\r\nTanggal Order \t : " + _HisTglOrder.ToString("dd MMM yyyy") +
                        ",\r\nTanggal Nota \t : " + _SHisTglNotaPem +
                        ",\r\nTanggal Terima \t : " + _SHisTglTerima + 
                        ",\r\nNo. Order \t\t : " + _HisNoRequest +
                        ",\r\nNo. Nota \t\t : " + _HisNoNota, "*Informasi Riwayat Pengambilan Terakhir*" );
                    TxtHarga.Text = _hisHarga.ToString();
                }
                else {
                    _hisHarga = GetDataHargaBeli(lookupStock.BarangID);
                    TxtHarga.Text = _hisHarga.ToString();
                }
                txtQtyRataJualBulan.Text = _rata2JualPerbualn.ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
