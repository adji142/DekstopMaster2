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

namespace ISA.Trading.Penjualan
{
    public partial class frmLaporanGoodInTransit : ISA.Trading.BaseForm
    {
        public frmLaporanGoodInTransit()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (rangePeriode.FromDate != null && rangePeriode.ToDate != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Penjualan_GoodInTransit")); //cek heri 05032013
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@cab1", SqlDbType.VarChar, txtCabang1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
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
            else
            {
                MessageBox.Show("Masukkan periode tanggal", "Periode Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rangePeriode.Focus();
            }
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangePeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangePeriode.ToDate).ToString("dd/MM/yyyy"));

            string reportType = string.Empty;
            reportType = chkLaporan.Checked ==true ? "Penjualan.rptLaporanGoodInTransitAuditVersion.rdlc" : "Penjualan.rptLaporanGoodInTransit.rdlc";

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer(reportType, rptParams, dt, "dsToko_Data2");
            ifrmReport.ExportToExcelAndSend("Laporan GIT", "Laporan GIT_" + rangePeriode.FromDate.Value.Month.ToString() + "-" + rangePeriode.FromDate.Value.Year.ToString());
            ifrmReport.Show();
        }

        public void DisplayReportGITAuto(string fileName, DataTable dt, DateTime d1, DateTime d2)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)d1).ToString("dd/MM/yyyy"), ((DateTime)d2).ToString("dd/MM/yyyy"));

            string reportType = string.Empty;
            reportType = "Penjualan.rptLaporanGoodInTransitAuditVersion.rdlc";

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer(reportType, rptParams, dt, "dsToko_Data2");
            ifrmReport.ExportToExcelAuto(fileName);
        }

        private void txtWilayah_TextChanged(object sender, EventArgs e)
        {
            txtWilayah.Text = txtWilayah.Text.ToUpper();
        }

        private void frmLaporanGoodInTransit_Load(object sender, EventArgs e)
        {
            txtCabang1.Text = GlobalVar.CabangID;
            lookupGudang.GudangID = GlobalVar.Gudang;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (rangePeriode.FromDate != null && rangePeriode.ToDate != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Penjualan_GoodInTransit")); //cek heri 05032013
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@cab1", SqlDbType.VarChar, txtCabang1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
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
            else
            {
                MessageBox.Show("Masukkan periode tanggal", "Periode Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rangePeriode.Focus();
            }

        }
    }
}
