using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Fixrute
{
    public partial class frmRptRegisterKunjunganSales : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();
        public frmRptRegisterKunjunganSales()
        {
            InitializeComponent();
        }

        private void frmRptRegisterKunjunganSales_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_RekapKunjSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tidak Ada Data");
            }

            else
            {
                Report(dt);
            }
        }


        public void Report( DataTable dt)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                string fromdate = string.Format("{0:dd-MMM-yyyy}", dateTimePicker1.Value.ToShortDateString());
                string todate = string.Format("{0:dd-MMM-yyyy}", dateTimePicker2.Value.ToShortDateString());
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("fromdate", fromdate.ToString()));
                rptParams.Add(new ReportParameter("todate", todate.ToString()));
                rptParams.Add(new ReportParameter("Gudang", GlobalVar.Gudang.ToString()));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Fixrute.rptRekapRegKunj.rdlc", rptParams, dt, "dtRekapKunjSales_Data");
                ifrmReport.Text = "Data Register Kinjungan Salesman";
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
