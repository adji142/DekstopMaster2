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

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptTokoOrderBaruFilter : ISA.Trading.BaseForm
    {
        public frmRptTokoOrderBaruFilter()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_TokoOrderBaru"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeOrder.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeOrder.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toko", SqlDbType.VarChar, txtToko.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, cbWilID.WilID));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeOrder.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeOrder.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptTokoOrderBaru.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();
        }

        private void frmRptTokoOrderBaruFilter_Load(object sender, EventArgs e)
        {
            rangeOrder.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeOrder.ToDate = DateTime.Now;
        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
