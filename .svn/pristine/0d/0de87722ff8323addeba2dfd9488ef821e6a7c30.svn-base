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
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using ISA.Toko.Class;


namespace ISA.Toko.Persediaan
    {
    public partial class frmRptGudangPosisiStok : ISA.Toko.BaseForm
        {

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            string periode;
            periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Gudang", lookupGudang1.GudangID));

            if (cboPen.Text!="")
            {
            rptParams.Add(new ReportParameter("PengRak",cboPen.Text));
            }
            else
                {
                rptParams.Add(new ReportParameter("PengRak",""));
                }

            if(cboKel.Text!="")
                {
                rptParams.Add(new ReportParameter("Kelompok", cboKel.Text));
                }
            else
                {
                rptParams.Add(new ReportParameter("Kelompok", ""));
                }
            
            rptParams.Add(new ReportParameter("Harga", "H.Beli rata"));
                
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Persediaan.rptGudangPosisiStokNew.rdlc", rptParams, dt, "dsStandarStok_Data1");
            ifrmReport.Show();

            }


        private void DisplayReportExcell(DataTable dt)
        {
            //Laporan persediaan langsung ke Excell
            using (ExcelPackage p = new ExcelPackage())
            {

                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Laporan Persediaan"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 40;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 2;

                ws.Cells[1, 2].Worksheet.Column(2).Width = 73;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 23;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 23;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 7;

                ws.Cells[1, 6].Worksheet.Column(6).Width = 7;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;

                ws.Cells[1, 8].Worksheet.Column(8).Width = 7;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;

                ws.Cells[1, 10].Worksheet.Column(10).Width = 7;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15;

                ws.Cells[1, 12].Worksheet.Column(12).Width = 7;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 15;

                ws.Cells[1, 14].Worksheet.Column(14).Width = 7;
                ws.Cells[1, 15].Worksheet.Column(15).Width = 15;

                ws.Cells[1, 16].Worksheet.Column(16).Width = 7;
                ws.Cells[1, 17].Worksheet.Column(17).Width = 15;

                ws.Cells[1, 18].Worksheet.Column(18).Width = 7;
                ws.Cells[1, 19].Worksheet.Column(19).Width = 15;

                ws.Cells[1, 20].Worksheet.Column(20).Width = 7;
                ws.Cells[1, 21].Worksheet.Column(21).Width = 15;

                ws.Cells[1, 22].Worksheet.Column(22).Width = 7;
                ws.Cells[1, 23].Worksheet.Column(23).Width = 15;

                ws.Cells[1, 24].Worksheet.Column(24).Width = 7;
                ws.Cells[1, 25].Worksheet.Column(25).Width = 15;

                ws.Cells[1, 26].Worksheet.Column(26).Width = 7;
                ws.Cells[1, 27].Worksheet.Column(27).Width = 15;

                ws.Cells[1, 28].Worksheet.Column(28).Width = 7;
                ws.Cells[1, 29].Worksheet.Column(29).Width = 15;

                ws.Cells[1, 30].Worksheet.Column(30).Width = 7;
                ws.Cells[1, 31].Worksheet.Column(31).Width = 15;

                ws.Cells[1, 32].Worksheet.Column(32).Width = 7;
                ws.Cells[1, 33].Worksheet.Column(33).Width = 15;

                ws.Cells[1, 34].Worksheet.Column(34).Width = 7;
                ws.Cells[1, 35].Worksheet.Column(35).Width = 15;

                ws.Cells[1, 36].Worksheet.Column(36).Width = 7;
                ws.Cells[1, 37].Worksheet.Column(37).Width = 15;

                ws.Cells[1, 38].Worksheet.Column(38).Width = 7;
                ws.Cells[1, 39].Worksheet.Column(39).Width = 15;

                ws.Cells[1, 40].Worksheet.Column(40).Width = 15;

                ws.Cells[1, 2].Value = "POSISI STOK - (Hpp Rata-Rata)";
                ws.Cells[2, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.FromDate.Value) + " s/d " + string.Format("{0:dd-MMM-yyyy}", rangeDateBox1.ToDate.Value);
                ws.Cells[4, 2].Value = "";
                ws.Cells[1, 2, 1, MaxCol].Merge = true;
                ws.Cells[2, 2, 2, MaxCol].Merge = true;
                ws.Cells[1, 2, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 2, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 2, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 2].Style.Font.Size = 14;
                ws.Cells[2, 2].Style.Font.Size = 11;

                ws.Cells[5, 2, 6, 2].Merge = true;
                ws.Cells[5, 3, 6, 3].Merge = true;
                ws.Cells[5, 4, 6, 4].Merge = true;
                ws.Cells[5, 5, 6, 5].Merge = true;

                ws.Cells[5, 6, 5, 7].Merge = true;
                ws.Cells[5, 8, 5, 9].Merge = true;
                ws.Cells[5, 10, 5, 11].Merge = true;
                ws.Cells[5, 12, 5, 13].Merge = true;
                ws.Cells[5, 14, 5, 15].Merge = true;
                ws.Cells[5, 16, 5, 17].Merge = true;
                ws.Cells[5, 18, 5, 19].Merge = true;
                ws.Cells[5, 20, 5, 21].Merge = true;
                ws.Cells[5, 22, 5, 23].Merge = true;
                ws.Cells[5, 24, 5, 25].Merge = true;
                ws.Cells[5, 26, 5, 27].Merge = true;
                ws.Cells[5, 28, 5, 29].Merge = true;
                ws.Cells[5, 30, 5, 31].Merge = true;
                ws.Cells[5, 32, 5, 33].Merge = true;
                ws.Cells[5, 34, 5, 35].Merge = true;
                ws.Cells[5, 36, 5, 37].Merge = true;
                ws.Cells[5, 38, 5, 39].Merge = true;
                ws.Cells[5, 40, 6, 40].Merge = true;

                ws.Cells[5, 2].Value = "Nama Barang";
                ws.Cells[5, 3].Value = "Kode Barang";
                ws.Cells[5, 4].Value = "Jenis Barang";
                ws.Cells[5, 5].Value = "Rak";

                ws.Cells[5, 6].Value = "Stok Awal";
                ws.Cells[6, 6].Value = "Qty";
                ws.Cells[6, 7].Value = "Rp";

                ws.Cells[5, 8].Value = "Pembelian";
                ws.Cells[6, 8].Value = "Qty";
                ws.Cells[6, 9].Value = "Rp";

                ws.Cells[5, 10].Value = "Retur Beli";
                ws.Cells[6, 10].Value = "Qty";
                ws.Cells[6, 11].Value = "Rp";

                ws.Cells[5, 12].Value = "Penjualan";
                ws.Cells[6, 12].Value = "Qty";
                ws.Cells[6, 13].Value = "Rp";

                ws.Cells[5, 14].Value = "Retur Jual";
                ws.Cells[6, 14].Value = "Qty";
                ws.Cells[6, 15].Value = "Rp";

                ws.Cells[5, 16].Value = "Antar Gdg";
                ws.Cells[6, 16].Value = "Qty";
                ws.Cells[6, 17].Value = "Rp";

                ws.Cells[5, 18].Value = "Mutasi Masuk";
                ws.Cells[6, 18].Value = "Qty";
                ws.Cells[6, 19].Value = "Rp";

                ws.Cells[5, 20].Value = "Mutasi Keluar";
                ws.Cells[6, 20].Value = "Qty";
                ws.Cells[6, 21].Value = "Rp";

                ws.Cells[5, 22].Value = "Koreksi Pembelian";
                ws.Cells[6, 22].Value = "Qty";
                ws.Cells[6, 23].Value = "Rp";

                ws.Cells[5, 24].Value = "Koreksi Retur Pembelian";
                ws.Cells[6, 24].Value = "Qty";
                ws.Cells[6, 25].Value = "Rp";
                
                ws.Cells[5, 26].Value = "Koreksi Penjualan";
                ws.Cells[6, 26].Value = "Qty";
                ws.Cells[6, 27].Value = "Rp";

                ws.Cells[5, 28].Value = "Koreksi Retur Penjualan";
                ws.Cells[6, 28].Value = "Qty";
                ws.Cells[6, 29].Value = "Rp";

                ws.Cells[5, 30].Value = "Adjs Opname";
                ws.Cells[6, 30].Value = "Qty";
                ws.Cells[6, 31].Value = "Rp";

                ws.Cells[5, 32].Value = "Adjs Stok";
                ws.Cells[6, 32].Value = "Qty";
                ws.Cells[6, 33].Value = "Rp";

                ws.Cells[5, 34].Value = "Stok Akhir";
                ws.Cells[6, 34].Value = "Qty";
                ws.Cells[6, 35].Value = "Rp";

                ws.Cells[5, 36].Value = "Total GIT AG";
                ws.Cells[6, 36].Value = "Qty";
                ws.Cells[6, 37].Value = "Rp";

                ws.Cells[5, 38].Value = "Stok Gudang";
                ws.Cells[6, 38].Value = "Qty";
                ws.Cells[6, 39].Value = "Rp";

                ws.Cells[5, 40].Value = "Hppa";

                ws.Cells[5, 2, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 2, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                int idx = 7;
                int no = 1;
                foreach (DataRow drd in dt.Rows)
                {
                    ws.Cells[idx, 2].Value = drd["NamaBarang"];
                    ws.Cells[idx, 3].Value = drd["BarangID"];
                    ws.Cells[idx, 4].Value = drd["JenisBarang"];
                    ws.Cells[idx, 5].Value = drd["KodeRak"];

                    ws.Cells[idx, 6].Value = drd["QtyAwal"];
                    ws.Cells[idx, 6].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 7].Value = drd["RpSaldoAwal"];
                    ws.Cells[idx, 7].Style.Numberformat.Format = "#,##";
                    
                    ws.Cells[idx, 8].Value = drd["QtyBeli"];
                    ws.Cells[idx, 8].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 9].Value = drd["RpBeli"];
                    ws.Cells[idx, 9].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 10].Value = drd["QtyReturBeli"];
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 11].Value = drd["RpReturBeli"];
                    ws.Cells[idx, 11].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 12].Value = drd["QtyJual"];
                    ws.Cells[idx, 12].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 13].Value = drd["RpJual"];
                    ws.Cells[idx, 14].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 14].Value = drd["QtyReturJual"];
                    ws.Cells[idx, 14].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 15].Value = drd["RpReturJual"];
                    ws.Cells[idx, 15].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 16].Value = drd["QtyAG"];
                    ws.Cells[idx, 16].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 17].Value = drd["RpAG"];
                    ws.Cells[idx, 17].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 18].Value = drd["QtyMutasiMasuk"];
                    ws.Cells[idx, 18].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 19].Value = drd["RpMutasiMasuk"];
                    ws.Cells[idx, 19].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 20].Value = drd["QtyMutasiKeluar"];
                    ws.Cells[idx, 20].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 21].Value = drd["RpMutasiKeluar"];
                    ws.Cells[idx, 21].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 22].Value = drd["QtyKorBeli"];
                    ws.Cells[idx, 22].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 23].Value = drd["RpKorBeli"];
                    ws.Cells[idx, 23].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 24].Value = drd["QtyKorRetBeli"];
                    ws.Cells[idx, 24].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 25].Value = drd["RpKorRetBeli"];
                    ws.Cells[idx, 25].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 26].Value = drd["QtyKorJual"];
                    ws.Cells[idx, 26].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 27].Value = drd["RpKorJual"];
                    ws.Cells[idx, 27].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 28].Value = drd["QtyKorRetJual"];
                    ws.Cells[idx, 28].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 29].Value = drd["RpKorRetJual"];
                    ws.Cells[idx, 29].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 30].Value = drd["ADJOpname"];
                    ws.Cells[idx, 30].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 31].Value = drd["RpADJOpname"];
                    ws.Cells[idx, 31].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 32].Value = drd["ADJlosing"];
                    ws.Cells[idx, 32].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 33].Value = drd["RpADJClosing"];
                    ws.Cells[idx, 33].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 34].Value = drd["StokAkhir"];
                    ws.Cells[idx, 34].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 35].Value = drd["RpStokAkhir"];
                    ws.Cells[idx, 35].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 36].Value = drd["QtyGIT"];
                    ws.Cells[idx, 36].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 37].Value = drd["RpGIT"];
                    ws.Cells[idx, 37].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 38].Value = drd["StokGudang"];
                    ws.Cells[idx, 38].Style.Numberformat.Format = "#,##";
                    ws.Cells[idx, 39].Value = drd["RpStokGudang"];
                    ws.Cells[idx, 39].Style.Numberformat.Format = "#,##";

                    ws.Cells[idx, 40].Value = drd["Hppa"];
                    ws.Cells[idx, 40].Style.Numberformat.Format = "#,##";

                    no++;
                    idx++;
                }

                ws.Cells[5, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                ws.Cells[6, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[6, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

                var border = ws.Cells[7, 2, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[5, 2, 6, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = 
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[idx, 2, idx, MaxCol].Style.Border;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style = 
                border.Right.Style = ExcelBorderStyle.Thin;

                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rptGudangPosisiStokNew" + ".xlsx";
                //sf.FileName = "Penjualan_Per_barang" + dateTimePicker2.Value.ToString("yyyyMMdd") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }
            }

        }


        private void ReloadCBO()
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt=db.Commands[0].ExecuteDataTable();
                    
                    object[] dr = {"",""};
                    dt.Rows.Add(dr);

                    cboKel.ValueMember="kelompokBrgID";
                    cboKel.DisplayMember="kelompokBrgID";
                    cboKel.DataSource=dt;
                    cboKel.SelectedValue = "";

                    }
                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
                }
            }

        private void ReloadCBOPeng()
            {
            try
                {

                using (Database db = new Database())
                    {
                    DataTable dtPD=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                    dtPD=db.Commands[0].ExecuteDataTable();

                    object[] dr = { Guid.NewGuid(), "" };
                    dtPD.Rows.Add(dr);

                    cboPen.ValueMember="Nama";
                    cboPen.DisplayMember="Nama";
                    cboPen.DataSource=dtPD;
                    cboPen.SelectedValue = "";
                    }

                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            
            }
            
        public frmRptGudangPosisiStok()
            {
            InitializeComponent();
            }

        private void frmRptGudangPosisiStok_Load(object sender, EventArgs e)
            {
            rdbA1.Checked=true;
            rdbB1.Checked=true;
            rdbD1.Checked=true;
            ReloadCBO();
            ReloadCBOPeng();
            rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate=DateTime.Now;
            txtNama.Visible = false;
            fillComboBoxJenisBarangType();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
                if (lookupGudang1.GudangID == "" && GlobalVar.Gudang!="0901")
                {
                    lookupGudang1.Focus();
                    ErrorProvider err = new ErrorProvider();
                    err.SetError(lookupGudang1, "harap di isi");
                    return;
                }
             try
                 {                
                     this.Cursor = Cursors.WaitCursor;
                     DataTable dt = new DataTable();
                     using (Database db = new Database())
                         {

                         //db.Commands.Add(db.CreateCommand((this.lookupGudang1.GudangID != "") ? "[rsp_StokGudang_PosisiStok]" : "[rsp_StokGudang_PosisiStok_all]"));
                             db.Commands.Add(db.CreateCommand("[rsp_StokGudang_PosisiStokNew]"));
                         db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime,rangeDateBox1.FromDate.Value));
                         db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                         db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar,GlobalVar.Gudang));
                         db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                         db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar,cboKel.Text));
                         db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, lookupStock.BarangID));
                           if (rdbD2.Checked==true)
                         {
                         db.Commands[0].Parameters.Add(new Parameter("@Minus", SqlDbType.Int, 0));
                         }

                         if (cboPen.Text!="")
                         {
                         	db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar,cboPen.Text));
                         }
                            if (!rdbB1.Checked)
                         {
                             db.Commands[0].Parameters.Add(new Parameter("@LPasif", SqlDbType.Bit, rdbB2.Checked ? 0 :1));
                         }
                         
                         if (rdbA2.Checked==true)
                         {
                         	db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, txtNama.Text));
                         }
                         db.Commands[0].Parameters.Add(new Parameter("@HppBeli", SqlDbType.Bit, 1));
                         dt = db.Commands[0].ExecuteDataTable();
                         }

                 if (dt.Rows.Count==0)
                 {
                     MessageBox.Show("No Data");
                     return;
                 }
                        //DisplayReport(dt);
                        DisplayReportExcell(dt);

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

        private void lookupStock_Leave(object sender, EventArgs e)
        {
            if (lookupStock.NamaStock == "")
            {
                lookupStock.BarangID = "";
            }
            

        }


        private void lookupGudang1_Leave(object sender, EventArgs e)
            {
            if (lookupGudang1.NamaGudang=="")
            {
            lookupGudang1.GudangID="";
            }
            }

        private void rdbA1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbA1.Checked)
            {
                txtNama.Text = "";
                txtNama.Visible = false;
                lookupStock.BarangID = "";
                lookupStock.Visible = true;
            }else
            {
                txtNama.Text = "";
                txtNama.Visible = true;
                lookupStock.BarangID = "";
                lookupStock.Visible = false;
            }
        }

        private void rdbA2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbA2.Checked == false)
            {
                txtNama.Text = "";
                txtNama.Visible = false;
                lookupStock.BarangID = "";
                lookupStock.Visible = true;
            }
            else
            {
                txtNama.Text = "";
                txtNama.Visible = true;
                lookupStock.BarangID = "";
                lookupStock.Visible = false;
            }
        }

        private void fillComboBoxJenisBarangType()
        {

            try
            {

                //retrieving data

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_JenisBarang_list]"));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                object[] dr = { Guid.NewGuid(), "" };
                dt.Rows.Add(dr);
                //display data
                cboKel.DataSource = dt;
                cboKel.DisplayMember = "Jenis";
                cboKel.ValueMember = "RowID";

                cboKel.SelectedValue = "";

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        }
    }
