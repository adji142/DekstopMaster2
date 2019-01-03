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

namespace ISA.Toko.Laporan.Salesman
{
    public partial class frmRptNotaBelumDiSelesaikanOlehChecker : ISA.Toko.BaseForm
    {
        public frmRptNotaBelumDiSelesaikanOlehChecker()
        {
            InitializeComponent();
        }

        private void frmRptNotaBelumDiSelesaikanOlehChecker_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;  DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                  
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_NotaBelumDiSelesaikanChecker"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));

                    if (lookupSales.SalesID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    }

                    if ((lookupPostArea.PostID != "") || (lookupPostArea.PostID == "ALL"))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Pos", SqlDbType.VarChar, lookupPostArea.PostID));
                    }

                    dt = db.Commands[0].ExecuteDataTable();


                } if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
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

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales == "")
            {
                lookupSales.SalesID = "";
            }
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Sales", lookupSales.SalesID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Pos", lookupPostArea.PostID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptNotaBelumDiSelesaikanChecker.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
