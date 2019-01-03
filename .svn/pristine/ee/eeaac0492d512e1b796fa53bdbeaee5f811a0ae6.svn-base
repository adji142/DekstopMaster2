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
    public partial class frmRptlaporanRefilToko : ISA.Trading.BaseForm
    {
        public frmRptlaporanRefilToko()
        {
            InitializeComponent();
        }

        private void frmRptlaporanRefilToko_Load(object sender, EventArgs e)
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


                    db.Commands.Add(db.CreateCommand("[rsp_laporanRefilToko]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBoxPenjualan.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBoxPenjualan.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("tanggal", rangeDateBoxPenjualan.FromDate.Value.ToString()));
            // rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.RptLaporanRefilToko.rdlc", rptParams, dt, "dsLaporanRefilToko_Data");
            ifrmReport.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
