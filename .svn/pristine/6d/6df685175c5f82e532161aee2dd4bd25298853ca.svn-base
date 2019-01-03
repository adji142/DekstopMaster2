using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
namespace ISA.Trading.CSM
{
    public partial class frmLaporanOmsetPerKendaraan : ISA.Trading.BaseForm
    {

        DataSet ds = new DataSet();

        private void laporanOmsetPerkendaraan(string flagKtg)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                string periodReport = txtDate1.DateValue.Value.ToString("dd-MMMM-yyyy") + " s/d " + txtDate2.DateValue.Value.ToString("dd-MMMM-yyyy");
                rptParams.Add(new ReportParameter("periodeReport", periodReport));
                string ttl = "Laporan Omset ";
                if (flagKtg == "INTI")
                {
                    ttl = ttl + "CUSTOMER INTI";
                }
                else if (flagKtg == "MITRAPS")
                {
                    ttl = ttl + "MITRA PS";
                }
                else if (flagKtg == "MITRASAS")
                {
                    ttl = ttl + "MITRA SAS";
                }
                ttl = ttl + " Perkendaraan";
                rptParams.Add(new ReportParameter("title", ttl));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CSM_LaporanOmsetPertypeKendaraan"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglStart", SqlDbType.DateTime, txtDate1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglEnd", SqlDbType.DateTime, txtDate2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, flagKtg));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("CSM.laporanOmzetPerkendaraan.rdlc", rptParams, ds.Tables[0], "dsLaporanOmzetCIPerKendaraan_PerKendaraan");
                    ifrmReport.Text = ttl ;
                    ifrmReport.Show();
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

        public frmLaporanOmsetPerKendaraan()
        {
            InitializeComponent();
            this.Title = "Laporan Omset Per Kendaraan";
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (rbCustomerInti.Checked == true)
            {
                laporanOmsetPerkendaraan("INTI");
            }
            if (rbMitraPS.Checked == true)
            {
                laporanOmsetPerkendaraan("MITRAPS");
            }
            if (rbMitraSAS.Checked == true)
            {
                laporanOmsetPerkendaraan("MITRASAS");
            }
            if (rbCalnCI.Checked == true)
            {
              
            }
            if (rbReg.Checked == true)
            {
                laporanOmsetPerkendaraan("REG");
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanOmsetPerKendaraan_Load(object sender, EventArgs e)
        {
            txtDate2.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtDate1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }
    }
}
