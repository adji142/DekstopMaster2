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
    public partial class frmRptInsentifPengirimanToko : ISA.Controls.BaseForm
    {
        public frmRptInsentifPengirimanToko()
        {
            InitializeComponent();
        }

        private void frmRptInsentifPengirimanToko_Load(object sender, EventArgs e)
        {
            int thn = GlobalVar.DateTimeOfServer.Year;
            int bln = GlobalVar.DateTimeOfServer.Month;
            DateTime D1 = new DateTime(thn, bln, 1);
            rdbTanggal.FromDate = D1;
            rdbTanggal.ToDate = GlobalVar.DateTimeOfServer;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse(rdbTanggal.FromDate.ToString());
            DateTime d2 = DateTime.Parse(rdbTanggal.ToDate.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_LaporanInsentifPengiriman_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReportInsentifPengiriman(dt, d1, d2);
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

        private void DisplayReportInsentifPengiriman(DataTable dt, DateTime d1, DateTime d2)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentifPengiriman(dt, d1, d2));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifPengiriman";

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


        private ExcelPackage LapInsentifPengiriman(DataTable dt, DateTime d1, DateTime d2)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif Pengiriman Toko";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Pengiriman Toko", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 12;      //jumlahnota
            ws.Cells[1, 4].Worksheet.Column(4).Width = 18;      //pengiriman >= 6hr
            ws.Cells[1, 5].Worksheet.Column(5).Width = 18;      //pengiriman < 6hr
            ws.Cells[1, 6].Worksheet.Column(6).Width = 6;       //(%)
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //<=70%
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //71%-90%
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //91%-100%
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //accinsentif
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //personil

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Good In Transit";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Depo "+GlobalVar.Gudang;
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 4;
            Rowx = nRow;
            int MaxCol = 11;

            for (int i = 2; i <= 6; i++)
            {
                ws.Cells[Rowx, i, Rowx + 2, i].Merge = true;
            }
            ws.Cells[Rowx, 7, Rowx, 9].Merge = true;
            ws.Cells[Rowx + 1, 7, Rowx + 2, 7].Merge = true;
            ws.Cells[Rowx + 1, 8, Rowx + 2, 8].Merge = true;
            ws.Cells[Rowx + 1, 9, Rowx + 2, 9].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 2, 10].Merge = true;
            ws.Cells[Rowx, 11, Rowx + 2, 11].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Jumlah Nota ";
            ws.Cells[Rowx, 4].Value = " Pengiriman >= 6 hari ";
            ws.Cells[Rowx, 5].Value = " Pengiriman < 6 hari ";
            ws.Cells[Rowx, 6].Value = " (%) ";
            ws.Cells[Rowx, 7].Value = " Grade Perolehan Insentif ";
            ws.Cells[Rowx + 1, 7].Value = " <= 70% ";
            ws.Cells[Rowx + 1, 8].Value = " 71% - 90% ";
            ws.Cells[Rowx + 1, 9].Value = " 91% - 100% ";
            ws.Cells[Rowx, 10].Value = " Acc Insentif ";
            ws.Cells[Rowx, 11].Value = " Personil ";

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 3;
            int no = 0;
            double Jumlah = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Int32.Parse(Tools.isNull(dr1["JmlNota"], "0").ToString());
                    ws.Cells[Rowx, 3].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 4].Value = Int32.Parse(Tools.isNull(dr1["Jmlhr1"], "0").ToString());
                    ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Jmlhr2"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Persen"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Bns1"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Bns2"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Bns3"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["AccBns"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    Jumlah += Convert.ToDouble(Tools.isNull(dr1["AccBns"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;

            ws.Cells[Rowx, 10].Value = Tools.isNull(Jumlah, 0);
            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 10].Style.Font.Bold = true;

            ws.Cells[Rowx, 10, Rowx , 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 10, Rowx , 10].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx, 10, Rowx, 10].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            Rowx += 2;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            return ex;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse(rdbTanggal.FromDate.ToString());
            DateTime d2 = DateTime.Parse(rdbTanggal.ToDate.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_LaporanInsentifPengiriman_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReportInsentifPengiriman(dt, d1, d2);
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
}
