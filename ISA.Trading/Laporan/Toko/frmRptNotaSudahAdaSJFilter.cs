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
    public partial class frmRptNotaSudahAdaSJFilter : ISA.Trading.BaseForm
    {
        public frmRptNotaSudahAdaSJFilter()
        {
            InitializeComponent();
        }

        private void frmRptNotaSudahAdaSJFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Sudah dibikinkan SJ";
            this.Text = "Laporan";
            rdbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl.ToDate = DateTime.Now;
            rdbTgl.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl.FromDate.ToString() == "" || rdbTgl.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl, "Range tanggal masih kosong");
                valid = false;
            }
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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_NotaSudahAdaSJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initPrs", SqlDbType.VarChar,GlobalVar.PerusahaanID )); 
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptNotaSudahAdaSJ.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
