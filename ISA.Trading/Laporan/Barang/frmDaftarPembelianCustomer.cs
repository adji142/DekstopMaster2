using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Laporan.Barang
{
    public partial class frmDaftarPembelianCustomer : ISA.Trading.BaseForm
    {
        public frmDaftarPembelianCustomer()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_DaftarPembelianCustomer"));
                    
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeTglPembelian.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeTglPembelian.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, Convert.ToString(cboCabang.SelectedValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@toko", SqlDbType.VarChar, Convert.ToString(lookupToko1.KodeToko)));
                    
                    if (!string.IsNullOrEmpty(cboKelompok.Text))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Convert.ToString(cboKelompok.SelectedValue)));
                    }

                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[1].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, Convert.ToString(lookupToko1.TokoID)));
                    dt1 = db.Commands[1].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt, dt1);
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

            if (string.IsNullOrEmpty(rangeTglPembelian.FromDate.ToString()) || string.IsNullOrEmpty(rangeTglPembelian.ToDate.ToString()))
            {
                errorProvider1.SetError(rangeTglPembelian, "Range tanggal masih kosong !");
                valid = false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(cboCabang.SelectedValue)))
            {
                errorProvider1.SetError(cboCabang, "Pilih cabang !");
                valid = false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lookupToko1.TokoID)))
            {
                errorProvider1.SetError(lookupToko1, "Toko masih kosong !");
                valid = false;
            }

            return valid;
        }

        private void DisplayReport(DataTable dt, DataTable dt1)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTglPembelian.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTglPembelian.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Cabang", Convert.ToString(cboCabang.SelectedValue)));
            rptParams.Add(new ReportParameter("Toko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("Alamat", dt1.Rows[0].ItemArray.GetValue(3).ToString()));
            rptParams.Add(new ReportParameter("Kota", dt1.Rows[0].ItemArray.GetValue(4).ToString()));
            rptParams.Add(new ReportParameter("WilID", dt1.Rows[0].ItemArray.GetValue(6).ToString()));
            rptParams.Add(new ReportParameter("TokoID", lookupToko1.TokoID));
            rptParams.Add(new ReportParameter("Kelompok", string.IsNullOrEmpty(cboKelompok.Text) ? "Semua" : cboKelompok.Text));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptDaftarPembelianCustomer.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void frmDaftarPembelianCustomer_Load(object sender, EventArgs e)
        {
            this.Title = "Daftar Pembelian Customer";
            this.Text = "Laporan";
            rangeTglPembelian.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTglPembelian.ToDate = DateTime.Now;
            rangeTglPembelian.Focus();

            ReloadCBOCab();
            ReloadCBOKelompok();

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

                    cboCabang.ValueMember = "CabangID";
                    cboCabang.DisplayMember = "Cab";
                    cboCabang.DataSource = dt;
                    cboCabang.SelectedValue = GlobalVar.CabangID;
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

        private void ReloadCBOKelompok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    object[] a = { "", "" };
                    dt.Rows.Add(a);

                    cboKelompok.DataSource = dt;
                    cboKelompok.DisplayMember = "kelompokBrgID";
                    cboKelompok.ValueMember = "kelompokBrgID";
                    //cboKelompok.SelectedIndex = -1;
                    cboKelompok.SelectedValue = "";
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

        private void lookupToko1_Leave(object sender, EventArgs e)
        {
            if (lookupToko1.NamaToko == "")
                lookupToko1.TokoID = "";
        }
    }
}
