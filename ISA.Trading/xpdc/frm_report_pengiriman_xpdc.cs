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
using ISA.Trading.Class;
using ISA.Trading;
using ISA.Trading.Master;
using System.Data.SqlTypes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace ISA.Trading.xpdc
{
    public partial class frm_report_pengiriman_xpdc : ISA.Controls.BaseForm
    {
        DataTable dt;

        #region Generate
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "REKAP PENGIRIMAN";

            ex.Workbook.Worksheets.Add("Rekap Pengiriman");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.Cells[1, 1].Worksheet.Column(1).Width = 14;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 12;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 25;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 25;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 14;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 14;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 35;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 50;
            ws.Cells[1,10].Worksheet.Column(10).Width = 20;
            ws.Cells[1,11].Worksheet.Column(11).Width = 15;
            ws.Cells[1,12].Worksheet.Column(12).Width = 14;
            ws.Cells[1,13].Worksheet.Column(13).Width = 23;

            ws.Cells[1, 1, 1, 3].Merge = true;
            ws.Cells[2, 1, 2, 3].Merge = true;
            ws.Cells[1, 1].Value = "Laporan     : Rekap Pengiriman";
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", Tgl1.DateValue) + " s/d " + string.Format("{0:dd-MM-yyyy}", Tgl2.DateValue);

            ws.Cells[5, 1].Value = "TANGGAL"; ws.Cells[5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "NOMOR"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "SOPIR"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "KERNET"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "NO POL"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "TGL NOTA"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "NO NOTA"; ws.Cells[5, 7, 6, 7].Merge = true;
            ws.Cells[5, 8].Value = "NAMA TOKO"; ws.Cells[5, 8, 6, 8].Merge = true;
            ws.Cells[5, 9].Value = "ALAMAT"; ws.Cells[5, 9, 6, 9].Merge = true;
            ws.Cells[5,10].Value = "TUJUAN"; ws.Cells[5,10, 6,10].Merge = true;
            ws.Cells[5,11].Value = "JML KOLI"; ws.Cells[5,11, 6,11].Merge = true;
            ws.Cells[5,12].Value = "TGL TERIMA"; ws.Cells[5,12, 6,12].Merge = true;
            ws.Cells[5,13].Value = "BARCODE"; ws.Cells[5,13, 6,13].Merge = true;

            ws.Cells[5, 1, 6, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int Rowp = 6;
            int i = 0;
            for (i = 0; i <= (dt.Rows.Count)-1; i++)
            {
                Rowp++;
                ws.Cells[Rowp, 1].Value = string.Format("{0:dd/MM/yyyy}",dt.Rows[i]["TglKirim"]);
                ws.Cells[Rowp, 2].Value = Convert.ToString(dt.Rows[i]["NoKirim"]);
                ws.Cells[Rowp, 3].Value = Convert.ToString(dt.Rows[i]["Sopir"]);
                ws.Cells[Rowp, 4].Value = Convert.ToString(dt.Rows[i]["Kernet"]);
                ws.Cells[Rowp, 5].Value = Convert.ToString(dt.Rows[i]["NoPolisi"]);
                ws.Cells[Rowp, 6].Value = string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["TglSuratJalan"]);
                ws.Cells[Rowp, 7].Value = Convert.ToString(dt.Rows[i]["NoSuratJalan"]);
                ws.Cells[Rowp, 8].Value = Convert.ToString(dt.Rows[i]["NamaToko"]);
                ws.Cells[Rowp, 9].Value = Convert.ToString(dt.Rows[i]["Alamat"]);
                ws.Cells[Rowp,10].Value = Convert.ToString(dt.Rows[i]["Tujuan"]);
                ws.Cells[Rowp,11].Value = Convert.ToString(dt.Rows[i]["KeteranganKoli"]);
                ws.Cells[Rowp,12].Value = string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["TglTrmToko"]);
                ws.Cells[Rowp,13].Value = Convert.ToString(dt.Rows[i]["Barcode"]);
            }



            /*
            int rowx = 7;
            double FE2col2 = 0, FE2col3 = 0, FE2col4 = 0, FE2col5 = 0, FE2col7 = 0;
            double FE4col2 = 0, FE4col3 = 0, FE4col4 = 0, FE4col5 = 0, FE4col7 = 0;
            double FB2col2 = 0, FB2col3 = 0, FB2col4 = 0, FB2col5 = 0, FB2col7 = 0;
            double FB4col2 = 0, FB4col3 = 0, FB4col4 = 0, FB4col5 = 0, FB4col7 = 0;
            double FAcol2 = 0, FAcol3 = 0, FAcol4 = 0, FAcol5 = 0, FAcol7 = 0;
            double FLcol2 = 0, FLcol3 = 0, FLcol4 = 0, FLcol5 = 0, FLcol7 = 0;
            */
            /*
            foreach (DataRow dr1 in dt.Rows)
            {
                ws.Cells[5, 7].Value = "BUDGET PEMBELIAN\n (" + Convert.ToString(dr1["Budget"]) + " %)";
                string aa = dr1["KelompokBrgID"].ToString().Substring(0, 3);
                switch (aa)
                {
                    case "FE2":
                        rowx = 7;
                        FE2col2 = Convert.ToDouble(dr1["totalbeli"]);
                        FE2col3 = Convert.ToDouble(dr1["Netto1"]);
                        FE2col4 = Convert.ToDouble(dr1["Netto2"]);
                        FE2col5 = Convert.ToDouble(dr1["Netto3"]);
                        FE2col7 = Convert.ToDouble(dr1["BudgetPembelian"]);
                        break;
                    case "FE4":
                        rowx = 8;
                        FE4col2 = Convert.ToDouble(dr1["totalbeli"]);
                        FE4col3 = Convert.ToDouble(dr1["Netto1"]);
                        FE4col4 = Convert.ToDouble(dr1["Netto2"]);
                        FE4col5 = Convert.ToDouble(dr1["Netto3"]);
                        FE4col7 = Convert.ToDouble(dr1["BudgetPembelian"]);
                        break;
                    case "FB2":
                        rowx = 9;
                        FB2col2 = Convert.ToDouble(dr1["totalbeli"]);
                        FB2col3 = Convert.ToDouble(dr1["Netto1"]);
                        FB2col4 = Convert.ToDouble(dr1["Netto2"]);
                        FB2col5 = Convert.ToDouble(dr1["Netto3"]);
                        FB2col7 = Convert.ToDouble(dr1["BudgetPembelian"]);
                        break;
                    case "FB4":
                        rowx = 10;
                        FB4col2 = Convert.ToDouble(dr1["totalbeli"]);
                        FB4col3 = Convert.ToDouble(dr1["Netto1"]);
                        FB4col4 = Convert.ToDouble(dr1["Netto2"]);
                        FB4col5 = Convert.ToDouble(dr1["Netto3"]);
                        FB4col7 = Convert.ToDouble(dr1["BudgetPembelian"]);
                        break;
                    default:
                        {
                            if (Tools.Left(aa, 2) == "FA")
                            {
                                rowx = 11;
                                FAcol2 = FAcol2 + Convert.ToDouble(dr1["totalbeli"]);
                                FAcol3 = FAcol3 + Convert.ToDouble(dr1["Netto1"]);
                                FAcol4 = FAcol4 + Convert.ToDouble(dr1["Netto2"]);
                                FAcol5 = FAcol5 + Convert.ToDouble(dr1["Netto3"]);
                                FAcol7 = FAcol7 + Convert.ToDouble(dr1["BudgetPembelian"]);
                            }
                            else
                            {
                                rowx = 12;
                                FLcol2 = FLcol2 + Convert.ToDouble(dr1["totalbeli"]);
                                FLcol3 = FLcol3 + Convert.ToDouble(dr1["Netto1"]);
                                FLcol4 = FLcol4 + Convert.ToDouble(dr1["Netto2"]);
                                FLcol5 = FLcol5 + Convert.ToDouble(dr1["Netto3"]);
                                FLcol7 = FLcol7 + Convert.ToDouble(dr1["BudgetPembelian"]);
                            }
                        }
                        break;
                }
            }*/

            /*
            ws.Cells[7, 2].Value = FE2col2; ws.Cells[7, 3].Value = FE2col3; ws.Cells[7, 4].Value = FE2col4;
            ws.Cells[7, 5].Value = FE2col5; ws.Cells[7, 7].Value = FE2col7;

            ws.Cells[8, 2].Value = FE4col2; ws.Cells[8, 3].Value = FE4col3; ws.Cells[8, 4].Value = FE4col4;
            ws.Cells[8, 5].Value = FE4col5; ws.Cells[8, 7].Value = FE4col7;

            ws.Cells[9, 2].Value = FB2col2; ws.Cells[9, 3].Value = FB2col3; ws.Cells[9, 4].Value = FB2col4;
            ws.Cells[9, 5].Value = FB2col5; ws.Cells[9, 7].Value = FB2col7;

            ws.Cells[10, 2].Value = FB4col2; ws.Cells[10, 3].Value = FB4col3; ws.Cells[10, 4].Value = FB4col4;
            ws.Cells[10, 5].Value = FB4col5; ws.Cells[10, 7].Value = FB4col7;

            ws.Cells[11, 2].Value = FAcol2; ws.Cells[11, 3].Value = FAcol3; ws.Cells[11, 4].Value = FAcol4;
            ws.Cells[11, 5].Value = FAcol5; ws.Cells[11, 7].Value = FAcol7;

            ws.Cells[12, 2].Value = FLcol2; ws.Cells[12, 3].Value = FLcol3; ws.Cells[12, 4].Value = FLcol4;
            ws.Cells[12, 5].Value = FLcol5; ws.Cells[12, 7].Value = FLcol7;
            */

            /*
            for (int y = 7; y <= 12; y++)
            {
                ws.Cells[y, 6].Formula = "=(" + ws.Cells[y, 3].Address + "+" + ws.Cells[y, 4].Address +
                                            "+" + ws.Cells[y, 5].Address + ")/3";
                if (Convert.ToInt32(ws.Cells[y, 7].Value) > 0)
                    ws.Cells[y, 8].Formula = "=(" + ws.Cells[y, 2].Address + "/" + ws.Cells[y, 7].Address + "*100)";
                else
                    ws.Cells[y, 8].Value = 0;

                ws.Cells[y, 9].Formula = "=(" + ws.Cells[y, 7].Address + "-" + ws.Cells[y, 2].Address + ")";
                for (int z = 2; z <= 9; z++)
                {
                    ws.Cells[y, z].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                }
            }
            // Total
            for (int z = 2; z <= 5; z++)
            {
                ws.Cells[13, z].Formula = "(SUM(" + ws.Cells[7, z].Address + ":" + ws.Cells[12, z].Address + "))";
                ws.Cells[13, z].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
            }
            ws.Cells[13, 6].Formula = "=(" + ws.Cells[13, 3].Address + "+" + ws.Cells[13, 4].Address +
                                            "+" + ws.Cells[13, 5].Address + ")/3";
            ws.Cells[13, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
            */
            
            var border3 = ws.Cells[5, 1, Rowp, 13].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[5, 1, 6, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 6, 13].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            return ex;
        }
        #endregion

        
        
        public frm_report_pengiriman_xpdc()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_report_pengiriman_xpdc_Load(object sender, EventArgs e)
        {
            Tgl1.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            Tgl2.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_ReportKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, Tgl1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, Tgl2.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                    //MessageBox.Show(dt.Rows.Count.ToString());
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

            if (dt.Rows.Count > 0)
            {
                //GenerateExcel(dt);
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Rekap_pengiriman_barang.xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Data tidak ada..!");
            }
        }
    }
}
