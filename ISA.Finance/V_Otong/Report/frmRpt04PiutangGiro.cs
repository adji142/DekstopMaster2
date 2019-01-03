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

namespace ISA.Finance.V_Otong.Report
{
    public partial class frmRpt04PiutangGiro : ISA.Finance.BaseForm
    {
        public frmRpt04PiutangGiro()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt04PiutangGiro_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_VOtong_04RekapPiutangGiro]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt.DefaultView.ToTable("tes"));
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

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;


                string periode = string.Empty;
                periode = String.Format("{0} ", da.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("Title", "OVERDUE PER SALES"));

                frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt04PiutangGiro.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = " OVERDUE PER SALES";
                ifrmReport.Show();

                //call report viewer

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
