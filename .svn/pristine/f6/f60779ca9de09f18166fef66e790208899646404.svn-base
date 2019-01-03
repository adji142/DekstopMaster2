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

namespace ISA.Toko.Laporan.Toko
{
    public partial class frmRptAnalisaPer3BulanFilter : ISA.Toko.BaseForm
    {
        public frmRptAnalisaPer3BulanFilter()
        {
            InitializeComponent();
        }

        private void frmRptAnalisaPer3BulanFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Analisa per 3 Bulan";
            this.Text = "Laporan";
            rdbTgl.FromDate = DateTime.Now.AddDays(-90);
            rdbTgl.ToDate = DateTime.Now;
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl.FromDate.ToString() == "" || rdbTgl.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl, "Range Tanggal masih kosong");
                valid = false;
                rdbTgl.Focus();
                goto SelesaiValidate;
            }

            TimeSpan tsTanggal = ((DateTime)rdbTgl.ToDate).Subtract((DateTime)rdbTgl.FromDate);
            int tmSpan = tsTanggal.Days;
            if (tmSpan > 95 || tmSpan < 85)
            {
                errorProvider1.SetError(rdbTgl, "Range tanggal salah");
                valid = false;
                rdbTgl.Focus();
                goto SelesaiValidate;
            }

        SelesaiValidate:
            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_AnalisaPEr3Bulan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    
                    if (lookupToko.NamaToko != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (lookupSales.NamaSales != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (txtKota.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    
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
            //construct parameter
            string periode, fromDate, toDate;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            fromDate = ((DateTime)rdbTgl.FromDate).ToString("MM/dd/yyyy");
            toDate = ((DateTime)rdbTgl.ToDate).ToString("MM/dd/yyyy");
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("FromDate", fromDate));
            rptParams.Add(new ReportParameter("ToDate", toDate));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptAnalisaPer3Bulan.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();
        } 


        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupSales_Load(object sender, EventArgs e)
        {

        }

        private void lookupToko_Leave(object sender, EventArgs e)
        {
            if (lookupToko.NamaToko.Trim()=="")
            {
                lookupToko.KodeToko = "";
            }
        }

        private void cmdCLOSE_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbTgl_Leave(object sender, EventArgs e)
        {
           
        }

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales=="")
            {
                lookupSales.SalesID = "";
            }
        }
        
        
    }
}
