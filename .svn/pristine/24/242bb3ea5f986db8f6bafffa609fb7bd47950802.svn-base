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
    public partial class frmLaporanInsentifPerBarang : ISA.Controls.BaseForm
    {
        public frmLaporanInsentifPerBarang()
        {
            InitializeComponent();
        }

        private void frmLaporanInsentifPerBarang_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (rangePeriode.FromDate != null && rangePeriode.ToDate != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_InsentifSales_PerBarang"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DateTime fromDate = Convert.ToDateTime(rangePeriode.FromDate.ToString());
                        DateTime toDate = Convert.ToDateTime(rangePeriode.ToDate.ToString());
                        DisplayReport(ds, fromDate, toDate);
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

        private void DisplayReport(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentif(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifSalesPerBarang";

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


        private ExcelPackage LapInsentif(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif Sales per Barang";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Sales", "1147");

            ex.Workbook.Worksheets.Add("Insentif Sales");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //kelompok
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //insentif

            int nRow = 0, nHeader = 0, Rowx = 0;

            //#region Laporan
            if (ds.Tables[0].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Insentif Sales per Barang";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FE";

                int MaxCol = 6;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Kelompok ";
                ws.Cells[Rowx, 6].Value = " Insentif ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0;
                double Ins1 = 0, Ins2 = 0, Dnda = 0, Jml = 0;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Klp"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    Ins1 += Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    //ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 6].Value = Tools.isNull(Ins1, 0);
                ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 6].Style.Font.Bold = true;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }


            /*Sheet Detail*/
            ex.Workbook.Worksheets.Add("Detail Insentif Sales per Barang");
            ws = ex.Workbook.Worksheets[2];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no nota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl nota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 31;      //namatoko
            ws.Cells[1, 8].Worksheet.Column(8).Width = 20;      //kota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //transactionType
            ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //kode barang
            ws.Cells[1, 11].Worksheet.Column(11).Width = 73;    //nama barang
            ws.Cells[1, 12].Worksheet.Column(12).Width = 5;     //sat
            ws.Cells[1, 13].Worksheet.Column(13).Width = 9;     //qty nota
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //het
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //hrgjual
            ws.Cells[1, 16].Worksheet.Column(16).Width = 7;     //disc1
            ws.Cells[1, 17].Worksheet.Column(17).Width = 7;     //disc2
            ws.Cells[1, 18].Worksheet.Column(18).Width = 7;     //disc3
            ws.Cells[1, 19].Worksheet.Column(19).Width = 12;    //potrp
            ws.Cells[1, 20].Worksheet.Column(20).Width = 12;    //potrp
            ws.Cells[1, 21].Worksheet.Column(21).Width = 7;     //persen
            ws.Cells[1, 22].Worksheet.Column(22).Width = 12;    //insentif
            ws.Cells[1, 23].Worksheet.Column(23).Width = 7;     //JTR

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Sales per Barang";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            int MaxCold = 23;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Kode Sales ";
            ws.Cells[Rowx, 4].Value = " Nama Sales ";
            ws.Cells[Rowx, 5].Value = " No Nota ";
            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
            ws.Cells[Rowx, 7].Value = " Nama Toko ";
            ws.Cells[Rowx, 8].Value = " Kota ";
            ws.Cells[Rowx, 9].Value = " TR ";
            ws.Cells[Rowx, 10].Value = " Kode Barang ";
            ws.Cells[Rowx, 11].Value = " Nama Stok ";
            ws.Cells[Rowx, 12].Value = " Sat ";
            ws.Cells[Rowx, 13].Value = " Qty Nota ";
            ws.Cells[Rowx, 14].Value = " HET ";
            ws.Cells[Rowx, 15].Value = " Hrg Jual ";
            ws.Cells[Rowx, 16].Value = " Disc1 ";
            ws.Cells[Rowx, 17].Value = " Disc2 ";
            ws.Cells[Rowx, 18].Value = " Disc3 ";
            ws.Cells[Rowx, 19].Value = " Pot Rp ";
            ws.Cells[Rowx, 20].Value = " Rp Nota ";
            ws.Cells[Rowx, 21].Value = " Persen ";
            ws.Cells[Rowx, 22].Value = " Insentif ";
            ws.Cells[Rowx, 23].Value = " Kode TR ";

            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int nod = 0, Jrec = 0, nRec = 0;
            double JmlInsentif = 0, TotInsentif = 0, Jmlfe = 0, Jmlbe = 0;
            string cKodeSales = "";
            string cKlp = "";
            string cAwal = "1";

            Jrec = ds.Tables[1].Rows.Count;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    nRec++;
                    if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 20].Value = "Jumlah";
                            ws.Cells[Rowx, 20].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 22].Value = Tools.isNull(Jmlfe, 0);
                            ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 22].Style.Font.Bold = true;
                            ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);
                            Rowx++;
                            Jmlfe = 0;

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCold].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;
                            ws.Cells[Rowx, 22].Value = Tools.isNull(JmlInsentif, 0);
                            ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 22].Style.Font.Bold = true;
                            Rowx++;
                            Rowx++;
                            JmlInsentif = 0;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Kode Sales ";
                            ws.Cells[Rowx, 4].Value = " Nama Sales ";
                            ws.Cells[Rowx, 5].Value = " No Nota ";
                            ws.Cells[Rowx, 6].Value = " Tgl Nota ";
                            ws.Cells[Rowx, 7].Value = " Nama Toko ";
                            ws.Cells[Rowx, 8].Value = " Kota ";
                            ws.Cells[Rowx, 9].Value = " TR ";
                            ws.Cells[Rowx, 10].Value = " Kode Barang ";
                            ws.Cells[Rowx, 11].Value = " Nama Stok ";
                            ws.Cells[Rowx, 12].Value = " Sat ";
                            ws.Cells[Rowx, 13].Value = " Qty Nota ";
                            ws.Cells[Rowx, 14].Value = " HET ";
                            ws.Cells[Rowx, 15].Value = " Hrg Jual ";
                            ws.Cells[Rowx, 16].Value = " Disc1 ";
                            ws.Cells[Rowx, 17].Value = " Disc2 ";
                            ws.Cells[Rowx, 18].Value = " Disc3 ";
                            ws.Cells[Rowx, 19].Value = " Pot Rp ";
                            ws.Cells[Rowx, 20].Value = " Rp Nota ";
                            ws.Cells[Rowx, 21].Value = " Persen ";
                            ws.Cells[Rowx, 22].Value = " Insentif ";
                            ws.Cells[Rowx, 23].Value = " Kode TR ";

                            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCold].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx++;
                        }
                    }

                    cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                    cAwal = "0";
                    nod += 1;
                    ws.Cells[Rowx, 2].Value = nod.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoNota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["BarangID"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["SatJual"], "").ToString();
                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["QtyNota"], "").ToString();
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 14].Value = Convert.ToDecimal(Tools.isNull(dr1["Het"], "").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 15].Value = Convert.ToDecimal(Tools.isNull(dr1["HrgJual"], "").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 16].Value = Convert.ToDecimal(Tools.isNull(dr1["disc1"], "").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 17].Value = Convert.ToDecimal(Tools.isNull(dr1["disc2"], "").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 18].Value = Convert.ToDecimal(Tools.isNull(dr1["disc3"], "").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 19].Value = Convert.ToDecimal(Tools.isNull(dr1["PotRp"], "").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 20].Value = Convert.ToDecimal(Tools.isNull(dr1["Nominal"], "").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 21].Value = Convert.ToDecimal(Tools.isNull(dr1["persen"], "").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 22].Value = Convert.ToDecimal(Tools.isNull(dr1["Insentif"], "").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 23].Value = Tools.isNull(dr1["Kode"], "").ToString();
                    ws.Cells[Rowx, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    JmlInsentif += Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    TotInsentif += Convert.ToDouble(Tools.isNull(dr1["Insentif"], "0").ToString());
                    Rowx++;
                }
            }

            if (nRec == Jrec)
            {
                ws.Cells[Rowx, 20].Value = "Jumlah";
                ws.Cells[Rowx, 20].Style.Font.Color.SetColor(Color.Red);
                ws.Cells[Rowx, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[Rowx, 22].Value = Tools.isNull(JmlInsentif, 0);
                ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 22].Style.Font.Bold = true;
                ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);
                Rowx++;

                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCold].Style.Border;
                border1.Bottom.Style = ExcelBorderStyle.Thin;
                border1.Top.Style =
                border1.Left.Style =
                border1.Right.Style = ExcelBorderStyle.None;
                ws.Cells[Rowx, 22].Value = Tools.isNull(JmlInsentif, 0);
                ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 22].Style.Font.Bold = true;
                Rowx++;

                ws.Cells[Rowx, 20].Value = "Total Insentif";
                ws.Cells[Rowx, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[Rowx, 22].Value = Tools.isNull(TotInsentif, 0);
                ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 22].Style.Font.Bold = true;
                ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);
            }

            Rowx += 1;
            nHeader = Rowx;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            return ex;
        }
    }
}
