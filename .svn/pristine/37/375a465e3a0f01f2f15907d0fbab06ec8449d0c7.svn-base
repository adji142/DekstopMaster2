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

namespace ISA.Toko.Pembelian
{
    public partial class frmRptRekapKoreksiReturBeliFilter : ISA.Toko.BaseForm
    {
        public frmRptRekapKoreksiReturBeliFilter()
        {
            InitializeComponent();
        }

        private void frmRptRekapKoreksiReturBeliFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Rekap Koreksi Retur Beli";
            this.Text = "Pembelian";
            rdbTglKoreksi.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglKoreksi.ToDate = DateTime.Now;
            rdbTglKoreksi.Focus();
        }

        private void rdbTglKoreksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdYES.Focus();
                cmdYES.PerformClick();
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglKoreksi.FromDate.ToString() == "" || rdbTglKoreksi.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglKoreksi, "Range Tgl. Koreksi masih kosong");
                valid = false;
            }
            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("rsp_ReturBeli_RekapKoreksiReturBeli"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglKoreksi.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglKoreksi.ToDate));
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglKoreksi.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglKoreksi.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptRekapKoreksiReturBeli.rdlc", rptParams, dt, "dsReturPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
