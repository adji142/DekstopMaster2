using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmBudgetPembelian : ISA.Trading.BaseForm
    {
        DateTime _FromDate;
        DateTime _ToDate;
        int _budget;
        string _cMonth1;
        string _cMonth2;
        string _cMonth3;
        DataTable dt = new DataTable();


        #region Generate
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Analisa Budget Pembelian";

            ex.Workbook.Worksheets.Add("Budget Pembelian");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            for (int y = 1; y <= 10; y++)
            {
                ws.Cells[1, y].Worksheet.Column(y).Width = 15;
            }
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;
            ws.Cells[1, 1, 1, 3].Merge = true;
            ws.Cells[2, 1, 2, 3].Merge = true;
            ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1].Value = "Laporan     : Analisa Budget Pembelian";
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth);
            ws.Cells[3, 1].Value = "Update      : ";

            ws.Cells[5, 1].Value = "KELP.BARANG"; ws.Cells[5, 1, 6, 1].Merge = true;

            ws.Cells[5, 2].Value = "TOTAL BELI"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "OMSET"; ws.Cells[5, 3, 5, 6].Merge = true;

            
            ws.Cells[5, 7, 6, 7].Merge = true; ws.Cells[5, 7].Style.WrapText = true;
            ws.Cells[5, 8].Value = "ACTUAL\n(%)"; ws.Cells[5, 8, 6, 8].Merge = true; ws.Cells[5, 8].Style.WrapText = true;
            ws.Cells[5, 9].Value = "SELISIH\n(Rp)"; ws.Cells[5, 9, 6, 9].Merge = true; ws.Cells[5, 9].Style.WrapText = true;
            ws.Cells[5, 10].Value = "KETERANGAN"; ws.Cells[5, 10, 6, 10].Merge = true;

            ws.Cells[6, 3].Value = _cMonth1;
            ws.Cells[6, 4].Value = _cMonth2;
            ws.Cells[6, 5].Value = _cMonth3;
            ws.Cells[6, 6].Value = "Rata-rata";
            ws.Cells[5, 1, 6, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[7, 1].Value = "FE2";
            ws.Cells[8, 1].Value = "FE4";
            ws.Cells[9, 1].Value = "FB2";
            ws.Cells[10, 1].Value = "FB4";
            ws.Cells[11, 1].Value = "FA";
            ws.Cells[12, 1].Value = "FLAIN";
            ws.Cells[13, 1].Value = "TOTAL";

            int rowx = 7;
            double FE2col2 = 0, FE2col3 = 0, FE2col4 = 0, FE2col5 = 0, FE2col7 = 0;
            double FE4col2 = 0, FE4col3 = 0, FE4col4 = 0, FE4col5 = 0, FE4col7 = 0;
            double FB2col2 = 0, FB2col3 = 0, FB2col4 = 0, FB2col5 = 0, FB2col7 = 0;
            double FB4col2 = 0, FB4col3 = 0, FB4col4 = 0, FB4col5 = 0, FB4col7 = 0;
            double FAcol2 = 0, FAcol3 = 0, FAcol4 = 0, FAcol5 = 0, FAcol7 = 0;
            double FLcol2 = 0, FLcol3 = 0, FLcol4 = 0, FLcol5 = 0, FLcol7 = 0;

            foreach (DataRow dr1 in dt.Rows)
            {
                ws.Cells[5, 7].Value = "BUDGET PEMBELIAN\n (" + Convert.ToString(dr1["Budget"])+ " %)";
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
            }

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
                ws.Cells[13, z].Formula = "(SUM("+ ws.Cells[7, z].Address+":" + ws.Cells[12, z].Address+"))";
                ws.Cells[13, z].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
            }
            ws.Cells[13, 6].Formula = "=(" + ws.Cells[13, 3].Address + "+" + ws.Cells[13, 4].Address +
                                            "+" + ws.Cells[13, 5].Address + ")/3";
            ws.Cells[13, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
            var border3 = ws.Cells[5, 1, 13, 10].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[5, 1, 6, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 6, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

        return ex;
        }
        #endregion

        public frmBudgetPembelian()
        {
            InitializeComponent();
        }

        private void frmBudgetPembelian_Load(object sender, EventArgs e)
        {

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo ind= CultureInfo.GetCultureInfo("id-ID");
                _FromDate = monthYearBox1.FirstDateOfMonth;
                _ToDate = monthYearBox1.LastDateOfMonth;

                int _Month1 = (_FromDate.AddMonths(-1)).Month;
                int _Month2 = (_FromDate.AddMonths(-2)).Month;
                int _Month3 = (_FromDate.AddMonths(-3)).Month;

                _cMonth1 = ind.DateTimeFormat.MonthNames[_Month1-1];
                _cMonth2 = ind.DateTimeFormat.MonthNames[_Month2-1];
                _cMonth3 = ind.DateTimeFormat.MonthNames[_Month3-1];

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LaporanAnalisaBudgetPembelian]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Tidak Ada Data");
                }

                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Analisa Budget Pembelian.xlsx";

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
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}


