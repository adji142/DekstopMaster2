using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.GL
{
    public partial class frmRpt09ACatLapKeuangan : ISA.Finance.BaseForm
    {
        DateTime fromDate = new DateTime();
        DateTime toDate = new DateTime();

        public frmRpt09ACatLapKeuangan()
        {
            InitializeComponent();
        }

        private void SetControl()
        {
            monthYearBox1.Month = DateTime.Now.Month;
            monthYearBox1.Year = DateTime.Now.Year;
            lookupGudang1.GudangID = "";
        }

        private void frmRpt09ACatLapKeuangan_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if(rbNeraca.Checked)
            {
                rptNeraca();
            }
            else if (rbLabaRugi.Checked)
            {
                rptLabaRugi();
            }
            else if (rbLabaRugiAkumulasi.Checked)
            {
                rptLabaRugiAkumulasi();
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rptNeraca()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fromDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_09CatatanAtasLaporanKeuangan_A"));
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
                ShowReportNeraca(dt);

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

        private void rptLabaRugi()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fromDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_09CatatanAtasLaporanKeuangan_B"));
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
                ShowReportLabaRugi(dt);

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

        private void rptLabaRugiAkumulasi()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fromDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_09CatatanAtasLaporanKeuangan_C"));
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
                ShowReportLabaRugiAkumulasi(dt);

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


        private void ShowReportNeraca(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime currPeriode = toDate;
            DateTime prevPeriode = fromDate.AddDays(-1);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("ToDate", currPeriode.ToString("dd-MMM-yyyy")));                
                rptParams.Add(new ReportParameter("KodeGudang", lookupGudang1.GudangID));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt09ACatLapKeuangan.rdlc", rptParams, dt, "dsGL_Data");
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

        private void ShowReportLabaRugi(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime currPeriode = toDate;
            DateTime prevPeriode = fromDate.AddDays(-1);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("ToDate", currPeriode.ToString("dd-MMM-yyyy")));
                rptParams.Add(new ReportParameter("KodeGudang", lookupGudang1.GudangID));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt09BCatLapKeuanganrdlc.rdlc", rptParams, dt, "dsGL_Data");
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

        private void ShowReportLabaRugiAkumulasi(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime currPeriode = toDate;
            DateTime prevPeriode = fromDate.AddDays(-1);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("ToDate", currPeriode.ToString("dd-MMM-yyyy")));
                rptParams.Add(new ReportParameter("KodeGudang", lookupGudang1.GudangID));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt09CCatLapKeuangan.rdlc", rptParams, dt, "dsGL_Data");
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
