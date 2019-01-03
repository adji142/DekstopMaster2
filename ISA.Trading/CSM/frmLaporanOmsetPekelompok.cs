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
    public partial class frmLaporanOmsetPekelompok : ISA.Trading.BaseForm
    {
        DataSet dt = new DataSet();




        private void laporanOmsetPerkelompok(string flagKtg)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                string periodReport = txtDate1.DateValue.Value.ToString("dd-MMMM-yyyy") + " s/d " + txtDate2.DateValue.Value.ToString("dd-MMMM-yyyy");
                rptParams.Add(new ReportParameter("periodeReport", periodReport));
               
                string ttl = "Laporan ";
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
                ttl = ttl + " Omset PerKelompok";
                rptParams.Add(new ReportParameter("title", ttl));
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CSM_LaporanPerOmsetBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglStart", SqlDbType.DateTime , txtDate1.DateValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@tglEnd", SqlDbType.DateTime, txtDate2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, flagKtg));
                    dt = db.Commands[0].ExecuteDataSet();
                }

               

                if (dt.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("CSM.laporanOmzetPerKelompokBarang.rdlc", rptParams, dt.Tables[0], "dsLaporanOmsetPerKelompokBarang_csm_omset_perkelompok_barang");
                    ifrmReport.Text = ttl;
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

        public frmLaporanOmsetPekelompok()
        {
            InitializeComponent();
            this.Title = "Laporan Omset Per Kelompok Barang";
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

            if (rbCustomerInti.Checked == true)
            {
                laporanOmsetPerkelompok("INTI");
            }
            if (rbMitraPS.Checked == true)
            {
                laporanOmsetPerkelompok("MITRAPS");
            }
            if (rbMitraSAS.Checked == true)
            {
                laporanOmsetPerkelompok("MITRASAS");
            }
            if (rbCalnCI.Checked == true)
            {

            }
            if (rbRegular.Checked == true)
            {
                laporanOmsetPerkelompok("REG");
            }
        }

        private void frmLaporanOmsetPekelompok_Load(object sender, EventArgs e)
        {
            txtDate2.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtDate1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
        }

        private void rbCalnCI_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbMitraPS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbMitraSAS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbCustomerInti_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDate2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
