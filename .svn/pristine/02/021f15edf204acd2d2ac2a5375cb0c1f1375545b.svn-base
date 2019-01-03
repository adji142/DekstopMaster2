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


namespace ISA.Trading.Persediaan
{
    public partial class frmRptStokTidakBergerak : ISA.Controls.BaseForm
    {
        public frmRptStokTidakBergerak()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DateTime D1 = DateTime.Parse(rdbTgl.FromDate.ToString());
            DateTime D2 = DateTime.Parse(rdbTgl.ToDate.ToString());
            string cKlp = Tools.isNull(cbKlp.Text,"").ToString();

            if (rbStok.Checked)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_StokTidakBergerak_AllStok"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, D1));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, D2));
                        if (cKlp != "")
                            db.Commands[0].Parameters.Add(new Parameter("@Klp", SqlDbType.VarChar, cKlp));
                        dt = db.Commands[0].ExecuteDataTable();
             }
                    if (dt.Rows.Count > 0)
                    {
                        DisplayReportStokTidakBergerak(dt, D1, D2, cKlp);
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
            else if (rbAG.Checked)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_StokTidakBergerakAG"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, D1));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, D2));
                        if (cKlp != "")
                            db.Commands[0].Parameters.Add(new Parameter("@Klp", SqlDbType.VarChar, cKlp));
                        dt = db.Commands[0].ExecuteDataTable();

                    }
                    if (dt.Rows.Count > 0)
                    {
                        DisplayReportStokTidakBergerakAG(dt, D1, D2, cKlp);
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


        private void DisplayReportStokTidakBergerak(DataTable dt, DateTime D1, DateTime D2, string cKlp)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapStokTidakBergerakAllStok(dt, D1, D2, cKlp));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_StokTidakBergerak_AllStok";

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

        private ExcelPackage LapStokTidakBergerakAllStok(DataTable dt, DateTime D1, DateTime D2, string cKlp)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Stok Tidak Bergerak Semua Stok";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Stok Tidak Bergerak Semua Stok", "1147");

            ex.Workbook.Worksheets.Add("Stok Tidak Bergerak Semua Stok");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;

            #region Stok Tidak Bergerak Semua Stok

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
            ws.Cells[1, 3].Worksheet.Column(3).Width = 50;      //namabarang
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //kodebarang
            ws.Cells[1, 5].Worksheet.Column(5).Width = 5;       //sat
            ws.Cells[1, 6].Worksheet.Column(6).Width = 10;      //qtystok
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //hpp
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //nominal

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Stok Tidak Bergerak";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", D1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", D2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Kelompok Barang : "+cKlp;
            //ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 4;
            Rowx = nRow;
            int MaxCol = 8;
            nRow = Rowx;

            for (int i = 2; i <= 8; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " NAMA BARANG ";
            ws.Cells[Rowx, 4].Value = " KODE BARANG ";
            ws.Cells[Rowx, 5].Value = " SAT ";
            ws.Cells[Rowx, 6].Value = " QTY STOK ";
            ws.Cells[Rowx, 7].Value = " HPP ";
            ws.Cells[Rowx, 8].Value = " NOMINAL ";

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
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["BarangID"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["SatJual"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Stok"], "").ToString();
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Double.Parse(Tools.isNull(dr1["Hpp"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Double.Parse(Tools.isNull(dr1["Nominal"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";

                    Jumlah += Convert.ToDouble(Tools.isNull(dr1["Nominal"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 8].Value = Tools.isNull(Jumlah, 0);
            ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 8].Style.Font.Bold = true;

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

            border = ws.Cells[Rowx, MaxCol, Rowx, MaxCol].Style.Border;
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


        private void DisplayReportStokTidakBergerakAG(DataTable dt, DateTime D1, DateTime D2, string cKlp)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapStokTidakBergerakAG(dt, D1, D2, cKlp));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_StokTidakBergerak_AG";

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


        private ExcelPackage LapStokTidakBergerakAG(DataTable dt, DateTime D1, DateTime D2, string cKlp)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Stok Tidak Bergerak Berdasarkan AG";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Stok Tidak Bergerak Berdasarkan AG", "1147");

            ex.Workbook.Worksheets.Add("Stok Tidak Bergerak AG");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;


            #region Laporan rekap insentif OA

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //nomor
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //no ag
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tgl terima
            ws.Cells[1, 5].Worksheet.Column(5).Width = 8;       //dr gud
            ws.Cells[1, 6].Worksheet.Column(6).Width = 8;       //ke gud
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //kode barang
            ws.Cells[1, 8].Worksheet.Column(8).Width = 70;      //nama barang
            ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //satuan
            ws.Cells[1, 10].Worksheet.Column(10).Width = 11;    //qty terima
            ws.Cells[1, 11].Worksheet.Column(11).Width = 11;    //qty jual
            ws.Cells[1, 12].Worksheet.Column(12).Width = 11;    //hppa
            ws.Cells[1, 13].Worksheet.Column(13).Width = 13;    //jumlah

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Stok Tidak Bergerak Berdasarkan AG";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", D1) + " s/d " + string.Format("{0:dd-MMM-yyyy}", D2);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Kelompok Barang : "+cKlp;
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 4;
            Rowx = nRow;
            int MaxCol = 13;

            nRow = Rowx;

            for (int i = 2; i <= 13; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No AG ";
            ws.Cells[Rowx, 4].Value = " Tgl Terima ";
            ws.Cells[Rowx, 5].Value = " Dr Gud ";
            ws.Cells[Rowx, 6].Value = " Ke Gud ";
            ws.Cells[Rowx, 7].Value = " Kode Barang ";
            ws.Cells[Rowx, 8].Value = " Nama Barang ";
            ws.Cells[Rowx, 9].Value = " Sat ";
            ws.Cells[Rowx, 10].Value = " Qty Terima ";
            ws.Cells[Rowx, 11].Value = " Qty Jual ";
            ws.Cells[Rowx, 12].Value = " Hppa ";
            ws.Cells[Rowx, 13].Value = " Jumlah ";

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
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoAG"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglTerima"]);
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["DrGudang"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["KeGudang"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["KodeBarang"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Satuan"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["QtyTerima"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";

                    Jumlah += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    Rowx++;
                }
            }
            Rowx++;
            ws.Cells[Rowx, 4].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 4].Style.Font.Bold = true;

            ws.Cells[Rowx, 13].Value = Tools.isNull(Jumlah, 0);
            ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 13].Style.Font.Bold = true;

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

            border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
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

        private void frmRptStokTidakBergerak_Load(object sender, EventArgs e)
        {
            rbStok.Checked = true;
            rbAG.Checked = false;
            //dtTanggal.DateValue = GlobalVar.DateTimeOfServer;
            //dtTanggal.Focus();
        }

    }
}
