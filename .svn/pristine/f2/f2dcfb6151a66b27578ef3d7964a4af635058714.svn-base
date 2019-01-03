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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
namespace ISA.Finance.GL
{
    public partial class frmRpt02BukuBesar : ISA.Finance.BaseForm
    {
        string nop = "";
        public frmRpt02BukuBesar()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";                
                sf.FileName = "rpt02BukuBesar.xlsx";
                
                sf.OverwritePrompt = true;
                
                
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_GL_02BukuBesar"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@fromNoPerkiraan", SqlDbType.VarChar, lookupPerkiraan1.NoPerkiraan));
                        db.Commands[0].Parameters.Add(new Parameter("@toNoPerkiraan", SqlDbType.VarChar, lookupPerkiraan2.NoPerkiraan));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                        db.Commands[0].Parameters.Add(new Parameter("@cetakNol", SqlDbType.Bit, chkCetakSaldoNol.Checked));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(Messages.Confirm.NoDataAvailable);
                        return;
                    }
                    //ShowReport(dt);

                    string file = sf.FileName.ToString();
                    GenerateExcel(dt,file);
                    
                    Process.Start(file);
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);
                MessageBox.Show(ex.Message+nop);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            //periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglDO.ToDate).ToString("dd/MM/yyyy"));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", rangeDateBox1.FromDate.ToString() + "-" + rangeDateBox1.ToDate.ToString()));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt02BukuBesar.rdlc", rptParams, dt, "dsJurnal_Data");
                ifrmReport.Text = "Buku Besar";
                ifrmReport.Show();
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

        private void frmRpt02BukuBesar_Load(object sender, EventArgs e)
        {
            SetControl();   
        }

        private void SetControl()
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths (1).AddDays(-1);
            lookupPerkiraan1.NoPerkiraan = "110101100";
            lookupPerkiraan2.NoPerkiraan = "911110100";
            lookupGudang1.GudangID = "";
        }

        private void GenerateExcel(DataTable dt, string file)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "rpt02BukuBesar";

                int sheet=0,i=0,j=0;
                DataTable dtSheets = new DataTable();
                dtSheets = dt.DefaultView.ToTable(true, "NoPerkiraan", "NamaPerkiraan");
                foreach (DataRow dr in dtSheets.Rows)
                {
                    sheet++;
                    p.Workbook.Worksheets.Add(dr["NoPerkiraan"].ToString());
                    ExcelWorksheet ws = p.Workbook.Worksheets[sheet];
                    nop = dr["NoPerkiraan"].ToString();
                    ws.Name = dr["NoPerkiraan"].ToString(); //Setting Sheet's name
                    ws.Cells.Style.Font.Size = 8; //Default font size for whole sheet
                    ws.Cells.Style.Font.Name = "Arial";

                    

                    ws.Cells[1, 1].Worksheet.Column(1).Width = 10;
                    ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                    ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                    ws.Cells[1, 4].Worksheet.Column(4).Width = 50;
                    ws.Cells[1, 5].Worksheet.Column(5).Width = 12;
                    ws.Cells[1, 6].Worksheet.Column(6).Width = 12;
                    ws.Cells[1, 7].Worksheet.Column(7).Width = 12;

                    if (sheet == 1)
                    {
                        ws.Cells[1, 1].Value = "Buku Besar";
                        ws.Cells[2, 1].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.FromDate.Value) + " - " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.ToDate.Value);
                        ws.Cells[1, 1, 1, 7].Merge = true;
                        ws.Cells[2, 1, 2, 7].Merge = true;
                        ws.Cells[1, 1, 2, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[1, 1, 2, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ws.Cells[4, 1].Value = "Kode"; ws.Cells[4, 2].Value = ":"; ws.Cells[4, 3].Value = dr["NoPerkiraan"].ToString();
                        ws.Cells[5, 1].Value = "Nama"; ws.Cells[5, 2].Value = ":"; ws.Cells[5, 3].Value = dr["NamaPerkiraan"].ToString();
                        ws.Cells[6, 1].Value = "Company"; ws.Cells[6, 2].Value = ":"; ws.Cells[6, 3].Value = lookupGudang1.GudangID;
                        i = 8;
                    }
                    else
                    {
                        ws.Cells[1, 1].Value = "Kode"; ws.Cells[1, 2].Value = ":"; ws.Cells[1, 3].Value = dr["NoPerkiraan"].ToString();
                        ws.Cells[2, 1].Value = "Nama"; ws.Cells[2, 2].Value = ":"; ws.Cells[2, 3].Value = dr["NamaPerkiraan"].ToString();
                        ws.Cells[3, 1].Value = "Company"; ws.Cells[3, 2].Value = ":"; ws.Cells[3, 3].Value = lookupGudang1.GudangID;
                        i = 5;
                    }

                    ws.Cells[i, 1].Value = "Tanggal";
                    ws.Cells[i, 1, i+1, 1].Merge = true;
                    ws.Cells[i, 2].Value = "Kode";
                    ws.Cells[i, 2, i + 1, 2].Merge = true;
                    ws.Cells[i, 3].Value = "NoBukti";
                    ws.Cells[i, 3, i + 1, 3].Merge = true;
                    ws.Cells[i, 4].Value = "Keterangan";
                    ws.Cells[i, 4, i + 1, 4].Merge = true;

                    ws.Cells[i, 5].Value = "Mutasi";
                    ws.Cells[i+1, 5].Value = "Debet";
                    ws.Cells[i+1, 6].Value = "Kredit";
                    ws.Cells[i, 5, i, 6].Merge = true;

                    ws.Cells[i, 7].Value = "Saldo";
                    ws.Cells[i, 7, i + 1, 7].Merge = true;

                    ws.Cells[i, 1, i+1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[i, 1, i+1, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    i++;

                    var border = ws.Cells[i - 1, 1, i, 7].Style.Border;
                    border.Bottom.Style =
                     border.Top.Style =
                     border.Left.Style =
                     border.Right.Style = ExcelBorderStyle.Thin;

                    DataTable dtData = new DataTable();
                    dtData = dt.Copy();
                    dtData.DefaultView.RowFilter = "NoPerkiraan='" + dr["NoPerkiraan"].ToString() + "'";
                    dtData.DefaultView.Sort = "Tanggal, NoReff";
                    double Saldo = 0;
                    int iAwal = i+1;
                    foreach (DataRowView drData in dtData.DefaultView)
                    {
                        i++;
                        if (i == iAwal)
                        {
                            Saldo = Saldo + Convert.ToDouble(drData["Debet"]) - Convert.ToDouble(drData["Kredit"]);
                            ws.Cells[i, 7].Value = Saldo;
                        }
                        else
                            ws.Cells[i, 7].Formula = ws.Cells[i - 1, 7].Address + "+" + ws.Cells[i, 5].Address +"-"+ ws.Cells[i, 6].Address;
                        ws.Cells[i, 1].Value = drData["Tanggal"];
                        ws.Cells[i, 2].Value = drData["KodeGudang"];
                        ws.Cells[i, 3].Value = drData["NoReff"];
                        ws.Cells[i, 4].Value = drData["UraianDetail"].ToString().Trim();
                        ws.Cells[i, 5].Value = drData["Debet"];
                        ws.Cells[i, 6].Value = drData["Kredit"];                        
                        //ws.Cells[i, 7].Value = Saldo;
                        var border2 = ws.Cells[i , 1, i, 7].Style.Border;
                         border2.Left.Style =
                         border2.Right.Style = ExcelBorderStyle.Thin;
                    }
                    i++;
                    ws.Cells[i, 5].Formula = "Sum(" + ws.Cells[iAwal, 5].Address +
                            ":" + ws.Cells[i - 1, 5].Address + ")";
                    ws.Cells[i, 6].Formula = "Sum(" + ws.Cells[iAwal, 6].Address +
                            ":" + ws.Cells[i - 1, 6].Address + ")";
                    ws.Cells[i, 7].Formula = ws.Cells[i, 5].Address +
                            "-" + ws.Cells[i, 6].Address;

                    ws.Cells[i, 1, i, 4].Merge = true;
                    var border3 = ws.Cells[i, 1, i, 7].Style.Border;
                    border3.Bottom.Style =
                     border3.Top.Style =
                     border3.Left.Style =
                     border3.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[i, 1, i, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            ws.Cells[i, 1, i, 7].Style.Fill.BackgroundColor.SetColor(Color.Gray);

                    ws.Cells[iAwal, 5, i, 7].Style.Numberformat.Format = "#,##0;(#,##0);#";
                    ws.Cells[iAwal, 1, i, 1].Style.Numberformat.Format = "dd/MM/yyyy";


                    ws.Cells[iAwal, 1, i, 7].Style.WrapText = true;
                    ws.Cells[iAwal, 1, i, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    ws.Cells[iAwal, 1, i, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[iAwal, 3, i, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[iAwal, 5, i, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    
                }
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;

                File.WriteAllBytes(file, bin);
                MessageBox.Show("Laporan Selesai. " + file);

                
            }
        }
    }
}
