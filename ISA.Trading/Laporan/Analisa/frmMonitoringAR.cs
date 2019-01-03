using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.Trading.DataTemplates;
using ISA.DAL;

namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmMonitoringAR : Form
    {
        DateTime _FromDate1, _ToDate1, _FromDate2, _ToDate2;
        DataTable dt = new DataTable();
        public frmMonitoringAR()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (dateTextBox1.DateValue >= GlobalVar.DateOfServer)
            {
                MessageBox.Show("Inputan Tanggal Harus Lebih Kecil Dari Tanggal Hari Ini", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dateTextBox1.DateValue.HasValue == false)
            {
                dateTextBox1.Focus();
                return;
            }

            try
            {
                GetDataMonitoringAR();
                //MessageBox.Show(dt.Rows.Count.ToString());
                if (dt.Rows.Count == 0)
                {
                    if (MessageBox.Show("Data Tidak Ada, Apakah Anda Ingin Memprosesnya?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_MonitoringAR_Daily"));
                            db.Commands[0].Parameters.Add(new Parameter("@ToDate1", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        GetDataMonitoringAR();
                    }
                    else
                    {
                        return;
                    }
                }

                DisplayReport(dt);

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

        private void frmMonitoringAR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = GlobalVar.DateOfServer.AddDays(-1);
            dateTextBox1.Focus();
            txtInitPerusahaan.Text = GlobalVar.PerusahaanID;
        }

        private void GetDataMonitoringAR()
        {
            _ToDate1 = (DateTime)dateTextBox1.DateValue;
            _FromDate1 = new DateTime(_ToDate1.Year, _ToDate1.Month, 1);

            _ToDate2 = _FromDate1.AddDays(-1);
            _FromDate2 = new DateTime(_ToDate2.Year, _ToDate2.Month, 1);

            this.Cursor = Cursors.WaitCursor;

            using (Database db = new Database())
            {
                /*
                db.Commands.Add(db.CreateCommand("rsp_Monitoring_ARv02"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate1", SqlDbType.DateTime, _FromDate1));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate1", SqlDbType.DateTime, _ToDate1));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate2", SqlDbType.DateTime, _FromDate2));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate2", SqlDbType.DateTime, _ToDate2));
                */
                db.Commands.Add(db.CreateCommand("rsp_Monitoring_ARv03"));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTextBox1.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                dt = db.Commands[0].ExecuteDataTable();
            }
        }
        
        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {
            try
            {
                string Bln1 = _FromDate1.ToString("MMM/yyyy");
                string Bln2 = _FromDate2.ToString("MMM/yyyy");
                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", _FromDate1.ToString("dd/MMM/yyyy"), _ToDate1.ToString("dd/MMM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Bln1", Bln1));
                rptParams.Add(new ReportParameter("Bln2", Bln2));
                rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd/MM/yyyy")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Analisa.rptMonitoringAR.rdlc", rptParams, dt, "dsMonitoringAR_Data1");
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
