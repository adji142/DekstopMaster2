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

namespace ISA.Trading.HPPA
{
    public partial class frmHPPAExecute : ISA.Trading.BaseForm
    {
        DataTable StokList = new DataTable();

        DateTime? _FromDate;
        DateTime? _ToDate;
        int _Update;
        DataSet ds = new DataSet();

        private void GenerateExcell(DataSet ds)
        {

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN AStok";


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[2];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                ws2.Name = "Sheet2"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 3;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 14;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 73;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 12;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12;



                string periode = "PERIODE : " + ((DateTime)_FromDate).ToString("MMMM yyyy");

                ws.Cells[1, 1].Value = "LAPORAN BARANG PASIF  !=0 ";
                ws.Cells[2, 1].Value = periode;
                ws.Cells[3, 1].Value = "Cabang : "+GlobalVar.CabangID;
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 12;



                #region Generate Header

                ws.Cells[4, 1].Value = "KODE BARANG";
                ws.Cells[4, 2].Value = "NAMA BARANG";
                ws.Cells[4, 3].Value = "SALDO AKHIR";
          
                ws.Cells[4, 1, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[4, 1, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData
                int idx = 5;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ws.Cells[idx, 1].Value = dr["BarangID"];
                    ws.Cells[idx, 2].Value = dr["NamaStok"];
                    ws.Cells[idx, 3].Value = dr["QtyAkhir"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[4, 1, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[4, 1, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[5, 3, idx - 1, 3].Style.Numberformat.Format = "#,##0;(#,##0);0";


                ws.Cells[5, 3, idx - 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[5, 3, idx - 1, 3].Style.WrapText = true;
                var border = ws.Cells[4, 1, idx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion



                 MaxCol = 4;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 9;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 73;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 12;



                  periode = "PERIODE : " + ((DateTime)_FromDate).ToString("MMMM yyyy");

                ws2.Cells[1, 1].Value = "LAPORAN BARANG PASIF  !=0 ";
                ws2.Cells[2, 1].Value = periode;
                ws2.Cells[3, 1].Value = "Cabang : " + GlobalVar.CabangID;
                ws2.Cells[1, 1, 1, MaxCol].Merge = true;
                ws2.Cells[2, 1, 2, MaxCol].Merge = true;

                ws2.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws2.Cells[1, 1].Style.Font.Size = 14;
                ws2.Cells[2, 1].Style.Font.Size = 12;



                #region Generate Header

                ws2.Cells[4, 1].Value = "Gudang";
                ws2.Cells[4, 2].Value = "KODE BARANG";
                ws2.Cells[4, 3].Value = "NAMA BARANG";
                ws2.Cells[4, 4].Value = "SALDO AKHIR";

                ws2.Cells[4, 1, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[4, 1, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData
                  idx = 5;

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    ws2.Cells[idx, 1].Value = dr["GudangID"];
                    ws2.Cells[idx, 2].Value = dr["BarangID"];
                    ws2.Cells[idx, 3].Value = dr["NamaStok"];
                    ws2.Cells[idx, 4].Value = dr["QtyAkhir"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws2.Cells[4, 1, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[4, 1, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws2.Cells[5, 4, idx - 1, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";


                ws2.Cells[5, MaxCol, idx - 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws2.Cells[5, MaxCol, idx - 1, MaxCol].Style.WrapText = true;
                var border2 = ws2.Cells[4, 1, idx - 1, MaxCol].Style.Border;
                border2.Bottom.Style =
                 border2.Top.Style =
                 border2.Left.Style =
                 border2.Right.Style = ExcelBorderStyle.Thin;
                #endregion


                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Barang pasif.xlsx";

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

        private void ChekPasif()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();

                using (Database db = new Database( ))
                {
                    db.Commands.Add(db.CreateCommand("[psp_HPPA_CHEK]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDAte", SqlDbType.DateTime, (DateTime) _FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDATE", SqlDbType.DateTime, (DateTime)_ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count != 0)
                {
                    MessageBox.Show("Saldo Pasif Tidak sama dengan 0");
                    GenerateExcell(ds);
                    this.Close();
                }
                
               
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

        public frmHPPAExecute(DateTime? fromDate, DateTime? toDate, DataTable dt, int update)
        {
            InitializeComponent();
            _FromDate = fromDate;
            _ToDate = toDate;
            _Update = update;
            StokList = dt;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void Execute() 
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                    int i = 0;
                    foreach (DataRow  row in StokList.Rows)
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_HPPA_EXECUTE"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, row["BarangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@update", SqlDbType.Bit, _Update));
                        db.Commands[0].Parameters.Add(new Parameter("@REcord", SqlDbType.Int, i));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        dt = db.Commands[0].ExecuteDataTable();
                        ////Cehking
                        //if (dt.Rows.Count > 0 && Tools.isNull(dt.Rows[0]["Msg"], "").ToString() != "")
                        //{
                        //    string msg_ = string.Empty;
                        //    MessageBox.Show(Tools.isNull(dt.Rows[0]["Msg"], "").ToString(), "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning );
                        //    dt.Dispose();
                        //    return;
                        //}

                        

                        if (dt.Rows.Count > 0)
                        {
                            row.BeginEdit();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row[col.ColumnName] = dt.Rows[0][col.ColumnName];
                            }
                            row.EndEdit();
                            customGridView1.CurrentCell = customGridView1.Rows[i].Cells[0];                            
                        }
                        i++;
                        progressBar1.Value = i;
                        RefreshBar();
                    }
                    if (_Update==1)
                    {
                    
                    Guid closingID = Guid.NewGuid();
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_ClosingStok_INSERT"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, closingID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, "HPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAwal", SqlDbType.DateTime, _FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhir", SqlDbType.DateTime, _ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].ExecuteNonQuery();
                    }
                }
                DisplayReport(StokList);
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)_FromDate).ToString("dd/MM/yyyy"), ((DateTime) _ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("HPPA.rptHPPA.rdlc", rptParams, dt, "dsStok_Data");
            ifrmReport.Show();

        }

        private void frmHPPAExecute_Load(object sender, EventArgs e)
        {            
            customGridView1.DataSource = StokList;
            progressBar1.Value = 0;
            progressBar1.Maximum = StokList.Rows.Count;
            lblCount.Text = progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
            StokList.Columns.Add("Ket");
            StokList.Columns.Add("Msg");
            RefreshBar();
           // ChekPasif();
        }


        private void RefreshBar()
        {
            Application.DoEvents();
            this.Invalidate();
            lblCount.Text = progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            Execute();
        }
    }
}
