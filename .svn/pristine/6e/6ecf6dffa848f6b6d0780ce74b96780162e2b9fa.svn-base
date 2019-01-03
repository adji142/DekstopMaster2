using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptReturJualPerTokoFilter : ISA.Trading.BaseForm
    {
        public frmRptReturJualPerTokoFilter()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (rngDateTextBox.FromDate == null || rngDateTextBox.ToDate == null || string.IsNullOrEmpty(lkptoko.KodeToko))
            {
                if (rngDateTextBox.FromDate == null)
                    rngDateTextBox.Focus();
                else if (string.IsNullOrEmpty(lkptoko.KodeToko))
                    lkptoko.Focus();
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    string category = string.Empty;
                    string jenis = string.Empty;

                    string alamat = lkptoko.Alamat;
                    string kota = lkptoko.Kota;
                    string namatoko = lkptoko.NamaToko;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_returjual_pertoko"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rngDateTextBox.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rngDateTextBox.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, string.IsNullOrEmpty(lkptoko.KodeToko) ? null : lkptoko.KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    DisplayReport(dt, alamat, kota, namatoko);
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

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt, string alamat, string kota, string namatoko)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rngDateTextBox.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rngDateTextBox.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode",periode));
            rptParams.Add(new ReportParameter("Alamat",alamat));
            rptParams.Add(new ReportParameter("NamaToko",namatoko));
            rptParams.Add(new ReportParameter("Kota",kota));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptReturJualPerToko.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();

        }

        private void frmRptReturJualPerTokoFilter_Load(object sender, EventArgs e)
        {
            rngDateTextBox.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rngDateTextBox.ToDate = DateTime.Now;
        }
    }
}
