using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Controls;

namespace ISA.Trading.Laporan.Xtd
{
    public partial class frmLaporanPersediaanTax : ISA.Trading.BaseForm
    {
        public frmLaporanPersediaanTax()
        {
            InitializeComponent();
        }

        private void frmLaporanPersediaanTax_Load(object sender, EventArgs e)
        {
            RngDateRange.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            RngDateRange.ToDate = DateTime.Now;

            radioAll.Checked = true;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[usp_LaporanPersediaanXtd]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, RngDateRange.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, RngDateRange.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                if (radioPlus.Checked)
                {
                    dt.DefaultView.RowFilter = "QtyAkhir>0";
                }
                else if (radioMin.Checked)
                {
                    dt.DefaultView.RowFilter = "QtyAkhir<0";
                }
                
                DisplayReport(dt.DefaultView.ToTable());

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string initial = "SAS-" + GlobalVar.Gudang;
            string judul = "Persediaan";
            string pengolah = SecurityManager.UserID + ", " + GlobalVar.DateTimeOfServer.ToString("dd/MM/yyyy");
            string created = "Created By " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Data");
                return;
            }

            if (radioPlus.Checked)
            {
                judul = judul + " Plus";
            }
            else if (radioMin.Checked)
            {
                judul = judul + " Minus";
            }
            periode = String.Format("{0} s/d {1}", ((DateTime)RngDateRange.FromDate).ToString("dd/MM/yyyy"), ((DateTime)RngDateRange.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Initial", initial));
            rptParams.Add(new ReportParameter("JudulLaporan", judul));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Pengolah", pengolah));
            rptParams.Add(new ReportParameter("CreatedBy", created));

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Xtd.rptLaporanPersediaanXtd.rdlc", rptParams, dt, "dsLapPersediaanTAX_Data");
            ifrmReport.Show();
        }
    }
}
