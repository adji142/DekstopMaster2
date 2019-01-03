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

namespace ISA.Trading.VACCDO
{
    public partial class frmRptAnalisaAuditFilter : ISA.Trading.BaseForm
    {
        DateTime _fromDate, _toDate;
        DateTime _fromTime = DateTime.Now, _toTime = DateTime.Now;
        public frmRptAnalisaAuditFilter()
        {
            InitializeComponent();
        }

        private void frmRptAnalisaAuditFilter_Load(object sender, EventArgs e)
        {
            DataTable dtYear;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtYear = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_GetYearListOfDO")); //cek heri, 13032013
                    dtYear = db.Commands[0].ExecuteDataTable();
                }
                cboYear.DataSource = dtYear;
                cboYear.DisplayMember = "Tahun";
                cboYear.ValueMember = "Tahun";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            cboMonth.SelectedItem = DateTime.Today.Month.ToString();
            cboYear.SelectedValue = DateTime.Today.Year;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!lookupPostArea.textMatch)
            {
                MessageBox.Show("Pos tidak ada");
                lookupPostArea.Focus();
                return;
            }
            _fromDate = DateTime.Parse(cboMonth.SelectedItem + "/1/" + cboYear.SelectedValue.ToString());
            _toDate = _fromDate.AddMonths(1).AddDays(-1);

            try
            {
                _fromTime = DateTime.Now;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_AnalisaAuditDOACC")); //cek heri 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, txtC1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@postID", SqlDbType.VarChar, lookupPostArea.PostID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Tidak ada data...!");
                else
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
            _toTime = DateTime.Now;
            //construct parameter
            string periode, time;
            periode = String.Format("{0} s/d {1}", ((DateTime)_fromDate).ToString("dd/MM/yyyy"), ((DateTime)_toDate).ToString("dd/MM/yyyy"));
            time = String.Format("{0} s/d {1}", ((DateTime)_fromTime).ToString("hh:mm:ss"), ((DateTime)_toTime).ToString("hh:mm:ss"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            DateTime date2 = _toDate;
            DateTime date1 = _fromDate.AddDays(-1);

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Title", "PEMERIKSAAN DO BERDASARKAN ANALISA TRANSAKSI TOKO"));
            rptParams.Add(new ReportParameter("InitPrs", GetInitPrs()));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Date", _fromDate.ToString()));
            rptParams.Add(new ReportParameter("Date1", date1.ToString()));
            rptParams.Add(new ReportParameter("Date2", date2.ToString()));
            rptParams.Add(new ReportParameter("ExecutionTime", time));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("VACCDO.rptAnalisaAudit.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();

        }

        private string GetInitPrs()
        {
            string initGudang = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count != 0)
                {
                    initGudang = dt.Rows[0]["InitGudang"].ToString();
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

            return initGudang;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
