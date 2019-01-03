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
    public partial class frmRptBrgBlmDiterimaFilter : ISA.Toko.BaseForm
    {
        public frmRptBrgBlmDiterimaFilter()
        {
            InitializeComponent();
        }

        private void frmRptBrgBlmDiterimaFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Barang Belum Diterima";
            this.Text = "Pembelian";
            txtTgl.DateValue = DateTime.Now;
            txtTgl.Focus();
        }

        private void txtTgl_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txtTgl.DateValue.ToString() == "")
            {
                errorProvider1.SetError(txtTgl, "Tanggal cut off masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_BrgBlmDiterima"));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, txtTgl.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                string sSum = dt.Compute("SUM(Nilai)", "Nilai IS NOT NULL").ToString();

                if (sSum == "")
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
            string tgl;
            tgl = ((DateTime)txtTgl.DateValue).ToString("dd/MM/yyyy");
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Tanggal", tgl));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptBrgBlmDiterima.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
