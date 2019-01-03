using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using ISA.DAL;
using OfficeOpenXml.Style;
using System.IO;

namespace ISA.Finance.Testing
{
    public partial class frmGenerate_Excel : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        DateTime FromDate = new DateTime(2012, 1, 1);
        DateTime ToDate = new DateTime(2012, 1, 10);
        DataTable dtHeader = new DataTable();
        public frmGenerate_Excel()
        {
            InitializeComponent();
        }

        private void frmGenerate_Excel_Load(object sender, EventArgs e)
        {
            dtHeader.Columns.Add("IDWIL");
            dtHeader.Columns.Add("NAMA TOKO");
            dtHeader.Columns.Add("SALES");
            dtHeader.Columns.Add("NOTA");
            dtHeader.Columns.Add("TGL. NOTA");
            dtHeader.Columns.Add("TGL. JT");
            dtHeader.Columns.Add("RP JUAL");
            dtHeader.Columns.Add("RP BAYAR");
            dtHeader.Columns.Add("RP SISA");
            dtHeader.Columns.Add("KETERANGAN");
            dtHeader.Rows.Add("WilID", "NamaToko", "KodeSales", "NoTransaksi", "TglTransaksi", "TglJthTempo", "RpJual", "RpBayar", "RpSisa", "Catatan");
            using (ExcelPackage p =new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "Penyelesaian Nota Per Wilayah";

                //Create a sheet

                p.Workbook.Worksheets.Add("Sample WorkSheet");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Rpt4PenyelesaianNotaPerWilayah"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                //Merging cells and create a center heading for out table
                
                ws.Cells[1, 1].Value = "Initial";
                ws.Cells[2, 1].Value = "Laporan";
                ws.Cells[3, 1].Value = "Periode";
                ws.Cells[4, 1].Value = "Pengolah";
                
                ws.Cells[1, 2].Value = ": " + GlobalVar.Gudang;
                ws.Cells[2, 2].Value = ": " + p.Workbook.Properties.Title;
                ws.Cells[3, 2].Value = ": " + String.Format("{0:dd-MMM-yyyy}", FromDate) + " S/D " + String.Format("{0:dd-MMM-yyyy}", ToDate);
                ws.Cells[4, 2].Value = ": " + SecurityManager.UserName;

                getData();
                ws.Cells[1, 2, 1, dtHeader.Columns.Count].Merge = true;
                //ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[1, 2, 1, dtHeader.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[2, 2, 2, dtHeader.Columns.Count].Merge = true;
                //ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[2, 2, 2, dtHeader.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[3, 2, 3, dtHeader.Columns.Count].Merge = true;
                //ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[3, 2, 3, dtHeader.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[4, 2, 4, dtHeader.Columns.Count].Merge = true;
                //ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[4, 2, 4, dtHeader.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                
                ws.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                var border = ws.Cells[1,1,4,dtHeader.Columns.Count].Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = ExcelBorderStyle.Thin;

                

                int colIndex = 1;
                int rowIndex = 6;
                foreach (DataColumn dc in dtHeader.Columns)
                {
                    var cell = ws.Cells[rowIndex, colIndex];

                    //Setting the background color of header cells to Gray

                    var fill = cell.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(Color.Aqua);

                    //Setting Top/left,right/bottom borders.

                    //var border = cell.Style.Border;
                    //border.Bottom.Style =
                    //    border.Top.Style =
                    //    border.Left.Style =
                    //    border.Right.Style = ExcelBorderStyle.Thin;
                    
                    //Setting Value in cell
                    cell.Value = dc.ColumnName;
                    colIndex++;
                }
                int rowAwal = 0;
                dt.DefaultView.Sort = "KodeToko";
                DataTable dtnew = dt.DefaultView.ToTable(true, "KodeToko");
                foreach (DataRow dr in dtnew.Rows)
                {
                    DataTable dtGroup = dt.Copy();
                    dtGroup.DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"] + "'";
                    rowIndex++;
                    rowAwal = rowIndex;
                    ws.Cells[rowIndex, 1].Value = dtGroup.Rows[0][dtHeader.Rows[0][0].ToString()];
                    ws.Cells[rowIndex, 2].Value = dtGroup.Rows[0][dtHeader.Rows[0][1].ToString()];
                    ws.Cells[rowIndex, 10].Value = dtGroup.Rows[0][dtHeader.Rows[0][9].ToString()];
                    
                    ws.Cells[rowIndex, 1, rowIndex + dtGroup.DefaultView.Count-1, 1].Merge = true;
                    ws.Cells[rowIndex, 2, rowIndex + dtGroup.DefaultView.Count-1, 2].Merge = true;
                    ws.Cells[rowIndex, 10, rowIndex + dtGroup.DefaultView.Count, 10].Merge = true;
                    
                    foreach (DataRowView dr2 in dtGroup.DefaultView)
                    {
                        ws.Cells[rowIndex, 3].Value = dtGroup.Rows[0][dtHeader.Rows[0][2].ToString()];
                        ws.Cells[rowIndex, 4].Value = dtGroup.Rows[0][dtHeader.Rows[0][3].ToString()];
                        ws.Cells[rowIndex, 5].Value = String.Format("{0:dd-MMM-yyyy}",dtGroup.Rows[0][dtHeader.Rows[0][4].ToString()]);
                        ws.Cells[rowIndex, 5].Style.Numberformat.Format = "dd-MMM-yyyy";
                        ws.Cells[rowIndex, 6].Value = String.Format("{0:dd-MMM-yyyy}",dtGroup.Rows[0][dtHeader.Rows[0][5].ToString()]);
                        ws.Cells[rowIndex, 6].Style.Numberformat.Format = "dd-MMM-yyyy";
                        ws.Cells[rowIndex, 7].Value = dtGroup.Rows[0][dtHeader.Rows[0][6].ToString()];
                        ws.Cells[rowIndex, 8].Value = dtGroup.Rows[0][dtHeader.Rows[0][7].ToString()];
                        ws.Cells[rowIndex, 9].Value = dtGroup.Rows[0][dtHeader.Rows[0][8].ToString()];
                        ws.Cells[rowIndex, 7].Style.Numberformat.Format = "#,##0";
                        ws.Cells[rowIndex, 8].Style.Numberformat.Format = "#,##0";
                        ws.Cells[rowIndex, 9].Style.Numberformat.Format = "#,##0";
                        rowIndex++;
                    }
                    ws.Cells[rowIndex, 1, rowIndex, 5].Merge = true;
                    ws.Cells[rowIndex, 6, rowIndex, 9].Style.Font.Bold = true;
                    ws.Cells[rowIndex, 6].Value = "SubTotal";
                    ws.Cells[rowIndex, 7].Formula = "Sum(" +ws.Cells[rowAwal, 7].Address +
                            ":" +ws.Cells[rowIndex - 1, 7].Address +")";
                    ws.Cells[rowIndex, 8].Formula = "Sum(" + ws.Cells[rowAwal, 8].Address +
                            ":" + ws.Cells[rowIndex - 1, 8].Address + ")";
                    ws.Cells[rowIndex, 9].Formula = "Sum(" + ws.Cells[rowAwal, 9].Address +
                            ":" + ws.Cells[rowIndex - 1, 9].Address + ")";

                }
                rowIndex++;
                ws.Cells[rowIndex, 1, rowIndex, 5].Merge = true;
                ws.Cells[rowIndex, 6, rowIndex, 9].Style.Font.Bold = true;
                ws.Cells[rowIndex, 6].Value = "Total";
                ws.Cells[rowIndex, 7].Value = Convert.ToDouble(dt.Compute("Sum(RpJual)", ""));

                ws.Cells[rowIndex, 8].Value = Convert.ToDouble(dt.Compute("Sum(RpBayar)", ""));

                ws.Cells[rowIndex, 9].Value = Convert.ToDouble(dt.Compute("Sum(RpSisa)", ""));
                ws.Cells[rowIndex, 7].Style.Numberformat.Format = "#,##0";
                ws.Cells[rowIndex, 8].Style.Numberformat.Format = "#,##0";
                ws.Cells[rowIndex, 9].Style.Numberformat.Format = "#,##0";
                ws.Cells[6, 1, dt.Rows.Count, dtHeader.Columns.Count].AutoFitColumns();


                var border2 = ws.Cells[6, 1, rowIndex, dtHeader.Columns.Count].Style.Border;
                border2.Bottom.Style =
                    border2.Top.Style =
                    border2.Left.Style =
                    border2.Right.Style = ExcelBorderStyle.Thin;

                Byte[] bin = p.GetAsByteArray();

                string file = "d:\\" + Guid.NewGuid().ToString() + ".xlsx";
                //ws.Cells.Style.ShrinkToFit = true;

               File.WriteAllBytes(file, bin);
               MessageBox.Show("beres");
            }
        }

        public void getData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_4PenyelesaianNotaPerWilayah"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@LMinus", SqlDbType.Int, 1));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                dt.DefaultView.Sort = "NamaToko, WilID, TglTransaksi";


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
