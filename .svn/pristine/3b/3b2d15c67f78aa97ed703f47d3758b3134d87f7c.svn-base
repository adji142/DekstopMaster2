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
    public partial class frmRpt10PenjualanJTBulanDepan : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {
            try
            {
                ISA.Controls.MonthYearBox m = new ISA.Controls.MonthYearBox();
                m.Year = Setorans.Year;
                m.Month = Setorans.Month;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy"), rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy"));

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", "NOTA - NOTA YANG JATUH TEMPO BULAN DEPAN"));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Setoran.Report.rpt10PenjualanJTBulanDepan.rdlc", rptParams, ds.Tables[0], "dsSetoran_Data");
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

        public frmRpt10PenjualanJTBulanDepan()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt10PenjualanJTBulanDepan_Load(object sender, EventArgs e)
        {
            ISA.Controls.MonthYearBox m = new ISA.Controls.MonthYearBox();

            m.Year = Setorans.Year;
            m.Month = Setorans.Month;
            rangeDateBox1.FromDate = m.FirstDateOfMonth;
            rangeDateBox1.ToDate = m.LastDateOfMonth;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.HasValue== false || rangeDateBox1.ToDate.HasValue==false)
            {
                ErrorProvider er = new ErrorProvider();
                er.SetError(rangeDateBox1, "Harap Di ISI");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_Setoran_10_RealisasiJTBulanDepan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSetoran", SqlDbType.DateTime,  Setorans.TglSetoran));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
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
