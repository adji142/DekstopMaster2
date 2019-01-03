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
    public partial class frmRptAnalisaPiutang : ISA.Controls.BaseForm
    {
        public frmRptAnalisaPiutang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptAnalisaPiutang_Load(object sender, EventArgs e)
        {

        }

        private void cmdCetak_Click(object sender, EventArgs e)
        {
            int tgl = 1;
            int bln = DateTime.Parse(Tanggal.DateValue.ToString()).AddMonths(-2).Month;
            int thn = DateTime.Parse(Tanggal.DateValue.ToString()).Year;
            DateTime Tgl1 = DateTime.Parse(Tanggal.DateValue.ToString()).AddMonths(-2).AddDays(tgl - 1);
            DateTime fromDate = new DateTime(thn, bln, tgl);
            DateTime toDate = DateTime.Parse(Tanggal.DateValue.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_KebiasaanBayar"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DisplayReportKebiasaanBayar(ds, fromDate, toDate);
                    //DisplayReportAnalisaPiutang(ds, fromDate, toDate);
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

        private void DisplayReportAnalisaPiutang(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapAnalisaPiutang(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LaporanAnalisaPiutang";

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



        private ExcelPackage LapAnalisaPiutang(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Analisa Piutang";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Analisa Piutang", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan rekap piutang per kategori

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 12;      //gudang
            ws.Cells[1, 4].Worksheet.Column(4).Width = 12;      //erpkas
            ws.Cells[1, 5].Worksheet.Column(5).Width = 12;      //erptrn
            ws.Cells[1, 6].Worksheet.Column(6).Width = 12;      //erpbgc
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //erpdll

            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //ontkas
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //onttrn
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //ontbgc
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;    //ontdll

            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;      //nplkas
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;      //nplkas
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;      //nplkas
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;      //nplgiro

            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //overdue

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Analisa Piutang";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 16;

            ws.Cells[Rowx, 2].Value = "REKAP";
            ws.Cells[Rowx, 2].Style.Font.Bold = true;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            Rowx++;
            nRow = Rowx;

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 16, Rowx + 1, 16].Merge = true;

            ws.Cells[Rowx, 4, Rowx, 7].Merge = true;
            ws.Cells[Rowx, 8, Rowx, 11].Merge = true;
            ws.Cells[Rowx, 12, Rowx, 15].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Gudang ";

            ws.Cells[Rowx, 4].Value = " Early Payment ";
            ws.Cells[Rowx + 1, 4].Value = " Kas ";
            ws.Cells[Rowx + 1, 5].Value = " Trn ";
            ws.Cells[Rowx + 1, 6].Value = " Bgc ";
            ws.Cells[Rowx + 1, 7].Value = " DLL ";

            ws.Cells[Rowx, 8].Value = " Ontime ";
            ws.Cells[Rowx + 1, 8].Value = " Kas ";
            ws.Cells[Rowx + 1, 9].Value = " Trn ";
            ws.Cells[Rowx + 1, 10].Value = " Bgc ";
            ws.Cells[Rowx + 1, 11].Value = " DLL ";

            ws.Cells[Rowx, 12].Value = " Non Performance Loan ";
            ws.Cells[Rowx + 1, 12].Value = " Kas ";
            ws.Cells[Rowx + 1, 13].Value = " Trn ";
            ws.Cells[Rowx + 1, 14].Value = " Bgc ";
            ws.Cells[Rowx + 1, 15].Value = " DLL ";

            ws.Cells[Rowx, 16].Value = " Overdue ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["Gudang"], "").ToString();

                    ws.Cells[Rowx, 4].Value = Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
                    ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["ErpDll"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    Rowx++;
                }
            }
            Rowx++;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = 0;// Tools.isNull(nInsentifOA, 0);
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


            #region Laporan rakap piutang per Toko

            ex.Workbook.Worksheets.Add("Rekap Per Toko");
            ws = ex.Workbook.Worksheets[2];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            nRow = 0; nHeader = 1; Rowx = 0;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Analisa Piutang Per Toko";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nHeader += 3;
            ws.Cells[nHeader, 2].Value = "REKAP PER TOKO";
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader, 2].Style.Font.Italic = true;

            nHeader++;
            nRow = nHeader;
            Rowx = nRow;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 35;      //nama toko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      //idwil

            ws.Cells[1, 5].Worksheet.Column(5).Width = 12;      //erpkas
            ws.Cells[1, 6].Worksheet.Column(6).Width = 12;      //erptrn
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //erpbgc
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //erpdll

            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //ontkas
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;      //ontgiro
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;      //ontkas
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;      //ontgiro

            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;      //nplkas
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //nplgiro
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;      //nplkas
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //nplgiro

            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //due

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
            ws.Cells[Rowx, 17, Rowx + 1, 17].Merge = true;

            ws.Cells[Rowx, 5, Rowx, 8].Merge = true;
            ws.Cells[Rowx, 9, Rowx, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx, 16].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Idwil ";
            ws.Cells[Rowx, 5].Value = " Early Payment ";
            ws.Cells[Rowx + 1, 5].Value = " Kas ";
            ws.Cells[Rowx + 1, 6].Value = " Trn ";
            ws.Cells[Rowx + 1, 7].Value = " Bgc ";
            ws.Cells[Rowx + 1, 8].Value = " DLL ";

            ws.Cells[Rowx, 9].Value = " Ontime ";
            ws.Cells[Rowx + 1, 9].Value = " Kas ";
            ws.Cells[Rowx + 1, 10].Value = " Trn ";
            ws.Cells[Rowx + 1, 11].Value = " Bgc ";
            ws.Cells[Rowx + 1, 12].Value = " DLL ";

            ws.Cells[Rowx, 13].Value = " Non Performance Loan ";
            ws.Cells[Rowx + 1, 13].Value = " Kas ";
            ws.Cells[Rowx + 1, 14].Value = " Trn ";
            ws.Cells[Rowx + 1, 15].Value = " Bgc ";
            ws.Cells[Rowx + 1, 16].Value = " DLL ";

            ws.Cells[Rowx, 17].Value = " Overdue ";

            MaxCol = 17;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx += 2;

            no = 0;
            double nErpkas = 0, nErpTrn = 0, nErpbgc = 0, nErpDll = 0,
                   nOntkas = 0, nOntTrn = 0, nOntbgc = 0, nOntDll = 0,
                   nNplkas = 0, nNplTrn = 0, nNplbgc = 0, nNplDll = 0, nDue = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Idwil"], "").ToString();

                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["ErpDll"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";

                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";

                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";

                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";

                    nErpkas += Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
                    nErpTrn += Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
                    nErpbgc += Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
                    nErpDll += Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());

                    nOntkas += Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
                    nOntTrn += Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
                    nOntbgc += Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
                    nOntDll += Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());

                    nNplkas += Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
                    nNplTrn += Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
                    nNplbgc += Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
                    nNplDll += Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());

                    nDue += Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
                    Rowx++;
                }
                Rowx++;
                ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 3].Style.Font.Bold = true;

                ws.Cells[Rowx, 5].Value = Tools.isNull(nErpkas, 0);
                ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 5].Style.Font.Bold = true;

                ws.Cells[Rowx, 6].Value = Tools.isNull(nErpTrn, 0);
                ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 6].Style.Font.Bold = true;

                ws.Cells[Rowx, 7].Value = Tools.isNull(nErpbgc, 0);
                ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 7].Style.Font.Bold = true;

                ws.Cells[Rowx, 8].Value = Tools.isNull(nErpDll, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                ws.Cells[Rowx, 9].Value = Tools.isNull(nOntkas, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nOntTrn, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 11].Value = Tools.isNull(nOntbgc, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                ws.Cells[Rowx, 12].Value = Tools.isNull(nOntDll, 0);
                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 12].Style.Font.Bold = true;

                ws.Cells[Rowx, 13].Value = Tools.isNull(nNplkas, 0);
                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 13].Style.Font.Bold = true;

                ws.Cells[Rowx, 14].Value = Tools.isNull(nNplTrn, 0);
                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 14].Style.Font.Bold = true;

                ws.Cells[Rowx, 15].Value = Tools.isNull(nNplbgc, 0);
                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 15].Style.Font.Bold = true;

                ws.Cells[Rowx, 16].Value = Tools.isNull(nNplDll, 0);
                ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 16].Style.Font.Bold = true;

                ws.Cells[Rowx, 17].Value = Tools.isNull(nDue, 0);
                ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 17].Style.Font.Bold = true;

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

                border = ws.Cells[Rowx, 5, Rowx, MaxCol].Style.Border;
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
            }
            #endregion


            #region Laporan Detail Analisa Piutang

            ex.Workbook.Worksheets.Add("Detail Laporan");
            ws = ex.Workbook.Worksheets[3];
            ws.View.ShowGridLines = false;

            nRow = 0; nHeader = 1; Rowx = 0;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Analisa Piutang";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nHeader += 3;
            nRow = nHeader;
            Rowx = nRow;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //nonota
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglnota
            ws.Cells[1, 5].Worksheet.Column(5).Width = 5;       //tr
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgljttempo
            ws.Cells[1, 7].Worksheet.Column(7).Width = 35;      //namatoko
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //idwil
            ws.Cells[1, 9].Worksheet.Column(9).Width = 11;      //kodesales
            ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //debet
            ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //kredit
            ws.Cells[1, 12].Worksheet.Column(12).Width = 8;     //kdtr
            ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //tgltransaksi
            ws.Cells[1, 14].Worksheet.Column(14).Width = 5;     //flag
            ws.Cells[1, 15].Worksheet.Column(15).Width = 40;    //keterangan

            MaxCol = 15;
            for (int i = 2; i <= MaxCol; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No Nota ";
            ws.Cells[Rowx, 4].Value = " Tgl Nota ";
            ws.Cells[Rowx, 5].Value = " TR ";
            ws.Cells[Rowx, 6].Value = " Tgl Jt.Tempo ";
            ws.Cells[Rowx, 7].Value = " Nama Toko ";
            ws.Cells[Rowx, 8].Value = " Idwil ";
            ws.Cells[Rowx, 9].Value = " KodeSales ";
            ws.Cells[Rowx, 10].Value = " Debet ";
            ws.Cells[Rowx, 11].Value = " Kredit ";
            ws.Cells[Rowx, 12].Value = " Kode TR ";
            ws.Cells[Rowx, 13].Value = " Tgl Transaksi ";
            ws.Cells[Rowx, 14].Value = " Flag ";
            ws.Cells[Rowx, 15].Value = " Keterangan ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;

            no = 0;
            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoNota"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJatuhTempo"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Idwil"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["KodeTrans"], "").ToString();
                    ws.Cells[Rowx, 13].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
                    ws.Cells[Rowx, 14].Value = Tools.isNull(dr1["Ket"], "").ToString();
                    ws.Cells[Rowx, 15].Value = Tools.isNull(dr1["Keterangan"], "").ToString();
                    Rowx++;
                }
                Rowx++;

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

            }
            #endregion

            return ex;
        }

        private void DisplayReportKebiasaanBayar(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapKebiasaanBayar(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LaporanAnalisaPiutang";

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


        private ExcelPackage LapKebiasaanBayar(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Kebiasaan Bayar";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Kebiasaan Bayar", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan rekap piutang per kategori

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 31;      //namatoko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 60;      //alamat
            ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //kota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 8;       //idwil
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //sckas
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //kas
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //sctrn
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //trn
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //scbgc
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;    //bgc
            ws.Cells[1, 13].Worksheet.Column(13).Width = 10;    //sclain
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //lain
            ws.Cells[1, 15].Worksheet.Column(15).Width = 20;    //ket

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Kebiasaan Pembayaran";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 15;

            ws.Cells[Rowx, 2].Value = "REKAP";
            ws.Cells[Rowx, 2].Style.Font.Bold = true;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            Rowx++;
            nRow = Rowx;

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
            ws.Cells[Rowx, 5, Rowx + 1, 5].Merge = true;
            ws.Cells[Rowx, 6, Rowx + 1, 6].Merge = true;
            ws.Cells[Rowx, 15, Rowx + 1, 15].Merge = true;

            ws.Cells[Rowx, 7, Rowx, 8].Merge = true;
            ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            ws.Cells[Rowx, 11, Rowx, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx, 14].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Alamat ";
            ws.Cells[Rowx, 5].Value = " Kota ";
            ws.Cells[Rowx, 6].Value = " Idwil ";

            ws.Cells[Rowx, 7].Value = " KAS ";
            ws.Cells[Rowx + 1, 7].Value = " Score ";
            ws.Cells[Rowx + 1, 8].Value = " Nominal ";

            ws.Cells[Rowx, 9].Value = " Transfer ";
            ws.Cells[Rowx + 1, 9].Value = " Score ";
            ws.Cells[Rowx + 1, 10].Value = " Nominal ";

            ws.Cells[Rowx, 11].Value = " Giro ";
            ws.Cells[Rowx + 1, 11].Value = " Score ";
            ws.Cells[Rowx + 1, 12].Value = " Nominal ";

            ws.Cells[Rowx, 13].Value = " Lain-lain ";
            ws.Cells[Rowx + 1, 13].Value = " Score ";
            ws.Cells[Rowx + 1, 14].Value = " Nominal ";

            ws.Cells[Rowx, 15].Value = " Jenis Pembayaran ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[0].Rows)
            //    {
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["Gudang"], "").ToString();

            //        ws.Cells[Rowx, 4].Value = Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
            //        ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["ErpDll"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";

            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
            //        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";

            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
            //        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
            //        ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";

            //        ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
            //        ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

            //        Rowx++;
            //    }
            //}
            Rowx++;
            //ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = 0;// Tools.isNull(nInsentifOA, 0);
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


            #region Laporan rakap piutang per Toko

            //ex.Workbook.Worksheets.Add("Rekap Per Toko");
            //ws = ex.Workbook.Worksheets[2];
            //ws.View.ShowGridLines = false;
            //ws.Cells.Style.Font.Name = "Calibri";
            //ws.Cells.Style.Font.Size = 10;

            //nRow = 0; nHeader = 1; Rowx = 0;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Analisa Piutang Per Toko";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //nHeader += 3;
            //ws.Cells[nHeader, 2].Value = "REKAP PER TOKO";
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader, 2].Style.Font.Italic = true;

            //nHeader++;
            //nRow = nHeader;
            //Rowx = nRow;

            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 35;      //nama toko
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      //idwil

            //ws.Cells[1, 5].Worksheet.Column(5).Width = 12;      //erpkas
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 12;      //erptrn
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //erpbgc
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //erpdll

            //ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //ontkas
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 12;      //ontgiro
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 12;      //ontkas
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 12;      //ontgiro

            //ws.Cells[1, 13].Worksheet.Column(13).Width = 12;      //nplkas
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //nplgiro
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 12;      //nplkas
            //ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //nplgiro

            //ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //due

            //ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            //ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            //ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
            //ws.Cells[Rowx, 17, Rowx + 1, 17].Merge = true;

            //ws.Cells[Rowx, 5, Rowx, 8].Merge = true;
            //ws.Cells[Rowx, 9, Rowx, 12].Merge = true;
            //ws.Cells[Rowx, 13, Rowx, 16].Merge = true;

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " Nama Toko ";
            //ws.Cells[Rowx, 4].Value = " Idwil ";
            //ws.Cells[Rowx, 5].Value = " Early Payment ";
            //ws.Cells[Rowx + 1, 5].Value = " Kas ";
            //ws.Cells[Rowx + 1, 6].Value = " Trn ";
            //ws.Cells[Rowx + 1, 7].Value = " Bgc ";
            //ws.Cells[Rowx + 1, 8].Value = " DLL ";

            //ws.Cells[Rowx, 9].Value = " Ontime ";
            //ws.Cells[Rowx + 1, 9].Value = " Kas ";
            //ws.Cells[Rowx + 1, 10].Value = " Trn ";
            //ws.Cells[Rowx + 1, 11].Value = " Bgc ";
            //ws.Cells[Rowx + 1, 12].Value = " DLL ";

            //ws.Cells[Rowx, 13].Value = " Non Performance Loan ";
            //ws.Cells[Rowx + 1, 13].Value = " Kas ";
            //ws.Cells[Rowx + 1, 14].Value = " Trn ";
            //ws.Cells[Rowx + 1, 15].Value = " Bgc ";
            //ws.Cells[Rowx + 1, 16].Value = " DLL ";

            //ws.Cells[Rowx, 17].Value = " Overdue ";

            //MaxCol = 17;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            //Rowx += 2;

            //no = 0;
            //double nErpkas = 0, nErpTrn = 0, nErpbgc = 0, nErpDll = 0,
            //       nOntkas = 0, nOntTrn = 0, nOntbgc = 0, nOntDll = 0,
            //       nNplkas = 0, nNplTrn = 0, nNplbgc = 0, nNplDll = 0, nDue = 0;

            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[1].Rows)
            //    {
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Idwil"], "").ToString();

            //        ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
            //        ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
            //        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
            //        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["ErpDll"], "0").ToString());
            //        ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";

            //        ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
            //        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
            //        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());
            //        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";

            //        ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
            //        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
            //        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
            //        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());
            //        ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";

            //        ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
            //        ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";

            //        nErpkas += Convert.ToDouble(Tools.isNull(dr1["ErpKas"], "0").ToString());
            //        nErpTrn += Convert.ToDouble(Tools.isNull(dr1["ErpTrn"], "0").ToString());
            //        nErpbgc += Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());
            //        nErpDll += Convert.ToDouble(Tools.isNull(dr1["ErpBgc"], "0").ToString());

            //        nOntkas += Convert.ToDouble(Tools.isNull(dr1["OntKas"], "0").ToString());
            //        nOntTrn += Convert.ToDouble(Tools.isNull(dr1["OntTrn"], "0").ToString());
            //        nOntbgc += Convert.ToDouble(Tools.isNull(dr1["OntBgc"], "0").ToString());
            //        nOntDll += Convert.ToDouble(Tools.isNull(dr1["OntDll"], "0").ToString());

            //        nNplkas += Convert.ToDouble(Tools.isNull(dr1["NplKas"], "0").ToString());
            //        nNplTrn += Convert.ToDouble(Tools.isNull(dr1["NplTrn"], "0").ToString());
            //        nNplbgc += Convert.ToDouble(Tools.isNull(dr1["NplBgc"], "0").ToString());
            //        nNplDll += Convert.ToDouble(Tools.isNull(dr1["NplDll"], "0").ToString());

            //        nDue += Convert.ToDouble(Tools.isNull(dr1["DUE"], "0").ToString());
            //        Rowx++;
            //    }
            //    Rowx++;
            //    ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
            //    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    ws.Cells[Rowx, 3].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 5].Value = Tools.isNull(nErpkas, 0);
            //    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 5].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 6].Value = Tools.isNull(nErpTrn, 0);
            //    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 6].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 7].Value = Tools.isNull(nErpbgc, 0);
            //    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 7].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 8].Value = Tools.isNull(nErpDll, 0);
            //    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 8].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 9].Value = Tools.isNull(nOntkas, 0);
            //    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 9].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 10].Value = Tools.isNull(nOntTrn, 0);
            //    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 10].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 11].Value = Tools.isNull(nOntbgc, 0);
            //    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 11].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 12].Value = Tools.isNull(nOntDll, 0);
            //    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 12].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 13].Value = Tools.isNull(nNplkas, 0);
            //    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 13].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 14].Value = Tools.isNull(nNplTrn, 0);
            //    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 14].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 15].Value = Tools.isNull(nNplbgc, 0);
            //    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 15].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 16].Value = Tools.isNull(nNplDll, 0);
            //    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 16].Style.Font.Bold = true;

            //    ws.Cells[Rowx, 17].Value = Tools.isNull(nDue, 0);
            //    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
            //    ws.Cells[Rowx, 17].Style.Font.Bold = true;

            //    border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style = ExcelBorderStyle.None;
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.Thin;

            //    border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style = ExcelBorderStyle.Thin;
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.None;

            //    border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style =
            //    border.Left.Style = ExcelBorderStyle.Thin;
            //    border.Right.Style = ExcelBorderStyle.None;

            //    border = ws.Cells[Rowx, 5, Rowx, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style =
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.Thin;

            //    border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style =
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.Thin;

            //    nHeader = Rowx;
            //    Rowx += 1;

            //    ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx, 2].Style.Font.Italic = true;
            //}
            //#endregion


            //#region Laporan Detail Analisa Piutang

            //ex.Workbook.Worksheets.Add("Detail Laporan");
            //ws = ex.Workbook.Worksheets[3];
            //ws.View.ShowGridLines = false;

            //nRow = 0; nHeader = 1; Rowx = 0;

            //ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            //ws.Cells[nHeader, 2].Value = "Laporan Analisa Piutang";
            //ws.Cells[nHeader, 2].Style.Font.Size = 14;
            //ws.Cells[nHeader, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            //ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            //nHeader += 3;
            //nRow = nHeader;
            //Rowx = nRow;

            //ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //nonota
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglnota
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 5;       //tr
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgljttempo
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 35;      //namatoko
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //idwil
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 11;      //kodesales
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //debet
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //kredit
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 8;     //kdtr
            //ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //tgltransaksi
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 5;     //flag
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 40;    //keterangan

            //MaxCol = 15;
            //for (int i = 2; i <= MaxCol; i++)
            //{
            //    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            //}

            //ws.Cells[Rowx, 2].Value = " No ";
            //ws.Cells[Rowx, 3].Value = " No Nota ";
            //ws.Cells[Rowx, 4].Value = " Tgl Nota ";
            //ws.Cells[Rowx, 5].Value = " TR ";
            //ws.Cells[Rowx, 6].Value = " Tgl Jt.Tempo ";
            //ws.Cells[Rowx, 7].Value = " Nama Toko ";
            //ws.Cells[Rowx, 8].Value = " Idwil ";
            //ws.Cells[Rowx, 9].Value = " KodeSales ";
            //ws.Cells[Rowx, 10].Value = " Debet ";
            //ws.Cells[Rowx, 11].Value = " Kredit ";
            //ws.Cells[Rowx, 12].Value = " Kode TR ";
            //ws.Cells[Rowx, 13].Value = " Tgl Transaksi ";
            //ws.Cells[Rowx, 14].Value = " Flag ";
            //ws.Cells[Rowx, 15].Value = " Keterangan ";

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //Rowx += 2;

            //no = 0;
            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[2].Rows)
            //    {
            //        no += 1;
            //        ws.Cells[Rowx, 2].Value = no.ToString();
            //        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoNota"], "").ToString();
            //        ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
            //        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
            //        ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJatuhTempo"], ""));
            //        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
            //        ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Idwil"], "").ToString();
            //        ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
            //        ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());
            //        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
            //        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["KodeTrans"], "").ToString();
            //        ws.Cells[Rowx, 13].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
            //        ws.Cells[Rowx, 14].Value = Tools.isNull(dr1["Ket"], "").ToString();
            //        ws.Cells[Rowx, 15].Value = Tools.isNull(dr1["Keterangan"], "").ToString();
            //        Rowx++;
            //    }
            //    Rowx++;

            //    border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style = ExcelBorderStyle.None;
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.Thin;

            //    border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style = ExcelBorderStyle.Thin;
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.None;

            //    border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style =
            //    border.Left.Style = ExcelBorderStyle.Thin;
            //    border.Right.Style = ExcelBorderStyle.None;

            //    border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            //    border.Bottom.Style =
            //    border.Top.Style =
            //    border.Left.Style =
            //    border.Right.Style = ExcelBorderStyle.Thin;

            //    nHeader = Rowx;
            //    Rowx += 1;

            //    ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            //    ws.Cells[Rowx, 2].Style.Font.Size = 8;
            //    ws.Cells[Rowx, 2].Style.Font.Italic = true;

            //}
            #endregion

            return ex;
        }


    }
}
