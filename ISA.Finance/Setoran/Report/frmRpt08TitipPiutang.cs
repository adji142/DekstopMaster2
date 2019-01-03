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
    public partial class frmRpt08TitipPiutang : ISA.Finance.BaseForm
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
                rptParams.Add(new ReportParameter("Title", "LAPORAN TITIPAN PELUNASAN PIUTANG"));
                //call report viewer

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);
                pTable.Add(ds.Tables[1]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsSetoran_Data");
                pDatasetName.Add("dsSetoran_Data1");

                frmReportViewer ifrmReport = new frmReportViewer("Setoran.Report.rpt08TitipPiutang.rdlc", rptParams, pTable,pDatasetName);
                ifrmReport.Text = "Global";
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

        public frmRpt08TitipPiutang()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt08TitipPiutang_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("rsp_Setoran_08_TitipanPelunasanPiutang"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
