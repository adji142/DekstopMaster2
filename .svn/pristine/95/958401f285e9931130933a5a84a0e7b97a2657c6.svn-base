using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmRpt08CashFlow : ISA.Finance.BaseForm
    {
        DateTime fromDate = new DateTime();
        DateTime toDate = new DateTime();


        public frmRpt08CashFlow()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fromDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_08CashFlow"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                    return;
                }
                ShowReport(dt);

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt08CashFlow_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            monthYearBox1.Month = DateTime.Now.Month;
            monthYearBox1.Year = DateTime.Now.Year;
            lookupGudang1.GudangID = "";
        }

        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime currPeriode = toDate;
            DateTime prevPeriode = fromDate.AddDays(-1);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", currPeriode.ToString("dd-MMM-yyyy") + " dan " + prevPeriode.ToString("dd-MMM-yyyy")));
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserInitial));
                rptParams.Add(new ReportParameter("KodeGudang", lookupGudang1.GudangID));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt08CashFlow.rdlc", rptParams, dt, "dsGL_Data");
                ifrmReport.Text = "Buku Besar";
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
