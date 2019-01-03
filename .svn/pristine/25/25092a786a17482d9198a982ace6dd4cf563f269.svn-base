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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using ISA.Toko.Class;

namespace ISA.Toko.Penjualan
{
    public partial class frmLaporanPenjualan : ISA.Toko.BaseForm
    {
        public frmLaporanPenjualan()
        {
            InitializeComponent();
        }

        private void frmLaporanPenjualan_Load(object sender, EventArgs e)
        {
            txtRangeDate.FromDate = GlobalVar.DateTimeOfServer;
            txtRangeDate.ToDate = GlobalVar.DateTimeOfServer;

            cboRekap.Checked = true;
          
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            //int a = 12;
            //double b = 0.3;
            //double r = Math.Round(b * a);
            //MessageBox.Show(r.ToString());
            //return;
            //silakan
            if(lookup_TipeTransaksi1.Kode ==""){
                MessageBox.Show("Silahkan pilih jenis transaksi terlebih dahulu");
                lookup_TipeTransaksi1.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_LaporanPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, txtRangeDate.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, txtRangeDate.ToDate));
                    if(lookupStock1.BarangID ==""){                    
                        db.Commands[0].Parameters.Add(new Parameter("@StockRowID", SqlDbType.UniqueIdentifier, lookupStock1.RowID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@jenistransasi", SqlDbType.VarChar, lookup_TipeTransaksi1.Kode));
                    if( cbStatus.Visible)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, cbStatus.Text));
                    }
                    if(cboRekap.Checked)
                    {
                         db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "Rekap"));
                    }
                    else
                    {                    
                        db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "Detail"));
                    }
                    //if (SecurityManager.UserID == "MANAGER")
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@lapUser", SqlDbType.VarChar, "MGR"));
                    //}
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data Kosong");
                    return;
                }

                string periode, created, namerdlc, namalaporan;
                periode = "Periode " + DateTime.Parse(txtRangeDate.FromDate.ToString()).ToString("dd/MM/yyyy") + " s/d " + DateTime.Parse(txtRangeDate.FromDate.ToString()).ToString("dd/MM/yyyy");
                created="Created by " + SecurityManager.UserID + " on "+ GlobalVar.DateTimeOfServer;
                List<ReportParameter> rptParams = new List<ReportParameter>();

                rptParams.Add(new ReportParameter("NamaPerusahaan", GlobalVar.PerusahaanName));
                rptParams.Add(new ReportParameter("AlamatPerusahaan", GlobalVar.PerusahaanAddress));
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("JenisTransaksi", "Penjualan : "+lookup_TipeTransaksi1.Keterangan));
                rptParams.Add(new ReportParameter("Created", created));

                if(cboRekap.Checked)
                {
                    namerdlc="rptLapPenjualanRekap.rdlc";
                    namalaporan="Laporan Penjualan Rekap";
                }
                else{
                    namerdlc="rptLapPenjualanDetail.rdlc";
                    namalaporan="Laporan Penjualan Detail";
                }
                frmReportViewer ifrmReport = new frmReportViewer("Penjualan."+namerdlc, rptParams, dt, "dsLaporanPenjualan_Data");
                //ifrmReport.ExportToExcel(namalaporan);
                ifrmReport.Show();
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookup_TipeTransaksi1_SelectData(object sender, EventArgs e)
        {
            if (lookup_TipeTransaksi1.Keterangan.Length > 6 && lookup_TipeTransaksi1.Keterangan.Substring(0,6).ToUpper() == "KREDIT")
            {
                cbStatus.Visible = true;
            }
            else{
                cbStatus.Visible = false;
            }
        }
    }
}
