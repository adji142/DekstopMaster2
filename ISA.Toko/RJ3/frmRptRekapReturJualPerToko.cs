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

namespace ISA.Toko.RJ3
{
    public partial class frmRptRekapReturJualPerToko : ISA.Toko.BaseForm
    {
        public frmRptRekapReturJualPerToko()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptRekapReturJualPerToko_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            //if (lookupToko.KodeToko=="")
            //{
            //    lookupToko.Focus();
            //    return;
            //}

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_RekapReturPenjualan_PerToko]")); //cek hr 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    if (lookupToko.KodeToko!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    }
                   
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            if (lookupToko.KodeToko != "")
            {
                rptParams.Add(new ReportParameter("NamaToko", lookupToko.NamaToko));
                rptParams.Add(new ReportParameter("Alamat", lookupToko.Alamat));
                rptParams.Add(new ReportParameter("Kota", lookupToko.Kota));
            }   else
            {
                rptParams.Add(new ReportParameter("NamaToko", "Semua"));
                rptParams.Add(new ReportParameter("Alamat", "-"));
                rptParams.Add(new ReportParameter("Kota", "-"));
            }
            //call report viewer

            frmReportViewer ifrmReport = new frmReportViewer("RJ3.rpRekapReturJualPerToko.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();

        }

        private void lookupToko_Leave(object sender, EventArgs e)
        {
            if (lookupToko.NamaToko.Trim()=="")
            {
                lookupToko.KodeToko = "";
            }
        }
    }
}
