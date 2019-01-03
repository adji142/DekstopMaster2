using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Laporan.Barang
{
    public partial class frmReturJualPerNamaBarangFilter : ISA.Toko.BaseForm
    {
        public frmReturJualPerNamaBarangFilter()
        {
            InitializeComponent();
        }

        private void frmReturJualPerNamaBarangFilter_Load(object sender, EventArgs e)
        {
            try
            {
                RngTextBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                RngTextBox1.ToDate = DateTime.Now;

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Kategori_LIST"));
                    dt2 = db.Commands[0].ExecuteDataTable();
                    cmbKategori.DataSource = dt2;
                    cmbKategori.ValueMember = "Kategori";
                    cmbKategori.DisplayMember = "Keterangan";
                    cmbKategori.SelectedIndex = -1;

                    cmbJenisRetur.Items.Add("Murni");
                    cmbJenisRetur.Items.Add("Dari Cabang");
                    cmbJenisRetur.Items.Add("Tarikan");
                    //murni =1
                    //dari cabang = 2
                    //tarikan = 3

                    dt.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[1].ExecuteDataTable();
                    cmbCabang.DataSource = dt;
                    cmbCabang.ValueMember = "CabangID";
                    cmbCabang.DisplayMember = "Cab";
                    cmbCabang.SelectedValue = GlobalVar.CabangID;

                    lkpGudang.GudangID = GlobalVar.Gudang;
                    //lkpGudang.NamaGudang = string.Empty;

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (RngTextBox1.FromDate == null || RngTextBox1.ToDate == null)
            {
                RngTextBox1.Focus();
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    string jnsretur;

                    if (cmbJenisRetur.SelectedItem != null)
                    {
                        if (cmbJenisRetur.SelectedItem.ToString() == "Murni")
                            jnsretur = "1";
                        else if (cmbJenisRetur.SelectedItem.ToString() == "Dari Cabang")
                            jnsretur = "2";
                        else
                            jnsretur = "3";
                    }
                    jnsretur = null;    
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_returjual_pernamabarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@STARTDATE", SqlDbType.DateTime, RngTextBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ENDDATE", SqlDbType.DateTime, RngTextBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CABANG", SqlDbType.VarChar, cmbCabang.SelectedValue == null ? null : cmbCabang.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@KODEGUDANG", SqlDbType.VarChar, lkpGudang.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KODERETUR", SqlDbType.VarChar, jnsretur));
                    db.Commands[0].Parameters.Add(new Parameter("@KATEGORI", SqlDbType.VarChar, cmbKategori.SelectedValue == null ? null : cmbKategori.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@KODESALES", SqlDbType.VarChar, string.IsNullOrEmpty(lkpsales.SalesID) ? null : lkpsales.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@FILTER", SqlDbType.VarChar, rbMPR.Checked == true ? 1 : 2));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

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

        private void cmdcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)RngTextBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)RngTextBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
            rptParams.Add(new ReportParameter("KodeCabang", cmbCabang.SelectedValue != null ? (cmbCabang.SelectedValue.ToString()) : ""));
            rptParams.Add(new ReportParameter("Filter", rbMPR.Checked == true ? "Tanggal MPR" : "Tgl Nota Retur"));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptReturJualPerNamaBarang.rdlc",rptParams,dt,"dsReturPenjualan_Data");
            ifrmReport.Show();

        }
    }
}
