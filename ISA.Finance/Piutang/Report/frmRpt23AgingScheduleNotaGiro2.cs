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
    public partial class frmRpt23AgingScheduleNotaGiro2 : ISA.Finance.BaseForm
    {
        private void AddType()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            string a = "O-B-Z-H-L-A-C-V-J-2-4-G-T";
            string[] aa = a.Split('-');
            dt.Rows.Add("All", string.Empty);
            foreach (string b in aa)
            {
                dt.Rows.Add(b, b);
            }

            //dt.DefaultView.Sort = "Label ASC";
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Label";
            comboBox1.ValueMember = "Value";
        }

        private void AddTypeWilID()
        {
            this.Width = 100;

            if (this.DesignMode)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPostArea = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_WilayahID_LIST"));
                    dtPostArea = db.Commands[0].ExecuteDataTable();
                }
                dtPostArea.Rows.Add("");
                dtPostArea.DefaultView.Sort = "WilID ASC";
                wilIDComboBox1.DataSource = dtPostArea;
                wilIDComboBox1.DisplayMember = "WilID";
                wilIDComboBox1.ValueMember = "WilID";
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

                DateTime da = new DateTime(dateTextBox1.DateValue.Value.Year, dateTextBox1.DateValue.Value.Month, 1);
                DateTime da2 = dateTextBox1.DateValue.Value;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                DateTime d1 = (DateTime)dateTextBox1.DateValue;

                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                if (checkBox1.Checked)
                {
                    rptParams.Add(new ReportParameter("Title", " LAPORAN AGING SCHEDULE PIUTANG NOTA (RAGU RAGU)"));
                }
                else {
                    rptParams.Add(new ReportParameter("Title", " LAPORAN AGING SCHEDULE PIUTANG NOTA"));
                }
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2A.rdlc", rptParams, ds.Tables[0], "dsKpiutang_Data");
                ifrmReport.Text = "LAPORAN AGING SCHEDULE PIUTANG NOTA (A)";
               

                rptParams.RemoveAt(3);
                rptParams.Add(new ReportParameter("Title", " LAPORAN AGING SCHEDULE PIUTANG GIRO"));

                //call report viewer
                frmReportViewer ifrmReport1 = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2B.rdlc", rptParams, ds.Tables[1], "dsKpiutang_Data1");
                ifrmReport1.Text = "LAPORAN AGING SCHEDULE PIUTANG GIRO (B)";
               


                rptParams.RemoveAt(3);
                rptParams.Add(new ReportParameter("Title", " LAPORAN REKAP AGING SCHEDULE PIUTANG"));

                //call report viewer
                frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2C.rdlc", rptParams, ds.Tables[2], "dsKpiutang_Data2");
                ifrmReport2.Text = "LAPORAN REKAP AGING SCHEDULE PIUTANG (C)";
                

                rptParams.RemoveAt(3);
                rptParams.Add(new ReportParameter("Title", " LAPORAN REKAP AGING SCHEDULE PIUTANG"));

                //call report viewer
                frmReportViewer ifrmReport3 = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2D.rdlc", rptParams, ds.Tables[3], "dsKpiutang_Data3");
                ifrmReport3.Text = "LAPORAN REKAP AGING SCHEDULE PIUTANG (D)";
               

                //call report viewer
                frmReportViewer ifrmReport4 = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2E.rdlc", rptParams, ds.Tables[4], "dsKpiutang_Data3");
                ifrmReport4.Text = "LAPORAN REKAP AGING SCHEDULE PIUTANG (E)";

                //call report viewer
                frmReportViewer ifrmReport5 = new frmReportViewer("Piutang.Report.rpt23AgingScheduleNotaGiro2F_V2.rdlc", rptParams, ds.Tables[5], "dsKpiutang_Data1");
                ifrmReport5.Text = "LAPORAN REKAP AGING SCHEDULE PIUTANG (F)";

                ifrmReport.Show();
                ifrmReport1.Show();
                ifrmReport2.Show();
                ifrmReport3.Show();
                ifrmReport4.Show();
                ifrmReport5.Show();
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

        public frmRpt23AgingScheduleNotaGiro2()
        {
            InitializeComponent();
        }

        private void frmRpt23AgingScheduleNotaGiro2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
            AddType();
            AddTypeWilID();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_23AgingSchedule2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, comboBox1.SelectedValue.ToString()));
                    if (checkBox1.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@piutang", SqlDbType.VarChar, "prr"));
                    }
                    else {
                        db.Commands[0].Parameters.Add(new Parameter("@piutang", SqlDbType.VarChar, ""));
                    }
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
    }
}
