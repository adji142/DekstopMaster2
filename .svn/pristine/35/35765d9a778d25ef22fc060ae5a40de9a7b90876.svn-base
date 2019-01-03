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

namespace ISA.Finance.Register.Report
{
    public partial class frmRpt06RencanaTagih : ISA.Finance.BaseForm
    {
        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)monthYearBox1.LastDateOfMonth;


                string periode = string.Empty;
                periode = String.Format("{0} ", da.ToString("Y"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Tittle", "RENCANA TAGIHAN NOTA DAN BGC TOLAK (BRG.A)"));

                frmReportViewer ifrmReport = new frmReportViewer("Register.Report.rpt06RencanaTagihA.rdlc", rptParams, ds.Tables[0], "dsTagihan_Data1");
                ifrmReport.Text = "BRG-A";
                ifrmReport.Show();


                rptParams.RemoveAt(1);
                rptParams.Add(new ReportParameter("Tittle", " RENCANA TAGIHAN NOTA DAN BGC TOLAK (BRG. B-E)"));
                frmReportViewer ifrmReport1 = new frmReportViewer("Register.Report.rpt06RencanaTagihA.rdlc", rptParams, ds.Tables[1], "dsTagihan_Data1");
                ifrmReport1.Text = "BRG-B-E";
                ifrmReport1.Show();

                rptParams.RemoveAt(1);
                rptParams.Add(new ReportParameter("Tittle", "RENCANA TAGIHAN NOTA DAN BGC TOLAK"));
                frmReportViewer ifrmReport2 = new frmReportViewer("Register.Report.rpt06RencanaTagihB.rdlc", rptParams, ds.Tables[2], "dsTagihan_Data1");
                ifrmReport2.Text = "RENCANA TAGIHAN";
                ifrmReport2.Show();

            

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


        private void AddData()
        {
            try
            {
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_UserWilID_List"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "UserID+'='+UserName");
                dt.Columns.Add(cConcatenated);
                cboUserWilID.DropDownStyle = ComboBoxStyle.DropDownList;
                cboUserWilID.DataSource = dt;
                cboUserWilID.DisplayMember = "Concatenated";
                cboUserWilID.ValueMember = "UserID";
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

        public frmRpt06RencanaTagih()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt06RencanaTagih_Load(object sender, EventArgs e)
        {
            monthYearBox1.Month = DateTime.Now.Month;
            monthYearBox1.Year = DateTime.Now.Year;
            this.WindowState = FormWindowState.Normal;
            AddData();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_06RencanaTagih]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, cboUserWilID.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@InitUser", SqlDbType.VarChar, SecurityManager.UserInitial));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0)
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
    }
}
