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
    public partial class frmRptSalesmanScore : ISA.Trading.BaseForm
    {
        #region Variables
        DataSet dsFBFE = new DataSet();
        DataTable dtFBFE = new DataTable();
        DataTable dtFA = new DataTable();
        DataTable dtFLAIN = new DataTable();
        DateTime _FromDate;
        DateTime _ToDate;
        string _salesID;


        #endregion

        #region Generate
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Salesman Score";

            ex.Workbook.Worksheets.Add("Lap Salesman Score");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 23;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 15;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 25;
            for (int y = 3; y <= 24; y++)
            {
                ws.Cells[1, y].Worksheet.Column(y).Width = 14;
            }

            ws.Cells[1, 1, 1, 3].Merge = true;
            ws.Cells[2, 1, 2, 3].Merge = true;
            ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1].Value = "Laporan     : Salesman Score (Kelp. FB & FE)";
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value );
            ws.Cells[3, 1].Value = "Update      : " ;

            //Header
            ws.Cells[5, 1].Value = "KD.SALES"; ws.Cells[ 5, 1, 6, 1].Merge = true;
            ws.Cells[5, 2].Value = "SALESMAN"; ws.Cells[ 5, 2, 6, 2].Merge = true;

            ws.Cells[5, 3].Value = "NOMINAL"; ws.Cells[ 5, 3, 5, 6].Merge = true;
            ws.Cells[6, 3].Value = "Target";
            ws.Cells[6, 4].Value = "Actual";
            ws.Cells[6, 5].Value = "Selisih";
            ws.Cells[6, 6].Value = "%"; 

            ws.Cells[5, 7].Value = "OA"; ws.Cells[5, 7, 5,10].Merge = true;
            ws.Cells[6, 7].Value = "Target";
            ws.Cells[6, 8].Value = "Toko Order";
            ws.Cells[6, 9].Value = "Selisih";
            ws.Cells[6, 10].Value = "%"; 

            ws.Cells[5,11].Value = "SKU"; ws.Cells[5,11, 5,14].Merge = true;
            ws.Cells[6, 11].Value = "Target";
            ws.Cells[6, 12].Value = "Items";
            ws.Cells[6, 13].Value = "Selisih";
            ws.Cells[6, 14].Value = "%";


            ws.Cells[5,15].Value = "FB2 Nominal"; ws.Cells[5, 15, 6, 15].Merge = true;

            ws.Cells[5, 16].Value = "FB4 Nominal"; ws.Cells[5, 16, 6, 16].Merge = true;

            ws.Cells[5, 17].Value = "FE2 Nominal"; ws.Cells[5, 17, 6, 17].Merge = true;
            
            ws.Cells[5, 18].Value = "FE4 Nominal"; ws.Cells[5, 18, 6, 18].Merge = true;

            ws.Cells[5, 19].Value = "Score";  ws.Cells[5, 19, 5, 21].Merge = true;
            ws.Cells[6, 19].Value = "Score Omset"; 
            ws.Cells[6, 20].Value = "Score OA"; 
            ws.Cells[6, 21].Value = "Score SKU";

            ws.Cells[5, 22].Value = "Total"; ws.Cells[5, 22, 6, 22].Merge = true;
            ws.Cells[5, 23].Value = "Status Sales"; ws.Cells[5, 23, 6, 23].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            
            
            int rowx = 7;
           
            double selisih = 0 ,  nilai = 0,  target=0, percent= 0;
            double selisihoa = 0, nilaioa = 0, targetoa = 0, percentoa = 0;
            double selisihsku = 0, nilaisku = 0, targetsku = 0, percentsku = 0;
            DateTime tglkeluar = DateTime.MinValue;

            foreach (DataRow dr1 in dsFBFE.Tables[0].Rows)
            {
                ws.Cells[rowx, 1].Value = dr1["KodeSales"];
                ws.Cells[rowx, 2].Value = dr1["NamaSales"];

                nilai = Convert.ToDouble(Tools.isNull(dr1["nilai"], 0));
                target = Convert.ToDouble(Tools.isNull(dr1["TargetOmset"], 0));

                ws.Cells[rowx, 3].Value = target;
                ws.Cells[rowx, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 4].Value = nilai;
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                selisih = nilai - target;

                ws.Cells[rowx, 5].Value = selisih;
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                if (target == 0)
                {
                    ws.Cells[rowx, 6].Value = 0;
                    ws.Cells[rowx, 6].Style.Numberformat.Format = "0%";
                }
                else
                {
                    percent = nilai / target;
                    ws.Cells[rowx, 6].Value = percent;
                    ws.Cells[rowx, 6].Style.Numberformat.Format = "0.00 %";
                }


                //oa
                nilaioa = Convert.ToInt32(Tools.isNull(dr1["TokoOrder"], 0));
                targetoa = Convert.ToInt32(Tools.isNull(dr1["TargetOa"], 0));

                ws.Cells[rowx, 7].Value = targetoa;
                ws.Cells[rowx, 8].Value = nilaioa;

                selisihoa = nilaioa - targetoa;

                ws.Cells[rowx, 9].Value = selisihoa;

                if (targetoa == 0)
                {
                    ws.Cells[rowx, 10].Value = 0;
                    ws.Cells[rowx, 10].Style.Numberformat.Format = "0 %";
                }
                else
                {
                    percentoa = nilaioa / targetoa;
                    ws.Cells[rowx, 10].Value = percentoa;
                    ws.Cells[rowx, 10].Style.Numberformat.Format = "0.00 %";
                }

                //sku
                nilaisku = Convert.ToInt32(Tools.isNull(dr1["items"], 0));
                targetsku = Convert.ToInt32(Tools.isNull(dr1["TargetSKU"], 0));

                ws.Cells[rowx, 11].Value = targetsku;
                ws.Cells[rowx, 12].Value = nilaisku;

                selisihsku = nilaisku - targetsku;

                ws.Cells[rowx, 13].Value = selisihsku;

                if (targetsku == 0)
                {
                    ws.Cells[rowx, 14].Value = 0;
                    ws.Cells[rowx, 14].Style.Numberformat.Format = "0 %";
                }
                else
                {
                    percentsku = nilaisku / targetsku;
                    ws.Cells[rowx, 14].Value = percentsku;
                    ws.Cells[rowx, 14].Style.Numberformat.Format = "0.00 %";
                }

                ws.Cells[rowx, 15].Value = dr1["nilaifb2"];
                ws.Cells[rowx, 15].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 16].Value = dr1["nilaifb4"];
                ws.Cells[rowx, 16].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 17].Value = dr1["nilaife2"];
                ws.Cells[rowx, 17].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 18].Value = dr1["nilaife4"];
                ws.Cells[rowx, 18].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                //score
                ws.Cells[rowx, 19].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 10].Address + "<80," + ws.Cells[rowx, 14].Address + "<80),MIN(50," + ws.Cells[rowx, 6].Address + "*0.5)," + ws.Cells[rowx, 6].Address + "*0.5)";
                ws.Cells[rowx, 19].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                ws.Cells[rowx, 20].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 10].Address + "<80," + ws.Cells[rowx, 14].Address + "<80),MIN(25," + ws.Cells[rowx, 10].Address + "*0.25)," + ws.Cells[rowx, 10].Address + "*0.25)";
                ws.Cells[rowx, 20].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                ws.Cells[rowx, 21].Formula = "IF(OR(" + ws.Cells[rowx, 6].Address + "<80," + ws.Cells[rowx, 10].Address + "<80," + ws.Cells[rowx, 14].Address + "<80),MIN(25," + ws.Cells[rowx, 14].Address + "*0.25)," + ws.Cells[rowx, 14].Address + "*0.25)";
                ws.Cells[rowx, 21].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                ws.Cells[rowx, 22].Formula = "(" + ws.Cells[rowx, 19].Address + "+" + ws.Cells[rowx, 20].Address + "+" + ws.Cells[rowx, 21].Address + ")";
                ws.Cells[rowx, 22].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                ws.Cells[rowx, 23].Value = dr1["StatusSales"] ;
               

                rowx++;
            }


            ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 1, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;



            #region sheet 2

            
            ex.Workbook.Worksheets.Add("Toko OB");
            ExcelWorksheet ws4 = ex.Workbook.Worksheets[2];

            //// Width
            ws4.Cells[1, 1].Worksheet.Column(1).Width = 20;
            ws4.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws4.Cells[1, 3].Worksheet.Column(3).Width = 18;
            ws4.Cells[1, 1, 1, 3].Merge = true;
            ws4.Cells[2, 1, 2, 3].Merge = true;
            ws4.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws4.Cells[1, 1].Value = "Laporan     : Toko OB";
            ws4.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws4.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws4.Cells[5, 1].Value = "KODE TOKO";
            ws4.Cells[5, 2].Value = "NAMA TOKO";
            ws4.Cells[5, 3].Value = "Rp NOTA";

            ws4.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws4.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dsFBFE.Tables[1].Rows)
            {
                ws4.Cells[rowx, 1].Value = dr1["KodeToko"];
                ws4.Cells[rowx, 2].Value = dr1["NamaToko"];
                ws4.Cells[rowx, 3].Value = dr1["RpNota"];
                ws4.Cells[rowx, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }

            var border5 = ws4.Cells[5, 1, rowx, 3].Style.Border;
            border5.Bottom.Style =
            border5.Top.Style =
            border5.Left.Style =
            border5.Right.Style = ExcelBorderStyle.Thin;
            ws4.Cells[5, 1, 5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws4.Cells[5, 1, 5, 3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            #endregion //toko ob
            
            #region sheet 3


            ex.Workbook.Worksheets.Add("OA Pasif 6 Bulan");
            ExcelWorksheet ws5 = ex.Workbook.Worksheets[3];

            //// Width
            ws5.Cells[1, 1].Worksheet.Column(1).Width = 20;
            ws5.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws5.Cells[1, 3].Worksheet.Column(3).Width = 18;
            ws5.Cells[1, 1, 1, 3].Merge = true;
            ws5.Cells[2, 1, 2, 3].Merge = true;
            ws5.Cells[3, 1, 3, 3].Merge = true;

            //// Title
            ws5.Cells[1, 1].Value = "Laporan     : OA Pasif 6 Bulan";
            ws5.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", dtbEnd.DateValue.Value);
            ws5.Cells[3, 1].Value = "Update      : ";

            ////Header
            ws5.Cells[5, 1].Value = "KODE TOKO";
            ws5.Cells[5, 2].Value = "NAMA TOKO";
            ws5.Cells[5, 3].Value = "Rp NOTA";

            ws5.Cells[5, 1, 5, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws5.Cells[5, 1, 5, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 6;
            foreach (DataRow dr1 in dsFBFE.Tables[2].Rows)
            {
                ws5.Cells[rowx, 1].Value = dr1["KodeToko"];
                ws5.Cells[rowx, 2].Value = dr1["NamaToko"];
                ws5.Cells[rowx, 3].Value = dr1["RpNota"];
                ws5.Cells[rowx, 3].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                rowx++;
            }

            var border6 = ws5.Cells[5, 1, rowx, 3].Style.Border;
            border6.Bottom.Style =
            border6.Top.Style =
            border6.Left.Style =
            border6.Right.Style = ExcelBorderStyle.Thin;
            ws5.Cells[5, 1, 5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws5.Cells[5, 1, 5, 3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            
            #endregion
            

            return ex;
        }

        #endregion
        

        public frmRptSalesmanScore()
        {
            InitializeComponent();
        }

        private void frmRptSalesmanScore_Load(object sender, EventArgs e)
        {
                               
            dtbEnd.DateValue = GlobalVar.DateOfServer.AddDays(-1);
            dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1 * (dtbEnd.DateValue.Value.Day - 1));
        }


        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                _FromDate = dtbStart.DateValue.Value;
                _ToDate = dtbEnd.DateValue.Value;
                dsFBFE = new DataSet();
                _salesID = Tools.isNull(lookupSales.SalesID,"").ToString();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_lapSalesmanScore]"));
                    if (_salesID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _salesID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _ToDate));
                    dsFBFE = db.Commands[0].ExecuteDataSet();
                }

                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Salesman Score.xlsx";

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

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtbEnd_Leave(object sender, EventArgs e)
        {
            if (dtbEnd.DateValue.HasValue)
            {
                dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1 * (dtbEnd.DateValue.Value.Day - 1));
            }
        }
    }


}
