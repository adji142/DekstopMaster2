using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptRegisterKoreksiReturJualFilter : ISA.Trading.BaseForm
    {
        public frmRptRegisterKoreksiReturJualFilter()
        {
            InitializeComponent();
        }

        private void frmRptRegisterKoreksiReturJualFilter_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[rsp_Laporan_Toko_RegisterKoreksiReturJual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                   

                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
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


        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptRegisterKoreksiReturJual.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();

        }
    }
}
