using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;

namespace ISA.Toko.xpdc
{
    public partial class frmRptKonfirmasiToko : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();
        string KodeToko;
        public frmRptKonfirmasiToko()
        {
            InitializeComponent();
        }

        private void frmRptKonfirmasiToko_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void GetData()
        {
            KodeToko = lookupToko1.KodeToko.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetDataToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (lookupToko1.NamaToko == "")
            {
                MessageBox.Show("Pilih Nama Toko");
                return;
            }
            else
            {
                GetData();
                DisplayReport();
            }
        }

        public void DisplayReport()
        {
            DateTime Tgl = Convert.ToDateTime(DateTime.Now);
            string Tanggal = Tgl.ToString("dd-MMM-yyyy");
            string NamaToko = Convert.ToString(dt.Rows[0]["NamaToko"].ToString());
            string Alamat = Convert.ToString(dt.Rows[0]["Alamat"].ToString());
            string WilID = Convert.ToString(dt.Rows[0]["WilID"].ToString());
            string Daerah = Convert.ToString(dt.Rows[0]["Daerah"].ToString());
            string Kota = Convert.ToString(dt.Rows[0]["Kota"].ToString());
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Tanggal", Tanggal));
            rptParams.Add(new ReportParameter("NamaToko", NamaToko));
            rptParams.Add(new ReportParameter("Alamat", Alamat));
            rptParams.Add(new ReportParameter("WilID", WilID));
            rptParams.Add(new ReportParameter("Daerah", Daerah));
            rptParams.Add(new ReportParameter("Kota", Kota));

            frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptKonfirmasiToko.rdlc", rptParams);
            ifrmReport.Show();
        }
    }
}
