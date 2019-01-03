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

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptHargaKhususFilter : ISA.Trading.BaseForm
    {
        public frmRptHargaKhususFilter()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_HargaKhusus"));
                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rdbDate.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rdbDate.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbDate.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbDate.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptHargaKhusus.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void frmRptHargaKhusus_Load(object sender, EventArgs e)
        {
            rdbDate.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbDate.ToDate = DateTime.Now;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
