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

namespace ISA.Toko.Penjualan
{
    public partial class frmLaporanPembelianBO : ISA.Toko.BaseForm
    {
        public frmLaporanPembelianBO()
        {
            InitializeComponent();
        }

        private void frmLaporanPembelianBO_Load(object sender, EventArgs e)
        {
            rangeDateBoxPembelian.ToDate = DateTime.Now;
            rangeDateBoxPembelian.FromDate = DateTime.Now;

            rangeDateBoxPenjualan.ToDate = DateTime.Now;
            rangeDateBoxPenjualan.FromDate = DateTime.Now;

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (!rangeDateBoxPenjualan.ToDate.HasValue || !rangeDateBoxPenjualan.FromDate.HasValue)
            {
                errorProvider1.SetError(rangeDateBoxPenjualan, "Isi Dengan Benar");
                rangeDateBoxPenjualan.Focus();
                return;
            }

            if (!rangeDateBoxPembelian.ToDate.HasValue || !rangeDateBoxPembelian.FromDate.HasValue)
            {
                errorProvider1.SetError(rangeDateBoxPembelian, "Isi Dengan Benar");
                rangeDateBoxPembelian.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Laporan_Penjualan_DOBO]")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDateBeli", SqlDbType.DateTime, rangeDateBoxPembelian.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDateBeli", SqlDbType.DateTime, rangeDateBoxPembelian.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDateDO", SqlDbType.DateTime, rangeDateBoxPenjualan.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDateDO", SqlDbType.DateTime, rangeDateBoxPenjualan.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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
                        string periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBoxPembelian.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBoxPembelian.ToDate).ToString("dd/MM/yyyy"));
            string periode1 = String.Format("{0} s/d {1}", ((DateTime)rangeDateBoxPenjualan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBoxPenjualan.ToDate).ToString("dd/MM/yyyy")); 
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Periode1", periode1));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptPembelianBO.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void rangeDateBoxPenjualan_Load(object sender, EventArgs e)
        {

        }
    }
}
