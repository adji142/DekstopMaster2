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

namespace ISA.Trading.Penjualan
{
    public partial class frmLaporanPointPromoPenjualan : ISA.Controls.BaseForm
    {
        public frmLaporanPointPromoPenjualan()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (rangePeriode.FromDate != null && rangePeriode.ToDate != null)
            {
                try
                {
                    string model = "";
                    if (rbRekap.Checked)
                        model = "0";
                    else if (rbDetail.Checked)
                        model = "1";

                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_PointPromo_Penjualan"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(lkptoko.KodeToko, DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@model", SqlDbType.VarChar, model));
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
            else
            {
                MessageBox.Show("Masukkan periode tanggal", "Periode Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rangePeriode.Focus();
            }

        }


        private void DisplayReport(DataTable dt)
        {
            string periode = String.Format("{0} s/d {1}", ((DateTime)rangePeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangePeriode.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptLaporanPointPromo.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void frmLaporanPointPromoPenjualan_Load(object sender, EventArgs e)
        {
            rangePeriode.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangePeriode.ToDate = DateTime.Now;
        }
    }
}
