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
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace ISA.Toko.xpdc
{
    public partial class frmRptRekapXpdc : ISA.Toko.BaseForm
    {
        public frmRptRekapXpdc()
        {
            InitializeComponent();
        }

        private void frmRptRekapXpdc_Load(object sender, EventArgs e)
        {
            rgbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglSuratJalan.ToDate = DateTime.Now;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_RekapExpedisi"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglSuratJalan.ToDate));

                    dt = db.Commands[0].ExecuteDataTable();
                    DisplayReport(dt);
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


        private void DisplayReport(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1(dt));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Rekap Pengiriman Barang" + GlobalVar.Gudang;
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


        private ExcelPackage Process1(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Rekap Pengiriman Barang";

            #region sheet 1
            ex.Workbook.Worksheets.Add("Rekap Pengiriman Barang");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 13;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 20;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 20;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 50;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 70;
            ws.Cells[1, 10].Worksheet.Column(10).Width = 30;
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
            ws.Cells[1, 12].Worksheet.Column(12).Width = 20;
            ws.Cells[1, 13].Worksheet.Column(13).Width = 20;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "Laporan     : LAPORAN PENGIRIMAN BARANG";
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rgbTglSuratJalan.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rgbTglSuratJalan.ToDate);
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 1].Value = "TANGGAL"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "NOMOR"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "SOPIR"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "KERNET"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "NO.POL"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "TGL.NOTA"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "NO.NOTA"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 8].Value = "NAMA TOKO"; ws.Cells[5, 8, 6, 8].Merge = true;
            ws.Cells[5, 9].Value = "ALAMAT"; ws.Cells[5, 9, 6, 9].Merge = true;
            ws.Cells[5, 10].Value = "TUJUAN"; ws.Cells[5, 10, 6, 10].Merge = true;
            ws.Cells[5, 11].Value = "JML.KOLI"; ws.Cells[5, 11, 6, 11].Merge = true;
            ws.Cells[5, 12].Value = "TGL.TRM"; ws.Cells[5, 12, 6, 12].Merge = true;
            ws.Cells[5, 13].Value = "BARCODE"; ws.Cells[5, 13, 6, 13].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;
            //int nomer = 0;
            foreach (DataRow dr1 in dt.Rows)
            {
                //nomer = nomer + 1;
                ws.Cells[rowx, 1].Value = string.Format("{0:dd MMMM yyyy}", dr1["Tanggal"]);
                ws.Cells[rowx, 2].Value = dr1["Nomor"];
                ws.Cells[rowx, 3].Value = dr1["Sopir"];
                ws.Cells[rowx, 4].Value = dr1["Kernet"];
                ws.Cells[rowx, 5].Value = dr1["NoPolisi"];
                ws.Cells[rowx, 6].Value = string.Format("{0:dd MMMM yyyy}", dr1["TglNota"]);
                //ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 7].Value = dr1["NoNota"];
                ws.Cells[rowx, 8].Value = dr1["NamaToko"];
                ws.Cells[rowx, 9].Value = dr1["Alamat"];
                ws.Cells[rowx, 10].Value = dr1["Tujuan"];
                ws.Cells[rowx, 11].Value = Convert.ToInt32(Tools.isNull(dr1["JumlahKoli"],0));
                ws.Cells[rowx, 12].Value = string.Format("{0:dd MMMM yyyy}", dr1["TglTerima"]);
                ws.Cells[rowx, 13].Value = dr1["Barcode"];

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

            return ex;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
