using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;


namespace ISA.Finance.Piutang.Report
{
    public partial class frmRptOmsetVsBayar : ISA.Controls.BaseForm
    {
        public frmRptOmsetVsBayar()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptOmsetVsBayar_Load(object sender, EventArgs e)
        {
            DateTime today = GlobalVar.DateOfServer;
            DateTime firstDay = new DateTime(today.Year, today.Month, 1);
            rdbTgl.FromDate = firstDay;
            rdbTgl.ToDate = today;

        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (!rdbTgl.FromDate.HasValue || !rdbTgl.ToDate.HasValue)
            {
                MessageBox.Show("Tanggal harus diisi lengkap.");
                return;
            }

            DateTime fromDate = (DateTime)rdbTgl.FromDate;
            DateTime toDate = (DateTime)rdbTgl.ToDate;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_OmsetVsBayar]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, toDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);

            }
            catch (System.Exception ex)
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DateTime today = GlobalVar.DateOfServer;
                string fromDate = ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy");
                string toDate = ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy");

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", string.Format("Periode: {0} s.d. {1}", fromDate, toDate)));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserName + " " + today.ToString("yyyyMMdd hhmmss")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rptOmsetVsNota.rdlc", rptParams, dt, "dsOmsetVsNota_Data");
                ifrmReport.Text = "Omset vs Pembayaran";
                ifrmReport.Show();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


    }
}
