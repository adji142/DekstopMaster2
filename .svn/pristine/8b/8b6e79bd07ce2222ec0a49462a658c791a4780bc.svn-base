using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.VACCDO
{
    public partial class frmReportACCDOviaPIN : ISA.Trading.BaseForm
    {
        public frmReportACCDOviaPIN()
        {
            InitializeComponent();
        }

        private void frmReportACCDOviaPIN_Load(object sender, EventArgs e)
        {
            rdTanggal.FromDate = new DateTime(GlobalVar.DateOfServer.Year,GlobalVar.DateOfServer.Month,1);
            rdTanggal.ToDate = GlobalVar.DateOfServer; 
        }

        private void cmbYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_ACCDO_viaPIN"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdTanggal.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                generateLaporanACCDOviaPIN(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateLaporanACCDOviaPIN(DataTable dt)
        {
            string _KodeGudang;
            _KodeGudang = GlobalVar.Gudang;
            string _periode = "Periode : " + ((DateTime)rdTanggal.FromDate).ToString("dd/MM/yyyy") + " s/d " + ((DateTime)rdTanggal.ToDate).ToString("dd/MM/yyyy");

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("KodeGudang", _KodeGudang));
            rptParams.Add(new ReportParameter("Periode", _periode));

            frmReportViewer ifrmReport = new frmReportViewer("VACCDO.rptLaporanACCviaPIN.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Text = "ACC DO via PIN";
            ifrmReport.Show();
        }
    }
}
