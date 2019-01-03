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

namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmRptPerformanceSalesman : ISA.Controls.BaseForm
    {
        public frmRptPerformanceSalesman()
        {
            InitializeComponent();
        }

        private void frmRptPerformanceSalesman_Load(object sender, EventArgs e)
        {
            int thn = GlobalVar.DateTimeOfServer.Year;
            int bln = GlobalVar.DateTimeOfServer.Month;
            DateTime D1 = new DateTime(thn, bln, 1);
            rdbTgl.FromDate = D1;
            rdbTgl.ToDate = GlobalVar.DateTimeOfServer;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse(rdbTgl.FromDate.ToString());
            DateTime d2 = DateTime.Parse(rdbTgl.ToDate.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_PerformanceSales"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    DisplayReportPerformanceSalesman(dt, d1, d2);
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

        public void DisplayReportPerformanceSalesman(DataTable dt, DateTime d1, DateTime d2)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapPerformanceSalesman(dt, d1, d2));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_PerformanceSalesman";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    //Process.Start(sf.FileName.ToString());
                    Email.Send("Performance Salesman", file);
                }
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void DisplayReportPerformanceSalesmanAuto(string fileName, DataTable dt, DateTime d1, DateTime d2)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapPerformanceSalesman(dt, d1, d2));
                string dir = "C:\\Temp\\";
                string file = dir + fileName + ".xlsx";
                Byte[] bin1 = exs[0].GetAsByteArray();
                File.WriteAllBytes(file, bin1);
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage LapPerformanceSalesman(DataTable dt, DateTime d1, DateTime d2)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Performance Salesman";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Performance Salesman", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 6;       //cab
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      //sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //rqbe
            ws.Cells[1, 6].Worksheet.Column(6).Width = 10;      //rqfx
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //totalrq

            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //dobe
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //dofx
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //totaldo
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //skube
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;    //skufx
            ws.Cells[1, 13].Worksheet.Column(13).Width = 10;    //totalsku
            ws.Cells[1, 14].Worksheet.Column(14).Width = 10;    //oabe
            ws.Cells[1, 15].Worksheet.Column(15).Width = 10;    //oafx
            ws.Cells[1, 16].Worksheet.Column(16).Width = 10;    //totaloa
            ws.Cells[1, 17].Worksheet.Column(17).Width = 2;     //kosong

            ws.Cells[1, 18].Worksheet.Column(18).Width = 10;    //notabe
            ws.Cells[1, 19].Worksheet.Column(19).Width = 10;    //notafx
            ws.Cells[1, 20].Worksheet.Column(20).Width = 10;    //totalnota
            ws.Cells[1, 21].Worksheet.Column(21).Width = 10;    //skunotabe
            ws.Cells[1, 22].Worksheet.Column(22).Width = 10;    //skunotafx
            ws.Cells[1, 23].Worksheet.Column(23).Width = 10;    //totalnotasku
            ws.Cells[1, 24].Worksheet.Column(24).Width = 10;    //oanotabe
            ws.Cells[1, 25].Worksheet.Column(25).Width = 10;    //oanotafx
            ws.Cells[1, 26].Worksheet.Column(26).Width = 10;    //totalnotaoa
            ws.Cells[1, 27].Worksheet.Column(27).Width = 2;     //kosong

            ws.Cells[1, 28].Worksheet.Column(28).Width = 10;    //itembe
            ws.Cells[1, 29].Worksheet.Column(29).Width = 10;    //qtybe
            ws.Cells[1, 30].Worksheet.Column(30).Width = 10;    //nombobe
            ws.Cells[1, 31].Worksheet.Column(31).Width = 10;    //itemfx
            ws.Cells[1, 32].Worksheet.Column(32).Width = 10;    //qtyfx
            ws.Cells[1, 33].Worksheet.Column(33).Width = 10;    //nombofx
            ws.Cells[1, 34].Worksheet.Column(34).Width = 10;    //itemtolakbe
            ws.Cells[1, 35].Worksheet.Column(35).Width = 10;    //qtytolakbe
            ws.Cells[1, 36].Worksheet.Column(36).Width = 10;    //nomtolakbe
            ws.Cells[1, 37].Worksheet.Column(37).Width = 10;    //itemtolakfx
            ws.Cells[1, 38].Worksheet.Column(38).Width = 10;    //qtytolakfx
            ws.Cells[1, 39].Worksheet.Column(39).Width = 10;    //nomtolakfx
            ws.Cells[1, 40].Worksheet.Column(40).Width = 10;    //pendingbe
            ws.Cells[1, 41].Worksheet.Column(41).Width = 10;    //pendingfx
            ws.Cells[1, 42].Worksheet.Column(42).Width = 2;     //kosong

            ws.Cells[1, 43].Worksheet.Column(43).Width = 10;    //klp69fe
            ws.Cells[1, 44].Worksheet.Column(44).Width = 10;    //r2
            ws.Cells[1, 45].Worksheet.Column(45).Width = 10;    //r4
            ws.Cells[1, 46].Worksheet.Column(46).Width = 10;    //totalfe

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Performance Salesman";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 43;
            int MinCol1 = 2, MaxCol1 = 16;
            int MinCol2 = 18, MaxCol2 = 26;
            int MinCol3 = 28, MaxCol3 = 41;
            int MinCol4 = 43, MaxCol4 = 46;

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;

            ws.Cells[Rowx, 5, Rowx, 6].Merge = true;
            ws.Cells[Rowx, 7, Rowx + 1, 7].Merge = true;
            ws.Cells[Rowx, 8, Rowx, 9].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 1, 10].Merge = true;
            ws.Cells[Rowx, 11, Rowx, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx + 1, 13].Merge = true;
            ws.Cells[Rowx, 14, Rowx, 15].Merge = true;
            ws.Cells[Rowx, 16, Rowx + 1, 16].Merge = true;

            ws.Cells[Rowx, 18, Rowx, 19].Merge = true;
            ws.Cells[Rowx, 20, Rowx + 1, 20].Merge = true;
            ws.Cells[Rowx, 21, Rowx, 22].Merge = true;
            ws.Cells[Rowx, 23, Rowx + 1, 23].Merge = true;
            ws.Cells[Rowx, 24, Rowx, 25].Merge = true;
            ws.Cells[Rowx, 26, Rowx + 1, 26].Merge = true;

            ws.Cells[Rowx, 28, Rowx, 30].Merge = true;
            ws.Cells[Rowx, 31, Rowx, 33].Merge = true;
            ws.Cells[Rowx, 34, Rowx, 36].Merge = true;
            ws.Cells[Rowx, 37, Rowx, 39].Merge = true;
            ws.Cells[Rowx, 40, Rowx, 41].Merge = true;

            ws.Cells[Rowx, 43, Rowx, 45].Merge = true;
            ws.Cells[Rowx, 46, Rowx + 1, 46].Merge = true;

            //do
            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " CAB ";
            ws.Cells[Rowx, 4].Value = " SALESMAN ";

            ws.Cells[Rowx, 5].Value = " SO ";
            ws.Cells[Rowx + 1, 5].Value = " BE ";
            ws.Cells[Rowx + 1, 6].Value = " Non BE ";
            ws.Cells[Rowx, 7].Value = " TOTAL ";

            ws.Cells[Rowx, 8].Value = " DO ";
            ws.Cells[Rowx + 1, 8].Value = " BE ";
            ws.Cells[Rowx + 1, 9].Value = " Non BE ";
            ws.Cells[Rowx, 10].Value = " TOTAL ";

            ws.Cells[Rowx, 11].Value = " SKU ";
            ws.Cells[Rowx + 1, 11].Value = " BE ";
            ws.Cells[Rowx + 1, 12].Value = " Non BE ";
            ws.Cells[Rowx, 13].Value = " TOTAL ";

            ws.Cells[Rowx, 14].Value = " OA ";
            ws.Cells[Rowx + 1, 14].Value = " BE ";
            ws.Cells[Rowx + 1, 15].Value = " Non BE ";
            ws.Cells[Rowx, 16].Value = " OA REAL ";

            //nota
            ws.Cells[Rowx, 18].Value = " NOTA ";
            ws.Cells[Rowx + 1, 18].Value = " BE ";
            ws.Cells[Rowx + 1, 19].Value = " Non BE ";
            ws.Cells[Rowx, 20].Value = " TOTAL ";

            ws.Cells[Rowx, 21].Value = " SKU ACTUAL ";
            ws.Cells[Rowx + 1, 21].Value = " BE ";
            ws.Cells[Rowx + 1, 22].Value = " Non BE ";
            ws.Cells[Rowx, 23].Value = " TOTAL ";

            ws.Cells[Rowx, 24].Value = " OA ACTUAL ";
            ws.Cells[Rowx + 1, 24].Value = " BE ";
            ws.Cells[Rowx + 1, 25].Value = " Non BE ";
            ws.Cells[Rowx, 26].Value = " TOTAL ";

            //pending
            ws.Cells[Rowx, 28].Value = " BACK ORDER BE ";
            ws.Cells[Rowx + 1, 28].Value = " ITEM ";
            ws.Cells[Rowx + 1, 29].Value = " QTY ";
            ws.Cells[Rowx + 1, 30].Value = " NOMINAL ";

            ws.Cells[Rowx, 31].Value = " BACK ORDER NON BE ";
            ws.Cells[Rowx + 1, 31].Value = " ITEM ";
            ws.Cells[Rowx + 1, 32].Value = " QTY ";
            ws.Cells[Rowx + 1, 33].Value = " NOMINAL ";

            ws.Cells[Rowx, 34].Value = " TOLAK HARGA BE ";
            ws.Cells[Rowx + 1, 34].Value = " ITEM ";
            ws.Cells[Rowx + 1, 35].Value = " QTY ";
            ws.Cells[Rowx + 1, 36].Value = " NOMINAL ";

            ws.Cells[Rowx, 37].Value = " TOLAK HARGA NON BE ";
            ws.Cells[Rowx + 1, 37].Value = " ITEM ";
            ws.Cells[Rowx + 1, 38].Value = " QTY ";
            ws.Cells[Rowx + 1, 39].Value = " NOMINAL ";

            ws.Cells[Rowx, 40].Value = " PENDING PIUTANG ";
            ws.Cells[Rowx + 1, 40].Value = " BE ";
            ws.Cells[Rowx + 1, 41].Value = " NON BE ";

            ws.Cells[Rowx, 43].Value = " BARANG E ";
            ws.Cells[Rowx + 1, 43].Value = " KLP69 ";
            ws.Cells[Rowx + 1, 44].Value = " R2 ";
            ws.Cells[Rowx + 1, 45].Value = " R4 ";
            ws.Cells[Rowx, 46].Value = " TOTAL ";

            ws.Cells[Rowx, MinCol1, Rowx + 1, MaxCol4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, MinCol1, Rowx + 1, MaxCol4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //tabel1
            ws.Cells[Rowx, MinCol1, Rowx + 1, MinCol1 + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, MinCol1, Rowx + 1, MinCol1 + 2].Style.Fill.BackgroundColor.SetColor(Color.Linen);

            ws.Cells[Rowx, MinCol1 + 3, Rowx + 1, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, MinCol1 + 3, Rowx + 1, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.MediumSpringGreen);

            //tabel2
            ws.Cells[Rowx, MinCol2, Rowx + 1, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, MinCol2, Rowx + 1, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Orange);

            //tabel3
            ws.Cells[Rowx, MinCol3, Rowx + 1, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, MinCol3, Rowx + 1, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //tabel4
            ws.Cells[Rowx, MinCol4, Rowx + 1, MaxCol4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, MinCol4, Rowx + 1, MaxCol4].Style.Fill.BackgroundColor.SetColor(Color.Plum);

            Rowx += 2;
            int no = 0;
            double Jumlah = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = GlobalVar.Gudang.ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["KodeSales"], "").ToString();

                    /*SO*/
                    ws.Cells[Rowx, 5].Value = Double.Parse(Tools.isNull(dr1["RqBE"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Double.Parse(Tools.isNull(dr1["RqFX"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Double.Parse(Tools.isNull(dr1["JmlRq"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";

                    /*DO*/
                    ws.Cells[Rowx, 8].Value = Double.Parse(Tools.isNull(dr1["DoBE"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Double.Parse(Tools.isNull(dr1["DoFX"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Double.Parse(Tools.isNull(dr1["JmlDO"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 11].Value = Double.Parse(Tools.isNull(dr1["SkuBEDo"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Double.Parse(Tools.isNull(dr1["SkuFXDo"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Double.Parse(Tools.isNull(dr1["JmlSkuDo"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 14].Value = Double.Parse(Tools.isNull(dr1["OABEDo"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Double.Parse(Tools.isNull(dr1["OAFXDo"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Double.Parse(Tools.isNull(dr1["JmlOADo"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    /*NOTA*/
                    ws.Cells[Rowx, 18].Value = Double.Parse(Tools.isNull(dr1["NotaBE"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 19].Value = Double.Parse(Tools.isNull(dr1["NotaFX"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 20].Value = Double.Parse(Tools.isNull(dr1["JmlNota"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 21].Value = Double.Parse(Tools.isNull(dr1["SkuBENota"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 22].Value = Double.Parse(Tools.isNull(dr1["SkuFXNota"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 23].Value = Double.Parse(Tools.isNull(dr1["JmlSkuNota"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 24].Value = Double.Parse(Tools.isNull(dr1["OABENota"], "0").ToString());
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 25].Value = Double.Parse(Tools.isNull(dr1["OAFXNota"], "0").ToString());
                    ws.Cells[Rowx, 25].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 26].Value = Double.Parse(Tools.isNull(dr1["JmlOANota"], "0").ToString());
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);";

                    /*pending*/
                    ws.Cells[Rowx, 28].Value = Double.Parse(Tools.isNull(dr1["SkuBoBE"], "0").ToString());
                    ws.Cells[Rowx, 28].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 29].Value = Double.Parse(Tools.isNull(dr1["QtyBoBE"], "0").ToString());
                    ws.Cells[Rowx, 29].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 30].Value = Double.Parse(Tools.isNull(dr1["JmlBoBE"], "0").ToString());
                    ws.Cells[Rowx, 30].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 31].Value = Double.Parse(Tools.isNull(dr1["SkuBoFX"], "0").ToString());
                    ws.Cells[Rowx, 31].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 32].Value = Double.Parse(Tools.isNull(dr1["QtyBoFX"], "0").ToString());
                    ws.Cells[Rowx, 32].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 33].Value = Double.Parse(Tools.isNull(dr1["JmlBoFX"], "0").ToString());
                    ws.Cells[Rowx, 33].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 34].Value = Double.Parse(Tools.isNull(dr1["SkuThBE"], "0").ToString());
                    ws.Cells[Rowx, 34].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 35].Value = Double.Parse(Tools.isNull(dr1["QtyThBE"], "0").ToString());
                    ws.Cells[Rowx, 35].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 36].Value = Double.Parse(Tools.isNull(dr1["RpThBE"], "0").ToString());
                    ws.Cells[Rowx, 36].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 37].Value = Double.Parse(Tools.isNull(dr1["SkuThFX"], "0").ToString());
                    ws.Cells[Rowx, 37].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 38].Value = Double.Parse(Tools.isNull(dr1["QtyThFX"], "0").ToString());
                    ws.Cells[Rowx, 38].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 39].Value = Double.Parse(Tools.isNull(dr1["RpThFX"], "0").ToString());
                    ws.Cells[Rowx, 39].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 40].Value = Double.Parse(Tools.isNull(dr1["PdBE"], "0").ToString());
                    ws.Cells[Rowx, 40].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 41].Value = Double.Parse(Tools.isNull(dr1["PdFX"], "0").ToString());
                    ws.Cells[Rowx, 41].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 43].Value = Double.Parse(Tools.isNull(dr1["SkuPS"], "0").ToString());
                    ws.Cells[Rowx, 43].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 44].Value = Double.Parse(Tools.isNull(dr1["QtyR2"], "0").ToString());
                    ws.Cells[Rowx, 44].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 45].Value = Double.Parse(Tools.isNull(dr1["QtyR4"], "0").ToString());
                    ws.Cells[Rowx, 45].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 46].Value = Double.Parse(Tools.isNull(dr1["JmlQty"], "0").ToString());
                    ws.Cells[Rowx, 46].Style.Numberformat.Format = "#,##;(#,##);";

                    ////        ws.Cells[Rowx, 4].Value = Int32.Parse(Tools.isNull(dr1["Jmlhr1"], "0").ToString());
            ////        ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Jmlhr2"], "0").ToString());
            ////        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Persen"], "0").ToString());
            ////        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ////        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Bns1"], "0").ToString());
            ////        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Bns2"], "0").ToString());
            ////        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Bns3"], "0").ToString());
            ////        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            ////        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["AccBns"], "0").ToString());
            ////        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            ////        Jumlah += Convert.ToDouble(Tools.isNull(dr1["AccBns"], "0").ToString());

                    Rowx++;
                }
            }
            Rowx++;

            //ws.Cells[Rowx, 10].Value = Tools.isNull(Jumlah, 0);
            //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 10].Style.Font.Bold = true;

            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            /*tabel1*/
            var border = ws.Cells[nRow + 1, MinCol1, Rowx - 1, MaxCol1].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, MinCol1, Rowx - 1, MaxCol1].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, MinCol1, nRow + 1, MaxCol1].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[nRow + 1, MinCol1 + 5, Rowx - 1, MinCol1 + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 5, Rowx - 1, MinCol1 + 5].Style.Fill.BackgroundColor.SetColor(Color.MediumSpringGreen);
            ws.Cells[nRow + 1, MinCol1 + 8, Rowx - 1, MinCol1 + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 8, Rowx - 1, MinCol1 + 8].Style.Fill.BackgroundColor.SetColor(Color.MediumSpringGreen);
            ws.Cells[nRow + 1, MinCol1 + 11, Rowx - 1, MinCol1 + 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 11, Rowx - 1, MinCol1 + 11].Style.Fill.BackgroundColor.SetColor(Color.MediumSpringGreen);

            //tabel2
            border = ws.Cells[nRow + 1, MinCol2, Rowx - 1, MaxCol2].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, MinCol2, Rowx - 1, MaxCol2].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, MinCol2, nRow + 1, MaxCol2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[nRow + 1, MinCol1 + 18, Rowx - 1, MinCol1 + 18].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 18, Rowx - 1, MinCol1 + 18].Style.Fill.BackgroundColor.SetColor(Color.Orange);
            ws.Cells[nRow + 1, MinCol1 + 21, Rowx - 1, MinCol1 + 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 21, Rowx - 1, MinCol1 + 21].Style.Fill.BackgroundColor.SetColor(Color.Orange);
            ws.Cells[nRow + 1, MinCol1 + 24, Rowx - 1, MinCol1 + 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 24, Rowx - 1, MinCol1 + 24].Style.Fill.BackgroundColor.SetColor(Color.Orange);


            //tabel3
            border = ws.Cells[nRow + 1, MinCol3, Rowx - 1, MaxCol3].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, MinCol3, Rowx - 1, MaxCol3].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, MinCol3, nRow + 1, MaxCol3].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[nRow + 1, MinCol1 + 28, Rowx - 1, MinCol1 + 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 28, Rowx - 1, MinCol1 + 28].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            ws.Cells[nRow + 1, MinCol1 + 31, Rowx - 1, MinCol1 + 31].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 31, Rowx - 1, MinCol1 + 31].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            ws.Cells[nRow + 1, MinCol1 + 34, Rowx - 1, MinCol1 + 34].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 34, Rowx - 1, MinCol1 + 34].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            ws.Cells[nRow + 1, MinCol1 + 37, Rowx - 1, MinCol1 + 37].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 37, Rowx - 1, MinCol1 + 37].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //tabel4
            border = ws.Cells[nRow + 1, MinCol4, Rowx - 1, MaxCol4].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, MinCol4, Rowx - 1, MaxCol4].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, MinCol4, nRow + 1, MaxCol4].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[nRow + 1, MinCol1 + 44, Rowx - 1, MinCol1 + 44].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[nRow + 1, MinCol1 + 44, Rowx - 1, MinCol1 + 44].Style.Fill.BackgroundColor.SetColor(Color.Plum);

            Rowx += 2;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            return ex;

        }

    }
}
