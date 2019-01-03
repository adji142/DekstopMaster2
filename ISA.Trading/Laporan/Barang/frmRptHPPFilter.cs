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

namespace ISA.Trading.Laporan.Barang
{
    public partial class frmRptHPPFilter : ISA.Trading.BaseForm
    {
        public frmRptHPPFilter()
        {
            InitializeComponent();
        }

        private void frmInfoHPP_Load(object sender, EventArgs e)
        {
            dtbTanggal.DateValue = DateTime.Now;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_HPPdanHargaJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dtbTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@stockName", SqlDbType.VarChar, txtNamaStok.Text));
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
            string tanggal;
            tanggal = ((DateTime)dtbTanggal.DateValue).ToString("dd/MM/yyyy");

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Tanggal", tanggal));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptHPP.rdlc", rptParams, dt, "dsLaporanBarang_Data");
            ifrmReport.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
