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

namespace ISA.Trading.Expedisi
{
    public partial class frmRptExpLuarKotaFilter : ISA.Trading.BaseForm
    {
        string shift = "0";

        public frmRptExpLuarKotaFilter()
        {
            InitializeComponent();
        }

        private void frmRptExpLuarKotaFilter_Load(object sender, EventArgs e)
        {
            rdbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglSuratJalan.ToDate = DateTime.Now;
            rdoShift1.Checked = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (rdoShift1.Checked == true)
                shift = "1";
            if (rdoShift2.Checked == true)
                shift = "2";
            if (rdoSemuaShift.Checked == true)
                shift = "0";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_ExpedisiLuarKota"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglSuratJalan.ToDate));
                    if (shift != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, int.Parse(shift)));

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
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglSuratJalan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglSuratJalan.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Shift", shift));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptExpLuarKota.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();
        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
