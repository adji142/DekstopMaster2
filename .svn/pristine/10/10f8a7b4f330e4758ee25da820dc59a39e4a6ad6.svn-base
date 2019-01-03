using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmRpt01LaporanJournals : ISA.Finance.BaseForm
    {
        public frmRpt01LaporanJournals()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetControl()
        {
            monthYearBox1.Month = DateTime.Now.Month;
            monthYearBox1.Year = DateTime.Now.Year;
            lookupGudang1.GudangID = "";
        }

        private void frmRpt01LaporanJournals_Load(object sender, EventArgs e)
        {
            SetControl();            
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_01LaporanJournals"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
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
        }

        private void ShowReport(DataTable dt)
        {
            //construct parameter
            string periode;
            string kodeGudang;
            periode = String.Format("{0} s/d {1}", ((DateTime)monthYearBox1.FirstDateOfMonth).ToString("dd-MMM-yyyy"), ((DateTime)monthYearBox1.LastDateOfMonth).ToString("dd-MMM-yyyy"));

            if (string.IsNullOrEmpty(lookupGudang1.GudangID))
            {
                kodeGudang = "ALL";
            }
            else
            {
                kodeGudang = lookupGudang1.GudangID;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode",periode));
                rptParams.Add(new ReportParameter("kodeGudang", kodeGudang));                

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rpt01LaporanJournals.rdlc", rptParams, dt, "dsJurnal_Data");
                ifrmReport.Text = "Laporan Journals";
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
