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
    public partial class frmRpt4PenyelesainNotaPerWilayah : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataTable dt)
        {

            try
            {



                string periode;
                periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", ": Penyelesaian Transaksi"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt4PenyelesainNotaPerWilayah.rdlc", rptParams, dt, "dsKpiutang_Data");
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


        public frmRpt4PenyelesainNotaPerWilayah()
        {
            InitializeComponent();
        }

        private void frmRpt4PenyelesainNotaPerWilayah_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            wilIDComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            rdb1Toko.Checked = true;
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
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_4PenyelesaianNotaPerWilayah"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@LMinus", SqlDbType.Int, (LMinus.Checked ? 0 : 1)));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                dt.DefaultView.Sort = (rdb1Toko.Checked) ? "NamaToko, WilID, TglTransaksi" : "WilID, TglJthTempo" + " ASC";
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
