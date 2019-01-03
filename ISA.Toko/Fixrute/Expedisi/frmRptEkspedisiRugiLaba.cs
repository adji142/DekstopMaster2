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
    public partial class frmRptEkspedisiRugiLaba : ISA.Toko.BaseForm
    {
       
        public frmRptEkspedisiRugiLaba()
        {
            InitializeComponent();
        }

        private void frmRptEkspedisiRugiLaba_Load(object sender, EventArgs e)
        {
            rangeSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeSuratJalan.ToDate = DateTime.Now;
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Sopir_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@sk", SqlDbType.VarChar, "Sopir"));
                    dt = db.Commands[0].ExecuteDataTable();
                    cboSopir.DataSource = dt;
                    cboSopir.DisplayMember = "Nama";
                    cboSopir.ValueMember = "Nama";
                    if (cboSopir.Items.Count > 0)
                    {
                        cboSopir.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Ekspedisi_LaporanRugiLaba"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeSuratJalan.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, cboSopir.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kmsSopirT", SqlDbType.Money, double.Parse(txtSopirTunai.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@kmsSopirK", SqlDbType.Money, double.Parse(txtSopirKredit.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@kmsKernetT", SqlDbType.Money, double.Parse(txtKernetTunai.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@kmsKernetK", SqlDbType.Money, double.Parse(txtKernetKredit.Text)));

                    dt = db.Commands[0].ExecuteDataTable();
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeSuratJalan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeSuratJalan.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Sopir", cboSopir.Text.Trim()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRugiLaba.rdlc", rptParams, dt, "dsEkspedisi_Data2");
            ifrmReport.Show();
        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
