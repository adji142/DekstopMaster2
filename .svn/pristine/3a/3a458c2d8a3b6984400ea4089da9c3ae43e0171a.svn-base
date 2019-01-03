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

namespace ISA.Trading.Pembelian
{
    public partial class frmRptRekapReturBeliFilter : ISA.Trading.BaseForm
    {
        public frmRptRekapReturBeliFilter()
        {
            InitializeComponent();
        }

        private void frmRptRekapReturBeliFilter_Load(object sender, EventArgs e)
        {            
            this.Title = "Laporan Rekap Retur Beli";
            this.Text = "Pembelian";
            rdbTglKeluar.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglKeluar.ToDate = DateTime.Now;
            rdbTglKeluar.Focus();
        }

        private void rdbTglKeluar_KeyPress(object sender, KeyPressEventArgs e)
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

            if (rdbTglKeluar.FromDate.ToString() == "" || rdbTglKeluar.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglKeluar, "Range Tgl. Keluar masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_ReturBeli_RekapReturBeli"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglKeluar.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglKeluar.ToDate));
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglKeluar.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglKeluar.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptRekapReturBeli.rdlc", rptParams, dt, "dsReturPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
