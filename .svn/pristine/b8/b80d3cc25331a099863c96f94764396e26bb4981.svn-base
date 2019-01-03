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
    public partial class frmRptBrgBlmTerpenuhiFilter : ISA.Toko.BaseForm
    {
        public frmRptBrgBlmTerpenuhiFilter()
        {
            InitializeComponent();
        }

        private void frmRptBrgBlmTerpenuhiFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Barang Belum Terpenuhi";
            this.Text = "Pembelian";
            rdbTglRQ.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglRQ.ToDate = DateTime.Now;
            rdbTglRQ.Focus();
        }

        private void rdbTglRQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdYES.PerformClick();
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglRQ.FromDate.ToString() == "" || rdbTglRQ.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglRQ, "Range Tgl RQ masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_BrgBlmTerpenuhiDari11"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglRQ.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglRQ.ToDate));
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglRQ.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglRQ.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptBrgBlmTerpenuhi.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
