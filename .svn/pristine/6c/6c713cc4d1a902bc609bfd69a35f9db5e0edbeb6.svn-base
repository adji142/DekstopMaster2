using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmPembelianDetailUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode _formMode;
        DataTable dt;
        Guid _rowID, _headerID;

        public frmPembelianDetailUpdate(Form caller, Guid rowID , FormTools.enumFormMode formMode)
        {
            InitializeComponent();
            _formMode = formMode;
            if (_formMode == FormTools.enumFormMode.Update)
                _rowID = rowID;
            else
                _headerID = rowID;
            this.Caller = caller;
        }

        private void frmPembelianDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == FormTools.enumFormMode.Update)
                    {
                        dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeli_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));

                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }

                if (_formMode == FormTools.enumFormMode.Update)
                {
                    lkpStokBkl.KodeStokBkl = dt.Rows[0]["Id_brg"].ToString();
                    lkpStokBkl.NamaStokBkl = dt.Rows[0]["NamaStok"].ToString();
                    txtSatuan.Text = dt.Rows[0]["satuan"].ToString(); 
                    //txtIsiKoli.Text = dt.Rows[0]["isikoli"].ToString();
                    txtQtyNota.Text = dt.Rows[0]["j_nota"].ToString();
                    txtQtyTerima.Text = dt.Rows[0]["j_sj"].ToString();
                    txtHargaSatuan.Text = dt.Rows[0]["h_beli"].ToString();
                    txtJmlBeli.Text = dt.Rows[0]["RpBeli"].ToString();
                    txtDisc1.Text = dt.Rows[0]["disc_1"].ToString();
                    txtDisc2.Text = dt.Rows[0]["disc_2"].ToString();
                    txtDisc3.Text = dt.Rows[0]["disc_3"].ToString();
                    txtPotongan.Text = dt.Rows[0]["pot_rp"].ToString();
                    txtPpn.Text = dt.Rows[0]["ppn"].ToString();
                    txtJmlNetto.Text = dt.Rows[0]["RpNet"].ToString();
                    txtCatatan.Text = dt.Rows[0]["catatan1"].ToString();
                    _headerID = new Guid(dt.Rows[0]["HeaderID"].ToString());
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
            if (txtQtyNota.Text == "")
                txtQtyNota.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();
        }

        private double HitungJmlHrg()
        {
            double _qtyNota = 0;
            double _hrgBeli = 0;
            if (txtQtyNota.Text != "")
                _qtyNota = txtQtyNota.GetDoubleValue;
            if (txtHargaSatuan.Text != "")
                _hrgBeli = txtHargaSatuan.GetDoubleValue;
            return (_qtyNota * _hrgBeli);
        }

        private double HitungJmlNetto()
        {
            double hrgNet3Disc = 0, _jmlBeli = 0, _qtyBeli = 0, _hbeli = 0, _disc1 = 0, _disc2 = 0, _disc3 = 0, _pot = 0, 
                   _Ppn = 0, _RpNetto = 0, _RpNettoPpn = 0;
            try
            {
                if (txtJmlBeli.Text != "")
                    _jmlBeli = double.Parse(txtJmlBeli.Text);
                if (txtQtyNota.Text != "")
                    _qtyBeli = double.Parse(txtQtyNota.Text);
                if (txtHargaSatuan.Text != "")
                    _hbeli = double.Parse(txtHargaSatuan.Text);
                if (txtDisc1.Text != "")
                    _disc1 = double.Parse(txtDisc1.Text);
                if (txtDisc2.Text != "")
                    _disc2 = double.Parse(txtDisc2.Text);
                if (txtDisc3.Text != "")
                    _disc3 = double.Parse(txtDisc3.Text);
                if (txtPotongan.Text != "")
                    _pot = double.Parse(txtPotongan.Text);
                if (txtPpn.Text != "")
                    _Ppn = double.Parse(txtPpn.Text);

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc")); // 27042013
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, _hbeli));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = Math.Round(double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString()), 0);
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            _RpNetto = ((hrgNet3Disc - _pot) * _qtyBeli);
            _RpNettoPpn = _RpNetto + Math.Round((_Ppn / 100) * _RpNetto, 0);

            return (_RpNettoPpn);
        }



        private bool CekInputBarang()
        {
            bool retVal=false;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dt.Rows[0]["RowID"]));
                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
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

            if( _formMode == FormTools.enumFormMode.New)
            {
                if (CekInputBarang())
                {
                    MessageBox.Show("Barang ID:" + lkpStokBkl.KodeStokBkl + " sudah diinput");
                    return;
                }
            }
                        
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch(_formMode)
                {
                    case FormTools.enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@j_nota", SqlDbType.Decimal, txtQtyNota.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@j_sj", SqlDbType.Decimal, txtQtyNota.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@h_beli", SqlDbType.Decimal, txtHargaSatuan.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc1.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_2", SqlDbType.Decimal, txtDisc2.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_3", SqlDbType.Decimal, txtDisc3.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Decimal, txtPotongan.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Decimal, txtPpn.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        //SaveStokBkl();
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        closeForm();
                        this.Close();
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@j_nota", SqlDbType.Decimal, txtQtyNota.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@j_sj", SqlDbType.Decimal, txtQtyNota.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@h_beli", SqlDbType.Decimal, txtHargaSatuan.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc1.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_2", SqlDbType.Decimal, txtDisc2.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_3", SqlDbType.Decimal, txtDisc3.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Decimal, txtPotongan.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Decimal, txtPpn.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        //SaveStokBkl();
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        closeForm();
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

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPembelianBengkel)
                {
                    frmPembelianBengkel formCaller = (frmPembelianBengkel)this.Caller;
                    //formCaller.RefreshDataPembelian();
                    formCaller.RefreshDataPembelianDetail();
                    formCaller.FindRow(FormTools.detailIndex.detail1, "RowIDDetail", _rowID.ToString());
                }
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (lkpStokBkl.KodeStokBkl == "[CODE]" || lkpStokBkl.KodeStokBkl == "")
            {
                errorProvider1.SetError(lkpStokBkl, "Barang tidak boleh kosong");
                valid = false;
                lkpStokBkl.Focus();
            }

            if (lkpStokBkl.NamaStokBkl == "")
            {
                errorProvider1.SetError(lkpStokBkl, "Nama Barang tidak boleh kosong");
                valid = false;
                lkpStokBkl.Focus();
            }

            if (txtQtyNota.GetIntValue == 0)
            {
                errorProvider1.SetError(txtQtyNota, "Tidak Boleh 0");
                valid = false;
                txtQtyNota.Focus();
            }

            if (txtHargaSatuan.GetIntValue == 0)
            {
                errorProvider1.SetError(txtHargaSatuan, "Tidak Boleh 0");
                valid = false;
                txtHargaSatuan.Focus();
            }
            return valid;
        }

        private void Clear()
        {
            lkpStokBkl.KodeStokBkl = "[Code]";
            lkpStokBkl.NamaStokBkl = "";
            txtSatuan.Text = "";
            txtIsiKoli.Text = "";
            txtJmlBeli.Text = "0";
            txtHargaSatuan.Text = "0";
            txtJmlBeli.Text = "0";
            txtDisc1.Text = "0";
            txtDisc2.Text = "0";
            txtDisc3.Text = "0";
            txtJmlNetto.Text = "0";
            txtCatatan.Text = "";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPembelianDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPembelianBrowser)
                {
                    frmPembelianBrowser formCaller = (frmPembelianBrowser)this.Caller;
                    formCaller.RefreshDataPembelianDetail();
                    formCaller.FindRow(FormTools.detailIndex.detail1, "RowID", _rowID.ToString()); 
                }
            }
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lkpStokBkl.Satuan;
            //txtIsiKoli.Text = 0.ToString();
            if (lkpStokBkl.KodeStokBkl != "" && lkpStokBkl.KodeStokBkl != "[CODE]")
            {
                HistoryBarang(lkpStokBkl.KodeStokBkl);
                 if (_formMode== FormTools.enumFormMode.New)
                 {
                   
                 }
                 //txtQtyAkhir.Text = QtyAkhir(lookupStock.BarangID).ToString();
                 //txtQtyJual.Text = AvgJual(lookupStock.BarangID).ToString();
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
            if (lkpStokBkl.KodeStokBkl != "" && lkpStokBkl.KodeStokBkl != "[CODE]")
            {
                //txtQtyAkhir.Text = QtyAkhir(lookupStock.BarangID).ToString();
                //txtQtyJual.Text = AvgJual(lookupStock.BarangID).ToString();
            }
        }

        private void SaveStokBkl()
        {
            try
            {
                switch (_formMode)
                {
                    case FormTools.enumFormMode.New:
                        Guid stok_rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_StokBengkel_INSERT"));
                            _rowID = Guid.NewGuid();
                            string RecID_ = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmss}", GlobalVar.DateTimeOfServer) + SecurityManager.UserInitial + " ";
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, RecID_));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, lkpStokBkl.NamaStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, lkpStokBkl.Satuan));
                            db.Commands[0].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }                        
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeliDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, lkpStokBkl.NamaStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@supplier", SqlDbType.UniqueIdentifier, dt.Rows[0]["pemasok"])); 
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }                                                
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtHargaSatuan_Validating(object sender, CancelEventArgs e)
        {
            if (txtHargaSatuan.Text == "")
                txtHargaSatuan.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();
        }

        private void txtDisc1_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc1.Text == "")
                txtDisc1.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();
        }

        private void txtDisc2_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc2.Text == "")
                txtDisc2.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();

        }

        private void txtDisc3_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc3.Text == "")
                txtDisc3.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();

        }

        private void txtPotongan_Validating(object sender, CancelEventArgs e)
        {
            if (txtPotongan.Text == "")
                txtPotongan.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();

        }

        private void txtPpn_Validating(object sender, CancelEventArgs e)
        {
            if (txtPpn.Text == "")
                txtPpn.Text = "0";
            txtJmlBeli.Text = HitungJmlHrg().ToString();
            txtJmlNetto.Text = HitungJmlNetto().ToString();
        }
    }
}
