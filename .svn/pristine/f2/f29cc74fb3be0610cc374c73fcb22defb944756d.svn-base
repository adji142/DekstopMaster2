using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Kasir.Report
{
    public partial class frmRptBankRekonsiliasi : ISA.Toko.BaseForm
    {
        Guid _rowID;
        string _namaBank, _noAcc;
        public frmRptBankRekonsiliasi(Form caller, Guid rowID, string namaBank, string noAcc)
        {
            this.Caller = caller;
            _rowID = rowID;
            _namaBank = namaBank;
            _noAcc = noAcc;
            InitializeComponent();
        }

        private void frmRptBankRekonsiliasi_Load(object sender, EventArgs e)
        {
            tbNamaBank.Text = _namaBank;
            tbTgl.DateValue = DateTime.Today;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_Bank_Rekonsiliasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tbTgl.DateValue.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                frmBukuBankBrowse frm = new frmBukuBankBrowse();
                frm = (frmBukuBankBrowse)Caller;
                frm.HeaderRefresh(_rowID);
                frm.HeaderFindRow("RowIDH", _rowID.ToString());
                frm.DetailRefresh();

                DisplayReport(dt);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayReport(DataTable dt)
        {

            string periode = String.Format("{0}", tbTgl.DateValue.Value.ToString("dd-MMM-yyyy"));

            double saldoRKBank = tbSaldoRKBank.GetDoubleValue;
            double saldoBankRK = Convert.ToDouble(dt.Rows[0]["jml3"]);
            double selisih = saldoRKBank - saldoBankRK;

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("periode", periode));
            rptParams.Add(new ReportParameter("nama", _namaBank));
            rptParams.Add(new ReportParameter("noAcc", _noAcc));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptBankRekonsiliasi.rdlc", rptParams, dt, "dsBank_Data");
            ifrmReport.ExportToExcel(ifrmReport.Name);

            if (selisih != 0)
                MessageBox.Show("Saldo RK Selisih " + selisih.ToString("#,###"));
            else
                MessageBox.Show("Saldo RK Sama");   
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
