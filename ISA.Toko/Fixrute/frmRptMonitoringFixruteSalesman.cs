using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;


namespace ISA.Toko.Fixrute
{
    public partial class frmRptMonitoringFixruteSalesman : ISA.Toko.BaseForm
    {
        public frmRptMonitoringFixruteSalesman()
        {
            InitializeComponent();
        }

        private void frmRptMonitoringFixruteSalesman_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)dateTimePicker1.Value).ToString("dd/MM/yyyy"), ((DateTime)dateTimePicker2.Value).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Fixrute.RptMonitoringFixruteSalesman.rdlc", rptParams, dt, "dsMonitoringFixruteSalesman_Data");
            ifrmReport.Show();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_MonitoringFixruteSalesman"));
                    if (lookupSales1.SalesID == "")
                    {
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, lookupSales1.SalesID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                   // MessageBox.Show(dt.Rows.Count.ToString());
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                    }
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
    }
}

