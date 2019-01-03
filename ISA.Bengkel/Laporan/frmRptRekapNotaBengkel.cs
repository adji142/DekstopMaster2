using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;
using ISA.Bengkel.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Collections;


namespace ISA.Bengkel.Laporan
{
    public partial class frmRptRekapNotaBengkel : ISA.Bengkel.BaseForm
    {
        public frmRptRekapNotaBengkel()
        {
            InitializeComponent();
        }

        private void frmRptRekapNotaBengkel_Load(object sender, EventArgs e)
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
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_RekapNotaBengkel_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rgbTglService.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rgbTglService.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data tida ada.");
                        return;
                    }
                    DisplayReport(dt, rgbTglService.FromDate.Value, rgbTglService.ToDate.Value);
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

        private void DisplayReport(DataTable dt, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(RekapServiceBengkel(dt, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "RekapNotaBengkel_" + GlobalVar.Gudang + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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


        private ExcelPackage RekapServiceBengkel(DataTable dt, DateTime fromdate, DateTime todate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Rekap NOta Bengkel";
            ex.Workbook.Properties.SetCustomPropertyValue("Rekap Nota Bengkel", "1147");

            ex.Workbook.Worksheets.Add("Rekap Nota Bengkel");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 12;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 30;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;
            ws.Cells[1, 10].Worksheet.Column(10).Width = 20;
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;
            ws.Cells[1, 13].Worksheet.Column(13).Width = 17;
            ws.Cells[1, 14].Worksheet.Column(14).Width = 10;
            ws.Cells[1, 15].Worksheet.Column(15).Width = 10;
            ws.Cells[1, 16].Worksheet.Column(16).Width = 10;

            int nRow = 0, nHeader = 1, Rowx = 0, MaxCol = 16;

            ws.Cells[nHeader, 2].Value = "REKAP NOTA BENGKEL";
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate);
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader + 1, 2].Style.Font.Size = 10;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;

            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[Rowx, 2].Value = "No";
            ws.Cells[Rowx, 3].Value = "Tgl Service";
            ws.Cells[Rowx, 4].Value = "No Service";
            ws.Cells[Rowx, 5].Value = "No Pol";
            ws.Cells[Rowx, 6].Value = "Nama Pelanggan";
            ws.Cells[Rowx, 7].Value = "Alamat";
            ws.Cells[Rowx, 8].Value = "No Nota(SP)";
            ws.Cells[Rowx, 9].Value = "Tgl Terima";
            ws.Cells[Rowx, 10].Value = "Nama Toko";
            ws.Cells[Rowx, 11].Value = "Rp Nota";
            ws.Cells[Rowx, 12].Value = "Rp Service";
            ws.Cells[Rowx, 13].Value = "Rp Sparepart Luar";
            ws.Cells[Rowx, 14].Value = "Piutang";
            ws.Cells[Rowx, 15].Value = "Bayar";
            ws.Cells[Rowx, 16].Value = "Sisa";

            ws.Cells[Rowx, 2, Rowx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double JRpnota = 0, JRpserv = 0, JRpluar = 0, Jdebet = 0, Jkredit = 0, JSisa = 0;
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no;
                    ws.Cells[Rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["tgl_service"], ""));
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["nomor_bengkel"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["no_pol"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["nama_cust"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["alamat"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["no_nota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["tgl_link"], ""));
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["namatoko"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["rp_nota"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["rp_service"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["rp_sparepart_luar"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["xdebet"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["xkredit"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["sisa"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    JRpnota += Convert.ToDouble(Tools.isNull(dr1["rp_nota"], "0").ToString());
                    JRpserv += Convert.ToDouble(Tools.isNull(dr1["rp_service"], "0").ToString());
                    JRpluar += Convert.ToDouble(Tools.isNull(dr1["rp_sparepart_luar"], "0").ToString());
                    Jdebet += Convert.ToDouble(Tools.isNull(dr1["xdebet"], "0").ToString());
                    Jkredit += Convert.ToDouble(Tools.isNull(dr1["xkredit"], "0").ToString());
                    JSisa += Convert.ToDouble(Tools.isNull(dr1["sisa"], "0").ToString());

                    Rowx += 1;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 7].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[Rowx, 11].Value = JRpnota;
            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 12].Value = JRpserv;
            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 13].Value = JRpluar;
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 14].Value = Jdebet;
            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 15].Value = Jkredit;
            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 16].Value = JSisa;
            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

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

            border = ws.Cells[Rowx, 11, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            return ex;
        }

    }
}
