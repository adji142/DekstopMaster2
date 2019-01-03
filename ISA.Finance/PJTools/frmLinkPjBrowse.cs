using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.PJTools
{
    public partial class frmLinkPJBrowse : ISA.Finance.BaseForm
    {
        string periode;
        DataTable dtc = new DataTable();
        DataTable dtPj = new DataTable();
        DataTable dtAC1 = new DataTable();
        //DataTable dtAG = new DataTable();
        //DataTable dtAC = new DataTable();
        DataTable dtPJProcess = new DataTable();
        //DataTable dtAGProcess = new DataTable();
        DataTable dtACProcess = new DataTable();
        DateTime fromDate;
        DateTime toDate;

        DataSet dsData = new DataSet();
        DataSet dsDbms = new DataSet();
        DataSet dsDbst = new DataSet();

        DataTemplates.dsPenjualan.DataDataTable dtRekapPj = new dsPenjualan.DataDataTable();

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();
        int jmlNota=0;
        bool link = true;
        string RecodID_ = "";
        Guid HeadID;

        public frmLinkPJBrowse()
        {
            InitializeComponent();
        }

        private void SetControl()
        {
            DateTimeFormatInfo formatInfo = new DateTimeFormatInfo();
            foreach (string month in formatInfo.MonthNames)
            {
                cboMonth.Items.Add(month);
            }
            if (cboMonth.Items.Count > 0)
            {
                cboMonth.SelectedIndex = DateTime.Now.AddMonths(-1).Month - 1;
            }
            txtYear.Value = DateTime.Now.AddMonths(-1).Year;
            lookupGudang1.GudangID = GlobalVar.Gudang;
            txtInitPrsh.Text = GlobalVar.PerusahaanID;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lookupGudang1.NamaGudang = Tools.isNull(dt.Rows[0]["NamaGudang"].ToString(), "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        
        }

        private void frmLinkPJBrowse_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //dtJurnalH = new dsJurnal.JournalDataTable();
                //dtJurnalD = new dsJurnal.JournalDetailDataTable();

                periode = txtYear.Value.ToString().PadLeft(4, '0') + (cboMonth.SelectedIndex + 1).ToString().PadLeft(2, '0');
                fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
                
                //MessageBox.Show(periode.ToString());

                //if (ISA.Finance.Class.PeriodeClosing.IsHPPClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsPJTClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))

                if (ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))
                {
                    MessageBox.Show(string.Format(Messages.Error.AlreadyClosingPJT, periode));
                    return;
                }

                Pj2gl();
                MessageBox.Show("Proses Selesai...!");

                //GET DATA
                //GetPJData();                
                //DisplayReport();
                //PREPARE DATA
                //PreparePJData();
                ////PrepareAC1Data();
                //PROCESS DATA
                /////ProcessPJData();
                //ProcessAC1Data();
                
                /*                
                if (dtJurnalH.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
                }

                cmdOk.Enabled = false;
                if (!DataHasProblem())
                {
                    //DISPLAY RESULT
                    DataTable dtRekapJurnalD = dtJurnalD.Copy();

                    DisplayReportRekap(dtRekapJurnalD, dtRekapPj);

                    dtJurnalD.DefaultView.Sort = "DK, NoPerkiraan";
                    frmLinkPjExecute ifrmChild = new frmLinkPjExecute(toDate, lookupGudang1.GudangID, dtJurnalH, dtJurnalD);
                    ifrmChild.Show();
                }
                 */
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

        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(lapPJ2GL());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "PJ2GL" + GlobalVar.Gudang;
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


        private ExcelPackage lapPJ2GL()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "PJTOOLS";
            ex.Workbook.Properties.SetCustomPropertyValue("PJTOOLS", "1147");

            #region sheet 1
            ex.Workbook.Worksheets.Add("Journal");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 12;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 30;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 40;

            // Title
            ws.Cells[2, 2].Value = "REKAP PENJUALAN & GIT - ANTAR CABANG";
            ws.Cells[2, 2].Style.Font.Bold = true;
            ws.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[3, 2].Value = "Periode     : "+ string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[3, 2].Style.Font.Bold = true;
            ws.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Header
            ws.Cells[4, 2].Value = " KODE ";
            ws.Cells[4, 3].Value = " PERKIRAAN ";
            ws.Cells[4, 4].Value = " DEBET ";
            ws.Cells[4, 5].Value = " KREDIT ";
            ws.Cells[4, 6].Value = " KETERANGAN ";

            int MaxCol = 6;
            int rowz = 4;
            int rowx = rowz + 1;
            double JmlD = 0, JmlK = 0;
           
            ws.Cells[4, 2, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[4, 2, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[4, 2, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 2, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            foreach (DataRow dr1 in dsData.Tables[1].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr1["NoPerkiraan"],"");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr1["NaPerkiraan"],"");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr1["debet"],0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr1["kredit"],0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 6].Value = Tools.isNull(dr1["uraian"],"");
                rowx++;
                JmlD = JmlD + Convert.ToDouble(Tools.isNull(dr1["Debet"],0));
                JmlK = JmlK + Convert.ToDouble(Tools.isNull(dr1["Kredit"],0));
            }

            foreach (DataRow dr2 in dsData.Tables[2].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr2["NoPerkiraan"],"");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr2["NaPerkiraan"],"");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr2["debet"],0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr2["kredit"],0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 6].Value = Tools.isNull(dr2["uraian"],"");
                rowx++;
                JmlD = JmlD + Convert.ToDouble(Tools.isNull(dr2["Debet"], 0));
                JmlK = JmlK + Convert.ToDouble(Tools.isNull(dr2["Kredit"], 0));
            }

            foreach (DataRow dr3 in dsData.Tables[3].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr3["NoPerkiraan"],"");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr3["NaPerkiraan"],"");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr3["debet"],0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr3["kredit"],0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 6].Value = Tools.isNull(dr3["uraian"],"");
                rowx++;
                JmlD = JmlD + Convert.ToDouble(Tools.isNull(dr3["Debet"], 0));
                JmlK = JmlK + Convert.ToDouble(Tools.isNull(dr3["Kredit"], 0));
            }

            foreach (DataRow dr4 in dsData.Tables[4].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr4["NoPerkiraan"],"");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr4["NaPerkiraan"],"");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr4["debet"],0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr4["kredit"],0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 6].Value = Tools.isNull(dr4["uraian"],"");
                rowx++;
                JmlD = JmlD + Convert.ToDouble(Tools.isNull(dr4["Debet"], 0));
                JmlK = JmlK + Convert.ToDouble(Tools.isNull(dr4["Kredit"], 0));
            }

            ws.Cells[rowx, 2].Value = "Jumlah";
            ws.Cells[rowx, 2].Style.Font.Bold = true;
            ws.Cells[rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[rowx, 4].Value = Tools.isNull(JmlD, 0);
            ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 4].Style.Font.Bold = true;
            ws.Cells[rowx, 5].Value = Tools.isNull(JmlK,0);
            ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 5].Style.Font.Bold = true;

            var border = ws.Cells[rowz + 1, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowz, 2, rowz, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region sheet 2
            ex.Workbook.Worksheets.Add("PJ");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

            // Width
            ws2.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 10;
            ws2.Cells[1, 4].Worksheet.Column(4).Width = 13;
            ws2.Cells[1, 5].Worksheet.Column(5).Width = 13;
            ws2.Cells[1, 6].Worksheet.Column(6).Width = 13;
            ws2.Cells[1, 7].Worksheet.Column(7).Width = 13;
            ws2.Cells[1, 8].Worksheet.Column(8).Width = 7;
            ws2.Cells[1, 9].Worksheet.Column(9).Width = 5;
            ws2.Cells[1, 10].Worksheet.Column(10).Width = 13;
            ws2.Cells[1, 11].Worksheet.Column(11).Width = 30;
            ws2.Cells[1, 12].Worksheet.Column(12).Width = 20;
            ws2.Cells[1, 13].Worksheet.Column(13).Width = 11;
            ws2.Cells[1, 14].Worksheet.Column(14).Width = 15;

            ws2.Cells[2, 2].Value = "PENJUALAN & GIT";
            ws2.Cells[2, 2].Style.Font.Bold = true;
            ws2.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws2.Cells[3, 2].Style.Font.Bold = true;
            ws2.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2].Value = " CAB1 ";
            ws2.Cells[4, 3].Value = " NO NOTA ";
            ws2.Cells[4, 4].Value = " TGL NOTA ";
            ws2.Cells[4, 5].Value = " TGL PL ";
            ws2.Cells[4, 6].Value = " TGL SJ ";
            ws2.Cells[4, 7].Value = " TGL TRM ";
            ws2.Cells[4, 8].Value = " KD TR ";
            ws2.Cells[4, 9].Value = " JW ";
            ws2.Cells[4, 10].Value = " KD SALES ";
            ws2.Cells[4, 11].Value = " NAMA TOKO ";
            ws2.Cells[4, 12].Value = " KOTA ";
            ws2.Cells[4, 13].Value = " IDWIL ";
            ws2.Cells[4, 14].Value = " NOMINAL ";

            int MaxCol2 = 14;
            rowz = 4;
            int rowx2 = rowz + 1;

            ws2.Cells[4, 2, 4, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[4, 2, 4, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[4, 2, 4, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            double Nominal = 0;

            foreach (DataRow dr0 in dsData.Tables[0].Rows)
            {
                ws2.Cells[rowx2, 2].Value = Tools.isNull(dr0["Cabang1"], "");
                ws2.Cells[rowx2, 3].Value = Tools.isNull(dr0["NoSuratJalan"], "");
                ws2.Cells[rowx2, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglNota"], ""));
                ws2.Cells[rowx2, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglPl"], ""));
                ws2.Cells[rowx2, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglSuratJalan"], ""));
                ws2.Cells[rowx2, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglTerima"], ""));
                ws2.Cells[rowx2, 8].Value = Tools.isNull(dr0["TransactionType"], "");
                ws2.Cells[rowx2, 9].Value = Tools.isNull(dr0["HariKredit"], 0);
                ws2.Cells[rowx2, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx2, 10].Value = Tools.isNull(dr0["KodeSales"], "");
                ws2.Cells[rowx2, 11].Value = Tools.isNull(dr0["NamaToko"], "");
                ws2.Cells[rowx2, 12].Value = Tools.isNull(dr0["Kota"], "");
                ws2.Cells[rowx2, 13].Value = Tools.isNull(dr0["WilID"], "");
                ws2.Cells[rowx2, 14].Value = Tools.isNull(dr0["nominal"], 0);
                ws2.Cells[rowx2, 14].Style.Numberformat.Format = "#,##;(#,##);0";
                rowx2++;
                Nominal = Nominal + Convert.ToDouble(Tools.isNull(dr0["nominal"], 0));
            }

            ws2.Cells[rowx2, 13].Value = "Jumlah";
            ws2.Cells[rowx2, 13].Style.Font.Bold = true;
            ws2.Cells[rowx2, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[rowx2, 14].Value = Tools.isNull(Nominal, 0);
            ws2.Cells[rowx2, 14].Style.Font.Bold = true;
            ws2.Cells[rowx2, 14].Style.Numberformat.Format = "#,##;(#,##);0";

            var border2 = ws2.Cells[rowz + 1, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.None;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowz, 2, rowz, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            border2 = ws2.Cells[rowx2, 2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style = ExcelBorderStyle.Thin;
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, 2, rowx2, 2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style = ExcelBorderStyle.Thin;
            border2.Right.Style = ExcelBorderStyle.None;

            border2 = ws2.Cells[rowx2, MaxCol2, rowx2, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            int nSheet = 2;

            #region : Tidak ada master toko (tabel 5)
            int x = 0;
            x = dsData.Tables[5].Rows.Count;
            if (x > 0)
            {
                nSheet = nSheet + 1;
                ex.Workbook.Worksheets.Add("NoToko");
                ExcelWorksheet ws3 = ex.Workbook.Worksheets[nSheet];

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 2;     //Kosong
                ws3.Cells[1, 1].Worksheet.Column(2).Width = 10;     //NoDo
                ws3.Cells[1, 2].Worksheet.Column(3).Width = 13;     //TglDO
                ws3.Cells[1, 3].Worksheet.Column(4).Width = 10;     //NoNota
                ws3.Cells[1, 4].Worksheet.Column(5).Width = 13;     //TglNota
                ws3.Cells[1, 5].Worksheet.Column(6).Width = 20;     //KodeToko
                ws3.Cells[1, 6].Worksheet.Column(7).Width = 30;     //NamaToko
                ws3.Cells[1, 7].Worksheet.Column(8).Width = 40;     //Alamat
                ws3.Cells[1, 8].Worksheet.Column(9).Width = 20;     //Kota
                ws3.Cells[1, 9].Worksheet.Column(10).Width = 7;     //WilID

                ws3.Cells[2, 2].Value = "PENJUALAN TIDAK ADA DITABEL TOKO";
                ws3.Cells[2, 2].Style.Font.Bold = true;
                ws3.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws3.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws3.Cells[3, 2].Style.Font.Bold = true;
                ws3.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws3.Cells[4, 2].Value = " NODO ";
                ws3.Cells[4, 3].Value = " TGL DO ";
                ws3.Cells[4, 4].Value = " NO NOTA ";
                ws3.Cells[4, 5].Value = " TGL NOTA ";
                ws3.Cells[4, 6].Value = " KODE TOKO ";
                ws3.Cells[4, 7].Value = " NAMA TOKO ";
                ws3.Cells[4, 8].Value = " ALAMAT ";
                ws3.Cells[4, 9].Value = " KOTA ";
                ws3.Cells[4, 10].Value = " IDWIL ";

                int MaxCol3 = 10;
                rowz = 4;
                int rowx3 = rowz + 1;

                ws3.Cells[4, 2, 4, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[4, 2, 4, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[4, 2, 4, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                foreach (DataRow dr5 in dsData.Tables[5].Rows)
                {
                    ws3.Cells[rowx3, 2].Value = Tools.isNull(dr5["NoDo"], "");
                    ws3.Cells[rowx3, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr5["TglDo"], ""));
                    ws3.Cells[rowx3, 4].Value = Tools.isNull(dr5["NoSuratJalan"], "");
                    ws3.Cells[rowx3, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr5["TglSuratJalan"], ""));
                    ws3.Cells[rowx3, 6].Value = Tools.isNull(dr5["KodeToko"], "");
                    ws3.Cells[rowx3, 7].Value = Tools.isNull(dr5["NamaToko"], "");
                    ws3.Cells[rowx3, 8].Value = Tools.isNull(dr5["Alamat"], "");
                    ws3.Cells[rowx3, 9].Value = Tools.isNull(dr5["Kota"], "");
                    ws3.Cells[rowx3, 10].Value = Tools.isNull(dr5["WilID"], "");
                    rowx3++;
                }

                var border3 = ws3.Cells[rowz + 1, 2, rowx3, MaxCol3].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style = ExcelBorderStyle.None;
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                border3 = ws3.Cells[rowz, 2, rowz, MaxCol3].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                border3 = ws3.Cells[rowx3, 2, rowx3, MaxCol3].Style.Border;
                border3.Bottom.Style = ExcelBorderStyle.None;
                border3.Top.Style = ExcelBorderStyle.Thin;
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.None;
            }
            #endregion


            #region : Tidak ada Idwil (tabel 6)
            int y = 0;
            y = dsData.Tables[6].Rows.Count;
            if (y > 0)
            {
                nSheet = nSheet + 1;
                ex.Workbook.Worksheets.Add("NoWilID");
                ExcelWorksheet ws4 = ex.Workbook.Worksheets[nSheet];

                ws4.Cells[1, 1].Worksheet.Column(1).Width =  2;     //Kosong
                ws4.Cells[1, 2].Worksheet.Column(2).Width = 10;     //NoDo
                ws4.Cells[1, 3].Worksheet.Column(3).Width = 13;     //TglDO
                ws4.Cells[1, 4].Worksheet.Column(4).Width = 10;     //NoNota
                ws4.Cells[1, 5].Worksheet.Column(5).Width = 13;     //TglNota
                ws4.Cells[1, 6].Worksheet.Column(6).Width = 20;     //KodeToko
                ws4.Cells[1, 7].Worksheet.Column(7).Width = 30;     //NamaToko
                ws4.Cells[1, 8].Worksheet.Column(8).Width = 40;     //Alamat
                ws4.Cells[1, 9].Worksheet.Column(9).Width = 20;     //Kota
                ws4.Cells[1,10].Worksheet.Column(10).Width = 7;     //WilID

                ws4.Cells[2, 2].Value = "TOKO TIDAK ADA IDWIL";
                ws4.Cells[2, 2].Style.Font.Bold = true;
                ws4.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws4.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws4.Cells[3, 2].Style.Font.Bold = true;
                ws4.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws4.Cells[4, 2].Value = " NODO ";
                ws4.Cells[4, 3].Value = " TGL DO ";
                ws4.Cells[4, 4].Value = " NO NOTA ";
                ws4.Cells[4, 5].Value = " TGL NOTA ";
                ws4.Cells[4, 6].Value = " KODE TOKO ";
                ws4.Cells[4, 7].Value = " NAMA TOKO ";
                ws4.Cells[4, 8].Value = " ALAMAT ";
                ws4.Cells[4, 9].Value = " KOTA ";
                ws4.Cells[4,10].Value = " IDWIL ";

                int MaxCol4 = 10;
                rowz = 4;
                int rowx4 = rowz + 1;

                ws4.Cells[4, 2, 4, MaxCol4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws4.Cells[4, 2, 4, MaxCol4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws4.Cells[4, 2, 4, MaxCol4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws4.Cells[4, 2, 4, MaxCol4].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                foreach (DataRow dr6 in dsData.Tables[6].Rows)
                {
                    ws4.Cells[rowx4, 2].Value = Tools.isNull(dr6["NoDo"], "");
                    ws4.Cells[rowx4, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr6["TglDo"], ""));
                    ws4.Cells[rowx4, 4].Value = Tools.isNull(dr6["NoSuratJalan"], "");
                    ws4.Cells[rowx4, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr6["TglSuratJalan"], ""));
                    ws4.Cells[rowx4, 6].Value = Tools.isNull(dr6["KodeToko"], "");
                    ws4.Cells[rowx4, 7].Value = Tools.isNull(dr6["NamaToko"], "");
                    ws4.Cells[rowx4, 8].Value = Tools.isNull(dr6["Alamat"], "");
                    ws4.Cells[rowx4, 9].Value = Tools.isNull(dr6["Kota"], "");
                    ws4.Cells[rowx4, 10].Value = Tools.isNull(dr6["WilID"], "");
                    rowx4++;
                }

                var border4 = ws4.Cells[rowz + 1, 2, rowx4, MaxCol4].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style = ExcelBorderStyle.None;
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

                border4 = ws4.Cells[rowz, 2, rowz, MaxCol4].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

                border4 = ws4.Cells[rowx4, 2, rowx4, MaxCol4].Style.Border;
                border4.Bottom.Style = ExcelBorderStyle.None;
                border4.Top.Style = ExcelBorderStyle.Thin;
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.None;
            }
            #endregion


            #region : Tidak ada master Stok (tabel 7)
            int z = 0;
            z = dsData.Tables[7].Rows.Count;
            if (z > 0)
            {
                nSheet = nSheet + 1;
                ex.Workbook.Worksheets.Add("NoStok");
                ExcelWorksheet ws5 = ex.Workbook.Worksheets[nSheet];

                ws5.Cells[1, 1].Worksheet.Column(1).Width = 2;     //Kosong
                ws5.Cells[1, 2].Worksheet.Column(2).Width = 10;     //NoDo
                ws5.Cells[1, 3].Worksheet.Column(3).Width = 13;     //TglDO
                ws5.Cells[1, 4].Worksheet.Column(4).Width = 10;     //NoNota
                ws5.Cells[1, 5].Worksheet.Column(5).Width = 13;     //TglNota
                ws5.Cells[1, 6].Worksheet.Column(6).Width = 20;     //BarangID
                ws5.Cells[1, 7].Worksheet.Column(7).Width = 30;     //Namastok

                ws5.Cells[2, 2].Value = "PENJUALAN TIDAK ADA MASTER STOK";
                ws5.Cells[2, 2].Style.Font.Bold = true;
                ws5.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws5.Cells[3, 2].Value = "Periode     : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws5.Cells[3, 2].Style.Font.Bold = true;
                ws5.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws5.Cells[4, 2].Value = " NODO ";
                ws5.Cells[4, 3].Value = " TGL DO ";
                ws5.Cells[4, 4].Value = " NO NOTA ";
                ws5.Cells[4, 5].Value = " TGL NOTA ";
                ws5.Cells[4, 6].Value = " ID BRG ";
                ws5.Cells[4, 7].Value = " NAMA STOK ";

                int MaxCol5 = 7;
                rowz = 4;
                int rowx5 = rowz + 1;

                ws5.Cells[4, 2, 4, MaxCol5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws5.Cells[4, 2, 4, MaxCol5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws5.Cells[4, 2, 4, MaxCol5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[4, 2, 4, MaxCol5].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                foreach (DataRow dr7 in dsData.Tables[7].Rows)
                {
                    ws5.Cells[rowx5, 2].Value = Tools.isNull(dr7["NoDo"], "");
                    ws5.Cells[rowx5, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr7["TglDo"], ""));
                    ws5.Cells[rowx5, 4].Value = Tools.isNull(dr7["NoSuratJalan"], "");
                    ws5.Cells[rowx5, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr7["TglSuratJalan"], ""));
                    ws5.Cells[rowx5, 6].Value = Tools.isNull(dr7["BarangID"], "");
                    ws5.Cells[rowx5, 7].Value = Tools.isNull(dr7["NamaStok"], "");
                    rowx5++;
                }

                var border5 = ws5.Cells[rowz + 1, 2, rowx5, MaxCol5].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style = ExcelBorderStyle.None;
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

                border5 = ws5.Cells[rowz, 2, rowz, MaxCol5].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

                border5 = ws5.Cells[rowx5, 2, rowx5, MaxCol5].Style.Border;
                border5.Bottom.Style = ExcelBorderStyle.None;
                border5.Top.Style = ExcelBorderStyle.Thin;
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.None;
            }
            #endregion


            #region : Missing Detail
            int p = 0;
            p = dsData.Tables[8].Rows.Count;
            if (p > 0)
            {
                nSheet = nSheet + 1;
                ex.Workbook.Worksheets.Add("NoDetail");
                ExcelWorksheet ws6 = ex.Workbook.Worksheets[nSheet];
                ws6.Cells[1, 1].Worksheet.Column(1).Width =  2;     //Kosong
                ws6.Cells[1, 2].Worksheet.Column(2).Width = 10;     //NoDo
                ws6.Cells[1, 3].Worksheet.Column(3).Width = 13;     //TglDO
                ws6.Cells[1, 4].Worksheet.Column(4).Width = 10;     //NoNota
                ws6.Cells[1, 5].Worksheet.Column(5).Width = 13;     //TglNota
                ws6.Cells[1, 6].Worksheet.Column(6).Width = 20;     //KodeToko
                ws6.Cells[1, 7].Worksheet.Column(7).Width = 50;     //NamaToko
                ws6.Cells[1, 8].Worksheet.Column(8).Width = 30;     //Kota

                ws6.Cells[2, 2].Value = "PENJUALAN TIDAK ADA DETAIL";
                ws6.Cells[2, 2].Style.Font.Bold = true;
                ws6.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws6.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws6.Cells[3, 2].Style.Font.Bold = true;
                ws6.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws6.Cells[4, 2].Value = " NODO ";
                ws6.Cells[4, 3].Value = " TGL DO ";
                ws6.Cells[4, 4].Value = " NO NOTA ";
                ws6.Cells[4, 5].Value = " TGL NOTA ";
                ws6.Cells[4, 6].Value = " KODE TOKO ";
                ws6.Cells[4, 7].Value = " NAMA TOKO ";
                ws6.Cells[4, 8].Value = " KOTA ";

                int MaxCol6 = 8;
                rowz = 4;
                int rowx6 = rowz + 1;

                ws6.Cells[4, 2, 4, MaxCol6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws6.Cells[4, 2, 4, MaxCol6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws6.Cells[4, 2, 4, MaxCol6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws6.Cells[4, 2, 4, MaxCol6].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                foreach (DataRow dr8 in dsData.Tables[8].Rows)
                {
                    ws6.Cells[rowx6, 2].Value = Tools.isNull(dr8["NoDo"], "");
                    ws6.Cells[rowx6, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr8["TglDo"], ""));
                    ws6.Cells[rowx6, 4].Value = Tools.isNull(dr8["NoSuratJalan"], "");
                    ws6.Cells[rowx6, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr8["TglSuratJalan"], ""));
                    ws6.Cells[rowx6, 6].Value = Tools.isNull(dr8["KodeToko"], "");
                    ws6.Cells[rowx6, 7].Value = Tools.isNull(dr8["NamaToko"], "");
                    ws6.Cells[rowx6, 8].Value = Tools.isNull(dr8["Kota"], "");
                    rowx6++;
                }

                var border6 = ws6.Cells[rowz + 1, 2, rowx6, MaxCol6].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style = ExcelBorderStyle.None;
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

                border6 = ws6.Cells[rowz, 2, rowz, MaxCol6].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style =
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

                border6 = ws6.Cells[rowx6, 2, rowx6, MaxCol6].Style.Border;
                border6.Bottom.Style = ExcelBorderStyle.None;
                border6.Top.Style = ExcelBorderStyle.Thin;
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.None;
            }
            #endregion


            #region : Nota beda dengan Piutang
            int q = 0;
            q = dsData.Tables[9].Rows.Count;
            if (q > 0)
            {
                nSheet = nSheet + 1;
                ex.Workbook.Worksheets.Add("Beda");
                ExcelWorksheet ws7 = ex.Workbook.Worksheets[nSheet];

                ws7.Cells[1, 1].Worksheet.Column(1).Width = 2;     //Kosong
                ws7.Cells[1, 2].Worksheet.Column(2).Width = 10;     //NoDo
                ws7.Cells[1, 3].Worksheet.Column(3).Width = 13;     //TglDO
                ws7.Cells[1, 4].Worksheet.Column(4).Width = 10;     //NoNota
                ws7.Cells[1, 5].Worksheet.Column(5).Width = 13;     //TglNota
                ws7.Cells[1, 6].Worksheet.Column(6).Width = 20;     //KodeToko
                ws7.Cells[1, 7].Worksheet.Column(7).Width = 50;     //NamaToko
                ws7.Cells[1, 8].Worksheet.Column(8).Width = 30;     //Kota
                ws7.Cells[1, 9].Worksheet.Column(9).Width = 12;     //RpNota
                ws7.Cells[1, 10].Worksheet.Column(10).Width = 12;    //RpPiutang
                ws7.Cells[1, 11].Worksheet.Column(11).Width = 12;    //Selisih

                ws7.Cells[2, 2].Value = "BEDA NILAI ANTARA NOTA DENGAN PIUTANG";
                ws7.Cells[2, 2].Style.Font.Bold = true;
                ws7.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws7.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws7.Cells[3, 2].Style.Font.Bold = true;
                ws7.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //Header
                ws7.Cells[4, 2].Value = " NODO ";
                ws7.Cells[4, 3].Value = " TGL DO ";
                ws7.Cells[4, 4].Value = " NO NOTA ";
                ws7.Cells[4, 5].Value = " TGL NOTA ";
                ws7.Cells[4, 6].Value = " KODE TOKO ";
                ws7.Cells[4, 7].Value = " NAMA TOKO ";
                ws7.Cells[4, 8].Value = " KOTA ";
                ws7.Cells[4, 9].Value = " Rp NOTA ";
                ws7.Cells[4, 10].Value = " Rp PIUTANG ";
                ws7.Cells[4, 11].Value = " SELISIH ";

                int MaxCol7 = 11;
                rowz = 4;
                int rowx7 = rowz + 1;

                ws7.Cells[4, 2, 4, MaxCol7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws7.Cells[4, 2, 4, MaxCol7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws7.Cells[4, 2, 4, MaxCol7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws7.Cells[4, 2, 4, MaxCol7].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                foreach (DataRow dr9 in dsData.Tables[9].Rows)
                {
                    ws7.Cells[rowx7, 2].Value = Tools.isNull(dr9["NoDo"], "");
                    ws7.Cells[rowx7, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr9["TglDo"], ""));
                    ws7.Cells[rowx7, 4].Value = Tools.isNull(dr9["NoSuratJalan"], "");
                    ws7.Cells[rowx7, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr9["TglSuratJalan"], ""));
                    ws7.Cells[rowx7, 6].Value = Tools.isNull(dr9["KodeToko"], "");
                    ws7.Cells[rowx7, 7].Value = Tools.isNull(dr9["NamaToko"], "");
                    ws7.Cells[rowx7, 8].Value = Tools.isNull(dr9["Kota"], "");
                    ws7.Cells[rowx7, 9].Value = Tools.isNull(dr9["nominal"], 0);
                    ws7.Cells[rowx7, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws7.Cells[rowx7,10].Value = Tools.isNull(dr9["piutang"], 0);
                    ws7.Cells[rowx7,10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws7.Cells[rowx7,11].Value = Convert.ToDouble(Tools.isNull(dr9["nominal"], 0)) - Convert.ToDouble(Tools.isNull(dr9["piutang"], 0));
                    ws7.Cells[rowx7,11].Style.Numberformat.Format = "#,##;(#,##);0";
                    rowx7++;
                }

                var border7 = ws7.Cells[rowz + 1, 2, rowx7, MaxCol7].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style = ExcelBorderStyle.None;
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

                border7 = ws7.Cells[rowz, 2, rowz, MaxCol7].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style =
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

                border7 = ws7.Cells[rowx7, 2, rowx7, MaxCol7].Style.Border;
                border7.Bottom.Style = ExcelBorderStyle.None;
                border7.Top.Style = ExcelBorderStyle.Thin;
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.None;
            }
            #endregion
            return ex;
        }


        private DataRow InsertJournalHeader(Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag, double debet, double kredit)
        {
            dsJurnal.JournalRow hdrNew = (dsJurnal.JournalRow)dtJurnalH.NewRow();
            hdrNew.RowID = rowID;
            hdrNew.RecordID = recordID;
            hdrNew.Tanggal = tanggal;
            hdrNew.NoReff = noReff;
            hdrNew.Uraian = uraian;
            hdrNew.Src = src;
            hdrNew.KodeGudang = kodeGudang;
            hdrNew.SyncFlag = syncFlag;
            hdrNew.Debet = debet;
            hdrNew.Kredit = kredit;
            dtJurnalH.Rows.Add(hdrNew);
            return (DataRow)hdrNew;
        }

        private DataRow InsertJournalDetail(Guid rowID, Guid headerID, string recordID, string hRecordID, string noPerkiraan, string uraian, double debet, double kredit, string DK)
        {
            dsJurnal.JournalDetailRow dtlNew = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
            dtlNew.RowID = rowID;
            dtlNew.HeaderID = headerID;
            dtlNew.RecordID = recordID;
            dtlNew.HRecordID = hRecordID;
            dtlNew.NoPerkiraan = noPerkiraan;
            dtlNew.Uraian = uraian;
            dtlNew.Debet = debet;
            dtlNew.Kredit = kredit;
            dtlNew.DK = DK;
            dtJurnalD.Rows.Add(dtlNew);
            return (DataRow)dtlNew;
        }


        private bool DataHasProblem()
        {
            bool valid = false;

            using (Database db = new Database(GlobalVar.DBName ))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_Nota_Bermasalah"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID ));
                dsDbms = db.Commands[0].ExecuteDataSet();

                //Get Barang Unregistered (done)
                //Nota tanpa ID WIL (done)
                //Nota yang Nol (done)
                //Nota yang tidak punya toko (done)
                //Nota yang nilainya beda dengan piutang (done)
                //Nota missing detail (done)
            }
            if (dsDbms.Tables.Count > 0)
            {
                valid = true;
            }
            return valid;
        }


        private void GetPJData()
        {          
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dtPj = db.Commands[0].ExecuteDataTable();
                dtPj.DefaultView.Sort = "NoSuratJalan";
            }
        }

        //private void GetAC1Data()
        
        private void Pj2gl()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetPenjualan_GIT"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                dsData = db.Commands[0].ExecuteDataSet();
            }
            if (dsData.Tables.Count > 0)
            {
                bool link = true;
                if (dsData.Tables[5].Rows.Count > 0 || dsData.Tables[6].Rows.Count > 0 || dsData.Tables[7].Rows.Count > 0
                    || dsData.Tables[8].Rows.Count > 0 || dsData.Tables[9].Rows.Count > 0)
                    link = false;

                DisplayReport();
                
                if (link)
                {
                    DialogResult jawab = MessageBox.Show("Link ke GL ?","Konfirmasi", MessageBoxButtons.YesNo);
                    if (jawab == DialogResult.Yes)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        int x = 0;

                        if (dsData.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in dsData.Tables[1].Rows)
                            {
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                    RecodID_ = GlobalVar.PerusahaanID +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                               Tools.isNull(dr1["kdtr"], "").ToString();

                                    string NoReff_ = Tools.isNull(dr1["kdtr"], "").ToString() + "-" +
                                                     string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                     string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr1["uraian"], "").ToString()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr1["kdtr"], "").ToString()));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }
                            }
                        }


                        // Detail : GIT Bulan ini
                        if (dsData.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow drd in dsData.Tables[1].Rows)
                            {
                                dtc = new DataTable();
                                using (Database dbc = new Database(GlobalVar.DBName))
                                {
                                    dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                    dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                    dtc = dbc.Commands[0].ExecuteDataTable();
                                }

                                if (dtc.Rows.Count > 0)
                                {
                                    HeadID = (Guid)(dtc.Rows[0]["RowID"]);
                                }
                                else
                                {
                                    HeadID = RowID_;
                                }

                                Guid _RowID = Guid.NewGuid();

                                using (Database dbd = new Database(GlobalVar.DBName))
                                {
                                    dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                    RecodID_ = GlobalVar.PerusahaanID +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                               Tools.isNull(drd["kdtr"], "").ToString();
                                    x++;
                                    string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "001" + x.ToString().PadLeft(6, '0');

                                    dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"],"")));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                    dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                    dbd.Commands[0].ExecuteNonQuery();
                                    dbd.CommitTransaction();
                                }
                            }
                        }
                        else if (dsData.Tables[2].Rows.Count > 0)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) + "PJ2";
                                           //Tools.isNull(dr1["kdtr"], "").ToString();

                                string NoReff_ = "PJ2-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                //string NoReff_ = Tools.isNull(dr1["kdtr"], "").ToString() + "-" +
                                //                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                //                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Penjualan Antar Cabang")); // Tools.isNull(dr1["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "PJ2")); // Tools.isNull(dr1["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        
                        // Detail : Piutang wilayah
                        if (dsData.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dre in dsData.Tables[2].Rows)
                            {
                                dtc = new DataTable();
                                using (Database dbc = new Database(GlobalVar.DBName))
                                {
                                    dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                    dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                    dtc = dbc.Commands[0].ExecuteDataTable();
                                }

                                if (dtc.Rows.Count > 0)
                                {
                                    HeadID = (Guid)(dtc.Rows[0]["RowID"]);
                                }
                                else
                                {
                                    HeadID = RowID_;
                                }

                                Guid _RowIDGITbl = Guid.NewGuid();

                                using (Database dbe = new Database(GlobalVar.DBName))
                                {
                                    dbe.Commands.Add(dbe.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                    RecodID_ = GlobalVar.PerusahaanID +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                               Tools.isNull(dre["kdtr"], "").ToString();
                                    x++;
                                    string _RecodID = RecodID_ + Tools.isNull(dre["dk"], "") + "001" + x.ToString().PadLeft(6, '0');

                                    dbe.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDGITbl));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dre["NoPerkiraan"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dre["uraian"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dre["debet"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dre["kredit"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(dre["dk"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                    dbe.Commands[0].ExecuteNonQuery();
                                    dbe.CommitTransaction();
                                }
                            }
                        }

                        // Detail : GIT bulan lalu
                        if (dsData.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dre in dsData.Tables[3].Rows)
                            {
                                dtc = new DataTable();
                                using (Database dbc = new Database(GlobalVar.DBName))
                                {
                                    dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                    dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                    dtc = dbc.Commands[0].ExecuteDataTable();
                                }

                                if (dtc.Rows.Count > 0)
                                {
                                    HeadID = (Guid)(dtc.Rows[0]["RowID"]);
                                }
                                else
                                {
                                    HeadID = RowID_;
                                }

                                Guid _RowID = Guid.NewGuid();

                                using (Database dbe = new Database(GlobalVar.DBName))
                                {
                                    dbe.Commands.Add(dbe.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                    RecodID_ = GlobalVar.PerusahaanID +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                               Tools.isNull(dre["kdtr"], "").ToString();
                                    x++;
                                    string _RecodID = RecodID_ + Tools.isNull(dre["dk"], "") + "001" + x.ToString().PadLeft(6, '0');

                                    dbe.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dre["NoPerkiraan"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dre["uraian"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dre["debet"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dre["kredit"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(dre["dk"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                    dbe.Commands[0].ExecuteNonQuery();
                                    dbe.CommitTransaction();
                                }
                            }
                        }


                        // Detail : Penjualan antar cabang
                        if (dsData.Tables[4].Rows.Count > 0)
                        {
                            foreach (DataRow dre in dsData.Tables[4].Rows)
                            {
                                dtc = new DataTable();
                                using (Database dbc = new Database(GlobalVar.DBName))
                                {
                                    dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                    dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                    dtc = dbc.Commands[0].ExecuteDataTable();
                                }

                                if (dtc.Rows.Count > 0)
                                {
                                    HeadID = (Guid)(dtc.Rows[0]["RowID"]);
                                }
                                else
                                {
                                    HeadID = RowID_;
                                }

                                Guid _RowID = Guid.NewGuid();

                                using (Database dbe = new Database(GlobalVar.DBName))
                                {
                                    dbe.Commands.Add(dbe.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                    RecodID_ = GlobalVar.PerusahaanID +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                               string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                               Tools.isNull(dre["kdtr"], "").ToString();
                                    x++;
                                    string _RecodID = RecodID_ + Tools.isNull(dre["dk"], "") + "001" + x.ToString().PadLeft(6, '0');

                                    dbe.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dre["NoPerkiraan"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dre["uraian"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dre["debet"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dre["kredit"], 0)));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(dre["dk"], "")));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                    dbe.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                    dbe.Commands[0].ExecuteNonQuery();
                                    dbe.CommitTransaction();
                                }
                            }
                        }

                        // Update ClosingStok \\
                        try
                        {
                            DataTable dt = new DataTable();
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_CloseUpdate"));
                                db.Commands[0].Parameters.Add(new Parameter("@kodetr", SqlDbType.VarChar, "PJT"));
                                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, fromDate));
                                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, toDate));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tidak Ada Data");
            }

        }

        private void PreparePJData()
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add ("Kode", typeof(System.String));
            dtResult.Columns.Add("Tipe", typeof(System.String));
            dtResult.Columns.Add("Debet", typeof(System.Double));
            dtResult.Columns.Add("Kredit", typeof(System.Double));
            dtResult.Columns.Add("DK", typeof(System.String));
            dtResult.Columns.Add("NoPerkiraan", typeof(System.String));
            dtResult.Columns.Add("NamaPerkiraan", typeof(System.String));
            DataColumn[] pkResult = new DataColumn[1];
            pkResult[0] = dtResult.Columns["Kode"];
            dtResult.PrimaryKey = pkResult;

            string prevNota = "";
            string curNota = "";
            jmlNota = 0;

            foreach (DataRow dr in dtPj.Rows)
            {
                curNota = dr["NoSuratJalan"].ToString();
                if (prevNota != curNota)
                {
                    
                    jmlNota++;

                    DataRow drRekap = dtRekapPj.NewRow();
                    drRekap["NoSuratJalan"] = dr["NoSuratJalan"];
                    drRekap["Tipe"] = "PJ";
                    drRekap["Total"] = dtPj.Compute("SUM(Total)","NoSuratJalan='" + dr["NoSuratJalan"].ToString() + "'");
                    
                    dtRekapPj.Rows.Add(drRekap);
                }
                prevNota = curNota;

                if (dr["WilID"].ToString()== "")
                {
                    throw new Exception("No Surat Jalan " + dr["NoSuratJalan"].ToString() + " Tidak ada WilID");
                }


                DataRow drWilFind = dtResult.Rows.Find(dr["WilID"].ToString().Substring(0, 1));
                DataRow drWilCur = drWilFind;

                bool isWilRegistered = false;
                if (drWilFind != null)
                {
                    if (drWilFind["Tipe"].ToString() == "WilID")
                    {
                        isWilRegistered = true;
                    }
                }
                if (!isWilRegistered)
                {
                    DataRow drNew = dtResult.NewRow();
                    drNew["Kode"] = dr["WilID"].ToString().Substring(0,1);
                    drNew["Tipe"] = "WilID";
                    drNew["Debet"] = 0;
                    drNew["Kredit"] = 0;
                    drNew["DK"] = "D";
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dtWilPerkiraan=Perkiraan.GetPerkiraanKoneksiDetail("COL" + dr["WilID"].ToString().Substring(0,1));
                        drNew["NoPerkiraan"] = dtWilPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                        drNew["NamaPerkiraan"] = dtWilPerkiraan.Rows[0]["Uraian"].ToString();
                    }
                    dtResult.Rows.Add(drNew);
                    drWilCur = drNew;                    
                }
                drWilCur["Debet"] = double.Parse(drWilCur["Debet"].ToString()) + (double.Parse(dr["HrgJualNet"].ToString()) * int.Parse(dr["QtySuratJalan"].ToString()));


                DataRow drBrgFind = dtResult.Rows.Find(dr["KelompokBrgID"]);
                DataRow drBrgCur = drBrgFind;


                bool isBrgRegistered = false;
                if (drBrgFind != null)
                {
                    if (drBrgFind["Tipe"].ToString() == "KelompokBrgID")
                    {
                        isBrgRegistered = true;
                    }
                }
                if (!isBrgRegistered)
                {
                    DataRow drNew = dtResult.NewRow();
                    drNew["Kode"] = dr["KelompokBrgID"].ToString();
                    drNew["Tipe"] = "KelompokBrgID";
                    drNew["Debet"] = 0;
                    drNew["Kredit"] = 0;
                    drNew["DK"] = "K";
                    DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                    drNew["NoPerkiraan"] = dtKlpBarang.Rows[0]["NoPerk"].ToString();
                    drNew["NamaPerkiraan"] = dtKlpBarang.Rows[0]["NamaPerkiraan"].ToString();
                    dtResult.Rows.Add(drNew);
                    drBrgCur = drNew;
                }
                drBrgCur["Kredit"] = double.Parse(drBrgCur["Kredit"].ToString()) + (double.Parse(dr["HrgJualNet"].ToString()) * int.Parse(dr["QtySuratJalan"].ToString()));


                
            }
            dtPJProcess = dtResult;
        }

 
        private void PrepareAC1Data()
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Kode", typeof(System.String));
            dtResult.Columns.Add("Tipe", typeof(System.String));
            dtResult.Columns.Add("Debet", typeof(System.Double));
            dtResult.Columns.Add("Kredit", typeof(System.Double));
            dtResult.Columns.Add("DK", typeof(System.String));
            dtResult.Columns.Add("NoPerkiraan", typeof(System.String));
            dtResult.Columns.Add("NamaPerkiraan", typeof(System.String));
            DataColumn[] pkResult = new DataColumn[1];
            pkResult[0] = dtResult.Columns["Kode"];
            dtResult.PrimaryKey = pkResult;

            string prevNota = "";
            string curNota = "";
            jmlNota = 0;
            if (dtAC1.Rows.Count > 0)
            {
                foreach (DataRow dr in dtAC1.Rows)
                {
                    curNota = dr["NoSuratJalan"].ToString();
                    if (prevNota != curNota)
                    {                        
                        jmlNota++;

                        DataRow drRekap = dtRekapPj.NewRow();
                        drRekap["NoSuratJalan"] = dr["NoSuratJalan"];
                        drRekap["Tipe"] = "AC";
                        drRekap["Total"] = dtAC1.Compute("SUM(Total)", "NoSuratJalan='" + dr["NoSuratJalan"].ToString() + "'");
                        dtRekapPj.Rows.Add(drRekap);
                    }
                    prevNota = curNota;
                    if (dr["WilID"].ToString() == "")
                    {
                        throw new Exception("No Surat Jalan " + dr["NoSuratJalan"].ToString() + " Tidak ada WilID");
                    }

                    DataRow drWilFind = dtResult.Rows.Find(dr["WilID"].ToString().Substring(0, 1));
                    DataRow drWilCur = drWilFind;


                    bool isWilRegistered = false;
                    if (drWilFind != null)
                    {
                        if (drWilFind["Tipe"].ToString() == "WilID")
                        {
                            isWilRegistered = true;
                        }
                    }
                    if (!isWilRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["Kode"] = dr["WilID"].ToString().Substring(0, 1);
                        drNew["Tipe"] = "WilID";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "D";
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dtWilPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("COL" + dr["WilID"].ToString().Substring(0, 1));
                            drNew["NoPerkiraan"] = dtWilPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                            drNew["NamaPerkiraan"] = dtWilPerkiraan.Rows[0]["Uraian"].ToString();
                        }
                        dtResult.Rows.Add(drNew);
                        drWilCur = drNew;
                    }
                    drWilCur["Debet"] = double.Parse(drWilCur["Debet"].ToString()) + (double.Parse(dr["HrgJualNet"].ToString()) * int.Parse(dr["QtySuratJalan"].ToString()));


                    DataRow drBrgFind = dtResult.Rows.Find(dr["KelompokBrgID"]);
                    DataRow drBrgCur = drBrgFind;


                    bool isBrgRegistered = false;
                    if (drBrgFind != null)
                    {
                        if (drBrgFind["Tipe"].ToString() == "KelompokBrgID")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["Kode"] = dr["KelompokBrgID"].ToString();
                        drNew["Tipe"] = "KelompokBrgID";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "K";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = dtKlpBarang.Rows[0]["NoPerk"].ToString();
                        drNew["NamaPerkiraan"] = dtKlpBarang.Rows[0]["NamaPerkiraan"].ToString();
                        dtResult.Rows.Add(drNew);
                        drBrgCur = drNew;
                    }
                    drBrgCur["Kredit"] = double.Parse(drBrgCur["Kredit"].ToString()) + (double.Parse(dr["HrgJualNet"].ToString()) * int.Parse(dr["QtySuratJalan"].ToString()));
                }
                dtACProcess = dtResult;
            }
        }

        private void ProcessPJData()
        {
            Guid headerID = Guid.NewGuid();
            string headerRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            string hReff="ADJPJ" + toDate.ToString("yyyyMMdd") ;
            string hUraian = string.Format( "PENJUALAN KREDIT {0} LEMBAR Per {1}" , jmlNota.ToString("#,##0"),lookupGudang1.GudangID);
            string hSrc ="PJ3";

            if (dtPJProcess.Rows.Count > 0)
            {
                double qtyWil = Convert.ToDouble(dtPJProcess.Compute("SUM(Debet)", "Tipe='WilID'"));
                double qtyBrg = Convert.ToDouble(dtPJProcess.Compute("SUM(Kredit)", "Tipe='KelompokBrgID'"));



                InsertJournalHeader(headerID, headerRecID, toDate, hReff, hUraian, hSrc, lookupGudang1.GudangID, false, qtyWil, qtyBrg);

                foreach (DataRow dr in dtPJProcess.Rows)
                {
                    Guid dRowID = Guid.NewGuid();
                    string dNoPerk = dr["NoPerkiraan"].ToString();
                    string dUraian = dr["NamaPerkiraan"].ToString();
                    double dDebet = Convert.ToDouble(dr["Debet"]);
                    double dKredit = Convert.ToDouble(dr["Kredit"]);
                    string dDK = dr["DK"].ToString();
                    string dRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    InsertJournalDetail(dRowID, headerID, dRecID, headerRecID, dNoPerk, dUraian, dDebet, dKredit, dDK);
                }
            }
        }


        private void ProcessAC1Data()
        {
            Guid headerID = Guid.NewGuid();
            string headerRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            string hReff = "ADJPJ" + toDate.ToString("yyyyMMdd");
            string hUraian = string.Format("PENJUALAN KREDIT {0} LEMBAR Per {1}", jmlNota.ToString("#,##0"), lookupGudang1.GudangID);
            string hSrc = "PJ3";


            double qtyWil = (double)dtACProcess.Compute("SUM(Debet)", "Tipe='WilID'");
            double qtyBrg = (double)dtACProcess.Compute("SUM(Kredit)", "Tipe='KelompokBrgID'");



            InsertJournalHeader(headerID, headerRecID, toDate, hReff, hUraian, hSrc, lookupGudang1.GudangID, false, qtyWil, qtyBrg);

            foreach (DataRow dr in dtACProcess.Rows)
            {
                Guid dRowID = Guid.NewGuid();
                string dNoPerk = dr["NoPerkiraan"].ToString();
                string dUraian = dr["NamaPerkiraan"].ToString();
                double dDebet = (double)dr["Debet"];
                double dKredit = (double)dr["Kredit"];
                string dDK = dr["DK"].ToString();
                string dRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                InsertJournalDetail(dRowID, headerID, dRecID, headerRecID, dNoPerk, dUraian, dDebet, dKredit, dDK);
            }
        }

        /*
        private void DisplayReportBermasalah(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", fromDate.ToString("dd/MM/yyyy"), toDate.ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PJTools.rptNotaBermasalah.rdlc", rptParams, dt, "dsPenjualan_Data");
            ifrmReport.Show();
        }*/

        private void DisplayReportRekap(DataTable dtJournal, DataTable dtPenjualan)
        {
        
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", fromDate.ToString("dd/MM/yyyy"), toDate.ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("LbrNota", jmlNota.ToString("#,##0")));

            //List Data Table
            List<DataTable> dtList = new List<DataTable>();
            dtList.Add(dtJournal);
            dtList.Add(dtPenjualan);

            //List DataSet Name
            List<string> datasetName = new List<string>();
            datasetName.Add("dsJurnal_Data");
            datasetName.Add("dsPenjualan_Data");

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PJTools.rptRekapJournalPJ.rdlc", rptParams, dtList, datasetName);
            
            ifrmReport.Show();
        }

        private void cmdLink2gl_Click(object sender, EventArgs e)
        {
            try
            {
                if (dsData.Tables.Count > 0)
                {
                    MessageBox.Show("Masuk dep");
                }
                else
                {
                    MessageBox.Show("Gagal dep");
                }

                /*
                this.Cursor = Cursors.WaitCursor;

                dtJurnalH = new dsJurnal.JournalDataTable();
                dtJurnalD = new dsJurnal.JournalDetailDataTable();
                
                periode = txtYear.Value.ToString().PadLeft(4, '0') + (cboMonth.SelectedIndex + 1).ToString().PadLeft(2, '0');
                fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);

                Pj2gl();

                if (dtJurnalH.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
                }

                cmdOk.Enabled = false;
                if (!DataHasProblem())
                {
                    DataTable dtRekapJurnalD = dtJurnalD.Copy();
                    DisplayReportRekap(dtRekapJurnalD, dtRekapPj);
                    dtJurnalD.DefaultView.Sort = "DK, NoPerkiraan";
                    frmLinkPjExecute ifrmChild = new frmLinkPjExecute(toDate, lookupGudang1.GudangID, dtJurnalH, dtJurnalD);
                    ifrmChild.Show();
                }
                 */
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
    }
}
