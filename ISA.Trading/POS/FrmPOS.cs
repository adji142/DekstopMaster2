using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Trading;
using ISA.Controls;
using ISA.DAL;
using ISA.Trading.Controls;
using System.Data.SqlTypes;
using System.Globalization;
using ISA.Common;
using ISA.Trading.Class;
using Microsoft.Reporting.WinForms;


namespace ISA.Trading.POS
{

    public partial class FrmPOS : ISA.Trading.BaseForm
    {
        public enum EnumPasif { All, Aktiv };
        double  menit = 0, varmenit=0;
        double  miliDetik = 0, varmilidetik=0;
        string initCab = GlobalVar.CabangID;
        string initgudang = GlobalVar.Gudang;
        string docNoDO = "NOMOR_DO_TAX";
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowid, _headerID, _rowIDDetail;
        string noAccPiutang = "", noAccPusat = "";
        object _TglACCPiutang, _TglReorder;
        string printerName, printer;
        public int nRowGridView = 0;
        public Boolean PengajuanHarga = false;
        public Boolean ValidasiPenjualanTunai = false;

        string HtrId;
        string cab1;
        string cab2;
        string cab3;
        string gudang;
        int hari = 0;
        int nprint = 0;
        EnumPasif _LPasifType = EnumPasif.Aktiv;


        // variabel dalam toko
        string kodetoko;
        string statustoko;
        string alamatkirim;
        string kotatoko;
        string stsTk, _stsToko;

        //variabel dalam sales
        string idsales;

        DateTime tanggal;
        int total;
        int a,b;
        double kuantiti, kuantiti2;
        double harga, d1, d2, d3, potrp;
        double jumlah, jumnet, jumnetakhir, jumdis;

        //variabel simpan detail
        string _noACC = "", _htrID;
        DataTable dtDODetail, dtDO;
        Guid _notaHeaderRowID;
        Guid _RowIDNota;
        Guid _RowIDPos;
        Guid _RowIDDO;

        string fHargaKhusus = "";
        int JmlBrgPromo = 0;
        string JmlPromo = "";

        //variabel nota
        double _rpSisaACCPiutang, _jmlHrgNota, _rpACCPiutang;
        string _transType;
        string _Cat1 = string.Empty, _Cat2 = string.Empty, _Cat3 = string.Empty,
                _Cat4 = string.Empty, _Cat5 = string.Empty, _CatD = string.Empty;
        int _hariKredit;


       //variabel gethitunghrgjual
        string _barangID;
        DateTime _tglDO, _tglAkhir;
               string _c1;
        double HrgJualBMK_;
        int QTYPOS;
        double _hrgB = 0,_hrgM = 0,_hrgK = 0,_hrgJual = 0,_hrgAkhir = 0,_hrgAmbil = 0,_hargaFinal = 0,
                _hrgHPP = 0, _hrgNet = 0, _hrgKus, _Hnet = 0;

        DataTable dtPromo, dtpromotetap, dtbarang, dtHrgPoint;
        int _nCetak = -1, _nOli = 1;
        string _ketNota = "";

        //variable bengkel
        string pemanggil;
        Guid rowidbengkel;
        string flagperbaikan;
        string flagHR4;
        string noVch = "";
        
        string wilayah;
        double discwil = 0;
        double _Het = 0;
        double nDiscK4;
        double _hrgkhs = 0;
        double _hrgtunai = 0;

        double plafonToko = 0, piutangToko = 0, gitToko = 0, giroToko, giroTolakToko, sisaPlafonToko, overdue, overdueFB, overdueFX;
        string noAcc = string.Empty;
        bool tokoPnt = false;
        bool _KdSalesKhusus = false;

        string _notaHeaderRecID;
        string _notaDetailRecID;
        string nomorNota = "";
        string _TransactionType = "";

        DataTable dtNota;
        
        public FrmPOS()
        {
            InitializeComponent();
        }

        public FrmPOS(Form caller, DataTable dt_, string gudang_)
        {
            this.Caller = caller;
            InitializeComponent();
        }

        public FrmPOS(string _pemanggil, Guid _rowidservice, Guid RowIDNota, string cabang,
            string perusahaan, DateTime lastclosingdate,string gudang, string perbaikan, string userinitial)
        {
            pemanggil = _pemanggil;
            if (pemanggil == "BENGKEL")
            {
                rowidbengkel = _rowidservice;
                _RowIDNota = RowIDNota;
            }

            //_notaHeaderRowID = rowidbengkel;
            //initCab = "28";
            //cab1 = "28";
            //cab2 = "28";
            //    cab3 = "";
            //    GlobalVar.PerusahaanID = "10P";
            //    GlobalVar.LastClosingDate = DateTime.Today.AddDays(-1);
            //    GlobalVar.Gudang = "2811";
            //    initgudang = "2811";

            initCab = cabang;
            cab1 = cabang;
            cab2 = cabang;
            cab3 = "";
            GlobalVar.PerusahaanID = perusahaan;
            GlobalVar.LastClosingDate = lastclosingdate;
            GlobalVar.Gudang = gudang;
            initgudang = gudang;
            //SecurityManager.userinitial = userinitial;
            flagperbaikan = perbaikan;
                        
            InitializeComponent();

        }

        #region Kumpulan Function

        private double HrgNetto(Double _Pot)
        {
            double hrgNetto = 0;
            try
            {
                double HrgJual__ = 0;
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;
                string _discFormula="";

                
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
            if (_barangID != "[CODE]" && _barangID != "")
            {
                if (_noACC != "BONUSAN" && (HrgNetto(0) < HrgJualBMK_))
                {

                    if (_barangID.Substring(0, 3) == "FAL" || _barangID.Substring(0, 3) == "FAB" || _barangID.Substring(0, 3) == "FAT")
                    {
                        Valid = false;
                    }
                    else
                    {
                        Valid = true;
                    }
                }
            }
            return Valid;
        }

        private void ACC_Pembulat()
        {
            string NoACC_ = "";
            double HrgNetto_ = 0;
            double _Pot = 0;
            //if (txtPotongan.Text != "")
            //    _Pot = double.Parse("0");

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
            }
            else
            {
                NoACC_ = "";
            }

            if (NoACC_ != "")
            {

                //txtNoACC.Text = NoACC_;
                _noACC = NoACC_;
            }
            else if (_noACC != "" && _noACC == "PMBULAT")
            {

                //txtNoACC.Text = "";
                _noACC = "";
            }

        }

        private void BulatBulat()
        {
            if (_noACC != "BONUSAN")
            {

                if (HrgNetto(0) < HrgJualBMK_)
                {

                    if (_barangID.Substring(0, 3) == "FAL" || _barangID.Substring(0, 3) == "FAB" || _barangID.Substring(0, 3) == "FAT")
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
                    if (_noACC != "" && _noACC.Trim() == "PMBULAT")
                    {

                        //txtNoACC.Text = "";
                        _noACC = "";
                    }
                }
            }
        }

        private void HrgJualValidating()
        {
            if (_hrgJual< 0)
            {
                MessageBox.Show("Harga jual < 0");
                     return;
            }

            if (_barangID != "[CODE]" && _barangID != "")
            {

                if (ValidBulat())
                {

                    if (MessageBox.Show("Harga jual Netto tidak sama dengan Harga C-T-E !!!", "Lanjut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        BulatBulat();
                    }

                }
                else if (_noACC== "PMBULAT")
                {
                    _noACC = "";
                    //txtNoACC.Text = "";
                }

            }

        }

        
        private void GetHrgJual()
        {
            if (_barangID != "" && QTYPOS != 0)
            {
                try
                {
                    DataTable dtGetHrgJual = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));                        
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, Tools.Left(comboBox1.Text,2)));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtGetHrgJual.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                        HrgJualBMK_ = _hrgJual;
                    }
                    else
                    {
                        _hrgJual = 0;
                        HrgJualBMK_ = 0;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        private void GetHrgJualPOS()
        {
            if (_barangID != "" && QTYPOS != 0)
            {
                try
                {
                    DataTable dtGetHrgJual = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHrgJualPOS"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, Tools.Left(comboBox1.Text, 2)));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtGetHrgJual.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                        HrgJualBMK_ = _hrgJual;
                    }
                    else
                    {
                        _hrgJual = 0;
                        HrgJualBMK_ = 0;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        private void GetHargaPromoPoint()
        {
            if (_barangID != "" && QTYPOS != 0)
            {
                try
                {
                    dtHrgPoint = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHrgPromoPoint"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, Tools.Left(comboBox1.Text, 2)));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtHrgPoint = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtHrgPoint.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtHrgPoint.Rows[0]["h_Jual"]);
                        HrgJualBMK_ = _hrgJual;
                    }
                    else
                    {
                        _hrgJual = 0;
                        HrgJualBMK_ = 0;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        
        public void CekHargaBMK(string _barangid)
        {
            try
            {
                DataTable dtGetHrgBMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetHargaJual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, initCab));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgBMK.Rows.Count > 0)
                {
                    _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                    _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                    _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                else
                {
                    _hrgB = 0;
                    _hrgM = 0;
                    _hrgK = 0;
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                if (_hrgAkhir > 0)
                {
                    if (dtGetHrgBMK.Rows.Count > 0)
                    {
                        _tglAkhir = (DateTime)dtGetHrgBMK.Rows[0]["TglTerakhir"];
                    }
                    else
                    {
                        _tglAkhir = new DateTime(1900, 1, 1);
                    }
                }
                lblBMK.Text = "C: " + _hrgB.ToString("N0") + "  T: " + _hrgM.ToString("N0") + "  E: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");

                double _hrgInfo1 = 0, _hrgInfo2 = 0;

                //if (_barangid.Trim().Substring(0, 3) == "FB4" || _barangid.Trim().Substring(0, 3) == "FE4")
                //{
                //    GetFlagHR4("HKR4");
                //    GetHargaPriceList(DateTime.Parse(TxtTGL.DateValue.ToString()), _barangid);
                //    if (nDiscK4 > 0 && _Hnet > 0)
                //    {
                //        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                //        _hrgInfo1 = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                //    }
                //    else
                //    {
                //        GetWilayah();
                //        GetDiscWilayah();
                //        if (discwil > 0 && _Hnet > 0)
                //        {
                //            decimal x = Convert.ToDecimal(discwil)+5, y = 100;
                //            _hrgInfo2 = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                //        }
                //    }
                //}

                try
                {
                    DataTable dtGetHrgKhusus = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                        dtGetHrgKhusus = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgKhusus.Rows.Count > 0)
                    {
                        if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        {
                            _hrgKus = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        }
                        else
                        {
                            _hrgKus = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                lblHrgwilayah.Text = "Harga Khusus R4 : " + _hrgInfo1.ToString("N0") +
                                     "         ||  Harga Wilayah : " + _hrgInfo2.ToString("N0") +
                                     "         ||  Harga Khusus : " + _hrgKus.ToString("N0");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void ViewHargaKhusus(string _barangid)
        {
            try
            {
                _barangID = _barangid;
                double _hrgInfo1 = 0, _hrgInfo2 = 0;
                if (_barangid.Trim().Substring(0, 3) == "FB4" || _barangid.Trim().Substring(0, 3) == "FE4")
                {
                    GetFlagHR4("HKR4");
                    GetHrgJualHKR4();
                    if (nDiscK4 > 0 && _hrgJual > 0)
                    {
                        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                        _hrgInfo1 = _hrgNet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_hrgNet)), 0));
                    }
                    else
                    {
                        //tambahan kondisi untuk harga jual kredit, HET - 20% untuk wilayah Jawa Tengah
                        GetWilayah();
                        GetDiscWilayah();
                        GetHET();
                        if (discwil > 0 && _Het > 0)
                        {
                            decimal x = Convert.ToDecimal(discwil), y = 100;
                            _hrgInfo2 = _hrgNet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_hrgNet)), 0));
                        }
                    }
                }
                try
                {
                    DataTable dtGetHrgKhusus = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                        dtGetHrgKhusus = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgKhusus.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(Tools.isNull(dtGetHrgKhusus.Rows[0]["h_top10"], "0").ToString()) > 0)
                        {
                            _hrgKus = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                lblHrgwilayah.Text = "Harga Khusus R4 : " + _hrgInfo1.ToString("N0") +
                                     "         ||  Harga Wilayah : " + _hrgInfo2.ToString("N0") +
                                     "         ||  Harga Khusus Standar : " + _hrgKus.ToString("N0");
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
                    db.Commands.Add(db.CreateCommand("[usp_GetHargaJual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, _c1));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgBMK.Rows.Count > 0)
                {
                    _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                    _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                    _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                else
                {
                    _hrgB = 0;
                    _hrgM = 0;
                    _hrgK = 0;
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }

                
                if (_hrgAkhir > 0)
                {
                    if (dtGetHrgBMK.Rows.Count > 0)
                    {
                        _tglAkhir = (DateTime)dtGetHrgBMK.Rows[0]["TglTerakhir"];
                    }
                    else
                    {
                        _tglAkhir = new DateTime(1900, 1, 1);
                    }

                }

                //if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0)
                //{
                lblBMK.Text = "C: " + _hrgB.ToString("N0") + "  T: " + _hrgM.ToString("N0") + "  E: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
                //}
                //else
                //{
                //    lblBMK.Text = "Belum ada harga CTE";
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void GetHargaHpp(string barangID)
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
                    _hrgHPP = 0;
                    MessageBox.Show("Barang tidak mempunyai riwayat HPP, hubungi HO");

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void CekHargaKhusus(string _barangid)
        {
            try
            {
                DataTable dtGetHrgKhusus = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                    dtGetHrgKhusus = db.Commands[0].ExecuteDataTable();
                }

                if (dtGetHrgKhusus.Rows.Count > 0)
                {
                    string flagHK = Convert.ToString(dtGetHrgKhusus.Rows[0]["FlagHK"]);
                    if (flagHK == "")
                    {
                        double hrgb_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        if (hrgb_ > 0)
                            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);

                        double hrgm_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                        if (hrgm_ > 0)
                            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);

                        double hrgk_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        if (hrgk_ > 0)
                            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                    }
                    else
                    {
                        string _KodeToko = lookupToko1.KodeToko;
                        DataTable dtHK = new DataTable();
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_GetDataTokokhusus"));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                                dtHK = db.Commands[0].ExecuteDataTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }

                        if (dtHK.Rows.Count > 0)
                        {
                            double hrgb_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            if (hrgb_ > 0)
                                _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);

                            double hrgm_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                            if (hrgm_ > 0)
                                _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);

                            double hrgk_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                            if (hrgk_ > 0)
                            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        }


                        #region ijo2
                        //----
                        //string _KodeToko = lookupToko1.KodeToko;
                        //DataTable dtHK = new DataTable();
                        //try
                        //{
                        //    using (Database db = new Database())
                        //    {
                        //        db.Commands.Add(db.CreateCommand("usp_GetDatakhusus"));
                        //        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                        //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                        //        dtHK = db.Commands[0].ExecuteDataTable();
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Error.LogError(ex);
                        //}

                        //if (dtHK.Rows.Count > 0)
                        //{
                        //    if (TxtNamaToko.Text == "ECERAN CASH" && dtHK.Rows[0]["KodeSales"].ToString().Substring(0, 10) == lookupSales1.SalesID.ToString().Substring(0, 10))
                        //    {
                        //        _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        //        _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                        //        _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        //    }
                        //}

                        //dtHK = new DataTable();
                        //try
                        //{
                        //    using (Database db = new Database())
                        //    {
                        //        db.Commands.Add(db.CreateCommand("usp_GetDatakhusus"));
                        //        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                        //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                        //        dtHK = db.Commands[0].ExecuteDataTable();
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Error.LogError(ex);
                        //}

                        //if (dtHK.Rows.Count > 0)
                        //{
                        //    if (TxtNamaToko.Text == "ECERAN CASH" && dtHK.Rows[0]["KodeSales"].ToString().Substring(0, 10) == lookupSales1.SalesID.ToString().Substring(0, 10))
                        //    {
                        //        _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        //        _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                        //        _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        //    }
                        //}
                        #endregion 
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetHrgKhusus()
        {
            try
            {
                DataTable dtGetHrgKhusus = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtGetHrgKhusus = db.Commands[0].ExecuteDataTable();
                }

                if (dtGetHrgKhusus.Rows.Count > 0)
                {
                    if (txtstatus.Text.ToString().Substring(0, 1) == "B")
                    {
                        if (Convert.ToDouble(Tools.isNull(dtGetHrgKhusus.Rows[0]["h_cash"], "0").ToString()) > 0)
                        {
                            _hargaFinal = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                        }
                    }
                    else if (txtstatus.Text.ToString().Substring(0, 1) == "M")
                    {
                        if (Convert.ToDouble(Tools.isNull(dtGetHrgKhusus.Rows[0]["h_top10"], "0").ToString()) > 0)
                        {
                            _hargaFinal = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            //_hargaFinal = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                            //_hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                        }
                    }
                    else if (txtstatus.Text.ToString().Substring(0, 1) == "K")
                    {
                        if (Convert.ToDouble(Tools.isNull(dtGetHrgKhusus.Rows[0]["h_user"], "0").ToString()) > 0)
                        {
                            _hargaFinal = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            //_hargaFinal = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                            //_hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            #region old
            //try
            //{
            //    DataTable dtGetHrgKhusus = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
            //        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
            //        dtGetHrgKhusus = db.Commands[0].ExecuteDataTable();
            //    }
                //if (dtGetHrgKhusus.Rows.Count > 0)
                //{
                //    string flagHK = Convert.ToString(dtGetHrgKhusus.Rows[0]["FlagHK"]);
                //    if (flagHK == "")
                //    {
                //        double hrgb_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                //        if (hrgb_ > 0)
                //            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);

                //        double hrgm_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                //        if (hrgm_ > 0)
                //            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);

                //        double hrgk_ = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                //        if (hrgk_ > 0)
                //            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                //    }
                //    else
                //    {
                //        string _KodeToko = lookupToko1.KodeToko;
                //        DataTable dtHK = new DataTable();
                //        try
                //        {
                //            using (Database db = new Database())
                //            {
                //                db.Commands.Add(db.CreateCommand("usp_GetDataTokokhusus"));
                //                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                //                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                //                dtHK = db.Commands[0].ExecuteDataTable();
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            Error.LogError(ex);
                //        }

                //        if (dtHK.Rows.Count > 0)
                //        {
                //            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                //            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                //            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                //        }

                //        if (_hrgB > 0)
                //        {
                //            fHargaKhusus = "1";
                //        }

                //        #region ijo2
                //        //string _KodeToko = lookupToko1.KodeToko;
                //        //DataTable dtHK = new DataTable();
                //        //try
                //        //{
                //        //    using (Database db = new Database())
                //        //    {
                //        //        db.Commands.Add(db.CreateCommand("usp_GetDatakhusus"));
                //        //        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                //        //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                //        //        dtHK = db.Commands[0].ExecuteDataTable();
                //        //    }
                //        //}
                //        //catch (Exception ex)
                //        //{
                //        //    Error.LogError(ex);
                //        //}

                //        //if (dtHK.Rows.Count > 0)
                //        //{
                //        //    if (TxtNamaToko.Text == "ECERAN CASH" && dtHK.Rows[0]["KodeSales"].ToString().Substring(0, 10) == lookupSales1.SalesID.ToString().Substring(0, 10))
                //        //    {
                //        //        _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                //        //        _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                //        //        _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                //        //    }
                //        //}
                //        #endregion 
                //    }
                //}
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            #endregion
        }


        private void GetHrgKhususPos(string brgid)
        {
            try
            {
                noVch = Tools.isNull(TxtCat3.Text,"").ToString().Trim().ToUpper();
                DataTable dtVch = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetVoucher"));
                    db.Commands[0].Parameters.Add(new Parameter("@voucher", SqlDbType.VarChar, noVch));
                    dtVch = db.Commands[0].ExecuteDataTable();
                }
                if ((dtVch.Rows.Count > 0 && noVch == Tools.isNull(dtVch.Rows[0]["NoVoucher"], "").ToString()) || noVch == "VOUCHER" )
                {
                    DataTable dtGetHrgKhususPos = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetHargaKhususPos"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, brgid));
                        dtGetHrgKhususPos = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgKhususPos.Rows.Count > 0)
                    {
                        _hrgkhs = Convert.ToDouble(dtGetHrgKhususPos.Rows[0]["h_cash"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        
        
        private void GetHrgBMKMessage()
        {
            if (_noACC != "BONUSAN")
            {

                GetHrgBMK();

                string msgBMK = "", msgAkhir = "";

                msgBMK = "Harga CTE yaitu \nC: " + _hrgB.ToString("#,##0") + "  T: " + _hrgM.ToString("#,##0") + "  E: " + _hrgK.ToString("#,##0");

                string sTglAkhir = "-";

                if (_hrgAkhir > 0)
                {
                    sTglAkhir = _tglAkhir.ToString("dd-MMM-yyyy");
                }

                msgAkhir = "Penjualan terakhir Rp. " + _hrgAkhir.ToString("#,##0")
                        + " Tgl. " + sTglAkhir;

                MessageBox.Show(msgBMK + System.Environment.NewLine + msgAkhir, "Info Harga Jual");
            }
        }

        public EnumPasif LPasif
        {
            get { return _LPasifType; }
            set { _LPasifType = value; }
        }

        public void AmbilBarang2()
        {
            cab1 = initCab;
            cab2 = initCab;
            cab3 = "";
            
            
            if (TxtBarcode.Text == "")
            {
                return;
            }
            if (TxtNamaToko.Text == "")
            {
                MessageBox.Show("Data Customer masih kosong..\nMohon diisi dahulu karena akan mempengaruhi harga CTE");
                return;
            }
            int nRowIndex = dataGridView1.Rows.Count;
           
            //this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, TxtBarcode.Text));
                
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count == 0)
            {
                TampilFormBarang();
               
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    bool lCek = false;
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        //dataGridView1.AllowUserToAddRows = false;
                    }

                    //dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                    dataGridView1.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    dataGridView1.Rows[nRowIndex].Cells[2].Value = 1;
                    dataGridView1.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];
                    dataGridView1.Rows[nRowIndex].Cells[11].Value= dr["Merek"];

                    _barangID = Convert.ToString(dr["BarangID"]);
                    QTYPOS = 1;
                    _c1 = cab1;
                    double _hargaJual = 0;

                    if (_noACC != "BONUSAN")
                    {
                        GetHrgJual();
                        if (_hrgJual > 0)
                        {
                            _hargaFinal = _hrgJual;
                        }
                        GetHrgBMKMessage();
                        //GetHrgKhusus();
                        GetHargaHpp(idbarang);

                        #region old
                        //if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        //    _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgK, "0").ToString());
                        //else
                        //    _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgB, "0").ToString());

                        //if (GlobalVar.Gudang == "2802" || GlobalVar.Gudang == "2804" || GlobalVar.Gudang == "2805" ||
                        //    GlobalVar.Gudang == "2809" || GlobalVar.Gudang == "2811" || GlobalVar.Gudang == "2819" ||
                        //    GlobalVar.Gudang == "2823")
                        //{
                        //    if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                        //    {
                        //        _hrgkhs = 0;
                        //        GetHrgKhususPos(idbarang);
                        //        if (_hrgkhs > 0)
                        //        {
                        //            _hargaFinal = _hrgkhs;
                        //        }
                        //    }
                        //}

                        /*GetHargaKhusus Tunai*/
                        //if (_barangID.ToString().Substring(0, 2) == "FB" || _barangID.ToString().Substring(0, 2) == "FE")
                        //{
                        //    GetHrgKhususTunai();
                        //    if (_hrgtunai > 0)
                        //        _hargaFinal = _hrgtunai;
                        //}
                        #endregion

                        dataGridView1.Rows[nRowIndex].Cells[12].Value = "AUTOACC";

                        #region kondisi lama
                        //GetHargaPriceList(DateTime.Parse(TxtTGL.DateValue.ToString()), _barangID);
                        //if (_barangID.ToString().Substring(0, 3) == "FB4" || _barangID.ToString().Substring(0, 3) == "FE4")
                        //{
                        //    //harga khusus Roda4 untuk toko2 tertentu
                        //    GetFlagHR4("HKR4");
                        //    if (nDiscK4 > 0 && _hrgJual > 0)
                        //    {
                        //        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                        //        _hrgB = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                        //        _hrgK = _hrgB;
                        //        _hargaFinal = _hrgB;
                        //    }
                        //    else
                        //    {
                        //        //tambahan kondisi untuk harga jual kredit, HET - 20% untuk wilayah Jawa Tengah
                        //        GetWilayah();
                        //        GetDiscWilayah();
                        //        //GetHET();
                        //        if (discwil > 0 && _Hnet > 0)
                        //        {
                        //            if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        //            {
                        //                _hargaFinal = _hrgK;
                        //            }
                        //            else
                        //            {
                        //                decimal x = Convert.ToDecimal(discwil) + 5, y = 100;
                        //                _hrgB = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                        //                _hargaFinal = _hrgB;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            GetHrgJual();
                        //            if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        //            {
                        //                _hargaFinal = _hrgK;
                        //            }
                        //            else
                        //            {
                        //                _hargaFinal = _hrgB;
                        //            }
                        //        }
                        //    }
                        //}
                        //else if (_barangID.ToString().Substring(0, 3) == "FB2" || _barangID.ToString().Substring(0, 3) == "FE2")
                        //    _hargaFinal = _hrgJual;
                        //else
                        //{
                        //    if (pemanggil != "BENGKEL")
                        //    {
                        //        CekHargaBMK(_barangID);
                        //        if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        //            _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgK, "0").ToString());
                        //        else
                        //            _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgB, "0").ToString());
                        //        //-----------------Harga khusus promo point-------------------
                        //        GetHargaPromoPoint();
                        //        if (dtHrgPoint.Rows.Count > 0)
                        //            _hargaFinal = _hrgJual;
                        //        else
                        //        {
                        //            GetHrgKhusus();
                        //            if (lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH")
                        //            {
                        //                if (Convert.ToDouble(Tools.isNull(_hrgK, "0").ToString()) > 0)
                        //                    _hargaFinal = _hrgK;
                        //                else if (Convert.ToDouble(Tools.isNull(_hrgB, "0").ToString()) > 0)
                        //                    _hargaFinal = _hrgB;
                        //                else
                        //                    _hargaFinal = 0;
                        //            }
                        //            else
                        //            {
                        //                if (Convert.ToDouble(Tools.isNull(_hrgB, "0").ToString()) > 0)
                        //                    _hargaFinal = _hrgB;
                        //                else
                        //                    _hargaFinal = 0;
                        //            }
                        //        }
                        //    }
                        //}
                        //if (_hargaFinal == 0)
                        //{
                        //    double _hrgHppNew = 0;
                        //    decimal persen = 0.01m;
                        //    _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
                        //    _hargaFinal = _hrgHppNew;
                        //}
                        #endregion
                    }

                    dataGridView1.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                    dataGridView1.Rows[nRowIndex].Cells[4].Value = _hargaFinal;

                    #region transaksi tunai dng
                    ////tutup karena sudah ada 2803                    
                    //string Jenisdong, jenis2;
                    //Jenisdong = comboBox1.Text;
                    //jenis2 = Tools.Left(Jenisdong, 1);
                    //if (TxtNamaToko.Text != "ECERAN CASH")
                    //{
                    //    dataGridView1.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                    //    dataGridView1.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                    //}
                    //else
                    //{
                    //    //kebijakan jual barang FX ke toko2 khusus di 2802 dengan sales VIA (sebelum ada 2803)
                    //    //------------------------------------------------------------------------------------
                    //    string _KodeToko = lookupToko1.KodeToko;
                    //    DataTable dtHK = new DataTable();
                    //    try
                    //    {
                    //        using (Database db = new Database())
                    //        {
                    //            db.Commands.Add(db.CreateCommand("usp_GetDatakhusus"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    //            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    //            dtHK = db.Commands[0].ExecuteDataTable();
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Error.LogError(ex);
                    //    }
                    //    if (dtHK.Rows.Count > 0)
                    //    {
                    //        _hargaFinal = _hrgB;
                    //        dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgB;
                    //        dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgB;
                    //    }
                    //    else
                    //    {
                    //        dataGridView1.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                    //        dataGridView1.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                    //    }
                    //    //------------------------------------------------------------------------------------
                    //}
                    #endregion

                    #region harga tidak boleh kurang dari atau sama dengan 0
                    //for (a = 0; a < dataGridView1.Rows.Count; a++)
                    //{
                    //    int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                    //    if (qty > 0)
                    //    {
                    //        //if (_hargaFinal <= 0 && _hrgHPP <= 0)
                    //        //{
                    //        //    dataGridView1.AllowUserToAddRows = false;
                    //        //    b = a + dataGridView1.Rows.Count-1;
                    //        //    MessageBox.Show("Harga Jual dan HPP masih 0, Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                    //        //    dataGridView1.Rows.Remove(dataGridView1.Rows[b]);
                    //        //    dataGridView1.AllowUserToAddRows = false;
                    //        //    return;
                    //        //}
                    //    }
                    //}
                    #endregion

                    dataGridView1.Rows[nRowIndex].Cells[5].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[6].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[7].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[8].Value = 0;

                    //dataGridView1.MultiSelect = false;
                    //dataGridView1.BeginEdit(true);
                    //dataGridView1.AllowUserToAddRows = false;

                    #region  hitung total2
                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                        kuantiti2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                    TxtBarcode.Text = "";
                    dataGridView1.Rows[nRowIndex].Cells[2].Selected = true;                   

                    #endregion
                }
                this.Cursor = Cursors.Default;
                //dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Focus();
            }
        }

        private void GetHrgKhususTunai()
        {
            try
            {
                DataTable dtHrgKhususTunai = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetHargaKhusus"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHrgKhususTunai = db.Commands[0].ExecuteDataTable();
                }

                if (dtHrgKhususTunai.Rows.Count > 0)
                {
                    if (Convert.ToDouble(Tools.isNull(dtHrgKhususTunai.Rows[0]["h_cash"], "0").ToString()) > 0)
                        _hrgtunai = Convert.ToDouble(dtHrgKhususTunai.Rows[0]["h_cash"]);

                    //if (Convert.ToDouble(Tools.isNull(dtHrgKhususTunai.Rows[0]["h_top10"], "0").ToString()) > 0)
                    //{
                    //    _hrgM = Convert.ToDouble(dtHrgKhususTunai.Rows[0]["h_top10"]);
                    //    _hargaFinal = _hrgM;
                    //}
                    //if (Convert.ToDouble(Tools.isNull(dtHrgKhususTunai.Rows[0]["h_user"], "0").ToString()) > 0)
                    //    _hrgK = Convert.ToDouble(dtHrgKhususTunai.Rows[0]["h_user"]);
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
                        nDiscK4 = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Value"], "").ToString());
                    else
                        nDiscK4 = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
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
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        dtGetHrgJualR4 = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgJualR4.Rows.Count > 0)
                       _hrgJual = Convert.ToDouble(Tools.isNull(dtGetHrgJualR4.Rows[0]["Hnet"],"0").ToString());
                    else
                       _hrgJual = 0;

                    HrgJualBMK_ = _hrgJual;
                    //_hargaFinal = _hrgJual;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        private bool validation()
        {

            string[, ,] cek = {{ 
                                {TxtAlamatToko.Text.ToString(),"isNull","Alamat Toko belum diisi.."}
                                ,{TxtNamaToko.Text.ToString(),"isNull","Nama Toko belum diisi.."}
                                ,{TxtKota.Text.ToString(), "isNull","Kota belum diisi.."}
                                ,{TxtTGL.Text.ToString(),"isNull", "Tanggal belum diisi.."}
                                ,{lookupSales1.NamaSales.ToString(),"isNull", "Pramuniaga belum diisi.."}
                                
                             }};

            return Class.validation.error(cek);
        }

        private void Recalculate(string idbarang_, string gudang_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                 

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, gudang_));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, idbarang_));

                        if (pemanggil == "BENGKEL")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }
                        db.Commands[0].ExecuteNonQuery();

                
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

        private int GetHariKirim()
        {
            int hari = 0;
            try
            {
                if (CBOEkspedisi.SelectedValue.ToString() == "SAS")
                // ||
                //txtTransactionType.Text.Trim() == "")
                {
                    hari = 0;
                }
                //else
                //{
                //    hari = 0;
                //    if (txtTransactionType.Text.Trim().Substring(0, 1) == "K")
                //    {
                //        hari = txtToko.HariKirim;
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                hari = 0;
            }


            return hari;
        }
        //------
        private bool IsTokoPT()
        {
            bool result = false;
            DataTable dtToko;
            using (Database db = new Database())
            {
   
                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));

                dtToko = db.Commands[0].ExecuteDataTable();
               
            }
            if (dtToko.Rows.Count >= 0)
            {
                //if (dtToko.Rows[0]["Cabang2"].ToString().Trim() == "PT")
                if (cab2.ToString().Trim() == "PT")
                {
                    result = true;
                }
            }

            //if (dtDO.Rows[0]["Cabang1"].ToString() != dtDO.Rows[0]["Cabang2"].ToString() && Tools.Left(dtDO.Rows[0]["Cabang1"].ToString(), 1) == "9")
            if (cab1 != cab2 && Tools.Left(cab1.ToString(), 1) == "9")
            {
                result = false;
            }
            return result;
        }
        //----
        private string GetInitialPT()
        {
            string code1;
            string code2;
            string code3;

            DataTable dtGudang;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                dtGudang = db.Commands[0].ExecuteDataTable();
            }
            code1 = dtGudang.Rows[0]["Fax"].ToString();
            code2 = Tools.ToCode("NOTA_PT_M");
            code3 = Tools.ToCode("NOTA_PT_Y");

            return code1 + code2 + code3;
        }
        //----

        private string GetDefaultToko()
        {
            string defKodeToko = string.Empty;

            DataTable dtAppSet;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "ECERAN_CASH"));
                dtAppSet = db.Commands[0].ExecuteDataTable();
            }

            if (dtAppSet.Rows.Count > 0)
            {
                defKodeToko = dtAppSet.Rows[0]["Value"].ToString();
            }

            return defKodeToko;
        }

        #endregion

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            menit = 0; varmenit = 0;
            miliDetik = 0; varmilidetik = 0;

            total = 0;
            label12.Text = Convert.ToString(total);
            idsales = "";
            tanggal = DateTime.Now;
            string tgl = tanggal.ToString("dd/MM/yyyy");
            string NmTk = GetDefaultToko();
            TxtTGL.Text = Convert.ToString(tgl);
            lookupToko1.SetToko(GetDefaultToko());
            kuantiti2 = 0;
            lblqty.Text = Convert.ToString(kuantiti2);

            #region tampil hari dan tanggal
            CultureInfo culture;
            culture = new CultureInfo("id-ID");
            string tgl_label = System.DateTime.Today.ToString("dddd, dd MMMM yyyy", culture);
            label25.Text = Convert.ToString(tgl_label);
            #endregion

            if (flagperbaikan == "Y")
            {
                comboBox1.Text = "K2";
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Text = "TG";
                comboBox1.Enabled = true;   // false;
            }

            if (GlobalVar.Gudang != "2808")
            {
                txtstatus.Enabled = false;
                txtstatus.ReadOnly = true;
            }

            #region Expedisi
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtExp = new DataTable();

                using (Database db = new Database())
                {
                    //display Expedisi List
                    db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST"));
                    dtExp = db.Commands[0].ExecuteDataTable();
                    CBOEkspedisi.DataSource = dtExp;
                    CBOEkspedisi.DisplayMember = "Expedisi";
                    CBOEkspedisi.ValueMember = "KodeExpedisi";
                    CBOEkspedisi.SelectedValue = "SAS";



                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                        dt = db.Commands[2].ExecuteDataTable();
                        nprint = int.Parse(dt.Rows[0]["NPrint"].ToString());
                        noAccPiutang = dt.Rows[0]["NoACCPiutang"].ToString();
                        noAccPusat = dt.Rows[0]["NoACCPusat"].ToString();
                        _TglACCPiutang = dt.Rows[0]["TglACCPiutang"];
                        _TglReorder = dt.Rows[0]["TglACCPiutang"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            #endregion

            dataGridView1.Columns["gVplu"].DisplayIndex = 0;
            dataGridView1.Columns["GvNamaBrg"].DisplayIndex = 1;
            dataGridView1.Columns["GvQTy"].DisplayIndex = 2;
            dataGridView1.Columns["GvSat"].DisplayIndex = 3;
            dataGridView1.Columns["GvHarga"].DisplayIndex = 4;
            dataGridView1.Columns["GvD1"].DisplayIndex = 5;
            dataGridView1.Columns["GvD2"].DisplayIndex = 6;
            dataGridView1.Columns["GvD3"].DisplayIndex = 7;
            dataGridView1.Columns["GvPot"].DisplayIndex = 8;
            dataGridView1.Columns["GvJumlah"].DisplayIndex = 9;
            dataGridView1.Columns["Merek"].DisplayIndex = 11;
            dataGridView1.Columns["NoAcc"].DisplayIndex = 12;
            _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            try
            {
                kodetoko = lookupToko1.KodeToko;
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko;

                #region CekDataTokoBermasalah
                try
                {
                    DataTable dtctf = new DataTable();
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TokoFiktif_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
                        dtctf = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtctf.Rows.Count > 0)
                    {
                        MessageBox.Show("Toko Bermasalah, tidak bisa bertransaksi.");
                        lookupToko1.Focus();
                        return;
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
                #endregion 


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetStatusToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, initCab));
                    stsToko = db.Commands[0].ExecuteScalar();

                    db.Commands.Add(db.CreateCommand("usp_StsToko_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    dtStsToko = db.Commands[1].ExecuteDataTable();
                }

                stsTk = stsToko.ToString();
               
                #region statustoko
                //if (stsTk == "" || stsTk == null)
                //{
                //    MessageBox.Show("Toko belum ada statusnya");
                //    statustoko = "";
                //    alamatkirim = "";
                //    TxtNamaToko.Text = "";
                //    TxtAlamatToko.Text = "";
                //    TxtKota.Text = "";
                //    TxtIDWil.Text = "";

                //  //statustoko = Convert.ToString(stsToko);
                //    alamatkirim = "";
                //    kotatoko = "";
                //    txtstatus.Text = "";
                 
                //    return;
                //}
                #endregion

                #region Toko bentrok
                //int jml = dtStsToko.Rows.Count;
                //for (int i = 0; i < jml; i++)
                //{
                //    string cabang1 = dtStsToko.Rows[i]["CabangID"].ToString();
                //    if (cabang1 != initCab)
                //    {
                //        MessageBox.Show("Toko ini bentrok dengan " + cabang1);
                //    }
                //}
                #endregion 

                TxtNamaToko.Text = lookupToko1.NamaToko;
                TxtAlamatToko.Text = lookupToko1.Alamat;
                TxtKota.Text = lookupToko1.Kota;
                TxtIDWil.Text = lookupToko1.WilID;
                LblKodeToko.Text = lookupToko1.TokoID;

                statustoko = Convert.ToString(stsToko);
                alamatkirim = lookupToko1.Alamat;
                kotatoko = lookupToko1.Kota;
                if (stsToko == null)
                {
                    stsToko = "";
                }
                _stsToko = Tools.isNull(stsToko, "").ToString();
                txtstatus.Text = _stsToko.ToString();

                comboBox1.Enabled = true;
                comboBox1.Focus();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void CmdADD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("kk");
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lookupSales1_SelectData(object sender, EventArgs e)
        {
            idsales = lookupSales1.SalesID;
        }

        private void lookupToko1_Load_1(object sender, EventArgs e)
        {

            DateTime waktu = DateTime.Now;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime waktu = DateTime.Now;
            string wkt = DateTime.Now.ToString("HH:mm:ss");
            label24.Text = wkt;
                        
            TxtWaktu.Text = waktu.TimeOfDay.ToString();
        }

        private object val(object p)
        {
            throw new NotImplementedException();
        }


        public void getPromo()
        {
            try
            {
                int sumqtyBarang = 0;
                double sumhargajualbarang = 0;
                int qtybarang = 0;
                double hargajualbarang = 0;

                int sumqtyKelompok = 0;
                double sumhargajualKelompok = 0;
                int qtyKelompok = 0;
                double hargajualKelompok = 0;

                int sumqtyTahunan = 0;
                double sumhargajualTahunan = 0;
                int qtyTahunan = 0;
                double hargajualTahunan = 0;

                int sumKelipatanQtyBarang = 0;
                int sumKelipatanQtyKelompok = 0;
                int sumKelipatanQtyTahunan = 0;
                int i = 0;

                int PromoPoint = 0;
                double nSmin = 0;

                #region cari promo tetap. promo tetap itu  yang dapet cuma dari toko inti
                //transaksi penjualan pertama setiap bulan, kode toko buat input, trus cek nota diya pernah transaksi di bulan yang sama, where ambil bulan tglsj = getdate(brti salah);
                kodetoko = lookupToko1.KodeToko;

                if (Prolib.HistoryPenjualan(kodetoko) == false)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_getPromoTetap"));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        dtpromotetap = db.Commands[0].ExecuteDataTable();
                    }
                }
                else
                {
                    dtpromotetap = new DataTable();
                }
                #endregion

                #region mencari barang apa aja yang lagi promo

                DataTable dtPromoBrg = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetPromoBarang_LIST"));
                    dtPromoBrg = db.Commands[0].ExecuteDataTable();
                }

                #endregion

                #region promo kelompok nya
                DataTable dtPromoKelompok, dtPromoTahunan = new DataTable();
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Prolib.cekpromokelompok(_barangID) == true)
                    {
                        qtyKelompok = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);
                        sumqtyKelompok = sumqtyKelompok + qtyKelompok;
                        hargajualKelompok = Convert.ToDouble(label12.Text.ToString());
                        sumhargajualKelompok = hargajualKelompok;
                        dtPromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);
                    }
                }
                #endregion

                #region Promo Tahunan
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Prolib.PromoTahunan(_barangID) == true)
                    {
                        qtyTahunan = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);
                        sumqtyTahunan = sumqtyTahunan + qtyTahunan;
                        hargajualTahunan = Convert.ToDouble(label12.Text.ToString());
                        sumhargajualTahunan = hargajualTahunan;
                        dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyTahunan, sumhargajualTahunan);
                        string KodeToko = lookupToko1.KodeToko;
                        string KodeBarang = dtPromoTahunan.Rows[0]["id_brg"].ToString();
                        if (Prolib.CekHistoryTokoTahunan(KodeToko, KodeBarang) == true)
                        {
                            dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyTahunan, sumhargajualTahunan);
                        }
                        else
                        {
                            dtPromoTahunan = new DataTable();
                        }
                    }
                }
                #endregion

                #region bonus promo barang dan bonus promo kelompok
                DataTable dtPromoBarangBonus = Prolib.DataPromoBarangBonus(sumqtyBarang, sumhargajualbarang);
                DataTable dtpromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);

                #region Belum ada history
                for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                {
                    //kodetoko = lookupToko1.KodeToko;
                    //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                    //if (Prolib.BelumAdaHistory(PromoRowID) == true)
                    //{
                    //    DataTable dtHistJualToko = Prolib.HistJualToko(kodetoko);
                    //    if (dtHistJualToko.Rows.Count > 0)
                    //    {
                    //        //dapet bonus
                    //    }
                    //}
                }
                #endregion

                #region enduser barang
                for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                {
                    if (lookupToko1.NamaToko == "ECERAN CASH")
                    {
                        Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                        //panggil dari prolib yang fungsi cek enduser
                        if (Prolib.Enduser(PromoRowID) == true)
                        {
                            //akumulasi
                            #region Akumulasi barang
                            for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                            {
                                DateTime hari = DateTime.Now;
                                kodetoko = lookupToko1.KodeToko;
                                int akumulasihari, qtyakumulasi;
                                double hargaJualAkumulasi;

                                DataTable dtAkumulasihari, dtAkumulasiPenjualan;

                                if (Prolib.Akumulasi(PromoRowID) == true)
                                {
                                    //ambil akumulasi berapa hari
                                    dtAkumulasihari = Prolib.AmbilHari(PromoRowID);
                                    akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                    dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
                                    if (dtAkumulasiPenjualan.Rows.Count > 0)
                                    {
                                        //ambil akumulasi berapa hari
                                        dtAkumulasihari = Prolib.AmbilHari(PromoRowID);
                                        akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                        if (akumulasihari == 0)
                                        {
                                            akumulasihari = 1;
                                        }
                                        dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
                                        qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                        hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);
                                        //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                        sumqtyKelompok = qtyakumulasi + qtybarang;
                                        sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
                                    }
                                }
                            }
                            #endregion

                            //kelipatan
                            #region kelipatan promo barang
                            for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                            {
                                //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                                int qmin = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_min"]);
                                int qmax = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_max"]);
                                double smin = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_min"]);
                                double smax = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_max"]);
                                int qtybonus = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["qty_bns"]);
                                int kelipatan = 1;
                                if (Prolib.Kelipatan(PromoRowID) == true)
                                {
                                    //cek syarat qtymax barang
                                    if (qmax > 0 && sumqtyBarang <= qmax)
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyBarang) / qmin));
                                    }
                                    if (qmax > 0 && sumqtyBarang > qmax)
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmax) / qmin));
                                    }

                                    //cek syarat smax barang
                                    if (smax > 0 && sumhargajualbarang <= smax)
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
                                    }

                                    if (smax > 0 && sumhargajualbarang >= smax)
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smax));
                                    }

                                    if (qmax == 0 && smax == 0)
                                    {
                                        if (qmin == 0)
                                        {
                                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
                                        }
                                        else
                                        {
                                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qmin));
                                        }
                                    }

                                    //menghitung kelipatan barang
                                    sumKelipatanQtyBarang = kelipatan * qtybonus;
                                    dtPromoBarangBonus.Rows[i]["qty_bns"] = sumKelipatanQtyBarang.ToString();
                                }
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        //masuk ke bawah
                        //akumulasi
                        #region Akumulasi barang
                        for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                        {
                            DateTime hari = DateTime.Now;
                            kodetoko = lookupToko1.KodeToko;
                            int akumulasihari, qtyakumulasi;
                            double hargaJualAkumulasi;

                            Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                            DataTable dtAkumulasihari, dtAkumulasiPenjualan;

                            if (Prolib.Akumulasi(PromoRowID) == true)
                            {
                                //ambil akumulasi berapa hari
                                dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

                                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[0]["hrg_promo"]);
                                if (akumulasihari == 0)
                                {
                                    akumulasihari = 1;
                                }
                                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);

                                if (dtAkumulasiPenjualan.Rows.Count > 0)
                                {
                                    qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                    hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

                                    //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                    sumqtyKelompok = qtyakumulasi + qtybarang;
                                    sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
                                }
                            }


                        #endregion
                            //kelipatan
                            #region kelipatan promo barang

                            //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                            int qmin = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_min"]);
                            int qmax = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_max"]);
                            double smin = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_min"]);
                            double smax = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_max"]);
                            int qtybonus = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["qty_bns"]);
                            int kelipatan = 1;
                            if (Prolib.Kelipatan(PromoRowID) == true)
                            {
                                //cek syarat qtymax barang
                                if (qmax > 0 && sumqtyBarang <= qmax)
                                {
                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyBarang) / qmin));
                                }
                                if (qmax > 0 && sumqtyBarang > qmax)
                                {
                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmax) / qmin));
                                }

                                //cek syarat smax barang
                                if (smax > 0 && sumhargajualbarang <= smax)
                                {
                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
                                }

                                if (smax > 0 && sumhargajualbarang >= smax)
                                {
                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smax));
                                }

                                if (qmax == 0 && smax == 0)
                                {
                                    if (qmin == 0)
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
                                    }
                                    else
                                    {
                                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qmin));
                                    }
                                }

                                //menghitung kelipatan barang
                                sumKelipatanQtyBarang = kelipatan * qtybonus;
                                dtPromoBarangBonus.Rows[i]["qty_bns"] = sumKelipatanQtyBarang.ToString();
                            }
                        }
                            #endregion
                    }
                }
                #endregion

                #region enduser kelompok
                for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                {
                    if (lookupToko1.NamaToko == "ECERAN CASH")
                    {
                        Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                        //panggil dari prolib yang fungsi cek enduser
                        if (Prolib.Enduser(PromoRowIDKelompok) == true)
                        {
                            //akumulasi
                            #region Akumulasi Kelompok
                            for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                            {
                                DateTime hari = DateTime.Now;
                                kodetoko = lookupToko1.KodeToko;
                                int akumulasihari, qtyakumulasi;
                                double hargaJualAkumulasi;

                                //Guid PromoRowID = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                                DataTable dtAkumulasihari, dtAkumulasiPenjualan;

                                if (Prolib.Akumulasi(PromoRowIDKelompok) == true)
                                {
                                    //ambil akumulasi berapa hari
                                    dtAkumulasihari = Prolib.AmbilHari(PromoRowIDKelompok);

                                    akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                    if (akumulasihari == 0)
                                    {
                                        akumulasihari = 1;
                                    }

                                    dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
                                    qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                    hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

                                    //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                    sumqtyKelompok = qtyakumulasi + qtybarang;
                                    sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
                                }
                            }

                            #endregion

                            //kelipatan
                            #region kelipatan promo kelompok
                            for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                            {
                                //Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                                int qminKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_min"]);
                                int qmaxKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_max"]);
                                double sminKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_min"]);
                                double smaxKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_max"]);
                                int qtybonusKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["qty_bns"]);
                                int kelipatanKelompok = 1;
                                if (Prolib.Kelipatan(PromoRowIDKelompok) == true)
                                {
                                    //cek syarat qtymax barang
                                    if (qmaxKelompok > 0 && sumqtyKelompok <= qmaxKelompok)
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
                                    }
                                    if (qmaxKelompok > 0 && sumqtyKelompok > qmaxKelompok)
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxKelompok) / qminKelompok));
                                    }

                                    //cek syarat smax barang
                                    if (smaxKelompok > 0 && sumhargajualKelompok <= smaxKelompok)
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
                                    }

                                    if (smaxKelompok > 0 && sumhargajualKelompok >= smaxKelompok)
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / smaxKelompok));
                                    }

                                    if (qmaxKelompok == 0 && smaxKelompok == 0)
                                    {
                                        if (qminKelompok == 0)
                                        {
                                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
                                        }
                                        else
                                        {
                                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
                                        }
                                    }

                                    //menghitung kelipatan 
                                    sumKelipatanQtyKelompok = kelipatanKelompok * qtybonusKelompok;
                                    dtpromoKelompok.Rows[i]["qty_bns"] = sumKelipatanQtyKelompok.ToString();
                                }
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        //masuk ke bawah
                        #region Akumulasi Kelompok
                        for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                        {
                            DateTime hari = DateTime.Now;
                            kodetoko = lookupToko1.KodeToko;
                            int akumulasihari, qtyakumulasi = 0;
                            double hargaJualAkumulasi = 0;

                            Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                            DataTable dtAkumulasihari, dtAkumulasiPenjualan;

                            if (Prolib.Akumulasi(PromoRowIDKelompok) == true)
                            {
                                //ambil akumulasi berapa hari
                                dtAkumulasihari = Prolib.AmbilHari(PromoRowIDKelompok);

                                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                if (akumulasihari == 0)
                                {
                                    akumulasihari = 1;
                                }

                                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);

                                if (dtAkumulasiPenjualan.Rows.Count > 0)
                                {
                                    qtyakumulasi = Convert.ToInt32(Tools.isNull(dtAkumulasiPenjualan.Rows[0]["finalqty"], "0").ToString());
                                    hargaJualAkumulasi = Convert.ToDouble(Tools.isNull(dtAkumulasiPenjualan.Rows[0]["finalharga"], "0").ToString());
                                }
                                //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                sumqtyKelompok = qtyakumulasi + qtybarang;
                                sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;

                            }

                            if (Tools.isNull(dtpromoKelompok.Rows[0]["far"], "").ToString().Trim() == "1")
                            {
                                PromoPoint = 1;
                            }

                        }
                        #endregion

                        #region kelipatan promo kelompok
                        for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                        {
                            Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                            int qminKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_min"]);
                            int qmaxKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_max"]);
                            double sminKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_min"]);
                            double smaxKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_max"]);
                            int qtybonusKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["qty_bns"]);
                            int kelipatanKelompok = 1;

                            if (Prolib.Kelipatan(PromoRowIDKelompok) == true)
                            {
                                if (Tools.isNull(dtpromoKelompok.Rows[0]["far"], "").ToString().Trim() == "1")
                                {
                                    nSmin = sminKelompok;
                                }

                                //cek syarat qtymax barang
                                if (qmaxKelompok > 0 && sumqtyKelompok <= qmaxKelompok)
                                {
                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
                                }
                                if (qmaxKelompok > 0 && sumqtyKelompok > qmaxKelompok)
                                {
                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxKelompok) / qminKelompok));
                                }

                                //cek syarat smax barang
                                if (smaxKelompok > 0 && sumhargajualKelompok <= smaxKelompok)
                                {
                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
                                }

                                if (smaxKelompok > 0 && sumhargajualKelompok >= smaxKelompok)
                                {
                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(smaxKelompok) / sminKelompok));
                                }

                                if (qmaxKelompok == 0 && smaxKelompok == 0)
                                {
                                    if (qminKelompok == 0)
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
                                    }
                                    else
                                    {
                                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
                                    }
                                }

                                //menghitung kelipatan 
                                sumKelipatanQtyKelompok = kelipatanKelompok * qtybonusKelompok;
                                dtpromoKelompok.Rows[i]["qty_bns"] = sumKelipatanQtyKelompok.ToString();
                            }
                        }

                        #endregion

                    }
                }
                #endregion

                #region enduser Tahunan
                for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
                {
                    if (lookupToko1.NamaToko == "ECERAN CASH")
                    {
                        Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
                        //panggil dari prolib yang fungsi cek enduser
                        if (Prolib.Enduser(PromoRowIDTahunan) == true)
                        {
                            //akumulasi
                            #region Akumulasi Tahunan
                            for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
                            {
                                DateTime hari = DateTime.Now;
                                kodetoko = lookupToko1.KodeToko;
                                int akumulasihari, qtyakumulasi;
                                double hargaJualAkumulasi;

                                //Guid PromoRowID = (Guid)(dtpromoTahunan.Rows[i]["PromoDetailRowID"]);
                                DataTable dtAkumulasihari, dtAkumulasiPenjualan;


                                if (Prolib.Akumulasi(PromoRowIDTahunan) == true)
                                {
                                    //ambil akumulasi berapa hari
                                    dtAkumulasihari = Prolib.AmbilHari(PromoRowIDTahunan);

                                    akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                    if (akumulasihari == 0)
                                    {
                                        akumulasihari = 1;
                                    }

                                    dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);


                                    qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                    hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

                                    //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                    sumqtyTahunan = qtyakumulasi + qtybarang;
                                    sumhargajualTahunan = hargaJualAkumulasi + hargajualTahunan;


                                }
                            }

                            #endregion

                            //kelipatan
                            #region kelipatan promo Tahunan
                            for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
                            {
                                //Guid PromoRowIDTahunan = (Guid)(dtpromoTahunan.Rows[i]["PromoDetailRowID"]);
                                int qminTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_min"]);
                                int qmaxTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_max"]);
                                double sminTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_min"]);
                                double smaxTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_max"]);
                                int qtybonusTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["qty_bns"]);
                                int kelipatanTahunan = 1;
                                if (Prolib.Kelipatan(PromoRowIDTahunan) == true)
                                {
                                    //cek syarat qtymax barang
                                    if (qmaxTahunan > 0 && sumqtyTahunan <= qmaxTahunan)
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
                                    }
                                    if (qmaxTahunan > 0 && sumqtyTahunan > qmaxTahunan)
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxTahunan) / qminTahunan));
                                    }

                                    //cek syarat smax barang
                                    if (smaxTahunan > 0 && sumhargajualTahunan <= smaxTahunan)
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
                                    }

                                    if (smaxTahunan > 0 && sumhargajualTahunan >= smaxTahunan)
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / smaxTahunan));
                                    }

                                    if (qmaxTahunan == 0 && smaxTahunan == 0)
                                    {
                                        if (qminTahunan == 0)
                                        {
                                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
                                        }
                                        else
                                        {
                                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
                                        }
                                    }

                                    //menghitung kelipatan 
                                    sumKelipatanQtyTahunan = kelipatanTahunan * qtybonusTahunan;
                                    dtPromoTahunan.Rows[i]["qty_bns"] = sumKelipatanQtyTahunan.ToString();
                                }
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        //masuk ke bawah
                        #region Akumulasi Tahunan
                        for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
                        {
                            DateTime hari = DateTime.Now;
                            kodetoko = lookupToko1.KodeToko;
                            int akumulasihari, qtyakumulasi;
                            double hargaJualAkumulasi;

                            Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
                            DataTable dtAkumulasihari, dtAkumulasiPenjualan;


                            if (Prolib.Akumulasi(PromoRowIDTahunan) == true)
                            {
                                //ambil akumulasi berapa hari
                                dtAkumulasihari = Prolib.AmbilHari(PromoRowIDTahunan);

                                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                                if (akumulasihari == 0)
                                {
                                    akumulasihari = 1;
                                }

                                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);


                                qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

                                //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                sumqtyTahunan = qtyakumulasi + qtybarang;
                                sumhargajualTahunan = hargaJualAkumulasi + hargajualTahunan;


                            }
                        }

                        #endregion

                        #region kelipatan promo Tahunan
                        for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
                        {
                            Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
                            int qminTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_min"]);
                            int qmaxTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_max"]);
                            double sminTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_min"]);
                            double smaxTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_max"]);
                            int qtybonusTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["qty_bns"]);
                            int kelipatanTahunan = 1;
                            if (Prolib.Kelipatan(PromoRowIDTahunan) == true)
                            {
                                //cek syarat qtymax barang
                                if (qmaxTahunan > 0 && sumqtyTahunan <= qmaxTahunan)
                                {
                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
                                }
                                if (qmaxTahunan > 0 && sumqtyTahunan > qmaxTahunan)
                                {
                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxTahunan) / qminTahunan));
                                }

                                //cek syarat smax barang
                                if (smaxTahunan > 0 && sumhargajualTahunan <= smaxTahunan)
                                {
                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
                                }

                                if (smaxTahunan > 0 && sumhargajualTahunan >= smaxTahunan)
                                {
                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(smaxTahunan) / sminTahunan));
                                }

                                if (qmaxTahunan == 0 && smaxTahunan == 0)
                                {
                                    if (qminTahunan == 0)
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
                                    }
                                    else
                                    {
                                        kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
                                    }
                                }

                                //menghitung kelipatan 
                                sumKelipatanQtyTahunan = kelipatanTahunan * qtybonusTahunan;
                                dtPromoTahunan.Rows[i]["qty_bns"] = sumKelipatanQtyTahunan.ToString();
                            }
                        }

                        #endregion

                    }
                }
                #endregion

                if (dtPromoBrg.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0 || dtPromoTahunan.Rows.Count > 0)
                {
                    string idtoko = lookupToko1.KodeToko;
                    DO.frmpilihbonusDO ifrmChild = new DO.frmpilihbonusDO(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBrg, dtpromoKelompok, dtPromoTahunan);
                    ifrmChild.ShowDialog();
                    if (PromoPoint == 1)
                    {
                        MessageBox.Show("Transaksi ini telah mendapat Point");
                        MessageBox.Show(nSmin.ToString());
                    }
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
            }
        }


        #region GetPromoLama
        //private void getPromo()
        //{
        //    try
        //    {
        //        int sumqtyBarang = 0;
        //        double sumhargajualbarang = 0;
        //        int qtybarang = 0;
        //        double hargajualbarang = 0;
        //        int sumqtyKelompok = 0;
        //        double sumhargajualKelompok = 0;
        //        int qtyKelompok = 0;
        //        double hargajualKelompok = 0;
        //        int sumKelipatanQtyBarang = 0;
        //        int sumKelipatanQtyKelompok = 0;
        //        int i = 0;
        //        #region cari promo tetap. promo tetap itu  yang dapet cuma dari toko inti
        //        //transaksi penjualan pertama setiap bulan, kode toko buat input, trus cek nota diya pernah transaksi di bulan yang sama, where ambil bulan tglsj = getdate(brti salah);
        //        kodetoko = lookupToko1.KodeToko;
        //        if (Prolib.HistoryPenjualan(kodetoko) == false)
        //        {
        //            using (Database db = new Database())
        //            {
        //                db.Commands.Add(db.CreateCommand("usp_getPromoTetap"));
        //                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
        //                dtpromotetap = db.Commands[0].ExecuteDataTable();
        //            }
        //        }
        //        else
        //        {
        //            dtpromotetap = new DataTable();
        //        }
        //        #endregion
        //        #region mencari barang apa aja yang lagi promo
        //        for (i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            string idbrng = dataGridView1.Rows[i].Cells[0].Value.ToString();
        //            DataTable dtpromobarang = Prolib.DataPromoBarang(_barangID);
        //            qtybarang = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);
        //            hargajualbarang = Convert.ToDouble(dataGridView1.Rows[i].Cells["GvJumlah"].Value);
        //            if (dtpromobarang.Rows.Count > 0)
        //            {
        //                sumqtyBarang = sumqtyBarang + qtybarang;
        //                sumhargajualbarang = sumhargajualbarang + hargajualbarang;
        //            }
        //        }
        //        #endregion

        //        #region promo kelompok nya

        //        for (i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (Prolib.cekpromokelompok(_barangID) == true)
        //            {
        //                qtyKelompok = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);

        //                sumqtyKelompok = sumqtyKelompok + qtyKelompok;
        //                //dataGridView1.Rows[i].Cells["GvJumlah"].Value = jumnetakhir;
        //                hargajualKelompok = Convert.ToDouble(dataGridView1.Rows[i].Cells["GvJumlah"].Value);
        //                //MessageBox.Show(hargajualKelompok.ToString());

        //                sumhargajualKelompok = sumhargajualKelompok + hargajualKelompok;


        //                DataTable dtPromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);

        //            }
        //        }
        //        #endregion


        //        #region bonus promo barang dan bonus promo kelompok

        //        DataTable dtPromoBarangBonus = Prolib.DataPromoBarangBonus(sumqtyBarang, sumhargajualbarang);
        //        DataTable dtpromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);

        //        #region Belum ada history
        //        for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //        {
        //            //kodetoko = lookupToko1.KodeToko;
        //            //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //            //if (Prolib.BelumAdaHistory(PromoRowID) == true)
        //            //{
        //            //    DataTable dtHistJualToko = Prolib.HistJualToko(kodetoko);
        //            //    if (dtHistJualToko.Rows.Count > 0)
        //            //    {
        //            //        //dapet bonus
        //            //    }
        //            //}
        //        }
        //        #endregion

        //        #region enduser barang
        //        for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //        {
        //            if (lookupToko1.NamaToko == "ECERAN CASH")
        //            {
        //                Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //                //panggil dari prolib yang fungsi cek enduser
        //                if (Prolib.Enduser(PromoRowID) == true)
        //                {
        //                    //akumulasi
        //                    #region Akumulasi barang
        //                    for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //                    {
        //                        DateTime hari = DateTime.Now;
        //                        kodetoko = lookupToko1.KodeToko;
        //                        int akumulasihari, qtyakumulasi;
        //                        double hargaJualAkumulasi;

        //                        //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //                        DataTable dtAkumulasihari, dtAkumulasiPenjualan;

        //                        if (Prolib.Akumulasi(PromoRowID) == true)
        //                        {
        //                            //ambil akumulasi berapa hari
        //                            dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

        //                            akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);

        //                            dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);

        //                            if (dtAkumulasiPenjualan.Rows.Count > 0)
        //                            {
        //                                //ambil akumulasi berapa hari
        //                                dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

        //                                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                                if (akumulasihari == 0)
        //                                {
        //                                    akumulasihari = 1;
        //                                }

        //                                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
        //                                qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                                hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                                //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                                sumqtyKelompok = qtyakumulasi + qtybarang;
        //                                sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
        //                            }
        //                        }

        //                    }
        //                    #endregion
        //                    //kelipatan
        //                    #region kelipatan promo barang
        //                    for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //                    {
        //                        //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //                        int qmin = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_min"]);
        //                        int qmax = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_max"]);
        //                        double smin = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_min"]);
        //                        double smax = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_max"]);
        //                        int qtybonus = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["qty_bns"]);
        //                        int kelipatan = 1;
        //                        if (Prolib.Kelipatan(PromoRowID) == true)
        //                        {
        //                            //cek syarat qtymax barang
        //                            if (qmax > 0 && sumqtyBarang <= qmax)
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyBarang) / qmin));
        //                            }
        //                            if (qmax > 0 && sumqtyBarang > qmax)
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmax) / qmin));
        //                            }

        //                            //cek syarat smax barang
        //                            if (smax > 0 && sumhargajualbarang <= smax)
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                            }

        //                            if (smax > 0 && sumhargajualbarang >= smax)
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smax));
        //                            }

        //                            if (qmax == 0 && smax == 0)
        //                            {
        //                                if (qmin == 0)
        //                                {
        //                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                                }
        //                                else
        //                                {
        //                                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qmin));
        //                                }
        //                            }


        //                            //menghitung kelipatan barang
        //                            sumKelipatanQtyBarang = kelipatan * qtybonus;

        //                            dtPromoBarangBonus.Rows[i]["qty_bns"] = sumKelipatanQtyBarang.ToString();


        //                        }
        //                    }
        //                    #endregion
        //                }
        //            }
        //            else
        //            {
        //                //masuk ke bawah
        //                //akumulasi
        //                #region Akumulasi barang
        //                for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //                {
        //                    DateTime hari = DateTime.Now;
        //                    kodetoko = lookupToko1.KodeToko;
        //                    int akumulasihari, qtyakumulasi;
        //                    double hargaJualAkumulasi;

        //                    Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //                    DataTable dtAkumulasihari, dtAkumulasiPenjualan;

        //                    if (Prolib.Akumulasi(PromoRowID) == true)
        //                    {
        //                        //ambil akumulasi berapa hari
        //                        dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

        //                        akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[0]["hrg_promo"]);
        //                        if (akumulasihari == 0)
        //                        {
        //                            akumulasihari = 1;
        //                        }
        //                        dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);

        //                        if (dtAkumulasiPenjualan.Rows.Count > 0)
        //                        {
        //                            qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                            hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                            //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                            sumqtyKelompok = qtyakumulasi + qtybarang;
        //                            sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
        //                        }
        //                    }


        //                #endregion
        //                    //kelipatan
        //                    #region kelipatan promo barang

        //                    //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //                    int qmin = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_min"]);
        //                    int qmax = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_max"]);
        //                    double smin = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_min"]);
        //                    double smax = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_max"]);
        //                    int qtybonus = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["qty_bns"]);
        //                    int kelipatan = 1;
        //                    if (Prolib.Kelipatan(PromoRowID) == true)
        //                    {
        //                        //cek syarat qtymax barang
        //                        if (qmax > 0 && sumqtyBarang <= qmax)
        //                        {
        //                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyBarang) / qmin));
        //                        }
        //                        if (qmax > 0 && sumqtyBarang > qmax)
        //                        {
        //                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmax) / qmin));
        //                        }

        //                        //cek syarat smax barang
        //                        if (smax > 0 && sumhargajualbarang <= smax)
        //                        {
        //                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                        }

        //                        if (smax > 0 && sumhargajualbarang >= smax)
        //                        {
        //                            kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smax));
        //                        }

        //                        if (qmax == 0 && smax == 0)
        //                        {
        //                            if (qmin == 0)
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                            }
        //                            else
        //                            {
        //                                kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qmin));
        //                            }
        //                        }


        //                        //menghitung kelipatan barang
        //                        sumKelipatanQtyBarang = kelipatan * qtybonus;

        //                        dtPromoBarangBonus.Rows[i]["qty_bns"] = sumKelipatanQtyBarang.ToString();


        //                    }
        //                }
        //                    #endregion
        //            }
        //        }
        //        #endregion

        //        #region enduser kelompok
        //        for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //        {
        //            if (lookupToko1.NamaToko == "ECERAN CASH")
        //            {
        //                Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //                //panggil dari prolib yang fungsi cek enduser
        //                if (Prolib.Enduser(PromoRowIDKelompok) == true)
        //                {
        //                    //akumulasi
        //                    #region Akumulasi Kelompok
        //                    for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //                    {
        //                        DateTime hari = DateTime.Now;
        //                        kodetoko = lookupToko1.KodeToko;
        //                        int akumulasihari, qtyakumulasi;
        //                        double hargaJualAkumulasi;

        //                        //Guid PromoRowID = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //                        DataTable dtAkumulasihari, dtAkumulasiPenjualan;


        //                        if (Prolib.Akumulasi(PromoRowIDKelompok) == true)
        //                        {
        //                            //ambil akumulasi berapa hari
        //                            dtAkumulasihari = Prolib.AmbilHari(PromoRowIDKelompok);

        //                            akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                            if (akumulasihari == 0)
        //                            {
        //                                akumulasihari = 1;
        //                            }

        //                            dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);


        //                            qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                            hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                            //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                            sumqtyKelompok = qtyakumulasi + qtybarang;
        //                            sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;


        //                        }
        //                    }

        //                    #endregion

        //                    //kelipatan
        //                    #region kelipatan promo kelompok
        //                    for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //                    {
        //                        //Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //                        int qminKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_min"]);
        //                        int qmaxKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_max"]);
        //                        double sminKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_min"]);
        //                        double smaxKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_max"]);
        //                        int qtybonusKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["qty_bns"]);
        //                        int kelipatanKelompok = 1;
        //                        if (Prolib.Kelipatan(PromoRowIDKelompok) == true)
        //                        {
        //                            //cek syarat qtymax barang
        //                            if (qmaxKelompok > 0 && sumqtyKelompok <= qmaxKelompok)
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                            }
        //                            if (qmaxKelompok > 0 && sumqtyKelompok > qmaxKelompok)
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxKelompok) / qminKelompok));
        //                            }

        //                            //cek syarat smax barang
        //                            if (smaxKelompok > 0 && sumhargajualKelompok <= smaxKelompok)
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                            }

        //                            if (smaxKelompok > 0 && sumhargajualKelompok >= smaxKelompok)
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / smaxKelompok));
        //                            }

        //                            if (qmaxKelompok == 0 && smaxKelompok == 0)
        //                            {
        //                                if (qminKelompok == 0)
        //                                {
        //                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                                }
        //                                else
        //                                {
        //                                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                                }
        //                            }

        //                            //menghitung kelipatan 
        //                            sumKelipatanQtyKelompok = kelipatanKelompok * qtybonusKelompok;
        //                            dtpromoKelompok.Rows[i]["qty_bns"] = sumKelipatanQtyKelompok.ToString();
        //                        }
        //                    }

        //                    #endregion
        //                }
        //            }
        //            else
        //            {
        //                //masuk ke bawah
        //                #region Akumulasi Kelompok
        //                for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //                {
        //                    DateTime hari = DateTime.Now;
        //                    kodetoko = lookupToko1.KodeToko;
        //                    int akumulasihari, qtyakumulasi;
        //                    double hargaJualAkumulasi;

        //                    Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //                    DataTable dtAkumulasihari, dtAkumulasiPenjualan;


        //                    if (Prolib.Akumulasi(PromoRowIDKelompok) == true)
        //                    {
        //                        //ambil akumulasi berapa hari
        //                        dtAkumulasihari = Prolib.AmbilHari(PromoRowIDKelompok);

        //                        akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                        if (akumulasihari == 0)
        //                        {
        //                            akumulasihari = 1;
        //                        }

        //                        dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);


        //                        qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                        hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                        //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                        sumqtyKelompok = qtyakumulasi + qtybarang;
        //                        sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;


        //                    }
        //                }

        //                #endregion

        //                #region kelipatan promo kelompok
        //                for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //                {
        //                    Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //                    int qminKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_min"]);
        //                    int qmaxKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_max"]);
        //                    double sminKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_min"]);
        //                    double smaxKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_max"]);
        //                    int qtybonusKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["qty_bns"]);
        //                    int kelipatanKelompok = 1;
        //                    if (Prolib.Kelipatan(PromoRowIDKelompok) == true)
        //                    {
        //                        //cek syarat qtymax barang
        //                        if (qmaxKelompok > 0 && sumqtyKelompok <= qmaxKelompok)
        //                        {
        //                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                        }
        //                        if (qmaxKelompok > 0 && sumqtyKelompok > qmaxKelompok)
        //                        {
        //                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxKelompok) / qminKelompok));
        //                        }

        //                        //cek syarat smax barang
        //                        if (smaxKelompok > 0 && sumhargajualKelompok <= smaxKelompok)
        //                        {
        //                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                        }

        //                        if (smaxKelompok > 0 && sumhargajualKelompok >= smaxKelompok)
        //                        {
        //                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / smaxKelompok));
        //                        }

        //                        if (qmaxKelompok == 0 && smaxKelompok == 0)
        //                        {
        //                            if (qminKelompok == 0)
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                            }
        //                            else
        //                            {
        //                                kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                            }
        //                        }

        //                        //menghitung kelipatan 
        //                        sumKelipatanQtyKelompok = kelipatanKelompok * qtybonusKelompok;
        //                        dtpromoKelompok.Rows[i]["qty_bns"] = sumKelipatanQtyKelompok.ToString();
        //                    }
        //                }

        //                #endregion

        //            }
        //        }
        //        #endregion



        //        #region kelipatan promo barang
        //        /*for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //        {
        //            Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //            int qmin = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_min"]);
        //            int qmax = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["q_max"]);
        //            double smin = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_min"]);
        //            double smax = Convert.ToDouble(dtPromoBarangBonus.Rows[i]["s_max"]);
        //            int qtybonus = Convert.ToInt32(dtPromoBarangBonus.Rows[i]["qty_bns"]);
        //            int kelipatan = 1;
        //            if (Prolib.Kelipatan(PromoRowID) == true)
        //            {
        //                //cek syarat qtymax barang
        //                if (qmax > 0 && sumqtyBarang <= qmax)
        //                {
        //                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyBarang) / qmin));
        //                }
        //                if (qmax > 0 && sumqtyBarang > qmax)
        //                {
        //                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmax) / qmin));
        //                }

        //                //cek syarat smax barang
        //                if (smax > 0 && sumhargajualbarang <= smax)
        //                {
        //                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                }

        //                if (smax > 0 && sumhargajualbarang >= smax)
        //                {
        //                    kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smax));
        //                }

        //                if (qmax == 0 && smax == 0)
        //                {
        //                    if (qmin == 0)
        //                    {
        //                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualbarang) / smin));
        //                    }
        //                    else
        //                    {
        //                        kelipatan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qmin));
        //                    }
        //                }


        //                //menghitung kelipatan barang
        //                sumKelipatanQtyBarang = kelipatan * qtybonus;

        //                dtPromoBarangBonus.Rows[i]["qty_bns"] = sumKelipatanQtyBarang.ToString();


        //            }
        //        }*/
        //        #endregion

        //        #region kelipatan promo kelompok
        //        /*for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //        {
        //            Guid PromoRowIDKelompok = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //            int qminKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_min"]);
        //            int qmaxKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["q_max"]);
        //            double sminKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_min"]);
        //            double smaxKelompok = Convert.ToDouble(dtpromoKelompok.Rows[i]["s_max"]);
        //            int qtybonusKelompok = Convert.ToInt32(dtpromoKelompok.Rows[i]["qty_bns"]);
        //            int kelipatanKelompok = 1;
        //            if (Prolib.Kelipatan(PromoRowIDKelompok) == true)
        //            {
        //                //cek syarat qtymax barang
        //                if (qmaxKelompok > 0 && sumqtyKelompok <= qmaxKelompok)
        //                {
        //                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                }
        //                if (qmaxKelompok > 0 && sumqtyKelompok > qmaxKelompok)
        //                {
        //                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxKelompok) / qminKelompok));
        //                }

        //                //cek syarat smax barang
        //                if (smaxKelompok > 0 && sumhargajualKelompok <= smaxKelompok)
        //                {
        //                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                }

        //                if (smaxKelompok > 0 && sumhargajualKelompok >= smaxKelompok)
        //                {
        //                    kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / smaxKelompok));
        //                }

        //                if (qmaxKelompok == 0 && smaxKelompok == 0)
        //                {
        //                    if (qminKelompok == 0)
        //                    {
        //                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualKelompok) / sminKelompok));
        //                    }
        //                    else
        //                    {
        //                        kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyKelompok) / qminKelompok));
        //                    }
        //                }

        //                //menghitung kelipatan 
        //                sumKelipatanQtyKelompok = kelipatanKelompok * qtybonusKelompok;
        //                dtpromoKelompok.Rows[i]["qty_bns"] = sumKelipatanQtyKelompok.ToString();
        //            }
        //        }*/

        //        #endregion

        //        #region Akumulasi barang
        //        /* for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
        //        {
        //            DateTime hari = DateTime.Now;
        //            kodetoko = lookupToko1.KodeToko;
        //            int akumulasihari, qtyakumulasi;
        //            double hargaJualAkumulasi;

        //            Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
        //            DataTable dtAkumulasihari,dtAkumulasiPenjualan;

        //            if (Prolib.Akumulasi(PromoRowID) == true)
        //            {
        //                //ambil akumulasi berapa hari
        //                dtAkumulasihari = Prolib.AmbilHari(PromoRowID);
                        
        //                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
                        
        //                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
                            
        //                    if (dtAkumulasiPenjualan.Rows.Count > 0)
        //                    {
        //                        //ambil akumulasi berapa hari
        //                        dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

        //                        akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                        if (akumulasihari == 0)
        //                        {
        //                            akumulasihari = 1;
        //                        }

        //                        dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
        //                        qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                        hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                        //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                        sumqtyKelompok = qtyakumulasi + qtybarang;
        //                        sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;
        //                    }
        //            }

        //        }*/
        //        #endregion

        //        #region Akumulasi Kelompok
        //        /*for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
        //        {
        //            DateTime hari = DateTime.Now;
        //            kodetoko = lookupToko1.KodeToko;
        //            int akumulasihari, qtyakumulasi;
        //            double hargaJualAkumulasi;

        //            Guid PromoRowID = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
        //            DataTable dtAkumulasihari, dtAkumulasiPenjualan;


        //            if (Prolib.Akumulasi(PromoRowID) == true)
        //            {
        //                //ambil akumulasi berapa hari
        //                dtAkumulasihari = Prolib.AmbilHari(PromoRowID);

        //                akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                if (akumulasihari == 0)
        //                {
        //                    akumulasihari = 1;
        //                }

        //                dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);


        //                qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

        //                //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                sumqtyKelompok = qtyakumulasi + qtybarang;
        //                sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;


        //            }
        //        }*/

        //        #endregion

        //        if (dtPromoBarangBonus.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0)
        //        {
        //            string idtoko = lookupToko1.KodeToko;

        //            frmpilihbonus ifrmChild = new frmpilihbonus(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBarangBonus, dtpromoKelompok);
        //            ifrmChild.ShowDialog();
        //        }
        //        #endregion

        //        #region ijo2
        //        //DataTable dtrw = new DataTable();
        //        //using (Database db = new Database())
        //        //{
        //        //    db.Commands.Add(db.CreateCommand("usp_cek_row_promo"));
        //        //    db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, idbrng));
        //        //    dtrw = db.Commands[0].ExecuteDataTable();
        //        //}

        //        //if (dtrw.Rows.Count > 0)
        //        //{
        //        //    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
        //        //}


        //        //ngambil barang promo (hadiah) kalo sumqty dan sumharga nya >= q_min dan s_min


        //        //int nRowIndex = dataGridView1.Rows.Count;
        //        //using (Database db = new Database())
        //        //{
        //        //    db.Commands.Add(db.CreateCommand("usp_Get_Barang_Promo_DO_List"));
        //        //    /* db.Commands[0].Parameters.Add(new Parameter("@total", SqlDbType.Money, 500000));
        //        //     db.Commands[0].Parameters.Add(new Parameter("@QtyTtl", SqlDbType.Int, 50));
        //        //     db.Commands[0].Parameters.Add(new Parameter("@datepro", SqlDbType.DateTime, Convert.ToDateTime("2012/07/01")));
        //        //      */
        //        //    db.Commands[0].Parameters.Add(new Parameter("@total", SqlDbType.Money, Convert.ToDouble(label12.Text)));
        //        //    db.Commands[0].Parameters.Add(new Parameter("@QtyTtl", SqlDbType.Int, Convert.ToInt32(lblqty.Text) ));
        //        //    db.Commands[0].Parameters.Add(new Parameter("@datepro", SqlDbType.DateTime, Convert.ToDateTime(DateTime.Now)));
        //        //    dtPromo = db.Commands[0].ExecuteDataTable();
        //        //}


        //        //if (dtpromotetap.Rows.Count > 0|| dtPromo.Rows.Count > 0)
        //        //{
        //        //    string idtoko = lookupToko1.KodeToko;
        //        //    //string barangID = ;
        //        //    frmpilihbonus ifrmChild = new frmpilihbonus(this, idtoko, _barangID);
        //        //    ifrmChild.ShowDialog();
        //        //foreach (DataRow dr in dtPromo.Rows)
        //        //{
        //        //    dataGridView1.Rows.Add(1);
        //        //    dataGridView1.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[2].Value = Convert.ToInt32(dr["QtyRequest"]);
        //        //    dataGridView1.Rows[nRowIndex].Cells[3].Value = dr["Satuan"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[4].Value = dr["HrgJual"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[5].Value = dr["Disc1"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[6].Value = dr["Disc2"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[7].Value = dr["Disc3"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[8].Value = dr["Pot"];
        //        //    dataGridView1.Rows[nRowIndex].Cells[9].Value = dr["jumlah"];
        //        //    nRowIndex++;
        //        //}
        //        //}
        //        #endregion
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //    }
        //}
        #endregion


        //public bool savepromo(DataTable dtbarang)
        public bool savepromo(DataTable dtPromo)
        {
            int i = 0;
            i = dataGridView1.Rows.Count;
            int j = i + 1;

            /*nyimpen promo barang setelah dipilih dari grid promo barang*/
            string idBrg = string.Empty;
            string idBrgPromo = string.Empty;
            double h_jual = 0, hjual;

            foreach (DataRow dr in dtPromo.Rows)
            {
                idBrgPromo = Convert.ToString(dr["id_brg"]);
                h_jual = Convert.ToDouble(Tools.isNull(dr["h_jual"], "0").ToString());
                foreach (DataGridViewRow drDO in dataGridView1.Rows)
                {
                    idBrg = Convert.ToString(drDO.Cells["gVplu"].Value);
                    hjual = Convert.ToDouble(Tools.isNull(drDO.Cells["GvHarga"].Value, "0").ToString());
                    if (idBrg == idBrgPromo && hjual == h_jual)
                    {
                        return false;
                    }
                }
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = idBrgPromo;
                dataGridView1.Rows[i].Cells[1].Value = dr["nama_stok"];
                dataGridView1.Rows[i].Cells[2].Value = Convert.ToInt32(dr["qty_bns"]);
                dataGridView1.Rows[i].Cells[3].Value = dr["satuan"];
                dataGridView1.Rows[i].Cells[4].Value = dr["h_jual"];
                dataGridView1.Rows[i].Cells[5].Value = 0;
                dataGridView1.Rows[i].Cells[6].Value = 0;
                dataGridView1.Rows[i].Cells[7].Value = 0;
                dataGridView1.Rows[i].Cells[8].Value = 0;
                dataGridView1.Rows[i].Cells[9].Value = 0;
                dataGridView1.Rows[i].Cells[12].Value = 1;
                i++;
            }
            return true;

            #region lama
            ////masukin barang promo yang udah kepilih ke datagrid yang udah ada
            //int i = 0;
            //i = dataGridView1.Rows.Count;
            //int j = i + 1;
            ////nyimpen promo barang setelah dipilih dari grid promo barang
            //string idBrg = string.Empty;
            //string idBrgPromo = string.Empty;
            //foreach (DataRow dr in dtbarang.Rows)
            //{
            //    idBrgPromo = Convert.ToString(dr["barangid"]);
            //    foreach (DataGridViewRow drPOS in dataGridView1.Rows)
            //    {
            //        idBrg = Convert.ToString(drPOS.Cells["gVplu"].Value);
            //        if (idBrg == idBrgPromo)
            //        {
            //            return false;
            //        }
            //    }
            //    dataGridView1.Rows.Add(1);
            //    dataGridView1.Rows[i].Cells[0].Value = dr["barangid"];
            //    dataGridView1.Rows[i].Cells[1].Value = dr["namabarang"];
            //    dataGridView1.Rows[i].Cells[2].Value = Convert.ToInt32(dr["qtybonus"]);
            //    dataGridView1.Rows[i].Cells[3].Value = dr["satuan"];
            //    dataGridView1.Rows[i].Cells[4].Value = dr["h_jual"];
            //    dataGridView1.Rows[i].Cells[5].Value = 0;
            //    dataGridView1.Rows[i].Cells[6].Value = 0;
            //    dataGridView1.Rows[i].Cells[7].Value = 0;
            //    dataGridView1.Rows[i].Cells[8].Value = 0;
            //    dataGridView1.Rows[i].Cells[9].Value = 0;
            //    i++;
            //}
            //return true;
            #endregion
        }


  
        private void CBShift_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(CBShift.Text);
                if (a < 1)
                {
                    MessageBox.Show(" 1 atau 2 ", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CBShift.Text = "1";
                    CBShift.Select();
                }
                if (a > 2)
                {
                    MessageBox.Show(" 1 atau 2 ", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CBShift.Text = "1";
                    CBShift.Select();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR");
                CBShift.Text = "1";
                CBShift.Select();
            }
        }

        private void CmdClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        public void Save_DONOTA(object sender, EventArgs e)
        {
            if (validation())
            {
                #region Variabel
                idsales = lookupSales1.SalesID;
                if (formMode == enumFormMode.New)
                {
                    HtrId = Tools.CreateFingerPrint();
                    cab1 = initCab;
                    cab2 = initCab;
                    cab3 = "";
                    gudang = initgudang;
                }
                double nRpBayar = Convert.ToDouble(Tools.isNull(txtBayar.Text.ToString(), "0").ToString());
                double nRpNetto = Convert.ToDouble(Tools.isNull(label12.Text.ToString(), "0").ToString());
                double _totalHrg = 0;// double.Parse(dt.Compute("SUM(TotalHrg)", string.Empty).ToString());
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;
                double _discFormula = 0;
                double _harga3D = 0;
                int k; int l;
                k = 0; l = 0;

                _notaHeaderRowID = Guid.NewGuid();
                _notaHeaderRecID = Tools.CreateShortFingerPrint(k);
                _notaDetailRecID = string.Empty;

                this.Cursor = Cursors.WaitCursor;
                string temp = string.Empty;
                string kodeNota = "";
                string PTpattern = "KH,TH,KL,TL";
                string depannota = "";
                string belakangnota = "";
                nomorNota = "";
                int iNomorNota = 0;
                int iNomor = 0;
                int lebarnota = 4;
                int lebar = 4;
                int lebarOriginal = 0;
                int ctr = 0;
                int lastCtr = 0;
                int ctrBef = 0;
                DataTable dtNumNota;
                int countRows;

                depannota = GetInitialPT();

                /*generate nomor DO*/
                docNoDO = "NOMOR_DO_TAX";
                DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                lebar = 4;
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                if (Tools.isNull(dtNum.Rows[0]["Depan"], "").ToString() != depannota)
                    iNomor = 1;
                else
                {
                    iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    iNomor = iNomor + 1;
                }
                string _Nodo = Tools.FormatNumerator(iNomor, lebar, depannota, belakang);

                /*generate nomor Nota*/
                kodeNota = "NOMOR_NOTA_TAX";
                dtNumNota = Tools.GetGeneralNumerator(kodeNota);
                if (dtNumNota.Rows.Count > 0)
                {
                    lebarnota = 4;
                    belakangnota = dtNumNota.Rows[0]["Belakang"].ToString();
                    if (Tools.isNull(dtNumNota.Rows[0]["Depan"], "").ToString() != depannota)
                        iNomorNota = 1;
                    else
                    {
                        iNomorNota = int.Parse(dtNumNota.Rows[0]["Nomor"].ToString());
                        iNomorNota = iNomorNota + 1;
                    }
                }
                else
                {
                    MessageBox.Show("Numerator tidak ada!!");
                    return;
                }
                nomorNota = Tools.FormatNumerator(iNomorNota, lebarnota, depannota, belakangnota);
                LblNoNota.Text = nomorNota;

                string BarcodeNota = nomorNota.Trim() + GlobalVar.DateTimeOfServer.ToString("yyy").Substring(1, 3) +
                       GlobalVar.DateTimeOfServer.ToString("MM");

                if (DateTime.Today <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                #endregion

                #region SIMPAN HEADER DO NOTA
                //-------------    proses simpan ke HeaderDO, DetailDO, HeaderNota, DetailNota    -------------------------
                try
                {
                    _RowIDPos = Guid.NewGuid();
                    string _NoaccPusat = "";
                    if (!PengajuanHarga)
                        _NoaccPusat = "AUTOACC";
                    bool lNota = false;

                    #region pemanggil bengkel
                    if (pemanggil == "BENGKEL")
                    {
                        if (_RowIDNota.ToString() == "")
                            lNota = false;
                        else
                        {
                            if (CekNotaPos())
                            {
                                lNota = true;
                                try
                                {
                                    DataTable dtGetRecID = new DataTable();
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_GetHeaderRecordID"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDNota));
                                        dtGetRecID = db.Commands[0].ExecuteDataTable();
                                    }
                                    if (dtGetRecID.Rows.Count > 0)
                                    {
                                        _notaHeaderRecID = Convert.ToString(dtGetRecID.Rows[0]["RecordID"]);
                                        HtrId = Convert.ToString(dtGetRecID.Rows[0]["RecordID"]);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                }
                            }
                            else
                                lNota = false;
                        }
                    }
                    #endregion

                    if (lNota == false)
                    {
                        _TransactionType = comboBox1.Text;

                        #region OrderPenjualan
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.BeginTransaction();

                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_INSERT"));
                            if (pemanggil == "BENGKEL")
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowidbengkel)); //_rowid
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDPos)); //_rowid

                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, "CASH"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, _Nodo));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, _NoaccPusat));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, idsales));
                            db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, statustoko));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, alamatkirim));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, TxtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, "    "));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, TxtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, TxtCat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, TxtCat3.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, TxtCat4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, CBOEkspedisi.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, hari));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, 0));

                            if (!PengajuanHarga)
                                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 1));

                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, "1"));

                            if (pemanggil == "BENGKEL")
                            {
                                if (flagperbaikan == "Y")
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, 30));
                                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, "KG"));
                                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                                }
                                else
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, _TransactionType));
                                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID + " : " + "BENGKEL"));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID + " : " + "BENGKEL"));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, _TransactionType));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@CekSO", SqlDbType.Bit, 1));

                            //UPDATE NUMERATOR
                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depannota));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            if (pemanggil == "BENGKEL")
                                db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                            else
                                db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                        #endregion

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_GetRowIDDO"));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            dt = db.Commands[0].ExecuteDataTable();
                            _RowIDDO = (Guid)dt.Rows[0]["RowID"];
                        }

                        #region validasi overdue
                        /*update noaccpiutang TG*/
                        //overdue FX
                        if (pemanggil != "BENGKEL")
                        {
                            if ((comboBox1.Text != "K2" && comboBox1.Text != "K4") && (comboBox1.Text.Substring(0, 1) == "T"))
                            {
                                if (overdueFB > 0)
                                {
                                    int bagianPin = PinId.Bagian.OverdueFB;
                                    using (Database db = new Database())
                                    {
                                        DataTable dt = new DataTable();
                                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDPos));
                                        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                                        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc));
                                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        dt = db.Commands[0].ExecuteDataTable();
                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                }
                                else if (overdueFX > 0)
                                {
                                    int bagianPin = -1;
                                    using (Database db = new Database())
                                    {
                                        DataTable dt = new DataTable();
                                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDPos));
                                        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                                        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc));
                                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        dt = db.Commands[0].ExecuteDataTable();
                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        #endregion

                        #region nota penjualan
                        //save to header nota
                        //string barcodeNota = (nomorNota + TxtTGL.Text.Substring(1, 3) + TxtTGL.Text.Substring(4, 2));
                        if (!PengajuanHarga && !ValidasiPenjualanTunai)
                        {
                            string _TransacType = comboBox1.Text;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_INSERT"));
                                if (pemanggil == "BENGKEL")
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowidbengkel));  //_notaHeaderRowID
                                else
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDPos));  //_notaHeaderRowID
                                db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaHeaderRecID)); //_notaHeaderRecID));
                                db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _RowIDDO)); //_rowid
                                db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                                db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, nomorNota));//Tools.GetGeneralNumerator("NOMOR_NOTA").Rows[0].ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, nomorNota));
                                db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, TxtTGL.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, idsales));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                                db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, alamatkirim));
                                db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, kotatoko));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, _Cat1));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, _Cat2));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, _Cat3));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, _Cat4));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, _Cat5));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@BarcodeNota", SqlDbType.VarChar, BarcodeNota));

                                if (pemanggil == "BENGKEL")
                                {
                                    if (flagperbaikan == "Y")
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, "KG"));
                                        db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 30));
                                        db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                                    }
                                    else
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TransacType));
                                        db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                                        db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                                    }
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID.Trim()+" : " + "BENGKEL"));
                                }
                                else
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TransacType));
                                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                }
                                //UPDATE NUMERATOR NOTA
                                db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                                db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, kodeNota));
                                db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depannota));
                                db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakangnota));
                                db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomorNota));
                                db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebarnota));
                                if (pemanggil == "BENGKEL")
                                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                                else
                                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                //db.BeginTransaction();
                                db.Commands[0].ExecuteNonQuery();
                                db.Commands[1].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }
                        #endregion

                        #region Jika pemanggil Bengkel
                        if (pemanggil == "BENGKEL")
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_Bengkel_POS_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, rowidbengkel));
                                db.Commands[0].Parameters.Add(new Parameter("@notajualid", SqlDbType.UniqueIdentifier, rowidbengkel)); //_notaHeaderRowID 
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        #endregion

                    }

                    #region nota penjualan detail
                    //Detail Nota
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string r = (a + 1).ToString().PadLeft(3, '0');
                        Guid DetailRowIDDO = Guid.NewGuid();
                        string _recID = Tools.CreateFingerPrint().Substring(0, 19) + r;
                        string barangID;
                        int QTY, qtyperbarang;
                        double potongan = 0;

                        double HPP, disc1, disc2, disc3;
                        barangID = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        QTY = Convert.ToInt32(kuantiti2);
                        qtyperbarang = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                        HPP = Convert.ToDouble(dataGridView1.Rows[a].Cells[4].Value);
                        disc1 = Convert.ToDouble(dataGridView1.Rows[a].Cells[5].Value);
                        disc2 = Convert.ToDouble(dataGridView1.Rows[a].Cells[6].Value);
                        disc3 = Convert.ToDouble(dataGridView1.Rows[a].Cells[7].Value);
                        potongan = Convert.ToInt32(dataGridView1.Rows[a].Cells[8].Value);
                        _noACC = Convert.ToString(dataGridView1.Rows[a].Cells[12].Value);

                        using (Database db = new Database())
                        {
                            CekBarangID(barangID);
                            if (barangID.Substring(0, 3).Equals("FXB"))
                                potongan = 1;
                            if (_noACC.Equals("BONUSAN"))
                                potongan = 1;

                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, DetailRowIDDO));
                            if (pemanggil == "BENGKEL")
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowidbengkel)); //_rowid
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _RowIDPos)); //_rowid

                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recID));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, qtyperbarang));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, qtyperbarang));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, HPP));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, disc1));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, disc2));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, disc3));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, potongan));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, _noACC));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, TxtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nboPrint", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));

                            if (pemanggil == "BENGKEL")
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }

                        int counter = 0;
                        _notaDetailRecID = Tools.CreateFingerPrint().Substring(0, 19) + r;
                        Guid DetailRowIDNota = Guid.NewGuid();

                        if (!PengajuanHarga && !ValidasiPenjualanTunai)
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, DetailRowIDNota));
                                if (pemanggil == "BENGKEL")
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowidbengkel));
                                }
                                else
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _RowIDPos));
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaDetailRecID));
                                db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _notaHeaderRecID));

                                if (pemanggil == "BENGKEL")
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, rowidbengkel));
                                }
                                else
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _RowIDDO));
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, DetailRowIDDO));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, qtyperbarang));
                                db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, HPP));
                                db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, disc1));
                                db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, disc2));
                                db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, disc3));
                                db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, potongan));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, qtyperbarang));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, TxtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, ""));

                                if (pemanggil == "BENGKEL")
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                                else
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                                ctr++;
                                counter++;
                            }
                        }
                        #region recalculate
                        Recalculate(barangID, gudang);
                        //MessageBox.Show("Proses RECALCULATE Selesai");
                        this.Cursor = Cursors.Default;
                        #endregion
                    }
                    #endregion

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                #endregion

                #region LINK KE PIUTANG DAN BKM
                /*ditutup, dikembalikan ke penjualan tunai kasir*/
                /*Link ke Piutang dan BKM*/
                //if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                //{
                //    if (nRpBayar > 0 && pemanggil != "BENGKEL")
                //    {
                //        dtNota = new DataTable();
                //        try
                //        {
                //            this.Cursor = Cursors.WaitCursor;
                //            using (Database db = new Database())
                //            {
                //                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDPos));
                //                dtNota = db.Commands[0].ExecuteDataTable();
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            Error.LogError(ex);
                //        }
                //        finally
                //        {
                //            this.Cursor = Cursors.Default;
                //        }

                //        if (dtNota.Rows.Count == 0)
                //        {
                //            return;
                //        }

                //        string uraian = "", namasales = "", noPerkiraan = "";
                //        namasales = lookupSales1.NamaSales;
                //        uraian = "PJT (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
                //        noPerkiraan = GetNoPerkiraan();

                //        try
                //        {
                //            IsiTglTerima();
                //            LinkKePiutang();

                //            string rpNet3 = nRpNetto.ToString();
                //            double n = double.Parse(rpNet3) - nRpBayar;
                //            double PLL = 0;
                //            double POT = 0;
                //            if (n > 0 && n <= 1000)
                //            {
                //                POT = n;
                //            }
                //            if (n < 0 && n >= -1000)
                //            {
                //                PLL = Math.Abs(n);
                //            }

                //            try
                //            {
                //                this.Cursor = Cursors.WaitCursor;
                //                using (Database db = new Database())
                //                {
                //                    db.Commands.Add(db.CreateCommand("psp_PJT_LinkToKasir_ISA"));
                //                    db.Commands[0].Parameters.Add(new Parameter("@nilaiBayar", SqlDbType.Money, rpNet3));
                //                    db.Commands[0].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, _RowIDPos));
                //                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, noPerkiraan));
                //                    db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, uraian));
                //                    db.Commands[0].Parameters.Add(new Parameter("@nilaiPOT", SqlDbType.Money, POT));
                //                    db.Commands[0].Parameters.Add(new Parameter("@nilaiPLL", SqlDbType.Money, PLL));
                //                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                //                    db.Commands[0].ExecuteNonQuery();
                //                }
                //                MessageBox.Show("Data telah disimpan");
                //                this.DialogResult = DialogResult.OK;
                //                this.Close();
                //            }
                //            catch (Exception ex)
                //            {
                //                Error.LogError(ex);
                //            }
                //            finally
                //            {
                //                this.Cursor = Cursors.Default;
                //            }
                //            this.Cursor = Cursors.Default;
                //            this.Close();
                //        }
                //        catch (System.Exception ex)
                //        {
                //            Error.LogError(ex);
                //        }
                //    }
                //}
                #endregion 

            }
        }

        private string GetNoPerkiraan()
        {
            string noPerkiraan = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string kodeTrn = "COL" + lookupToko1.WilID.ToString().Trim().Substring(0, 1);

                this.Cursor = Cursors.WaitCursor;
                DataTable dtGL = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeTrn", SqlDbType.VarChar, kodeTrn));
                    dtGL = db.Commands[0].ExecuteDataTable();
                }
                if (dtGL.Rows.Count > 0)
                {
                    noPerkiraan = dtGL.Rows[0]["NoPerkiraan"].ToString();
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
            return noPerkiraan;
        }

        private void IsiTglTerima()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtNota.Rows[0]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["DOID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, dtNota.Rows[0]["TglSerahTerimaChecker"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtNota.Rows[0]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtNota.Rows[0]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtNota.Rows[0]["Cabang3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtNota.Rows[0]["KodeSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtNota.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtNota.Rows[0]["alamatKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, dtNota.Rows[0]["Kota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtNota.Rows[0]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtNota.Rows[0]["Cat1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtNota.Rows[0]["Cat2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, dtNota.Rows[0]["Cat3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, dtNota.Rows[0]["Cat4"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, dtNota.Rows[0]["Cat5"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtNota.Rows[0]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtNota.Rows[0]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, dtNota.Rows[0]["Checker1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, dtNota.Rows[0]["Checker2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TransactionType));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
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

        private DateTime HitungTglJatuhTempo()
        {
            object tglJatuhTempo = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTglJatuhTempo"));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, "TG"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                    tglJatuhTempo = db.Commands[0].ExecuteScalar();
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
            return (DateTime)tglJatuhTempo;
        }

        private void LinkKePiutang()
        {
            if (cab1 != GlobalVar.CabangID)
            {
                return;
            }
            string rpNet2 = dtNota.Rows[0]["RpNet2"].ToString();
            string rpJual2 = dtNota.Rows[0]["RpJual2"].ToString();
            string rpPot2 = dtNota.Rows[0]["RpPot2"].ToString();

            if (double.Parse(rpNet2) == 0 && (double.Parse(rpJual2) - double.Parse(rpPot2)) == 0)
            {
                MessageBox.Show("Nota Barang Bonus, tidak perlu dilink ke API");
                this.Close();
                return;
            }

            string rpNet3 = dtNota.Rows[0]["RpNet3"].ToString();
            if (double.Parse(rpNet3) == 0)
            {
                MessageBox.Show("Nilai Nota masih 0..!, Cek data dan link ulang ke API", "PERINGATAN");
                this.Close();
                return;
            }

            /* proses untuk link ke piutang (panggil psp) */
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_PJ3_LinkToPiutang_ISA"));
                    db.Commands[0].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, HitungTglJatuhTempo()));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeLink", SqlDbType.VarChar, "1")); // TipeLink 1 untuk POS
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
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


        private void CekBarangID(string barangID)
        {
            try
            {
                if (pemanggil == "BENGKEL")
                    _headerID = rowidbengkel;
                else
                    _headerID = _RowIDPos;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            POS.Laporan.FrmPOSLaporan ifrmChild = new POS.Laporan.FrmPOSLaporan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdTutup_Click_1(object sender, EventArgs e)
        {
            PengajuanHarga = false;
            for (a = 0; a < dataGridView1.Rows.Count; ++a)
            {
                if (Convert.ToString(dataGridView1.Rows[a].Cells[12].Value).Trim() == "HARGA")
                {
                    PengajuanHarga = true;
                }
            }
            if (PengajuanHarga)
            {
                if (MessageBox.Show("Masih ada Harga dibawah Standar, minta acc harga ke HO ?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            if (validation())
            {
                if (GlobalVar.Gudang != "2803")
                {
                    #region Save to EntryDoTmp
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_EntryDoTmp_DELETE"));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    int nRec = 0;
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string _BarangID = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        string _NamaStok = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
                        int _Qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                        string _Sat = Convert.ToString(dataGridView1.Rows[a].Cells[3].Value);
                        double _Harga = Convert.ToDouble(dataGridView1.Rows[a].Cells[4].Value);
                        double _Disc1 = Convert.ToDouble(dataGridView1.Rows[a].Cells[5].Value);
                        double _Disc2 = Convert.ToDouble(dataGridView1.Rows[a].Cells[6].Value);
                        double _Disc3 = Convert.ToDouble(dataGridView1.Rows[a].Cells[7].Value);
                        double _Pot = Convert.ToDouble(dataGridView1.Rows[a].Cells[8].Value);
                        double _Jumlah = Convert.ToDouble(dataGridView1.Rows[a].Cells[9].Value);

                        using (Database db = new Database())
                        {
                            //CekBarangID(barangID);
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_EmtryDoTmp_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, _BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, _NamaStok));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, _Qty));
                            db.Commands[0].Parameters.Add(new Parameter("@Satuan", SqlDbType.VarChar, _Sat));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, _Harga));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Money, _Disc1));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Money, _Disc2));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Money, _Disc3));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, _Pot));
                            db.Commands[0].Parameters.Add(new Parameter("@jumlah", SqlDbType.Money, _Jumlah));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        nRec++;
                    }
                    #endregion
                    
                    #region GetItemBarangPromo
                    DataTable dtPrmBrg = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetItemBarangPromo_LIST"));
                        dtPrmBrg = db.Commands[0].ExecuteDataTable();
                    }

                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string _BarangID = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        string _NmBarang = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
                        int qtydo = Convert.ToInt32(Tools.isNull(dataGridView1.Rows[a].Cells[2].Value, "0").ToString());
                        string promoflg = Convert.ToString(Tools.isNull(dataGridView1.Rows[a].Cells[12].Value, ""));
                        int hrgbrg = Convert.ToInt32(Tools.isNull(dataGridView1.Rows[a].Cells[4].Value, "0").ToString());

                        DataTable dtBrgPromo = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_CekBarangPromo"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.VarChar, GlobalVar.DateTimeOfServer));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _BarangID));
                            dtBrgPromo = db.Commands[0].ExecuteDataTable();
                        }
                    }
                    #endregion

                    dataGridView1.Refresh();
                    double sum = 0;
                    int jqt = 0;

                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[a].Cells[9].Value);
                        jqt += Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                    }
                    label12.Text = sum.ToString("N0");
                    lblqty.Text = jqt.ToString("N0");


                    getPromo();

                    StringBuilder msgBuilder = new StringBuilder();
                    int fxbCount = 0;
                    ArrayList delRows = new ArrayList();

                    int cnt = 0;
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string plu = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        string nama = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
                        double harga = Convert.ToDouble(Tools.isNull(dataGridView1.Rows[a].Cells[4].Value, "0").ToString());
                        int qty = Convert.ToInt32(Tools.isNull(dataGridView1.Rows[a].Cells[2].Value,"0").ToString());
                        string cPrm = Convert.ToString(dataGridView1.Rows[a].Cells[10].Value);
                        _barangID = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);

                        DataTable dtBrgPromo = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_CekBarangPromo"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.VarChar, GlobalVar.DateTimeOfServer));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, plu));
                            dtBrgPromo = db.Commands[0].ExecuteDataTable();
                        }

                        
                        if (qty > 0)
                        {
                            if (plu == "")
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, NAMA BARANG atau HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                                return;
                            }
                            if (harga <= 0)
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " Harga Jual = 0");
                                return;
                            }
                        }

                        #region old
                        /*kebijakan harga khusus untuk eceran cash*/
                        //if (GlobalVar.Gudang == "2802" || GlobalVar.Gudang == "2804" || GlobalVar.Gudang == "2811" || GlobalVar.Gudang == "2823")
                        //{
                        //    if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                        //    {
                        //        double nhrg = 0, nHrk = 0;
                        //        _hrgkhs = 0;
                        //        GetHrgJual(); _hargaFinal = _hrgJual;
                        //        GetHrgKhususPos(plu);
                        //        if (_hrgkhs > 0 && cnt == 0)
                        //        {
                        //            _hargaFinal = _hrgkhs;
                        //            if (harga <= _hrgkhs)
                        //            {
                        //                dataGridView1.Rows[a].Cells[4].Value = _hrgkhs;
                        //                dataGridView1.Rows[a].Cells[12].Value = "AUTOACC";
                        //                cnt += 1;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (harga < _hargaFinal)
                        //            {
                        //                dataGridView1.Rows[a].Cells[12].Value = "HARGA";
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    }


                    ValidasiPenjualanTunai = false;

                    #region old
                    //if (sum > 2000000)
                    //{
                    //    ValidasiPenjualanTunai = true;
                    //}

                    /*toko penetrasi*/
                    //try
                    //{
                    //    this.Cursor = Cursors.WaitCursor;
                    //    DataTable dtt = new DataTable();
                    //    using (Database db = new Database())
                    //    {
                    //        db.Commands.Add(db.CreateCommand("usp_TokoKhususPnt_LIST"));
                    //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
                    //        dtt = db.Commands[0].ExecuteDataTable();
                    //        if (dtt.Rows.Count > 0)
                    //        {
                    //            tokoPnt = true;
                    //        }
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Error.LogError(ex);
                    //}
                    //finally
                    //{
                    //    this.Cursor = Cursors.Default;
                    //}

                    //if (tokoPnt)
                    //{
                    //    if (overdueFB > 0 || overdueFX > 0)
                    //    {
                    //        ValidasiPenjualanTunai = true;
                    //    }
                    //}
                    #endregion
                }

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Bayar.FrmBayar ifrmChild;

                    if (this.pemanggil != "BENGKEL")
                        ifrmChild = new Bayar.FrmBayar(this);
                    else
                    {
                        ifrmChild = new Bayar.FrmBayar(this, false);
                    }
                    ifrmChild.ShowDialog();
                }
                String TotalHarga = label12.Text;
            }
        }


        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvQty"].Value) <= 0)
                    {
                        MessageBox.Show("minimum qty tidak boleh kurang dari 1");
                        dataGridView1.CurrentRow.Cells["GvQty"].Value = 1;
                        return;
                    }

                    if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvQty"].Value) > 1)
                    {
                        _hrgkhs = 0;
                        CekHargaBMK(_barangID);
                        GetHargaHpp(_barangID);

                        /*harga khusus voucher*/
                        //if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                        //{
                        //    GetHrgKhususPos(_barangID);
                        //}
                        //if (_hrgkhs > 0)
                        //{
                        //    dataGridView1.CurrentRow.Cells["GvQty"].Value = 1;
                        //}
                    }

                }

                if (e.ColumnIndex == 4)
                {
                    string _barangID = dataGridView1[0, e.RowIndex].Value.ToString();
                    double _hargaJual = 0, _hrgHppNew = 0;
                    string cPromo = "";
                    double _hargaInput = Convert.ToDouble(Tools.isNull(dataGridView1[4, e.RowIndex].Value, "0").ToString());

                    _hrgkhs = 0;
                    //CekHargaBMK(_barangID);
                    //GetHrgJual();
                    GetHrgJualPOS();
                    GetHargaHpp(_barangID);
                    _hargaFinal = _hrgJual;

                    /*harga khusus voucher*/
                    //if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                    //{
                    //    GetHrgKhususPos(_barangID);
                    //}

                    /*harga khusus barang BE*/
                    //if (_barangID.ToString().Substring(0, 2) == "FB" || _barangID.ToString().Substring(0, 2) == "FE")
                    //{
                    //    GetHrgKhususTunai();
                    //    _hrgkhs = _hrgtunai;
                    //}

                    //if (_hrgkhs > 0)
                    //{
                    //    if (_hargaInput <= _hrgkhs)
                    //    {
                    //        dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hrgkhs;
                    //        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";

                    //        //if (_barangID.ToString().Substring(0, 2) == "FB" || _barangID.ToString().Substring(0, 2) == "FE")
                    //        //{
                    //        //    dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaInput;
                    //        //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "HARGA";
                    //        //}
                    //        //else
                    //        //{
                    //        //    dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hrgkhs;
                    //        //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //        //}
                    //    }
                    //    else
                    //    {
                    //        dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaInput;
                    //        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //    }
                    //}
                    //else
                    //{
                    //    //if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                    //    //    _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgK, "0").ToString());
                    //    //else
                    //    //    _hargaFinal = Convert.ToDouble(Tools.isNull(_hrgB, "0").ToString());

                    //    //if (_hargaInput < _hrgHPP)
                    //    //{
                    //    //    dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;
                    //    //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //    //    MessageBox.Show("Harga dibawah Hpp");
                    //    //}
                    //    if (_hargaInput < _hargaFinal)
                    //    {
                    //        dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;
                    //        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //        MessageBox.Show("Harga dibawah Harga Standar");
                    //    }
                    //    else
                    //    {
                    //        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //    }

                    //    //if (_hargaInput < _hrgHPP)
                    //    //{
                    //    //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "HARGA";
                    //    //    MessageBox.Show("Harga dibawah Hpp");
                    //    //}
                    //    //else if (_hargaInput < _hargaFinal)
                    //    //{
                    //    //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "HARGA";
                    //    //    MessageBox.Show("Harga dibawah Harga Standar");
                    //    //}
                    //    //else
                    //    //{
                    //    //    dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    //    //}
                    //}

                    #region coda lama
                    //GetHargaPriceList(DateTime.Parse(TxtTGL.DateValue.ToString()), _barangID);
                    ////if (_hrgHPP > 1)
                    ////{
                    ////    _hrgHppNew = 0;
                    ////    decimal persen = 0.01m;
                    ////    _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
                    ////}
                    //if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                    //    _hargaFinal = _hrgK;
                    //else
                    //    _hargaFinal = _hrgB;
                    //if (_barangID.Substring(0,3) == "FB4" || _barangID.Substring(0,3)=="FE4")
                    //{
                    //    GetFlagHR4("HKR4");
                    //    //GetHrgJualHKR4();
                    //    if (nDiscK4 > 0 && _Hnet > 0)
                    //    {
                    //        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                    //        _hrgB = _hrgJual - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_hrgJual)), 0));
                    //        _hrgK = _hrgB;
                    //        _hargaFinal = _hrgB;
                    //    }
                    //    else
                    //    {
                    //        //tambahan kondisi untuk harga jual kredit, HET - 20% untuk wilayah Jawa Tengah
                    //        GetWilayah();
                    //        GetDiscWilayah();
                    //        //GetHET();
                    //        if (discwil > 0 && _Hnet > 0)
                    //        {
                    //            decimal x = Convert.ToDecimal(discwil) + 5, y = 100;
                    //            _hrgB = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                    //            _hrgK = _hrgB;
                    //            _hargaFinal = _hrgB;
                    //        }
                    //        else
                    //        {
                    //            CekHargaKhusus(_barangID);
                    //            if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                    //            {
                    //                if (_hrgK > 0)
                    //                    _hargaFinal = _hrgK;
                    //            }
                    //            else
                    //            {
                    //                if (_hrgB > 0)
                    //                    _hargaFinal = _hrgB;
                    //            }
                    //        }
                    //    }
                    //}
                    //else if (dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FA" ||
                    //        dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FC" ||
                    //        dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FX")
                    //{
                    //    #region harga khusus flag KG
                    //    //Harga Khusus dengan FlagKG_____________________
                    //    //CekHargaKhusus(_barangID);
                    //    //if (lookupToko1.NamaToko.Trim() == "ECERAN CASH")
                    //    //{
                    //    //    if (_hrgK > 0)
                    //    //        _hargaFinal = _hrgK;
                    //    //}
                    //    //else
                    //    //{
                    //    //    if (_hrgB > 0)
                    //    //        _hargaFinal = _hrgB;
                    //    //}
                    //    #endregion
                    //    //Get Harga Promo Point_________________________
                    //    GetHargaPromoPoint();
                    //    if (dtHrgPoint.Rows.Count > 0 && _hrgJual > 0)
                    //    {
                    //        double hjual = 0;
                    //        hjual = Convert.ToDouble(Tools.isNull(dataGridView1.CurrentRow.Cells["GvHarga"].Value,"0").ToString());
                    //        if (hjual > _hrgJual)
                    //        {
                    //            MessageBox.Show("Transaksi ini mendapatkan Harga Khusus Promo Point : Rp "+_hrgJual.ToString());
                    //            cPromo = "1";
                    //        }
                    //    }
                    //    #region ijo2
                    //    //bool isBmkValidated = LookupInfoValue.CekBmkPos();
                    //    //if (isBmkValidated)
                    //    //{
                    //    //    double _hrgHppNew = 0;
                    //    //    decimal persen = 0.01m;
                    //    //    _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
                    //    //    if (_hrgHppNew > 1)
                    //    //    {
                    //    //        if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hrgHppNew)
                    //    //        {
                    //    //            MessageBox.Show("Harga dibawah Hpp", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //            if (_hargaJual > _hrgHppNew)
                    //    //                _hargaFinal = _hargaJual;
                    //    //            else
                    //    //                _hargaFinal = _hrgHppNew;
                    //    //        }
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        if (_hargaJual > 0)
                    //    //            _hargaFinal = _hargaJual;
                    //    //    }
                    //    //    if (_hargaJual > 0)
                    //    //    {
                    //    //        if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hargaJual)
                    //    //        {
                    //    //            _hargaFinal = _hargaJual;
                    //    //            MessageBox.Show("Harga dibawah standar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //        }
                    //    //        else
                    //    //        {
                    //    //            _hargaFinal = Convert.ToDouble(dataGridView1[4, e.RowIndex].Value);
                    //    //        }
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        _hargaJual = _hrgHppNew;
                    //    //        _hargaFinal = _hrgHppNew;
                    //    //    }
                    //    //    //Get Harga Promo Point
                    //    //    GetHargaPromoPoint();
                    //    //    if (dtHrgPoint.Rows.Count > 0 && _hrgJual > 0)
                    //    //    {
                    //    //        MessageBox.Show("Transaksi ini mendapatkan Harga Khusus");
                    //    //        if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hrgJual)
                    //    //        {
                    //    //            _hargaFinal = _hrgJual;
                    //    //            _hargaJual = _hrgJual;
                    //    //        }
                    //    //        else
                    //    //        {
                    //    //            _hargaFinal = Convert.ToDouble(dataGridView1[4, e.RowIndex].Value);
                    //    //            _hargaJual = _hrgJual;
                    //    //        }
                    //    //    }
                    //    //}
                    //    //if (_hrgHPP <= 1 && _hargaFinal == 0)
                    //    //{
                    //    //    MessageBox.Show("Harga BMK 0 dan Hpp 0, Hubungi PSHO", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //    return;
                    //    //}
                    //    #endregion
                    //}
                    //if (_hargaInput >= _hargaFinal)
                    //{
                    //    _hargaFinal = _hargaInput;
                    //    dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;
                    //}
                    //if (cPromo != "1")
                    //{
                    //    if (_hargaInput < _hrgHPP)
                    //    {
                    //        dataGridView1.CurrentRow.Cells["NoACC"].Value = "HARGA";
                    //        MessageBox.Show("Harga Jual dibawah Hpp", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //    else if (_hargaInput < _hargaFinal)
                    //    {
                    //        dataGridView1.CurrentRow.Cells["NoACC"].Value = "HARGA";
                    //        MessageBox.Show("Harga Jual dibawah Standar", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //    else
                    //    {
                    //        dataGridView1.CurrentRow.Cells["NoACC"].Value = "AUTOACC";
                    //    }
                    //}
                    //dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;
                    #endregion

                    if (_hargaInput < _hargaFinal)
                    {
                        dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;
                        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                        MessageBox.Show("Harga dibawah Harga Standar");
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells["NoAcc"].Value = "AUTOACC";
                    }

                }


                if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD1"].Value) < 0 || Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD1"].Value) > 100)
                {
                    MessageBox.Show("Discount antara 0 - 100", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    kuantiti = Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvQty"].Value);
                    harga = Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvHarga"].Value);
                    jumlah = kuantiti * harga;

                    double nd1, nd2, nd3, ndisc;

                    nd1 = jumlah * d1;
                    double jumnet1 = jumlah - nd1;
                    jumnet = jumnet1;
                    ndisc = nd1;
                    if (d2 > 0)
                    {
                        nd2 = jumnet1 * d2;
                        double jumnet2 = jumnet1 - nd2;
                        jumnet = jumnet2;
                        ndisc = nd2 + nd1;

                        if (d3 > 0)
                        {
                            nd3 = jumnet2 * d3;
                            double jumnet3 = jumnet2 - nd3;
                            jumnet = jumnet3;
                            ndisc = nd1 + nd2 + nd3;
                        }
                    }
                    else
                    {
                        nd3 = jumnet1 * d3;
                        double jumnet3 = jumnet1 - nd3;
                        jumnet = jumnet3;
                        ndisc = nd1 + nd3;
                    }

                    jumnetakhir = jumnet - (potrp * kuantiti);

                    dataGridView1.CurrentRow.Cells["GvTotDisc"].Value = ndisc;
                    dataGridView1.CurrentRow.Cells["GvJumlah"].Value = jumnetakhir;

                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                        kuantiti2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error...", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            miliDetik = miliDetik + 1;
            if (miliDetik >= 10)
            {
                miliDetik = 0;
                menit = menit + 1;
                varmilidetik = miliDetik;
                varmenit = menit;
            }
            if (menit < 10)
            {
                varmenit = menit; 
            }
            else
            {
                varmenit = menit;
            }
            varmilidetik = miliDetik;

            if (menit >=60 )
            {
                varmenit = menit / 60;
            }

        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
              
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["GvJumlah"].Style.ForeColor = Color.Blue;              

        }

        private void TxtCatatan_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                TxtCat2.Focus();
            }
        }

        private void FrmPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                button2_Click_1(sender, e);
            }
            if (e.KeyCode == Keys.F11)
            {
                cmdTutup_Click_1(sender, e);
            }
            if (e.KeyCode == Keys.F10)
            {
                lookupSales1.Select();
                lookupSales1.Focus();
                
            }
            if (e.KeyCode == Keys.F9)
            {
                //lookupBarcode1.Select();
                //lookupBarcode1.Focus();
            }
            if (e.KeyCode == Keys.F8)
            {
                lookupToko1.Select();
                lookupToko1.Focus();
            }
            if (e.KeyCode == Keys.F7)
            {
                TampilFormBarang();
            }
            if (e.KeyCode == Keys.Insert)
            {
                bool _KdSalesKhusus = CekSalesKhusus(lookupSales1.SalesID);
                if (_KdSalesKhusus)
                {
                    if (comboBox1.Text.ToString().Trim() != "TB")
                    {
                        MessageBox.Show("Sales ini hanya bisa untuk bertransaksi Busi.");
                        return;
                    }
                }

                int nRec = dataGridView1.Rows.Count;
                string cVoucher = Tools.isNull(TxtCat3.Text,"").ToString().Trim().ToUpper();

                noVch = Tools.isNull(TxtCat3.Text, "").ToString().Trim().ToUpper();
                DataTable dtVch = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetVoucher"));
                    db.Commands[0].Parameters.Add(new Parameter("@voucher", SqlDbType.VarChar, noVch));
                    dtVch = db.Commands[0].ExecuteDataTable();
                }

                if ((cVoucher == "VOUCHER" || dtVch.Rows.Count > 0) && nRec > 0)
                    MessageBox.Show("Barang Promo sudah diinput"); 
                else
                    TampilFormBarang();
            }
            if (e.KeyCode == Keys.Delete)
            {
                deleterows();
            }
        }

        private Boolean CekSalesKhusus(string KdSales)
        {
            bool x = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dts = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KodeSalesKhusus_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KdSales));
                    dts = db.Commands[0].ExecuteDataTable();
                    if (dts.Rows.Count > 0)
                    {
                        x = true;
                    }
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
            return x;
        }


        private void BtnBarcode_Click(object sender, EventArgs e)
        {
            TampilBarcode();
        }

        private void TampilFormBarang()
        {
            if (comboBox1.Text.ToString().Trim() == "TG")
            {
                POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this);
                ifrmChild.Show();
            }
            else
            {
                POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this, comboBox1.Text.ToString().Trim());
                ifrmChild.Show();
            }
        }

        private void TampilBarcode()
        {
            POS.FrmBarcode1 ifrmChild = new POS.FrmBarcode1(this);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void deleterows()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string kodeBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["GvNamaBrg"].Value.ToString();
                if (MessageBox.Show("Hapus Data : " + kodeBarang + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        //dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        dataGridView1.Rows.RemoveAt(nRowGridView);
                        
                        MessageBox.Show("Data telah dihapus");

                        #region  hitung total2

                        int sum = 0;
                        kuantiti2 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                            kuantiti2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                        }

                        label12.Text = sum.ToString("N0");
                        lblqty.Text = kuantiti2.ToString("N0");
                        TxtBarcode.Text = "";
                        // dataGridView1.Rows[nRowIndex].Cells[2].Selected = true;                   

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Select satu baris yang akan di delete!");
                       // MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this);
                AmbilBarang2();
                //MessageBox.Show("Stok Barang 0");
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            lookupSales1.Focus();
            if (comboBox1.Text == "TG" || comboBox1.Text == "TB")
            {
                plafonToko = double.Parse(Tools.isNull(TokoPlafon.Plafon(lookupToko1.KodeToko, comboBox1.Text),"0").ToString());
                piutangToko = double.Parse(Tools.isNull(TokoPlafon.Piutang(lookupToko1.KodeToko, comboBox1.Text),"0").ToString());
                gitToko = double.Parse(Tools.isNull(TokoPlafon.GIT(lookupToko1.KodeToko, comboBox1.Text),"0").ToString());
                giroToko = TokoPlafon.Giro(lookupToko1.KodeToko, comboBox1.Text);
                giroTolakToko = TokoPlafon.GiroTolak(lookupToko1.KodeToko, comboBox1.Text);
                sisaPlafonToko = TokoPlafon.SisaPlafon(plafonToko, piutangToko, gitToko, giroToko, giroTolakToko);
                overdue = TokoOverdue.Overdue(lookupToko1.KodeToko);
                overdueFB = TokoOverdue.OverdueFB(lookupToko1.KodeToko);
                overdueFX = TokoOverdue.OverdueFX(lookupToko1.KodeToko);
            }
        }

        private void lookupStock2_SelectData(object sender, EventArgs e)
        {
            AmbilBarang2();
        }


        private void IncreamentNPrint()
        {
            int Nprint_ = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cekNprintNota")); //udah cek heri
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            Nprint_ = Convert.ToInt32(dt.Rows[0]["Nprint"]);
            Nprint_++;
            dt.Rows[0]["Nprint"] = Nprint_.ToString();
            //this.dataGridNotaJual.RefreshEdit();
        }
        public void cekcetak()
        {
            int nprint = 0;
            Penjualan.frmCetakNota ifrmDialog = new Penjualan.frmCetakNota(this, nprint);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
                _nCetak = ifrmDialog.Result;
            else
                return;

            /*sudah tidak berlaku*/
            //string _TokoPnt = "";
            //DataTable dtp = new DataTable();
            //try
            //{
            //    string kdToko = lookupToko1.KodeToko.ToString();
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_TokoKhususPnt_LIST"));
            //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdToko));
            //        dtp = db.Commands[0].ExecuteDataTable();
            //        if (dtp.Rows.Count > 0)
            //        {
            //            _TokoPnt = "1";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}

            //if (_TokoPnt != "1")
                CetakNotaTax();
            //else
            //    MessageBox.Show("Untuk Toko ini cetak nota di Tabel Nota Jual");



        }
        public void CetakNotaTax()
        {
            if (_nCetak == 2 || _nCetak == 4)
            {
                _ketNota = "RE";
            }
            else if (_nCetak == 5 || _nCetak == 6)
            {
                _ketNota = string.Empty;
            }
            else if (_nCetak == 1 || _nCetak == 3)
            {
                _ketNota = "CP";
            }

            string transType = comboBox1.Text.ToString();
            if (transType == "TB")
            {
                _KdSalesKhusus = CekSalesKhusus(lookupSales1.SalesID);
            }

            if (GlobalVar.Gudang != "2803")
            {
                try
                {
                    if (pemanggil == "BENGKEL")
                        _notaHeaderRowID = rowidbengkel;
                    else
                        _notaHeaderRowID = _RowIDPos;


                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualanTax")); //udah cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //if (GlobalVar.Gudang != "2808")
                    //{
                        if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                        {
                            //printerName = "INKJET", printer = Convert.ToString(asd.CekAppSetting(printerName));
                            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                        }
                        else
                        {
                            //printerName = "DOTMATRIX", printer = Convert.ToString(asd.CekAppSetting(printerName));;
                            CetakNotaTaxRaw(dt);
                        }
                    //}
                    //else
                    //{
                    //    CetakNotaTaxRaw(dt);
                    //}
                    IncreamentNPrint();

                    #region sudah tidak berlaku
                    /*sudah tidak berlaku*/
                    /*Toko sparepart pnt*/
                    //string kdToko = Tools.isNull(dt.Rows[0]["KodeToko"],"").ToString();
                    //DataTable dtp = new DataTable();
                    //using (Database db = new Database())
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_TokoKhususPnt_LIST"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdToko));
                    //    dtp = db.Commands[0].ExecuteDataTable();
                    //}
                    ///*------------------*/
                    //if (GlobalVar.Gudang != "2808")
                    //{
                    //    if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                    //    {
                    //        if (dtp.Rows.Count == 0)
                    //        {
                    //            //printerName = "INKJET";
                    //            //Penjualan.frmNotaJualBrowser asd = new ISA.Trading.Penjualan.frmNotaJualBrowser();
                    //            //printer = Convert.ToString(asd.CekAppSetting(printerName));
                    //            if (_KdSalesKhusus)
                    //            {
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                    //            }
                    //            else
                    //            {
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            /*Toko PNT*/
                    //            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiTPKhusus");
                    //            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiTPKhususCopy1");
                    //            DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiTPKhususCopy2");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //printerName = "DOTMATRIX";
                    //        //Penjualan.frmNotaJualBrowser asd = new ISA.Trading.Penjualan.frmNotaJualBrowser();
                    //        //printer = Convert.ToString(asd.CekAppSetting(printerName));
                    //        CetakNotaTaxRaw(dt);
                    //    }
                    //}
                    //else
                    //{
                    //    CetakNotaTaxRaw(dt);
                    //    //CetakNotaRaw2808(dt);
                    //}
                    //IncreamentNPrint();
                    #endregion
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
        }

        #region tutup
        //private void CetakNotaRaw2808(DataTable dt)
        //{

        //    BuildString detail = new BuildString();
        //    detail.Append(CetakHeaderNota2808(dt));

        //    #region Cetak Detail
        //    int nUrut = 0;
        //    string sNmBrg, sSatuan, sTemp, subNamaBarang;
        //    double nQty, nHrgSat, nHrgBruto;
        //    double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0,
        //           nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPot = 0, nJmlNetto = 0, HrgNet = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        nUrut++;
        //        sNmBrg = dr["NamaBarang"].ToString();
        //        int panjanghuruf = sNmBrg.Length;
        //        if (panjanghuruf >= 57)
        //        {
        //            subNamaBarang = sNmBrg.Substring(0, 57);
        //        }
        //        else
        //        {
        //            subNamaBarang = sNmBrg;
        //        }

        //        sSatuan = dr["Satuan"].ToString();
        //        nQty = int.Parse(dr["QtySuratJalan"].ToString());
        //        nHrgSat = double.Parse(dr["HrgJual"].ToString());
        //        nHrgBruto = nQty * nHrgSat;
        //        //nSumDisc += double.Parse(dr["Disc"].ToString());
        //        nDisc1 = double.Parse(Tools.isNull(dr["Disc1"], "0").ToString());
        //        nDisc2 = double.Parse(Tools.isNull(dr["Disc2"], "0").ToString());
        //        nPot = double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
        //        nSumPot += double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
        //        nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()));

        //        HrgNet = Convert.ToDouble(Tools.isNull(HitNet3D(nHrgSat, nDisc1, nDisc2, nDisc3), "0").ToString()) - nPot;
        //        nJmlNetto = nQty * HrgNet;
        //        nSumHrgBruto = nSumHrgBruto + nJmlNetto;

        //        sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
        //        sTemp = sTemp + subNamaBarang.PadRight(57, '.') + " ";
        //        sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
        //        sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(10, ' ') + " ";
        //        sTemp = sTemp + nDisc1.ToString("#,###0.#0") + " ";
        //        sTemp = sTemp + nDisc2.ToString("#,###0.#0") + " ";
        //        sTemp = sTemp + "Rp." + nPot.ToString("#,###").PadLeft(7, ' ') + " ";
        //        sTemp = sTemp + "Rp." + HrgNet.ToString("#,###").PadLeft(10) + " ";
        //        sTemp = sTemp + "Rp." + nJmlNetto.ToString("#,###").PadLeft(10) + " ";
        //        detail.PROW(true, 1, sTemp);
        //    }
        //    detail.FontCondensed(true);
        //    detail.AddCR();
        //    if (nUrut % 20 > 0)
        //    {
        //        detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //        for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
        //        {
        //            detail.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
        //        }
        //    }
        //    string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
        //    string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
        //    detail.PROW(true, 1, detail.PrintDoubleLine(134));
        //    detail.AddCR();
        //    detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    detail.PROW(true, 1, "Pembayaran : " + sBayar);
        //    detail.PROW(false, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));

        //    if (Convert.ToBoolean(Class.AppSetting.GetValue("BIAYA_KIRIM")))
        //    {
        //        detail.PROW(true, 1, "Catatan    : Biaya Kirim Gratis " + sLain);
        //    }
        //    else
        //    {
        //        detail.PROW(true, 1, "Catatan    : " + sLain);
        //    }
        //    detail.PROW(true, 1, "Packing : " + sBayar);
        //    detail.PROW(false, 39, "Penerima");
        //    detail.PROW(false, 60, "Admin");
        //    detail.PROW(false, 81, "Pengirim");
        //    detail.PROW(true, 1, "");
        //    detail.PROW(true, 1, "");
        //    detail.PROW(false, 39, detail.PrintHorizontalLine(13));
        //    detail.PROW(false, 60, detail.PrintHorizontalLine(13));
        //    detail.PROW(false, 81, detail.PrintHorizontalLine(13));

        //    detail.PROW(false, 120, detail.PrintHorizontalLine(15));
        //    detail.PROW(true, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));
        //    detail.PROW(true, 1, "- Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
        //    detail.PROW(true, 1, "- Agar tidak terjadi kesalahan dalam pencatatan pembayaran, mohon setelah melakukan pembayaran / Retur berkenan melakukan");
        //    detail.PROW(true, 1, "  konfirmasi via sms / telepon ke Hp. 08170631848 / 087836167652 ");
        //    //detail.PROW(true, 1, "");//mus tambah
        //    detail.Eject();
        //    //--website:www.sas-autoparts.com '+IIF(nOli=2,Thisform.Rp2Kode(nReal),'')
        //    #endregion // end region cetak detail
        //    //string nama = "";


        //    detail.SendToPrinter("notaJual.txt");
        //    //detail.SendToFile("notaJual.txt");
        //    //detail.SendToPrinter("notaJual.txt", printer);// tambah inputan printer buat mengambil default printer sesuai yang dipilih pada radio button
        //}

        //private string CetakHeaderNota2808(DataTable dt)
        //{
        //    BuildString header = new BuildString();

        //    //string typePrinter = header.GetPrinterDotmatrix(printer);
        //    string typePrinter = header.GetPrinterName();
        //    string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
        //    string sToko = sNamaToko + header.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
        //    string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
        //    string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
        //    string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
        //        + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
        //    string sExpedisi = string.Empty; ;
        //    string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


        //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
        //    {
        //        sExpedisi = string.Empty;
        //    }

        //    #region Header
        //    header.Initialize();
        //    header.PageLLine(33);
        //    header.LeftMargin(1);
        //    if (typePrinter.Contains("LX"))
        //    {
        //        header.BottomMargin(0);
        //        header.LetterQuality(false);
        //        header.FontBold(true);
        //        header.FontCondensed(true);
        //        header.DoubleHeight(true);
        //        header.PROW(true, 1, header.SPACE(25) + "NOTA  : "
        //            + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
        //            + _ketNota);
        //    }
        //    else
        //    {
        //        header.BottomMargin(1);
        //        header.LetterQuality(true);
        //        header.FontBold(true);
        //        header.DoubleHeight(true);
        //        header.DoubleWidth(true);
        //        header.PROW(true, 1, header.SPACE(21) + "NOTA  : "
        //            + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
        //            + _ketNota);
        //    }
        //    //header.FontBold(false);
        //    header.DoubleWidth(false);
        //    header.DoubleHeight(false);
        //    header.FontCPI(12);
        //    header.LineSpacing("1/8");
        //    header.FontCondensed(false);
        //    header.PROW(true, 1, "NOMOR DO   : " + dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString());
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintTopLeftCorner() + header.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + header.PrintHorizontalLine(14) + header.PrintTopRightCorner());
        //    header.FontItalic(false);
        //    header.PROW(true, 1, "SUB        :  ");
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
        //    header.FontItalic(false);
        //    header.AddCR();
        //    header.PROW(false, 55, sToko);
        //    header.PROW(true, 1, "TANGGAL    : " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
        //    header.FontItalic(false);
        //    header.FontCondensed(true);
        //    header.AddCR();
        //    header.PROW(false, 92, sAlamat.PadRight(60));
        //    header.FontCondensed(false);
        //    header.PROW(true, 1, "TEMPO      : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ")");
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
        //    header.FontItalic(false);
        //    header.AddCR();
        //    header.PROW(false, 55, sDaerah.PadRight(25));
        //    header.PROW(true, 1, "SALESMAN   : " + GetSales().PadRight(27));
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
        //    header.FontItalic(false);
        //    header.AddCR();
        //    header.PROW(false, 55, sKota);
        //    header.PROW(true, 1, "EXPEDISI   : " + sExpedisi);
        //    header.FontItalic(true);
        //    header.PROW(false, 53, header.PrintBottomLeftCorner() + header.PrintHorizontalLine(40) + header.PrintBottomRightCorner());
        //    header.FontItalic(false);
        //    header.PROW(true, 1, "");
        //    header.FontCondensed(false);
        //    header.AddCR();
        //    header.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    //header.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
        //    header.PROW(true, 1, "No.  N a m a   B a r a n g                                     Q t y    HET         Disc1 Disc2  Pot       Harga Net      Jumlah");
        //    header.PROW(true, 1, header.PrintDoubleLine(134));
        //    #endregion // end region header

        //    return header.GenerateString();
        //}
        #endregion


        private string GetSales(DataTable dt)
        {
            string konfersi = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int c1 = int.Parse(dt.Rows[0]["Cabang1"].ToString()) % 26;
            int c2 = int.Parse(dt.Rows[0]["Cabang2"].ToString()) % 26;
            string namaSales = dt.Rows[0]["NamaSales"].ToString();
            if (c1 == 0)
                c1 = 26;
            if (c2 == 0)
                c2 = 26;
            string result = konfersi.Substring(c1 - 1, 1) + "\\" + konfersi.Substring(c2 - 1, 1)
                            + "\\" + namaSales;

            return result;
        }


        public void DisplayReportNotaJual(DataTable dt, String ReportName)
        {
            //string sExpedisi = dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();

            // Double Total = Convert.ToDouble(dt.Compute("Sum((CONVERT(HrgJual,'System.Double')) * (CONVERT(QtySuratJalan,'System.Double')))", ""));

            double Total = 0;
            double TotalDisc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                //=FormatNumber(Sum(
                //    (Fields!Disc.Value*Fields!QtySuratJalan.Value)
                //    +(Fields!Pot.Value*Fields!QtySuratJalan.Value)), 0)



                int QtySJ = Convert.ToInt32(dr["QtySuratJalan"]);
                Double HrgJual = Convert.ToDouble(dr["HrgJual"]);

                Double Disc = Convert.ToInt32(dr["Disc"]);
                Double Pot = Convert.ToInt32(dr["Pot"]);

                TotalDisc = TotalDisc + ((Disc * QtySJ) + (Pot * QtySJ));

                Total = Total + (QtySJ * HrgJual);
            }

            Double TotalAkumulasi = Total - TotalDisc;

            //if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            //{
               string sExpedisi = string.Empty;
            //}
            DateTime tglSJ = Convert.ToDateTime(dt.Rows[0]["TglSuratJalan"].ToString());
            String tglSJFix = tglSJ.ToString("dd-MMM-yyyy");
            String tglSJBarcode = tglSJ.ToString("dd-MM-yyyy");
            String Barcode = (dt.Rows[0]["NoSuratJalan"].ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));
            String Catatan = "";
            string KodeGudang = GlobalVar.Gudang;
            string TunaiKredit = "TG";

            if (Tools.isNull(comboBox1.SelectedItem.ToString(), "").ToString().Substring(0, 1) != "")
            {
                TunaiKredit = Tools.isNull(comboBox1.SelectedItem.ToString(), "").ToString().Substring(0, 1);
            }

            //String tgl = GlobalVar.DateOfServer.ToString("dd-MMM-yyyy");            
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("NomorDO", dt.Rows[0]["NoDO"].ToString()));
            rptParams.Add(new ReportParameter("NoSuratJalan", dt.Rows[0]["NoSuratJalan"].ToString()));
            rptParams.Add(new ReportParameter("TglSuratJalan", tglSJFix));
            rptParams.Add(new ReportParameter("HariKredit", dt.Rows[0]["HariKredit"].ToString()));
            rptParams.Add(new ReportParameter("Sales", GetSales(dt)));
            rptParams.Add(new ReportParameter("Expedisi", sExpedisi));
            rptParams.Add(new ReportParameter("NamaToko", dt.Rows[0]["NamaToko"].ToString().Trim()));
            rptParams.Add(new ReportParameter("Alamat", dt.Rows[0]["Alamat"].ToString().Trim()));
            rptParams.Add(new ReportParameter("Kota", dt.Rows[0]["Kota"].ToString()));
            rptParams.Add(new ReportParameter("Daerah", dt.Rows[0]["Daerah"].ToString()));
            rptParams.Add(new ReportParameter("WilID", dt.Rows[0]["WilID"].ToString()));
            rptParams.Add(new ReportParameter("KetNota", _ketNota));
            rptParams.Add(new ReportParameter("Total", Total.ToString()));
            rptParams.Add(new ReportParameter("TotalDisc", TotalDisc.ToString()));
            rptParams.Add(new ReportParameter("TotalAkumulasi", TotalAkumulasi.ToString()));
            rptParams.Add(new ReportParameter("Catatan3", dt.Rows[0]["Catatan3"].ToString()));
            rptParams.Add(new ReportParameter("Catatan4", dt.Rows[0]["Catatan4"].ToString()));
            rptParams.Add(new ReportParameter("BarcodeBar", "*" + Barcode + "*"));
            rptParams.Add(new ReportParameter("Barcode", Barcode));
            rptParams.Add(new ReportParameter("Catatan", ""));
            rptParams.Add(new ReportParameter("TK", TunaiKredit));
            rptParams.Add(new ReportParameter("KodeGudang", KodeGudang));

            //call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaJual.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            frmReportViewer ifrmReport = new frmReportViewer("POS." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Print();

            //ifrmReport.Show();
        }


        private bool CekNotaPos()
        {
            bool cek = false;
            DataTable dtHeader;
            Guid RowIDNota_ = _RowIDNota; // (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowIDNota"].Value;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_service_NOTA"));
                db.Commands[0].Parameters.Add(new Parameter("@RowIDNota", SqlDbType.UniqueIdentifier, RowIDNota_));
                dtHeader = db.Commands[0].ExecuteDataTable();
            }
            if (dtHeader.Rows.Count > 0)
            {
                cek = true;
            }
            return cek;
        }

       
        private void CetakNotaTaxRaw(DataTable dt)
        {
            BuildString data = new BuildString();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamaToko = dt.Rows[0]["NamaToko"].ToString().Trim();
            string sToko = sNamaToko + data.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dt.Rows[0]["Alamat"].ToString().Trim();
            string sDaerah = dt.Rows[0]["Daerah"].ToString().Trim();
            string sKota = dt.Rows[0]["Kota"].ToString().Trim().PadRight(20)
                + " (" + dt.Rows[0]["WilID"].ToString().Trim() + ")";
            string sPramuniaga = dt.Rows[0]["KodeSales"].ToString().Trim();

            DateTime tglSJ = DateTime.Parse(dt.Rows[0]["TglSuratJalan"].ToString());
            string barcodeNota = dt.Rows[0]["NoSuratJalan"].ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM");

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }
            data.PROW(true, 1, dt.Rows[0]["NamaPrs"].ToString().Trim());
            data.PROW(false, 47, "NOTA : " + dt.Rows[0]["NoSuratJalan"].ToString() + "   " + _ketNota);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dt.Rows[0]["AlamatPrs"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);

            data.PROW(true, 1, "                                       ");
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.PROW(true, 1, "NPWP/PKP    : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            //data.FontItalic(true);
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();

            data.DoubleHeight(true);
            data.PROW(false, 58, sToko);
            data.DoubleHeight(false);

            if (dt.Rows[0]["TglPKP"].ToString() == "")
            {
                data.PROW(true, 1, "TANGGAL PKP :  ");
            }
            else
            {
            data.PROW(true, 1, "TANGGAL PKP : " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
            }
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.FontCondensed(true);
            data.AddCR();
            data.PROW(false, 92, sAlamat.PadRight(60));
            data.FontCondensed(false);
            data.PROW(true, 1, "");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sDaerah.PadRight(25));
            data.PROW(true, 1, "TANGGAL NOTA: " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sKota);
            data.PROW(true, 1, "Pramuniaga  : " + sPramuniaga+ " ");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(true, 1, "Penjualan   : " + "Tunai");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.FontItalic(false);

            data.PROW(true, 1, "Barcode No : " + barcodeNota);
            data.PROW(true, 1, "");
            data.FontCondensed(true);

            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 65)
                {
                    subNamaBarang = sNmBrg.Substring(0, 65);
                }
                else
                {
                    subNamaBarang = sNmBrg;
                }
                //string subNamaBarang = sNmBrg.Substring(Math.Max(0, sNmBrg.Length - 30));
                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                nSumDisc = double.Parse(dr["Disc"].ToString());
                nSumPot = double.Parse(dr["Pot"].ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()) - double.Parse(dr["Pot"].ToString()));

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                sTemp = sTemp + subNamaBarang.PadRight(65, '.') + "  ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3,' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9,' ');
                sTemp = sTemp + nSumDisc.ToString("#,###").PadLeft(8,' ');
                sTemp = sTemp + "Rp." + nSumPot.ToString("#,###").PadLeft(8,' ');
                sTemp = sTemp + "       Rp." + nHrgBruto.ToString("#,###").PadLeft(10) + " ";
                data.PROW(true, 1, sTemp);
                //data.PROW(true, 1, "");
            }
            data.FontCondensed(true);
            data.AddCR();
            if (nUrut % 20 > 0)
            {
                data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            //string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            //string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21)
                + "                                                  Jumlah     Rp. "
                + nSumHrgBruto.ToString("#,###").PadLeft(13));            
            data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
            data.Eject();
            #endregion // end region detail

            data.SendToPrinter("notaJualTax.txt");
            //data.SendToPrinter("notaJualTax.txt",printer);  //buat pilih printer
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void lookupSales1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void lookupToko1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtNamaToko_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TxtNamaToko_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CBShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void lookupToko1_Leave(object sender, EventArgs e)
        {

                if (lookupToko1.KodeToko != "")
                {
                    comboBox1.Focus();
                    //lookupSales1.Focus();
                }
                else
                {
                    lookupToko1.Focus();
                }
            
        }

        private void lookupSales1_Leave(object sender, EventArgs e)
        {
            if (lookupSales1.NamaSales != "")
            {
                dataGridView1.Focus();
            }
            else
            {
                lookupSales1.Focus();
            }
        }

        private void TxtBarcode_Leave(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string kodebarang = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["gVplu"].Value, string.Empty).ToString();
                if (kodebarang != string.Empty)
                {
                    CekHargaBMK(kodebarang);
                    //ViewHargaKhusus(kodebarang);
                    //CekHargaKhusus(kodebarang);
                    GetHargaHpp(kodebarang);
                }
                nRowGridView = dataGridView1.CurrentRow.Index;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

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
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
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
                    _hrgJual = _Het;
                    HrgJualBMK_ = _hrgJual;
                    _hargaFinal = _hrgJual;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void TxtCat3_Validated(object sender, EventArgs e)
        {
            if ((GlobalVar.Gudang == "2802" || GlobalVar.Gudang == "2804" || GlobalVar.Gudang == "2805" ||
                GlobalVar.Gudang == "2809" || GlobalVar.Gudang == "2811" || GlobalVar.Gudang == "2819" ||
                GlobalVar.Gudang == "2823") && lookupToko1.NamaToko.ToString().Trim() == "ECERAN CASH" )
            {
                Boolean Ok = false;
                noVch = Tools.isNull(TxtCat3.Text, "").ToString().Trim().ToUpper();
                DataTable dtVch = new DataTable();

                if (noVch != "" && noVch != "VOUCHER")
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetVoucher"));
                        db.Commands[0].Parameters.Add(new Parameter("@voucher", SqlDbType.VarChar, noVch));
                        dtVch = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtVch.Rows.Count == 0)
                    {
                        MessageBox.Show("No Voucher ini tidak ada");
                        Ok = false;
                        TxtCat3.Text = "";
                    }
                }

                if (noVch == "VOUCHER" || dtVch.Rows.Count > 0)
                    Ok = true;

                if (Ok && dataGridView1.Rows.Count > 1)
                {
                    TxtCat3.Text = "";
                    MessageBox.Show("Voucher hanya bisa digunakan untuk 1 item barang saja");
                    return;
                }

                for (a = 0; a < dataGridView1.Rows.Count; ++a)
                {
                    _hrgkhs = 0;
                    _barangID = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                    int qty = Convert.ToInt32(Tools.isNull(dataGridView1.Rows[a].Cells[2].Value, "0").ToString());
                    int hrg = Convert.ToInt32(Tools.isNull(dataGridView1.Rows[a].Cells[4].Value, "0").ToString());

                    GetHrgJual();
                    GetHrgKhususPos(_barangID);
                    if (Ok)
                    {
                        //if (_hrgkhs > 0 && (hrg <= _hrgkhs))
                        //{
                        dataGridView1.Rows[a].Cells[2].Value = 1;
                        dataGridView1.Rows[a].Cells[4].Value = _hrgkhs;
                        dataGridView1.Rows[a].Cells[9].Value = 1 * _hrgkhs;
                        dataGridView1.Rows[a].Cells[12].Value = "AUTOACC";
                        //}
                    }
                    else
                    {
                        if (hrg < _hrgJual)
                        {
                            dataGridView1.Rows[a].Cells[4].Value = _hrgJual;
                            dataGridView1.Rows[a].Cells[9].Value = qty * _hrgJual;
                            dataGridView1.Rows[a].Cells[12].Value = "AUTOACC";
                        }
                    }
                }
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}