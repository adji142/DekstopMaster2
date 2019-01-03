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

namespace ISA.Trading.Laporan.Salesman
{
    public partial class frmRptPenyelesaianOrderSales : ISA.Trading.BaseForm
    {

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
          
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptPenyelesaianOrderSales.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();

        }


        public frmRptPenyelesaianOrderSales()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (rdbSales.Checked)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database())
                    {
                        //db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenyelesaianOrderSales"));
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenyelesaianOrderSalesDetail"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    DateTime D1 = Convert.ToDateTime(rangeDateBox1.FromDate.ToString());
                    DateTime D2 = Convert.ToDateTime(rangeDateBox1.ToDate.ToString());

                    LaporanPenyelesaianOrderSales(ds, D1, D2);
                    //DisplayReport(ds);

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

            if (rdbDO.Checked)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database())
                    {
                        if (GlobalVar.Gudang != "2803")
                            db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenyelesaianOrderSalesDetail"));
                        else
                            db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenyelesaianOrderSalesDetail2803"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    DateTime D1 = Convert.ToDateTime(rangeDateBox1.FromDate.ToString());
                    DateTime D2 = Convert.ToDateTime(rangeDateBox1.ToDate.ToString());

                    LaporanPenyelesaianOrderSalesDetail(ds, D1, D2);
                    //DisplayReport(dt);

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

        private void frmRptPenyelesaianOrderSales_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rdbDO.Checked = true;
            rdbSales.Checked = false;
        }

        private void LaporanPenyelesaianOrderSalesDetail(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapOrderSalesDetail(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_PenyelesaianOrderSalesDetail";

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



        private ExcelPackage LapOrderSalesDetail(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Penyelesaian Order Sales Per DO";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Penyelesaian Order Sales", "1147");

            ex.Workbook.Worksheets.Add("Per DO");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan rekap insentif OA

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //nodo
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tgldo
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;      //kodesales
            ws.Cells[1, 6].Worksheet.Column(6).Width = 40;      //namatoko
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            ws.Cells[1, 8].Worksheet.Column(8).Width = 5;       //tr
            ws.Cells[1, 9].Worksheet.Column(9).Width = 13;      //DoA
            ws.Cells[1, 10].Worksheet.Column(10).Width = 13;      //DoB
            ws.Cells[1, 11].Worksheet.Column(11).Width = 13;    //DoE
            ws.Cells[1, 12].Worksheet.Column(12).Width = 13;    //RpDO
            ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //BObe
            ws.Cells[1, 14].Worksheet.Column(14).Width = 13;    //BOfx
            ws.Cells[1, 15].Worksheet.Column(15).Width = 13;    //pendingbe
            ws.Cells[1, 16].Worksheet.Column(16).Width = 13;    //Pendingfx
            ws.Cells[1, 17].Worksheet.Column(17).Width = 13;    //pendingoverduebe
            ws.Cells[1, 18].Worksheet.Column(18).Width = 13;    //Pendingoverduefx
            ws.Cells[1, 19].Worksheet.Column(19).Width = 13;    //plafonFB
            ws.Cells[1, 20].Worksheet.Column(20).Width = 13;    //plafonFX
            ws.Cells[1, 21].Worksheet.Column(21).Width = 13;    //plafonFB
            ws.Cells[1, 22].Worksheet.Column(22).Width = 13;    //plafonFX
            ws.Cells[1, 23].Worksheet.Column(23).Width = 13;    //jumlah

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Penyelesaian Order Sales Detail";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 2;
            Rowx = nRow;
            int MaxCol = 23;

            Rowx++;
            nRow = Rowx;

            for (int i = 2; i <= 12; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }
            ws.Cells[Rowx, 13, Rowx, 14].Merge = true;
            ws.Cells[Rowx, 15, Rowx, 23].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No DO ";
            ws.Cells[Rowx, 4].Value = " Tgl DO ";
            ws.Cells[Rowx, 5].Value = " Kode Sales ";
            ws.Cells[Rowx, 6].Value = " Nama Toko ";
            ws.Cells[Rowx, 7].Value = " Idwil ";
            ws.Cells[Rowx, 8].Value = " TR ";
            ws.Cells[Rowx, 9].Value = " DO A ";
            ws.Cells[Rowx, 10].Value = " DO B ";
            ws.Cells[Rowx, 11].Value = " DO E ";
            ws.Cells[Rowx, 12].Value = " Rp DO ";

            ws.Cells[Rowx, 13].Value = " BACK ORDER ";
            ws.Cells[Rowx + 1, 13].Value = " BO BE ";
            ws.Cells[Rowx + 1, 14].Value = " BO FA ";

            ws.Cells[Rowx, 15].Value = " P E N D I N G ";
            ws.Cells[Rowx + 1, 15].Value = " Penjualan BE ";
            ws.Cells[Rowx + 1, 16].Value = " Penjualan FA ";

            ws.Cells[Rowx + 1, 17].Value = " Overdue BE ";
            ws.Cells[Rowx + 1, 18].Value = " Overdue FA ";

            ws.Cells[Rowx + 1, 19].Value = " Plafon BE ";
            ws.Cells[Rowx + 1, 20].Value = " Plafon FA ";

            ws.Cells[Rowx + 1, 21].Value = " Acc Harga FB ";
            ws.Cells[Rowx + 1, 22].Value = " Acc Harga FA ";

            ws.Cells[Rowx + 1, 23].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double nPending = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoDO"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["KodeSales"], "0").ToString();

                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["NamaToko"], "0").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["WilID"], "0").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["TransactionType"], "0").ToString();
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["DOA"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["DOB"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["DOE"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NBOFB"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NBOFX"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["nPendingFB"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["nPendingFX"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["PendingOverdueFB"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["PendingOverdueFX"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["PendingPlafonFB"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["PendingPlafonFX"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["TolakHargaFB"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["TolakHargaFX"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Pending"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);";

                    nPending += Convert.ToDouble(Tools.isNull(dr1["Pending"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;

            ws.Cells[Rowx, 6].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 6].Style.Font.Bold = true;

            ws.Cells[Rowx, 23].Value = Tools.isNull(nPending, 0);
            ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 23].Style.Font.Bold = true;

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

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion

            return ex;
        }

        private void LaporanPenyelesaianOrderSales(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapOrderSales(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_PenyelesaianOrderSales";

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


        private ExcelPackage LapOrderSales(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Penyelesaian Order Sales Per Sales";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Penyelesaian Order Sales Per Sales", "1147");

            ex.Workbook.Worksheets.Add("Per Sales");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan Penyelesaian Order Sales

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //kodesales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      //qtytoko
            ws.Cells[1, 5].Worksheet.Column(5).Width = 12;      //doa
            ws.Cells[1, 6].Worksheet.Column(6).Width = 12;      //dob
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //doe
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //reala
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //realb
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //reale
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;    //DoE
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;    //RpDO
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;    //BObe
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //BOfx
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //pendingbe
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //Pendingfx
            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //pendingoverduebe
            ws.Cells[1, 18].Worksheet.Column(18).Width = 12;    //Pendingoverduefx
            ws.Cells[1, 19].Worksheet.Column(19).Width = 12;    //plafonFB
            ws.Cells[1, 20].Worksheet.Column(20).Width = 12;    //plafonFX
            ws.Cells[1, 21].Worksheet.Column(21).Width = 12;    //tolakhargaFB
            ws.Cells[1, 22].Worksheet.Column(22).Width = 12;    //tolakhargaFX
            ws.Cells[1, 23].Worksheet.Column(23).Width = 12;    //jumlah

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Penyelesaian Order Sales";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 2;
            Rowx = nRow;
            int MaxCol = 23;

            Rowx++;
            nRow = Rowx;

            for (int i = 2; i <= 4; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }
            ws.Cells[Rowx, 5, Rowx, 7].Merge = true;
            ws.Cells[Rowx, 8, Rowx, 10].Merge = true;
            ws.Cells[Rowx, 11, Rowx, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx, 14].Merge = true;
            ws.Cells[Rowx, 15, Rowx, 23].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Jml Toko ";
            ws.Cells[Rowx, 5].Value = " SALES ORDER ";
            ws.Cells[Rowx + 1, 5].Value = " DO A ";
            ws.Cells[Rowx + 1, 6].Value = " DO B ";
            ws.Cells[Rowx + 1, 7].Value = " DO E ";
            ws.Cells[Rowx, 8].Value = " REALISASI ";
            ws.Cells[Rowx + 1, 8].Value = " FA ";
            ws.Cells[Rowx + 1, 9].Value = " FB ";
            ws.Cells[Rowx + 1, 10].Value = " FE ";
            ws.Cells[Rowx, 11].Value = " RETUR ";
            ws.Cells[Rowx + 1, 11].Value = " BE ";
            ws.Cells[Rowx + 1, 12].Value = " FA ";
            ws.Cells[Rowx, 13].Value = " BACK ORDER ";
            ws.Cells[Rowx + 1, 13].Value = " BO BE ";
            ws.Cells[Rowx + 1, 14].Value = " BO FA ";

            ws.Cells[Rowx, 15].Value = " P E N D I N G ";
            ws.Cells[Rowx + 1, 15].Value = " Penjualan BE ";
            ws.Cells[Rowx + 1, 16].Value = " Penjualan FA ";

            ws.Cells[Rowx + 1, 17].Value = " Overdue BE ";
            ws.Cells[Rowx + 1, 18].Value = " Overdue FA ";

            ws.Cells[Rowx + 1, 19].Value = " Plafon BE ";
            ws.Cells[Rowx + 1, 20].Value = " Plafon FA ";

            ws.Cells[Rowx + 1, 21].Value = " Acc Harga BE ";
            ws.Cells[Rowx + 1, 22].Value = " Acc Harga FA ";

            ws.Cells[Rowx + 1, 23].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double nPending = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "0").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["QtyToko"], "0").ToString();
                    ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["DOA"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["DOB"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["DOE"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["RealA"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["RealB"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["RealE"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["NominalReturFB"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["NominalReturFX"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["NBOFB"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["NBOFX"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["NominalPendingFB"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["NominalPendingFX"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["PendingOverdueFB"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["PendingOverdueFX"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["PendingPlafonFB"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["PendingPlafonFX"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["TolakHargaFB"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["TolakHargaFX"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);";

                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Pending"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);";

                    nPending += Convert.ToDouble(Tools.isNull(dr1["Pending"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;

            ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 3].Style.Font.Bold = true;

            ws.Cells[Rowx, 23].Value = Tools.isNull(nPending, 0);
            ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 23].Style.Font.Bold = true;

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

            ws.Cells[Rowx + 1, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx + 1, 2].Style.Font.Size = 8;
            ws.Cells[Rowx + 1, 2].Style.Font.Italic = true;

            #endregion

            return ex;
        }
    }
}
