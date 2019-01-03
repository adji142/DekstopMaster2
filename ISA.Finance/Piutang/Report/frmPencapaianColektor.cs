using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
//using Excel = Microsoft.Office.Interop.Excel;
using ISA.Finance;
using ISA.DAL;
using System.Net;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Finance.Piutang.Report
{
    public partial class frmPencapaianColektor : Form
    {
        string nop = "";
        public frmPencapaianColektor()
        {
            InitializeComponent();
        }
        private void frmPencapaianColektor_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void btnPrintColektor_Click(object sender, EventArgs e)
        {
            DateTime iDate; 
            iDate = dateTimePicker1.Value;
            string tgl = iDate.Day.ToString();
            string bln = iDate.Month.ToString();
            int bul=int.Parse(bln);
            string th = iDate.Year.ToString();
            string date = th + "-" + bln + "-" + tgl;
            int t = int.Parse(tgl);
            toEx(t, date, iDate);

            //DateTime tw = (new DateTime(iDate.Year, iDate.Month, 1)).AddDays(-1);
            //string []tgl1ata = iDate.Split(' ');
            //MessageBox.Show("Selected date is " + tw);
            this.Close();
        }

        public void toEx(int tgl, string date, DateTime iDate)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Pencapaian Kolektor.xlsx";

                sf.OverwritePrompt = true;


                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt;
                    using (Database db = new Database("ISADBDepoBatchReport"))
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_tagihankolektor]"));
                        db.Commands[0].Parameters.Add(new Parameter("todate", SqlDbType.Date, date));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    DataTable dt2;
                    using (Database db2 = new Database("ISADBDepoBatchReport"))
                    {
                        db2.Commands.Add(db2.CreateCommand("[rsp_dailymonitoring]"));
                        db2.Commands[0].Parameters.Add(new Parameter("todate", SqlDbType.Date, date));
                        dt2 = db2.Commands[0].ExecuteDataTable();
                    }


                    //ShowReport(dt);

                    string file = sf.FileName.ToString();
                    GenerateExcel(dt, dt2, file, tgl, iDate);
                    //GenerateExcel2(dt2, file, tgl, iDate);

                    Process.Start(file);
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void GenerateExcel(DataTable dt,DataTable dt2, string file, int jml, DateTime iDate)
        {

            int tgl = int.Parse(iDate.Day.ToString());
            int bln = int.Parse(iDate.Month.ToString());
            int th = int.Parse(iDate.Year.ToString());
            int jml2 = jml;
            DateTime tw = (new DateTime(iDate.Year, iDate.Month, 1)).AddDays(-1);
            int tgl2 = int.Parse(tw.Day.ToString());
            int bln2 = int.Parse(tw.Month.ToString());
            int th2 = int.Parse(tw.Year.ToString());
            //int = datepart(d,iDate);

            if (tgl > tgl2)
            {
                jml2 = tgl2;
            }

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "Laporan Pencapaian Kolektor";

                int sheet = 0, i = 0, j = 0;
               // DataTable dtSheets = new DataTable();
                //dtSheets = dt.DefaultView.ToTable(true, "LaporanPencapaianKolektor");
                sheet++;

                //
                p.Workbook.Worksheets.Add("PencapaianKolektor");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                // nop = dr["LaporanPencapaianKolektor"].ToString();
                ws.Name = "PencapaianKolektor"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 8; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";
                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 60;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                for (int a = 0; a < jml; a++)
                {
                    ws.Cells[1, a + 7].Worksheet.Column(a + 7).Width = 15;
                }
                ws.Cells[1, 7 + jml].Worksheet.Column(7 + jml).Width = 10;
                for (int a = 8; a <= 10; a++)
                {
                    ws.Cells[1, a + jml].Worksheet.Column(a + jml).Width = 15;
                }

                ws.Cells[2, 2].Value = "Laporan Pencapaian Kolektor";
                ws.Cells[2, 2, 2, 10 + jml].Merge = true;
                ws.Cells[2, 2].Style.Font.Size = 12;
                ws.Cells[2, 2].Style.Font.Bold = true;
                ws.Cells[2, 2, 2, 5 + jml].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[2, 2, 2, 5 + jml].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[4, 2].Value = "Cabang";
                ws.Cells[4, 2, 4, 3].Merge = true;
                ws.Cells[5, 2].Value = "Periode";
                ws.Cells[5, 2, 5, 3].Merge = true;
                ws.Cells[4, 4].Value = ": "+GlobalVar.Gudang;
                string mon = ConvertBln(bln);
                string mon1 = ConvertBln(bln-1);

                ws.Cells[5, 4].Value = ": " + mon + " " + th;


                ws.Cells[7, 2].Value = "No";
                ws.Cells[7, 3].Value = "Kolektor/Sales";
                ws.Cells[7, 4].Value = "Wilayah Kerja";
                ws.Cells[7, 5].Value = "Target              " + mon + " " + th;
                ws.Cells[7, 6].Value = "Actual              " + mon1 + " " + th2;
                ws.Cells[7, 7].Value = "Actual Growth This Month";
                ws.Cells[7, 7, 7, 6 + jml].Merge = true;
                for (int a = 1; a <= jml; a++)
                {
                    ws.Cells[8, a + 6].Value = a + "/" + bln + "/" + th;
                }
                for (int a = 1; a < 6; a++)
                {
                    ws.Cells[7, a + 1, 9, a + 1].Merge = true;
                }
                for (int a = 1; a <= jml; a++)
                {
                    ws.Cells[8, a + 6, 9, a + 6].Merge = true;
                }

                ws.Cells[7, jml + 7].Value = "% Achv vs Target";
                ws.Cells[7, jml + 8].Value = "Dev " + mon + " " + th+" vs Target";
                ws.Cells[7, jml + 9].Value = "Act same date months ago";
                ws.Cells[7, jml + 10].Value = "Dev Today vs months ago";

                for (int a = 7; a <= 10; a++)
                {
                    ws.Cells[7, a + jml, 9, a + jml].Merge = true;
                }

                ws.Cells[7, 2, 9, jml + 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[7, 2, 9, jml + 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[7, 2, 9, jml + 10].Style.Font.Bold = true;
                ws.Cells[7, 2, 9, jml + 10].Style.WrapText = true;

                DataTable dtData = new DataTable();
                dtData = dt.Copy();
                int iAwal = 10;
                int k = 1;
                foreach (DataRow dataRow in dt.Rows)
                {
                    int m = 2;
                    ws.Cells[iAwal, 2].Value = k;
                    foreach (var item in dataRow.ItemArray)
                    {
                        if (m < jml + 6 && m > 2)
                        {
                            if (m == 5)
                            {
                                ws.Cells[iAwal, m].Value = 40000000;
                            }
                            else if (m > 5)
                            {
                                ws.Cells[iAwal, m + 1].Value = item;
                            }
                            else
                            {
                                ws.Cells[iAwal, m].Value = item;
                            }
                        }
                        else
                        {

                            if (m == 40 + jml2)
                            {
                                if (Equals(item, null) || item.ToString() == "")
                                {
                                    ws.Cells[iAwal, jml + 9].Value = 0;
                                }
                                else
                                {
                                    ws.Cells[iAwal, jml + 9].Value = item;
                                }
                            }
                            if (m == 40 + tgl2)
                            {
                                if (Equals(item, null) || item.ToString() == "")
                                {
                                    ws.Cells[iAwal, 6].Value = 0;
                                }
                                else
                                {
                                    ws.Cells[iAwal, 6].Value = item;
                                }
                            }
                        }
                        m++;
                    }
                    iAwal++;
                    k++;
                }

                for (int a = 10; a < iAwal; a++)
                {
                    ws.Cells[a, jml + 7].Formula = "(" + ws.Cells[a, jml + 6].Address +
                                "/" + ws.Cells[a, 5].Address + ")";
                    ws.Cells[a, jml + 8].Formula = "(" + ws.Cells[a, jml + 6].Address +
                                "-" + ws.Cells[a, 5].Address + ")";
                    ws.Cells[a, jml + 10].Formula = "(" + ws.Cells[a, jml + 6].Address +
                               "-" + ws.Cells[a, jml + 9].Address + ")";
                }
                ws.Cells[iAwal, 2].Style.Numberformat.Format = "0.00%";
                ws.Cells[iAwal, 2].Value = "Total";
                ws.Cells[iAwal, 2, iAwal, 4].Merge = true;
                if (iAwal == 10)
                {
                    ws.Cells[10, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[10, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    for (int a = 0; a <= jml; a++)
                    {
                        ws.Cells[iAwal, a + 6].Value= 0;
                    }
                    for (int a = 8; a <= 10; a++)
                    {
                        ws.Cells[iAwal, jml+a].Value = 0;
                    }
                    ws.Cells[10, 5, iAwal, jml + 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";
                }
                else
                {
                    ws.Cells[10, 2, iAwal - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[10, 2, iAwal, jml+10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[10, 2, iAwal - 1, 2].Style.WrapText = true;
                    for (int a = 0; a <= jml+1; a++)
                    {
                        ws.Cells[iAwal, a + 5].Formula = "Sum(" + ws.Cells[10, a + 5].Address +
                                ":" + ws.Cells[iAwal - 1, a + 5].Address + ")";
                    }
                    for (int a = 8; a <= 10; a++)
                    {
                        ws.Cells[iAwal, a + jml].Formula = "Sum(" + ws.Cells[10, a + jml].Address +
                                ":" + ws.Cells[iAwal - 1, a + jml].Address + ")";
                    }
                    ws.Cells[10, 5, iAwal, jml + 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";
                    ws.Cells[10, jml + 7, iAwal, jml + 7].Style.Numberformat.Format = "0.00%";
                    ws.Cells[10, jml + 8, iAwal, jml + 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";

                    ws.Cells[10, 4, iAwal-1, 4].Style.WrapText = true;
                }

                var border = ws.Cells[7, 2, iAwal, jml + 10].Style.Border;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[iAwal + 3, 2].Value = "Created by "+SecurityManager.UserName+" on " + GlobalVar.DateTimeOfServer;


                //
                p.Workbook.Worksheets.Add("DailyMonitoring");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[2];
                // nop = dr["LaporanPencapaianKolektor"].ToString();
                ws2.Name = "DailyMonitoring"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 8; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Arial";
                ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 10;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 15;
                for (int a = 0; a < jml; a++)
                {
                    ws2.Cells[1, a + 6].Worksheet.Column(a + 6).Width = 15;
                }
                ws2.Cells[1, 6 + jml].Worksheet.Column(6 + jml).Width = 10;
                for (int a = 7; a <= 9; a++)
                {
                    ws2.Cells[1, a + jml].Worksheet.Column(a + jml).Width = 15;
                }

                ws2.Cells[2, 2].Value = "Daily Monitoring";
                ws2.Cells[2, 2, 2, 9 + jml].Merge = true;
                ws2.Cells[2, 2].Style.Font.Size = 12;
                ws2.Cells[2, 2].Style.Font.Bold = true;
                ws2.Cells[2, 2, 2, 5 + jml].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[2, 2, 2, 5 + jml].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[4, 2].Value = "Cabang";
                ws2.Cells[4, 2, 4, 3].Merge = true;
                ws2.Cells[5, 2].Value = "Periode";
                ws2.Cells[5, 2, 5, 3].Merge = true;
                ws2.Cells[4, 4].Value = ": " + GlobalVar.Gudang;
                ws2.Cells[5, 4].Value = ": " + mon + " " + th;


                ws2.Cells[7, 2].Value = "No";
                ws2.Cells[7, 3].Value = "Monitored";
                ws2.Cells[7, 4].Value = "Target              " + mon + " " + th;
                ws2.Cells[7, 5].Value = "Actual              " + mon1 + " " + th2;
                ws2.Cells[7, 6].Value = "Actual Growth This Month";
                ws2.Cells[7, 6, 7, 5 + jml].Merge = true;
                for (int a = 1; a <= jml; a++)
                {

                    ws2.Cells[8, a + 5].Value = a + "/" + bln + "/" + th;
                }
                ws2.Cells[7, jml + 6].Value = "% Achv vs Target";
                ws2.Cells[7, jml + 7].Value = "Dev " + mon + " " + th + " vs Target";
                ws2.Cells[7, jml + 8].Value = "Act same date months ago";
                ws2.Cells[7, jml + 9].Value = "Dev Today vs months ago";

                for (int a = 6; a <= 9; a++)
                {
                    ws2.Cells[7, a + jml, 9, a + jml].Merge = true;
                }
                for (int a = 1; a < 5; a++)
                {
                    ws2.Cells[7, a + 1, 9, a + 1].Merge = true;
                }
                for (int a = 1; a <= jml; a++)
                {
                    ws2.Cells[8, a + 5, 9, a + 5].Merge = true;
                }
                ws2.Cells[7, 2, 9, jml + 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[7, 2, 9, jml + 9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[7, 2, 9, jml + 9].Style.Font.Bold = true;
                ws2.Cells[7, 2, 9, jml + 9].Style.WrapText = true;


                ws2.Cells[10, 2].Value = 1;
                ws2.Cells[11, 2].Value = 2;
                ws2.Cells[10, 3].Value = "Tagihan";
                ws2.Cells[11, 3].Value = "Overdue";
                //ws2.Cells[10, 4].Formula = "'PencapaianKolektor'!"+ws.Cells[iAwal, 5].Address;
                ws2.Cells[11, 4].Value = 0;

                for (int a = 0; a <= jml + 1; a++)
                {
                    ws2.Cells[10, a+4].Formula = "'PencapaianKolektor'!" + ws.Cells[iAwal, a+5].Address;
                }
                
                    ws2.Cells[10, jml + 8].Formula = "'PencapaianKolektor'!" + ws.Cells[iAwal, 9 + jml].Address;
               

                DataTable dtData2 = new DataTable();
                dtData2 = dt2.Copy();
                k = 5;
                foreach (DataRow dataRow in dt2.Rows)
                {
                    int m = 9;

                    foreach (var item in dataRow.ItemArray)
                    {
                        if (m > 10)
                        {
                            if (k < jml + 5)
                            {
                                if (Equals(item, null) || item.ToString() == "")
                                {
                                    ws2.Cells[m, k + 1].Value = 0;
                                }
                                else
                                {
                                    ws2.Cells[m, k + 1].Value = item;
                                }

                            }
                            else if (k == jml + 5)
                            {
                                if (Equals(item, null) || item.ToString() == "")
                                {
                                    ws2.Cells[m, jml + 8].Value = 0;
                                }
                                else
                                {
                                    ws2.Cells[m, jml + 8].Value = item;
                                }
                            }
                            else if (k == jml + 6)
                            {
                                if (Equals(item, null) || item.ToString() == "")
                                {
                                    ws2.Cells[m, 5].Value = 0;
                                }
                                else
                                {
                                    ws2.Cells[m, 5].Value = item;
                                }
                            }
                        }
                        m++;
                    }
                    k++;
                }

                for (int a = 10; a < 12; a++)
                {
                    ws2.Cells[a, jml + 6].Formula = "(" + ws2.Cells[a, jml + 5].Address +
                                "/" + ws2.Cells[a, 4].Address + ")";
                    ws2.Cells[a, jml + 7].Formula = "(" + ws2.Cells[a, jml + 5].Address +
                                "-" + ws2.Cells[a, 4].Address + ")";
                    ws2.Cells[a, jml + 9].Formula = "(" + ws2.Cells[a, jml + 5].Address +
                               "-" + ws2.Cells[a, jml + 8].Address + ")";
                }
                ws2.Cells[10, 2, 11, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[10, 2, 11, jml + 9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[10, 4, 11, jml + 5].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";
                ws2.Cells[10, jml + 6, 11, jml + 6].Style.Numberformat.Format = "0.00%";
                ws2.Cells[10, jml + 7, 11, jml + 9].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";

                var border2 = ws2.Cells[7, 2, 11, jml + 9].Style.Border;
                border2.Bottom.Style = ExcelBorderStyle.Thin;
                border2.Top.Style = ExcelBorderStyle.Thin;
                border2.Left.Style = ExcelBorderStyle.Thin;
                border2.Right.Style = ExcelBorderStyle.Thin;

                ws2.Cells[15, 2].Value = "Created by "+SecurityManager.UserName+" on " + GlobalVar.DateTimeOfServer;

                //

                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;

                try
                {
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                }
                catch
                {
                    MessageBox.Show("Silahkan tutup Laporan Pencapaian Kolektor.xlsx terlebih dahulu");
                }
            }
        } 

        public string ConvertBln(int i)
        {
            //string h="";
            string[] bulan = { "Desember", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            return "" + bulan[i];
        }

        private void btnREfresh_Click(object sender, EventArgs e)
        {
            DateTime iDate;
            iDate = dateTimePicker1.Value;
            string tgl = iDate.Day.ToString();
            string bln = iDate.Month.ToString();
            string th = iDate.Year.ToString();
            string fdate = th + "-" + bln + "-" + "01";
            string todate = th + "-" + bln + "-" + tgl;
            string tgln = tgl + "/" + bln + "/" + th;
            RefreshData(fdate, todate, tgl);
        }

        public void RefreshData( string fdate, string todate, string tgl)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();

                using (Database db = new Database("ISADBDepoBatchReport"))
                {
                    db.Commands.Add(db.CreateCommand("[psp_RefreshDataEvalusiColector]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, fdate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, todate));
                    db.Commands[0].Parameters.Add(new Parameter("@userid", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Refresh Data Sukses");
            }
            catch (System.Exception ex)
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

