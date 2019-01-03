using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlTypes;

namespace ISA.Finance.Piutang.Report
{
    public partial class frmRpt11UmurPiutang : ISA.Finance.BaseForm
    {
        public frmRpt11UmurPiutang()
        {
            InitializeComponent();
        }

        private void frmRpt11UmurPiutang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
            dateTextBox1.Focus();
        }

        private void DisplayReport(DataTable dt)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
                DateTime da2 = (DateTime)dateTextBox1.DateValue;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", " Rekapitulasi Piutang"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt11UmurPiutang.rdlc", rptParams, dt, "dsKpiutang_Data1");
                ifrmReport.Text = "LAP 8";
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (dateTextBox1.DateValue.HasValue==false)
            {
                dateTextBox1.Focus();
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_11UmurPiutang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue));
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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
