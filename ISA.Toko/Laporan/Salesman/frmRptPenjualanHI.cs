using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Laporan.Salesman
{
    public partial class frmRptPenjualanHI : ISA.Toko.BaseForm
    {
        public frmRptPenjualanHI()
        {
            InitializeComponent();
        }

        private void frmRptPenjualanHI_Load(object sender, EventArgs e)
        {
            rgbTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTanggal.ToDate = DateTime.Now;
            rdoHBeli.Checked = true;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (cboCabang1.SelectedValue.ToString().Trim() != ""
                && cboCabang2.SelectedValue.ToString().Trim() != ""
                && cboCabang1.SelectedValue.ToString().Trim() == cboCabang2.SelectedValue.ToString().Trim())
            {
                MessageBox.Show("Cabang 1 dan Cabang 2 tidak boleh sama", "Perhatian");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor; DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenjualanHI"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTanggal.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTanggal.ToDate.Value));

                    if (cboCabang1.SelectedValue.ToString().Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cboCabang1.SelectedValue.ToString()));
                    }
                    if (cboCabang2.SelectedValue.ToString().Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cboCabang2.SelectedValue.ToString()));
                    }

                    dt = db.Commands[0].ExecuteDataTable();


                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);

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
            string harga = "Beli";
            if (rdoRataRata.Checked)
                harga = "AVG";
            string cabang = "(semua)";
            if (cboCabang1.SelectedValue.ToString().Trim() != "")
                cabang = cboCabang1.SelectedValue.ToString().Trim();

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbTanggal.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Cabang", cabang));
            rptParams.Add(new ReportParameter("Harga", harga));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptPenjualanHI.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
