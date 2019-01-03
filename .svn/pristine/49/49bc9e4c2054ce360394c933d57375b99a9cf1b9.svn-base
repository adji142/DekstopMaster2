using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Expedisi
{
    public partial class frmRptRekapExpedisiFilter : ISA.Toko.BaseForm
    {
        public frmRptRekapExpedisiFilter()
        {
            InitializeComponent();
        }

        private void frmRptRekapExpedisiFilter_Load(object sender, EventArgs e)
        {
            rgbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglSuratJalan.ToDate = DateTime.Now;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_RekapExpedisi"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglSuratJalan.ToDate));

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
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapExpedisi.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();

        } 
        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
