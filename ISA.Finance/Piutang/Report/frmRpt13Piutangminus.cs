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
    public partial class frmRpt13Piutangminus : ISA.Finance.BaseForm
    {

        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Tgl Jt", "TglJatuhTempo, NoTransaksi,TglJthGiro ASC");
            dt.Rows.Add("Tanggal Nota", "TglTransaksiDetail, NoTransaksi ASC");
            dt.Rows.Add("Sales", "KodeSales,NoTransaksi,TglJthGiro ASC");
            dt.Rows.Add("Nama Toko", "NamaToko,NoTransaksi,TglJthGiro ASC");
            dt.Rows.Add("Wilayah", "WilID,NoTransaksi,TglJthGiro ASC");
            dt.Rows.Add("NoNota", "NoTransaksi,TglJthGiro ASC");
            //dt.DefaultView.Sort = "Label ASC";
            cboSort.DataSource = dt;
            cboSort.DisplayMember = "Label";
            cboSort.ValueMember = "Value";
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
                rptParams.Add(new ReportParameter("Title", " Rekapitulasi Piutang"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt13PiutangMinus.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = "InfoTran";
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

        public frmRpt13Piutangminus()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt13Piutangminus_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            AddTypeSort();
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rdb1TglJT.Checked = true;
            rdb2Tunai.Checked = true;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_13PiutangMinus]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, (rdb2Kredit.Checked ? "K" : (rdb2Tunai.Checked ? "T" : "T|K"))));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTgl", SqlDbType.VarChar, rdb1TglJT.Checked ? "TglJT" : "TglTransaksi"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
               dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
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
