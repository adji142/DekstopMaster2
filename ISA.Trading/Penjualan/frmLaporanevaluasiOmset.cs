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
    public partial class frmLaporanevaluasiOmset : ISA.Controls.BaseForm
    {
        public frmLaporanevaluasiOmset()
        {
            InitializeComponent();
        }

        private void frmLaporanevaluasiOmset_Load(object sender, EventArgs e)
        {
            string tgl = GlobalVar.DateTimeOfServer.Day.ToString().PadLeft(2, '0');
            string bln = GlobalVar.DateTimeOfServer.Month.ToString().PadLeft(2, '0');
            string thn = GlobalVar.DateTimeOfServer.Year.ToString().PadLeft(4, '0');
            string periode = thn + bln + tgl;

            DateTime toDate;
            DateTime fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
            DateTime tglAkhir = fromDate.AddMonths(1).AddDays(-1);

            if (GlobalVar.DateTimeOfServer > tglAkhir)
                toDate = tglAkhir;
            else
                toDate = GlobalVar.DateTimeOfServer;

            rangeDateBoxPenjualan.FromDate = fromDate;
            rangeDateBoxPenjualan.ToDate = toDate;

            cmdPrint.Focus();

        }

        private void cmdyes_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("rsp_LaporanEvaluasiOmset"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBoxPenjualan.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBoxPenjualan.ToDate.Value));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables.Count > 0)
                {

                    string cek = "";
                    if (checkBox1.Checked)
                    {
                        cek = "1";
                    }
                    DateTime d1 = rangeDateBoxPenjualan.FromDate.Value;
                    DateTime d2 = rangeDateBoxPenjualan.ToDate.Value;
                    DisplayReport(ds,d1,d2,cek);
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

        private void DisplayReport(DataSet ds,DateTime d1,DateTime d2,string cek)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                if (cek == "1")
                    exs.Add(LapEvaluasiOmset(ds, d1, d2));
                else
                    exs.Add(LapEvaluasiOmsetBE(ds, d1, d2));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_EvaluasiOmset";

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


        private ExcelPackage LapEvaluasiOmset(DataSet ds,DateTime d1,DateTime d2)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Evaluasi Omset";
            ex.Workbook.Properties.SetCustomPropertyValue("Evaluasi Omset", "1147");

            ex.Workbook.Worksheets.Add("Evaluasi Omset");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;      //kodesales
            ws.Cells[1, 3].Worksheet.Column(3).Width = 20;      //namasales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //targetbe
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //targetfa
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //jumlah
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //targetbe harian
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //targetfa harian
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //jumlahtarget harian
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //omsetbe harian
            ws.Cells[1, 11].Worksheet.Column(11).Width =  5;    //persenbe harian
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //+-be harian
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //omsetfa harian
            ws.Cells[1, 14].Worksheet.Column(14).Width =  5;    //persenfa harian
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //+-fa harian
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //omsetAll harian
            ws.Cells[1, 17].Worksheet.Column(17).Width =  5;    //persenAll harian
            ws.Cells[1, 18].Worksheet.Column(18).Width = 15;    //+-All harian
            ws.Cells[1, 19].Worksheet.Column(19).Width = 15;    //omset bulanan
            ws.Cells[1, 20].Worksheet.Column(20).Width =  5;    //persen bulanan
            ws.Cells[1, 21].Worksheet.Column(21).Width = 15;    //+-be harian
            ws.Cells[1, 22].Worksheet.Column(22).Width = 15;    //omsetfa harian
            ws.Cells[1, 23].Worksheet.Column(23).Width =  5;    //persenfa harian
            ws.Cells[1, 24].Worksheet.Column(24).Width = 15;    //+-fa harian
            ws.Cells[1, 25].Worksheet.Column(25).Width = 15;    //omsetAll harian
            ws.Cells[1, 26].Worksheet.Column(26).Width =  5;    //persenAll harian
            ws.Cells[1, 27].Worksheet.Column(27).Width = 15;    //+-All harian
            int nRow = 0, nHeader = 0, Rowx = 0;

            //#region Laporan
            if (ds.Tables[1].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                nRow = nHeader + 3;
                Rowx = nRow;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = "Laporan Evaluasi Omset";
                ws.Cells[nHeader, 2].Style.Font.Size = 14;
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
                //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

                int MaxCol = 27;

                ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
                ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;

                ws.Cells[Rowx, 4, Rowx, 6].Merge = true;
                ws.Cells[Rowx, 7, Rowx, 9].Merge = true;
                ws.Cells[Rowx, 10, Rowx, 18].Merge = true;
                ws.Cells[Rowx, 19, Rowx, 27].Merge = true;

                ws.Cells[Rowx, 4].Value = " Target Per Bulan ";
                ws.Cells[Rowx, 7].Value = " Target Per Hari ";
                ws.Cells[Rowx, 10].Value = " Omset Per Tanggal " + string.Format("{0:dd-MMM-yyyy}", d2);
                ws.Cells[Rowx, 19].Value = " Omset Per Periode " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);

                ws.Cells[Rowx, 2].Value = " Kode Sales ";
                ws.Cells[Rowx, 3].Value = " Nama Sales ";
                ws.Cells[Rowx + 1, 4].Value = " BE ";           //target BE
                ws.Cells[Rowx + 1, 5].Value = " FA ";
                ws.Cells[Rowx + 1, 6].Value = " Jumlah ";
                ws.Cells[Rowx + 1, 7].Value = " BE ";           //target FA
                ws.Cells[Rowx + 1, 8].Value = " FA ";
                ws.Cells[Rowx + 1, 9].Value = " Jumlah ";
                ws.Cells[Rowx + 1, 10].Value = " BE ";          //omset BE harian
                ws.Cells[Rowx + 1, 11].Value = " % ";
                ws.Cells[Rowx + 1, 12].Value = " +/- ";
                ws.Cells[Rowx + 1, 13].Value = " FA ";          //omset FA harian
                ws.Cells[Rowx + 1, 14].Value = " % ";
                ws.Cells[Rowx + 1, 15].Value = " +/- ";
                ws.Cells[Rowx + 1, 16].Value = " All ";         //omset All harian
                ws.Cells[Rowx + 1, 17].Value = " % ";
                ws.Cells[Rowx + 1, 18].Value = " +/- ";
                ws.Cells[Rowx + 1, 19].Value = " BE ";          //omset BE bulanan
                ws.Cells[Rowx + 1, 20].Value = " % ";
                ws.Cells[Rowx + 1, 21].Value = " +/- ";
                ws.Cells[Rowx + 1, 22].Value = " FA ";          //omset FA bulanan
                ws.Cells[Rowx + 1, 23].Value = " % ";
                ws.Cells[Rowx + 1, 24].Value = " +/- ";
                ws.Cells[Rowx + 1, 25].Value = " All ";         //omset All bulanan
                ws.Cells[Rowx + 1, 26].Value = " % ";
                ws.Cells[Rowx + 1, 27].Value = " +/- ";

                ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                ws.Cells[Rowx, 7, Rowx + 1, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 7, Rowx + 1, 9].Style.Fill.BackgroundColor.SetColor(Color.AntiqueWhite);

                ws.Cells[Rowx, 10, Rowx + 1, 18].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[Rowx, 10, Rowx + 1, 18].Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);

                Rowx++;
                Rowx++;

                int no = 0;
                double nTargetBE = 0, nTargetFA = 0, nTargetAll = 0,
                       nTargetBEhr = 0, nTargetFAhr = 0, nTargetAllhr = 0,
                       nOmsetBEhr = 0, npersenBEhr = 0, npmBEhr = 0,
                       nOmsetFAhr = 0, npersenFAhr = 0, npmFAhr = 0,
                       nOmsetAllhr = 0, npersenAllhr = 0, npmAllhr = 0,
                       nOmsetBE = 0, npersenBE = 0, npmBE = 0,
                       nOmsetFA = 0, npersenFA = 0, npmFA = 0,
                       nOmsetAll = 0, npersenAll = 0, npmAll = 0;

                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                    ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetFA"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["TargetALL"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["TargetFAhr"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["TargetAllhr"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["persenBEhr"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetFAhr"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["persenFAhr"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["pmFAhr"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetAllhr"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["persenAllhr"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["pmAllhr"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["persenBE"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetFA"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["persenFA"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Value = Convert.ToDouble(Tools.isNull(dr1["pmFA"], "0").ToString());
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 25].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetAll"], "0").ToString());
                    ws.Cells[Rowx, 25].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 26].Value = Convert.ToDouble(Tools.isNull(dr1["persenAll"], "0").ToString());
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Value = Convert.ToDouble(Tools.isNull(dr1["pmAll"], "0").ToString());
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";

                    nTargetBE += Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                    nTargetFA += Convert.ToDouble(Tools.isNull(dr1["TargetFA"], "0").ToString());
                    nTargetAll += Convert.ToDouble(Tools.isNull(dr1["TargetAll"], "0").ToString());

                    nTargetBEhr += Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());
                    nTargetFAhr += Convert.ToDouble(Tools.isNull(dr1["TargetFAhr"], "0").ToString());
                    nTargetAllhr += Convert.ToDouble(Tools.isNull(dr1["TargetAllhr"], "0").ToString());

                    nOmsetBEhr += Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                    npersenBEhr += Convert.ToDouble(Tools.isNull(dr1["persenBEhr"], "0").ToString());
                    npmBEhr += Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());

                    nOmsetFAhr += Convert.ToDouble(Tools.isNull(dr1["OmsetFAhr"], "0").ToString());
                    npersenFAhr += Convert.ToDouble(Tools.isNull(dr1["persenFAhr"], "0").ToString());
                    npmFAhr += Convert.ToDouble(Tools.isNull(dr1["pmFAhr"], "0").ToString());

                    nOmsetAllhr += Convert.ToDouble(Tools.isNull(dr1["OmsetAllhr"], "0").ToString());
                    npersenAllhr += Convert.ToDouble(Tools.isNull(dr1["persenAllhr"], "0").ToString());
                    npmAllhr += Convert.ToDouble(Tools.isNull(dr1["pmAllhr"], "0").ToString());

                    nOmsetBE += Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                    npersenBE += Convert.ToDouble(Tools.isNull(dr1["persenBE"], "0").ToString());
                    npmBE += Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());

                    nOmsetFA += Convert.ToDouble(Tools.isNull(dr1["OmsetFA"], "0").ToString());
                    npersenFA += Convert.ToDouble(Tools.isNull(dr1["persenFA"], "0").ToString());
                    npmFA += Convert.ToDouble(Tools.isNull(dr1["pmFA"], "0").ToString());

                    nOmsetAll += Convert.ToDouble(Tools.isNull(dr1["OmsetAll"], "0").ToString());
                    npersenAll += Convert.ToDouble(Tools.isNull(dr1["persenAll"], "0").ToString());
                    npmAll += Convert.ToDouble(Tools.isNull(dr1["pmAll"], "0").ToString());

                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 4].Value = Tools.isNull(nTargetBE, 0);
                ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 4].Style.Font.Bold = true;

                ws.Cells[Rowx, 5].Value = Tools.isNull(nTargetFA, 0);
                ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 5].Style.Font.Bold = true;

                ws.Cells[Rowx, 6].Value = Tools.isNull(nTargetAll, 0);
                ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 6].Style.Font.Bold = true;

                ws.Cells[Rowx, 7].Value = Tools.isNull(nTargetBEhr, 0);
                ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 7].Style.Font.Bold = true;

                ws.Cells[Rowx, 8].Value = Tools.isNull(nTargetFAhr, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                ws.Cells[Rowx, 9].Value = Tools.isNull(nTargetAllhr, 0);
                ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 9].Style.Font.Bold = true;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nOmsetBEhr, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 12].Value = Tools.isNull(npmBEhr, 0);
                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 12].Style.Font.Bold = true;

                ws.Cells[Rowx, 13].Value = Tools.isNull(nOmsetFAhr, 0);
                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 13].Style.Font.Bold = true;

                ws.Cells[Rowx, 15].Value = Tools.isNull(npmFAhr, 0);
                ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 15].Style.Font.Bold = true;

                ws.Cells[Rowx, 16].Value = Tools.isNull(nOmsetAllhr, 0);
                ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 16].Style.Font.Bold = true;

                ws.Cells[Rowx, 18].Value = Tools.isNull(npmAllhr, 0);
                ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 18].Style.Font.Bold = true;

                ws.Cells[Rowx, 19].Value = Tools.isNull(nOmsetBE, 0);
                ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 19].Style.Font.Bold = true;

                ws.Cells[Rowx, 21].Value = Tools.isNull(npmBE, 0);
                ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 21].Style.Font.Bold = true;

                ws.Cells[Rowx, 22].Value = Tools.isNull(nOmsetFA, 0);
                ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 22].Style.Font.Bold = true;

                ws.Cells[Rowx, 24].Value = Tools.isNull(npmFA, 0);
                ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 24].Style.Font.Bold = true;

                ws.Cells[Rowx, 25].Value = Tools.isNull(nOmsetAll, 0);
                ws.Cells[Rowx, 25].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 25].Style.Font.Bold = true;

                ws.Cells[Rowx, 27].Value = Tools.isNull(npmAll, 0);
                ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 27].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 2, 2, Rowx - 1, MaxCol].Style.Border;
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

                border = ws.Cells[Rowx, 4, Rowx, MaxCol].Style.Border;
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

        private ExcelPackage LapEvaluasiOmsetBE(DataSet ds, DateTime d1, DateTime d2)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Evaluasi Omset";
            ex.Workbook.Properties.SetCustomPropertyValue("Evaluasi Omset", "1147");

            ex.Workbook.Worksheets.Add("Evaluasi Omset");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;      //kodesales
            ws.Cells[1, 3].Worksheet.Column(3).Width = 20;      //namasales
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //targetbe
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //targetfa
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //jumlah
            ws.Cells[1, 7].Worksheet.Column(7).Width =  5;      //targetbe harian
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //targetfa harian
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;      //jumlahtarget harian
            ws.Cells[1, 10].Worksheet.Column(10).Width = 5;     //omsetbe harian
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //persenbe harian
            
            int nRow = 0, nHeader = 0, Rowx = 0;

            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Evaluasi Omset";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            int MaxCol = 11;

            ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;

            ws.Cells[Rowx, 4, Rowx, 5].Merge = true;
            ws.Cells[Rowx, 6, Rowx, 8].Merge = true;
            ws.Cells[Rowx, 9, Rowx, 11].Merge = true;

            ws.Cells[Rowx, 2].Value = " Kode Sales ";
            ws.Cells[Rowx, 3].Value = " Nama Sales ";
            ws.Cells[Rowx, 4].Value = " Target Omset BE ";
            ws.Cells[Rowx + 1, 4].Value = " Per Bulan ";
            ws.Cells[Rowx + 1, 5].Value = " Per Hari ";

            ws.Cells[Rowx, 6].Value = " Omset Tanggal " + string.Format("{0:dd-MMM-yyyy}", d2);
            ws.Cells[Rowx + 1, 6].Value = " Omset BE ";
            ws.Cells[Rowx + 1, 7].Value = " % ";
            ws.Cells[Rowx + 1, 8].Value = " +/- ";

            ws.Cells[Rowx, 9].Value = " Omset Periode ";
            ws.Cells[Rowx + 1, 9].Value = " Omset BE ";
            ws.Cells[Rowx + 1, 10].Value = " % ";
            ws.Cells[Rowx + 1, 11].Value = " +/- ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            ws.Cells[Rowx, 6, Rowx + 1, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 6, Rowx + 1, 8].Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);

            Rowx++;
            Rowx++;

            int no = 0;
            double nTargetBE = 0, nTargetFA = 0, nTargetAll = 0,
                   nTargetBEhr = 0, nTargetFAhr = 0, nTargetAllhr = 0,
                   nOmsetBEhr = 0, npersenBEhr = 0, npmBEhr = 0,
                   nOmsetFAhr = 0, npersenFAhr = 0, npmFAhr = 0,
                   nOmsetAllhr = 0, npersenAllhr = 0, npmAllhr = 0,
                   nOmsetBE = 0, npersenBE = 0, npmBE = 0,
                   nOmsetFA = 0, npersenFA = 0, npmFA = 0,
                   nOmsetAll = 0, npersenAll = 0, npmAll = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaSales"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                    ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["persenBEhr"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["persenBE"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                    nTargetBE += Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                    nTargetBEhr += Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());

                    nOmsetBEhr += Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                    npmBEhr += Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());

                    nOmsetBE += Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                    npmBE += Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());

                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[Rowx, 4].Value = Tools.isNull(nTargetBE, 0);
            ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 5].Value = Tools.isNull(nTargetBEhr, 0);
            ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 5].Style.Font.Bold = true;

            ws.Cells[Rowx, 6].Value = Tools.isNull(nOmsetBEhr, 0);
            ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 6].Style.Font.Bold = true;

            ws.Cells[Rowx, 8].Value = Tools.isNull(npmBEhr, 0);
            ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 8].Style.Font.Bold = true;

            ws.Cells[Rowx, 9].Value = Tools.isNull(nOmsetBE, 0);
            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

            ws.Cells[Rowx, 11].Value = Tools.isNull(npmBE, 0);
            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 11].Style.Font.Bold = true;

            var border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow + 2, 2, Rowx - 1, MaxCol].Style.Border;
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

            border = ws.Cells[Rowx, 4, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            
            /*detail per sales*/
            int cnt = 0;

            foreach (DataTable dt in ds.Tables)
            {
                if (cnt > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ex.Workbook.Worksheets.Add(cnt.ToString()+". "+dt.Rows[0]["KodeSales"].ToString());
                        ws = ex.Workbook.Worksheets[cnt+1];

                        ws.View.ShowGridLines = false;
                        ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
                        ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
                        ws.Cells[1, 3].Worksheet.Column(3).Width = 25;      //namatoko
                        ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //kota
                        ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //idwil

                        ws.Cells[1, 6].Worksheet.Column(6).Width = 14;      //targetBEhr
                        ws.Cells[1, 7].Worksheet.Column(7).Width = 14;      //omsetBEhr
                        ws.Cells[1, 8].Worksheet.Column(8).Width = 5;       //%BEhr
                        ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //+-BEhr

                        ws.Cells[1, 10].Worksheet.Column(10).Width = 14;    //targetBE
                        ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //rpdo
                        ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //omsetBE
                        ws.Cells[1, 13].Worksheet.Column(13).Width = 5;     //%BE
                        ws.Cells[1, 14].Worksheet.Column(14).Width = 14;    //+-BE

                        ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //RpBO
                        ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //PendingJual
                        ws.Cells[1, 17].Worksheet.Column(17).Width = 15;    //PendingOvd
                        ws.Cells[1, 18].Worksheet.Column(18).Width = 15;    //TglKunjungan


                        nRow = 0; nHeader = 0; Rowx = 0;

                        nHeader++;
                        nRow = nHeader + 4;
                        Rowx = nRow;

                        ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                        ws.Cells[nHeader, 2].Value = "Laporan Evaluasi Omset";
                        ws.Cells[nHeader, 2].Style.Font.Size = 14;
                        ws.Cells[nHeader, 2].Style.Font.Bold = true;
                        ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
                        ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

                        ws.Cells[nHeader + 3, 2].Value = "Sales      : " + dt.Rows[0]["KodeSales"].ToString() + "  /  " + dt.Rows[0]["NamaSales"].ToString();
                        ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
                        ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

                        MaxCol = 18;

                        ws.Cells[Rowx, 2, Rowx + 1, 2].Merge = true;
                        ws.Cells[Rowx, 3, Rowx + 1, 3].Merge = true;
                        ws.Cells[Rowx, 4, Rowx + 1, 4].Merge = true;
                        ws.Cells[Rowx, 5, Rowx + 1, 5].Merge = true;
                        ws.Cells[Rowx, 15, Rowx + 1, 15].Merge = true;
                        ws.Cells[Rowx, 16, Rowx + 1, 16].Merge = true;
                        ws.Cells[Rowx, 17, Rowx + 1, 17].Merge = true;
                        ws.Cells[Rowx, 18, Rowx + 1, 18].Merge = true;

                        ws.Cells[Rowx, 6, Rowx, 9].Merge = true;
                        ws.Cells[Rowx, 10, Rowx, 14].Merge = true;

                        ws.Cells[Rowx, 2].Value = " No ";
                        ws.Cells[Rowx, 3].Value = " Nama Toko ";
                        ws.Cells[Rowx, 4].Value = " Kota ";
                        ws.Cells[Rowx, 5].Value = " Idwil ";

                        ws.Cells[Rowx, 6].Value = " Target/Omset Tgl " + string.Format("{0:dd-MMM-yyyy}", d2);
                        ws.Cells[Rowx + 1, 6].Value = " Target ";
                        ws.Cells[Rowx + 1, 7].Value = " Omset ";
                        ws.Cells[Rowx + 1, 8].Value = " % ";
                        ws.Cells[Rowx + 1, 9].Value = " (+-) ";

                        ws.Cells[Rowx, 10].Value = " Target/Omset Akumulasi BE ";
                        ws.Cells[Rowx + 1, 10].Value = " Target ";
                        ws.Cells[Rowx + 1, 11].Value = " DO ";
                        ws.Cells[Rowx + 1, 12].Value = " Omset ";
                        ws.Cells[Rowx + 1, 13].Value = " % ";
                        ws.Cells[Rowx + 1, 14].Value = " (+-) ";

                        ws.Cells[Rowx, 15].Value = " BackOrder ";
                        ws.Cells[Rowx, 16].Value = " Pending Jual ";
                        ws.Cells[Rowx, 17].Value = " Pending Ovd ";
                        ws.Cells[Rowx, 18].Value = " Tgl Kunj.";

                        ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                        ws.Cells[Rowx, 6, Rowx + 1, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[Rowx, 6, Rowx + 1, 9].Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);

                        Rowx++;
                        Rowx++;
                        no = 0;
                        double nTarBE = 0, nRpdo = 0, nOmsBE = 0, npminBE = 0, nTarBEhr = 0, nOmsBEhr = 0, 
                               npminBEhr = 0, nRpBO = 0, nPendJual = 0, nPendOvd = 0;

                        foreach (DataRow dr1 in dt.Rows)
                        {
                            no++;
                            ws.Cells[Rowx, 2].Value = no.ToString();
                            ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                            ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Kota"], "").ToString();
                            ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Idwil"], "").ToString();

                            ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());
                            ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                            ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["persenBEhr"], "0").ToString());
                            ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());
                            ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##)";

                            ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["RpDO"], "0").ToString());
                            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                            ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["persenBE"], "0").ToString());
                            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());
                            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpBO"], "0").ToString());
                            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["PendingJual"], "0").ToString());
                            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["PendingOverdue"], "0").ToString());
                            ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##)";
                            ws.Cells[Rowx, 18].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglRequest"], ""));

                            nTarBEhr += Convert.ToDouble(Tools.isNull(dr1["TargetBEhr"], "0").ToString());
                            nOmsBEhr += Convert.ToDouble(Tools.isNull(dr1["OmsetBEhr"], "0").ToString());
                            npminBEhr += Convert.ToDouble(Tools.isNull(dr1["pmBEhr"], "0").ToString());
                            nTarBE += Convert.ToDouble(Tools.isNull(dr1["TargetBE"], "0").ToString());
                            nRpdo += Convert.ToDouble(Tools.isNull(dr1["RpDO"], "0").ToString());
                            nOmsBE += Convert.ToDouble(Tools.isNull(dr1["OmsetBE"], "0").ToString());
                            npminBE += Convert.ToDouble(Tools.isNull(dr1["pmBE"], "0").ToString());
                            nRpBO += Convert.ToDouble(Tools.isNull(dr1["RpBO"], "0").ToString());
                            nPendJual += Convert.ToDouble(Tools.isNull(dr1["PendingJual"], "0").ToString());
                            nPendOvd += Convert.ToDouble(Tools.isNull(dr1["PendingOverdue"], "0").ToString());

                            Rowx++;
                        }
                        Rowx++;
                        ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
                        ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[Rowx, 6].Value = Tools.isNull(nTarBEhr, 0);
                        ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 6].Style.Font.Bold = true;

                        ws.Cells[Rowx, 7].Value = Tools.isNull(nOmsBEhr, 0);
                        ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 7].Style.Font.Bold = true;

                        ws.Cells[Rowx, 9].Value = Tools.isNull(npminBEhr, 0);
                        ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 9].Style.Font.Bold = true;

                        ws.Cells[Rowx, 10].Value = Tools.isNull(nTarBE, 0);
                        ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 10].Style.Font.Bold = true;

                        ws.Cells[Rowx, 11].Value = Tools.isNull(nRpdo, 0);
                        ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 11].Style.Font.Bold = true;

                        ws.Cells[Rowx, 12].Value = Tools.isNull(nOmsBE, 0);
                        ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 12].Style.Font.Bold = true;

                        ws.Cells[Rowx, 14].Value = Tools.isNull(npminBE, 0);
                        ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 14].Style.Font.Bold = true;

                        ws.Cells[Rowx, 15].Value = Tools.isNull(nRpBO, 0);
                        ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 15].Style.Font.Bold = true;

                        ws.Cells[Rowx, 16].Value = Tools.isNull(nPendJual, 0);
                        ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 16].Style.Font.Bold = true;

                        ws.Cells[Rowx, 17].Value = Tools.isNull(nPendOvd, 0);
                        ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                        ws.Cells[Rowx, 17].Style.Font.Bold = true;

                        border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
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

                        border = ws.Cells[Rowx, 6, Rowx, MaxCol].Style.Border;
                        border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;
                    }
                }
                cnt += 1;
            }


            return ex;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("rsp_LaporanEvaluasiOmset"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBoxPenjualan.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBoxPenjualan.ToDate.Value));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables.Count > 0)
                {

                    string cek = "";
                    if (checkBox1.Checked)
                    {
                        cek = "1";
                    }
                    DateTime d1 = rangeDateBoxPenjualan.FromDate.Value;
                    DateTime d2 = rangeDateBoxPenjualan.ToDate.Value;
                    DisplayReport(ds, d1, d2, cek);
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
