using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlTypes;


namespace ISA.Finance.Piutang.Report
{
    public partial class frmOmsetUmurPiutangJS : ISA.Controls.BaseForm
    {
        public frmOmsetUmurPiutangJS()
        {
            InitializeComponent();
        }

        private void frmOmsetUmurPiutangJS_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rdTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdTgl.ToDate = DateTime.Now;
            rdTgl.Focus();

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapOmsetVsUmurPiutangVsJS]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rdTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rdTgl.ToDate));
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

        private void DisplayReport(DataSet ds)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime da = (DateTime)rdTgl.FromDate;
                DateTime da2 = (DateTime)rdTgl.ToDate;

                List<DataTable> dtlist = new List<DataTable>();
                dtlist.Add(ds.Tables[4]);
                dtlist.Add(ds.Tables[5]);

                List<string> dslist = new List<string>();
                dslist.Add("dsOmsetUmurPiutangJS_Data2");
                dslist.Add("dsOmsetUmurPiutangJS_Data21");

                string periode = "", cabangid = "", created = "";
                periode = "Periode : " + String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                cabangid = "Kode Gudang : " + GlobalVar.Gudang;
                created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("CabangID", cabangid));
                rptParams.Add(new ReportParameter("Created", created));

                //Detail
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSDetail.rdlc", rptParams, ds.Tables[0], "dsOmsetUmurPiutangJS_Data");
                ifrmReport.Text = "Laporan Omset VS Umur Piutang VS JS (Detail)";
                ifrmReport.Show();

                //Detail per Toko
                frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSDetailperToko.rdlc", rptParams, ds.Tables[0], "dsOmsetUmurPiutangJS_Data");
                ifrmReport2.Text = "Laporan Omset VS Umur Piutang VS JS (Detail per Toko)";
                ifrmReport2.Show();

                //Rekap per JS
                frmReportViewer ifrmReport3 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSRekapJS.rdlc", rptParams, ds.Tables[1], "dsOmsetUmurPiutangJS_Data");
                ifrmReport3.Text = "Laporan Omset VS Umur Piutang VS JS (Rekap per JS)";
                ifrmReport3.Show();

                //Rekap per Bulan
                frmReportViewer ifrmReport4 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSRekapBulan.rdlc", rptParams, ds.Tables[2], "dsOmsetUmurPiutangJS_Data");
                ifrmReport4.Text = "Laporan Omset VS Umur Piutang VS JS (Rekap per Bulan)";
                ifrmReport4.Show();

                //Rekap per Toko
                frmReportViewer ifrmReport5 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSRekapToko.rdlc", rptParams, ds.Tables[3], "dsOmsetUmurPiutangJS_Data");
                ifrmReport5.Text = "Laporan Omset VS Umur Piutang VS JS (Rekap per Toko)";
                ifrmReport5.Show();

                //Rekap ALL
                frmReportViewer ifrmReport6 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSRekapRataOmsetJS.rdlc", rptParams, dtlist, dslist);
                ifrmReport6.Text = "Laporan Omset VS Umur Piutang VS JS (Rekap ALL)";
                ifrmReport6.Show();

                //Rekap JS
                frmReportViewer ifrmReport7 = new frmReportViewer("Piutang.Report.rptOmsetUmurPiutangJSRekapALLJS.rdlc", rptParams, ds.Tables[6], "dsOmsetUmurPiutangJS_Data");
                ifrmReport7.Text = "Laporan Omset VS Umur Piutang VS JS (Rekap JS)";
                ifrmReport7.Show();

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
