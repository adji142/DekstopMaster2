using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ISA.Toko.CSM
{
    public partial class frmLaporanAnalisisOmset : ISA.Toko.BaseForm
    {

        DataTable dt = new DataTable();

        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int a = 0;
            a = Math.Abs((d1.Month - d2.Month) + 12 * (d1.Year - d2.Year));
            return a + 1;

        }


        private void GenerateExcell(DataSet ds, string flagKtg)
        {
            DataTable dt1 = new DataTable();

            dt1 = ds.Tables[0].Copy();
            DataTable dtToko = ds.Tables[0].DefaultView.ToTable(true, "kd_toko", "namatoko", "targetNom", "sts", "rd", "alamat", "kota" , "KetKunj").Copy();
            
            int mdif =  MonthDiff( txtDate1.DateValue.Value ,  txtDate2.DateValue.Value ) ;
            int tmpCol = 0; 
           

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "Laporan Analisis Omset Customer Inti";

                p.Workbook.Worksheets.Add("Laporan Analisis Omset Customer Inti");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 10 + (3 * mdif) + mdif   ;
                int startH = 11 ;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 18;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 25;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 14;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 5;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 24;
                
                tmpCol = 0;
                for (int i = 0; i < mdif; i++)
                {
                    ws.Cells[startH, 7 + (i * 3)].Worksheet.Column(7 + (i * 3)).Width = 15;
                    ws.Cells[startH, 8 + (i * 3)].Worksheet.Column(8 + (i * 3)).Width = 15;
                    ws.Cells[startH, 9 + (i * 3)].Worksheet.Column(9 + (i * 3)).Width = 15;
                    tmpCol = 9 + (i * 3);
                }
                for (int i = 0; i < mdif; i++)
                {
                    ws.Cells[startH, tmpCol + 1 + i].Worksheet.Column(tmpCol + 1 + i).Width = 15;
                }
                tmpCol = tmpCol + mdif;
                ws.Cells[startH, tmpCol + 1].Worksheet.Column(tmpCol + 1).Width = 15;
                ws.Cells[startH, tmpCol + 2].Worksheet.Column(tmpCol + 2).Width = 15;
                ws.Cells[startH, tmpCol + 3].Worksheet.Column(tmpCol + 3).Width = 70;
                ws.Cells[startH, tmpCol + 4].Worksheet.Column(tmpCol + 4).Width = 50;


                string Title = "Laporan Analisis Omset ";
                if (flagKtg == "INTI")
                {
                    Title = Title + "CUSTOMER INTI";
                }
                else if (flagKtg == "MITRAPS")
                {
                    Title = Title + "MITRA PS";
                }
                else if (flagKtg == "MITRASAS")
                {
                    Title = Title + "MITRA SAS";
                }
              
                
                string periodeLaporan = txtDate1.DateValue.Value.ToString("MMMM yyyy") + " s/d " + txtDate2.DateValue.Value.ToString("MMMM yyyy");
                



                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[3, 1, 3, MaxCol].Merge = true;

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = periodeLaporan ;
                ws.Cells[2, 1].Style.Font.Size = 14;
                ws.Cells[3, 1].Style.Font.Size = 10;

                ws.Cells[2, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[2, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[3, 1, 3, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[3, 1, 3, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                if (lookupToko1.NamaToko != "")
                {
                    ws.Cells[4, 1, 4, MaxCol].Merge = true;
                    ws.Cells[4, 1].Value = "Toko : " + lookupToko1.NamaToko;
                    ws.Cells[4, 1].Style.Font.Size = 10;
                    ws.Cells[4, 1, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, 1, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                if ( lookupSales1.NamaSales != "")
                {
                    ws.Cells[5, 1, 5, MaxCol].Merge = true;
                    ws.Cells[5, 1].Value = "Salesman : " + lookupSales1.NamaSales;
                    ws.Cells[5, 1].Style.Font.Size = 10;
                    ws.Cells[5, 1, 5, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[5, 1, 5, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                if ( txtKota.Text != "")
                {
                    ws.Cells[6, 1, 6, MaxCol].Merge = true;
                    ws.Cells[6, 1].Value = "Kota : " + txtKota.Text;
                    ws.Cells[6, 1].Style.Font.Size = 10;
                    ws.Cells[6, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[6, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }



                #region Generate Header

                ws.Cells[startH - 1, 1, startH, 1].Merge = true;
                ws.Cells[startH - 1, 1, startH, 1].Value = "Nama Toko";
                ws.Cells[startH - 1, 2, startH, 2].Merge = true;
                ws.Cells[startH - 1, 2, startH, 2].Value = "Alamat";
                ws.Cells[startH - 1, 3, startH, 3].Merge = true;
                ws.Cells[startH - 1, 3, startH, 3].Value = "Kota";
                ws.Cells[startH - 1, 4, startH,4].Merge = true;
                ws.Cells[startH - 1, 4, startH, 4].Value = "Sts";
                ws.Cells[startH - 1, 5, startH, 5].Merge = true;
                ws.Cells[startH - 1, 5, startH, 5].Value = "Rd";
                ws.Cells[startH - 1,6, startH, 6].Merge = true;
                ws.Cells[startH - 1, 6, startH, 6].Value = "Salesman";


                DateTime dtMonthYr = txtDate1.DateValue.Value;
                tmpCol = 0;
                for (int i = 0; i < mdif; i++)
                {
                    
                    ws.Cells[startH - 1, 7 + (i * 3), startH-1, 9 + (i * 3)].Merge = true;
                    ws.Cells[startH - 1, 7 + (i * 3), startH - 1, 9 + (i * 3)].Value = "Penjualan Bulan " + dtMonthYr.AddMonths(i).ToString("MMMM yyyy");
                    ws.Cells[startH, 7 + (i * 3)].Value = "A";
                    ws.Cells[startH, 8 + (i * 3)].Value = "B";
                    ws.Cells[startH, 9 + (i * 3)].Value = "C";
                    tmpCol = 9 + (i * 3) ; 
                }

                ws.Cells[startH - 1, tmpCol+1, startH - 1, tmpCol + mdif  ].Merge = true;
                ws.Cells[startH - 1, tmpCol + 1, startH - 1, tmpCol + mdif].Value = "Total Penjumlahan" ;
                for (int i = 0; i < mdif; i++)
                {
                    ws.Cells[startH, tmpCol + 1 + i].Value =  dtMonthYr.AddMonths(i).ToString("MMMM yy");
                   
                }
                tmpCol = tmpCol + mdif;
                ws.Cells[startH - 1, tmpCol + 1, startH, tmpCol + 1].Merge = true;
                ws.Cells[startH - 1, tmpCol + 1, startH, tmpCol + 1].Value = "Tertinggi";
                ws.Cells[startH - 1, tmpCol + 2, startH, tmpCol + 2].Merge = true;
                ws.Cells[startH - 1, tmpCol + 2, startH, tmpCol + 2].Value = "Target";

                 ws.Cells[startH - 1, tmpCol + 3, startH, tmpCol + 3].Merge = true;
                ws.Cells[startH - 1, tmpCol + 3, startH, tmpCol + 3].Value = "Ket Kunj.";
                ws.Cells[startH - 1, tmpCol + 4, startH, tmpCol + 4].Merge = true;
                ws.Cells[startH - 1, tmpCol + 4, startH, tmpCol + 4].Value = "Catatan";

            
                ws.Cells[startH - 1, 1, startH - 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH - 1, 1, startH - 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion


                #region FillData
                int idx = startH + 1;

                foreach (DataRow dr in dtToko.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["namatoko"];
                    ws.Cells[idx, 2].Value = dr["alamat"];
                    ws.Cells[idx, 3].Value = dr["kota"];
                    ws.Cells[idx, 4].Value = dr["sts"];
                    ws.Cells[idx, 5].Value = dr["rd"];

                    DataRow[] drS = dt1.Select("kd_toko='" + dr["kd_toko"].ToString() + "'");

                    ws.Cells[idx, 6].Value = drS[0]["NamaSales"].ToString();
                    
                    tmpCol = 0;

                    DateTime dtDAte = txtDate1.DateValue.Value;

                    for (int i = 0; i < mdif; i++)
                    {
                        
                        var Bulan = dt1.Select("kd_toko='" + dr["kd_toko"].ToString() + "' AND periodMonth='"
                        +dtDAte.AddMonths(i-1).ToString("yyyyMM")+"'");

                        double FA = 0;
                        double FB = 0;
                        double FE = 0;

                        foreach (DataRow drB in Bulan)
                        {
                            FA = FA + Convert.ToDouble(drB["FA"]);

                            FB = FB + Convert.ToDouble(drB["FB"]);

                            FE = FE + Convert.ToDouble(drB["FE"]);
                        }
                         


                        ws.Cells[idx, 7 + (i * 3)].Value = FA ;
                        ws.Cells[idx, 8 + (i * 3)].Value = FB ;
                        ws.Cells[idx, 9 + (i * 3)].Value = FE ;
                        tmpCol = 9 + (i * 3);
                    }

                    for (int i = 0; i < mdif; i++)
                    {
                        ws.Cells[idx, tmpCol + 1 + i].Formula = "SUM(" + ws.Cells[idx, 7 + (i * 3)].Address +
                                            ":" + ws.Cells[idx, 9 + (i * 3)].Address + " )";
                    }
                    tmpCol = tmpCol + mdif;

                    ws.Cells[idx, tmpCol + 1].Formula = "MAX(" + ws.Cells[idx, 7].Address +
                                            ":" + ws.Cells[idx, tmpCol ].Address + " )";
                    ws.Cells[idx, tmpCol + 2].Value = dr["targetNom"];

                    ws.Cells[idx, tmpCol + 3].Value = dr["KetKunj"];
                    ws.Cells[idx, tmpCol + 4].Value = "";
                    
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH-1, 1, startH-1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH-1,1, startH-1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws.Cells[idx, 1].Value = "Grand Total";



                tmpCol = 0;
                for (int i = 0; i < mdif; i++)
                {
                    ws.Cells[idx, 7 + (i * 3)].Formula = "Sum(" + ws.Cells[startH + 1, 7 + (i * 3)].Address +
                        ":" + ws.Cells[idx - 1, 7 + (i * 3)].Address + ")";
                    ws.Cells[idx, 8 + (i * 3)].Formula = "Sum(" + ws.Cells[startH + 1, 8 + (i * 3)].Address +
                        ":" + ws.Cells[idx - 1, 8 + (i * 3)].Address + ")";
                    ws.Cells[idx, 9 + (i * 3)].Formula = "Sum(" + ws.Cells[startH + 1, 9 + (i * 3)].Address +
                                            ":" + ws.Cells[idx - 1,9 + (i * 3)].Address + ")";

                    tmpCol = 9 + (i * 3);
                }

                for (int i = 0; i < mdif; i++)
                {
                    ws.Cells[idx, tmpCol + 1 + i].Formula = "Sum(" + ws.Cells[startH + 1, tmpCol + 1 + i].Address +
                                            ":" + ws.Cells[idx - 1, tmpCol + 1 + i].Address + ")";
                }
                tmpCol = tmpCol + mdif;

                ws.Cells[idx, tmpCol + 1].Formula = "Sum(" + ws.Cells[startH + 1, tmpCol + 1].Address +
                        ":" + ws.Cells[idx - 1, tmpCol + 1].Address + ")";
                ws.Cells[idx, tmpCol + 2].Formula = "Sum(" + ws.Cells[startH + 1, tmpCol + 2].Address +
                      ":" + ws.Cells[idx - 1, tmpCol + 2].Address + ")";

                
                ws.Cells[startH + 1, 7 , idx, MaxCol-2].Style.Numberformat.Format = "#,##0.0000;(#,##0.0000);0";


                ws.Cells[startH + 1, 5, idx, MaxCol-2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ws.Cells[startH + 1, 5, idx, MaxCol].Style.WrapText = true;
                var border = ws.Cells[startH-1, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Analisi Omset.xlsx";

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


        private void laporanAnalisiOmset(string flagKtg)
        {
            try
            {
                DataSet ds = new DataSet();
 
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CSM_LaporanAnalisisOmset"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglStart", SqlDbType.DateTime , txtDate1.DateValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@tglEnd", SqlDbType.DateTime, txtDate2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, lookupToko1.NamaToko ));
                    db.Commands[0].Parameters.Add(new Parameter("@namaSalesman", SqlDbType.VarChar, lookupSales1.NamaSales));
                    db.Commands[0].Parameters.Add(new Parameter("@namaKota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, flagKtg));               
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

               GenerateExcell(ds ,flagKtg);

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

        public frmLaporanAnalisisOmset()
        {
            InitializeComponent();
            this.Title = "Laporan Analisis Omset";
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            
                int mdif = MonthDiff(txtDate1.DateValue.Value, txtDate2.DateValue.Value);
                if (mdif <= 12)
                {
                    if (rbCustomerInti.Checked == true)
                    {
                        laporanAnalisiOmset("INTI");
                    }
                    if (rbMitraPS.Checked == true)
                    {
                        laporanAnalisiOmset("MITRAPS");
                    }
                    if (rbMitraSAS.Checked == true)
                    {
                        laporanAnalisiOmset("MITRASAS");
                    }
                    if (rbCalnCI.Checked == true)
                    {

                    }
                    if (rbRegular.Checked == true)
                    {
                        laporanAnalisiOmset("REG");
                    }
                }
                else
                {
                    MessageBox.Show("Data Terlalu Lama");
                }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanAnalisisOmset_Load(object sender, EventArgs e)
        {
            txtDate2.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtDate1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }
    }
}
