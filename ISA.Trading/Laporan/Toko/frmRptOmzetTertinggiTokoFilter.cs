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

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptOmzetTertinggiTokoFilter : ISA.Trading.BaseForm
    {
        DataTable dt;
        string Klp = "";

        public frmRptOmzetTertinggiTokoFilter()
        {
            InitializeComponent();
        }

        private void frmRptOmzetTertinggiTokoFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Omzet Tertinggi Toko";
            this.Text = "Laporan"; 
            rdbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl.ToDate = DateTime.Now;
            cabangComboBox.CabangID = Tools.Left(GlobalVar.CabangID,2);
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl.FromDate.ToString() == "" || rdbTgl.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl, "Range Tanggal masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
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
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_OmzetTertinggiToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    if (lookupSales.NamaSales != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (txtWilID.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text));
                    if (txtKota.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    if (txtWilayah.Text != "" && txtWilayah.Text != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
                    if (cabangComboBox.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, cabangComboBox.CabangID));
                    if (Klp != "")
                        db.Commands[0].Parameters.Add(new Parameter("Klp", SqlDbType.VarChar, Klp));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                string sSum = dt.Compute("SUM(Omzet)", "Omzet IS NOT NULL").ToString();
                if (sSum == "")
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    //MessageBox.Show(dt.Rows.Count.ToString());
                    //DisplayReportExcell(dt);
                    DisplayReport(dt);

                    //List<ExcelPackage> exs = new List<ExcelPackage>();
                    //exs.Add(laporanOT());

                    //SaveFileDialog sf = new SaveFileDialog();
                    //sf.InitialDirectory = "C:\\Temp\\";
                    //sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    //sf.FileName = "rptOmzetTertinggiToko";       // + GlobalVar.Gudang;
                    //sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                    //sf.OverwritePrompt = true;
                    //if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                    //{
                    //    string file = sf.FileName.ToString();
                    //    Byte[] bin1 = exs[0].GetAsByteArray();
                    //    File.WriteAllBytes(file, bin1);
                    //    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    //    Process.Start(sf.FileName.ToString());
                    //}
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


        private void DisplayReportExcell(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(laporanOT());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rptOmzetTertinggiToko";       // + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

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
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private ExcelPackage laporanOT()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "OMZET TERTINGGI TOKO";
            ex.Workbook.Properties.Title = "Laporan";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan", "1147");

            ex.Workbook.Worksheets.Add("rptOmzetTertinggiToko");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 31;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 50;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 20;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 9;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 12;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;

            int MaxCol = 7;
            // Title
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "OMZET TERTINGGI TOKO";
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : "+ string.Format("{0:dd-MMM-yyyy}", rdbTgl.FromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", rdbTgl.ToDate);
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[3, 1].Value = "SALESMAN : " + Tools.isNull(lookupSales.NamaSales, "");
            ws.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells[4, 1].Value = "IDWIL           : " + Tools.isNull(txtWilID.Text, "");
            ws.Cells[4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells[5, 1].Value = "KOTA            : " + Tools.isNull(txtKota.Text, "");
            ws.Cells[5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells[6, 1].Value = "C1                  : " + Tools.isNull(cabangComboBox.CabangID, "");
            ws.Cells[6, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            //Header
            ws.Cells[7, 1].Value = " NAMA TOKO "; ws.Cells[7, 1, 8, 1].Merge = true;
            ws.Cells[7, 2].Value = " KODE POS "; ws.Cells[7, 2, 8, 2].Merge = true;
            ws.Cells[7, 3].Value = " ALAMAT "; ws.Cells[7, 3, 8, 3].Merge = true;
            ws.Cells[7, 4].Value = " KOTA "; ws.Cells[7, 4, 8, 4].Merge = true;
            ws.Cells[7, 5].Value = " IDWIL "; ws.Cells[7, 5, 8, 5].Merge = true;
            ws.Cells[7, 6].Value = " BLN INI "; ws.Cells[7, 6, 8, 6].Merge = true;
            ws.Cells[7, 7].Value = " TERTINGGI "; ws.Cells[7, 7, 8, 7].Merge = true;

            int rowx = 9;
            double JmlD = 0, JmlK = 0;

            ws.Cells[7, 1, 7, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[7, 1, 7, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[7, 1, 7, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[7, 1, 7, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            int i;
            for (i = 0; i <= (dt.Rows.Count) - 1; i++)
            {
                ws.Cells[rowx, 1].Value = Convert.ToString(dt.Rows[i]["NamaToko"]);
                ws.Cells[rowx, 2].Value = Convert.ToString(dt.Rows[i]["KodePos"]);
                ws.Cells[rowx, 3].Value = Convert.ToString(dt.Rows[i]["Alamat"]);
                ws.Cells[rowx, 4].Value = Convert.ToString(dt.Rows[i]["Kota"]);
                ws.Cells[rowx, 5].Value = Convert.ToString(dt.Rows[i]["WilID"]);
                ws.Cells[rowx, 6].Value = Convert.ToDouble(dt.Rows[i]["Omzet"]);
                ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 7].Value = Convert.ToDouble(dt.Rows[i]["Omzet"]);
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";

                JmlD = JmlD + Convert.ToDouble(Tools.isNull(dt.Rows[i]["Omzet"],0));
                JmlK = JmlK + Convert.ToDouble(Tools.isNull(dt.Rows[i]["Omzet"],0));
                rowx++;
            }

            ws.Cells[rowx, 6].Value = Tools.isNull(JmlD, 0);
            ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 7].Value = Tools.isNull(JmlK, 0);
            ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";

            var border = ws.Cells[7, 1, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[rowx, 1, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[rowx, 1, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            return ex;
        }


        
        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string sales = "Semua", wilID = "Semua", kota = "Semua", c1 = "Semua";
            if (lookupSales.NamaSales != "")
                sales = lookupSales.SalesID;
            if (txtWilID.Text != "")
                wilID = txtWilID.Text;
            if (txtKota.Text != "")
                kota = txtKota.Text;
            if (cabangComboBox.SelectedValue.ToString() != "")
                c1 = cabangComboBox.SelectedValue.ToString();

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Sales", sales));
            rptParams.Add(new ReportParameter("WilID", wilID));
            rptParams.Add(new ReportParameter("Kota", kota));
            rptParams.Add(new ReportParameter("C1", c1));
            rptParams.Add(new ReportParameter("Klp", Klp));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptOmzetTertinggiToko.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales.Trim()=="")
            {
                lookupSales.SalesID = ""; 
            }
        }
    }
}
