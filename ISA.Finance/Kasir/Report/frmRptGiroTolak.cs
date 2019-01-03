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

namespace ISA.Finance.Kasir
{
    public partial class frmRptGiroTolak : ISA.Finance.BaseForm
    {
        public frmRptGiroTolak()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {

            try
            {


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_GiroTolak"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@perusahaanID", SqlDbType.VarChar, txtPID.Text));
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

            string fromDate = String.Format("{0}", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy"));
            string toDate = String.Format("{0}", rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy"));


            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("fromDate", fromDate));
            rptParams.Add(new ReportParameter("toDate", toDate));



            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptGiroTolak.rdlc", rptParams, dt, "dsGiro_Data");
            ifrmReport.ExportToExcel(ifrmReport.Name);

        }

        private void frmRptGiroTolak_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            txtPID.Text = GlobalVar.PerusahaanID;
        }



    
    }
}
