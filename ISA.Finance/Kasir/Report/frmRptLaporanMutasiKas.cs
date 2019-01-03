using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.Kasir
{
    public partial class frmRptLaporanMutasiKas : ISA.Finance.BaseForm
    {
        DateTime fromDate, toDate;
        string posko;
        DataSet dsMutasi;
        public frmRptLaporanMutasiKas()
        {
            InitializeComponent();
        }

        private void frmRptLaporanMutasiKas_Load(object sender, EventArgs e)
        {
            tbRange.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            tbRange.ToDate = DateTime.Today;
            txtPID.Text = GlobalVar.PerusahaanID;
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            fromDate = (DateTime)tbRange.FromDate;
            toDate = (DateTime)tbRange.ToDate;
            posko = GlobalVar.PerusahaanID;

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_MutasiKas"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@posko", SqlDbType.VarChar, txtPID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dsMutasi = db.Commands[0].ExecuteDataSet();
                }

                RptMutasiKas(dsMutasi);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void RptMutasiKas(DataSet ds)
        {

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("fromDate", String.Format("{0:dd-MMM-yyyy}", fromDate)));
            rptParams.Add(new ReportParameter("toDate", String.Format("{0:dd-MMM-yyyy}", toDate)));
            rptParams.Add(new ReportParameter("Kodecabang", GlobalVar.Gudang));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);


            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsMutasiKas_Data");
            pDatasetName.Add("dsMutasiKas_Data1");

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptLaporanMutasiKas.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Text = "lap_mutasikas";
            ifrmReport.ExportToExcel(ifrmReport.Name);
        }
    }
}
