using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;

namespace ISA.Toko.Laporan.Barang
{
    public partial class frmAccReturJualKe11 : ISA.Toko.BaseForm
    {
        public frmAccReturJualKe11()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_AccReturjualKe11"));

                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeTglRetur.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeTglRetur.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, Convert.ToString(cboCabang1.SelectedValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@pilihan", SqlDbType.VarChar, plh1.Checked ? '1' : '0'));
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(rangeTglRetur.FromDate.ToString()) || string.IsNullOrEmpty(rangeTglRetur.ToDate.ToString()))
            {
                errorProvider1.SetError(rangeTglRetur, "Range tanggal masih kosong !");
                valid = false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(cboCabang1.SelectedValue)))
            {
                errorProvider1.SetError(cboCabang1, "Pilih cabang !");
                valid = false;
            }

            return valid;
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTglRetur.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTglRetur.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID)); 
                //rptParams.Add(new ReportParameter("Cabang", Convert.ToString(cboCabang.SelectedValue)));
                //rptParams.Add(new ReportParameter("Toko", lookupToko1.TokoID));
                //rptParams.Add(new ReportParameter("Alamat", dt1.Rows[0].ItemArray.GetValue(3).ToString()));
                //rptParams.Add(new ReportParameter("Kota", dt1.Rows[0].ItemArray.GetValue(4).ToString()));
                //rptParams.Add(new ReportParameter("WilID", dt1.Rows[0].ItemArray.GetValue(6).ToString()));
                //rptParams.Add(new ReportParameter("TokoID", dt1.Rows[0].ItemArray.GetValue(1).ToString()));
                //rptParams.Add(new ReportParameter("Kelompok", string.IsNullOrEmpty(Convert.ToString(cboKelompok.SelectedValue)) ? "Semua" : Convert.ToString(cboKelompok.SelectedText)));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptAccReturJualKe11.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();
        }

        private void frmAccReturJualKe11_Load(object sender, EventArgs e)
        {
            this.Title = "Acc Retur Jual Ke 11";
            this.Text = "Laporan Acc Retur Jual Ke 11";

            rangeTglRetur.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTglRetur.ToDate = DateTime.Now;
            rangeTglRetur.Focus();

            plh1.Checked = true;

            ReloadCBOCab();
        }

        private void ReloadCBOCab()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    cboCabang1.ValueMember = "CabangID";
                    cboCabang1.DisplayMember = "Cab";
                    cboCabang1.DataSource = dt;
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
