using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Laporan.Barang
{
    public partial class frmRegisterJualPerKelompokBarangFilter : ISA.Toko.BaseForm
    {
        public frmRegisterJualPerKelompokBarangFilter()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmYes_Click(object sender, EventArgs e)
        {
            if (rngDateTextBox.FromDate == null || rngDateTextBox.ToDate == null)
            {
                rngDateTextBox.Focus();
                return;
            }
            try
            {
                string datetype = null;
                if (rbtReturJual.Checked)
                    datetype = "1";
                else
                    datetype = "2";

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    string category = string.Empty;
                    string jenis = string.Empty;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_register_returjual_perkelompokbarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@STARTDATE", SqlDbType.DateTime, rngDateTextBox.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ENDDATE", SqlDbType.DateTime, rngDateTextBox.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@OPTION", SqlDbType.VarChar,datetype));

                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rngDateTextBox.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rngDateTextBox.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptRegisterJualPerKelompokBarang.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        private void frmRegisterJualPerKelompokBarangFilter_Load(object sender, EventArgs e)
        {
            rngDateTextBox.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rngDateTextBox.ToDate = DateTime.Now;
            rngDateTextBox.Focus();
        }

    }
}
