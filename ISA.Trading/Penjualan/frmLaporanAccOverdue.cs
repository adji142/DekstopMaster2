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
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.Penjualan
{
    public partial class frmLaporanAccOverdue : ISA.Controls.BaseForm
    {
        string periode = string.Empty;
        DateTime _fromDate;
        DateTime _toDate;
        DataSet dsData = new DataSet();

        public frmLaporanAccOverdue()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanAccOverdue_Load(object sender, EventArgs e)
        {
            SetControl();
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
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            periode = txtYear.Value.ToString().PadLeft(4, '0') + (cboMonth.SelectedIndex + 1).ToString().PadLeft(2, '0');
            _fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
            _toDate = _fromDate.AddMonths(1).AddDays(-1);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_HistAcc_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
                if (dsData.Tables[0].Rows.Count > 0)
                    DisplayReport(_fromDate, _toDate);
                else
                    MessageBox.Show("Data tidak ada");
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


        private void DisplayReport(DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapHistAcc(fromdate_, todate_));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_HistoryAcc";

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

        private ExcelPackage LapHistAcc(DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Histtory Acc Overdue";
            ex.Workbook.Properties.SetCustomPropertyValue("Acc DO", "1147");

            ex.Workbook.Worksheets.Add("Laporan");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
            ws.Cells[1, 6].Worksheet.Column(5).Width = 7;
            ws.Cells[1, 7].Worksheet.Column(6).Width = 15;
            ws.Cells[1, 8].Worksheet.Column(7).Width = 15;
            ws.Cells[1, 9].Worksheet.Column(8).Width = 15;
            ws.Cells[1, 10].Worksheet.Column(9).Width = 15;
            ws.Cells[1, 11].Worksheet.Column(10).Width = 15;
            ws.Cells[1, 12].Worksheet.Column(11).Width = 15;
            ws.Cells[1, 13].Worksheet.Column(12).Width = 15;
            ws.Cells[1, 14].Worksheet.Column(13).Width = 15;
            ws.Cells[1, 15].Worksheet.Column(14).Width = 35;
            ws.Cells[1, 16].Worksheet.Column(15).Width = 75;
            ws.Cells[1, 17].Worksheet.Column(16).Width = 25;
            ws.Cells[1, 18].Worksheet.Column(17).Width = 15;

            int rowAcc = 0, nHeader = 0, rowx = 0;

            #region Laporan
            if (dsData.Tables[0].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAcc = nHeader + 2;
                rowx = rowAcc;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " LAPORAN HISTORY ACC ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;

                int MaxCol = 17;
                double nRpDo = 0, nRpAcc = 0, nOvdBE = 0, nOvdSbl = 0;

                ws.Cells[rowx, 2].Value = " No DO ";
                ws.Cells[rowx, 3].Value = " TGL DO ";
                ws.Cells[rowx, 4].Value = " OVD BE ";
                ws.Cells[rowx, 5].Value = " KET ";
                ws.Cells[rowx, 6].Value = " Rp.DO ";
                ws.Cells[rowx, 7].Value = " Rp.ACC ";
                ws.Cells[rowx, 8].Value = " PLAFON ";
                ws.Cells[rowx, 9].Value = " PIUTANG ";
                ws.Cells[rowx, 10].Value = " GIT ";
                ws.Cells[rowx, 11].Value = " GIRO ";
                ws.Cells[rowx, 12].Value = " GIRO TOLAK ";
                ws.Cells[rowx, 13].Value = " KODE SALES ";
                ws.Cells[rowx, 14].Value = " NAMA TOKO ";
                ws.Cells[rowx, 15].Value = " ALAMAT ";
                ws.Cells[rowx, 16].Value = " KOTA ";
                ws.Cells[rowx, 17].Value = " IDWIl ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr1 in dsData.Tables[0].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr1["NoDO"], "");
                    ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));

                    if (Tools.isNull(dr1["pin"], "").ToString() != "1")
                        ws.Cells[rowx, 4].Value = Tools.isNull(dr1["OvBE"], "");
                    else
                        ws.Cells[rowx, 4].Value = "0";

                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr1["pin"], "");
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr1["SumRpNet"], 0);
                    ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 7].Value = Tools.isNull(dr1["SumRpNet"], 0);
                    ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 8].Value = Tools.isNull(dr1["plf_fb"], 0);
                    ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 9].Value = Tools.isNull(dr1["Piutang"], 0);
                    ws.Cells[rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 10].Value = Tools.isNull(dr1["Git"], 0);
                    ws.Cells[rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 11].Value = Tools.isNull(dr1["Giro"], 0);
                    ws.Cells[rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 12].Value = Tools.isNull(dr1["GiroTolak"], 0);
                    ws.Cells[rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 13].Value = Tools.isNull(dr1["KodeSales"], "");
                    ws.Cells[rowx, 14].Value = Tools.isNull(dr1["NamaToko"], "");
                    ws.Cells[rowx, 15].Value = Tools.isNull(dr1["Alamat"], "");
                    ws.Cells[rowx, 16].Value = Tools.isNull(dr1["Kota"], "");
                    ws.Cells[rowx, 17].Value = Tools.isNull(dr1["WilID"], "");

                    nRpDo = nRpDo + Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], 0));
                    nRpAcc = nRpAcc + Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], 0));

                    if (Tools.isNull(dr1["pin"], "").ToString() != "1")
                        nOvdBE = nOvdBE + Convert.ToDouble(Tools.isNull(dr1["OvdBE"], 0));

                    nOvdSbl = nOvdSbl + Convert.ToDouble(Tools.isNull(dr1["OvdSBL"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Jumlah".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;

                ws.Cells[rowx, 4].Value = Tools.isNull(nOvdBE, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;

                ws.Cells[rowx, 6].Value = Tools.isNull(nRpDo, 0);
                ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 6].Style.Font.Bold = true;

                ws.Cells[rowx, 7].Value = Tools.isNull(nRpAcc, 0);
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 7].Style.Font.Bold = true;

                var border = ws.Cells[rowAcc + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAcc, 2, rowAcc, MaxCol].Style.Border;
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

                nHeader = rowx;
            }
            #endregion
            return ex;
        }
    }
}
