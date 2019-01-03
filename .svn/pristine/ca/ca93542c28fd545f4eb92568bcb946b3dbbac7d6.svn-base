using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using ISA.DAL;


namespace ISA.Finance.Setoran.Report
{
    public partial class frmRpt11Pembayaran3Bulan : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {
            try
            {
                ISA.Controls.MonthYearBox m = new ISA.Controls.MonthYearBox();
                m.Year = Setorans.Year;
                m.Month = Setorans.Month;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString());

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", "Pemabayaran 3 Bulan Terakhir"));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Setoran.Report.rpt11Pembayaran3Bulan.rdlc", rptParams, ds.Tables[1], "dsSetoran_Data");
                ifrmReport.Text = "Lap Bayar 3 Bulan";
                ifrmReport.Show();
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

        public frmRpt11Pembayaran3Bulan()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt11Pembayaran3Bulan_Load(object sender, EventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_Setoran_11_Pembayaran3BulanTerakhir"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSetoran", SqlDbType.DateTime, Setorans.TglSetoran ));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[1].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
