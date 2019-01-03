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
    public partial class frmRptReturBeliPerBarangFilter : ISA.Toko.BaseForm
    {
        public frmRptReturBeliPerBarangFilter()
        {
            InitializeComponent();
        }

        private void frmRptReturBeliPerBrgFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Retur Beli per Barang";
            this.Text = "Pembelian";
            rdbTglRetur.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglRetur.ToDate = DateTime.Now;
            rdbTglRetur.Focus();
        }

        private void rdbTglRetur_KeyPress(object sender, KeyPressEventArgs e)
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

            if (rdbTglRetur.FromDate.ToString() == "" || rdbTglRetur.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglRetur, "Range Tgl. Nota Retur masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_ReturBeli_ReturBeliPerBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglRetur.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglRetur.ToDate));
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglRetur.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglRetur.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptReturBeliPerBarang.rdlc", rptParams, dt, "dsReturPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
