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
    public partial class frmRptExpDalamKotaFilter : ISA.Toko.BaseForm
    {
        string shift = "0";
        string via = "";

        public frmRptExpDalamKotaFilter()
        {
            InitializeComponent();
        }

        private void frmRptExpDalamKotaFilter_Load(object sender, EventArgs e)
        {
            rdbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglSuratJalan.ToDate = DateTime.Now;
            rdoShift1.Checked = true;
            rdoKantor.Checked = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (rdoShift1.Checked == true)
                shift = "1";
            if (rdoShift2.Checked == true)
                shift = "2";
            if (rdoSemuaShift.Checked == true)
                shift = "0";

            if (rdoKantor.Checked == true)
                via = "K";
            if (rdoGudang.Checked == true)
                via = "G";
            if (rdoKantorGudang.Checked == true)
                via = "A";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_ExpedisiDalamKota"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglSuratJalan.ToDate));
                    if (shift != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, int.Parse(shift)));
                    if (via != "A")
                        db.Commands[0].Parameters.Add(new Parameter("@via", SqlDbType.VarChar, via));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No Data !");
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglSuratJalan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglSuratJalan.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Shift", shift));
            rptParams.Add(new ReportParameter("Via", via));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptExpDalamKota.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();
        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
