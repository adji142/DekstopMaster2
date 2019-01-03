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

namespace ISA.Toko.Laporan.Barang
{
    public partial class frmInfoRptRekapHPPPenjualan : ISA.Toko.BaseForm
    {
        public frmInfoRptRekapHPPPenjualan()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTanggal.FromDate.ToString() == "" || rdbTanggal.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTanggal, "Range Tanggal masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_RekapHPPPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rdbTanggal.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rdbTanggal.ToDate.Value));
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTanggal.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptInfoRekapHPPPenjualan.rdlc", rptParams, dt, "dsLaporanBarang_Data");
            ifrmReport.Show();
        }

        private void frmInfoRptRekapHPPPenjualan_Load_1(object sender, EventArgs e)
        {
            rdbTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTanggal.ToDate = DateTime.Now;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
