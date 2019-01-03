using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Linq;


namespace ISA.Trading.DO
{
    public partial class FrmDO2828 : ISA.Controls.BaseForm
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
        string wilayah;
        string flagHR4;

        //variabel dalam sales
        string idsales;

        DateTime tanggal;
        int total;
        int a, b;
        double kuantiti, kuantiti2;
        double harga, d1, d2, d3, potrp;
        double jumlah, jumnet, jumnetakhir, jumdis;

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
        Boolean _isOk = true;

        //variabel gethitunghrgjual
        string _barangID;
        DateTime _tglDO, _tglAkhir;
        string _kodeToko;
        string _c1;
        double HrgJualBMK_;
        string QTYPOS;
        int QTYPOS1;
        double _hrgB = 0, _hrgM = 0, _hrgK = 0, _hrgJual = 0, _hrgAkhir = 0, _hrgHPP = 0, _hargaFinal = 0,
                _hrgNet = 0, _ovd = 0, _gtolak = 0, nDiscK4 = 0, _Hnet = 0, discwil = 0;

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
        Guid _doID;
        Guid _doDetailID;
        
        //variable ID POS from AG
        string AGRecordID = "";
        string AGTransactionID = "";

        int JWtoko = 0;
        int JStoko = 0;
        int JXtoko = 0;

        int JWtokoFx = 0;
        int JStokoFx = 0;
        int JXtokoFx = 0;

        int JWtokoFAB = 0;
        int JStokoFAB = 0;
        int JXtokoFAB = 0;

        DateTime Date1 = Convert.ToDateTime(string.Format("{0:dd-MMM-yyyy}", new DateTime(int.Parse("2016"), int.Parse("11"), 1)));
        DateTime Date2 = Convert.ToDateTime(string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer));

        public FrmDO2828(DataTable dtag)
        {
            InitializeComponent();
        }

        public FrmDO2828(Form caller, DataTable dt_, string gudang_)
        {
            this.Caller = caller;
            InitializeComponent();
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


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmDO2828_Load(object sender, EventArgs e)
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
            menit = 0; varmenit=0;
            miliDetik = 0; varmilidetik = 0;
           
            total = 0;
            label12.Text = Convert.ToString(total);
            kodetoko = "";
            idsales = "";
            tanggal = GlobalVar.DateTimeOfServer;   // DateTime.Now;
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
                lookupGudang1.Enabled = true;
                lookupGudang1.GudangID = GlobalVar.Gudang;
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dtStok = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar,GlobalVar.Gudang));
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


            this.lookupSales1.Enabled = true;
            this.lookupJenisTransaksi1.Enabled = true;
            this.textBox10.Enabled = true;
            this.textBox11.Enabled = true;
            this.txtTglrq.Enabled = true;
            this.CBShift.Enabled = true;
            this.txtNorq.Enabled = true;

            lookupToko1.Focus();


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

                    CBOEkspedisi.Text = dtExp.Rows[0]["Expedisi"].ToString();

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

            
            #region data NOTA
                //retrieving data
                //DataTable dtnota;
                //DataTable dtnota = new DataTable();
                //this.Cursor = Cursors.WaitCursor;
                //using (Database db = new Database())
                //{
                //    DataView dv = new DataView();
                //    DataTable dtt = new DataTable();
                //    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID_2")); //cek
                //    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowid));
                //    dtnota = db.Commands[0].ExecuteDataTable();

                //    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_RowID"));
                //    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                //    dtDO = db.Commands[1].ExecuteDataTable();

                //    //_doHtrID = Tools.isNull(dtDO.Rows[0]["HtrID"], "").ToString();
                //    foreach (DataRow dtDOrow in dtDO.Rows)
                //    {
                //        _rpACCPiutang = double.Parse(Tools.isNull(dtDOrow["RpACCPiutang"], "0.0").ToString());
                //        _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
                //        _transType = Tools.isNull(dtDOrow["TransactionType"], "").ToString();
                //        _hariKredit = int.Parse(Tools.isNull(dtDOrow["HariKredit"], "0").ToString());
                //        _Cat1 = dtDO.Rows[0]["Catatan1"].ToString();
                //        _Cat2 = dtDO.Rows[0]["Catatan2"].ToString();
                //        _Cat3 = dtDO.Rows[0]["Catatan3"].ToString();
                //        _Cat4 = dtDO.Rows[0]["Catatan4"].ToString();
                //        _Cat5 = dtDO.Rows[0]["Catatan5"].ToString();
                //    }
                //}

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
            DataGridDO.Columns["GvPot"].DisplayIndex = 8;
            DataGridDO.Columns["GvHjual"].DisplayIndex = 9;
            DataGridDO.Columns["GvJumlah"].DisplayIndex = 10;

            //----- nota
            _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
            _isEsc = true;

        }


        private void commandButton3_Click(object sender, EventArgs e)
        {
            Close();
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


        private void TxtPLU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int nRowIndex = DataGridDO.Rows.Count - 1;

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PLU_SEARCH_BARCODE"));
                    db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, TxtPLU.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Barang tidak ada atau HPP Barang = Null", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string idbarang = Convert.ToString(dr["BarangID"]);
                        string namabarang = Convert.ToString(dr["nama_stok"]);
                        for (a = 0; a < DataGridDO.Rows.Count - 1; ++a)
                        {
                            string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                            if (idbarang == idbarangcell )
                            {
                                MessageBox.Show("'"+namabarang+"'"+"\n"+" sudah ada di daftar belanja..","INFORMASI",MessageBoxButtons.OK,MessageBoxIcon.Stop );
                                this.Cursor = Cursors.Default;
                                return;                                                             
                            }
                        }
                        DataGridDO.Rows.Add(1);
                        DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                        DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["nama_stok"];
                        DataGridDO.Rows[nRowIndex].Cells[2].Value = 1;
                        DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["satjual"];
                        DataGridDO.Rows[nRowIndex].Cells[4].Value = Convert.ToInt32(dr["hpp"]);
                        DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                        DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                        DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                        DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;
                        DataGridDO.Rows[nRowIndex].Cells[9].Value = Convert.ToInt32(dr["hpp"]);
                        DataGridDO.Rows[nRowIndex].Cells[10].Value = Convert.ToInt32(dr["hpp"]);
                    }

                    // hitung total
                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[9].Value);
                        kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                    }

                    label12.Text = sum.ToString("N0");
                    lblqty.Text = kuantiti2.ToString("N0");
                    TxtPLU.Text = "";
                    DataGridDO.Rows[nRowIndex].Cells[2].Selected = true;
                }
                this.Cursor = Cursors.Default;
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


        private void CmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void CmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        public void InsertTokoPlafon()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_KartuPiutang_FilterByUsia"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
                    db.Commands[0].Parameters.Add(new Parameter("@Usia", SqlDbType.Int, 210)); //210 hari 
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Toko ini mempunyai nota overdue > 120 hari menyebabkan Plafon menjadi nol. \nSilakan selesaikan overdue lalu ajukan kembali Plafon","Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_TokoPlafon_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, kodetoko));
                        db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fx", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_fa", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kb", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kh", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kv", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@plf_kg", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@max_credit", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fb", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fx", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@max_fa", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@tmptoko", SqlDbType.Decimal, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
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
        }

 
        public void Save_DONOTA(object sender, EventArgs e)
        {
            if (validation())
            {
                idsales = lookupSales1.SalesID;
                _JenTr = lookupJenisTransaksi1.IdTr;
 
                IsTokoPT ();
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


                #region ijo-ijo
                //if (GlobalVar.Gudang == "2803")
                //{
                //    int lebarRq = 0;
                //    string depanRq = "";
                //    int iNomorRq = 0;
                //    string belakangRq = "";
                //    string strNoRq = "";

                //    depanRq = string.Format("{0:dd/MM/yyyy}", GlobalVar.DateTimeOfServer).Substring(0, 2) +
                //              string.Format("{0:dd/MM/yyyy}", GlobalVar.DateTimeOfServer).Substring(3, 2);
                //    DataTable dtNumRq = Tools.GetGeneralNumerator("NORQ_2803", depanRq);
                //    if (dtNumRq.Rows.Count > 0)
                //    {
                //        lebarRq = 3;
                //        iNomorRq = int.Parse(Tools.isNull(dtNumRq.Rows[0]["Nomor"], "0").ToString());
                //        belakangRq = Tools.isNull(dtNumRq.Rows[0]["Belakang"], "").ToString();
                //        iNomorRq++;
                //        strNoRq = Tools.isNull(Tools.FormatNumerator(iNomorRq, lebarRq, depanRq, belakangRq), "").ToString();
                //        txtNorq.Text = strNoRq;
                //    }
                //}
                #endregion

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
                        cab2 = lookupGudang1.GudangID;//.Substring(0,2);
                        cab3 = lookupGudang1.GudangID.Substring(2,2);
                    }
                }

                
                //-------------    proses simpan ke HeaderDO, DetailDO    -------------------------
                try
                {
                    if (formMode == enumFormMode.New)
                    {
                        string _noAccPiutang = string.Empty, _noAccPusat = string.Empty, _Catatan5 = string.Empty;

                        if (GlobalVar.Gudang == "2808")
                        {
                            _noAccPiutang = "FULLACC";
                            _noAccPusat = "AUTOACC";
                            _Catatan5 = "ACC";
                            _noACC = "AUTOACC";
                        }

                        using (Database db = new Database())
                        {
                            _rowid = Guid.NewGuid();
                            _doID = _rowid;

                            //if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2823" && flagkg=="KG"
                            //    && (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB"
                            //    || lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC"))
                            //{
                            //    _noAccPusat = "AUTOACC";
                            //}

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowid));
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cab2));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cab3));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, txtNorq.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, txtTglrq.DateValue ));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, strNoDO));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, TxtTGL.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, _noAccPusat));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, _noAccPiutang ));
                            db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, string.Empty));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, TxtJW.Text));
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
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, hari));
                            db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, txtJS.Text));
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
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                        }

                        Guid _headerID;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_GetRowIDDO"));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                            dt = db.Commands[0].ExecuteDataTable();
                            _headerID = (Guid)dt.Rows[0]["RowID"];
                            db.Commands[0].ExecuteNonQuery();
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
                            potongan = Convert.ToInt32(DataGridDO.Rows[a].Cells[8].Value);

                            using (Database db = new Database())
                            {
                                CekBarangID(barangID);
                                //if (barangID.Substring(0, 3).Equals("FXB"))
                                //{
                                //    potongan = 1;
                                //}
                                //if (_noACC.Equals("BONUSAN"))
                                //{
                                //    potongan = 1;
                                //}

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
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, _noACC));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nboPrint", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
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

                            #region pin 04
                            //int bagianPin = 0;

                            //if (_isAllBonus)
                            //{
                            //    bagianPin = PinId.Bagian.Bonus;
                            //}
                            //else if (Convert.ToDouble(txtoverduefx.Text) > 0)
                            //{
                            //    bagianPin = -1;
                            //}
                            //else if (Convert.ToDouble(txtoverduefb.Text) > 0)
                            //{
                            //    bagianPin = PinId.Bagian.OverdueFB;
                            //}

                            ///*
                            //if (Convert.ToDouble(txtoverduefb.Text) > 0)
                            //{
                            //    bagianPin = PinId.Bagian.OverdueFB;
                            //}
                            //else if (Convert.ToDouble(txtoverduefx.Text) > 0)
                            //{
                            //    bagianPin = -1;
                            //}
                            //else if (_isAllBonus)
                            //{
                            //    bagianPin = PinId.Bagian.Bonus;
                            //}
                            //*/

                            //if (GlobalVar.Gudang != "2803")
                            //{
                            //    using (Database db = new Database())
                            //    {

                            //        DataTable dt = new DataTable();
                            //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                            //        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                            //        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                            //        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, noAcc));
                            //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            //        dt = db.Commands[0].ExecuteDataTable();
                            //        db.Commands[0].ExecuteNonQuery();

                            //        //if (dtPiutangSales.Rows.Count > 0)
                            //        //{
                            //        //    bagianPin = PinId.Bagian.SalesBL;

                            //        //    dt = new DataTable();
                            //        //    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            //        //    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowid));
                            //        //    db.Commands[1].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagianPin));
                            //        //    db.Commands[1].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                            //        //    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            //        //    dt = db.Commands[1].ExecuteDataTable();
                            //        //    db.Commands[1].ExecuteNonQuery();
                            //        //}
                            //    }
                            //}
                            #endregion
                        }
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

//------------------------------------------------- SELESAI SIMPAN ----------------------------------------------------


        
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


        #region getPromo
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
                if (lookupJenisTransaksi1.IdTr == "K2" || lookupJenisTransaksi1.IdTr == "K4")
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetPromoBarang_LIST"));
                        dtPromoBrg = db.Commands[0].ExecuteDataTable();
                    }
                }

                //tutup dulu
                //for (i = 0; i < DataGridDO.Rows.Count; i++)
                //{
                //    string idbrng = DataGridDO.Rows[i].Cells[0].Value.ToString();
                //    DataTable dtpromobarang = Prolib.DataPromoBarang(_barangID);
                //    qtybarang = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
                //    hargajualbarang = Convert.ToDouble(DataGridDO.Rows[i].Cells["GvJumlah"].Value);
                //    if (dtpromobarang.Rows.Count > 0)
                //    {
                //        sumqtyBarang = sumqtyBarang + qtybarang;
                //        sumhargajualbarang = sumhargajualbarang + hargajualbarang;
                //    }
                //}
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

                        #region tutup
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
                        #endregion
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


                //if (dtPromoBarangBonus.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0 || dtPromoTahunan.Rows.Count > 0 )
                if (dtPromoBrg.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0 || dtPromoTahunan.Rows.Count > 0)
                {
                    string idtoko = lookupToko1.KodeToko;
                    DO.frmpilihbonusDO ifrmChild = new DO.frmpilihbonusDO(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBrg, dtpromoKelompok, dtPromoTahunan);
                    //DO.frmpilihbonusDO ifrmChild = new DO.frmpilihbonusDO(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBarangBonus, dtpromoKelompok, dtPromoTahunan);
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
        #endregion


        #region promo lama
        /*Get Promo Lama*/
        //=========================================================================
        //public void getPromo()
        //{
        //    #region promo tagihan
        //    //transaksi penjualan pertama setiap bulan, kode toko buat input, trus cek nota diya pernah transaksi di bulan yang sama, where ambil bulan tglsj = getdate(brti salah);
        //    DataTable dtTagihan;
        //    kodetoko = lookupToko1.KodeToko;
        //    if (Prolib.CekHistPromo(kodetoko) == false)
        //    {
        //        dtTagihan = new DataTable();
        //    }
        //    else
        //    {
        //        dtTagihan = Prolib.CekTagihan(kodetoko);
        //    }
        //    if (dtTagihan.Rows.Count > 0)
        //    {
        //        frmPromoTagihan ifrmChild = new frmPromoTagihan(this, dtTagihan);
        //        ifrmChild.ShowDialog();
        //    }
        //    #endregion
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
        //        int sumqtyTahunan = 0;
        //        double sumhargajualTahunan = 0;
        //        int qtyTahunan = 0;
        //        double hargajualTahunan = 0;
        //        int sumKelipatanQtyBarang = 0;
        //        int sumKelipatanQtyKelompok = 0;
        //        int sumKelipatanQtyTahunan = 0;
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
        //        for (i = 0; i < DataGridDO.Rows.Count; i++)
        //        {
        //            string idbrng = DataGridDO.Rows[i].Cells[0].Value.ToString();
        //            DataTable dtpromobarang = Prolib.DataPromoBarang(_barangID);
        //            qtybarang = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
        //            hargajualbarang = Convert.ToDouble(DataGridDO.Rows[i].Cells["GvJumlah"].Value);
        //            if (dtpromobarang.Rows.Count > 0)
        //            {
        //                sumqtyBarang = sumqtyBarang + qtybarang;
        //                sumhargajualbarang = sumhargajualbarang + hargajualbarang;
        //            }
        //        }
        //        #endregion
        //        #region promo kelompok nya
        //        DataTable dtPromoKelompok, dtPromoTahunan = new DataTable();
        //        for (i = 0; i < DataGridDO.Rows.Count; i++)
        //        {
        //            if (Prolib.cekpromokelompok(_barangID) == true)
        //            {
        //                qtyKelompok = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
        //                sumqtyKelompok = sumqtyKelompok + qtyKelompok;
        //                //DataGridDO.Rows[i].Cells["GvJumlah"].Value = jumnetakhir;
        //                hargajualKelompok = Convert.ToDouble(label12.Text.ToString());
        //                //MessageBox.Show(hargajualKelompok.ToString());
        //                sumhargajualKelompok = hargajualKelompok; //sumhargajualKelompo + hargajualKelompok;
        //                dtPromoKelompok = Prolib.DataPromoKelompok(sumqtyKelompok, sumhargajualKelompok);
        //                //DataTable dtPromoTahunan = new DataTable();
        //                /*  for (i = 0; i < dtPromoKelompok.Rows.Count; i++)
        //                {
        //                    if (Prolib.PromoTahunan() == true)
        //                    {
        //                        //qtyTahunan = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
        //                        //sumqtyTahunan = sumqtyTahunan + qtyTahunan;
        //                        //hargajualTahunan = Convert.ToDouble(label12.Text.ToString());
        //                        //sumhargajualTahunan = hargajualTahunan;
        //                        dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyKelompok, sumhargajualKelompok);
        //                        string KodeToko = lookupToko1.KodeToko;
        //                        string KodeBarang = dtPromoTahunan.Rows[0]["id_brg"].ToString();
        //                        if (Prolib.CekHistoryTokoTahunan(KodeToko, KodeBarang) == true)
        //                        {
        //                            dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyKelompok, sumhargajualKelompok);
        //                        }
        //                        else
        //                        {
        //                            dtPromoTahunan = new DataTable();
        //                        }
        //                    }
        //                }*/
        //            }
        //        }
        //        #endregion
        //        #region Promo Tahunan
        //        //DataTable dtPromoTahunan = new DataTable();
        //        for (i = 0; i < DataGridDO.Rows.Count; i++)
        //        {
        //            if (Prolib.PromoTahunan(_barangID) == true)
        //            {
        //                qtyTahunan = Convert.ToInt32(DataGridDO.Rows[i].Cells["GvQty"].Value);
        //                sumqtyTahunan = sumqtyTahunan + qtyTahunan;
        //                hargajualTahunan = Convert.ToDouble(label12.Text.ToString());
        //                sumhargajualTahunan = hargajualTahunan;
        //                dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyTahunan, sumhargajualTahunan);
        //                string KodeToko = lookupToko1.KodeToko;
        //                string KodeBarang = dtPromoTahunan.Rows[0]["id_brg"].ToString();
        //                if (Prolib.CekHistoryTokoTahunan(KodeToko, KodeBarang) == true)
        //                {
        //                    dtPromoTahunan = Prolib.DataPromoTahunan(sumqtyTahunan, sumhargajualTahunan);
        //                }
        //                else
        //                {
        //                    dtPromoTahunan = new DataTable();
        //                }
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
        //                            kelipatanKelompok = Convert.ToInt32(Math.Floor(Convert.ToDouble(smaxKelompok) / sminKelompok));
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
        //        #region enduser Tahunan
        //        for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
        //        {
        //            if (lookupToko1.NamaToko == "ECERAN CASH")
        //            {
        //                Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
        //                //panggil dari prolib yang fungsi cek enduser
        //                if (Prolib.Enduser(PromoRowIDTahunan) == true)
        //                {
        //                    //akumulasi
        //                    #region Akumulasi Tahunan
        //                    for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
        //                    {
        //                        DateTime hari = DateTime.Now;
        //                        kodetoko = lookupToko1.KodeToko;
        //                        int akumulasihari, qtyakumulasi;
        //                        double hargaJualAkumulasi;
        //                        //Guid PromoRowID = (Guid)(dtpromoTahunan.Rows[i]["PromoDetailRowID"]);
        //                        DataTable dtAkumulasihari, dtAkumulasiPenjualan;
        //                        if (Prolib.Akumulasi(PromoRowIDTahunan) == true)
        //                        {
        //                            //ambil akumulasi berapa hari
        //                            dtAkumulasihari = Prolib.AmbilHari(PromoRowIDTahunan);
        //                            akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                            if (akumulasihari == 0)
        //                            {
        //                                akumulasihari = 1;
        //                            }
        //                            dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
        //                            qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
        //                            hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);
        //                            //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                            sumqtyTahunan = qtyakumulasi + qtybarang;
        //                            sumhargajualTahunan = hargaJualAkumulasi + hargajualTahunan;
        //                        }
        //                    }
        //                    #endregion
        //                    //kelipatan
        //                    #region kelipatan promo Tahunan
        //                    for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
        //                    {
        //                        //Guid PromoRowIDTahunan = (Guid)(dtpromoTahunan.Rows[i]["PromoDetailRowID"]);
        //                        int qminTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_min"]);
        //                        int qmaxTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_max"]);
        //                        double sminTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_min"]);
        //                        double smaxTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_max"]);
        //                        int qtybonusTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["qty_bns"]);
        //                        int kelipatanTahunan = 1;
        //                        if (Prolib.Kelipatan(PromoRowIDTahunan) == true)
        //                        {
        //                            //cek syarat qtymax barang
        //                            if (qmaxTahunan > 0 && sumqtyTahunan <= qmaxTahunan)
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
        //                            }
        //                            if (qmaxTahunan > 0 && sumqtyTahunan > qmaxTahunan)
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxTahunan) / qminTahunan));
        //                            }
        //                            //cek syarat smax barang
        //                            if (smaxTahunan > 0 && sumhargajualTahunan <= smaxTahunan)
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
        //                            }
        //                            if (smaxTahunan > 0 && sumhargajualTahunan >= smaxTahunan)
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / smaxTahunan));
        //                            }
        //                            if (qmaxTahunan == 0 && smaxTahunan == 0)
        //                            {
        //                                if (qminTahunan == 0)
        //                                {
        //                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
        //                                }
        //                                else
        //                                {
        //                                    kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
        //                                }
        //                            }
        //                            //menghitung kelipatan 
        //                            sumKelipatanQtyTahunan = kelipatanTahunan * qtybonusTahunan;
        //                            dtPromoTahunan.Rows[i]["qty_bns"] = sumKelipatanQtyTahunan.ToString();
        //                        }
        //                    }
        //                    #endregion
        //                }
        //            }
        //            else
        //            {
        //                //masuk ke bawah
        //                #region Akumulasi Tahunan
        //                for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
        //                {
        //                    DateTime hari = DateTime.Now;
        //                    kodetoko = lookupToko1.KodeToko;
        //                    int akumulasihari, qtyakumulasi;
        //                    double hargaJualAkumulasi;
        //                    Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
        //                    DataTable dtAkumulasihari, dtAkumulasiPenjualan;
        //                    if (Prolib.Akumulasi(PromoRowIDTahunan) == true)
        //                    {
        //                        //ambil akumulasi berapa hari
        //                        dtAkumulasihari = Prolib.AmbilHari(PromoRowIDTahunan);
       //                        akumulasihari = Convert.ToInt32(dtAkumulasihari.Rows[i]["hrg_promo"]);
        //                        if (akumulasihari == 0)
        //                        {
        //                            akumulasihari = 1;
        //                        }
        //                        dtAkumulasiPenjualan = Prolib.AkumulasiPenjualan(akumulasihari, kodetoko);
        //                        qtyakumulasi = Convert.ToInt32(dtAkumulasiPenjualan.Rows[0]["finalqty"]);
       //                        hargaJualAkumulasi = Convert.ToDouble(dtAkumulasiPenjualan.Rows[0]["finalharga"]);
        //                        //mencari history qty dan history harga ditambah dengan penjualan yang sedang di input
        //                        sumqtyTahunan = qtyakumulasi + qtybarang;
        //                        sumhargajualTahunan = hargaJualAkumulasi + hargajualTahunan;
        //                    }
        //                }
        //                #endregion
        //                #region kelipatan promo Tahunan
        //                for (i = 0; i < dtPromoTahunan.Rows.Count; i++)
        //                {
        //                    Guid PromoRowIDTahunan = (Guid)(dtPromoTahunan.Rows[i]["PromoDetailRowID"]);
        //                    int qminTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_min"]);
        //                    int qmaxTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["q_max"]);
        //                    double sminTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_min"]);
        //                    double smaxTahunan = Convert.ToDouble(dtPromoTahunan.Rows[i]["s_max"]);
        //                    int qtybonusTahunan = Convert.ToInt32(dtPromoTahunan.Rows[i]["qty_bns"]);
        //                    int kelipatanTahunan = 1;
        //                    if (Prolib.Kelipatan(PromoRowIDTahunan) == true)
        //                    {
        //                        //cek syarat qtymax barang
        //                        if (qmaxTahunan > 0 && sumqtyTahunan <= qmaxTahunan)
        //                        {
        //                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
        //                        }
        //                        if (qmaxTahunan > 0 && sumqtyTahunan > qmaxTahunan)
        //                        {
        //                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(qmaxTahunan) / qminTahunan));
        //                        }
        //                        //cek syarat smax barang
        //                        if (smaxTahunan > 0 && sumhargajualTahunan <= smaxTahunan)
        //                        {
        //                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
        //                        }
        //                        if (smaxTahunan > 0 && sumhargajualTahunan >= smaxTahunan)
        //                        {
        //                            kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(smaxTahunan) / sminTahunan));
        //                        }
        //                        if (qmaxTahunan == 0 && smaxTahunan == 0)
        //                        {
        //                            if (qminTahunan == 0)
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumhargajualTahunan) / sminTahunan));
        //                            }
        //                            else
        //                            {
        //                                kelipatanTahunan = Convert.ToInt32(Math.Floor(Convert.ToDouble(sumqtyTahunan) / qminTahunan));
        //                            }
        //                        }
       //                        //menghitung kelipatan 
        //                        sumKelipatanQtyTahunan = kelipatanTahunan * qtybonusTahunan;
        //                        dtPromoTahunan.Rows[i]["qty_bns"] = sumKelipatanQtyTahunan.ToString();
        //                    }
        //                }
       //                #endregion
        //            }
        //        }
        //        #endregion
        //        if (dtPromoBarangBonus.Rows.Count > 0 || dtpromotetap.Rows.Count > 0 || dtpromoKelompok.Rows.Count > 0 || dtPromoTahunan.Rows.Count > 0 )
        //        {
        //            string idtoko = lookupToko1.KodeToko;
        //            DO.frmpilihbonusDO ifrmChild = new DO.frmpilihbonusDO(this, idtoko, sumqtyBarang, sumhargajualbarang, sumqtyKelompok, sumhargajualKelompok, dtPromoBarangBonus, dtpromoKelompok,dtPromoTahunan);
        //            ifrmChild.ShowDialog();
        //        }
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
        //====================================================================================
        #endregion


        private void cmdTutup_Click_1(object sender, EventArgs e)
        {
            GenuineTrans();
            if (!_isOk)
                return;

            _isEsc = false;
            if (validation())
            {

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

                        if (harga <= 0)
                        {
                            if (harga < 0 || (promoFlag == string.Empty && plu.Substring(0, 3) != "FXB"))
                            {
                                int b = a + 1;
                                MessageBox.Show("Baris " + b + " KODE BARCODE, HARGA Kosong" + "\n" + "Baris ini akan dihapus sebelum 'Tutup Transaksi'");
                                this.DataGridDO.Rows[a].Selected = true;
                                this.DataGridDO.FirstDisplayedScrollingRowIndex = a;
                                deleterows();
                                return;
                            }
                        }

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

                        //cek jika edit data harga di entry do yang kurang dari harga HPP atau Harga Final
                        GetPembandingHarga(plu);
                        //DataGridDO.Rows[a].Cells["GvNoAcc"].Value = string.Empty;

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
                //}

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

        private void DataGridDO_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void GetPembandingHarga(string idbarang)
        {
            if (idbarang.Substring(0, 3) != "FXB")
            {
                _hargaFinal = 0;
                _barangID = idbarang;
                if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                    lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                {
                    GetHrgJual();
                    GetHrgBMK();
                    //GetHrgKhusus();
                    GetHargaHpp(idbarang);
                }
                else
                {
                    GetHrgJual();
                    GetHrgBMK();
                    //GetHrgKhusus();
                    GetHargaHpp(idbarang);
                }
            }
            string jenis2;
            jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

            double _hrgHppNew = 0;
            decimal persen = 0.01m;

            if (flagkg == "KG")
            {
                _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
            }

            if (TxtNamaToko.Text != "ECERAN CASH")
            {
                if (jenis2 == "T" || jenis2 == "t")
                {
                    _hargaFinal = _hrgB;
                }
                if (jenis2 == "K" || jenis2 == "k")
                {
                    if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                        lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    {
                        if (flagkg == "KG")
                            _hargaFinal = _hrgB;
                        else
                        {
                            if (GlobalVar.Gudang == "2807")
                                _hargaFinal = _hrgB;
                            else
                                _hargaFinal = _hrgM;
                        }
                    }
                }
            }
            else
            {
                _hargaFinal = _hrgK;
            }
        }


        private void DataGridDO_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
    

        private void BtnCariBarcode_Click(object sender, EventArgs e)
        {

        }

   
         
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        

        private void DataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }


        private void TxtJW_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) 
            { 
            e.Handled = false; 
            } 
            else 
            { 
            e.Handled = true; 
            } 
        }             
   
        private void FrmDO_KeyDown(object sender, KeyEventArgs e)
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
                    //if (GlobalVar.Gudang == "2823" || GlobalVar.Gudang == "2803" || GlobalVar.Gudang == "2807")
                        TampilFormBarang();
                    //else
                    //{
                    //    GenuineTrans();
                    //    if (!_isOk)
                    //    {
                    //        return;
                    //    }
                    //    if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                    //        lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    //    {
                    //        if (flagkg == "KG")
                    //            TampilFormBarang();
                    //        else
                    //            MessageBox.Show("Transaksi penjualan Barang Genuine harus Tunai");
                    //    }
                    //    else
                    //        TampilFormBarang();
                    //}
                }
            }
        }

        
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GlobalVar.Gudang == "2803" || GlobalVar.Gudang == "2823" || GlobalVar.Gudang == "2808")
                    AmbilBarang3();
                else
                {
                    if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                        lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    {
                        if (flagkg == "KG")
                           AmbilBarang3();
                        else
                            MessageBox.Show("Transaksi Penjualan Barang Genuine harus Tunai");
                    }
                    else
                    {
                        AmbilBarang3();
                    }
                }
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
            if (TxtNamaToko.Text == "")
            {
                MessageBox.Show("Data Customer masih kosong..\nMohon diisi dahulu karena akan mempengaruhi harga BMK");
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

            //MessageBox.Show(kelompok.ToString()+"  "+flagkg);
            //this.Cursor = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perkode"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci",SqlDbType.VarChar, TxtBarcode.Text));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, kelompok.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
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
                    for (a = 0; a < DataGridDO.Rows.Count ; ++a)
                    {
                        string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            //MessageBox.Show("'" + namabarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK,MessageBoxIcon.Stop);
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
                       ////GetHrgKhusus();
                       GetHargaHpp(idbarang);
                       //GetHargaPriceList(DateTime.Parse(TxtTGL.DateValue.ToString()), _barangID);

                       //if (lookupJenisTransaksi1.IdTr == "K4")
                       //{
                       //    GetFlagHR4("HKR4");
                       //    if (nDiscK4 > 0 && _Hnet > 0)
                       //    {
                       //        decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                       //        _hrgM = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                       //        _hargaFinal = _hrgM;
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
                       //            _hargaFinal = _hrgM;
                       //        }
                       //        else
                       //        {
                       //            GetHrgJual();
                       //        }
                       //    }
                       //}
                   }

                   string jenis2;
                   jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

                   if (TxtNamaToko.Text != "ECERAN CASH")
                   {
                       if (jenis2 == "T" || jenis2 == "t")
                       {
                            _hargaFinal = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgB;
                       }

                       if (jenis2 == "K" || jenis2 == "k")
                       {
                           if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" || lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                           {
                               #region gudang 2803
                               if (GlobalVar.Gudang == "2803")
                               {
                                   DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                               }
                               #endregion 

                               #region gudang 2823
                               if (GlobalVar.Gudang == "2823")
                               {
                                   _hargaFinal = _hrgM;
                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                                   //DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                               }
                               #endregion 

                               #region gudang 2807
                               if (GlobalVar.Gudang == "2807")
                               {
                                   _hargaFinal = _hrgB;
                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
                               }
                               #endregion 

                               #region depo standar
                               if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2823" && GlobalVar.Gudang != "2807")
                               {
                                   //_hargaFinal = _hrgM;
                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                                   DataGridDO.Rows[nRowIndex].Cells[10].Value = _hargaFinal;
                               }
                               #endregion 
                           }

                           if (lookupJenisTransaksi1.IdTr == "K4")
                           {
                               _hargaFinal = _hrgM;
                               DataGridDO.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                               DataGridDO.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                               DataGridDO.Rows[nRowIndex].Cells[10].Value = _hargaFinal;
                           }

                           if (lookupJenisTransaksi1.IdTr == "K2")
                           {
                               _hargaFinal = _hrgM;
                               DataGridDO.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                               DataGridDO.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                               DataGridDO.Rows[nRowIndex].Cells[10].Value = _hargaFinal;
                           }
                       }
                   }
                   else
                   {
	                   _hargaFinal = _hrgK;
                       DataGridDO.Rows[nRowIndex].Cells[4].Value = _hargaFinal;
                       DataGridDO.Rows[nRowIndex].Cells[9].Value = _hargaFinal;
                       DataGridDO.Rows[nRowIndex].Cells[10].Value = _hargaFinal;
                   }

                   DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                   DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                   DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                   DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;
                    
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

                    if (DataGridDO.Rows.Count  >= 2)
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


        #region tutup
        //                       if (flagkg == "KG")
        //                       {
        //                           //Kebijakan baru dari HBK
        //                           //Harga jual kredit genuine (KG) = Harga jual Tunai (TG)
        //                           decimal persen = 0.01m;
        //                           _hargaFinal = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
        //                           _hrgB = _hargaFinal;
        //                           DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
        //                           DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
        //                           DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgB;
        //                       }
        //                       else
        //                       {
        //                           if (GlobalVar.Gudang == "2807")
        //                           {
        //                               if (_hrgB == 0)
        //                               {
        //                                   MessageBox.Show("Harga Jual 0, Hubungi HO");
        //                                   double _hrgHppNew = 0;
        //                                   decimal persen = 0.01m;
        //                                   _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
        //                                   _hargaFinal = _hrgHppNew;
        //                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgHppNew;
        //                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgHppNew;
        //                               }
        //                               else
        //                               {
        //                                   _hargaFinal = _hrgB;
        //                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
        //                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
        //                               }
        //                           }
        //                           else
        //                           {
        //                               if (_hrgM == 0)
        //                               {
        //                                   MessageBox.Show("Harga Jual 0, Hubungi HO");
        //                                   double _hrgHppNew = 0;
        //                                   decimal persen = 0.01m;
        //                                   _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);
        //                                   _hargaFinal = _hrgHppNew;
        //                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgHppNew;
        //                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgHppNew;
        //                               }
        //                               else
        //                               {
        //                                   _hargaFinal = _hrgM;
        //                                   DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgM;
        //                                   DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgM;
        //                               }
        //                           }
        //                       }
        //                   }
        //                   else
        //                   {
        //                       _hargaFinal = _hrgM;
        //                       DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgM;
        //                       DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgM;
        //                   }
        //               }
        //           }
        //           else
        //           {
        //               _hargaFinal = _hrgK;
        //               DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgK;
        //               DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgK;
        //           }

        //           #region harga tidak boleh kurang dari atau sama dengan 0

        //           if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
        //           {
        //               for (a = 0; a < DataGridDO.Rows.Count; a++)
        //               {
        //                   int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
        //                   if (qty > 0)
        //                   {
        //                       //if (idbarang != "FXBSOFTDRINK" && idbarang != "FXBBISKUITKL" && idbarang != "FXBKURSIBKSO" && idbarang != "FXBTSHIRTOBL")
        //                       //{
        //                       if (idbarang.Substring(0, 3) != "FXB")
        //                       {
        //                           if (_hargaFinal <= 0 && _hrgHPP <= 0)
        //                           {
        //                               DataGridDO.AllowUserToAddRows = false;
        //                               b = a + DataGridDO.Rows.Count;
        //                               MessageBox.Show("Harga Jual dan HPP masih 0,Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
        //                               //if (b > 2)
        //                               //{
        //                               //DataGridDO.Rows.Remove(DataGridDO.Rows[b]);
        //                               //}
        //                               DataGridDO.Rows.Remove(DataGridDO.Rows[a]);
        //                               DataGridDO.AllowUserToAddRows = false;
        //                               return;
        //                           }
        //                       }
        //                   }
        //               }
        //           }
        //           #endregion

        //           DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
        //           DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
        //           DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
        //           DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;
                    
        //           DataGridDO.MultiSelect = false;
        //           DataGridDO.BeginEdit(true);
        //           DataGridDO.AllowUserToAddRows = false;

        //           #region hitung total2

        //            int sum = 0;
        //            kuantiti2 = 0;
        //            for (int i = 0; i < DataGridDO.Rows.Count; ++i)
        //            {
        //                sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[9].Value);
        //                kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
        //            }

        //            label12.Text = sum.ToString("N0");
        //            lblqty.Text = kuantiti2.ToString("N0");
        //            TxtBarcode.Text = "";

        //            if (DataGridDO.Rows.Count  >= 2)
        //            {
        //                DataGridDO.Rows[nRowIndex].Cells[2].Selected = true;
        //            }

        //           #endregion
        //        }
        //        this.Cursor = Cursors.Default;
        //        //getPromo();
        //        DataGridDO.AllowUserToAddRows = false;
        //    }
        //}
        #endregion

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
                //TampilFormBarang();
                MessageBox.Show("Barcode tidak ditemukan..!");
                return;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string idbarang = Convert.ToString(dr["BarangID"]);
                    string namabarang = Convert.ToString(dr["NamaStok"]);
                    bool lCek = false;
                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string idbarangcell = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        if (idbarang == idbarangcell)
                        {
                            lCek = true;
                            DataGridDO.Rows[a].Cells[2].Value = Int32.Parse(Tools.isNull(DataGridDO.Rows[a].Cells[2].Value, "0").ToString()) + 1;
                            Double hjl = Double.Parse(Tools.isNull(DataGridDO.Rows[a].Cells[9].Value, "0").ToString());
                            Int32 qdo = Int32.Parse(Tools.isNull(DataGridDO.Rows[a].Cells[2].Value, "0").ToString());
                            DataGridDO.Rows[a].Cells[10].Value = qdo * hjl;
                            TxtBarcode.Text = "";
                            //return;
                            //MessageBox.Show("'" + namabarang + "'" + "\n" + " sudah ada di daftar belanja..", "INFORMASI", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                            //this.Cursor = Cursors.Default;
                            //return;
                        }
                        DataGridDO.AllowUserToAddRows = false;
                    }

                    if (lCek)
                    {
                        double xsum = 0;
                        int xkuantiti2 = 0;
                        for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                        {
                            xsum += Convert.ToDouble(DataGridDO.Rows[i].Cells[10].Value);
                            xkuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                        }
                        label12.Text = xsum.ToString("N0");
                        lblqty.Text = xkuantiti2.ToString("N0");
                        return;
                    }

                    DataGridDO.AllowUserToAddRows = true;
                    DataGridDO.Rows.Add(1);
                    DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["BarangID"];
                    DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    if (!lCek)
                    {
                        DataGridDO.Rows[nRowIndex].Cells[2].Value = 1;
                    }
                    DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];

                    _barangID = Convert.ToString(dr["BarangID"]);
                    QTYPOS = "1";
                    _c1 = cab1;

                    if (idbarang.Substring(0, 3) != "FXB")
                    {
                        if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                            lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                        {
                            GetHrgJual();
                            GetHrgBMKMessage();
                            //GetHrgKhusus();
                            GetHargaHpp(idbarang);
                        }
                        else
                        {
                            if (lookupJenisTransaksi1.IdTr == "K4")
                            {
                                GetFlagHR4("HKR4");
                                if (flagHR4 == "" || flagHR4 == "0")
                                {
                                    GetHrgJual();
                                }
                                else
                                {
                                    GetHrgJualHKR4();
                                }
                            }
                            //GetHrgJual();
                            GetHrgBMKMessage();
                            //GetHrgKhusus();
                            GetHargaHpp(idbarang);
                        }
                    }

                    string jenis2;
                    jenis2 = Tools.Left(lookupJenisTransaksi1.IdTr, 1);

                    if (TxtNamaToko.Text != "ECERAN CASH")
                    {
                        if (jenis2 == "T" || jenis2 == "t")
                        {
                            _hargaFinal = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
                            DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgB;
                        }
                        if (jenis2 == "K" || jenis2 == "k")
                        {
                            if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                                lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                            {
                                if (flagkg == "KG")
                                {
                                    _hargaFinal = _hrgB;
                                    DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgB;
                                    DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgB;
                                    DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgB;
                                }
                                else
                                {
                                    _hargaFinal = _hrgM;
                                    DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgM;
                                    DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgM;
                                    DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgM;
                                }
                            }
                            else
                            {
                                _hargaFinal = _hrgM;
                                DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgM;
                                DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgM;
                                DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgM;
                            }
                        }
                    }
                    else
                    {
                        _hargaFinal = _hrgK;
                        DataGridDO.Rows[nRowIndex].Cells[4].Value = _hrgK;
                        DataGridDO.Rows[nRowIndex].Cells[9].Value = _hrgK;
                        DataGridDO.Rows[nRowIndex].Cells[10].Value = _hrgK;
                    }

                    #region harga tidak boleh kurang dari atau sama dengan 0
                    for (a = 0; a < DataGridDO.Rows.Count; a++)
                    {
                        int qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        if (qty > 0)
                        {
                            //if (idbarang != "FXBSOFTDRINK" && idbarang != "FXBBISKUITKL" && idbarang != "FXBKURSIBKSO" && idbarang != "FXBTSHIRTOBL")
                            //{
                            if (idbarang.Substring(0, 3) != "FXB")
                            {
                                if (_hargaFinal <= 0 && _hrgHPP <= 0)
                                {
                                    DataGridDO.AllowUserToAddRows = false;
                                    b = a + DataGridDO.Rows.Count;
                                    MessageBox.Show("Harga Jual dan HPP masih 0,Segera Hubungi HO bagian Penjualan Untuk mendapatkan Harga");
                                    //if (b > 2)
                                    //{
                                    //DataGridDO.Rows.Remove(DataGridDO.Rows[b]);
                                    //}
                                    DataGridDO.Rows.Remove(DataGridDO.Rows[a]);
                                    DataGridDO.AllowUserToAddRows = false;
                                    return;
                                }
                            }
                            //}
                        }
                    }
                    #endregion

                    DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;

                    DataGridDO.MultiSelect = false;
                    DataGridDO.BeginEdit(true);
                    DataGridDO.AllowUserToAddRows = false;

                    #region hitung total2

                    int sum = 0;
                    kuantiti2 = 0;
                    for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(DataGridDO.Rows[i].Cells[10].Value);
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


        private void GetHrgJualHKR4()
        {
            if (_barangID != "" && double.Parse(QTYPOS) != 0)
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
                    {
                        _hrgJual = Convert.ToDouble(Tools.isNull(dtGetHrgJualR4.Rows[0]["Hnet"], "0").ToString());
                        _Hnet = Convert.ToDouble(Tools.isNull(dtGetHrgJualR4.Rows[0]["Hnet"], "0").ToString());
                    }
                    else
                    {
                        _hrgJual = 0;
                        _Hnet = 0;
                    }

                    HrgJualBMK_ = _hrgJual;
                    _hargaFinal = _hrgJual;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TampilFormBarang();
        }


        private void TampilFormBarang()
        {
            if (GlobalVar.Gudang == "2808")
                flagkg = "";
            
            DO.FrmBarcodeDO ifrmChild = new DO.FrmBarcodeDO(this, lookupJenisTransaksi1.IdTr,flagkg);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
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
                        db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                        dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtGetHrgJual.Rows.Count > 0)
                    {
                        _hrgJual = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                        //Tambahan
                        HrgJualBMK_ = _hrgJual;
                        _hargaFinal = _hrgJual;
                    }
                    else
                    {
                        _hrgJual = 0;
                        HrgJualBMK_ = 0;
                        _hargaFinal = 0;
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

        private void DataGridDO_KeyDown(object sender, KeyEventArgs e)
        {

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

            //Application.DoEvents();
            //Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //this.RefreshDataDO();
            //this.FindHeader("RowID", rowID.ToString());
        }

        private void lookupSales1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (lookupSales1.RowID != Guid.Empty)
            //    {
            //        txtNorq.Focus();
            //        idsales = lookupSales1.SalesID;
            //    }
            //    else
            //    {
            //        lookupSales1.Focus();
            //    }

            //}
        }

        private void lookupSales1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (lookupSales1.RowID != Guid.Empty)
                {
                    txtNorq.Focus();
                    idsales = lookupSales1.SalesID;
                }
                else
                {
                    lookupSales1.Focus();
                }

            }
        }

        private void CBShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNorq.Focus();
            }
        }

        private void txtNorq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridDO.Focus();
            }
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

        private void DataGridDO_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void lookupJenisTransaksi1_SelectData(object sender, EventArgs e)
        {

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
        

        private void UpdateEntryDo(DataTable dt)
        {
            dtAG = dt;
            int nRowIndex = 0;

            if (dt != null)
            {
                txtNorq.Text = Tools.isNull(dtAG.Rows[0]["NoAg"], "AG2803").ToString();
                AGTransactionID = Tools.isNull(dtAG.Rows[0]["TransactionID"], "").ToString();

                foreach (DataRow dr in dtAG.Rows)
                {
                    DataGridDO.Rows.Add(1);
                    DataGridDO.Rows[nRowIndex].Cells[0].Value = dr["KodeBarang"];
                    DataGridDO.Rows[nRowIndex].Cells[1].Value = dr["NamaStok"];
                    DataGridDO.Rows[nRowIndex].Cells[2].Value = Convert.ToInt32(dr["QtyKirim"]);
                    DataGridDO.Rows[nRowIndex].Cells[3].Value = dr["SatJual"];
                    DataGridDO.Rows[nRowIndex].Cells[4].Value = Convert.ToInt32(dr["hjual"]);
                    DataGridDO.Rows[nRowIndex].Cells[5].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[6].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[7].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[8].Value = 0;
                    DataGridDO.Rows[nRowIndex].Cells[9].Value = Convert.ToInt32(dr["QtyKirim"]) * Convert.ToInt32(dr["hjual"]);
                    nRowIndex += 1;
                    JumlahDo += (Convert.ToInt32(dr["QtyKirim"]) * Convert.ToInt32(dr["hjual"]));
                }
            }
        }


        private void GenuineTrans()
        {
            _isOk = true;
            string trtype_ = lookupJenisTransaksi1.IdTr;
            if (trtype_ == "KG" || trtype_ == "KB" || trtype_ == "KV" || trtype_ == "KC")
            {
                if (GlobalVar.Gudang != "2823" && GlobalVar.Gudang != "2807" && GlobalVar.Gudang != "2803")
                {
                    string kdtoko_ = lookupToko1.KodeToko;
                    double overdueFX = TokoOverdue.OverdueFX(kdtoko_);

                    GetFlagKg(kdtoko_);
                    if (flagkg == "KG")
                    {
                        //ditutup, agar bisa pengajuan ke ho
                        //if (overdueFX > 0)
                        //{
                        //    MessageBox.Show("Masih ada Nota FX yang sudah jatuh tempo dan belum terbayar");
                        //    _isOk = false;
                        //}
                    }
                    else
                    {
                        if (GlobalVar.Gudang != "2808")
                        {
                            MessageBox.Show("Pengambilan barang Genuine harus menggunakan Transaksi Tunai");
                            _isOk = false;
                        }
                    }
                }
            }
        }


        private void lookupToko1_Load(object sender, EventArgs e)
        {
            DateTime waktu = DateTime.Now;
            timer1.Enabled = true;
        }

        private void lookupToko1_SelectData_1(object sender, EventArgs e)
        {
            try
            {
                kodetoko = lookupToko1.KodeToko;
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodetoko));
                    dtToko = db.Commands[0].ExecuteDataTable();
                    if (dtToko.Rows.Count > 0)
                    {
                        JWtoko = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["JangkaWaktuKredit"], "0").ToString());
                        JStoko = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["HariSales"], "0").ToString());
                        JXtoko = 0;

                        JWtokoFx = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["JangkaWaktuKreditFX"], "0").ToString());
                        JStokoFx = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["HariSalesFX"], "0").ToString());
                        JXtokoFx = 0;

                        JWtokoFAB = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["JangkaWaktuKreditFAB"], "0").ToString());
                        JStokoFAB = Convert.ToInt32(Tools.isNull(dtToko.Rows[0]["HariSalesFAB"], "0").ToString());
                        JXtokoFAB = 0;
                    }
                }

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

                stsToko = Tools.isNull(stsToko, "").ToString();
                _stsToko = Tools.isNull(stsToko, "").ToString();

                stsTk = stsToko.ToString();
                txtstatus.Text = _stsToko.ToString();

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

                JStoko = lookupToko1.HariSales;
                JXtoko = lookupToko1.HariKirim;

                //GetFlagKg(kodetoko);

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

                    #region Plafon 04
                    //double plafonToko = TokoPlafon.Plafon(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    //if (plafonToko > 0)
                    //{
                    //    txtPlafon.Text = string.Format("{0:N0}", plafonToko);
                    //    BtnSearch.Enabled = true;
                    //    TxtBarcode.Enabled = true;
                    //}
                    //else
                    //{
                    //    if (lookupJenisTransaksi1.IdTr.Substring(0, 1) == "K")
                    //        MessageBox.Show("Toko " + kodetoko + " Belum Punya Plafon /n Hubungi PSHO");

                    //    BtnSearch.Enabled = true;   //false;
                    //    TxtBarcode.Enabled = true;  //false;
                    //}
                    #endregion

                    #region Piutang
                    //double piutangToko = TokoPlafon.Piutang(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    //txtpiutang.Text = string.Format("{0:N0}", piutangToko);
                    #endregion

                    #region GIT
                    //double gitToko = TokoPlafon.GIT(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    //txtgit.Text = string.Format("{0:N0}", gitToko);
                    #endregion

                    #region Giro
                    //double giroToko = TokoPlafon.Giro(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    //txtgiro.Text = string.Format("{0:N0}", giroToko);
                    #endregion

                    #region Giro Tolak
                    //double giroTolakToko = TokoPlafon.GiroTolak(lookupToko1.KodeToko, lookupJenisTransaksi1.IdTr);
                    //txttolak.Text = string.Format("{0:N0}", giroTolakToko);
                    #endregion

                    #region Sisa Plafon
                    //double sisaPlafonToko = TokoPlafon.SisaPlafon(plafonToko, piutangToko, gitToko, giroToko, giroTolakToko);
                    //txtsisa.Text = string.Format("{0:N0}", sisaPlafonToko);
                    #endregion

                    #region Piutang Overdue
                    //double overdue = TokoOverdue.Overdue(lookupToko1.KodeToko);
                    //txtoverdue.Text = string.Format("{0:N0}", overdue);
                    #endregion

                    #region Piutang Overdue Non Agen
                    //double overdueFB = TokoOverdue.OverdueFB(lookupToko1.KodeToko);
                    //txtoverduefb.Text = string.Format("{0:N0}", overdueFB);
                    #endregion

                    #region Piutang Overdue Agen
                    //double overdueFX = TokoOverdue.OverdueFX(lookupToko1.KodeToko);
                    //txtoverduefx.Text = string.Format("{0:N0}", overdueFX);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void lookupJenisTransaksi1_SelectData_1(object sender, EventArgs e)
        {
            TxtJW.Text = "0";
            txtJS.Text = "0";
            txtjx.Text = "0";

            if (lookupJenisTransaksi1.IdTr != string.Empty)
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

                #region Informasi Toko

                #region Jenis Transaksi
                if (Date1 <= Date2)
                {
                    if (lookupJenisTransaksi1.IdTr == "K2" || lookupJenisTransaksi1.IdTr == "K4")
                    {
                        TxtJW.Text = JWtoko.ToString();
                        txtJS.Text = JStoko.ToString();
                        txtjx.Text = JXtoko.ToString();
                    }
                    else if (lookupJenisTransaksi1.IdTr == "KB")
                    {
                        if (JWtokoFAB > 0)
                            TxtJW.Text = JWtokoFAB.ToString();
                        else
                            TxtJW.Text = lookupJenisTransaksi1.JW.ToString();

                        if (JStokoFAB > 0)
                            txtJS.Text = JStokoFAB.ToString();
                        else
                            txtJS.Text = lookupJenisTransaksi1.JS.ToString();
                    }
                    else if (lookupJenisTransaksi1.IdTr == "KG")
                    {
                        if (GlobalVar.Gudang == "2808")
                        {
                            if (JWtokoFx > 0)
                                TxtJW.Text = JWtokoFx.ToString();
                            else
                                TxtJW.Text = lookupJenisTransaksi1.JW.ToString();

                            if (JStokoFx > 0)
                                txtJS.Text = JStokoFx.ToString();
                            else
                                txtJS.Text = lookupJenisTransaksi1.JS.ToString();
                        }
                        else
                        {
                            TxtJW.Text = lookupJenisTransaksi1.JW.ToString();
                            txtJS.Text = lookupJenisTransaksi1.JS.ToString();
                        }
                    }
                    else
                    {
                        TxtJW.Text = lookupJenisTransaksi1.JW.ToString();
                        txtJS.Text = lookupJenisTransaksi1.JS.ToString();
                    }

                    //if (GlobalVar.Gudang.Substring(0, 1) == "9")
                    //{
                    //    if (TxtJW.Text.Substring(0, 1) == "T")
                    //    {
                    //        MessageBox.Show("Transaksi Tunai Input di menu POS");
                    //        return;
                    //    }
                    //}
                }
                #endregion

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
                    if (lookupJenisTransaksi1.IdTr.Substring(0, 1) == "K")
                        MessageBox.Show("Toko " + kodetoko + " Belum Punya Plafon /n Hubungi PSHO");

                    BtnSearch.Enabled = true;   // false;
                    TxtBarcode.Enabled = true;  // false;
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
                #endregion

                //GenuineTrans();
                //if (!_isOk)
                //{
                //    this.lookupJenisTransaksi1.Focus();
                //    return;
                //}
            }

        }

        private void TxtBarcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GlobalVar.Gudang == "2803" || GlobalVar.Gudang == "2823")
                    AmbilBarang3();
                else
                {
                    //if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                    //    lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    //{
                    //    if (flagkg == "KG")
                    //        AmbilBarang3();
                    //    else
                    //        MessageBox.Show("Transaksi Penjualan Barang Genuine harus Tunai");
                    //}
                    //else
                    //{
                        AmbilBarang3();
                    //}
                }
            }

        }

        private void lookupSales1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (lookupSales1.RowID != Guid.Empty)
                {
                    idsales = lookupSales1.SalesID;
                    txtNorq.Focus();
                }
                else
                {
                    lookupSales1.Focus();
                }
            }
        }

        private void FrmDO2828_KeyDown(object sender, KeyEventArgs e)
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
                    //if (GlobalVar.Gudang == "2823" || GlobalVar.Gudang == "2803" || GlobalVar.Gudang == "2807")
                        TampilFormBarang();
                    //else
                    //{
                    //    GenuineTrans();
                    //    if (!_isOk)
                    //    {
                    //        return;
                    //    }
                    //    if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                    //        lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    //    {
                    //        if (flagkg == "KG")
                    //            TampilFormBarang();
                    //        else
                    //            MessageBox.Show("Transaksi penjualan Barang Genuine harus Tunai");
                    //    }
                    //    else
                    //        TampilFormBarang();
                    //}
                }
            }

        }

        private void FrmDO2828_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataGridDO_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                    if (GlobalVar.Gudang != "2808")
                    {
                        string promoFlag = Tools.isNull(DataGridDO.CurrentRow.Cells["gvPromoFlag"].Value, string.Empty).ToString();

                        if (promoFlag == string.Empty)
                        {
                            string idbrg = Convert.ToString(DataGridDO.CurrentRow.Cells["gVplu"].Value);
                            GetPembandingHarga(idbrg);
                            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = string.Empty;
                            harga = Convert.ToDouble(DataGridDO.CurrentRow.Cells["GvHarga"].Value);
                            GetHargaPriceList(DateTime.Parse(TxtTGL.DateValue.ToString()), _barangID);

                            if (lookupJenisTransaksi1.IdTr == "K4")
                            {
                                GetFlagHR4("HKR4");
                                if (nDiscK4 > 0 && _Hnet > 0)
                                {
                                    decimal x = Convert.ToDecimal(nDiscK4), y = 100;
                                    _hrgM = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                                    _hargaFinal = _hrgM;
                                    DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                                }
                                else
                                {
                                    GetWilayah();
                                    GetDiscWilayah();
                                    if (discwil > 0 && _Hnet > 0)
                                    {
                                        decimal x = Convert.ToDecimal(discwil), y = 100;
                                        _hrgM = _Hnet - (Math.Round(Convert.ToDouble((x / y) * Convert.ToDecimal(_Hnet)), 0));
                                        _hargaFinal = _hrgM;
                                        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                                    }
                                    else
                                    {
                                        GetHrgJual();
                                        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                                    }
                                }
                            }

                            #region tutup sementara
                            ////----------------------------- validasi harga -----------------------------------
                            //if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                            //    lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                            //{
                            //    double _hrgHppNew = 0;
                            //    decimal persen = 0.01m;
                            //    _hrgHppNew = Math.Round(Convert.ToDouble(Convert.ToDecimal(_hrgHPP) + (persen * Convert.ToDecimal(_hrgHPP))), 0);

                            //#region gudang 2803
                            //if (GlobalVar.Gudang == "2803")
                            //{
                            //    DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //}
                            //#endregion

                            //#region gudang = "2823"
                            //if (GlobalVar.Gudang == "2823")
                            //{
                            //    #region harga hpp + 1%
                            //    //harga hpp + 1% ditutup, karena sudah ada harga khusus melalui promo point
                            //    //if (harga < _hrgHppNew || harga < _hrgHPP)
                            //    //{
                            //    //    if (harga < _hrgHPP)
                            //    //        MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //    //    else
                            //    //        MessageBox.Show("Harga Jual dibawah harga Standar " + string.Format("{0:N0}", _hrgHppNew));

                            //    //    DataGridDO[4, e.RowIndex].Value = _hrgHppNew;
                            //    //    DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    //}
                            //    //else
                            //    //{
                            //    //    DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    //}
                            //    #endregion

                            //    if (harga < _hargaFinal)
                            //    {
                            //        MessageBox.Show("Harga Jual dibawah harga Standar " + string.Format("{0:N0}", _hrgHppNew));
                            //        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //        //DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    }
                            //    else if (harga < _hrgHPP)
                            //    {
                            //        MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    }
                            //    else
                            //    {
                            //        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    }
                            //}
                            //#endregion 2823

                            //    #region gudang 2807
                            //    if (GlobalVar.Gudang == "2807")
                            //    {
                            //        #region harga hpp+1%
                            //        if (flagkg == "KG")
                            //        {
                            //            if (harga < _hrgHppNew || harga < _hrgHPP)
                            //            {
                            //                if (harga < _hrgHPP)
                            //                    MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //                else
                            //                    MessageBox.Show("Harga Jual dibawah harga standar " + string.Format("{0:N0}", _hrgHppNew));

                            //                DataGridDO[4, e.RowIndex].Value = _hrgHppNew;
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //            else
                            //            {
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (harga < _hrgB || harga < _hrgHPP)
                            //            {
                            //                if (harga < _hrgHPP)
                            //                    MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //                else
                            //                    MessageBox.Show("Harga Jual dibawah harga standar " + string.Format("{0:N0}", _hrgB));

                            //                DataGridDO[4, e.RowIndex].Value = _hrgB;
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //            else
                            //            {
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //        }
                            //        #endregion

                            //        _hargaFinal = _hrgB;
                            //        if (harga < _hargaFinal)
                            //        {
                            //            MessageBox.Show("Harga Jual dibawah harga Standar " + string.Format("{0:N0}", _hrgHppNew));
                            //            DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        }
                            //        else if (harga < _hrgHPP)
                            //        {
                            //            MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //            DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        }
                            //        else
                            //        {
                            //            DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        }
                            //    }
                            //    #endregion 

                            //    #region Depo standar
                            //    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2823" && GlobalVar.Gudang != "2807")
                            //    {
                            //        #region harga hpp+1%
                            //        //if (flagkg == "KG")
                            //        //{
                            //        //    if (harga < _hrgHppNew || harga < _hrgHPP)
                            //        //    {
                            //        //        if (harga < _hrgHPP)
                            //        //            MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //        //        else
                            //        //            MessageBox.Show("Harga Jual dibawah harga standar " + string.Format("{0:N0}", _hrgHppNew));
                            //        //        DataGridDO[4, e.RowIndex].Value = _hrgHppNew;
                            //        //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        //    }
                            //        //    else
                            //        //    {
                            //        //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        //    }
                            //        //}
                            //        //else
                            //        //{
                            //        //    if (harga < _hargaFinal || harga < _hrgHPP)
                            //        //    {
                            //        //        if (harga < _hrgHPP)
                            //        //            MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //        //        else
                            //        //            MessageBox.Show("Harga Jual dibawah harga Standar " + string.Format("{0:N0}", _hargaFinal));
                            //        //        DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //        //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        //    }
                            //        //    else
                            //        //    {
                            //        //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //        //    }
                            //        //}
                            //        #endregion

                            //        if (lookupJenisTransaksi1.IdTr != "KB" && lookupJenisTransaksi1.IdTr != "KV")
                            //        {
                            //            if (harga < _hrgHPP)
                            //            {
                            //                MessageBox.Show("Harga Jual dibawah Hpp " + string.Format("{0:N0}", _hrgHPP));
                            //                DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //            else if (harga < _hargaFinal)
                            //            {
                            //                MessageBox.Show("Harga Jual dibawah harga Standar " + string.Format("{0:N0}", _hargaFinal));
                            //                DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //            else
                            //            {
                            //                DataGridDO[4, e.RowIndex].Value = harga;    // _hargaFinal;
                            //                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //            }
                            //        }
                            //    }
                            //    #endregion 

                            //}
                            //else if (lookupJenisTransaksi1.IdTr == "K4" || lookupJenisTransaksi1.IdTr == "K2")
                            //{
                            //    if (harga < _hrgHPP)
                            //    {
                            //        MessageBox.Show("Harga dibawah Hpp");
                            //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                            //    }
                            //    else if (harga < _hargaFinal)
                            //    {
                            //        MessageBox.Show("Harga dibawah standar");
                            //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                            //    }
                            //    else
                            //    {
                            //        DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            //    }
                            //}
                            //------------------------------------------------------------------------------

                            //if (_hargaFinal <= 1)
                            //{
                            //    MessageBox.Show("Harga Jual 0, Minta Harga Jual ke HO");
                            //    DataGridDO[4, e.RowIndex].Value = 0;
                            //    return;
                            //}
                            #endregion

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

                double hrg = 0, qty = 0, ds1 = 0, ds2 = 0, ds3 = 0, pot = 0, HrgNet = 0;
                if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2823")
                {
                    hrg = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvHarga"].Value, "0").ToString());
                    qty = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvQty"].Value, "0").ToString());
                    ds1 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD1"].Value, "0").ToString());
                    ds2 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD2"].Value, "0").ToString());
                    ds3 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD3"].Value, "0").ToString());
                    pot = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvPot"].Value, "0").ToString());
                    HrgNet = Convert.ToDouble(Tools.isNull(HitNet3D(hrg, ds1, ds2, ds3, pot), "0").ToString()) - pot;

                    DataGridDO.CurrentRow.Cells["GvHjual"].Value = HrgNet;
                    DataGridDO.CurrentRow.Cells["GvJumlah"].Value = HrgNet * qty;

                    if (lookupJenisTransaksi1.IdTr == "K4" || lookupJenisTransaksi1.IdTr == "K2")
                    {
                        if (HrgNet < _hrgHPP)
                        {
                            MessageBox.Show("Harga dibawah Hpp");
                            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                        }
                        else if (HrgNet < _hargaFinal)
                        {
                            MessageBox.Show("Harga dibawah standar");
                            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                        }
                        else
                        {
                            DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                        }
                    }

                    if (lookupJenisTransaksi1.IdTr == "KG" || lookupJenisTransaksi1.IdTr == "KB" ||
                        lookupJenisTransaksi1.IdTr == "KV" || lookupJenisTransaksi1.IdTr == "KC")
                    {
                        if (lookupJenisTransaksi1.IdTr == "KB" || lookupJenisTransaksi1.IdTr == "KV")
                        {
                            if (HrgNet < _hrgHPP)
                            {
                                MessageBox.Show("Harga dibawah Hpp");
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                            }
                            else if (HrgNet < _hargaFinal)
                            {
                                MessageBox.Show("Harga dibawah standar");
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "HARGA";
                            }
                            else
                            {
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            }
                        }
                        else
                        {
                            if (HrgNet < _hrgHPP)
                            {
                                MessageBox.Show("Harga dibawah Hpp");
                                DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                                DataGridDO[5, e.RowIndex].Value = 0;
                                DataGridDO[6, e.RowIndex].Value = 0;
                                DataGridDO[7, e.RowIndex].Value = 0;
                                DataGridDO[8, e.RowIndex].Value = 0;
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            }
                            else if (HrgNet < _hargaFinal)
                            {
                                MessageBox.Show("Harga dibawah standar");
                                DataGridDO[4, e.RowIndex].Value = _hargaFinal;
                                DataGridDO[5, e.RowIndex].Value = 0;
                                DataGridDO[6, e.RowIndex].Value = 0;
                                DataGridDO[7, e.RowIndex].Value = 0;
                                DataGridDO[8, e.RowIndex].Value = 0;
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            }
                            else
                            {
                                DataGridDO.CurrentRow.Cells["GvNoAcc"].Value = "AUTOACC";
                            }
                        }
                    }
                }
                hrg = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvHarga"].Value, "0").ToString());
                qty = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvQty"].Value, "0").ToString());
                ds1 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD1"].Value, "0").ToString());
                ds2 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD2"].Value, "0").ToString());
                ds3 = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvD3"].Value, "0").ToString());
                pot = Convert.ToDouble(Tools.isNull(DataGridDO.CurrentRow.Cells["GvPot"].Value, "0").ToString());
                HrgNet = Convert.ToDouble(Tools.isNull(HitNet3D(hrg, ds1, ds2, ds3, pot), "0").ToString()) - pot;

                DataGridDO.CurrentRow.Cells["GvHjual"].Value = HrgNet;
                DataGridDO.CurrentRow.Cells["GvJumlah"].Value = HrgNet * qty;

                double sum = 0;
                kuantiti2 = 0;
                for (int i = 0; i < DataGridDO.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(DataGridDO.Rows[i].Cells[10].Value);
                    kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
                }

                label12.Text = sum.ToString("N0");
                lblqty.Text = kuantiti2.ToString("N0");

                if (GlobalVar.Gudang != "2808")
                {
                    if (lookupJenisTransaksi1.IdTr.Substring(0, 1) == "K")
                    {
                        if (sum > Convert.ToDouble(txtsisa.Text))
                        {
                            MessageBox.Show("Jumlah Penjualan melebihi Sisa Plafon.");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private double HitNet3D(double hrg,double d1,double d2,double d3,double potrp)
        {
            double Harga = 0;
            Harga = hrg - ((d1 / 100) * hrg);
            Harga = Harga - ((d2 / 100) * Harga);
            Harga = Math.Round(Harga - ((d3 / 100) * Harga),0);
            return Harga;
        }


        private void DataGridDO_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridDO.Rows[e.RowIndex].Cells["GvJumlah"].Style.ForeColor = Color.Blue;

        }

        private void DataGridDO_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                nRowGridView = DataGridDO.CurrentRow.Index;
                deleterows();
            }

        }

        private void DataGridDO_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DataGridDO.SelectedCells.Count > 0)
            {
                string kodebarang = Tools.isNull(DataGridDO.SelectedCells[0].OwningRow.Cells["gVplu"].Value, string.Empty).ToString();
                if (kodebarang != string.Empty)
                    CekHargaBMK(kodebarang);
                nRowGridView = DataGridDO.CurrentRow.Index;
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

            GenuineTrans();
            if (!_isOk)
            {
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
                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string _BarangID = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        string _NamaStok = Convert.ToString(DataGridDO.Rows[a].Cells[1].Value);
                        int _Qty = Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                        string _Sat = Convert.ToString(DataGridDO.Rows[a].Cells[3].Value);
                        double _Harga = Convert.ToDouble(DataGridDO.Rows[a].Cells[4].Value);
                        double _Disc1 = Convert.ToDouble(DataGridDO.Rows[a].Cells[5].Value);
                        double _Disc2 = Convert.ToDouble(DataGridDO.Rows[a].Cells[6].Value);
                        double _Disc3 = Convert.ToDouble(DataGridDO.Rows[a].Cells[7].Value);
                        double _Pot = Convert.ToDouble(DataGridDO.Rows[a].Cells[8].Value);
                        double _Jumlah = Convert.ToDouble(DataGridDO.Rows[a].Cells[9].Value);

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
                    if (lookupJenisTransaksi1.IdTr == "K2")
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetItemBarangPromo_LIST"));
                            dtPrmBrg = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        string _BarangID = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);
                        string _NmBarang = Convert.ToString(DataGridDO.Rows[a].Cells[1].Value);
                        int qtydo = Convert.ToInt32(Tools.isNull(DataGridDO.Rows[a].Cells[2].Value, "0").ToString());
                        string promoflg = Convert.ToString(Tools.isNull(DataGridDO.Rows[a].Cells[12].Value, ""));
                        int hrgbrg = Convert.ToInt32(Tools.isNull(DataGridDO.Rows[a].Cells[4].Value, "0").ToString());

                        DataTable dtBrgPromo = new DataTable();
                        if (lookupJenisTransaksi1.IdTr == "K2")
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_CekBarangPromo"));
                                db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.VarChar, GlobalVar.DateTimeOfServer));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _BarangID));
                                dtBrgPromo = db.Commands[0].ExecuteDataTable();
                            }
                        }
                    }
                    #endregion

                    DataGridDO.Refresh();

                    double sum = 0;
                    int jqt = 0;

                    for (a = 0; a < DataGridDO.Rows.Count; ++a)
                    {
                        sum += Convert.ToDouble(DataGridDO.Rows[a].Cells[9].Value);
                        jqt += Convert.ToInt32(DataGridDO.Rows[a].Cells[2].Value);
                    }
                    label12.Text = sum.ToString("N0");
                    lblqty.Text = jqt.ToString("N0");

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
                        _barangID = Convert.ToString(DataGridDO.Rows[a].Cells[0].Value);

                        DataTable dtBrgPromo = new DataTable();
                        if (lookupJenisTransaksi1.IdTr == "K2")
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_CekBarangPromo"));
                                db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.VarChar, GlobalVar.DateTimeOfServer));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, plu));
                                dtBrgPromo = db.Commands[0].ExecuteDataTable();
                            }
                        }

                        if (plu.Trim().Substring(0, 3) != "" && plu.Trim().Substring(0, 3) != "FXB" && harga > 0)
                        {
                            GetPembandingHarga(plu);
                            GetHrgJual();
                            GetHargaHpp(_barangID);
                            
                            DataGridDO.Rows[a].Cells["GvNoAcc"].Value = string.Empty;

                            #region cek ulang harga
                            if (promoFlag == string.Empty)
                            {
                                if (harga <= 0)
                                {
                                    if (dtBrgPromo.Rows.Count > 0)
                                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "AUTOACC";
                                    else
                                        delRows.Add(a);
                                }
                                else if (harga < _hrgHPP)
                                {
                                    msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                                    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "HARGA";
                                }
                                else if (harga < _hargaFinal)
                                {
                                    msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga Standar." + string.Format("{0:N0}", _hargaFinal));
                                    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "HARGA";
                                }
                                else
                                {
                                    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "AUTOACC";
                                }
                            }
                            else
                            {
                                if (promoFlag == "1")
                                {
                                    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "AUTOACC";
                                }
                                else
                                {
                                    if (harga < _hrgHPP)
                                    {
                                        msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "HARGA";
                                    }
                                    else if (harga < _hargaFinal)
                                    {
                                        msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga Standar." + string.Format("{0:N0}", _hargaFinal));
                                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "HARGA";
                                    }
                                    else
                                    {
                                        DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "AUTOACC";
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            DataGridDO.Rows[a].Cells["GvNoAcc"].Value = "AUTOACC";
                        }

                        if (plu.Substring(0, 3) == "FXB")
                        {
                            fxbCount += 1;
                        }

                        ///*cek jika edit data harga di entry do yang kurang dari harga HPP atau Harga Final*/
                        //GetPembandingHarga(plu);
                        ////DataGridDO.Rows[a].Cells["GvNoAcc"].Value = string.Empty;
                        //if (promoFlag == string.Empty)
                        //{
                        //    if (harga <= 0)
                        //    {
                        //        delRows.Add(a);
                        //    }
                        //    //else if (harga < _hargaFinal)
                        //    //{
                        //    //    msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga Standar." + string.Format("{0:N0}", _hargaFinal));
                        //    //    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                        //    //}
                        //    //else if (harga < _hrgHPP)
                        //    //{
                        //    //    msgBuilder.AppendLine("Harga Jual " + plu + " lebih kecil dari Harga HPP " + string.Format("{0:N0}", _hrgHPP));
                        //    //    DataGridDO.Rows[a].Cells["GvNoAcc"].Value = _noACCHarga;
                        //    //}
                        //}
                        //if (plu.Substring(0, 3) == "FXB")
                        //{
                        //    fxbCount += 1;
                        //}
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

    }
}
