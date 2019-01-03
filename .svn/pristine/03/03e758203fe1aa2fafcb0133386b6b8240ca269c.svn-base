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

namespace ISA.Trading.Laporan.Salesman
{
    public partial class frmRptOmzetPerPos : ISA.Trading.BaseForm
    {

        DateTime tmpDate;
        DateTime tmpDate2;

        private DateTime GetLastDayOfMonth(DateTime dtDate)
        {
            DateTime dtTo = dtDate;
            dtTo = dtTo.AddMonths(1);
            dtTo = dtTo.AddDays(-(dtTo.Day));
            return dtTo;
        }

     
        private void ReloadCBOCab()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    cboCab.ValueMember = "CabangID";
                    cboCab.DisplayMember = "Cab";
                    cboCab.DataSource = dt;
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
            string periode,periode1,periode2,periode3;
            periode = String.Format("{0} s/d {1}", ((DateTime)fromDate.DateValue).ToString("dd/MM/yyyy"), ((DateTime)toDate.DateValue).ToString("dd/MM/yyyy"));
            periode3 = String.Format(((DateTime)toDate.DateValue).ToString());
           
            periode2 = String.Format((new DateTime(tmpDate2.Year, tmpDate2.Month+1, 1)).ToString()); 
            periode1 = String.Format(((DateTime)fromDate.DateValue).ToString());
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Periode1", periode1));
            rptParams.Add(new ReportParameter("Periode2", periode2));
            rptParams.Add(new ReportParameter("Periode3", periode3));
            if (rdbA.Checked==true)
            {
                rptParams.Add(new ReportParameter("Mode", "Netto"));
            }else
            {
                rptParams.Add(new ReportParameter("Mode", "Brutto"));
            }
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptOmzetPerPos.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        public frmRptOmzetPerPos()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptOmzetPerPos_Load(object sender, EventArgs e)
        {
            fromDate.DateValue =   DateTime.Now;
            tmpDate = (DateTime)fromDate.DateValue;
            tmpDate2 = (DateTime)fromDate.DateValue;
            toDate.DateValue = GetLastDayOfMonth(tmpDate.AddMonths(3));
            ReloadCBOCab();
            radioButton2.Checked = true;
            fromDate.Focus();
        }

        private void fromDate_Leave(object sender, EventArgs e)
        {
            tmpDate = (DateTime)fromDate.DateValue;
            tmpDate2 = (DateTime)fromDate.DateValue; 
            toDate.DateValue = GetLastDayOfMonth(tmpDate.AddMonths(2));
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;    DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_OmzetPerPost"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cboCab.Text));
                  


                    if (radioButton2.Checked==true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.Int,2));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.Int, 1));
                    }


                    dt = db.Commands[0].ExecuteDataTable();


                } if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);
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
}
