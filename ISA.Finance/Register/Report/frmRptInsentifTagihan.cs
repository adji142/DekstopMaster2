using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.Register.Report
{
    public partial class frmRptInsentifTagihan : ISA.Controls.BaseForm
    {
        public frmRptInsentifTagihan()
        {
            InitializeComponent();
        }

        private void frmRptInsentifTagihan_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                string periode = monthYearBox1.Year.ToString() + monthYearBox1.Month.ToString().PadLeft(2, '0');
                DateTime fromDate = new DateTime(int.Parse(monthYearBox1.Year.ToString()), int.Parse(monthYearBox1.Month.ToString().PadLeft(2, '0')), 1);
                DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Insentif_Tagihan_Collector_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayReportTagihanFeb2017(ds, fromDate, toDate);
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
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void DisplayReportTagihanFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapInsentifTagihanFeb2017(ds, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_InsentifTagihan_Collector";

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


        private ExcelPackage LapInsentifTagihanFeb2017(DataSet ds, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Insentif Tagihan Collector";
            ex.Workbook.Properties.SetCustomPropertyValue("Insentif Tagihan Collector", "1147");

            ex.Workbook.Worksheets.Add("Insentif Tagihan Collector");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            #region Laporan rekap insentif Tagihan Collector

            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0, MaxCol = 18;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 30;      //penagih
            ws.Cells[1, 4].Worksheet.Column(4).Width = 12;      //nominalBE
            ws.Cells[1, 5].Worksheet.Column(5).Width = 12;      //<=30hari
            ws.Cells[1, 6].Worksheet.Column(6).Width = 12;      //30-60hari
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;      //60-90hari
            ws.Cells[1, 8].Worksheet.Column(8).Width = 12;      //1%
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;      //0,5%
            ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //0,25
            ws.Cells[1, 11].Worksheet.Column(11).Width = 12;    //Insbe
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;    //nominalFX
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;    //0-14hari
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //0,5%
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //>=30s/d<40
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //>=40s/d<50
            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //>=50
            ws.Cells[1, 18].Worksheet.Column(18).Width = 12;    //totalInsentif

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Tagihan Collector";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Kelompok Barang BE dan FX";
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 3, 2].Style.Font.Italic = true;

            nHeader += 4;
            Rowx = nHeader;

            ws.Cells[Rowx, 2, Rowx + 2, 2].Merge = true;
            ws.Cells[Rowx, 3, Rowx + 2, 3].Merge = true;

            ws.Cells[Rowx, 4, Rowx, 11].Merge = true;
            ws.Cells[Rowx + 1, 4, Rowx + 2, 4].Merge = true;
            ws.Cells[Rowx + 1, 5, Rowx + 1, 7].Merge = true;
            ws.Cells[Rowx + 1, 8, Rowx + 1, 10].Merge = true;
            ws.Cells[Rowx + 1, 11, Rowx + 2, 11].Merge = true;
            ws.Cells[Rowx + 1, 4, Rowx + 2, 4].Style.WrapText = true;

            ws.Cells[Rowx, 12, Rowx, 14].Merge = true;
            ws.Cells[Rowx + 1, 12, Rowx + 2, 12].Merge = true;
            ws.Cells[Rowx + 1, 13, Rowx + 2, 13].Merge = true;
            ws.Cells[Rowx + 1, 14, Rowx + 2, 14].Merge = true;
            ws.Cells[Rowx + 1, 12, Rowx + 2, 12].Style.WrapText = true;
            ws.Cells[Rowx + 1, 13, Rowx + 2, 13].Style.WrapText = true;
            ws.Cells[Rowx + 1, 14, Rowx + 2, 14].Style.WrapText = true;

            ws.Cells[Rowx, 15, Rowx, 17].Merge = true;
            ws.Cells[Rowx + 1, 15, Rowx + 2, 15].Merge = true;
            ws.Cells[Rowx + 1, 16, Rowx + 2, 16].Merge = true;
            ws.Cells[Rowx + 1, 17, Rowx + 2, 17].Merge = true;
            ws.Cells[Rowx + 1, 15, Rowx + 2, 15].Style.WrapText = true;
            ws.Cells[Rowx + 1, 16, Rowx + 2, 16].Style.WrapText = true;
            ws.Cells[Rowx + 1, 17, Rowx + 2, 17].Style.WrapText = true;

            ws.Cells[Rowx, 18, Rowx + 2, 18].Merge = true;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Penagih ";
            ws.Cells[Rowx, 4].Value = " Pembayaran Transaksi FB ";
            ws.Cells[Rowx + 1, 4].Value = " Nominal Tagihan BE ";
            ws.Cells[Rowx + 1, 5].Value = " Tempo Bayar ";
            ws.Cells[Rowx + 2, 5].Value = " <= 30 Hari ";
            ws.Cells[Rowx + 2, 6].Value = " 30 - 60 Hari ";
            ws.Cells[Rowx + 2, 7].Value = " > 60 Hari ";

            ws.Cells[Rowx + 1, 8].Value = " % Insentif ";
            ws.Cells[Rowx + 2, 8].Value = " 1% ";
            ws.Cells[Rowx + 2, 9].Value = " 0,5% ";
            ws.Cells[Rowx + 2, 10].Value = " 0,25% ";
            ws.Cells[Rowx + 1, 11].Value = " Insentif BE";

            ws.Cells[Rowx, 12].Value = " Transaksi FX ";
            ws.Cells[Rowx + 1, 12].Value = " Nominal Tagihan FX ";
            ws.Cells[Rowx + 1, 13].Value = " Tempo Bayar 0-14 Hari ";
            ws.Cells[Rowx + 1, 14].Value = " Insentif FX 0,5";

            ws.Cells[Rowx, 15].Value = " Insentif Tambahan Tagihan BE ";
            ws.Cells[Rowx + 1, 15].Value = " >= 30JT s/d < 40JT ";
            ws.Cells[Rowx + 1, 16].Value = " >= 40JT s/d < 50JT ";
            ws.Cells[Rowx + 1, 17].Value = " >= 50JT ";

            ws.Cells[Rowx, 18].Value = " Total Insentif ";

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 2, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            
            Rowx += 3;
            nRow = Rowx;

            int no = 0;
            double Jbe = 0, Jfx = 0, Jt1 = 0, Jt2 = 0, Jt3 = 0, Jml = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe"], "0").ToString());
                    ws.Cells[Rowx, 4].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 5].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe1"], "0").ToString());
                    ws.Cells[Rowx, 5].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 6].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe2"], "0").ToString());
                    ws.Cells[Rowx, 6].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe3"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 8].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe1"], "0").ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe2"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe3"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["RpFX1"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["Tambahan1"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["Tambahan2"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["Tambahan3"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);";

                    Jbe += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Jfx += Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    Jt1 += Convert.ToDouble(Tools.isNull(dr1["Tambahan1"], "0").ToString());
                    Jt2 += Convert.ToDouble(Tools.isNull(dr1["Tambahan2"], "0").ToString());
                    Jt3 += Convert.ToDouble(Tools.isNull(dr1["Tambahan3"], "0").ToString());
                    Jml += Convert.ToDouble(Tools.isNull(dr1["Jumlah"], "0").ToString());
                    Rowx++;
                }
            }

            Rowx++;
            ws.Cells[Rowx, 3].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 3].Style.Font.Bold = true;

            ws.Cells[Rowx, 11].Value = Tools.isNull(Jbe, 0);
            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 11].Style.Font.Bold = true;

            ws.Cells[Rowx, 14].Value = Tools.isNull(Jfx, 0);
            ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 14].Style.Font.Bold = true;

            ws.Cells[Rowx, 15].Value = Tools.isNull(Jt1, 0);
            ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 15].Style.Font.Bold = true;

            ws.Cells[Rowx, 16].Value = Tools.isNull(Jt2, 0);
            ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 16].Style.Font.Bold = true;

            ws.Cells[Rowx, 17].Value = Tools.isNull(Jt3, 0);
            ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 17].Style.Font.Bold = true;

            ws.Cells[Rowx, 18].Value = Tools.isNull(Jml, 0);
            ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[Rowx, 18].Style.Font.Bold = true;

            var border = ws.Cells[nHeader, 2, nHeader + 2, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, Rowx - 1, MaxCol].Style.Border;
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

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;
            #endregion


            #region Laporan detail insentif tagihan
            ex.Workbook.Worksheets.Add("Detail Insentif Tagihan");
            ws = ex.Workbook.Worksheets[2];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 9;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 8;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 25;      //penagih
            ws.Cells[1, 4].Worksheet.Column(4).Width = 11;      //noreg
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //tglreg
            ws.Cells[1, 6].Worksheet.Column(6).Width = 11;      //nonota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //tglterima
            ws.Cells[1, 8].Worksheet.Column(8).Width = 5;       //TR
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //hariptg
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;    //tgljttempo
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //tglinden
            ws.Cells[1, 12].Worksheet.Column(12).Width = 12;    //rptagih
            ws.Cells[1, 13].Worksheet.Column(13).Width = 12;    //nominalbe
            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    //rpkas
            ws.Cells[1, 15].Worksheet.Column(15).Width = 12;    //rpgiro
            ws.Cells[1, 16].Worksheet.Column(16).Width = 12;    //rptrn
            ws.Cells[1, 17].Worksheet.Column(17).Width = 12;    //<=30
            ws.Cells[1, 18].Worksheet.Column(18).Width = 12;    //30-60
            ws.Cells[1, 19].Worksheet.Column(19).Width = 12;    //>60
            ws.Cells[1, 20].Worksheet.Column(20).Width = 8;     //1%
            ws.Cells[1, 21].Worksheet.Column(21).Width = 8;     //0,5%
            ws.Cells[1, 22].Worksheet.Column(22).Width = 8;     //0,25%
            ws.Cells[1, 23].Worksheet.Column(23).Width = 16;    //ins<=30
            ws.Cells[1, 24].Worksheet.Column(24).Width = 16;    //ins 30-60
            ws.Cells[1, 25].Worksheet.Column(25).Width = 16;    //ins>60
            ws.Cells[1, 26].Worksheet.Column(26).Width = 16;    //insentifbe
            ws.Cells[1, 27].Worksheet.Column(27).Width = 16;    //nominalfx
            ws.Cells[1, 28].Worksheet.Column(28).Width = 16;    //<=14
            ws.Cells[1, 29].Worksheet.Column(29).Width = 8;     //0,5%
            ws.Cells[1, 30].Worksheet.Column(30).Width = 16;    //ins <14hari
            ws.Cells[1, 31].Worksheet.Column(31).Width = 16;    //ins <14hari

            nRow = 0; nHeader = 1; Rowx = 0;
            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Insentif Tagihan";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang BE dan FX";
            ws.Cells[nHeader + 2, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nHeader++;
            nHeader++;
            nRow = nHeader + 2;
            Rowx = nRow;
            MaxCol = 31;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Penagih ";
            ws.Cells[Rowx, 4].Value = " No Reg ";
            ws.Cells[Rowx, 5].Value = " Tgl Reg ";
            ws.Cells[Rowx, 6].Value = " No Nota ";
            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            ws.Cells[Rowx, 8].Value = " TR ";
            ws.Cells[Rowx, 9].Value = " HariPtg ";
            ws.Cells[Rowx, 10].Value = " Tgl JtTempo ";
            ws.Cells[Rowx, 11].Value = " Tgl Inden ";
            ws.Cells[Rowx, 12].Value = " Rp Tagih ";
            ws.Cells[Rowx, 13].Value = " Nominal BE ";
            ws.Cells[Rowx, 14].Value = " Rp Kas ";
            ws.Cells[Rowx, 15].Value = " Rp Giro ";
            ws.Cells[Rowx, 16].Value = " rp Trn ";
            ws.Cells[Rowx, 17].Value = " <= 30 Hari ";
            ws.Cells[Rowx, 18].Value = " 30-60 Hari ";
            ws.Cells[Rowx, 19].Value = " > 60 Hari ";
            ws.Cells[Rowx, 20].Value = " 1% ";
            ws.Cells[Rowx, 21].Value = " 0,5% ";
            ws.Cells[Rowx, 22].Value = " 0,25% ";
            ws.Cells[Rowx, 23].Value = " Ins <= 30 Hari ";
            ws.Cells[Rowx, 24].Value = " Ins 30-60 Hari ";
            ws.Cells[Rowx, 25].Value = " Ins > 60 Hari ";
            ws.Cells[Rowx, 26].Value = " Insentif BE ";
            ws.Cells[Rowx, 27].Value = " Nominal FX ";
            ws.Cells[Rowx, 28].Value = " <= 14 Hari ";
            ws.Cells[Rowx, 29].Value = " 0,5% ";
            ws.Cells[Rowx, 30].Value = " Ins <= 14 Hari ";
            ws.Cells[Rowx, 31].Value = " Total Insentif ";

            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 1;

            no = 0;
            int Jrec = 0, nRec = 0;
            double Jmlb = 0, Jmlx = 0, Jmls = 0, Totb = 0, Totx = 0, Total = 0;

            string cNama = "";
            string cAwal = "1";

            if (ds.Tables[1].Rows.Count > 0)
            {
                Jrec = ds.Tables[1].Rows.Count;
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    nRec++;
                    if (cNama != Tools.isNull(dr1["Nama"], "").ToString())
                    {
                        if (cAwal != "1")
                        {
                            ws.Cells[Rowx, 3].Value = "Jumlah";
                            ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                            ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            ws.Cells[Rowx, 26].Value = Tools.isNull(Jmlb, 0);
                            ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 26].Style.Font.Bold = true;
                            ws.Cells[Rowx, 26].Style.Font.Color.SetColor(Color.Blue);

                            ws.Cells[Rowx, 30].Value = Tools.isNull(Jmlx, 0);
                            ws.Cells[Rowx, 30].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 30].Style.Font.Bold = true;
                            ws.Cells[Rowx, 30].Style.Font.Color.SetColor(Color.Blue);

                            ws.Cells[Rowx, 31].Value = Tools.isNull(Jmls, 0);
                            ws.Cells[Rowx, 31].Style.Numberformat.Format = "#,##;(#,##);0";
                            ws.Cells[Rowx, 31].Style.Font.Bold = true;
                            ws.Cells[Rowx, 31].Style.Font.Color.SetColor(Color.Blue);

                            Jmlb = 0; Jmlx = 0; Jmls = 0;
                            Rowx++;

                            var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                            border1.Bottom.Style = ExcelBorderStyle.Thin;
                            border1.Top.Style =
                            border1.Left.Style =
                            border1.Right.Style = ExcelBorderStyle.None;

                            Rowx++;
                            Rowx++;
                            nRow = Rowx;

                            ws.Cells[Rowx, 2].Value = " No ";
                            ws.Cells[Rowx, 3].Value = " Nama Penagih ";
                            ws.Cells[Rowx, 4].Value = " No Reg ";
                            ws.Cells[Rowx, 5].Value = " Tgl Reg ";
                            ws.Cells[Rowx, 6].Value = " No Nota ";
                            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
                            ws.Cells[Rowx, 8].Value = " TR ";
                            ws.Cells[Rowx, 9].Value = " HariPtg ";
                            ws.Cells[Rowx, 10].Value = " Tgl JtTempo ";
                            ws.Cells[Rowx, 11].Value = " Tgl Inden ";
                            ws.Cells[Rowx, 12].Value = " Rp Tagih ";
                            ws.Cells[Rowx, 13].Value = " Nominal BE ";
                            ws.Cells[Rowx, 14].Value = " Rp Kas ";
                            ws.Cells[Rowx, 15].Value = " Rp Giro ";
                            ws.Cells[Rowx, 16].Value = " rp Trn ";
                            ws.Cells[Rowx, 17].Value = " <= 30 Hari ";
                            ws.Cells[Rowx, 18].Value = " 30-60 Hari ";
                            ws.Cells[Rowx, 19].Value = " > 60 Hari ";
                            ws.Cells[Rowx, 20].Value = " 1% ";
                            ws.Cells[Rowx, 21].Value = " 0,5% ";
                            ws.Cells[Rowx, 22].Value = " 0,25% ";
                            ws.Cells[Rowx, 23].Value = " Ins <= 30 Hari ";
                            ws.Cells[Rowx, 24].Value = " Ins 30-60 Hari ";
                            ws.Cells[Rowx, 25].Value = " Ins > 60 Hari ";
                            ws.Cells[Rowx, 26].Value = " Insentif BE ";
                            ws.Cells[Rowx, 27].Value = " Nominal FX ";
                            ws.Cells[Rowx, 28].Value = " <= 14 Hari ";
                            ws.Cells[Rowx, 29].Value = " 0,5% ";
                            ws.Cells[Rowx, 30].Value = " Ins <= 14 Hari ";
                            ws.Cells[Rowx, 31].Value = " Total Insentif ";

                            ws.Cells[Rowx, 9, Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 12, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            Rowx += 3;
                            no = 0;
                        }
                    }

                    cNama = Tools.isNull(dr1["Nama"], "").ToString();
                    cAwal = "0";
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["Nama"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NoReg"], "").ToString();
                    ws.Cells[Rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglReg"], ""));
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["NoTransaksi"], "").ToString();
                    ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTransaksi"], ""));
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(Tools.isNull(dr1["HariPtg"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[Rowx, 10].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglJtTempo"], ""));
                    ws.Cells[Rowx, 11].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglInden"], ""));
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["RpTagih"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["RpKas"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpGiro"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["RpTransfer"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 17].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe1"], "0").ToString());
                    ws.Cells[Rowx, 17].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 18].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe2"], "0").ToString());
                    ws.Cells[Rowx, 18].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 19].Value = Convert.ToDouble(Tools.isNull(dr1["Rpbe3"], "0").ToString());
                    ws.Cells[Rowx, 19].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 20].Value = Convert.ToDouble(Tools.isNull(dr1["persen1"], "0").ToString());
                    ws.Cells[Rowx, 20].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 21].Value = Convert.ToDouble(Tools.isNull(dr1["persen2"], "0").ToString());
                    ws.Cells[Rowx, 21].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 22].Value = Convert.ToDouble(Tools.isNull(dr1["persen3"], "0").ToString());
                    ws.Cells[Rowx, 22].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 23].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe1"], "0").ToString());
                    ws.Cells[Rowx, 23].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 24].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe2"], "0").ToString());
                    ws.Cells[Rowx, 24].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 25].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe3"], "0").ToString());
                    ws.Cells[Rowx, 25].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 26].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 27].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx"], "0").ToString());
                    ws.Cells[Rowx, 27].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 28].Value = Convert.ToDouble(Tools.isNull(dr1["Rpfx1"], "0").ToString());
                    ws.Cells[Rowx, 28].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 29].Value = Convert.ToDouble(Tools.isNull(dr1["persenFX1"], "0").ToString());
                    ws.Cells[Rowx, 29].Style.Numberformat.Format = "#,###0.#0";
                    ws.Cells[Rowx, 30].Value = Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    ws.Cells[Rowx, 30].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 31].Value = Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString()) +
                                               Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    ws.Cells[Rowx, 31].Style.Numberformat.Format = "#,##;(#,##);0";

                    Jmlb += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Jmlx += Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    Jmls += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString()) +
                              Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    Totb += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString());
                    Totx += Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    Total += Convert.ToDouble(Tools.isNull(dr1["Insbe"], "0").ToString()) +
                             Convert.ToDouble(Tools.isNull(dr1["Insfx1"], "0").ToString());
                    Rowx++;
                }

                if (nRec == Jrec)
                {
                    ws.Cells[Rowx, 3].Value = "Jumlah";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 26].Value = Tools.isNull(Jmlb, 0);
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 26].Style.Font.Bold = true;
                    ws.Cells[Rowx, 26].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 30].Value = Tools.isNull(Jmlx, 0);
                    ws.Cells[Rowx, 30].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 30].Style.Font.Bold = true;
                    ws.Cells[Rowx, 30].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 31].Value = Tools.isNull(Jmls, 0);
                    ws.Cells[Rowx, 31].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 31].Style.Font.Bold = true;
                    ws.Cells[Rowx, 31].Style.Font.Color.SetColor(Color.Blue);

                    Rowx++;

                    ws.Cells[Rowx, 3].Value = "Total";
                    ws.Cells[Rowx, 3].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[Rowx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells[Rowx, 26].Value = Tools.isNull(Totb, 0);
                    ws.Cells[Rowx, 26].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 26].Style.Font.Bold = true;
                    ws.Cells[Rowx, 26].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 30].Value = Tools.isNull(Totx, 0);
                    ws.Cells[Rowx, 30].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 30].Style.Font.Bold = true;
                    ws.Cells[Rowx, 30].Style.Font.Color.SetColor(Color.Blue);

                    ws.Cells[Rowx, 31].Value = Tools.isNull(Total, 0);
                    ws.Cells[Rowx, 31].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 31].Style.Font.Bold = true;
                    ws.Cells[Rowx, 31].Style.Font.Color.SetColor(Color.Blue);

                    var border1 = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
                    border1.Bottom.Style = ExcelBorderStyle.Thin;
                    border1.Top.Style =
                    border1.Left.Style =
                    border1.Right.Style = ExcelBorderStyle.None;
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
