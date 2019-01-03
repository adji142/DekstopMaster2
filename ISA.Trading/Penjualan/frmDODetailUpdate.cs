using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Master;
using System.Data.SqlTypes;

namespace ISA.Trading.Penjualan
{
    public partial class frmDODetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID, _headerID;
        string _discFormula = "", _barangID = "", _kodeToko, _c1, _noACC = "", _htrID, _stsToko = "", _namatoko="", _jenistrans="";
        string _noAccPusat, _TipeTransaksi = string.Empty;
        double _hrgB = 0, _hrgM = 0, _hrgK = 0,_hrgAkhir = 0;
        double _hrgJualAwal = 0;
        double HrgJual_ = 0; double HrgJualBMK_ = 0;
        double _hrgHPP = 0;
        DateTime _tglDO, _tglAkhir;
        string[] _arrayStok = new string[1000];

        string _TrType = "";
        string flagkg = "";
        string flagHR4;
        string wilayah = "";
        double discwil = 0;
        double _Het = 0;
        double _HargaFinal = 0;
        double nDiscK4;
        double _Hnet;
        double _hrgInput = 0;
        string _NoAccHarga = "";

        double _hrgJual = 0;
        double _hargaFinal = 0;

        DataTable dtDODetail, dtDO;

        public frmDODetailUpdate(Form caller, Guid headerID, string namatoko, string jenistransaksi)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = headerID;
            _namatoko = namatoko;
            _jenistrans = jenistransaksi;
            this.Caller = caller;
        }

        public frmDODetailUpdate(Form caller, Guid headerID, string namatoko, string jenistransaksi, string noAccPusat, String tipetrans)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = headerID;
            _namatoko = namatoko;
            _jenistrans = jenistransaksi;
            _noAccPusat = noAccPusat;
            _TipeTransaksi = tipetrans;
            this.Caller = caller;
        }

        public frmDODetailUpdate(Form caller, Guid rowID, Guid headerID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _headerID = headerID;
            this.Caller = caller;
        }

        public frmDODetailUpdate(Form caller, Guid rowID, Guid headerID, string jt)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _headerID = headerID;
            this.Caller = caller;
            _jenistrans = jt;
        }

        public frmDODetailUpdate(Form caller, Guid rowID, Guid headerID, string jt, string noAccPusat)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _headerID = headerID;
            this.Caller = caller;
            _jenistrans = jt;
            _noAccPusat = noAccPusat;
        }

        private double HitungJmlHrg()
        {
            double _hrgJual = 0;
            double _qtyDO = 0;
            txtQtyDO.Text = txtQtyRQ.Text;
            if(txtHrgJual.Text != "")
                _hrgJual =  txtHrgJual.GetDoubleValue;
            if (txtQtyDO.Text != "")
                _qtyDO =  txtQtyDO.GetDoubleValue;
            return (_qtyDO * _hrgJual);
        }

        private double HitungJmlDisc()
        {
            double hrgNet3Disc = 0;
            try
            {          
                double _jmlHrg = 0;
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;
                if (txtJmlHrg.Text != "")
                    _jmlHrg = double.Parse(txtJmlHrg.Text);
                if (txtDisc1.Text != "")
                    _disc1 = double.Parse(txtDisc1.Text);
                if (txtDisc2.Text != "")
                    _disc2 = double.Parse(txtDisc2.Text);
                if (txtDisc3.Text != "")
                    _disc3 = double.Parse(txtDisc3.Text);

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc")); // 27042013
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, _jmlHrg));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = Math.Round(double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString()),0);
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return (double.Parse(txtJmlHrg.Text) - hrgNet3Disc);
        }

        private double HitungTotalPot()
        {
            int _qtyDO = 0;
            double _pot = 0;
                        
            if (txtQtyDO.Text != "")
                _qtyDO = txtQtyDO.GetIntValue;
            if (txtPotongan.Text != "")
                _pot = double.Parse(txtPotongan.Text);
            return (_qtyDO * _pot);
        }

        private double HitungHrgNetto()
        {
            return (HitungJmlHrg() - HitungJmlDisc() - HitungTotalPot());
        }

       

        private void frmDODetailUpdate_Load(object sender, EventArgs e)
        {
            lookupStock.Focus();
            if (this.Caller is TabelDO)
            {
                Penjualan.TabelDO frmCaller = (Penjualan.TabelDO)this.Caller;
                //namatoko = convert.ToString(frmCaller.lblnamatoko);
                // jenistrans = frmCaller.lbljenistransaksi.ToString();
            }
            try
            {
                //MessageBox.Show(namatoko + "--" + jenistrans);
                dtDO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST")); // 27042013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDO = db.Commands[0].ExecuteDataTable();
                }
                if (dtDO.Rows.Count > 0)
                {
                    _tglDO = (DateTime)dtDO.Rows[0]["TglDO"];
                    _kodeToko = Tools.isNull(dtDO.Rows[0]["KodeToko"], "").ToString();
                    _c1 = Tools.isNull(dtDO.Rows[0]["Cabang1"], "").ToString();
                    _htrID = Tools.isNull(dtDO.Rows[0]["HtrID"], "").ToString();
                    _TrType = Tools.isNull(dtDO.Rows[0]["TransactionType"], "").ToString();
                    _stsToko = Tools.isNull(dtDO.Rows[0]["StsToko"], "").ToString();
                    GetFlagKg(_kodeToko);
                }

                if (formMode == enumFormMode.Update)
                {
                    dtDODetail = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtDODetail = db.Commands[0].ExecuteDataTable();
                    }
                    lookupStock.NamaStock = Tools.isNull(dtDODetail.Rows[0]["NamaStok"], "").ToString();
                    lookupStock.BarangID = Tools.isNull(dtDODetail.Rows[0]["BarangID"], "").ToString();
                    _barangID = lookupStock.BarangID;

                    if (GlobalVar.Gudang == "2808")
                        lookupStock.Enabled = true;
                    else
                        lookupStock.Enabled = false;

                    txtQtyRQ.Text = Tools.isNull(dtDODetail.Rows[0]["QtyRequest"], "").ToString();

                    int JDO = Convert.ToInt32 (Tools.isNull(dtDODetail.Rows[0]["QtyDO"], "0").ToString());
                    if (JDO == 0)
                        txtQtyDO.Text = Tools.isNull(dtDODetail.Rows[0]["QtyRequest"], "").ToString();
                    else
                        txtQtyDO.Text = Tools.isNull(dtDODetail.Rows[0]["QtyDO"], "").ToString();
                    
                    txtSelisih.Text = ((txtQtyRQ.GetIntValue) - (txtQtyDO.GetIntValue)).ToString();
                    txtSatuan.Text = Tools.isNull(dtDODetail.Rows[0]["SatSolo"], "").ToString();
                    txtHrgJual.Text = Tools.isNull(dtDODetail.Rows[0]["HrgJual"], "").ToString();
                    _hrgJualAwal = double.Parse(txtHrgJual.Text);
                    txtJmlHrg.Text = HitungJmlHrg().ToString();
                    txtNoACC.Text = Tools.isNull(dtDODetail.Rows[0]["NoACC"], "").ToString();

                    _noACC = txtNoACC.Text;
                    if (Tools.isNull(_noACC, "") == "" || _noACC.Trim() == "" || _noACC.Trim() == "HARGA" || _noACC.Trim() == "AUTOACC")
                    {
                        lookupStock.Enabled = true;
                        txtHrgJual.Enabled = true;
                        txtHrgJual.ReadOnly = false;
                    }
                    else
                    {
                        lookupStock.Enabled = false;
                        txtHrgJual.Enabled = false;
                        txtHrgJual.ReadOnly = true;
                    }
                    
                    txtDisc1.Text = Tools.isNull(dtDODetail.Rows[0]["Disc1"], "0").ToString(); 
                    txtDisc2.Text = Tools.isNull(dtDODetail.Rows[0]["Disc2"], "0").ToString();
                    txtDisc3.Text = Tools.isNull(dtDODetail.Rows[0]["Disc3"], "0").ToString();
                    txtDisc.Text = HitungJmlDisc().ToString();
                    txtPotongan.Text = Tools.isNull(dtDODetail.Rows[0]["Pot"], "").ToString();
                    txtTotalPotongan.Text = HitungTotalPot().ToString();
                    txtNetto.Text = HitungHrgNetto().ToString();
                    txtDiscKompensasi.Text = Tools.isNull(dtDODetail.Rows[0]["DiscKompensasi"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dtDODetail.Rows[0]["Catatan"], "").ToString();
                    _discFormula = Tools.isNull(dtDODetail.Rows[0]["DiscFormula"], "").ToString();

                    GetHrgBMK();

                    if (SecurityManager.HasRight("TRD.ACC_HARGA"))
                    {
                        //txtHrgJual.Enabled = true;
                        //txtHrgJual.ReadOnly = false;
                        txtNoACC.Enabled = true;
                        txtNoACC.ReadOnly = false;
                    }
                    else
                    {
                        //txtHrgJual.Enabled = false;
                        //txtHrgJual.ReadOnly = true;
                        txtNoACC.Enabled = false;
                        txtNoACC.ReadOnly = true;
                    }

                    if (_noAccPusat == "BONUSAN")
                    {
                        SetTextBoxBasedOnBONUSAN(true);
                    }

                    if (GlobalVar.Gudang == "2808")
                    {
                        txtDisc1.Enabled = true;
                        txtDisc2.Enabled = true;
                        txtDisc3.Enabled = true;
                        txtPotongan.Enabled = true;
                    }
                    else
                    {
                        txtDisc1.Enabled = false;
                        txtDisc2.Enabled = false;
                        txtDisc3.Enabled = false;
                        txtPotongan.Enabled = false;
                    }
                }
                else
                {
                    txtQtyRQ.Text = "0";
                    txtQtyDO.Text = "0";
                    txtSelisih.Text = "0";
                    txtHrgJual.Text = "0";
                    txtJmlHrg.Text = "0";
                    txtDisc1.Text = "0";
                    txtDisc2.Text = "0";
                    txtDisc3.Text = "0";
                    txtDisc.Text = "0";
                    txtPotongan.Text = "0";
                    txtTotalPotongan.Text = "0";
                    txtNetto.Text = "0";
                    txtDiscKompensasi.Text = "0";

                    PopulateExistingStok();
                }
            }
            catch (Exception ex)
            { 
                Error.LogError(ex);
            }            
        }


        private void SetNoACCDO()
        {
            if (_barangID.Substring(0, 3) != "FXB")
            {
                GetHrgJual();
                GetHrgJualPromoBarang(_barangID);
                //GetHrgBMKMessage();
                //GetHrgKhusus();
                GetHargaHpp(_barangID);
                GetHargaPriceList(_tglDO, _barangID);

                _hrgInput = Convert.ToDouble(Tools.isNull(txtHrgJual.Text, "0").ToString())-
                            Convert.ToDouble(Tools.isNull(txtDisc.Text, "0").ToString())-
                            Convert.ToDouble(Tools.isNull(txtTotalPotongan.Text, "0").ToString());

                #region harga khusus R4 Close
                //tutup, tidak berlaku lagi
                //if (_jenistrans == "K4" || _jenistrans == "T4")
                //{
                //    GetFlagHR4("HKR4");
                //    if (nDiscK4 > 0 && _Hnet > 0)
                //    {
                //        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                //        _hrgM = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                //        _HargaFinal = _hrgM;
                //        _NoAccHarga = "AUTOACC";
                //    }
                //    else
                //    {
                //        //tambahan kondisi untuk harga jual kredit, HET - 20% untuk wilayah Jawa Tengah
                //        GetWilayah();
                //        GetDiscWilayah();
                //        if (discwil > 0 && _Hnet > 0)
                //        {
                //            decimal x = Convert.ToDecimal(discwil), y = 100;
                //            _hrgM = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                //            _HargaFinal = _hrgM;
                //            _NoAccHarga = "AUTOACC";
                //        }
                //        else
                //        {
                //            GetHrgJual();
                //        }
                //    }
                //}
                #endregion

                #region harga BE Open
                if (_jenistrans == "K2" || _jenistrans == "K4" || _jenistrans == "T2" || _jenistrans == "T4")
                {
                    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2823")
                    {
                        if (_hrgInput < _hrgHPP)
                        {
                            txtNoACC.Text = "HARGA";
                            txtNoACC.BackColor = Color.Yellow;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        }
                        else if (_hrgInput > _hrgHPP && _hrgInput < _HargaFinal)
                        {
                            txtNoACC.Text = "HARGA";
                            txtNoACC.BackColor = Color.Yellow;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga Standar " + string.Format("{0:N0}", _HargaFinal));
                        }
                        else
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        if (_hrgInput < _hrgHPP)
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        }
                        else if (_hrgInput > _hrgHPP && _hrgInput < _HargaFinal)
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga Standar " + string.Format("{0:N0}", _HargaFinal));
                        }
                        else
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }
                    }

                }
                #endregion

                #region harga FX Open 
                else if (_jenistrans == "KG" || _jenistrans == "KB" || _jenistrans == "KV" || _jenistrans == "KC" ||
                         _jenistrans == "TG" || _jenistrans == "TB" || _jenistrans == "TV" || _jenistrans == "TC")
                {
                    #region gudang 2803 Open
                    if (GlobalVar.Gudang == "2803")
                    {
                        _NoAccHarga = "AUTOACC";
                        txtNoACC.Text = "AUTOACC";
                        txtNoACC.BackColor = Color.White;
                    }
                    #endregion

                    #region gudang 2823
                    if (GlobalVar.Gudang == "2823")
                    {
                        _HargaFinal = _hrgB;
                        _NoAccHarga = "AUTOACC";
                        txtNoACC.Text = "AUTOACC";
                        txtNoACC.BackColor = Color.White;
                    }
                    #endregion

                    #region gudang 2807 Close
                    //if (GlobalVar.Gudang == "2807")
                    //{
                    //    _HargaFinal = _hrgB;
                    //}
                    #endregion

                    #region gudang 2808
                    if (GlobalVar.Gudang == "2808")
                    {
                        if (_hrgInput < _hrgHPP)
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }
                        else if (_hrgInput < _HargaFinal && _hrgInput >= _hrgHPP)
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }
                        else
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }
                    }
                    #endregion

                    #region depo standar
                    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2823" && GlobalVar.Gudang != "2808")
                    {
                        _HargaFinal = _hrgB;

                        if (_hrgInput < _hrgHPP)
                        {
                            txtNoACC.Text = "HARGA";
                            txtNoACC.BackColor = Color.Yellow;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        }
                        else if (_hrgInput > _hrgHPP && _hrgInput < _HargaFinal)
                        {
                            txtNoACC.Text = "HARGA";
                            txtNoACC.BackColor = Color.Yellow;
                            //MessageBox.Show("Harga Jual lebih Kecil dari Harga Standar " + string.Format("{0:N0}", _HargaFinal));
                        }
                        else
                        {
                            txtNoACC.Text = "AUTOACC";
                            txtNoACC.BackColor = Color.White;
                        }

                        #region kondisi lama Close
                        //if (_TrType == "KG" || _TrType == "KB" || _TrType == "KV" || _TrType == "TB" || _TrType == "TV" || _TrType == "TG")
                        //{
                        //    if (_hrgInput < _hrgHPP)
                        //    {
                        //        txtNoACC.Text = "HARGA";
                        //        txtNoACC.BackColor = Color.Yellow;
                        //        //MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        //    }
                        //    else if (_hrgInput > _hrgHPP && _hrgInput < _HargaFinal)
                        //    {
                        //        txtNoACC.Text = "HARGA";
                        //        txtNoACC.BackColor = Color.Yellow;
                        //        //MessageBox.Show("Harga Jual lebih Kecil dari Harga Standar " + string.Format("{0:N0}", _HargaFinal));
                        //    }
                        //    else
                        //    {
                        //        txtNoACC.Text = "AUTOACC";
                        //        txtNoACC.BackColor = Color.White;
                        //    }
                        //}
                        //else
                        //{
                        //    if (_hrgInput < _hrgHPP)
                        //    {
                        //        txtHrgJual.Text = _HargaFinal.ToString();
                        //        txtNoACC.Text = "AUTOACC";
                        //        txtNoACC.BackColor = Color.White;
                        //        //MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        //    }
                        //    else if (_hrgInput < _HargaFinal && _hrgInput >= _hrgHPP)
                        //    {
                        //        txtHrgJual.Text = _HargaFinal.ToString();
                        //        txtNoACC.Text = "AUTOACC";
                        //        txtNoACC.BackColor = Color.White;
                        //        //MessageBox.Show("Harga Jual lebih Kecil dari Harga Standar " + string.Format("{0:N0}", _HargaFinal));
                        //    }
                        //    else
                        //    {
                        //        txtNoACC.Text = "AUTOACC";
                        //        txtNoACC.BackColor = Color.White;
                        //    }
                        //}
                        #endregion

                        //kembalikan ke NoAcc sebelumnya jika sudah di-acc dan NoAcc-nya berubah kembali menjadi Harga
                        //dan harga jual setelah diedit >= harga jual sebelum pengeditan
                        if (txtNoACC.Text == "HARGA" && _hrgInput >= _hrgJualAwal && _noACC != string.Empty && _noACC != "HARGA" && _noACC != "AUTOACC")
                        {
                            txtNoACC.Text = _noACC;
                            txtNoACC.BackColor = Color.Yellow;
                        }

                    }
                    #endregion
                }
                #endregion 
            }
        }


        private void GetHargaPriceList(DateTime Tgl, string BrgID)
        {
            if (BrgID != "")
            {
                try
                {
                    DataTable dtPl = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHET"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, Tgl));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, BrgID));
                        dtPl = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtPl.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(Tools.isNull(Convert.ToDouble(dtPl.Rows[0]["Hnet"]), "0").ToString()) > 0)
                            _Hnet = Convert.ToDouble(dtPl.Rows[0]["Hnet"]);
                    }
                    else
                    {
                        _Hnet = 0;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }





        private void SetNoACC()
        {
            if (_TrType == "KG" || _TrType == "KB" || _TrType == "KV" || _TrType == "KC")
            {
                if (GlobalVar.Gudang == "2828")
                {
                    double _hrgJualAkhir = txtHrgJual.GetDoubleValue;
                    GetHrgJualDO();
                    GetHargaHpp(_barangID);

                    if (_hrgJualAkhir < HrgJualBMK_ && _hrgJualAkhir >= _hrgHPP)
                    {
                        MessageBox.Show("Harga dibawah standar");
                        txtHrgJual.Text = HrgJualBMK_.ToString();
                        txtNoACC.Text = "AUTOACC";
                        txtNoACC.BackColor = Color.White;
                    }
                    else if (_hrgJualAkhir < _hrgHPP)
                    {
                        MessageBox.Show("Harga dibawah HPP");
                        txtHrgJual.Text = HrgJualBMK_.ToString();
                        txtNoACC.Text = "AUTOACC";
                        txtNoACC.BackColor = Color.White;
                    }
                    else
                    {
                        txtNoACC.Text = "AUTOACC";
                        txtNoACC.BackColor = Color.White;
                    }

                    //kembalikan ke NoAcc sebelumnya jika sudah di-acc dan NoAcc-nya berubah kembali menjadi Harga
                    //dan harga jual setelah diedit >= harga jual sebelum pengeditan
                    if (txtNoACC.Text == "HARGA" && _hrgJualAkhir >= _hrgJualAwal && _noACC != string.Empty && _noACC != "HARGA" && _noACC != "AUTOACC")
                    {
                        txtNoACC.Text = _noACC;
                        txtNoACC.BackColor = Color.Yellow;
                    }
                }
            }
            else
            {
                double _hrgJualAkhir = txtHrgJual.GetDoubleValue;
                GetHrgJualDO();
                GetHargaHpp(_barangID);

                if (_hrgJualAkhir < HrgJualBMK_)
                {
                    txtNoACC.Text = "HARGA";
                    txtNoACC.BackColor = Color.Yellow;
                }
                else if (_hrgJualAkhir < _hrgHPP)
                {
                    txtNoACC.Text = "HARGA";
                    txtNoACC.BackColor = Color.Yellow;
                    MessageBox.Show("Harga Jual lebih Kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                }
                else
                {
                    txtNoACC.Text = "AUTOACC";
                    txtNoACC.BackColor = Color.White;
                }

                //kembalikan ke NoAcc sebelumnya jika sudah di-acc dan NoAcc-nya berubah kembali menjadi Harga
                //dan harga jual setelah diedit >= harga jual sebelum pengeditan
                if (txtNoACC.Text == "HARGA" && _hrgJualAkhir >= _hrgJualAwal && _noACC != string.Empty && _noACC != "HARGA" && _noACC != "AUTOACC")
                {
                    txtNoACC.Text = _noACC;
                    txtNoACC.BackColor = Color.Yellow;
                }
            }
        }


        private void GetHrgJualDO()
        {
            if (_barangID != "")
            {
                GetHrgJual();
                if (_jenistrans == "K4")
                {
                    GetFlagHR4("HKR4");
                    if (flagHR4 == "" || flagHR4 == "0")
                    {
                        GetWilayah();
                        GetDiscWilayah();
                        GetHET();

                        if (_Het == 0)
                        {
                            MessageBox.Show("HET masih kosong..!");
                            return;
                        }
                        if (discwil > 0)
                        {
                            decimal x = Convert.ToDecimal(discwil), y = 100;
                            decimal z = x / y;
                            _hrgM = _Het - (Math.Round(Convert.ToDouble(z * Convert.ToDecimal(_Het)), 0));
                            HrgJualBMK_ = _hrgM;
                        }

                    }
                    else
                    {
                        GetHrgJualHKR4();
                        if (flagHR4 != "" && flagHR4 != "0")
                        {
                            decimal x = Convert.ToDecimal(flagHR4), y = 100;
                            decimal z = x / y;
                            HrgJualBMK_ = HrgJual_ - (Math.Round(Convert.ToDouble(z * Convert.ToDecimal(HrgJual_)), 0));
                        }
                        else
                        {
                            HrgJualBMK_ = _hrgM;
                        }
                    }
                }

                #region ijo2
                //try
                //{
                //    DataTable dtGetHrgJual = new DataTable();
                //    using (Database db = new Database())
                //    {
                //        db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
                //        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                //        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                //        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
                //        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                //        db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                //        dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                //    }
                //    if (dtGetHrgJual.Rows.Count > 0)
                //    {
                //        HrgJual_  = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                //        HrgJualBMK_ = HrgJual_;
                //    }
                //    else
                //    {
                //        HrgJual_ = 0;
                //        HrgJualBMK_ = 0;
                //    }

                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                #endregion
            }
        }


        private void GetWilayah()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                    wilayah = Tools.isNull(dt.Rows[0]["Alamat3"], "").ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        //private void GetWilayah()
        //{
        //    try
        //    {
        //        using (Database db = new Database())
        //        {
        //            DataTable dt = new DataTable();
        //            db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
        //            dt = db.Commands[0].ExecuteDataTable();
        //            wilayah = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString().Trim();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //}


        private void GetDiscWilayah()
        {
            //discount per wilayah
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_getDiscWilayah_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, wilayah));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        discwil = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DT"], "0").ToString());
                    else
                        discwil = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void GetHET()
        {
            if (_barangID != "")
            {
                try
                {
                    DataTable dtHrgw = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHET"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtHrgw = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtHrgw.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(Tools.isNull(Convert.ToDouble(dtHrgw.Rows[0]["Hnet"]), "0").ToString()) > 0)
                            _Het = Convert.ToDouble(dtHrgw.Rows[0]["Hnet"]);
                    }
                    else
                    {
                        _Het = 0;
                    }
                    HrgJualBMK_ = _Het;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }



        private void GetHrgJualHKR4()
        {
            if (_barangID != "")
            {
                try
                {
                    DataTable dtGetHrgJualR4 = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHrgJual_HKR4"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtGetHrgJualR4 = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgJualR4.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(Tools.isNull(Convert.ToDouble(dtGetHrgJualR4.Rows[0]["Hnet"]), "0").ToString()) > 0)
                            HrgJual_ = Convert.ToDouble(dtGetHrgJualR4.Rows[0]["Hnet"]);
                        else
                            HrgJual_ = Convert.ToDouble(dtGetHrgJualR4.Rows[0]["hjual_t"]);
                    }
                    else
                    {
                        HrgJual_ = 0;
                    }
                    HrgJualBMK_ = HrgJual_;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }
        
        

        private void GetHrgJual()
        {
            try
            {
                DataTable dtGetHrgJual = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                    dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgJual.Rows.Count > 0)
                {
                    HrgJual_ = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                    HrgJualBMK_ = HrgJual_;
                    _hargaFinal = HrgJual_;
                }
                else
                {
                    HrgJual_ = 0;
                    HrgJualBMK_ = 0;
                    _hargaFinal = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void GetFlagHR4(string cKey)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_getFlagHR4_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, cKey));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        flagHR4 = Tools.isNull(dt.Rows[0]["Value"], "").ToString();
                    else
                        flagHR4 = "";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        //private void GetHrgJualDO()
        //{
        //    if (_barangID != "" && double.Parse(txtQtyDO.Text) != 0)
        //    {
        //        try
        //        {
        //            DataTable dtGetHrgJual = new DataTable();
        //            using (Database db = new Database())
        //            {
        //                db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
        //                db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
        //                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
        //                db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
        //                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
        //                db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, _c1));
        //                dtGetHrgJual = db.Commands[0].ExecuteDataTable();
        //            }
        //            if (dtGetHrgJual.Rows.Count > 0)
        //            {
        //                HrgJualBMK_ = Convert.ToDouble(Tools.isNull(dtGetHrgJual.Rows[0]["HrgJual"],0).ToString());
        //            }
        //            else
        //            {
        //                HrgJualBMK_ = 0;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Error.LogError(ex);
        //        }
        //    }
        //}


        private void GetFlagKg(string kodetoko)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodetoko));
                    dt = db.Commands[0].ExecuteDataTable();
                    flagkg = Tools.isNull(dt.Rows[0]["RefSupervisor"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        




        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if(!ValidateInput())
            {
                return;
            }

            //SetNoACC();
            SetNoACCDO();

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();                     
                        string _recID = Tools.CreateFingerPrint();
                        double potongan = 0;
                        using (Database db = new Database())
                        {
                            CekBarangID(lookupStock.BarangID);
                            //if(lookupStock.BarangID.Substring(0,3).Equals("FXB"))
                            //{
                            //    potongan = 1;
                            //}
                            //if (_noACC.Equals("BONUSAN"))
                            //{
                            //    potongan = 1;
                            //}
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recID));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _htrID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, txtQtyRQ.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, txtQtyDO.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(txtHrgJual.Text)));
                            //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, ""));
                            //db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, double.Parse(txtDisc1.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, double.Parse(txtDisc2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, double.Parse(txtDisc3.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, potongan));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@nboPrint", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text == string.Empty ? "AUTOACC" : txtNoACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            
                        }
                        AddingNewItemToArrayStok(lookupStock.BarangID);
                        //MessageBox.Show("Data telah tersimpan");
                        //this.DialogResult = DialogResult.OK;
                        Clear();
                        lookupStock.Focus();
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDODetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDODetail.Rows[0]["HtrID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDODetail.Rows[0]["BarangID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, txtQtyRQ.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, txtQtyDO.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(txtHrgJual.Text)));
                            //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtDODetail.Rows[0]["KodeToko"]));
                            //db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dtDODetail.Rows[0]["TglSuratJalan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, double.Parse(txtDisc1.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, double.Parse(txtDisc2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, double.Parse(txtDisc3.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDODetail.Rows[0]["Pot"]));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDODetail.Rows[0]["DiscFormula"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, dtDODetail.Rows[0]["NoDOBO"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        //MessageBox.Show("Data telah tersimpan");
                        this.DialogResult = DialogResult.OK;
                        cmdCLOSE.PerformClick();
                        this.Close();
                        break;
                }
                this.DialogResult = DialogResult.OK;
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void Clear()
        {
            txtQtyRQ.Text = "0";
            txtHrgJual.Text = "0";
            txtDisc1.Text = "0";
            txtDisc2.Text = "0";
            txtDisc3.Text = "0";
            txtSatuan.Text = "";
            txtQtyDO.Text = "0";
            txtNetto.Text = "0";
            txtJmlHrg.Text = "0";
            _barangID = "";
            txtCatatan.Text = "";
            txtNoACC.Text = "";
            _noACC = "";
            lookupStock.BarangID = _barangID;
            lookupStock.NamaStock = "";
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            int _qtyRQ = txtQtyRQ.GetIntValue;
            double _hrgJual = double.Parse(txtHrgJual.Text);
    
            if (_qtyRQ <= 0)
            {
                errorProvider1.SetError(txtQtyRQ, "Quantity Request tidak boleh <= 0");
                valid = false;
            }

            if (_hrgJual <= 0 && _noAccPusat != "BONUSAN")
            {
                errorProvider1.SetError(txtHrgJual, "Harga Jual tidak boleh <= 0");
                valid = false;
            }

            if (_barangID == "")
            {
                errorProvider1.SetError(lookupStock, "Barang tidak boleh kosong");
                valid = false;
            }

            if (_noAccPusat == "BONUSAN" && Tools.Left(_barangID, 3) != "FXB")
            {
                errorProvider1.SetError(lookupStock, "DO bonusan. Barang yang dipilih bukan barang bonusan");
                valid = false;
            }

            bool validItem = true;
            string jenisTransBrg = lookupStock.BarangID.Substring(0, 3);

            if (jenisTransBrg == "K2" && (_jenistrans != "FB2" || _jenistrans != "FE2" || _jenistrans != "FXB"))
            {
                validItem = false;
            }
            else if (jenisTransBrg == "K4" && (_jenistrans != "FB4" || _jenistrans != "FE4"))
            {
                validItem = false;
            }
            else if (jenisTransBrg == "KG" && (_jenistrans != "FX2" || _jenistrans != "FX4"))
            {
                validItem = false;
            }
            else if (jenisTransBrg == "KB" && _jenistrans != "FAB")
            {
                validItem = false;
            }
            else if (jenisTransBrg == "KC" && (_jenistrans != "FC2" || _jenistrans != "FC4"))
            {
                validItem = false;
            }
            else if (jenisTransBrg == "KV" && (_jenistrans != "FA2" || _jenistrans != "FA4"))
            {
                validItem = false;
            }

            if (!validItem)
            {
                errorProvider1.SetError(lookupStock, "Barang yang dipilih tidak sesuai dengan jenis transaksi " + _jenistrans);
                valid = validItem;
            }

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmDOUpdate)
                {
                    frmDOUpdate frmCaller1 = (frmDOUpdate)this.Caller;
                    TabelDO frmCaller2 = (TabelDO)frmCaller1.Caller;
                    frmCaller2.RefreshRowDataDO(_headerID.ToString());
                    frmCaller2.RefreshDataDetailDO();
                    frmCaller2.FindHeader("RowID", _headerID.ToString());
                    frmCaller2.FindDetail("DetailRowID", _rowID.ToString());
                }
                else if (this.Caller is TabelDO)
                {
                    if (formMode == enumFormMode.New)
                    {
                        TabelDO frmCaller = (TabelDO)this.Caller;
                        frmCaller.RefreshDataDO();
                        frmCaller.FindHeader("RowID", _headerID.ToString());
                        frmCaller.RefreshDataDetailDO();
                        frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                    }
                    else
                    {
                        TabelDO frmCaller = (TabelDO)this.Caller;
                        frmCaller.RefreshDataDO();
                        frmCaller.FindHeader("RowID", _headerID.ToString());
                        frmCaller.RefreshDataDetailDO();
                        frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                    }
                }
                else
                {
                    if (this.Caller is frmDOUpdate)
                    {
                        frmDOUpdate frmCaller1 = (frmDOUpdate)this.Caller;
                        TabelDO frmCaller2 = (TabelDO)frmCaller1.Caller;
                        frmCaller2.RefreshRowDataDO(_headerID.ToString());
                        frmCaller2.FindHeader("RowID", _headerID.ToString());
                    }
                }
            }
            this.Close();
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lookupStock.Satuan;
            _barangID = lookupStock.BarangID;

            String TipeTrans;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[fsp_GetTipeTransaksi]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _barangID));
                TipeTrans = db.Commands[0].ExecuteScalar().ToString();
            }

            if (_jenistrans != TipeTrans) //jika tipe transaksi beda dgn tipe transaksi DO Header maka tidak boleh simpan
            {
                MessageBox.Show("Barang Yang Anda Pilih Bukan Barang Untuk Tipe Transaksi " + _TipeTransaksi + "\nPilih Barang Lain!","Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                cmdSAVE.Enabled = false;
            }
            else
            {
                cmdSAVE.Enabled = true;
            }


            if (CheckExistingStok())
            {
                if (MessageBox.Show("Nama barang sudah ada.\nApakah ini Hadiah/Bonus?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetTextBoxBasedOnBONUSAN(true);
                }
                else if (_noAccPusat == "BONUSAN")
                {
                    SetTextBoxBasedOnBONUSAN(true);
                }
                else
                {
                    SetTextBoxBasedOnBONUSAN(false);
                    Clear();
                }
            }
            else
            {
                if (_noAccPusat == "BONUSAN")
                {
                    SetTextBoxBasedOnBONUSAN(true);
                }
                else
                {
                    SetTextBoxBasedOnBONUSAN(false);
                }

                //GetHrgJual();
                ////GetHrgBMK();
                //txtHrgJual.Text = _hargaFinal.ToString();
                //MessageBox.Show(_hargaFinal.ToString());

            }

            GetHrgJual();
            //GetHrgBMK();
            txtHrgJual.Text = _hargaFinal.ToString();

        }

        private void SetTextBoxBasedOnBONUSAN(bool bonusan)
        {
            if (bonusan)
            {
                _noACC = "BONUSAN";
                txtHrgJual.Text = "0";
                txtPotongan.Text = "0";
                txtDisc1.Text = "0";
                txtDisc2.Text = "0";
                txtDisc3.Text = "0";
                txtHrgJual.Enabled = false;
                txtHrgJual.ReadOnly = true;
                //txtPotongan.Enabled = false;
                //txtPotongan.ReadOnly = true;
                //txtDisc1.Enabled = false;
                //txtDisc1.ReadOnly = true;
                //txtDisc2.Enabled = false;
                //txtDisc2.ReadOnly = true;
                //txtDisc3.Enabled = false;
                //txtDisc3.ReadOnly = true;
            }

            else
            {
                _noACC = "";
                txtHrgJual.Text = "0";
                txtPotongan.Text = "0";
                txtDisc1.Text = "0";
                txtDisc2.Text = "0";
                txtDisc3.Text = "0";
                txtHrgJual.Enabled = true;
                txtHrgJual.ReadOnly = false;
                //txtPotongan.Enabled = true;
                //txtPotongan.ReadOnly = false;
                //txtDisc1.Enabled = true;
                //txtDisc1.ReadOnly = false;
                //txtDisc2.Enabled = true;
                //txtDisc2.ReadOnly = false;
                //txtDisc3.Enabled = true;
                //txtDisc3.ReadOnly = false;
            }
        }

        private bool CheckExistingStok()
        {
            bool result = false;
            int count = 0;
            while (_arrayStok[count] != null)
            {
                if (_arrayStok[count] == _barangID)
                {
                    result = true;
                }
                count++;
            }
            return result;


            //int nRows = 0;
            //try
            //{
            //    DataTable dtDetail = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST"));

            //        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
            //        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
            //        dtDetail = db.Commands[0].ExecuteDataTable();
            //    }
            //    nRows  = dtDetail.Rows.Count;             
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}

            //if (nRows > 0)
            //    return true;
            //else
            //    return false;

        }

        private void AddingNewItemToArrayStok(string _newBarangID)
        {
            int count = 0;
            while (_arrayStok[count] != null)
            {
                count++;
            }
            _arrayStok[count] = _newBarangID;
        }

        private void PopulateExistingStok()
        {
            try
            {
                DataTable dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_BARANG_HEADERID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }

                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    _arrayStok[i] = Tools.isNull(dtDetail.Rows[i]["BarangID"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void GetHrgBMK()
        {
            try
            {
                DataTable dtGetHrgBMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetInfoHrgJualDepo")); //cek HR, 25032013
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, _c1));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }

                _hrgB =Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"] );
                _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"] );
                _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"] );

                if (_hrgAkhir > 0)
                {
                    if (dtGetHrgBMK.Rows.Count>0)
                    {
                        _tglAkhir = (DateTime)dtGetHrgBMK.Rows[0]["TglTerakhir"];
                    }
                    else
                    {
                        _tglAkhir = new DateTime(1900, 1, 1);
                    }
                   
                }

                if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0)
                {
                    lblBMK.Text = "B: " + _hrgB + "  M: " + _hrgM + "  K: " + _hrgK;
                }
                else
                {
                    lblBMK.Text = "Belum ada harga BMK"; 
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            } 
        }

        private void frmDODetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmDOUpdate)
                {
                    frmDOUpdate frmCaller1 = (frmDOUpdate)this.Caller;
                    TabelDO frmCaller2 = (TabelDO)frmCaller1.Caller;
                    frmCaller2.RefreshRowDataDO(_headerID.ToString());
                    frmCaller2.RefreshDataDetailDO();
                    frmCaller2.FindHeader("RowID", _headerID.ToString());
                    frmCaller2.FindDetail("DetailRowID", _rowID.ToString());
                }
                else if (this.Caller is TabelDO)
                {
                    if (formMode == enumFormMode.New)
                    {
                        TabelDO frmCaller = (TabelDO)this.Caller;
                        frmCaller.RefreshDataDetailDO();
                        frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                    }
                    else
                    {
                        TabelDO frmCaller = (TabelDO)this.Caller;
                        frmCaller.RefreshDataDetailDO();
                        frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                    }
                }
                else
                {
                    if (this.Caller is frmDOUpdate)
                    {
                        frmDOUpdate frmCaller1 = (frmDOUpdate)this.Caller;
                        TabelDO frmCaller2 = (TabelDO)frmCaller1.Caller;
                        frmCaller2.RefreshRowDataDO(_headerID.ToString());
                        frmCaller2.FindHeader("RowID", _headerID.ToString());
                    }
                }
            }
        }

       private void GetHrgBMKMessage()
        {
            if (_noACC != "BONUSAN")
            {

                GetHrgBMK();

                string msgBMK = "", msgAkhir = "";

                msgBMK = "Harga BMK yaitu \nB: " + _hrgB.ToString("#,##0") + "  M: " + _hrgM.ToString("#,##0") + "  K: " + _hrgK.ToString("#,##0");

                string sTglAkhir = "-";

                if (_hrgAkhir > 0)
                {
                    sTglAkhir = _tglAkhir.ToString("dd-MMM-yyyy");
                }

                msgAkhir = "Penjualan terakhir Rp. " + _hrgAkhir.ToString("#,##0")
                        + " Tgl. " + sTglAkhir;

                MessageBox.Show(msgBMK + System.Environment.NewLine + msgAkhir, "Info Harga Jual");
            }
            //MessageBox.Show(_namatoko + "---" + _jenistrans);
            string _jenis2 = Tools.Left(_jenistrans, 1);
            if (_namatoko != "ECERAN CASH")
            {
                if (_jenis2 == "T" || _jenis2 == "t")
                {
                    //txtHrgJual.Text = _hrgB.ToString();
                    HrgJualBMK_ = _hrgB;
                }
                if (_jenis2 == "K" || _jenis2 == "k")
                {
                    //txtHrgJual.Text = _hrgM.ToString();
                    HrgJualBMK_ = _hrgM;
                }
            }
            else
            {
                //txtHrgJual.Text = _hrgK.ToString();
                HrgJualBMK_ = _hrgK;
            }
        }

       private void GetHargaHpp(string barangID)
       {
           try
           {
               DataTable dtGetHargaHPP = new DataTable();
               using (Database db = new Database())
               {
                   db.Commands.Add(db.CreateCommand("usp_cekHargaHPP"));
                   db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                   dtGetHargaHPP = db.Commands[0].ExecuteDataTable();
               }

               if (dtGetHargaHPP.Rows.Count > 0)
               {
                   _hrgHPP = Convert.ToDouble(dtGetHargaHPP.Rows[0]["HPP"]);
               }
               else
               {
                   if (barangID == "FXBBISKUITKL" || barangID == "FXBSOFTDRINK" || barangID == "FXBKURSIBKSO" || barangID == "FXBTSHIRTOBL")
                   {
                       _hrgHPP = 0;
                   }
                   else
                   {
                       MessageBox.Show("Barang Belum punya history harga hpp, segera hubungi HO");
                   }
               }
           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
       }

        private void CekBarangID(string barangID)
        {
            try
            {
                DataTable dtCekBarangID = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_Barang"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtCekBarangID = db.Commands[0].ExecuteDataTable();
                }
                if (dtCekBarangID.Rows.Count > 0)
                {
                    MessageBox.Show("Barang ini sudah ada di order penjualan ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtHrgJual_Leave(object sender, EventArgs e)
        {
            SetNoACCDO();
        }

        private void txtQtyRQ_Validated(object sender, EventArgs e)
        {
            if (txtQtyRQ.Text == "")
                txtQtyRQ.Text = "0";
            txtQtyDO.Text = txtQtyRQ.Text;
            //if (_noACC != "BONUSAN")
            //{
            //        //GetHrgJual();
            //        txtJmlHrg.Text = HitungJmlHrg().ToString();
            //        //txtHrgJual_Validating(sender, new CancelEventArgs());
            //        //GetHrgBMKMessage();             
            //}
        }

        private void txtHrgJual_Validating(object sender, CancelEventArgs e)
        {
            if (txtHrgJual.GetDoubleValue < 0)
            {
                e.Cancel = true;
                MessageBox.Show("Harga tidak boleh kurang dari 0");
                return;     
            }

            if (txtHrgJual.Text == "")
                txtHrgJual.Text = "0";

            if (txtDisc1.Text == "")
                txtDisc1.Text = "0";

            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = HitungJmlDisc().ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();

            if (lookupStock.BarangID != "[CODE]" && lookupStock.BarangID != "")
            {
                if (GlobalVar.Gudang != "2808")
                {
                    if (ValidBulat())
                    {
                        if (Convert.ToDouble(Tools.isNull(txtHrgJual.Text, "0").ToString()) < _HargaFinal)
                        {
                            if (MessageBox.Show("Harga jual Netto tidak sama dengan Harga B-M-K !!!", "Lanjut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                if (formMode == enumFormMode.New)
                                {
                                    lookupStock.Focus();
                                }
                                else
                                {
                                    txtHrgJual.Focus();
                                }
                                return;
                            }
                        }
                        else
                        {
                            BulatBulat();
                        }

                    }
                    else if (txtNoACC.Text == "PMBULAT")
                    {
                        _noACC = "";
                        txtNoACC.Text = "";
                    }
                }
                else
                {
                    _noACC = "AUTOACC";
                    txtNoACC.Text = "AUTOACC";
                }
            }
        }


        private void txtDisc1_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc1.Text == "")
                txtDisc1.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(),0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text,"0").ToString()); 
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //txtDisc.Text = HitungJmlDisc().ToString();
            SetNoACCDO();
        }

        private void txtDisc2_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc2.Text == "")
                txtDisc2.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //txtDisc.Text = HitungJmlDisc().ToString();
        }

        private void txtDisc3_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc3.Text == "")
                txtDisc3.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //txtDisc.Text = HitungJmlDisc().ToString();
        }

        private void lookupStock_Validating(object sender, CancelEventArgs e)
        {
           //'lookupStock.
            if (lookupStock.NamaStock.Trim()==string.Empty)
            {
                lookupStock.Focus();
            }
        }

        /*Tambahan Pembulat*/
        private void ACC_Pembulat()
        {
            string NoACC_ = "";
            double HrgNetto_ = 0;
            double _Pot = 0;
            if (txtPotongan.Text != "")
                _Pot = double.Parse("0");

            HrgNetto_ = HrgNetto(_Pot);

            if ((HrgJualBMK_ >= 1000 && HrgJualBMK_ <= 9999) && ((HrgJualBMK_ - HrgNetto_ <= 50) && (HrgJualBMK_ - HrgNetto_ > 0)))
            {
                NoACC_ = "PMBULAT";
            }
            else if ((HrgJualBMK_ > 9999 && HrgJualBMK_ <= 99999) && ((HrgJualBMK_ - HrgNetto_ <= 250) && (HrgJualBMK_ - HrgNetto_ > 0)))
            {
                NoACC_ = "PMBULAT";
            }
            else if ((HrgJualBMK_ >= 100000 && HrgJualBMK_ < 1000000) && ((HrgJualBMK_ - HrgNetto_ <= 2500) && (HrgJualBMK_ - HrgNetto_ > 0)))
            {
                NoACC_ = "PMBULAT";
            }else
            {
                NoACC_ = "";
            }
          
                if (NoACC_!="")
                {

                  txtNoACC.Text = NoACC_;
                  _noACC = NoACC_;
                 }
                else if (txtNoACC.Text != "" && txtNoACC.Text == "PMBULAT")
                {

                    txtNoACC.Text = "";
                    _noACC = "";
                }


            
        }
        private double HrgNetto(Double _Pot)
        {
            double hrgNetto = 0;
            try
            {
                double HrgJual__ = 0;
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;

                if (txtJmlHrg.Text != "")
                    HrgJual__ = double.Parse(txtHrgJual.Text);
                if (txtDisc1.Text != "")
                    _disc1 = double.Parse(txtDisc1.Text);
                if (txtDisc2.Text != "")
                    _disc2 = double.Parse(txtDisc2.Text);
                if (txtDisc3.Text != "")
                    _disc3 = double.Parse(txtDisc3.Text);
               

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetPembulatACC"));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, HrgJual__));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, _Pot));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNetto = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNetto"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return hrgNetto;
        }

        
        private bool ValidBulat()
        {

            bool Valid = false;
            //HrgJual_ = Convert.ToDouble(txtHrgJual.Text);
            if (lookupStock.BarangID != "[CODE]" && lookupStock.BarangID != "")
            {
                if (_noACC != "BONUSAN" && (HrgNetto(0) < HrgJualBMK_))
                {

                    if (lookupStock.BarangID.ToString().Substring(0, 3) == "FAL" || lookupStock.BarangID.ToString().Substring(0, 3) == "FAB" || lookupStock.BarangID.ToString().Substring(0, 3) == "FAT")
                    {
                        Valid = false;
                    }else
                    {
                        Valid = true;
                    }
                }
            }
            return Valid;
        }
        private void BulatBulat()
        {
            if (_noACC != "BONUSAN")
            {

                if (HrgNetto(0) < HrgJualBMK_)
                {
                    
                    if (lookupStock.BarangID.ToString().Substring(0, 3) == "FAL" || lookupStock.BarangID.ToString().Substring(0, 3) == "FAB" || lookupStock.BarangID.ToString().Substring(0, 3) == "FAT")
                    {
                        _noACC = "";
                    }
                    else
                    {
                        ACC_Pembulat();
                    }
                }
                else
                {
                    if (txtNoACC.Text.Trim() != "" && txtNoACC.Text.Trim() == "PMBULAT")
                    {

                        txtNoACC.Text = "";
                        _noACC = "";
                    }
                }
            } 
        }

        private void txtQtyRQ_TextChanged(object sender, EventArgs e)
        {

        }

        private void lookupStock_Load(object sender, EventArgs e)
        {

        }

        private void txtPotongan_Validating(object sender, CancelEventArgs e)
        {
            if (txtPotongan.Text == "")
                txtPotongan.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            SetNoACCDO();
        }

        private void txtQtyDO_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyDO.Text == "")
                txtQtyDO.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyRQ.Text, "0").ToString());
            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            SetNoACCDO();
        }

        private void txtQtyRQ_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyDO.Text == "")
                txtQtyDO.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyRQ.Text, "0").ToString());
            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            SetNoACCDO();
        }

        private void GetHrgJualPromoBarang(string idbrg)
        {
            if (_barangID != "")
            {
                try
                {
                    DataTable dtBrgPromo = new DataTable();
                    DataTable dtHrgBrgPromo = new DataTable();

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_CekBarangPromo"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                        dtBrgPromo = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtBrgPromo.Rows.Count > 0)
                    {
                        //_PromoBrg = "1";
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetHrgJual_BarangPromo"));
                            db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                            db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                            dtHrgBrgPromo = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    if (dtHrgBrgPromo.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtHrgBrgPromo.Rows[0]["hjual_c"]);
                        HrgJualBMK_ = _hrgJual;
                        _hargaFinal = _hrgJual;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void txtQtyDO_KeyDown(object sender, KeyEventArgs e)
        {
            txtQtyRQ.Text = txtQtyDO.Text;
        }



    
    }
}
