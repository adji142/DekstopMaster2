using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Laporan.Toko
{
    public partial class frmRptAnalisaKunjunganSalesFilter : ISA.Toko.BaseForm
    {
        public frmRptAnalisaKunjunganSalesFilter()
        {
            InitializeComponent();
        }

        private void frmRptAnalisaKunjunganSalesFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Analisa Kunjungan Sales";
            this.Text = "Laporan";
            DateTime nextMnth = DateTime.Now.AddMonths(1);
            rdbTgl2.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl2.ToDate = new DateTime(nextMnth.Year, nextMnth.Month, 1).AddDays(-1);
            rdbTgl1.FromDate = ((DateTime)rdbTgl2.FromDate).AddMonths(-1);
            rdbTgl1.ToDate = ((DateTime)rdbTgl2.ToDate).AddMonths(-1);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtKodePos = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KodePos_LIST"));
                    dtKodePos = db.Commands[0].ExecuteDataTable();
                }
                dtKodePos.Rows.Add("");
                dtKodePos.DefaultView.Sort = "KodePos ASC";

                cboPos.DataSource = dtKodePos;
                cboPos.DisplayMember = "KodePos";
                cboPos.ValueMember = "KodePos";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            txtWilayah.Text = "";
            rdbTgl1.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl1.FromDate.ToString() == "" || rdbTgl1.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl1, "Range tanggal Periode I masih kosong");
                valid = false;
            }

            if (rdbTgl2.FromDate.ToString() == "" || rdbTgl2.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl2, "Range tanggal Periode II masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string tipeTgl = "DO", tipeNominal = "BR", urut = "TOKO";
            if (rdoNota.Checked)
                tipeTgl = "SJ";
            if (rdoNetto.Checked)
                tipeNominal = "NT";
            if (rdoSales.Checked)
                urut = "SALES";
            if (rdoKota.Checked)
                urut = "KOTA";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_AnalisaKunjunganSales"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate1", SqlDbType.DateTime, rdbTgl1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate1", SqlDbType.DateTime, rdbTgl1.ToDate));

                    db.Commands[0].Parameters.Add(new Parameter("@fromDate2", SqlDbType.DateTime, rdbTgl2.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate2", SqlDbType.DateTime, rdbTgl2.ToDate));

                    db.Commands[0].Parameters.Add(new Parameter("@tipeTgl", SqlDbType.VarChar, tipeTgl));
                    db.Commands[0].Parameters.Add(new Parameter("@urut", SqlDbType.VarChar, urut));
                    db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, GlobalVar.CabangID));
                    //if (rdoNetto.Checked)
                        db.Commands[0].Parameters.Add(new Parameter("@tipeNominal", SqlDbType.VarChar, tipeNominal));
                    if (lookupSales.NamaSales.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (txtKota.Text.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    if (cboPos.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, cboPos.SelectedValue.ToString()));
                    if (txtWilayah.Text.Trim() != "" && txtWilayah.Text != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
                    
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
            string tipeReport = "(DO)";
            if (rdoNota.Checked)
            {
                if (rdoBruto.Checked)
                    tipeReport = "(BRUTO)";
                if (rdoNetto.Checked)
                    tipeReport = "(NETTO)";
            }

            string periode1, periode2;
            periode1 = String.Format("{0} s/d {1}", ((DateTime)rdbTgl1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl1.ToDate).ToString("dd/MM/yyyy"));
            periode2 = String.Format("{0} s/d {1}", ((DateTime)rdbTgl2.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl2.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode1", periode1));
            rptParams.Add(new ReportParameter("Periode2", periode2));
            rptParams.Add(new ReportParameter("TipeReport", tipeReport));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptAnalisaKunjunganSales.rdlc", rptParams, dt, "dsToko_Data");
            ifrmReport.Show();

        } 


        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
