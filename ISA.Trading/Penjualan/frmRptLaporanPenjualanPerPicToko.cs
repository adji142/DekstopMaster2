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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using ISA.Common;


namespace ISA.Trading.Penjualan
{
    public partial class frmRptLaporanPenjualanPerPicToko : ISA.Controls.BaseForm
    {
        DataTable dtRekap;
        string Klp = "";

        public frmRptLaporanPenjualanPerPicToko()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            try
            {
                if (rbAll.Checked)
                    Klp = "";
                else if (rbFX.Checked)
                    Klp = "FX";
                else if (rbBE.Checked)
                    Klp = "BE";

                this.Cursor = Cursors.WaitCursor;
                dtRekap = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenjualanRekapPerToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdb.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdb.ToDate));
                    if (lookupSales1.NamaSales != "")
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    if (Klp != "")
                        db.Commands[0].Parameters.Add(new Parameter("Klp", SqlDbType.VarChar, Klp));
                    dtRekap = db.Commands[0].ExecuteDataTable();
                }
                if (dtRekap.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.");
                    return;
                }
                DateTime d1 = DateTime.Parse(rdb.FromDate.ToString());
                DateTime d2 = DateTime.Parse(rdb.ToDate.ToString());

                DisplayReportPenjualanRekapPerToko(dtRekap, d1, d2, Klp);


                //string sSum = dt.Compute("SUM(Omzet)", "Omzet IS NOT NULL").ToString();
                //if (sSum == "")
                //{
                //    MessageBox.Show("Data tidak ada.....");
                //}


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


        private void DisplayReportPenjualanRekapPerToko(DataTable dt, DateTime d1, DateTime d2, string Klp)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapRekapPenjualanRekapPerToko(dt, d1, d2));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_LaporanPenjualanRekapPerToko";

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

        private ExcelPackage LapRekapPenjualanRekapPerToko(DataTable dt, DateTime d1, DateTime d2)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Penjualan Rekap Per Toko";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Penjualan", "1147");

            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 31;      //namatoko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 50;      //alamat
            ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //kota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 9;       //idwil
            ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //kodesales
            ws.Cells[1, 8].Worksheet.Column(8).Width = 13;      //targetomset
            ws.Cells[1, 9].Worksheet.Column(9).Width = 14;      //omsettertinggi
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //akumulasiomset
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //piutang28xx
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    //saldopiutang
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;    //piutanglancar
            ws.Cells[1, 14].Worksheet.Column(14).Width = 15;    //overdue
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //DO
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;    //BO

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Penjualan Rekap Per Toko";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", d1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", d2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Klp Barang : " + GlobalVar.Gudang;
            //ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 4;
            Rowx = nRow;
            int MaxCol = 16;

            for (int i = 2; i <= 16; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }
            ws.Cells[Rowx, 9].Style.WrapText = true;
            ws.Cells[Rowx, 10].Style.WrapText = true;
            ws.Cells[Rowx, 11].Style.WrapText = true;
            ws.Cells[Rowx, 12].Style.WrapText = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Alamat ";
            ws.Cells[Rowx, 5].Value = " Kota ";
            ws.Cells[Rowx, 6].Value = " Idwil ";
            ws.Cells[Rowx, 7].Value = " PIC Toko ";
            ws.Cells[Rowx, 8].Value = " Target Omset ";
            ws.Cells[Rowx, 9].Value = " Omset Tertinggi 6 bulan ";
            ws.Cells[Rowx, 10].Value = " Omset s/d          " + string.Format("{0:dd-MM-yyyy}", d2) + " ";
            ws.Cells[Rowx, 11].Value = " Plafon ";
            ws.Cells[Rowx, 12].Value = " Saldo Piutang " + GlobalVar.Gudang + " ";
            ws.Cells[Rowx, 13].Value = " Piutang Lancar ";
            ws.Cells[Rowx, 14].Value = " Overdue ";
            ws.Cells[Rowx, 15].Value = " DO ";
            ws.Cells[Rowx, 16].Value = " Back Order ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double JmlTg = 0, JmlOT = 0, JmlAO = 0, JmlSP = 0, JmlPL = 0, JmlOv = 0, JmlDO = 0, JmlBO = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["WilID"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 8].Value = double.Parse(Tools.isNull(dr1["TargetToko"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = double.Parse(Tools.isNull(dr1["MaxOmset"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = double.Parse(Tools.isNull(dr1["CurOmset"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = double.Parse(Tools.isNull(dr1["PlafonFX"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = double.Parse(Tools.isNull(dr1["Piutang"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = double.Parse(Tools.isNull(dr1["PiutangLancar"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = double.Parse(Tools.isNull(dr1["Overdue"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = double.Parse(Tools.isNull(dr1["RpDO"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = double.Parse(Tools.isNull(dr1["RpBO"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";

                    JmlTg += double.Parse(Tools.isNull(dr1["TargetToko"], "0").ToString());
                    JmlOT += double.Parse(Tools.isNull(dr1["MaxOmset"], "0").ToString());
                    JmlAO += double.Parse(Tools.isNull(dr1["CurOmset"], "0").ToString());
                    JmlSP += double.Parse(Tools.isNull(dr1["Piutang"], "0").ToString());
                    JmlPL += double.Parse(Tools.isNull(dr1["PiutangLancar"], "0").ToString());
                    JmlOv += double.Parse(Tools.isNull(dr1["Overdue"], "0").ToString());
                    JmlDO += double.Parse(Tools.isNull(dr1["RpDO"], "0").ToString());
                    JmlBO += double.Parse(Tools.isNull(dr1["RpBO"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;

            ws.Cells[Rowx, 5].Value = "TOTAL";
            ws.Cells[Rowx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 5].Style.Font.Bold = true;

            ws.Cells[Rowx, 8].Value = Tools.isNull(JmlTg, 0);
            ws.Cells[Rowx, 9].Value = Tools.isNull(JmlOT, 0);
            ws.Cells[Rowx, 10].Value = Tools.isNull(JmlAO, 0);
            ws.Cells[Rowx, 12].Value = Tools.isNull(JmlSP, 0);
            ws.Cells[Rowx, 13].Value = Tools.isNull(JmlPL, 0);
            ws.Cells[Rowx, 14].Value = Tools.isNull(JmlOv, 0);
            ws.Cells[Rowx, 15].Value = Tools.isNull(JmlDO, 0);
            ws.Cells[Rowx, 16].Value = Tools.isNull(JmlBO, 0);

            ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 8, Rowx, MaxCol].Style.Font.Bold = true;

            ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx++;
            var border = ws.Cells[nRow + 2, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, 2, Rowx - 1, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx - 1, 3, Rowx - 1, MaxCol-1].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = 
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx - 1, MaxCol, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style = ExcelBorderStyle.None;
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            Rowx += 3;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            return ex;

        }



        private bool ValidateInput()
        {
            bool valid = true;

            if (rdb.FromDate.ToString() == "" || rdb.ToDate.ToString() == "")
            {
                MessageBox.Show("Range Tanggal masih kosong");
                valid = false;
            }
            //if (lookupSales1.SalesID == "")
            //{
            //    MessageBox.Show("Kode Sales harus diisi.");
            //    valid = false;
            //}
            return valid;
        }

        private void frmRptLaporanPenjualanPerPicToko_Load(object sender, EventArgs e)
        {
            //
        }


    }
}
