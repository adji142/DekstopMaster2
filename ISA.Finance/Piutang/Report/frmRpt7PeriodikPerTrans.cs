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
    public partial class frmRpt7PeriodikPerTrans : ISA.Finance.BaseForm
    {

        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Tanggal Transaksi", "TglTransaksiDetail");
            dt.Rows.Add("Nama Toko", "NamaToko ASC");
            dt.Rows.Add("id-Wilayah", "WilID ASC");
            dt.Rows.Add("Max Debet", "Debet DESC");
            dt.Rows.Add("Max Kredit", "Kredit DESC DESC");
            dt.Rows.Add("Tgl Jt Giro", "TglJthGiro ASC");
            dt.Rows.Add("NoNota", "NoTransaksi ASC");
            dt.Rows.Add("Tanggal Nota", "TglTransaksi");
            dt.Rows.Add("NoBKM", "NoBKM ASC");
            dt.Rows.Add("NoBG", "NoBG ASC");
            dt.Rows.Add("Bank", "Bank ASC");
            dt.Rows.Add("NoACC", "NoACC ASC");


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
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt7PeriodikPerTrans.rdlc", rptParams, dt, "dsKpiutang_Data");
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

        public frmRpt7PeriodikPerTrans()
        {
            InitializeComponent();
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
                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_7Transaksi]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar,lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, ""));
                    //db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, (rdb2Kredit.Checked ? "K" : (rdb2Tunai.Checked ? "T" : "T|K"))));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeReport", SqlDbType.Int, rdb1Accounting.Checked?1:2));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, ""));
                    //db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, kodeTransComboBox1.KodeTransaksi));
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

        private void frmRpt7PeriodikPerTrans_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            AddTypeSort();
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rdb1Accounting.Checked = true;
            rdb2Tunai.Checked = true;
            //wilIDComboBox1.DropDownStyle = ComboBoxStyle.DropDown;

        }
    }
}
