using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Penjualan
{
    public partial class frmLaporanInputTanggalTerima : ISA.Toko.BaseForm
    {
        public frmLaporanInputTanggalTerima()
        {
            InitializeComponent();
        }

        private void frmLaporanInputTanggalTerima_Load(object sender, EventArgs e)
        {
            rangePeriode.FromDate = DateTime.Now;
            rangePeriode.ToDate = DateTime.Now;
        }

        private void cmdKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Penjualan_InputTanggalTerima")); //cek heri 05042013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    string sorting = "";

                    if (rbIdWil.Checked)
                        sorting = "IdWil";
                    else if (rbKota.Checked)
                        sorting = "Kota";
                    else if (rbNoNota.Checked)
                        sorting = "NoSuratJalan";
                    else if (rbSales.Checked)
                        sorting = "KodeSales";
                    else if (rbTglNota.Checked)
                        sorting = "TglSuratJalan,NoSuratJalan";
                    else if (rbTglTerima.Checked)
                        sorting = "TglTerima,NoSuratJalan";
                    else
                        sorting = "Toko,NoSuratJalan";
                    dt.DefaultView.Sort = sorting;
                    DisplayReport(dt.DefaultView.ToTable());
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rangePeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangePeriode.ToDate).ToString("dd/MM/yyyy"));

            string sorting = string.Empty;

            if (rbIdWil.Checked)
                sorting = "IdWil";
            else if (rbKota.Checked)
                sorting = "Kota";
            else if (rbNoNota.Checked)
                sorting = "NoSuratJalan";
            else if (rbSales.Checked)
                sorting = "KodeSales";
            else if (rbTglNota.Checked)
                sorting = "TglSuratJalan";
            else if (rbTglTerima.Checked)
                sorting = "TglTerima";
            else
                sorting = "Toko";

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Sorting", sorting));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptLaporanInputSerahTerima.rdlc", rptParams, dt, "dsToko_Data2");
            ifrmReport.Show();
        }

        private void rbNoNota_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
