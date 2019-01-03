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
    public partial class frmRpt3PenyelesainNotaPersalesman : ISA.Finance.BaseForm
    {

        private void AddTypeSort()
        {
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Label");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("Value");
            dt.Columns.Add(dc2);
            dt.Rows.Add("Tanggal J.Tempo", "KodeSales, TglJthTempo");
            dt.Rows.Add("Tanggal Nota", "KodeSales, TglTransaksi");
            dt.Rows.Add("Nomor Nota", "KodeSales, NoTransaksi");
            dt.Rows.Add("Nama Toko", "KodeSales, NamaToko");
            dt.Rows.Add("Wilayah", "KodeSales, WilID");
            
            //dt.DefaultView.Sort = "Label ASC";
            cboSort.DataSource = dt;
            cboSort.DisplayMember = "Label";
            cboSort.ValueMember = "Value";
        }

        
        private void DisplayReport(DataTable dt)
        {

            try
            {

                DateTime da = monthYearBox1.FirstDateOfMonth;
                DateTime da2 = monthYearBox1.LastDateOfMonth;

                string periode=string.Empty;
                periode = String.Format("{0} s/d {1}",da.ToString("dd/MM/yyyy"),da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", ": Penyelesaian Transaksi"));
                rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rpt3PenyelesainNotaPersalesman.rdlc", rptParams, dt, "dsKpiutang_Data");
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


        public frmRpt3PenyelesainNotaPersalesman()
        {
            InitializeComponent();
        }

        private void frmRpt3PenyelesainNotaPersalesman_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            AddTypeSort();
           
            rdb1JTempo.Checked = true;
            rdb2Lunas.Checked = true;
            monthYearBox1.Year = DateTime.Now.Year;
            monthYearBox1.Month = DateTime.Now.Month;
           
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
                    
                    db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_3PenyelesaianNotaPerSales]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTgl", SqlDbType.VarChar, (rdb1JTempo.Checked ? "TglJthTempo" : "TglTransaksi")));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeTransaksi", SqlDbType.VarChar, (rdb2Lunas.Checked ? "Lunas" : (rdb2Belum.Checked ? "Belum" :"All"))));
                   
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                dt.DefaultView.Sort = cboSort.SelectedValue.ToString() + " ASC";
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
