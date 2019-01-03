using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.AKC
{
    public partial class LaporanHasilKunjunganCollector : ISA.Trading.BaseForm
    {

        private void laporanKunjCollector()
        {
            try
            {
                DataSet ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                string periodReport = txtDate1.DateValue.Value.ToString("dd-MMMM-yyyy")+ " s/d " + txtDate2.DateValue.Value.ToString("dd-MMMM-yyyy") ;
                rptParams.Add(new ReportParameter("periodeReport", periodReport));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglStart", SqlDbType.DateTime, txtDate1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglEnd", SqlDbType.DateTime, txtDate2.DateValue));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("AKC.LaporanHasilKunjunganCollector.rdlc", rptParams, ds.Tables[0], "dsLaporanKunjunganCollector_KunjunganCollector");
                    ifrmReport.Text = "Laporan Kunjungan Collector";
                    ifrmReport.Show();
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

        public LaporanHasilKunjunganCollector()
        {
            InitializeComponent();
            this.Title = "Laporan Kunjungan Collector";
        }

        private void LaporanHasilKunjunganCollector_Load(object sender, EventArgs e)
        {
            txtDate2.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtDate1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            laporanKunjCollector();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
