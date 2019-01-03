using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Controls;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Trading.Laporan.Xtd
{
    public partial class frmLaporanPenjualanTAX : ISA.Trading.BaseForm
    {
        public frmLaporanPenjualanTAX()
        {
            InitializeComponent();
        }

        private void frmLaporanPenjualanTAX_Load(object sender, EventArgs e)
        {
            RngDateRange.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            RngDateRange.ToDate = DateTime.Now;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_LaporanPenjualanXtd]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, RngDateRange.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, RngDateRange.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();


                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);

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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string initial = "SAS-" + GlobalVar.Gudang;
            string judul = "Penjualan Total";
            string pengolah = SecurityManager.UserID + ", " + GlobalVar.DateTimeOfServer.ToString("dd/MM/yyyy");
            string created = "Created By " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;

            periode = String.Format("{0} s/d {1}", ((DateTime)RngDateRange.FromDate).ToString("dd/MM/yyyy"), ((DateTime)RngDateRange.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Initial", initial));
            rptParams.Add(new ReportParameter("JudulLaporan", judul));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Pengolah", pengolah));
            rptParams.Add(new ReportParameter("CreatedBy", created));

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Xtd.rptLapPenjualanXtd.rdlc", rptParams, dt, "dsLapPenjualanTAX_Data");
            ifrmReport.Show();
        }

        private void cmdPenjualanMinus_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenjualanMinusXtd]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, RngDateRange.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, RngDateRange.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();


                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                cretaeFileDBF(dt);

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

        private void cretaeFileDBF(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string FileName = "pjlmin_" + GlobalVar.Gudang;
                string hPhysical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

                if (File.Exists(hPhysical))
                {
                    File.Delete(hPhysical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HRecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("QtySuratJalan", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("NoSuratJalan", "no_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("QtyMinus", "stok_min", Foxpro.enFoxproTypes.Numeric, 5));

                Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dt);

                MessageBox.Show("Eksport Data Sukses. File disimpan di " + hPhysical);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdPrintDataFaktur_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LaporanDataFaktur"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, RngDateRange.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, RngDateRange.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();


                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                exportDataFaktur(dt);

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

        private void exportDataFaktur(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN RENCANA ORDER";
                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                string periode = "";

                ws.Name = "Sheet1"; 
                ws.Cells.Style.Font.Size = 9; 
                ws.Cells.Style.Font.Name = "Calibri";
                //MessageBox.Show("periode ="+this.periode);

                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 50;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 30;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 20;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 30;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 15;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 15;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 20;
                ws.Cells[1, 15].Worksheet.Column(15).Width = 15;
                ws.Cells[1, 16].Worksheet.Column(16).Width = 15;
                ws.Cells[1, 17].Worksheet.Column(17).Width = 15;
                ws.Cells[1, 18].Worksheet.Column(18).Width = 15;
                ws.Cells[1, 19].Worksheet.Column(19).Width = 15;

                #region Generate Header
                int i = 1;
                ws.Cells[i, 1].Value = "FK";
                ws.Cells[i, 2].Value = "KD_JENIS_TRANSAKSI";
                ws.Cells[i, 3].Value = "FG_PENGGANTI";
                ws.Cells[i, 4].Value = "NOMOR_FAKTUR";
                ws.Cells[i, 5].Value = "MASA_PAJAK";
                ws.Cells[i, 6].Value = "TAHUN_PAJAK";
                ws.Cells[i, 7].Value = "TANGGAL_FAKTUR";
                ws.Cells[i, 8].Value = "NPWP";
                ws.Cells[i, 9].Value = "NAMA";
                ws.Cells[i, 10].Value = "ALAMAT_LENGKAP";
                ws.Cells[i, 11].Value = "JUMLAH_DPP";
                ws.Cells[i, 12].Value = "JUMLAH_PPN";
                ws.Cells[i, 13].Value = "JUMLAH_PPNBM";
                ws.Cells[i, 14].Value = "ID_KETERANGAN_TAMBAHAN";
                ws.Cells[i, 15].Value = "FG_UANG_MUKA";
                ws.Cells[i, 16].Value = "UANG_MUKA_DPP";
                ws.Cells[i, 17].Value = "UANG_MUKA_PPN";
                ws.Cells[i, 18].Value = "UANG_MUKA_PPNBM";
                ws.Cells[i, 19].Value = "REFERENSI";

                																	
                i++;
                ws.Cells[i, 1].Value = "LT";
                ws.Cells[i, 2].Value = "NPWP";
                ws.Cells[i, 3].Value = "NAMA";
                ws.Cells[i, 4].Value = "JALAN";
                ws.Cells[i, 5].Value = "BLOK";
                ws.Cells[i, 6].Value = "NOMOR";
                ws.Cells[i, 7].Value = "RT";
                ws.Cells[i, 8].Value = "RW";
                ws.Cells[i, 9].Value = "KECAMATAN";
                ws.Cells[i, 10].Value = "KELURAHAN";
                ws.Cells[i, 11].Value = "KABUPATEN";
                ws.Cells[i, 12].Value = "PROPINSI";
                ws.Cells[i, 13].Value = "KODE_POS";
                ws.Cells[i, 14].Value = "NOMOR_TELEPON";
                
                											
                i++;
                ws.Cells[i, 1].Value = "OF";
                ws.Cells[i, 2].Value = "KODE_OBJEK";
                ws.Cells[i, 3].Value = "NAMA";
                ws.Cells[i, 4].Value = "HARGA_SATUAN";
                ws.Cells[i, 5].Value = "JUMLAH_BARANG";
                ws.Cells[i, 6].Value = "HARGA_TOTAL";
                ws.Cells[i, 7].Value = "DISKON";
                ws.Cells[i, 8].Value = "DPP";
                ws.Cells[i, 9].Value = "PPN";
                ws.Cells[i, 10].Value = "TARIF_PPNBM";
                ws.Cells[i, 11].Value = "PPNBM";

                i++;
                #endregion

                #region FillData
                string NoFaktur = "-";
                string NoFakturTemp = "";
                foreach (DataRow dr in dt.Rows)
                {

                    NoFakturTemp = dr["NoFaktur"].ToString();
                    if(NoFaktur != NoFakturTemp)
                    {
                        ws.Cells[i, 1].Value = "FK";
                        ws.Cells[i, 2].Value = dr["KodeTrans"];
                        ws.Cells[i, 3].Value = dr["FgPengganti"];
                        ws.Cells[i, 4].Value = dr["NoFaktur"];
                        ws.Cells[i, 5].Value = dr["Bln"];
                        ws.Cells[i, 6].Value = dr["Tahun"];
                        ws.Cells[i, 7].Value = dr["Tglfaktur"];
                        ws.Cells[i, 8].Value = dr["NPWP"];
                        ws.Cells[i, 9].Value = dr["NamaToko"];
                        ws.Cells[i, 10].Value = dr["Alamat"];
                        ws.Cells[i, 11].Value = dr["JmlDPP"];
                        ws.Cells[i, 12].Value = dr["JmlPPN"];
                        ws.Cells[i, 13].Value = dr["JmlPPNBM"];
                        ws.Cells[i, 14].Value = dr["KetTambahan"];
                        ws.Cells[i, 15].Value = dr["PGUangMuka"];
                        ws.Cells[i, 16].Value = dr["UangMukaDPP"];
                        ws.Cells[i, 17].Value = dr["UangMukaPPN"];
                        ws.Cells[i, 18].Value = dr["UangMukaPPNBM"];
                        ws.Cells[i, 19].Value = dr["Referensi"];
                        i++;
                    }

                    ws.Cells[i, 1].Value = "OF";
                    ws.Cells[i, 2].Value = dr["BarangID"];
                    ws.Cells[i, 3].Value = dr["NamaStok"];
                    ws.Cells[i, 4].Value = dr["HrgJual"];
                    ws.Cells[i, 5].Value = dr["QtySuratJalan"];
                    ws.Cells[i, 6].Value = dr["NominalTotal"];
                    ws.Cells[i, 7].Value = dr["Diskon"];
                    ws.Cells[i, 8].Value = dr["NominalDPP"];
                    ws.Cells[i, 9].Value = dr["NominalPPN"];
                    ws.Cells[i, 10].Value = dr["TarifPPNBM"];
                    ws.Cells[i, 11].Value = dr["PPNBM"];
                    i++;

                    NoFaktur = NoFakturTemp;
                }
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "DATA FAKTUR " + GlobalVar.Gudang + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    //MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion

            }
        }
    }
}
