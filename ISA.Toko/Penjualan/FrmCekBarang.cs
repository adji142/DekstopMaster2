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

namespace ISA.Toko.Penjualan
{
    public partial class FrmCekBarang : ISA.Toko.BaseForm
    {
        bool CanInsertGridViewPos = true;
        public enum EnumPasif { All, Aktiv };
        double menit = 0, varmenit = 0;
        String _NoNota;
        double miliDetik = 0, varmilidetik = 0;
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
        int a, b;
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
        public FrmCekBarang()
        {
            InitializeComponent();
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
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, "0000000001"));
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

                if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0 && _hrg4 > 0)
                {
                //    lblBMK.Text = "1: " + _hrgB.ToString("N0") + "  2: " + _hrgM.ToString("N0") + "  3: " + _hrgK.ToString("N0") + "  4: " + _hrg4.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");

                }
                else
                {
                    KotakPesan.HargaJual("tidak mempunyai BMK Silakan hubungi Manager anda");
                   
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
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

            this.Cursor = Cursors.WaitCursor;
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
            else if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Data tidak ditemukan");
                this.Cursor = Cursors.Default;
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {

                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    int stokgudang = Convert.ToInt16(dr["StokAkhirGudang"]);


                    if (idbarang.Length == 13)
                    {
                        _barangID = Convert.ToString(dr["BarangID"]);
                        QTYPOS = 1;
                        _c1 = cab1;


                        if (_noACC != "BONUSAN")
                        {
                            GetHrgJual();
                            GetHrgBMKMessage();
                            GetHargaHpp(idbarang);
                        }
                        Txtbarangid.Text = dr["BarangID"].ToString();
                        TxtNamastok.Text = dr["NamaStok"].ToString();
                        TXTMerk.Text = dr["Merek"].ToString();
                        TxtStokAkhir.Text = dr["StokAkhirGudang"].ToString();
                        TxtRak1.Text = dr["KodeRak"].ToString();
                        TxtRak2.Text = dr["KodeRak1"].ToString();
                        TxtRak3.Text = dr["KodeRak2"].ToString();
                        Harga4.Text = _hrg4.ToString();
                        HargaB.Text = _hrgB.ToString();
                        HargaM.Text = _hrgM.ToString();
                        HargaK.Text = _hrgK.ToString();

                    }

                }
                this.Cursor = Cursors.Default;

            }


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

             this.Cursor = Cursors.WaitCursor;
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


                     if (idbarang.Length == 13)
                     {
                         _barangID = Convert.ToString(dr["BarangID"]);
                         QTYPOS = 1;
                         _c1 = cab1;


                         if (_noACC != "BONUSAN")
                         {
                             GetHrgJual();
                             GetHrgBMKMessage();
                             GetHargaHpp(idbarang);
                         }
                         //if (!CanInsertGridViewPos) { CanInsertGridViewPos = true; return; }
                         //dataGridView1.AllowUserToAddRows = true;
                         //dataGridView1.Rows.Add(1);
                         Txtbarangid.Text = dr["BarangID"].ToString();
                         TxtNamastok.Text = dr["NamaStok"].ToString();
                         TXTMerk.Text = dr["Merek"].ToString();
                         TxtStokAkhir.Text = dr["StokAkhirGudang"].ToString();
                         Harga4.Text = _hrg4.ToString();
                         HargaB.Text = _hrgB.ToString();
                         HargaM.Text = _hrgM.ToString();
                         HargaK.Text = _hrgK.ToString();

                     }

                 }
                 this.Cursor = Cursors.Default;

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

        private void TampilFormBarang(DataTable dt, String Keyword)
        {

            POS.FrmBarcode ifrmChild = new POS.FrmBarcode(this, dt, Keyword);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

       
        private void GetHrgBMKMessage()
        {
            if (_noACC != "BONUSAN")
            {

                GetHrgBMK();


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

                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, "0000000001"));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, Tools.Left("TUN", 2)));
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

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                AmbilBarang2();

            }
        }

        private void FrmCekBarang_Load(object sender, EventArgs e)
        {
            TxtBarcode.Focus();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HargaM_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
