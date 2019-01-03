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
using System.IO;
using ISA.Trading.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Trading.ArusStock
    {
    public partial class frmRptAntarGudangBelumDiterima : ISA.Trading.BaseForm
        {
        public frmRptAntarGudangBelumDiterima()
            {
            InitializeComponent();
            }

        private void cmdClose_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (rdbNota.Checked == true)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("rsp_AntarGudangBelumDiterima_PerNota"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                        //if (!string.IsNullOrEmpty(lookupGudang.GudangID))
                        //{
                        //    db.Commands[0].Parameters.Add(new Parameter("@DrGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                        //}
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Tidak Ada Data");
                            return;
                        }
                        DateTime fromDate = Convert.ToDateTime(rangeDateBox1.FromDate.ToString());
                        DateTime toDate = Convert.ToDateTime(rangeDateBox1.ToDate.ToString());
                        DisplayReportToExcell(dt, fromDate, toDate, "Nota");

                        //DisplayReport(dt);
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

            if (rdbBarang.Checked == true)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("rsp_AntarGudangBelumDiterima_PerBarang"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                        //if (!string.IsNullOrEmpty(lookupGudang.GudangID))
                        //{
                        //    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, lookupGudang.GudangID));
                        //}


                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Tidak Ada Data");
                            return;
                        }

                        DateTime fromDate = Convert.ToDateTime(rangeDateBox1.FromDate.ToString());
                        DateTime toDate = Convert.ToDateTime(rangeDateBox1.ToDate.ToString());

                        //DisplayReport(dt);
                        DisplayReportToExcell(dt, fromDate, toDate, "Barang");
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

        private void frmRptAntarGudangBelumDiterima_Load(object sender, EventArgs e)
        {
        rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        rangeDateBox1.ToDate=DateTime.Now;
        lookupGudang.GudangID="";
        }

        private void DisplayReport(DataTable dt)
            {

            ////construct parameter
            //string periode;
            //periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //List<ReportParameter> rptParams=new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport=new frmReportViewer("ArusStock.rptAntarGudangBelumDiterimaPerBarang.rdlc", rptParams, dt, "dsAntarGudang_Data");
            //ifrmReport.Show();

            }

        private void DisplayReportToExcell(DataTable dt,DateTime fromDate,DateTime toDate, string Model)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            if (Model == "Nota")
                exs.Add(LaporanGitNota(dt,fromDate,toDate));
            else
                exs.Add(LaporanGitBarang(dt, fromDate, toDate));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "rpt_AgBelumTerima";

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


        private ExcelPackage LaporanGitNota(DataTable dt,DateTime fromDate,DateTime toDate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan AG belum terima per Nota";
            ex.Workbook.Properties.SetCustomPropertyValue("GIT", "1147");

            ex.Workbook.Worksheets.Add("GIT");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //noag
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglkirim
            ws.Cells[1, 5].Worksheet.Column(5).Width = 7;       //drgud
            ws.Cells[1, 6].Worksheet.Column(6).Width = 7;       //kegud
            ws.Cells[1, 7].Worksheet.Column(7).Width = 14;      //JumlahAG

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 1].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 1].Value = "Laporan Barang Belum Diterima";
            ws.Cells[nHeader, 1].Style.Font.Size = 14;
            ws.Cells[nHeader, 1].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

            int MaxCol = 7;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No AG ";
            ws.Cells[Rowx, 4].Value = " Tgl Kirim ";
            ws.Cells[Rowx, 5].Value = " Dr Gud ";
            ws.Cells[Rowx, 6].Value = " Ke Gud ";
            ws.Cells[Rowx, 7].Value = " Jumlah AG";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoAG"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglKirim"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["DrGudang"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["KeGudang"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Convert.ToDouble(Tools.isNull(dr1["JumlahAG"], "0").ToString());
                    ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    nSaldo += (Convert.ToDouble(Tools.isNull(dr1["JumlahAG"], "0").ToString()));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 6].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 7].Value = Tools.isNull(nSaldo, 0);
                ws.Cells[Rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 7].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
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

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            return ex;
        }


        private ExcelPackage LaporanGitBarang(DataTable dt, DateTime fromDate, DateTime toDate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan AG belum terima";
            ex.Workbook.Properties.SetCustomPropertyValue("GIT", "1147");

            ex.Workbook.Worksheets.Add("GIT");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //noag
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglkirim
            ws.Cells[1, 5].Worksheet.Column(5).Width = 7;       //drgud
            ws.Cells[1, 6].Worksheet.Column(6).Width = 7;       //kegud
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;      //kodebarang
            ws.Cells[1, 8].Worksheet.Column(8).Width = 73;      //namastok
            ws.Cells[1, 9].Worksheet.Column(9).Width = 6;       //satuan
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //qtykirim
            ws.Cells[1, 11].Worksheet.Column(11).Width = 14;    //hppa
            ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //jmlah

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Barang Belum Diterima";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

            int MaxCol = 12;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No AG ";
            ws.Cells[Rowx, 4].Value = " Tgl Kirim ";
            ws.Cells[Rowx, 5].Value = " Dr Gud ";
            ws.Cells[Rowx, 6].Value = " Ke Gud ";
            ws.Cells[Rowx, 7].Value = " Kode Barang ";
            ws.Cells[Rowx, 8].Value = " Nama Stok ";
            ws.Cells[Rowx, 9].Value = " Sat ";
            ws.Cells[Rowx, 10].Value = " Qty Kirim ";
            ws.Cells[Rowx, 11].Value = " Hppa ";
            ws.Cells[Rowx, 12].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoAG"], "").ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglKirim"], ""));
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["DrGudang"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["KeGudang"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["KodeBarang"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Satuan"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString()) *
                                               Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";

                    nQty += Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    nSaldo += (Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString()) *
                              Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString()));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 8].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 10].Value = Tools.isNull(nQty, 0);
                ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 10].Style.Font.Bold = true;

                ws.Cells[Rowx, 12].Value = Tools.isNull(nSaldo, 0);
                ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 12].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
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

                border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
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


        private void DisplayReport2(DataTable dt)
            {

            ////construct parameter
            //string periode;
            //periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //List<ReportParameter> rptParams=new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //if (lookupGudang.GudangID!="")
            //{
            //rptParams.Add(new ReportParameter("Pengirim", lookupGudang.GudangID));
            //}
            //else
            //    {
            //    rptParams.Add(new ReportParameter("Pengirim","Semua"));
            //    }
            

            ////call report viewer
            //frmReportViewer ifrmReport=new frmReportViewer("ArusStock.rptAntarGudangBelumDiTerimaPerNota.rdlc", rptParams, dt, "dsAntarGudang_Data");
            //ifrmReport.Show();

            }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if(e.KeyChar==13)
                {
                cmdYes.PerformClick();
                }
            }

        private void lookupGudang_Leave(object sender, EventArgs e)
            {
            if (lookupGudang.NamaGudang=="")
            {
            lookupGudang.GudangID="";
            }
            }
        
        }
    } 
