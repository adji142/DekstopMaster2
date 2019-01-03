using System;
using System.Collections;
using System.Collections.Generic;
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


namespace ISA.Trading.DO
{
    public partial class FrmDO2803 : ISA.Controls.BaseForm
    {
        double menit = 0, varmenit = 0;
        double miliDetik = 0, varmilidetik = 0;
        string initCab = GlobalVar.CabangID;
        string initgudang = GlobalVar.Gudang;
        string docNoDO = "NOMOR_DO";
        string docNoDO1 = "NOMOR_DO";
        string docNoDOPT = "NOMOR_DO_TAX";
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowid, _headerID, _rowIDDetail;
        string noAccPiutang = "", noAccPusat = "";
        object _TglACCPiutang, _TglReorder;
        int _nCetak;
        string HtrId;
        string cab1;
        string cab2;
        string cab3;
        string gudang;
        int hari = 0;
        int nprint = 0;
        int nRowGridView = 0;
        string StatausToko_ = string.Empty;

        // variabel dalam toko
        string kodetoko;
        string statustoko, stsTk, _stsToko;
        string alamatkirim;
        string kotatoko;
        string flagkg;

        //variabel dalam sales
        string idsales;

        DateTime tanggal;
        int total;
        int a, b;
        double kuantiti, kuantiti2;
        double harga, d1, d2, d3, potrp;
        double jumlah, jumnet, jumnetakhir, jumdis, HargaBersih, Hd1, Hd2, Hd3;

        //variabel simpan detail
        string _htrID;
        DataTable dtDODetail, dtDO;
        Guid _notaHeaderRowID;
        string _noACC = "AUTOACC";
        string _noACCHarga = "HARGA";
        bool _isAllBonus = false;
        string _JenTr = "";
        string _diBawahHarga = "";
        string _notaHeaderRecID;
        string _notaDetailRecID = string.Empty;
        //variabel nota
        double _rpSisaACCPiutang, _jmlHrgNota, _rpACCPiutang;
        string _transType;
        string _Cat1 = string.Empty, _Cat2 = string.Empty, _Cat3 = string.Empty,
                _Cat4 = string.Empty, _Cat5 = string.Empty, _CatD = string.Empty;
        int _hariKredit;

        //variabel gethitunghrgjual
        string _barangID;
        DateTime _tglDO, _tglAkhir;
        string _kodeToko;
        string _c1;
        double HrgJualBMK_;
        string QTYPOS;
        int QTYPOS1;
        double _hrgB = 0,_hrgM = 0,_hrgK = 0,_hrgJual = 0,_hrgAkhir = 0,_hrgHPP = 0, 
               _hargaFinal = 0,_hrgNet = 0,_ovd = 0,_gtolak = 0,
               _Het = 0,_dcash = 0,_dcash2 = 0,_dcash3 = 0, HrgNetto = 0;

        //variable kelompok ambil barang
        string kelompok;
        DataTable dtPromo, dtpromotetap, dtbarang;
        //DataTable dtPromo = new DataTable();
        private bool _isEsc = true;

        DataTable dtAGx;
        DataTable dtAG;
        string JenisTransaksiKG;
        string JenisTransaksiTR;
        double JumlahDo = 0;
        double JmlQty = 0;
        Guid _doID;
        Guid _doDetailID;

        //variable ID POS from AG
        string AGRecordID = "";
        string AGTransactionID = "";
        int _JS; 

        public FrmDO2803(DataTable dtag)
        {
            InitializeComponent();
            if (GlobalVar.Gudang == "2803")
            {
                dtAGx = dtag;
                //UpdateEntryDo(dtAGx);
            }
        }

        public FrmDO2803(Form caller, DataTable dt_, string gudang_)
        {
            this.Caller = caller;
            InitializeComponent();
        }


        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

        private void FrmDO2803_Load(object sender, EventArgs e)
        {
            txtPlafon.Text = string.Format("{0:N0}", 0);
            txtpiutang.Text = string.Format("{0:N0}", 0);
            txtgit.Text = string.Format("{0:N0}", 0);
            txtgiro.Text = string.Format("{0:N0}", 0);
            txttolak.Text = string.Format("{0:N0}", 0);
            txtoverdue.Text = string.Format("{0:N0}", 0);
            txtoverduefb.Text = string.Format("{0:N0}", 0);
            txtoverduefx.Text = string.Format("{0:N0}", 0);
            txtsisa.Text = string.Format("{0:N0}", 0);

            //this.Text = "Delivery Order";
            menit = 0; varmenit = 0;
            miliDetik = 0; varmilidetik = 0;

            total = 0;
            label12.Text = Convert.ToString(total);
            kodetoko = "";
            idsales = "";
            tanggal = DateTime.Now;
            string tgl = tanggal.ToString("dd/MM/yyyy");
            TxtTGL.Text = Convert.ToString(tgl);
            kuantiti2 = 0;
            lblqty.Text = Convert.ToString(kuantiti2);

            #region tampil hari dan tanggal
            CultureInfo culture;
            culture = new CultureInfo("id-ID");
            string tgl_label = System.DateTime.Today.ToString("dddd, dd MMMM yyyy", culture);
            string tgl_Rq = System.DateTime.Today.ToString("dd/MM/yyyy", culture);
            label25.Text = Convert.ToString(tgl_label);
            txtTglrq.Text = Convert.ToString(tgl_Rq);
            #endregion

            //txtCab1.Text = GlobalVar.CabangID;
            txtCab1.Text = GlobalVar.Gudang;

            if (Tools.Left(GlobalVar.Gudang, 1) != "9")
            {
                lookupGudang1.Enabled = false;
                lookupGudang1.GudangID = GlobalVar.Gudang;
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dtStok = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, GlobalVar.Gudang));
                        dtStok = db.Commands[0].ExecuteDataTable();
                        if (dtStok.Rows.Count == 1)
                            lookupGudang1.NamaGudang = Tools.isNull(dtStok.Rows[0]["NamaGudang"], "").ToString();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                lookupGudang1.Enabled = true;
            }


            if (GlobalVar.Gudang == "2803")
            {
                this.lookupSales1.Enabled = true;   // false;
                this.lookupJenisTransaksi1.Enabled = false;
                this.textBox10.Enabled = false;
                this.textBox11.Enabled = false;
                this.txtTglrq.Enabled = false;
                this.CBShift.Enabled = false;
                this.txtNorq.Enabled = false;

                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dtSls = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_Sales_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, "VIA"));
                        db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, "28"));

                        dtSls = db.Commands[0].ExecuteDataTable();
                        if (dtSls.Rows.Count == 1)
                        {
                            lookupSales1.NamaSales = Tools.isNull(dtSls.Rows[0]["NamaSales"], "").ToString();
                            lookupSales1.SalesID = Tools.isNull(dtSls.Rows[0]["SalesID"], "").ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
            else
            {
                this.lookupSales1.Enabled = true;
                this.lookupJenisTransaksi1.Enabled = true;
                this.textBox10.Enabled = true;
                this.textBox11.Enabled = true;
                this.txtTglrq.Enabled = true;
                this.CBShift.Enabled = true;
                this.txtNorq.Enabled = true;
            }


            #region Data Detail

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

            if (GlobalVar.Gudang == "2803")
                CBOEkspedisi.Enabled = false;
            else
                CBOEkspedisi.Enabled = true;

            #endregion


            // pengaturan index datagridview
            DataGridDO.Columns["gVplu"].DisplayIndex = 0;
            DataGridDO.Columns["GvNamaBrg"].DisplayIndex = 1;
            DataGridDO.Columns["GvQTy"].DisplayIndex = 2;
            DataGridDO.Columns["GvSat"].DisplayIndex = 3;
            DataGridDO.Columns["GvHarga"].DisplayIndex = 4;
            DataGridDO.Columns["GvD1"].DisplayIndex = 5;
            DataGridDO.Columns["GvD2"].DisplayIndex = 6;
            DataGridDO.Columns["GvD3"].DisplayIndex = 7;
            DataGridDO.Columns["GvHrgNet1"].DisplayIndex = 8;
            DataGridDO.Columns["GvPot"].DisplayIndex = 9;
            DataGridDO.Columns["GvHjual"].DisplayIndex = 10;
            DataGridDO.Columns["GvJumlah"].DisplayIndex = 11;

            //DataGridDO.Columns["gVplu"].DisplayIndex = 0;
            //DataGridDO.Columns["GvNamaBrg"].DisplayIndex = 1;
            //DataGridDO.Columns["GvQTy"].DisplayIndex = 2;
            //DataGridDO.Columns["GvSat"].DisplayIndex = 3;
            //DataGridDO.Columns["GvHarga"].DisplayIndex = 4;
            //DataGridDO.Columns["GvD1"].DisplayIndex = 5;
            //DataGridDO.Columns["GvD2"].DisplayIndex = 6;
            //DataGridDO.Columns["GvD3"].DisplayIndex = 7;
            //DataGridDO.Columns["GvPot"].DisplayIndex = 8;
            //DataGridDO.Columns["GvHjual"].DisplayIndex = 9;
            //DataGridDO.Columns["GvJumlah"].DisplayIndex = 10;

            _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
            _isEsc = true;

            if (GlobalVar.Gudang == "2803")
            {
                UpdateEntryDo(dtAGx);
            }

            lookupToko1.Focus();
        }


        #region Kumpulan Function

        private bool validation()
        {
            if (GlobalVar.Gudang != "2803")
            {
                string[, ,] cek = {{ 
                                {TxtAlamatToko.Text.ToString(),"isNull","Alamat Toko belum diisi.."}
                                ,{TxtNamaToko.Text.ToString(),"isNull","Nama Toko belum diisi.."}
                                ,{TxtKota.Text.ToString(), "isNull","Kota belum diisi.."}
                                ,{TxtTGL.Text.ToString(),"isNull", "Tanggal belum diisi.."}
                                ,{lookupSales1.NamaSales.ToString(),"isNull", "Pramuniaga belum diisi.."}
                                ,{txtNorq.Text.ToString(),"isNull","No RQ belum diisi.."}
                                ,{lookupGudang1.GudangID.ToString(),"isNull","Cab2 belum diisi.."}
                                
                             }};
                return Class.validation.error(cek);
            }
            else
            {
                string[, ,] cek = {{ 
                                {TxtAlamatToko.Text.ToString(),"isNull","Alamat Toko belum diisi.."}
                                ,{TxtNamaToko.Text.ToString(),"isNull","Nama Toko belum diisi.."}
                                ,{TxtKota.Text.ToString(), "isNull","Kota belum diisi.."}
                                ,{TxtTGL.Text.ToString(),"isNull", "Tanggal belum diisi.."}
                                ,{lookupSales1.NamaSales.ToString(),"isNull", "Pramuniaga belum diisi.."}
                                ,{lookupGudang1.GudangID.ToString(),"isNull","Cab2 belum diisi.."}
                                
                             }};
                return Class.validation.error(cek);
            }

            //return Class.validation.error(cek);
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
                Error.LogError(ex);
            }
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
                //a = 0;
                //for (a = 0; a < DataGridDO.Rows.Count - 1; ++a)
                //{
                //    string kdTOKO = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));

                dtToko = db.Commands[0].ExecuteDataTable();
                //}
            }
            if (dtToko.Rows.Count >= 0)
            {
                if (dtToko.Rows[0]["Cabang2"].ToString().Trim() == "PT")

                //if (dtToko.ToString().Trim() == "PT")
                {
                    result = true;
                    docNoDO = docNoDOPT;
                }
                else
                {
                    result = false;
                    docNoDO = docNoDO1;
                }
            }

            //if (dtDO.Rows[0]["Cabang1"].ToString() != dtDO.Rows[0]["Cabang2"].ToString() && Tools.Left(dtDO.Rows[0]["Cabang1"].ToString(), 1) == "9")
            if (cab1 != cab2 && Tools.Left(cab1.ToString(), 1) == "9")
            {
                result = false;
                docNoDO = docNoDO1;
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


        #endregion



        private void UpdateEntryDo(DataTable dt)
        {
            dtAG = dt;
            int nRowIndex = 0;

            if (dt != null)
            {
                txtNorq.Text = Tools.isNull(dtAG.Rows[0]["NoAg"], "AG2803").ToString();
                AGTransactionID = Tools.isNull(dtAG.Rows[0]["TransactionID"], "").ToString();

                _JS = Convert.ToInt32(Tools.isNull(dtAG.Rows[0]["JS"], "0").ToString());
                if (_JS > 0)
                {
                    txtJS.Text = _JS.ToString();
                }



                //using (Database db = new Database())
                //{
                //    DataTable dtc = new DataTable();
                //    db.Commands.Add(db.CreateCommand("usp_GetRowIDDO"));
                //    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, AGTransactionID));
                //    dtc = db.Commands[0].ExecuteDataTable();
                //    if (dtc.Rows.Count > 0)
                //    {
                //        MessageBox.Show(Tools.isNull(dtc.Rows[0]["RowID"], "").ToString());
                //        return;
                //    }
                //}


                foreach (DataRow dr in dtAG.Rows)
                {
                    DataGridDO.Rows.Add(1);
                    DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["KodeBarang"];
                    DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    DataGridDO.Rows[nRowIndex].Cells[2].Value = Convert.ToInt32(Tools.isNull(dr["QtyKirim"], "0").ToString());
                    DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];
                    DataGridDO.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(Tools.isNull(dr["hjual"], "0").ToString());
                    DataGridDO.Rows[nRowIndex].Cells[5].Value = Convert.ToDouble(Tools.isNull(dr["disc1"], "0").ToString());
                    DataGridDO.Rows[nRowIndex].Cells[6].Value = Convert.ToDouble(Tools.isNull(dr["disc2"], "0").ToString());
                    DataGridDO.Rows[nRowIndex].Cells[8].Value = Convert.ToDouble(0);
                    DataGridDO.Rows[nRowIndex].Cells[9].Value = Convert.ToDouble(0);
                    DataGridDO.Rows[nRowIndex].Cells[10].Value = Convert.ToDouble(0);
                    DataGridDO.Rows[nRowIndex].Cells[11].Value = Convert.ToDouble(0);

                    Double nHjual = Convert.ToDouble(Tools.isNull(dr["hjual"], "0").ToString());
                    Double nDisc1 = Convert.ToDouble(Tools.isNull(dr["disc1"], "0").ToString());
                    Double nDisc2 = Convert.ToDouble(Tools.isNull(dr["disc2"], "0").ToString());
                    Double nDisc3 = 0;
                    Double potrp = 0;
                    Int32 nQty = Convert.ToInt32(Tools.isNull(dr["QtyKirim"], "0").ToString());

                    Double nHrg = Hitnet3Dis(nHjual, nDisc1, nDisc2, nDisc3);
                    Double nNet = Hitnet3Dis(nHjual, nDisc1, nDisc2, nDisc3) - potrp;
                    Double nJumlah = nNet * nQty;

                    double ndisc = (nNet * nQty) - nJumlah;
                    DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                    DataGridDO.Rows[nRowIndex].Cells[9].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                    DataGridDO.Rows[nRowIndex].Cells[11].Value = nJumlah;

                    nRowIndex += 1;
                    JumlahDo += nJumlah;
                    JmlQty += nQty;
                }
                label12.Text = JumlahDo.ToString("N0");
                lblqty.Text = JmlQty.ToString("N0");
            }
            else
            {
                AGTransactionID = Tools.CreateFingerPrint();
            }
        }


        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            try
            {
                kodetoko = lookupToko1.KodeToko;
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko;

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

                #region StatusToko
                //if (stsTk == "" || stsTk == null)
                //{
                //    MessageBox.Show("Toko belum ada statusnya");
                //    statustoko = "";
                //    alamatkirim = "";
                //    TxtNamaToko.Text = "";
                //    TxtAlamatToko.Text = "";
                //    TxtKota.Text = "";
                //    TxtIDWil.Text = "";

                //    //statustoko = Convert.ToString(stsToko);
                //    alamatkirim = "";
                //    kotatoko = "";
                //    txtstatus.Text = "";

                //    return;
                //}
                #endregion

                TxtNamaToko.Text = lookupToko1.NamaToko;
                TxtAlamatToko.Text = lookupToko1.Alamat;
                TxtKota.Text = lookupToko1.Kota;
                TxtIDWil.Text = lookupToko1.WilID;

                statustoko = Convert.ToString(stsToko);
                alamatkirim = lookupToko1.Alamat;
                kotatoko = lookupToko1.Kota;

                GetFlagKg(kodetoko);

                if (GlobalVar.Gudang == "2803")
                {
                    flagkg = "KG";
                    DataTable dtj = new DataTable();
                    if (Tools.isNull(lookupToko1.KodeToko, "").ToString() != "")
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_GetJangkaWaktuKredit"));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                                dtj = db.Commands[0].ExecuteDataTable();
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
                    if (dtj.Rows.Count > 0)
                    {
                        TxtJW.Text = Tools.isNull(dtj.Rows[0]["JangkaWaktuKredit"], "").ToString();
                    }
                    else
                    {
                        int jw = 7;
                        TxtJW.Text = jw.ToString();
                    }
                    txtJS.Text = lookupToko1.HariSales.ToString();
                    txtjx.Text = lookupToko1.HariKirim.ToString();

                    //_JS = Convert.ToInt32(Tools.isNull(dtAG.Rows[0]["JS"], "0").ToString());
                    if (_JS > 0)
                    {
                        txtJS.Text = _JS.ToString();
                    }

                }

                if (stsToko == null)
                {
                    stsToko = "";
                }
                _stsToko = Tools.isNull(stsToko, "").ToString();
                txtstatus.Text = _stsToko.ToString();

                if (GlobalVar.Gudang != "2803")
                {
                    lookupJenisTransaksi1.Focus();
                }
                else
                {
                    DataGridDO.Focus();

                    #region Plafon
                    double plafonToko = TokoPlafon.Plafon(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    if (plafonToko > 0)
                    {
                        txtPlafon.Text = string.Format("{0:N0}", plafonToko);

                        BtnSearch.Enabled = true;
                        TxtBarcode.Enabled = true;
                    }
                    else
                    {
                        if (GlobalVar.Gudang != "2803")
                        {
                            if (lookupJenisTransaksi1.IdTr.Substring(0, 1) == "K")
                                MessageBox.Show("Toko " + kodetoko + " Belum Punya Plafon /n Hubungi PSHO");

                            BtnSearch.Enabled = false;
                            TxtBarcode.Enabled = false;
                        }
                    }
                    #endregion

                    #region Piutang
                    double piutangToko = TokoPlafon.Piutang(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);

                    txtpiutang.Text = string.Format("{0:N0}", piutangToko);
                    #endregion

                    #region GIT
                    double gitToko = TokoPlafon.GIT(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);

                    txtgit.Text = string.Format("{0:N0}", gitToko);
                    #endregion

                    #region Giro
                    double giroToko = TokoPlafon.Giro(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);

                    txtgiro.Text = string.Format("{0:N0}", giroToko);
                    #endregion

                    #region Giro Tolak
                    double giroTolakToko = TokoPlafon.GiroTolak(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);

                    txttolak.Text = string.Format("{0:N0}", giroTolakToko);
                    #endregion

                    #region Sisa Plafon
                    double sisaPlafonToko = TokoPlafon.SisaPlafon(plafonToko, piutangToko, gitToko, giroToko, giroTolakToko);

                    txtsisa.Text = string.Format("{0:N0}", sisaPlafonToko);
                    #endregion

                    #region Piutang Overdue
                    double overdue = TokoOverdue.Overdue(lookupToko1.KodeToko);

                    txtoverdue.Text = string.Format("{0:N0}", overdue);
                    #endregion

                    #region Piutang Overdue Non Agen
                    double overdueFB = TokoOverdue.OverdueFB(lookupToko1.KodeToko);

                    txtoverduefb.Text = string.Format("{0:N0}", overdueFB);
                    #endregion

                    #region Piutang Overdue Agen
                    double overdueFX = TokoOverdue.OverdueFX(lookupToko1.KodeToko);

                    txtoverduefx.Text = string.Format("{0:N0}", overdueFX);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


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

        private void lookupToko1_Load(object sender, EventArgs e)
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

            if (menit >= 60)
            {
                varmenit = menit / 60;
            }
        }

        private object val(object p)
        {
            throw new NotImplementedException();
        }


        private void TxtPLU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //int nRowIndex = DataGridDO.Rows.Count - 1;
                //this.Cursor = Cursors.WaitCursor;
                //DataTable dt = new DataTable();

                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_PLU_SEARCH_BARCODE"));
                //    db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, TxtPLU.Text));
                //    dt = db.Commands[0].ExecuteDataTable();
                //}
                //if (dt.Rows.Count == 0)
                //{
                //    MessageBox.Show("Barang tidak ada atau HPP Barang = Null", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        string idbarang = Convert.ToString(dr["BarangID"]);
                //        string namabarang = Convert.ToString(dr["nama_stok"]);
                //        for (a = 0; a < DataGridDO.Rows.Count - 1; ++a)
                //        {
                //            string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                //            if (idbarang == idbarangcell)
                //            {
                //                MessageBox.Show("'" + namabarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //                this.Cursor = Cursors.Default;
                //                return;
                //            }
                //        }
                //        DataGridDO.Rows.Add(1);
                //        DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                //        DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["nama_stok"];
                //        DataGridDO.Rows[nRowIndex].Cells[2].Value = 1;
                //        DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["satjual"];
                //        DataGridDO.Rows[nRowIndex].Cells[4].Value = Convert.ToInt32(dr["hpp"]);
                //        DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                //        DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                //        DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                //        DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;
                //        DataGridDO.Rows[nRowIndex].Cells[9].Value = Convert.ToInt32(dr["hpp"]);
                //    }
                //    // format
                //    // hitung total
                //    int sum = 0;
                //    kuantiti2 = 0;
                //    for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                //    {
                //        sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[9].Value);
                //        kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                //    }
                //    label12.Text = sum.ToString("N0");
                //    lblqty.Text = kuantiti2.ToString("N0");
                //    TxtPLU.Text = "";
                //    DataGridDO.Rows[nRowIndex].Cells[2].Selected = true;
                //    //}
                //}
                //this.Cursor = Cursors.Default;
            }
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


        public void Save_DONOTA(object sender, EventArgs e)
        {
            if (validation())
            {
                idsales = lookupSales1.SalesID;
                _JenTr = lookupJenisTransaksi1.IdTr;

                IsTokoPT();
                int lebar;
                string depan;
                int iNomor;
                string belakang;
                if (docNoDO == "NOMOR_DO")
                {
                    DataTable dtNum = Tools.GetGeneralNumerator(docNoDO, Tools.GeneralInitial());
                    lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    depan = Tools.GeneralInitial();
                    belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;
                }
                else
                {
                    depan = GetInitialPT();
                    DataTable dtNum = Tools.GetGeneralNumerator(docNoDO, depan);
                    lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;
                }
                string strNoDO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                LblNoDO.Text = strNoDO;

                //Get Nomor RQ    
                int lebarRq = 0;
                string depanRq = "";
                int iNomorRq = 0;
                string belakangRq = "";
                string strNoRq = "";

                //proses Do
                if (formMode == enumFormMode.New)
                {
                    HtrId = Tools.CreateFingerPrint();
                    cab1 = initCab;
                    gudang = initgudang;
                    if (string.IsNullOrEmpty(lookupGudang1.GudangID) || lookupGudang1.GudangID == initgudang)
                    {
                        cab2 = initgudang;
                        cab3 = "";
                    }
                    else
                    {
                        cab2 = lookupGudang1.GudangID;
                        cab3 = lookupGudang1.GudangID.Substring(2,2);
                    }
                }

                //-------------    proses simpan ke HeaderDO, DetailDO    -------------------------
                try
                {
                    if (formMode == enumFormMode.New)
                    {
                        using (Database db = new Database())
                        {
                            _rowid = Guid.NewGuid();
                            _doID = _rowid;
                            string _noAccPiutang = string.Empty, _noAccPusat = string.Empty, _Catatan5 = string.Empty;

                            if (GlobalVar.Gudang == "2803")
                            {
                                _noAccPiutang = "FULLACC";
                                _noAccPusat = "AUTOACC";
                                _Catatan5 = "ACC";
                                if (AGTransactionID != "")
                                {
                                    HtrId = AGTransactionID;
                                }
                            }

                            if (GlobalVar.Gudang == "2823" && lookupJenisTransaksi1.IdTr == "KG")
                            {
                                //_noAccPiutang = "FULLACC";
                                _noAccPusat = "AUTOACC";
                                //_Catatan5 = "ACC";
                                //HtrId = AGTransactionID;
                            }

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowid));
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cab2));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cab3));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, txtNorq.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, txtTglrq.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, strNoDO));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, _noAccPusat));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, _noAccPiutang));
                            db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, Convert.ToInt32(Tools.isNull(TxtJW.Text,"0").ToString())));
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
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, _JenTr));
                            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, CBOEkspedisi.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, Convert.ToInt32(Tools.isNull(hari,"0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, Convert.ToInt32(Tools.isNull(txtJS.Text,"0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, _Catatan5));
                            db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, string.Empty));
                            double RpPiutangTerakhir = Convert.ToDouble(txtpiutang.Text) + Convert.ToDouble(txtgiro.Text);
                            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, JumlahDo));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, Convert.ToDouble(txtsisa.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, RpPiutangTerakhir));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, Convert.ToDouble(txttolak.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, Convert.ToDouble(txtoverdue.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, "1"));
                            
                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, Convert.ToInt32(Tools.isNull(iNomor,"0").ToString())));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                        }


                        if (GlobalVar.Gudang == "2803")
                        {
                            int k; int l;
                            k = 0; l = 0;
                            _notaHeaderRowID = Guid.NewGuid();
                            _notaHeaderRecID = Tools.CreateShortFingerPrint(k);
                            _notaDetailRecID = string.Empty;
                            this.Cursor = Cursors.WaitCursor;

                            string temp = string.Empty;
                            string kodeNota = "";
                            string nomorNota = "";
                            string PTpattern = "KH,TH,KL,TL";
                            string _doHtrID = HtrId;
                            string depanNota = "";
                            string belakangNota = "";

                            int iNomorNota;
                            int lebarNota;
                            int lebarOriginal = 0;
                            int ctr = 0;
                            int lastCtr = 0;
                            int ctrBef = 0;
                            DataTable dtNum;
                            int countRows = 0;

                            if (IsTokoPT())
                            {
                                string transType = _transType;
                                if (PTpattern.Contains(transType))
                                {
                                    kodeNota = "NOMOR_NOTA_TAX_2";
                                }
                                else
                                {
                                    kodeNota = "NOMOR_NOTA_TAX";
                                }
                                depanNota = GetInitialPT();
                            }
                            else
                            {
                                if (Tools.Left(cab1, 1) == "9")
                                {
                                    kodeNota = "NOMOR_NOTA_PS";
                                }
                                else
                                {
                                    kodeNota = "NOMOR_NOTA";
                                }

                                depanNota = Tools.GeneralInitial();
                            }

                            _doHtrID = AGTransactionID;

                            dtNum = Tools.GetGeneralNumerator(kodeNota, depanNota);
                            lebarOriginal = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                            lebarNota = lebarOriginal;
                            iNomorNota = int.Parse(dtNum.Rows[0]["Nomor"].ToString());

                            belakangNota = dtNum.Rows[0]["Belakang"].ToString();
                            iNomor++;
                            nomorNota = Tools.FormatNumerator(iNomorNota, lebarNota, depanNota, belakangNota);

                            using (Database dbn = new Database())
                            {
                                dbn.Commands.Add(dbn.CreateCommand("usp_NotaPenjualan_INSERT"));

                                dbn.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                                dbn.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaHeaderRecID)); //_notaHeaderRecID));
                                dbn.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _doID));
                                dbn.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _doHtrID));
                                dbn.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, nomorNota));//Tools.GetGeneralNumerator("NOMOR_NOTA").Rows[0].ToString()));
                                dbn.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, SqlDateTime.Null));
                                dbn.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, DateTime.Today));
                                dbn.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                                dbn.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                                dbn.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, gudang));
                                dbn.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cab2));
                                dbn.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, cab3));
                                dbn.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, idsales));
                                dbn.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                                dbn.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, alamatkirim));
                                dbn.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, TxtKota.Text));
                                dbn.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                                dbn.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, "ACC"));
                                dbn.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                dbn.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                                dbn.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _JenTr));
                                dbn.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, Convert.ToInt32(Tools.isNull(TxtJW.Text,"0").ToString())));
                                dbn.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, Convert.ToInt32(Tools.isNull(hari,"0").ToString())));
                                dbn.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, Convert.ToInt32(Tools.isNull(txtJS.Text,"0").ToString())));
                                dbn.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, ""));
                                dbn.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                dbn.Commands.Add(dbn.CreateCommand("usp_Numerator_UPDATE"));
                                dbn.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, kodeNota));
                                dbn.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                                dbn.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                                dbn.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                                dbn.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebarOriginal));
                                dbn.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                dbn.BeginTransaction();
                                dbn.Commands[0].ExecuteNonQuery();
                                dbn.Commands[1].ExecuteNonQuery();
                                dbn.CommitTransaction();
                            }
                        }

                        Guid _headerID;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_GetRowIDDO"));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();
                            _headerID = (Guid)dt.Rows[0]["RowID"];
                        }

                        string noAcc = string.Empty;
                        int counter = 0;

                        for (a = 0; a < DataGridDO.Rows.Count; ++a)
                        {
                            double potongan = 0;
                            _rowIDDetail = Guid.NewGuid();
                            _doDetailID = _rowIDDetail;
                            string _recID = Tools.CreateFingerPrint();
                            string barangID;
                            int QTY, qtyperbarang;

                            double HPP, disc1, disc2, disc3;
                            barangID = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                            QTY = Convert.ToInt32(kuantiti2);
                            qtyperbarang = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                            HPP = Convert.ToDouble(DataGridDO.Rows[a].Cells[4].Value);
                            disc1 = Convert.ToDouble(DataGridDO.Rows[a].Cells[5].Value);
                            disc2 = Convert.ToDouble(DataGridDO.Rows[a].Cells[6].Value);
                            disc3 = Convert.ToDouble(DataGridDO.Rows[a].Cells[7].Value);
                            potongan = Convert.ToInt32(DataGridDO.Rows[a].Cells[9].Value);

                            using (Database db = new Database())
                            {
                                CekBarangID(barangID);

                                #region potongan
                                //if (barangID.Substring(0, 3).Equals("FXB"))
                                //{
                                //    potongan = 1;
                                //}
                                //if (_noACC.Equals("BONUSAN"))
                                //{
                                //    potongan = 1;
                                //}
                                #endregion

                                noAcc = _noACC;
                                if (GlobalVar.Gudang != "2803")
                                {
                                    if (DataGridDO.Rows[a].Cells["GvNoAcc"].Value != null)
                                    {
                                        if (DataGridDO.Rows[a].Cells["GvNoAcc"].Value.ToString() == _noACCHarga)
                                        {
                                            noAcc = _noACCHarga;
                                        }
                                    }
                                }
                                else
                                {
                                    if (GlobalVar.Gudang == "2803")
                                    {
                                        HtrId = AGTransactionID;
                                        noAcc = "AUTOACC";
                                    }
                                }

                                db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDDetail));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowid));
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
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, noAcc));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nboPrint", SqlDbType.VarChar, ""));

                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();


                                if (GlobalVar.Gudang == "2803")
                                {
                                    string _notaDetailRecID = Tools.CreateShortFingerPrint(counter + 1);

                                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_INSERT"));
                                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                                    db.Commands[1].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                                    db.Commands[1].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaDetailRecID));
                                    db.Commands[1].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _notaHeaderRecID));
                                    db.Commands[1].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _doID));
                                    db.Commands[1].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, _doDetailID));
                                    db.Commands[1].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                                    db.Commands[1].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                    db.Commands[1].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, qtyperbarang));
                                    db.Commands[1].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, HPP));
                                    db.Commands[1].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, disc1));
                                    db.Commands[1].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, disc2));
                                    db.Commands[1].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, disc3));
                                    db.Commands[1].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                                    db.Commands[1].Parameters.Add(new Parameter("@pot", SqlDbType.Money, potongan));
                                    db.Commands[1].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, 0));
                                    db.Commands[1].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, 0));
                                    db.Commands[1].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, 0));
                                    db.Commands[1].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, 0));
                                    db.Commands[1].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, ""));
                                    db.Commands[1].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                                    db.Commands[1].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                    db.Commands[1].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, ""));
                                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[1].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, ""));
                                    db.Commands[1].ExecuteNonQuery();

                                }
                            }
                            counter++;

                            #region recalculate
                            if (lookupGudang1.GudangID.Substring(0, 1) != "9")
                            {
                                Recalculate(barangID, gudang);
                            }
                            this.Cursor = Cursors.Default;
                            #endregion

                            #region umur piutang
                            //// Cari umur piutang > 90 hari berdasarkan kode sales
                            //DataTable dtPiutangSales = new DataTable();
                            //using (Database db = new Database())
                            //{
                            //    db.Commands.Add(db.CreateCommand("usp_KartuPiutang_LIST_KodeSales"));
                            //    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, idsales));
                            //    dtPiutangSales = db.Commands[0].ExecuteDataTable();
                            //}
                            #endregion


                            int bagianPin = 0;

                            if (_isAllBonus)
                            {
                                bagianPin = PinId.Bagian.Bonus;
                            }
                            else if (Convert.ToDouble(txtoverduefx.Text) > 0)
                            {
                                bagianPin = -1;
                            }
                            else if (Convert.ToDouble(txtoverduefb.Text) > 0)
                            {
                                bagianPin = PinId.Bagian.OverdueFB;
                            }

                            /*
                            if (Convert.ToDouble(txtoverduefb.Text) > 0)
                            {
                                bagianPin = PinId.Bagian.OverdueFB;
                            }
                            else if (Convert.ToDouble(txtoverduefx.Text) > 0)
                            {
                                bagianPin = -1;
                            }
                            else if (_isAllBonus)
                            {
                                bagianPin = PinId.Bagian.Bonus;
                            }
                            */

                            //kebijakan bahwa validasi overdue nota dan validasi plafon untuk 2803 dibuka 12/10/2015
                            //if (GlobalVar.Gudang != "2803")
                            //{
                                using (Database db = new Database())
                                {

                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                                    db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                    db.Commands[0].ExecuteNonQuery();

                                    //if (dtPiutangSales.Rows.Count > 0)
                                    //{
                                    //    bagianPin = PinId.Bagian.SalesBL;

                                    //    dt = new DataTable();
                                    //    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                                    //    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                                    //    db.Commands[1].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                                    //    db.Commands[1].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                                    //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    //    dt = db.Commands[1].ExecuteDataTable();
                                    //    db.Commands[1].ExecuteNonQuery();
                                    //}
                                }
                            }
                        //}
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                this.Close();
            }
        }

        DataTable dt = new DataTable();
        DataTable dtnota = new DataTable();


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

        private void DataGridDO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nRowGridView = DataGridDO.CurrentRow.Index;
        }

        private void DataGridDO_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2)
                {
                    if (Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvQty"].Value) <= 0)
                    {
                        MessageBox.Show("minimum qty tidak boleh kurang dari 1");
                        DataGridDO.CurrentRow.Cells["GvQty"].Value = 1;
                        return;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    string idbrg = Convert.ToString(DataGridDO.CurrentRow.Cells["gVplu"].Value);
                    GetPembandingHarga(idbrg);
                    DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = string.Empty;
                    harga = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvHarga"].Value);
                    string promoFlag = Tools.isNull(DataGridDO.CurrentRow.Cells["gvPromoFlag"].Value, string.Empty).ToString();
                    if (promoFlag == string.Empty)
                    {
                        if (GlobalVar.Gudang == "2803")
                        {
                            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                        }
                        else if (GlobalVar.Gudang == "2823" && lookupJenisTransaksi1.IdTr == "KG")
                        {
                            double _hrgHppNew = 0;
                            decimal persen = 0.01m;
                            _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);

                            if (harga >= _hrgHppNew)
                            {
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            }
                            else
                            {
                                DataGridDO[4, e.RowIndex].Value = _hrgHppNew;
                            }
                        }
                        else
                        {
                            if (harga <= 0)
                            {
                                MessageBox.Show("Bukan barang promo. Harga jual tidak boleh <= 0");
                            }
                            else if (harga < _hargaFinal)
                            {
                                MessageBox.Show("Harga Jual lebih kecil dari Harga Standar " + string.Format("{0:N0}", _hargaFinal));
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                            else if (harga < _hrgHPP)
                            {
                                MessageBox.Show("Harga Jual lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                        }
                    }
                }

                if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {
                    if (Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD1"].Value) < 0 || Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD1"].Value) > 100)
                    {
                        MessageBox.Show("Discount antara 0 - 100", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                //d1 = (Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD1"].Value) / 100);
                //d2 = (Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD2"].Value) / 100);
                //d3 = (Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD3"].Value) / 100);

                d1 = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD1"].Value);
                d2 = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD2"].Value);
                d3 = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvD3"].Value);

                potrp = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvPot"].Value);
                kuantiti = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvQty"].Value);
                harga = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvHarga"].Value);

                //jumlah = Hitnet3Dx(kuantiti * harga, d1, d2, d3);
                //HargaBersih = Hitnet3Dx(harga, d1, d2, d3);

                HargaBersih = Hitnet3Dx(harga, d1, d2, d3) - potrp;
                jumlah = kuantiti * HargaBersih;
                //jumlah = Hitnet3Dx(kuantiti * harga, d1, d2, d3) - (kuantiti * potrp);

                //jumlah = kuantiti * harga;
                //double nd1, nd2, nd3, ndisc, ndh1, ndh2, ndh3;
                //nd1 = jumlah * d1;
                //double jumnet1 = jumlah - nd1;
                //jumnet = jumnet1;
                //ndisc = nd1;
                //ndh1 = harga * d1;
                //if (d2 > 0)
                //{
                //    nd2 = jumnet1 * d2;
                //    double jumnet2 = jumnet1 - nd2;
                //    jumnet = jumnet2;
                //    ndisc = nd2 + nd1;
                //    if (d3 > 0)
                //    {
                //        nd3 = jumnet2 * d3;
                //        double jumnet3 = jumnet2 - nd3;
                //        jumnet = jumnet3;
                //        ndisc = nd1 + nd2 + nd3;
                //    }
                //}
                //else
                //{
                //    nd3 = jumnet1 * d3;
                //    double jumnet3 = jumnet1 - nd3;
                //    jumnet = jumnet3;
                //    ndisc = nd1 + nd3;
                //}
                //jumnetakhir = jumnet - (potrp * kuantiti);

                
                double ndisc = (harga * kuantiti) - jumlah; 
                DataGridDO.CurrentRow.Cells["GvTotDisc"].Value = ndisc;
                DataGridDO.CurrentRow.Cells["GvHjual"].Value = HargaBersih;
                DataGridDO.CurrentRow.Cells["GvJumlah"].Value = jumlah;

                // hitung total
                double sum = 0;
                kuantiti2 = 0;
                for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(DataGridDO.Rows[i].Cells[11].Value);
                    kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                }

                label12.Text = sum.ToString("N0");
                lblqty.Text = kuantiti2.ToString("N0");

                //Tutp untuk 2803
                //if (lookupJenisTransaksi1.IdTr.Substring(0, 1) == "K")
                //{
                //    if (sum > Convert.ToDouble(txtsisa.Text))
                //    {
                //        MessageBox.Show("Jumlah Penjualan melebihi Sisa Plafon.");
                //    }
                //}
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridDO.Rows[e.RowIndex].Cells["GvJumlah"].Style.ForeColor = Color.Blue;
        }

        private void DataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                nRowGridView = DataGridDO.CurrentRow.Index;
                //deleterows();
            }
        }


        private void deleterows()
        {
            if (DataGridDO.SelectedCells.Count > 0)
            {
                //Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string kodeBarang = Convert.ToString(DataGridDO.SelectedCells[0].OwningRow.Cells["GvNamaBrg"].Value);
                if (MessageBox.Show("Hapus Data : " + kodeBarang + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        //DataGridDO.Rows.RemoveAt(this.DataGridDO.SelectedRows[0].Index);
                        DataGridDO.Rows.RemoveAt(nRowGridView);
                        //MessageBox.Show("Data telah dihapus");

                        #region  hitung total2

                        int sum = 0;
                        kuantiti2 = 0;
                        for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[9].Value);
                            kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                        }

                        label12.Text = sum.ToString("N0");
                        lblqty.Text = kuantiti2.ToString("N0");
                        TxtBarcode.Text = "";
                        // dataGridView1.Rows[nRowIndex].Cells[2].Selected = true;                   

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void DataGridDO_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridDO.SelectedCells.Count > 0)
            {
                string kodebarang = Tools.isNull(DataGridDO.SelectedCells[0].OwningRow.Cells["gVplu"].Value, string.Empty).ToString();
                if (kodebarang != string.Empty)
                    CekHargaBMK(kodebarang);
                nRowGridView = DataGridDO.CurrentRow.Index;
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


        public void GetHrgBMK()
        {
            try
            {
                DataTable dtGetHrgBMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetInfoHrgJualDepo"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, initCab));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }

                _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                _hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);





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

                if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0)
                {
                    lblBMK.Text = "C: " + _hrgB.ToString("N0") + "  T: " + _hrgM.ToString("N0") + "  E: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
                    //lblBMK.Text = "B: " + _hrgB.ToString("N0") + "  M: " + _hrgM.ToString("N0") + "  K: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
                }
                else
                {
                    lblBMK.Text = "Belum ada harga CTE";

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
                    _hrgB = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_cash"]);
                    _hrgM = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_top10"]);
                    _hrgK = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["h_user"]);
                    _Het  = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["het"]);
                    _dcash= Convert.ToDouble(dtGetHrgKhusus.Rows[0]["dcash"]);
                    _dcash2 = Convert.ToDouble(dtGetHrgKhusus.Rows[0]["dcash2"]);
                    _dcash3 = 0;
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void GetHrgBMKMessage()
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


        private void DataGridDO_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void IncreamentNPrint()
        {
            int Nprint_ = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cekNPrinDO")); //udah cek heri
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            Nprint_ = Convert.ToInt32(dt.Rows[0]["Nprint"]);
            Nprint_++;
            dt.Rows[0]["Nprint"] = Nprint_.ToString();
            //this.dataGridNotaJual.RefreshEdit();
        }


        public void cetakNotaDoRaw()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_CetakDO]")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                CetakDORaw(dt);
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



        private string CetakHeaderDO(DataTable dt, int nUrut, int nMaxHal, out int nHlm)
        {

            BuildString header = new BuildString();

            int nHal = (int)Math.Round((nUrut / 18) + 0.4, 0) + 1;
            nHlm = nHal;

            string cat1 = dt.Rows[0]["Catatan1"].ToString();
            string cat3 = dt.Rows[0]["Catatan2"].ToString();
            string sales = dt.Rows[0]["NamaSales"].ToString();
            string namaToko = dt.Rows[0]["NamaToko"].ToString();
            string cClass = dt.Rows[0]["StsToko"].ToString();
            string DO = dt.Rows[0]["NoDO"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).ToString("dd-MMM-yyyy");
            string noRq = dt.Rows[0]["NoRequest"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).ToString("dd-MMM-yyyy");
            string alamatKirim = header.Alamat(dt.Rows[0]["Alamat"].ToString());
            string nSpace = namaToko.Trim() + header.SPACE(namaToko.Trim().Length + (15 - namaToko.Trim().Length) - 7) + cClass;
            string waktu = dt.Rows[0]["HariKredit"].ToString() + " Hari / ";
            string wilID = dt.Rows[0]["WilID"].ToString();
            string daerah = header.Daerah(dt.Rows[0]["Daerah"].ToString()) + "(Wil: " + wilID + ") ";
            string kota = header.Kota(dt.Rows[0]["Kota"].ToString());
            string expedisi = dt.Rows[0]["Expedisi"].ToString();
            string namaExpedisi = dt.Rows[0]["NamaExpedisi"].ToString();
            double plafon = double.Parse(dt.Rows[0]["Plafon"].ToString());
            string grade = dt.Rows[0]["Grade"].ToString();
            string typePrinter = header.GetPrinterName(); //ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX");
            string cKet = header.SPACE(2);
            StatausToko_ = cClass;
            if (_nCetak == 1)
            {
                cKet = "COPY";
            }
            else if (_nCetak == 2)
            {
                cKet = "REVISI";
            }

            #region Cetak Header
            header.Initialize();
            header.FontCondensed(false);
            header.FontCPI(17);
            header.PageLLine(33);
            header.LeftMargin(1);
            header.BottomMargin(1);
            header.FontCondensed(true);
            if (typePrinter.Contains("LX"))
            {
                header.DoubleHeight(true);
            }
            else
            {
                header.DoubleWidth(true);
            }

            header.PROW(true, 1, "DELIVERY ORDER    (" + nHal.ToString() + "/" + nMaxHal.ToString() + ")" + header.SPACE(3) + cKet);
            header.FontCondensed(false);
            header.DoubleHeight(false);
            header.DoubleWidth(false);
            header.FontCPI(12);
            header.PROW(true, 1, header.Sales(sales));
            header.FontBold(false);
            header.FontItalic(false);
            header.LineSpacing("1/8");
            header.FontItalic(true);
            header.AddCR();
            header.Append(" ");
            header.FontItalic(false);
            header.PROW(false, 53, "ÚÄÄ Pengiriman kepada Toko ÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿");
            header.PROW(true, 1, cat1.PadRight(47, ' '));
            header.PROW(false, 51, "³                                        ³");
            header.AddCR();
            header.PROW(false, 55, nSpace);
            header.PROW(true, 1, "NOMOR D.O : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, DO);
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontCondensed(true);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 92, alamatKirim);
            header.FontItalic(false);
            header.FontCondensed(false);
            header.PROW(true, 1, "JK.WAKTU  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, waktu + cat3.PadRight(20, ' '));
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, daerah);
            header.FontItalic(false);
            header.PROW(true, 1, "NOMOR RQ. : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, noRq);
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, kota);
            header.FontItalic(false);

            header.PROW(true, 1, "EXPEDISI  : ");
            header.FontBold(false);
            header.FontItalic(true);
            if (!expedisi.Equals("SAS"))
            {
                header.PROW(false, 13, expedisi + " (" + namaExpedisi + ")");
            }
            header.FontItalic(false);
            header.PROW(false, 57, "³                               Grade:   ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, "PLAFON:" + plafon.ToString("#,###").PadLeft(15, ' '));
            header.FontItalic(false);
            header.PROW(false, 91, header.STR(2, grade));
            header.FontItalic(false);
            header.PROW(true, 1, header.SPACE(50) + "ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ");
            header.LetterQuality(false);
            header.FontCondensed(true);
            header.PROW(true, 1, "No. N a m a   B a r a n g                                                     RAK   Dipesan            Dikirim             H.Sat.  Disc./Pot. Jml.Net   Stok");
            header.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
            header.LineSpacing("1/6");
            #endregion

            return header.GenerateString();
        }


        public void CetakDORaw(DataTable dt)
        {
            BuildString detail = new BuildString();
            int nMaxHal = dt.Rows.Count;
            int nHal = 0;
            int nUrut = 0;
            double x = (nMaxHal / 18);
            nMaxHal = nMaxHal % 18 == 0 ? (int)Math.Round(x, 0) : (int)(nMaxHal / 18) + 1;
            detail.Append(CetakHeaderDO(dt, nUrut, nMaxHal, out nHal));

            #region Cetak Detail
            double nJumlah = 0;

            string NamaStok = string.Empty;
            string KodeRak = string.Empty;
            string Satuan = string.Empty;
            string Dikirim = string.Empty;
            string tempQSisa = string.Empty;
            string JumlahDo = string.Empty;

            int QSisa = 0;
            double Net = 0;

            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                NamaStok = dr["NamaBarang"].ToString().PadRight(73, '.');
                KodeRak = detail.STR(7, dr["KodeRak"].ToString());
                Satuan = detail.STR(3, dr["Satuan"].ToString());
                Dikirim = nUrut % 2 == 1 ? detail.STR(3, nUrut.ToString()) + ".[_______]             " : detail.STR(16, nUrut.ToString()) + ".[_______]";
                QSisa = int.Parse(dr["QtySisa"].ToString());
                Net = double.Parse(dr["HrgNet"].ToString());
                JumlahDo = detail.STR(5, dr["QtyDO"].ToString());
                nJumlah = nJumlah + Net;
                tempQSisa = QSisa == 0 ? "      0" : QSisa.ToString("#,###").PadLeft(7, ' ');

                detail.PROW(true, 1, detail.STR(2, nUrut.ToString()) + ". " + NamaStok + " " + KodeRak + " " + JumlahDo + " " + Satuan + Dikirim + detail.SPACE(27) + tempQSisa);

                if ((nUrut % 18 == 0) && (nHal < nMaxHal))
                {
                    detail.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
                    detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
                    detail.PROW(true, 1, "");
                    detail.PROW(true, 1, " ");
                    detail.Append("  (     Bag. Piutang     )          (     Bag. Penjualan     )          (     Bag. Gudang     )        (    Bag. Cheker I    )        (   Bag. Cheker II   )");
                    detail.Eject();
                    detail.Append(CetakHeaderDO(dt, nUrut, nMaxHal, out nHal));
                }
            }
            if (nUrut % 18 != 0)
            {
                for (int i = nUrut + 1; i <= nUrut + (18 - (nUrut % 18)); i++)
                {
                    detail.PROW(true, 1, detail.STR(2, i.ToString()) + ". ");
                }
            }
            #endregion

            #region Footer

            detail.LineSpacing("1/8");
            detail.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
            detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
            detail.DoubleWidth(true);
            detail.FontItalic(true);
            detail.AddCR();
            detail.PROW(false, 43, "Total D.O ");
            detail.PROW(false, 59, "Rp." + nJumlah.ToString("#,###").PadLeft(14, ' '));
            detail.DoubleWidth(false);
            detail.FontItalic(false);
            detail.PROW(true, 1, "");
            detail.PROW(true, 1, "  (     Bag. Piutang     )          (     Bag. Penjualan     )          (     Bag. Gudang     )        (    Bag. Cheker I    )        (   Bag. Cheker II   )");
            detail.Eject();
            #endregion

            detail.SendToPrinter("do.txt", detail.GenerateString());
        }


        private void FrmDO_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isEsc && DataGridDO.Rows.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("Detail barang belum disimpan. Simpan?", "Konfirmasi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dlg == DialogResult.Yes)
                    cmdTutup_Click_1(sender, e);
                else if (dlg == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void cmdTutup_Click_1(object sender, EventArgs e)
        {
            _isEsc = false;
            if (validation())
            {
                if (GlobalVar.Gudang != "2803")
                {
                    if (Tools.Left(GlobalVar.Gudang.ToString(), 1) == "9")
                    {
                        if (string.IsNullOrEmpty(lookupGudang1.GudangID))
                        {
                            MessageBox.Show("Cab2 masih kosong..");
                            return;
                        }
                        else
                        {
                            try
                            {
                                using (Database db = new Database())
                                {
                                    DataTable dtStok = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, lookupGudang1.NamaGudang.Trim()));
                                    dtStok = db.Commands[0].ExecuteDataTable();
                                    if (dtStok.Rows.Count.ToString() == "0")
                                    {
                                        MessageBox.Show("Kode Gudang tidak ada");
                                        lookupGudang1.NamaGudang = "";
                                        lookupGudang1.GudangID = "";
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }

                            if (lookupGudang1.GudangID == GlobalVar.Gudang)
                            {
                                MessageBox.Show("Untuk Penjualan Antar Cabang Cab1 harus beda dengan Cab2");
                                return;
                            }
                        }
                    }

                    getPromo();

                    StringBuilder msgBuilder = new StringBuilder();
                    int fxbCount = 0;
                    ArrayList delRows = new ArrayList();

                    for (int a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string plu = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        string nama = Convert.ToString(DataGridDO.Rows[a].Cells[1].Value);
                        double harga = Convert.ToDouble(DataGridDO.Rows[a].Cells[4].Value);
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        string promoFlag = Tools.isNull(DataGridDO.Rows[a].Cells["gvPromoFlag"].Value, string.Empty).ToString();

                        //cek jika ada harga <= 0
                        if (harga <= 0)
                        {
                            //if (plu != "FXBBISKUITKL" && plu != "FXBSOFTDRINK" && plu != "FXBKURSIBKSO" && plu != "FXBTSHIRTOBL")
                            //{
                            if (harga < 0 || (promoFlag == string.Empty && plu.Substring(0, 3) != "FXB"))
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                deleterows();
                                return;
                            }
                            //}
                        }

                        //cek jika ada id barang yang null
                        if (qty > 0)
                        {
                            if (plu == "")
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, NAMA BARANG atau HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                deleterows();
                                return;
                            }
                        }

                        //cek jika ada edit harga yan kurang dari harga HPP atau Harga Final
                        GetPembandingHarga(plu);

                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = string.Empty;
                        if (promoFlag == string.Empty)
                        {
                            if (harga <= 0)
                            {
                                delRows.Add(a);
                            }
                            else if (harga < _hargaFinal)
                            {
                                msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga Standar." + string.Format("{0:N0}", _hargaFinal));
                                DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                            else if (harga < _hrgHPP)
                            {
                                msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                                DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                        }

                        if (plu.Substring(0, 3) == "FXB")
                        {
                            fxbCount += 1;
                        }
                    }

                    _isAllBonus = fxbCount > 0 && fxbCount == DataGridDO.Rows.Count;

                    if (msgBuilder.Length != 0)
                    {
                        MessageBox.Show(msgBuilder.ToString());
                    }

                    if (!_isAllBonus && delRows.Count > 0)
                    {
                        foreach (int delRow in delRows)
                        {
                            MessageBox.Show("Baris " + (delRow + 1).ToString() + " Harga Jual <= 0." + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                            this.DataGridDO.Rows[delRow].Selected = true;
                            this.DataGridDO.FirstDisplayedScrollingRowIndex = delRow;
                            deleterows();
                            return;
                        }
                    }
                }

                if (DataGridDO.Rows.Count > 0)
                {
                    BayarDO.FrmBayarDO ifrmChild = new BayarDO.FrmBayarDO(this);

                    ifrmChild.ShowDialog();
                }
            }

            String TotalHarga = label12.Text;
        }


        private void GetPembandingHarga(string idbarang)
        {
            if (idbarang.Substring(0, 3) != "FXB")
            {
                _hargaFinal = 0;
                _barangID = idbarang;
                GetHrgJual();
                GetHrgBMK();
                GetHrgKhusus();
                GetHargaHpp(idbarang);
            }

            string jenis2;
            jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

            if (TxtNamaToko.Text != "ECERAN CASH")
            {
                if (jenis2 == "T" || jenis2 == "t")
                {
                    _hargaFinal = _hrgB;

                }
                if (jenis2 == "K" || jenis2 == "k")
                {
                    _hargaFinal = _hrgM;
                }
            }
            else
            {
                _hargaFinal = _hrgK;
            }
        }


        public void getPromo()
        {
            #region promo tagihan
            //transaksi penjualan pertama setiap bulan, kode toko buat input, trus cek nota diya pernah transaksi di bulan yang sama, where ambil bulan tglsj = getdate(brti salah);
            DataTable dtTagihan;
            kodetoko = lookupToko1.KodeToko;

            if (Prolib.CekHistPromo(kodetoko) == false)
            {
                dtTagihan = new DataTable();
            }
            else
            {
                dtTagihan = Prolib.CekTagihan(kodetoko);
            }

            if (dtTagihan.Rows.Count > 0)
            {
                frmPromoTagihan ifrmChild = new frmPromoTagihan(this, dtTagihan);
                ifrmChild.ShowDialog();
            }
            #endregion

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

                for (i = 0; i < DataGridDO.Rows.Count; i++)
                {
                    string idbrng = DataGridDO.Rows[i].Cells[0].Value.ToString();
                    DataTable dtpromobarang = Prolib.DataPromoBarang(_barangID);
                    qtybarang = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
                    hargajualbarang = Convert.ToDouble(DataGridDO.Rows[i].Cells["GvJumlah"].Value);
                    if (dtpromobarang.Rows.Count > 0)
                    {
                        sumqtyBarang = sumqtyBarang + qtybarang;
                        sumhargajualbarang = sumhargajualbarang + hargajualbarang;


                    }
                }

                #endregion

                #region promo kelompok nya
                DataTable dtPromoKelompok, dtPromoTahunan = new DataTable();
                for (i = 0; i < DataGridDO.Rows.Count; i++)
                {
                    if (Prolib.cekpromokelompok(_barangID) == true)
                    {
                        qtyKelompok = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);

                        sumqtyKelompok = sumqtyKelompok + qtyKelompok;
                        //DataGridDO.Rows[i].Cells["GvJumlah"].Value = jumnetakhir;
                        hargajualKelompok = Convert.ToDouble(label12.Text.ToString());
                        //MessageBox.Show(hargajualKelompok.ToString());

                        sumhargajualKelompok = hargajualKelompok; //sumhargajualKelompo + hargajualKelompok;


                        dtPromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);


                        //DataTable dtPromoTahunan = new DataTable();
                        /*  for (i = 0; i < dtPromoKelompok.Rows.Count; i++)
                          {

                              if (Prolib.PromoTahunan() == true)
                              {
                                  //qtyTahunan = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
                                  //sumqtyTahunan = sumqtyTahunan + qtyTahunan;
                                  //hargajualTahunan = Convert.ToDouble(label12.Text.ToString());
                                  //sumhargajualTahunan = hargajualTahunan;

                                  dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyKelompok, sumhargajualKelompok);
                                  string KodeToko = lookupToko1.KodeToko;
                                  string KodeBarang = dtPromoTahunan.Rows[0]["id_brg"].ToString();
                                  if (Prolib.CekHistoryTokoTahunan(KodeToko, KodeBarang) == true)
                                  {
                                      dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyKelompok, sumhargajualKelompok);
                                  }
                                  else
                                  {
                                      dtPromoTahunan = new DataTable();
                                  }
                              }
                          }*/

                    }
                }
                #endregion

                #region Promo Tahunan
                //DataTable dtPromoTahunan = new DataTable();
                for (i = 0; i < DataGridDO.Rows.Count; i++)
                {

                    if (Prolib.PromoTahunan(_barangID) == true)
                    {
                        qtyTahunan = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
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

                if (dtPromoBarangBonus.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0 || dtPromoTahunan.Rows.Count > 0)
                {
                    string idtoko = lookupToko1.KodeToko;

                    DO.frmpilihbonusDO ifrmChild = new DO.frmpilihbonusDO(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBarangBonus, dtpromoKelompok, dtPromoTahunan);
                    ifrmChild.ShowDialog();
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

        private void cmdTutup_Click(object sender, EventArgs e)
        {
            string sie = Class.AppSetting.GetValue("so_insert_enable");
            if (sie.ToLower() != "true")
            {
                MessageBox.Show("Silakan input melalui https://wiser.sas-autoparts.com");
                return;
            }

            _isEsc = false;
            if (validation())
            {
                if (GlobalVar.Gudang != "2803")
                {
                    if (Tools.Left(GlobalVar.Gudang.ToString(), 1) == "9")
                    {
                        if (string.IsNullOrEmpty(lookupGudang1.GudangID))
                        {
                            MessageBox.Show("Cab2 masih kosong..");
                            return;
                        }
                        else
                        {
                            try
                            {
                                using (Database db = new Database())
                                {
                                    DataTable dtStok = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, lookupGudang1.NamaGudang.Trim()));
                                    dtStok = db.Commands[0].ExecuteDataTable();
                                    if (dtStok.Rows.Count.ToString() == "0")
                                    {
                                        MessageBox.Show("Kode Gudang tidak ada");
                                        lookupGudang1.NamaGudang = "";
                                        lookupGudang1.GudangID = "";
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }

                            if (Tools.Left(lookupGudang1.GudangID, 2) == Tools.Left(GlobalVar.Gudang, 2))
                            {
                                MessageBox.Show("Untuk Penjualan Antar Cabang Cab1 harus beda dengan Cab2");
                                return;
                            }
                        }
                    }

                    getPromo();

                    StringBuilder msgBuilder = new StringBuilder();
                    int fxbCount = 0;
                    ArrayList delRows = new ArrayList();

                    for (int a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string plu = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        string nama = Convert.ToString(DataGridDO.Rows[a].Cells[1].Value);
                        double harga = Convert.ToDouble(DataGridDO.Rows[a].Cells[4].Value);
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        string promoFlag = Tools.isNull(DataGridDO.Rows[a].Cells["gvPromoFlag"].Value, string.Empty).ToString();

                        //cek jika ada harga <= 0
                        if (harga <= 0)
                        {
                            //if (plu != "FXBBISKUITKL" && plu != "FXBSOFTDRINK" && plu != "FXBKURSIBKSO" && plu != "FXBTSHIRTOBL")
                            //{
                            if (harga < 0 || (promoFlag == string.Empty && plu.Substring(0, 3) != "FXB"))
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                deleterows();
                                return;
                            }
                            //}
                        }

                        //cek jika ada id barang yang null
                        if (qty > 0)
                        {
                            if (plu == "")
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, NAMA BARANG atau HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                deleterows();
                                return;
                            }
                        }

                        //cek jika ada edit harga yan kurang dari harga HPP atau Harga Final
                        GetPembandingHarga(plu);

                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = string.Empty;
                        if (promoFlag == string.Empty)
                        {
                            if (harga <= 0)
                            {
                                delRows.Add(a);
                            }
                            else if (harga < _hargaFinal)
                            {
                                msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga Standar." + string.Format("{0:N0}", _hargaFinal));
                                DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                            else if (harga < _hrgHPP)
                            {
                                msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                                DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                            }
                        }

                        if (plu.Substring(0, 3) == "FXB")
                        {
                            fxbCount += 1;
                        }
                    }

                    _isAllBonus = fxbCount > 0 && fxbCount == DataGridDO.Rows.Count;

                    if (msgBuilder.Length != 0)
                    {
                        MessageBox.Show(msgBuilder.ToString());
                    }

                    if (!_isAllBonus && delRows.Count > 0)
                    {
                        foreach (int delRow in delRows)
                        {
                            MessageBox.Show("Baris " + (delRow + 1).ToString() + " Harga Jual <= 0." + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                            this.DataGridDO.Rows[delRow].Selected = true;
                            this.DataGridDO.FirstDisplayedScrollingRowIndex = delRow;
                            deleterows();
                            return;
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string plu = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        string nama = Convert.ToString(DataGridDO.Rows[a].Cells[1].Value);
                        double harga = Convert.ToDouble(DataGridDO.Rows[a].Cells[4].Value);
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        string promoFlag = Tools.isNull(DataGridDO.Rows[a].Cells["gvPromoFlag"].Value, string.Empty).ToString();

                        if (harga <= 0)
                        {
                            if (harga < 0 || (promoFlag == string.Empty && plu.Substring(0, 3) != "FXB"))
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + "  HARGA KOSONG");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                //deleterows();
                                return;
                            }
                        }

                        if (qty > 0)
                        {
                            if (plu == "")
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + "  KODE BARANG KOSONG");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                //deleterows();
                                return;
                            }
                        }
                    }
                }

                if (DataGridDO.Rows.Count > 0)
                {
                    BayarDO.FrmBayarDO ifrmChild = new BayarDO.FrmBayarDO(this);

                    ifrmChild.ShowDialog();
                }
            }

            String TotalHarga = label12.Text;

        }


        public bool savepromo(DataTable dtPromo)
        {
            //masukin barang promo yang udah kepilih ke datagrid yang udah ada
            int i = 0;
            i = DataGridDO.Rows.Count;
            int j = i + 1;

            //nyimpen promo barang setelah dipilih dari grid promo barang
            string idBrg = string.Empty;
            string idBrgPromo = string.Empty;
            foreach (DataRow dr in dtPromo.Rows)
            {
                idBrgPromo = Convert.ToString(dr["id_brg"]);
                foreach (DataGridViewRow drDO in DataGridDO.Rows)
                {
                    idBrg = Convert.ToString(drDO.Cells["gVplu"].Value);

                    if (idBrg == idBrgPromo)
                    {
                        return false;
                    }
                }

                DataGridDO.Rows.Add(1);
                DataGridDO.Rows[i].Cells[0].Value = idBrgPromo;
                DataGridDO.Rows[i].Cells[1].Value = dr["nama_stok"];
                DataGridDO.Rows[i].Cells[2].Value = Convert.ToInt32(dr["qty_bns"]);
                DataGridDO.Rows[i].Cells[3].Value = dr["satuan"];
                DataGridDO.Rows[i].Cells[4].Value = dr["h_jual"];
                DataGridDO.Rows[i].Cells[5].Value = 0;
                DataGridDO.Rows[i].Cells[6].Value = 0;
                DataGridDO.Rows[i].Cells[7].Value = 0;
                DataGridDO.Rows[i].Cells[8].Value = 0;
                DataGridDO.Rows[i].Cells[9].Value = 0;
                DataGridDO.Rows[i].Cells[12].Value = 1;
                i++;
            }

            return true;
        }


        private void GetHrgJual()
        {
            if (GlobalVar.Gudang == "2803")
            {
                QTYPOS = "1";
            }

            if (_barangID != "" && double.Parse(QTYPOS) != 0)
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
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, _c1));
                        */

                        db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TxtTGL.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, lookupJenisTransaksi1.IdTr));
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

        private void FrmDO2803_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F10)
            {
                cmdTutup_Click_1(sender, e);
            }
            //if (e.KeyCode == Keys.F10)
            //{
            //    lookupSales1.Select();
            //    lookupSales1.Focus();

            //}
            if (e.KeyCode == Keys.F9)
            {
                TxtBarcode.Select();
                TxtBarcode.Focus();
            }
            if (e.KeyCode == Keys.F8)
            {
                lookupToko1.Select();
                lookupToko1.Focus();
            }
            if (e.KeyCode == Keys.Insert)
            {
                if (lookupJenisTransaksi1.IdTr != string.Empty)
                {
                    TampilFormBarang();
                }
            }
        }


        private void TampilFormBarang()
        {
            DO.FrmBarcodeDO ifrmChild = new DO.FrmBarcodeDO(this, lookupJenisTransaksi1.IdTr, flagkg);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


        private void FrmDO2803_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isEsc && DataGridDO.Rows.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("Detail barang belum disimpan. Simpan?", "Konfirmasi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dlg == DialogResult.Yes)
                    cmdTutup_Click_1(sender, e);
                else if (dlg == DialogResult.Cancel)
                    e.Cancel = true;
            }

        }


        public void AmbilBarang2()
        {
            cab1 = initCab;
            cab2 = initCab;
            cab3 = "";
            _Het = 0; _dcash = 0; _dcash2 = 0; _dcash3 = 0; HrgNetto = 0; 


            if (TxtBarcode.Text == "")
            {
                return;
            }
            if (TxtNamaToko.Text == "")
            {
                MessageBox.Show("Data Customer masih kosong..\nMohon diisidahulu karena akan mempengaruhi harga BMK");
                return;
            }

            if (lookupJenisTransaksi1.IdTr == string.Empty)
            {
                MessageBox.Show("Jenis Transaksi Belum dipilih..\nMohon dipilih dahulu karena akan mempengaruhi harga BMK");
                return;
            }

            int nRowIndex = DataGridDO.Rows.Count;
            kelompok = lookupJenisTransaksi1.IdTr;

            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, TxtBarcode.Text));
                //db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, kelompok.ToString()));
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
                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            this.Cursor = Cursors.Default;
                            return;

                        }
                        DataGridDO.AllowUserToAddRows = false;
                    }
                    DataGridDO.AllowUserToAddRows = true;
                    DataGridDO.Rows.Add(1);
                    DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                    DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    DataGridDO.Rows[nRowIndex].Cells[2].Value = 1;
                    DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];

                    _barangID = Convert.ToString(dr["BarangID"]);
                    QTYPOS = "1";
                    _c1 = cab1;

                    if (idbarang.Substring(0, 3) != "FXB")
                    {
                        GetHrgJual();
                        GetHrgBMKMessage();
                        GetHrgKhusus();
                        GetHargaHpp(idbarang);
                    }

                    string jenis2;
                    jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

                    if (TxtNamaToko.Text != "ECERAN CASH")
                    {
                        if (jenis2 == "T" || jenis2 == "t")
                        {
                            _hargaFinal = _hrgB;
                            if (_Het == 0)
                            {
                                _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                            }
                            
                            Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                            Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value,"0").ToString());
                            Double nNet = nHrg - nPot;
                            int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                            DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                            DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                            DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                            DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                            DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                            DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                        }
                        if (jenis2 == "K" || jenis2 == "k")
                        {
                            if (_hrgB == 0)
                            {
                                MessageBox.Show("Harga Jual 0, Hubungi HO");
                                double _hrgHppNew = 0;
                                decimal persen = 0.01m;
                                int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                                _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
                                _hargaFinal = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                                DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                                DataGridDO.Rows[nRowIndex].Cells[8].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * _hrgHppNew;
                            }
                            else
                            {
                                _hargaFinal = _hrgB;
                                if (_Het == 0)
                                {
                                    _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                                }
                                Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                                Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value, "0").ToString());
                                Double nNet = nHrg - nPot;
                                int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                                DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                                DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                                DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                                DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                                DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                                DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                            }
                        }
                    }
                    else
                    {
                        _hargaFinal = _hrgB;
                        if (_Het == 0)
                        {
                            _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                        }
                        
                        Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                        Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value, "0").ToString());
                        Double nNet = nHrg - nPot;
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                        DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                        DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                        DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                        DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                        DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                        DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                    }

                    #region harga tidak boleh kurang dari atau sama dengan 0

                    for (a = 0; a < DataGridDO.Rows.Count; a++)
                    {
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        if (qty > 0)
                        {
                            if (idbarang.Substring(0, 3) != "FXB")
                            {
                                if (_hargaFinal <= 0 && _hrgHPP <= 0)
                                {
                                    DataGridDO.AllowUserToAddRows = false;
                                    b = a + DataGridDO.Rows.Count;
                                    MessageBox.Show("Harga Jual dan HPP masih 0,Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                                    DataGridDO.Rows.Remove(DataGridDO.Rows[a]);
                                    DataGridDO.AllowUserToAddRows = false;
                                    return;
                                }
                            }
                        }
                    }

                    #endregion

                    DataGridDO.MultiSelect = false;
                    DataGridDO.BeginEdit(true);
                    DataGridDO.AllowUserToAddRows = false;

                    #region hitung total2

                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[11].Value);
                        kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                    }

                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                    TxtBarcode.Text = "";

                    if (DataGridDO.Rows.Count >= 2)
                    {
                        DataGridDO.Rows[nRowIndex].Cells[2].Selected = true;
                    }
                    #endregion
                }

                this.Cursor = Cursors.Default;
                //getPromo();
                DataGridDO.AllowUserToAddRows = false;
            }
        }


        public void AmbilBarang3()
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
                MessageBox.Show("Data Customer masih kosong..\nMohon diisidahulu karena akan mempengaruhi harga BMK");
                return;
            }
            //Tambahan untuk verifikasi jenis transaksi
            if (lookupJenisTransaksi1.IdTr == string.Empty)
            {
                MessageBox.Show("Jenis Transaksi Belum dipilih..\nMohon dipilih dahulu karena akan mempengaruhi harga BMK");
                return;
            }

            int nRowIndex = DataGridDO.Rows.Count;
            kelompok = lookupJenisTransaksi1.IdTr;

            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH3_perKode"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, TxtBarcode.Text.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, kelompok.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                dt = db.Commands[0].ExecuteDataTable();

            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Barcode tidak ditemukan..!");
                return;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        DataGridDO.AllowUserToAddRows = false;
                    }
                    DataGridDO.AllowUserToAddRows = true;
                    DataGridDO.Rows.Add(1);
                    DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                    DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    DataGridDO.Rows[nRowIndex].Cells[2].Value = 1;
                    DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];

                    _barangID = Convert.ToString(dr["BarangID"]);
                    QTYPOS = "1";
                    _c1 = cab1;

                    if (idbarang.Substring(0, 3) != "FXB")
                    {
                        GetHrgJual();
                        GetHrgBMKMessage();
                        GetHrgKhusus();
                        GetHargaHpp(idbarang);
                    }

                    string jenis2;
                    jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

                    if (TxtNamaToko.Text != "ECERAN CASH")
                    {
                        if (jenis2 == "T" || jenis2 == "t")
                        {
                            _hargaFinal = _hrgB;
                            if (_Het == 0)
                            {
                                _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                            }

                            Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                            Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value, "0").ToString());
                            Double nNet = nHrg - nPot;
                            int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                            DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                            DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                            DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                            DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                            DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                            DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                        }

                        if (jenis2 == "K" || jenis2 == "k")
                        {
                            //_hargaFinal = _hrgM;
                            //DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgM;
                            //DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgM;

                            if (_hrgB == 0)
                            {
                                MessageBox.Show("Harga Jual 0, Hubungi HO");
                                double _hrgHppNew = 0;
                                decimal persen = 0.01m;
                                int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                                _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
                                _hargaFinal = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                                DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                                DataGridDO.Rows[nRowIndex].Cells[8].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgHppNew;
                                DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * _hrgHppNew;
                            }
                            else
                            {
                                _hargaFinal = _hrgB;
                                if (_Het == 0)
                                {
                                    _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                                }
                                Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                                Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value, "0").ToString());
                                Double nNet = nHrg - nPot;
                                int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                                DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                                DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                                DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                                DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                                DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                                DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                            }
                        }
                    }
                    else
                    {
                        //_hargaFinal = _hrgK;
                        //DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgK;
                        //DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgK;

                        _hargaFinal = _hrgB;
                        if (_Het == 0)
                        {
                            _Het = _hrgB; _dcash = 0; _dcash2 = 0; _dcash3 = 0;
                        }

                        Double nHrg = Hitnet3Dis(_Het, _dcash, _dcash2, _dcash3);
                        Double nPot = Convert.ToDouble(Tools.isNull(DataGridDO.Rows[nRowIndex].Cells[9].Value, "0").ToString());
                        Double nNet = nHrg - nPot;
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);

                        DataGridDO.Rows[nRowIndex].Cells[4].Value = _Het;
                        DataGridDO.Rows[nRowIndex].Cells[5].Value = _dcash;
                        DataGridDO.Rows[nRowIndex].Cells[6].Value = _dcash2;
                        DataGridDO.Rows[nRowIndex].Cells[8].Value = nHrg;
                        DataGridDO.Rows[nRowIndex].Cells[10].Value = nNet;
                        DataGridDO.Rows[nRowIndex].Cells[11].Value = qty * nNet;
                    }

                    #region harga tidak boleh kurang dari atau sama dengan 0
                    for (a = 0; a < DataGridDO.Rows.Count; a++)
                    {
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        if (qty > 0)
                        {
                            if (idbarang.Substring(0, 3) != "FXB")
                            {
                                if (_hargaFinal <= 0 && _hrgHPP <= 0)
                                {
                                    DataGridDO.AllowUserToAddRows = false;
                                    b = a + DataGridDO.Rows.Count;
                                    MessageBox.Show("Harga Jual dan HPP masih 0,Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                                    DataGridDO.Rows.Remove(DataGridDO.Rows[a]);
                                    DataGridDO.AllowUserToAddRows = false;
                                    return;
                                }
                            }
                            //}
                        }
                    }
                    #endregion

                    //DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                    //DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                    //DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                    //DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;

                    DataGridDO.MultiSelect = false;
                    DataGridDO.BeginEdit(true);
                    DataGridDO.AllowUserToAddRows = false;

                    #region hitung total2

                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[9].Value);
                        kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                    }

                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                    TxtBarcode.Text = "";

                    if (DataGridDO.Rows.Count >= 2)
                    {
                        DataGridDO.Rows[nRowIndex].Cells[2].Selected = true;
                    }
                    #endregion
                }
                this.Cursor = Cursors.Default;
                //getPromo();
                DataGridDO.AllowUserToAddRows = false;
            }
        }


        private void Hitnet3d(double Het_,double dcash_,double dcash2_)
        {
            double x = 0,y = 0;
            x = Het_ - (Math.Round((dcash_ / 100) * Het_,0));
            HrgNetto = x - (Math.Round((dcash2_ / 100) * x, 0));
        }


        public double Hitnet3Dx(double Nilai_, double d1_, double d2_, double d3_)
        {
            double _Nilai,_d1,_d2,_d3,_Pot,a,b,c;
            _Nilai = Convert.ToDouble(Tools.isNull(Nilai_,0).ToString());
            _d1    = Convert.ToDouble(Tools.isNull(d1_,0).ToString());
            _d2    = Convert.ToDouble(Tools.isNull(d2_,0).ToString());
            _d3    = Convert.ToDouble(Tools.isNull(d3_,0).ToString());

            a = _Nilai - Math.Round(((_d1/100) * _Nilai),0);
            b = a - Math.Round(((_d2/100) * a),0);
            c = b - Math.Round(((_d3/100) * b),0);
            return c;
        }

        public double Hitnet3Dis(double Nilai_, double d1_, double d2_, double d3_)
        {
            double _Nilai, _d1, _d2, _d3, _Pot, a, b, c;
            _Nilai = Convert.ToDouble(Tools.isNull(Nilai_, 0).ToString());
            _d1 = Convert.ToDouble(Tools.isNull(d1_, 0).ToString());
            _d2 = Convert.ToDouble(Tools.isNull(d2_, 0).ToString());
            _d3 = Convert.ToDouble(Tools.isNull(d3_, 0).ToString());

            a = _Nilai - Math.Round(((_d1 / 100) * _Nilai), 0);
            b = a - Math.Round(((_d2 / 100) * a), 0);
            c = b - Math.Round(((_d3 / 100) * b), 0);
            return c;
        }
    
    }
}
