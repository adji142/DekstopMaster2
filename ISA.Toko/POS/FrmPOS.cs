using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA.Toko;
using ISA.Controls;
using ISA.DAL;
using ISA.Toko.Controls;
using System.Data.SqlTypes;
using System.Globalization;
using ISA.Common;
using ISA.Toko.Class;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.POS
{

    public partial class FrmPOS : ISA.Toko.BaseForm
    {
        bool CanInsertGridViewPos = true;
        public enum EnumPasif { All, Aktiv };
        double  menit = 0, varmenit=0;
        String _NoNota;
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

        //variabel nota
        double _rpSisaACCPiutang, _jmlHrgNota, _rpACCPiutang;
        string _transType;
        string _Cat1 = string.Empty, _Cat2 = string.Empty, _Cat3 = string.Empty,
                _Cat4 = string.Empty, _Cat5 = string.Empty, _CatD = string.Empty;
        int _hariKredit;


       //variabel gethitunghrgjual
        string _barangID, _NamaBarang;
        DateTime _tglDO, _tglAkhir;
               string _c1;
        double HrgJualBMK_;
        int QTYPOS;
        double _hrgB = 0, _hrgM = 0, _hrgK = 0, _hrg4 = 0, _hrgJual = 0, _hrgAkhir = 0, _hrgAmbil = 0, _hargaFinal = 0, _hrgHPP = 0, _hrgNet = 0;

        DataTable dtPromo, dtpromotetap, dtbarang;
        int _nCetak = -1, _nOli = 1;
        string _ketNota = "";

        //variable bengkel
        string pemanggil;
        Guid rowidbengkel;
        string flagperbaikan;
        
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

                    if (MessageBox.Show("Harga jual Netto tidak sama dengan Harga 1, 2, 3, dan 4!!!", "Lanjut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                        /*
                        db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));

                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, QTYPOS));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar,lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, _c1));
                        */

                        db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));

                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));                        
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, Tools.Left(txtTipeTransaksi.Text,2)));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));

                        dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgJual.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                        //Tambahan
                        HrgJualBMK_ = _hrgJual;
                    }
                    else
                    {
                        _hrgJual = 0;
                        HrgJualBMK_ = 0;
                    }
                   // MessageBox.Show(HrgJualBMK_.ToString() + " - " + _hrgJual.ToString());

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
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, GlobalVar.DateOfServer));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, initCab));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgBMK.Rows.Count > 0)
                {
                    _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                    _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                    _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                    _hrg4 = Convert.ToDouble(dtGetHrgBMK.Rows[0]["Hrg4"]);
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                else
                {
                    KotakPesan.HargaJual("Barang tidak mempunyai Harga Jual, hubungi Manager Anda");
                    CanInsertGridViewPos = false;
                    _hrgB = 0;
                    _hrgM = 0;
                    _hrgK = 0;
                    _hrg4 = 0;
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
                lblBMK.Text = "1: " + _hrgB.ToString("N0") + "  2: " + _hrgM.ToString("N0") + "  3: " + _hrgK.ToString("N0") + "  4: " + _hrg4.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
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

        private void GetHrgBMK()
        {
            try
            {
            DataTable dtGetHrgBMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetHargaJual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, GlobalVar.DateOfServer));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, _c1));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgBMK.Rows.Count > 0)
                {
                    _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                    _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                    _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                    _hrg4 = Convert.ToDouble(dtGetHrgBMK.Rows[0]["Hrg4"]);
                    _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    _hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                else
                {
                    
                    _hrgB = 0;
                    _hrgM = 0;
                    _hrgK = 0;
                    _hrg4 = 0;
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

                if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0 && _hrg4 >0)
                {
                    lblBMK.Text = "1: " + _hrgB.ToString("N0") + "  2: " + _hrgM.ToString("N0") + "  3: " + _hrgK.ToString("N0") + "  4: " + _hrg4.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
                
                }
                else
                {
                    KotakPesan.HargaJual("tidak mempunyai BMK Silakan hubungi Manager anda");
                    CanInsertGridViewPos = false;
                }
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
                    KotakPesan.HargaBeli("Barang tidak mempunyai riwayat HPP, hubungi Manager Anda");
                    CanInsertGridViewPos = false;
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
                    //_hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                    //_hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                    //_hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);

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
                            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        }



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
                            _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                            _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                            _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                        }

                        if (_hrgB > 0)
                        {
                            fHargaKhusus = "1";
                        }

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
                if (!CanInsertGridViewPos) return;
                msgBMK = "Harga Jual yaitu \n1. : " + _hrgB.ToString("#,##0") + "  2. : " + _hrgM.ToString("#,##0") + "  3: " + _hrgK.ToString("#,##0") + "  4. : " + _hrg4.ToString("#,##0");

                string sTglAkhir = "-";

                if (_hrgAkhir > 0)
                {
                    sTglAkhir = _tglAkhir.ToString("dd-MMM-yyyy");
                }

                msgAkhir = "Penjualan terakhir Rp. " + _hrgAkhir.ToString("#,##0")
                        + " Tgl. " + sTglAkhir;

                KotakPesan.InfoHargaJual(msgBMK + System.Environment.NewLine + msgAkhir);
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
                KotakPesan.StatusHarga("Data Customer masih kosong..\nMohon diisi dahulu karena akan mempengaruhi harga Jual 1, 2, 3, 4");
                return;
            }
            int nRowIndex = dataGridView1.Rows.Count;
           
            //this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode_posV2"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, TxtBarcode.Text));
                
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 1)
            {

                TampilFormBarang(dt, TxtBarcode.Text);
               
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {

                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    int stokgudang = Convert.ToInt16(dr["StokAkhirGudang"]);
                    if (stokgudang <= 0)
                    {
                        MessageBox.Show("'" + namabarang + "'" + "\n" + " Stok gudang 0 ", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            MessageBox.Show("'" + namabarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Cursor = Cursors.Default;
                            return;

                        }
                        dataGridView1.AllowUserToAddRows = false;
                    }

                    if (idbarang.Length == 13)
                    {
                        _barangID = Convert.ToString(dr["BarangID"]);
                        QTYPOS = 1;
                        _c1 = cab1;


                        if (_noACC != "BONUSAN")
                        {
                            GetHrgJual();
                            GetHrgBMKMessage();
                            if (pemanggil != "BENGKEL")
                            {
                                GetHrgKhusus();
                            }
                            GetHargaHpp(idbarang);
                        }
                        if (!CanInsertGridViewPos) { CanInsertGridViewPos = true; return; }
                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                        dataGridView1.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                        dataGridView1.Rows[nRowIndex].Cells[2].Value = 1;
                        dataGridView1.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];
                        dataGridView1.Rows[nRowIndex].Cells[11].Value = dr["Merek"];
                        dataGridView1.Rows[nRowIndex].Cells[12].Value = dr["StokAkhirGudang"];
                        switch (stsTk)
                        {
                            case "H4":
                                _hargaFinal = _hrg4;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrg4;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrg4;
                                break;
                            case "H3":
                                _hargaFinal = _hrgK;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgK;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgK;
                                break;
                            case "H2":
                                _hargaFinal = _hrgM;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgM;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgM;
                                break;
                            default:
                                _hargaFinal = _hrgB;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgB;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgB;
                                break;
                        }

                        #region harga tidak boleh kurang dari atau sama dengan 0
                        for (a = 0; a < dataGridView1.Rows.Count; a++)
                        {


                            int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                            if (qty > 0)
                            {

                                //if (_hargaFinal <= 0 && _hrgHPP <= 0)
                                //{
                                //    dataGridView1.AllowUserToAddRows = false;
                                //    b = a + dataGridView1.Rows.Count-1;
                                //    MessageBox.Show("Harga Jual dan HPP masih 0, Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                                //    dataGridView1.Rows.Remove(dataGridView1.Rows[b]);
                                //    dataGridView1.AllowUserToAddRows = false;
                                //    return;
                                //}

                            }
                        }
                        #endregion


                        dataGridView1.Rows[nRowIndex].Cells[5].Value = 0;
                        dataGridView1.Rows[nRowIndex].Cells[6].Value = 0;
                        dataGridView1.Rows[nRowIndex].Cells[7].Value = 0;
                        dataGridView1.Rows[nRowIndex].Cells[8].Value = 0;

                        //LblKet.Text = "\"" + dr["NamaStok"].ToString() + "\" ";
                        dataGridView1.MultiSelect = false;
                        dataGridView1.BeginEdit(true);
                        dataGridView1.AllowUserToAddRows = false;


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
                    else 
                    {
                        TxtBarcode.Text = Convert.ToString(dr["BarangID"]);
                        AmbilBarangJasa();
                    }
                }
                this.Cursor = Cursors.Default;
                //getPromo();
                dataGridView1.AllowUserToAddRows = false;
                
            }
            
            
        }

        public void AmbilDetailJasa(String KodeJasa) 
        {
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_Jasa_list_detail]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeJasa", SqlDbType.VarChar, KodeJasa));
                dt = db.Commands[0].ExecuteDataTable();
            }
            _barangID = dt.Rows[0]["Kode"].ToString();
            _NamaBarang = dt.Rows[0]["Nama"].ToString();
            _hargaFinal = Convert.ToDouble(dt.Rows[0]["HargaJual"]);
            lblBMK.Text = "Harga Net: " + _hargaFinal.ToString("N0");
        }

        public void AmbilBarangJasa()
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
                KotakPesan.StatusHarga("Data Customer masih kosong..\nMohon diisi dahulu karena akan mempengaruhi harga Jual 1, 2, 3, 4");
                return;
            }

            
            int nRowIndex = dataGridView1.Rows.Count;
            AmbilDetailJasa(TxtBarcode.Text);

            for (a = 0; a < dataGridView1.Rows.Count; ++a)
            {
                string idbarangcell = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                if (_barangID == idbarangcell)
                {
                    MessageBox.Show("'" + _NamaBarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Cursor = Cursors.Default;
                    return;

                }
                dataGridView1.AllowUserToAddRows = false;
            }
            if (!CanInsertGridViewPos) { CanInsertGridViewPos = true; return; }
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Add(1);
            dataGridView1.Rows[nRowIndex].Cells[0].Value = _barangID;
            dataGridView1.Rows[nRowIndex].Cells[1].Value = _NamaBarang;
            dataGridView1.Rows[nRowIndex].Cells[2].Value = 1;
            dataGridView1.Rows[nRowIndex].Cells[3].Value = "";
            dataGridView1.Rows[nRowIndex].Cells[11].Value = "";
            dataGridView1.Rows[nRowIndex].Cells[12].Value = "";
            dataGridView1.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
            dataGridView1.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
            dataGridView1.Rows[nRowIndex].Cells[5].Value = 0;
            dataGridView1.Rows[nRowIndex].Cells[6].Value = 0;
            dataGridView1.Rows[nRowIndex].Cells[7].Value = 0;
            dataGridView1.Rows[nRowIndex].Cells[8].Value = 0;

            //LblKet.Text = "\"" + dr["NamaStok"].ToString() + "\" ";
            dataGridView1.MultiSelect = false;
            dataGridView1.BeginEdit(true);
            dataGridView1.AllowUserToAddRows = false;


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
      

            this.Cursor = Cursors.Default;
            //getPromo();
            dataGridView1.AllowUserToAddRows = false;
        }

        public void AmbilBarang2(int stockGudang)
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
                KotakPesan.StatusHarga("Data Customer masih kosong..\nMohon diisi dahulu karena akan mempengaruhi harga Jual 1, 2, 3, 4");
                return;
            }
            int nRowIndex = dataGridView1.Rows.Count;

            //this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, TxtBarcode.Text));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, txtTipeTransaksi.Text));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Stok barang kosong");
                TampilFormBarang();

            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {

                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            MessageBox.Show("'" + namabarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Cursor = Cursors.Default;
                            return;

                        }
                        dataGridView1.AllowUserToAddRows = false;
                    }



                    _barangID = Convert.ToString(dr["BarangID"]);
                    QTYPOS = 1;
                    _c1 = cab1;


                    if (_noACC != "BONUSAN")
                    {
                        GetHrgJual();
                        GetHrgBMKMessage();
                        if (pemanggil != "BENGKEL")
                        {
                            GetHrgKhusus();
                        }
                        GetHargaHpp(idbarang);
                    }
                    if (!CanInsertGridViewPos) { CanInsertGridViewPos = true; return; }
                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                    dataGridView1.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    dataGridView1.Rows[nRowIndex].Cells[2].Value = 1;
                    dataGridView1.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];
                    dataGridView1.Rows[nRowIndex].Cells[11].Value = dr["Merek"];
                    dataGridView1.Rows[nRowIndex].Cells[12].Value = stockGudang;
                    //int valSetting = Convert.ToInt16(AppSetting.GetValue("DO_ISI_HJUAL"));
                    //if (valSetting != 0 && valSetting != 1) { KotakPesan.Warning("Setting DokumenNotaJual belum dilakukan dengan benar. Mohon perbaiki nilai di APPSetting.", "AppSetting"); return; }
                    //if (valSetting == 1)
                    //{

                    //    _hargaFinal = _hrgAkhir;
                    //    dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgAkhir;
                    //    dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgAkhir;
                    //    if (_hargaFinal == 0) valSetting = 0;
                    //}
                    //if (valSetting == 0)
                    //{
                        switch (stsTk)
                        {
                            case "H4":
                                _hargaFinal = _hrg4;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrg4;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrg4;
                                break;
                            case "H3":
                                _hargaFinal = _hrgK;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgK;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgK;
                                break;
                            case "H2":
                                _hargaFinal = _hrgM;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgM;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgM;
                                break;
                            default:
                                _hargaFinal = _hrgB;
                                dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgB;
                                dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgB;
                                break;

                        }
                    //}



                    //string Jenisdong, jenis2;
                    //Jenisdong = txtTipeTransact.Text;
                    //jenis2 = Tools.Left(Jenisdong, 1);


                    //    if (TxtNamaToko.Text != "ECERAN CASH")
                    //    {
                    //        if (jenis2 == "T" || jenis2 == "t")
                    //        {
                    //            _hargaFinal = _hrgB;
                    //            dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgB;
                    //            dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgB;
                    //        }
                    //        if (jenis2 == "K" || jenis2 == "k")
                    //        {
                    //            _hargaFinal = _hrgM;
                    //            dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgM;
                    //            dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgM;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        string _KodeToko = lookupToko1.KodeToko;
                    //        DataTable dtHK = new DataTable();
                    //        try
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                db.Commands.Add(db.CreateCommand("usp_GetDatakhusus"));
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

                    //            _hargaFinal = _hrgK;
                    //            dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgK;
                    //            dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgK;

                    //        }
                    //        else
                    //        {
                    //            _hargaFinal = _hrgK;
                    //            dataGridView1.Rows[nRowIndex].Cells[9].Value = _hrgK;
                    //            dataGridView1.Rows[nRowIndex].Cells[4].Value = _hrgK;
                    //        }
                    //    }



                    #region harga tidak boleh kurang dari atau sama dengan 0
                    for (a = 0; a < dataGridView1.Rows.Count; a++)
                    {


                        int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                        if (qty > 0)
                        {

                            //if (_hargaFinal <= 0 && _hrgHPP <= 0)
                            //{
                            //    dataGridView1.AllowUserToAddRows = false;
                            //    b = a + dataGridView1.Rows.Count-1;
                            //    MessageBox.Show("Harga Jual dan HPP masih 0, Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                            //    dataGridView1.Rows.Remove(dataGridView1.Rows[b]);
                            //    dataGridView1.AllowUserToAddRows = false;
                            //    return;
                            //}

                        }
                    }
                    #endregion


                    dataGridView1.Rows[nRowIndex].Cells[5].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[6].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[7].Value = 0;
                    dataGridView1.Rows[nRowIndex].Cells[8].Value = 0;

                    //LblKet.Text = "\"" + dr["NamaStok"].ToString() + "\" ";
                    dataGridView1.MultiSelect = false;
                    dataGridView1.BeginEdit(true);
                    dataGridView1.AllowUserToAddRows = false;


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


                this.Cursor = Cursors.Default;
                //getPromo();
                dataGridView1.AllowUserToAddRows = false;
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
                if (lookup_Ekspedisi1.Expedisi== "SAS")
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
        
        private void SetDevaultEkspedisi()
        {
            lookup_Ekspedisi1.KodeExpedisi = AppSetting.GetValue("KODE_EXPEDISI_DEFAULT");
    
        }

        private void SetDevaultToko()
        {
            lookupToko1.NamaToko = AppSetting.GetValue("TOKO_TUNAI");

        }

        //private string GetDefaultToko()
        //{
        //    //string defKodeToko = string.Empty;

        //    //DataTable dtAppSet;
        //    //using (Database db = new Database())
        //    //{
        //    //    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
        //    //    db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "TOKO_TUNAI"));
        //    //    dtAppSet = db.Commands[0].ExecuteDataTable();
        //    //}

        //    //if (dtAppSet.Rows.Count > 0)
        //    //{
        //    //    defKodeToko = dtAppSet.Rows[0]["Value"].ToString();
        //    //}
        //    //return defKodeToko;
            
        //}



        #endregion

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void SetTipeTransact()
        {
            txtTipeTransaksi.Text = AppSetting.GetValue("TIPE_TRANSAKSI_POS");
        }
        
        private void SetSales()
        {
          lookupSales1.NamaSales = AppSetting.GetValue("SALES_DEFAULT");
        }
        private void FrmPOS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            menit = 0; varmenit = 0;
            miliDetik = 0; varmilidetik = 0;
            total = 0;
            label12.Text = Convert.ToString(total);
            idsales = "";
            tanggal = GlobalVar.DateOfServer;
            string tgl = tanggal.ToString("dd/MM/yyyy");
            TxtTGL.Text = Convert.ToString(tgl);
            //lookupToko1.SetToko(GetDefaultToko());
            kuantiti2 = 0;
            lblqty.Text = Convert.ToString(kuantiti2);

            #region tampil hari dan tanggal
            CultureInfo culture;
            culture = new CultureInfo("id-ID");
            string tgl_label = GlobalVar.DateOfServer.ToString("dddd, dd MMMM yyyy", culture);
            label25.Text = Convert.ToString(tgl_label);
            #endregion


            //if (flagperbaikan == "Y")
            //{
            //    txtTipeTransact.Text = "K2";
            //    txtTipeTransact.Enabled = false;
            //}
            //else
            //{
            //    txtTipeTransact.Text = "TG";
            //    txtTipeTransact.Enabled = false;
            //}
            #region Data Detail
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtExp = new DataTable();

                using (Database db = new Database())
                {
                    //display Expedisi List
                    //db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@Aktif", SqlDbType.Bit, true));
                    ////dtExp = db.Commands[0].ExecuteDataTable();
                    ////if (dtExp.Rows.Count > 0)
                    ////{
                    ////    CBOEkspedisi.DisplayMember = "Expedisi";
                    ////    CBOEkspedisi.ValueMember = "KodeExpedisi";
                    ////    CBOEkspedisi.DataSource = dtExp;
                    ////    CBOEkspedisi.SelectedValue = "AMB";
                    ////    CBOEkspedisi.SelectedIndex = 0;
                    //}
                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                        dt = db.Commands[0].ExecuteDataTable();
                        nprint = int.Parse(dt.Rows[0]["NPrint"].ToString());
                        noAccPiutang = dt.Rows[0]["NoACCPiutang"].ToString();
                        noAccPusat = dt.Rows[0]["NoACCPusat"].ToString();
                        _TglACCPiutang = dt.Rows[0]["TglACCPiutang"];
                        _TglReorder = dt.Rows[0]["TglACCPiutang"];
                    }

                }

            #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            // pengaturan index datagridview
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
            //----- nota

            
            _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
            SetTipeTransact();

            SetDevaultEkspedisi();
            SetSales();           
            SetDevaultToko();
            //lookupToko1.NamaToko = Tools.getAppSettingKeterangan("Nama_Pelanggan_Tunai");
            //CBOEkspedisi.Text = Tools.getAppSettingKeterangan("Kode_Expedisi_Default");
        }

        private void resetdataCostumer()
        {
            lookupToko1.NamaToko = "";
            lookupToko1.KodeToko = "";
            TxtNamaToko.Text = "";
            TxtAlamatToko.Text = "";
            TxtKota.Text = "";
            TxtIDWil.Text = "";
            txtstatus.Text = "";

        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            try
            {
                double plafonToko = ISA.Toko.Class.TokoPlafon.Plafon(lookupToko1.KodeToko);
                if (plafonToko == 0)
                {
                    KotakPesan.Plafon("Tidak bisa pilih toko karena belum ada Plafon Toko, masih belum diisi. Hubungi Manager anda. ");
                    resetdataCostumer();
                    return;
                }
                kodetoko = lookupToko1.KodeToko;
                DataTable dtToko = new DataTable();
                DataTable dtStsToko, dtStatusToko = new DataTable();
                object stsToko;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetStatusToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, initCab));
                    dtStatusToko = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_StsToko_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    dtStsToko = db.Commands[1].ExecuteDataTable();
                }
                if (dtStatusToko.Rows.Count > 0)
                {
                    stsTk = dtStatusToko.Rows[0][0].ToString();
                    _stsToko = dtStatusToko.Rows[0][1].ToString();
                }
                else {
                    KotakPesan.StatusHarga("Tidak bisa pilih toko karena belum ada Status harga Toko, masih belum diisi. Hubungi Manager anda.");
                    resetdataCostumer();
                    stsTk = ""; _stsToko = "";
                    return;
                }

               
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

                //int jml = dtStsToko.Rows.Count;
                //for (int i = 0; i < jml; i++)
                //{
                //    string cabang1 = dtStsToko.Rows[i]["CabangID"].ToString();
                //    if (cabang1 != initCab)
                //    {
                //        MessageBox.Show("Toko ini bentrok dengan " + cabang1);
                //    }

                //}
                TxtNamaToko.Text = lookupToko1.NamaToko;
                TxtAlamatToko.Text = lookupToko1.Alamat;
                TxtKota.Text = lookupToko1.Kota;
                TxtIDWil.Text = lookupToko1.WilID;
                LblKodeToko.Text = lookupToko1.TokoID;

                statustoko = stsTk;
                alamatkirim = lookupToko1.Alamat;
                kotatoko = lookupToko1.Kota;
                
                
                txtstatus.Text = _stsToko.ToString();
                lookup_Ekspedisi1.Focus();

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
            DateTime waktu = GlobalVar.DateOfServer;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime waktu = GlobalVar.DateOfServer;
            string wkt = GlobalVar.DateTimeOfServer.ToString("HH:mm:ss");
            label24.Text = wkt;
                        
            TxtWaktu.Text = waktu.TimeOfDay.ToString();
        }

        private object val(object p)
        {
            throw new NotImplementedException();
        }

        private void getPromo()
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


                int sumKelipatanQtyBarang = 0;
                int sumKelipatanQtyKelompok = 0;


                int i = 0;
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

                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string idbrng = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    DataTable dtpromobarang = Prolib.DataPromoBarang(_barangID);
                    qtybarang = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);
                    hargajualbarang = Convert.ToDouble(dataGridView1.Rows[i].Cells["GvJumlah"].Value);
                    if (dtpromobarang.Rows.Count > 0)
                    {
                        sumqtyBarang = sumqtyBarang + qtybarang;
                        sumhargajualbarang = sumhargajualbarang + hargajualbarang;


                    }
                }

                #endregion

                #region promo kelompok nya

                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Prolib.cekpromokelompok(_barangID) == true)
                    {
                        qtyKelompok = Convert.ToInt32(dataGridView1.Rows[i].Cells["GvQty"].Value);

                        sumqtyKelompok = sumqtyKelompok + qtyKelompok;
                        //dataGridView1.Rows[i].Cells["GvJumlah"].Value = jumnetakhir;
                        hargajualKelompok = Convert.ToDouble(dataGridView1.Rows[i].Cells["GvJumlah"].Value);
                        //MessageBox.Show(hargajualKelompok.ToString());

                        sumhargajualKelompok = sumhargajualKelompok + hargajualKelompok;


                        DataTable dtPromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);

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
                                DateTime hari = GlobalVar.DateOfServer;
                                kodetoko = lookupToko1.KodeToko;
                                int akumulasihari, qtyakumulasi;
                                double hargaJualAkumulasi;

                                //Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
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
                            DateTime hari = GlobalVar.DateOfServer;
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
                                DateTime hari = GlobalVar.DateOfServer;
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
                            DateTime hari = GlobalVar.DateOfServer;
                            kodetoko = lookupToko1.KodeToko;
                            int akumulasihari, qtyakumulasi;
                            double hargaJualAkumulasi;

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


                                qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
                                hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);

                                //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
                                sumqtyKelompok = qtyakumulasi + qtybarang;
                                sumhargajualKelompok = hargaJualAkumulasi + hargajualKelompok;


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
                #endregion



                #region kelipatan promo barang
                /*for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                {
                    Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
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
                }*/
                #endregion

                #region kelipatan promo kelompok
                /*for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
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
                }*/

                #endregion

                #region Akumulasi barang
                /* for (i = 0; i < dtPromoBarangBonus.Rows.Count; i++)
                {
                    DateTime hari = DateTime.Now;
                    kodetoko = lookupToko1.KodeToko;
                    int akumulasihari, qtyakumulasi;
                    double hargaJualAkumulasi;

                    Guid PromoRowID = (Guid)(dtPromoBarangBonus.Rows[i]["PromoDetailRowID"]);
                    DataTable dtAkumulasihari,dtAkumulasiPenjualan;

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

                }*/
                #endregion

                #region Akumulasi Kelompok
                /*for (i = 0; i < dtpromoKelompok.Rows.Count; i++)
                {
                    DateTime hari = DateTime.Now;
                    kodetoko = lookupToko1.KodeToko;
                    int akumulasihari, qtyakumulasi;
                    double hargaJualAkumulasi;

                    Guid PromoRowID = (Guid)(dtpromoKelompok.Rows[i]["PromoDetailRowID"]);
                    DataTable dtAkumulasihari, dtAkumulasiPenjualan;


                    if (Prolib.Akumulasi(PromoRowID) == true)
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
                }*/

                #endregion

                if (dtPromoBarangBonus.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0)
                {
                    string idtoko = lookupToko1.KodeToko;

                    frmpilihbonus ifrmChild = new frmpilihbonus(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBarangBonus, dtpromoKelompok);
                    ifrmChild.ShowDialog();
                }
                #endregion

                #region ijo2
                //DataTable dtrw = new DataTable();
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_cek_row_promo"));
                //    db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, idbrng));
                //    dtrw = db.Commands[0].ExecuteDataTable();
                //}

                //if (dtrw.Rows.Count > 0)
                //{
                //    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                //}


                //ngambil barang promo (hadiah) kalo sumqty dan sumharga nya >= q_min dan s_min


                //int nRowIndex = dataGridView1.Rows.Count;
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_Get_Barang_Promo_DO_List"));
                //    /* db.Commands[0].Parameters.Add(new Parameter("@total", SqlDbType.Money, 500000));
                //     db.Commands[0].Parameters.Add(new Parameter("@QtyTtl", SqlDbType.Int, 50));
                //     db.Commands[0].Parameters.Add(new Parameter("@datepro", SqlDbType.DateTime, Convert.ToDateTime("2012/07/01")));
                //      */
                //    db.Commands[0].Parameters.Add(new Parameter("@total", SqlDbType.Money, Convert.ToDouble(label12.Text)));
                //    db.Commands[0].Parameters.Add(new Parameter("@QtyTtl", SqlDbType.Int, Convert.ToInt32(lblqty.Text) ));
                //    db.Commands[0].Parameters.Add(new Parameter("@datepro", SqlDbType.DateTime, Convert.ToDateTime(DateTime.Now)));
                //    dtPromo = db.Commands[0].ExecuteDataTable();
                //}


                //if (dtpromotetap.Rows.Count > 0|| dtPromo.Rows.Count > 0)
                //{
                //    string idtoko = lookupToko1.KodeToko;
                //    //string barangID = ;
                //    frmpilihbonus ifrmChild = new frmpilihbonus(this, idtoko, _barangID);
                //    ifrmChild.ShowDialog();
                //foreach (DataRow dr in dtPromo.Rows)
                //{
                //    dataGridView1.Rows.Add(1);
                //    dataGridView1.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                //    dataGridView1.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                //    dataGridView1.Rows[nRowIndex].Cells[2].Value = Convert.ToInt32(dr["QtyRequest"]);
                //    dataGridView1.Rows[nRowIndex].Cells[3].Value = dr["Satuan"];
                //    dataGridView1.Rows[nRowIndex].Cells[4].Value = dr["HrgJual"];
                //    dataGridView1.Rows[nRowIndex].Cells[5].Value = dr["Disc1"];
                //    dataGridView1.Rows[nRowIndex].Cells[6].Value = dr["Disc2"];
                //    dataGridView1.Rows[nRowIndex].Cells[7].Value = dr["Disc3"];
                //    dataGridView1.Rows[nRowIndex].Cells[8].Value = dr["Pot"];
                //    dataGridView1.Rows[nRowIndex].Cells[9].Value = dr["jumlah"];
                //    nRowIndex++;
                //}
                //}
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

        public bool savepromo(DataTable dtbarang)
        {
            //masukin barang promo yang udah kepilih ke datagrid yang udah ada
            int i = 0;
            i = dataGridView1.Rows.Count;
            int j = i + 1;

            //nyimpen promo barang setelah dipilih dari grid promo barang
            string idBrg = string.Empty;
            string idBrgPromo = string.Empty;
            foreach (DataRow dr in dtbarang.Rows)
            {
                idBrgPromo = Convert.ToString(dr["barangid"]);
                foreach (DataGridViewRow drPOS in dataGridView1.Rows)
                {
                    idBrg = Convert.ToString(drPOS.Cells["gVplu"].Value);

                    if (idBrg == idBrgPromo)
                    {
                        return false;
                    }
                }

                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = dr["barangid"];
                dataGridView1.Rows[i].Cells[1].Value = dr["namabarang"];
                dataGridView1.Rows[i].Cells[2].Value = Convert.ToInt32(dr["qtybonus"]);
                dataGridView1.Rows[i].Cells[3].Value = dr["satuan"];
                dataGridView1.Rows[i].Cells[4].Value = dr["h_jual"];
                dataGridView1.Rows[i].Cells[5].Value = 0;
                dataGridView1.Rows[i].Cells[6].Value = 0;
                dataGridView1.Rows[i].Cells[7].Value = 0;
                dataGridView1.Rows[i].Cells[8].Value = 0;
                dataGridView1.Rows[i].Cells[9].Value = 0;
                i++;
            }

            return true;
        }

        /// <summary>
        /// simpanan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
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
                idsales = lookupSales1.SalesID;       

                if (formMode == enumFormMode.New)
                {
                    HtrId = Tools.CreateFingerPrint();
                    cab1 = initCab;
                    cab2 = initCab;
                    cab3 = "";
                    gudang = initgudang;
                }

                #region nota
                double _totalHrg = 0;// double.Parse(dt.Compute("SUM(TotalHrg)", string.Empty).ToString());
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;
                double _discFormula = 0;
                double _harga3D = 0;
                int k; int l;
                k = 0; l = 0;

                _notaHeaderRowID = Guid.NewGuid();
                //_notaHeaderRowID = rowidbengkel;
                
                string _notaHeaderRecID = Tools.CreateShortFingerPrint(k);
                string _notaDetailRecID = string.Empty;
                // Add new Nota Penjualan Header
                this.Cursor = Cursors.WaitCursor;
                string temp = string.Empty;
                //Generate Nomor Nota
                string kodeNota = "";
                string nomorNota = "";
                string PTpattern = "KH,TH,KL,TL";


                string depannota = "";
                string belakangnota = "";
                int iNomorNota;
                int lebarnota;
                int lebarOriginal = 0;
                int ctr = 0;
                int lastCtr = 0;
                int ctrBef = 0;
                DataTable dtNumNota;
                int countRows;

                kodeNota = "NOMOR_NOTA_TAX";
                docNoDO = "NOMOR_DO_TAX";

                depannota = GetInitialPT();

                //generate nomor DO
                //DataTable dtNum = Tools.GetGeneralNumerator(docNoDO, depannota);
                //int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                //int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                //string depan = depannota;
                //string belakang = dtNum.Rows[0]["Belakang"].ToString();
                //iNomor = iNomor + 1;

                if (GlobalVar.DateOfServer <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                //dtNumNota = Tools.GetGeneralNumerator(kodeNota, depannota);
                //lebarOriginal = int.Parse(dtNumNota.Rows[0]["Lebar"].ToString());
                ////lebarnota = lebarOriginal - 3;
                //lebarnota = int.Parse(dtNumNota.Rows[0]["Lebar"].ToString());
                ////lebarnota = lebarOriginal - 3;
                //iNomorNota = int.Parse(dtNumNota.Rows[0]["Nomor"].ToString());

                //belakangnota = dtNumNota.Rows[0]["Belakang"].ToString();
                //iNomorNota=iNomorNota+1;
                ////nomorNota = Tools.FormatNumerator(iNomorNota, lebarnota, depannota, belakangnota);
                //nomorNota = Tools.AutoNumbering("NoDo", "ISADBDepoRetail.dbo.OrderPenjualan");
                nomorNota = Numerator.BookNumerator("PJL");
                LblNoNota.Text = nomorNota;

                string BarcodeNota = nomorNota.Trim() + GlobalVar.DateTimeOfServer.ToString("yyy").Substring(1, 3) ;

                #endregion
                #region SIMPAN HEADER DO NOTA
                //-------------    proses simpan ke HeaderDO, DetailDO, HeaderNota, DetailNota    -------------------------
                try
                {
                    _RowIDPos = Guid.NewGuid();

                    bool lNota = false;
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

                    if (lNota==false)
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.BeginTransaction();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_INSERT"));
                            if (pemanggil=="BENGKEL")
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowidbengkel)); //_rowid
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDPos)); //_rowid
                            
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cab1));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cab2));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cab3));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, "CASH"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, nomorNota));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, string.Empty));
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
                            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, lookup_Ekspedisi1.KodeExpedisi));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, hari));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, "1"));

                            if (flagperbaikan == "Y")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, 30));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, "K2"));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, "TG"));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
                            }

                            if (pemanggil == "BENGKEL")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, "BENGKEL"));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID));
                            }

                            ////UPDATE NUMERATOR
                            //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                            //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depannota));
                            //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            //if (pemanggil == "BENGKEL")
                            //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                            //else
                            //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[0].ExecuteNonQuery();
                            //db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                    
                        //GET ROWID DO
                        //Guid _RowIDDO;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_GetRowIDDO"));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            dt = db.Commands[0].ExecuteDataTable();
                            _RowIDDO = (Guid)dt.Rows[0]["RowID"];
                        }


                        //---  save to header nota
                        //string barcodeNota = (nomorNota + TxtTGL.Text.Substring(1, 3) + TxtTGL.Text.Substring(4, 2));

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_INSERT"));
                            if (pemanggil == "BENGKEL")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowidbengkel));  //_notaHeaderRowID
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDPos));  //_notaHeaderRowID
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaHeaderRecID)); //_notaHeaderRecID));
                            db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _RowIDDO)); //_rowid
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, nomorNota));//Tools.GetGeneralNumerator("NOMOR_NOTA").Rows[0].ToString()));
                            _NoNota = nomorNota;
                            db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, nomorNota));
                            //db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, TxtTGL.DateValue));
                            //db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cab1));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cab2));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, cab3));
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
                            db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.UniqueIdentifier, null));
                            db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.UniqueIdentifier, null));
                            db.Commands[0].Parameters.Add(new Parameter("@BarcodeNota", SqlDbType.VarChar, BarcodeNota));
                            db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, txtTipeTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));//_hariKredit));
                            db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                            if (pemanggil == "BENGKEL")
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                            else
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            ////UPDATE NUMERATOR NOTA
                            //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, kodeNota));
                            //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depannota));
                            //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakangnota));
                            //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomorNota));
                            //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebarOriginal));
                            //if (pemanggil == "BENGKEL")
                            //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "BENGKEL"));
                            //else
                            //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            //db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            //db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();

                        }

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

                    //SIMPAN DETAIL
                    for (a = 0; a < dataGridView1.Rows.Count; ++a)
                    {
                        Guid DetailRowIDDO = Guid.NewGuid();
                        string _recID = Tools.CreateFingerPrint();
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

                        using (Database db = new Database())
                        {
                            CekBarangID(barangID);
                            if (barangID.Substring(0, 3).Equals("FXB"))
                                potongan = 1;
                            if (_noACC.Equals("BONUSAN"))
                                potongan = 1;

                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, DetailRowIDDO));
                            if (pemanggil=="BENGKEL")
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
                            //db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, _noACC));

                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, "AUTOACC"));
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
                        _notaDetailRecID = Tools.CreateShortFingerPrint(counter + 1);
                        Guid DetailRowIDNota = Guid.NewGuid();

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

                        #region recalculate
                        Recalculate(barangID, gudang);
                        //MessageBox.Show("Proses RECALCULATE Selesai");
                        this.Cursor = Cursors.Default;
                        #endregion

                    }

                    cetakNota();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }

                #endregion
                               
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        /// <summary>
        /// selesai jadi simpanan
        /// 
        /// </summary>
        /// <param name="barangID"></param>
  
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
            if (validation())
            {
                #region ijo2
                //for (a = 0; a < dataGridView1.Rows.Count; a++)
                //{
                //    _barangID = dataGridView1.Rows[a].Cells["gVplu"].Value.ToString();
                //    CekHargaBMK(_barangID);
                //    string Jenisdong, jenis2;
                //    Jenisdong = txtTipeTransact.Text;
                //    jenis2 = Tools.Left(Jenisdong, 1);


                //    if (TxtNamaToko.Text != "ECERAN CASH")
                //    {
                //        if (jenis2 == "T" || jenis2 == "t")
                //        {
                //            _hargaFinal = _hrgB;
                //            dataGridView1.Rows[a].Cells[9].Value = _hrgB;
                //            dataGridView1.Rows[a].Cells[4].Value = _hrgB;
                //        }
                //        if (jenis2 == "K" || jenis2 == "k")
                //        {
                //            _hargaFinal = _hrgM;
                //            dataGridView1.Rows[a].Cells[9].Value = _hrgM;
                //            dataGridView1.Rows[a].Cells[4].Value = _hrgM;
                //        }
                //    }
                //    else
                //    {
                //        _hargaFinal = _hrgK;
                //        dataGridView1.Rows[a].Cells[9].Value = _hrgK;
                //        dataGridView1.Rows[a].Cells[4].Value = _hrgK;
                //    }

                //    int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                //    if (qty > 0)
                //    {
                //        double _hrgJual = Convert.ToDouble(dataGridView1.Rows[a].Cells[4].Value);
                //        if ( _hrgJual < _hargaFinal || _hrgJual < _hrgHPP)
                //        {
                //            MessageBox.Show("Harga Jual dan HPP masih 0, Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                //            return;
                //        }
                //    }
                //}
                #endregion
                getPromo();
                 
                for (a = 0; a < dataGridView1.Rows.Count; ++a)
                {
                    string plu = Convert.ToString(dataGridView1.Rows[a].Cells[0].Value);
                    string nama = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
                    int harga = Convert.ToInt32(dataGridView1.Rows[a].Cells[4].Value);
                    int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                    if (qty > 0)
                    {
                        if (plu == "")
                        {
                            int b = a + 1;
                            MessageBox.Show("Baris " + b + " KODE BARCODE, NAMA BARANG atau HARGA Kosong"+"\n"+"Baris ini akan dihapus sebelum 'Tutup Transaksi'");
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
                }
                if (dataGridView1.SelectedCells.Count > 0 )   
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
                string kodebarang = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["gVplu"].Value, string.Empty).ToString();
                if (kodebarang.Length == 13)
                {
                    CekHargaBMK(kodebarang);
                    switch (stsTk)
                    {
                        case "H4":
                            _hargaFinal = _hrg4;
                            break;
                        case "H3":
                            _hargaFinal = _hrgK;
                            break;
                        case "H2":
                            _hargaFinal = _hrgM;
                            break;
                        default:
                            _hargaFinal = _hrgB;
                            break;
                    }
                }
                else
                {
                    AmbilDetailJasa(kodebarang);
                }

                if (Convert.ToDouble(dataGridView1[2, e.RowIndex].Value) <= 0)
                {
                    MessageBox.Show("Quantity tidak boleh kurang dari 1", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.CurrentRow.Cells["GvQty"].Value = 1;
                }
                //cek harga tidak boleh diubah lebih kecil

                if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hargaFinal)
                {
                    MessageBox.Show("Harga tidak boleh lebih kecil dari harga jual semestinya", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.CurrentRow.Cells["GvHarga"].Value = _hargaFinal;                 
                }
                string _barangID = dataGridView1[0, e.RowIndex].Value.ToString();
                if (_barangID.Length == 13)
                {
                    if (Convert.ToDouble(dataGridView1[2, e.RowIndex].Value) >= Convert.ToInt64(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells[12].Value, 0)))
                    {
                        MessageBox.Show("Sisa Stok NamaBarang tinggal " + Convert.ToInt64(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells[12].Value, 0)).ToString() + ", nilai penjualan melebihi sisa stok. Hubungi ManagerAnda atau lakukan stok opname", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridView1.CurrentRow.Cells["GvQty"].Value = Convert.ToInt64(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells[12].Value, 0));
                    }
                    //CekHargaBMK(_barangID);
                    //CekHargaKhusus(_barangID);
                    //GetHargaHpp(_barangID);

                    //string Jenisdong1, jenis21;
                    //Jenisdong1 = txtTipeTransaksi.Text;
                    //jenis21 = Tools.Left(Jenisdong1, 1);
                    //if (TxtNamaToko.Text != "ECERAN CASH")
                    //{
                    //    if (jenis21 == "T" || jenis21 == "t")
                    //    {
                    //        _hargaFinal = _hrgB;

                    //    }
                    //    if (jenis21 == "K" || jenis21 == "k")
                    //    {
                    //        _hargaFinal = _hrgM;

                    //    }
                    //}
                    //else
                    //{
                        
                    //    _hargaFinal = _hrgK;
                    //}

                    bool isBmkValidated = LookupInfoValue.CekBmkPos();
                    if (isBmkValidated)
                    {
                        //if (dataGridView1[11, e.RowIndex].Value.ToString() != "AHM" && dataGridView1[11, e.RowIndex].Value.ToString() != "YGP" && dataGridView1[11, e.RowIndex].Value.ToString() != "SGP")
                        //if (dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FA" ||
                        //    dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FB" ||
                        //    dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 2) == "FE")
                        //{
                        //    double _hrgHppNew = 0;
                        //    decimal persen = 0.01m;
                        //    _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);

                        //    if (_hargaFinal > 0)
                        //    {
                        //        if (_hrgHPP > 1)
                        //        {
                        //            if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) <= _hrgHPP)
                        //            {
                        //                KotakPesan.HargaJual("Harga dibawah Hpp");
                        //                dataGridView1[4, e.RowIndex].Value = _hargaFinal;
                        //                dataGridView1[9, e.RowIndex].Value = _hargaFinal;
                        //            }
                        //            else if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hargaFinal)
                        //            {
                        //                KotakPesan.HargaJual("Harga dibawah standar");
                        //                dataGridView1[4, e.RowIndex].Value = _hargaFinal;
                        //                dataGridView1[9, e.RowIndex].Value = _hargaFinal;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Hpp 0, Hubungi PSHO", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //            if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hargaFinal)
                        //            {
                        //                MessageBox.Show("Harga dibawah standar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //                dataGridView1[4, e.RowIndex].Value = _hargaFinal;
                        //                dataGridView1[9, e.RowIndex].Value = _hargaFinal;
                        //            }
                        //        }

                               
                        //    }
                        //    else
                        //    {
                        //        if (_hrgHPP > 1)
                        //        {
                        //            MessageBox.Show("Harga BMK 0, Hubungi PSHO", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //            dataGridView1[4, e.RowIndex].Value = 0;
                        //            dataGridView1[9, e.RowIndex].Value = 0;
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Harga BMK dan Hpp 0, Hubungi PSHO", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //            dataGridView1[4, e.RowIndex].Value = 0;
                        //            dataGridView1[9, e.RowIndex].Value = 0;
                        //        }
                        //    }


                        //}
                        //else
                        //{
                            double _hrgHppNew = 0;

                            if (_hrgHPP > 0)
                            {
                                if (Convert.ToDouble(dataGridView1[4, e.RowIndex].Value) < _hrgHppNew)
                                {
                                    KotakPesan.HargaBeli("Harga dibawah Hpp");
                                   
                                }
                            }
                            else
                            {
                                KotakPesan.HargaBeli("Hpp kosong !, segera hubungi manager anda untuk Update Hpp.");
                                dataGridView1[4, e.RowIndex].Value = _hargaFinal;
                                dataGridView1[9, e.RowIndex].Value = _hargaFinal;
                                return;
                            }
                       // }
                    }


                    if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD1"].Value) < 0 || Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD1"].Value) > 100)
                    {
                        MessageBox.Show("Discount antara 0 - 100", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //d1 = (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD1"].Value) / 100);
                        //d2 = (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD2"].Value) / 100);
                        //d3 = (Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvD3"].Value) / 100);
                        //potrp = Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvPot"].Value);
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

                        // hitung total

                        Int64 sum = 0;
                        kuantiti2 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt64(dataGridView1.Rows[i].Cells[9].Value);
                            kuantiti2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                        }

                        label12.Text = sum.ToString("N0");
                        lblqty.Text = kuantiti2.ToString("N0");
                        //getPromo();

                        //harga = Convert.ToDouble(dataGridView1.CurrentRow.Cells["GvHarga"].Value);

                        string Jenisdong, jenis2;
                        Jenisdong = txtTipeTransaksi.Text;
                        jenis2 = Tools.Left(Jenisdong, 1);
                        if (TxtNamaToko.Text != "ECERAN CASH")
                        {
                            if (jenis2 == "T" || jenis2 == "t")
                            {
                                _hrgAmbil = _hrgB;
                            }
                            if (jenis2 == "K" || jenis2 == "k")
                            {
                                _hrgAmbil = _hrgM;
                            }
                        }
                        else
                        {
                            _hrgAmbil = _hrgK;
                        }

                    }
                }
                else 
                {
                    dataGridView1[9, e.RowIndex].Value = Convert.ToDouble(dataGridView1[2, e.RowIndex].Value) * Convert.ToDouble(dataGridView1[4, e.RowIndex].Value);
                    Int64 sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt64(dataGridView1.Rows[i].Cells[9].Value);
                        kuantiti2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    }

                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                        
                }
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Error... : " +ex.ToString(), "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;      
            }
               
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                nRowGridView = dataGridView1.CurrentRow.Index;
                //MessageBox.Show(nRowGridView.ToString());

                //if (dataGridView1.SelectedCells.Count > 0 )
                //{
                //    if ( Convert.ToString(dataGridView1.SelectedCells[0].OwningRow.Cells["GvNamaBrg"].Value) == "")
                //    {
                //        LblKet.Text = "";
                //    }
                //    else
                //    {
                //        LblKet.Text = "\"" + dataGridView1.SelectedCells[0].OwningRow.Cells["GvNamaBrg"].Value.ToString() + "\" ";
                //    }
                //}
                //else
                //{
                //    LblKet.Text = " ";
                //}  
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
                if (!validateTambahBarang) return;
                TampilFormBarang();
            }
            if (e.KeyCode == Keys.Delete)
            {
                deleterows();
            }
        }

        private void BtnBarcode_Click(object sender, EventArgs e)
        {
            if (!validateTambahBarang) return;

            TampilBarcode(txtTipeTransaksi.Text.ToString());
        }

        private bool validateTambahBarang
        {
            get
            {
                bool falid = true;
                String pesan = "";
                if (lookupToko1.NamaToko == "")
                {
                    pesan += "- Anda Belum Melengkapi data Costumer\n";
                    falid = false;
                }
                
                if (lookup_Ekspedisi1.Expedisi == "")
                {
                    pesan += "- Anda Belum Memilih Ekspedisi\n";
                    falid = false;
                }
                if (lookupSales1.NamaSales == "")
                {
                    pesan += "- Anda Belum Memilih Sales\n";
                    falid = false;
                }
                if (!falid) MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return falid;
            }
        }
        private void TampilFormBarang()
        {
            
            POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this, txtTipeTransaksi.Text.ToString());
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void TampilFormBarang(DataTable dt, String Keyword)
        {

            POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this, dt, Keyword);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void TampilBarcode(string kelompok)
        {
            POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this, kelompok);
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

        private void txtTipeTransact_Leave(object sender, EventArgs e)
        {
            //if (txtTipeTransact.Text != "TG")
            //{
            //    txtTipeTransact.Text = "TG";
            //}
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

            //Nprint_ = Convert.ToInt32(dt.Rows[0]["Nprint"]);
            //Nprint_++;
            //dt.Rows[0]["Nprint"] = Nprint_.ToString();
            //this.dataGridNotaJual.RefreshEdit();
        }
  
        public void cekcetak()
        {
            int nprint = 0;
            //Penjualan.frmCetakNota ifrmDialog = new Penjualan.frmCetakNota(this, nprint);
            //ifrmDialog.ShowDialog();
            //if (ifrmDialog.DialogResult == DialogResult.OK)
            //{
            //    _nCetak = ifrmDialog.Result;
            //}
            //else
            //{
            //    return;
            //}
            CetakNotaTax();


        }
        
        public void CetakNotaTax()
        {
            DataTable dtAppSet;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "NOTA_JUAL"));
                dtAppSet = db.Commands[0].ExecuteDataTable();
            }

            if (dtAppSet.Rows.Count > 0)
            {
                _nCetak = int.Parse(dtAppSet.Rows[0]["Value"].ToString());
            }

            
            //if (_nCetak == 2 || _nCetak == 4)
            //{
            //    _ketNota = "RE";
            //}
            //else if (_nCetak == 5 || _nCetak == 6)
            //{
                _ketNota = string.Empty;
            //}
            //else if (_nCetak == 1 || _nCetak == 3)
            //{
            //    _ketNota = "CP";
            //}
            

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


                if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6 || _nCetak == 2)
                {
                    //printerName = "INKJET";
                    //Penjualan.frmNotaJualBrowser asd = new ISA.Trading.Penjualan.frmNotaJualBrowser();
                    //printer = Convert.ToString(asd.CekAppSetting(printerName));
                        //DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                        //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                        //if(_nCetak == 3)DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                }
                else
                {
                    //printerName = "DOTMATRIX";
                    //Penjualan.frmNotaJualBrowser asd = new ISA.Trading.Penjualan.frmNotaJualBrowser();
                    //printer = Convert.ToString(asd.CekAppSetting(printerName));
                    CetakNotaTaxRaw(dt);
                }


                //CetakNotaTaxRaw(dt);
                IncreamentNPrint();
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
            //string result = konfersi.Substring(c1 - 1, 1) + "\\" + konfersi.Substring(c2 - 1, 1)
            //                + "\\" + namaSales;
            string result =  namaSales;
            return result;
        }

        //public void DisplayReportNotaJual(DataTable dt, String ReportName)
        //{
        //    //string sExpedisi = dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();
        //    string Note = "";
        //    // Double Total = Convert.ToDouble(dt.Compute("Sum((CONVERT(HrgJual,'System.Double')) * (CONVERT(QtySuratJalan,'System.Double')))", ""));
        //    DataTable dtAppSet;
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
        //        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "CATATAN_NJ_1"));
        //        dtAppSet = db.Commands[0].ExecuteDataTable();
        //    }

        //    if (dtAppSet.Rows.Count > 0)
        //    {
        //        Note = dtAppSet.Rows[0]["Value"].ToString();
        //    }
        //    double Total = 0;
        //    double TotalDisc = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //=FormatNumber(Sum(
        //        //    (Fields!Disc.Value*Fields!QtySuratJalan.Value)
        //        //    +(Fields!Pot.Value*Fields!QtySuratJalan.Value)), 0)



        //        int QtySJ = Convert.ToInt32(dr["QtySuratJalan"]);
        //        Double HrgJual = Convert.ToDouble(dr["HrgJual"]);

        //        Double Disc = Convert.ToInt32(dr["Disc"]);
        //        Double Pot = Convert.ToInt32(dr["Pot"]);

        //        TotalDisc = TotalDisc + ((Disc * QtySJ) + (Pot * QtySJ));

        //        Total = Total + (QtySJ * HrgJual);
        //    }

        //    Double TotalAkumulasi = Total - TotalDisc;

        //    //if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
        //    //{
        //       string sExpedisi = string.Empty;
        //    //}
        //    DateTime tglSJ = Convert.ToDateTime(dt.Rows[0]["TglSuratJalan"].ToString());
        //    String tglSJFix = tglSJ.ToString("dd-MMM-yyyy");
        //    String tglSJBarcode = tglSJ.ToString("dd-MM-yyyy");
        //    String Barcode = (dt.Rows[0]["NoSuratJalan"].ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));
        //    //String tgl = GlobalVar.DateOfServer.ToString("dd-MMM-yyyy");            
        //    //construct parameter            
        //    List<ReportParameter> rptParams = new List<ReportParameter>();

        //    rptParams.Add(new ReportParameter("NomorDO", dt.Rows[0]["NoDO"].ToString()));
        //    rptParams.Add(new ReportParameter("NoSuratJalan", dt.Rows[0]["NoSuratJalan"].ToString()));
        //    rptParams.Add(new ReportParameter("TglSuratJalan", tglSJFix));
        //    rptParams.Add(new ReportParameter("HariKredit", dt.Rows[0]["HariKredit"].ToString()));
        //    rptParams.Add(new ReportParameter("Sales", GetSales(dt)));
        //    rptParams.Add(new ReportParameter("Expedisi", sExpedisi));
        //    rptParams.Add(new ReportParameter("NamaToko", dt.Rows[0]["NamaToko"].ToString().Trim()));
        //    rptParams.Add(new ReportParameter("Alamat", dt.Rows[0]["Alamat"].ToString().Trim()));
        //    rptParams.Add(new ReportParameter("Kota", dt.Rows[0]["Kota"].ToString()));
        //    rptParams.Add(new ReportParameter("Daerah", dt.Rows[0]["Daerah"].ToString()));
        //    rptParams.Add(new ReportParameter("WilID", dt.Rows[0]["WilID"].ToString()));
        //    rptParams.Add(new ReportParameter("KetNota", _ketNota));
        //    rptParams.Add(new ReportParameter("Total", Total.ToString()));
        //    rptParams.Add(new ReportParameter("TotalDisc", TotalDisc.ToString()));
        //    rptParams.Add(new ReportParameter("TotalAkumulasi", TotalAkumulasi.ToString()));
        //    rptParams.Add(new ReportParameter("Catatan3", dt.Rows[0]["Catatan3"].ToString()));
        //    rptParams.Add(new ReportParameter("Catatan4", dt.Rows[0]["Catatan4"].ToString()));
        //    rptParams.Add(new ReportParameter("BarcodeBar", "*" + Barcode + "*"));
        //    rptParams.Add(new ReportParameter("Barcode", Barcode));
        //    rptParams.Add(new ReportParameter("Note", Note));
        //    rptParams.Add(new ReportParameter("User", SecurityManager.UserName));
        //    rptParams.Add(new ReportParameter("DatetimeServer", GlobalVar.DateOfServer.ToString("dd-MM-yyyy")));
        //    //call report viewer
        //    //frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaJual.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
        //    frmReportViewer ifrmReport = new frmReportViewer("POS." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
        //    ifrmReport.Print();

        //    //ifrmReport.Show();
        //}

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

            //string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


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
            data.PROW(true, 1, "NPWP/PKP    : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sToko);
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
                sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10) + " ";
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
                + "                                                  Jumlah         Rp. "
                + nSumHrgBruto.ToString("#,###").PadLeft(13));            
            data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
            data.Eject();
            #endregion // end region detail

            data.SendToPrinter("notaJualTax.txt");
            //data.SendToPrinter("notaJualTax.txt",printer);  //buat pilih printer
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            nRowGridView = dataGridView1.CurrentRow.Index;
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

            //if (lookupToko1.NamaToko == "")
            //{
            //    MessageBox.Show("Mohon untuk diisikan nama tokonya terlebih dahulu");
            //    lookupToko1.Focus();
            //}
        }

        private void lookupSales1_Leave(object sender, EventArgs e)
        {
            if (lookupSales1.NamaSales == "")
            {

                MessageBox.Show("Mohon untuk diisikan nama salesnya terlebih dahulu");
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
                    if (kodebarang.Length == 13)
                    {
                        CekHargaBMK(kodebarang);
                        CekHargaKhusus(kodebarang);
                        GetHargaHpp(kodebarang);
                    }
                    else 
                    {
                        AmbilDetailJasa(kodebarang);
                    }
                }
                nRowGridView = dataGridView1.CurrentRow.Index;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtTipeTransact_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lookupSales1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ChangeRowGrid(false);
            }
        }

        private void ChangeRowGrid(bool enable)
        {
            GroupBox1.Enabled = enable;
            groupBox3.Enabled = enable;
            groupBox9.Enabled = enable;
            groupBox5.Enabled = enable;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                ChangeRowGrid(true);
            }
        }

        public void DisplayReportNotaJual(DataTable dt, String ReportName)
        {
            string sExpedisi = lookup_Ekspedisi1.Name;
            double Total = 0;
            double TotalDisc = 0;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    int QtySJ = Convert.ToInt32(dr["QtySuratJalan"]);
            //    Double HrgJual = Convert.ToDouble(dr["HrgJual"]);

            //    Double Disc = Convert.ToInt32(dr["Disc"]);
            //    Double Pot = Convert.ToInt32(dr["Pot"]);

            //    TotalDisc = TotalDisc + ((Disc * QtySJ) + (Pot * QtySJ));

            //    if (GlobalVar.Gudang == "2803")
            //    {
            //        Double x = QtySJ * HrgJual;
            //        Decimal dcash = Convert.ToDecimal(Tools.isNull(dr["Disc1"], "0").ToString());
            //        Decimal dcash2= Convert.ToDecimal(Tools.isNull(dr["Disc2"], "0").ToString()); 
            //        Double y = x - Convert.ToDouble(Math.Round(((dcash / 100) * Convert.ToDecimal(x)),0));
            //        Double z = y - Convert.ToDouble(Math.Round(((dcash2 / 100) * Convert.ToDecimal(y)), 0));
            //        Total = Total + Convert.ToDouble(z);
            //    }
            //    else
            //    {
            //        Total = Total + (QtySJ * HrgJual);
            //    }
            //}

            Double TotalAkumulasi = Total - TotalDisc;

            //if (lookup_Ekspedisi1.Name != "SAS")
            //{
            //    sExpedisi = string.Empty;
            //}
            DateTime tglSJ = (DateTime)TxtTGL.DateValue;
            String tglSJFix = tglSJ.ToString("dd-MMM-yyyy");
            String tglSJBarcode = tglSJ.ToString("dd-MM-yyyy");
            //string barcodeNota = (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));

            //dataGridNotaJual.SelectedCells[0].OwningRow.Cells["Barcode"].Value = barcodeNota;

            string jnstransaksi = txtTipeTransaksi.Text;
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("NomorDO", "CASH"));
            rptParams.Add(new ReportParameter("HariKredit", "0 HARI"));
            rptParams.Add(new ReportParameter("Sales", lookupSales1.NamaSales));
            rptParams.Add(new ReportParameter("Expedisi", lookup_Ekspedisi1.Expedisi));
            rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("Alamat", TxtAlamatToko.Text));
            rptParams.Add(new ReportParameter("Daerah", lookupToko1.Daerah));
            rptParams.Add(new ReportParameter("Kota", lookupToko1.Kota));
            rptParams.Add(new ReportParameter("Catatan4", TxtCat3.Text));
            rptParams.Add(new ReportParameter("NoSuratJalan", _NoNota));
            rptParams.Add(new ReportParameter("TglSuratJalan", tglSJFix));
            rptParams.Add(new ReportParameter("Total", label12.Text));
            rptParams.Add(new ReportParameter("NamaPerusahaan", GlobalVar.PerusahaanName ));
            rptParams.Add(new ReportParameter("AlamatPerusahaan", GlobalVar.PerusahaanAddress));
            rptParams.Add(new ReportParameter("KotaPerusahaan", GlobalVar.PerusahaanKota));
            rptParams.Add(new ReportParameter("TelpPerusahaan", GlobalVar.PerusahaanTelp));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("TglProses", "("+ GlobalVar.DateTimeOfServer.ToString("dd MMM yyyy HH:mm:ss") + ")"));
            
            //rptParams.Add(new ReportParameter("Catatan", ));
            //rptParams.Add(new ReportParameter("footer", ));

            //if (jnstransaksi == "T")
            //{
            //    frmReportViewer ifrmReport = new frmReportViewer("POS." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_NotaJual");
            //    ifrmReport.Print();
            //    //ifrmReport.Show();
            //}
            //else
            //{
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_NotaJual");
            ifrmReport.Print();
            //ifrmReport.Show();
            //}

            //ifrmReport.Show();
        }

        public void cetakNota()
        {
            try 
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _RowIDPos));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                //{
                //buat pilih printer
                //printerName = "INKJET";
                //printer = Convert.ToString(CekAppSetting(printerName));
                int JumlahRangkap = Convert.ToInt16(AppSetting.GetValue("DokumenNotaJual"));
                if (JumlahRangkap >= 4 || JumlahRangkap <= 0) { KotakPesan.Warning("Setting Dokumen DO belum dilakukan dengan benar. Mohon perbaiki nilai di APPSetting.", "Peringatan AppSetting"); return; }
                else DisplayReportNotaJual(dt, "rptCetakNotaJual");
                //if (JumlahRangkap >= 1) DisplayReportNotaJual(dt, "rptCetakNotaJual");
                //if (JumlahRangkap >= 2) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                //if (JumlahRangkap >= 3) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");

                //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                //}
                //else
                //{
                //    //buat pilih printer
                //    //printerName = "DOTMATRIX";
                //    //printer = Convert.ToString(CekAppSetting(printerName));

                //    CetakNotaRaw(dt);
                //}

                //IncreamentNPrint();
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
}