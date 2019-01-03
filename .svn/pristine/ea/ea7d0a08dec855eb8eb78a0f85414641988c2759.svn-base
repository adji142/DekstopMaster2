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
    public partial class frmLaporanInsentifPenagihanSales : ISA.Controls.BaseForm
    {
        public frmLaporanInsentifPenagihanSales()
        {
            InitializeComponent();
        }

        private void frmLaporanInsentifPenagihanSales_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                string periode = monthYearBox1.Year.ToString() + monthYearBox1.Month.ToString().PadLeft(2, '0');
                DateTime fromDate = new DateTime(int.Parse(monthYearBox1.Year.ToString()), int.Parse(monthYearBox1.Month.ToString().PadLeft(2, '0')), 1);
                DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_InsentifSales_Denda_FEB2017_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DisplayReportFeb2017(ds, fromDate, toDate);
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


        private void DisplayReportFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentifFeb2017(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifPenagihanSales";

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



        private ExcelPackage LapInsentifFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Insentif Penagihan Sales";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Penagihan Sales", "1147");

            ex.Workbook.Worksheets.Add("Rekap Insentif Penagihan Sales");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            #region Laporan rekap insentif Tagihan FX
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //omset real fx
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //omset fx
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //omset1
            ws.Cells[1, 8].Worksheet.Column(8).Width = 5;       //%1
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //insentif1
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //omset2
            ws.Cells[1, 11].Worksheet.Column(11).Width = 5;     //%2
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //insentif2
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //Jumlah

            int nRow = 0, nJudul = 1, nHeader = 0, Rowx = 0, MaxCol = 13;

            ws.Cells[nJudul, 2].Style.Font.Bold.ToString();
            ws.Cells[nJudul, 2].Value = "Laporan Penagihan BE & FX";
            ws.Cells[nJudul, 2].Style.Font.Size = 14;
            ws.Cells[nJudul, 2].Style.Font.Bold = true;
            ws.Cells[nJudul + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nJudul + 1, 2].Style.Font.Bold = false;
            ws.Cells[nJudul + 3, 2].Value = "Insentif Tagihan Nota Barang FX";
            ws.Cells[nJudul + 3, 2].Style.Font.Bold = true;
            ws.Cells[nJudul + 3, 2].Style.Font.Italic = true;

            Rowx = nJudul + 4;
            nHeader = Rowx;

            for (int i = 2; i <= 6; i++)
            {
                ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            }

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
            ws.Cells[Rowx + 2, 10].Value = " Pelunasan ";
            ws.Cells[Rowx + 2, 11].Value = " (%) ";
            ws.Cells[Rowx + 2, 12].Value = " Insentif ";
            ws.Cells[Rowx, 13].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx += 3;
            nRow = Rowx;

            int no = 0;
            double Jml = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetRealFX"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetFX"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Omset1"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    if (Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) > 0)
                    {
                        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Persen1"], "0").ToString());
                        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,###0.#0;";
                    }
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Omset2"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    if (Convert.ToDouble(Tools.isNull(dr1["Insentif2"], "0").ToString()) > 0)
                    {
                        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Persen2"], "0").ToString());
                        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,###0.#0;";
                    }
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif2"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";

                    Jml += (Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString()));

                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }
            }

            Rowx++;
            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            ws.Cells[Rowx, 12].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 12].Style.Font.Bold = true;

            ws.Cells[Rowx, 13].Value = Tools.isNull(Jml, 0);
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 13].Style.Font.Bold = true;

            var border = ws.Cells[nHeader, 2, nHeader + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = 
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
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

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            #endregion


            #region Laporan rekap insentif BE
            //Rowx += 2;
            //nRow = Rowx;
            //nHeader = 0;
            //MaxCol = 14;

            //ws.Cells[Rowx, 2].Value = "Kelompok Barang BE";
            //ws.Cells[Rowx, 2].Style.Font.Bold = true;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            //Rowx++;
            //nRow = Rowx;

            //for (int i = 2; i <= 7; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            //}

            //ws.Cells[Rowx, 8, Rowx + 1, 10].Merge = true;
            //ws.Cells[Rowx, 11, Rowx + 1, 13].Merge = true;
            //ws.Cells[Rowx, 14, Rowx + 2, 14].Merge = true;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Target Omset ";
            //ws.Cells[Rowx, 6].Value = " Omset BE ";
            //ws.Cells[Rowx, 7].Value = " Pelunasan ";
            //ws.Cells[Rowx, 8].Value = " Merek Part Station ";
            //ws.Cells[Rowx + 2, 8].Value = " Pelunasan ";
            //ws.Cells[Rowx + 2, 9].Value = " (%) ";
            //ws.Cells[Rowx + 2, 10].Value = " Insentif ";
            //ws.Cells[Rowx, 11].Value = " Non Part Station ";
            //ws.Cells[Rowx + 2, 11].Value = " Pelunasan ";
            //ws.Cells[Rowx + 2, 12].Value = " (%) ";
            //ws.Cells[Rowx + 2, 13].Value = " Insentif ";
            //ws.Cells[Rowx, 14].Value = " Jumlah ";

            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx += 3;

            //no = 0;
            //double nOmsetReal = 0, nOmsetBE = 0, nOmsetPS = 0, nInsentifPS = 0, nOmsetNonPS = 0, nInsentifNonPS = 0, nJumlahBE = 0;

            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[2].Rows)
            //    {
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetRealBE"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetPS"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["PersenPS"], "0").ToString());
            //        if (Convert.ToDouble(Tools.isNull(dr1["PersenPS"], "0").ToString()) > 0)
            //            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,###0.#0;";
            //        else
            //            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString());
            //        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["PersenNonPS"], "0").ToString());
            //        if (Convert.ToDouble(Tools.isNull(dr1["PersenNonPS"], "0").ToString()) > 0)
            //            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,###0.#0;";
            //        else
            //            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";

            //        nOmsetReal += Convert.ToDouble(Tools.isNull(dr1["OmsetRealBE"], "0").ToString());
            //        nOmsetBE += Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
            //        nOmsetPS += Convert.ToDouble(Tools.isNull(dr1["OmsetPS"], "0").ToString());
            //        nInsentifPS += Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString());
            //        nOmsetNonPS += Convert.ToDouble(Tools.isNull(dr1["OmsetNonPS"], "0").ToString());
            //        nInsentifNonPS += Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        nJumlahBE += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString()); ;

            //        //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
            //        Rowx++;
            //    }
            //}

            //Rowx++;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            //ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 4].Style.Font.Bold = true;

            //ws.Cells[Rowx, 6].Value = Tools.isNull(nOmsetReal, 0);
            //ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 6].Style.Font.Bold = true;

            //ws.Cells[Rowx, 7].Value = Tools.isNull(nOmsetBE, 0);
            //ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 7].Style.Font.Bold = true;

            //ws.Cells[Rowx, 8].Value = Tools.isNull(nOmsetPS, 0);
            //ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 8].Style.Font.Bold = true;

            //ws.Cells[Rowx, 10].Value = Tools.isNull(nInsentifPS, 0);
            //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 10].Style.Font.Bold = true;

            //ws.Cells[Rowx, 11].Value = Tools.isNull(nOmsetNonPS, 0);
            //ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 11].Style.Font.Bold = true;

            //ws.Cells[Rowx, 13].Value = Tools.isNull(nInsentifNonPS, 0);
            //ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 13].Style.Font.Bold = true;

            //ws.Cells[Rowx, 14].Value = Tools.isNull(nJumlahBE, 0);
            //ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 14].Style.Font.Bold = true;

            //border = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[nRow + 3, 2, Rowx - 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.None;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.Thin;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style = ExcelBorderStyle.Thin;
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 6, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //nHeader = Rowx;
            //Rowx += 1;

            //ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;
            //#endregion


            //#region Laporan rekap all
            //Rowx += 2;
            //nRow = Rowx;
            //nHeader = 0;

            //MaxCol = 13;
            //ws.Cells[Rowx, 2].Value = "REKAP INSENTIF SALES";
            //ws.Cells[Rowx, 2].Style.Font.Bold = true;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            //Rowx++;
            //nRow = Rowx;

            //for (int i = 2; i <= 7; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            //}
            //ws.Cells[Rowx, 8, Rowx, 11].Merge = true;
            //ws.Cells[Rowx, 12, Rowx + 1, 13].Merge = true;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Omset Real";
            //ws.Cells[Rowx, 6].Value = " Omset ";
            //ws.Cells[Rowx, 7].Value = " Insentif ";
            //ws.Cells[Rowx, 8].Value = " Retur Penjualan ";
            //ws.Cells[Rowx + 1, 8].Value = " Nominal(Rp) ";
            //ws.Cells[Rowx + 1, 9].Value = " (%) ";
            //ws.Cells[Rowx + 1, 10].Value = " Denda(%) ";
            //ws.Cells[Rowx + 1, 11].Value = " Denda(Rp) ";
            //ws.Cells[Rowx, 12].Value = " Insetif Netto";

            ////ws.Cells[Rowx, 12, Rowx, 13].Merge = true;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //Rowx += 2;
            //no = 0;
            //nOmsetReal = 0;
            //double nOmset = 0, nInsentif = 0, nRetur = 0, nDenda = 0, nInsentifNetto = 0;

            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[3].Rows)
            //    {
            //        ws.Cells[Rowx, 12, Rowx, 13].Merge = true;

            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetReal"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";

            //        if (Convert.ToDouble(Tools.isNull(dr1["PersenRetur"], "0").ToString()) > 0)
            //        {
            //            ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["PersenRetur"], "0").ToString());
            //            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,###0.#0;";
            //        }
            //        if (Convert.ToDouble(Tools.isNull(dr1["PersenDenda"], "0").ToString()) > 0)
            //        {
            //            ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["PersenDenda"], "0").ToString());
            //            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,###0.#0;";
            //        }

            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##)";
            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifNeto"], "0").ToString());
            //        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";

            //        nOmsetReal += Convert.ToDouble(Tools.isNull(dr1["OmsetReal"], "0").ToString());
            //        nOmset += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        nInsentif += Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
            //        nRetur += Convert.ToDouble(Tools.isNull(dr1["Retur"], "0").ToString());
            //        nDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //        nInsentifNetto += Convert.ToDouble(Tools.isNull(dr1["InsentifNeto"], "0").ToString());

            //        //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
            //        Rowx++;
            //    }
            //}
            //ws.Cells[Rowx, 12, Rowx, 13].Merge = true;
            //Rowx++;
            //ws.Cells[Rowx, 12, Rowx, 13].Merge = true;

            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            //ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //ws.Cells[Rowx, 4].Style.Font.Bold = true;

            //ws.Cells[Rowx, 5].Value = Tools.isNull(nOmsetReal, 0);
            //ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 5].Style.Font.Bold = true;

            //ws.Cells[Rowx, 6].Value = Tools.isNull(nOmset, 0);
            //ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 6].Style.Font.Bold = true;

            //ws.Cells[Rowx, 7].Value = Tools.isNull(nInsentif, 0);
            //ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 7].Style.Font.Bold = true;

            //ws.Cells[Rowx, 8].Value = Tools.isNull(nRetur, 0);
            //ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 8].Style.Font.Bold = true;

            //ws.Cells[Rowx, 11].Value = Tools.isNull(nDenda, 0);
            //ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 11].Style.Font.Bold = true;

            //ws.Cells[Rowx, 12].Value = Tools.isNull(nInsentifNetto, 0);
            //ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 12].Style.Font.Bold = true;

            //border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.None;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.Thin;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style = ExcelBorderStyle.Thin;
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 5, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //nHeader = Rowx;
            //Rowx += 1;

            //ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;
            #endregion


            #region Insentif OA
            //Rowx++;
            //Rowx++;
            //MaxCol = 10;

            //ws.Cells[Rowx, 2].Value = "REKAP INSENTIF OA";
            //ws.Cells[Rowx, 2].Style.Font.Bold = true;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            //Rowx++;
            //nRow = Rowx;

            //for (int i = 2; i <= 8; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            //}

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Target OA ";
            //ws.Cells[Rowx, 6].Value = " Insentif per OA ";
            //ws.Cells[Rowx, 7].Value = " Omset OA ";
            //ws.Cells[Rowx, 8].Value = " Jml OA ";
            //ws.Cells[Rowx, 9].Value = " Insentif OA ";

            //ws.Cells[Rowx, 9, Rowx + 1, 10].Merge = true;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //Rowx += 2;
            //no = 0;
            //double nInsentifOA = 0;

            //if (ds.Tables[8].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[8].Rows)
            //    {
            //        ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetOA"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["InsPerOA"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["JmlOA"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifOA"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

            //        nInsentifOA += Convert.ToDouble(Tools.isNull(dr1["InsentifOA"], "0").ToString());
            //        Rowx++;
            //    }
            //}
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //Rowx++;
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            //ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 4].Style.Font.Bold = true;

            //ws.Cells[Rowx, 9].Value = Tools.isNull(nInsentifOA, 0);
            //ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 9].Style.Font.Bold = true;

            //border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.None;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.Thin;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style = ExcelBorderStyle.Thin;
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //nHeader = Rowx;
            //Rowx += 1;

            //ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region InsentifOB
            //Rowx++;
            //Rowx++;
            //MaxCol = 10;

            //ws.Cells[Rowx, 2].Value = "REKAP INSENTIF OB";
            //ws.Cells[Rowx, 2].Style.Font.Bold = true;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            //Rowx++;
            //nRow = Rowx;

            //for (int i = 2; i <= 8; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            //}

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Target OB ";
            //ws.Cells[Rowx, 6].Value = " Insentif per OB ";
            //ws.Cells[Rowx, 7].Value = " Omset OB ";
            //ws.Cells[Rowx, 8].Value = " Jml OB ";
            //ws.Cells[Rowx, 9].Value = " Insentif OB ";

            //ws.Cells[Rowx, 9, Rowx + 1, 10].Merge = true;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //Rowx += 2;
            //no = 0;
            //double nInsentifOB = 0;

            //if (ds.Tables[9].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[9].Rows)
            //    {
            //        ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetOB"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["InsPerOB"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["JmlOB"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifOB"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

            //        nInsentifOB += Convert.ToDouble(Tools.isNull(dr1["InsentifOB"], "0").ToString());
            //        Rowx++;
            //    }
            //}
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //Rowx++;
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            //ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 4].Style.Font.Bold = true;

            //ws.Cells[Rowx, 9].Value = Tools.isNull(nInsentifOB, 0);
            //ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 9].Style.Font.Bold = true;

            //border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.None;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.Thin;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style = ExcelBorderStyle.Thin;
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //nHeader = Rowx;
            //Rowx += 1;

            //ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;


            #endregion


            #region Laporan Denda Sales
            //Rowx++;
            //Rowx++;
            //MaxCol = 10;

            //ws.Cells[Rowx, 2].Value = "REKAP DENDA";
            //ws.Cells[Rowx, 2].Style.Font.Bold = true;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            ////ws.Cells[Rowx, 8].Value = "PERSEN DENDA 1% PERBULAN";
            ////ws.Cells[Rowx, 8].Style.Font.Bold = true;
            ////ws.Cells[Rowx, 8].Style.Font.Italic = true;

            //Rowx++;
            //nRow = Rowx;

            //for (int i = 2; i <= 4; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            //}
            //ws.Cells[Rowx, 5, Rowx, 10].Merge = true;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " PERSEN DENDA 1% PERBULAN ";
            //ws.Cells[Rowx + 1, 5].Value = " Klp ";
            //ws.Cells[Rowx + 1, 6].Value = " Denda(Rp) ";
            //ws.Cells[Rowx + 1, 7].Value = " Klp ";
            //ws.Cells[Rowx + 1, 8].Value = " Denda(Rp) ";
            //ws.Cells[Rowx + 1, 9].Value = " Jumlah(Rp) ";

            //ws.Cells[Rowx + 1, 9, Rowx + 1, 10].Merge = true;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //Rowx += 2;
            //no = 0;
            //double OvdBE = 0, DendaBE = 0, OvdFX = 0, DendaFX = 0, JumlahDenda = 0;

            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[6].Rows)
            //    {
            //        ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["KlpBE"], "").ToString();
            //        ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["KlpFX"], "").ToString();
            //        ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString()) +
            //                                  Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

            //        DendaBE += Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString());
            //        DendaFX += Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString());
            //        JumlahDenda += (Convert.ToDouble(Tools.isNull(dr1["RpdendaBE"], "0").ToString()) +
            //                        Convert.ToDouble(Tools.isNull(dr1["RpdendaFX"], "0").ToString()));

            //        //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
            //        Rowx++;
            //    }
            //}
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //Rowx++;
            //ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            //ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 4].Style.Font.Bold = true;

            //ws.Cells[Rowx, 6].Value = Tools.isNull(DendaBE, 0);
            //ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 6].Style.Font.Bold = true;

            //ws.Cells[Rowx, 8].Value = Tools.isNull(DendaFX, 0);
            //ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 8].Style.Font.Bold = true;

            //ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahDenda, 0);
            //ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 9].Style.Font.Bold = true;

            //border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.None;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style = ExcelBorderStyle.Thin;
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style = ExcelBorderStyle.Thin;
            //border.Right.Style = ExcelBorderStyle.None;

            //border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            //nHeader = Rowx;
            //Rowx += 1;

            //ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region Laporan detail insentif
            //ex.Workbook.Worksheets.Add("Detail Insentif Sales");
            //ws = ex.Workbook.Worksheets[2];

            //ws.View.ShowGridLines = false;
            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 4;       //klp
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 14;      //target
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //omset real
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //omset insentif
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //Omset1
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 5;     //%
            //ws.Cells[1, 13].Worksheet.Column(13).Width = 14;    //insentif1
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //Omset2
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 5;     //%
            //ws.Cells[1, 16].Worksheet.Column(16).Width = 14;    //insentif2
            //ws.Cells[1, 17].Worksheet.Column(17).Width = 14;    //OmsetPS
            //ws.Cells[1, 18].Worksheet.Column(18).Width = 5;    //%
            //ws.Cells[1, 19].Worksheet.Column(19).Width = 14;    //insentifPS
            //ws.Cells[1, 20].Worksheet.Column(20).Width = 14;    //OmsetNonPS
            //ws.Cells[1, 21].Worksheet.Column(21).Width = 5;     //%
            //ws.Cells[1, 22].Worksheet.Column(22).Width = 14;    //insentifNonPS
            //ws.Cells[1, 23].Worksheet.Column(23).Width = 14;    //jumlah
            //ws.Cells[1, 24].Worksheet.Column(24).Width = 16;    //Kodebarang
            //ws.Cells[1, 25].Worksheet.Column(25).Width = 85;    //nama barang
            //ws.Cells[1, 26].Worksheet.Column(26).Width = 25;    //keterangan

            //nRow = 0;
            //nHeader = 0;
            //Rowx = 0;

            //nHeader++;
            //nHeader++;
            //nRow = nHeader + 3;
            //Rowx = nRow;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Insentif Sales Vs Pelunasan Pembayaran";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //MaxCol = 26;

            //for (int i = 2; i <= 10; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            //}
            //ws.Cells[Rowx, 11, Rowx, 13].Merge = true;
            //ws.Cells[Rowx + 1, 11, Rowx + 1, 13].Merge = true;

            //ws.Cells[Rowx, 14, Rowx + 1, 16].Merge = true;
            //ws.Cells[Rowx, 17, Rowx + 1, 19].Merge = true;
            //ws.Cells[Rowx, 20, Rowx + 1, 22].Merge = true;
            //for (int i = 23; i <= 26; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            //}

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " No Nota ";
            //ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            //ws.Cells[Rowx, 7].Value = " Klp ";
            //ws.Cells[Rowx, 8].Value = " Target ";
            //ws.Cells[Rowx, 9].Value = " Omset Real";
            //ws.Cells[Rowx, 10].Value = " Omset ";
            //ws.Cells[Rowx, 11].Value = " Penjualan Kredit FX ";
            //ws.Cells[Rowx + 1, 11].Value = " Sesuai Tempo ";
            //ws.Cells[Rowx + 2, 11].Value = " Omset ";
            //ws.Cells[Rowx + 2, 12].Value = " (%) ";
            //ws.Cells[Rowx + 2, 13].Value = " Insentif ";
            //ws.Cells[Rowx, 14].Value = " Penjualan Tunai FX ";
            //ws.Cells[Rowx + 2, 14].Value = " Omset ";
            //ws.Cells[Rowx + 2, 15].Value = " (%) ";
            //ws.Cells[Rowx + 2, 16].Value = " Insentif ";
            //ws.Cells[Rowx, 17].Value = " PartStation (BE) ";
            //ws.Cells[Rowx + 2, 17].Value = " Omset ";
            //ws.Cells[Rowx + 2, 18].Value = " (%) ";
            //ws.Cells[Rowx + 2, 19].Value = " Insentif ";
            //ws.Cells[Rowx, 20].Value = " Non PartStation (BE) ";
            //ws.Cells[Rowx + 2, 20].Value = " Omset ";
            //ws.Cells[Rowx + 2, 21].Value = " (%) ";
            //ws.Cells[Rowx + 2, 22].Value = " Insentif ";
            //ws.Cells[Rowx, 23].Value = " Jumlah ";
            //ws.Cells[Rowx, 24].Value = " Kode Barang ";
            //ws.Cells[Rowx, 25].Value = " Nama Barang ";
            //ws.Cells[Rowx, 26].Value = " Keterangan ";

            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //border = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;


            //Rowx += 3;

            //no = 0;
            //int Jrec = 0, nRec = 0;
            //double JmlInsentif = 0, TotInsentif = 0, Jmlfx = 0, Jmlbe = 0;
            //string cKodeSales = "";
            //string cKlp = "";
            //string cAwal = "1";

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Jrec = ds.Tables[0].Rows.Count;

            //    foreach (DataRow dr1 in ds.Tables[0].Rows)
            //    {
            //        nRec++;
            //        if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
            //        {
            //            if (cAwal != "1")
            //            {
            //                ws.Cells[Rowx, 22].Value = "Jumlah";
            //                ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Red);
            //                ws.Cells[Rowx, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //                ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlfx, 0);
            //                    Jmlfx = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlbe, 0);
            //                    Jmlbe = 0;
            //                }
            //                Rowx++;

            //                var border1 = ws.Cells[nRow, 2, Rowx - 1, 2].Style.Border;
            //                border1.Bottom.Style =
            //                border1.Top.Style = ExcelBorderStyle.None;
            //                border1.Left.Style = ExcelBorderStyle.Thin;
            //                border1.Right.Style = ExcelBorderStyle.None;

            //                border1 = ws.Cells[nRow, MaxCol, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style =
            //                border1.Top.Style =
            //                border1.Left.Style = ExcelBorderStyle.None;
            //                border1.Right.Style = ExcelBorderStyle.Thin;

            //                border1 = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            //                border1.Bottom.Style =
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.Thin;

            //                border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.None;

            //                border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, 2].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style = ExcelBorderStyle.None;
            //                border1.Left.Style = ExcelBorderStyle.Thin;
            //                border1.Right.Style = ExcelBorderStyle.None;

            //                border1 = ws.Cells[Rowx - 1, MaxCol, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style = ExcelBorderStyle.None;
            //                border1.Left.Style = ExcelBorderStyle.None;
            //                border1.Right.Style = ExcelBorderStyle.Thin;

            //                ws.Cells[Rowx, 23].Value = Tools.isNull(JmlInsentif, 0);
            //                ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //                Rowx++;
            //                Rowx++;
            //                nRow = Rowx;
            //                JmlInsentif = 0;


            //                for (int i = 2; i <= 10; i++)
            //                {
            //                    ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            //                }
            //                ws.Cells[Rowx, 11, Rowx, 13].Merge = true;
            //                ws.Cells[Rowx + 1, 11, Rowx + 1, 13].Merge = true;

            //                ws.Cells[Rowx, 14, Rowx + 1, 16].Merge = true;
            //                ws.Cells[Rowx, 17, Rowx + 1, 19].Merge = true;
            //                ws.Cells[Rowx, 20, Rowx + 1, 22].Merge = true;
            //                for (int i = 23; i <= 26; i++)
            //                {
            //                    ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            //                }

            //                ws.Cells[Rowx, 2].Value = " No ";
            //                ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //                ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //                ws.Cells[Rowx, 5].Value = " No Nota ";
            //                ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            //                ws.Cells[Rowx, 7].Value = " Klp ";
            //                ws.Cells[Rowx, 8].Value = " Target ";
            //                ws.Cells[Rowx, 9].Value = " Omset Real";
            //                ws.Cells[Rowx, 10].Value = " Omset ";
            //                ws.Cells[Rowx, 11].Value = " Penjualan Kredit FX ";
            //                ws.Cells[Rowx + 1, 11].Value = " Sesuai Tempo ";
            //                ws.Cells[Rowx + 2, 11].Value = " Omset ";
            //                ws.Cells[Rowx + 2, 12].Value = " (%) ";
            //                ws.Cells[Rowx + 2, 13].Value = " Insentif ";
            //                ws.Cells[Rowx, 14].Value = " Penjualan Tunai FX ";
            //                ws.Cells[Rowx + 2, 14].Value = " Omset ";
            //                ws.Cells[Rowx + 2, 15].Value = " (%) ";
            //                ws.Cells[Rowx + 2, 16].Value = " Insentif ";
            //                ws.Cells[Rowx, 17].Value = " PartStation (BE) ";
            //                ws.Cells[Rowx + 2, 17].Value = " Omset ";
            //                ws.Cells[Rowx + 2, 18].Value = " (%) ";
            //                ws.Cells[Rowx + 2, 19].Value = " Insentif ";
            //                ws.Cells[Rowx, 20].Value = " Non PartStation (BE) ";
            //                ws.Cells[Rowx + 2, 20].Value = " Omset ";
            //                ws.Cells[Rowx + 2, 21].Value = " (%) ";
            //                ws.Cells[Rowx + 2, 22].Value = " Insentif ";
            //                ws.Cells[Rowx, 23].Value = " Jumlah ";
            //                ws.Cells[Rowx, 24].Value = " Kode Barang ";
            //                ws.Cells[Rowx, 25].Value = " Nama Barang ";
            //                ws.Cells[Rowx, 26].Value = " Keterangan ";

            //                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //                border = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            //                border.Bottom.Style =
            //                border.Top.Style =
            //                border.Left.Style =
            //                border.Right.Style = ExcelBorderStyle.Thin;
            //                Rowx += 3;
            //                no = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (cKodeSales == Tools.isNull(dr1["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr1["Klp"], "").ToString())
            //            {
            //                ws.Cells[Rowx, 22].Value = "Jumlah";
            //                ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Red);
            //                ws.Cells[Rowx, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //                ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlfx, 0);
            //                    Jmlfx = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlbe, 0);
            //                    Jmlbe = 0;
            //                }
            //                Rowx++;
            //                no = 0;
            //            }
            //        }

            //        cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        cKlp = Tools.isNull(dr1["Klp"], "").ToString();
            //        string cLunas = Tools.isNull(dr1["Ket"], "").ToString();
            //        string cket = "";

            //        if (cLunas != "LUNAS")
            //        {
            //            cket = "Nota belum lunas";
            //        }
            //        else
            //        {
            //            DateTime dTglJt = Convert.ToDateTime(Tools.isNull(dr1["TglJthTempo"], DateTime.MinValue).ToString()).AddDays(3);
            //            DateTime dTglLn = Convert.ToDateTime(Tools.isNull(dr1["TglPelunasan"], DateTime.MinValue).ToString());
            //            if (dTglJt < dTglLn)
            //            {
            //                cket = "Tidak sesuai Tempo";
            //            }
            //            else
            //            {
            //                if (cKlp.Substring(1, 2) == "FX")
            //                {
            //                    if (Tools.isNull(dr1["FHarga"], "").ToString() == "")
            //                    {
            //                        cket = "Harga dibawah Standar";
            //                    }
            //                }
            //            }
            //        }

            //        cAwal = "0";
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoNota"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Klp"], "").ToString().Substring(1, 2);
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Target"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
            //        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Omset1"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["persen1"], "0").ToString());
            //        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString());
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Omset2"], "0").ToString());
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["persen2"], "0").ToString());
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,###0.#0";
            //        ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString());
            //        ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetPS"], "0").ToString());
            //        ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["PersenPS"], "0").ToString());
            //        ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,###0.#0";
            //        ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString());
            //        ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["PersenNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,###0.#0";
            //        ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) +
            //                                   Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString()) +
            //                                   Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString()) +
            //                                   Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 24].Value = Tools.isNull(dr1["BarangID"], "").ToString();
            //        ws.Cells[Rowx, 25].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
            //        ws.Cells[Rowx, 26].Value = cket;

            //        JmlInsentif += Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());

            //        TotInsentif += Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());

            //        if (Tools.isNull(dr1["Klp"], "").ToString() == "1FX")
            //        {
            //            Jmlfx += Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        }
            //        if (Tools.isNull(dr1["Klp"], "").ToString() == "2BE")
            //        {
            //            Jmlbe += Convert.ToDouble(Tools.isNull(dr1["Insentif1"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["insentif2"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifPS"], "0").ToString()) +
            //                     Convert.ToDouble(Tools.isNull(dr1["InsentifNonPS"], "0").ToString());
            //        }
            //        Rowx++;

            //    }

            //    if (nRec == Jrec)
            //    {
            //        ws.Cells[Rowx, 22].Value = "Jumlah";
            //        ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Red);
            //        ws.Cells[Rowx, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);
            //        if (cKlp == "1FX")
            //        {
            //            ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlfx, 0);
            //            Jmlfx = 0;
            //        }
            //        if (cKlp == "2BE")
            //        {
            //            ws.Cells[Rowx, 23].Value = Tools.isNull(Jmlbe, 0);
            //            Jmlbe = 0;
            //        }
            //        Rowx++;

            //        var border1 = ws.Cells[nRow, 2, Rowx - 1, 2].Style.Border;
            //        border1.Bottom.Style =
            //        border1.Top.Style = ExcelBorderStyle.None;
            //        border1.Left.Style = ExcelBorderStyle.Thin;
            //        border1.Right.Style = ExcelBorderStyle.None;

            //        border1 = ws.Cells[nRow, MaxCol, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style =
            //        border1.Top.Style =
            //        border1.Left.Style = ExcelBorderStyle.None;
            //        border1.Right.Style = ExcelBorderStyle.Thin;

            //        border1 = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            //        border1.Bottom.Style =
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.Thin;

            //        border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.None;

            //        border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, 2].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style = ExcelBorderStyle.None;
            //        border1.Left.Style = ExcelBorderStyle.Thin;
            //        border1.Right.Style = ExcelBorderStyle.None;

            //        border1 = ws.Cells[Rowx - 1, MaxCol, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style = ExcelBorderStyle.None;
            //        border1.Left.Style = ExcelBorderStyle.None;
            //        border1.Right.Style = ExcelBorderStyle.Thin;

            //        ws.Cells[Rowx, 23].Value = Tools.isNull(JmlInsentif, 0);
            //        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 23].Style.Font.Bold = true;

            //        ws.Cells[Rowx, 23].Value = Tools.isNull(JmlInsentif, 0);
            //        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //        Rowx++;

            //        ws.Cells[Rowx, 22].Value = "Total Insentif";
            //        ws.Cells[Rowx, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 23].Value = Tools.isNull(TotInsentif, 0);
            //        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 23].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);
            //    }

            //    Rowx += 1;
            //    nHeader = Rowx;
            //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            //}
            #endregion


            #region Laporan detail Retur
            //ex.Workbook.Worksheets.Add("Detail Retur");
            //ws = ex.Workbook.Worksheets[3];

            ////#region header
            //ws.View.ShowGridLines = false;
            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 4;       //klp
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //BarangID
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 80;      //NamaStok
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 4;     //satuan
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //QtyGudang
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //HargaJual
            //ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //nominal
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 30;    //Catatan
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 55;    //kategori + Keterangan

            //nRow = 0;
            //nHeader = 0;
            //Rowx = 0;

            //nHeader++;
            //nHeader++;
            //nRow = nHeader + 3;
            //Rowx = nRow;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Detail Retur";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //MaxCol = 15;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " No Retur ";
            //ws.Cells[Rowx, 6].Value = " Tgl Retur ";
            //ws.Cells[Rowx, 7].Value = " Klp ";
            //ws.Cells[Rowx, 8].Value = " Kode Barang ";
            //ws.Cells[Rowx, 9].Value = " Nama Stok ";
            //ws.Cells[Rowx, 10].Value = " Sat ";
            //ws.Cells[Rowx, 11].Value = " Qty Gudang ";
            //ws.Cells[Rowx, 12].Value = " Hrg Jual ";
            //ws.Cells[Rowx, 13].Value = " Rp Retur ";
            //ws.Cells[Rowx, 14].Value = " Catatan ";
            //ws.Cells[Rowx, 15].Value = " Kategori Retur ";

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx++;

            //no = 0; Jrec = 0; nRec = 0; Jmlfx = 0; Jmlbe = 0;
            //double JmlRetur = 0, TotRetur = 0;

            //cKodeSales = "";
            //cKlp = "";
            //cAwal = "1";

            //if (ds.Tables[4].Rows.Count > 0)
            //{
            //    Jrec = ds.Tables[4].Rows.Count;
            //    foreach (DataRow dr4 in ds.Tables[4].Rows)
            //    {
            //        nRec++;
            //        if (cKodeSales != Tools.isNull(dr4["KodeSales"], "").ToString())
            //        {
            //            if (cAwal != "1")
            //            {
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
            //                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Jmlfx = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
            //                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Jmlbe = 0;
            //                }

            //                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.None;
            //                ws.Cells[Rowx, 13].Value = Tools.isNull(JmlRetur, 0);
            //                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //                Rowx++;
            //                Rowx++;
            //                JmlRetur = 0;

            //                ws.Cells[Rowx, 2].Value = " No ";
            //                ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //                ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //                ws.Cells[Rowx, 5].Value = " No Retur ";
            //                ws.Cells[Rowx, 6].Value = " Tgl Retur ";
            //                ws.Cells[Rowx, 7].Value = " Klp ";
            //                ws.Cells[Rowx, 8].Value = " Kode Barang ";
            //                ws.Cells[Rowx, 9].Value = " Nama Stok ";
            //                ws.Cells[Rowx, 10].Value = " Sat ";
            //                ws.Cells[Rowx, 11].Value = " Qty Gudang ";
            //                ws.Cells[Rowx, 12].Value = " Hrg Jual ";
            //                ws.Cells[Rowx, 13].Value = " Rp Retur ";
            //                ws.Cells[Rowx, 14].Value = " Catatan ";
            //                ws.Cells[Rowx, 15].Value = " Kategori Retur ";

            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //                Rowx++;
            //                no = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (cKodeSales == Tools.isNull(dr4["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr4["Klp"], "").ToString())
            //            {
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
            //                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Jmlfx = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
            //                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Jmlbe = 0;
            //                }
            //                no = 0;
            //            }
            //        }

            //        cKodeSales = Tools.isNull(dr4["KodeSales"], "").ToString();
            //        cKlp = Tools.isNull(dr4["Klp"], "").ToString();
            //        cAwal = "0";
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr4["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr4["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr4["NoNotaRetur"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr4["TglNotaRetur"], ""));
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr4["Klp"], "").ToString().Substring(1, 2);
            //        ws.Cells[Rowx, 8].Value = Tools.isNull(dr4["BarangID"], "").ToString();
            //        ws.Cells[Rowx, 9].Value = Tools.isNull(dr4["NamaStok"], "").ToString();
            //        ws.Cells[Rowx, 10].Value = Tools.isNull(dr4["SatJual"], "").ToString();
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr4["QtyGudang"], "0").ToString());
            //        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr4["HrgJual"], "0").ToString());
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
            //        ws.Cells[Rowx, 14].Value = Tools.isNull(dr4["Catatan1"], "").ToString();
            //        ws.Cells[Rowx, 15].Value = Tools.isNull(dr4["Kategori"], "").ToString().Trim() + " - " + Tools.isNull(dr4["Keterangan"], "").ToString().Trim();

            //        JmlRetur += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
            //        TotRetur += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());

            //        if (Tools.isNull(dr4["Klp"], "").ToString() == "1FX")
            //        {
            //            Jmlfx += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
            //        }
            //        if (Tools.isNull(dr4["Klp"], "").ToString() == "2BE")
            //        {
            //            Jmlbe += Convert.ToDouble(Tools.isNull(dr4["Nominal"], "0").ToString());
            //        }
            //        Rowx++;
            //    }

            //    if (nRec == Jrec)
            //    {
            //        if (cKlp == "1FX")
            //        {
            //            ws.Cells[Rowx, 12].Value = "Jumlah";
            //            ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //            ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlfx, 0);
            //            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //            Rowx++;
            //            Jmlfx = 0;
            //        }
            //        if (cKlp == "2BE")
            //        {
            //            ws.Cells[Rowx, 12].Value = "Jumlah";
            //            ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //            ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            ws.Cells[Rowx, 13].Value = Tools.isNull(Jmlbe, 0);
            //            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //            Rowx++;
            //            Jmlbe = 0;
            //        }
            //        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.None;
            //        ws.Cells[Rowx, 13].Value = Tools.isNull(JmlRetur, 0);
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //        Rowx++;

            //        ws.Cells[Rowx, 12].Value = "Total Retur";
            //        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 13].Value = Tools.isNull(TotRetur, 0);
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 13].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);
            //    }

            //    Rowx += 1;
            //    nHeader = Rowx;
            //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            //}
            #endregion


            #region Laporan Detail Insentif OA
            //ex.Workbook.Worksheets.Add("Detail OA");
            //ws = ex.Workbook.Worksheets[4];

            ////#region header
            //ws.View.ShowGridLines = false;
            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kodesales
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //namasales
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 35;      //namatoko
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 25;      //kota
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 14;      //omset

            //nRow = 0;
            //nHeader = 0;
            //Rowx = 0;

            //nHeader++;
            //nHeader++;
            //nRow = nHeader + 3;
            //Rowx = nRow;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Insentif OA Detail";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //MaxCol = 8;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Nama Toko ";
            //ws.Cells[Rowx, 6].Value = " Kota ";
            //ws.Cells[Rowx, 7].Value = " Idwil ";
            //ws.Cells[Rowx, 8].Value = " Omset ";

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx++;

            //no = 0; Jrec = 0; nRec = 0;
            //double Jumlah = 0, Total = 0;
            //cKodeSales = ""; cAwal = "1"; 
            //string cKodeToko = "";

            //if (ds.Tables[10].Rows.Count > 0)
            //{
            //    Jrec = ds.Tables[10].Rows.Count;

            //    foreach (DataRow dr1 in ds.Tables[10].Rows)
            //    {
            //        nRec++;
            //        if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
            //        {
            //            if (cAwal != "1")
            //            {
            //                ws.Cells[Rowx, 7].Value = "Jumlah";
            //                ws.Cells[Rowx, 7].Style.Font.Color.SetColor(Color.Red);
            //                ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                ws.Cells[Rowx, 8].Value = Tools.isNull(Jumlah, 0);
            //                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 8].Style.Font.Bold = true;
            //                ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Blue);
            //                Rowx++;
            //                Jumlah = 0;

            //                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.None;
            //                Rowx++;
            //                Rowx++;

            //                ws.Cells[Rowx, 2].Value = " No ";
            //                ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //                ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //                ws.Cells[Rowx, 5].Value = " Nama Toko ";
            //                ws.Cells[Rowx, 6].Value = " Kota ";
            //                ws.Cells[Rowx, 7].Value = " Idwil ";
            //                ws.Cells[Rowx, 8].Value = " Omset ";

            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //                Rowx++;
            //                no = 0;
            //            }
            //        }

            //        cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        cAwal = "0";
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Idwil"], "").ToString();
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";

            //        Jumlah += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        Total += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        Rowx++;
            //    }

            //    if (nRec == Jrec)
            //    {
            //        ws.Cells[Rowx, 7].Value = "Jumlah";
            //        ws.Cells[Rowx, 7].Style.Font.Color.SetColor(Color.Red);
            //        ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 8].Value = Tools.isNull(Jumlah, 0);
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 8].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Blue);
            //        Rowx++;
            //        Jumlah = 0;

            //        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.None;

            //        ws.Cells[Rowx, 8].Value = Tools.isNull(Total, 0);
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 8].Style.Font.Bold = true;
            //        Rowx++;
            //    }

            //    Rowx += 1;
            //    nHeader = Rowx;
            //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            //}

            #endregion


            #region Laporan Detail Insentif OB
            //ex.Workbook.Worksheets.Add("Detail OB");
            //ws = ex.Workbook.Worksheets[5];

            ////#region header
            //ws.View.ShowGridLines = false;
            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kodesales
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //namasales
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 35;      //namatoko
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 25;      //kota
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 23;      //tglaktif
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //omset

            //nRow = 0;
            //nHeader = 0;
            //Rowx = 0;

            //nHeader++;
            //nHeader++;
            //nRow = nHeader + 3;
            //Rowx = nRow;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Insentif OA Detail";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //MaxCol = 9;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " Nama Toko ";
            //ws.Cells[Rowx, 6].Value = " Kota ";
            //ws.Cells[Rowx, 7].Value = " Idwil ";
            //ws.Cells[Rowx, 8].Value = " Tgl Aktif ";
            //ws.Cells[Rowx, 9].Value = " Omset ";

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx++;

            //no = 0; Jrec = 0; nRec = 0;
            //double JumlahOB = 0, TotalOB = 0;
            //cKodeSales = ""; cAwal = "1";

            //if (ds.Tables[11].Rows.Count > 0)
            //{
            //    Jrec = ds.Tables[11].Rows.Count;

            //    foreach (DataRow dr1 in ds.Tables[11].Rows)
            //    {
            //        nRec++;
            //        if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
            //        {
            //            if (cAwal != "1")
            //            {
            //                ws.Cells[Rowx, 8].Value = "Jumlah";
            //                ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Red);
            //                ws.Cells[Rowx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahOB, 0);
            //                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 9].Style.Font.Bold = true;
            //                ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Blue);
            //                Rowx++;
            //                JumlahOB = 0;

            //                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.None;
            //                Rowx++;
            //                Rowx++;

            //                ws.Cells[Rowx, 2].Value = " No ";
            //                ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //                ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //                ws.Cells[Rowx, 5].Value = " Nama Toko ";
            //                ws.Cells[Rowx, 6].Value = " Kota ";
            //                ws.Cells[Rowx, 7].Value = " Idwil ";
            //                ws.Cells[Rowx, 8].Value = " Tgl Aktif ";
            //                ws.Cells[Rowx, 9].Value = " Omset ";

            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //                Rowx++;
            //                no = 0;
            //            }
            //        }

            //        cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        cAwal = "0";
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Idwil"], "").ToString();
            //        ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglAktif"], ""));
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";

            //        JumlahOB += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        TotalOB += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
            //        Rowx++;
            //    }

            //    if (nRec == Jrec)
            //    {
            //        ws.Cells[Rowx, 8].Value = "Jumlah";
            //        ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Red);
            //        ws.Cells[Rowx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahOB, 0);
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 9].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Blue);
            //        Rowx++;
            //        Jumlah = 0;

            //        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.None;

            //        ws.Cells[Rowx, 9].Value = Tools.isNull(TotalOB, 0);
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 9].Style.Font.Bold = true;
            //        Rowx++;
            //    }

            //    Rowx += 1;
            //    nHeader = Rowx;
            //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            //}

            #endregion


            #region Laporan detail denda
            //ex.Workbook.Worksheets.Add("Detail Denda");
            //ws = ex.Workbook.Worksheets[4];

            ////#region header
            //ws.View.ShowGridLines = false;
            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kode sales
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 20;      //nama sales
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //tgl terima
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 13;      //tgl jatuh tempo
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //Klp
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 31;    //namatoko
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //kota
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 9;     //idwil
            //ws.Cells[1, 13].Worksheet.Column(13).Width = 5;     //transactiontype
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //Saldopiutang
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 14;    //Rpdenda
            //ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //tglcutoff 

            //nRow = 0;
            //nHeader = 0;
            //Rowx = 0;

            //nHeader++;
            //nHeader++;
            //nRow = nHeader + 3;
            //Rowx = nRow;
            //MaxCol = 15;

            //DateTime Tglcutoff = Convert.ToDateTime(Tools.isNull(ds.Tables[7].Rows[0]["TglCutoff"], DateTime.MinValue).ToString());

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Denda Tagihan";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 1, 14].Value = "Tgl Cutoff";
            //ws.Cells[nHeader + 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //ws.Cells[nHeader + 1, 15].Value = string.Format("{0:dd-MMM-yyyy}", Tglcutoff);
            //ws.Cells[nHeader + 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //ws.Cells[Rowx, 5].Value = " No Nota ";
            //ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            //ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            //ws.Cells[Rowx, 8].Value = " Tgl JtTempo ";
            //ws.Cells[Rowx, 9].Value = " Klp ";
            //ws.Cells[Rowx, 10].Value = " Nama Toko ";
            //ws.Cells[Rowx, 11].Value = " Kota ";
            //ws.Cells[Rowx, 12].Value = " Idwil ";
            //ws.Cells[Rowx, 13].Value = " TR ";
            //ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
            //ws.Cells[Rowx, 15].Value = " Denda(Rp) ";

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx++;

            //no = 0; Jrec = 0; nRec = 0;
            //double JmlDendaBE = 0, JmlDendaFX = 0, JmlDenda = 0, TotDenda = 0;
            //double JmlPiutgBE = 0, JmlPiutgFX = 0, JmlPiutg = 0, TotPiutg = 0;
            //cKodeSales = ""; cKlp = ""; cAwal = "1";

            //if (ds.Tables[7].Rows.Count > 0)
            //{
            //    Jrec = ds.Tables[7].Rows.Count;

            //    foreach (DataRow dr1 in ds.Tables[7].Rows)
            //    {
            //        nRec++;
            //        if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
            //        {
            //            if (cAwal != "1")
            //            {
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
            //                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //                    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
            //                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    JmlDendaFX = 0;
            //                    JmlPiutgFX = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
            //                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //                    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
            //                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    JmlDendaBE = 0;
            //                    JmlPiutgBE = 0;
            //                }

            //                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.Thin;
            //                border1.Top.Style =
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.None;
            //                ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutg, 0);
            //                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //                ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDenda, 0);
            //                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //                ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //                Rowx++;
            //                Rowx++;
            //                JmlDenda = 0;
            //                JmlPiutg = 0;

            //                ws.Cells[Rowx, 2].Value = " No ";
            //                ws.Cells[Rowx, 3].Value = " Kode Sales ";
            //                ws.Cells[Rowx, 4].Value = " Nama Sales ";
            //                ws.Cells[Rowx, 5].Value = " No Nota ";
            //                ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            //                ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            //                ws.Cells[Rowx, 8].Value = " Tgl JtTempo ";
            //                ws.Cells[Rowx, 9].Value = " Klp ";
            //                ws.Cells[Rowx, 10].Value = " Nama Toko ";
            //                ws.Cells[Rowx, 11].Value = " Kota ";
            //                ws.Cells[Rowx, 12].Value = " Idwil ";
            //                ws.Cells[Rowx, 13].Value = " TR ";
            //                ws.Cells[Rowx, 14].Value = " Saldo Piutang ";
            //                ws.Cells[Rowx, 15].Value = " Denda(Rp) ";

            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //                Rowx++;
            //                no = 0;
            //            }
            //        }
            //        else
            //        {
            //            if (cKodeSales == Tools.isNull(dr1["KodeSales"], "").ToString() && cKlp != Tools.isNull(dr1["Kode"], "").ToString())
            //            {
            //                if (cKlp == "1FX")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
            //                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //                    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
            //                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Rowx++;
            //                    JmlDendaFX = 0;
            //                    JmlPiutgFX = 0;
            //                }
            //                if (cKlp == "2BE")
            //                {
            //                    ws.Cells[Rowx, 12].Value = "Jumlah";
            //                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                    ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
            //                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //                    ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
            //                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //                    Rowx++;
            //                    Rowx++;
            //                    JmlDendaBE = 0;
            //                    JmlPiutgBE = 0;
            //                }
            //                no = 0;
            //            }
            //        }

            //        cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        cKlp = Tools.isNull(dr1["Kode"], "").ToString();
            //        cAwal = "0";
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
            //        ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTerima"], ""));
            //        ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJatuhTempo"], ""));
            //        ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Kode"], "").ToString().Substring(1, 2);
            //        ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
            //        ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["Kota"], "").ToString();
            //        ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["WilID"], "").ToString();
            //        ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
            //        ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";

            //        if (cKlp == "1FX")
            //        {
            //            JmlDendaFX += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            JmlDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            TotDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            JmlPiutgFX += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //            JmlPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //            TotPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //        }
            //        else
            //        {
            //            JmlDendaBE += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            JmlDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            TotDenda += Convert.ToDouble(Tools.isNull(dr1["RpDenda"], "0").ToString());
            //            JmlPiutgBE += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //            JmlPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //            TotPiutg += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
            //        }

            //        Rowx++;
            //    }

            //    if (nRec == Jrec)
            //    {
            //        if (cKlp == "1FX")
            //        {
            //            ws.Cells[Rowx, 12].Value = "Jumlah";
            //            ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //            ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgFX, 0);
            //            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //            ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaFX, 0);
            //            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //            Rowx++;
            //            JmlDendaFX = 0;
            //            JmlPiutgFX = 0;
            //        }

            //        if (cKlp == "2BE")
            //        {
            //            ws.Cells[Rowx, 12].Value = "Jumlah";
            //            ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Red);
            //            ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutgBE, 0);
            //            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //            ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDendaBE, 0);
            //            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //            ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //            ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //            Rowx++;
            //            JmlDendaBE = 0;
            //            JmlPiutgBE = 0;
            //        }

            //        var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            //        border1.Bottom.Style = ExcelBorderStyle.Thin;
            //        border1.Top.Style =
            //        border1.Left.Style =
            //        border1.Right.Style = ExcelBorderStyle.None;
            //        ws.Cells[Rowx, 14].Value = Tools.isNull(JmlPiutg, 0);
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDenda, 0);
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //        Rowx++;

            //        ws.Cells[Rowx, 12].Value = "TOTAL DENDA";
            //        ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 14].Value = Tools.isNull(TotPiutg, 0);
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 14].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);
            //        ws.Cells[Rowx, 15].Value = Tools.isNull(TotDenda, 0);
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 15].Style.Font.Bold = true;
            //        ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);
            //    }

            //    Rowx += 1;
            //    nHeader = Rowx;
            //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            //}
            #endregion
            return ex;
        }

    }
}
