using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Expedisi
{
    public partial class frmRptRekapKoliFilter : ISA.Toko.BaseForm
    {


        public frmRptRekapKoliFilter()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    if (rdbSales.Checked==true)
                    {
                        db.Commands.Add(db.CreateCommand("rsp_RekapKoli_MenurutSales"));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_RekapKoli_MenurutToko]"));
                       //db.Commands.Add(db.CreateCommand("rsp_RekapKoli"));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    if (rdbShift1.Checked==true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, "1"));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, "2"));
                    }
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    if (rdbSales.Checked == true)
                    {
                        DisplayReport2(dt);
                    }
                    else
                    {
                        DisplayReport(dt);
                    }
                  
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

        private void frmRptRekapKoliFilter_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;

            rdbShift1.Checked = true;
            rdbSales.Checked = true;
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            if (rdbShift1.Checked==true)
            {
                rptParams.Add(new ReportParameter("Shift", "1"));
            }
            else{
                rptParams.Add(new ReportParameter("Shift", "2"));
            }
          
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapKoli.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        private void DisplayReport2(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            if (rdbShift1.Checked == true)
            {
                rptParams.Add(new ReportParameter("Shift", "1"));
            }
            else
            {
                rptParams.Add(new ReportParameter("Shift", "2"));
            }
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapKoli3.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
