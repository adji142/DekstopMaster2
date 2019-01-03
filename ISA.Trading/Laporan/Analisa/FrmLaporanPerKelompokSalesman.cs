using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlTypes;

namespace ISA.Trading.Laporan.Analisa
{
    public partial class FrmLaporanPerKelompokSalesman : ISA.Trading.BaseForm
    {
        public FrmLaporanPerKelompokSalesman()
        {
            InitializeComponent();
        }
        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = rangeDateBox1.FromDate.Value;
                DateTime da2 = rangeDateBox1.ToDate.Value;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                DateTime d1 = (DateTime)rangeDateBox1.FromDate.Value;

                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                //rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                //rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Analisa.RptPerkelompokSalesman_A.rdlc", rptParams, ds.Tables[0], "DsKategoriSales_Data1");
                ifrmReport.Text = "LAPORAN PERKELOMPOK SALESMAN (A)";

                //call report viewer
                frmReportViewer ifrmReport1 = new frmReportViewer("Laporan.Analisa.RptPerkelompokSalesman_B.rdlc", rptParams, ds.Tables[1], "DsKategoriSales_Data2");
                ifrmReport1.Text = "LAPORAN PERKELOMPOK SALESMAN (B)";

                ifrmReport.Show();
                ifrmReport1.Show();
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
        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[rsp_OmzPerKelompokSalesman]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
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
