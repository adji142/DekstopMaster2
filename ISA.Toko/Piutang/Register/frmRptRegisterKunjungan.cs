using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Toko.DataTemplates;
using System.Data.SqlTypes;

namespace ISA.Toko.Register
{
    public partial class frmRptRegisterKunjungan : ISA.Toko.BaseForm
    {
        public frmRptRegisterKunjungan()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_Kunjungan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                  
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
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

        private void frmRptRegisterKunjungan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
 
        }

        private void DisplayReport(DataTable dt)
        {

            try
            {

                DateTime da = (DateTime)rangeDateBox1.FromDate;
                DateTime da2 = (DateTime)rangeDateBox1.ToDate;

                string periode = string.Empty;
                periode = String.Format("REGISTER TAGIHAN : {0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                //rptParams.Add(new ReportParameter("Title", " REKAP TONGOLAN DAN OVERDUE - Wilayah"));
                //rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                //rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Register.rptRegisterKunjungan.rdlc", rptParams, dt, "dsTagihan_Data");
                ifrmReport.Text = "Rekap Tongolan";
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
    }
}
