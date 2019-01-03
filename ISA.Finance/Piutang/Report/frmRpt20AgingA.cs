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
    public partial class frmRpt20AgingA : ISA.Finance.BaseForm
    {
        DataTable dtToko = new DataTable();

        private void AddType()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            string a = "KO-KB-KZ-KH-KL-KA-KC-KV-KJ-K2-K4-TO-TB-TZ-TH-TL-TA-TC-TV-TJ-T2-T4";
            string[] aa=a.Split('-');
            dt.Rows.Add("All", string.Empty);
            foreach (string b in aa)
            {
                dt.Rows.Add(b, b);
            }
          
            dt.DefaultView.Sort = "Label ASC";
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Label";
            comboBox1.ValueMember = "Value";
        }
        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
                DateTime da2 = (DateTime)dateTextBox1.DateValue;

                string periode = string.Empty;
                periode = String.Format("{0} ", da2.ToString("dd/MM/yyyy"));
                DateTime d1 = (DateTime)dateTextBox1.DateValue;
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd-MMM-yyyy")));
                rptParams.Add(new ReportParameter("Title", " LAPORAN AGING SCHEDULE CASH-FLOW NOTA"));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt20AgingAA.rdlc", rptParams, ds.Tables[0], "dsKpiutang_Data2");
                ifrmReport.Text = "Sld.Piutang Blm.JT";
                ifrmReport.Show();

                rptParams.RemoveAt(3);
                rptParams.Add(new ReportParameter("Title", "  LAPORAN REKAP AGING SCHEDULE CASH-FLOW"));
                frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.Report.rpt20AgingAB.rdlc", rptParams, ds.Tables[1], "dsKpiutang_Data2");
                ifrmReport2.Text = "Rekap Piutang Wil.";
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

        public frmRpt20AgingA()
        {
            InitializeComponent();
        }

        private void frmRpt20AgingA_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            lblToko.Text = "";
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
            AddType();

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void commandButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        DataTable dt = new DataTable();
        //        DataSet ds = new DataSet();
        //        Guid RptSesion = Guid.NewGuid();
        //        using (Database db = new Database(GlobalVar.DBName))
        //        {

        //            db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_20AgingSchedule_GetToko]"));
        //            db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text));
        //            dt = db.Commands[0].ExecuteDataTable();
        //        }
        //        int i = 0;
        //        progressBar1.Visible = true;
        //        progressBar1.Maximum = dt.Rows.Count;
        //        progressBar1.Value = 0;

        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            lblToko.Text = dr["NamaToko"].ToString();
        //            using (Database db = new Database(GlobalVar.DBName))
        //            {
        //                db.Commands.Clear();
        //                db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_20AgingSchedule_Populate"));
        //                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
        //                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue));
        //                db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, comboBox1.SelectedValue.ToString()));
        //                db.Commands[0].Parameters.Add(new Parameter("@RptSesion", SqlDbType.UniqueIdentifier, RptSesion));
        //                db.Commands[0].ExecuteNonQuery();
        //            }

        //            Application.DoEvents();
        //            this.Invalidate();
        //            i++;
        //            progressBar1.Value = i;
        //        }

        //        using (Database db = new Database(GlobalVar.DBName))
        //        {
        //            db.Commands.Clear();
        //            db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_20AgingSchedule_GetResult"));
        //            db.Commands[0].Parameters.Add(new Parameter("@RptSesion", SqlDbType.UniqueIdentifier, RptSesion));
        //            ds = db.Commands[0].ExecuteDataSet();
        //        }

        //        if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0)
        //        {
        //            MessageBox.Show("No Data");
        //            return;
        //        }
        //        // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
        //        DisplayReport(ds);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        lblToko.Text = string.Empty;
        //        progressBar1.Value = 0;
        //        progressBar1.Visible = false;
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_AgingScheduleCashFlow"));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, comboBox1.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0)
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
