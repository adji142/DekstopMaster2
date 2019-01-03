using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.DKNForm
{
    public partial class frmRptDKNHarian : ISA.Finance.BaseForm
    {
        public frmRptDKNHarian()
        {
            InitializeComponent();
        }

        private void frmRptDKNHarian_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;

            rangeDateBox1.Focus();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_DKN_Harian"));                    
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));


                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter


            string DK = string.Empty;
            string Tanggal = string.Empty;
            string NoDKN = string.Empty;
            string headerTitle = string.Empty;
            string deskripsi = string.Empty;
            string cabang = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempTotal = string.Empty;

            DK = Tools.isNull(dt.Rows[0]["DK"], "").ToString();
            Tanggal = ((DateTime)dt.Rows[0]["Tanggal"]).ToString("dd/MM/yyyy");
            NoDKN = Tools.isNull(dt.Rows[0]["NoDKN"], "").ToString();
            cabang = Tools.isNull(dt.Rows[0]["Cabang"], "").ToString();

            if (DK == "D")
            {
                headerTitle = "DEBET NOTA";
                deskripsi = "Dengan ini kami mendebit rekening Saudara untuk transaksi sebagai berikut :";
            }
            else if (DK == "K")
            {
                headerTitle = "KREDIT NOTA";
                deskripsi = "Dengan ini kami menkredit rekening Saudara untuk transaksi sebagai berikut :";
            }

            DateTime tanggalRows;
            double terbilang;

            foreach (DataRow dr in dt.Rows)
            {
                tanggalRows = (DateTime)dr["Tanggal"];
                terbilang = Convert.ToDouble(dt.Compute("SUM(Jumlah)", "Tanggal = '" + tanggalRows.ToString()+"'"));
                dr["Terbilang"] = ISA.Common.Tools.Terbilang(terbilang).ToString();                
                
            }
                        

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("headerTitle", headerTitle));
            rptParams.Add(new ReportParameter("noDKN", NoDKN));
            rptParams.Add(new ReportParameter("Tanggal", Tanggal));
            rptParams.Add(new ReportParameter("Cabang", cabang));
            rptParams.Add(new ReportParameter("Deskripsi", deskripsi));
            rptParams.Add(new ReportParameter("Total", ISA.Common.Tools.Terbilang(sumJumlah)));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("DKNForm.rptDKNHarian.rdlc", rptParams, dt, "dsDKN_Data");
            ifrmReport.Show();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
