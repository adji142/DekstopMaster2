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
    public partial class frmPenjualanBarangPerItemPerkota : ISA.Toko.BaseForm
    {
        public frmPenjualanBarangPerItemPerkota()
        {
            InitializeComponent();
        }

        private void frmPenjualanBarangPerItemPerkota_Load(object sender, EventArgs e)
        {
            rangeDateBox_barang.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox_barang.ToDate = DateTime.Now;
            try
            {
                cmdYes.Focus();
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }
                    comboBox_cabang.DataSource = dt;
                    comboBox_cabang.ValueMember = "CabangID";
                    comboBox_cabang.DisplayMember = "Cab";
                    comboBox_cabang.SelectedValue = "09";
                  
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StockBarang.BarangID))
            {
                StockBarang.Focus();
                return;
            }
            else if (rangeDateBox_barang.FromDate == null || rangeDateBox_barang.ToDate == null)
            {
                rangeDateBox_barang.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_barang_penjualanBarang_peritem_perkota"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox_barang.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox_barang.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@cabangId", SqlDbType.VarChar, comboBox_cabang.SelectedValue == null ? null : comboBox_cabang.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, string.IsNullOrEmpty(StockBarang.BarangID) ? null : StockBarang.BarangID));

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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox_barang.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox_barang.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("rpm_namabarang", StockBarang.NamaStock));
            rptParams.Add(new ReportParameter("rpm_awalperiode", rangeDateBox_barang.FromDate.Value.ToString("dd/MM/yyyy")));
            rptParams.Add(new ReportParameter("rpm_akhirperiode", rangeDateBox_barang.ToDate.Value.ToString("dd/MM/yyyy")));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptPenjualanBarangPerItemPerkota.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rangeDateBox_barang_Load(object sender, EventArgs e)
        {

        }
    }
}
