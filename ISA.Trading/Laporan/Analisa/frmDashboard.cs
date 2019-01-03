using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

using System.Diagnostics;
using System.Data.SqlTypes;
using OfficeOpenXml.Drawing.Chart;

namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmDashboard : ISA.Trading.BaseForm
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("Rsp_DashboardV1_DupSAP"));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue.Value));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                GenerateExcell(ds);
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }
        private void GenerateExcell(DataSet ds)
        {
            int hari = dateTextBox1.DateValue.Value.Day;

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN DASHBOARD MONITORING";

                #region sheet1
                p.Workbook.Worksheets.Add("Dashboard Monitoring");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[1];

                DataTable dt1a = new DataTable();
                //DataTable dt1b = new DataTable();
                dt1a = ds.Tables[0].Copy();
                //dt1b = ds.Tables[1].Copy();

                ws1.Name = "Sheet1"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";

                string Title = "DASHBOARD MONITORING";
                string periode = "PERIODE : " + dateTextBox1.DateValue.Value.ToString("MM-yyyy");

                ws1.Cells[1, 1].Value = Title;
                ws1.Cells[1, 1].Style.Font.Size = 16;
                ws1.Cells[2, 1].Value = periode;
                ws1.Cells[3, 1].Value = "KODE CABANG : " + GlobalVar.Gudang;
                ws1.Cells[4, 1].Value = "TGL PROSES : " + GlobalVar.DateOfServer.Date.ToString("dd-MM-yyyy");
                ws1.Cells[2, 1, 4, 1].Style.Font.Size = 12;

                ws1.Cells[6, 1].Worksheet.Column(1).Width = 15;
                ws1.Cells[6, 2].Worksheet.Column(2).Width = 60;
                ws1.Cells[6, 3].Worksheet.Column(3).Width = 12;

                for (int x = 4; x <= hari + 1; x++)
                {
                    ws1.Cells[6, x].Worksheet.Column(x).Width = 12;
                }


                int startH = 6;
                int MaxC = hari + 3;

                #region Generate Header table 1
                
                ws1.Cells[startH, 1].Value = "Kode Barang";
                ws1.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws1.Cells[startH, 2].Value = "Nama Barang";
                ws1.Cells[startH, 2, startH + 1, 2].Merge = true;
                ws1.Cells[startH, 3].Value = "Stock Awal";
                ws1.Cells[startH + 1, 3].Value = "Qty";
                ws1.Cells[startH, 4].Value = dateTextBox1.DateValue.Value.Date.ToString("MMM yyyy");
                ws1.Cells[startH, 4, startH, MaxC].Merge = true;
                
                int xx = 1;
                for (xx = 1; xx <= hari; xx++)
                {
                    ws1.Cells[startH + 1, xx + 3].Value = xx.ToString();
                }
                ws1.Cells[startH, hari+4].Value = "Total";
                ws1.Cells[startH, hari + 4, startH + 1, hari + 4].Merge = true;

                ws1.Cells[startH, hari + 5].Value = "Saldo Akhir";
                ws1.Cells[startH, hari + 5, startH + 1, hari + 5].Merge = true;
                #endregion

                #region FillData table 1
                int idx = 6 + 2;

                foreach (DataRow dr in dt1a.Rows)
                {
                    //ws1.Cells[idx, 1].Value = Tools.isNull(dr["QtyAwal"], 0);
                    ws1.Cells[idx, 1].Value = dr["BarangID"];
                    ws1.Cells[idx, 2].Value = dr["namastok"];
                    ws1.Cells[idx, 3].Value = Tools.isNull(dr["QtyAwal"], 0);
                    for (int x = 1; x <= hari; x++)
                    {
                        ws1.Cells[idx, x + 3].Value = Tools.isNull(dr["Q" + x], 0);
                    }
                    ws1.Cells[idx, hari+4].Formula = "=Sum(" + ws1.Cells[idx, 4].Address +
                        ":" + ws1.Cells[idx, hari+3].Address + ")";
                    ws1.Cells[idx, hari + 5].Formula = ws1.Cells[idx, 3].Address + "-" + ws1.Cells[idx, hari + 4].Address;
                    idx++;
                    
                    
                    //    Formula =
                    //"=Sum(" + ws1.Cells[startH+2, 4].Address +
                    //":" + ws1.Cells[startH+2, hari].Address + ")";
                }
                #endregion
                int btsTbl1 = idx - 1;
                #region Summary & Formatting

                ws1.Cells[1, 1, 1, MaxC].Merge = true;
                ws1.Cells[2, 1, 2, MaxC].Merge = true;
                ws1.Cells[3, 1, 3, MaxC].Merge = true;
                ws1.Cells[4, 1, 4, MaxC].Merge = true;

                ws1.Cells[1, 1, 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws1.Cells[1, 1, 4, MaxC].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws1.Cells[1, 1, 4, MaxC+2].Style.Font.Bold = true;


                ws1.Cells[startH, 1, startH + 1, MaxC+2].Style.Font.Bold = true;
                ws1.Cells[startH, 1, startH + 1, MaxC+2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Font.Bold = true;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws1.Cells[startH, 1, startH + 1, MaxC+2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[startH, 1, startH + 1, MaxC+2].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                var border = ws1.Cells[6, 1, btsTbl1, MaxC+2].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;

                //var border1b = ws1.Cells[btsTbl1 + 3, 1, idx, MaxC].Style.Border;
                //border1b.Bottom.Style =
                //border1b.Top.Style =
                //border1b.Left.Style =
                //border1b.Right.Style = ExcelBorderStyle.Thin;

                ws1.Cells[startH + 2, 1, btsTbl1, 1].Style.Numberformat.Format = "#,###,###";
                ws1.Cells[startH + 2, 3, btsTbl1, MaxC+2].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 1, idx - 1, 1].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 3, idx - 1, MaxC].Style.Numberformat.Format = "#,###,###";

                #endregion

                #endregion
                #region sheet2
                p.Workbook.Worksheets.Add("Dashboard Monitoring");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[2];

                //DataTable dt1a = new DataTable();
                //DataTable dt1b = new DataTable();
                dt1a = ds.Tables[0].Copy();
                //dt1b = ds.Tables[1].Copy();

                ws2.Name = "Sheet2"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";

                //string Title = "DASHBOARD MONITORING";
                //string periode = "PERIODE : " + dateTextBox1.DateValue.Value.ToString("MM-yyyy");

                ws2.Cells[1, 1].Value = Title;
                ws2.Cells[1, 1].Style.Font.Size = 16;
                ws2.Cells[2, 1].Value = periode;
                ws2.Cells[3, 1].Value = "KODE CABANG : " + GlobalVar.Gudang;
                ws2.Cells[4, 1].Value = "TGL PROSES : " + GlobalVar.DateOfServer.Date.ToString("dd-MM-yyyy");
                ws2.Cells[2, 1, 4, 1].Style.Font.Size = 12;

                ws2.Cells[6, 1].Worksheet.Column(1).Width = 15;
                ws2.Cells[6, 2].Worksheet.Column(2).Width = 60;
                ws2.Cells[6, 3].Worksheet.Column(3).Width = 12;

                for (int x = 4; x <= hari + 1; x++)
                {
                    ws2.Cells[6, x].Worksheet.Column(x).Width = 12;
                }


                //int startH = 6;
                //int MaxC = hari + 2;

                #region Generate Header table 1
                ws2.Cells[startH, 1].Value = "Kode Barang";
                ws2.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws2.Cells[startH, 2].Value = "Nama Barang";
                ws2.Cells[startH, 2, startH + 1, 2].Merge = true;
                ws2.Cells[startH, 3].Value = "Stock Awal";
                ws2.Cells[startH + 1, 3].Value = "RP";
                ws2.Cells[startH, 4].Value = dateTextBox1.DateValue.Value.Date.ToString("MMM yyyy");
                ws2.Cells[startH, 4, startH, MaxC].Merge = true;

                for (int x = 1; x <= hari; x++)
                {
                    ws2.Cells[startH + 1, x + 3].Value = x.ToString();
                }
                ws2.Cells[startH, hari + 4].Value = "Total";
                ws2.Cells[startH, hari + 4, startH + 1, hari + 4].Merge = true;
                ws2.Cells[startH, hari + 5].Value = "Saldo Akhir";
                ws2.Cells[startH, hari + 5, startH + 1, hari + 5].Merge = true;
                #endregion

                #region FillData table 1
                idx = 6 + 2;

                foreach (DataRow dr in dt1a.Rows)
                {
                    
                    ws2.Cells[idx, 1].Value = dr["BarangID"];
                    ws2.Cells[idx, 2].Value = dr["namastok"];
                    ws2.Cells[idx, 3].Value = Tools.isNull(dr["RpAwal"], 0);
                    for (int x = 1; x <= hari; x++)
                    {
                        ws2.Cells[idx, x + 3].Value = Tools.isNull(dr["N" + x], 0);
                    }
                    ws2.Cells[idx, hari + 4].Formula = "=Sum(" + ws2.Cells[idx, 4].Address +
                        ":" + ws2.Cells[idx, hari + 3].Address + ")";
                    ws2.Cells[idx, hari + 5].Formula = ws2.Cells[idx, 3].Address + "-" + ws2.Cells[idx, hari + 4].Address;
                    idx++;
                }
                #endregion
                //int btsTbl1 = idx - 1;
                #region Summary & Formatting

                ws2.Cells[1, 1, 1, MaxC].Merge = true;
                ws2.Cells[2, 1, 2, MaxC].Merge = true;
                ws2.Cells[3, 1, 3, MaxC].Merge = true;
                ws2.Cells[4, 1, 4, MaxC].Merge = true;

                ws2.Cells[1, 1, 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws2.Cells[1, 1, 4, MaxC].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[1, 1, 4, MaxC+2].Style.Font.Bold = true;


                ws2.Cells[startH, 1, startH + 1, MaxC + 2].Style.Font.Bold = true;
                ws2.Cells[startH, 1, startH + 1, MaxC + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Font.Bold = true;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws2.Cells[startH, 1, startH + 1, MaxC + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[startH, 1, startH + 1, MaxC + 2].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                border = ws2.Cells[6, 1, btsTbl1, MaxC + 2].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;

                //var border1b = ws1.Cells[btsTbl1 + 3, 1, idx, MaxC].Style.Border;
                //border1b.Bottom.Style =
                //border1b.Top.Style =
                //border1b.Left.Style =
                //border1b.Right.Style = ExcelBorderStyle.Thin;

                ws2.Cells[startH + 2, 1, btsTbl1, 1].Style.Numberformat.Format = "#,###,###";
                ws2.Cells[startH + 2, 3, btsTbl1, MaxC + 2].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 1, idx - 1, 1].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 3, idx - 1, MaxC].Style.Numberformat.Format = "#,###,###";

                #endregion

                #endregion
                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Dashboard Monitoring " + DateTime.Now.ToString("dd-mm-yyyy") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
