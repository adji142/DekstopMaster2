using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmRptSalesmanScoreV2 : Form
    {
        #region Variables
        DataSet dsFBFE = new DataSet();
        DataTable dtFBFE = new DataTable();
        DataTable dtFA = new DataTable();
        DataTable dtFLAIN = new DataTable();
        DataTable dtFBFEDaily = new DataTable();
        DataTable dtSKUTgt = new DataTable();
        DataTable dtSKU = new DataTable();
        DateTime _FromDate;
        DateTime _ToDate;
        string _salesID;
        string _GudangID;
        double nominalMinimumOAR2;

        #endregion

        #region Generate
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Salaesman Score";

            ex.Workbook.Worksheets.Add("FE & FB");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
            //ws.Cells.Style.Font.Name = "Arial";

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 11;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
            for (int y = 3; y <= 19; y++)
            {
                ws.Cells[1, y].Worksheet.Column(y).Width = 14;
            }
            //ws.Cells[1, 26].Worksheet.Column(26).Width = 12;
            //ws.Cells[1, 27].Worksheet.Column(27).Width = 14;
            //ws.Cells[1, 28].Worksheet.Column(28).Width = 12;
            //ws.Cells[1, 29].Worksheet.Column(29).Width = 14;

            ws.Cells[1, 26].Worksheet.Column(26).Width = 18;
            ws.Cells[1, 27].Worksheet.Column(27).Width = 18;

            ws.Cells[1, 1, 1, 3].Merge = true;
            ws.Cells[2, 1, 2, 3].Merge = true;
            ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1].Value = "Laporan     : Salesman Score (Kelp. FB & FE)";
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 1].Value = "KD.SALES"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "SALESMAN"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NOMINAL"; ws.Cells[5, 3, 5, 6].Merge = true;
            ws.Cells[5, 7].Value = "OA"; ws.Cells[5, 7, 5, 11].Merge = true;
            ws.Cells[5, 13].Value = "SKU"; ws.Cells[5, 13, 5, 16].Merge = true;
            ws.Cells[5, 17].Value = "FB2 Nominal"; ws.Cells[5, 17, 6, 17].Merge = true;
            ws.Cells[5, 18].Value = "FB4 Nominal"; ws.Cells[5, 18, 6, 18].Merge = true;
            ws.Cells[5, 19].Value = "FE2 Nominal"; ws.Cells[5, 19, 6, 19].Merge = true;
            ws.Cells[5, 20].Value = "FE4 Nominal"; ws.Cells[5, 20, 6, 20].Merge = true;
            ws.Cells[5, 21].Value = "Score"; ws.Cells[5, 21, 5, 23].Merge = true;
            ws.Cells[6, 21].Value = "Score Omset";
            ws.Cells[6, 22].Value = "Score OA";
            ws.Cells[6, 23].Value = "Score SKU";
            ws.Cells[5, 24].Value = "Total Score"; ws.Cells[5, 24, 6, 24].Merge = true;
            ws.Cells[5, 25].Value = "Status Sales"; ws.Cells[5, 25, 6, 25].Merge = true;
            ws.Cells[5, 26].Value = "Biaya Operasional"; ws.Cells[5, 26, 6, 26].Merge = true;
            ws.Cells[5, 27].Value = "B. Ops vs Omset"; ws.Cells[5, 27, 6, 27].Merge = true;

            //ws.Cells[5, 26].Value = "Toko OB"; ws.Cells[5, 26, 5, 27].Merge = true;
            //ws.Cells[6, 26].Value = "Qty";
            //ws.Cells[6, 27].Value = "Omset Netto";
            //ws.Cells[5, 28].Value = "OA Pasif > 6 Bulan"; ws.Cells[5, 28, 5, 29].Merge = true;
            //ws.Cells[6, 28].Value = "Qty";
            //ws.Cells[6, 29].Value = "Omset Netto";

            ws.Cells[6, 3].Value = "Target";
            ws.Cells[6, 4].Value = "Actual";
            ws.Cells[6, 5].Value = "Selisih";
            ws.Cells[6, 6].Value = "%";
            ws.Cells[6, 7].Value = "Target";
            ws.Cells[6, 8].Value = "Toko Order";
            ws.Cells[6, 9].Value = "Order R2 >= " + nominalMinimumOAR2.ToString();
            ws.Cells[6, 10].Value = "Order R4 >= 2000000 ";
            ws.Cells[6, 11].Value = "Selisih";
            ws.Cells[6, 12].Value = "%";
            ws.Cells[6, 13].Value = "Target";
            ws.Cells[6, 14].Value = "Items";
            ws.Cells[6, 15].Value = "Selisih";
            ws.Cells[6, 16].Value = "%";

            ws.Cells[5, 20, 5, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[6, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[5, 1, 6, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int rowx = 7;
            double col3 = 0, col7 = 0, col12 = 0;
            foreach (DataRow dr1 in dtFBFE.Rows)
            {
                //dtFBFE.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";
                //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                ws.Cells[rowx, 1].Value = dr1["SalesID"].ToString();
                ws.Cells[rowx, 2].Value = dr1["NamaSales"].ToString();
                col3 = col3 + (Convert.ToDouble(dr1["NomFB2"]) +
                               Convert.ToDouble(dr1["NomFB4"]) +
                               Convert.ToDouble(dr1["NomFE2"]) +
                               Convert.ToDouble(dr1["NomFE4"]));
                ws.Cells[rowx, 3].Value = Convert.ToDouble(dr1["NomFB2"]) +
                                          Convert.ToDouble(dr1["NomFB4"]) +
                                          Convert.ToDouble(dr1["NomFE2"]) +
                                          Convert.ToDouble(dr1["NomFE4"]);
                ws.Cells[rowx, 4].Formula = "(" + ws.Cells[rowx, 17].Address + "+" + ws.Cells[rowx, 18].Address +
                                            "+" + ws.Cells[rowx, 19].Address + "+" + ws.Cells[rowx, 20].Address + ")";
                ws.Cells[rowx, 5].Formula = "(" + ws.Cells[rowx, 4].Address + "-" + ws.Cells[rowx, 3].Address + ")";
                if (Convert.ToDouble(dr1["NomFB2"]) +
                    Convert.ToDouble(dr1["NomFB4"]) +
                    Convert.ToDouble(dr1["NomFE2"]) +
                    Convert.ToDouble(dr1["NomFE4"]) > 0)
                {
                    ws.Cells[rowx, 6].Formula = "(" + ws.Cells[rowx, 4].Address + "/" + ws.Cells[rowx, 3].Address + "*100)";
                }
                else
                {
                    ws.Cells[rowx, 6].Formula = "(" + ws.Cells[rowx, 3].Address + "*0)";
                }
                col7 = col7 + Convert.ToInt32(dr1["OrderAktif"]);
                ws.Cells[rowx, 7].Value = Convert.ToInt32(dr1["OrderAktif"]);
                ws.Cells[rowx, 8].Value = Convert.ToInt32(dr1["TotalToko"]);
                ws.Cells[rowx, 9].Value = Convert.ToInt32(dr1["TotalTokoR2Juta"]);
                ws.Cells[rowx, 10].Value = Convert.ToInt32(dr1["TotalTokoJuta"]);
                ws.Cells[rowx, 11].Formula = "(" + ws.Cells[rowx, 9].Address + "+" + ws.Cells[rowx, 10].Address + "-" + ws.Cells[rowx, 7].Address + ")";
                if (Convert.ToInt32(dr1["OrderAktif"]) > 0)
                {
                    ws.Cells[rowx, 12].Formula = "((" + ws.Cells[rowx, 9].Address + "+" + ws.Cells[rowx, 10].Address + ") /" + ws.Cells[rowx, 7].Address + "*100)";
                }
                else
                {
                    ws.Cells[rowx, 12].Formula = "(" + ws.Cells[rowx, 7].Address + "*0)";
                }
                col12 = col12 + Convert.ToInt32(dr1["SKUR2"]) +
                                Convert.ToInt32(dr1["SKUR4"]);
                ws.Cells[rowx, 13].Value = Convert.ToInt32(dr1["SKUR2"]) +
                                           Convert.ToInt32(dr1["SKUR4"]);
                ws.Cells[rowx, 14].Value = Convert.ToInt32(dr1["TotalItem"]);
                ws.Cells[rowx, 15].Formula = "(" + ws.Cells[rowx, 14].Address + "-" + ws.Cells[rowx, 13].Address + ")";

                if (Convert.ToInt32(dr1["SKUR2"]) +
                    Convert.ToInt32(dr1["SKUR4"]) > 0)
                {
                    ws.Cells[rowx, 16].Formula = "(" + ws.Cells[rowx, 14].Address + "/" + ws.Cells[rowx, 13].Address + "*100)";

                }
                else
                {
                    ws.Cells[rowx, 16].Formula = "(" + ws.Cells[rowx, 13].Address + "*0)";
                }

                ws.Cells[rowx, 17].Value = Convert.ToDouble(dr1["NettoFB2"]);
                ws.Cells[rowx, 18].Value = Convert.ToDouble(dr1["NettoFB4"]);
                ws.Cells[rowx, 19].Value = Convert.ToDouble(dr1["NettoFE2"]);
                ws.Cells[rowx, 20].Value = Convert.ToDouble(dr1["NettoFE4"]);

                ws.Cells[rowx, 21].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 12].Address + "<80," + ws.Cells[rowx, 16].Address + "<80),MIN(50," + ws.Cells[rowx, 6].Address + "*0.5)," + ws.Cells[rowx, 6].Address + "*0.5)";
                ws.Cells[rowx, 22].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 12].Address + "<80," + ws.Cells[rowx, 16].Address + "<80),MIN(25," + ws.Cells[rowx, 12].Address + "*0.25)," + ws.Cells[rowx, 12].Address + "*0.25)";
                ws.Cells[rowx, 23].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 12].Address + "<80," + ws.Cells[rowx, 16].Address + "<80),MIN(25," + ws.Cells[rowx, 16].Address + "*0.25)," + ws.Cells[rowx, 16].Address + "*0.25)";


                ws.Cells[rowx, 24].Formula = "(" + ws.Cells[rowx, 21].Address + "+" + ws.Cells[rowx, 22].Address + "+" + ws.Cells[rowx, 23].Address + ")";
                ws.Cells[rowx, 25].Value = dr1["AktifKeluarSales"].ToString();
                //ws.Cells[rowx, 26].Value = Convert.ToDouble(dr1["BiayaOps"]);
                ws.Cells[rowx, 26].Value = Convert.ToDouble(0);
                if (double.Parse(Tools.isNull(ws.Cells[rowx, 4].Value, "0").ToString()) != 0)
                    ws.Cells[rowx, 27].Formula = "(" + ws.Cells[rowx, 4].Address + "/" + ws.Cells[rowx, 26].Address + ")";


                //ws.Cells[rowx, 26].Value = Convert.ToInt32 (dr1["QtyOB"]);
                //ws.Cells[rowx, 27].Value = Convert.ToDouble (dr1["OmsetOB"]);
                //ws.Cells[rowx, 28].Value = Convert.ToInt32 (dr1["QtyOA"]);
                //ws.Cells[rowx, 29].Value = Convert.ToDouble (dr1["OmsetOA"]);

                ws.Cells[rowx, 21].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 22].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 23].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 24].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 26].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[rowx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                //ws.Cells[rowx, 28].Style.Numberformat.Format = "#,##0;(#,##0);0";
                //ws.Cells[rowx, 29].Style.Numberformat.Format = "#,##0;(#,##0);0";


                for (int z = 3; z <= 20; z += 1)
                {
                    ws.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                }
                ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 12].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 16].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }
            ws.Cells[rowx, 1].Value = "T O T A L"; ws.Cells[rowx, 1, rowx, 2].Merge = true;
            for (int z = 3; z <= 20; z += 1)
            {
                ws.Cells[rowx, z].Formula = "SUM(" + ws.Cells[7, z].Address + ":" + ws.Cells[rowx - 1, z].Address + ")";
                ws.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[rowx, 3].Value = col3; ws.Cells[rowx, 7].Value = col7; ws.Cells[rowx, 13].Value = col12;
            }

            for (int z = 26; z <= 25; z += 1)
            {
                ws.Cells[rowx, z].Formula = "SUM(" + ws.Cells[7, z].Address + ":" + ws.Cells[rowx - 1, z].Address + ")";
                ws.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[rowx, 3].Value = col3; ws.Cells[rowx, 7].Value = col7; ws.Cells[rowx, 13].Value = col12;
            }

            if (Convert.ToDouble(ws.Cells[rowx, 3].Value) > 0)
            {
                ws.Cells[rowx, 6].Formula = "(" + ws.Cells[rowx, 4].Address + "/" + ws.Cells[rowx, 3].Address + "*100)";
            }
            else
            {
                ws.Cells[rowx, 6].Formula = "(" + ws.Cells[rowx, 3].Address + "*0)";
            }
            ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            if (Convert.ToDouble(ws.Cells[rowx, 7].Value) > 0)
            {
                ws.Cells[rowx, 12].Formula = "(" + ws.Cells[rowx, 8].Address + "/" + ws.Cells[rowx, 7].Address + "*100)";
            }
            else
            {
                ws.Cells[rowx, 12].Formula = "(" + ws.Cells[rowx, 7].Address + "*0)";
            }
            ws.Cells[rowx, 12].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            if (Convert.ToDouble(ws.Cells[rowx, 13].Value) > 0)
            {
                ws.Cells[rowx, 16].Formula = "(" + ws.Cells[rowx, 14].Address + "/" + ws.Cells[rowx, 13].Address + "*100)";
            }
            else
            {
                ws.Cells[rowx, 16].Formula = "(" + ws.Cells[rowx, 13].Address + "*0)";
            }
            ws.Cells[rowx, 16].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            var border3 = ws.Cells[5, 1, rowx, 27].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[5, 1, 6, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 6, 27].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);


            #region sheet 2

            //ex.Workbook.Worksheets.Add("FA");
            //ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            //// Width
            //ws2.Cells[1, 1].Worksheet.Column(1).Width = 11;
            //ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
            //for (int y = 3; y <= 15; y++)
            //{
            //    ws2.Cells[1, y].Worksheet.Column(y).Width = 14;
            //}
            //ws2.Cells[1, 1, 1, 3].Merge = true;
            //ws2.Cells[2, 1, 2, 3].Merge = true;
            //ws2.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            //ws2.Cells[1, 1].Value = "Laporan     : Salesman Score (Kelp. FA)";
            //ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth);
            //ws2.Cells[3, 1].Value = "Update      : ";

            ////Header
            //ws2.Cells[5, 1].Value = "KD.SALES"; ws2.Cells[5, 1, 6, 1].Merge = true;
            //ws2.Cells[5, 2].Value = "SALESMAN"; ws2.Cells[5, 2, 6, 2].Merge = true;
            //ws2.Cells[5, 3].Value = "NOMINAL"; ws2.Cells[5, 3, 5, 6].Merge = true;
            //ws2.Cells[5, 7].Value = "OA"; ws2.Cells[5, 7, 5, 11].Merge = true;
            //ws2.Cells[5, 12].Value = "SKU"; ws2.Cells[5, 12, 5, 15].Merge = true;

            //ws2.Cells[6, 3].Value = "Target";
            //ws2.Cells[6, 4].Value = "Actual";
            //ws2.Cells[6, 5].Value = "Selisih";
            //ws2.Cells[6, 6].Value = "%";
            //ws2.Cells[6, 7].Value = "Target";
            //ws2.Cells[6, 8].Value = "Toko Order";
            //ws2.Cells[6, 9].Value = "Order >= 1 Juta";
            //ws2.Cells[6, 10].Value = "Selisih";
            //ws2.Cells[6, 11].Value = "%";
            //ws2.Cells[6, 12].Value = "Target";
            //ws2.Cells[6, 13].Value = "Items";
            //ws2.Cells[6, 14].Value = "Selisih";
            //ws2.Cells[6, 15].Value = "%";
            //ws2.Cells[5, 1, 6, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws2.Cells[5, 1, 6, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //rowx = 7;
            //col3 = col7 = col12 = 0;
            //foreach (DataRow dr1 in dtFA.Rows)
            //{
            //    //dtFBFE.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";
            //    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
            //    ws2.Cells[rowx, 1].Value = dr1["SalesID"].ToString();
            //    ws2.Cells[rowx, 2].Value = dr1["NamaSales"].ToString();
            //    col3 = col3 + Convert.ToDouble(dr1["NomFA"]);
            //    ws2.Cells[rowx, 3].Value = Convert.ToDouble(dr1["NomFA"]) ;
            //    ws2.Cells[rowx, 4].Value = Convert.ToDouble(dr1["NettoFA"]);
            //    ws2.Cells[rowx, 5].Formula = "(" + ws2.Cells[rowx, 4].Address + "-" + ws2.Cells[rowx, 3].Address + ")";
            //    if (Convert.ToDouble(dr1["NomFA"]) > 0)
            //    {
            //        ws2.Cells[rowx, 6].Formula = "(" + ws2.Cells[rowx, 4].Address + "/" + ws2.Cells[rowx, 3].Address + "*100)";
            //    }
            //    else
            //    {
            //        ws2.Cells[rowx, 6].Formula = "(" + ws2.Cells[rowx, 3].Address + "*0)";
            //    }
            //    col7 = col7 + Convert.ToInt32(dr1["OrderAktif"]);
            //    ws2.Cells[rowx, 7].Value = Convert.ToInt32(dr1["OrderAktif"]);
            //    ws2.Cells[rowx, 8].Value = Convert.ToInt32(dr1["TotalToko"]);
            //    ws2.Cells[rowx, 9].Value = Convert.ToInt32(dr1["TotalTokoJuta"]);
            //    ws2.Cells[rowx, 10].Formula = "(" + ws2.Cells[rowx, 8].Address + "-" + ws2.Cells[rowx, 7].Address + ")";
            //    if (Convert.ToInt32(dr1["OrderAktif"]) > 0)
            //    {
            //        ws2.Cells[rowx, 11].Formula = "(" + ws2.Cells[rowx, 8].Address + "/" + ws2.Cells[rowx, 7].Address + "*100)";
            //    }
            //    else
            //    {
            //        ws2.Cells[rowx, 11].Formula = "(" + ws2.Cells[rowx, 7].Address + "*0)";
            //    }

            //    col12 = col12 + Convert.ToInt32(dr1["SKUR2"]) +
            //                    Convert.ToInt32(dr1["SKUR4"]);
            //    ws2.Cells[rowx, 12].Value = Convert.ToInt32(dr1["SKUR2"]) +
            //                                Convert.ToInt32(dr1["SKUR4"]);
            //    ws2.Cells[rowx, 13].Value = Convert.ToInt32(dr1["TotalItem"]);
            //    ws2.Cells[rowx, 14].Formula = "(" + ws2.Cells[rowx, 13].Address + "-" + ws2.Cells[rowx, 12].Address + ")";

            //    if (Convert.ToInt32(dr1["SKUR2"]) +
            //        Convert.ToInt32(dr1["SKUR4"]) > 0)
            //    {
            //        ws2.Cells[rowx, 15].Formula = "(" + ws2.Cells[rowx, 13].Address + "/" + ws2.Cells[rowx, 12].Address + "*100)";

            //    }
            //    else
            //    {
            //        ws2.Cells[rowx, 15].Formula = "(" + ws2.Cells[rowx, 12].Address + "*0)";
            //    }


            //    for (int z = 3; z <= 15; z += 1)
            //    {
            //        ws2.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
            //    }
            //    ws2.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    ws2.Cells[rowx, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    ws2.Cells[rowx, 15].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    rowx++;
            //}
            //ws2.Cells[rowx, 1].Value = "T O T A L"; ws2.Cells[rowx, 1, rowx, 2].Merge = true;
            //for (int z = 3; z <= 15; z += 1)
            //{
            //    ws2.Cells[rowx, z].Formula = "SUM(" + ws2.Cells[7, z].Address + ":" + ws2.Cells[rowx - 1, z].Address + ")";
            //    ws2.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
            //    ws2.Cells[rowx, 3].Value = col3; ws2.Cells[rowx, 7].Value = col7; ws2.Cells[rowx, 12].Value = col12;
            //}
            //if (Convert.ToDouble(ws2.Cells[rowx, 3].Value) > 0)
            //{
            //    ws2.Cells[rowx, 6].Formula = "(" + ws2.Cells[rowx, 4].Address + "/" + ws2.Cells[rowx, 3].Address + "*100)";
            //}
            //else
            //{
            //    ws2.Cells[rowx, 6].Formula = "(" + ws2.Cells[rowx, 3].Address + "*0)";
            //}
            //ws2.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //if (Convert.ToDouble(ws2.Cells[rowx, 7].Value) > 0)
            //{
            //    ws2.Cells[rowx, 11].Formula = "(" + ws2.Cells[rowx, 8].Address + "/" + ws2.Cells[rowx, 7].Address + "*100)";
            //}
            //else
            //{
            //    ws2.Cells[rowx, 11].Formula = "(" + ws2.Cells[rowx, 7].Address + "*0)";
            //}
            //ws2.Cells[rowx, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //if (Convert.ToDouble(ws2.Cells[rowx, 12].Value) > 0)
            //{
            //    ws2.Cells[rowx, 15].Formula = "(" + ws2.Cells[rowx, 13].Address + "/" + ws2.Cells[rowx, 12].Address + "*100)";
            //}
            //else
            //{
            //    ws2.Cells[rowx, 15].Formula = "(" + ws2.Cells[rowx, 12].Address + "*0)";
            //}
            //ws2.Cells[rowx, 15].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //var border4 = ws2.Cells[5, 1, rowx, 15].Style.Border;
            //border4.Bottom.Style =
            //border4.Top.Style =
            //border4.Left.Style =
            //border4.Right.Style = ExcelBorderStyle.Thin;
            //ws2.Cells[5, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws2.Cells[5, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);


            //ex.Workbook.Worksheets.Add("FA");
            //ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            //// Width
            //ws2.Cells[1, 1].Worksheet.Column(1).Width = 11;
            //ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
            //for (int y = 3; y <= 15; y++)
            //{
            //    ws2.Cells[1, y].Worksheet.Column(y).Width = 14;
            //}
            //ws2.Cells[1, 1, 1, 3].Merge = true;
            //ws2.Cells[2, 1, 2, 3].Merge = true;
            //ws2.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            //ws2.Cells[1, 1].Value = "Laporan     : Salesman Score (Kelp. FA)";
            //ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth);
            //ws2.Cells[3, 1].Value = "Update      : ";

            ////Header
            //ws2.Cells[5, 1].Value = "KD.SALES"; ws2.Cells[5, 1, 6, 1].Merge = true;
            //ws2.Cells[5, 2].Value = "SALESMAN"; ws2.Cells[5, 2, 6, 2].Merge = true;
            //ws2.Cells[5, 3].Value = "NOMINAL"; ws2.Cells[5, 3, 5, 6].Merge = true;
            //ws2.Cells[5, 7].Value = "OA"; ws2.Cells[5, 7, 5, 11].Merge = true;
            //ws2.Cells[5, 12].Value = "SKU"; ws2.Cells[5, 12, 5, 15].Merge = true;

            //ws2.Cells[6, 3].Value = "Target";
            //ws2.Cells[6, 4].Value = "Actual";
            //ws2.Cells[6, 5].Value = "Selisih";
            //ws2.Cells[6, 6].Value = "%";
            //ws2.Cells[6, 7].Value = "Target";
            //ws2.Cells[6, 8].Value = "Toko Order";
            //ws2.Cells[6, 9].Value = "Order >= 1 Juta";
            //ws2.Cells[6, 10].Value = "Selisih";
            //ws2.Cells[6, 11].Value = "%";
            //ws2.Cells[6, 12].Value = "Target";
            //ws2.Cells[6, 13].Value = "Items";
            //ws2.Cells[6, 14].Value = "Selisih";
            //ws2.Cells[6, 15].Value = "%";
            //ws2.Cells[5, 1, 6, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws2.Cells[5, 1, 6, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;





            ex.Workbook.Worksheets.Add("OA R4 > 2jt");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            //// Width
            ws2.Cells[1, 1].Worksheet.Column(1).Width = 11;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
            for (int y = 3; y <= 15; y++)
            {
                ws2.Cells[1, y].Worksheet.Column(y).Width = 14;
            }
            ws2.Cells[1, 1, 1, 3].Merge = true;
            ws2.Cells[2, 1, 2, 3].Merge = true;
            ws2.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws2.Cells[1, 1].Value = "Laporan     : OA R4 > 2jt";
            ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws2.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws2.Cells[5, 1].Value = "KD.SALES";
            ws2.Cells[5, 2].Value = "SALESMAN";
            ws2.Cells[5, 3].Value = "KODE TOKO";
            ws2.Cells[5, 4].Value = "NAMA TOKO";
            ws2.Cells[5, 5].Value = "Rp NOTA";

            ws2.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dtFLAIN.Rows)
            {
                if (dr1["SALESID"].ToString() == "") { MessageBox.Show("kosong" + dr1["KODETOKOR4"].ToString()); }
                ws2.Cells[rowx, 1].Value = dr1["SALESID"];
                ws2.Cells[rowx, 2].Value = dr1["NAMASALES"];
                ws2.Cells[rowx, 3].Value = dr1["KODETOKOR4"];
                ws2.Cells[rowx, 4].Value = dr1["NAMATOKO"];
                ws2.Cells[rowx, 5].Value = dr1["RpNota"];
                ws2.Cells[rowx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }

            var border4 = ws.Cells[5, 1, rowx, 4].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            ws2.Cells[5, 1, 5, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[5, 1, 5, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            #endregion


            #region sheet 3

            //ex.Workbook.Worksheets.Add("FLAIN");
            //ExcelWorksheet ws3 = ex.Workbook.Worksheets[3];

            //// Width
            //ws3.Cells[1, 1].Worksheet.Column(1).Width = 11;
            //ws3.Cells[1, 2].Worksheet.Column(2).Width = 15;
            //for (int y = 3; y <= 15; y++)
            //{
            //    ws3.Cells[1, y].Worksheet.Column(y).Width = 14;
            //}
            //ws3.Cells[1, 1, 1, 3].Merge = true;
            //ws3.Cells[2, 1, 2, 3].Merge = true;
            //ws3.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            //ws3.Cells[1, 1].Value = "Laporan     : Salesman Score (Kelp. LAIN)";
            //ws3.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth);
            //ws3.Cells[3, 1].Value = "Update      : ";

            ////Header
            //ws3.Cells[5, 1].Value = "KD.SALES"; ws3.Cells[5, 1, 6, 1].Merge = true;
            //ws3.Cells[5, 2].Value = "SALESMAN"; ws3.Cells[5, 2, 6, 2].Merge = true;
            //ws3.Cells[5, 3].Value = "NOMINAL"; ws3.Cells[5, 3, 5, 6].Merge = true;
            //ws3.Cells[5, 7].Value = "OA"; ws3.Cells[5, 7, 5, 11].Merge = true;
            //ws3.Cells[5, 12].Value = "SKU"; ws3.Cells[5, 12, 5, 15].Merge = true;

            //ws3.Cells[6, 3].Value = "Target";
            //ws3.Cells[6, 4].Value = "Actual";
            //ws3.Cells[6, 5].Value = "Selisih";
            //ws3.Cells[6, 6].Value = "%";
            //ws3.Cells[6, 7].Value = "Target";
            //ws3.Cells[6, 8].Value = "Toko Order";
            //ws3.Cells[6, 9].Value = "Order >= 1 Juta";
            //ws3.Cells[6, 10].Value = "Selisih";
            //ws3.Cells[6, 11].Value = "%";
            //ws3.Cells[6, 12].Value = "Target";
            //ws3.Cells[6, 13].Value = "Items";
            //ws3.Cells[6, 14].Value = "Selisih";
            //ws3.Cells[6, 15].Value = "%";
            //ws3.Cells[5, 1, 6, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws3.Cells[5, 1, 6, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //rowx = 7;
            //col3 = col7 = col12 = 0;
            //foreach (DataRow dr1 in dtFLAIN.Rows)
            //{
            //    //dtFBFE.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";
            //    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
            //    ws3.Cells[rowx, 1].Value = dr1["SalesID"].ToString();
            //    ws3.Cells[rowx, 2].Value = dr1["NamaSales"].ToString();
            //    col3 = col3 + Convert.ToDouble(dr1["NomFLAIN"]);
            //    ws3.Cells[rowx, 3].Value = Convert.ToDouble(dr1["NomFLAIN"]);
            //    ws3.Cells[rowx, 4].Value = Convert.ToDouble(dr1["NettoFLAIN"]);
            //    ws3.Cells[rowx, 5].Formula = "(" + ws3.Cells[rowx, 4].Address + "-" + ws3.Cells[rowx, 3].Address + ")";
            //    if (Convert.ToDouble(dr1["NomFLAIN"]) > 0)
            //    {
            //        ws3.Cells[rowx, 6].Formula = "(" + ws3.Cells[rowx, 4].Address + "/" + ws3.Cells[rowx, 3].Address + "*100)";
            //    }
            //    else
            //    {
            //        ws3.Cells[rowx, 6].Formula = "(" + ws3.Cells[rowx, 3].Address + "*0)";
            //    }

            //    col7 = col7 + Convert.ToDouble(dr1["OrderAktif"]);
            //    ws3.Cells[rowx, 7].Value = Convert.ToInt32(dr1["OrderAktif"]);
            //    ws3.Cells[rowx, 8].Value = Convert.ToInt32(dr1["TotalToko"]);
            //    ws3.Cells[rowx, 9].Value = Convert.ToInt32(dr1["TotalTokoJuta"]);
            //    ws3.Cells[rowx, 10].Formula = "(" + ws3.Cells[rowx, 8].Address + "-" + ws3.Cells[rowx, 7].Address + ")";
            //    if (Convert.ToInt32(dr1["OrderAktif"]) > 0)
            //    {
            //        ws3.Cells[rowx, 11].Formula = "(" + ws3.Cells[rowx, 8].Address + "/" + ws3.Cells[rowx, 7].Address + "*100)";
            //    }
            //    else
            //    {
            //        ws3.Cells[rowx, 11].Formula = "(" + ws3.Cells[rowx, 7].Address + "*0)";
            //    }
            //    col12 = col12 + Convert.ToInt32(dr1["SKUR2"]) +
            //                    Convert.ToInt32(dr1["SKUR4"]);
            //    ws3.Cells[rowx, 12].Value = Convert.ToInt32(dr1["SKUR2"]) +
            //                                Convert.ToInt32(dr1["SKUR4"]);
            //    ws3.Cells[rowx, 13].Value = Convert.ToInt32(dr1["TotalItem"]);
            //    ws3.Cells[rowx, 14].Formula = "(" + ws3.Cells[rowx, 13].Address + "-" + ws3.Cells[rowx, 12].Address + ")";

            //    if (Convert.ToInt32(dr1["SKUR2"]) +
            //        Convert.ToInt32(dr1["SKUR4"]) > 0)
            //    {
            //        ws3.Cells[rowx, 15].Formula = "(" + ws3.Cells[rowx, 13].Address + "/" + ws3.Cells[rowx, 12].Address + "*100)";

            //    }
            //    else
            //    {
            //        ws3.Cells[rowx, 15].Formula = "(" + ws3.Cells[rowx, 12].Address + "*0)";
            //    }


            //    for (int z = 3; z <= 15; z += 1)
            //    {
            //        ws3.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
            //    }
            //    ws3.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    ws3.Cells[rowx, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    ws3.Cells[rowx, 15].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            //    rowx++;
            //}
            //ws3.Cells[rowx, 1].Value = "T O T A L"; ws3.Cells[rowx, 1, rowx, 2].Merge = true;
            //for (int z = 3; z <= 15; z += 1)
            //{
            //    ws3.Cells[rowx, z].Formula = "SUM(" + ws3.Cells[7, z].Address + ":" +ws3.Cells[rowx-1, z].Address + ")";
            //    ws3.Cells[rowx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
            //    ws3.Cells[rowx, 3].Value = col3; ws3.Cells[rowx, 7].Value = col7; ws3.Cells[rowx, 12].Value = col12;
            //}
            //if (Convert.ToDouble(ws.Cells[rowx, 3].Value) > 0)
            //{
            //    ws3.Cells[rowx, 6].Formula = "(" + ws3.Cells[rowx, 4].Address + "/" + ws3.Cells[rowx, 3].Address + "*100)";
            //}
            //else
            //{
            //    ws3.Cells[rowx, 6].Formula = "(" + ws3.Cells[rowx, 3].Address + "*0)";
            //}
            //ws3.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //if (Convert.ToDouble(ws3.Cells[rowx, 7].Value) > 0)
            //{
            //    ws3.Cells[rowx, 11].Formula = "(" + ws3.Cells[rowx, 8].Address + "/" + ws3.Cells[rowx, 7].Address + "*100)";
            //}
            //else
            //{
            //    ws3.Cells[rowx, 11].Formula = "(" + ws3.Cells[rowx, 7].Address + "*0)";
            //}
            //ws3.Cells[rowx, 11].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //if (Convert.ToDouble(ws3.Cells[rowx, 12].Value) > 0)
            //{
            //    ws3.Cells[rowx, 15].Formula = "(" + ws3.Cells[rowx, 13].Address + "/" + ws3.Cells[rowx, 12].Address + "*100)";
            //}
            //else
            //{
            //    ws3.Cells[rowx, 15].Formula = "(" + ws3.Cells[rowx, 12].Address + "*0)";
            //}
            //ws3.Cells[rowx, 15].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            //var border5 = ws3.Cells[5, 1, rowx, 15].Style.Border;
            //border5.Bottom.Style =
            //border5.Top.Style =
            //border5.Left.Style =
            //border5.Right.Style = ExcelBorderStyle.Thin;
            //ws3.Cells[5, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws3.Cells[5, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);


            ex.Workbook.Worksheets.Add("OA R2 > " + nominalMinimumOAR2.ToString());
            ExcelWorksheet ws3 = ex.Workbook.Worksheets[3];

            //// Width
            ws3.Cells[1, 1].Worksheet.Column(1).Width = 11;
            ws3.Cells[1, 2].Worksheet.Column(2).Width = 15;
            for (int y = 3; y <= 15; y++)
            {
                ws3.Cells[1, y].Worksheet.Column(y).Width = 14;
            }
            ws3.Cells[1, 1, 1, 3].Merge = true;
            ws3.Cells[2, 1, 2, 3].Merge = true;
            ws3.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws3.Cells[1, 1].Value = "Laporan     : OA R2 > " + nominalMinimumOAR2.ToString();
            ws3.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", dtbEnd.DateValue.Value);
            ws3.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws3.Cells[5, 1].Value = "KD.SALES";
            ws3.Cells[5, 2].Value = "SALESMAN";
            ws2.Cells[5, 3].Value = "KODE TOKO";
            ws3.Cells[5, 4].Value = "NAMA TOKO";
            ws3.Cells[5, 5].Value = "Rp NOTA";

            ws3.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws3.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dtFA.Rows)
            {
                ws3.Cells[rowx, 1].Value = dr1["salesid"];
                ws3.Cells[rowx, 2].Value = dr1["NAMASALES"];
                ws3.Cells[rowx, 3].Value = dr1["KODETOKOR4"];
                ws3.Cells[rowx, 4].Value = dr1["NAMATOKO"];
                ws3.Cells[rowx, 5].Value = dr1["RpNota"];
                ws3.Cells[rowx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }


            #endregion


            #region sheet 4


            ex.Workbook.Worksheets.Add("Toko OB");
            ExcelWorksheet ws4 = ex.Workbook.Worksheets[4];

            //// Width
            ws4.Cells[1, 1].Worksheet.Column(1).Width = 20;
            ws4.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws4.Cells[1, 3].Worksheet.Column(3).Width = 18;
            ws4.Cells[1, 1, 1, 3].Merge = true;
            ws4.Cells[2, 1, 2, 3].Merge = true;
            ws4.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws4.Cells[1, 1].Value = "Laporan     : Toko OB";
            ws4.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws4.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws4.Cells[5, 1].Value = "KODE TOKO";
            ws4.Cells[5, 2].Value = "NAMA TOKO";
            ws4.Cells[5, 3].Value = "Rp NOTA";

            ws4.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws4.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dsFBFE.Tables[3].Rows)
            {
                ws4.Cells[rowx, 1].Value = dr1["KodeToko"];
                ws4.Cells[rowx, 2].Value = dr1["NamaToko"];
                ws4.Cells[rowx, 3].Value = dr1["RpNota"];
                ws4.Cells[rowx, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }

            var border5 = ws4.Cells[5, 1, rowx, 3].Style.Border;
            border5.Bottom.Style =
            border5.Top.Style =
            border5.Left.Style =
            border5.Right.Style = ExcelBorderStyle.Thin;
            ws4.Cells[5, 1, 5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws4.Cells[5, 1, 5, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            #endregion

            #region sheet 5


            ex.Workbook.Worksheets.Add("OA Pasif 6 Bulan");
            ExcelWorksheet ws5 = ex.Workbook.Worksheets[5];

            //// Width
            ws5.Cells[1, 1].Worksheet.Column(1).Width = 20;
            ws5.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws5.Cells[1, 3].Worksheet.Column(3).Width = 18;
            ws5.Cells[1, 1, 1, 3].Merge = true;
            ws5.Cells[2, 1, 2, 3].Merge = true;
            ws5.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws5.Cells[1, 1].Value = "Laporan     : OA Pasif 6 Bulan";
            ws5.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws5.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws5.Cells[5, 1].Value = "KODE TOKO";
            ws5.Cells[5, 2].Value = "NAMA TOKO";
            ws5.Cells[5, 3].Value = "Rp NOTA";

            ws5.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws5.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dsFBFE.Tables[4].Rows)
            {
                ws5.Cells[rowx, 1].Value = dr1["KodeToko"];
                ws5.Cells[rowx, 2].Value = dr1["NamaToko"];
                ws5.Cells[rowx, 3].Value = dr1["RpNota"];
                ws5.Cells[rowx, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }

            var border6 = ws5.Cells[5, 1, rowx, 3].Style.Border;
            border6.Bottom.Style =
            border6.Top.Style =
            border6.Left.Style =
            border6.Right.Style = ExcelBorderStyle.Thin;
            ws5.Cells[5, 1, 5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws5.Cells[5, 1, 5, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            #endregion

            #region sheet 6


            ex.Workbook.Worksheets.Add("SPV Score");
            ExcelWorksheet ws6 = ex.Workbook.Worksheets[6];

            ////TITLE
            ws6.Cells[1, 1].Value = "Laporan     : Supervisor Score";
            ws6.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws6.Cells[3, 1].Value = "Cabang      : " + GlobalVar.Gudang;

            ////HEADER
            //OMSET
            ws6.Cells[6, 2].Value = "NOMINAL R2";
            ws6.Cells[6, 6].Value = "NOMINAL R4";
            ws6.Cells[6, 10].Value = "SCORE OMSET";

            ws6.Cells[7, 2].Value = "Target";
            ws6.Cells[7, 3].Value = "Actual";
            ws6.Cells[7, 4].Value = "Selisih";
            ws6.Cells[7, 5].Value = "%";
            ws6.Cells[7, 6].Value = "Target";
            ws6.Cells[7, 7].Value = "Acutal";
            ws6.Cells[7, 8].Value = "Selisih";
            ws6.Cells[7, 9].Value = "%";

            ws6.Cells[6, 2, 6, 5].Merge = true;
            ws6.Cells[6, 6, 6, 9].Merge = true;

            ws6.Cells[13, 2, 13, 5].Merge = true;
            ws6.Cells[13, 6, 13, 9].Merge = true;

            ws6.Cells[20, 2, 20, 5].Merge = true;
            ws6.Cells[20, 6, 20, 9].Merge = true;

            ws6.Cells[6, 2, 7, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws6.Cells[13, 2, 14, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws6.Cells[20, 2, 21, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //OA
            ws6.Cells[13, 2].Value = "OA R2";
            ws6.Cells[13, 6].Value = "OA R4";
            ws6.Cells[13, 10].Value = "SCORE OA";

            ws6.Cells[14, 2].Value = "Target";
            ws6.Cells[14, 3].Value = "Actual";
            ws6.Cells[14, 4].Value = "Selisih";
            ws6.Cells[14, 5].Value = "%";
            ws6.Cells[14, 6].Value = "Target";
            ws6.Cells[14, 7].Value = "Acutal";
            ws6.Cells[14, 8].Value = "Selisih";
            ws6.Cells[14, 9].Value = "%";

            //SKU
            ws6.Cells[20, 2].Value = "SKU R2";
            ws6.Cells[20, 6].Value = "SKU R4";
            ws6.Cells[20, 10].Value = "SCORE SKU";

            ws6.Cells[21, 2].Value = "Target";
            ws6.Cells[21, 3].Value = "Items";
            ws6.Cells[21, 4].Value = "Selisih";
            ws6.Cells[21, 5].Value = "%";
            ws6.Cells[21, 6].Value = "Target";
            ws6.Cells[21, 7].Value = "Items";
            ws6.Cells[21, 8].Value = "Selisih";
            ws6.Cells[21, 9].Value = "%";

            ////BODY
            //NOMINAL R2
            if (dtFBFEDaily.Rows.Count > 0)
            {
                ws6.Cells[8, 2].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR2"]);
                ws6.Cells[8, 3].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR2"]);
                ws6.Cells[8, 4].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR2"]) - Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR2"]);
                if (Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR2"]) > 0)
                    ws6.Cells[8, 5].Value = (Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR2"]) / Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR2"])) * 100;
            }
            else
            {
                ws6.Cells[8, 2].Value = 0;
                ws6.Cells[8, 3].Value = 0;
                ws6.Cells[8, 4].Value = 0;
                ws6.Cells[8, 5].Value = 0;
            }

            ws6.Cells[8, 2].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 3].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 4].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 5].Style.Numberformat.Format = "#,##0";

            //NOMINAL R4
            if (dtFBFEDaily.Rows.Count > 0)
            {
                ws6.Cells[8, 6].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR4"]);
                ws6.Cells[8, 7].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR4"]);
                ws6.Cells[8, 8].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR4"]) - Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR4"]);
                if (Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR4"]) > 0)
                    ws6.Cells[8, 9].Value = (Convert.ToDouble(dtFBFEDaily.Rows[0]["RpNettoR4"]) / Convert.ToDouble(dtFBFEDaily.Rows[0]["TargetNominalR4"])) * 100;
            }
            else
            {
                ws6.Cells[8, 6].Value = 0;
                ws6.Cells[8, 7].Value = 0;
                ws6.Cells[8, 8].Value = 0;
                ws6.Cells[8, 9].Value = 0;
            }

            ws6.Cells[8, 6].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 7].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 8].Style.Numberformat.Format = "#,##0";
            ws6.Cells[8, 9].Style.Numberformat.Format = "#,##0";

            //OA R2
            if (dtSKUTgt.Rows.Count > 0 && dtFBFEDaily.Rows.Count > 0)
            {
                ws6.Cells[15, 2].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR2"]);
                ws6.Cells[15, 3].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR2"]);
                ws6.Cells[15, 4].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR2"]) - Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR2"]);
                if (Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR2"]) > 0)
                    ws6.Cells[15, 5].Value = (Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR2"]) / Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR2"])) * 100;
            }
            else
            {
                ws6.Cells[15, 2].Value = 0;
                ws6.Cells[15, 3].Value = 0;
                ws6.Cells[15, 4].Value = 0;
                ws6.Cells[15, 5].Value = 0;

                if (dtSKUTgt.Rows.Count > 0)
                    ws6.Cells[15, 2].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR2"]);

                if (dtFBFEDaily.Rows.Count > 0)
                    ws6.Cells[15, 3].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR2"]);

                ws6.Cells[15, 4].Value = Convert.ToDouble(ws6.Cells[15, 2].Value) - Convert.ToDouble(ws6.Cells[15, 3].Value);

                if (Convert.ToDouble(ws6.Cells[15, 2].Value) > 0)
                    ws6.Cells[15, 5].Value = (Convert.ToDouble(ws6.Cells[15, 3].Value) / Convert.ToDouble(ws6.Cells[15, 2].Value)) * 100;
            }

            ws6.Cells[15, 2].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 3].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 4].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 5].Style.Numberformat.Format = "#,##0";

            //OA R4
            if (dtSKUTgt.Rows.Count > 0 && dtFBFEDaily.Rows.Count > 0)
            {
                ws6.Cells[15, 6].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR4"]);
                ws6.Cells[15, 7].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR4"]);
                ws6.Cells[15, 8].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR4"]) - Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR4"]);
                if (Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR4"]) > 0)
                    ws6.Cells[15, 9].Value = (Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR4"]) / Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR4"])) * 100;
            }
            else
            {
                ws6.Cells[15, 6].Value = 0;
                ws6.Cells[15, 7].Value = 0;
                ws6.Cells[15, 8].Value = 0;
                ws6.Cells[15, 9].Value = 0;

                if (dtSKUTgt.Rows.Count > 0)
                    ws6.Cells[15, 6].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetOAR4"]);

                if (dtFBFEDaily.Rows.Count > 0)
                    ws6.Cells[15, 7].Value = Convert.ToDouble(dtFBFEDaily.Rows[0]["TotalTokoKumulatifR4"]);

                ws6.Cells[15, 8].Value = Convert.ToDouble(ws6.Cells[15, 6].Value) - Convert.ToDouble(ws6.Cells[15, 7].Value);
                if (Convert.ToDouble(ws6.Cells[15, 6].Value) > 0)
                    ws6.Cells[15, 9].Value = (Convert.ToDouble(ws6.Cells[15, 7].Value) / Convert.ToDouble(ws6.Cells[15, 6].Value)) * 100;
            }

            ws6.Cells[15, 6].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 7].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 8].Style.Numberformat.Format = "#,##0";
            ws6.Cells[15, 9].Style.Numberformat.Format = "#,##0";

            //SKU R2
            if (dtSKUTgt.Rows.Count > 0 && dtSKU.Rows.Count > 0)
            {
                ws6.Cells[22, 2].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR2"]);
                ws6.Cells[22, 3].Value = Convert.ToDouble(dtSKU.Rows[0]["Roda2"]);
                ws6.Cells[22, 4].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR2"]) - Convert.ToDouble(dtSKU.Rows[0]["Roda2"]);
                if (Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR2"]) > 0)
                    ws6.Cells[22, 5].Value = (Convert.ToDouble(dtSKU.Rows[0]["Roda2"]) / Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR2"])) * 100;

                ws6.Cells[22, 6].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR4"]);
                ws6.Cells[22, 7].Value = Convert.ToDouble(dtSKU.Rows[0]["Roda4"]);
                ws6.Cells[22, 8].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR4"]) - Convert.ToDouble(dtSKU.Rows[0]["Roda4"]);
                if (Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR4"]) > 0)
                    ws6.Cells[22, 5].Value = (Convert.ToDouble(dtSKU.Rows[0]["Roda4"]) / Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR4"])) * 100;
            }
            else
            {
                ws6.Cells[22, 2].Value = 0;
                ws6.Cells[22, 3].Value = 0;
                ws6.Cells[22, 4].Value = 0;
                ws6.Cells[22, 5].Value = 0;

                ws6.Cells[22, 6].Value = 0;
                ws6.Cells[22, 7].Value = 0;
                ws6.Cells[22, 8].Value = 0;
                ws6.Cells[22, 5].Value = 0;

                if (dtSKUTgt.Rows.Count > 0)
                    ws6.Cells[22, 2].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR2"]);

                if (dtSKU.Rows.Count > 0)
                    ws6.Cells[22, 3].Value = Convert.ToDouble(dtSKU.Rows[0]["Roda2"]);

                ws6.Cells[22, 4].Value = Convert.ToDouble(ws6.Cells[22, 2].Value) - Convert.ToDouble(ws6.Cells[22, 3].Value);

                if (Convert.ToDouble(ws6.Cells[22, 2].Value) > 0)
                    ws6.Cells[22, 5].Value = (Convert.ToDouble(ws6.Cells[22, 3].Value) / Convert.ToDouble(ws6.Cells[22, 2].Value)) * 100;

                if (dtSKUTgt.Rows.Count > 0)
                    ws6.Cells[22, 6].Value = Convert.ToDouble(dtSKUTgt.Rows[0]["TargetSKUR4"]);

                if (dtSKU.Rows.Count > 0)
                    ws6.Cells[22, 7].Value = Convert.ToDouble(dtSKU.Rows[0]["Roda4"]);

                ws6.Cells[22, 8].Value = Convert.ToDouble(ws6.Cells[22, 6].Value) - Convert.ToDouble(ws6.Cells[22, 7].Value);
                if (Convert.ToDouble(ws6.Cells[22, 6].Value) > 0)
                    ws6.Cells[22, 5].Value = (Convert.ToDouble(ws6.Cells[22, 7].Value) / Convert.ToDouble(ws6.Cells[22, 6].Value)) * 100;

            }

            var border7 = ws6.Cells[6, 2, 8, 10].Style.Border;
            border7.Bottom.Style =
            border7.Top.Style =
            border7.Left.Style =
            border7.Right.Style = ExcelBorderStyle.Thin;
            ws6.Cells[6, 2, 7, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws6.Cells[6, 2, 7, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            var border8 = ws6.Cells[13, 2, 15, 10].Style.Border;
            border8.Bottom.Style =
            border8.Top.Style =
            border8.Left.Style =
            border8.Right.Style = ExcelBorderStyle.Thin;
            ws6.Cells[13, 2, 14, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws6.Cells[13, 2, 14, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            var border9 = ws6.Cells[20, 2, 22, 10].Style.Border;
            border9.Bottom.Style =
            border9.Top.Style =
            border9.Left.Style =
            border9.Right.Style = ExcelBorderStyle.Thin;
            ws6.Cells[20, 2, 21, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws6.Cells[20, 2, 21, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            for (int i = 2; i <= 10; i++)
            {
                ws6.Cells[8, i].Worksheet.Column(i).Width = 15;
                ws6.Cells[15, i].Worksheet.Column(i).Width = 15;
                ws6.Cells[22, i].Worksheet.Column(i).Width = 15;
            }

            ws6.Cells[8, 5].Worksheet.Column(5).Width = 7;
            ws6.Cells[15, 5].Worksheet.Column(5).Width = 7;
            ws6.Cells[22, 5].Worksheet.Column(5).Width = 7;

            ws6.Cells[8, 9].Worksheet.Column(5).Width = 7;
            ws6.Cells[15, 9].Worksheet.Column(5).Width = 7;
            ws6.Cells[22, 9].Worksheet.Column(5).Width = 7;
            #endregion

            return ex;
        }

        #endregion
        int total = 0;
        DataTable dt0, dt1, dt2, dt3 = new DataTable();
        public frmRptSalesmanScoreV2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmRptSalesmanScoreV2_Load(object sender, EventArgs e)
        {
            dtbEnd.DateValue = GlobalVar.DateOfServer.AddDays(-1); 
        }

        private void DisplayReport(DataTable dataReport, string gudang)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptparam = new List<ReportParameter>();
                rptparam.Add(new ReportParameter("Gudang", gudang));

                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Analisa.rptBestSellerFavorit_TidakBergerak.rdlc", rptparam, dataReport, "dsBestSellerFavorit_TidakBergerak_Data");
                ifrmReport.Show();
            }
            catch (Exception Ex) { Error.LogError(Ex); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.DateTimeOfServer;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            _GudangID = lookupGudang1.GudangID;
            if (_GudangID == "[CODE]")
            {
                _GudangID = "";
            }

            ////x
            //DataTable dtBSF = new DataTable();
            //try
            //{
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("rsp_BestSellerFavorit_TidakBergerak"));
            //        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, _GudangID));
            //        dtBSF = db.Commands[0].ExecuteDataTable();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally { this.Cursor = Cursors.Default; }



            //if (dtBSF.Rows.Count > 0)
            //{
            //    DisplayReport(dtBSF, _GudangID);

            //    Tools.pin(PinId2.Periode.Hari, mingguKe, date, PinId2.Bagian.Penjualan, Convert.ToInt32(PinId2.ModulId.BestSellerFavorit), "Barang Best Seller atau Favorit yang tidak bergerak selama 3 bulan.");
            //    if (GlobalVar.pinResult == false) { return; }
            //}


            //x 

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_transaksiToko"));
                    dt0 = db.Commands[0].ExecuteDataTable();

                    if (dt0.Rows.Count > 0)
                    {
                        if (dt0.Rows[0][0].ToString() == "kosong")
                        {
                            total = 1;

                            MessageBox.Show("Data Customer Inti masih kosong, \n silahkan mengisinya pada menu yang tersedia");
                            return;
                        }
                        else { total = Convert.ToInt32(dt0.Rows[0][0]); }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally { this.Cursor = Cursors.Default; }

            if (total > 0)
            {

                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_transaksiToko"));
                        db.Commands[0].Parameters.Add(new Parameter("@getData", SqlDbType.Int, 1));
                        dt1 = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally { this.Cursor = Cursors.Default; }

                if (dt1.Rows.Count > 0) { generateXLCusInti(dt1); }

                //Tools.pin(PinId2.Periode.Hari, mingguKe, date, PinId2.Bagian.Penjualan, Convert.ToInt32(PinId2.ModulId.SalesmanScore), "Ada Customer Inti yang tidak melakukan transaksi pada 2 bulan terakhir");
                //if (GlobalVar.pinResult == false) { return; }

            }

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kunjungan_Sales"));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, date));
                    dt2 = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally { this.Cursor = Cursors.Default; }



            //if (Convert.ToInt32(dt2.Rows.Count) < 5)
            //{
            //    Tools.pin(PinId2.Periode.Hari, mingguKe, date, PinId2.Bagian.Penjualan, Convert.ToInt32(PinId2.ModulId.SalesmanScoreKunjunganSales), "Kunjungan Saleman Kurang Dari 5");
            //    if (GlobalVar.pinResult == false) { return; }
            //}




            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SalesmanScoreSuratJalan_SELECT"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, _GudangID));
                    dt3 = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally { this.Cursor = Cursors.Default; }
            //MessageBox.Show("sj="+dt3.Rows.Count.ToString());


            if (dt3.Rows.Count > 0)
            {
                //MessageBox.Show("masuk yaaa");

                //Tools.pin(PinId2.Periode.Hari, mingguKe, date, PinId2.Bagian.Penjualan, Convert.ToInt32(PinId2.ModulId.SalesmanScoreSuratJalan), "Ada GET yang lebih besar dari waktu yang di tentukan");
                //if (GlobalVar.pinResult == false) { return; }
            }


            if (dtbEnd.DateValue.HasValue)
            {
                dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1 * (dtbEnd.DateValue.Value.Day - 1));
            }

            if (Class.AppSetting.GetValue("JAWA") == "1" || Class.AppSetting.GetValue("JAWA") == "false")
            {
                nominalMinimumOAR2 = 2000000;
            }
            else
            {
                nominalMinimumOAR2 = 2000000;
            }

            _salesID = lookupSales.SalesID;
            //_GudangID = lookupGudang1.GudangID;
            //if (_GudangID == "[CODE]")
            //{
            //    _GudangID = "";
            //}
            _FromDate = dtbStart.DateValue.Value;
            _ToDate = dtbEnd.DateValue.Value;
            dsFBFE = new DataSet();

            // this.Cursor = Cursors.WaitCursor;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_LaporanSalesmanScoreV2]"));
                db.Commands[0].Parameters.Add(new Parameter("@salesID", SqlDbType.VarChar, _salesID));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, _GudangID));
                dsFBFE = db.Commands[0].ExecuteDataSet();
                dtFBFE = dsFBFE.Tables[0].Copy();
                dtFLAIN = dsFBFE.Tables[1].Copy();
                dtFA = dsFBFE.Tables[2].Copy();
                //MessageBox.Show(dsFBFE.Tables.Count.ToString());
            }

            //if (dtFBFE.Rows.Count == 0)
            //{
            //    throw new Exception("Tidak Ada Data");
            //}

            DataSet dsMarketShare = new DataSet();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_LaporanMarketShare_2]"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _ToDate));
                dsMarketShare = db.Commands[0].ExecuteDataSet();
            }

            dtSKUTgt = dsMarketShare.Tables[0].Copy();
            dtFBFEDaily = dsMarketShare.Tables[1].Copy();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_LaporanSKUPerTanggal"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dtSKU = db.Commands[0].ExecuteDataTable();
            }

            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(Process1());

            #region Generate File
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "Laporan Salesman Score.xlsx";

            sf.OverwritePrompt = true;
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
            {
                string file = sf.FileName.ToString();
                Byte[] bin1 = exs[0].GetAsByteArray();
                File.WriteAllBytes(file, bin1);
                MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                Process.Start(sf.FileName.ToString());
            }
            #endregion
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateXLCusInti(DataTable dt)
        {

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "CUSTOMER INTI";

                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";


                int LCol = 2;
                int Mcol = 16;

                #region Title
                ws.Cells[1, 1].Worksheet.Column(1).Width = 14;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 75;


                ws.Cells[1, 1].Value = "CUSTOMER INTI";
                ws.Cells[2, 1].Value = "";
                ws.Cells[1, 1, 1, LCol].Merge = true;
                ws.Cells[2, 1, 2, LCol].Merge = true;
                ws.Cells[1, 1, 3, LCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 3, LCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 3, LCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 12;
                #endregion
                #region data
                int i = 1;
                ws.Cells[3, 1].Value = "Kode Toko";
                ws.Cells[3, 2].Value = "Nama Toko";
                ws.Cells[3, 3].Value = "ID Toko";
                ws.Cells[3, 4].Value = "Wilayah Toko";
                foreach (DataRow dr in dt.Rows)
                {

                    ws.Cells[3 + i, 1].Value = dr["KodeToko"];
                    ws.Cells[3 + i, 2].Value = dr["NamaToko"];
                    ws.Cells[3 + i, 3].Value = dr["TokoID"];
                    ws.Cells[3 + i, 4].Value = dr["WilID"];
                    i = i + 1;
                }
                #endregion


                #region Summary & Formatting
                //ws.Cells[4, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws.Cells[4, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                //var border = ws.Cells[4, 1, idx - 1, MaxCol].Style.Border;
                //border.Bottom.Style =
                //  border.Top.Style =
                //  border.Left.Style =
                //  border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Customer Inti - " + GlobalVar.DateOfServer.ToString("ddMMMyyyy") + ".xlsx";

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

        private void dtbEnd_Leave(object sender, EventArgs e)
        {
            if (dtbEnd.DateValue.HasValue)
            {
                dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1 * (dtbEnd.DateValue.Value.Day - 1));
            }
        }
    }
}
