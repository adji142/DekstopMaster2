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
    public partial class frmRptEvaluasiOmzetPosFilter : ISA.Trading.BaseForm
    {
        public frmRptEvaluasiOmzetPosFilter()
        {
            InitializeComponent();
        }

        private void frmRptEvaluasiOmzetPos_Load(object sender, EventArgs e)
        {
            dateRange.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateRange.ToDate = new DateTime(dateRange.FromDate.Value.Year, dateRange.FromDate.Value.Month + 1, 1).AddDays(-1);
            cbPost.SelectedValue = "";
        }

        private void dateRange_Leave(object sender, EventArgs e)
        {
            dateRange.ToDate = new DateTime(dateRange.FromDate.Value.Year, dateRange.FromDate.Value.Month + txtBulan.GetIntValue, 1).AddDays(-1);
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_EvaluasiOmzetPos"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateRange.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateRange.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@post", SqlDbType.VarChar, cbPost.PostID));
                    db.Commands[0].Parameters.Add(new Parameter("@nBulan", SqlDbType.Int, txtBulan.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
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
            periode = String.Format("{0} s/d {1}", ((DateTime)dateRange.FromDate).ToString("dd/MM/yyyy"), ((DateTime)dateRange.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("SalesID", string.IsNullOrEmpty(lookupSales.SalesID) == true ? "Semua" : lookupSales.SalesID));
            rptParams.Add(new ReportParameter("PostID", cbPost.PostID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Daerah", string.IsNullOrEmpty(txtDaerah.Text) == true ? "Semua" : txtDaerah.Text));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptEvaluasiOmzetPos.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBulan_Leave(object sender, EventArgs e)
        {
            dateRange.ToDate = new DateTime(dateRange.FromDate.Value.Year, dateRange.FromDate.Value.Month + txtBulan.GetIntValue, 1).AddDays(-1);
        }
    }
}
