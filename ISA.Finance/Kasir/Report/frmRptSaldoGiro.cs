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
    public partial class frmRptSaldoGiro : ISA.Finance.BaseForm
    {
        public frmRptSaldoGiro()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptSaldoGiro_Load(object sender, EventArgs e)
        {
            dbPeriode.DateValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            txtPID.Text = GlobalVar.PerusahaanID;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (rdoBGD.Checked)
            {
                BGD();
            }
            else if (rdoBGT.Checked)
            {
                BGT();
            }
        }

        private void BGD()
        {
            try
            {


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_SaldoGiroDitangan"));
                    db.Commands[0].Parameters.Add(new Parameter("@endDate", SqlDbType.DateTime, dbPeriode.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@perusahaanID", SqlDbType.VarChar, txtPID.Text));                    
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReportBGD(dt);
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


        private void DisplayReportBGD(DataTable dt)
        {

            string endDate = String.Format("{0}", ((DateTime) dbPeriode.DateValue).ToString("dd-MMM-yyyy"));
            


            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("endDate", endDate));
           

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptSaldoGiroDitangan.rdlc", rptParams, dt, "dsGiro_Data");
            ifrmReport.ExportToExcel(ifrmReport.Name);

        }



        private void BGT()
        {
            try
            {


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_SalDoGiroTitip"));
                    db.Commands[0].Parameters.Add(new Parameter("@endDate", SqlDbType.DateTime, dbPeriode.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@perusahaanID", SqlDbType.VarChar, txtPID.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReportBGT(dt);
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


        private void DisplayReportBGT(DataTable dt)
        {

            string endDate = String.Format("{0}", ((DateTime)dbPeriode.DateValue).ToString("dd-MMM-yyyy"));



            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("endDate", endDate));


            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptSaldoGiroTitip.rdlc", rptParams, dt, "dsGiro_Data");
            ifrmReport.ExportToExcel(ifrmReport.Name);

        }

    }
}
