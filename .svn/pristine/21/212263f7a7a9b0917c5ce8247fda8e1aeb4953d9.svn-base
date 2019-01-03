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
    public partial class frmRptAnalisaKunjunganSales : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        public frmRptAnalisaKunjunganSales()
        {
            InitializeComponent();
        }

        private void frmRptAnalisaKunjunganSales_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            getdata();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tidak Ada Data");
                return;
            }
            else
            {
                DisplayReport(dt);
            }
        }

        private void getdata()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[rsp_fixAnalisaKunjunganSales_RealisasiNota]"));
                    if (lookupSales1.SalesID == "")
                    {
                        MessageBox.Show("Kode Salesman harus di isi!");
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, lookupSales1.SalesID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                    
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


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)dateTimePicker1.Value).ToString("dd/MM/yyyy"), ((DateTime)dateTimePicker2.Value).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Fixrute.rptAnalisaKunjunganVsRealisasiNota.rdlc", rptParams, dt, "dsAnalisaKunjungan_Data");
            ifrmReport.Show();
        }
    }
}
