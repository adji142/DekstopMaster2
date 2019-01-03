using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.Piutang.Report
{
    public partial class frmRptKebiasaanPembayaranPiutang : ISA.Controls.BaseForm
    {
        public frmRptKebiasaanPembayaranPiutang()
        {
            InitializeComponent();
        }

        private void frmRptKebiasaanPembayaranPiutang_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCetak_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.Parse(rdbLaporan.FromDate.ToString());
            DateTime toDate = DateTime.Parse(rdbLaporan.ToDate.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_KebiasaanBayar"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DisplayReportKebiasaanBayar(ds, fromDate, toDate);
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


        private void DisplayReportKebiasaanBayar(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapKebiasaanBayar(ds, fromdate_, todate_));
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LaporanKebiasaanPembayaranPiutang";
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

        private ExcelPackage LapKebiasaanBayar(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Kebiasaan Pembayaran";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Kebiasaan Pembayaran", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            #region Laporan rekap piutang per kategori

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 31;      //namatoko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 60;      //alamat
            ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //kota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 8;       //idwil
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //sckas
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //kas
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //sctrn
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //trn
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //sctrn
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;    //trn
            ws.Cells[1, 13].Worksheet.Column(13).Width = 10;    //scbgc
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //bgc
            ws.Cells[1, 15].Worksheet.Column(15).Width = 10;    //sclain
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //lain
            ws.Cells[1, 17].Worksheet.Column(17).Width = 20;    //ket

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Kebiasaan Pembayaran";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 17;

            ws.Cells[Rowx, 2].Value = "REKAP";
            ws.Cells[Rowx, 2].Style.Font.Bold = true;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            Rowx++;
            nRow = Rowx;

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
            ws.Cells[Rowx, 5, Rowx + 1, 5].Merge = true;
            ws.Cells[Rowx, 6, Rowx + 1, 6].Merge = true;
            ws.Cells[Rowx, 17, Rowx + 1, 17].Merge = true;

            ws.Cells[Rowx, 7, Rowx, 8].Merge = true;
            ws.Cells[Rowx, 9, Rowx, 10].Merge = true;
            ws.Cells[Rowx, 11, Rowx, 12].Merge = true;
            ws.Cells[Rowx, 13, Rowx, 14].Merge = true;
            ws.Cells[Rowx, 15, Rowx, 16].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Alamat ";
            ws.Cells[Rowx, 5].Value = " Kota ";
            ws.Cells[Rowx, 6].Value = " Idwil ";

            ws.Cells[Rowx, 7].Value = " KAS ";
            ws.Cells[Rowx + 1, 7].Value = " Score ";
            ws.Cells[Rowx + 1, 8].Value = " Nominal ";

            ws.Cells[Rowx, 9].Value = " Transfer ";
            ws.Cells[Rowx + 1, 9].Value = " Score ";
            ws.Cells[Rowx + 1, 10].Value = " Nominal ";

            ws.Cells[Rowx, 11].Value = " Debet ";
            ws.Cells[Rowx + 1, 11].Value = " Score ";
            ws.Cells[Rowx + 1, 12].Value = " Nominal ";

            ws.Cells[Rowx, 13].Value = " Giro ";
            ws.Cells[Rowx + 1, 13].Value = " Score ";
            ws.Cells[Rowx + 1, 14].Value = " Nominal ";

            ws.Cells[Rowx, 15].Value = " Lain-lain ";
            ws.Cells[Rowx + 1, 15].Value = " Score ";
            ws.Cells[Rowx + 1, 16].Value = " Nominal ";

            ws.Cells[Rowx, 17].Value = " Jenis Pembayaran ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0,nfkas = 0,nftrn = 0,nfdbt = 0,nfbgc = 0,nfdll = 0;
            double nkas = 0,ntrn = 0,ndbt = 0,nbgc = 0,ndll = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["WilID"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["fKas"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Kas"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["fTrn"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Trn"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["fDbt"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Dbt"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["fBgc"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Bgc"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["fDll"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["Dll"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 17].Value = Tools.isNull(dr1["Ket"], "").ToString();

                    nfkas = nfkas + Convert.ToInt32(Tools.isNull(dr1["fKas"], "0").ToString());
                    nkas = nkas + Convert.ToDouble(Tools.isNull(dr1["Kas"], "0").ToString());
                    nftrn = nftrn + Convert.ToInt32(Tools.isNull(dr1["fTrn"], "0").ToString());
                    ntrn = ntrn + Convert.ToDouble(Tools.isNull(dr1["Trn"], "0").ToString());
                    nfdbt = nfdbt + Convert.ToInt32(Tools.isNull(dr1["fDbt"], "0").ToString());
                    ndbt = ndbt + Convert.ToDouble(Tools.isNull(dr1["Dbt"], "0").ToString());
                    nfbgc = nfbgc + Convert.ToInt32(Tools.isNull(dr1["fBgc"], "0").ToString());
                    nbgc = nbgc + Convert.ToDouble(Tools.isNull(dr1["Bgc"], "0").ToString());
                    nfdll = nfdll + Convert.ToInt32(Tools.isNull(dr1["fDll"], "0").ToString());
                    ndll = ndll + Convert.ToDouble(Tools.isNull(dr1["Dll"], "0").ToString());

                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 5].Style.Font.Bold = true;

            ws.Cells[Rowx, 7].Value = Tools.isNull(nfkas, 0);
            ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 7].Style.Font.Bold = true;
            ws.Cells[Rowx, 8].Value = Tools.isNull(nkas, 0);
            ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 8].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = Tools.isNull(nftrn, 0);
            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 9].Style.Font.Bold = true;
            ws.Cells[Rowx, 10].Value = Tools.isNull(ntrn, 0);
            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 10].Style.Font.Bold = true;

            ws.Cells[Rowx, 11].Value = Tools.isNull(nfdbt, 0);
            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 11].Style.Font.Bold = true;
            ws.Cells[Rowx, 12].Value = Tools.isNull(ndbt, 0);
            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 12].Style.Font.Bold = true;

            ws.Cells[Rowx, 13].Value = Tools.isNull(nfbgc, 0);
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 13].Style.Font.Bold = true;
            ws.Cells[Rowx, 14].Value = Tools.isNull(nbgc, 0);
            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 14].Style.Font.Bold = true;

            ws.Cells[Rowx, 15].Value = Tools.isNull(nfdll, 0);
            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 15].Style.Font.Bold = true;
            ws.Cells[Rowx, 16].Value = Tools.isNull(ndll, 0);
            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 16].Style.Font.Bold = true;

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

            border = ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Border;
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


            #region Laporan kebiasaan pembayaran piutang detail

            ex.Workbook.Worksheets.Add("Detail");
            ws = ex.Workbook.Worksheets[2];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            nRow = 0; nHeader = 1; Rowx = 0;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Kebiasaan Pembayaran Piutang Detail";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            nHeader += 3;
            ws.Cells[nHeader, 2].Value = "Detail";
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader, 2].Style.Font.Italic = true;

            nHeader++;
            nRow = nHeader;
            Rowx = nRow;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 35;      //nama toko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 60;      //alamat
            ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //kota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 8;       //idwil
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //minggu1
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //minggu2
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //minggu3
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //minggu4
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;    //minggu5

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
            ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
            ws.Cells[Rowx, 5, Rowx + 1, 5].Merge = true;
            ws.Cells[Rowx, 6, Rowx + 1, 6].Merge = true;
            ws.Cells[Rowx, 7, Rowx + 1, 7].Merge = true;
            ws.Cells[Rowx, 7, Rowx + 1, 7].Style.WrapText = true;
            ws.Cells[Rowx, 8, Rowx + 1, 8].Merge = true;
            ws.Cells[Rowx, 8, Rowx + 1, 8].Style.WrapText = true;
            ws.Cells[Rowx, 9, Rowx + 1, 9].Merge = true;
            ws.Cells[Rowx, 9, Rowx + 1, 9].Style.WrapText = true;
            ws.Cells[Rowx, 10, Rowx + 1, 10].Merge = true;
            ws.Cells[Rowx, 10, Rowx + 1, 10].Style.WrapText = true;
            ws.Cells[Rowx, 11, Rowx + 1, 11].Merge = true;
            ws.Cells[Rowx, 11, Rowx + 1, 11].Style.WrapText = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Alamat ";
            ws.Cells[Rowx, 5].Value = " Kota ";
            ws.Cells[Rowx, 6].Value = " Idwil ";
            ws.Cells[Rowx, 7].Value = " Minggu I          1-7 ";
            ws.Cells[Rowx, 8].Value = " Minggu II       8-14 ";
            ws.Cells[Rowx, 9].Value = " Minggu III    15-21 ";
            ws.Cells[Rowx, 10].Value = " Minggu IV    22-28 ";
            ws.Cells[Rowx, 11].Value = " Minggu V    29-31 ";

            MaxCol = 11;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx += 2;

            no = 0;
            double nMinggu1 = 0, nMinggu2 = 0, nMinggu3 = 0, nMinggu4 = 0, nMinggu5 = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["WilID"], "").ToString();

                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Minggu1"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Minggu2"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Minggu3"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Minggu4"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Minggu5"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                    nMinggu1 += Convert.ToDouble(Tools.isNull(dr1["Minggu1"], "0").ToString());
                    nMinggu2 += Convert.ToDouble(Tools.isNull(dr1["Minggu2"], "0").ToString());
                    nMinggu3 += Convert.ToDouble(Tools.isNull(dr1["Minggu3"], "0").ToString());
                    nMinggu4 += Convert.ToDouble(Tools.isNull(dr1["Minggu4"], "0").ToString());
                    nMinggu5 += Convert.ToDouble(Tools.isNull(dr1["Minggu5"], "0").ToString());
                    Rowx++;
                }
                Rowx++;
                ws.Cells[Rowx, 5].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 5].Style.Font.Bold = true;

                ws.Cells[Rowx, 7].Value = Tools.isNull(nMinggu1, 0);
                ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 7].Style.Font.Bold = true;

                ws.Cells[Rowx, 8].Value = Tools.isNull(nMinggu2, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                ws.Cells[Rowx, 9].Value = Tools.isNull(nMinggu3, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nMinggu4, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 11].Value = Tools.isNull(nMinggu5, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

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

                border = ws.Cells[Rowx, 5, Rowx, MaxCol].Style.Border;
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
            }
            #endregion

            return ex;
        }


    }
}
