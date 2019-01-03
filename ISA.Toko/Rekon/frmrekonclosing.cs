using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using ISA.Toko.Class;

namespace ISA.Toko.Rekon
{
    public partial class frmrekonclosing : ISA.Toko.BaseForm
    {
        #region Variables
        DataTable dt1 = new DataTable();
        DataTable dtpj2bkm = new DataTable();
        DataTable dtpjvspiut = new DataTable();
        DataTable dtinden = new DataTable();
        DataTable dtpiutreg = new DataTable();
        DataTable dtOVD120 = new DataTable();
        
        
        DataSet dsOverdouFU = new DataSet();
        string FileName1 = "OverdueFU";
        DateTime tglawaltrans;
        //int hari = (int)DateTime.Today.DayOfWeek;
        int hari = (int)DateTime.Now.DayOfWeek;
        


        //bool lmasalah = false;
        #endregion


        #region Generate
        
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PartStation";
            ex.Workbook.Properties.Title = "Rekonsiliasi Harian PJT + Inden";
            int k = 0;
            int rowx = 7;
            double col3 = 0, col7 = 0, col12 = 0;

            #region sheet 2

            
                ex.Workbook.Worksheets.Add("PJT");
                ExcelWorksheet ws2 = ex.Workbook.Worksheets[1];

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 11;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
                for (int y = 3; y <= 19; y++)
                {
                    ws2.Cells[1, y].Worksheet.Column(y).Width = 14;
                }
                ws2.Cells[1, 1, 1, 3].Merge = true;
                ws2.Cells[2, 1, 2, 3].Merge = true;
                ws2.Cells[3, 1, 3, 3].Merge = true;

                // Title
                ws2.Cells[1, 1].Value = "Laporan     : Outstanding Penjualan Tunai ";
                ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);
                ws2.Cells[3, 1].Value = "Update      : " + string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                ws2.Cells[4, 1].Value = "Tgl.Closing : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);

                ////Header
                ws2.Cells[5, 1].Value = "TGL.NOTA"; ws2.Cells[5, 1, 6, 1].Merge = true;
                ws2.Cells[5, 2].Value = "NO.NOTA"; ws2.Cells[5, 2, 6, 2].Merge = true;
                ws2.Cells[5, 3].Value = "KD.SALES"; ws2.Cells[5, 3, 6, 3].Merge = true;
                ws2.Cells[5, 4].Value = "NAMA TOKO "; ws2.Cells[5, 4, 6, 4].Merge = true;
                ws2.Cells[5, 5].Value = "KOTA "; ws2.Cells[5, 5, 6, 5].Merge = true;
                ws2.Cells[5, 6].Value = "PJT (Rp)"; ws2.Cells[5, 6, 6, 6].Merge = true;
                ws2.Cells[5, 7].Value = "TR "; ws2.Cells[5, 7, 6, 7].Merge = true;
                ws2.Cells[5, 8].Value = "PIUTANG (Rp.) "; ws2.Cells[5, 8, 6, 8].Merge = true;
                ws2.Cells[5, 9].Value = "DEPO"; ws2.Cells[5, 9, 6, 9].Merge = true;
                ws2.Cells[5, 10].Value = "TGL.BKM "; ws2.Cells[5, 10, 6, 10].Merge = true;
                ws2.Cells[5, 11].Value = "NO.BKM"; ws2.Cells[5, 11, 6, 11].Merge = true;
                ws2.Cells[5, 12].Value = "BKM (Rp.) "; ws2.Cells[5, 12, 6, 12].Merge = true;
                ws2.Cells[5, 13].Value = "SELISIH (Rp.) "; ws2.Cells[5, 13, 6, 13].Merge = true;
                ws2.Cells[5, 14].Value = "KETERANGAN Outstanding"; ws2.Cells[5, 14, 6, 14].Merge = true;

                ws2.Cells[5, 1, 6, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[5, 1, 6, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                rowx = 7;
                col3 = col7 = col12 = 0;

                int i = 0;
                for (i = 0; i < dtpj2bkm.Rows.Count; i++)
                //foreach (DataRow dr1 in dtpj2bkm.Rows)
                {
                    ws2.Cells[rowx, 1].Value = string.Format("{0:dd-MM-yyyy}", dtpj2bkm.Rows[i]["tglsuratjalan"]);
                    //ws2.Cells[rowx, 1].Value = Convert.ToDateTime(dr1["tglsuratjalan"]).ToShortDateString();
                    ws2.Cells[rowx, 2].Value = dtpj2bkm.Rows[i]["NoSuratJalan"].ToString();
                    ws2.Cells[rowx, 3].Value = dtpj2bkm.Rows[i]["KodeSales"].ToString();
                    ws2.Cells[rowx, 4].Value = dtpj2bkm.Rows[i]["NamaToko"].ToString();
                    ws2.Cells[rowx, 5].Value = dtpj2bkm.Rows[i]["Kota"].ToString();
                    ws2.Cells[rowx, 6].Value = Convert.ToInt32(dtpj2bkm.Rows[i]["RpNet2"]);
                    ws2.Cells[rowx, 7].Value = dtpj2bkm.Rows[i]["TransactionType"].ToString();
                    ws2.Cells[rowx, 8].Value = Convert.ToDouble(Tools.isNull(dtpj2bkm.Rows[i]["jmlkredit"], 0)) - Convert.ToDouble(Tools.isNull(dtpj2bkm.Rows[i]["jmlDebit"], 0));
                    ws2.Cells[rowx, 9].Value = GlobalVar.Gudang;
                    ws2.Cells[rowx, 10].Value = string.Format("{0:dd-MM-yyyy}", dtpj2bkm.Rows[i]["tglbukti"]);
                    ws2.Cells[rowx, 11].Value = dtpj2bkm.Rows[i]["Nobukti"].ToString();
                    ws2.Cells[rowx, 12].Value = Convert.ToDouble(Tools.isNull(dtpj2bkm.Rows[i]["Jumlah"], 0));
                    ws2.Cells[rowx, 13].Value = Convert.ToDouble(Tools.isNull(dtpj2bkm.Rows[i]["RpNet2"], 0)) - Convert.ToDouble(Tools.isNull(dtpj2bkm.Rows[i]["Jumlah"], 0));
                    rowx++;
                }

                var border2 = ws2.Cells[5, 1, rowx, 14].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;
                ws2.Cells[5, 1, 6, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[5, 1, 6, 14].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            
            #endregion

            #region sheet 4

            
                ex.Workbook.Worksheets.Add("INDEN");
                ExcelWorksheet ws4 = ex.Workbook.Worksheets[2];

                ws4.Cells[1, 1].Worksheet.Column(1).Width = 11;
                ws4.Cells[1, 2].Worksheet.Column(2).Width = 15;
                for (int y = 3; y <= 19; y++)
                {
                    ws4.Cells[1, y].Worksheet.Column(y).Width = 14;
                }
                ws4.Cells[1, 1, 1, 3].Merge = true;
                ws4.Cells[2, 1, 2, 3].Merge = true;
                ws4.Cells[3, 1, 3, 3].Merge = true;

                // Title
                ws4.Cells[1, 1].Value = "Laporan     : Penyelesaian Penerimaan Inden ";
                ws4.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);
                ws4.Cells[3, 1].Value = "Update      : " + string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                ws4.Cells[4, 1].Value = "Tgl.Closing : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);

                ////Header
                ws4.Cells[5, 1].Value = "TGL.KASIR"; ws4.Cells[5, 1, 6, 1].Merge = true;
                ws4.Cells[5, 2].Value = "NO.BUKTI"; ws4.Cells[5, 2, 6, 2].Merge = true;
                ws4.Cells[5, 3].Value = "COLECTOR"; ws4.Cells[5, 3, 6, 3].Merge = true;
                ws4.Cells[5, 4].Value = "RP.CASH "; ws4.Cells[5, 4, 6, 4].Merge = true;
                ws4.Cells[5, 5].Value = "RP.GIRO "; ws4.Cells[5, 5, 6, 5].Merge = true;
                ws4.Cells[5, 6].Value = "RP.TRF"; ws4.Cells[5, 6, 6, 6].Merge = true;
                ws4.Cells[5, 7].Value = "NAMA TOKO"; ws4.Cells[5, 7, 6, 7].Merge = true;
                ws4.Cells[5, 8].Value = "KD.TRANS "; ws4.Cells[5, 8, 6, 8].Merge = true;
                ws4.Cells[5, 9].Value = "RP.INDEN"; ws4.Cells[5, 9, 6, 9].Merge = true;
                ws4.Cells[5, 10].Value = "RP.SISA"; ws4.Cells[5, 10, 6, 10].Merge = true;
                ws4.Cells[5, 11].Value = "Keterangan Selisih"; ws4.Cells[5, 11, 6, 11].Merge = true;

                ws4.Cells[5, 1, 6, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws4.Cells[5, 1, 6, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                rowx = 7;
                col3 = col7 = col12 = 0;

                int l = 0;
                for (l = 0; l < dtinden.Rows.Count; l++)


                //foreach (DataRow dr1 in dtinden.Rows)
                {
                    ws4.Cells[rowx, 1].Value = string.Format("{0:dd-MM-yyyy}", dtinden.Rows[l]["tglkasir"]);
                    ws4.Cells[rowx, 2].Value = dtinden.Rows[l]["Nobukti"].ToString();
                    ws4.Cells[rowx, 3].Value = dtinden.Rows[l]["NamaCollector"].ToString();
                    ws4.Cells[rowx, 4].Value = dtinden.Rows[l]["RpCash"];
                    ws4.Cells[rowx, 5].Value = dtinden.Rows[l]["RpGiro"];
                    ws4.Cells[rowx, 6].Value = dtinden.Rows[l]["RpTrf"];
                    ws4.Cells[rowx, 7].Value = dtinden.Rows[l]["NamaToko"].ToString();
                    //ws4.Cells[rowx, 8].Value = dr1[""];
                    //ws4.Cells[rowx, 9].Value = Convert.ToInt32(dr1[""]);
                    //ws4.Cells[rowx, 10].Value = dr1[""].ToString();
                    rowx++;
                }
                var border4 = ws4.Cells[5, 1, rowx, 11].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;
                ws4.Cells[5, 1, 6, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws4.Cells[5, 1, 6, 11].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            
            #endregion


            return ex;
        }


        private ExcelPackage Process2()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PartStation";
            ex.Workbook.Properties.Title = "Rekonsiliasi Harian PJK + PIUT";
            int k = 0;
            int rowx = 7;
            double col3 = 0, col7 = 0, col12 = 0;

            #region sheet 3

            

                ex.Workbook.Worksheets.Add("PJK");
                ExcelWorksheet ws3 = ex.Workbook.Worksheets[1];

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 11;
                ws3.Cells[1, 2].Worksheet.Column(2).Width = 15;
                for (int y = 3; y <= 19; y++)
                {
                    ws3.Cells[1, y].Worksheet.Column(y).Width = 14;
                }
                ws3.Cells[1, 1, 1, 3].Merge = true;
                ws3.Cells[2, 1, 2, 3].Merge = true;
                ws3.Cells[3, 1, 3, 3].Merge = true;

                // Title
                ws3.Cells[1, 1].Value = "Laporan     : Outstanding Penjualan Kredit ";
                ws3.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);
                ws3.Cells[3, 1].Value = "Update      : " + string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                ws3.Cells[4, 1].Value = "Tgl.Closing : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);

                ////Header
                ws3.Cells[5, 1].Value = "TGL.NOTA"; ws3.Cells[5, 1, 6, 1].Merge = true;
                ws3.Cells[5, 2].Value = "NO.NOTA"; ws3.Cells[5, 2, 6, 2].Merge = true;
                ws3.Cells[5, 3].Value = "KD.SALES"; ws3.Cells[5, 3, 6, 3].Merge = true;
                ws3.Cells[5, 4].Value = "NAMA TOKO "; ws3.Cells[5, 4, 6, 4].Merge = true;
                ws3.Cells[5, 5].Value = "ALAMAT "; ws3.Cells[5, 5, 6, 5].Merge = true;
                ws3.Cells[5, 6].Value = "KOTA"; ws3.Cells[5, 6, 6, 6].Merge = true;
                ws3.Cells[5, 7].Value = "Rp.NOTA"; ws3.Cells[5, 7, 6, 7].Merge = true;
                ws3.Cells[5, 8].Value = "Rp.KIRIM "; ws3.Cells[5, 8, 6, 8].Merge = true;
                ws3.Cells[5, 9].Value = "TGL.TRM"; ws3.Cells[5, 9, 6, 9].Merge = true;
                ws3.Cells[5, 10].Value = "Rp.PIUTANG "; ws3.Cells[5, 10, 6, 10].Merge = true;
                ws3.Cells[5, 11].Value = "TR"; ws3.Cells[5, 11, 6, 11].Merge = true;
                ws3.Cells[5, 12].Value = "BARCODE"; ws3.Cells[5, 12, 6, 12].Merge = true;
                ws3.Cells[5, 13].Value = "Rp.SISA "; ws3.Cells[5, 13, 6, 13].Merge = true;
                ws3.Cells[5, 14].Value = "FLAG "; ws3.Cells[5, 14, 6, 14].Merge = true;
                //ws3.Cells[5, 13].Value = "OLDER "; ws3.Cells[5, 13, 6, 13].Merge = true;
                ws3.Cells[5, 15].Value = "KETERANGAN Outstanding"; ws3.Cells[5, 15, 6, 15].Merge = true;

                ws3.Cells[5, 1, 6, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[5, 1, 6, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //int x=0;
                rowx = 7;
                col3 = col7 = col12 = 0;
                //foreach (DataRow dr1 in dtpjvspiut.Rows)                         
                int j = 0;
                for (j = 0; j < dtpjvspiut.Rows.Count; j++)
                {
                    if (dtpjvspiut.Rows[j]["lmasalah"].ToString() == "0")
                    {
                        //x++;
                        //MessageBox.Show(x.ToString());
                        ws3.Cells[rowx, 1].Value = string.Format("{0:dd-MM-yyyy}", dtpjvspiut.Rows[j]["tglsuratjalan"]);
                        ws3.Cells[rowx, 2].Value = dtpjvspiut.Rows[j]["NoSuratJalan"].ToString();
                        ws3.Cells[rowx, 3].Value = dtpjvspiut.Rows[j]["KodeSales"].ToString();
                        ws3.Cells[rowx, 4].Value = dtpjvspiut.Rows[j]["NamaToko"].ToString();
                        ws3.Cells[rowx, 5].Value = dtpjvspiut.Rows[j]["AlamatKirim"].ToString();
                        ws3.Cells[rowx, 6].Value = dtpjvspiut.Rows[j]["Kota"].ToString();
                        ws3.Cells[rowx, 7].Value = Convert.ToInt32(dtpjvspiut.Rows[j]["RpNet2"]);
                        ws3.Cells[rowx, 8].Value = Convert.ToInt32(dtpjvspiut.Rows[j]["RpNet2"]);
                        ws3.Cells[rowx, 9].Value = string.Format("{0:dd-MM-yyyy}", dtpjvspiut.Rows[j]["tglnota"]);
                        ws3.Cells[rowx, 10].Value = Convert.ToInt32(Tools.isNull(dtpjvspiut.Rows[j]["RpNet3"], 0));
                        ws3.Cells[rowx, 11].Value = dtpjvspiut.Rows[j]["TransactionType"].ToString();
                        ws3.Cells[rowx, 12].Value = dtpjvspiut.Rows[j]["barcode"].ToString();
                        ws3.Cells[rowx, 13].Value = Convert.ToInt32(Tools.isNull(dtpjvspiut.Rows[j]["RpSisa"], 0));
                        ws3.Cells[rowx, 14].Value = dtpjvspiut.Rows[j]["lmasalah"].ToString();
                        ws3.Cells[rowx, 15].Value = string.Format("{0:dd-MM-yyyy}", dtpjvspiut.Rows[j]["tglsuratjalan"]);
                        rowx++;
                    }
                }
                var border3 = ws3.Cells[5, 1, rowx, 15].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;
                ws3.Cells[5, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[5, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            
            #endregion

            #region Sheet 5 (Overdue120)

            if (!checkOverdue120())
            {
                ex.Workbook.Worksheets.Add("PIUTANG 120 Hari");
                ExcelWorksheet ws5 = ex.Workbook.Worksheets[2];

                ws5.Cells[1, 1].Worksheet.Column(1).Width = 11;
                ws5.Cells[1, 2].Worksheet.Column(2).Width = 15;
                for (int y = 3; y <= 19; y++)
                {
                    ws5.Cells[1, y].Worksheet.Column(y).Width = 14;
                }
                ws5.Cells[1, 1, 1, 5].Merge = true;
                ws5.Cells[2, 1, 2, 5].Merge = true;
                ws5.Cells[3, 1, 3, 5].Merge = true;

                // Title
                ws5.Cells[1, 1].Value = "Initial         : SAS " + GlobalVar.Gudang;
                ws5.Cells[2, 1].Value = "Laporan     : REKAP UMUR PIUTANG LEBIH DARI 120 HARI  ";
                ws5.Cells[3, 1].Value = "Cut Off       : " + string.Format("{0:dd-MM-yyyy}", tglclosing.DateValue);
                ws5.Cells[4, 1].Value = "Pengolah   : " + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + SecurityManager.UserInitial;

                //

                ws5.Cells[5, 1].Worksheet.Column(1).Width = 16;
                ws5.Cells[5, 2].Worksheet.Column(2).Width = 10;
                ws5.Cells[5, 3].Worksheet.Column(3).Width = 6;
                ws5.Cells[5, 4].Worksheet.Column(4).Width = 6;
                ws5.Cells[5, 5].Worksheet.Column(5).Width = 6;
                ws5.Cells[5, 6].Worksheet.Column(6).Width = 14;
                ws5.Cells[5, 7].Worksheet.Column(7).Width = 10;
                ws5.Cells[5, 8].Worksheet.Column(8).Width = 10;
                ws5.Cells[5, 9].Worksheet.Column(9).Width = 35;
                ws5.Cells[5, 10].Worksheet.Column(10).Width = 15;
                ws5.Cells[5, 11].Worksheet.Column(11).Width = 18;
                ws5.Cells[5, 12].Worksheet.Column(12).Width = 15;
                ws5.Cells[5, 13].Worksheet.Column(13).Width = 15;
                ws5.Cells[5, 14].Worksheet.Column(14).Width = 30;
                ws5.Cells[5, 15].Worksheet.Column(15).Width = 30;
                ws5.Cells[5, 16].Worksheet.Column(16).Width = 45;


                ////Header
                ws5.Cells[5, 1].Value = "TANGGAL TRANS"; ws5.Cells[5, 1, 6, 1].Merge = true;
                ws5.Cells[5, 2].Value = "KD. TR"; ws5.Cells[5, 2, 6, 2].Merge = true;
                ws5.Cells[5, 3].Value = "JKW"; ws5.Cells[5, 3, 6, 3].Merge = true;
                ws5.Cells[5, 4].Value = "JKX"; ws5.Cells[5, 4, 6, 4].Merge = true;
                ws5.Cells[5, 5].Value = "JKS"; ws5.Cells[5, 5, 6, 5].Merge = true;
                ws5.Cells[5, 6].Value = "TGL.JT"; ws5.Cells[5, 6, 6, 6].Merge = true;
                ws5.Cells[5, 7].Value = "NOTA"; ws5.Cells[5, 7, 6, 7].Merge = true;
                ws5.Cells[5, 8].Value = "IDWIL"; ws5.Cells[5, 8, 6, 8].Merge = true;
                ws5.Cells[5, 9].Value = "NAMA TOKO"; ws5.Cells[5, 9, 6, 9].Merge = true;
                ws5.Cells[5, 10].Value = "KD.SALES"; ws5.Cells[5, 10, 6, 10].Merge = true;
                ws5.Cells[5, 11].Value = "USIA TONGOLAN"; ws5.Cells[5, 11, 6, 11].Merge = true;
                ws5.Cells[5, 12].Value = "RP.TAGIHAN"; ws5.Cells[5, 12, 6, 12].Merge = true;
                ws5.Cells[5, 13].Value = "SISA PIUTANG"; ws5.Cells[5, 13, 6, 13].Merge = true;
                ws5.Cells[5, 14].Value = "TGL.JT UMUR PIUTANG 120 HARI"; ws5.Cells[5, 14, 6, 14].Merge = true;
                ws5.Cells[5, 15].Value = "LAMA UMUR PIUTANG 120 HARI"; ws5.Cells[5, 15, 6, 15].Merge = true;
                ws5.Cells[5, 16].Value = "HASIL EVALUASI PIUTANG"; ws5.Cells[5, 16, 6, 16].Merge = true;

                ws5.Cells[5, 1, 6, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws5.Cells[5, 1, 6, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                rowx = 7;
                col3 = col7 = col12 = 0;

                int m = 0;
                for (m = 0; m < dtOVD120.Rows.Count; m++)
                //foreach (DataRow dr1 in dt1.Rows)
                {
                    ws5.Cells[rowx, 1].Value = string.Format("{0:dd-MM-yyyy}", dtOVD120.Rows[m]["TanggalTrans"]);
                    ws5.Cells[rowx, 2].Value = dtOVD120.Rows[m]["KdTrans"].ToString();
                    ws5.Cells[rowx, 3].Value = Convert.ToInt32(Tools.isNull(dtOVD120.Rows[m]["Jkw"], 0));
                    ws5.Cells[rowx, 4].Value = Convert.ToInt32(Tools.isNull(dtOVD120.Rows[m]["Jkx"], 0));
                    ws5.Cells[rowx, 5].Value = Convert.ToInt32(Tools.isNull(dtOVD120.Rows[m]["Jks"], 0));
                    ws5.Cells[rowx, 6].Value = string.Format("{0:dd-MM-yyyy}", dtOVD120.Rows[m]["TglJt"]);
                    ws5.Cells[rowx, 7].Value = dtOVD120.Rows[m]["NoNota"].ToString();
                    ws5.Cells[rowx, 8].Value = dtOVD120.Rows[m]["IdWil"].ToString();
                    ws5.Cells[rowx, 9].Value = dtOVD120.Rows[m]["NamaToko"].ToString();
                    ws5.Cells[rowx, 10].Value = dtOVD120.Rows[m]["KodeSales"].ToString();
                    ws5.Cells[rowx, 11].Value = Convert.ToInt32(Tools.isNull(dtOVD120.Rows[m]["UsiaTongolan"], 0));
                    ws5.Cells[rowx, 12].Value = Convert.ToDouble(Tools.isNull(dtOVD120.Rows[m]["RpTagihan"], 0));
                    ws5.Cells[rowx, 13].Value = Convert.ToDouble(Tools.isNull(dtOVD120.Rows[m]["SisaPiutang"], 0));
                    ws5.Cells[rowx, 14].Value = string.Format("{0:dd-MM-yyyy}", dtOVD120.Rows[m]["TglJt120Hari"]);
                    ws5.Cells[rowx, 15].Value = Convert.ToInt32(Tools.isNull(dtOVD120.Rows[m]["Jt120Hari"], 0));
                    ws5.Cells[rowx, 16].Value = dtOVD120.Rows[m]["EvaluasiPiut"].ToString();
                    rowx++;
                }

                var border5 = ws5.Cells[5, 1, rowx, 16].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;
                ws5.Cells[5, 1, 6, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[5, 1, 6, 16].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            }
            #endregion

            return ex;
        }

        #endregion


        DataTable dtclstrans;

        public frmrekonclosing()
        {
            InitializeComponent();
        }

        private void frmrekonclosing_Load(object sender, EventArgs e)
        {
            
            DataTable dtcektglawal = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_rekon_clstrans_cek"));
                    
                    dtcektglawal = db.Commands[0].ExecuteDataTable();
                    
                }
                if (dtcektglawal.Rows.Count > 0)
                {
                    tglawaltrans = Convert.ToDateTime(dtcektglawal.Rows[0]["tanggal"].ToString()).AddDays(-3);
                    if (tglawaltrans.DayOfWeek == DayOfWeek.Sunday)
                    {
                        tglclsawal.DateValue = tglawaltrans.AddDays(-1);
                    }
                    else
                    {
                        tglclsawal.DateValue = tglawaltrans;
                    }

                }
                else
                {
                    tglclsawal.DateValue = Convert.ToDateTime("2012/01/01");
                }

            tglclsakhir.DateValue = DateTime.Today.AddDays(-3);
            tglclosing.DateValue = DateTime.Today;
                                                                        
            lblPerhatian.Text = "PERHATIAN !!!" + System.Environment.NewLine + System.Environment.NewLine
                 + "1. PASTIKAN semua Transaksi PENJUALAN, ANTAR GUDANG, KASIR SUDAH SELESAI  "
                 + System.Environment.NewLine
                 + "2. PROSES CLOSING REKON sebaiknya dilakukan sore hari setelah transaksi selesai ";
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    DataTable dt = new DataTable();

            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_rekon_clstrans_load"));
            //        db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.Date, tglclsawal.DateValue));
            //        db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
            //        db.Commands[0].Parameters.Add(new Parameter("@tglclosing", SqlDbType.Date, tglclosing.DateValue));
            //        dt = db.Commands[0].ExecuteDataTable();
            //        tglclsawal.DateValue = (DateTime)(dt.Rows[0]["tanggal"]);
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
        }

       

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Save_closing(int lpin, string pin)
        {
            try
            {
                DateTime tglpending = DateTime.Today.AddDays(3);
                
                using (Database db = new Database())
                {                  
                    db.Commands.Add(db.CreateCommand("usp_Rekon_Clstrans_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.Date, tglclosing.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@lkas", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lpiutang", SqlDbType.Bit, 1)); ;
                    db.Commands[0].Parameters.Add(new Parameter("@linden", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lag", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lpb", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lrj", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lsamping", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lpin", SqlDbType.Bit, lpin));
                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, pin));
                    db.Commands[0].Parameters.Add(new Parameter("@lpending", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@tglpending", SqlDbType.Date, tglpending.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@periode1", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@periode2", SqlDbType.Date, tglclsakhir.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                if (lpin == 0)
                {
                    MessageBox.Show("Proses Rekonsiliasi sudah selesai dan Data Closing telah tersimpan");
                    this.DialogResult = DialogResult.OK;
                }
                
                // this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void prosesclosing_Click(object sender, EventArgs e)
        {

            DataTable dtCekRekon = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Rekon_Cek_Now"));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tglclosing.DateValue));
                dtCekRekon = db.Commands[0].ExecuteDataTable();
            }

            if (dtCekRekon.Rows.Count > 0)
            {
                //MessageBox.Show("Sudah melakukan closing rekon untuk tanggal tersebut");
                
                //Pin.frmPin ifrmChild = new Pin.frmPin(this, 0, 1, 10, (Guid)dtCekRekon.Rows[0]["RowID"], DateTime.Today);

                DataTable dtRekonNow = new DataTable();
                using (Database db = new Database())
                {
                db.Commands.Add(db.CreateCommand("usp_Rekon_List_Now"));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
                dtRekonNow = db.Commands[0].ExecuteDataTable();
                }

                if (dtRekonNow.Rows.Count > 0)
                {

                    if (!chekinden() || !chekpjt2bkm())
                    {
                        
                        MessageBox.Show("Masukkan Pin Rekon PJT");
                        Pin.frmPinDaily ifrmChild = new Pin.frmPinDaily(this, (Guid)dtCekRekon.Rows[0]["RowID"], PinId.Bagian.RekonsPJT, DateTime.Today, "Pin rekon PJT ");
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    else
                    {
                        
                            MessageBox.Show("Masukkan Pin Rekon PJK");
                            Pin.frmPinDaily ifrmChild2 = new Pin.frmPinDaily(this, (Guid)dtCekRekon.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon PJK ");
                            ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Sudah Melakukan Closing Rekon");
                    return;
                }

                
            }
            else
            {

                this.Cursor = Cursors.WaitCursor;

                //chekrekonAG();
                chekpjt2bkm();
                chekpjvspiut();
                chekinden();
               // chekregister();
                //chekOverdueFU();
                checkOverdue120();



                //dt1.Rows.Count >= 1 || dtpj2bkm.Rows.Count >= 1 || dtpjvspiut.Rows.Count >= 1 || dtinden.Rows.Count >=1)
                int count = 0;
                if (!chekinden())
                {
                    count = count + 1;
                }

                //if (!chekOverdueFU())
                //{
                //    count = count + 1;
                //}

                if (hari == 1)
                {
                    if (!checkOverdue120())
                    {
                        count = count + 1;
                    }
                }


                if (!chekpjt2bkm())
                {
                    count = count + 1;
                }

                
                if (!chekpjvspiut())
                {
                    count = count + 1;
                }

                //if (!chekregister())
                //{
                //    count = count + 1;
                //}

                //if (!chekrekonAG())
                //{
                //    count = count + 1;
                //}

                if (count > 0)
                {
                    Save_closing(1, "");

                    DisplayReport();
                    DisplayReport2();


                    DataTable dtRekonNow = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekon_List_Now"));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
                        dtRekonNow = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtRekonNow.Rows.Count > 0)
                    {
                        if (!chekinden() || !chekpjt2bkm())
                        {
                            Pin.frmPinDaily ifrmChild = new Pin.frmPinDaily(this, (Guid)dtRekonNow.Rows[0]["RowID"], PinId.Bagian.RekonsPJT, DateTime.Today, "Pin rekon PJT ");
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        else
                        {
                            Pin.frmPinDaily ifrmChild2 = new Pin.frmPinDaily(this, (Guid)dtRekonNow.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon PJK ");
                            ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
                        }

                        ////Pin.frmPin ifrmChild = new Pin.frmPin(this, 0, 1, 10, (Guid)dtRekonNow.Rows[0]["RowID"], DateTime.Today);
                        //Pin.frmPinDaily ifrmChild = new Pin.frmPinDaily(this, (Guid)dtRekonNow.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon harian");

                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        //ifrmChild.Show();
                    }
                    //else
                    //{
                    //    Pin.frmPinDaily ifrmChild = new Pin.frmPinDaily(this, (Guid)dtRekonNow.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon harian PJK");

                    //    ifrmChild.MdiParent = Program.MainForm;
                    //    Program.MainForm.RegisterChild(ifrmChild);
                    //    ifrmChild.Show();

                    //    Pin.frmPinDaily ifrmChild2 = new Pin.frmPinDaily(this, (Guid)dtRekonNow.Rows[0]["RowID"], PinId.Bagian.RekonsPJT, DateTime.Today, "Pin rekon harian2");

                    //    ifrmChild2.MdiParent = Program.MainForm;
                    //    Program.MainForm.RegisterChild(ifrmChild2);
                    //    ifrmChild2.Show();

                    //}

                }
                else
                {

                    Save_closing(0, "");
                }
                this.Cursor = Cursors.Default;

                //if (dsOverdouFU.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Ada toko overdue yang harus di follow up HO. Ambil datanya di c:/Temp/DBFMATCH.DBF lalu kirim ke HO");
                //}
                this.Close();

            }
        }


        private void Upload()
        {
            string Physical1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            
            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }
 

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

           // fields.Add(new Foxpro.DataStruct("RowId", "RowId", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("IDKP", "IDKP", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeToko", "KodeToko", Foxpro.enFoxproTypes.Char,19));
            fields.Add(new Foxpro.DataStruct("KodeSales", "KodeSales", Foxpro.enFoxproTypes.Char, 11));
             fields.Add(new Foxpro.DataStruct("TglTransaksi", "TglTrans", Foxpro.enFoxproTypes.DateTime, 8));
           
            fields.Add(new Foxpro.DataStruct("NoTransaksi", "NoTrans", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("JangkaWaktu", "JkWaktu", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("TglJatuhTempo", "TglJT", Foxpro.enFoxproTypes.DateTime, 8)); 
            fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("RpJual", "RpJual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpKredit", "RpKredit", Foxpro.enFoxproTypes.Numeric , 14));
            fields.Add(new Foxpro.DataStruct("RpSisa", "RpSisa", Foxpro.enFoxproTypes.Numeric , 14));
            fields.Add(new Foxpro.DataStruct("TransactionType", "TrType", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "SyncFlag", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("HariKirim", "HariKirim", Foxpro.enFoxproTypes.Numeric , 3));
            fields.Add(new Foxpro.DataStruct("HariSales" , "HariSales", Foxpro.enFoxproTypes.Numeric , 3 ));
            fields.Add(new Foxpro.DataStruct("subnota", "subnota", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("KeteranganTagih", "KetTagih", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("NamaToko", "NamaToko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("KodeGudang", "KodeGudang", Foxpro.enFoxproTypes.Varchar , 4));
         //   fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "LsUpdBy", Foxpro.enFoxproTypes.Varchar, 50)); 
         //   fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "LsUpdTime", Foxpro.enFoxproTypes.DateTime , 8));
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName1, fields, dsOverdouFU.Tables[0]);

        }

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            

            string fileZipName = GlobalVar.DbfUpload + "\\DBFMATCH.zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1);
          

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }
           
        }

        public bool checkOverdue120()
        {
            bool checkOverdue120 = true;
            try
            {
                if (hari == 1)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_rekons_overdue120"));
                        db.Commands[0].Parameters.Add(new Parameter("@tglclosing", SqlDbType.Date, tglclosing.DateValue));
                        dtOVD120 = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtOVD120.Rows.Count > 0)
                    {
                        checkOverdue120 = false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return checkOverdue120;
        }

        private bool chekOverdueFU() {
            bool chekOFU = true;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Insert_Data_Overdue"));
                     db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                     db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                     db.Commands[0].Parameters.Add(new Parameter("@kdGudang", SqlDbType.VarChar, GlobalVar.CabangID));
                     db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                     dsOverdouFU = db.Commands[0].ExecuteDataSet();
                }
                if (dsOverdouFU.Tables[0].Rows.Count > 0)
                {
                    Upload();
                    ZipFile();
                    
                    chekOFU = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return chekOFU;
        
        
        }


        private bool chekrekonAG()
        {
            bool chekag = true;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_AG"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt1 = db.Commands[0].ExecuteDataTable();
                }
                if (dt1.Rows.Count > 0) 
                {
                    chekag = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return chekag;
        }

        private bool chekpjt2bkm()
        {
            bool chekpj2bkm = true;
            try
            {
                   using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_pj2bkm"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                    dtpj2bkm = db.Commands[0].ExecuteDataTable();

                }
                if (dtpj2bkm.Rows.Count > 0)
                {
                    chekpj2bkm = false;
                }
                               
            }              
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return chekpj2bkm;        
        }

        private bool chekpjvspiut()
        {
            bool chekpjvspiut = true;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_PJKVSPIUT_Prepare"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                    dtpjvspiut = db.Commands[0].ExecuteDataTable();

                }

                if (dtpjvspiut.Rows.Count > 0)
                {

                    chekpjvspiut = false;

                    //int i = 0;
                    //for (i = 0; i < dtpjvspiut.Rows.Count; i++)
                    //{
                    //    string lmasalah = Tools.isNull(dtpjvspiut.Rows[i]["lmasalah"], "").ToString();
                    //    if (string.Compare(lmasalah, "") == 0)
                    //    {
                    //        MessageBox.Show("1");
                    //        //dtpjvspiut.Rows[i]["lmasalah"] = true;                        
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("2");
                    //    }
                    //}
                }                         
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            //return lmasalah;

            return chekpjvspiut;
        }

        private bool chekregister()
        {
            bool chekregister = true;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_Reg"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                    dtpiutreg = db.Commands[0].ExecuteDataTable();

                }

                if (dtpiutreg.Rows.Count > 0)
                {
                    chekregister = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            //return lmasalah;

            return chekregister;
        }


        private bool chekinden()
        {
            bool chekinden = true;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_Inden"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglclsawal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglclsakhir.DateValue));
                    dtinden = db.Commands[0].ExecuteDataTable();
                }
                if (dtinden.Rows.Count >= 1)
                {
                    chekinden = false;              
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return chekinden;
        }

        private void DisplayReport()
        {
            try
            {
                if (!chekinden() || !chekpjt2bkm())
                {
                    List<ExcelPackage> exs = new List<ExcelPackage>();
                    exs.Add(Process1());
                    // exs.Add(Process2());

                    #region Generate File
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "C:\\Temp\\";
                    sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    sf.FileName = "Rekonsiliasi Harian PJT + INDEN";
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
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void DisplayReport2()
        {
            try
            {
                if (!chekpjvspiut() || !checkOverdue120())
                {
                    List<ExcelPackage> exs = new List<ExcelPackage>();
                    //exs.Add(Process1());
                    exs.Add(Process2());

                    #region Generate File
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "C:\\Temp\\";
                    sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    //sf.FileName = "Rekonsiliasi Harian PJT + INDEN";
                    sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

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
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void tglclosing_Validated(object sender, EventArgs e)
        {
            DateTime tglclosingvar;
            tglclosingvar = Convert.ToDateTime(tglclosing.DateValue);
            tglclsakhir.DateValue = Convert.ToDateTime(tglclosingvar.AddDays(-3));
        }

    }
}
    

