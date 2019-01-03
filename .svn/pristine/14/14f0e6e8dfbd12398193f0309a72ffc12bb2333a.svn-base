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
    public partial class frmRptAnalisaTokoFilter : ISA.Toko.BaseForm
    {
        public frmRptAnalisaTokoFilter()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptAnalisaTokoFilter_Load(object sender, EventArgs e)
        {
            rangeAnalisa.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeAnalisa.ToDate = new DateTime(rangeAnalisa.FromDate.Value.Year, rangeAnalisa.FromDate.Value.Month + 1, 1).AddDays(-1);
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCabang.CabangID))
            {
                MessageBox.Show("ID Cabang belum dipilih!","Laporan Analisa Toko",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cbCabang.Focus();
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_AnalisaToko"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeAnalisa.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeAnalisa.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, cbCabang.CabangID));
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
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeAnalisa.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeAnalisa.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", string.IsNullOrEmpty(cbCabang.CabangID) == true ? "Semua" : cbCabang.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptAnalisaToko.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();
        }
    }
}
