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
    public partial class frmRptBuktiPenyerahanBarangFilter : ISA.Toko.BaseForm
    {
        public frmRptBuktiPenyerahanBarangFilter()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_BuktiPenyerahanBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, TanggalNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, TanggalNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, rbShift1.Checked == true ? "1" : "2" ));
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

        private void frmLaporanBuktiPenyerahanBarang_Load(object sender, EventArgs e)
        {
            TanggalNota.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            TanggalNota.ToDate = DateTime.Now;
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)TanggalNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)TanggalNota.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Shift", rbShift1.Checked == true ? "1":"2"));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptBuktiPenyerahanBarang.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
