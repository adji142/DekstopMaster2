using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using System.IO;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace ISA.Trading.PSReport
{
    public partial class frmDashboardKaDepoV2 : ISA.Trading.BaseForm
    {
        DataTable dt;
        DataTable dtPs;
        DataTable dtOvd;
        DataTable dtLst;
        DataTable dtLsw;
        DataTable dtSa;
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;

        DateTime fromDate, toDate;

        public frmDashboardKaDepoV2()
        {
            InitializeComponent();
        }

        private void frmDashboardKaDepo_Load(object sender, EventArgs e)
        {
            rangePeriode.Controls[2].Enabled = false;
            rangePeriode.Controls[2].BackColor = Color.White;
            rangePeriode.FromDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            rangePeriode.ToDate = GlobalVar.DateOfServer;
        }

        public DateTime LastSunday(DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target >= start)
                target -= 7;
            return from.AddDays(target - start);
        }

        public DateTime MondayBfrLastSunday(DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target -= 6;
            return from.AddDays(target - start);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            fromDate = rangePeriode.FromDate.Value;
            toDate = rangePeriode.ToDate.Value;
            pictureBox3.Visible = true;
            bwKADepo.RunWorkerAsync();
            //PopulateData();
            //this.Cursor = Cursors.Default;
        }

        private void PopulateData() 
        {
            dtPs = new DataTable();
            //dtOvd = new DataTable();
            //dtLst = new DataTable();
            //dtLsw = new DataTable();
            //dtSa = new DataTable();
            //dtBf = new DataTable();

            //Tarik data Fixed Route
            //PullDataSF();

            dtPs = GetData("rsp_Dashboard_Salesman_Performance_V2");
            //dtOvd = GetData("rsp_Dashboard_Overdue");
            //dtLst = GetData("rsp_Dashboard_LostSalesToko");
            //dtLsw = GetData("rsp_Dashboard_LostSalesWalkIn");
            //dtSa = GetData("rsp_Dashboard_StockAging");
            //dtBf = GetData("rsp_Dashboard_BarangFokus_SKU");
        }

        private DataTable GetData(string cmd)
        {
            dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(cmd));
                    db.Commands[0].Parameters.Add(new ISA.DAL.Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new ISA.DAL.Parameter("@ToDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new ISA.DAL.Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private void DisplayReport(DataTable dt, string reportVwr, string dataSet)
        {
            DateTime prd2 = LastSunday(rangePeriode.ToDate.Value, DayOfWeek.Sunday);
            string periode, proses, periode2;
            periode = rangePeriode.FromDate.Value.ToString("d MMM yyyy",
                      CultureInfo.CreateSpecificCulture("en-US"))
                      + " s/d " +
                      rangePeriode.ToDate.Value.ToString("d MMM yyyy",
                      CultureInfo.CreateSpecificCulture("en-US")); ;
           
            periode2 = prd2.ToString("d MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));
            proses = GlobalVar.DateOfServer.ToString("d MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Proses", proses));
            rptParams.Add(new ReportParameter("GudangID", GlobalVar.Gudang));
            if (reportVwr == "Overdue")
            {
                rptParams.Add(new ReportParameter("Periode2", periode2));
            }

            frmReportViewer ifrmReport = new frmReportViewer("PSReport.rptDashboard"+reportVwr+".rdlc", rptParams, dt, "dsDashboardKaDepo_"+dataSet);
            ifrmReport.Show();
        }

        private void DisplayGraph(List<DataTable> dt, string reportVwr, List<string> dataSet)
        {
            DateTime prd2 = LastSunday(rangePeriode.ToDate.Value, rangePeriode.ToDate.Value.DayOfWeek);
            string periode, proses, periode2;
            
            periode = rangePeriode.FromDate.Value.ToString("d MMM yyyy",
                          CultureInfo.CreateSpecificCulture("en-US"))
                          + " s/d " +
                          rangePeriode.ToDate.Value.ToString("d MMM yyyy",
                          CultureInfo.CreateSpecificCulture("en-US")); ;
            
            periode2 = prd2.ToString("d MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));
            proses = GlobalVar.DateOfServer.ToString("d MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Proses", proses));
            rptParams.Add(new ReportParameter("GudangID", GlobalVar.Gudang));
            rptParams.Add(new ReportParameter("Periode2", periode2));

            frmReportViewer ifrmReport = new frmReportViewer("PSReport.rptDashboard" + reportVwr + ".rdlc", rptParams, dt, dataSet);
            ifrmReport.Show();
        }

        private void bwKADepo_DoWork(object sender, DoWorkEventArgs e)
        {
            PopulateData();
        }

        private void bwKADepo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;

            DisplayReport(dtPs, "SalesmanPerformanceV2", "DataPSV2");
            //DisplayReport(dtOvd, "Overdue", "DataOvd");
            //DisplayReport(dtLst, "LostSalesToko", "DataLostSalesToko");
            //DisplayReport(dtLsw, "LostSalesWalkIn", "DataLostSalesWalkIn");
            //DisplayReport(dtSa, "StockAging", "DataStockAging");

            List<DataTable> dt = new List<DataTable>();
            dt.Add(dtPs);
            dt.Add(dtOvd);
            List<string> dsName = new List<string>();
            dsName.Add("dsDashboardKaDepo_DataPS");
            dsName.Add("dsDashboardKaDepo_DataOvd");

            //DisplayGraph(dt, "Grafik", dsName);
            //DisplayReport(dtBf, "BarangFokus", "DataBarangFokus");
        }       
    }
}