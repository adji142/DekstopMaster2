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

namespace ISA.Trading.Pembelian
{
    public partial class frmRptBackOrder_OrderPembelian : ISA.Controls.BaseForm
    {
        public frmRptBackOrder_OrderPembelian()
        {
            InitializeComponent();
        }

        private void frmRptBackOrder_OrderPembelian_Load(object sender, EventArgs e)
        {

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(rdbTglRq.FromDate.ToString());
                DateTime toDate = Convert.ToDateTime(rdbTglRq.ToDate.ToString());

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_BackOrder_OrderPembelian"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    if (lookupStock.BarangID != "[CODE]" && lookupStock.BarangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, lookupStock.BarangID));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReportBackOrder_PO(dt, fromDate, toDate);
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

        private void DisplayReportBackOrder_PO(DataTable dt, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapBackOrder_OrderPembelian(dt, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_BackOrder_PO";

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

        private ExcelPackage LapBackOrder_OrderPembelian(DataTable dt, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan BackOrder PO";
            ex.Workbook.Properties.SetCustomPropertyValue("Back Order PO", "1147");

            ex.Workbook.Worksheets.Add("BackOrder PO");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan rekap insentif OA

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //norq
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglrq
            ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //pemasok
            ws.Cells[1, 6].Worksheet.Column(6).Width = 10;      //nonota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //tglnota
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //kodebarang
            ws.Cells[1, 9].Worksheet.Column(9).Width = 60;      //namabarang
            ws.Cells[1, 10].Worksheet.Column(10).Width = 5;     //sat
            ws.Cells[1, 11].Worksheet.Column(11).Width = 13;    //hppa
            ws.Cells[1, 12].Worksheet.Column(12).Width = 13;    //qtyorder
            ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //rporder
            ws.Cells[1, 14].Worksheet.Column(14).Width = 13;    //qtybeli
            ws.Cells[1, 15].Worksheet.Column(15).Width = 13;    //rpbeli
            ws.Cells[1, 16].Worksheet.Column(16).Width = 13;    //qtybo
            ws.Cells[1, 17].Worksheet.Column(17).Width = 13;    //rpbo

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan BackOrder PO";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 2;
            Rowx = nRow;
            int MaxCol = 17;

            Rowx++;
            nRow = Rowx;

            for (int i = 2; i <= MaxCol; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No RQ ";
            ws.Cells[Rowx, 4].Value = " Tgl RQ ";
            ws.Cells[Rowx, 5].Value = " Pemasok ";
            ws.Cells[Rowx, 6].Value = " No Nota ";
            ws.Cells[Rowx, 7].Value = " Tgl Nota ";
            ws.Cells[Rowx, 8].Value = " Kode Barang ";
            ws.Cells[Rowx, 9].Value = " Nama Barang ";
            ws.Cells[Rowx, 10].Value = " Sat ";
            ws.Cells[Rowx, 11].Value = " Hppa ";
            ws.Cells[Rowx, 12].Value = " Qty Order ";
            ws.Cells[Rowx, 13].Value = " Rp Order ";
            ws.Cells[Rowx, 14].Value = " Qty Beli ";
            ws.Cells[Rowx, 15].Value = " Rp Beli ";
            ws.Cells[Rowx, 16].Value = " Qty BO ";
            ws.Cells[Rowx, 17].Value = " Rp BO ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0, QtyRq = 0, QtyReal = 0, QtyBO = 0;
            double JmlOrder = 0, JmlReal = 0, JmlBo = 0 ;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoRequest"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglRequest"]);
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Pemasok"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["NoRequest"], "").ToString();
                    ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglRequest"],""));
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["BarangID"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["SatJual"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["QtyTambahan"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["JumlahOrder"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["QtyRealisasi"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["JumlahReal"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["QtyBO"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["RpBO"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";

                    QtyRq += Convert.ToInt32(Tools.isNull(dr1["QtyTambahan"], "0").ToString());
                    QtyReal += Convert.ToInt32(Tools.isNull(dr1["QtyRealisasi"], "0").ToString());
                    QtyBO += Convert.ToInt32(Tools.isNull(dr1["QtyBO"], "0").ToString());
                    JmlOrder += Convert.ToDouble(Tools.isNull(dr1["JumlahOrder"], "0").ToString());
                    JmlReal += Convert.ToDouble(Tools.isNull(dr1["JumlahReal"], "0").ToString());
                    JmlBo += Convert.ToDouble(Tools.isNull(dr1["RpBO"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

            ws.Cells[Rowx, 12].Value = Tools.isNull(QtyRq, 0);
            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 12].Style.Font.Bold = true;

            ws.Cells[Rowx, 13].Value = Tools.isNull(JmlOrder, 0);
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 13].Style.Font.Bold = true;

            ws.Cells[Rowx, 14].Value = Tools.isNull(QtyReal, 0);
            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 14].Style.Font.Bold = true;

            ws.Cells[Rowx, 15].Value = Tools.isNull(JmlReal, 0);
            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 15].Style.Font.Bold = true;

            ws.Cells[Rowx, 16].Value = Tools.isNull(QtyBO, 0);
            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 16].Style.Font.Bold = true;

            ws.Cells[Rowx, 17].Value = Tools.isNull(JmlBo, 0);
            ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 17].Style.Font.Bold = true;

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

            border = ws.Cells[Rowx, 12, Rowx, MaxCol].Style.Border;
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

            return ex;
        }
    }
}
