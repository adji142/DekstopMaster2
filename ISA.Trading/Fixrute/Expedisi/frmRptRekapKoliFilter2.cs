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
    public partial class frmRptRekapKoliFilter2 : ISA.Trading.BaseForm
    {
        string shift = "0";
        string status = "";

        public frmRptRekapKoliFilter2()
        {
            InitializeComponent();
        }

        private void frmRptRekapKoliFilter2_Load(object sender, EventArgs e)
        {
            rgbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglSuratJalan.ToDate = DateTime.Now;
            rdoMuat.Checked = true;
            rdoShift1.Checked = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (rdoMuat.Checked == true)
                status = "M";
            if (rdoPending.Checked == true)
                status = "P";
            if (rdoMuatPending.Checked == true)
                status = "A";

            if (rdoShift1.Checked == true)
                shift = "1";
            if (rdoShift2.Checked == true)
                shift = "2";
            if (rdoSemuaShift.Checked == true)
                shift = "0";
                      
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_RekapKoli"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglSuratJalan.ToDate));
                    if (shift != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, int.Parse(shift)));
                    if (status != "A")
                        db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, status));
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglSuratJalan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbTglSuratJalan.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Shift", shift));
            rptParams.Add(new ReportParameter("Status", status));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapKoli2.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();

        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
