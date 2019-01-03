using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Trading.Laporan.Barang
{
    public partial class frmRptTargetTokoDanSalesman : ISA.Trading.BaseForm
    {
        public frmRptTargetTokoDanSalesman()
        {
            InitializeComponent();
        }

        private void frmRptTargetTokoDanSalesman_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Target Toko Dan Salesman";
            this.Text = "Laporan Target Toko Dan Salesman";

            if (lookupSales1.NamaSales == "")
                lookupSales1.SalesID = "";

            if (lookupToko1.NamaToko == "")
                lookupToko1.KodeToko = "";

            rbtSudahOrder.Checked = true;
            rangeTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTanggal.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
        }

        private void rbtSalesman_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSalesman.Checked)
            {
                lookupSales1.Show();
                lookupToko1.Hide();
            }
            else
            {
                lookupSales1.Hide();
                lookupToko1.Show();
            }
        }

        private void rbtToko_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtToko.Checked)
            {
                lookupToko1.Show();
                lookupSales1.Hide();
            }
            else
            {
                lookupToko1.Hide();
                lookupSales1.Show();
            }
        }

        private void rbtBelumAmbil_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBelumAmbil.Checked)
            {
                txtTglEvaluasi.ReadOnly = false;
                txtTglEvaluasi.DateValue = rangeTanggal.ToDate.Value;
            }
            else
            {
                txtTglEvaluasi.ReadOnly = true;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_TargetTokoDanSalesman"));

                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rangeTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rangeTanggal.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.VarChar, rbtSalesman.Checked ? "1" : rbtToko.Checked ? "2" : "0"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaTarget", SqlDbType.VarChar, rbtSalesman.Checked ? lookupSales1.SalesID : rbtToko.Checked ? lookupToko1.KodeToko : ""));
                    db.Commands[0].Parameters.Add(new Parameter("@Order", SqlDbType.VarChar, rbtSudahOrder.Checked ? "1" : rbtBelumAmbil.Checked ? "2" : rbtBelumPernah.Checked ? "3" : "0"));
                    db.Commands[0].Parameters.Add(new Parameter("@Evaluasi", SqlDbType.DateTime, txtTglEvaluasi.ReadOnly == false ? Convert.ToDateTime(txtTglEvaluasi.Text) : DateTime.Now));
                    dt = db.Commands[0].ExecuteDataTable();

                    string sp = string.Empty;

                    if (rbtSalesman.Checked)
                        sp = "usp_Sales_SEARCH";
                    else if (rbtToko.Checked)
                        sp = "usp_Toko_SEARCH";

                    db.Commands.Add(db.CreateCommand(sp));
                    db.Commands[1].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, rbtSalesman.Checked ? lookupSales1.SalesID : rbtToko.Checked ? lookupToko1.TokoID : ""));
                    dt1 = db.Commands[1].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    if (rbtToko.Checked && rbtSudahOrder.Checked)
                        DisplayReportTargetToko21(dt, dt1);
                    else if (rbtSalesman.Checked && rbtSudahOrder.Checked)
                        DisplayReportTargetToko11(dt, dt1);
                    else if (rbtToko.Checked && rbtBelumAmbil.Checked)
                        DisplayReportTargetToko22(dt, dt1);
                    else if (rbtSalesman.Checked && rbtBelumAmbil.Checked)
                        DisplayReportTargetToko12(dt, dt1);
                    else if (rbtToko.Checked && rbtBelumPernah.Checked)
                        DisplayReportTargetToko23(dt, dt1);
                    else if (rbtSalesman.Checked && rbtBelumPernah.Checked)
                        DisplayReportTargetToko13(dt, dt1);
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(rangeTanggal.FromDate.ToString()) || string.IsNullOrEmpty(rangeTanggal.ToDate.ToString()))
            {
                errorProvider1.SetError(rangeTanggal, "Range tanggal masih kosong !");
                valid = false;
            }

            if (rbtSalesman.Checked && lookupSales1.SalesID == "")
            {
                errorProvider1.SetError(lookupSales1, "Nama Sales masih kosong !");
                valid = false;
            }

            if (rbtToko.Checked && lookupToko1.KodeToko == "")
            {
                errorProvider1.SetError(lookupToko1, "Nama Toko masih kosong !");
                valid = false;
            }

            if (txtTglEvaluasi.ReadOnly == false)
            {
                //IFormatProvider iFP = new CultureInfo("en-GB", true);
                //DateTimeStyles style = DateTimeStyles.None;
                //string givendate = txtTglEvaluasi.Text;
                //DateTime result = DateTime.Parse(givendate, iFP, style);

                //if (DateTime.Compare(result, rangeTanggal.FromDate.Value) > 0)
                //{
                //    errorProvider1.SetError(txtTglEvaluasi, "Tanggal evaluasi masih salah !");
                //    valid = false;
                //}

                if (txtTglEvaluasi.DateValue > rangeTanggal.ToDate)
                {
                    errorProvider1.SetError(txtTglEvaluasi, "Tanggal evaluasi masih salah !");
                    valid = false;
                }
            }
            return valid;
        }

        private void DisplayReportTargetToko21(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            
            //rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            rptParams.Add(new ReportParameter("Toko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("Alamat", dt1.Rows[0].ItemArray.GetValue(3).ToString()));
            rptParams.Add(new ReportParameter("Telp", dt1.Rows[0].ItemArray.GetValue(5).ToString()));
            rptParams.Add(new ReportParameter("WilID", dt1.Rows[0].ItemArray.GetValue(6).ToString()));
            rptParams.Add(new ReportParameter("KodePos", dt1.Rows[0].ItemArray.GetValue(22).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_TokoSudahOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void DisplayReportTargetToko22(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            rptParams.Add(new ReportParameter("Toko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("Alamat", dt1.Rows[0].ItemArray.GetValue(3).ToString()));
            rptParams.Add(new ReportParameter("Telp", dt1.Rows[0].ItemArray.GetValue(5).ToString()));
            rptParams.Add(new ReportParameter("WilID", dt1.Rows[0].ItemArray.GetValue(6).ToString()));
            rptParams.Add(new ReportParameter("KodePos", dt1.Rows[0].ItemArray.GetValue(22).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_TokoOrderBelumAmbilLagi.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void DisplayReportTargetToko23(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            rptParams.Add(new ReportParameter("Toko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("Alamat", dt1.Rows[0].ItemArray.GetValue(3).ToString()));
            rptParams.Add(new ReportParameter("Telp", dt1.Rows[0].ItemArray.GetValue(5).ToString()));
            rptParams.Add(new ReportParameter("WilID", dt1.Rows[0].ItemArray.GetValue(6).ToString()));
            rptParams.Add(new ReportParameter("KodePos", dt1.Rows[0].ItemArray.GetValue(22).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_TokoBelumPernahOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void DisplayReportTargetToko11(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_SalesmanSudahOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void DisplayReportTargetToko12(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));

            string evaluasi;
            evaluasi = String.Format("{0} s/d {1}", ((DateTime)txtTglEvaluasi.DateValue).ToString("dd/MM/yyyy"), ((DateTime)DateTime.Today).ToString("dd/MM/yyyy"));
            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Evaluasi", evaluasi));

            rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_SalesmanOrderBelumAmbilLagi.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void DisplayReportTargetToko13(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTanggal.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTanggal.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            rptParams.Add(new ReportParameter("Sales", dt1.Rows[0].ItemArray.GetValue(2).ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptTargetTokoDanSalesman_SalesmanBelumPernahOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
