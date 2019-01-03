using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Kasir.Report
{
    public partial class frmRptBukuBank : ISA.Finance.BaseForm
    {
         Guid _rowID;
         string _namaBank, _noRek, _jnsRek;
         double saldoAwal = 0, saldoAkhir = 0, mutasi = 0;
        public frmRptBukuBank(Form caller, Guid rowID, string namaBank, string noRek, string jnsRek)
        {
            _rowID = rowID;
            _namaBank = namaBank;
             _noRek = noRek;
             _jnsRek = jnsRek;
             Caller = caller;
            InitializeComponent();
        }

        private void frmRptBukuBank_Load(object sender, EventArgs e)
        {
            tbPeriode.FromDate = DateTime.Today;
            tbPeriode.ToDate = DateTime.Today;
            tbNamaBank.Text = _namaBank;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_BukuBank"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tbPeriode.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tbPeriode.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                saldoAwal = Convert.ToDouble(ISA.Common.Tools.isNullOrEmpty(dt.Rows[0]["Saldo"].ToString(),"0").ToString());
                saldoAkhir = Convert.ToDouble(ISA.Common.Tools.isNullOrEmpty(dt.Rows[dt.Rows.Count - 1]["Saldo"].ToString(), "0").ToString());
                mutasi = saldoAkhir - saldoAwal;

                DisplayReport(dt);

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

        private void DisplayReport(DataTable dt)
        {

            string periode = String.Format("{0}", tbPeriode.FromDate.Value.ToString("dd-MMM-yyyy"))+" S/D "+String.Format("{0}",  tbPeriode.ToDate.Value.ToString("dd-MMM-yyyy"));



            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("periode", periode));
            rptParams.Add(new ReportParameter("nama", _namaBank));
            rptParams.Add(new ReportParameter("noRek", _noRek));
            rptParams.Add(new ReportParameter("jnsRek", _jnsRek));
            rptParams.Add(new ReportParameter("saldoAwal", saldoAwal.ToString("#,###")));
            rptParams.Add(new ReportParameter("saldoAkhir", saldoAkhir.ToString("#,###")));
            rptParams.Add(new ReportParameter("mutasi", mutasi.ToString("#,###")));


            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptBukuBank.rdlc", rptParams, dt, "dsBank_Data2");
            ifrmReport.ExportToExcel(ifrmReport.Name);

        }
    }
}
