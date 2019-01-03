using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;

namespace ISA.Toko.Laporan.Toko
{
    public partial class frmRptRekapKoliMenurutToko00 : ISA.Toko.BaseForm
    {
        public frmRptRekapKoliMenurutToko00()
        {
            InitializeComponent();
        }

        private void frmRptRekapKoliMenurutToko00_Load(object sender, EventArgs e)
        {
            rangeTanggalNota.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTanggalNota.ToDate = DateTime.Now;
            rangeTanggalNota.Focus();
            rdbShift1.Checked = true;

            this.Text = "Laporan Rekap Koli";
            this.Title = "LAPORAN REKAP KOLI";
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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_RekapKoliMenurutToko00"));

                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rangeTanggalNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rangeTanggalNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, rdbShift1.Checked ? "1" : "2"));

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(rangeTanggalNota.FromDate.ToString()) || string.IsNullOrEmpty(rangeTanggalNota.ToDate.ToString()))
            {
                errorProvider1.SetError(rangeTanggalNota, "Range tanggal masih kosong !");
                valid = false;
            }          

            return valid;
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggalNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggalNota.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Shift", rdbShift1.Checked ? "1" : "2"));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptRekapKoliMenurutToko00.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
