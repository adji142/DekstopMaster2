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
using ISA.Controls;
using ISA.Trading.Class;
using System.Globalization;

namespace ISA.Trading.PSReport
{
    public partial class frmDashboardPS : ISA.Trading.BaseForm
    {
        DataSet ds;
        DateTime fromDate, toDate;

        public frmDashboardPS()
        {
            InitializeComponent();
        }

        private void frmDashboardPS_Load(object sender, EventArgs e)
        {
            //myPeriode.Month = GlobalVar.DateOfServer.Month;
            //myPeriode.Year = GlobalVar.DateOfServer.Year;
            myPeriode.FromDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            myPeriode.ToDate = GlobalVar.DateOfServer;
        }

        private void GetData() 
        {
            try 
            {
                using (Database db = new Database()) 
                {
                    db.Commands.Add(db.CreateCommand("rsp_DashboardPS_populate_V2"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    ds = db.Commands[0].ExecuteDataSet();
                }
            }catch(Exception ex)
            {
                //Error.LogError(ex);
            }
        }

        private void DisplayReport() 
        {
            string periode, proses;
            /*periode = myPeriode.ToDate.Value.ToString("MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));*/
            //periode = myPeriode.MonthName + " " + myPeriode.Year;
            periode = myPeriode.FromDate.Value.ToString("dd MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US")) + " s/d " +
                  myPeriode.ToDate.Value.ToString("dd MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));
            proses = GlobalVar.DateOfServer.ToString("d MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Proses", proses));
            rptParams.Add(new ReportParameter("GudangID", GlobalVar.Gudang));

            List<DataTable> dTable = new List<DataTable>();
            dTable.Add(ds.Tables[0]);
            dTable.Add(ds.Tables[1]);

            List<string> dSetName = new List<string>();
            dSetName.Add("dsDashboardPS_DataPS");
            dSetName.Add("dsDashboardPS_DataPSB");
           
            frmReportViewer ifrmReport = new frmReportViewer("PSReport.rptDashboardPS.rdlc", rptParams, dTable, dSetName);
            ifrmReport.Show();
        }

        private void bwDashboardPS_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }

        private void bwDashboardPS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
            DisplayReport();
        }

        private void cmbPrint_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            fromDate = myPeriode.FromDate.Value;
            toDate = myPeriode.ToDate.Value;
            bwDashboardPS.RunWorkerAsync();
        }

        private void cmbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            fromDate = myPeriode.FromDate.Value;
            toDate = myPeriode.ToDate.Value;
            bwDashboardPS.RunWorkerAsync();
        }
    }
}

