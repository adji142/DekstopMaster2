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
    public partial class frmRptPerbandinganDODanRealisasiOmzetPerSalesFilter : ISA.Trading.BaseForm
    {
        public frmRptPerbandinganDODanRealisasiOmzetPerSalesFilter()
        {
            InitializeComponent();
        }

        private void frmRptPerbandinganDODanRealisasiOmzetPerSalesFilter_Load(object sender, EventArgs e)
        {
            rangeAnalisa.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeAnalisa.ToDate = new DateTime(rangeAnalisa.FromDate.Value.Year, rangeAnalisa.FromDate.Value.Month + 1, 1).AddDays(-1);

            rangePembanding.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangePembanding.ToDate = new DateTime(rangePembanding.FromDate.Value.Year, rangePembanding.FromDate.Value.Month + 1, 1).AddDays(-1);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                int cetakSaldo = 0;
                if (lookupSales.SalesID=="")
                {
                    cetakSaldo = MessageBox.Show("Cetak Nota..?", "Cetak Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0;
                }
                
                
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PerbandinganDOdanRealisasiOmzetPerSales"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFromAnalisa", SqlDbType.DateTime, rangeAnalisa.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateToAnalisa", SqlDbType.DateTime, rangeAnalisa.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFromPembanding", SqlDbType.DateTime, rangePembanding.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateToPembanding", SqlDbType.DateTime, rangePembanding.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@pembanding", SqlDbType.VarChar, rbDO.Checked == true ? "D" : "N"));
                    db.Commands[0].Parameters.Add(new Parameter("@cetakSaldo", SqlDbType.Int, cetakSaldo));
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
            string periodeAnalisa;
            string periodePembanding;
            periodeAnalisa = String.Format("{0} s/d {1}", ((DateTime)rangeAnalisa.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeAnalisa.ToDate).ToString("dd/MM/yyyy"));
            periodePembanding = String.Format("{0} s/d {1}", ((DateTime)rangePembanding.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangePembanding.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("PeriodeAnalisa", periodeAnalisa));
            rptParams.Add(new ReportParameter("PeriodePembanding", periodePembanding));
            rptParams.Add(new ReportParameter("Sales", string.IsNullOrEmpty(lookupSales.SalesID) == true ? "Semua" : lookupSales.SalesID));
            
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptPerbandinganDODanRealisasiOmzetPerSales.rdlc", rptParams, dt, "dsSales_Data");
            ifrmReport.Show();
        }

        private void lookupSales_Validated(object sender, EventArgs e)
        {
            if (lookupSales.SalesID!="" && lookupSales.NamaSales.Trim()=="")
            {
                lookupSales.SalesID = "";
            }

          
        }
    }
}
