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
    public partial class frmRpt02PemegangKP : ISA.Finance.BaseForm
    {
        int i = 0;
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

        private void DisplayReport(DataTable dt)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
              

                string periode = string.Empty;
                periode = String.Format("{0} ", da.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("Title", "OVERDUE/TONGOLAN GIRO TOLAK"));
                switch (i)
                {

                    case 1:
                        {
                            rptParams.RemoveAt(3);
                            rptParams.Add(new ReportParameter("Title", "OVERDUE/TONGOLAN NOTA PER KP"));
                            frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt02PemegangKP01.rdlc", rptParams, dt, "dsKpiutang_Data");
                            ifrmReport.Text = " OVERDUE/TONGOLAN NOTA PER KP";
                            ifrmReport.Show();
                        }
                        break;
                    case 3:
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt02PemegangKP03.rdlc", rptParams, dt, "dsKpiutang_Data");
                            ifrmReport.Text = " OVERDUE/TONGOLAN GIRO TOLAK";
                            ifrmReport.Show();
                        }
                        break;

                case 2:
                    {
                        rptParams.RemoveAt(3);
                        rptParams.Add(new ReportParameter("Title", "OVERDUE/TONGOLAN GIRO"));
                        frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt02PemegangKP02.rdlc", rptParams, dt, "dsKpiutang_Data");
                        ifrmReport.Text = " OVERDUE/TONGOLAN GIRO";
                        ifrmReport.Show();
                    }
                    break;
                }
                //call report viewer
                //
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


        private void DisplayReport2(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;


                string periode = string.Empty;
                periode = String.Format("{0} ", da.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("T1", Tools.isNull(ds.Tables[2].Rows[0][0],"0").ToString()));
                rptParams.Add(new ReportParameter("T2", Tools.isNull(ds.Tables[2].Rows[0][1], "0").ToString()));
                rptParams.Add(new ReportParameter("Title", "OVERDUE/TONGOLAN NOTA PER KP"));

                frmReportViewer ifrmReport = new frmReportViewer("V_Otong.Report.rpt02PemegangKP00A.rdlc", rptParams, ds.Tables[0], "dsKpiutang_Data");
                ifrmReport.Text = " OVERDUE/TONGOLAN NOTA PER KP";
                ifrmReport.Show();

                rptParams.RemoveAt(5);
                rptParams.Add(new ReportParameter("Title", " DAFTAR PIUTANG PELANGGAN YANG BERMASALAH"));

                //call report viewer
                frmReportViewer ifrmReport1 = new frmReportViewer("V_Otong.Report.rpt02PemegangKP00B.rdlc", rptParams, ds.Tables[1], "dsKpiutang_Data");
                ifrmReport1.Text = "DAFTAR PIUTANG PELANGGAN YANG BERMASALAH";
                ifrmReport1.Show();
                //call report viewer

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

        private void GetGiroTolak()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_VOtong_02RekapPerPemegangKP_03]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

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


        private void GetNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_VOtong_02RekapPerPemegangKP_01]"));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, cboUserWilID.SelectedValue.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

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


        private void GetAudit()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_VOtong_02RekapPerPemegangKP_00]"));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, cboUserWilID.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@UmurNota", SqlDbType.Int, numericTextBox1.GetIntValue));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count==0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport2(ds);
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


        private void GetPiutangGiro()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_VOtong_02RekapPerPemegangKP_02]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, cboUserWilID.SelectedValue.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

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

        public frmRpt02PemegangKP()
        {
            InitializeComponent();
        }

        private void frmRpt02PemegangKP_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
            AddData();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
          if (rdb1GiroTolak.Checked)
          {
              i = 3;
              GetGiroTolak();
          }

          if (rdbPiutangGiro.Checked)
          {
              i = 2;
              GetPiutangGiro();
          }


          if (rdb1Nota.Checked && checkBox1.Checked)
          {
              i = 1;
              GetAudit();
          }

          if (rdb1Nota.Checked && !checkBox1.Checked)
          {
              i = 1;
              GetNota();
          }
        }

        private void rdb1Nota_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1Nota.Checked)
            {
                checkBox1.Visible = true;
            }else
            {
                checkBox1.Visible = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1Nota.Checked && checkBox1.Checked)
            {
                numericTextBox1.Visible = true;
            }
            if (checkBox1.Checked)
            {
                numericTextBox1.Visible = true;
            }else{
                numericTextBox1.Visible = false;
            }
        }
    }
}
