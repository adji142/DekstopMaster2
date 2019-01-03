using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using ISA.Toko.DataTemplates;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Toko.POS.Laporan
{
    public partial class FrmPOSLaporan : BaseForm
    {
        string _sales;
        public FrmPOSLaporan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPOSLaporan_Load(object sender, EventArgs e)
        {
            this.Text = "Laporan";
            
        }
        
        private void DisplayReport(DataTable dt)
        {

            
                List<ReportParameter> rptParams = new List<ReportParameter>();

                rptParams.Add(new ReportParameter("fromdate", DateLaporan.Text));
       

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("POS.Laporan.RptPOS.rdlc", rptParams, dt, "DSLaporanPOS_TabelNota");
                ifrmReport.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        if (lookupSales1.NamaSales == "")
                        {
                            db.Commands.Add(db.CreateCommand("rsp_Laporan_POS_ALL"));
                            db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Convert.ToDateTime(DateLaporan.Text)));
                            //db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                            dt = db.Commands[0].ExecuteDataTable();                            
                        }
                        else
                        {
                            db.Commands.Add(db.CreateCommand("rsp_Laporan_POS"));
                            db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Convert.ToDateTime(DateLaporan.Text)));
                           // db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                            db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data tidak ada.....");
                        Close();
                    }
                    else
                    {
                        DisplayReport(dt);
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
      

        private void CmdExcel_Click(object sender, EventArgs e)
        {
            
           

        }

        private void GenerateExcell(DataSet ds)
        {

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN POS";


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 12;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 12;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12;



                //string periode = "PERIODE : " +
                //                   rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy") + " S.D  " +
                //                   rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy");

                ws.Cells[1, 1].Value = "LAPORAN HARIAN SALES";
                //+ (checkBox1.Checked ? "[ HPP-A ]" : "");
                //ws.Cells[2, 1].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.FromDate.Value) + " - " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.ToDate.Value);
                ws.Cells[3, 1].Value = "";
                ws.Cells[4, 1].Value = "";
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 11;



                #region Generate Header
                ws.Cells[5, 1].Value = " LAPORAN DATA KARYAWAN "; ws.Cells[5, 1, 5, 7].Merge = true;
                //ws.Cells[5, 4].Value = " NOMOR SERI "; ws.Cells[5, 4, 6, 4].Merge = true;

                //ws.Cells[5, MaxCol].Value = "N O M I N A L"; ws.Cells[5, MaxCol, 6, MaxCol].Merge = true;

                ws.Cells[6, 1].Value = "SALES";
                ws.Cells[6, 2].Value = "TANGGAL";
                ws.Cells[6, 3].Value = "NO.NOTA";
                ws.Cells[6, 4].Value = "CUSTOMER";
                ws.Cells[6, 5].Value = "RP. JUAL";
                ws.Cells[6, 6].Value = "DISC";
                ws.Cells[6, 7].Value = "JUMLAH";

                ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData



                int idx = 7;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ws.Cells[idx, 1].Value = dr["NamaSales"];
                    ws.Cells[idx, 2].Value = dr["TglNota"];
                    ws.Cells[idx, 3].Value = dr["NoNota"];
                    ws.Cells[idx, 4].Value = dr["NamaToko"];
                    ws.Cells[idx, 5].Value = dr["HrgJual"];                     
                    ws.Cells[idx, 7].Value = dr["nBersih"];
                    ws.Cells[idx, 6].Value = (Convert.ToInt32(dr["QtySuratJalan"])
                       * Convert.ToInt32(dr["HrgJual"]))
                       - Convert.ToInt32(dr["nBersih"]);
                    //ws.Cells[idx, 8].Value = dr["HrgJual"];
                    //ws.Cells[idx, 9].Value = dr["QtySuratJalan"];
                    
                    idx++;
                }
                #endregion
                
                #region Summary & Formatting
                ws.Cells[5, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                // ws.Cells[7, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";


                //ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[7, 5].Address +
                // ":" + ws.Cells[idx - 1, 5].Address + ")";
                // ws.Cells[idx, 5].Style.Font.Bold = true;

                //    ws.Cells[7, 5, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";
                // ws.Cells[7, 5, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                //ws.Cells[7, 5, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // ws.Cells[7, 5, idx - 1, MaxCol].Style.WrapText = true;
                //var border = ws.Cells[5, 1, idx - 1, MaxCol].Style.Border;
                var border = ws.Cells[5, 1, idx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
                //var border2 = ws.Cells[idx, 5].Style.Border;
                //border2.Bottom.Style =
                // border2.Top.Style =
                // border2.Left.Style =
                // border2.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "reportHarianPOS.xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion


            }
        }

        private void CmdToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();

                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Laporan_POS"));
                    //db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.VarChar, lookUpKaryawan1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, Convert.ToDateTime(DateLaporan.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                    //db.Commands[0].Parameters.Add(new Parameter("@ToDATE", SqlDbType.DateTime,rangeDateBox1.ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@HPPA", SqlDbType.Bit, checkBox1.Checked? 1:0));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    //MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                //DisplayReport(ds);
                GenerateExcell(ds);
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



        //private void ReportExcel(DataTable ds)
        //{
        //    throw new NotImplementedException();
        //}    
        
    }
}
