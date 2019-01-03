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

namespace ISA.Finance.V_Otong.Report
{
    public partial class frmRpt01RekapTongolan : ISA.Finance.BaseForm
    {
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

                //DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "UserID+'='+UserName");
                //dt.Columns.Add(cConcatenated);
                //cboUserWilID.DropDownStyle = ComboBoxStyle.DropDownList;
                //cboUserWilID.DataSource = dt;
                //cboUserWilID.DisplayMember = "Concatenated";
                //cboUserWilID.ValueMember = "UserID";

                dt.Rows.Add("");
                dt.DefaultView.Sort = "UserID";
                cboUserWilID.DataSource = dt;
                cboUserWilID.DisplayMember = "UserID";
                cboUserWilID.ValueMember = "UserID";


                //DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "UserID+'='+UserName");
                //dt.Columns.Add(cConcatenated);
                //cboUserWilID.DropDownStyle = ComboBoxStyle.DropDownList;
                //cboUserWilID.DataSource = dt;
                //cboUserWilID.DisplayMember = "Concatenated";
                //cboUserWilID.DisplayMember = "UserID";
                //cboUserWilID.ValueMember = "UserID";
            
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

            try
            {

                DateTime da = (DateTime)rangeDateBox1.FromDate;
                DateTime da2 = (DateTime)rangeDateBox1.ToDate;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", " REKAP TONGOLAN DAN OVERDUE - Wilayah : "+cboUserWilID.SelectedValue.ToString()));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + ", " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt01RekapTongolan.rdlc", rptParams, dt, "dsKpiutang_Data2");
                ifrmReport.Text = "Rekap Tongolan";
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

        public frmRpt01RekapTongolan()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt1RekapTongolan_Load(object sender, EventArgs e)
        {
            AddData();
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("rsp_VOtong_01RekapTongolan"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Actual", SqlDbType.Bit, checkBox1.Checked?1:0));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, cboUserWilID.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, rdb1FB2FE2.Checked?"FB2|FE2":(rdb1FB4FE4.Checked?"FB4|FE4":"") ));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(dt.DefaultView.ToTable("tes"));
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
