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
    public partial class frmDOBeliDetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode _formMode;
        DataTable dtDODetail, dtDO;
        Guid _rowID, _headerID;

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
                    txtQtyTambahan.Text = dtDODetail.Rows[0]["QtyTambahan"].ToString();
                    txtJmlQtyRQ.Text = dtDODetail.Rows[0]["QtyRequest"].ToString();
                    txtQtyAkhir.Text = dtDODetail.Rows[0]["LastQty"].ToString();
                    txtQtyJual.Text = dtDODetail.Rows[0]["QtyJual"].ToString();
                    txtKet.Text = dtDODetail.Rows[0]["Keterangan"].ToString();
                    txtQtyTambahan.Focus();
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
            int qtyRQ = txtQtyBO.GetIntValue + txtQtyTambahan.GetIntValue;
            txtJmlQtyRQ.Text = qtyRQ.ToString();

            //ditutup : ket dari teo
            //if ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) > txtQtyMax.GetIntValue)
            //{
            //    MessageBox.Show("Nilai Order " + lookupStock.NamaStock + " Melebihi batas Stok Maksimum." + System.Environment.NewLine +
            //        "Kelebihan " + ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMax.GetIntValue).ToString()
            //        );
            //}
            //if ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) < txtQtyMin.GetIntValue)
            //{
            //    MessageBox.Show("Nilai Order " + lookupStock.NamaStock + " Kurang dari  Stok Minimum ." + System.Environment.NewLine +
            //       "Kekurangan " + ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMin.GetIntValue).ToString()
            //       );
            //}

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
            
            //ditutup utk ahass
            //if ((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) > txtQtyMax.GetIntValue  && (string.IsNullOrEmpty(txtKet.Text)))
            //{
            //    MessageBox.Show("Nilai Order "+lookupStock.NamaStock + " Melebihi batas Stok Maksimum." + System.Environment.NewLine +
            //        "Kelebihan "+((txtQtyTambahan.GetIntValue + txtQtyAkhir.GetIntValue) - txtQtyMax.GetIntValue).ToString()+ System.Environment.NewLine +
            //        "Harus isi alasan di keterangan");
            //    txtKet.Focus();
            //    return;
            //}

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
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTambahan", SqlDbType.Int, txtQtyTambahan.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, txtQtyJual.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyAkhir", SqlDbType.Int, txtQtyAkhir.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKet.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
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
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTambahan", SqlDbType.Int, txtQtyTambahan.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, txtQtyJual.GetIntValue));
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
            txtQtyTambahan.Text = "0";
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
                 if (_formMode== enumFormMode.New)
                 {
                   
                 }
                 txtQtyAkhir.Text = QtyAkhir(lookupStock.BarangID).ToString();
                 txtQtyJual.Text = AvgJual(lookupStock.BarangID).ToString();
                 StokMax(lookupStock.BarangID);
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
    }
}
