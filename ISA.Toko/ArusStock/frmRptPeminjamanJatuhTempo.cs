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

namespace ISA.Toko.ArusStock
{
    public partial class frmRptPeminjamanJatuhTempo : ISA.Toko.BaseForm
    {
        public frmRptPeminjamanJatuhTempo()
        {
            InitializeComponent();
        }

        private void frmRptPeminjamanJatuhTempo_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                cmdYes.PerformClick();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_PeminjamanJatuhTempo"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Cab", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                   
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data");
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


        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptPinjamanJatuhTempo.rdlc", rptParams, dt, "dsPinjam_Data");
            ifrmReport.Show();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
