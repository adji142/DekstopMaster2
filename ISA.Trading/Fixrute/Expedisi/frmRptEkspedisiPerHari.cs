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

namespace ISA.Trading.Expedisi
{
    public partial class frmRptEkspedisiPerHari : ISA.Trading.BaseForm
    {
        int hari;
        public frmRptEkspedisiPerHari()
        {
            InitializeComponent();
        }

        private void frmRptEkspedisiPerHari_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            txtHari.Text = "0";
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                hari = 0;
                hari = Convert.ToInt32(txtHari.Text);
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    

                    db.Commands.Add(db.CreateCommand("rsp_EkspedisiPerHari"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Nhari", SqlDbType.Int, hari));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("NO Data !!!");
                    return;
                }
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptEkspedisiPerhari.rdlc", rptParams, dt, "dsEkspedisi_Data");
                ifrmReport.Show();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                hari = 0;
                hari = Convert.ToInt32(txtHari.Text);
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("rsp_EkspedisiPerHari"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Nhari", SqlDbType.Int, hari));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("NO Data !!!");
                    return;
                }
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

    }
}
