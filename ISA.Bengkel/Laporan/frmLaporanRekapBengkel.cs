﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    public partial class frmLaporanRekapBengkel : ISA.Bengkel.BaseForm
    {
        public frmLaporanRekapBengkel()
        {
            InitializeComponent();
        }

        private void frmLaporanRekapBengkel_Load(object sender, EventArgs e)
        {
            rgbTglService.FromDate = DateTime.Now;
            rgbTglService.ToDate = DateTime.Now;
            rgbTglService.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_RekapServiceBengkel_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rgbTglService.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rgbTglService.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data tida ada.");
                        return;
                    }
                    DisplayReport(dt, rgbTglService.FromDate.Value, rgbTglService.ToDate.Value);
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
                exs.Add(RekapServiceBengkel(dt, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan BengkelPerbaikanInventaris_" + GlobalVar.Gudang + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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


        private ExcelPackage RekapServiceBengkel(DataTable dt, DateTime fromdate, DateTime todate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Bengkel";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Bengkel", "1147");

            ex.Workbook.Worksheets.Add("Laporan Bengkel");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.View.ShowGridLines = false;

            int MaxCol = 21;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 25;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 40;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 80;
            ws.Cells[1, 10].Worksheet.Column(10).Width = 20;
            ws.Cells[1, 11].Worksheet.Column(11).Width = 5;
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;
            ws.Cells[1, 13].Worksheet.Column(13).Width = 10;
            ws.Cells[1, 14].Worksheet.Column(14).Width = 15;
            ws.Cells[1, 15].Worksheet.Column(15).Width = 15;
            ws.Cells[1, 16].Worksheet.Column(16).Width = 15;
            ws.Cells[1, 17].Worksheet.Column(17).Width = 15;
            ws.Cells[1, 18].Worksheet.Column(18).Width = 15;
            ws.Cells[1, 19].Worksheet.Column(19).Width = 15;
            ws.Cells[1, 19].Worksheet.Column(20).Width = 15;
            ws.Cells[1, 19].Worksheet.Column(21).Width = 25;

            ws.Cells[1, 1].Value = "LAPORAN BENGKEL";
            ws.Cells[2, 1].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate);
            ws.Cells[3, 1].Value = "";
            ws.Cells[1, 1].Style.Font.Size = 14;
            ws.Cells[2, 1].Style.Font.Size = 11;
            ws.Cells[1, 1].Style.Font.Bold = true;

            ////#region Generate Header
            //ws.Cells[4, 1].Value = "NO."; ws.Cells[4, 1, 5, 1].Merge = true;
            //ws.Cells[4, 2].Value = "Tgl Servis"; ws.Cells[4, 2, 5, 2].Merge = true;
            //ws.Cells[4, 3].Value = "Nomor"; ws.Cells[4, 3, 5, 3].Merge = true;
            //ws.Cells[4, 4].Value = "No.Pol"; ws.Cells[4, 4, 5, 4].Merge = true;
            //ws.Cells[4, 5].Value = "Sepeda Motor"; ws.Cells[4, 5, 5, 5].Merge = true;
            //ws.Cells[4, 6].Value = "Mekanik"; ws.Cells[4, 6, 5, 6].Merge = true;
            //ws.Cells[4, 7].Value = "Service"; ws.Cells[4, 7, 5, 7].Merge = true;
            //ws.Cells[4, 8].Value = "Biaya"; ws.Cells[4, 8, 5, 8].Merge = true;
            //ws.Cells[4, 9].Value = "Sparepart"; ws.Cells[4, 9, 5, 9].Merge = true;
            //ws.Cells[4, 10].Value = "Kode Barang"; ws.Cells[4, 10, 5, 10].Merge = true;
            //ws.Cells[4, 11].Value = "Klp"; ws.Cells[4, 11, 5, 11].Merge = true;
            //ws.Cells[4, 12].Value = "Qty"; ws.Cells[4, 12, 5, 12].Merge = true;
            //ws.Cells[4, 13].Value = "Sat"; ws.Cells[4, 13, 5, 13].Merge = true;
            //ws.Cells[4, 14].Value = "Nominal (FA)"; ws.Cells[4, 14, 5, 14].Merge = true;
            //ws.Cells[4, 15].Value = "Nominal (FB)"; ws.Cells[4, 15, 5, 15].Merge = true;
            //ws.Cells[4, 16].Value = "Nominal (FC)"; ws.Cells[4, 16, 5, 16].Merge = true;
            //ws.Cells[4, 17].Value = "Nominal (FE)"; ws.Cells[4, 17, 5, 17].Merge = true;
            //ws.Cells[4, 18].Value = "Nominal (FX)"; ws.Cells[4, 18, 5, 18].Merge = true;
            //ws.Cells[4, 19].Value = "Lain-Lain"; ws.Cells[4, 19, 5, 19].Merge = true;
            //ws.Cells[4, 20].Value = "Beli Di Luar"; ws.Cells[4, 20, 5, 20].Merge = true;
            //ws.Cells[4, 21].Value = "Keterangan"; ws.Cells[4, 21, 5, 21].Merge = true;

            //ws.Cells[4, 1, 5, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[4, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //#region data
            //int idx = 6;
            //double TotBya = 0;
            //double TotalFA = 0;
            //double TotalFB = 0;
            //double TotalFC = 0;
            //double TotalFE = 0;
            //double TotalFX = 0;
            //double TotalLN = 0;
            //double TotalLuar = 0;
            //int num = 1;
            //string cNomor = "";
            //int nRec = 0, nJrec = Convert.ToInt32(Tools.isNull(ds.Tables[0].Rows.Count, "0").ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        nRec++;
            //        string cNmr = Tools.isNull(dr["nomor"], "").ToString().Trim();
            //        if (cNomor != cNmr)
            //        {
            //            string tglserv = ((DateTime)dr["tgl_srv"]).ToString("dd-MMM-yyyy");
            //            ws.Cells[idx, 1].Value = num;
            //            ws.Cells[idx, 2].Value = tglserv;
            //            ws.Cells[idx, 3].Value = dr["nomor"];
            //            ws.Cells[idx, 4].Value = dr["no_pol"];
            //            ws.Cells[idx, 5].Value = dr["spm"];
            //            ws.Cells[idx, 6].Value = dr["mekanik"];

            //            if (cNomor != "")
            //            {
            //                var border1 = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.None;
            //                border1.Top.Style = ExcelBorderStyle.Thin;
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.Thin;
            //            }
            //            cNomor = cNmr;
            //            num++;
            //        }

            //        ws.Cells[idx, 7].Value = dr["kategori"];
            //        ws.Cells[idx, 8].Value = dr["biaya"];
            //        ws.Cells[idx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[idx, 9].Value = dr["NamaStok"];
            //        ws.Cells[idx, 10].Value = dr["BarangID"];
            //        ws.Cells[idx, 11].Value = dr["Klp"];
            //        ws.Cells[idx, 12].Value = dr["QtySuratJalan"];
            //        ws.Cells[idx, 13].Value = dr["SatJual"];
            //        ws.Cells[idx, 14].Value = dr["nominalFA"];
            //        ws.Cells[idx, 15].Value = dr["nominalFB"];
            //        ws.Cells[idx, 16].Value = dr["nominalFC"];
            //        ws.Cells[idx, 17].Value = dr["nominalFE"];
            //        ws.Cells[idx, 18].Value = dr["nominalFX"];
            //        ws.Cells[idx, 19].Value = dr["lainlain"];
            //        ws.Cells[idx, 20].Value = dr["BeliDiLuar"];
            //        ws.Cells[idx, 21].Value = dr["keterangan"];
            //        ws.Cells[idx, 14, idx, 20].Style.Numberformat.Format = "#,##;(#,##);0";

            //        var border2 = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //        border2.Left.Style =
            //        border2.Right.Style = ExcelBorderStyle.Thin;

            //        double FA = Convert.ToDouble(Tools.isNull(dr["nominalFA"], 0));
            //        TotalFA = TotalFA + FA;
            //        double FB = Convert.ToDouble(Tools.isNull(dr["nominalFB"], 0));
            //        TotalFB = TotalFB + FB;
            //        double FC = Convert.ToDouble(Tools.isNull(dr["nominalFC"], 0));
            //        TotalFC = TotalFC + FC;
            //        double FE = Convert.ToDouble(Tools.isNull(dr["nominalFE"], 0));
            //        TotalFE = TotalFE + FE;
            //        double FX = Convert.ToDouble(Tools.isNull(dr["nominalFX"], 0));
            //        TotalFX = TotalFX + FX;
            //        double LN = Convert.ToDouble(Tools.isNull(dr["lainlain"], 0));
            //        TotalLN = TotalLN + LN;
            //        double Luar = Convert.ToDouble(Tools.isNull(dr["BeliDiLuar"], 0));
            //        TotalLuar = TotalLuar + Luar;
            //        Double Bya = Convert.ToDouble(Tools.isNull(dr["Biaya"], 0));
            //        TotBya = TotBya + Bya;
            //        idx++;
            //    }
            //}

            //ws.Cells[idx, 8].Value = TotBya;
            //ws.Cells[idx, 14].Value = TotalFA;
            //ws.Cells[idx, 15].Value = TotalFB;
            //ws.Cells[idx, 16].Value = TotalFC;
            //ws.Cells[idx, 17].Value = TotalFE;
            //ws.Cells[idx, 18].Value = TotalFX;
            //ws.Cells[idx, 19].Value = TotalLN;
            //ws.Cells[idx, 20].Value = TotalLuar;
            //ws.Cells[idx, 8, idx, 20].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[idx, 8, idx, 20].Style.Font.Color.SetColor(Color.Blue);
            //ws.Cells[idx, 8, idx, 20].Style.Font.Bold = true;

            //ws.Cells[4, 1, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[4, 1, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //var header = ws.Cells[4, 1, 5, MaxCol].Style.Border;
            //header.Bottom.Style =
            //header.Top.Style =
            //header.Left.Style =
            //header.Right.Style = ExcelBorderStyle.Thin;

            //if (nRec == nJrec)
            //{
            //    var borderbt = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style =
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.Thin;

            //    borderbt = ws.Cells[idx, 2, idx, 6].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style = ExcelBorderStyle.Thin;
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.None;

            //    borderbt = ws.Cells[idx, 9, idx, 13].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style = ExcelBorderStyle.Thin;
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.None;

            //    ws.Cells[idx, 7].Value = "Jumlah";
            //    ws.Cells[idx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    ws.Cells[idx, 7].Style.Font.Color.SetColor(Color.Red);
            //    ws.Cells[idx, 7].Style.Font.Bold = true;
            //}

            //#endregion


            ///*Laporan Bengkel Perbaikan Inventaris*/
            //ex.Workbook.Worksheets.Add("Perbaikan Inventaris");
            //ws = ex.Workbook.Worksheets[2];
            //ws.View.ShowGridLines = false;

            //int MaxColp = 21;

            //ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 10;
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            //ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            //ws.Cells[1, 6].Worksheet.Column(6).Width = 25;
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 40;
            //ws.Cells[1, 8].Worksheet.Column(8).Width = 10;
            //ws.Cells[1, 9].Worksheet.Column(9).Width = 80;
            //ws.Cells[1, 10].Worksheet.Column(10).Width = 20;
            //ws.Cells[1, 11].Worksheet.Column(11).Width = 5;
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 10;
            //ws.Cells[1, 13].Worksheet.Column(13).Width = 10;
            //ws.Cells[1, 14].Worksheet.Column(14).Width = 15;
            //ws.Cells[1, 15].Worksheet.Column(15).Width = 15;
            //ws.Cells[1, 16].Worksheet.Column(16).Width = 15;
            //ws.Cells[1, 17].Worksheet.Column(17).Width = 15;
            //ws.Cells[1, 18].Worksheet.Column(18).Width = 15;
            //ws.Cells[1, 19].Worksheet.Column(19).Width = 15;
            //ws.Cells[1, 19].Worksheet.Column(20).Width = 15;
            //ws.Cells[1, 19].Worksheet.Column(21).Width = 25;

            //ws.Cells[1, 1].Value = "LAPORAN BENGKEL";
            //ws.Cells[2, 1].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate);
            //ws.Cells[3, 1].Value = "Perbaikan Inventaris";
            //ws.Cells[1, 1].Style.Font.Size = 14;
            //ws.Cells[2, 1].Style.Font.Size = 11;
            //ws.Cells[3, 1].Style.Font.Color.SetColor(Color.Red);
            //ws.Cells[1, 1].Style.Font.Bold = true;
            //ws.Cells[3, 1].Style.Font.Bold = true;

            //ws.Cells[5, 1].Value = "NO."; ws.Cells[5, 1, 6, 1].Merge = true;
            //ws.Cells[5, 2].Value = "Tgl Servis"; ws.Cells[5, 2, 6, 2].Merge = true;
            //ws.Cells[5, 3].Value = "Nomor"; ws.Cells[5, 3, 6, 3].Merge = true;
            //ws.Cells[5, 4].Value = "No.Pol"; ws.Cells[5, 4, 6, 4].Merge = true;
            //ws.Cells[5, 5].Value = "Sepeda Motor"; ws.Cells[5, 5, 6, 5].Merge = true;
            //ws.Cells[5, 6].Value = "Mekanik"; ws.Cells[5, 6, 6, 6].Merge = true;
            //ws.Cells[5, 7].Value = "Service"; ws.Cells[5, 7, 6, 7].Merge = true;
            //ws.Cells[5, 8].Value = "Biaya"; ws.Cells[5, 8, 6, 8].Merge = true;
            //ws.Cells[5, 9].Value = "Sparepart"; ws.Cells[5, 9, 6, 9].Merge = true;
            //ws.Cells[5, 10].Value = "Kode Barang"; ws.Cells[5, 10, 6, 10].Merge = true;
            //ws.Cells[5, 11].Value = "Klp"; ws.Cells[5, 11, 6, 11].Merge = true;
            //ws.Cells[5, 12].Value = "Qty"; ws.Cells[5, 12, 6, 12].Merge = true;
            //ws.Cells[5, 13].Value = "Sat"; ws.Cells[5, 13, 6, 13].Merge = true;
            //ws.Cells[5, 14].Value = "Nominal (FA)"; ws.Cells[5, 14, 6, 14].Merge = true;
            //ws.Cells[5, 15].Value = "Nominal (FB)"; ws.Cells[5, 15, 6, 15].Merge = true;
            //ws.Cells[5, 16].Value = "Nominal (FC)"; ws.Cells[5, 16, 6, 16].Merge = true;
            //ws.Cells[5, 17].Value = "Nominal (FE)"; ws.Cells[5, 17, 6, 17].Merge = true;
            //ws.Cells[5, 18].Value = "Nominal (FX)"; ws.Cells[5, 18, 6, 18].Merge = true;
            //ws.Cells[5, 19].Value = "Lain-Lain"; ws.Cells[5, 19, 6, 19].Merge = true;
            //ws.Cells[5, 20].Value = "Beli Di Luar"; ws.Cells[5, 20, 6, 20].Merge = true;
            //ws.Cells[5, 21].Value = "Keterangan"; ws.Cells[5, 21, 6, 21].Merge = true;

            //ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //#region data
            //idx = 7;
            //TotBya = 0;
            //TotalFA = 0;
            //TotalFB = 0;
            //TotalFC = 0;
            //TotalFE = 0;
            //TotalFX = 0;
            //TotalLN = 0;
            //TotalLuar = 0;
            //num = 1;
            //cNomor = "";
            //nRec = 0;
            //nJrec = Convert.ToInt32(Tools.isNull(ds.Tables[1].Rows.Count, "0").ToString());

            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[1].Rows)
            //    {
            //        nRec++;
            //        string cNmr = Tools.isNull(dr["nomor"], "").ToString().Trim();
            //        if (cNomor != cNmr)
            //        {
            //            string tglserv = ((DateTime)dr["tgl_srv"]).ToString("dd-MMM-yyyy");
            //            ws.Cells[idx, 1].Value = num;
            //            ws.Cells[idx, 2].Value = tglserv;
            //            ws.Cells[idx, 3].Value = dr["nomor"];
            //            ws.Cells[idx, 4].Value = dr["no_pol"];
            //            ws.Cells[idx, 5].Value = dr["spm"];
            //            ws.Cells[idx, 6].Value = dr["mekanik"];

            //            if (cNomor != "")
            //            {
            //                var border1 = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //                border1.Bottom.Style = ExcelBorderStyle.None;
            //                border1.Top.Style = ExcelBorderStyle.Thin;
            //                border1.Left.Style =
            //                border1.Right.Style = ExcelBorderStyle.Thin;
            //            }
            //            cNomor = cNmr;
            //            num++;
            //        }

            //        ws.Cells[idx, 7].Value = dr["kategori"];
            //        ws.Cells[idx, 8].Value = dr["biaya"];
            //        ws.Cells[idx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //        ws.Cells[idx, 9].Value = dr["NamaStok"];
            //        ws.Cells[idx, 10].Value = dr["BarangID"];
            //        ws.Cells[idx, 11].Value = dr["Klp"];
            //        ws.Cells[idx, 12].Value = dr["QtySuratJalan"];
            //        ws.Cells[idx, 13].Value = dr["SatJual"];
            //        ws.Cells[idx, 14].Value = dr["nominalFA"];
            //        ws.Cells[idx, 15].Value = dr["nominalFB"];
            //        ws.Cells[idx, 16].Value = dr["nominalFC"];
            //        ws.Cells[idx, 17].Value = dr["nominalFE"];
            //        ws.Cells[idx, 18].Value = dr["nominalFX"];
            //        ws.Cells[idx, 19].Value = dr["lainlain"];
            //        ws.Cells[idx, 20].Value = dr["BeliDiLuar"];
            //        ws.Cells[idx, 21].Value = dr["keterangan"];
            //        ws.Cells[idx, 14, idx, 20].Style.Numberformat.Format = "#,##;(#,##);0";

            //        var border2 = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //        border2.Left.Style =
            //        border2.Right.Style = ExcelBorderStyle.Thin;

            //        double FA = Convert.ToDouble(Tools.isNull(dr["nominalFA"], 0));
            //        TotalFA = TotalFA + FA;
            //        double FB = Convert.ToDouble(Tools.isNull(dr["nominalFB"], 0));
            //        TotalFB = TotalFB + FB;
            //        double FC = Convert.ToDouble(Tools.isNull(dr["nominalFC"], 0));
            //        TotalFC = TotalFC + FC;
            //        double FE = Convert.ToDouble(Tools.isNull(dr["nominalFE"], 0));
            //        TotalFE = TotalFE + FE;
            //        double FX = Convert.ToDouble(Tools.isNull(dr["nominalFX"], 0));
            //        TotalFX = TotalFX + FX;
            //        double LN = Convert.ToDouble(Tools.isNull(dr["lainlain"], 0));
            //        TotalLN = TotalLN + LN;
            //        double Luar = Convert.ToDouble(Tools.isNull(dr["BeliDiLuar"], 0));
            //        TotalLuar = TotalLuar + Luar;
            //        Double Bya = Convert.ToDouble(Tools.isNull(dr["Biaya"], 0));
            //        TotBya = TotBya + Bya;
            //        idx++;
            //    }
            //}
            //ws.Cells[idx, 8].Value = TotBya;
            //ws.Cells[idx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[idx, 14].Value = TotalFA;
            //ws.Cells[idx, 15].Value = TotalFB;
            //ws.Cells[idx, 16].Value = TotalFC;
            //ws.Cells[idx, 17].Value = TotalFE;
            //ws.Cells[idx, 18].Value = TotalFX;
            //ws.Cells[idx, 19].Value = TotalLN;
            //ws.Cells[idx, 20].Value = TotalLuar;
            //ws.Cells[idx, 14, idx, 20].Style.Numberformat.Format = "#,##;(#,##);0";

            //ws.Cells[idx, 8, idx, 20].Style.Font.Color.SetColor(Color.Blue);
            //ws.Cells[idx, 8, idx, 20].Style.Font.Bold = true;

            //ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            //var header2 = ws.Cells[5, 1, 6, MaxCol].Style.Border;
            //header2.Bottom.Style =
            //header2.Top.Style =
            //header2.Left.Style =
            //header2.Right.Style = ExcelBorderStyle.Thin;

            //if (nRec == nJrec)
            //{
            //    var borderbt = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style =
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.Thin;

            //    borderbt = ws.Cells[idx, 2, idx, 6].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style = ExcelBorderStyle.Thin;
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.None;

            //    borderbt = ws.Cells[idx, 9, idx, 13].Style.Border;
            //    borderbt.Bottom.Style =
            //    borderbt.Top.Style = ExcelBorderStyle.Thin;
            //    borderbt.Left.Style =
            //    borderbt.Right.Style = ExcelBorderStyle.None;

            //    ws.Cells[idx, 7].Value = "Jumlah";
            //    ws.Cells[idx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    ws.Cells[idx, 7].Style.Font.Color.SetColor(Color.Red);
            //    ws.Cells[idx, 7].Style.Font.Bold = true;
            //}

            //#endregion

            return ex;
        }

    }
}