using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics; 


namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmRptMarketShare : ISA.Trading.BaseForm
    {


        #region Variables
        DataSet dsMarketShare = new DataSet();
        DataSet dsMarketShare_BlnLalu = new DataSet(); 

        DataTable dtFBFE = new DataTable();
        DataTable dtFBFE_BlnLalu = new DataTable();

        DataTable dtFBFEDaily = new DataTable();        
        DateTime _SelectedDate;
        bool newProcess = false; 
        

        #endregion

        public frmRptMarketShare()
        {
            InitializeComponent();
        }


        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dtbEnd.DateValue.HasValue)
            {
                dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1 * (dtbEnd.DateValue.Value.Day - 1));
            }
            
            try
            {
                dsMarketShare = new DataSet(); 
                dtFBFE = new DataTable();
                dtFBFEDaily = new DataTable();
                dtFBFE_BlnLalu = new DataTable();

               
                
                using (Database db = new Database())
                {

                    //Code ini akan dibuang jika transisi dari proses job sdh jalan semua 
                    //try
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_getsalesmanscoredaily_recordcount"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, dtbStart.DateValue.Value));
                    //    object objNewProcess = db.Commands[0].ExecuteScalar();
                    //    if (objNewProcess != DBNull.Value)
                    //    {
                    //        if (Convert.ToInt32(objNewProcess) >= 1 || dtbEnd.DateValue.Value.Day <=2 )
                    //        {
                    //            newProcess = true; 
                    //        }
                    //    }

                    //}
                    //catch(Exception ex) 
                    //{
                    //    Error.LogError(ex);
                    //}

                    //db.Commands.RemoveAt(0);  

                   
                    db.Commands.Add(db.CreateCommand("[rsp_LaporanMarketShare_2]"));
                    
                    
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtbStart.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtbEnd.DateValue.Value));
                    dsMarketShare = db.Commands[0].ExecuteDataSet();

                    db.Commands[0].Parameters[0].Value = dtbStart.DateValue.Value.AddMonths(-1);
                    db.Commands[0].Parameters[1].Value = dtbStart.DateValue.Value.AddDays(-1);
                    
                    dsMarketShare_BlnLalu = db.Commands[0].ExecuteDataSet();                   
                }

                dtFBFE = dsMarketShare.Tables[0].Copy();
                dtFBFEDaily = dsMarketShare.Tables[1].Copy();

                dtFBFE_BlnLalu = dsMarketShare_BlnLalu.Tables[0].Copy(); 

                if (dtFBFE.Rows.Count == 0)
                {
                    throw new Exception("Tidak Ada Data");
                }

                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Market Share.xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtbEnd_Leave(object sender, EventArgs e)
        {
            if (dtbEnd.DateValue.HasValue)
            {
                dtbStart.DateValue = dtbEnd.DateValue.Value.AddDays(-1* (dtbEnd.DateValue.Value.Day-1));                      
            }
        }



        #region Generate
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Monitoring Market Share " + string.Format("{0:MMMM yyyy}", dtbEnd.DateValue.Value);

            ex.Workbook.Worksheets.Add(dtbEnd.DateValue.Value.ToString("MMM yyyy"));
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
            //ws.Cells.Style.Font.Name = "Arial";

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 11;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
            for (int y = 3; y <= 19; y++)
            {
                ws.Cells[1, y].Worksheet.Column(y).Width = 14;
            }

            //Title Setting 
            ws.Cells[4, 1, 5, 8 + dtFBFEDaily.Rows.Count + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[1, 1, 1, 4].Merge = true;
            ws.Cells[2, 1, 2, 4].Merge = true;

            ws.Cells[4, 1, 5, 1].Merge = true;  //branch header 
            ws.Cells[4, 2, 5, 3].Merge = true;  //Monitored header 
            ws.Cells[4, 4, 4, 6].Merge = true;  //Yearly comparison header 
            ws.Cells[4, 7, 5, 7].Merge = true;  //Actual header 
            ws.Cells[4, 8, 5, 8].Merge = true;  //Daily Target header 

            ws.Cells[4, 9, 4, 8+dtFBFEDaily.Rows.Count].Merge = true;  //Omset Pertanggal header 
            ws.Cells[4, 8 + dtFBFEDaily.Rows.Count + 1, 5, 8 + dtFBFEDaily.Rows.Count + 1].Merge = true;  
            ws.Cells[4, 8 + dtFBFEDaily.Rows.Count + 2, 5, 8 + dtFBFEDaily.Rows.Count + 2].Merge = true;

            ws.Cells[6, 1, 11 , 1].Merge = true;  //Branch Value 

            var border3 = ws.Cells[4, 1, 11, 8 + dtFBFEDaily.Rows.Count+2].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[4, 1, 5, 8 + dtFBFEDaily.Rows.Count + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 6].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
            ws.Cells[4, 7, 5, 8].Style.Fill.BackgroundColor.SetColor(Color.LightPink);
            ws.Cells[4, 9, 5, 8 + dtFBFEDaily.Rows.Count+2].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);

            
            // Title
            ws.Cells[1, 1].Value = "Monitoring Market Share " + string.Format("{0:MMMM yyyy}", dtbEnd.DateValue.Value);
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", dtbStart.DateValue.Value) + " - " + string.Format("{0:dd-MM-yyyy}", dtbEnd.DateValue.Value);
            
            ws.Cells[4, 1].Value = "Branch";
            ws.Cells[4, 2].Value = "Monitored";
            
            ws.Cells[4, 4].Value = "Yearly Comparison";
            ws.Cells[5, 4].Value = "Actual";
            ws.Cells[5, 5].Value = "Budget";
            ws.Cells[5, 6].Value = "Growth Plans";
            ws.Cells[4, 7].Value = "Actual " + dtbStart.DateValue.Value.AddMonths(-1).ToString("MMM yyyy");
            ws.Cells[4, 8].Value = "Daily Target"; 
            
            for (int i = 0; i < dtFBFEDaily.Rows.Count ; i++)
            {
                ws.Cells[5, 9 + i].Value = Convert.ToDateTime(dtFBFEDaily.Rows[i]["tanggal"]).ToString("dd/MM/yyyy");
                ws.Cells[5, 9 + i].Worksheet.Column(9 + i).Width = 18; 
            }

            ws.Cells[4, 8 + dtFBFEDaily.Rows.Count + 1 ].Value = "% Achv vs Grwth Plan" ;
            ws.Cells[4, 8 + dtFBFEDaily.Rows.Count + 2].Value = "Dev Dec 2012 vs Budget";
            
            ws.Cells[6, 1].Value = dtFBFE.Rows[0]["initgudang"].ToString();

            //===============================================Omset===============================================
            ws.Cells[6, 2].Value = "OMSET";
            ws.Cells[6, 2, 7, 2].Merge = true;

            ws.Cells[6, 3].Value = "R2";
            ws.Cells[7, 3].Value = "R4";

            ws.Cells[6, 4].Value = Convert.ToDouble(dtFBFE.Rows[0]["RpNetto"]);
            ws.Cells[6, 4].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            ws.Cells[6 , 4 , 7 , 4].Merge = true;


            ws.Cells[6, 5].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetNominal"]);
            ws.Cells[6, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            ws.Cells[6, 5, 7, 5].Merge = true;

            ws.Cells[6, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR2"]);
            ws.Cells[6, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            ws.Cells[7, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR4"]);
            ws.Cells[7, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


            ws.Cells[6, 7].Value = Convert.ToDouble(dtFBFE_BlnLalu.Rows[0]["RpNetto"]); 
            ws.Cells[6, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            ws.Cells[6, 7, 7, 7].Merge = true;


            ws.Cells[6, 8].Formula = "(" + ws.Cells[6, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day + ")";
            ws.Cells[6, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            ws.Cells[7, 8].Formula = "(" + ws.Cells[7, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day + ")";
            ws.Cells[7, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            double actualOmsetKumulatifR4 = 0;
            double actualOmsetKumulatifR2 = 0; 

            for (int i = 0; i < dtFBFEDaily.Rows.Count; i++)
            {
                //actualOmsetKumulatifR2 = actualOmsetKumulatifR2 + Convert.ToDouble(dtFBFEDaily.Rows[i]["RpNettoR2"]);
                //actualOmsetKumulatifR4 = actualOmsetKumulatifR4 + Convert.ToDouble(dtFBFEDaily.Rows[i]["RpNettoR2"]);

                ws.Cells[6, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["RpNettoR2"]);
                ws.Cells[7, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["RpNettoR4"]);
   
                ws.Cells[6, 9 + i].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[7, 9 + i].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

            }

            ws.Cells[6, 8 + dtFBFEDaily.Rows.Count + 1].Value = (actualOmsetKumulatifR2/ Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR2"])*100) ;
            ws.Cells[7, 8 + dtFBFEDaily.Rows.Count + 1].Value = (actualOmsetKumulatifR4 / Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR4"]) * 100);

            ws.Cells[6, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            ws.Cells[7, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


            ws.Cells[6, 8 + dtFBFEDaily.Rows.Count + 2].Value = actualOmsetKumulatifR2 - Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR2"]); 
            ws.Cells[7, 8 + dtFBFEDaily.Rows.Count + 2].Value = actualOmsetKumulatifR4 - Convert.ToDouble(dtFBFE.Rows[0]["TargetNominalR4"]); 

            ws.Cells[6, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
            ws.Cells[7, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";



            //===============================================OA===============================================
            ws.Cells[8, 2].Value = "OA";
            ws.Cells[8, 2, 9, 2].Merge = true;

            ws.Cells[8, 3].Value = "R2";
            ws.Cells[9, 3].Value = "R4";


            ws.Cells[8, 4].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalToko"]);
            ws.Cells[8, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[8, 4, 9, 4].Merge = true;


            ws.Cells[8, 5].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetOA"]);
            ws.Cells[8, 5].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[8, 5, 9, 5].Merge = true;

            ws.Cells[8, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR2"]);
            ws.Cells[8, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[9, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR4"]);
            ws.Cells[9, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";


            ws.Cells[8, 7].Value = Convert.ToDouble(dtFBFE_BlnLalu.Rows[0]["TotalToko"]);
            ws.Cells[8, 7].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[8, 7, 9, 7].Merge = true;


            ws.Cells[8, 8].Formula = "(" + ws.Cells[8, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day  + ")";
            ws.Cells[8, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[9, 8].Formula = "(" + ws.Cells[9, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day  + ")";
            ws.Cells[9, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";

            double actualOAKumulatifR4 = 0;
            double actualOAKumulatifR2 = 0;

            for (int i = 0; i < dtFBFEDaily.Rows.Count; i++)
            {

                ws.Cells[8, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["TotalTokoKumulatifR2"]);
                ws.Cells[9, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["TotalTokoKumulatifR4"]);

                ws.Cells[8, 9 + i].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[9, 9 + i].Style.Numberformat.Format = "#,##0;(#,##0);0";

            }

            ws.Cells[8, 8 + dtFBFEDaily.Rows.Count + 1].Value = (Convert.ToDouble(dtFBFE.Rows[0]["TotalTokoR2"]) / Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR2"]) * 100);
            ws.Cells[9, 8 + dtFBFEDaily.Rows.Count + 1].Value = (Convert.ToDouble(dtFBFE.Rows[0]["TotalTokoR4"]) / Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR4"]) * 100);

            ws.Cells[8, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[9, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0;(#,##0);0";


            ws.Cells[8, 8 + dtFBFEDaily.Rows.Count + 2].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalTokoR2"]) - Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR2"]);
            ws.Cells[9, 8 + dtFBFEDaily.Rows.Count + 2].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalTokoR2"]) - Convert.ToDouble(dtFBFE.Rows[0]["TargetOAR4"]);

            ws.Cells[8, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[9, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0;(#,##0);0";

            

            
            //================================================SKU===============================================
            
            ws.Cells[10, 2].Value = "SKU";
            ws.Cells[10, 2, 11, 2].Merge = true;

            ws.Cells[10, 3].Value = "R2";
            ws.Cells[11, 3].Value = "R4";


            ws.Cells[10, 4].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalItem"]);
            ws.Cells[10, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[10, 4, 11, 4].Merge = true;


            ws.Cells[10, 5].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetSKU"]);
            ws.Cells[10, 5].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[10, 5, 11, 5].Merge = true;

            ws.Cells[10, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR2"]);
            ws.Cells[10, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[11, 6].Value = Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR4"]);
            ws.Cells[11, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";


            ws.Cells[10, 7].Value = Convert.ToDouble(dtFBFE_BlnLalu.Rows[0]["TotalItem"]);
            ws.Cells[10, 7].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[10, 7, 11, 7].Merge = true;


            ws.Cells[10, 8].Formula = "(" + ws.Cells[10, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day  + ")";
            ws.Cells[10, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[11, 8].Formula = "(" + ws.Cells[11, 6].Address + "/ " + dtbStart.DateValue.Value.AddMonths(1).AddDays(-1).Day + ")";
            ws.Cells[11, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";

            double actualSKUKumulatifR4 = 0;
            double actualSKUKumulatifR2 = 0;

            for (int i = 0; i < dtFBFEDaily.Rows.Count; i++)
            {

                ws.Cells[10, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["TotalSKUKumulatifR2"]);
                ws.Cells[11, 9 + i].Value = Convert.ToDouble(dtFBFEDaily.Rows[i]["TotalSKUKumulatifR4"]);

                ws.Cells[10, 9 + i].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[11, 9 + i].Style.Numberformat.Format = "#,##0;(#,##0);0";

            }

            ws.Cells[10, 8 + dtFBFEDaily.Rows.Count + 1].Value = (Convert.ToDouble(dtFBFE.Rows[0]["TotalItemR2"]) / Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR2"]) * 100);
            ws.Cells[11, 8 + dtFBFEDaily.Rows.Count + 1].Value = (Convert.ToDouble(dtFBFE.Rows[0]["TotalItemR4"]) / Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR4"]) * 100);

            ws.Cells[10, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[11, 8 + dtFBFEDaily.Rows.Count + 1].Style.Numberformat.Format = "#,##0;(#,##0);0";


            ws.Cells[10, 8 + dtFBFEDaily.Rows.Count + 2].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalItemR2"]) - Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR2"]);
            ws.Cells[11, 8 + dtFBFEDaily.Rows.Count + 2].Value = Convert.ToDouble(dtFBFE.Rows[0]["TotalItemR4"]) - Convert.ToDouble(dtFBFE.Rows[0]["TargetSKUR4"]);

            ws.Cells[10, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0;(#,##0);0";
            ws.Cells[11, 8 + dtFBFEDaily.Rows.Count + 2].Style.Numberformat.Format = "#,##0;(#,##0);0";

            if (newProcess == true)
            {
                ws.Cells[16, 1].Value = "..";
            }
            else
            {
                ws.Cells[16, 1].Value = ".";
            }



            return ex;

        }
        #endregion 

        private void frmRptMarketShare_Load(object sender, EventArgs e)
        {
            dtbEnd.DateValue = GlobalVar.DateOfServer.Date.AddDays(-1);  
        }


    }
}
