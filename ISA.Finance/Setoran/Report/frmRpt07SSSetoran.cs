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
    public partial class frmRpt07SSSetoran : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {
            try
            {
                ISA.Controls.MonthYearBox m = new ISA.Controls.MonthYearBox();
                m.Year = Setorans.Year;
                m.Month = Setorans.Month;

                string periode = string.Empty;
                 periode = String.Format("{0} ",m.LastDateOfMonth.ToString("MMMM-yyyy"));

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", "LAPORAN SELISIH SETORAN"));
                rptParams.Add(new ReportParameter("Title2", "CABANG: PT. SURYA ANUGRAH SETIAABADI  "));
                rptParams.Add(new ReportParameter("FirstDate", m.FirstDateOfMonth.ToString("yyyy/MM/dd")));
                rptParams.Add(new ReportParameter("LastDate", m.LastDateOfMonth.Day.ToString()));
                //call report viewer

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);
              //  pTable.Add(ds.Tables[1]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsSetoran_data2");
               // pDatasetName.Add("dsSetoran_Data1");

                frmReportViewer ifrmReport = new frmReportViewer("Setoran.Report.rpt07RSetoran.rdlc", rptParams, pTable, pDatasetName);
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

        public frmRpt07SSSetoran()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt07SSSetoran_Load(object sender, EventArgs e)
        {
            

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            ISA.Controls.MonthYearBox m = new ISA.Controls.MonthYearBox();
            m.Year = Setorans.Year;
            m.Month = Setorans.Month;


            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_Setoran_07_RRSelisih]"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
                    db.Commands[0].Parameters.Add(new Parameter("@RpMin", SqlDbType.Money,Setorans.Min));
                    db.Commands[0].Parameters.Add(new Parameter("@LMin", SqlDbType.Bit, Setorans.LMin ? 1 :0));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 )
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
