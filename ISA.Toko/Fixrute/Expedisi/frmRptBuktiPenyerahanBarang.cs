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
    public partial class frmRptBuktiPenyerahanBarang : ISA.Toko.BaseForm
    {
        public frmRptBuktiPenyerahanBarang()
        {
            InitializeComponent();
        }

        private void frmRptBuktiPenyerahanBarang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate  = DateTime.Now;
            rdoShift1.Checked = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                   
                    db.Commands.Add(db.CreateCommand("rsp_BuktiPenyerahanBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    if (rdoShift1.Checked)
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar,"1"));    
                    }
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No Data!!!");
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptBuktiPenyerahanBarang.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
