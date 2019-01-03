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


namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmRptAnalisaPergerakanBarangdanrealisasiPenjualan : ISA.Controls.BaseForm
    {
        public frmRptAnalisaPergerakanBarangdanrealisasiPenjualan()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptAnalisaPergerakanBarangdanrealisasiPenjualan_Load(object sender, EventArgs e)
        {
            dtTanggal.DateValue = DateTime.Now;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("rsp_AnalisaPembelianPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, dtTanggal.DateValue));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DisplayReport(ds);
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


        private void DisplayReport(DataSet ds)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapAnalisaPembelianPenjualan(ds));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_AnalisaPergerakanBarang";

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


        private ExcelPackage LapAnalisaPembelianPenjualan(DataSet ds)
        {
            DateTime now = Convert.ToDateTime(dtTanggal.DateValue);
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan";
            ex.Workbook.Properties.SetCustomPropertyValue("Analisa", "1147");

            ex.Workbook.Worksheets.Add("Analisa Stok");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            #region pergerakan stok
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 6;       //depo
            ws.Cells[1, 3].Worksheet.Column(3).Width = 11;      //periode
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //periode
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //periode
            ws.Cells[1, 6].Worksheet.Column(6).Width = 10;      //qty awal
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //hpp awal
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //qty ag masuk
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //hpp ag masuk
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //qty ag balik
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //hpp ag balik
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;    //qty jual tunai
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //hpp jual tunai
            ws.Cells[1, 14].Worksheet.Column(14).Width = 10;    //qty jual kredit
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //hpp jual kredit
            ws.Cells[1, 16].Worksheet.Column(16).Width = 10;    //qty ret
            ws.Cells[1, 17].Worksheet.Column(17).Width = 15;    //hpp ret
            ws.Cells[1, 18].Worksheet.Column(18).Width = 10;    //qty akhir
            ws.Cells[1, 19].Worksheet.Column(19).Width = 15;    //hpp akhir

            int nRow = 0, nHeader = 0, Rowx = 0, Rowa = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                nHeader++;
                nRow = nHeader + 4;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan analisa pergerakan barang dan realisasi penjualan";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Kategori";
                ws.Cells[nHeader + 1, 4].Value = ": Non BE (Busi,Accu,Oli,Ban dan sparepart)";
                ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang";
                ws.Cells[nHeader + 2, 4].Value = ": FAB,FC dan FX";
                ws.Cells[nHeader + 3, 2].Value = "Periode";
                ws.Cells[nHeader + 3, 4].Value = ": " + string.Format("{0:dd-MMM-yyyy}", startDate) + "  s/d  " + string.Format("{0:dd-MMM-yyyy}", endDate);

                int MaxCol = 19;

                ws.Cells[Rowx, 2, Rowx + 3, MaxCol].Style.Font.Size = 10;

                ws.Cells[Rowx, 2, Rowx + 2, 2].Merge = true;
                ws.Cells[Rowx, 2].Value = " Depo ";
                ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 3, Rowx + 2, 3].Merge = true;
                ws.Cells[Rowx, 3].Value = " Periode ";
                ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 4, Rowx + 2, 4].Merge = true;
                ws.Cells[Rowx, 4].Value = " Tanggal-1 ";
                ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 5, Rowx + 2, 5].Merge = true;
                ws.Cells[Rowx, 5].Value = " Tanggal-2 ";
                ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 6, Rowx + 1, 7].Merge = true;
                ws.Cells[Rowx, 6].Value = " Saldo Awal ";
                ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[Rowx + 2, 6].Value = " Qty ";
                ws.Cells[Rowx + 2, 7].Value = " Nominal (Hpp) ";

                ws.Cells[Rowx, 8, Rowx, 11].Merge = true;
                ws.Cells[Rowx + 1, 8, Rowx + 1, 9].Merge = true;
                ws.Cells[Rowx + 1, 10, Rowx + 1, 11].Merge = true;
                ws.Cells[Rowx, 8].Value = " Realisasi Pemenuhan Barang (Netto) ";
                ws.Cells[Rowx + 1, 8].Value = " Penjualan HO ke Depo ";
                ws.Cells[Rowx + 1, 10].Value = " Retur Beli dari depo ke HO ";
                ws.Cells[Rowx + 2, 8].Value = " Qty ";
                ws.Cells[Rowx + 2, 9].Value = " Nominal (Hpp) ";
                ws.Cells[Rowx + 2, 10].Value = " Qty ";
                ws.Cells[Rowx + 2, 11].Value = " Nominal (Hpp) ";

                ws.Cells[Rowx, 12, Rowx, 15].Merge = true;
                ws.Cells[Rowx + 1, 12, Rowx + 1, 13].Merge = true;
                ws.Cells[Rowx + 1, 14, Rowx + 1, 15].Merge = true;
                ws.Cells[Rowx, 12].Value = " Realisasi Penjualan Depo ";
                ws.Cells[Rowx + 1, 12].Value = " Penjualan Tunai (Brutto) ";
                ws.Cells[Rowx + 1, 14].Value = " Penjualan Kredit (Brutto) ";
                ws.Cells[Rowx + 2, 12].Value = " Qty ";
                ws.Cells[Rowx + 2, 13].Value = " Nominal (Hpp) ";
                ws.Cells[Rowx + 2, 14].Value = " Qty ";
                ws.Cells[Rowx + 2, 15].Value = " Nominal (Hpp) ";

                ws.Cells[Rowx, 16, Rowx + 1, 17].Merge = true;
                ws.Cells[Rowx, 16].Value = " Retur ";
                ws.Cells[Rowx, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[Rowx + 2, 16].Value = " Qty ";
                ws.Cells[Rowx + 2, 17].Value = " Nominal (Hpp) ";

                ws.Cells[Rowx, 18, Rowx + 1, 19].Merge = true;
                ws.Cells[Rowx, 18].Value = " Stok Akhir ";
                ws.Cells[Rowx, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 18].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[Rowx + 2, 18].Value = " Qty ";
                ws.Cells[Rowx + 2, 19].Value = " Nominal (Hpp) ";

                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                var borderh = ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Border;
                borderh.Bottom.Style =
                borderh.Top.Style =
                borderh.Left.Style =
                borderh.Right.Style = ExcelBorderStyle.Thin;
                Rowx += 3;
                Rowa = Rowx;

                int no = 0, nQawal = 0, nQakhir = 0, nQtyAG = 0, nQtyAGB = 0, nQtyJualT = 0, nQtyJualK = 0, nQtyRet = 0;
                double nHawal = 0, nHakhir = 0, nHppAG = 0, nHppAGB = 0, nHppJualT = 0, nHppJualK = 0, nHppRet = 0;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["Depo"], "").ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["Periode"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["Tgl1"], ""));
                    ws.Cells[Rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["Tgl2"], ""));
                    ws.Cells[Rowx, 6].Value = Convert.ToInt32(Tools.isNull(dr1["QtyAwal"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["HppAwal"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToInt32(Tools.isNull(dr1["QtyAG"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["HppAG"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToInt32(Tools.isNull(dr1["QtyAGB"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["HppAGB"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToInt32(Tools.isNull(dr1["QtyJualT"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["HppJualT"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToInt32(Tools.isNull(dr1["QtyJualK"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["HppJualK"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToInt32(Tools.isNull(dr1["QtyRet"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["HppRet"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToInt32(Tools.isNull(dr1["QtyAkhir"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["HppAkhir"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";

                    nQtyAG += Convert.ToInt32(Tools.isNull(dr1["QtyAG"], "0").ToString());
                    nHppAG += Convert.ToDouble(Tools.isNull(dr1["HppAG"], "0").ToString());
                    nQtyAGB += Convert.ToInt32(Tools.isNull(dr1["QtyAGB"], "0").ToString());
                    nHppAGB += Convert.ToDouble(Tools.isNull(dr1["HppAGB"], "0").ToString());
                    nQtyJualT += Convert.ToInt32(Tools.isNull(dr1["QtyJualT"], "0").ToString());
                    nHppJualT += Convert.ToDouble(Tools.isNull(dr1["HppJualT"], "0").ToString());
                    nQtyJualK += Convert.ToInt32(Tools.isNull(dr1["QtyJualK"], "0").ToString());
                    nHppJualK += Convert.ToDouble(Tools.isNull(dr1["HppJualK"], "0").ToString());
                    nQtyRet += Convert.ToInt32(Tools.isNull(dr1["QtyRet"], "0").ToString());
                    nHppRet += Convert.ToDouble(Tools.isNull(dr1["HppRet"], "0").ToString());
                    nQawal = Convert.ToInt32(Tools.isNull(dr1["QtyAwal"], "0").ToString());
                    nHawal = Convert.ToDouble(Tools.isNull(dr1["HppAwal"], "0").ToString());
                    nQakhir = Convert.ToInt32(Tools.isNull(dr1["QtyAkhir"], "0").ToString());
                    nHakhir = Convert.ToDouble(Tools.isNull(dr1["HppAkhir"], "0").ToString());
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 8].Value = Tools.isNull(nQtyAG, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;
                ws.Cells[Rowx, 9].Value = Tools.isNull(nHppAG, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nQtyAGB, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;
                ws.Cells[Rowx, 11].Value = Tools.isNull(nHppAGB, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                ws.Cells[Rowx, 12].Value = Tools.isNull(nQtyJualT, 0);
                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 12].Style.Font.Bold = true;
                ws.Cells[Rowx, 13].Value = Tools.isNull(nHppJualT, 0);
                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 13].Style.Font.Bold = true;

                ws.Cells[Rowx, 14].Value = Tools.isNull(nQtyJualK, 0);
                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                ws.Cells[Rowx, 15].Value = Tools.isNull(nHppJualK, 0);
                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 15].Style.Font.Bold = true;

                ws.Cells[Rowx, 16].Value = Tools.isNull(nQtyRet, 0);
                ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 16].Style.Font.Bold = true;
                ws.Cells[Rowx, 17].Value = Tools.isNull(nHppRet, 0);
                ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 17].Style.Font.Bold = true;

                ws.Cells[Rowx, 18].Value = Tools.isNull(nQakhir, 0);
                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                ws.Cells[Rowx, 19].Value = Tools.isNull(nHakhir, 0);
                ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 19].Style.Font.Bold = true;

                ws.Cells[Rowa, 2, Rowx, MaxCol].Style.Font.Size = 10;

                var border = ws.Cells[Rowa, 2, Rowx - 1, MaxCol].Style.Border;
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

                Rowx += 1;
                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            #endregion

            //Detail penjualan-----------------------------------------------------------------
            ex.Workbook.Worksheets.Add("Penjualan");
            ws = ex.Workbook.Worksheets[2];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 14;      //kode sales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 23;      //nama sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 31;      //nama toko
            ws.Cells[1, 6].Worksheet.Column(6).Width = 25;      //daerah
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //wilid
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //no nota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 13;      //tgl nota
            ws.Cells[1, 10].Worksheet.Column(10).Width = 4;     //klp
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;    //debet
            ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //lunas <= 2 minggu
            ws.Cells[1, 13].Worksheet.Column(13).Width = 14;    //lunas > 2 minggu
            ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //penjualan tunai

            ws.Cells[1, 15].Worksheet.Column(15).Width = 14;     //kas
            ws.Cells[1, 16].Worksheet.Column(16).Width = 14;    //transfer
            ws.Cells[1, 17].Worksheet.Column(17).Width = 14;    //giro cair
            ws.Cells[1, 18].Worksheet.Column(18).Width = 14;    //retur
            ws.Cells[1, 19].Worksheet.Column(19).Width = 14;    //kpj
            ws.Cells[1, 20].Worksheet.Column(20).Width = 14;    //krj
            ws.Cells[1, 21].Worksheet.Column(21).Width = 14;    //pot
            ws.Cells[1, 22].Worksheet.Column(22).Width = 14;    //adj
            ws.Cells[1, 23].Worksheet.Column(23).Width = 14;    //adj
            ws.Cells[1, 24].Worksheet.Column(24).Width = 14;    //adj

            ws.Cells[1, 25].Worksheet.Column(25).Width = 5;     //tr
            ws.Cells[1, 26].Worksheet.Column(26).Width = 14;    //umur piutang
            ws.Cells[1, 27].Worksheet.Column(27).Width = 14;    //ovd rp
            ws.Cells[1, 28].Worksheet.Column(28).Width = 14;    //ovd hari

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Penjualan";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", startDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", endDate);

                int MaxCol = 28;

                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                ws.Cells[Rowx, 5].Value = " Nama Toko ";
                ws.Cells[Rowx, 6].Value = " Daerah ";
                ws.Cells[Rowx, 7].Value = " WilID ";
                ws.Cells[Rowx, 8].Value = " No Nota ";
                ws.Cells[Rowx, 9].Value = " Tgl Nota ";
                ws.Cells[Rowx, 10].Value = " Klp ";
                ws.Cells[Rowx, 11].Value = " Omset ";

                ws.Cells[Rowx, 12].Value = " Lunas<=2mg";
                ws.Cells[Rowx, 13].Value = " Lunas >2mg";
                ws.Cells[Rowx, 14].Value = " PJ TUNAI";

                ws.Cells[Rowx, 15].Value = " Kas ";
                ws.Cells[Rowx, 16].Value = " TRANSFER ";
                ws.Cells[Rowx, 17].Value = " GIRO CAIR ";
                ws.Cells[Rowx, 18].Value = " RET ";
                ws.Cells[Rowx, 19].Value = " KPJ ";
                ws.Cells[Rowx, 20].Value = " KRJ ";
                ws.Cells[Rowx, 21].Value = " POT ";
                ws.Cells[Rowx, 22].Value = " ADJ ";
                ws.Cells[Rowx, 23].Value = " PLL ";
                ws.Cells[Rowx, 24].Value = " MUT ";

                ws.Cells[Rowx, 25].Value = " TR ";
                ws.Cells[Rowx, 26].Value = " Umur Piut ";
                ws.Cells[Rowx, 27].Value = " Overdue ";
                ws.Cells[Rowx, 28].Value = " Lama Ovd ";

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 11, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                Rowx++;

                int no = 0, Jrec = 0, nRec = 0;
                double Joms = 0, Jks = 0, Jld = 0, Jtu = 0, Jkas = 0, Jtrn = 0, Jgrc = 0, Jret = 0, Jkpj = 0, Jkrj = 0,
                       Jpot = 0, Jadj = 0, Jpll = 0, Jmut = 0, Jovd = 0,
                       Toms = 0, Tks = 0, Tld = 0, Ttu = 0, Tkas = 0, Ttrn = 0, Tgrc = 0, Tret = 0, Tkpj = 0, Tkrj = 0,
                       Tpot = 0, Tadj = 0, Tpll = 0, Tmut = 0, Tovd = 0;

                string cKodeSales = "";
                string cKlp = "1FX";
                string cAwal = "1";

                Jrec = ds.Tables[1].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    nRec++;
                    if (Tools.isNull(dr1["Klp"], "").ToString() == "1FX")
                    {
                        if (cKodeSales != Tools.isNull(dr1["KodeSales"], "").ToString())
                        {
                            if (cAwal != "1")
                            {
                                ws.Cells[Rowx, 9].Value = "Jumlah";
                                ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Red);
                                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ws.Cells[Rowx, 11].Value = Tools.isNull(Joms, 0);
                                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 11].Style.Font.Bold = true;
                                ws.Cells[Rowx, 11].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 12].Value = Tools.isNull(Jks, 0);
                                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 12].Style.Font.Bold = true;
                                ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 13].Value = Tools.isNull(Jld, 0);
                                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 13].Style.Font.Bold = true;
                                ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 14].Value = Tools.isNull(Jtu, 0);
                                ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 14].Style.Font.Bold = true;
                                ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 15].Value = Tools.isNull(Jkas, 0);
                                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 15].Style.Font.Bold = true;
                                ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 16].Value = Tools.isNull(Jtrn, 0);
                                ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 16].Style.Font.Bold = true;
                                ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 17].Value = Tools.isNull(Jgrc, 0);
                                ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 17].Style.Font.Bold = true;
                                ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 18].Value = Tools.isNull(Jret, 0);
                                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 18].Style.Font.Bold = true;
                                ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 19].Value = Tools.isNull(Jkpj, 0);
                                ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 19].Style.Font.Bold = true;
                                ws.Cells[Rowx, 19].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 20].Value = Tools.isNull(Jkrj, 0);
                                ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 20].Style.Font.Bold = true;
                                ws.Cells[Rowx, 20].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 21].Value = Tools.isNull(Jpot, 0);
                                ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 21].Style.Font.Bold = true;
                                ws.Cells[Rowx, 21].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 22].Value = Tools.isNull(Jadj, 0);
                                ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 22].Style.Font.Bold = true;
                                ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 23].Value = Tools.isNull(Jpll, 0);
                                ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 23].Style.Font.Bold = true;
                                ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 24].Value = Tools.isNull(Jmut, 0);
                                ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 24].Style.Font.Bold = true;
                                ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                                ws.Cells[Rowx, 27].Value = Tools.isNull(Jovd, 0);
                                ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                                ws.Cells[Rowx, 27].Style.Font.Bold = true;
                                ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);

                                Rowx++;

                                Joms = 0; Jks = 0; Jld = 0; Jtu = 0; Jkas = 0; Jtrn = 0; Jgrc = 0; Jret = 0; Jkpj = 0; Jkrj = 0;
                                Jpot = 0; Jadj = 0; Jpll = 0; Jmut = 0; Jovd = 0;

                                var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                                border1.Bottom.Style = ExcelBorderStyle.Thin;
                                border1.Top.Style =
                                border1.Left.Style =
                                border1.Right.Style = ExcelBorderStyle.None;

                                Rowx++;
                                Rowx++;

                                ws.Cells[Rowx, 2].Value = " No ";
                                ws.Cells[Rowx, 3].Value = " Kode Sales ";
                                ws.Cells[Rowx, 4].Value = " Nama Sales ";
                                ws.Cells[Rowx, 5].Value = " Nama Toko ";
                                ws.Cells[Rowx, 6].Value = " Daerah ";
                                ws.Cells[Rowx, 7].Value = " WilID ";
                                ws.Cells[Rowx, 8].Value = " No Nota ";
                                ws.Cells[Rowx, 9].Value = " Tgl Nota ";
                                ws.Cells[Rowx, 10].Value = " Klp ";
                                ws.Cells[Rowx, 11].Value = " Omset ";

                                ws.Cells[Rowx, 12].Value = " Lunas<=2mg";
                                ws.Cells[Rowx, 13].Value = " Lunas >2mg";
                                ws.Cells[Rowx, 14].Value = " PJ TUNAI";

                                ws.Cells[Rowx, 15].Value = " Kas ";
                                ws.Cells[Rowx, 16].Value = " TRANSFER ";
                                ws.Cells[Rowx, 17].Value = " GIRO CAIR ";
                                ws.Cells[Rowx, 18].Value = " RET ";
                                ws.Cells[Rowx, 19].Value = " KPJ ";
                                ws.Cells[Rowx, 20].Value = " KRJ ";
                                ws.Cells[Rowx, 21].Value = " POT ";
                                ws.Cells[Rowx, 22].Value = " ADJ ";
                                ws.Cells[Rowx, 23].Value = " PLL ";
                                ws.Cells[Rowx, 24].Value = " MUT ";

                                ws.Cells[Rowx, 25].Value = " TR ";
                                ws.Cells[Rowx, 26].Value = " Umur Piut ";
                                ws.Cells[Rowx, 27].Value = " Overdue ";
                                ws.Cells[Rowx, 28].Value = " Lama Ovd ";

                                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                ws.Cells[Rowx, 11, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                                Rowx++;
                            }
                        }

                        cKodeSales = Tools.isNull(dr1["KodeSales"], "").ToString();
                        cKlp = Tools.isNull(dr1["Klp"], "").ToString();
                        cAwal = "0";
                        no += 1;

                        double cash = 0, ksjs = 0, ldjs = 0;
                        if (Tools.isNull(dr1["Kode"], "").ToString() == "CASH")
                            cash = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
                        else if (Tools.isNull(dr1["Kode"], "").ToString() == "KSJS")
                            ksjs = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());
                        else if (Tools.isNull(dr1["Kode"], "").ToString() == "LDJS")
                            ldjs = Convert.ToDouble(Tools.isNull(dr1["Kredit"], "0").ToString());

                        ws.Cells[Rowx, 2].Value = no.ToString();
                        ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                        ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                        ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                        ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Daerah"], "").ToString();
                        ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["WilID"], "").ToString();
                        ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["NoNota"], "").ToString();
                        ws.Cells[Rowx, 9].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglNota"], ""));
                        ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["Klp"], "").ToString().Substring(1, 2);
                        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());
                        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 12].Value = ksjs;
                        ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 13].Value = ldjs;
                        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 14].Value = cash;

                        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["Kas"], "0").ToString());
                        ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["Trn"], "0").ToString());
                        ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["Grc"], "0").ToString());
                        ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Ret"], "0").ToString());
                        ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["Kpj"], "0").ToString());
                        ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["Krj"], "0").ToString());
                        ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["Pot"], "0").ToString());
                        ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["Adj"], "0").ToString());
                        ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Pll"], "0").ToString());
                        ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 24].Value = Convert.ToDouble(Tools.isNull(dr1["Mut"], "0").ToString());

                        ws.Cells[Rowx, 25].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                        ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 26].Value = Convert.ToDouble(Tools.isNull(dr1["UmurPiutang"], "0").ToString());
                        ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 27].Value = Convert.ToDouble(Tools.isNull(dr1["overdue"], "0").ToString());
                        ws.Cells[Rowx, 28].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 28].Value = Convert.ToDouble(Tools.isNull(dr1["lamaovd"], "0").ToString());

                        Joms += Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());
                        Toms += Convert.ToDouble(Tools.isNull(dr1["Debet"], "0").ToString());

                        Jks += ksjs;
                        Tks += ksjs;
                        Jld += ldjs;
                        Tld += ldjs;
                        Jtu += cash;
                        Ttu += cash;

                        Jkas += Convert.ToDouble(Tools.isNull(dr1["Kas"], "0").ToString());
                        Tkas += Convert.ToDouble(Tools.isNull(dr1["Kas"], "0").ToString());
                        Jtrn += Convert.ToDouble(Tools.isNull(dr1["Trn"], "0").ToString());
                        Ttrn += Convert.ToDouble(Tools.isNull(dr1["Trn"], "0").ToString());
                        Jgrc += Convert.ToDouble(Tools.isNull(dr1["Grc"], "0").ToString());
                        Tgrc += Convert.ToDouble(Tools.isNull(dr1["Grc"], "0").ToString());
                        Jret += Convert.ToDouble(Tools.isNull(dr1["Ret"], "0").ToString());
                        Tret += Convert.ToDouble(Tools.isNull(dr1["Ret"], "0").ToString());
                        Jkpj += Convert.ToDouble(Tools.isNull(dr1["Kpj"], "0").ToString());
                        Tkpj += Convert.ToDouble(Tools.isNull(dr1["Kpj"], "0").ToString());
                        Jkrj += Convert.ToDouble(Tools.isNull(dr1["Krj"], "0").ToString());
                        Tkrj += Convert.ToDouble(Tools.isNull(dr1["Krj"], "0").ToString());
                        Jpot += Convert.ToDouble(Tools.isNull(dr1["Pot"], "0").ToString());
                        Tpot += Convert.ToDouble(Tools.isNull(dr1["Pot"], "0").ToString());
                        Jadj += Convert.ToDouble(Tools.isNull(dr1["Adj"], "0").ToString());
                        Tadj += Convert.ToDouble(Tools.isNull(dr1["Adj"], "0").ToString());
                        Jpll += Convert.ToDouble(Tools.isNull(dr1["Pll"], "0").ToString());
                        Tpll += Convert.ToDouble(Tools.isNull(dr1["Pll"], "0").ToString());
                        Jmut += Convert.ToDouble(Tools.isNull(dr1["Mut"], "0").ToString());
                        Tmut += Convert.ToDouble(Tools.isNull(dr1["Mut"], "0").ToString());
                        Jovd += Convert.ToDouble(Tools.isNull(dr1["overdue"], "0").ToString());
                        Tovd += Convert.ToDouble(Tools.isNull(dr1["overdue"], "0").ToString());
                        Rowx++;
                    }
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 9].Value = "Jumlah";
                    ws.Cells[Rowx, 9].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 11].Value = Tools.isNull(Joms, 0);
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Style.Font.Bold = true;
                    ws.Cells[Rowx, 11].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 12].Value = Tools.isNull(Jks, 0);
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Style.Font.Bold = true;
                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 13].Value = Tools.isNull(Jld, 0);
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 14].Value = Tools.isNull(Jtu, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 15].Value = Tools.isNull(Jkas, 0);
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 16].Value = Tools.isNull(Jtrn, 0);
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Style.Font.Bold = true;
                    ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 17].Value = Tools.isNull(Jgrc, 0);
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Style.Font.Bold = true;
                    ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 18].Value = Tools.isNull(Jret, 0);
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Style.Font.Bold = true;
                    ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 19].Value = Tools.isNull(Jkpj, 0);
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Style.Font.Bold = true;
                    ws.Cells[Rowx, 19].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 20].Value = Tools.isNull(Jkrj, 0);
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Style.Font.Bold = true;
                    ws.Cells[Rowx, 20].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 21].Value = Tools.isNull(Jpot, 0);
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Style.Font.Bold = true;
                    ws.Cells[Rowx, 21].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 22].Value = Tools.isNull(Jadj, 0);
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 22].Style.Font.Bold = true;
                    ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 23].Value = Tools.isNull(Jpll, 0);
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 23].Style.Font.Bold = true;
                    ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 24].Value = Tools.isNull(Jmut, 0);
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Style.Font.Bold = true;
                    ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 27].Value = Tools.isNull(Jovd, 0);
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Style.Font.Bold = true;
                    ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);
                    Rowx++;

                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;

                    ws.Cells[Rowx, 9].Value = "Total";
                    ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 11].Value = Tools.isNull(Toms, 0);
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Style.Font.Bold = true;
                    ws.Cells[Rowx, 11].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 12].Value = Tools.isNull(Tks, 0);
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Style.Font.Bold = true;
                    ws.Cells[Rowx, 12].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 13].Value = Tools.isNull(Tld, 0);
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Style.Font.Bold = true;
                    ws.Cells[Rowx, 13].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 14].Value = Tools.isNull(Ttu, 0);
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Style.Font.Bold = true;
                    ws.Cells[Rowx, 14].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 15].Value = Tools.isNull(Tkas, 0);
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Style.Font.Bold = true;
                    ws.Cells[Rowx, 15].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 16].Value = Tools.isNull(Ttrn, 0);
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Style.Font.Bold = true;
                    ws.Cells[Rowx, 16].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 17].Value = Tools.isNull(Tgrc, 0);
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Style.Font.Bold = true;
                    ws.Cells[Rowx, 17].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 18].Value = Tools.isNull(Tret, 0);
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Style.Font.Bold = true;
                    ws.Cells[Rowx, 18].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 19].Value = Tools.isNull(Tkpj, 0);
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Style.Font.Bold = true;
                    ws.Cells[Rowx, 19].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 20].Value = Tools.isNull(Tkrj, 0);
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Style.Font.Bold = true;
                    ws.Cells[Rowx, 20].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 21].Value = Tools.isNull(Tpot, 0);
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Style.Font.Bold = true;
                    ws.Cells[Rowx, 21].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 22].Value = Tools.isNull(Tadj, 0);
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 22].Style.Font.Bold = true;
                    ws.Cells[Rowx, 22].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 23].Value = Tools.isNull(Tpll, 0);
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 23].Style.Font.Bold = true;
                    ws.Cells[Rowx, 23].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 24].Value = Tools.isNull(Tmut, 0);
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Style.Font.Bold = true;
                    ws.Cells[Rowx, 24].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 27].Value = Tools.isNull(Tovd, 0);
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Style.Font.Bold = true;
                    ws.Cells[Rowx, 27].Style.Font.Color.SetColor(Color.Blue);
                }

                Rowx += 2;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            }


            #region rekap per barang
            //Rekap Per Barang-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            ex.Workbook.Worksheets.Add("Rekap Per Barang");
            ws = ex.Workbook.Worksheets[3];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
            ws.Cells[1, 3].Worksheet.Column(3).Width = 17;      //barangid
            ws.Cells[1, 4].Worksheet.Column(4).Width = 75;      //nama barang
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //stok awal
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //saldo awal
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //qty terima
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //hpp terima
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //qty kirim
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //hpp kirim
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //qty penjualan
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //rp jual
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //hpp jual
            ws.Cells[1, 14].Worksheet.Column(14).Width = 10;    //qty penjualanK
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //rp jualK
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //hpp jualK
            ws.Cells[1, 17].Worksheet.Column(17).Width = 10;    //qty gudang
            ws.Cells[1, 18].Worksheet.Column(18).Width = 15;    //rp retur
            ws.Cells[1, 19].Worksheet.Column(19).Width = 15;    //hpp ret
            ws.Cells[1, 20].Worksheet.Column(20).Width = 10;    //stok akhir
            ws.Cells[1, 21].Worksheet.Column(21).Width = 15;    //saldo akhir

            nRow = 0;
            nHeader = 0;
            Rowx = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Rekap Per Barang";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", startDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", endDate);

                int MaxCol = 21;

                ws.Cells[Rowx, 2, Rowx + 2, 2].Merge = true;
                ws.Cells[Rowx, 2].Value = " No ";
                ws.Cells[Rowx, 3, Rowx + 2, 3].Merge = true;
                ws.Cells[Rowx, 3].Value = " Kode Barang ";
                ws.Cells[Rowx, 4, Rowx + 2, 4].Merge = true;
                ws.Cells[Rowx, 4].Value = " Nama Barang ";
                ws.Cells[Rowx, 5, Rowx + 1, 6].Merge = true;
                ws.Cells[Rowx, 5].Value = " Saldo Awal ";
                ws.Cells[Rowx + 2, 5].Value = " Qty ";
                ws.Cells[Rowx + 2, 6].Value = " Hpp ";

                ws.Cells[Rowx, 7, Rowx, 10].Merge = true;
                ws.Cells[Rowx + 1, 7, Rowx + 1, 8].Merge = true;
                ws.Cells[Rowx + 1, 9, Rowx + 1, 10].Merge = true;
                ws.Cells[Rowx, 7].Value = " REALISASI PEMENUHAN BARANG (Netto) ";
                ws.Cells[Rowx + 1, 7].Value = " Penjualan HO ke Depo ";
                ws.Cells[Rowx + 1, 9].Value = " Retur Beli dari depo ke HO ";
                ws.Cells[Rowx + 2, 7].Value = " Qty ";
                ws.Cells[Rowx + 2, 8].Value = " Hpp ";
                ws.Cells[Rowx + 2, 9].Value = " Qty ";
                ws.Cells[Rowx + 2, 10].Value = " Hpp ";

                ws.Cells[Rowx, 11, Rowx, 16].Merge = true;
                ws.Cells[Rowx + 1, 11, Rowx + 1, 13].Merge = true;
                ws.Cells[Rowx + 1, 14, Rowx + 1, 16].Merge = true;
                ws.Cells[Rowx, 11].Value = " REALISASI PENJUALAN DEPO ";
                ws.Cells[Rowx + 1, 11].Value = " Penjualan Tunai ";
                ws.Cells[Rowx + 1, 14].Value = " Penjualan Kredit ";
                ws.Cells[Rowx + 2, 11].Value = " Qty ";
                ws.Cells[Rowx + 2, 12].Value = " Rp Jual ";
                ws.Cells[Rowx + 2, 13].Value = " Hpp ";
                ws.Cells[Rowx + 2, 14].Value = " Qty ";
                ws.Cells[Rowx + 2, 15].Value = " Rp Jual ";
                ws.Cells[Rowx + 2, 16].Value = " Hpp ";

                ws.Cells[Rowx, 17, Rowx + 1, 19].Merge = true;
                ws.Cells[Rowx, 17].Value = " Retur Jual ";
                ws.Cells[Rowx + 2, 17].Value = " Qty ";
                ws.Cells[Rowx + 2, 18].Value = " Rp Retur ";
                ws.Cells[Rowx + 2, 19].Value = " Hpp ";

                ws.Cells[Rowx, 20, Rowx + 1, 21].Merge = true;
                ws.Cells[Rowx, 20].Value = " Saldo Akhir ";
                ws.Cells[Rowx + 2, 20].Value = " Qty ";
                ws.Cells[Rowx + 2, 21].Value = " Hpp ";

                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                var borderh = ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Border;
                borderh.Bottom.Style =
                borderh.Top.Style =
                borderh.Left.Style =
                borderh.Right.Style = ExcelBorderStyle.Thin;

                Rowx += 3;
                int no = 0, Jrec = 0, nRec = 0;
                int nQawal = 0, nQterima = 0, nQkirim = 0, nQjual = 0, nQjualK = 0, nQgud = 0, nQakhir = 0;

                double nSawal = 0, nSterima = 0, nSkirim = 0, nRpJual = 0, nSjual = 0,
                       nRpJualK = 0, nSjualK = 0, nRpret = 0, nSret = 0, nSakhir = 0;

                Jrec = ds.Tables[2].Rows.Count;

                foreach (DataRow dr1 in ds.Tables[2].Rows)
                {
                    nRec++;
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["KodeBarang"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["StokAwal"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["SaldoAwal"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["QtyTerima"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["HppTerima"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["HppKirim"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["RpNet"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["HppJual"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalanK"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpNetK"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["HppJualK"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";

                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["QtyGudang"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["RpRetur"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["HppRet"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";

                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["StokAkhir"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["SaldoAkhir"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";

                    nQawal += Convert.ToInt32(Tools.isNull(dr1["StokAwal"], "0").ToString());
                    nQterima += Convert.ToInt32(Tools.isNull(dr1["QtyTerima"], "0").ToString());
                    nQkirim += Convert.ToInt32(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    nQjual += Convert.ToInt32(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                    nQjualK += Convert.ToInt32(Tools.isNull(dr1["QtySuratJalanK"], "0").ToString());
                    nQgud += Convert.ToInt32(Tools.isNull(dr1["QtyGudang"], "0").ToString());
                    nQakhir += Convert.ToInt32(Tools.isNull(dr1["StokAkhir"], "0").ToString());

                    nSawal += Convert.ToDouble(Tools.isNull(dr1["SaldoAwal"], "0").ToString());
                    nSterima += Convert.ToDouble(Tools.isNull(dr1["HppTerima"], "0").ToString());
                    nSkirim += Convert.ToDouble(Tools.isNull(dr1["HppKirim"], "0").ToString());

                    Rowx++;
                }

                Rowx += 1;
                nHeader = Rowx;
                ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
                ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;
            }
            #endregion

            return ex;
        }
    }
}
