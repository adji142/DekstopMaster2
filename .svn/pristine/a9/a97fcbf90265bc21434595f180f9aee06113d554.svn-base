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
    public partial class frmRpt22KetTagih : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = new DateTime(dateTextBox1.DateValue.Value.Year, dateTextBox1.DateValue.Value.Month, 1);
                DateTime da2 = dateTextBox1.DateValue.Value;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                DateTime d1 = (DateTime)dateTextBox1.DateValue;
               
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", " PIUTANG JT DAN OVERDUE"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("Col1", da.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("Col2", "s/d " + da2.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("Col3", da2.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("WilID", "PIUTANG NOTA - WIL : "+wilIDComboBox1.Text));

                List<ReportParameter> rptParams2 = new List<ReportParameter>();
                rptParams2.Add(new ReportParameter("Periode", periode));
                rptParams2.Add(new ReportParameter("Title", " REKAP REALISASI TAGIHAN "));
                rptParams2.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams2.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams2.Add(new ReportParameter("Col1", da.ToString("dd/MM/yyyy")));
                rptParams2.Add(new ReportParameter("Col2", "s/d "+da2.ToString("dd/MM/yyyy")));
                rptParams2.Add(new ReportParameter("Col3", da2.ToString("dd/MM/yyyy")));
                rptParams2.Add(new ReportParameter("WilID", "PIUTANG GIRO TOLAK - WIL : " + wilIDComboBox1.Text));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt22KetTagihA.rdlc", rptParams, ds.Tables[0], "dsKpiutang_Data2");
                ifrmReport.Text = "Lap 20 A";
                ifrmReport.Show();
                frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.Report.rpt22KetTagihB.rdlc", rptParams2, ds.Tables[1], "dsKpiutang_Data2");
                ifrmReport2.Text = "Lap 20B";
                ifrmReport2.Show();
                

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

        public frmRpt22KetTagih()
        {
            InitializeComponent();
        }

        private void frmRpt22KetTagih_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_22KetTagih]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, textBox1.Text.Trim()));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(ds);
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
