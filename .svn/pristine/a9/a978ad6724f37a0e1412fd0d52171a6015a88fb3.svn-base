using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Toko.Laporan.Salesman
{
    public partial class frmRptReturJualHI : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();
        public frmRptReturJualHI()
        {
            InitializeComponent();
        }

        private void FillCbo()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtCabang = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add("");
                dtCabang.DefaultView.Sort = "CabangID ASC";

                cboCab1.DataSource = dtCabang;
                cboCab1.DisplayMember = "Concatenated";
                cboCab1.ValueMember = "CabangID";

                cboCab2.DataSource = dtCabang;
                cboCab2.DisplayMember = "Concatenated";
                cboCab2.ValueMember = "CabangID";
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
        
        private void frmRptReturJualHI_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;

            FillCbo();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Laporan_Salesman_ReturHI]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, GlobalVar.CabangID));


                    ds = db.Commands[0].ExecuteDataSet();


                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                GenerateExcell(ds);



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

        private int GetIdx(DataRowView dr)
        {
            int idx = 0;
            //DataTable dt = dtKLP.Copy();
            //dt.DefaultView.RowFilter = "KLP='"+KLP+"'";

            //idx = Convert.ToInt32(Tools.isNull(dt.DefaultView.ToTable().Rows[0]["IDX"],"0").ToString());
            idx = Convert.ToInt32(dr["IDX"]);
            return idx;
        }

        private void GenerateExcell(DataSet ds)
        {

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "RETUR JUAL HUBUNGAN ISTIMEWA";


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 1 +8 + (ds.Tables[1].Rows.Count * 2)  + 1 + 1;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12;

                int Lcol = 9;
                for (int i = 2; i <= MaxCol; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 14;
                }
                ws.Cells[1, 6].Worksheet.Column(6).Width = 30;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 40;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 35;
                ws.Cells[1, MaxCol].Worksheet.Column(MaxCol).Width = 15;


                string periode = "PERIODE : " +
                                   rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy") + "  S.D  " +
                                   rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy");

                ws.Cells[1, 1].Value = "RETUR JUAL HUBUNGAN ISTIMEWA";
                ws.Cells[2, 1].Value = periode;
                ws.Cells[3, 1].Value = "";// Convert.ToDouble(ds.Tables[0].Compute("SUM(HargaSatuan)", string.Empty));
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[1, 1, 3, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 3, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 3, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 12;


                #region Generate Header

                ws.Cells[4, 2].Value = "C1";
                ws.Cells[4, 3].Value = "C2";
                ws.Cells[4, 4].Value = "Tanggal";
                ws.Cells[4, 5].Value = "No.Nota";
                ws.Cells[4, 6].Value = "Kd.Sales";
                ws.Cells[4, 7].Value = "Nama Toko";
                ws.Cells[4, 8].Value = "Kota";
                ws.Cells[4, 9].Value = "Nilai Retur (Rp)";

                ws.Cells[4, MaxCol-1].Value = "HPPA"; ws.Cells[4, MaxCol-1, 5, MaxCol].Merge = true;
                ws.Cells[6, MaxCol-1].Value = "PCS";
                ws.Cells[6, MaxCol ].Value = "Nilai";

                DataTable dtCol = ds.Tables[1].Copy();
                int y = 1;
                string Ket = string.Empty;

                DataTable dKet = dtCol.DefaultView.ToTable(true, "Keterangan", "N").Copy();


                foreach (DataRowView dv in dKet.DefaultView)
                {
                    ws.Cells[4, y + Lcol].Value =dv[0].ToString();
                    ws.Cells[4, y + Lcol, 4, y + Lcol + (Convert.ToInt32(dv["n"])*2)-1].Merge = true;
                    y = y + (Convert.ToInt32(dv["n"])*2);
                }
                y = 1;
                for (int i = 1; i <= dtCol.Rows.Count; i++)
                {
                    
                    ws.Cells[5, y + Lcol].Value = dtCol.Rows[i - 1][1].ToString();
                    ws.Cells[6, y + Lcol].Value = "Pcs";
                    ws.Cells[6, y + Lcol +1 ].Value = "Nilai";

                    ws.Cells[5, y+Lcol, 5, y+Lcol+1].Merge = true;
                    y +=2;

                    //ws.Cells[4, i + Lcol].Worksheet.Column(i + 3).Width = 15;
                }

                for (int i = 2; i <= 9;i++ )
                {
                    ws.Cells[4, i, 6, i].Merge = true;
                }
                //ws.Cells[4, MaxCol, 4, MaxCol].Merge = true;
                ws.Cells[4, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[4, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData

                DataTable dtHeader = new DataTable();
                dtHeader = ds.Tables[0].Copy();
              

                DataTable dtRows = new DataTable();
                dtRows = dtHeader.DefaultView.ToTable(true, "RowID", "Cabang1", "Cabang2", "TglGudang", "NoNotaRetur", "KodeSales", "NamaToko", "Kota","RpNilai2","QtyALL","HPP").Copy();
                string RowID_ = string.Empty;

                int idx = 7;
                foreach (DataRow dr in dtRows.Rows)
                {
                    ws.Cells[idx, 2].Value = dr["Cabang1"];
                    ws.Cells[idx, 3].Value = dr["Cabang2"];
                    ws.Cells[idx, 4].Value = dr["TglGudang"];
                    ws.Cells[idx, 5].Value = dr["NoNotaRetur"];
                    ws.Cells[idx, 6].Value = dr["KodeSales"];
                    ws.Cells[idx, 7].Value = dr["NamaToko"].ToString().Trim();
                    ws.Cells[idx, 8].Value = dr["Kota"].ToString().Trim();
                    ws.Cells[idx, 9].Value = dr["RpNilai2"];
                    ws.Cells[idx, MaxCol-1].Value = dr["QtyALL"];
                    ws.Cells[idx, MaxCol].Value = dr["HPP"];
 
                    RowID_ = dr["RowID"].ToString();
                    dtHeader.DefaultView.RowFilter = "RowID='" + RowID_ + "'";
                    int x = 0;

                    foreach (DataRowView dv in dtHeader.DefaultView)
                    {
                        if (GetIdx(dv) > 0)
                        {
                            x = GetIdx(dv)*2;

                            ws.Cells[idx, x -   1 + Lcol].Value = Convert.ToInt32(dv["QtyGudang"]);
                            ws.Cells[idx, x + Lcol].Value = Convert.ToDouble(dv["HrgNetto2"]);

                        }
                    }

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[4, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[4, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[7, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[idx, 2].Value = "TOTAL";
                ws.Cells[idx, 2, idx, 8].Merge = true;
                ws.Cells[idx, 2, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 2, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);


                for (int i = 9; i <= MaxCol; i++)
                {
                    ws.Cells[idx, i  ].Formula = "Sum(" + ws.Cells[7, i].Address +
                        ":" + ws.Cells[idx - 1, i ].Address + ")";
                }



                //ws.Cells[idx, MaxCol].Formula = "Sum(" + ws.Cells[idx, 4].Address +
                //           ":" + ws.Cells[idx, MaxCol - 1].Address + ")";

                //for (int j = 1; j < idx - 3; j++)
                //{
                //    ws.Cells[j + 4, MaxCol].Formula = "SUM(" + ws.Cells[j + 4, 4].Address +
                //      ":" + ws.Cells[j + 4, MaxCol - 1].Address + ")";
                //}
                ws.Cells[7, 9, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[7, 9, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[7, 9, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[5, 4, idx, MaxCol].Style.WrapText = true;
                var border = ws.Cells[4, 2, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Retur HI.xlsx";

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

    }
}
