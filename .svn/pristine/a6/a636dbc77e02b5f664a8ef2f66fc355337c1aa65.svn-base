using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Laporan.Salesman
{
    public partial class frmRptRekapitulasiKelompokPenjualanSales : ISA.Trading.BaseForm
    {
        public frmRptRekapitulasiKelompokPenjualanSales()
        {
            InitializeComponent();
        }

        private void frmRptRekapitulasiKelompokPenjualanSales_Load(object sender, EventArgs e)
        {
            rangeTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTanggal.ToDate = DateTime.Now;
            rangeTanggal.Focus();

            this.Text = "Laporan Rekapitulasi Kelompok Penjualan Sales";
            this.Title = "Rekapitulasi Kelompok Penjualan Sales";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_RekapitulasiKelompokPenjualanSales"));

                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rangeTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rangeTanggal.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Hpp", SqlDbType.VarChar, "OhYes"));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(rangeTanggal.FromDate.ToString()) || string.IsNullOrEmpty(rangeTanggal.ToDate.ToString()))
            {
                errorProvider1.SetError(rangeTanggal, "Range tanggal masih kosong !");
                valid = false;
            }

            return valid;
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptRekapitulasiKelompokPenjualanSales.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
