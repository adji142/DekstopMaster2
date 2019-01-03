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

namespace ISA.Finance.Piutang.Report
{
    public partial class frmRpt5TransaksiBelumLink : ISA.Finance.BaseForm
    {
        private void DisplayReport(DataTable dt)
        {

            try
            {
                string culum = string.Empty;
                switch (cboSort.SelectedValue.ToString())
                {
                case "Nota Retur Jual":
                        culum = "NO.RET";
                	break;
                case "Koreksi Nota Jual":
                    culum = "NO.KOR";
                    break;
                case "Koreksi Retur Jual":
                    culum = "NO.KOR";
                    break;
                case "Penjualan Tunai":
                    culum = "NO.NOTA";
                    break;
                case "Potongan Penjualan":
                    culum = "NO.POT";
                    break;
                }


                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("Title", cboSort.SelectedValue.ToString()));
                rptParams.Add(new ReportParameter("NoTransaksi", culum));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt5TransaksiBelumLink.rdlc", rptParams, dt, "dsKpiutang_Data");
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

        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Retur Jual", "Nota Retur Jual");
            dt.Rows.Add("Koreksi Nota Jual", "Koreksi Nota Jual");
            dt.Rows.Add("Koreksi Retur Jual", "Koreksi Retur Jual");
            dt.Rows.Add("Penjualan Tunai", "Penjualan Tunai");
            dt.Rows.Add("Potongan Penjualan", "Potongan Penjualan");

            //dt.DefaultView.Sort = "Label ASC";
            cboSort.DataSource = dt;
            cboSort.DisplayMember = "Label";
            cboSort.ValueMember = "Value";
        }



        public frmRpt5TransaksiBelumLink()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_5TransaksiBelumLink"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, cboSort.SelectedValue.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                //dt.DefaultView.Sort = cboSort.SelectedValue.ToString() + " ASC";
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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt5TransaksiBelumLink_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            AddTypeSort();
        }
    }
}
