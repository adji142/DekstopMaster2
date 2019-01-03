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
    public partial class frmRptServiceBengkelDetail : ISA.Bengkel.BaseForm
    {
        DataTable dtBkl;

        public frmRptServiceBengkelDetail()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptServiceBengkelDetail_Load(object sender, EventArgs e)
        {
            int thn = GlobalVar.DateTimeOfServer.Year;
            int bln = GlobalVar.DateTimeOfServer.Month;
            DateTime D1 = new DateTime(thn, bln, 1);

            rgbTglService.FromDate = D1;
            rgbTglService.ToDate = GlobalVar.DateTimeOfServer;
            rgbTglService.Focus();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_bklDetail_report]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rgbTglService.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rgbTglService.ToDate.Value));
                    dtBkl = db.Commands[0].ExecuteDataTable();

                    if (dtBkl.Rows.Count > 0)
                    {
                        DateTime fromDate = Convert.ToDateTime(rgbTglService.FromDate.ToString());
                        DateTime toDate = Convert.ToDateTime(rgbTglService.ToDate.ToString());
                        DisplayReport(dtBkl, rgbTglService.FromDate.Value, rgbTglService.ToDate.Value);
                    }
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
                exs.Add(LaporanBengkelOto(dt, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LaporanBengkelDetail_" + GlobalVar.Gudang + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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


        private ExcelPackage LaporanBengkelOto(DataTable dt, DateTime fromdate, DateTime todate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "Otomotif";
            ex.Workbook.Properties.Title = "Laporan Bengkel Detail";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Bengkel Detail", "1147");

            ex.Workbook.Worksheets.Add("Detailp");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
            ws.Cells[1, 3].Worksheet.Column(3).Width = 25;      //distnk
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;      //pemakai
            ws.Cells[1, 5].Worksheet.Column(5).Width = 40;      //alamat
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;      //kota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //notelp
            ws.Cells[1, 8].Worksheet.Column(8).Width = 25;      //nomesin
            ws.Cells[1, 9].Worksheet.Column(9).Width = 25;      //typemotor
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //nopol
            ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //agama
            ws.Cells[1, 12].Worksheet.Column(12).Width = 13;    //tglservice
            ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //tglkembali
            ws.Cells[1, 14].Worksheet.Column(14).Width = 7;     //km
            ws.Cells[1, 15].Worksheet.Column(15).Width = 8;     //kpb1
            ws.Cells[1, 16].Worksheet.Column(16).Width = 8;     //kpb2
            ws.Cells[1, 17].Worksheet.Column(17).Width = 8;     //kpb3
            ws.Cells[1, 18].Worksheet.Column(18).Width = 8;     //kpb4
            ws.Cells[1, 19].Worksheet.Column(19).Width = 4;     //pl
            ws.Cells[1, 20].Worksheet.Column(20).Width = 25;    //asaldealer
            ws.Cells[1, 21].Worksheet.Column(21).Width = 10;    //norangka
            ws.Cells[1, 22].Worksheet.Column(22).Width = 10;    //tahun
            ws.Cells[1, 22].Worksheet.Column(23).Width = 10;    //kecamatan

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Bengkel Detail";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "NAMA AHASS    : PT. SINAR AGUNG";
            ws.Cells[nHeader + 4, 2].Value = "NO AHASS         : 5247";
            ws.Cells[nHeader + 5, 2].Value = "KOTA                  : TULUNGAGUNG";

            //ws.Cells[nHeader + 3, 14].Value = "Kepada Yth";
            //ws.Cells[nHeader + 4, 14].Value = "Periode Laporan";
            //ws.Cells[nHeader + 5, 14].Value = "Ditujukan";

            //ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 6;
            Rowx = nRow;
            int MaxCol = 23;

            for (int i = 2; i <= 20; i++)
            {
                if (i == 2 || i > 4)
                {
                    ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
                }
            }
            ws.Cells[Rowx, 3, Rowx, 4].Merge = true;
            //ws.Cells[Rowx, 15, Rowx + 1, 15].Worksheet.Cells.Text.Merge = true;
            ws.Cells[Rowx, 15, Rowx + 1, 15].Style.WrapText = true;
            ws.Cells[Rowx, 16, Rowx + 1, 16].Style.WrapText = true;
            ws.Cells[Rowx, 17, Rowx + 1, 17].Style.WrapText = true;
            ws.Cells[Rowx, 18, Rowx + 1, 18].Style.WrapText = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Konsumen ";
            ws.Cells[Rowx + 1, 3].Value = " Di STNK ";
            ws.Cells[Rowx + 1, 4].Value = " Pemakai X ";
            ws.Cells[Rowx, 5].Value = " Alamat ";
            ws.Cells[Rowx, 6].Value = " Kota ";
            ws.Cells[Rowx, 7].Value = " No HP ";
            ws.Cells[Rowx, 8].Value = " No Mesin ";
            ws.Cells[Rowx, 9].Value = " Type Motor ";
            ws.Cells[Rowx, 10].Value = " No Pol ";
            ws.Cells[Rowx, 11].Value = " Agama ";
            ws.Cells[Rowx, 12].Value = " Tgl Service ";
            ws.Cells[Rowx, 13].Value = " Tgl Kembali ";
            ws.Cells[Rowx, 14].Value = " Km ";
            ws.Cells[Rowx, 15].Value = " KPB 1 ";
            ws.Cells[Rowx, 16].Value = " KPB 2 ";
            ws.Cells[Rowx, 17].Value = " KPB 3 ";
            ws.Cells[Rowx, 18].Value = " KPB 4 ";
            ws.Cells[Rowx, 19].Value = " PL ";
            ws.Cells[Rowx, 20].Value = " AsalDealer ";
            ws.Cells[Rowx, 21].Value = " No Rangka ";
            ws.Cells[Rowx, 22].Value = " Tahun ";
            ws.Cells[Rowx, 23].Value = " Kecamatan ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double Jumlah = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["nama_cust"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Pemakai"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["no_telp"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["no_mesin"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["spm"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["no_pol"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["Agama"], "").ToString();
                    if (Tools.isNull(dr1["tgl_srv"], "").ToString() != "")
                        ws.Cells[Rowx, 12].Value = string.Format("{0:dd-MMM-yyyy}", dr1["tgl_srv"]);
                    else
                        ws.Cells[Rowx, 12].Value = "";
                    if (Tools.isNull(dr1["TglKembali"], "").ToString() != "")
                        ws.Cells[Rowx, 13].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglKembali"]);
                    else
                        ws.Cells[Rowx, 13].Value = "";
                    ws.Cells[Rowx, 14].Value = int.Parse(Tools.isNull(dr1["Km"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Tools.isNull(dr1["Kpb1"], "").ToString();
                    ws.Cells[Rowx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 16].Value = Tools.isNull(dr1["Kpb2"], "").ToString();
                    ws.Cells[Rowx, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 17].Value = Tools.isNull(dr1["Kpb3"], "").ToString();
                    ws.Cells[Rowx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 18].Value = Tools.isNull(dr1["Kpb4"], "").ToString();
                    ws.Cells[Rowx, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 19].Value = Tools.isNull(dr1["PL"], "").ToString();
                    ws.Cells[Rowx, 20].Value = Tools.isNull(dr1["AsalDealer"], "").ToString();
                    ws.Cells[Rowx, 21].Value = Tools.isNull(dr1["norangka"], "").ToString();
                    ws.Cells[Rowx, 22].Value = Tools.isNull(dr1["tahun"], "").ToString();
                    ws.Cells[Rowx, 23].Value = Tools.isNull(dr1["Kecamatan"], "").ToString();
                    Rowx++;
                }
            }
            Rowx++;

            //ws.Cells[Rowx, 10].Value = Tools.isNull(Jumlah, 0);
            //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 10].Style.Font.Bold = true;

            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

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

            // swap
            border = ws.Cells[Rowx - 1, 10, Rowx, 10].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
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

    }
}
