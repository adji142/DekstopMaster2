using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using ISA.Trading.Class;

namespace ISA.Trading.PSReport
{
    public partial class frmLaporanPenjualanPerItem : ISA.Trading.BaseForm
    {
        DataTable dtKota, dtBarang, dtGudang, dtLapRekap, dtLapKabHarian, dtLapKabBulan;
        DataTable dtKurang10toko, dtCustomerinti, dtStokTidakBrgerak;
        DataSet dsLaporan;
        public frmLaporanPenjualanPerItem()
        {
            InitializeComponent();
        }

        private void frmLaporanPenjualanPerItem_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePicker2.Value = DateTime.Today;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;

            radioButton4.Checked = true;
            radioButton1.Checked = true;

            #region ComboKota

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Kota_list]"));
                dtKota = db.Commands[0].ExecuteDataTable();
            }
            if (dtKota.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada.....");
                Close();
            }
            else
            {
                foreach (DataRow datacombo in dtKota.Rows)
                {
                    string NamaKota = Convert.ToString(datacombo["kota"]);

                    cmbKota.Items.Add(NamaKota);

                }
            }

            #endregion

            #region ComboBarang

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_KelompokBarang_LIST]"));
                dtBarang = db.Commands[0].ExecuteDataTable();
                //comboBox1.DataSource = dtBarang;
                //comboBox1.ValueMember = "KelompokBrgID";
                //comboBox1.DisplayMember = "KelompokBrgID";
            }
            if (dtBarang.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada.....");
                Close();
            }
            else
            {
                foreach (DataRow datacombo in dtBarang.Rows)
                {
                    string barang = Convert.ToString(datacombo["KelompokBrgID"]);

                    comboBox1.Items.Add(barang);
                }
            }

            #endregion

            #region ComboGudang

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_KodeGud_LIST]"));
                dtGudang = db.Commands[0].ExecuteDataTable();
                // comboBox2.DataSource = dtGudang;
                //comboBox2.ValueMember = "GudangID";
                //comboBox2.DisplayMember = "GudangID";
            }
            if (dtGudang.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada.....");
                Close();
            }
            else
            {
                foreach (DataRow datacombo in dtGudang.Rows)
                {
                    string gudang = Convert.ToString(datacombo["GudangID"]);
                    string namagudang = Convert.ToString(datacombo["NamaGudang"]);


                    comboBox2.Items.Add(gudang + " | " + namagudang);
                }
            }

            comboBox2.Text = GlobalVar.Gudang;

            #endregion



        }
        public void CekKunjunganKurang10Toko()
        {
            #region cek Kunjungan Sales kurang dari 10 toko
            DateTime a;

            DateTime fromdate = dateTimePicker2.Value;

            if (fromdate.DayOfWeek == DayOfWeek.Monday)
            {
                a = fromdate.AddDays(-2);
            }
            else
            {
                a = fromdate.AddDays(-1);
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekKunjKurang10"));
                //db.Commands[0].Parameters.Add(new Parameter("@x", SqlDbType.DateTime, a));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, a));
                dtKurang10toko = db.Commands[0].ExecuteDataTable();
            }
            #endregion
        }



        public void CekCustomerIntiTidakBrtransaksi()
        {
            #region cek Customer inti tidak bertransaksi 2 bulan terakhir
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekCustomerInti"));
                //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                dtCustomerinti = db.Commands[0].ExecuteDataTable();
            }
            #endregion
        }

        public void StokTidakBergerak()
        {
            #region Stok tidak bergerak terhitunga dari tgl terima
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekStokTidakBergerak"));
                db.Commands[0].Parameters.Add(new Parameter("@initGudang", SqlDbType.VarChar, GlobalVar.Gudang.ToString()));
                dtStokTidakBrgerak = db.Commands[0].ExecuteDataTable();
            }
            #endregion
        }


        public void valdasi()
        {
            //validasi 3 point

            if (GlobalVar.Gudang.Substring(0, 2) == "28" || GlobalVar.Gudang.Substring(0, 1) == "9")
            {
                CekKunjunganKurang10Toko();
                CekCustomerIntiTidakBrtransaksi();
                if (GlobalVar.Gudang.Substring(0, 1) != "9")
                {
                    StokTidakBergerak();
                }
            }
            else
            {
                CekCustomerIntiTidakBrtransaksi();
                StokTidakBergerak();
            }
        }

        public void GenerateLaporan()
        {
            if (radioButton3.Checked == true)
            {
                GenerateLaporanNetto();
            }
            if (radioButton4.Checked == true)
            {
                GenerateLaporanNetto();
            }

        }


        public void GenerateLaporanBrutto()
        {
            #region Laporan

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("rsp_LaporanPenjualanPerbarang_rekap"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                if (lookupSales2.NamaSales == "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, lookupSales2.SalesID));
                }
                if (cmbKota.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cmbKota.Text));
                }
                if (lookupStock2.NamaStock == "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.VarChar, lookupStock2.BarangID));
                }
                if (comboBox1.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, comboBox1.Text));
                }
                if (comboBox2.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, comboBox2.Text));
                }
                dsLaporan = db.Commands[0].ExecuteDataSet();
            }
            GenerateExcell(dsLaporan);
            #endregion

        }

        public void GenerateLaporanNetto()
        {
            #region Laporan

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[rsp_LaporanPenjualanPerbarangNetto_rekap]"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                if (lookupSales2.NamaSales == "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, lookupSales2.SalesID));
                }
                if (cmbKota.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cmbKota.Text));
                }
                if (lookupStock2.NamaStock == "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.VarChar, lookupStock2.BarangID));
                }
                if (comboBox1.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, comboBox1.Text));
                }
                if (comboBox2.Text == "(All ......)")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, null));
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, comboBox2.Text));
                }
                dsLaporan = db.Commands[0].ExecuteDataSet();
            }
            GenerateExcell(dsLaporan);
            #endregion
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang.Substring(0,1) != "9")
            {
                //MessageBox.Show(DateTime.Now.AddMonths(-1).ToString());
                try
                {
                    //valdasi();

                    //if (dtCustomerinti.Rows.Count > 0 || dtKurang10toko.Rows.Count > 0 || dtStokTidakBrgerak.Rows.Count > 0)
                    //{
                    //    DateTime fromdate = dateTimePicker2.Value;//kebalik harusnya todate
                    //    DateTime todate = dateTimePicker1.Value;
                    //    DateTime a;
                    //    if (fromdate.DayOfWeek == DayOfWeek.Monday)
                    //    {
                    //        a = fromdate.AddDays(-2);
                    //    }
                    //    else
                    //    {
                    //        a = fromdate.AddDays(-1);
                    //    }
                    //    PSReport.frmCegatanLaporan ifrmChild = new PSReport.frmCegatanLaporan(this, dtCustomerinti, dtStokTidakBrgerak, dtKurang10toko, a, fromdate, todate);
                    //    ifrmChild.MdiParent = Program.MainForm;
                    //    Program.MainForm.RegisterChild(ifrmChild);
                    //    ifrmChild.Show();
                    //}
                    //else
                    //{
                        this.Cursor = Cursors.WaitCursor;
                        GenerateLaporan();
                        UploadLaporan();

                    //}
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                //MessageBox.Show(DateTime.Now.AddMonths(-1).ToString());
                try
                {
                    //valdasi();

                    //if (dtCustomerinti.Rows.Count > 0 || dtKurang10toko.Rows.Count > 0)
                    //{
                    //    DateTime fromdate = dateTimePicker1.Value;//kebalik harusnya todate
                    //    DateTime todate = dateTimePicker2.Value;
                    //    DateTime a;

                    //    if (fromdate.DayOfWeek == DayOfWeek.Monday)
                    //    {
                    //        a = fromdate.AddDays(-2);
                    //    }
                    //    else
                    //    {
                    //        a = fromdate.AddDays(-1);
                    //    }
                    //    PSReport.frmCegatanLaporan ifrmChild = new PSReport.frmCegatanLaporan(this, dtCustomerinti, dtStokTidakBrgerak, dtKurang10toko, a, fromdate, todate);
                    //    ifrmChild.MdiParent = Program.MainForm;
                    //    Program.MainForm.RegisterChild(ifrmChild);
                    //    ifrmChild.Show();
                    //}
                    //else
                    //{
                        this.Cursor = Cursors.WaitCursor;
                        GenerateLaporan();
                        UploadLaporan();

                    //}
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GenerateExcell(DataSet dsLaporan)
        {
            string JenisLaporan = string.Empty;
            if (radioButton3.Checked == true)
            {
                JenisLaporan = "BRUTTO";
            }
            if (radioButton4.Checked == true)
            {
                JenisLaporan = "NETTO";
            }

            using (ExcelPackage p = new ExcelPackage())
            {
                string fromdate = string.Format("{0:dd-MM-yyyy}", dateTimePicker1.Value);
                string todate = string.Format("{0:dd-MM-yyyy}", dateTimePicker2.Value);
                p.Workbook.Properties.Author = "Server " + comboBox2.Text;
                p.Workbook.Properties.Title = "Laporan Penjualan";

                #region Laporan Penjualan Perbarang

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Rekap"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 19;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 10;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 35;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 10;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 12;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 10;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 10;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 20;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 78;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 10;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 10;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 15;
                ws.Cells[1, 15].Worksheet.Column(15).Width = 15;
                ws.Cells[1, 16].Worksheet.Column(16).Width = 15;
                ws.Cells[1, 17].Worksheet.Column(17).Width = 15;
                ws.Cells[1, 18].Worksheet.Column(18).Width = 15;
                ws.Cells[1, 19].Worksheet.Column(19).Width = 10;

                ws.Cells[1, 1].Value = "PENJUALAN PER BARANG " + JenisLaporan;
                ws.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws.Cells[4, 1].Value = "";
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws.Cells[5, 1].Value = "NO.";
                ws.Cells[5, 2].Value = "Kota";
                ws.Cells[5, 3].Value = "Id Toko";
                ws.Cells[5, 4].Value = "Nama Toko";
                ws.Cells[5, 5].Value = "Idwil";
                ws.Cells[5, 6].Value = "Kd Sales";
                ws.Cells[5, 7].Value = "Tanggal";
                ws.Cells[5, 8].Value = "No Do";
                ws.Cells[5, 9].Value = "No Nota";
                ws.Cells[5, 10].Value = "Kode Barang";
                ws.Cells[5, 11].Value = "Nama Barang";
                ws.Cells[5, 12].Value = "Satuan";
                ws.Cells[5, 13].Value = "Qty";
                ws.Cells[5, 14].Value = "Hrg Satuan";
                ws.Cells[5, 15].Value = "Jumlah Netto";
                ws.Cells[5, 16].Value = "Status Laba";
                ws.Cells[5, 17].Value = "Hpp Satuan";
                ws.Cells[5, 18].Value = "Jumlah Hpp ";
                ws.Cells[5, 19].Value = "Kd Gud";

                ws.Cells[5, 1, 5, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 1, 5, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx = 6;
                int totalqty = 0;
                double totalNetto = 0;
                double totalHpp = 0;
                int num = 1;
                double hpp_pernama = 0;
                foreach (DataRow dr in dsLaporan.Tables[0].Rows)
                {
                    ws.Cells[idx, 1].Value = num;
                    ws.Cells[idx, 2].Value = dr["Kota"];
                    ws.Cells[idx, 3].Value = Convert.ToString(dr["TokoID"]);
                    ws.Cells[idx, 4].Value = dr["NamaToko"];
                    ws.Cells[idx, 5].Value = dr["WilID"];
                    ws.Cells[idx, 6].Value = dr["KodeSales"];
                    ws.Cells[idx, 7].Value = dr["tanggal"];
                    ws.Cells[idx, 8].Value = dr["NoDO"];
                    ws.Cells[idx, 9].Value = dr["NoNota"];
                    ws.Cells[idx, 10].Value = dr["BarangID"];
                    ws.Cells[idx, 11].Value = dr["NamaStok"];
                    ws.Cells[idx, 12].Value = dr["SatJual"];
                    ws.Cells[idx, 13].Value = dr["QtySuratJalan"];
                    ws.Cells[idx, 14].Value = dr["HrgJual"];
                    ws.Cells[idx, 15].Value = dr["Jumlah_Netto"];
                    ws.Cells[idx, 16].Value = dr["StatusLaba"];

                    double hpp = Convert.ToDouble(Tools.isNull(dr["Hpp"], 0));
                    int qty = Convert.ToInt32(Tools.isNull(dr["QtySuratJalan"], 0));
                    ws.Cells[idx, 17].Value = hpp;
                    hpp_pernama = hpp * qty;

                    ws.Cells[idx, 18].Value = hpp_pernama;
                    ws.Cells[idx, 19].Value = Convert.ToString(dr["KodeGudang"]);

                    double netto = Convert.ToDouble(Tools.isNull(dr["Jumlah_Netto"], 0));
                    totalNetto = totalNetto + netto;


                    totalqty = totalqty + qty;

                    // double hpp = Convert.ToDouble(Tools.isNull(dr["Hpp"], 0));
                    totalHpp = totalHpp + hpp;

                    ws.Cells[idx + 1, 13].Value = "";
                    ws.Cells[idx + 1, 15].Value = "";
                    ws.Cells[idx + 1, 17].Value = "";

                    ws.Cells[idx + 2, 13].Value = totalqty;
                    ws.Cells[idx + 2, 15].Value = totalNetto;
                    ws.Cells[idx + 2, 17].Value = totalHpp;
                    idx++;
                    num++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws.Cells[idx + 1, 1, idx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx + 1, 1, idx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border = ws.Cells[5, 1, idx + 1, MaxCol].Style.Border;

                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Omset Perkabupaten Harian

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[2];

                ws1.Name = "Lap Oms PerKab Harian"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";

                int MaxCol1 = 4;

                ws1.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws1.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws1.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws1.Cells[1, 4].Worksheet.Column(4).Width = 10;


                ws1.Cells[1, 1].Value = "LAPORAN OMSET PER KABUPATEN";
                ws1.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws1.Cells[4, 1].Value = "";
                ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
                ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
                ws1.Cells[1, 1, 2, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[1, 1, 2, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws1.Cells[1, 1, 2, MaxCol1].Style.Font.Bold = true;
                ws1.Cells[1, 1].Style.Font.Size = 14;
                ws1.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws1.Cells[5, 1].Value = "NO.";
                ws1.Cells[5, 2].Value = "Kota";
                ws1.Cells[5, 3].Value = "Omset";
                ws1.Cells[5, 4].Value = "OA";


                ws1.Cells[5, 1, 5, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[5, 1, 5, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx1 = 6;
                int noa = 0;
                double nomset = 0;
                int number = 1;
                foreach (DataRow dr1 in dsLaporan.Tables[1].Rows)
                {
                    ws1.Cells[idx1, 1].Value = number;
                    ws1.Cells[idx1, 2].Value = dr1["Kota"];
                    ws1.Cells[idx1, 3].Value = dr1["omset"];
                    ws1.Cells[idx1, 4].Value = dr1["KodeToko"];

                    int oa = Convert.ToInt32(Tools.isNull(dr1["KodeToko"], 0));
                    noa = noa + oa;

                    double omset = Convert.ToDouble(Tools.isNull(dr1["omset"], 0));
                    nomset = nomset + omset;

                    ws1.Cells[idx1 + 1, 4].Value = "";
                    ws1.Cells[idx1 + 1, 3].Value = "";

                    ws1.Cells[idx1 + 2, 4].Value = noa;
                    ws1.Cells[idx1 + 2, 3].Value = nomset;

                    number++;
                    idx1++;
                }
                #endregion

                #region Summary & Formatting
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws1.Cells[idx1 + 1, 1, idx1 + 1, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[idx1 + 1, 1, idx1 + 1, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border1 = ws1.Cells[5, 1, idx1 + 1, MaxCol1].Style.Border;
                border1.Bottom.Style =
                border1.Top.Style =
                border1.Left.Style =
                border1.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Omset Perkabupaten Bulanan

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet3");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[3];

                ws2.Name = "Lap Oms PerKab Bulanan"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";

                int MaxCol2 = 4;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 10;


                ws2.Cells[1, 1].Value = "LAPORAN OMSET PER KABUPATEN";
                ws2.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws2.Cells[4, 1].Value = "";
                ws2.Cells[1, 1, 1, MaxCol2].Merge = true;
                ws2.Cells[2, 1, 2, MaxCol2].Merge = true;
                ws2.Cells[1, 1, 2, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol2].Style.Font.Bold = true;
                ws2.Cells[1, 1].Style.Font.Size = 14;
                ws2.Cells[2, 1].Style.Font.Size = 11;





                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws2.Cells[5, 1].Value = "NO.";
                ws2.Cells[5, 2].Value = "Kota";
                ws2.Cells[5, 3].Value = "Omset";
                ws2.Cells[5, 4].Value = "OA";


                ws2.Cells[5, 1, 5, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[5, 1, 5, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx2 = 6;
                int noa1 = 0;
                float nomset1 = 0;
                int nomerlagi = 1;
                foreach (DataRow dr2 in dsLaporan.Tables[2].Rows)
                {
                    ws2.Cells[idx2, 1].Value = nomerlagi;
                    ws2.Cells[idx2, 2].Value = dr2["Kota"];
                    ws2.Cells[idx2, 3].Value = dr2["omset"];
                    ws2.Cells[idx2, 4].Value = dr2["KodeToko"];

                    int oa1 = Convert.ToInt32(Tools.isNull(dr2["KodeToko"], 0));
                    noa1 = noa1 + oa1;

                    float omset1 = Convert.ToInt32(Tools.isNull(dr2["omset"], 0));
                    nomset1 = nomset1 + omset1;

                    ws2.Cells[idx2 + 1, 4].Value = "";
                    ws2.Cells[idx2 + 1, 3].Value = "";

                    ws2.Cells[idx2 + 2, 4].Value = noa1;
                    ws2.Cells[idx2 + 2, 3].Value = nomset1;

                    nomerlagi++;
                    idx2++;
                }
                #endregion

                #region Summary & Formatting
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws2.Cells[idx2 + 1, 1, idx2 + 1, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[idx2 + 1, 1, idx2 + 1, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border2 = ws2.Cells[5, 1, idx2 + 1, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region LAPORAN DISTRIBURION SCORE PER AREA SALESMAN
                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet4");
                ExcelWorksheet ws3 = p.Workbook.Worksheets[4];

                ws3.Name = "Lap Dist Score Harian"; //Setting Sheet's name
                ws3.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws3.Cells.Style.Font.Name = "Calibri";

                DataTable dt = dsLaporan.Tables[3].DefaultView.ToTable(true, "KodeSales").Copy();
                int sls = dt.Rows.Count;
                int MaxCol3 = 9 + sls;

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws3.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws3.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws3.Cells[1, 4].Worksheet.Column(4).Width = 5;
                for (int r = 5; r <= MaxCol3; r++)
                {
                    ws3.Cells[1, r].Worksheet.Column(r).Width = 15;
                }


                ws3.Cells[1, 1].Value = "LAPORAN DISTRIBURION SCORE PER AREA SALESMAN";
                ws3.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws3.Cells[4, 1].Value = "";
                ws3.Cells[1, 1, 1, MaxCol3].Merge = true;
                ws3.Cells[2, 1, 2, MaxCol3].Merge = true;
                ws3.Cells[1, 1, 2, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.Font.Bold = true;
                ws3.Cells[1, 1].Style.Font.Size = 14;
                ws3.Cells[2, 1].Style.Font.Size = 11;

                // 	  	  	  	  	  



                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws3.Cells[5, 1].Value = "NO.";
                ws3.Cells[5, 2].Value = "Kota";
                ws3.Cells[5, 3].Value = "Omset";
                ws3.Cells[5, 4].Value = "oa";
                DataTable dtSales = dsLaporan.Tables[3].DefaultView.ToTable(true, "kodesales").Copy();
                int X = dtSales.Rows.Count;
                int MAXCol = dtSales.Rows.Count + 9;
                for (int i = 0; i < dtSales.Rows.Count; i++)
                {
                    ws3.Cells[5, i + 5].Value = dtSales.Rows[i][0].ToString();
                    //X++;
                }
                ws3.Cells[5, X + 5].Value = "TOTAL";
                ws3.Cells[5, X + 6].Value = "TARGET MIN";
                ws3.Cells[5, X + 7].Value = "ACTUAL";
                ws3.Cells[5, X + 8].Value = "SELISIH";
                ws3.Cells[5, X + 9].Value = "SCORE";
                ws3.Cells[5, 1, 5, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[5, 1, 5, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx3 = 6;

                double totalOms, ttlOa, Oms, OaOa = 0;


                DataTable dtKota = dsLaporan.Tables[3].DefaultView.ToTable(true, "Kota").Copy();
                DataTable dtData = dsLaporan.Tables[3].Copy();
                DataTable dtItung = dsLaporan.Tables[3].DefaultView.ToTable(true, "KodeSales").Copy();
                DataTable dtItungData = dsLaporan.Tables[3].Copy();
                int nomor = 1;
                int y = dtItung.Rows.Count;
                foreach (DataRow drK in dtKota.Rows)
                {
                    ws3.Cells[idx3, 1].Value = nomor;
                    ws3.Cells[idx3, 2].Value = drK["Kota"];


                    dtData.DefaultView.RowFilter = "Kota='" + drK["Kota"].ToString() + "'";
                    if (dtData.DefaultView.Table.Rows.Count > 0)
                    {
                        Oms = Convert.ToDouble(dtData.DefaultView.ToTable().Compute("SUM(omset)", "Kota='" + drK["Kota"].ToString() + "'"));
                        ws3.Cells[idx3, 3].Value = Oms;
                        //totalOms = totalOms + Oms;

                    }

                    if (dtData.DefaultView.Table.Rows.Count > 0)
                    {
                        OaOa = Convert.ToDouble(dtData.DefaultView.ToTable().Compute("SUM(OA)", "Kota='" + drK["Kota"].ToString() + "'"));
                        ws3.Cells[idx3, 4].Value = OaOa;

                    }


                    int cc = 5;
                    //int bawah = 6;
                    foreach (DataRow drS in dtItung.Rows)
                    {
                        dtItungData.DefaultView.RowFilter = "KodeSales='" + drS["KodeSales"].ToString() + "'";// +"and Kota='" + drK["Kota"].ToString() + "'";
                        DataTable dtX = dtItungData.DefaultView.ToTable().Copy();
                        dtX.DefaultView.RowFilter = " Kota='" + drK["Kota"].ToString() + "'";
                        DataTable dTY = dtX.DefaultView.ToTable().Copy();

                        for (int aa = 0; aa < dTY.Rows.Count; aa++)
                        {
                            if (dTY.Columns["KodeSales"].ToString() == dtItung.Columns["KodeSales"].ToString() && dTY.Columns["Kota"].ToString() == dtX.Columns["Kota"].ToString())
                            {
                                //if (dTY.Columns["Kota"].ToString() == dtX.Columns["Kota"].ToString())
                                //{
                                //if (dTY.Rows.Count > 0)
                                //{
                                ws3.Cells[idx3, cc].Value =
                                 Convert.ToDouble(dTY.Rows[aa]["total"].ToString());
                                cc++;
                                aa++;
                                //}

                                //if (dTY.Columns["Kota"].ToString() != dtX.Columns["Kota"].ToString())
                                //{
                                //    ws3.Cells[idx3, cc].Value = 0;
                                //    cc++;
                                //}


                            }
                            else
                            {
                                ws3.Cells[idx3, cc].Value = 0;
                                cc++;
                                aa++;
                            }
                        }

                    }
                    foreach (DataRow dr3 in dsLaporan.Tables[3].Rows)
                    {
                        double asd = Convert.ToDouble(dtData.DefaultView.ToTable().Compute("SUM(total)", "Kota='" + drK["Kota"].ToString() + "'"));
                        double target = Convert.ToDouble(Tools.isNull(dr3["TargetOmset"], 0));//Convert.ToDouble(dsLaporan.Tables[3].DefaultView.ToTable().Compute("SUM(TargetOmset)", "Kota='" + drK["Kota"].ToString() + "'"));
                        ws3.Cells[idx3, X + 5].Value = asd;
                        ws3.Cells[idx3, X + 7].Value = asd;
                        ws3.Cells[idx3, X + 6].Value = target;
                        double selisih = asd - target;
                        ws3.Cells[idx3, X + 8].Value = selisih;
                        double score = (asd / target) * 100;
                        ws3.Cells[idx3, X + 9].Value = score;

                    }


                    //ws3.Cells[idx3 + 1, 3].Value = "";
                    //ws3.Cells[idx3 + 1, 4].Value = "";

                    //ws3.Cells[idx3 + 2, 3].Value = totalOms;
                    //ws3.Cells[idx3 + 2, 4].Value = ttlOa;
                    nomor++;
                    idx3++;

                }

                #endregion

                #region Summary & Formatting
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws3.Cells[idx3 + 1, 1, idx3 + 1, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[idx3 + 1, 1, idx3 + 1, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border3 = ws3.Cells[5, 1, idx3 + 1, MaxCol3].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region LAPORAN DISTRIBURION SCORE PER AREA SALESMAN Bulanan
                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet5");
                ExcelWorksheet ws4 = p.Workbook.Worksheets[5];

                ws4.Name = "Lap Dist Score Bulanan"; //Setting Sheet's name
                ws4.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws4.Cells.Style.Font.Name = "Calibri";

                DataTable dtsls = dsLaporan.Tables[4].DefaultView.ToTable(true, "KodeSales").Copy();
                int sales = dtsls.Rows.Count;

                int MaxCol4 = 9 + sales;

                ws4.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws4.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws4.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws4.Cells[1, 4].Worksheet.Column(4).Width = 5;
                for (int r = 5; r <= MaxCol3; r++)
                {
                    ws4.Cells[1, r].Worksheet.Column(r).Width = 15;
                }

                ws4.Cells[1, 1].Value = "LAPORAN DISTRIBURION SCORE PER AREA SALESMAN";
                ws4.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws4.Cells[4, 1].Value = "";
                ws4.Cells[1, 1, 1, MaxCol4].Merge = true;
                ws4.Cells[2, 1, 2, MaxCol4].Merge = true;
                ws4.Cells[1, 1, 2, MaxCol4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws4.Cells[1, 1, 2, MaxCol4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws4.Cells[1, 1, 2, MaxCol4].Style.Font.Bold = true;
                ws4.Cells[1, 1].Style.Font.Size = 14;
                ws4.Cells[2, 1].Style.Font.Size = 11;

                // 	  	  	  	  	  

                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws4.Cells[5, 1].Value = "NO.";
                ws4.Cells[5, 2].Value = "Kota";
                ws4.Cells[5, 3].Value = "Omset";
                ws4.Cells[5, 4].Value = "oa";
                DataTable dtSales1 = dsLaporan.Tables[4].DefaultView.ToTable(true, "kodesales").Copy();
                int X1 = dtSales1.Rows.Count;
                int MAXCol1 = dtSales1.Rows.Count;
                for (int i = 0; i < dtSales1.Rows.Count; i++)
                {
                    ws4.Cells[5, i + 5].Value = dtSales1.Rows[i][0].ToString();
                    //X++;
                }
                ws4.Cells[5, X1 + 5].Value = "TOTAL";
                ws4.Cells[5, X1 + 6].Value = "TARGET MIN";
                ws4.Cells[5, X1 + 7].Value = "ACTUAL";
                ws4.Cells[5, X1 + 8].Value = "SELISIH";
                ws4.Cells[5, X1 + 9].Value = "SCORE";
                ws4.Cells[5, 1, 5, MaxCol4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws4.Cells[5, 1, 5, MaxCol4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx4 = 6;

                DataTable dtKota1 = dsLaporan.Tables[4].DefaultView.ToTable(true, "Kota").Copy();
                DataTable dtData1 = dsLaporan.Tables[4].Copy();
                DataTable dtItung1 = dsLaporan.Tables[4].DefaultView.ToTable(true, "KodeSales").Copy();
                DataTable dtItungData1 = dsLaporan.Tables[4].Copy();
                int nomor1 = 1;
                int y1 = dtItung1.Rows.Count;
                foreach (DataRow drK1 in dtKota1.Rows)
                {
                    ws4.Cells[idx4, 1].Value = nomor1;
                    ws4.Cells[idx4, 2].Value = drK1["Kota"];


                    dtData1.DefaultView.RowFilter = "Kota='" + drK1["Kota"].ToString() + "'";
                    if (dtData1.DefaultView.Table.Rows.Count > 0)
                    {
                        ws4.Cells[idx4, 3].Value =
                            Convert.ToDouble(dtData1.DefaultView.ToTable().Compute("SUM(omset)", "Kota='" + drK1["Kota"].ToString() + "'"));
                    }

                    if (dtData1.DefaultView.Table.Rows.Count > 0)
                    {
                        ws4.Cells[idx4, 4].Value =
                            Convert.ToDouble(dtData1.DefaultView.ToTable().Compute("SUM(oa)", "Kota='" + drK1["Kota"].ToString() + "'"));
                    }
                    int cc1 = 5;
                    //int bawah = 6;
                    foreach (DataRow drS1 in dtItung1.Rows)
                    {
                        dtItungData1.DefaultView.RowFilter = "KodeSales='" + drS1["KodeSales"].ToString() + "'";// +"and Kota='" + drK["Kota"].ToString() + "'";
                        DataTable dtX1 = dtItungData1.DefaultView.ToTable().Copy();
                        dtX1.DefaultView.RowFilter = " Kota='" + drK1["Kota"].ToString() + "'";
                        DataTable dTY1 = dtX1.DefaultView.ToTable().Copy();

                        for (int aa1 = 0; aa1 < dTY1.Rows.Count; aa1++)
                        {
                            if (dTY1.Columns["KodeSales"].ToString() == dtItung1.Columns["KodeSales"].ToString())
                            {
                                if (dTY1.Columns["kota"].ToString() == dtX1.Columns["kota"].ToString())
                                {
                                    //if (dTY.Rows.Count > 0)
                                    //{
                                    ws4.Cells[idx4, cc1].Value =
                                     Convert.ToDouble(dTY1.Rows[aa1]["total"].ToString());
                                    cc1++;
                                    aa1++;
                                }

                                if (dTY1.Columns["kota"].ToString() != dtX1.Columns["kota"].ToString())
                                {
                                    ws4.Cells[idx4, cc1].Value =
                                     "";
                                    cc1++;
                                }


                            }
                        }

                    }
                    foreach (DataRow dr4 in dsLaporan.Tables[4].Rows)
                    {
                        double asd1 = Convert.ToDouble(dtData1.DefaultView.ToTable().Compute("SUM(total)", "Kota='" + drK1["Kota"].ToString() + "'"));
                        double target1 = Convert.ToInt32(Tools.isNull(dr4["TargetOmset"], 0));
                        ws4.Cells[idx4, X1 + 5].Value = asd1;
                        ws4.Cells[idx4, X1 + 7].Value = asd1;
                        ws4.Cells[idx4, X1 + 6].Value = target1;
                        double selisih = asd1 - target1;
                        ws4.Cells[idx4, X1 + 8].Value = selisih;

                        double score1 = (asd1 / target1) * 100;
                        ws4.Cells[idx4, X1 + 9].Value = score1;

                    }
                    nomor1++;
                    idx4++;

                }

                #endregion

                #region Summary & Formatting
                ws4.Cells[5, 1, 5, MaxCol4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws4.Cells[5, 1, 5, MaxCol4].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws4.Cells[idx4 + 1, 1, idx4 + 1, MaxCol4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws4.Cells[idx4 + 1, 1, idx4 + 1, MaxCol4].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border4 = ws4.Cells[5, 1, idx4 + 1, MaxCol4].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Omset PerHari

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet6");
                ExcelWorksheet ws5 = p.Workbook.Worksheets[6];

                ws5.Name = "Lap Oms Harian"; //Setting Sheet's name
                ws5.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws5.Cells.Style.Font.Name = "Calibri";

                int MaxCol5 = 17;

                ws5.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws5.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws5.Cells[1, 3].Worksheet.Column(3).Width = 25;
                ws5.Cells[1, 4].Worksheet.Column(4).Width = 12;
                for (int r = 5; r <= 17; r++)
                {
                    ws5.Cells[1, r].Worksheet.Column(r).Width = 12;
                }

                ws5.Cells[1, 1].Value = "LAPORAN OMSET SPAREPART " + JenisLaporan;
                ws5.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws5.Cells[4, 1].Value = "";
                ws5.Cells[1, 1, 1, MaxCol5].Merge = true;
                ws5.Cells[2, 1, 2, MaxCol5].Merge = true;
                ws5.Cells[1, 1, 2, MaxCol5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws5.Cells[1, 1, 2, MaxCol5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws5.Cells[1, 1, 2, MaxCol5].Style.Font.Bold = true;
                ws5.Cells[1, 1].Style.Font.Size = 14;
                ws5.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws5.Cells[5, 1, 6, 1].Merge = true;
                ws5.Cells[5, 2, 6, 2].Merge = true;
                ws5.Cells[5, 3, 6, 3].Merge = true;
                ws5.Cells[5, 4, 5, 8].Merge = true;
                ws5.Cells[5, 9, 5, 12].Merge = true;
                ws5.Cells[5, 13, 5, 17].Merge = true;

                ws5.Cells[5, 1].Value = "NO.";
                ws5.Cells[5, 2].Value = "Kode Sales";
                ws5.Cells[5, 3].Value = "Nama Sales";
                ws5.Cells[5, 4].Value = "OMSET";
                ws5.Cells[6, 4].Value = "Target";
                ws5.Cells[6, 5].Value = "QTY";
                ws5.Cells[6, 6].Value = "Nilai";
                ws5.Cells[6, 7].Value = "Selisih";
                ws5.Cells[6, 8].Value = "(%)";
                ws5.Cells[5, 9].Value = "SKU";
                ws5.Cells[6, 9].Value = "Target";
                ws5.Cells[6, 10].Value = "Actual";
                ws5.Cells[6, 11].Value = "Selisih";
                ws5.Cells[6, 12].Value = "(%)";
                ws5.Cells[5, 13].Value = "OA";
                ws5.Cells[6, 13].Value = "Target";
                ws5.Cells[6, 14].Value = "OA ALL";
                ws5.Cells[6, 15].Value = "> 100 Rb";
                ws5.Cells[6, 16].Value = "Selisih";
                ws5.Cells[6, 17].Value = "(%)";



                ws5.Cells[5, 1, 6, MaxCol5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws5.Cells[5, 1, 6, MaxCol5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx5 = 7;
                int nomer = 1;
                double percentomset = 0;
                double selisihOmset = 0;
                double percentSku = 0;
                double selisihSku = 0;
                double percentOa = 0;
                double selisihOa = 0;
                foreach (DataRow drd in dsLaporan.Tables[5].Rows)
                {
                    ws5.Cells[idx5, 1].Value = nomer;
                    ws5.Cells[idx5, 2].Value = drd["KodeSales"];
                    ws5.Cells[idx5, 3].Value = drd["NamaSales"];
                    ws5.Cells[idx5, 4].Value = drd["targetomset"];
                    ws5.Cells[idx5, 5].Value = drd["qty"];
                    ws5.Cells[idx5, 6].Value = drd["nilai"];

                    double target = Convert.ToDouble(Tools.isNull(drd["targetomset"], 0));
                    double nilai = Convert.ToDouble(Tools.isNull(drd["nilai"], 0));
                    selisihOmset = nilai - target;
                    ws5.Cells[idx5, 7].Value = selisihOmset;

                    if (target == 0)
                    {
                        ws5.Cells[idx5, 8].Value = 0;
                    }
                    else
                    {
                        percentomset = (nilai / target) * 100;
                        ws5.Cells[idx5, 8].Value = percentomset;
                    }


                    ws5.Cells[idx5, 9].Value = drd["targetSku"];
                    ws5.Cells[idx5, 10].Value = drd["actual"];
                    double SKU = Convert.ToDouble(Tools.isNull(drd["targetSku"], 0));
                    double actualsku = Convert.ToDouble(Tools.isNull(drd["actual"], 0));


                    selisihSku = actualsku - SKU;

                    ws5.Cells[idx5, 11].Value = selisihSku;


                    if (SKU == 0)
                    {
                        ws5.Cells[idx5, 12].Value = 0;
                    }
                    else
                    {
                        percentSku = (actualsku / SKU) * 100;
                        ws5.Cells[idx5, 12].Value = percentSku;
                    }

                    ws5.Cells[idx5, 13].Value = drd["targetOa"];
                    ws5.Cells[idx5, 14].Value = drd["oaall"];
                    ws5.Cells[idx5, 15].Value = drd["oa100"];
                    double oa = Convert.ToDouble(Tools.isNull(drd["targetOa"], 0));
                    double oa100 = Convert.ToDouble(Tools.isNull(drd["oaall"], 0));

                    selisihOa = oa100 - oa;

                    ws5.Cells[idx5, 16].Value = selisihOa;
                    if (oa == 0)
                    {
                        ws5.Cells[idx5, 17].Value = 0;
                    }
                    else
                    {
                        percentOa = (oa100 / oa) * 100;
                        ws5.Cells[idx5, 17].Value = percentOa;
                    }



                    nomer++;
                    idx5++;
                }
                #endregion

                #region Summary & Formatting
                ws5.Cells[5, 1, 5, MaxCol5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[idx5 + 1, 1, idx5 + 1, MaxCol5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[5, 1, 5, MaxCol5].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws5.Cells[idx5 + 1, 1, idx5 + 1, MaxCol5].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border5 = ws5.Cells[5, 1, idx5 + 1, MaxCol5].Style.Border;
                ws5.Cells[6, 1, 6, MaxCol5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[6, 1, 6, MaxCol5].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Omset PerBulan

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet7");
                ExcelWorksheet ws6 = p.Workbook.Worksheets[7];

                ws6.Name = "Lap Oms PerBulan"; //Setting Sheet's name
                ws6.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws6.Cells.Style.Font.Name = "Calibri";

                int MaxCol6 = 32;

                ws6.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws6.Cells[1, 2].Worksheet.Column(2).Width = 12;
                ws6.Cells[1, 3].Worksheet.Column(3).Width = 25;

                ws6.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws6.Cells[1, 5].Worksheet.Column(5).Width = 9;
                ws6.Cells[1, 6].Worksheet.Column(6).Width = 12;
                ws6.Cells[1, 7].Worksheet.Column(7).Width = 12;
                ws6.Cells[1, 8].Worksheet.Column(8).Width = 7;
                ws6.Cells[1, 9].Worksheet.Column(9).Width = 9;
                ws6.Cells[1,10].Worksheet.Column(10).Width = 12;

                ws6.Cells[1,11].Worksheet.Column(11).Width = 12;
                ws6.Cells[1,12].Worksheet.Column(12).Width = 9;
                ws6.Cells[1,13].Worksheet.Column(13).Width = 12;
                ws6.Cells[1,14].Worksheet.Column(14).Width = 9;
                ws6.Cells[1,15].Worksheet.Column(15).Width = 9;
                ws6.Cells[1,16].Worksheet.Column(16).Width = 12;

                ws6.Cells[1,17].Worksheet.Column(17).Width = 12;
                ws6.Cells[1,18].Worksheet.Column(18).Width = 9;
                ws6.Cells[1,19].Worksheet.Column(19).Width = 9;
                ws6.Cells[1,20].Worksheet.Column(20).Width = 9;
                ws6.Cells[1,21].Worksheet.Column(21).Width = 9;
                ws6.Cells[1,22].Worksheet.Column(22).Width = 9;
                ws6.Cells[1,23].Worksheet.Column(23).Width = 12;

                ws6.Cells[1,24].Worksheet.Column(24).Width = 12;

                ws6.Cells[1,25].Worksheet.Column(25).Width = 9;
                ws6.Cells[1,26].Worksheet.Column(26).Width = 12;
                ws6.Cells[1,27].Worksheet.Column(27).Width = 9;
                ws6.Cells[1,28].Worksheet.Column(28).Width = 12;

                ws6.Cells[1,29].Worksheet.Column(29).Width = 9;
                ws6.Cells[1,30].Worksheet.Column(30).Width = 12;
                ws6.Cells[1,31].Worksheet.Column(31).Width = 9;
                ws6.Cells[1,32].Worksheet.Column(32).Width = 12;
                                
                
                
                //for (int r = 4; r <= 23; r++)
                //{
                //    ws6.Cells[1, r].Worksheet.Column(r).Width = 12;
                //}
                //ws6.Cells[1, 24].Worksheet.Column(24).Width = 15;
                //for (int r = 25; r <= 32; r++)
                //{
                //    ws6.Cells[1, r].Worksheet.Column(r).Width = 12;
                //}

                ws6.Cells[1, 1].Value = "LAPORAN OMSET SPAREPART " + JenisLaporan;
                ws6.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws6.Cells[4, 1].Value = "";
                ws6.Cells[1, 1, 1, MaxCol6].Merge = true;
                ws6.Cells[2, 1, 2, MaxCol6].Merge = true;
                ws6.Cells[1, 1, 2, MaxCol6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws6.Cells[1, 1, 2, MaxCol6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws6.Cells[1, 1, 2, MaxCol6].Style.Font.Bold = true;
                ws6.Cells[1, 1].Style.Font.Size = 14;
                ws6.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                //ws.Cells[5, 6, 1, MaxCol].Merge = true;
                ws6.Cells[5, 1, 6, 1].Merge = true;
                ws6.Cells[5, 2, 6, 2].Merge = true;
                ws6.Cells[5, 3, 6, 3].Merge = true;
                ws6.Cells[5, 4, 5, 10].Merge = true;
                ws6.Cells[5, 11, 5, 16].Merge = true;
                //ws6.Cells[5, 13, 5, 17].Merge = true;
                //ws6.Cells[5, 17, 5, 24].Merge = true;
                ws6.Cells[5, 17, 5, 23].Merge = true;
                ws6.Cells[5, 24, 6, 24].Merge = true;
                ws6.Cells[5, 25, 5, 26].Merge = true;
                ws6.Cells[5, 27, 5, 28].Merge = true;

                ws6.Cells[5, 29, 5, 30].Merge = true;
                ws6.Cells[5, 31, 5, 32].Merge = true;

                ws6.Cells[5, 1].Value = "NO.";
                ws6.Cells[5, 2].Value = "Kode Sales";
                ws6.Cells[5, 3].Value = "Nama Sales";
                ws6.Cells[5, 4].Value = "Omset";
                ws6.Cells[6, 4].Value = "Target";
                ws6.Cells[6, 5].Value = "QTY";
                ws6.Cells[6, 6].Value = "Nilai";
                ws6.Cells[6, 7].Value = "Selisih";
                ws6.Cells[6, 8].Value = "(%)";
                ws6.Cells[6, 9].Value = "Score";
                ws6.Cells[6, 10].Value = "Nilai Score";
                ws6.Cells[5, 11].Value = "SKU";
                ws6.Cells[6, 11].Value = "Target";
                ws6.Cells[6, 12].Value = "Actual";
                ws6.Cells[6, 13].Value = "Selisih";
                ws6.Cells[6, 14].Value = "(%)";
                ws6.Cells[6, 15].Value = "Score";
                ws6.Cells[6, 16].Value = "Nilai Score";
                ws6.Cells[5, 17].Value = "OA";
                ws6.Cells[6, 17].Value = "Target";
                ws6.Cells[6, 18].Value = "OA All";
                ws6.Cells[6, 19].Value = "> 100 Rb";
                ws6.Cells[6, 20].Value = "Selisih";
                ws6.Cells[6, 21].Value = "(%)";
                ws6.Cells[6, 22].Value = "Score";
                ws6.Cells[6, 23].Value = "Nilai Score";
                ws6.Cells[5, 24].Value = "Jumlah Score";
                ws6.Cells[5, 25].Value = "Omset FB2";
                ws6.Cells[6, 25].Value = "Qty";
                ws6.Cells[6, 26].Value = "Nilai";
                ws6.Cells[5, 27].Value = "Omset FB4";
                ws6.Cells[6, 27].Value = "Qty";
                ws6.Cells[6, 28].Value = "Nilai";

                ws6.Cells[5, 29].Value = "Omset FE2";
                ws6.Cells[6, 29].Value = "Qty";
                ws6.Cells[6, 30].Value = "Nilai";

                ws6.Cells[5, 31].Value = "Omset FE4";
                ws6.Cells[6, 31].Value = "Qty";
                ws6.Cells[6, 32].Value = "Nilai";

                ws6.Cells[5, 1, 6, MaxCol6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws6.Cells[5, 1, 6, MaxCol6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx6 = 7;
                int no = 1;
                double persen1 = 0, persen2 = 0, persen3 = 0;
                double selisih1 = 0, selisih2 = 0, selisih3 = 0;
                double nilaiscore1 = 0, nilaiscore2 = 0, nilaiscore3 = 0, nilaiscoreTotal = 0;
                foreach (DataRow drd in dsLaporan.Tables[6].Rows)
                {
                    ws6.Cells[idx6, 1].Value = no;
                    ws6.Cells[idx6, 2].Value = drd["KodeSales"];
                    ws6.Cells[idx6, 3].Value = drd["NamaSales"];
                    ws6.Cells[idx6, 4].Value = drd["targetomset"];
                    ws6.Cells[idx6, 4].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 5].Value = drd["qty"];
                    ws6.Cells[idx6, 5].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 6].Value = drd["nilai"];
                    ws6.Cells[idx6, 6].Style.Numberformat.Format = "#,##";

                    double nilai1 = Convert.ToDouble(Tools.isNull(drd["nilai"], 0));
                    double target1 = Convert.ToDouble(Tools.isNull(drd["targetomset"], 0));

                    selisih1 = nilai1 - target1;

                    ws6.Cells[idx6, 7].Value = selisih1;
                    ws6.Cells[idx6, 7].Style.Numberformat.Format = "#,##";


                    if (target1 == 0)
                    {
                        ws6.Cells[idx6, 8].Value = 0;
                        ws6.Cells[idx6, 8].Style.Numberformat.Format = "#,##0.00";
                    }
                    else
                    {
                        persen1 = (nilai1 / target1) * 100;
                        ws6.Cells[idx6, 8].Value = persen1;
                        ws6.Cells[idx6, 8].Style.Numberformat.Format = "#,##0.00";
                    }


                    ws6.Cells[idx6, 9].Value = drd["scoreomset"];

                    double score1 = Convert.ToDouble(Tools.isNull(drd["scoreomset"], 0));

                    if (score1 == 0)
                    {
                        ws6.Cells[idx6, 10].Value = 0;
                        ws6.Cells[idx6, 10].Style.Numberformat.Format = "#,##0.00";
                    }
                    else
                    {
                        nilaiscore1 = (score1 * persen1) / 100;
                        ws6.Cells[idx6, 10].Value = nilaiscore1;
                        ws6.Cells[idx6, 10].Style.Numberformat.Format = "#,##0.00";
                    }

                    ws6.Cells[idx6, 11].Value = drd["targetSku"];
                    ws6.Cells[idx6, 11].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 12].Value = drd["actual"];
                    ws6.Cells[idx6, 12].Style.Numberformat.Format = "#,##";

                    double nilai2 = Convert.ToDouble(Tools.isNull(drd["actual"], 0));
                    double target2 = Convert.ToDouble(Tools.isNull(drd["targetSku"], 0));

                    selisih2 = nilai2 - target2;
                    ws6.Cells[idx6, 13].Value = selisih2;
                    ws6.Cells[idx6, 13].Style.Numberformat.Format = "#,##";

                    if (target2 == 0)
                    {
                        ws6.Cells[idx6, 14].Value = 0;
                        ws6.Cells[idx6, 14].Style.Numberformat.Format = "#,##";
                    }
                    else
                    {
                        persen2 = (nilai2 / target2) * 100;
                        ws6.Cells[idx6, 14].Value = persen2;
                        ws6.Cells[idx6, 14].Style.Numberformat.Format = "#,##";
                    }

                    ws6.Cells[idx6, 15].Value = drd["scoresku"];
                    ws6.Cells[idx6, 15].Style.Numberformat.Format = "#,##";

                    double score2 = Convert.ToDouble(Tools.isNull(drd["scoresku"], 0));

                    if (score2 == 0)
                    {
                        ws6.Cells[idx6, 16].Value = 0;
                        ws6.Cells[idx6, 16].Style.Numberformat.Format = "#,##0.00";
                    }
                    else
                    {
                        nilaiscore2 = (score2 * persen2) / 100;
                        ws6.Cells[idx6, 16].Value = nilaiscore2;
                        ws6.Cells[idx6, 16].Style.Numberformat.Format = "#,##0.00";
                    }

                    ws6.Cells[idx6, 17].Value = drd["targetOa"];
                    ws6.Cells[idx6, 17].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 18].Value = drd["oaall"];
                    ws6.Cells[idx6, 18].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 19].Value = drd["oa100"];
                    ws6.Cells[idx6, 19].Style.Numberformat.Format = "#,##";

                    double lebihdari = Convert.ToDouble(Tools.isNull(drd["oaall"], 0));
                    double target3 = Convert.ToDouble(Tools.isNull(drd["targetOa"], 0));
                    
                    selisih3 = lebihdari - target3;

                    ws6.Cells[idx6, 20].Value = selisih3;
                    ws6.Cells[idx6, 20].Style.Numberformat.Format = "#,##";

                    if (target3 == 0)
                    {
                        ws6.Cells[idx6, 21].Value = 0;
                        ws6.Cells[idx6, 21].Style.Numberformat.Format = "#,##0.00";
                    }
                    else
                    {
                        persen3 = (lebihdari / target3) * 100;
                        ws6.Cells[idx6, 21].Value = persen3;
                        ws6.Cells[idx6, 21].Style.Numberformat.Format = "#,##0.00";
                    }


                    ws6.Cells[idx6, 22].Value = drd["scoreoa"];
                    ws6.Cells[idx6, 22].Style.Numberformat.Format = "#,##";

                    double score3 = Convert.ToDouble(Tools.isNull(drd["scoreoa"], 0));

                    if (score3 == 0)
                    {
                        ws6.Cells[idx6, 23].Value = 0;
                        ws6.Cells[idx6, 23].Style.Numberformat.Format = "#,##0.00";
                    }
                    else
                    {
                        nilaiscore3 = (score3 * persen3) / 100;
                        ws6.Cells[idx6, 23].Value = nilaiscore3;
                        ws6.Cells[idx6, 23].Style.Numberformat.Format = "#,##0.00";
                    }

                    ws6.Cells[idx6, 24].Value = nilaiscoreTotal;
                    ws6.Cells[idx6, 24].Style.Numberformat.Format = "#,##0.00";

                    nilaiscoreTotal = nilaiscore1 + nilaiscore2 + nilaiscore3;

                    ws6.Cells[idx6, 25].Value = drd["qtyFB"];
                    ws6.Cells[idx6, 25].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 26].Value = drd["nilaiFB"];
                    ws6.Cells[idx6, 26].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 27].Value = drd["qtyfb4"];
                    ws6.Cells[idx6, 27].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 28].Value = drd["nilaiFb4"];
                    ws6.Cells[idx6, 28].Style.Numberformat.Format = "#,##";

                    ws6.Cells[idx6, 29].Value = drd["qtyfe"];
                    ws6.Cells[idx6, 29].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 30].Value = drd["nilaiFe"];
                    ws6.Cells[idx6, 30].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 31].Value = drd["qtyfe4"];
                    ws6.Cells[idx6, 31].Style.Numberformat.Format = "#,##";
                    ws6.Cells[idx6, 32].Value = drd["nilaiFe4"];
                    ws6.Cells[idx6, 32].Style.Numberformat.Format = "#,##";
                    
                    no++;
                    idx6++;
                }
                #endregion

                #region Summary & Formatting
                ws6.Cells[5, 1, 5, MaxCol6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws6.Cells[idx6 + 1, 1, idx6 + 1, MaxCol6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws6.Cells[5, 1, 5, MaxCol6].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws6.Cells[idx6 + 1, 1, idx6 + 1, MaxCol6].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws6.Cells[6, 1, 6, MaxCol6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws6.Cells[6, 1, 6, MaxCol6].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border6 = ws6.Cells[5, 1, idx6 + 1, MaxCol6].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style =
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region LAPORAN PERBANDINGAN OMSET NETTO

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet8");
                ExcelWorksheet ws7 = p.Workbook.Worksheets[8];

                ws7.Name = "Lap Perbandingan Omset"; //Setting Sheet's name
                ws7.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws7.Cells.Style.Font.Name = "Calibri";

                int MaxCol7 = 6;

                ws7.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws7.Cells[1, 2].Worksheet.Column(2).Width = 24;
                ws7.Cells[1, 3].Worksheet.Column(3).Width = 25;
                //ws7.Cells[1, 4].Worksheet.Column(4).Width = 12;
                for (int r = 4; r <= 6; r++)
                {
                    ws7.Cells[1, r].Worksheet.Column(r).Width = 15;
                }

                ws7.Cells[1, 1].Value = "LAPORAN PERBANDINGAN OMSET " + JenisLaporan;
                ws7.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws7.Cells[4, 1].Value = "";
                ws7.Cells[1, 1, 1, MaxCol7].Merge = true;
                ws7.Cells[2, 1, 2, MaxCol7].Merge = true;
                ws7.Cells[1, 1, 2, MaxCol7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws7.Cells[1, 1, 2, MaxCol7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws7.Cells[1, 1, 2, MaxCol7].Style.Font.Bold = true;
                ws7.Cells[1, 1].Style.Font.Size = 14;
                ws7.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header

                ws7.Cells[5, 1].Value = "NO.";
                ws7.Cells[5, 2].Value = "Kode Sales";
                ws7.Cells[5, 3].Value = "Sales";
                ws7.Cells[5, 4].Value = dateTimePicker1.Value.AddMonths(-1).ToString("MMMM"); //DateTime.Now.AddMonths(-1).ToString("MMMM");
                ws7.Cells[5, 5].Value = dateTimePicker2.Value.ToString("MMMM");
                ws7.Cells[5, 6].Value = "Selisih";




                ws7.Cells[5, 1, 5, MaxCol7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws7.Cells[5, 1, 5, MaxCol7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx7 = 6;
                int nono = 1;
                double selisihnya = 0, totalkemarin = 0, totalsekarang = 0, totalselisih = 0;
                foreach (DataRow drd in dsLaporan.Tables[7].Rows)
                {
                    ws7.Cells[idx7, 1].Value = nono;
                    ws7.Cells[idx7, 2].Value = drd["KodeSales"];
                    ws7.Cells[idx7, 3].Value = drd["NamaSales"];
                    ws7.Cells[idx7, 5].Value = drd["sekarang"];
                    ws7.Cells[idx7, 4].Value = drd["kemarin"];

                    double sekarang = Convert.ToDouble(Tools.isNull(drd["sekarang"], 0));
                    double kemarin = Convert.ToDouble(Tools.isNull(drd["kemarin"], 0));
                    selisihnya = sekarang - kemarin;

                    ws7.Cells[idx7, 6].Value = selisihnya;


                    totalsekarang = totalsekarang + sekarang;
                    totalkemarin = totalkemarin + kemarin;
                    totalselisih = totalselisih + selisihnya;

                    ws7.Cells[idx7 + 1, 4].Value = "";
                    ws7.Cells[idx7 + 1, 5].Value = "";
                    ws7.Cells[idx7 + 1, 6].Value = "";

                    ws7.Cells[idx7 + 2, 4].Value = totalkemarin;
                    ws7.Cells[idx7 + 2, 5].Value = totalsekarang;
                    ws7.Cells[idx7 + 2, 6].Value = totalselisih;

                    nono++;
                    idx7++;
                }
                #endregion

                #region Summary & Formatting
                ws7.Cells[5, 1, 5, MaxCol7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws7.Cells[5, 1, 5, MaxCol7].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws7.Cells[idx7 + 1, 1, idx7 + 1, MaxCol7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws7.Cells[idx7 + 1, 1, idx7 + 1, MaxCol7].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                var border7 = ws7.Cells[5, 1, idx7 + 1, MaxCol7].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style =
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Lap Target VS Actual

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet9");
                ExcelWorksheet ws8 = p.Workbook.Worksheets[9];

                ws8.Name = "Lap Target VS Actual"; //Setting Sheet's name
                ws8.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws8.Cells.Style.Font.Name = "Calibri";

                int MaxCol8 = 10;

                ws8.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws8.Cells[1, 2].Worksheet.Column(2).Width = 24;
                // ws8.Cells[1, 3].Worksheet.Column(3).Width = 15;
                //ws8.Cells[1, 4].Worksheet.Column(4).Width = 10;
                for (int r = 3; r <= 10; r++)
                {
                    ws8.Cells[1, r].Worksheet.Column(r).Width = 15;
                }

                ws8.Cells[1, 1].Value = "LAPORAN Target VS Actual";
                ws8.Cells[3, 1].Value = "Periode  : " + fromdate + " s/d " + todate;
                ws8.Cells[4, 1].Value = "";
                ws8.Cells[1, 1, 1, MaxCol8].Merge = true;
                ws8.Cells[2, 1, 2, MaxCol8].Merge = true;
                ws8.Cells[1, 1, 2, MaxCol8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws8.Cells[1, 1, 2, MaxCol8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws8.Cells[1, 1, 2, MaxCol8].Style.Font.Bold = true;
                ws8.Cells[1, 1].Style.Font.Size = 14;
                ws8.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header

                ws8.Cells[5, 1, 6, 1].Merge = true;
                ws8.Cells[5, 2, 6, 2].Merge = true;
                ws8.Cells[5, 3, 5, 6].Merge = true;
                ws8.Cells[5, 7, 5, 10].Merge = true;

                ws8.Cells[5, 1].Value = "NO.";
                ws8.Cells[5, 2].Value = "KABUPATEN";
                ws8.Cells[5, 3].Value = "OMSET";
                ws8.Cells[6, 3].Value = "TARGET";
                ws8.Cells[6, 4].Value = "ACTUAL";
                ws8.Cells[6, 5].Value = "SELISIH";
                ws8.Cells[6, 6].Value = "(%)";
                ws8.Cells[5, 7].Value = "OA";
                ws8.Cells[6, 7].Value = "TARGET";
                ws8.Cells[6, 8].Value = "ACTUAL";
                ws8.Cells[6, 9].Value = "SELISIH";
                ws8.Cells[6, 10].Value = "(%)";



                ws8.Cells[5, 1, 5, MaxCol8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws8.Cells[5, 1, 5, MaxCol8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx8 = 7;
                int nonono = 1;
                double selisihomset = 0;
                double persenomset = 0;
                double selisihoa = 0;
                double persenoa = 0;
                foreach (DataRow drd in dsLaporan.Tables[8].Rows)
                {
                    ws8.Cells[idx8, 1].Value = nonono;
                    ws8.Cells[idx8, 2].Value = drd["kota"];
                    ws8.Cells[idx8, 3].Value = drd["target"];
                    ws8.Cells[idx8, 4].Value = drd["actualtarget"];
                    double actualomset = Convert.ToDouble(Tools.isNull(drd["actualtarget"], 0));
                    double targetomset = Convert.ToDouble(Tools.isNull(drd["target"], 0));
                    selisihomset = actualomset - targetomset;
                    ws8.Cells[idx8, 5].Value = selisihomset;
                    persenomset = (actualomset / targetomset) * 100;

                    ws8.Cells[idx8, 6].Value = persenomset;
                    ws8.Cells[idx8, 7].Value = drd["target_oa"];
                    ws8.Cells[idx8, 8].Value = drd["oa"];

                    double actualoa = Convert.ToDouble(Tools.isNull(drd["oa"], 0));
                    double targetoa = Convert.ToDouble(Tools.isNull(drd["target_oa"], 0));
                    selisihoa = actualoa - targetoa;
                    ws8.Cells[idx8, 9].Value = selisihoa;
                    persenoa = (actualoa / targetoa) * 100;
                    ws8.Cells[idx8, 10].Value = persenoa;

                    nonono++;
                    idx8++;
                }
                #endregion

                #region Summary & Formatting
                ws8.Cells[5, 1, 5, MaxCol8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws8.Cells[idx8 + 1, 1, idx8 + 1, MaxCol8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws8.Cells[5, 1, 5, MaxCol8].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws8.Cells[idx8 + 1, 1, idx8 + 1, MaxCol8].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws8.Cells[6, 1, 6, MaxCol8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws8.Cells[6, 1, 6, MaxCol8].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                var border8 = ws8.Cells[5, 1, idx8 + 1, MaxCol8].Style.Border;
                border8.Bottom.Style =
                border8.Top.Style =
                border8.Left.Style =
                border8.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region LAPORAN TAGIHAN
                p.Workbook.Worksheets.Add("Laporan Tagihan");
                ExcelWorksheet ws9 = p.Workbook.Worksheets[10];

                // Width
                int MaxCol9 = 14;
                ws9.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws9.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws9.Cells[1, 3].Worksheet.Column(3).Width = 70;
                for (int x = 4; x <= 11; x++)
                {
                    ws9.Cells[1, x].Worksheet.Column(x).Width = 20;
                }
                ws9.Cells[1, 12].Worksheet.Column(12).Width = 50;
                ws9.Cells[1, 13].Worksheet.Column(13).Width = 25;
                ws9.Cells[1, 14].Worksheet.Column(14).Width = 20;



                //ws.Cells[3, 1, 3, 3].Merge = true;

                // Title
                ws9.Cells[1, 1, 1, MaxCol9].Merge = true;
                ws9.Cells[1, 1].Value = "LAPORAN TAGIHAN";
                ws9.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws9.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws9.Cells[2, 1, 2, MaxCol9].Merge = true;
                ws9.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dateTimePicker1.Value) + " s/d " + string.Format("{0:dd MMMM yyyy}", dateTimePicker2.Value);
                ws9.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws9.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //ws.Cells[3, 1].Value = "Update      : ";

                //Header
                ws9.Cells[5, 1].Value = "NO"; ws9.Cells[5, 1, 7, 1].Merge = true;
                ws9.Cells[5, 2].Value = "NO. DPP"; ws9.Cells[5, 2, 7, 2].Merge = true;
                ws9.Cells[5, 3].Value = "NAMA TOKO"; ws9.Cells[5, 3, 7, 3].Merge = true;
                ws9.Cells[5, 4].Value = "IDWIL"; ws9.Cells[5, 4, 7, 4].Merge = true;
                ws9.Cells[5, 5].Value = "NO. NOTA"; ws9.Cells[5, 5, 7, 5].Merge = true;
                ws9.Cells[5, 6].Value = "RENCANA"; ws9.Cells[5, 6, 7, 6].Merge = true;
                ws9.Cells[5, 7].Value = "REALISASI"; ws9.Cells[5, 7, 5, 9].Merge = true;
                ws9.Cells[6, 7].Value = "PEMBAYARAN"; ws9.Cells[6, 7, 6, 9].Merge = true;
                ws9.Cells[7, 7].Value = "TUNAI";// ws9.Cells[5, 2, 7, 2].Merge = true;
                ws9.Cells[7, 8].Value = "GIRO"; //ws9.Cells[5, 3, 7, 3].Merge = true;
                ws9.Cells[7, 9].Value = "TRANSFER"; //ws9.Cells[5, 4, 7, 4].Merge = true;
                ws9.Cells[5, 5].Value = "WILAYAH"; ws9.Cells[5, 5, 7, 5].Merge = true;
                ws9.Cells[5, 6].Value = "OMSET"; ws9.Cells[5, 6, 7, 6].Merge = true;
                ws9.Cells[5, 10].Value = "TTL. REALISASI"; ws9.Cells[5, 10, 7, 10].Merge = true;
                ws9.Cells[5, 11].Value = "SALDO"; ws9.Cells[5, 11, 7, 11].Merge = true;
                ws9.Cells[5, 12].Value = "KETERANGAN"; ws9.Cells[5, 12, 7, 12].Merge = true;
                ws9.Cells[5, 13].Value = "KD SALES"; ws9.Cells[5, 13, 7, 13].Merge = true;
                ws9.Cells[5, 14].Value = "TGL. REG"; ws9.Cells[5, 14, 7, 14].Merge = true;


                ws9.Cells[5, 1, 7, MaxCol9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws9.Cells[5, 1, 7, MaxCol9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                int rowx9 = 8;
                int nomer8 = 0;
                double RpKas, RpGiro, RpTransfer, realisasi, RpTagih, saldo, rencana = 0;
                double ttlrencana = 0;
                double ttltunai = 0;
                double ttlgiro = 0;
                double ttltransfer = 0;
                double ttlRealisasi = 0;
                double ttlsaldo = 0;
                foreach (DataRow dr9 in dsLaporan.Tables[9].Rows)
                {
                    nomer8 = nomer8 + 1;
                    ws9.Cells[rowx9, 1].Value = nomer8;
                    ws9.Cells[rowx9, 2].Value = dr9["NoReg"];
                    ws9.Cells[rowx9, 3].Value = dr9["NamaToko"];
                    ws9.Cells[rowx9, 4].Value = dr9["WilID"];
                    ws9.Cells[rowx9, 5].Value = dr9["NoTransaksi"];
                    ws9.Cells[rowx9, 6].Value = dr9["RpTagih"];
                    ws9.Cells[rowx9, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    RpKas = Convert.ToDouble(Tools.isNull(dr9["RpKas"], 0));
                    RpGiro = Convert.ToDouble(Tools.isNull(dr9["RpGiro"], 0));
                    RpTransfer = Convert.ToDouble(Tools.isNull(dr9["RpTransfer"], 0));

                    ws9.Cells[rowx9, 7].Value = RpKas;
                    ws9.Cells[rowx9, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws9.Cells[rowx9, 8].Value = RpGiro;
                    ws9.Cells[rowx9, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws9.Cells[rowx9, 9].Value = RpTransfer;
                    ws9.Cells[rowx9, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    realisasi = RpKas + RpGiro + RpTransfer;

                    ws9.Cells[rowx9, 10].Value = realisasi;
                    ws9.Cells[rowx9, 10].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    RpTagih = Convert.ToDouble(Tools.isNull(dr9["RpTagih"], 0));

                    //ws9.Cells[rowx9, 11].Value =RpTagih;
                    //ws9.Cells[rowx9, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    saldo = RpTagih - realisasi;
                    ws9.Cells[rowx9, 11].Value = saldo;
                    ws9.Cells[rowx9, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws9.Cells[rowx9, 12].Value = dr9["Keterangan"];
                    ws9.Cells[rowx9, 13].Value = dr9["KodeSales"];
                    ws9.Cells[rowx9, 14].Value = string.Format("{0:dd MMMM yyyy}", dr9["TglTagih"]);

                    rencana = Convert.ToDouble(dr9["RpTagih"]);
                    ttlrencana = ttlrencana + rencana;
                    ttltunai = ttltunai + RpKas;
                    ttlgiro = ttlgiro + RpGiro;
                    ttltransfer = ttltransfer + RpTransfer;
                    ttlRealisasi = ttlRealisasi + realisasi;
                    ttlsaldo = ttlsaldo + saldo;



                    ws9.Cells[rowx9 + 1, 6].Value = 0;
                    ws9.Cells[rowx9 + 1, 7].Value = 0;
                    ws9.Cells[rowx9 + 1, 8].Value = 0;
                    ws9.Cells[rowx9 + 1, 9].Value = 0;
                    ws9.Cells[rowx9 + 1, 10].Value = 0;
                    ws9.Cells[rowx9 + 1, 11].Value = 0;


                    ws9.Cells[rowx9 + 2, 6].Value = ttlrencana;
                    ws9.Cells[rowx9 + 2, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws9.Cells[rowx9 + 2, 7].Value = ttltunai;
                    ws9.Cells[rowx9 + 2, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws9.Cells[rowx9 + 2, 8].Value = ttlgiro;
                    ws9.Cells[rowx9 + 2, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws9.Cells[rowx9 + 2, 9].Value = ttltransfer;
                    ws9.Cells[rowx9 + 2, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws9.Cells[rowx9 + 2, 10].Value = ttlRealisasi;
                    ws9.Cells[rowx9 + 2, 10].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws9.Cells[rowx9 + 2, 11].Value = ttlsaldo;
                    ws9.Cells[rowx9 + 2, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    rowx9++;
                }


                ws9.Cells[5, 1, 5, MaxCol9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws9.Cells[6, 1, 6, MaxCol9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws9.Cells[7, 1, 7, MaxCol9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws9.Cells[rowx9 + 1, 1, rowx9 + 1, MaxCol9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws9.Cells[5, 1, 5, MaxCol9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws9.Cells[6, 1, 6, MaxCol9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws9.Cells[7, 1, 7, MaxCol9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws9.Cells[rowx9 + 1, 1, rowx9 + 1, MaxCol9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border9 = ws9.Cells[5, 1, rowx9 + 1, MaxCol9].Style.Border;
                border9.Bottom.Style =
                border9.Top.Style =
                border9.Left.Style =
                border9.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                #region LAPORAN REKAP TAGIHAN
                p.Workbook.Worksheets.Add("Laporan Rekap Tagihan");
                ExcelWorksheet ws10 = p.Workbook.Worksheets[11];

                // Width
                int MaxCol10 = 4;
                ws10.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws10.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws10.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws10.Cells[1, 4].Worksheet.Column(4).Width = 20;




                //ws.Cells[3, 1, 3, 3].Merge = true;

                // Title
                ws10.Cells[1, 1, 1, MaxCol10].Merge = true;
                ws10.Cells[1, 1].Value = "REKAP TAGIHAN";
                ws10.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws10.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws10.Cells[2, 1, 2, MaxCol10].Merge = true;
                ws10.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dateTimePicker1.Value) + " s/d " + string.Format("{0:dd MMMM yyyy}", dateTimePicker2.Value);
                ws10.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws10.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //ws.Cells[3, 1].Value = "Update      : ";

                //Header
                ws10.Cells[5, 1].Value = "NO"; ws10.Cells[5, 1, 6, 1].Merge = true;
                ws10.Cells[5, 2].Value = "KD SALES"; ws10.Cells[5, 2, 6, 2].Merge = true;
                ws10.Cells[5, 3].Value = "OMSET"; ws10.Cells[5, 3, 6, 3].Merge = true;
                ws10.Cells[5, 4].Value = "TAGIHAN"; ws10.Cells[5, 4, 6, 4].Merge = true;


                ws10.Cells[5, 1, 6, MaxCol10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws10.Cells[5, 1, 6, MaxCol10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                int rowx10 = 7;
                int nomer9 = 0;
                double oms = 0;
                double tagihan = 0;
                double ttloms = 0;
                double ttltgh = 0;
                foreach (DataRow dr10 in dsLaporan.Tables[10].Rows)
                {
                    nomer9 = nomer9 + 1;
                    ws10.Cells[rowx10, 1].Value = nomer9;
                    ws10.Cells[rowx10, 2].Value = dr10["KodeSales"];
                    ws10.Cells[rowx10, 3].Value = dr10["omset"];
                    ws10.Cells[rowx10, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws10.Cells[rowx10, 4].Value = dr10["tagihan"];
                    ws10.Cells[rowx10, 4].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws10.Cells[rowx10 + 1, 3].Value = "";
                    ws10.Cells[rowx10 + 1, 4].Value = "";

                    oms = Convert.ToDouble(dr10["omset"]);
                    tagihan = Convert.ToDouble(dr10["tagihan"]);
                    ttloms = ttloms + oms;
                    ttltgh = ttltgh + tagihan;

                    ws10.Cells[rowx10 + 1, 3].Value = "";
                    ws10.Cells[rowx10 + 1, 4].Value = "";

                    ws10.Cells[rowx10 + 2, 3].Value = ttloms;
                    ws10.Cells[rowx10 + 2, 4].Value = ttltgh;

                    rowx10++;
                }


                ws10.Cells[5, 1, 5, MaxCol10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws10.Cells[6, 1, 6, MaxCol10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws10.Cells[7, 1, 7, MaxCol10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws10.Cells[rowx10 + 1, 1, rowx10 + 1, MaxCol10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws10.Cells[5, 1, 5, MaxCol10].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws10.Cells[6, 1, 6, MaxCol10].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                //ws10.Cells[7, 1, 7, MaxCol10].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws10.Cells[rowx10 + 1, 1, rowx10 + 1, MaxCol10].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border10 = ws10.Cells[5, 1, rowx10 + 1, MaxCol10].Style.Border;
                border10.Bottom.Style =
                border10.Top.Style =
                border10.Left.Style =
                border10.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Penjualan_Per_barang" + dateTimePicker2.Value.ToString("yyyyMMdd") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }

        public void UploadLaporan()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string pathString = @"c:\temp";

                string filename1 = pathString + "\\" + "omst.xml";
                string filename2 = pathString + "\\" + "omstall.xml"; 
                


                UploadXML1(filename1, pathString);
                UploadXML2(filename2, pathString);

                ZipFile(filename1,filename2,pathString);

                //MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + pathString + "\\dbfmatch.zip");
                MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + ". Lokasi File: " + pathString + "\\dbfmatch"+GlobalVar.Gudang+".zip");

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

        private void UploadXML1(string FileName, string pathString)
        {
            try
            {

                if (!System.IO.Directory.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }

                //FileName = pathString + "\\" + "omst-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                dsLaporan.Tables[7].WriteXml(FileName);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void UploadXML2(string FileName, string pathString)
        {
            try
            {

                if (!System.IO.Directory.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }

                //FileName = pathString + "\\" + "omstall-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                dsLaporan.Tables[6].WriteXml(FileName);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ZipFile(string FileName1, string FileName2, string Pathstring)//, string FileName3, string FileName4)
        {
            List<string> files = new List<string>();


            //string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".xml";

            string fileZipName = Pathstring + "\\dbfmatch" + GlobalVar.Gudang + ".zip";
            files.Add(FileName1);
            files.Add(FileName2);
            //files.Add(fileName3);
            
            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(FileName1) && File.Exists(FileName2))// && File.Exists(fileIndex))
            {
                File.Delete(FileName1);
                File.Delete(FileName2);
                //File.Delete(fileName3);
                //File.Delete(fileName4);
                //File.Delete(fileIndex);
            }
        }

    }
}