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

namespace ISA.Trading.Penjualan
{
    public partial class frmRptOUTSTANDINGOVERDUE : ISA.Trading.BaseForm
    {
        public frmRptOUTSTANDINGOVERDUE()
        {
            InitializeComponent();
        }

        private void frmRptOUTSTANDINGOVERDUE_Load(object sender, EventArgs e)
        {
            rangeDateBoxPenjualan.ToDate = DateTime.Now;
            rangeDateBoxPenjualan.FromDate = DateTime.Now;

        }

        private void cmdyes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("[usp_pengajuan_outstandingOverdue]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBoxPenjualan.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBoxPenjualan.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                DisplayReport(dt);
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBoxPenjualan.FromDate).ToString("dd-MM-yyyy"), ((DateTime)rangeDateBoxPenjualan.ToDate).ToString("dd-MM-yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer


            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.RptOutstandingOverdue.rdlc", rptParams, dt, "dsOutstandingOverdue_Data");
            ifrmReport.Show();

        }
    }
}
