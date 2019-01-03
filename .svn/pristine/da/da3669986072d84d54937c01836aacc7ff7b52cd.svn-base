using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.Kasir.Report
{
    public partial class frmMonitoringPaycoll : ISA.Controls.BaseForm
    {
        public frmMonitoringPaycoll()
        {
            InitializeComponent();
        }

        private void GenerateReport(DataSet ds)
        {
            //string periode = "Periode : " + monthYearBox1.MonthName + " " + monthYearBox1.Year;
            //string namabln = monthYearBox1.MonthName;
            //string jmlhari = monthYearBox1.LastDateOfMonth.Day.ToString();
            string createdby = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", rangeDateBox1.FromDate.ToString() + " s/d " + rangeDateBox1.ToDate.ToString()));
            //rptParams.Add(new ReportParameter("NamaBln", namabln));
            //rptParams.Add(new ReportParameter("TotalHari", jmlhari));
            rptParams.Add(new ReportParameter("CreatedBy", createdby));

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];
            DataTable dt4 = ds.Tables[3];
            //call report viewer
            frmReportViewer ifrmReport1 = new frmReportViewer("Kasir.Report.rptMonitoringPaycollV1.rdlc", rptParams, dt1, "dsMonitoringPaycoll_Data1");
            ifrmReport1.Show();
            ifrmReport1.Text = "Monitoring Paycoll Data 1";

            frmReportViewer ifrmReport2 = new frmReportViewer("Kasir.Report.rptMonitoringPaycollV2.rdlc", rptParams, dt2, "dsMonitoringPaycoll_Data2");
            ifrmReport2.Show();
            ifrmReport2.Text = "Monitoring Paycoll Data 2";

            frmReportViewer ifrmReport3 = new frmReportViewer("Kasir.Report.rptMonitoringPaycollV3.rdlc", rptParams, dt3, "dsMonitoringPaycoll_Data3");
            ifrmReport3.Show();
            ifrmReport3.Text = "Monitoring Paycoll Data 3";

            frmReportViewer ifrmReport4 = new frmReportViewer("Kasir.Report.rptMonitoringPaycollV4.rdlc", rptParams, dt4, "dsMonitoringPaycoll_Data4");
            ifrmReport4.Show();
            ifrmReport4.Text = "Monitoring Paycoll Data 4";
        }
        /*
        private void GenerateReportExcel(DataSet ds)
        {
           // int _enddate = monthYearBox1.LastDateOfMonth.Day;
            string _judullaporan = "Jadwal Detail Kunjungan Harian Salesman";

            ExcelPackage p = new ExcelPackage();
            p.Workbook.Properties.Author = "SAS";
            p.Workbook.Properties.Title = _judullaporan;

            #region Detail
            #region title
            p.Workbook.Worksheets.Add("Detail");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];

            ws.Name = "Detail"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";
            #endregion

            #region header
            ws.Column(1).Width = 15;
            ws.Column(2).Width = 15;
            ws.Column(3).Width = 30;
            ws.Column(4).Width = 15;
            ws.Column(5).Width = 50;
            ws.Column(6).Width = 15;
            ws.Column(7).Width = 15;
            ws.Column(4).Width = 15;

            int _kolommulai = 9;
            for (int i = 1; i <= _enddate+1; i++)
            {
                ws.Column(_kolommulai).Width = 15;
                ws.Column(_kolommulai+1).Width = 15;
                ws.Column(_kolommulai+2).Width = 15;
                ws.Column(_kolommulai+3).Width = 15;
                ws.Column(_kolommulai+4).Width = 15;
                ws.Column(_kolommulai+5).Width = 15;
                ws.Column(_kolommulai+6).Width = 15;
                ws.Column(_kolommulai+7).Width = 15;
                ws.Column(_kolommulai+8).Width = 15;
                ws.Column(_kolommulai+9).Width = 15;

                _kolommulai=_kolommulai+10;
            }

            int MaxCol = 7+(10*_enddate)+10;

            ws.Cells[1, 1].Value = _judullaporan;
            ws.Cells[1, 1, 1, 5].Merge = true;
            ws.Cells[1, 1, 1, 5].Style.Font.Size = 14;

            ws.Cells[3, 1].Value = "Cabang";
            ws.Cells[3, 2].Value = ": " + GlobalVar.Gudang;

            int StartH = 5;

            ws.Cells[StartH, 1].Value = "Cabang";
            ws.Cells[StartH, 2].Value = "KodeSales";
            ws.Cells[StartH, 3].Value = "Nama Toko";
            ws.Cells[StartH, 4].Value = "WilID";
            ws.Cells[StartH, 5].Value = "Alamat";
            ws.Cells[StartH, 6].Value = "Kota";
            ws.Cells[StartH, 7].Value = "Status";
            ws.Cells[StartH, 8].Value = "Verivikasi";
            for(int i=1;i<=8; i++)
            {
                ws.Cells[StartH, i, StartH+2, i].Merge = true;
            }

            int _no = 1;
            string _no1 = "01";
            string _blntahun = monthYearBox1.MonthName + " " + monthYearBox1.Year;

            _kolommulai = 9;
            for (int i = 1; i <= _enddate; i++)
            {
                _no1 = (i).ToString();
                if (i < 10)
                {
                    _no1 = "0" + _no1;
                }

                ws.Cells[StartH, _kolommulai].Value = _no1 + " " + _blntahun;
                ws.Cells[StartH, _kolommulai, StartH, _kolommulai+9].Merge = true;

                ws.Cells[StartH + 1, _kolommulai].Value = "Call";
                ws.Cells[StartH + 1, _kolommulai, StartH + 1 , _kolommulai + 1].Merge = true;
                ws.Cells[StartH + 2, _kolommulai].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai+1].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
                ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
                ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 6].Value = "Sales (Nom)";
                ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
                ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

                _kolommulai = _kolommulai + 10;

            }

            ws.Cells[StartH, _kolommulai].Value = "TOTAL";
            ws.Cells[StartH, _kolommulai, StartH, _kolommulai + 9].Merge = true;

            ws.Cells[StartH + 1, _kolommulai].Value = "Call";
            ws.Cells[StartH + 1, _kolommulai, StartH + 1, _kolommulai + 1].Merge = true;
            ws.Cells[StartH + 2, _kolommulai].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 1].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
            ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
            ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 6].Value = "Sales (Nom)";
            ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
            ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

            _kolommulai = _kolommulai + 9;

            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Font.Bold = true;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


            #endregion

            #region filldata
            string _kodesaleslama = "xxx";
            string _kodesalesbaru = "";


           
            _no = 1;
            int idx = StartH + 3;
            int _rowAwal=idx;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _kodesalesbaru = dr["SalesID"].ToString();

                if(_kodesalesbaru!=_kodesaleslama && _kodesaleslama !="xxx")
                {
                    ws.Cells[idx, 1].Value = "Total";
                    ws.Cells[idx, 1, idx , 8].Merge = true;
                    _kolommulai = 9;
                    for (int i = 1; i <= _enddate; i++)
                    {
                        ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
                        ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
                        ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
                        ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
                        ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
                        ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
                        ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
                        ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
                        ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
                        ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

                        _kolommulai=_kolommulai+10;
                    }

                    ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
                    ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
                    ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
                    ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
                    ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
                    ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
                    ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
                    ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
                    ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
                    ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

                    ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                    
                    idx++;
                    _rowAwal=idx;
                }

                ws.Cells[idx, 1].Value = dr["GudangID"].ToString();
                ws.Cells[idx, 2].Value = dr["SalesID"].ToString();
                ws.Cells[idx, 3].Value = dr["NamaToko"].ToString();
                ws.Cells[idx, 4].Value = dr["WilID"].ToString();
                ws.Cells[idx, 5].Value = dr["Alamat"].ToString();
                ws.Cells[idx, 6].Value = dr["Kota"].ToString();
                ws.Cells[idx, 7].Value = dr["StatusToko"].ToString();
                ws.Cells[idx, 8].Value = dr["StatusVerifikasi"].ToString();

                _kolommulai = 9;

                for (int i = 1; i <= _enddate; i++)
                {
                    _no1 = (i).ToString();
                    if (i < 10)
                    {
                        _no1 = "0" + _no1;
                    }
                    ws.Cells[idx, _kolommulai].Value = dr["ks"+_no1];
                    ws.Cells[idx, _kolommulai+1].Value = dr["hk"+_no1];
                    ws.Cells[idx, _kolommulai+2].Value = dr["ec"+_no1];
                    ws.Cells[idx, _kolommulai+3].Value = dr["hec"+_no1];
                    ws.Cells[idx, _kolommulai + 4].Value = dr["xver" + _no1];
                    ws.Cells[idx, _kolommulai+5].Value = dr["ver"+_no1];
                    ws.Cells[idx, _kolommulai+6].Value = dr["TargetOmset"];
                    ws.Cells[idx, _kolommulai+7].Value = dr["rlo"+_no1];
                    ws.Cells[idx, _kolommulai+8].Value = dr["piut"+_no1];
                    ws.Cells[idx, _kolommulai+9].Value = dr["byr"+_no1];

                    _kolommulai=_kolommulai+10;
                }

                ws.Cells[idx, _kolommulai].Value = dr["ksT"];
                ws.Cells[idx, _kolommulai+1].Value = dr["hkT"];
                ws.Cells[idx, _kolommulai+2].Value = dr["ecT"];
                ws.Cells[idx, _kolommulai+3].Value = dr["hecT"];
                ws.Cells[idx, _kolommulai + 4].Value = dr["xverT"];
                ws.Cells[idx, _kolommulai+5].Value = dr["verT"];
                ws.Cells[idx, _kolommulai+6].Value = dr["TargetOmset"];
                ws.Cells[idx, _kolommulai+7].Value = dr["rloT"];
                ws.Cells[idx, _kolommulai+8].Value = dr["piutT"];
                ws.Cells[idx, _kolommulai+9].Value = dr["byrT"];

                _kolommulai=_kolommulai+10;
                _kodesaleslama=_kodesalesbaru;

                idx++;
            }

            ws.Cells[idx, 1].Value = "Total";
            ws.Cells[idx, 1, idx , 8].Merge = true;
            _kolommulai = 9;
            for (int i = 1; i <= _enddate; i++)
            {
                ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
                ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
                ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
                ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
                ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
                ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
                ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
                ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
                ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
                ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

                _kolommulai=_kolommulai+10;
            }

            ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
            ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
            ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
            ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
            ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
            ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
            ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
            ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
            ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
            ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            #endregion

            #region summary & formatting

            var border = ws.Cells[StartH, 1, idx, _kolommulai + 9].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            //ws.Cells[StartH, 1, StartH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[StartH, 1, StartH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            //ws.Cells[1, 1, StartH, MaxCol].Style.Font.Bold = true;
            //ws.Cells[StartH, 1, StartH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //ws.Cells[StartH, 1, StartH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            //for (int i = 5; i <= MaxCol; i++)
            //{
            //    ws.Cells[idx, i].Formula = "SUM(" + ws.Cells[StartH + 1, i].Address + ":" + ws.Cells[idx - 1, i].Address + ")";
            //}

            ws.Cells[StartH + 3, 9, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[StartH + 3, 1, idx, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[StartH + 3, 4, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 4, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[StartH + 3, 7, idx, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 7, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[StartH + 3, 9, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 9, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            #endregion

            #endregion

            #region sheetrekap

            p.Workbook.Worksheets.Add("Rekap");
            ws = p.Workbook.Worksheets[2];

            ws.Name = "Rekap"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";
            

            #region header
            ws.Column(1).Width = 15;
            ws.Column(2).Width = 15;

            _kolommulai = 3;
            for (int i = 1; i <= _enddate; i++)
            {
                ws.Column(_kolommulai).Width = 15;
                ws.Column(_kolommulai+1).Width = 15;
                ws.Column(_kolommulai+2).Width = 15;
                ws.Column(_kolommulai+3).Width = 15;
                ws.Column(_kolommulai+4).Width = 15;
                ws.Column(_kolommulai+5).Width = 15;
                ws.Column(_kolommulai+6).Width = 15;
                ws.Column(_kolommulai+7).Width = 15;
                ws.Column(_kolommulai+8).Width = 15;
                ws.Column(_kolommulai+9).Width = 15;

                _kolommulai=_kolommulai+10;
            }

            ws.Column(_kolommulai).Width = 15;
            ws.Column(_kolommulai+1).Width = 15;
            ws.Column(_kolommulai+2).Width = 15;
            ws.Column(_kolommulai+3).Width = 15;
            ws.Column(_kolommulai+4).Width = 15;
            ws.Column(_kolommulai+5).Width = 15;
            ws.Column(_kolommulai+6).Width = 15;
            ws.Column(_kolommulai+7).Width = 15;
            ws.Column(_kolommulai+8).Width = 15;
            ws.Column(_kolommulai+9).Width = 15;

            _kolommulai=_kolommulai+9;

            MaxCol = _kolommulai;

            ws.Cells[1, 1].Value = "Rekap Kunjungan Harian Salesman";
            ws.Cells[1, 1, 1, 5].Merge = true;
            ws.Cells[1, 1, 1, 5].Style.Font.Size = 14;

            ws.Cells[3, 1].Value = "Cabang";
            ws.Cells[3, 2].Value = ": " + GlobalVar.Gudang;

            StartH = 5;

            ws.Cells[StartH, 1].Value = "Cabang";
            ws.Cells[StartH, 2].Value = "KodeSales";
            for(int i=1;i<=2; i++)
            {
                ws.Cells[StartH, i, StartH+2, i].Merge = true;
            }

            _no = 1;
            _no1 = "01";

            _kolommulai = 3;
            for (int i = 1; i <= _enddate; i++)
            {
                _no1 = (i).ToString();
                if (i < 10)
                {
                    _no1 = "0" + _no1;
                }

                ws.Cells[StartH, _kolommulai].Value = _no1 + " " + _blntahun;
                ws.Cells[StartH, _kolommulai, StartH, _kolommulai+9].Merge = true;

                ws.Cells[StartH + 1, _kolommulai].Value = "Call";
                ws.Cells[StartH + 1, _kolommulai, StartH + 1 , _kolommulai + 1].Merge = true;
                ws.Cells[StartH + 2, _kolommulai].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai+1].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
                ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
                ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 6].Value = "Sales (Nom)";
                ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
                ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

                _kolommulai = _kolommulai + 10;

            }

            ws.Cells[StartH, _kolommulai].Value = "TOTAL";
            ws.Cells[StartH, _kolommulai, StartH, _kolommulai + 9].Merge = true;

            ws.Cells[StartH + 1, _kolommulai].Value = "Call";
            ws.Cells[StartH + 1, _kolommulai, StartH + 1, _kolommulai + 1].Merge = true;
            ws.Cells[StartH + 2, _kolommulai].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 1].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
            ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
            ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 6].Value = "Sales (Nom)";
            ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
            ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

            _kolommulai = _kolommulai + 9;

            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Font.Bold = true;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


            #endregion

            #region filldata


           
            _no = 1;
            idx = StartH + 3;
            _rowAwal=idx;
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ws.Cells[idx, 1].Value = dr["GudangID"].ToString();
                ws.Cells[idx, 2].Value = dr["SalesID"].ToString();

                _kolommulai = 3;

                for (int i = 1; i <= _enddate; i++)
                {
                    _no1 = (i).ToString();
                    if (i < 10)
                    {
                        _no1 = "0" + _no1;
                    }
                    ws.Cells[idx, _kolommulai].Value = dr["ks"+_no1];
                    ws.Cells[idx, _kolommulai+1].Value = dr["hk"+_no1];
                    ws.Cells[idx, _kolommulai+2].Value = dr["ec"+_no1];
                    ws.Cells[idx, _kolommulai+3].Value = dr["hec"+_no1];
                    ws.Cells[idx, _kolommulai + 4].Value = dr["xver" + _no1];
                    ws.Cells[idx, _kolommulai+5].Value = dr["ver"+_no1];
                    ws.Cells[idx, _kolommulai+6].Value = dr["TargetOmset"];
                    ws.Cells[idx, _kolommulai+7].Value = dr["rlo"+_no1];
                    ws.Cells[idx, _kolommulai+8].Value = dr["piut"+_no1];
                    ws.Cells[idx, _kolommulai+9].Value = dr["byr"+_no1];

                    _kolommulai=_kolommulai+10;
                }

                ws.Cells[idx, _kolommulai].Value = dr["ksT"];
                ws.Cells[idx, _kolommulai+1].Value = dr["hkT"];
                ws.Cells[idx, _kolommulai+2].Value = dr["ecT"];
                ws.Cells[idx, _kolommulai+3].Value = dr["hecT"];
                ws.Cells[idx, _kolommulai + 4].Value = dr["xverT"];
                ws.Cells[idx, _kolommulai+5].Value = dr["verT"];
                ws.Cells[idx, _kolommulai+6].Value = dr["TargetOmset"];
                ws.Cells[idx, _kolommulai+7].Value = dr["rloT"];
                ws.Cells[idx, _kolommulai+8].Value = dr["piutT"];
                ws.Cells[idx, _kolommulai+9].Value = dr["byrT"];

                _kolommulai=_kolommulai+10;

                idx++;
            }

            ws.Cells[idx, 1].Value = "Total";
            ws.Cells[idx, 1, idx , 2].Merge = true;
            _kolommulai = 3;
            for (int i = 1; i <= _enddate; i++)
            {
                ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
                ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
                ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
                ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
                ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
                ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
                ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
                ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
                ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
                ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

                _kolommulai=_kolommulai+10;
            }

            ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
            ws.Cells[idx, _kolommulai+1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+1].Address + ":" + ws.Cells[idx - 1, _kolommulai+1].Address + ")";
            ws.Cells[idx, _kolommulai+2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+2].Address + ":" + ws.Cells[idx - 1, _kolommulai+2].Address + ")";
            ws.Cells[idx, _kolommulai+3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+3].Address + ":" + ws.Cells[idx - 1, _kolommulai+3].Address + ")";
            ws.Cells[idx, _kolommulai+4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+4].Address + ":" + ws.Cells[idx - 1, _kolommulai+4].Address + ")";
            ws.Cells[idx, _kolommulai+5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+5].Address + ":" + ws.Cells[idx - 1, _kolommulai+5].Address + ")";
            ws.Cells[idx, _kolommulai+6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+6].Address + ":" + ws.Cells[idx - 1, _kolommulai+6].Address + ")";
            ws.Cells[idx, _kolommulai+7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+7].Address + ":" + ws.Cells[idx - 1, _kolommulai+7].Address + ")";
            ws.Cells[idx, _kolommulai+8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+8].Address + ":" + ws.Cells[idx - 1, _kolommulai+8].Address + ")";
            ws.Cells[idx, _kolommulai+9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai+9].Address + ":" + ws.Cells[idx - 1, _kolommulai+9].Address + ")";

            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            _kolommulai = _kolommulai + 9;
            #endregion

            #region summary & formatting

            border = ws.Cells[StartH, 1, idx, _kolommulai].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[StartH+3, 3, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[StartH+3, 1, idx, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH+3, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[StartH+3, 3, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH+3, 3, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

        
            #endregion

            #endregion
            #region Output

            Byte[] bin = p.GetAsByteArray();

            //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
            //ws.Cells.Style.ShrinkToFit = true;
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "Kunjungan Harian Salesman_" + _blntahun + "_" + GlobalVar.DateTimeOfServer.ToString("yyyyMMddhhiiss") + ".xlsx";

            sf.OverwritePrompt = true;
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
            {
                string file = sf.FileName.ToString();
                System.IO.File.WriteAllBytes(file, bin);
                MessageBox.Show("Laporan Selesai. " + file);
                System.Diagnostics.Process.Start(sf.FileName.ToString());
            }
            #endregion
        }
        */

        private void frmMonitoringPaycoll_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.DateOfServer;
            rangeDateBox1.ToDate = GlobalVar.DateOfServer;
            //monthYearBox1.Month = GlobalVar.DateOfServer.Month;
            //monthYearBox1.Year = GlobalVar.DateOfServer.Year;

            //radioButton1.Checked = true;
        }

        private void cmdPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Paycoll_LaporanMonitoring"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    if (lookupCollector1.CollectorID == "" || lookupCollector1.CollectorID == "[CODE]")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, DBNull.Value));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, lookupCollector1.CollectorID));
                    }
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables.Count > 0)
                {
                    GenerateReport(ds);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
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

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
