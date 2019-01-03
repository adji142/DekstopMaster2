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
    public partial class frmRpt17NotaJTOVD : ISA.Finance.BaseForm 
    {
       

        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = monthYearBox1.FirstDateOfMonth;
                DateTime da2 = monthYearBox1.LastDateOfMonth;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                DateTime d1 =(DateTime) dateTextBox1.DateValue;
                string col2 = string.Empty;
                col2 = string.Format("REALISASI  ({0} s/d {1})",monthYearBox1.FirstDateOfMonth.ToString("dd MMM yyyy"), monthYearBox1.LastDateOfMonth.ToString("dd MMM yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", " PIUTANG JT DAN OVERDUE"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));

                List<ReportParameter> rptParams2 = new List<ReportParameter>();
                rptParams2.Add(new ReportParameter("Periode", periode));
                rptParams2.Add(new ReportParameter("Title", " REKAP REALISASI TAGIHAN "));
                rptParams2.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams2.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams2.Add(new ReportParameter("Col1", "TARGET TAGIHAN PIUTANG  (s/d "+d1.ToString("dd MMM yyyy")+" )"));
                rptParams2.Add(new ReportParameter("Col2", col2));
                rptParams2.Add(new ReportParameter("Col3", "REALISASI  (setelah "+monthYearBox1.LastDateOfMonth.ToString("dd MMM yyyy")+")" ));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt17NotaJTOVDA.rdlc", rptParams, ds.Tables[0], "dsKpiutang_Data2");
                ifrmReport.Text = "Lap 17 A";
                ifrmReport.Show();


                if (checkBox1.Checked)
                {
                    frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.Report.rpt17NotaJTOVDB.rdlc", rptParams2, ds.Tables[1], "dsKpiutang_Data4");
                    ifrmReport2.Text = "Lap 17 B";
                    ifrmReport2.Show();
                }

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

        public frmRpt17NotaJTOVD()
        {
            InitializeComponent();
        }


        private void frmRpt17NotaJTOVD_Load(object sender, EventArgs e)
        {   
            this.WindowState = FormWindowState.Normal;
            monthYearBox1.Year = DateTime.Now.Year;
            monthYearBox1.Month = DateTime.Now.Month;
            SetTgl();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_17NotaJTOVD]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate1", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate2", SqlDbType.DateTime, rangeDateBox2.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate3", SqlDbType.DateTime, rangeDateBox3.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate4", SqlDbType.DateTime, rangeDateBox4.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate5", SqlDbType.DateTime, rangeDateBox5.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate1", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate2", SqlDbType.DateTime, rangeDateBox2.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate3", SqlDbType.DateTime, rangeDateBox3.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate4", SqlDbType.DateTime, rangeDateBox4.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate5", SqlDbType.DateTime, rangeDateBox5.ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Api", SqlDbType.Bit, (checkBox1.Checked ? 1:0)));

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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthYearBox1_Validated(object sender, EventArgs e)
        {
            SetTgl();
        }

       

        private void SetTgl()
        {
            int a, b, M, Y;

            a = (int)monthYearBox1.FirstDateOfMonth.Day;
            b = (int)monthYearBox1.LastDateOfMonth.Day;

            rangeDateBox1.FromDate = monthYearBox1.FirstDateOfMonth;
            rangeDateBox5.ToDate = monthYearBox1.LastDateOfMonth;
            dateTextBox1.DateValue = rangeDateBox1.FromDate.Value.AddDays(-1);
            M = (int)monthYearBox1.LastDateOfMonth.Month;
            Y = (int)monthYearBox1.LastDateOfMonth.Year;
            bool t = false;
            string hari = string.Empty;
            DateTime jam = DateTime.Now;
            
            for (int i = a; i <= b; i++)
            {
                jam = new DateTime(Y, M, i);
                
                
                if (jam.DayOfWeek== DayOfWeek.Saturday)
                {
                    t = true;
                }

                if (t)
                {

                    rangeDateBox1.ToDate = jam;
                    rangeDateBox2.FromDate = jam.AddDays(+1);
                    rangeDateBox2.ToDate = rangeDateBox2.FromDate.Value.AddDays(+6);
                    rangeDateBox3.FromDate = rangeDateBox2.ToDate.Value.AddDays(+1);
                    rangeDateBox3.ToDate = rangeDateBox3.FromDate.Value.AddDays(+6);
                    rangeDateBox4.FromDate = rangeDateBox3.ToDate.Value.AddDays(+1);
                    rangeDateBox4.ToDate = rangeDateBox4.FromDate.Value.AddDays(+6);
                    rangeDateBox5.FromDate = rangeDateBox4.ToDate.Value.AddDays(+1);

                    t = false;
                    return;
                }

            }

        }
    }
}
