using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlTypes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
 

namespace ISA.Finance.Piutang.Report
{
    public partial class frmTokoAktif : ISA.Controls.BaseForm
    {
        DataSet dsT = new DataSet();// Template DS
        DataTable dtT = new DataTable(); //List All Toko
        DataTable dtV = new DataTable(); //List Toko YG valid
        DataSet dsTV = new DataSet();// Nilai Transaksi Nota yg Valid
        DataSet dsPV = new DataSet();// Nilai Transaksi Piutang yg Valid
        DataTable dtKLP = new DataTable();// List KLP
        int LCol = 4;
        int HCol = 7;

#region Procedure
        private void FillToko()
        {
           
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetToko]"));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text.Trim())); 
                dtT = db.Commands[0].ExecuteDataTable();
            }

            if (dtT.Rows.Count==0)
            {
                throw new Exception("Tidak Ada Data");
            }
            progressBar1.Value = 0;
            progressBar1.Maximum = dtT.Rows.Count;
        }

        private bool NotValid()
        {
            bool valid = false;
            ErrorProvider err = new ErrorProvider();

            if (monthYearBox2.Year != monthYearBox1.Year)
            {
                err.SetError(monthYearBox1, "Harus dalam tahun yang sama");
                err.SetError(monthYearBox2, "Harus dalam tahun yang sama");
                valid = true;
            }

            if (monthYearBox2.Month < monthYearBox1.Month   )
            {
                err.SetError(monthYearBox1, "Harus lebih kecil dari periode 2  ");
                err.SetError(monthYearBox2, "Harus lebih besar dari periode 1  ");
                valid = true;
            }

            return valid;
        }

        private DataTable GetNota(string KodeToko_, DateTime FromDate, DateTime ToDate,string KodeSales, string KodeGudang , string cabang,out bool Pass_)
        {
            DataTable dt = new DataTable();
            bool p = true;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetNota]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KodeSales));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, KodeGudang));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabang));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count==0)
            {
                p = false;
            }else
            {
               Double Nominal = Convert.ToDouble(dt.Compute("SUM(RpOmset)", string.Empty))/(ToDate.Month-FromDate.Month+1);
               Nominal = Math.Round(Nominal, 0);
               if (cboRat.Checked && (Nominal<txtNominal1.GetDoubleValue || Nominal>txtNominal2.GetDoubleValue))
               {
                   p = false;
               }
            }
            Pass_ = p;
            return dt;
        }

        private DataTable GetPiutang(string KodeToko_, DateTime ToDate, string KodeSales)
        {
            DataTable dt = new DataTable();
           
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetPiutang]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KodeSales));
                dt = db.Commands[0].ExecuteDataTable();
            }
            
           
            return dt;
        }

        private ExcelPackage Proses()
        {
#region "Var Excell"
            bool C = false;
            DateTime FromDate = monthYearBox1.FirstDateOfMonth;
            DateTime ToDate = monthYearBox2.LastDateOfMonth;
            string KodeSales = lookupSales1.SalesID;
            string Kodegudang = lookupGudang1.GudangID;
            string cabang = cabangComboBox1.CabangID;
            int Month = 0;
            int ic = 0;
            DataTable dt = new DataTable();
            DataTable dp = new DataTable();
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Laporan Toko Aktif";
            List<ExcelWorksheet> ws = new List<ExcelWorksheet>();
            
#endregion

#region "Generate Header & Sheet"
            ic = 1;
            for (int x = FromDate.Month; x <= ToDate.Month; x++)
            {
                DateTime Tgl = new DateTime(FromDate.Year, x, 1);
                ex.Workbook.Worksheets.Add(Tgl.ToString("MMMM yyyy"));
                ws.Add(ex.Workbook.Worksheets[ic]);
                ic++;
            }
            Month = ws.Count;
            ic = 0;
            for (int x = FromDate.Month; x <= ToDate.Month; x++)
            {
                DateTime Tgl = new DateTime(FromDate.Year, x, 1);
                ws[ic].Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws[ic].Cells.Style.Font.Name = "Arial";

                // Width

                ws[ic].Cells[1, 1].Worksheet.Column(1).Width = 72;
                ws[ic].Cells[1, 2].Worksheet.Column(2).Width = 9;
                ws[ic].Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws[ic].Cells[1, 4].Worksheet.Column(4).Width = 35;
                
                for (int i = 5; i <= 24; i++ )
                {
                    ws[ic].Cells[1, i].Worksheet.Column(i).Width = 13;
                }

                //Tiitle
                ws[ic].Cells[1, 1].Value = "Laporan     : Toko Aktif";
                ws[ic].Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws[ic].Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws[ic].Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  "+lookupSales1.NamaSales ;
                ws[ic].Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws[ic].Cells[1, 1, 1, 4].Merge = true; 
                ws[ic].Cells[2, 1, 2, 4].Merge = true;
                ws[ic].Cells[3, 1, 3, 4].Merge = true;
                ws[ic].Cells[4, 1, 4, 4].Merge = true;
                ws[ic].Cells[5, 1, 5, 4].Merge = true;

                ws[ic].Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws[ic].Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                ws[ic].Cells[8, 1].Value = "Nama Toko"; ws[ic].Cells[8, 1, 10, 1].Merge = true;
                ws[ic].Cells[8, 2].Value = "WilID"; ws[ic].Cells[8, 2, 10, 2].Merge = true;
                ws[ic].Cells[8, 3].Value = "KOTA"; ws[ic].Cells[8, 3, 10, 3].Merge = true;
                ws[ic].Cells[8, 4].Value = "DAERAH"; ws[ic].Cells[8, 4, 10, 4].Merge = true; 
                ws[ic].Cells[8, 5].Value = Tgl.ToString("MMMM yyyy"); ws[ic].Cells[8, 5, 8, 24].Merge = true;


                ws[ic].Cells[9, 5].Value  = "FB2";    ws[ic].Cells[9, 5, 9, 8].Merge = true;
                ws[ic].Cells[9, 9].Value  = "FB4";    ws[ic].Cells[9, 9, 9, 12].Merge = true;
                ws[ic].Cells[9, 13].Value = "FE2";    ws[ic].Cells[9, 13, 9, 16].Merge = true;
                ws[ic].Cells[9, 17].Value = "FE4";    ws[ic].Cells[9, 17, 9, 20].Merge = true;
                ws[ic].Cells[9, 21].Value  = "Lainya";ws[ic].Cells[9, 21, 9, 24].Merge = true;


                for (int i = 5; i <= 24; i+=4)
                {
                    ws[ic].Cells[10,   i].Value = "OMSET";
                    ws[ic].Cells[10, i + 1].Value = "HPP";
                    ws[ic].Cells[10, i + 2].Value = "LABA RP";
                    ws[ic].Cells[10, i + 3].Value = "LABA %";
                }

                ws[ic].Cells[8, 1, 10, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws[ic].Cells[8, 1, 10, 24].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ic++;
            }
#endregion

#region "Fill Detail"
            ic = 0;
            int idx = 11;

#region Monthly
            foreach (DataRow dr in dtT.Rows)
            {
                Application.DoEvents();
                this.Invalidate();
                txtNamaToko.Text = dr["NamaToko"].ToString();
                ic++;
                progressBar1.Value = ic;
                dt = GetNota(dr["KodeToko"].ToString(), FromDate, ToDate, KodeSales, Kodegudang, cabang, out C);

                if (!C)
                {
                    continue;
                }
                DataRow dr1 = dtV.NewRow();
                dr1["NamaToko"] = dr["NamaToko"].ToString().Trim();
                dr1["WilID"] = dr["WilID"].ToString().Trim();
                dr1["Kota"] = dr["Kota"].ToString().Trim();
                dr1["Daerah"] = dr["Daerah"].ToString().Trim();
                dr1["KodeToko"] = dr["KodeToko"].ToString().Trim();
                dtV.Rows.Add(dr1);
                dsTV.Tables.Add(dt);
                dsTV.Tables[dsTV.Tables.Count - 1].TableName = dr["KodeToko"].ToString();

                dp = GetPiutang(dr["KodeToko"].ToString(), ToDate, KodeSales);
                dsPV.Tables.Add(dp);
                dsPV.Tables[dsPV.Tables.Count - 1].TableName = dr["KodeToko"].ToString();

                int m = FromDate.Month;
                for (int x = FromDate.Month; x <= ToDate.Month; x++)
                {
                    ws[x - m].Cells[idx, 1].Value = dr["NamaToko"].ToString();
                    ws[x - m].Cells[idx, 2].Value = dr["WilID"].ToString();
                    ws[x - m].Cells[idx, 3].Value = dr["Kota"].ToString();
                    ws[x - m].Cells[idx, 4].Value = dr["Daerah"].ToString();
                    dt.DefaultView.RowFilter = "Bulan=" + x.ToString() + "";

                    foreach (DataRowView dv in dt.DefaultView)
                    {
                        if (GetIdx(dv["KLP"].ToString()) > 0)
                        {
                            ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                            ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                            ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                        }
                    }
                    double RpOmset = 0;
                    double RpLaba = 0;
                    for (int i = 8; i <= 24; i += 4)
                    {
                        RpOmset = Convert.ToDouble(ws[x - m].Cells[idx, i - 3].Value);
                        RpLaba = Convert.ToDouble(ws[x - m].Cells[idx, i - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws[x - m].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                }

                idx++;
            }
            if (dtV.Rows.Count==0)
            {
                throw new Exception("Tidak Ada Data");
            }
#endregion

#region Total;
            //total = Month + 1
            int var1 = Month;
            ex.Workbook.Worksheets.Add("Total");
            ws.Add(ex.Workbook.Worksheets[Month + 1]);

            ws[var1].Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws[var1].Cells.Style.Font.Name = "Arial";

            // Width

            ws[var1].Cells[1, 1].Worksheet.Column(1).Width = 72;
            ws[var1].Cells[1, 2].Worksheet.Column(2).Width = 9;
            ws[var1].Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws[var1].Cells[1, 4].Worksheet.Column(4).Width = 20;

            for (int i = 5; i <= 24; i++)
            {
                ws[var1].Cells[1, i].Worksheet.Column(i).Width = 13;
            }
            ws[var1].Cells[8, 1].Value = "Nama Toko"; ws[var1].Cells[8, 1, 10, 1].Merge = true;
            ws[var1].Cells[8, 2].Value = "WilID"; ws[var1].Cells[8, 2, 10, 2].Merge = true;
            ws[var1].Cells[8, 3].Value = "KOTA"; ws[var1].Cells[8, 3, 10, 3].Merge = true;
            ws[var1].Cells[8, 4].Value = "DAERAH"; ws[var1].Cells[8, 4, 10, 4].Merge = true;
            ws[var1].Cells[8, 5].Value = monthYearBox1.FirstDateOfMonth.ToString("MMMM yyyy") + "S/D" +
                                           monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                        ; 
            ws[var1].Cells[8, 5, 8, 24].Merge = true;


            ws[var1].Cells[9, 5].Value = "FB2"; ws[var1].Cells[9, 5, 9, 8].Merge = true;
            ws[var1].Cells[9, 9].Value = "FB4"; ws[var1].Cells[9, 9, 9, 12].Merge = true;
            ws[var1].Cells[9, 13].Value = "FE2"; ws[var1].Cells[9, 13, 9, 16].Merge = true;
            ws[var1].Cells[9, 17].Value = "FE4"; ws[var1].Cells[9, 17, 9, 20].Merge = true;
            ws[var1].Cells[9, 21].Value = "Lainya"; ws[var1].Cells[9, 21, 9, 24].Merge = true;


            for (int i = 5; i <= 24; i += 4)
            {
                ws[var1].Cells[10, i].Value = "OMSET";
                ws[var1].Cells[10, i + 1].Value = "HPP";
                ws[var1].Cells[10, i + 2].Value = "LABA RP";
                ws[var1].Cells[10, i + 3].Value = "LABA %";
            }

            ws[var1].Cells[8, 1, 10, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws[var1].Cells[8, 1, 10, 24].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //isi Total
            idx = 11;
            foreach (DataRow dr in dtV.Rows)
            {
                ws[var1].Cells[idx, 1].Value = dr["NamaToko"].ToString();
                ws[var1].Cells[idx, 2].Value = dr["WilID"].ToString();
                ws[var1].Cells[idx, 3].Value = dr["Kota"].ToString();
                ws[var1].Cells[idx, 4].Value = dr["Daerah"].ToString();

                dsTV.Tables[dr["KodeToko"].ToString()].DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"].ToString() + "'";

                foreach (DataRowView dv in dsTV.Tables[dr["KodeToko"].ToString()].DefaultView)
                {
                    if (GetIdx(dv["KLP"].ToString()) > 0)
                    {
                        ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                            Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                        ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                            Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                        ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                            Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                    }
                }

                double RpOmset = 0;
                double RpLaba = 0;
                for (int i = 8; i <= 24; i += 4)
                {
                    RpOmset = Convert.ToDouble(ws[var1].Cells[idx, i - 3].Value);
                    RpLaba = Convert.ToDouble(ws[var1].Cells[idx, i - 1].Value);
                    if (RpOmset != 0 && RpLaba != 0)
                    {
                        ws[var1].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                    }

                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                idx++;
            }

#endregion

#region "Average"
            int var2 = Month+1;
            ex.Workbook.Worksheets.Add("Rata-rata");
            ws.Add(ex.Workbook.Worksheets[Month + 2]);

            ws[var2].Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws[var2].Cells.Style.Font.Name = "Arial";

            // Width

            ws[var2].Cells[1, 1].Worksheet.Column(1).Width = 72;
            ws[var2].Cells[1, 2].Worksheet.Column(2).Width = 9;
            ws[var2].Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws[var2].Cells[1, 4].Worksheet.Column(4).Width = 20;

            for (int i = 5; i <= 24; i++)
            {
                ws[var2].Cells[1, i].Worksheet.Column(i).Width = 13;
            }
            ws[var2].Cells[8, 1].Value = "Nama Toko"; ws[var2].Cells[8, 1, 10, 1].Merge = true;
            ws[var2].Cells[8, 2].Value = "WilID"; ws[var2].Cells[8, 2, 10, 2].Merge = true;
            ws[var2].Cells[8, 3].Value = "KOTA"; ws[var2].Cells[8, 3, 10, 3].Merge = true;
            ws[var2].Cells[8, 4].Value = "DAERAH"; ws[var2].Cells[8, 4, 10, 4].Merge = true;
            ws[var2].Cells[8, 5].Value = monthYearBox1.FirstDateOfMonth.ToString("MMMM yyyy") + "S/D" +
                                           monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                        ;
            ws[var2].Cells[8, 5, 8, 24].Merge = true;


            ws[var2].Cells[9, 5].Value = "FB2"; ws[var2].Cells[9, 5, 9, 8].Merge = true;
            ws[var2].Cells[9, 9].Value = "FB4"; ws[var2].Cells[9, 9, 9, 12].Merge = true;
            ws[var2].Cells[9, 13].Value = "FE2"; ws[var2].Cells[9, 13, 9, 16].Merge = true;
            ws[var2].Cells[9, 17].Value = "FE4"; ws[var2].Cells[9, 17, 9, 20].Merge = true;
            ws[var2].Cells[9, 21].Value = "Lainya"; ws[var2].Cells[9, 21, 9, 24].Merge = true;


            for (int i = 5; i <= 24; i += 4)
            {
                ws[var2].Cells[10, i].Value = "OMSET";
                ws[var2].Cells[10, i + 1].Value = "HPP";
                ws[var2].Cells[10, i + 2].Value = "LABA RP";
                ws[var2].Cells[10, i + 3].Value = "LABA %";
            }

            ws[var2].Cells[8, 1, 10, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws[var2].Cells[8, 1, 10, 24].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //isi Total
            idx = 11;
            foreach (DataRow dr in dtV.Rows)
            {
                ws[var2].Cells[idx, 1].Value = dr["NamaToko"].ToString();
                ws[var2].Cells[idx, 2].Value = dr["WilID"].ToString();
                ws[var2].Cells[idx, 3].Value = dr["Kota"].ToString();
                ws[var2].Cells[idx, 4].Value = dr["Daerah"].ToString();

                dsTV.Tables[dr["KodeToko"].ToString()].DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"].ToString() + "'";

                foreach (DataRowView dv in dsTV.Tables[dr["KodeToko"].ToString()].DefaultView)
                {
                    if (GetIdx(dv["KLP"].ToString()) > 0)
                    {
                        ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                            Convert.ToDouble(ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                        ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                            Convert.ToDouble(ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                        ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                            Convert.ToDouble(ws[var2].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                    }
                }

                double RpOmset = 0;
                double RpLaba = 0;
                for (int i = 8; i <= 24; i += 4)
                {
                    ws[var2].Cells[idx, i - 3].Value = Math.Round(Convert.ToDouble(ws[var2].Cells[idx, i - 3].Value) / Month,0);
                    ws[var2].Cells[idx, i - 2].Value = Math.Round(Convert.ToDouble(ws[var2].Cells[idx, i - 2].Value) / Month,0);
                    ws[var2].Cells[idx, i - 1].Value = Math.Round(Convert.ToDouble(ws[var2].Cells[idx, i - 1].Value) / Month, 0);
                    RpOmset = Convert.ToDouble(ws[var2].Cells[idx, i - 3].Value);
                    RpLaba = Convert.ToDouble(ws[var2].Cells[idx, i - 1].Value);
                    if (RpOmset != 0 && RpLaba != 0)
                    {
                        ws[var2].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                    }

                    ws[var2].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws[var2].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws[var2].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                idx++;
            }
#endregion

#region Piutang
            var2 = Month + 2;
            ex.Workbook.Worksheets.Add("Piutang "+ToDate.ToString("MMMM yyyy"));
            ws.Add(ex.Workbook.Worksheets[Month + 3]);

            ws[var2].Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws[var2].Cells.Style.Font.Name = "Arial";

            // Width

            ws[var2].Cells[1, 1].Worksheet.Column(1).Width = 72;
            ws[var2].Cells[1, 2].Worksheet.Column(2).Width = 9;
            ws[var2].Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws[var2].Cells[1, 4].Worksheet.Column(4).Width = 20;

            for (int i = 5; i <= 8; i++)
            {
                ws[var2].Cells[1, i].Worksheet.Column(i).Width = 13;
            }
            ws[var2].Cells[9, 1].Value = "Nama Toko"; ws[var2].Cells[9, 1, 10, 1].Merge = true;
            ws[var2].Cells[9, 2].Value = "WilID"; ws[var2].Cells[9, 2, 10, 2].Merge = true;
            ws[var2].Cells[9, 3].Value = "KOTA"; ws[var2].Cells[9, 3, 10, 3].Merge = true;
            ws[var2].Cells[9, 4].Value = "DAERAH"; ws[var2].Cells[9, 4, 10, 4].Merge = true;
            ws[var2].Cells[9, 5].Value = "Umur Piutang " +
                                           monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                        ;
            ws[var2].Cells[9, 5, 9, 8].Merge = true;


            ws[var2].Cells[10, 5].Value = "<90 HARI";
            ws[var2].Cells[10, 6].Value = "91 -120 HARI";
            ws[var2].Cells[10, 7].Value = ">121 HARI";
            ws[var2].Cells[10, 8].Value = "Total"; 
       


           

            ws[var2].Cells[8, 1, 10, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws[var2].Cells[8, 1, 10, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //isi Total
            idx = 11;
            foreach (DataRow dr in dtV.Rows)
            {
                ws[var2].Cells[idx, 1].Value = dr["NamaToko"].ToString();
                ws[var2].Cells[idx, 2].Value = dr["WilID"].ToString();
                ws[var2].Cells[idx, 3].Value = dr["Kota"].ToString();
                ws[var2].Cells[idx, 4].Value = dr["Daerah"].ToString();

                dsPV.Tables[dr["KodeToko"].ToString()].DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"].ToString() + "'";

                foreach (DataRowView dv in dsPV.Tables[dr["KodeToko"].ToString()].DefaultView)
                {
                        ws[var2].Cells[idx, 5].Value = Convert.ToDouble(dv["A"]);
                        ws[var2].Cells[idx, 6].Value = Convert.ToDouble(dv["B"]);
                        ws[var2].Cells[idx, 7].Value = Convert.ToDouble(dv["C"]);
                        ws[var2].Cells[idx, 8].Value = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                }

                    ws[var2].Cells[idx, 5, idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws[var2].Cells[idx, 5, idx, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws[var2].Cells[idx, 5, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                idx++;
            }
#endregion
           
#endregion

#region SUmmary & Formating
            for (int i = 0; i < ws.Count - 1;i++ )
            {
                var border3 = ws[i].Cells[8, 1, idx-1, 24].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws[i].Cells[8, 1, 10, 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws[i].Cells[8, 1, 10, 24].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws[i].Cells[8, 1, idx-1, 24].Style.WrapText = true;
                
            }
          
            
                var border1 = ws[ ws.Count-1].Cells[9, 1, idx-1, 8].Style.Border;
                border1.Bottom.Style =
                 border1.Top.Style =
                 border1.Left.Style =
                 border1.Right.Style = ExcelBorderStyle.Thin;
                ws[ws.Count - 1].Cells[9, 1, 10, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws[ws.Count - 1].Cells[9, 1, 10, 8].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws[ws.Count - 1].Cells[9, 1, idx-1, 8].Style.WrapText = true;

           

#endregion


                return ex;

        }

        private ExcelPackage ProsesToko()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Laporan Toko Aktif";
            List<ExcelWorksheet> ws = new List<ExcelWorksheet>();
#region Variable

            DataTable dtKota = dtV.DefaultView.ToTable(true, "Kota").Copy();
            DateTime FromDate = monthYearBox1.FirstDateOfMonth;
            DateTime ToDate = monthYearBox2.LastDateOfMonth;
            int Month = ToDate.Month - FromDate.Month + 1;

            DataTable dtToko = dtV.Copy();
          
       
#endregion

#region "Generate Header & Sheet"
            int  ic = 1;
            for (int x = FromDate.Month; x <= ToDate.Month; x++)
            {
                DateTime Tgl = new DateTime(FromDate.Year, x, 1);
                ex.Workbook.Worksheets.Add(Tgl.ToString("MMMM yyyy"));
                ws.Add(ex.Workbook.Worksheets[ic]);
                ic++;
            }
            ex.Workbook.Worksheets.Add("Total");
            ws.Add(ex.Workbook.Worksheets[ic]);
            ex.Workbook.Worksheets.Add("Rata - rata");
            ws.Add(ex.Workbook.Worksheets[ic+1]);
            
            ic = 0;
            for (int x = FromDate.Month; x <= ToDate.Month+2; x++)
            {
                DateTime Tgl = new DateTime(FromDate.Year, x, 1);
                ws[ic].Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws[ic].Cells.Style.Font.Name = "Arial";

                // Width

                ws[ic].Cells[1, 1].Worksheet.Column(1).Width = 12;
                ws[ic].Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws[ic].Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws[ic].Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int i = 5; i <= 24; i++)
                {
                    ws[ic].Cells[1, i].Worksheet.Column(i).Width = 13;
                }

                //Tiitle
                ws[ic].Cells[1, 1].Value = "Laporan     : Toko Aktif";
                ws[ic].Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws[ic].Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws[ic].Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws[ic].Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws[ic].Cells[1, 1, 1, 4].Merge = true;
                ws[ic].Cells[2, 1, 2, 4].Merge = true;
                ws[ic].Cells[3, 1, 3, 4].Merge = true;
                ws[ic].Cells[4, 1, 4, 4].Merge = true;
                ws[ic].Cells[5, 1, 5, 4].Merge = true;

                ws[ic].Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws[ic].Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws[ic].Cells[8, 1].Value = "Nama Toko"; ws[ic].Cells[8, 1, 10, 1].Merge = true;
                //ws[ic].Cells[8, 2].Value = "WilID"; ws[ic].Cells[8, 2, 10, 2].Merge = true;
                ws[ic].Cells[8, 1].Value = "KOTA"; ws[ic].Cells[8, 1, 10, 4].Merge = true;
                //ws[ic].Cells[8, 4].Value = "DAERAH"; ws[ic].Cells[8, 4, 10, 4].Merge = true;
                if (x == (ToDate.Month+1))
                {
                    ws[ic].Cells[8, 5].Value = "TOTAL "+ToDate.ToString("MMMM yyyy"); ws[ic].Cells[8, 5, 8, 24].Merge = true;
                }
                else if (x == (ToDate.Month + 2))
                {
                    ws[ic].Cells[8, 5].Value = "Rata-rata " + ToDate.ToString("MMMM yyyy"); ws[ic].Cells[8, 5, 8, 24].Merge = true;
                }
                else
                {
                    ws[ic].Cells[8, 5].Value = Tgl.ToString("MMMM yyyy"); ws[ic].Cells[8, 5, 8, 24].Merge = true;
                }
                

                ws[ic].Cells[9, 5].Value = "FB2"; ws[ic].Cells[9, 5, 9, 8].Merge = true;
                ws[ic].Cells[9, 9].Value = "FB4"; ws[ic].Cells[9, 9, 9, 12].Merge = true;
                ws[ic].Cells[9, 13].Value = "FE2"; ws[ic].Cells[9, 13, 9, 16].Merge = true;
                ws[ic].Cells[9, 17].Value = "FE4"; ws[ic].Cells[9, 17, 9, 20].Merge = true;
                ws[ic].Cells[9, 21].Value = "Lainya"; ws[ic].Cells[9, 21, 9, 24].Merge = true;


                for (int i = 5; i <= 24; i += 4)
                {
                    ws[ic].Cells[10, i].Value = "OMSET";
                    ws[ic].Cells[10, i + 1].Value = "HPP";
                    ws[ic].Cells[10, i + 2].Value = "LABA RP";
                    ws[ic].Cells[10, i + 3].Value = "LABA %";
                }

                ws[ic].Cells[8, 1, 10, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws[ic].Cells[8, 1, 10, 24].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ic++;
            }
            #endregion           


#region FillDetail

            int idx = 11;

            foreach (DataRow drKota in dtKota.Rows)
            {
                 dtToko.DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
                 int m = FromDate.Month;
                 for (int x = FromDate.Month; x <= ToDate.Month; x++)
                 {
                     ws[x - m].Cells[idx, 1].Value = drKota["Kota"].ToString();
                     ws[x - m].Cells[idx, 1, idx, 4].Merge = true; 
                     foreach (DataRowView dv1 in dtToko.DefaultView)
                     {
                         dsTV.Tables[dv1["KodeToko"].ToString()].DefaultView.RowFilter = "Bulan=" + x.ToString() + "";
                         foreach (DataRowView dv in dsTV.Tables[dv1["KodeToko"].ToString()].DefaultView)
                         {
                             if (GetIdx(dv["KLP"].ToString()) > 0)
                             {
                                 ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                     Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                                 ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                     Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                                 ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                     Convert.ToDouble(ws[x - m].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                             }
                         }
                     }
                     double RpOmset = 0;
                     double RpLaba = 0;
                     for (int i = 8; i <= 24; i += 4)
                     {
                         RpOmset = Convert.ToDouble(ws[x - m].Cells[idx, i - 3].Value);
                         RpLaba = Convert.ToDouble(ws[x - m].Cells[idx, i - 1].Value);
                         if (RpOmset != 0 && RpLaba != 0)
                         {
                             ws[x - m].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                         }

                         ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                         ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                         ws[x - m].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                     }

                 }
              

                idx++;
            }
#endregion


#region Total
             idx = 11;
            int var1 = Month;
            int a =ws.Count;
             //ex.Workbook.Worksheets.Add("Total");
             //ws.Add(ex.Workbook.Worksheets[Month + 1]);
             //ws[var1].Cells[idx, 1].Value = dr["NamaToko"].ToString();
             //ws[var1].Cells[idx, 2].Value = dr["WilID"].ToString();
            foreach (DataRow drKota in dtKota.Rows)
            {
                dtToko.DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
            
               
                    ws[var1].Cells[idx, 1].Value = drKota["Kota"].ToString();
                    ws[var1].Cells[idx, 1, idx, 4].Merge = true;
                    foreach (DataRowView dv1 in dtToko.DefaultView)
                    {
                     
                        foreach (DataRow dv in dsTV.Tables[dv1["KodeToko"].ToString()].Rows)
                        {
                            if (GetIdx(dv["KLP"].ToString()) > 0)
                            {
                                ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                    Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                                ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                    Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                                ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                    Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                            }
                        }
                    }
                    double RpOmset = 0;
                    double RpLaba = 0;
                    for (int i = 8; i <= 24; i += 4)
                    {
                        RpOmset = Convert.ToDouble(ws[var1].Cells[idx, i - 3].Value);
                        RpLaba = Convert.ToDouble(ws[var1].Cells[idx, i - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws[var1].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws[var1].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws[var1].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws[var1].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

              


                idx++;
            }

#endregion
           
#region dada rata
            idx = 11;
             var1 = Month+1;
           
            //ex.Workbook.Worksheets.Add("Total");
            //ws.Add(ex.Workbook.Worksheets[Month + 1]);
            //ws[var1].Cells[idx, 1].Value = dr["NamaToko"].ToString();
            //ws[var1].Cells[idx, 2].Value = dr["WilID"].ToString();
            foreach (DataRow drKota in dtKota.Rows)
            {
                dtToko.DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";


                ws[var1].Cells[idx, 1].Value = drKota["Kota"].ToString();
                ws[var1].Cells[idx, 1, idx, 4].Merge = true;
                foreach (DataRowView dv1 in dtToko.DefaultView)
                {

                    foreach (DataRow dv in dsTV.Tables[dv1["KodeToko"].ToString()].Rows)
                    {
                        if (GetIdx(dv["KLP"].ToString()) > 0)
                        {
                            ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);
                            ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);
                            ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                Convert.ToDouble(ws[var1].Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                        }
                    }
                }
                double RpOmset = 0;
                double RpLaba = 0;
                for (int i = 8; i <= 24; i += 4)
                {
                    ws[var1].Cells[idx, i - 3].Value = Math.Round(Convert.ToDouble(ws[var1].Cells[idx, i - 3].Value) / Month, 0);
                    ws[var1].Cells[idx, i - 2].Value = Math.Round(Convert.ToDouble(ws[var1].Cells[idx, i - 2].Value) / Month, 0);
                    ws[var1].Cells[idx, i - 1].Value = Math.Round(Convert.ToDouble(ws[var1].Cells[idx, i - 1].Value) / Month, 0);
                    RpOmset = Convert.ToDouble(ws[var1].Cells[idx, i - 3].Value);
                    RpLaba = Convert.ToDouble(ws[var1].Cells[idx, i - 1].Value);
                    if (RpOmset != 0 && RpLaba != 0)
                    {
                        ws[var1].Cells[idx, i].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                    }

                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws[var1].Cells[idx, i - 3, idx, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }




                idx++;
            }

#endregion

#region Kutang
            int var2 = Month + 2;
            ex.Workbook.Worksheets.Add("Piutang " + ToDate.ToString("MMMM yyyy"));
            ws.Add(ex.Workbook.Worksheets[Month + 3]);

            ws[var2].Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws[var2].Cells.Style.Font.Name = "Arial";

            // Width

            ws[var2].Cells[1, 1].Worksheet.Column(1).Width = 12;
            ws[var2].Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws[var2].Cells[1, 3].Worksheet.Column(3).Width = 5;
            ws[var2].Cells[1, 4].Worksheet.Column(4).Width = 5;

            for (int i = 5; i <= 8; i++)
            {
                ws[var2].Cells[1, i].Worksheet.Column(i).Width = 13;
            }
            ws[ic].Cells[9, 1].Value = "KOTA"; ws[ic].Cells[9, 1, 10, 4].Merge = true;
            ws[var2].Cells[9, 5].Value = "Umur Piutang " +
                                           monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                        ;
            ws[var2].Cells[9, 5, 9, 8].Merge = true;


            ws[var2].Cells[10, 5].Value = "<90 HARI";
            ws[var2].Cells[10, 6].Value = "91 -120 HARI";
            ws[var2].Cells[10, 7].Value = ">121 HARI";
            ws[var2].Cells[10, 8].Value = "Total";





            ws[var2].Cells[8, 1, 10, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws[var2].Cells[8, 1, 10, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //isi Total
            idx = 11;
            foreach (DataRow drKota in dtKota.Rows)
            {
                dtToko.DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";


                ws[var2].Cells[idx, 1].Value = drKota["Kota"].ToString();
                ws[var2].Cells[idx, 1, idx, 4].Merge = true;
                foreach (DataRowView dv1 in dtToko.DefaultView)
                {

                    foreach (DataRow dv in dsPV.Tables[dv1["KodeToko"].ToString()].Rows)
                    {
                        ws[var2].Cells[idx, 5].Value = Convert.ToDouble(ws[var2].Cells[idx, 5].Value)+Convert.ToDouble(dv["A"]);
                        ws[var2].Cells[idx, 6].Value = Convert.ToDouble(ws[var2].Cells[idx, 6].Value) + Convert.ToDouble(dv["B"]);
                        ws[var2].Cells[idx, 7].Value = Convert.ToDouble(ws[var2].Cells[idx, 7].Value) + Convert.ToDouble(dv["C"]);
                        Double T = 0;
                        T = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                        ws[var2].Cells[idx, 8].Value = Convert.ToDouble(ws[var2].Cells[idx, 8].Value) + T;
                        
                    }
                }
               

                ws[var2].Cells[idx, 5, idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws[var2].Cells[idx, 5, idx, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws[var2].Cells[idx, 5, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                idx++;
            }
           
#endregion

#region SUmmary & Formating
            for (int i = 0; i < ws.Count - 1; i++)
            {
                var border3 = ws[i].Cells[8, 1, idx-1, 24].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws[i].Cells[8, 1, 10, 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws[i].Cells[8, 1, 10, 24].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws[i].Cells[8, 1, idx-1, 24].Style.WrapText = true;

            }


            var border1 = ws[ws.Count - 1].Cells[9, 1, idx-1, 8].Style.Border;
            border1.Bottom.Style =
             border1.Top.Style =
             border1.Left.Style =
             border1.Right.Style = ExcelBorderStyle.Thin;
            ws[ws.Count - 1].Cells[9, 1, 10, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws[ws.Count - 1].Cells[9, 1, 10, 8].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            ws[ws.Count - 1].Cells[9, 1, idx-1, 8].Style.WrapText = true;

#endregion

            return ex;
        }

        private void InitSheet()
        {
             
            for (int i = 1; i <= 1;i++ )
            {
               
                DataRow drw = dtKLP.NewRow();
                drw["Bulan"] = i.ToString();

                drw["FB2"] = (LCol + 4).ToString();
                drw["FB2.Omset"] = (LCol + 1).ToString();
                drw["FB2.HPP"] = (LCol + 2).ToString();

                drw["FB4"] = (LCol + 8).ToString();
                drw["FB4.Omset"] = (LCol + 5).ToString();
                drw["FB4.HPP"] = (LCol + 6).ToString();

                drw["FE2"] = (LCol + 12).ToString();
                drw["FE2.Omset"] = (LCol + 9).ToString();
                drw["FE2.HPP"] = (LCol + 10).ToString();

                drw["FE4"] = (LCol + 16).ToString();
                drw["FE4.Omset"] = (LCol + 13).ToString();
                drw["FE4.HPP"] = (LCol + 14).ToString();

                drw["Lainya"] = (LCol + 20).ToString();
                drw["Lainya.Omset"] = (LCol + 17).ToString();
                drw["Lainya.HPP"] = (LCol + 18).ToString();

                dtKLP.Rows.Add(drw);

            }
        }

        private int GetCol()
        {
            int i = 0;

            return i;
        }

        private int GetIdx(string Field)
        {
            int idx = 0;
            
            switch (Field)
            {
                case "FB2" : 
                    idx = (LCol + 1); 
                break;
                case "FB2.Omset" : 
                    idx = (LCol + 1); 
                break;
                case "FB2.HPP" : 
                    idx = (LCol + 2); 
                break;

                case "FB4" : 
                    idx = (LCol + 5); 
                break;
                case "FB4.Omset" : 
                    idx = (LCol + 5); 
                break;
                case "FB4.HPP" : 
                    idx = (LCol + 6); 
                break;

                case "FE2" : 
                    idx = (LCol + 9); 
                break;
                case "FE2.Omset" : 
                    idx = (LCol + 9); 
                break;
                case "FE2.HPP" : 
                     idx = (LCol + 10); 
                break;
                case "FE4" : 
                    idx = (LCol + 13); 
                break;
                case "FE4.Omset" : 
                    idx = (LCol + 13); 
                break;
                case "FE4.HPP" : 
                    idx = (LCol + 14); 
                break;
                case "Lainya" : 
                    idx = (LCol + 17); 
                break;
                case "Lainya.Omset" : 
                    idx = (LCol + 17); 
                break;
                case "Lainya.HPP" : 
                    idx = (LCol + 18);
                break;
            }
            return idx;
        }


#endregion

        public frmTokoAktif()
        {
            InitializeComponent();
        }

        private void frmTokoAktif_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            monthYearBox1.Month = 1;
            monthYearBox1.Year = DateTime.Now.Year;

            monthYearBox2.Month = DateTime.Now.Month;
            monthYearBox2.Year = DateTime.Now.Year;
            dsT =new dsToko();
            dtKLP = dsT.Tables["KLP"].Copy();
            dtV = dsT.Tables["Toko"].Copy();
            txtNamaToko.Text = "";
            progressBar1.Visible = false;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }
             try
            {
                this.Cursor = Cursors.WaitCursor;
                dtT.Clear();            dtV.Clear();  
                dsTV.Tables.Clear();    dsPV.Tables.Clear();    dtKLP.Rows.Clear(); 
                InitSheet();
                FillToko();
                progressBar1.Visible = true;

                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Proses());
                exs.Add(ProsesToko());

#region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Toko Aktif.xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    string file2 = sf.FileName.ToString().Replace(".xlsx", "(Kota).xlsx");
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    Byte[] bin2 = exs[1].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    File.WriteAllBytes(file2, bin2);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file + Environment.NewLine+file2);
                    Process.Start(sf.FileName.ToString());
                    Process.Start(file2);
                }
#endregion
            }
             catch (System.Exception ex)
             {
                 Error.LogError(ex);
             }
             finally
             {
                 this.Cursor = Cursors.Default;
                 progressBar1.Visible = false;
                 txtNamaToko.Text = string.Empty;
                 progressBar1.Visible = false;
             }
        }
    }
}
