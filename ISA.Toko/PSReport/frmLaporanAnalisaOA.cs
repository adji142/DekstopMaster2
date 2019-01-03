using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Globalization;

namespace ISA.Toko.PSReport
{
    public partial class frmLaporanAnalisaOA : ISA.Toko.BaseForm
    {
        DataSet dsData = new DataSet();

        DataSet dsDataYYK = new DataSet();

        DataSet dsDataSPV = new DataSet();

        DataTable dtSPV, dtYYK = new DataTable();

        public frmLaporanAnalisaOA()
        {
            InitializeComponent();
        }

        private void frmLaporanAnalisaOA_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }


        private void CegatanLaporanSPV()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CegataOA_SPV"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtSPV = db.Commands[0].ExecuteDataTable();
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

        private void CegatanLaporanYYK()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CegataOA_Support"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtYYK = db.Commands[0].ExecuteDataTable();
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

        public void Getdata()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_AnalisaOA4Bulan")); 
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
                if (dsData.Tables.Count > 0)
                {
                    DisplayReport();
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
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
            ex.Workbook.Properties.SetCustomPropertyValue("OA", "1147");

            #region sheet 1
            ex.Workbook.Worksheets.Add("OA Aktif 4 bulan");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

 

            // Width
            int MaxCol = 10;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 50;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 70;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 10;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 20;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 20;
            ws.Cells[1,10].Worksheet.Column(10).Width = 50;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "Laporan     : LAPORAN OA AKTIF 4 BULAN";
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 1].Value = "NO"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "KODE TOKO"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA TOKO"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "ALAMAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "WILAYAH"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "IDWIL"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "OMSET BRUTTO"; ws.Cells[5, 7, 6, 7].Merge = true;
            ws.Cells[5, 8].Value = "OMSET NETTO"; ws.Cells[5, 8, 6, 8].Merge = true;
            ws.Cells[5, 9].Value = "KUNJUNGAN"; ws.Cells[5, 9, 6, 9].Merge = true;
            ws.Cells[5,10].Value = "KETERANGAN"; ws.Cells[5,10, 6,10].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int rowx = 7;
            int nomer= 0;
            int nJob = 0;
            int nJon = 0;
            string cKet = "";
            
            foreach (DataRow dr1 in dsData.Tables[0].Rows)
            {
                int nOmset = 0;
                nOmset = Convert.ToInt32(Tools.isNull(dr1["Omset"],0)) - 
                         Convert.ToInt32(Tools.isNull(dr1["Retjual"],0)) -
                         Convert.ToInt32(Tools.isNull(dr1["Rettarikan"],0)) + 
                         Convert.ToInt32(Tools.isNull(dr1["Kpj"],0)) +
                         Convert.ToInt32(Tools.isNull(dr1["Krj"],0));

                nJob = nJob + Convert.ToInt32(Tools.isNull(dr1["Omset"], 0));
                nJon = nJon + nOmset;

                if (Convert.ToInt32(Tools.isNull(dr1["Omset"], 0)) > 0)
                {
                    cKet = "Ada Omset";
                }
                else
                {
                    if (string.Format("{0:dd MMMM yyyy}", dr1["Kunjungan"]) != "")
                    {
                        cKet = "Ada Kunjungan, Tidak ada Omset";
                    }
                    else
                    {
                        cKet = "Tidak Ada Kunjungan dan Tidak ada Omset";
                    }
                }

                nomer = nomer + 1;
                ws.Cells[rowx, 1].Value = nomer;
                ws.Cells[rowx, 2].Value = dr1["KodeToko"];
                ws.Cells[rowx, 3].Value = dr1["NamaToko"];
                ws.Cells[rowx, 4].Value = dr1["Alamat"];
                ws.Cells[rowx, 5].Value = dr1["wilayah"];
                ws.Cells[rowx, 6].Value = dr1["WilID"];

                ws.Cells[rowx, 7].Value = dr1["Omset"];
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                
                ws.Cells[rowx, 8].Value = nOmset;           //dr1["Omset"];
                ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 9].Value = string.Format("{0:dd MMMM yyyy}", dr1["Kunjungan"]);
                ws.Cells[rowx,10].Value = cKet;
                rowx++;
            }
            
            rowx++;
            ws.Cells[rowx, 6].Value = "Jumlah";
            ws.Cells[rowx, 7].Value = nJob;
            ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            ws.Cells[rowx, 8].Value = nJon;           //dr1["Omset"];
            ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            ws.Cells[rowx, 1, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[rowx, 1, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            //var border = ws.Cells[5, 1, rowx - 1, MaxCol].Style.Border;
            
            var border = ws.Cells[5, 1, rowx , MaxCol].Style.Border;
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
            ws1.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
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
            int nJoa = 0;
            int nAct = 0;
            int nSlh = 0;

            foreach (DataRow dr1 in dsData.Tables[1].Rows)
            {
                nom = nom + 1;
                ws1.Cells[rowxx, 1].Value = nom;
                ws1.Cells[rowxx, 2].Value = dr1["wilayah"];
      
                int oa =Convert.ToInt32(Tools.isNull(dr1["oa"],0)) ;
                int actual = Convert.ToInt32(Tools.isNull(dr1["actualoa"], 0));
                ws1.Cells[rowxx, 3].Value = oa;
                ws1.Cells[rowxx, 4].Value = actual;
                int total = 0;
                total = oa - actual;
                ws1.Cells[rowxx, 5].Value = total;

                nJoa = nJoa + oa;
                nAct = nAct + actual;
                nSlh = nSlh + total;

                rowxx++;
            }

            rowxx++;
            ws1.Cells[rowxx, 3].Value = nJoa;
            ws1.Cells[rowxx, 4].Value = nAct;
            ws1.Cells[rowxx, 5].Value = nSlh;
            ws1.Cells[rowxx, 1, rowxx, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[rowxx, 1, rowxx, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            var border1 = ws1.Cells[5, 1, rowxx , MaxCol1].Style.Border;
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
            ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
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

        private ExcelPackage ProcessYYK()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "TOKO REGULER";


            #region sheet 1
            ex.Workbook.Worksheets.Add("TOKO REGULER");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 6;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 50;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 70;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 70;
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "TOKO REGULER";
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 1].Value = "NO"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "KODE TOKO"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA TOKO"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "ALAMAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "WILAYAH"; ws.Cells[5, 5, 6, 5].Merge = true;
            //ws.Cells[5, 6].Value = "OMSET"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 6].Value = "KUNJUNGAN"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;
            int nomer = 0;
            foreach (DataRow dr1 in dtYYK.Rows)
            {
                nomer = nomer + 1;
                ws.Cells[rowx, 1].Value = nomer;
                ws.Cells[rowx, 2].Value = dr1["KodeToko"];
                ws.Cells[rowx, 3].Value = dr1["NamaToko"];
                ws.Cells[rowx, 4].Value = dr1["alamat"];
                ws.Cells[rowx, 5].Value = dr1["wilayah"];
                //ws.Cells[rowx, 6].Value = dr1["Omset"];

                //ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 6].Value = "Tidak ada Kunjungan lebih dari 15 hari";
                    //string.Format("{0:dd MMMM yyyy}", dr1["Kunjungan"]);

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
            ex.Workbook.Worksheets.Add("Pengajuan PIN");
            ExcelWorksheet ws1 = ex.Workbook.Worksheets[2];

            // Width
            int MaxCol1 = 3;
            ws1.Cells[1, 1].Worksheet.Column(1).Width = 70;
            ws1.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws1.Cells[1, 3].Worksheet.Column(3).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
            ws1.Cells[1, 1].Value = "PENGAJUAN PIN OA YYK";
            ws1.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws1.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
            ws1.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
            ws1.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws1.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws1.Cells[5, 1].Value = "KETERANGAN"; ws1.Cells[5, 1, 6, 1].Merge = true;
            ws1.Cells[5, 2].Value = "PIN"; ws1.Cells[5, 2, 6, 2].Merge = true;
            ws1.Cells[5, 3].Value = "TANGGAL"; ws1.Cells[5, 3, 6, 3].Merge = true;
          
            ws1.Cells[5, 1, 6, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[5, 1, 6, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            //int rowxx = 4;
            //int nom = 0;
            //foreach (DataRow dr1 in dsDataYYK.Tables[1].Rows)
            //{
                //nom = nom + 1;
                ws1.Cells[7, 1].Value = "Pengajuan Pin karena tidak ada kunjungan ke Toko Reguler lebih dari 15 hari";
                ws1.Cells[7, 3].Value = string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
               // ws1.Cells[1, 2].Value = ;

               // int oa = Convert.ToInt32(Tools.isNull(dr1["oa"], 0));
               // int actual = Convert.ToInt32(Tools.isNull(dr1["actualoa"], 0));
               // ws1.Cells[1, 3].Value = oa;
               // ws1.Cells[1, 4].Value = actual;
                //int total = 0;
                //total = oa - actual;
               // ws1.Cells[1, 5].Value = total;

                //rowxx++;
            //}


            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border1 = ws1.Cells[5, 1, 7, MaxCol1].Style.Border;
            border1.Bottom.Style =
            border1.Top.Style =
            border1.Left.Style =
            border1.Right.Style = ExcelBorderStyle.Thin;

            #endregion

            
            return ex;
        }

        private ExcelPackage ProcessSPV()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Analisa Kunjungan OA 4 bulan SPV";


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
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
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
            foreach (DataRow dr1 in dsDataSPV.Tables[0].Rows)
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

            //#region sheet 2
            //ex.Workbook.Worksheets.Add("Rekap Wilayah");
            //ExcelWorksheet ws1 = ex.Workbook.Worksheets[2];

            //// Width
            //int MaxCol1 = 5;
            //ws1.Cells[1, 1].Worksheet.Column(1).Width = 5;
            //ws1.Cells[1, 2].Worksheet.Column(2).Width = 20;
            //ws1.Cells[1, 3].Worksheet.Column(3).Width = 20;
            //ws1.Cells[1, 4].Worksheet.Column(4).Width = 20;
            //ws1.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ////ws1.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ////ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;



            ////ws.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            //ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
            //ws1.Cells[1, 1].Value = "Laporan     : LAPORAN REKAP WILAYAH";
            //ws1.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //ws1.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
            //ws1.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
            //ws1.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //ws1.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ////ws.Cells[3, 1].Value = "Update      : ";

            ////Header
            //ws1.Cells[5, 1].Value = "NO"; ws1.Cells[5, 1, 6, 1].Merge = true;
            //ws1.Cells[5, 2].Value = "WILAYAH"; ws1.Cells[5, 2, 6, 2].Merge = true;
            //ws1.Cells[5, 3].Value = "OA"; ws1.Cells[5, 3, 6, 3].Merge = true;
            //ws1.Cells[5, 4].Value = "AKTUAL OA"; ws1.Cells[5, 4, 6, 4].Merge = true;
            //ws1.Cells[5, 5].Value = "SELISIH"; ws1.Cells[5, 5, 6, 5].Merge = true;
            ////ws1.Cells[5, 6].Value = "OMSET"; ws1.Cells[5, 6, 6, 6].Merge = true;
            ////ws1.Cells[5, 7].Value = "KUNJUNGAN"; ws1.Cells[5, 7, 6, 7].Merge = true;

            //ws1.Cells[5, 1, 6, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws1.Cells[5, 1, 6, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            //int rowxx = 7;
            //int nom = 0;
            //foreach (DataRow dr1 in dsDataSPV.Tables[1].Rows)
            //{
            //    nom = nom + 1;
            //    ws1.Cells[rowxx, 1].Value = nom;
            //    ws1.Cells[rowxx, 2].Value = dr1["wilayah"];

            //    int oa = Convert.ToInt32(Tools.isNull(dr1["oa"], 0));
            //    int actual = Convert.ToInt32(Tools.isNull(dr1["actualoa"], 0));
            //    ws1.Cells[rowxx, 3].Value = oa;
            //    ws1.Cells[rowxx, 4].Value = actual;
            //    int total = 0;
            //    total = oa - actual;
            //    ws1.Cells[rowxx, 5].Value = total;

            //    rowxx++;
            //}


            //ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            //ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            //var border1 = ws1.Cells[5, 1, rowxx - 1, MaxCol1].Style.Border;
            //border1.Bottom.Style =
            //border1.Top.Style =
            //border1.Left.Style =
            //border1.Right.Style = ExcelBorderStyle.Thin;

            //#endregion

            //#region sheet 3
            //ex.Workbook.Worksheets.Add("Statistik");
            //ExcelWorksheet ws2 = ex.Workbook.Worksheets[3];

            //// Width
            //int MaxCol2 = 3;
            //ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;
            //ws2.Cells[1, 2].Worksheet.Column(2).Width = 50;
            //ws2.Cells[1, 3].Worksheet.Column(3).Width = 20;
            ////ws2.Cells[1, 4].Worksheet.Column(4).Width = 20;
            ////ws2.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ////ws1.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ////ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;



            ////ws.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            //ws2.Cells[1, 1, 1, MaxCol2].Merge = true;
            //ws2.Cells[1, 1].Value = "Laporan     : LAPORAN REKAP WILAYAH";
            //ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //ws2.Cells[2, 1, 2, MaxCol2].Merge = true;
            //ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rangeDateBox1.ToDate);
            //ws2.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //ws2.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ////ws.Cells[3, 1].Value = "Update      : ";

            ////Header
            //ws2.Cells[5, 1].Value = "NO"; ws2.Cells[5, 1, 6, 1].Merge = true;
            //ws2.Cells[5, 2].Value = "KETERANGAN"; ws2.Cells[5, 2, 6, 2].Merge = true;
            //ws2.Cells[7, 2].Value = "OA 4 bulan";
            //ws2.Cells[8, 2].Value = "OA jadi omset";
            //ws2.Cells[9, 2].Value = "OA terkunjungi tidak ada omset";
            //ws2.Cells[10, 2].Value = "OA tidak ada kunjungan tidak ada omset";
            //ws2.Cells[5, 3].Value = "JUMLAH"; ws2.Cells[5, 3, 6, 3].Merge = true;
            ////ws2.Cells[5, 4].Value = "AKTUAL OA"; ws2.Cells[5, 4, 6, 4].Merge = true;
            ////ws2.Cells[5, 5].Value = "SELISIH"; ws2.Cells[5, 5, 6, 5].Merge = true;
            ////ws1.Cells[5, 6].Value = "OMSET"; ws1.Cells[5, 6, 6, 6].Merge = true;
            ////ws1.Cells[5, 7].Value = "KUNJUNGAN"; ws1.Cells[5, 7, 6, 7].Merge = true;

            //ws2.Cells[5, 1, 6, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws2.Cells[5, 1, 6, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            //int rowxxx = 7;
            //int cell = 3;
            //int no = 0;
            //foreach (DataRow dr1 in dsDataSPV.Tables[2].Rows)
            //{
            //    no = no + 1;
            //    //ws2.Cells[rowxxx, 1].Value = no;
            //    ws2.Cells[7, 1].Value = "1";
            //    ws2.Cells[8, 1].Value = "2";
            //    ws2.Cells[9, 1].Value = "3";
            //    ws2.Cells[10, 1].Value = "4";

            //    ws2.Cells[7, cell].Value = dr1["oaall"];
            //    ws2.Cells[8, cell].Value = dr1["JadiOmset"];
            //    ws2.Cells[9, cell].Value = dr1["Kunj"];
            //    ws2.Cells[10, cell].Value = dr1["TdkKunjTdkOms"];


            //}


            //ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            //ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            //var border2 = ws2.Cells[5, 1, 11 - 1, MaxCol2].Style.Border;
            //border2.Bottom.Style =
            //border2.Top.Style =
            //border2.Left.Style =
            //border2.Right.Style = ExcelBorderStyle.Thin;

            //#endregion
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

        private void DisplayReportYYK()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ProcessYYK());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Pengajuan PIN Lap OA YYK " + GlobalVar.Gudang;
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

        private void DisplayReportSPV()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ProcessSPV());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Pengajuan PIN Lap OA SPV " + GlobalVar.Gudang;
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


        private void cmbOK_Click(object sender, EventArgs e)
        {
            CegatanLaporanSPV();
            CegatanLaporanYYK();

            //if (dtYYK.Rows.Count > 0 || dtSPV.Rows.Count > 0)
            if (dtYYK.Rows.Count > 0) //mus rubah
            {
                //this.Cursor = Cursors.WaitCursor;
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("rsp_AnalisaOA4Bulan_YYK"));
                //    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                //    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                //    dsDataYYK = db.Commands[0].ExecuteDataSet();
                //}
               
                    DisplayReportYYK();
                
                

                
                Pin.frmPinDaily ifrmpin = new Pin.frmPinDaily(this,  PinId.Bagian.OAYYK, DateTime.Today, "Pin OA Support/YYK");
                ifrmpin.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmpin);
                ifrmpin.Show();

               
            }
            //else if (dtYYK.Rows.Count == 0 && dtSPV.Rows.Count > 0)
            else if (dtSPV.Rows.Count > 0) //mus rubah
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_AnalisaOA4Bulan_SPV"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dsDataSPV = db.Commands[0].ExecuteDataSet();
                }
                if (dsDataSPV.Tables.Count > 0)
                {
                    DisplayReportSPV();
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                }

                Pin.frmPinDaily ifrmpin = new Pin.frmPinDaily(this, PinId.Bagian.OASPV, DateTime.Today, "Pin OA SPV");
                ifrmpin.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmpin);
                ifrmpin.Show();

            }
            else
            {
                Getdata();
            }
        }

        private void cmbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
