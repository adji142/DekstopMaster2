using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Fixrute
{
    public partial class frmCetakRencanaKunjungan : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _sales;
        public frmCetakRencanaKunjungan(Form caller, string sales)
        {
            this.Caller = caller;
            _sales = sales;
            formMode = enumFormMode.New;
            InitializeComponent();
        }
        public frmCetakRencanaKunjungan()
        {
            InitializeComponent();
        }

        private void frmCetakRencanaKunjungan_Load(object sender, EventArgs e)
        {
            txtKodeSales.Text = _sales;
            txtKodeSales.Enabled = false;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt, String NamaSales, String KodeSales)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaSales", NamaSales));
            rptParams.Add(new ReportParameter("KodeSales", KodeSales));
            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Fixrute.rptRencanaKunjungan.rdlc", rptParams, dt, "dsRencanaKunjungan_Data");
            ifrmReport.Show();
            
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_RencanaKunjungan"));
                    db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, _sales));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    ds = db.Commands[0].ExecuteDataSet();
                    dt = ds.Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                    }
                    String NamaSales = ds.Tables[1].Rows[0]["NamaSales"].ToString();
                    String KodeSales = ds.Tables[1].Rows[0]["SalesID"].ToString();

                    DisplayReport(dt, NamaSales, KodeSales);
                }
            }
            catch (Exception ex)
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
