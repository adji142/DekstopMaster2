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
using ISA.Toko.Class;
using ISA.Pin;

namespace ISA.Toko.PSReport
{
    public partial class frmCegatanLaporan : ISA.Toko.BaseForm
    {
        DataTable dtLaporanCustomerInti, dtStokTidakBergerak, dtKurang10, dtKunjungan;
        DateTime todate,tglpsreport,tglAwal;
        string pinCI, pinKunjungan;
        DataSet dsData = new DataSet();
        public frmCegatanLaporan(Form caller, DataTable dtCustomerInti, DataTable dtTidakBergerak, DataTable dtKurang10toko, DateTime a, DateTime fromdate, DateTime akhir)
        {

            dtLaporanCustomerInti = dtCustomerInti;
            dtStokTidakBergerak = dtTidakBergerak;
            dtKurang10 = dtKurang10toko;
            tglAwal = akhir;
            todate = a;
            tglpsreport = DateTime.Now;
            this.Caller = caller;
            InitializeComponent();
        }

        public frmCegatanLaporan()
        {
            InitializeComponent();
        }
        private void frmCegatanLaporan_Load(object sender, EventArgs e)
        {
            //this.pinCI = PINTransaksi.createPINPSReportCi(tglpsreport, GlobalVar.Gudang);
            //this.pinKunjungan = PINTransaksi.createPINPSReportKun(tglpsreport, GlobalVar.Gudang);

            this.pinCI = key.CreateDailyPin(tglpsreport, GlobalVar.Gudang, key.BaseCode.PSReportCI, key.BaseCodeMultiplier.PSReportCI);
            this.pinKunjungan = key.CreateDailyPin(tglpsreport, GlobalVar.Gudang, key.BaseCode.PSReportKS, key.BaseCodeMultiplier.PSReportKS);

            if (dtLaporanCustomerInti.Rows.Count == 0 && dtStokTidakBergerak.Rows.Count == 0)
            {
                txtci.Enabled = false;
                txtci.Text = this.pinCI;
                cmdGetPinCI.Enabled = false;
            }
            //if (dtKurang10.Rows.Count == 0)
            //{
                txtkunj.Enabled = false;
                txtkunj.Text = this.pinKunjungan;
                cmdGetPinKunjungan.Enabled = false;
            //}

           
        }

        private void cmdGetPinCI_Click(object sender, EventArgs e)
        {
            GenerateExcellCI(dtLaporanCustomerInti, dtStokTidakBergerak);
            Getdata();
            DisplayReport();
        }

        public void GenerateExcellCI(DataTable dtLaporanCustomerInti, DataTable dtStokTidakBergerak)
        {
            string tanggalLap = todate.ToString("dd-MM-yyyy");
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "Pengajuan_Pin_Ci";
                
                #region Laporan CUSTOMER INTI TIDAK ADA TRANSAKSI SELAMA DUA BULAN TERAKHIR


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Customer Inti"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol = 8;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 35;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 75;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 35;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 17;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 26;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 23;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 59;


                ws.Cells[1, 1].Value = "CUSTOMER INTI TIDAK ADA TRANSAKSI SELAMA DUA BULAN TERAKHIR";
                ws.Cells[3, 1].Value = "Tanggal  : " + tanggalLap;
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
                ws.Cells[5, 2].Value = "NAMA TOKO";
                ws.Cells[5, 3].Value = "ALAMAT";
                ws.Cells[5, 4].Value = "KOTA";
                ws.Cells[5, 5].Value = "KD SALES";
                ws.Cells[5, 6].Value = "NO TELPON";
                ws.Cells[5, 7].Value = "NAMA PEMILIK";
                ws.Cells[5, 8].Value = "KETERANGAN";


                ws.Cells[5, 1, 5, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 1, 5, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx = 6;
                int num = 1;
                foreach (DataRow dr in dtLaporanCustomerInti.Rows)
                {
                    ws.Cells[idx, 1].Value = num;
                    ws.Cells[idx, 2].Value = dr["namatoko"];
                    ws.Cells[idx, 3].Value = dr["alamat"];
                    ws.Cells[idx, 4].Value = dr["kota"];
                    ws.Cells[idx, 5].Value = dr["kodesales"];
                    ws.Cells[idx, 6].Value = dr["notelp"];
                    ws.Cells[idx, 7].Value = dr["namap"];
                    ws.Cells[idx, 8].Value = dr["keterangan"];


                    idx++;
                    num++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border = ws.Cells[5, 1, idx + 1, MaxCol].Style.Border;
                //ws.Cells[5, 7].sty

                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan STOK TIDAK BERGERAK

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[2];

                ws1.Name = "Stok tidak bergerak"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol1 = 9;

                ws1.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws1.Cells[1, 2].Worksheet.Column(2).Width = 71;
                ws1.Cells[1, 3].Worksheet.Column(3).Width = 25;
                ws1.Cells[1, 4].Worksheet.Column(4).Width = 13;
                ws1.Cells[1, 5].Worksheet.Column(5).Width = 16;
                ws1.Cells[1, 6].Worksheet.Column(6).Width = 16;
                ws1.Cells[1, 7].Worksheet.Column(7).Width = 16;
                ws1.Cells[1, 8].Worksheet.Column(8).Width = 13;


                ws1.Cells[1, 1].Value = "STOK TIDAK BERGERAK";
                ws1.Cells[3, 1].Value = "Tanggal  : "+ tanggalLap;
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
                ws1.Cells[5, 2].Value = "NAMA STOK";
                ws1.Cells[5, 3].Value = "ID BRG";
                ws1.Cells[5, 4].Value = "SATUAN";
                ws1.Cells[5, 5].Value = "NO NOTA AG";
                ws1.Cells[5, 6].Value = "TGL KRM";
                ws1.Cells[5, 7].Value = "STOK GDG";
                ws1.Cells[5, 8].Value = "TGL TRM";
                ws1.Cells[5, 9].Value = "KD GDG";
                


                ws1.Cells[5, 1, 5, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[5, 1, 5, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                if (GlobalVar.Gudang.Substring(0, 1) != "9")
                {
                    #region FillData
                    int idx1 = 6;

                    int num5 = 1;
                    foreach (DataRow dr in dtStokTidakBergerak.Rows)
                    {
                        ws1.Cells[idx1, 1].Value = num5;
                        ws1.Cells[idx1, 2].Value = dr["NamaStok"];
                        ws1.Cells[idx1, 3].Value = dr["KodeBarang"];
                        ws1.Cells[idx1, 4].Value = dr["satuan"];
                        ws1.Cells[idx1, 5].Value = dr["NoNota"];
                        //string.Format("{0:dd MMMM yyyy}", tglpsreport)
                        //DateTime tglkirim =Convert.ToDateTime(dr["TglKirim"]);
                        ws1.Cells[idx1, 6].Value = string.Format("{0:dd MMMM yyyy}", (dr["TglKirim"]));//tglkirim.ToShortDateString();
                        ws1.Cells[idx1, 7].Value = dr["StokAkhirGudang"];
                        //DateTime tglTerima = Convert.ToDateTime(dr["TglTerima"]);
                        ws1.Cells[idx1, 8].Value = string.Format("{0:dd MMMM yyyy}", (dr["TglTerima"]));
                        ws1.Cells[idx1, 9].Value = dr["KodeGudang"];


                        idx1++;
                        num5++;
                    }
                    #endregion
                    #region Summary & Formatting
                    ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                    var border1 = ws1.Cells[5, 1, idx1 + 1, MaxCol1].Style.Border;
                    //ws.Cells[5, 7].sty

                    border1.Bottom.Style =
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.Thin;

                    #endregion
                #endregion
                }
                #region PANGAJUAN PIN
                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet3");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[3];

                ws2.Name = "PANGAJUAN PIN"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol2 = 6;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 13;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 16;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 72;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 19;
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 10;



                ws2.Cells[1, 1].Value = "Pengajuan Pin";
                ws2.Cells[3, 1].Value = "Tanggal  : " + tanggalLap;
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
                ws2.Cells[5, 2].Value = "KD GDG";
                ws2.Cells[5, 3].Value = "TANGGAL";
                ws2.Cells[5, 4].Value = "KETERANGAN";
                ws2.Cells[5, 5].Value = "PIN";
                ws2.Cells[5, 6].Value = "USER";

                ws2.Cells[5, 1, 5, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[5, 1, 5, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                

                #endregion

                #region FillData
                int idx2 = 6;

                int num2 = 1;
                string tanggalkunj = todate.ToString("dd-MM-yyyy");
                ws2.Cells[idx2, 1].Value = num2;
                ws2.Cells[idx2, 2].Value = GlobalVar.Gudang;
                ws2.Cells[idx2, 3].Value = tanggalkunj;
                ws2.Cells[idx2, 4].Value = "CUSTOMER INI TIDAK BERTRANSAKSI DUA BULAN TERKAHIR";
                ws2.Cells[idx2 + 1, 4].Value = "STOK TIDAK BERGERAK SELAMA SATU BULAN TERHITUNG DARI TGL TERIMA";
                ws2.Cells[idx2, 5].Value = "";
                ws2.Cells[idx2, 6].Value = SecurityManager.UserID;

                #endregion

                #region Summary & Formatting
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border2 = ws2.Cells[5, 1, idx2 + 1, MaxCol2].Style.Border;
                //ws.Cells[5, 7].sty

                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Pengajuan_Pin_Ci" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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


        private void Getdata()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_AnalisaOA4Bulan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, tglAwal));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, tglpsreport));
                    dsData = db.Commands[0].ExecuteDataSet();
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

        #region generate excel

        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Analisa Kunjungan OA 4 bulan";


            #region sheet 1
            ex.Workbook.Worksheets.Add("OA Aktif 4 bulan");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 7;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 50;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 70;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "Laporan     : LAPORAN OA AKTIF 4 BULAN";
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", tglpsreport) + " s/d " + string.Format("{0:dd MMMM yyyy}", todate);
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 1].Value = "NO"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "KODE TOKO"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA TOKO"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "ALAMAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "WILAYAH"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "OMSET"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "KUNJUNGAN"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;
            int nomer = 0;
            foreach (DataRow dr1 in dsData.Tables[0].Rows)
            {
                nomer = nomer + 1;
                ws.Cells[rowx, 1].Value = nomer;
                ws.Cells[rowx, 2].Value = dr1["KodeToko"];
                ws.Cells[rowx, 3].Value = dr1["NamaToko"];
                ws.Cells[rowx, 4].Value = dr1["Alamat"];
                ws.Cells[rowx, 5].Value = dr1["wilayah"];
                ws.Cells[rowx, 6].Value = dr1["Omset"];
                ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 7].Value = string.Format("{0:dd MMMM yyyy}", dr1["Kunjungan"]);

                rowx++;
            }


            ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 1, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            #endregion

            #region sheet 2
            ex.Workbook.Worksheets.Add("Rekap Wilayah");
            ExcelWorksheet ws1 = ex.Workbook.Worksheets[2];

            // Width
            int MaxCol1 = 5;
            ws1.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws1.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws1.Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws1.Cells[1, 4].Worksheet.Column(4).Width = 20;
            ws1.Cells[1, 5].Worksheet.Column(5).Width = 20;
            //ws1.Cells[1, 6].Worksheet.Column(6).Width = 20;
            //ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
            ws1.Cells[1, 1].Value = "Laporan     : LAPORAN REKAP WILAYAH";
            ws1.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws1.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
            ws1.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", tglpsreport) + " s/d " + string.Format("{0:dd MMMM yyyy}", todate);
            ws1.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws1.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws1.Cells[5, 1].Value = "NO"; ws1.Cells[5, 1, 6, 1].Merge = true;
            ws1.Cells[5, 2].Value = "WILAYAH"; ws1.Cells[5, 2, 6, 2].Merge = true;
            ws1.Cells[5, 3].Value = "OA"; ws1.Cells[5, 3, 6, 3].Merge = true;
            ws1.Cells[5, 4].Value = "AKTUAL OA"; ws1.Cells[5, 4, 6, 4].Merge = true;
            ws1.Cells[5, 5].Value = "SELISIH"; ws1.Cells[5, 5, 6, 5].Merge = true;
            //ws1.Cells[5, 6].Value = "OMSET"; ws1.Cells[5, 6, 6, 6].Merge = true;
            //ws1.Cells[5, 7].Value = "KUNJUNGAN"; ws1.Cells[5, 7, 6, 7].Merge = true;

            ws1.Cells[5, 1, 6, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[5, 1, 6, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowxx = 7;
            int nom = 0;
            foreach (DataRow dr1 in dsData.Tables[1].Rows)
            {
                nom = nom + 1;
                ws1.Cells[rowxx, 1].Value = nom;
                ws1.Cells[rowxx, 2].Value = dr1["wilayah"];

                int oa = Convert.ToInt32(Tools.isNull(dr1["oa"], 0));
                int actual = Convert.ToInt32(Tools.isNull(dr1["actualoa"], 0));
                ws1.Cells[rowxx, 3].Value = oa;
                ws1.Cells[rowxx, 4].Value = actual;
                int total = 0;
                total = oa - actual;
                ws1.Cells[rowxx, 5].Value = total;

                rowxx++;
            }


            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border1 = ws1.Cells[5, 1, rowxx - 1, MaxCol1].Style.Border;
            border1.Bottom.Style =
            border1.Top.Style =
            border1.Left.Style =
            border1.Right.Style = ExcelBorderStyle.Thin;

            #endregion

            #region sheet 3
            ex.Workbook.Worksheets.Add("Statistik");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[3];

            // Width
            int MaxCol2 = 3;
            ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 20;
            //ws2.Cells[1, 4].Worksheet.Column(4).Width = 20;
            //ws2.Cells[1, 5].Worksheet.Column(5).Width = 20;
            //ws1.Cells[1, 6].Worksheet.Column(6).Width = 20;
            //ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws2.Cells[1, 1, 1, MaxCol2].Merge = true;
            ws2.Cells[1, 1].Value = "Laporan     : LAPORAN REKAP WILAYAH";
            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws2.Cells[2, 1, 2, MaxCol2].Merge = true;
            ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", tglpsreport) + " s/d " + string.Format("{0:dd MMMM yyyy}", todate);
            ws2.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws2.Cells[5, 1].Value = "NO"; ws2.Cells[5, 1, 6, 1].Merge = true;
            ws2.Cells[5, 2].Value = "KETERANGAN"; ws2.Cells[5, 2, 6, 2].Merge = true;
            ws2.Cells[7, 2].Value = "OA 4 bulan";
            ws2.Cells[8, 2].Value = "OA jadi omset";
            ws2.Cells[9, 2].Value = "OA terkunjungi tidak ada omset";
            ws2.Cells[10, 2].Value = "OA tidak ada kunjungan tidak ada omset";
            ws2.Cells[5, 3].Value = "JUMLAH"; ws2.Cells[5, 3, 6, 3].Merge = true;
            //ws2.Cells[5, 4].Value = "AKTUAL OA"; ws2.Cells[5, 4, 6, 4].Merge = true;
            //ws2.Cells[5, 5].Value = "SELISIH"; ws2.Cells[5, 5, 6, 5].Merge = true;
            //ws1.Cells[5, 6].Value = "OMSET"; ws1.Cells[5, 6, 6, 6].Merge = true;
            //ws1.Cells[5, 7].Value = "KUNJUNGAN"; ws1.Cells[5, 7, 6, 7].Merge = true;

            ws2.Cells[5, 1, 6, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[5, 1, 6, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowxxx = 7;
            int cell = 3;
            int no = 0;
            foreach (DataRow dr1 in dsData.Tables[2].Rows)
            {
                no = no + 1;
                //ws2.Cells[rowxxx, 1].Value = no;
                ws2.Cells[7, 1].Value = "1";
                ws2.Cells[8, 1].Value = "2";
                ws2.Cells[9, 1].Value = "3";
                ws2.Cells[10, 1].Value = "4";

                ws2.Cells[7, cell].Value = dr1["oaall"];
                ws2.Cells[8, cell].Value = dr1["JadiOmset"];
                ws2.Cells[9, cell].Value = dr1["Kunj"];
                ws2.Cells[10, cell].Value = dr1["TdkKunjTdkOms"];


            }


            ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border2 = ws2.Cells[5, 1, 11 - 1, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            #endregion
            return ex;
        }
        #endregion


        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Analisa Kunjungan OA 4 Bulan" + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private void cmdyes_Click(object sender, EventArgs e)
        {
            if (txtci.Text == this.pinCI && txtkunj.Text == this.pinKunjungan)
            {
                if (dtLaporanCustomerInti.Rows.Count > 0 || dtStokTidakBergerak.Rows.Count > 0)
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, "PINCI"));
                        db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, this.pinCI));
                        db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, "3"));
                        db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.Text, "CI DAN STOK"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }
                if (dtKurang10.Rows.Count > 0)
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, "PINTRANS"));
                        db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, this.pinKunjungan));
                        db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, "4"));
                        db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.Text, "KUNJUNGAN"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }

                PSReport.frmLaporanPenjualanPerItem frmCaller = (PSReport.frmLaporanPenjualanPerItem)this.Caller;
                frmCaller.GenerateLaporan();
                frmCaller.UploadLaporan();
                this.Close();

            }
            else
            {
                MessageBox.Show("PIN yang ada masukkan salah");
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekKunjKurang10detail"));
                //db.Commands[0].Parameters.Add(new Parameter("@x", SqlDbType.DateTime, a));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime,todate));
                dtKunjungan = db.Commands[0].ExecuteDataTable();
            }

            GenerateExcellKunjungan(dtKurang10, dtKunjungan);
            
        }

        public void GenerateExcellKunjungan(DataTable dtKurang10, DataTable dtKunjungan)
        {
            string tanggalLap = todate.ToString("dd-MM-yyyy");
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "Pengajuan_Pin_kunj_sales_dibawah_target";

                #region Laporan Rekap Kunjungan Sales


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Rekap Kunjungan Sales"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol = 5;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 20;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;

                ws.Cells[1, 1].Value = "REKAP KUNJUNGAN SALES DIBAWAH TARGET";
                ws.Cells[3, 1].Value = "Tanggal  : " + tanggalLap;
                ws.Cells[4, 1].Value = "";
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws.Cells[5, 4, 5, 5].Merge = true;

                ws.Cells[5, 1].Value = "NO.";
                ws.Cells[5, 2].Value = "KD GDG";
                ws.Cells[5, 3].Value = "KD SALES";
                ws.Cells[5, 4].Value = "KUNJUNGAN";
                ws.Cells[6, 4].Value = "TANGGAL";
                ws.Cells[6, 5].Value = "JUMLAH";



                ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx = 7;
                int num = 1;
                foreach (DataRow dt in dtKurang10.Rows)
                {
                    string tanggal = todate.ToString("dd-MM-yyyy");

                    ws.Cells[idx, 1].Value = num;
                    ws.Cells[idx, 2].Value = GlobalVar.Gudang;
                    ws.Cells[idx, 3].Value = dt["kd_sales"];
                    ws.Cells[idx, 4].Value = tanggal;
                    ws.Cells[idx, 5].Value = dt["Kunjung"];

                    idx++;
                    num++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border = ws.Cells[5, 1, idx + 1, MaxCol].Style.Border;
                //ws.Cells[5, 7].sty

                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Kunjungan Sales

                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[2];

                ws1.Name = "Kunjungan Sales"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol1 = 7;

                ws1.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws1.Cells[1, 2].Worksheet.Column(2).Width = 15;
                ws1.Cells[1, 3].Worksheet.Column(3).Width = 25;
                ws1.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws1.Cells[1, 5].Worksheet.Column(5).Width = 20;
                ws1.Cells[1, 6].Worksheet.Column(6).Width = 35;
                ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;



                ws1.Cells[1, 1].Value = "KUNJUNGAN SALES";
                ws1.Cells[3, 1].Value = "Tanggal  : " + tanggalLap;
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
                ws1.Cells[5, 2].Value = "KD GDG";
                ws1.Cells[5, 3].Value = "TGL KUNJUNGAN";
                ws1.Cells[5, 4].Value = "KD SALES";
                ws1.Cells[5, 5].Value = "NAMA TOKO";
                ws1.Cells[5, 6].Value = "ALAMAT";
                ws1.Cells[5, 7].Value = "KOTA";


                ws1.Cells[5, 1, 5, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[5, 1, 5, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx1 = 6;
                int numq = 1;
                foreach (DataRow dr in dtKunjungan.Rows)
                {
                    ws1.Cells[idx1, 1].Value = numq;
                    ws1.Cells[idx1, 2].Value = GlobalVar.Gudang;
                    ws1.Cells[idx1, 3].Value = dr["tgl_kunj"].ToString();
                    ws1.Cells[idx1, 4].Value = dr["kd_sales"];
                    ws1.Cells[idx1, 5].Value = dr["namatoko"];
                    ws1.Cells[idx1, 6].Value = dr["alamat"];
                    ws1.Cells[idx1, 7].Value = dr["kota"];
                    //ws.Cells[idx, 8].Value = dr["NoNota"];


                    idx1++;
                    numq++;
                }
                #endregion
                #region Summary & Formatting
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border1 = ws1.Cells[5, 1, idx1 + 1, MaxCol1].Style.Border;
                //ws.Cells[5, 7].sty

                border1.Bottom.Style =
                border1.Top.Style =
                border1.Left.Style =
                border1.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region PANGAJUAN PIN
                // Rekap (penjualan Perabarang)
                p.Workbook.Worksheets.Add("Sheet3");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[3];

                ws2.Name = "PANGAJUAN PIN"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol2 = 6;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 13;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 16;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 72;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 19;
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 10;



                ws2.Cells[1, 1].Value = "PANGAJUAN PIN";
                ws2.Cells[3, 1].Value = "Tanggal  : " +tanggalLap;
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
                ws2.Cells[5, 2].Value = "KD GDG";
                ws1.Cells[5, 3].Value = "TANGGAL";
                ws2.Cells[5, 4].Value = "KETERANGAN";
                ws2.Cells[5, 5].Value = "PIN";
                ws2.Cells[5, 6].Value = "USER";

                ws2.Cells[5, 1, 5, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[5, 1, 5, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx2 = 6;
                int num2 = 1;

                string tanggalkunj = todate.ToString("dd-MM-yyyy");
                ws2.Cells[idx2, 1].Value = num2;
                ws2.Cells[idx2, 2].Value = GlobalVar.Gudang;
                ws2.Cells[idx2, 3].Value = tanggalkunj;
                ws2.Cells[idx2, 4].Value = "KUNJUNGAN DIBAWAH TARGET (10 TOKO)";
                ws2.Cells[idx2, 5].Value = "";
                ws2.Cells[idx2, 6].Value = SecurityManager.UserID;
     


                #endregion

                #region Summary & Formatting
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border2 = ws2.Cells[5, 1, idx2 + 1, MaxCol2].Style.Border;

                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Pengajuan_Pin_kunj_sales_dibawah_target" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

