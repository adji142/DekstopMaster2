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

namespace ISA.Trading.Laporan.Salesman
{
    public partial class FrmLaporanKonsolidasiSalesman : ISA.Trading.BaseForm
    {
        public FrmLaporanKonsolidasiSalesman()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("Rsp_MonitoringSalesmanKonsol"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();

                } if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }
        private void DisplayReport(DataTable dt)
        {
            string periode;
            string OA;
            string SKU;
            DataTable dtbjd = new DataTable();
            using (Database db = new Database()) {
                db.Commands.Add(db.CreateCommand("Rsp_GetTotalOA"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                dtbjd = db.Commands[0].ExecuteDataTable();
            }
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("OA", dtbjd.Rows[0]["OA"].ToString()));
            rptParams.Add(new ReportParameter("SKU", dtbjd.Rows[0]["SKU"].ToString()));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.RptLaporanKonsolidasiSalesman.rdlc", rptParams, dt, "DsSalesKonsol_KonsolGan");
            ifrmReport.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
