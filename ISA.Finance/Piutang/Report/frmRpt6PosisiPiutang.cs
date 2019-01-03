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
    public partial class frmRpt6PosisiPiutang : ISA.Finance.BaseForm
    {

        public frmRpt6PosisiPiutang()
        {
            InitializeComponent();
        }


        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Nama Toko", "NamaToko ASC");
            dt.Rows.Add("Penjualan Terbesar", "RpJual DESC");
            dt.Rows.Add("Overdue Terbesar", "RpOverdue DESC");
            dt.Rows.Add("SaldoAwal Terbesar", "SaldoAwal DESC");
           
            dt.Rows.Add("Saldo Akhir Terbesar", "SaldoAkhir DESC");

            //dt.DefaultView.Sort = "Label ASC";
            cboSort.DataSource = dt;
            cboSort.DisplayMember = "Label";
            cboSort.ValueMember = "Value";
        }

        private void KodePos()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_KodePos_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.Rows.Add("", "", "",DateTime.Now );
                dt.DefaultView.Sort = "KodePos ASC";
                cboKodePos.DropDownStyle = ComboBoxStyle.DropDownList;
                cboKodePos.DataSource = dt.DefaultView;
                cboKodePos.DisplayMember = "KodePos";
                cboKodePos.ValueMember = "Wilayah";
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

       

        private void KodeTrans()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_KodeTransaksi_List]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.Rows.Add("", "");
                dt.DefaultView.Sort = "KodeTransaksi ASC";
                cboTrans.DropDownStyle = ComboBoxStyle.DropDownList;
                cboTrans.DataSource = dt.DefaultView;
                cboTrans.DisplayMember = "KodeTransaksi";
                cboTrans.ValueMember = "KodeTransaksi";
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DisplayReport(DataTable dt)
        {

            try
            {

                DateTime da = monthYearBox1.FirstDateOfMonth;
                DateTime da2 = monthYearBox1.LastDateOfMonth;

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", " Rekapitulasi Piutang"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt6PosisiPiutang.rdlc", rptParams, dt, "dsKpiutang_Data");
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
                    
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_6PosisiPiutang"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@KodePos", SqlDbType.VarChar, cboKodePos.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, wilIDComboBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, (rdb2Kredit.Checked?"K":(rdb2Tunai.Checked?"T":"T|K"))));

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

        private void frmRpt6PosisiPiutang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            AddTypeSort();
            monthYearBox1.Year = DateTime.Now.Year;
            monthYearBox1.Month = DateTime.Now.Month;
            KodePos();
            KodeTrans();
            rdb1Wilayah.Checked = true;
            cboKodePos.Enabled = false;
            rdb2Tunai.Checked = true;
            wilIDComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        }

      

        private void rdb1Wilayah_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1Wilayah.Checked)
            {
                cboKodePos.Enabled = false;
                wilIDComboBox1.Enabled = true;
            }else
            {
                cboKodePos.Enabled = true;
                wilIDComboBox1.Enabled = false;
            }
        }

        private void rdb1KodePos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1KodePos.Checked)
            {
                cboKodePos.Enabled = true;
                wilIDComboBox1.Enabled = false;
            }
            else
            {
                cboKodePos.Enabled = false;
                wilIDComboBox1.Enabled = true;
            }
        }
    }
}
