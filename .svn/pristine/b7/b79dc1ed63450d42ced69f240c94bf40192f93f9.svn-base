using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Finance.Register.Report
{
    public partial class frmRptInsentifTagihanSales : ISA.Controls.BaseForm
    {
        public frmRptInsentifTagihanSales()
        {
            InitializeComponent();
        }

        private void frmRptInsentifTagihanSales_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                string periode = monthYearBox1.Year.ToString() + monthYearBox1.Month.ToString().PadLeft(2, '0');
                DateTime fromDate = new DateTime(int.Parse(monthYearBox1.Year.ToString()), int.Parse(monthYearBox1.Month.ToString().PadLeft(2, '0')), 1);
                DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Insentif_Tagihan_Sales_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayReportTagihanFeb2017(ds, fromDate, toDate);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.NotFound);
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
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void DisplayReportTagihanFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentifTagihanFeb2017(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifTagihan_Sales";

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

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage LapInsentifTagihanFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif Tagihan Sales";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Tagihan Sales", "1147");

            ex.Workbook.Worksheets.Add("Rekap Insentif Tagihan Sales");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            #region Laporan rekap insentif Tagihan BE

            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            int nRow = 0, nHeader = 1, Rowx = 0, MaxCol = 16;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 14;      //omset be
            ws.Cells[1, 6].Worksheet.Column(6).Width = 14;      //pembayaran <= 90 hari
            ws.Cells[1, 7].Worksheet.Column(7).Width = 14;      //pembayaran <= 30 hari
            ws.Cells[1, 8].Worksheet.Column(8).Width = 6;       //%
            ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //insentif
            ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //pembayaran 31 - 60 hari
            ws.Cells[1, 11].Worksheet.Column(11).Width = 6;     //%
            ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //insentif
            ws.Cells[1, 13].Worksheet.Column(13).Width = 14;    //pembayaran 61 - 90 hari
            ws.Cells[1, 14].Worksheet.Column(14).Width = 6;     //%
            ws.Cells[1, 15].Worksheet.Column(15).Width = 14;    //insentif
            ws.Cells[1, 16].Worksheet.Column(16).Width = 14;    //jumlah
            ws.Cells[1, 17].Worksheet.Column(17).Width = 14;    //mbuh
            ws.Cells[1, 18].Worksheet.Column(18).Width = 14;    //ra ngerti

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Tagihan Sales";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Insentif Tagihan Nota Barang BE";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            Rowx = nHeader;

            for (int i = 2; i <= 6; i++)
            {
                ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            }
            ws.Cells[Rowx, 6, Rowx + 2, 6].Style.WrapText = true;

            ws.Cells[Rowx, 7, Rowx + 1, 9].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 1, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx + 1, 15].Merge = true;
            ws.Cells[Rowx, 16, Rowx + 2, 16].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Omset BE ";
            ws.Cells[Rowx, 6].Value = " Total Pembayaran <= 90 hari ";

            ws.Cells[Rowx, 7].Value = " Tempo Pembayaran <= 30 hari ";
            ws.Cells[Rowx + 2, 7].Value = " Pembayaran ";
            ws.Cells[Rowx + 2, 8].Value = " (%) ";
            ws.Cells[Rowx + 2, 9].Value = " Insentif ";

            ws.Cells[Rowx, 10].Value = " Tempo Pembayaran 31 - 60 hari ";
            ws.Cells[Rowx + 2, 10].Value = " Pembayaran ";
            ws.Cells[Rowx + 2, 11].Value = " (%) ";
            ws.Cells[Rowx + 2, 12].Value = " Insentif ";

            ws.Cells[Rowx, 13].Value = " Tempo Pembayaran 61 - 90 hari";
            ws.Cells[Rowx + 2, 13].Value = " Pembayaran ";
            ws.Cells[Rowx + 2, 14].Value = " (%) ";
            ws.Cells[Rowx + 2, 15].Value = " Insentif ";

            ws.Cells[Rowx, 16].Value = " Jumlah ";
            
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            
            Rowx += 3;
            nRow = Rowx;

            int no = 0;
            double JmlInsentifBE = 0, JmlInsentifFX = 0, JmlInsentif = 0, TotalInsentif = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["CollectorID"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBe"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe1"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Persen1"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe1"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe2"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Persen2"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe2"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe3"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Persen3"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe3"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    JmlInsentifBE += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Rowx++;
                }
            }

            //Rowx++;
            ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 5].Style.Font.Bold = true;

            ws.Cells[Rowx, 16].Value = Tools.isNull(JmlInsentifBE, 0);
            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 16].Style.Font.Bold = true;

            var border = ws.Cells[nHeader, 2, nHeader + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            if (ds.Tables[1].Rows.Count > 0)
            {
                border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
            }

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region rekap insentif tagihan FX

            ws.Cells[Rowx + 3, 2].Value = "Insentif Tagihan Nota Barang FX";
            ws.Cells[Rowx + 3, 2].Style.Font.Bold = true;
            ws.Cells[Rowx + 3, 2].Style.Font.Italic = true;

            nHeader = Rowx + 4;
            Rowx = nHeader;
            MaxCol = 13;

            for (int i = 2; i <= 6; i++)
            {
                ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            }
            ws.Cells[Rowx, 6, Rowx + 2, 6].Style.WrapText = true;

            ws.Cells[Rowx, 7, Rowx, 9].Merge = true;
            ws.Cells[Rowx + 1, 7, Rowx + 1, 9].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 1, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx + 2, 13].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Omset FX ";
            ws.Cells[Rowx, 6].Value = " Total Pembayaran ";

            ws.Cells[Rowx, 7].Value = " Penjualan Kredit ";
            ws.Cells[Rowx + 1, 7].Value = " Tempo Pembayaran 0 - 14 hari ";
            ws.Cells[Rowx + 2, 7].Value = " Pembayaran ";
            ws.Cells[Rowx + 2, 8].Value = " (%) ";
            ws.Cells[Rowx + 2, 9].Value = " Insentif ";

            ws.Cells[Rowx, 10].Value = " Penjualan Tunai ";
            ws.Cells[Rowx + 2, 10].Value = " Pembayaran ";
            ws.Cells[Rowx + 2, 11].Value = " (%) ";
            ws.Cells[Rowx + 2, 12].Value = " Insentif ";

            ws.Cells[Rowx, 13].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 3;
            nRow = Rowx;

            no = 0; JmlInsentifBE = 0; JmlInsentifFX = 0; JmlInsentif = 0; TotalInsentif = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["CollectorID"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetFx"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx1"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Persenfx1"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx2"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Persenfx2"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx2"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";

                    JmlInsentifFX += Convert.ToDouble(Tools.isNull(dr1["Insfx"], "0").ToString());
                    Rowx++;
                }
            }

            ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 5].Style.Font.Bold = true;

            ws.Cells[Rowx, 13].Value = Tools.isNull(JmlInsentifFX, 0);
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 13].Style.Font.Bold = true;

            border = ws.Cells[nHeader, 2, nHeader + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            if (ds.Tables[2].Rows.Count > 0)
            {
                border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
            }

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region Rekap Insentif netto

            ws.Cells[Rowx + 3, 2].Value = "Rekap Insentif Sales";
            ws.Cells[Rowx + 3, 2].Style.Font.Bold = true;
            ws.Cells[Rowx + 3, 2].Style.Font.Italic = true;

            nHeader = Rowx + 4;
            Rowx = nHeader;
            MaxCol = 18;

            for (int i = 2; i <= 6; i++)
            {
                ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            }
            ws.Cells[Rowx, 6, Rowx + 2, 6].Style.WrapText = true;

            ws.Cells[Rowx, 7, Rowx, 10].Merge = true;
            ws.Cells[Rowx + 1, 7, Rowx + 2, 7].Merge = true;
            ws.Cells[Rowx + 1, 8, Rowx + 2, 8].Merge = true;
            ws.Cells[Rowx + 1, 9, Rowx + 2, 9].Merge = true;
            ws.Cells[Rowx + 1, 10, Rowx + 2, 10].Merge = true;

            ws.Cells[Rowx, 11, Rowx + 2, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx + 2, 13].Merge = true;
            ws.Cells[Rowx, 14, Rowx + 2, 15].Merge = true;

            ws.Cells[Rowx, 16, Rowx, 18].Merge = true;
            ws.Cells[Rowx + 1, 16, Rowx + 2, 16].Merge = true;
            ws.Cells[Rowx + 1, 17, Rowx + 2, 17].Merge = true;
            ws.Cells[Rowx + 1, 18, Rowx + 2, 18].Merge = true;

            ws.Cells[Rowx, 13, Rowx + 2, 13].Style.WrapText = true;
            ws.Cells[Rowx, 16, Rowx + 2, 16].Style.WrapText = true;
            ws.Cells[Rowx, 17, Rowx + 2, 17].Style.WrapText = true;


            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Omset All ";
            ws.Cells[Rowx, 6].Value = " Insentif ";

            ws.Cells[Rowx, 7].Value = " Retur Penjualan ";
            ws.Cells[Rowx + 1, 7].Value = " Nominal(Rp) ";
            ws.Cells[Rowx + 1, 8].Value = " (%) ";
            ws.Cells[Rowx + 1, 9].Value = " Denda(%) ";
            ws.Cells[Rowx + 1, 10].Value = " Denda(Rp) ";

            ws.Cells[Rowx, 11].Value = " Insentif Netto ";
            ws.Cells[Rowx, 13].Value = " Jml Denda Overdue BE ";
            ws.Cells[Rowx, 14].Value = " Total Insentif ";

            ws.Cells[Rowx, 16].Value = " Acc Insentif ";
            ws.Cells[Rowx + 1, 16].Value = " Bonus Masuk HLL ";
            ws.Cells[Rowx + 1, 17].Value = " Bonus Dibagikan ";
            ws.Cells[Rowx + 1, 18].Value = " ACC ";

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 3;
            nRow = Rowx;

            no = 0; TotalInsentif = 0;

            if (ds.Tables[3].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    ws.Cells[Rowx, 11, Rowx, 12].Merge = true;
                    ws.Cells[Rowx, 14, Rowx, 15].Merge = true;

                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["PersenRetur"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["PersenDenda"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["InsNet1"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["RpDendaOvd"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["InsNet2"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";

                    TotalInsentif += Convert.ToDouble(Tools.isNull(dr1["InsNet2"], "0").ToString());
                    Rowx++;
                }
            }

            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 15].Value = Tools.isNull(TotalInsentif, 0);
            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 15].Style.Font.Bold = true;

            border = ws.Cells[nHeader, 2, nHeader + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            if (ds.Tables[3].Rows.Count > 0)
            {
                border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
            }

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region rekap denda

            ws.Cells[Rowx + 3, 2].Value = "Rekap Denda";
            ws.Cells[Rowx + 3, 2].Style.Font.Bold = true;
            ws.Cells[Rowx + 3, 2].Style.Font.Italic = true;

            nHeader = Rowx + 4;
            Rowx = nHeader;
            MaxCol = 10;

            for (int i = 2; i <= 4; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 5, Rowx, 9].Merge = true;
            ws.Cells[Rowx + 1, 8, Rowx + 1, 9].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 1, 10].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";

            ws.Cells[Rowx, 5].Value = " PERSEN DENDA 1% PERBULAN ";
            ws.Cells[Rowx + 1, 5].Value = " Klp ";
            ws.Cells[Rowx + 1, 6].Value = " Denda(Rp) ";
            ws.Cells[Rowx + 1, 7].Value = " Klp ";
            ws.Cells[Rowx + 1, 8].Value = " Denda(Rp) ";

            ws.Cells[Rowx, 10].Value = " Jumlah(Rp) ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            nRow = Rowx;

            no = 0; 
            double Rpdbe = 0, Rpdfx = 0, Rpdenda = 0;

            if (ds.Tables[4].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[4].Rows)
                {
                    ws.Cells[Rowx, 8, Rowx, 9].Merge = true;

                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = "BE";
                    ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["RpDendaBE"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = "FX";
                    ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["RpDendaFX"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["RpDendaBE"], "0").ToString()) +
                                               Convert.ToDouble(Tools.isNull(dr1["RpDendaFX"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";

                    Rpdbe += Convert.ToDouble(Tools.isNull(dr1["RpDendaBE"], "0").ToString());
                    Rpdfx += Convert.ToDouble(Tools.isNull(dr1["RpDendaFX"], "0").ToString());
                    Rpdenda += Convert.ToDouble(Tools.isNull(dr1["RpDendaBE"], "0").ToString()) +
                               Convert.ToDouble(Tools.isNull(dr1["RpDendaFX"], "0").ToString());
                    Rowx++;
                }
            }

            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 6].Value = Tools.isNull(Rpdbe, 0);
            ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 6].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = Tools.isNull(Rpdfx, 0);
            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

            ws.Cells[Rowx, 10].Value = Tools.isNull(Rpdenda, 0);
            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 10].Style.Font.Bold = true;

            border = ws.Cells[nHeader, 2, nHeader + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            if (ds.Tables[4].Rows.Count > 0)
            {
                border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
            }

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region Laporan detail insentif tagihan BE

            ex.Workbook.Worksheets.Add("Detail Tagihan BE");
            ws = ex.Workbook.Worksheets[2];
            ws.View.ShowGridLines = false;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 8;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //penagih
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //penagih
            ws.Cells[1, 5].Worksheet.Column(5).Width = 11;      //noreg
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //tglreg
            ws.Cells[1, 7].Worksheet.Column(7).Width = 11;      //nonota
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //tglterima
            ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //TR
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //hariptg
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //tgljttempo
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //tglinden
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;    //rptagih
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //nominalbe
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //rpkas
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //rpgiro
            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //rptrn
            ws.Cells[1, 18].Worksheet.Column(18).Width = 12;    //<=30
            ws.Cells[1, 19].Worksheet.Column(19).Width = 12;    //30-60
            ws.Cells[1, 20].Worksheet.Column(20).Width = 12;    //>60
            ws.Cells[1, 21].Worksheet.Column(21).Width = 8;     //1%
            ws.Cells[1, 22].Worksheet.Column(22).Width = 8;     //0,5%
            ws.Cells[1, 23].Worksheet.Column(23).Width = 8;     //0,25%
            ws.Cells[1, 24].Worksheet.Column(24).Width = 16;    //ins<=30
            ws.Cells[1, 25].Worksheet.Column(25).Width = 16;    //ins 30-60
            ws.Cells[1, 26].Worksheet.Column(26).Width = 16;    //ins>60
            ws.Cells[1, 27].Worksheet.Column(27).Width = 16;    //insentifbe

            nRow = 0; nHeader = 1; Rowx = 0;
            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Tagihan Sales";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Insentif Tagihan Nota Barang BE";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            nRow = nHeader;
            Rowx = nRow;
            MaxCol = 27;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Reg ";
            ws.Cells[Rowx, 6].Value = " Tgl Reg ";
            ws.Cells[Rowx, 7].Value = " No Nota ";
            ws.Cells[Rowx, 8].Value = " Tgl Terima ";
            ws.Cells[Rowx, 9].Value = " TR ";
            ws.Cells[Rowx, 10].Value = " HariPtg ";
            ws.Cells[Rowx, 11].Value = " Tgl JtTempo ";
            ws.Cells[Rowx, 12].Value = " Tgl Inden ";
            ws.Cells[Rowx, 13].Value = " Rp Tagih ";
            ws.Cells[Rowx, 14].Value = " Nominal BE ";
            ws.Cells[Rowx, 15].Value = " Rp Kas ";
            ws.Cells[Rowx, 16].Value = " Rp Giro ";
            ws.Cells[Rowx, 17].Value = " rp Trn ";
            ws.Cells[Rowx, 18].Value = " <= 30 Hari ";
            ws.Cells[Rowx, 19].Value = " 30-60 Hari ";
            ws.Cells[Rowx, 20].Value = " 60-90 Hari ";
            ws.Cells[Rowx, 21].Value = " 1% ";
            ws.Cells[Rowx, 22].Value = " 0,5% ";
            ws.Cells[Rowx, 23].Value = " 0,25% ";
            ws.Cells[Rowx, 24].Value = " Ins <= 30 Hari ";
            ws.Cells[Rowx, 25].Value = " Ins 30-60 Hari ";
            ws.Cells[Rowx, 26].Value = " Ins 60-90 Hari ";
            ws.Cells[Rowx, 27].Value = " Insentif BE ";

            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 1;

            no = 0;
            int Jrec = 0, nRec = 0;
            double Jmlbe = 0, Totbe = 0;
            string cNama = "";
            string cAwal = "1";

            if (ds.Tables[5].Rows.Count > 0)
            {
                Jrec = ds.Tables[5].Rows.Count;
                foreach (DataRow dr1 in ds.Tables[5].Rows)
                {
                    nRec++;
                    if (cNama != Tools.isNull(dr1["Nama"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 3].Value = "Jumlah";
                            ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 27].Value = Tools.isNull(Jmlbe, 0);
                            ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 27].Style.Font.Bold = true;
                            ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);

                            Jmlbe = 0;
                            Rowx++;

                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                                border1.Bottom.Style = ExcelBorderStyle.Thin;
                                border1.Top.Style =
                                border1.Left.Style =
                                border1.Right.Style = ExcelBorderStyle.None;
                            }

                            Rowx++;
                            ws.Cells[Rowx, 2].Value = "Insentif Tagihan Nota Barang BE";
                            ws.Cells[Rowx, 2].Style.Font.Bold = true;
                            ws.Cells[Rowx, 2].Style.Font.Italic = true;
                            Rowx++;
                            nRow = Rowx;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Reg ";
                            ws.Cells[Rowx, 6].Value = " Tgl Reg ";
                            ws.Cells[Rowx, 7].Value = " No Nota ";
                            ws.Cells[Rowx, 8].Value = " Tgl Terima ";
                            ws.Cells[Rowx, 9].Value = " TR ";
                            ws.Cells[Rowx, 10].Value = " HariPtg ";
                            ws.Cells[Rowx, 11].Value = " Tgl JtTempo ";
                            ws.Cells[Rowx, 12].Value = " Tgl Inden ";
                            ws.Cells[Rowx, 13].Value = " Rp Tagih ";
                            ws.Cells[Rowx, 14].Value = " Nominal BE ";
                            ws.Cells[Rowx, 15].Value = " Rp Kas ";
                            ws.Cells[Rowx, 16].Value = " Rp Giro ";
                            ws.Cells[Rowx, 17].Value = " rp Trn ";
                            ws.Cells[Rowx, 18].Value = " <= 30 Hari ";
                            ws.Cells[Rowx, 19].Value = " 30-60 Hari ";
                            ws.Cells[Rowx, 20].Value = " > 60 Hari ";
                            ws.Cells[Rowx, 21].Value = " 1% ";
                            ws.Cells[Rowx, 22].Value = " 0,5% ";
                            ws.Cells[Rowx, 23].Value = " 0,25% ";
                            ws.Cells[Rowx, 24].Value = " Ins <= 30 Hari ";
                            ws.Cells[Rowx, 25].Value = " Ins 30-60 Hari ";
                            ws.Cells[Rowx, 26].Value = " Ins > 60 Hari ";
                            ws.Cells[Rowx, 27].Value = " Insentif BE ";

                            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx += 1;
                            no = 0;
                        }
                    }

                    cNama = Tools.isNull(dr1["Nama"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["CollectorID"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoReg"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglReg"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
                    ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["HariPtg"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 11].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJtTempo"], ""));
                    ws.Cells[Rowx, 12].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglInden"], ""));
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["RpTagih"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpKas"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["RpGiro"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["RpTransfer"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe1"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe2"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe3"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["persen1"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["persen2"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["persen3"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 24].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe1"], "0").ToString());
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 25].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe2"], "0").ToString());
                    ws.Cells[Rowx, 25].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 26].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe3"], "0").ToString());
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jmlbe += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Totbe += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 3].Value = "Jumlah";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 27].Value = Tools.isNull(Jmlbe, 0);
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Style.Font.Bold = true;
                    ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);

                    Rowx++;

                    ws.Cells[Rowx, 3].Value = "Total";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 27].Value = Tools.isNull(Totbe, 0);
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Style.Font.Bold = true;
                    ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                        border1.Bottom.Style = ExcelBorderStyle.Thin;
                        border1.Top.Style =
                        border1.Left.Style =
                        border1.Right.Style = ExcelBorderStyle.None;
                    }
                }
                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            }
            #endregion


            #region Laporan detail insentif tagihan FX

            ex.Workbook.Worksheets.Add("Detail Tagihan FX");
            ws = ex.Workbook.Worksheets[3];
            ws.View.ShowGridLines = false;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 8;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 12;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 11;      //noreg
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //tglreg
            ws.Cells[1, 7].Worksheet.Column(7).Width = 11;      //nonota
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //tglterima
            ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //TR
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //hariptg
            ws.Cells[1, 11].Worksheet.Column(11).Width = 13;    //tgljttempo
            ws.Cells[1, 12].Worksheet.Column(12).Width = 13;    //tglinden
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;    //rptagih
            ws.Cells[1, 14].Worksheet.Column(14).Width = 18;    //total pembayaran
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //rpkas
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //rpgiro
            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //rptrn
            ws.Cells[1, 18].Worksheet.Column(18).Width = 12;    //0-14
            ws.Cells[1, 19].Worksheet.Column(19).Width = 8;     //0,5%
            ws.Cells[1, 20].Worksheet.Column(20).Width = 12;    //ins 0-14
            ws.Cells[1, 21].Worksheet.Column(21).Width = 18;    //penjualan tunai
            ws.Cells[1, 22].Worksheet.Column(22).Width = 8;     //0,5%
            ws.Cells[1, 23].Worksheet.Column(23).Width = 18;    //ins penj.tunai
            ws.Cells[1, 24].Worksheet.Column(24).Width = 18;    //total insentif

            nRow = 0; nHeader = 1; Rowx = 0;
            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Tagihan";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Insentif Tagihan Nota Barang FX";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            nRow = nHeader;
            Rowx = nRow;
            MaxCol = 24;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Reg ";
            ws.Cells[Rowx, 6].Value = " Tgl Reg ";
            ws.Cells[Rowx, 7].Value = " No Nota ";
            ws.Cells[Rowx, 8].Value = " Tgl Terima ";
            ws.Cells[Rowx, 9].Value = " TR ";
            ws.Cells[Rowx, 10].Value = " HariPtg ";
            ws.Cells[Rowx, 11].Value = " Tgl JtTempo ";
            ws.Cells[Rowx, 12].Value = " Tgl Inden ";
            ws.Cells[Rowx, 13].Value = " Rp Tagih ";
            ws.Cells[Rowx, 14].Value = " Total Pembayaran ";
            ws.Cells[Rowx, 15].Value = " Rp Kas ";
            ws.Cells[Rowx, 16].Value = " Rp Giro ";
            ws.Cells[Rowx, 17].Value = " rp Trn ";
            ws.Cells[Rowx, 18].Value = " 0-14 Hari ";
            ws.Cells[Rowx, 19].Value = " 0,5% ";
            ws.Cells[Rowx, 20].Value = " Ins 0-14 Hari ";
            ws.Cells[Rowx, 21].Value = " Penjualan Tunai ";
            ws.Cells[Rowx, 22].Value = " 0,5% ";
            ws.Cells[Rowx, 23].Value = " Ins Pjl Tunai ";
            ws.Cells[Rowx, 24].Value = " Total Insentif ";

            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 1;

            no = 0; Jrec = 0; nRec = 0;
            double Jmlfx = 0, Totfx = 0;
            cNama = ""; cAwal = "1";

            if (ds.Tables[6].Rows.Count > 0)
            {
                Jrec = ds.Tables[6].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[6].Rows)
                {
                    nRec++;
                    if (cNama != Tools.isNull(dr1["Nama"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 3].Value = "Jumlah";
                            ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 24].Value = Tools.isNull(Jmlfx, 0);
                            ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 24].Style.Font.Bold = true;
                            ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                            Jmlfx = 0;
                            Rowx++;

                            if (ds.Tables[6].Rows.Count > 0)
                            {
                                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                                border1.Bottom.Style = ExcelBorderStyle.Thin;
                                border1.Top.Style =
                                border1.Left.Style =
                                border1.Right.Style = ExcelBorderStyle.None;
                            }

                            Rowx++;
                            ws.Cells[Rowx, 2].Value = "Insentif Tagihan Nota Barang FX";
                            ws.Cells[Rowx, 2].Style.Font.Bold = true;
                            ws.Cells[Rowx, 2].Style.Font.Italic = true;
                            Rowx++;
                            nRow = Rowx;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Reg ";
                            ws.Cells[Rowx, 6].Value = " Tgl Reg ";
                            ws.Cells[Rowx, 7].Value = " No Nota ";
                            ws.Cells[Rowx, 8].Value = " Tgl Terima ";
                            ws.Cells[Rowx, 9].Value = " TR ";
                            ws.Cells[Rowx, 10].Value = " HariPtg ";
                            ws.Cells[Rowx, 11].Value = " Tgl JtTempo ";
                            ws.Cells[Rowx, 12].Value = " Tgl Inden ";
                            ws.Cells[Rowx, 13].Value = " Rp Tagih ";
                            ws.Cells[Rowx, 14].Value = " Total Pembayaran ";
                            ws.Cells[Rowx, 15].Value = " Rp Kas ";
                            ws.Cells[Rowx, 16].Value = " Rp Giro ";
                            ws.Cells[Rowx, 17].Value = " rp Trn ";
                            ws.Cells[Rowx, 18].Value = " 0-14 Hari ";
                            ws.Cells[Rowx, 19].Value = " 0,5% ";
                            ws.Cells[Rowx, 20].Value = " Ins 0-14 Hari ";
                            ws.Cells[Rowx, 21].Value = " Penjualan Tunai ";
                            ws.Cells[Rowx, 22].Value = " 0,5% ";
                            ws.Cells[Rowx, 23].Value = " Ins Pjl Tunai ";
                            ws.Cells[Rowx, 24].Value = " Total Insentif ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 10, Rowx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 13, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx += 1;
                            no = 0;
                        }
                    }

                    cNama = Tools.isNull(dr1["Nama"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["CollectorID"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoReg"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglReg"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
                    ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["HariPtg"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 11].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJtTempo"], ""));
                    ws.Cells[Rowx, 12].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglInden"], ""));
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["RpTagih"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpKas"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["RpGiro"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["RpTransfer"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx1"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["Persenfx1"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx2"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["Persenfx2"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx2"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx"], "0").ToString());
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jmlfx += Convert.ToDouble(Tools.isNull(dr1["Insfx"], "0").ToString());
                    Totfx += Convert.ToDouble(Tools.isNull(dr1["Insfx"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 3].Value = "Jumlah";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 24].Value = Tools.isNull(Jmlfx, 0);
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Style.Font.Bold = true;
                    ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                    Rowx++;

                    ws.Cells[Rowx, 3].Value = "Total";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 24].Value = Tools.isNull(Totfx, 0);
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Style.Font.Bold = true;
                    ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                        border1.Bottom.Style = ExcelBorderStyle.Thin;
                        border1.Top.Style =
                        border1.Left.Style =
                        border1.Right.Style = ExcelBorderStyle.None;
                    }
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            }
            #endregion


            #region detail denda retur

            ex.Workbook.Worksheets.Add("Detail denda retur");
            ws = ex.Workbook.Worksheets[4];
            ws.View.ShowGridLines = false;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 8;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no retur
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //tgl retur
            ws.Cells[1, 7].Worksheet.Column(7).Width = 30;      //nama toko
            ws.Cells[1, 8].Worksheet.Column(8).Width = 20;      //kota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //idwil
            ws.Cells[1, 10].Worksheet.Column(10).Width = 13;    //kode barang
            ws.Cells[1, 11].Worksheet.Column(11).Width = 13;    //nama barang
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;    //kategori
            ws.Cells[1, 13].Worksheet.Column(13).Width = 25;    //keterangan
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //rp retur

            nRow = 0; nHeader = 1; Rowx = 0;
            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Detail Retur";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Retur Barang BE & FX";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            nRow = nHeader;
            Rowx = nRow;
            MaxCol = 14;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Retur ";
            ws.Cells[Rowx, 6].Value = " Tgl Retur ";
            ws.Cells[Rowx, 7].Value = " Nama Toko ";
            ws.Cells[Rowx, 8].Value = " Kota ";
            ws.Cells[Rowx, 9].Value = " Idwil ";
            ws.Cells[Rowx, 10].Value = " Kode Barang ";
            ws.Cells[Rowx, 11].Value = " Nama Barang ";
            ws.Cells[Rowx, 12].Value = " Katagori ";
            ws.Cells[Rowx, 13].Value = " Keterangan ";
            ws.Cells[Rowx, 14].Value = " Rp Retur ";

            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 1;

            no = 0; Jrec = 0; nRec = 0;
            double Jmlret = 0, Totret = 0;
            cNama = ""; cAwal = "1";

            if (ds.Tables[7].Rows.Count > 0)
            {
                Jrec = ds.Tables[7].Rows.Count;
                foreach (DataRow dr1 in ds.Tables[7].Rows)
                {
                    nRec++;
                    if (cNama != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 3].Value = "Jumlah";
                            ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 14].Value = Tools.isNull(Jmlret, 0);
                            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 14].Style.Font.Bold = true;
                            ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                            Jmlret = 0;
                            Rowx++;

                            if (ds.Tables[7].Rows.Count > 0)
                            {
                                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                                border1.Bottom.Style = ExcelBorderStyle.Thin;
                                border1.Top.Style =
                                border1.Left.Style =
                                border1.Right.Style = ExcelBorderStyle.None;
                            }

                            Rowx++;
                            ws.Cells[Rowx, 2].Value = "Retur Barang BE & FX";
                            ws.Cells[Rowx, 2].Style.Font.Bold = true;
                            ws.Cells[Rowx, 2].Style.Font.Italic = true;
                            Rowx++;
                            nRow = Rowx;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Retur ";
                            ws.Cells[Rowx, 6].Value = " Tgl Retur ";
                            ws.Cells[Rowx, 7].Value = " Nama Toko ";
                            ws.Cells[Rowx, 8].Value = " Kota ";
                            ws.Cells[Rowx, 9].Value = " Idwil ";
                            ws.Cells[Rowx, 10].Value = " Kode Barang ";
                            ws.Cells[Rowx, 11].Value = " Nama Barang ";
                            ws.Cells[Rowx, 12].Value = " Katagori ";
                            ws.Cells[Rowx, 13].Value = " Keterangan ";
                            ws.Cells[Rowx, 14].Value = " Rp Retur ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx += 1;
                            no = 0;
                        }
                    }

                    cNama = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoNota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Idwil"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["BarangID"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["Kategori"], "").ToString();
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["Keterangan"], "").ToString();
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jmlret += Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
                    Totret += Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 3].Value = "Jumlah";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 14].Value = Tools.isNull(Jmlret, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                    Rowx++;

                    ws.Cells[Rowx, 3].Value = "Total";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 14].Value = Tools.isNull(Totret, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                        border1.Bottom.Style = ExcelBorderStyle.Thin;
                        border1.Top.Style =
                        border1.Left.Style =
                        border1.Right.Style = ExcelBorderStyle.None;
                    }
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            }

            #endregion


            #region Detail denda overdue

            ex.Workbook.Worksheets.Add("Detail denda overdue");
            ws = ex.Workbook.Worksheets[5];
            ws.View.ShowGridLines = false;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 8;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no retur
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //tgl retur
            ws.Cells[1, 7].Worksheet.Column(7).Width = 30;      //nama toko
            ws.Cells[1, 8].Worksheet.Column(8).Width = 20;      //kota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //idwil
            ws.Cells[1, 10].Worksheet.Column(10).Width = 5;     //TR
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //tgl terima
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //tgl jt tempo
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //umut piutang
            ws.Cells[1, 14].Worksheet.Column(14).Width = 15;    //saldo piutang
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //(%)denda
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //rp denda

            nRow = 0; nHeader = 1; Rowx = 0;
            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Detail Retur";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Denda Overdue Nota BE";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            nRow = nHeader;
            Rowx = nRow;
            MaxCol = 16;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Nota ";
            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            ws.Cells[Rowx, 7].Value = " Nama Toko ";
            ws.Cells[Rowx, 8].Value = " Kota ";
            ws.Cells[Rowx, 9].Value = " Idwil ";
            ws.Cells[Rowx, 10].Value = " TR ";
            ws.Cells[Rowx, 11].Value = " Tgl Terima ";
            ws.Cells[Rowx, 12].Value = " Tgl Jt.Tempo ";
            ws.Cells[Rowx, 13].Value = " Umur Piutang ";
            ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
            ws.Cells[Rowx, 15].Value = " Denda (%)";
            ws.Cells[Rowx, 16].Value = " Rp Denda ";

            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 1;

            no = 0; Jrec = 0; nRec = 0;
            double Jmldenda = 0, Totdenda = 0;
            cNama = ""; cAwal = "1";

            if (ds.Tables[8].Rows.Count > 0)
            {
                Jrec = ds.Tables[8].Rows.Count;
                foreach (DataRow dr1 in ds.Tables[8].Rows)
                {
                    nRec++;
                    if (cNama != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 3].Value = "Jumlah";
                            ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 16].Value = Tools.isNull(Jmldenda, 0);
                            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 16].Style.Font.Bold = true;
                            ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                            Jmldenda = 0;
                            Rowx++;

                            if (ds.Tables[8].Rows.Count > 0)
                            {
                                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                                border1.Bottom.Style = ExcelBorderStyle.Thin;
                                border1.Top.Style =
                                border1.Left.Style =
                                border1.Right.Style = ExcelBorderStyle.None;
                            }

                            Rowx++;
                            ws.Cells[Rowx, 2].Value = "Denda Overdue Nota BE";
                            ws.Cells[Rowx, 2].Style.Font.Bold = true;
                            ws.Cells[Rowx, 2].Style.Font.Italic = true;
                            Rowx++;
                            nRow = Rowx;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Nota ";
                            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                            ws.Cells[Rowx, 7].Value = " Nama Toko ";
                            ws.Cells[Rowx, 8].Value = " Kota ";
                            ws.Cells[Rowx, 9].Value = " Idwil ";
                            ws.Cells[Rowx, 10].Value = " TR ";
                            ws.Cells[Rowx, 11].Value = " Tgl Terima ";
                            ws.Cells[Rowx, 12].Value = " Tgl Jt.Tempo ";
                            ws.Cells[Rowx, 13].Value = " Umur Piutang ";
                            ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
                            ws.Cells[Rowx, 15].Value = " Denda (%)";
                            ws.Cells[Rowx, 16].Value = " Rp Denda ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx += 1;
                            no = 0;
                        }
                    }

                    cNama = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoSuratJalan"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglSuratJalan"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Idwil"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 11].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTerima"], ""));
                    ws.Cells[Rowx, 12].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJatuhTempo"], ""));
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["UmurPiutang"], "").ToString();
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Convert.ToInt32(Tools.isNull(dr1["Saldo"], "")).ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Tools.isNull(dr1["Persen"], "").ToString();
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Convert.ToInt32(Tools.isNull(dr1["RpDendaOvd"], "")).ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    Jmldenda += Convert.ToDouble(Tools.isNull(dr1["RpDendaOvd"], "0").ToString());
                    Totdenda += Convert.ToDouble(Tools.isNull(dr1["RpDendaOvd"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 3].Value = "Jumlah";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 16].Value = Tools.isNull(Jmldenda, 0);
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Style.Font.Bold = true;
                    ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                    Rowx++;

                    ws.Cells[Rowx, 3].Value = "Total";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 16].Value = Tools.isNull(Totdenda, 0);
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Style.Font.Bold = true;
                    ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                        border1.Bottom.Style = ExcelBorderStyle.Thin;
                        border1.Top.Style =
                        border1.Left.Style =
                        border1.Right.Style = ExcelBorderStyle.None;
                    }
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            }

            #endregion

            return ex;
        }

    }
}
