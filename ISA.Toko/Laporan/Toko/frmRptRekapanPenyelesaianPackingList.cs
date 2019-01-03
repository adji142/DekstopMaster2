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
    public partial class frmRptRekapanPenyelesaianPackingList : ISA.Toko.BaseForm
    {
        public frmRptRekapanPenyelesaianPackingList()
        {
            InitializeComponent();
        }

        private void frmRptRekapanPenyelesaianPackingList_Load(object sender, EventArgs e)
        {
            rangeTanggalNota.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTanggalNota.ToDate = DateTime.Now;
            rangeTanggalNota.Focus();

            this.Text = "Laporan Rekapan Penyelesaian Packing List";
            this.Title = "Rekapan Penyelesaian Packing List";
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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_RekapanPenyelesaianPackingList"));

                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rangeTanggalNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rangeTanggalNota.ToDate));

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

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptRekapanPenyelesaianPackingList.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
