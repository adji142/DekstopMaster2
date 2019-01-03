using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.Piutang.Report
{
    public partial class frmRptSalesBL : ISA.Controls.BaseForm
    {
        DataTable dt;
        DataTable dtd;

        public frmRptSalesBL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptSalesBL_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = Convert.ToDateTime("01/01/2000");
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_SalesBL"));
                    dt=db.Commands[0].ExecuteDataTable();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtd = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_OverdueNota90"));
                    dtd = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            DisplayReport();
        }


        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapSalesBL());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LapSalesBL";     // +GlobalVar.Gudang;

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




        private ExcelPackage LapSalesBL()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Lap SALES BL";
            ex.Workbook.Properties.SetCustomPropertyValue("SALES BL", "1147");

            #region sheet 1
            ex.Workbook.Worksheets.Add("SalesBL");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;

            // Title
            ws.Cells[1, 2].Value = "SALES BL";
            ws.Cells[1, 2].Style.Font.Bold = true;
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer); // + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[3, 2].Style.Font.Bold = true;
            ws.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Header
            ws.Cells[4, 2].Value = " NO ";
            ws.Cells[4, 3].Value = " KODE SALES ";
            ws.Cells[4, 4].Value = " OVERDUE ";

            int MaxCol = 4;
            int rowz = 4;
            int rowx = rowz + 1;
            int no = 0;
            double JmlD = 0, JmlK = 0;

            ws.Cells[4, 2, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[4, 2, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[4, 2, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 2, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            foreach (DataRow dr in dt.Rows)
            {
                no += 1;
                ws.Cells[rowx, 2].Value = no.ToString();
                ws.Cells[rowx, 3].Value = Tools.isNull(dr["KodeSales"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr["Ovd90Hr"], "");
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                rowx++;
            }

            //ws.Cells[rowx, 2].Value = "Jumlah";
            //ws.Cells[rowx, 2].Style.Font.Bold = true;
            //ws.Cells[rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[rowx, 4].Value = Tools.isNull(JmlD, 0);
            //ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[rowx, 4].Style.Font.Bold = true;
            //ws.Cells[rowx, 5].Value = Tools.isNull(JmlK, 0);
            //ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[rowx, 5].Style.Font.Bold = true;

            var border = ws.Cells[rowz + 1, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowz, 2, rowz, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion


            #region sheet 2
            ex.Workbook.Worksheets.Add("Nota Overdue > 90 hr");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            // Width
            ws2.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 10;
            ws2.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws2.Cells[1, 5].Worksheet.Column(5).Width = 15;
            ws2.Cells[1, 6].Worksheet.Column(6).Width = 6;
            ws2.Cells[1, 7].Worksheet.Column(7).Width = 6;
            ws2.Cells[1, 8].Worksheet.Column(8).Width = 15;
            ws2.Cells[1, 9].Worksheet.Column(9).Width = 10;
            ws2.Cells[1, 10].Worksheet.Column(10).Width = 20;
            ws2.Cells[1, 11].Worksheet.Column(11).Width = 15;
            ws2.Cells[1, 12].Worksheet.Column(12).Width = 35;
            ws2.Cells[1, 13].Worksheet.Column(13).Width = 65;
            ws2.Cells[1, 14].Worksheet.Column(14).Width = 25;
            ws2.Cells[1, 15].Worksheet.Column(15).Width = 10;

            ws2.Cells[1, 2].Value = "NOTA-NOTA OVERDUE > 90 HR";
            ws2.Cells[1, 2].Style.Font.Bold = true;
            ws2.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);    // +" s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws2.Cells[3, 2].Style.Font.Bold = true;
            ws2.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2].Value = " NO ";
            ws2.Cells[4, 3].Value = " NO NOTA ";
            ws2.Cells[4, 4].Value = " TGL NOTA ";
            ws2.Cells[4, 5].Value = " TGL TERIMA ";
            ws2.Cells[4, 6].Value = " JW ";
            ws2.Cells[4, 7].Value = " JS ";
            ws2.Cells[4, 8].Value = " TGL JT TEMPO ";
            ws2.Cells[4, 9].Value = " TRN TYPE ";
            ws2.Cells[4, 10].Value= " PIUTANG OVERDUE ";
            ws2.Cells[4, 11].Value= " KODE SALES ";
            ws2.Cells[4, 12].Value= " NAMA TOKO ";
            ws2.Cells[4, 13].Value= " ALAMAT ";
            ws2.Cells[4, 14].Value= " KOTA ";
            ws2.Cells[4, 15].Value= " IDWIL ";

            int MaxCol2 = 15;
            rowz = 4;
            int rowx2 = rowz + 1;
            int no2 = 0;
            Double Saldo = 0;

            ws2.Cells[4, 2, 4, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[4, 2, 4, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            double Nominal = 0;

            foreach (DataRow dr0 in dtd.Rows)
            {
                no2 += 1;
                ws2.Cells[rowx2, 2].Value = no2.ToString();
                ws2.Cells[rowx2, 3].Value = Tools.isNull(dr0["NoNota"], "");
                ws2.Cells[rowx2, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglNota"], ""));
                ws2.Cells[rowx2, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglTerima"], ""));
                ws2.Cells[rowx2, 6].Value = Tools.isNull(dr0["JW"], 0);
                ws2.Cells[rowx2, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 7].Value = Tools.isNull(dr0["JS"], 0);
                ws2.Cells[rowx2, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglJatuhTempo"], ""));
                ws2.Cells[rowx2, 9].Value = Tools.isNull(dr0["TransactionType"], "");
                ws2.Cells[rowx2, 10].Value = Tools.isNull(dr0["PiutangOverdue"], 0);
                ws2.Cells[rowx2, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 11].Value = Tools.isNull(dr0["KodeSales"], "");
                ws2.Cells[rowx2, 12].Value = Tools.isNull(dr0["NamaToko"], "");
                ws2.Cells[rowx2, 13].Value = Tools.isNull(dr0["Alamat"], "");
                ws2.Cells[rowx2, 14].Value = Tools.isNull(dr0["Kota"], "");
                ws2.Cells[rowx2, 15].Value = Tools.isNull(dr0["WilID"], "");
                rowx2++;
                Saldo = Saldo + Convert.ToDouble(Tools.isNull(dr0["PiutangOverdue"], 0));
            }

            ws2.Cells[rowx2, 9].Value = "Jumlah";
            ws2.Cells[rowx2, 9].Style.Font.Bold = true;
            ws2.Cells[rowx2, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[rowx2, 10].Value = Tools.isNull(Saldo, 0);
            ws2.Cells[rowx2, 10].Style.Font.Bold = true;
            ws2.Cells[rowx2, 10].Style.Numberformat.Format = "#,##;(#,##);0";

            var border2 = ws2.Cells[rowz + 1, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.None;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowz, 2, rowz, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowx2, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.Thin;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, 2, rowx2, 2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style = ExcelBorderStyle.Thin;
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, MaxCol2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region sheet 3
            //ex.Workbook.Worksheets.Add("Sales");
            //ExcelWorksheet ws3 = ex.Workbook.Worksheets[3];

            //// Width
            //ws3.Cells[1, 1].Worksheet.Column(1).Width = 2;
            //ws3.Cells[1, 2].Worksheet.Column(2).Width = 5;
            //ws3.Cells[1, 3].Worksheet.Column(3).Width = 17;
            //ws3.Cells[1, 4].Worksheet.Column(4).Width = 40;
            //ws3.Cells[1, 5].Worksheet.Column(5).Width = 15;
            //ws3.Cells[1, 6].Worksheet.Column(6).Width = 15;

            //ws3.Cells[1, 2].Value = "SALES TAC";
            //ws3.Cells[1, 2].Style.Font.Bold = true;
            //ws3.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws3.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);    // +" s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            //ws3.Cells[3, 2].Style.Font.Bold = true;
            //ws3.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws3.Cells[4, 2].Value = " NO ";
            //ws3.Cells[4, 3].Value = " KODE SALES ";
            //ws3.Cells[4, 4].Value = " NAMA SALES ";
            //ws3.Cells[4, 5].Value = " TGL MASUK ";
            //ws3.Cells[4, 6].Value = " TGL KELUAR ";

            //int MaxCol3 = 6;
            //rowz = 4;
            //int rowx3 = rowz + 1;
            //int no3 = 0;

            //ws3.Cells[4, 2, 4, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws3.Cells[4, 2, 4, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //foreach (DataRow dr0 in dsData.Tables[3].Rows)
            //{
            //    no3 += 1;
            //    ws3.Cells[rowx3, 2].Value = no3.ToString();
            //    ws3.Cells[rowx3, 3].Value = Tools.isNull(dr0["SalesID"], "");
            //    ws3.Cells[rowx3, 4].Value = Tools.isNull(dr0["NamaSales"], "");
            //    ws3.Cells[rowx3, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglMasuk"], ""));
            //    ws3.Cells[rowx3, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglKeluar"], ""));
            //    rowx3++;
            //}

            //var border3 = ws3.Cells[rowz + 1, 2, rowx3, MaxCol3].Style.Border;
            //border3.Bottom.Style =
            //border3.Top.Style = ExcelBorderStyle.None;
            //border3.Left.Style =
            //border3.Right.Style = ExcelBorderStyle.Thin;

            //border3 = ws3.Cells[rowz, 2, rowz, MaxCol3].Style.Border;
            //border3.Bottom.Style =
            //border3.Top.Style =
            //border3.Left.Style =
            //border3.Right.Style = ExcelBorderStyle.Thin;

            //border3 = ws3.Cells[rowx3, 2, rowx3, MaxCol3].Style.Border;
            //border3.Bottom.Style =
            //border3.Top.Style = ExcelBorderStyle.Thin;
            //border3.Left.Style =
            //border3.Right.Style = ExcelBorderStyle.None;

            //border3 = ws3.Cells[rowx3, 2, rowx3, 2].Style.Border;
            //border3.Bottom.Style =
            //border3.Top.Style =
            //border3.Left.Style = ExcelBorderStyle.Thin;
            //border3.Right.Style = ExcelBorderStyle.None;

            //border3 = ws3.Cells[rowx3, MaxCol3, rowx3, MaxCol3].Style.Border;
            //border3.Bottom.Style =
            //border3.Top.Style =
            //border3.Left.Style =
            //border3.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            return ex;
        }


    }
}
