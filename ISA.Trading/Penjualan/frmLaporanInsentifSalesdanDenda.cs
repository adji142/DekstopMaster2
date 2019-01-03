using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Trading.Penjualan
{
    public partial class frmLaporanInsentifSalesdanDenda : ISA.Controls.BaseForm
    {
        public frmLaporanInsentifSalesdanDenda()
        {
            InitializeComponent();
        }

        private void frmLaporanInsentifSalesdanDenda_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (rangePeriode.FromDate != null && rangePeriode.ToDate != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_InsentifSales_Denda_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DateTime fromDate = Convert.ToDateTime(rangePeriode.FromDate.ToString());
                        DateTime toDate = Convert.ToDateTime(rangePeriode.ToDate.ToString());
                        DisplayReport(ds, fromDate, toDate);
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
        }


        private void DisplayReport(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentif(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifSalesdanDenda";

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


        private ExcelPackage LapInsentif(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif Sales Vs Pelunasan Pembayaran";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Sales", "1147");

            ex.Workbook.Worksheets.Add("Insentif Sales");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            #region Laporan rekap insentif FX
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //target
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //omset
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //pelunasan
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //omset yg lunas <= 2 minggu
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //omset yg lunas > 2 minggu dan <= 4 minggu
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //insentif <= 2 minggu
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //insentif > 2 minggu dan <= 4 minggu
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //Jumlah insentif

            int nRow = 0, nHeader = 0, Rowx = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Insentif Sales Vs Pelunasan Pembayaran";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX";

                int MaxCol = 12;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Target Omset ";
                ws.Cells[Rowx, 6].Value = " Omset ";
                ws.Cells[Rowx, 7].Value = " Pelunasan ";
                ws.Cells[Rowx, 8].Value = " Lunas (<=2mg) ";
                ws.Cells[Rowx, 9].Value = " Penjualan Tunai ";
                ws.Cells[Rowx, 10].Value = " Insentif (1%) ";
                ws.Cells[Rowx, 11].Value = " Insentif (0,5%) ";
                ws.Cells[Rowx, 12].Value = " Total Insentif ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double Ins1 = 0, Ins2 = 0, Dnda = 0, Jml = 0;

                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Target"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Pembayaran"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Omset1"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Omset2"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif2"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());

                    Ins1 += Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString());
                    Ins2 += Convert.ToDouble(Tools.isNull(dr1["Insentif2"], "0").ToString());
                    Jml += (Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString()));

                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 10].Value = Tools.isNull(Ins1, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 11].Value = Tools.isNull(Ins2, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                ws.Cells[Rowx, 12].Value = Tools.isNull(Jml, 0);
                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 12].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

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

                border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan rekap insentif BE
            Rowx += 2;
            nRow = Rowx;
            ws.Cells[nRow, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[nRow, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[nRow, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[nRow, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[nRow, 5].Worksheet.Column(5).Width = 15;      //target
            ws.Cells[nRow, 6].Worksheet.Column(6).Width = 15;      //omset
            ws.Cells[nRow, 7].Worksheet.Column(7).Width = 15;      //Ins R2PS
            ws.Cells[nRow, 8].Worksheet.Column(8).Width = 15;      //Ins R2NP
            ws.Cells[nRow, 9].Worksheet.Column(9).Width = 15;      //Ins R4FB
            ws.Cells[nRow, 10].Worksheet.Column(10).Width = 15;    //Ins R4FE
            ws.Cells[nRow, 11].Worksheet.Column(11).Width = 15;    //Ins Jumlah

            nHeader = 0;
            //Rowx++ ;

            //#region Laporan
            if (ds.Tables[2].Rows.Count > 0)
            {
                int MaxCol = 11;
                ws.Cells[Rowx, 2].Value = "Kelompok Barang BE";
                Rowx++;
                nRow = Rowx;
                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Target Omset ";
                ws.Cells[Rowx, 6].Value = " Omset ";
                ws.Cells[Rowx, 7].Value = " Ins PS(6%) ";
                ws.Cells[Rowx, 8].Value = " Ins NonPS(4%) ";
                ws.Cells[Rowx, 9].Value = " Ins FB4(4%) ";
                ws.Cells[Rowx, 10].Value = " Ins FE4(5%) ";
                ws.Cells[Rowx, 11].Value = " Jumlah ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double r2ps = 0, r2np = 0, r4fb = 0, r4fe = 0,Jmlh = 0;

                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Target"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["InsR2PS"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["InsR2NP"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["InsR4FB"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["InsR4FE"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                    r2ps += Convert.ToDouble(Tools.isNull(dr1["InsR2PS"], "0").ToString());
                    r2np += Convert.ToDouble(Tools.isNull(dr1["InsR2NP"], "0").ToString());
                    r4fb += Convert.ToDouble(Tools.isNull(dr1["InsR4FB"], "0").ToString());
                    r4fe += Convert.ToDouble(Tools.isNull(dr1["InsR4FE"], "0").ToString());
                    Jmlh += Convert.ToDouble(Tools.isNull(dr1["InsR2PS"], "0").ToString()) +
                            Convert.ToDouble(Tools.isNull(dr1["InsR2NP"], "0").ToString()) +
                            Convert.ToDouble(Tools.isNull(dr1["InsR4FB"], "0").ToString()) +
                            Convert.ToDouble(Tools.isNull(dr1["InsR4FE"], "0").ToString());

                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 6].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 7].Value = Tools.isNull(r2ps, 0);
                ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 7].Style.Font.Bold = true;

                ws.Cells[Rowx, 8].Value = Tools.isNull(r2np, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                ws.Cells[Rowx, 9].Value = Tools.isNull(r4fb, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(r4fe, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 11].Value = Tools.isNull(Jmlh, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

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

                border = ws.Cells[Rowx, 7, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan rekap all
            Rowx += 2;
            nRow = Rowx;
            ws.Cells[nRow, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[nRow, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[nRow, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[nRow, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[nRow, 5].Worksheet.Column(5).Width = 15;      //target
            ws.Cells[nRow, 6].Worksheet.Column(6).Width = 15;      //omset
            ws.Cells[nRow, 7].Worksheet.Column(7).Width = 15;      //insentif <= 2 minggu
            ws.Cells[nRow, 8].Worksheet.Column(8).Width = 15;     //Jumlah insentif

            nHeader = 0;
            //Rowx++ ;

            //#region Laporan
            if (ds.Tables[3].Rows.Count > 0)
            {
                int MaxCol = 11;
                ws.Cells[Rowx, 2].Value = "REKAP";
                Rowx++;
                nRow = Rowx;
                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Omset ";
                ws.Cells[Rowx, 6].Value = " Insentif ";
                ws.Cells[Rowx, 7].Value = " Retur (Rp) ";
                ws.Cells[Rowx, 8].Value = " Retur (%) ";
                ws.Cells[Rowx, 9].Value = " Denda (%) ";
                ws.Cells[Rowx, 10].Value = " Denda (Rp) ";
                ws.Cells[Rowx, 11].Value = " Insetif Netto";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double Ins = 0, Ins2 = 0, Dnd = 0, Jml = 0;

                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["PersenRetur"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["PersenDenda"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,###.#0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifNeto"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                    Ins += Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    Ins2 += Convert.ToDouble(Tools.isNull(dr1["InsentifNeto"], "0").ToString());
                    Jml += Convert.ToDouble(Tools.isNull(dr1["InsentifNeto"], "0").ToString());
                    Dnd += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());

                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 6].Value = Tools.isNull(Ins, 0);
                ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 6].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(Dnd, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 11].Value = Tools.isNull(Jml, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

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

                border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan Denda Sales
            if (ds.Tables[6].Rows.Count > 0)
            {
                Rowx++;
                Rowx++;
                int MaxCol = 9;
                ws.Cells[Rowx, 2].Value = "REKAP DENDA";
                ws.Cells[Rowx, 8].Value = "PERSEN DENDA 1% PERBULAN";
                Rowx++;
                nRow = Rowx;
                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Klp ";
                ws.Cells[Rowx, 6].Value = " Denda(Rp) ";
                ws.Cells[Rowx, 7].Value = " Klp ";
                ws.Cells[Rowx, 8].Value = " Denda(Rp) ";
                ws.Cells[Rowx, 9].Value = " Jumlah(Rp) ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double OvdBE = 0, DendaBE = 0, OvdFX = 0, DendaFX = 0, JumlahDenda = 0;

                foreach (DataRow dr1 in ds.Tables[6].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["KlpBE"], "").ToString();
                    ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["KlpFX"], "").ToString();
                    ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString()) +
                                              Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";

                    DendaBE += Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
                    DendaFX += Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString());
                    JumlahDenda += (Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString()) +
                                    Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString()));

                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 6].Value = Tools.isNull(DendaBE, 0);
                ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 6].Style.Font.Bold = true;

                ws.Cells[Rowx, 8].Value = Tools.isNull(DendaFX, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahDenda, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

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

                border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan detail insenfit
            ex.Workbook.Worksheets.Add("Detail Insentif Sales");
            ws = ex.Workbook.Worksheets[2];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 4;       //klp
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //target
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //pelunasan
            ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //omset yg lunas <= 2 minggu
            ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //omset yg lunas > 2 minggu dan <= 3 minggu
            ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //insentif <= 2 minggu
            ws.Cells[1, 13].Worksheet.Column(13).Width = 14;    //insentif > 2 minggu dan <= 3 minggu
            ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //insentif R2PS
            ws.Cells[1, 15].Worksheet.Column(15).Width = 14;    //insentif R2NP
            ws.Cells[1, 16].Worksheet.Column(16).Width = 14;    //insentif R4FB
            ws.Cells[1, 17].Worksheet.Column(17).Width = 14;    //insentif R4FE
            ws.Cells[1, 18].Worksheet.Column(18).Width = 14;    //Jumlah insentif

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Insentif Sales Vs Pelunasan Pembayaran";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

                int MaxCol = 18;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " No Nota ";
                ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                ws.Cells[Rowx, 7].Value = " Klp ";
                ws.Cells[Rowx, 8].Value = " Target ";
                ws.Cells[Rowx, 9].Value = " Omset ";
                ws.Cells[Rowx, 10].Value = " Lunas (<=2mg) ";
                ws.Cells[Rowx, 11].Value = " Penjualan Tunai ";
                ws.Cells[Rowx, 12].Value = " Insentif (1%) ";
                ws.Cells[Rowx, 13].Value = " Insentif (0,5%) ";
                ws.Cells[Rowx, 14].Value = " Ins PS(6%) ";
                ws.Cells[Rowx, 15].Value = " Ins NonPS(4%) ";
                ws.Cells[Rowx, 16].Value = " Ins FB4(4%) ";
                ws.Cells[Rowx, 17].Value = " Ins FE4(5%) ";
                ws.Cells[Rowx, 18].Value = " Jumlah Insentif ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0, Jrec = 0, nRec = 0;
                double JmlInsentif = 0, TotInsentif = 0, Jmlfx = 0, Jmlbe = 0;
                string cKodeSales = "";
                string cKlp = "";
                string cAwal = "1";

                Jrec = ds.Tables[0].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 17].Value = "Jumlah";
                                ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlfx, 0);
                                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                                ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlfx = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 17].Value = "Jumlah";
                                ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlbe, 0);
                                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                                ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlbe = 0;
                            }

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            ws.Cells[Rowx, 18].Value = Tools.isNull(JmlInsentif, 0);
                            ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 18].Style.Font.Bold = true;
                            Rowx++;
                            Rowx++;
                            JmlInsentif = 0;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Nota ";
                            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                            ws.Cells[Rowx, 7].Value = " Klp ";
                            ws.Cells[Rowx, 8].Value = " Target ";
                            ws.Cells[Rowx, 9].Value = " Omset ";
                            ws.Cells[Rowx, 10].Value = " Lunas (<=2mg) ";
                            ws.Cells[Rowx, 11].Value = " Penjualan Tunai ";
                            ws.Cells[Rowx, 12].Value = " Insentif (1%) ";
                            ws.Cells[Rowx, 13].Value = " Insentif (0,5%) ";
                            ws.Cells[Rowx, 14].Value = " Ins PS(6%) ";
                            ws.Cells[Rowx, 15].Value = " Ins NonPS(4%) ";
                            ws.Cells[Rowx, 16].Value = " Ins FB4(4%) ";
                            ws.Cells[Rowx, 17].Value = " Ins FE4(5%) ";
                            ws.Cells[Rowx, 18].Value = " Jumlah Insentif ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                        }
                    }
                    else
                    {
                        if (cKodeSales == Tools.isNull(dr1["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr1["Klp"], "").ToString())
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 17].Value = "Jumlah";
                                ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlfx, 0);
                                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                                ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlfx = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 17].Value = "Jumlah";
                                ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlbe, 0);
                                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                                ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlbe = 0;
                            }
                        }
                    }

                    cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cKlp = Tools.isNull(dr1["Klp"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoNota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));

                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Klp"], "").ToString().Substring(1, 2);
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Target"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Omset1"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Omset2"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif2"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NominalR2PS"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NominalR2NP"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["NominalR4FB"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["NominalR4FE"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";

                    JmlInsentif += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    TotInsentif += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());

                    if (Tools.isNull(dr1["Klp"], "").ToString() == "1FX")
                    {
                        Jmlfx += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    }
                    if (Tools.isNull(dr1["Klp"], "").ToString() == "2BE")
                    {
                        Jmlbe += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    }
                    Rowx++;

                    #region ijo2
                    //if (nRec == Jrec)
                    //{
                    //    if (cKlp == "1FX")
                    //    {
                    //        ws.Cells[Rowx, 14].Value = "Jumlah";
                    //        ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Red);
                    //        ws.Cells[Rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    //        ws.Cells[Rowx, 15].Value = Tools.isNull(Jmlfx, 0);
                    //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    //        ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    //        ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                    //        Rowx++;
                    //        Jmlfx = 0;
                    //    }
                    //    if (cKlp == "2BE")
                    //    {
                    //        ws.Cells[Rowx, 14].Value = "Jumlah";
                    //        ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Red);
                    //        ws.Cells[Rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    //        ws.Cells[Rowx, 15].Value = Tools.isNull(Jmlbe, 0);
                    //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    //        ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    //        ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                    //        Rowx++;
                    //        Jmlbe = 0;
                    //    }
                    //    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    //    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    //    border1.Top.Style =
                    //    border1.Left.Style =
                    //    border1.Right.Style = ExcelBorderStyle.None;
                    //    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlInsentif, 0);
                    //    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    //    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    //    Rowx++;

                    //    ws.Cells[Rowx, 14].Value = "Total Insentif";
                    //    ws.Cells[Rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    //    ws.Cells[Rowx, 15].Value = Tools.isNull(TotInsentif, 0);
                    //    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    //    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    //    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                    //}
                    #endregion

                }

                if (nRec == Jrec)
                {
                    if (cKlp == "1FX")
                    {
                        ws.Cells[Rowx, 17].Value = "Jumlah";
                        ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlfx, 0);
                        ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 18].Style.Font.Bold = true;
                        ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        Jmlfx = 0;
                    }
                    if (cKlp == "2BE")
                    {
                        ws.Cells[Rowx, 17].Value = "Jumlah";
                        ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 18].Value = Tools.isNull(Jmlbe, 0);
                        ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 18].Style.Font.Bold = true;
                        ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        Jmlbe = 0;
                    }
                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;
                    ws.Cells[Rowx, 18].Value = Tools.isNull(JmlInsentif, 0);
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Style.Font.Bold = true;
                    Rowx++;

                    ws.Cells[Rowx, 17].Value = "Total Insentif";
                    ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 18].Value = Tools.isNull(TotInsentif, 0);
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Style.Font.Bold = true;
                    ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan detail Retur
            ex.Workbook.Worksheets.Add("Detail Retur");
            ws = ex.Workbook.Worksheets[3];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 4;       //klp
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //BarangID
            ws.Cells[1, 9].Worksheet.Column(9).Width = 80;      //NamaStok
            ws.Cells[1, 10].Worksheet.Column(10).Width = 4;     //satuan
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //QtyGudang
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //HargaJual
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //nominal
            ws.Cells[1, 14].Worksheet.Column(14).Width = 30;    //Catatan
            ws.Cells[1, 15].Worksheet.Column(15).Width = 55;    //kategori + Keterangan

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            if (ds.Tables[4].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Detail Retur";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

                int MaxCol = 15;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " No Retur ";
                ws.Cells[Rowx, 6].Value = " Tgl Retur ";
                ws.Cells[Rowx, 7].Value = " Klp ";
                ws.Cells[Rowx, 8].Value = " Kode Barang ";
                ws.Cells[Rowx, 9].Value = " Nama Stok ";
                ws.Cells[Rowx, 10].Value = " Sat ";
                ws.Cells[Rowx, 11].Value = " Qty Gudang ";
                ws.Cells[Rowx, 12].Value = " Hrg Jual ";
                ws.Cells[Rowx, 13].Value = " Rp Retur ";
                ws.Cells[Rowx, 14].Value = " Catatan ";
                ws.Cells[Rowx, 15].Value = " Kategori Retur ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0, Jrec = 0, nRec = 0;
                double JmlRetur = 0, TotRetur = 0, Jmlfx = 0, Jmlbe = 0;
                string cKodeSales = "";
                string cKlp = "";
                string cAwal = "1";

                Jrec = ds.Tables[4].Rows.Count;

                foreach (DataRow dr4 in ds.Tables[4].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr4["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
                                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 13].Style.Font.Bold = true;
                                ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlfx = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
                                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 13].Style.Font.Bold = true;
                                ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlbe = 0;
                            }

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            ws.Cells[Rowx, 13].Value = Tools.isNull(JmlRetur, 0);
                            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 13].Style.Font.Bold = true;
                            Rowx++;
                            Rowx++;
                            JmlRetur = 0;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Retur ";
                            ws.Cells[Rowx, 6].Value = " Tgl Retur ";
                            ws.Cells[Rowx, 7].Value = " Klp ";
                            ws.Cells[Rowx, 8].Value = " Kode Barang ";
                            ws.Cells[Rowx, 9].Value = " Nama Stok ";
                            ws.Cells[Rowx, 10].Value = " Sat ";
                            ws.Cells[Rowx, 11].Value = " Qty Gudang ";
                            ws.Cells[Rowx, 12].Value = " Hrg Jual ";
                            ws.Cells[Rowx, 13].Value = " Rp Retur ";
                            ws.Cells[Rowx, 14].Value = " Catatan ";
                            ws.Cells[Rowx, 15].Value = " Kategori Retur ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                        }
                    }
                    else
                    {
                        if (cKodeSales == Tools.isNull(dr4["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr4["Klp"], "").ToString())
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
                                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 13].Style.Font.Bold = true;
                                ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlfx = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
                                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 13].Style.Font.Bold = true;
                                ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Jmlbe = 0;
                            }
                        }
                    }

                    cKodeSales = Tools.isNull(dr4["KodeSales"], "").ToString();
                    cKlp = Tools.isNull(dr4["Klp"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr4["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr4["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr4["NoNotaRetur"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr4["TglNotaRetur"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr4["Klp"], "").ToString().Substring(1, 2);
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr4["BarangID"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr4["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr4["SatJual"], "").ToString();
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr4["QtyGudang"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr4["HrgJual"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
                    ws.Cells[Rowx, 14].Value = Tools.isNull(dr4["Catatan1"], "").ToString();
                    ws.Cells[Rowx, 15].Value = Tools.isNull(dr4["Kategori"], "").ToString().Trim() + " - " + Tools.isNull(dr4["Keterangan"], "").ToString().Trim();

                    JmlRetur += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
                    TotRetur += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());

                    if (Tools.isNull(dr4["Klp"], "").ToString() == "1FX")
                    {
                        Jmlfx += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
                    }
                    if (Tools.isNull(dr4["Klp"], "").ToString() == "2BE")
                    {
                        Jmlbe += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
                    }
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    if (cKlp == "1FX")
                    {
                        ws.Cells[Rowx, 12].Value = "Jumlah";
                        ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
                        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 13].Style.Font.Bold = true;
                        ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        Jmlfx = 0;
                    }
                    if (cKlp == "2BE")
                    {
                        ws.Cells[Rowx, 12].Value = "Jumlah";
                        ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
                        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 13].Style.Font.Bold = true;
                        ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        Jmlbe = 0;
                    }
                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;
                    ws.Cells[Rowx, 13].Value = Tools.isNull(JmlRetur, 0);
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
                    Rowx++;

                    ws.Cells[Rowx, 12].Value = "Total Retur";
                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 13].Value = Tools.isNull(TotRetur, 0);
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            }
            #endregion


            #region Laporan detail denda
            ex.Workbook.Worksheets.Add("Detail Denda");
            ws = ex.Workbook.Worksheets[4];

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Nota ";
            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            ws.Cells[Rowx, 8].Value = " Tgl JtTempo ";
            ws.Cells[Rowx, 9].Value = " Klp ";
            ws.Cells[Rowx, 10].Value = " Nama Toko ";
            ws.Cells[Rowx, 11].Value = " Kota ";
            ws.Cells[Rowx, 12].Value = " Idwil ";
            ws.Cells[Rowx, 13].Value = " TR ";
            ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
            ws.Cells[Rowx, 15].Value = " Denda(Rp) ";
            ws.Cells[Rowx, 16].Value = " Tgl Cutoff ";


            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 20;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //tgl terima
            ws.Cells[1, 8].Worksheet.Column(8).Width = 13;      //tgl jatuh tempo
            ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //Klp
            ws.Cells[1, 10].Worksheet.Column(10).Width = 31;    //namatoko
            ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //kota
            ws.Cells[1, 12].Worksheet.Column(12).Width = 9;     //idwil
            ws.Cells[1, 13].Worksheet.Column(13).Width = 5;     //transactiontype
            ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //Saldopiutang
            ws.Cells[1, 15].Worksheet.Column(15).Width = 14;    //Rpdenda
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //tglcutoff 

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            if (ds.Tables[7].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                DateTime Tglcutoff = Convert.ToDateTime(Tools.isNull(ds.Tables[7].Rows[0]["TglCutoff"], DateTime.MinValue).ToString());

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Denda Tagihan";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 1, 14].Value = "Tgl Cutoff";
                ws.Cells[nHeader + 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[nHeader + 1, 15].Value = string.Format("{0:dd-MMM-yyyy}", Tglcutoff);
                ws.Cells[nHeader + 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                int MaxCol = 15;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " No Nota ";
                ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                ws.Cells[Rowx, 7].Value = " Tgl Terima ";
                ws.Cells[Rowx, 8].Value = " Tgl JtTempo ";
                ws.Cells[Rowx, 9].Value = " Klp ";
                ws.Cells[Rowx, 10].Value = " Nama Toko ";
                ws.Cells[Rowx, 11].Value = " Kota ";
                ws.Cells[Rowx, 12].Value = " Idwil ";
                ws.Cells[Rowx, 13].Value = " TR ";
                ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
                ws.Cells[Rowx, 15].Value = " Denda(Rp) ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0, Jrec = 0, nRec = 0;
                double JmlDendaBE = 0, JmlDendaFX = 0, JmlDenda = 0, TotDenda = 0;
                double JmlPiutgBE = 0, JmlPiutgFX = 0, JmlPiutg = 0, TotPiutg = 0;
                string cKodeSales = "";
                string cKlp = "";
                string cAwal = "1";

                Jrec = ds.Tables[7].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[7].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
                                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                                ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                                ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
                                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 15].Style.Font.Bold = true;
                                ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                JmlDendaFX = 0;
                                JmlPiutgFX = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
                                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                                ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                                ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
                                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 15].Style.Font.Bold = true;
                                ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                JmlDendaBE = 0;
                                JmlPiutgBE = 0;
                            }

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutg, 0);
                            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 14].Style.Font.Bold = true;
                            ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDenda, 0);
                            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 15].Style.Font.Bold = true;
                            Rowx++;
                            Rowx++;
                            JmlDenda = 0;
                            JmlPiutg = 0;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Nota ";
                            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
                            ws.Cells[Rowx, 8].Value = " Tgl JtTempo ";
                            ws.Cells[Rowx, 9].Value = " Klp ";
                            ws.Cells[Rowx, 10].Value = " Nama Toko ";
                            ws.Cells[Rowx, 11].Value = " Kota ";
                            ws.Cells[Rowx, 12].Value = " Idwil ";
                            ws.Cells[Rowx, 13].Value = " TR ";
                            ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
                            ws.Cells[Rowx, 15].Value = " Denda(Rp) ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                        }
                    }
                    else
                    {
                        if (cKodeSales == Tools.isNull(dr1["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr1["Kode"], "").ToString())
                        {
                            if (cKlp == "1FX")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
                                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                                ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                                ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
                                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 15].Style.Font.Bold = true;
                                ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Rowx++;
                                JmlDendaFX = 0;
                                JmlPiutgFX = 0;
                            }
                            if (cKlp == "2BE")
                            {
                                ws.Cells[Rowx, 12].Value = "Jumlah";
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
                                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                                ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                                ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
                                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 15].Style.Font.Bold = true;
                                ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                                Rowx++;
                                Rowx++;
                                JmlDendaBE = 0;
                                JmlPiutgBE = 0;
                            }
                        }
                    }

                    cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cKlp = Tools.isNull(dr1["Kode"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
                    ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTerima"], ""));
                    ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJatuhTempo"], ""));
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Kode"], "").ToString().Substring(1, 2);
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["WilID"], "").ToString();
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";

                    if (cKlp == "1FX")
                    {
                        JmlDendaFX += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        JmlDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        TotDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        JmlPiutgFX += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                        JmlPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                        TotPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                    }
                    else
                    {
                        JmlDendaBE += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        JmlDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        TotDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
                        JmlPiutgBE += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                        JmlPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                        TotPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                    }

                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    if (cKlp == "1FX")
                    {
                        ws.Cells[Rowx, 12].Value = "Jumlah";
                        ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
                        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 14].Style.Font.Bold = true;
                        ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                        ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
                        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 15].Style.Font.Bold = true;
                        ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        JmlDendaFX = 0;
                        JmlPiutgFX = 0;
                    }

                    if (cKlp == "2BE")
                    {
                        ws.Cells[Rowx, 12].Value = "Jumlah";
                        ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
                        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
                        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 14].Style.Font.Bold = true;
                        ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                        ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
                        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 15].Style.Font.Bold = true;
                        ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
                        Rowx++;
                        JmlDendaBE = 0;
                        JmlPiutgBE = 0;
                    }

                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;
                    ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutg, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDenda, 0);
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    Rowx++;

                    ws.Cells[Rowx, 12].Value = "TOTAL DENDA";
                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 14].Value = Tools.isNull(TotPiutg, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
                    ws.Cells[Rowx, 15].Value = Tools.isNull(TotDenda, 0);
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
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
