using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.Penjualan
{
    public partial class frmLaporanOvdFXumurNotaLebih30hari : ISA.Controls.BaseForm
    {
        public frmLaporanOvdFXumurNotaLebih30hari()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("rsp_OverdueFX_UmurNotaLebih30"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapOvdFX(dt));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifSalesVsPelunasan";

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


        private ExcelPackage LapOvdFX(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan overdue FX umur Nota lebih dari 30 hari";
            ex.Workbook.Properties.SetCustomPropertyValue("OvdFX", "1147");

            ex.Workbook.Worksheets.Add("OvdFXun30");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;      //no nota
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //tgl nota
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //tgl link
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //kode sales
            ws.Cells[1, 6].Worksheet.Column(6).Width = 27;      //nama toko
            ws.Cells[1, 7].Worksheet.Column(7).Width = 40;      //alamat
            ws.Cells[1, 8].Worksheet.Column(8).Width = 20;      //kota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //idwil
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //saldo piutang
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //umur nota

            int nRow = 0, nHeader = 0, Rowx = 0;

            //#region Laporan
            if (dt.Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 1].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 1].Value = "Laporan overdue FX umur Nota lebih dari 30 hari";
                ws.Cells[nHeader, 1].Style.Font.Size = 14;
                ws.Cells[nHeader, 1].Style.Font.Bold = true;
                //ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

                int MaxCol = 11;

                ws.Cells[Rowx, 2].Value = " No Nota ";
                ws.Cells[Rowx, 3].Value = " Tgl Nota ";
                ws.Cells[Rowx, 4].Value = " Tgl Link ";
                ws.Cells[Rowx, 5].Value = " Kode Sales ";
                ws.Cells[Rowx, 6].Value = " Nama Toko ";
                ws.Cells[Rowx, 7].Value = " Alamat ";
                ws.Cells[Rowx, 8].Value = " Kota ";
                ws.Cells[Rowx, 9].Value = " Idwil ";
                ws.Cells[Rowx, 10].Value = " Saldo Ptg ";
                ws.Cells[Rowx, 11].Value = " Umur Nota ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double nSaldo = 0;

                foreach (DataRow dr1 in dt.Rows)
                {
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
                    ws.Cells[Rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglLink"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Wilid"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Umur"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                    nSaldo += Convert.ToDouble(Tools.isNull(dr1["Saldo"], "0").ToString());
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nSaldo, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

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
            return ex;
        }

        private void frmLaporanOvdFXumurNotaLebih30hari_Load(object sender, EventArgs e)
        {

        }

    }
}
