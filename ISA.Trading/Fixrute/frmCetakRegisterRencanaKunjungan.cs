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
    public partial class frmCetakRegisterRencanaKunjungan : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _sales;
        public frmCetakRegisterRencanaKunjungan()
        {
            InitializeComponent();
        }
        public frmCetakRegisterRencanaKunjungan(Form caller, string sales)
        {
            this.Caller = caller;
            _sales = sales;
            formMode = enumFormMode.New;
            InitializeComponent();
        }

        private void frmCetakRegisterRencanaKunjungan_Load(object sender, EventArgs e)
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
            frmReportViewer ifrmReport = new frmReportViewer("Fixrute.rptRegisterRencanaKunjungan.rdlc", rptParams, dt, "dsCetakRegisterRencanaKunjungan_Data");
            ifrmReport.Show();

        }


        private void cmdYes_Click(object sender, EventArgs e)
        {
            string _KdSales = txtKodeSales.Text;
            DateTime _tgl1 = rangeDateBox1.FromDate.Value;
            DateTime _tgl2 = rangeDateBox1.ToDate.Value;
            string _filterHari = txtHari.Text;
            string _jenis = cbJenis.SelectedText;
            DataSet ds = new DataSet();
            DataTable dt= new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_RegisterRencanaKunjungan"));
                db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, _KdSales));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, _tgl1));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, _tgl2));
                if (_filterHari == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, _filterHari));
                }
                if (_jenis == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, _jenis));
                }
                ds = db.Commands[0].ExecuteDataSet();
                dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada");
                    return;
                }
                else
                {
                    String NamaSales = ds.Tables[1].Rows[0]["NamaSales"].ToString();
                    String KodeSales = ds.Tables[1].Rows[0]["SalesID"].ToString();

                    DisplayReport(dt, NamaSales, KodeSales);
                }
            }
        }
    }
}
