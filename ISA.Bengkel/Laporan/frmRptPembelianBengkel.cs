using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
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
    public partial class frmRptPembelianBengkel : ISA.Bengkel.BaseForm
    {
        public frmRptPembelianBengkel()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptPembelianBengkel_Load(object sender, EventArgs e)
        {
            rgbTglbeli.FromDate = DateTime.Now.AddDays((DateTime.Now.Day-1)*-1);
            rgbTglbeli.ToDate = DateTime.Now;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtpb = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PembelianBengkel"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rgbTglbeli.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rgbTglbeli.ToDate.Value));
                    dtpb = db.Commands[0].ExecuteDataTable();
                    DisplayReport(dtpb);
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
                exs.Add(rptPembelianBengkel(dt));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_PembelianBengkel";

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


        private ExcelPackage rptPembelianBengkel(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Pembelian Bengkel";
            ex.Workbook.Properties.SetCustomPropertyValue("Bengkel", "1147");

            ex.Workbook.Worksheets.Add("Pembelian Bengkel");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
            ws.Cells[1, 3].Worksheet.Column(3).Width = 23;      //pemasok
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tgl nota
            ws.Cells[1, 5].Worksheet.Column(5).Width = 11;      //no nota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //kode barang
            ws.Cells[1, 7].Worksheet.Column(7).Width = 60;      //nama barang
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //qty nota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //harga
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //jumlah

            int nRow = 0, nHeader = 0, Rowx = 0;

            if (dt.Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 1].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 1].Value = "Laporan Pembelian Bengkel";
                ws.Cells[nHeader, 1].Style.Font.Size = 14;
                ws.Cells[nHeader, 1].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", rgbTglbeli.FromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", rgbTglbeli.ToDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

                int MaxCol = 10;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Pemasok ";
                ws.Cells[Rowx, 4].Value = " Tgl Nota ";
                ws.Cells[Rowx, 5].Value = " No Nota ";
                ws.Cells[Rowx, 6].Value = " Kode Barang ";
                ws.Cells[Rowx, 7].Value = " Nama Barang ";
                ws.Cells[Rowx, 8].Value = " Qty Nota ";
                ws.Cells[Rowx, 9].Value = " Harga ";
                ws.Cells[Rowx, 10].Value = " Jumlah ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double Jumlah = 0;

                foreach (DataRow dr1 in dt.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["nama"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["Tgl_nota"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["no_nota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["id_brg"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["nama_stok"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["j_nota"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["h_beli"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = (Convert.ToDouble(Tools.isNull(dr1["j_sj"], "0").ToString()) * Convert.ToDouble(Tools.isNull(dr1["h_beli"], "0").ToString()));
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jumlah = (Convert.ToDouble(Tools.isNull(dr1["j_nota"], "0").ToString()) * Convert.ToDouble(Tools.isNull(dr1["h_beli"], "0").ToString()));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 10].Value = Tools.isNull(Jumlah, 0);
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
    }
}
