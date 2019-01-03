using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Piutang.Report
{
    public partial class frmRpt1SaldoBersihPiutangNota : ISA.Finance.BaseForm
    {
#region "Procedure"
        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Tanggal Jatuh Tempo", "TglJthTempo");
            dt.Rows.Add("Tanggal Nota", "TglTransaksi");
            dt.Rows.Add("Sales", "NamaSales,NamaToko,NoTransaksi");
            dt.Rows.Add("Nama Toko", "NamaToko");
            dt.Rows.Add("ID Wilayah", "WilID");
            dt.Rows.Add("Nomor Nota", "NoTransaksi");
            dt.Rows.Add("Nilai Nota Terbesar", "RpJual");
            dt.Rows.Add("Nilai Sisa Terbesar", "RpSisa");


            dt.DefaultView.Sort = "Label ASC";
            cboSort.DataSource = dt;
            cboSort.DisplayMember = "Label";
            cboSort.ValueMember = "Value";
        }

        private void DisplayReport(DataTable dt)
        {
            try
            {
                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt1SaldoBersihPiutangNota_V2.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = "kpBGT";
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

        private void DisplayReport2(DataTable dt)
        {
            try
            {
                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt2SaldoBersihPiutangNota.rdlc", rptParams, dt , "dsKpiutang_DataB");
                ifrmReport.Text = "kpBGT2";
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

        private void DisplayReport3(DataTable dt)
        {
            try
            {
                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt3SaldoBersihPiutangNota.rdlc", rptParams, dt, "dsKpiutang_DataC"); //"dsKpiutang_DataC"
                ifrmReport.Text = "kpBGT3";
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

        private void DisplayReport4(DataTable dt)
        {
            try
            {
                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt4SaldoBersihPiutangNota.rdlc", rptParams, dt, "dsKpiutang_DataD");
                ifrmReport.Text = "kpBGT4";
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


#endregion

        public frmRpt1SaldoBersihPiutangNota()
        {
            InitializeComponent();
        }

        private void frmRpt1SaldoBersihPiutangNota_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate =Convert.ToDateTime("01/01/2000");
            rangeDateBox1.ToDate = DateTime.Now;
            AddTypeSort();
            cboSort.SelectedValue = "TglTransaksi";
            rdb1Tunai.Checked = true;
            rdb2Nota.Checked = true;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_1SaldoBersihPiutangNota"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTgl", SqlDbType.VarChar, (rdb2Nota.Checked) ? "TglTransaksi" : "TglJthTempo"));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, (rdb1Tunai.Checked) ? "Tunai" : ((rdb1Kredit.Checked) ? "Kredit":"All")));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar,lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID1", SqlDbType.VarChar, textBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID2", SqlDbType.VarChar, textBox2.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LMinus", SqlDbType.Int, (LMinus.Checked ? 1 : 0)));
                    ds=db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                ds.Tables[0].DefaultView.Sort = cboSort.SelectedValue.ToString() + " ASC";
                if (ds.Tables[0].Rows.Count > 0)
                    DisplayReport(ds.Tables[0].DefaultView.ToTable("tes"));
                //if (ds.Tables[1].Rows.Count > 0)
                //    DisplayReport2(ds.Tables[1].DefaultView.ToTable("tes2"));
                //if (ds.Tables[2].Rows.Count > 0)
                //    DisplayReport3(ds.Tables[2].DefaultView.ToTable("tes3"));
                //if (ds.Tables[3].Rows.Count > 0)
                //    DisplayReport4(ds.Tables[3].DefaultView.ToTable("tes4"));
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

        private void lookupToko1_Load(object sender, EventArgs e)
        {
           
        }        
    }
}
