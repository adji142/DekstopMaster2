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

namespace ISA.Toko.Piutang
{
    public partial class frmLaporanPiutang : ISA.Toko.BaseForm
    {
        public frmLaporanPiutang()
        {
            InitializeComponent();
        }

        private void frmLaporanPiutang_Load(object sender, EventArgs e)
        {
            txtRangeDate.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtRangeDate.ToDate = GlobalVar.DateTimeOfServer;
            lookupSales1.SalesID = "";
            lookupToko1.KodeToko = "";
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LaporanPiutang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txtRangeDate.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtRangeDate.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {
            string periode, created, namerdlc, namalaporan;
            periode = "Periode " + DateTime.Parse(txtRangeDate.FromDate.ToString()).ToString("dd/MM/yyyy") + " s/d " + DateTime.Parse(txtRangeDate.FromDate.ToString()).ToString("dd/MM/yyyy");
            created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("NamaPerusahaan", GlobalVar.PerusahaanName));
            rptParams.Add(new ReportParameter("AlamatPerusahaan", GlobalVar.PerusahaanAddress+", "+GlobalVar.PerusahaanKota+" ("+GlobalVar.PerusahaanTelp+")"));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Created", created));


            frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptLaporanPiutang.rdlc", rptParams, dt, "dsLaporanPiutang_Data");
            ifrmReport.Show();

        } 
    }
}
