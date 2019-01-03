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
    public partial class frmLaporanInsentifOAdanOB : ISA.Controls.BaseForm
    {
        public frmLaporanInsentifOAdanOB()
        {
            InitializeComponent();
        }

        private void frmLaporanInsentifOAdanOB_Load(object sender, EventArgs e)
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

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_InsentifOAOB_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayReportInsentifOAOB(ds, fromDate, toDate);
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


        private void DisplayReportInsentifOAOB(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentifOAOB(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_Insentif_OAOB";

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



        private ExcelPackage LapInsentifOAOB(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif OA dan OB";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif OA dan OB", "1147");

            ex.Workbook.Worksheets.Add("Rekap Insentif OA");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;


            #region Laporan rekap insentif OA

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //target OA
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //insentif per OA
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //omset
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //jmlOA
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //insentifOA

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif OA dan OB";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FB";
            ws.Cells[nHeader + 2, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 4;
            Rowx = nRow;
            int MaxCol = 9;

            ws.Cells[Rowx, 2].Value = "REKAP INSENTIF OA";
            ws.Cells[Rowx, 2].Style.Font.Bold = true;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            Rowx++;
            nRow = Rowx;

            for (int i = 2; i <= 9; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Target OA ";
            ws.Cells[Rowx, 6].Value = " Insentif per OA ";
            ws.Cells[Rowx, 7].Value = " Omset OA ";
            ws.Cells[Rowx, 8].Value = " Jml OA ";
            ws.Cells[Rowx, 9].Value = " Insentif OA ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double nInsentifOA = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetOA"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["InsPerOA"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["JmlOA"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifOA"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

                    nInsentifOA += Convert.ToDouble(Tools.isNull(dr1["InsentifOA"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = Tools.isNull(nInsentifOA, 0);
            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

            var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
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

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion


            #region InsentifOB
            Rowx++;
            Rowx++;
            MaxCol = 9;

            ws.Cells[Rowx, 2].Value = "REKAP INSENTIF OB";
            ws.Cells[Rowx, 2].Style.Font.Bold = true;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            Rowx++;
            nRow = Rowx;

            for (int i = 2; i <= 9; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Target OB ";
            ws.Cells[Rowx, 6].Value = " Insentif per OB ";
            ws.Cells[Rowx, 7].Value = " Omset OB ";
            ws.Cells[Rowx, 8].Value = " Jml OB ";
            ws.Cells[Rowx, 9].Value = " Insentif OB ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            no = 0;
            double nInsentifOB = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetOB"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["InsPerOB"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["JmlOB"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["InsentifOB"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";

                    nInsentifOB += Convert.ToDouble(Tools.isNull(dr1["InsentifOB"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = Tools.isNull(nInsentifOB, 0);
            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

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

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;
            #endregion


            #region Laporan Detail Insentif OA

            ex.Workbook.Worksheets.Add("Detail OA");
            ws = ex.Workbook.Worksheets[2];
            ws.View.ShowGridLines = false;

            nRow = 0; nHeader = 1; Rowx = 0;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif OA Detail";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nHeader += 3;
            nRow = nHeader;
            Rowx = nRow;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kodesales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //namasales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 35;      //namatoko
            ws.Cells[1, 6].Worksheet.Column(6).Width = 25;      //kota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            ws.Cells[1, 8].Worksheet.Column(8).Width = 14;      //omset

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Nama Toko ";
            ws.Cells[Rowx, 6].Value = " Kota ";
            ws.Cells[Rowx, 7].Value = " Idwil ";
            ws.Cells[Rowx, 8].Value = " Omset ";

            MaxCol = 8;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            no = 0;
            int Jrec = 0, nRec = 0;
            double Jumlah = 0, Total = 0;
            string cKodeSales = "", cAwal = "1", cKodeToko = "";

            if (ds.Tables[2].Rows.Count > 0)
            {
                Jrec = ds.Tables[2].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 7].Value = "Jumlah";
                            ws.Cells[Rowx, 7].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 8].Value = Tools.isNull(Jumlah, 0);
                            ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 8].Style.Font.Bold = true;
                            ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Blue);
                            Rowx++;
                            Jumlah = 0;

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            Rowx++;
                            Rowx++;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " Nama Toko ";
                            ws.Cells[Rowx, 6].Value = " Kota ";
                            ws.Cells[Rowx, 7].Value = " Idwil ";
                            ws.Cells[Rowx, 8].Value = " Omset ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                            no = 0;
                        }
                    }

                    cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Idwil"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jumlah += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    Total += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 7].Value = "Jumlah";
                    ws.Cells[Rowx, 7].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 8].Value = Tools.isNull(Jumlah, 0);
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Style.Font.Bold = true;
                    ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Blue);
                    Rowx++;
                    Jumlah = 0;

                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;

                    ws.Cells[Rowx, 8].Value = Tools.isNull(Total, 0);
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Style.Font.Bold = true;
                    Rowx++;
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            }

            #endregion


            #region Laporan Detail Insentif OB

            ex.Workbook.Worksheets.Add("Detail OB");
            ws = ex.Workbook.Worksheets[3];
            ws.View.ShowGridLines = false;

            nRow = 0; nHeader = 1; Rowx = 0;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif OB Detail";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nHeader += 3;
            nRow = nHeader;
            Rowx = nRow;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //kodesales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 30;      //namasales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 35;      //namatoko
            ws.Cells[1, 6].Worksheet.Column(6).Width = 25;      //kota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            ws.Cells[1, 8].Worksheet.Column(8).Width = 23;      //tglaktif
            ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //omset

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " Nama Toko ";
            ws.Cells[Rowx, 6].Value = " Kota ";
            ws.Cells[Rowx, 7].Value = " Idwil ";
            ws.Cells[Rowx, 8].Value = " Tgl Aktif ";
            ws.Cells[Rowx, 9].Value = " Omset ";

            MaxCol = 9;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            no = 0; Jrec = 0; nRec = 0;
            double JumlahOB = 0, TotalOB = 0;
            cKodeSales = ""; cAwal = "1";

            if (ds.Tables[3].Rows.Count > 0)
            {
                Jrec = ds.Tables[3].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[3].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 8].Value = "Jumlah";
                            ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahOB, 0);
                            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 9].Style.Font.Bold = true;
                            ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Blue);
                            Rowx++;
                            JumlahOB = 0;

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            Rowx++;
                            Rowx++;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " Nama Toko ";
                            ws.Cells[Rowx, 6].Value = " Kota ";
                            ws.Cells[Rowx, 7].Value = " Idwil ";
                            ws.Cells[Rowx, 8].Value = " Tgl Aktif ";
                            ws.Cells[Rowx, 9].Value = " Omset ";

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                            no = 0;
                        }
                    }

                    cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Idwil"], "").ToString();
                    ws.Cells[Rowx, 8].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglAktif"], ""));
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";

                    JumlahOB += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    TotalOB += Convert.ToDouble(Tools.isNull(dr1["Omset"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 8].Value = "Jumlah";
                    ws.Cells[Rowx, 8].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 9].Value = Tools.isNull(JumlahOB, 0);
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Style.Font.Bold = true;
                    ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Blue);
                    Rowx++;
                    Jumlah = 0;

                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;

                    ws.Cells[Rowx, 9].Value = Tools.isNull(TotalOB, 0);
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Style.Font.Bold = true;
                    Rowx++;
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mo nyetak");
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mbuh");
        }

        private void cmdPrint_Click(object sender, EventArgs e)
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
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_InsentifOAOB_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayReportInsentifOAOB(ds, fromDate, toDate);
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

    }
}
