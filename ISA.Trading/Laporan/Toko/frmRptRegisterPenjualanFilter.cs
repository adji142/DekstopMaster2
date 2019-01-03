using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using ISA.Trading.Class;

//using Excel = Microsoft.Office.Interop.Excel; 

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptRegisterPenjualanFilter : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        public frmRptRegisterPenjualanFilter()
        {
            InitializeComponent();
        }

        private void frmRptRegisterPenjualanFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Register Penjualan";
            this.Text = "Laporan";
            rdbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl.ToDate = DateTime.Now;
            rdoTglNota.Checked = true;
            rdoHrgBruto.Checked = true;
            rdbTgl.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl.FromDate.ToString() == "" || rdbTgl.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl, "Range Tanggal masih kosong");
                valid = false;
            }

            return valid;
        }

        #region laporanRekap
        private void prosesRekap()
        {
            if (!ValidateInput())
            {
                return;
            }

            string tipeTgl = "SJ";
            if (rdoTglTerima.Checked)
                tipeTgl = "TR";

            string tipeHarga = "BR";
            if (rdoHrgNetto.Checked)
                tipeHarga = "NT";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_RegisterPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeTgl", SqlDbType.VarChar, tipeTgl));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeHarga", SqlDbType.VarChar, tipeHarga));
                    db.Commands[0].Parameters.Add(new Parameter("@initcab", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                string sSum = dt.Compute("SUM(Nilai)", "Nilai IS NOT NULL").ToString();

                if (sSum == "")
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt);
                    UploadLaporan(dt);
                    //generateReport();
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptRegisterPenjualan.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            //ifrmReport.Show();
            ifrmReport.ExportToExcel("Register Penjualan_Rekap");
        } 
        #endregion

        #region Nota Jual
        private void NotaJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_NotaJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));

                    dt = db.Commands[0].ExecuteDataTable();

                } 
        
                DisplayReportNota(dt);
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

        private void DisplayReportNota(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Option", "2"));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptNotaJual.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            //ifrmReport.Show();
            ifrmReport.ExportToExcel("Register Penjualan Nota");

        }
        #endregion

        #region Retur
        private void Retur()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_ReturNotaJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));

                    dt = db.Commands[0].ExecuteDataTable();

                }
               

                DisplayReportRetur(dt);


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

        private void DisplayReportRetur(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            
            rptParams.Add(new ReportParameter("Harga", "HPP"));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptNotaReturJual.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            //ifrmReport.Show();
            ifrmReport.ExportToExcel("Register Penjualan Retur");

        }
        #endregion

        #region Refil
        private void Refill()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {


                    db.Commands.Add(db.CreateCommand("[rsp_laporanRefilToko]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rdbTgl.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rdbTgl.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReportRefil(dt);
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

        private void DisplayReportRefil(DataTable dt)
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("tanggal", rangeDateBoxPenjualan.FromDate.Value.ToString()));
            // rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.RptLaporanRefilToko.rdlc", rptParams, dt, "dsLaporanRefilToko_Data");
            //ifrmReport.Show();
            ifrmReport.ExportToExcel("Register Penjualan Refill");
        }
        #endregion

        private void cmdYES_Click(object sender, EventArgs e)
        {
            prosesRekap();
            NotaJual();
            Retur();
            Refill();
            
        }

        private void UploadLaporan(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string pathString = @"c:\temp";

                string filename1 = pathString + "\\" + "Rekap.xml";
                //string filename2 = pathString + "\\" + "omstall-" + DateTime.Now.ToString("yyyyMMdd") + " " + Guid.NewGuid().ToString() + ".xml";



                UploadXML(filename1, pathString, dt);

                ZipFile(filename1, pathString);

                //MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + pathString + "\\dbfmatch.zip");
                MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + ". Lokasi File: " + pathString + "\\dbfmatch"+GlobalVar.Gudang+".zip");

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

        private void UploadXML(string FileName, string Pathstring, DataTable dt)
        {
            try
            {

                if (!System.IO.Directory.Exists(Pathstring))
                {
                    System.IO.Directory.CreateDirectory(Pathstring);
                }
                dt.TableName = "Rekap";
                //FileName = pathString + "\\" + "omst-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                dt.WriteXml(FileName);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ZipFile(string FileName, string Pathstring)//, string FileName3, string FileName4)
        {
            List<string> files = new List<string>();


            //string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".xml";

            string fileZipName = Pathstring + "\\dbfmatch" + GlobalVar.Gudang + ".zip";
            files.Add(FileName);

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(FileName))// && File.Exists(fileIndex))
            {
                File.Delete(FileName);
                //File.Delete(FileName2);
                //File.Delete(fileName3);
                //File.Delete(fileName4);
                //File.Delete(fileIndex);
            }
        }

        //private void CreateNewWorkbook(Tables table)
        //{
        //    Excel.Application app = null;
        //    Excel.Workbook book = null;
        //    Excel.Worksheet sheet = null;

        //    try
        //    {
        //        string startPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        //        string filePath = System.IO.Path.Combine(startPath, "sal1011forms.xls");
        //        SaveFileDialog sfd = new SaveFileDialog();

        //        app = new Excel.Application();
        //        book = app.Workbooks.Open("filePath","","","","","","","","","","","","","","");
        //        //book = app.Workbooks.Open(filePath);
        //        sheet = (Excel.Worksheet)book.Worksheets.get_Item((int)table + 1);

        //        sfd.AddExtension = true;
        //        sfd.FileName = table.ToString() + ".xls";
        //        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //        if (sfd.ShowDialog() == true)
        //        {
        //        }
        //        if (sfd.ShowDialog() == true)
        //        {
        //            sheet.SaveAs(sfd.FileName);
        //        }
        //    }
        //    finally
        //    {
        //        if (book != null)
        //        {
        //            book.Close();
        //        }
        //        if (app != null)
        //        {
        //            app.Quit();
        //        }
        //        this.ReleaseObject(sheet);
        //        this.ReleaseObject(book);
        //        this.ReleaseObject(app);
        //    }
        //}

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void generateReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Register Penjualan" + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        #region generate excel

        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Register Penjualan";


            #region sheet 1
            ex.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            
            ws.Cells[1, 1].Worksheet.Column(1).Width = 25;
            ws.Cells[5, 1, 6, 1].Merge = true;

            DataTable dtJenisBarang = dt.DefaultView.ToTable(true, "KLP").Copy();
            int jenis = dtJenisBarang.Rows.Count;
            int total = jenis * 3;
            int MaxCol = total + 4;
            for (int r = 2; r <= MaxCol; r++)
            {
                ws.Cells[1, r].Worksheet.Column(r).Width = 15;
            }
           

            // Title
            string title = string.Empty;
            if (rdoHrgNetto.Checked == true)
            {
                title = "NETTO";
            }
            else
            {
                title = "BRUTTO";
            }
            ws.Cells[1, 1, 1, MaxCol].Merge = true;
            ws.Cells[1, 1].Value = "Laporan     : REGISTER PENJUALAN - " + title;
            

            ws.Cells[2, 1, 2, MaxCol].Merge = true;
            ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rdbTgl.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rdbTgl.ToDate);
            

            //Header
            ws.Cells[5, 1].Value = "KODE SALES"; ws.Cells[5, 1, 6, 1].Merge = true;
            for (int k = 0; k < jenis; k++)
            {
                int kk = k * 3;
                string namaklp = dtJenisBarang.Rows[k]["KLP"].ToString();
                ws.Cells[5, kk + 2].Value = namaklp; ws.Cells[5, kk + 2, 5, kk + 4].Merge = true;
                ws.Cells[6, kk + 2].Value = "PCS";
                ws.Cells[6, kk + 3].Value = "NILAI";
                ws.Cells[6, kk + 4].Value = "HPP";
                //k++;
            }
            ws.Cells[5, total+2].Value = "JUMLAH";
            ws.Cells[6, total + 2].Value = "PCS";
            ws.Cells[6, total + 3].Value = "NILAI";
            ws.Cells[6, total + 4].Value = "HPP";
            ws.Cells[5, total+2 , 5, total+4].Merge = true;

            ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;
            /*DataTable dtklp = dt.DefaultView.ToTable(true, "KLP").Copy();
            DataTable dtData = dt.Copy();
            DataTable dtSales = dt.DefaultView.ToTable(true, "KodeSales").Copy();
            int nilai = 0;
           // int cc = 2;
            foreach (DataRow drsales in dtSales.Rows)
            {
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";
                DataTable dtX = dtData.DefaultView.ToTable().Copy();

                string KodeSales = Convert.ToString(Tools.isNull(drsales["KodeSales"], ""));
                ws.Cells[rowx, 1].Value = KodeSales;
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";

                foreach (DataRow drklp in dtklp.Rows)
                {
                    dtX.DefaultView.RowFilter = "KLP='" + drklp["KLP"].ToString() + "'";
                    DataTable dTY = dtX.DefaultView.ToTable().Copy();


                   
                    //for (int u = 0; u < dTY.Rows.Count; u++)
                    //{

                        //if (dTY.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString())
                        //{
                            for (int cc = 0;cc < dtData.Rows.Count; cc++)
                            {
                                //if (dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString() && dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString())
                                //{
                                if (dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dtData.Columns["KLP"].ToString() == dTY.Columns["KLP"].ToString())
                                {

                                    nilai = Convert.ToInt32(Tools.isNull(dtData.DefaultView.ToTable().Compute("SUM(nilai)", "KodeSales='" + drsales["KodeSales"].ToString() + "'"), 0));
                                    //ws3.Cells[idx3, 3].Value = Oms;
                                    ws.Cells[rowx, cc * 3 + 3].Value = nilai;
                                   // cc++;
                                }
                                //}
                                //else
                                //{
                                //    ws.Cells[rowx, cc * 3 + 3].Value = 0;
                                //    cc++;
                                //}
                                cc++;
                            }
                                        //Convert.ToDouble(dTY.Rows[u]["nilai"].ToString());
                        //}
                        
                      //  u++;
                    //}
                    
                }
                
                rowx++;
            }*/


            ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 1, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            #endregion


            #region sheet 2
            ex.Workbook.Worksheets.Add("Nota");
            ExcelWorksheet ws1 = ex.Workbook.Worksheets[2];

            // Width

            ws1.Cells[1, 1].Worksheet.Column(1).Width = 25;
            ws1.Cells[1, 2].Worksheet.Column(2).Width = 15;
            ws1.Cells[1, 3].Worksheet.Column(3).Width = 15;
            ws1.Cells[1, 4].Worksheet.Column(4).Width = 50;
            ws1.Cells[1, 5].Worksheet.Column(5).Width = 50;
            ws1.Cells[1, 6].Worksheet.Column(5).Width = 15;

            ws1.Cells[5, 1, 6, 1].Merge = true;

            DataTable dtJenisBarang1 = dt.DefaultView.ToTable(true, "KLP").Copy();
            int jenis1 = dtJenisBarang1.Rows.Count;
            int total1 = jenis1 * 3;
            int MaxCol1 = total1 + 9;
            for (int r = 7; r <= MaxCol1; r++)
            {
                ws1.Cells[1, r].Worksheet.Column(r).Width = 15;
            }


            // Title
            
            ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
            ws1.Cells[1, 1].Value = "LAPORAN NOTA JUAL " ;


            ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
            ws1.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rdbTgl.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rdbTgl.ToDate);


            //Header
            ws1.Cells[5, 1].Value = "SALES"; ws1.Cells[5, 1, 6, 1].Merge = true;
            ws1.Cells[5, 2].Value = "TGL.NOTA"; ws1.Cells[5, 2, 6, 2].Merge = true;
            ws1.Cells[5, 3].Value = " NO. NOTA"; ws1.Cells[5, 3, 6, 3].Merge = true;
            ws1.Cells[5, 4].Value = "NAMA TOKO"; ws1.Cells[5, 4, 6, 4].Merge = true;
            ws1.Cells[5, 5].Value = "ALAMAT"; ws1.Cells[5, 5, 6, 5].Merge = true;
            ws1.Cells[5, 6].Value = "KOTA"; ws1.Cells[5, 6, 6, 6].Merge = true;
            for (int k = 0; k < jenis; k++)
            {
                int kk = k * 3;
                string namaklp = dtJenisBarang1.Rows[k]["KLP"].ToString();
                ws1.Cells[5, kk + 7].Value = namaklp; ws1.Cells[5, kk + 7, 5, kk + 9].Merge = true;
                ws1.Cells[6, kk + 7].Value = "PCS";
                ws1.Cells[6, kk + 8].Value = "NILAI";
                ws1.Cells[6, kk + 9].Value = "HPP";
                //k++;
            }
            ws1.Cells[5, total1 + 7].Value = "JUMLAH";
            ws1.Cells[6, total1 + 7].Value = "PCS";
            ws1.Cells[6, total1 + 8].Value = "NILAI";
            ws1.Cells[6, total1 + 9].Value = "HPP";
            ws1.Cells[5, total1 + 7, 5, total1 + 9].Merge = true;

            ws1.Cells[5, 1, 6, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[5, 1, 6, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx1 = 7;
            /*DataTable dtklp = dt.DefaultView.ToTable(true, "KLP").Copy();
            DataTable dtData = dt.Copy();
            DataTable dtSales = dt.DefaultView.ToTable(true, "KodeSales").Copy();
            int nilai = 0;
           // int cc = 2;
            foreach (DataRow drsales in dtSales.Rows)
            {
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";
                DataTable dtX = dtData.DefaultView.ToTable().Copy();

                string KodeSales = Convert.ToString(Tools.isNull(drsales["KodeSales"], ""));
                ws.Cells[rowx, 1].Value = KodeSales;
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";

                foreach (DataRow drklp in dtklp.Rows)
                {
                    dtX.DefaultView.RowFilter = "KLP='" + drklp["KLP"].ToString() + "'";
                    DataTable dTY = dtX.DefaultView.ToTable().Copy();


                   
                    //for (int u = 0; u < dTY.Rows.Count; u++)
                    //{

                        //if (dTY.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString())
                        //{
                            for (int cc = 0;cc < dtData.Rows.Count; cc++)
                            {
                                //if (dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString() && dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString())
                                //{
                                if (dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dtData.Columns["KLP"].ToString() == dTY.Columns["KLP"].ToString())
                                {

                                    nilai = Convert.ToInt32(Tools.isNull(dtData.DefaultView.ToTable().Compute("SUM(nilai)", "KodeSales='" + drsales["KodeSales"].ToString() + "'"), 0));
                                    //ws3.Cells[idx3, 3].Value = Oms;
                                    ws.Cells[rowx, cc * 3 + 3].Value = nilai;
                                   // cc++;
                                }
                                //}
                                //else
                                //{
                                //    ws.Cells[rowx, cc * 3 + 3].Value = 0;
                                //    cc++;
                                //}
                                cc++;
                            }
                                        //Convert.ToDouble(dTY.Rows[u]["nilai"].ToString());
                        //}
                        
                      //  u++;
                    //}
                    
                }
                
                rowx++;
            }*/


            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border1 = ws1.Cells[5, 1, rowx1 - 1, MaxCol1].Style.Border;
            border1.Bottom.Style =
            border1.Top.Style =
            border1.Left.Style =
            border1.Right.Style = ExcelBorderStyle.Thin;

            #endregion


            #region sheet 3
            ex.Workbook.Worksheets.Add("Retur");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[3];

            // Width

            ws2.Cells[1, 1].Worksheet.Column(1).Width = 25;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 15;
            ws2.Cells[1, 4].Worksheet.Column(4).Width = 50;
            ws2.Cells[1, 5].Worksheet.Column(5).Width = 50;
            ws2.Cells[1, 6].Worksheet.Column(5).Width = 15;
            ws2.Cells[5, 1, 6, 1].Merge = true;

            DataTable dtJenisBarang2 = dt.DefaultView.ToTable(true, "KLP").Copy();
            int jenis2 = dtJenisBarang2.Rows.Count;
            int total2 = jenis2 * 3;
            int MaxCol2 = total2 + 9;
            for (int r = 7; r <= MaxCol2; r++)
            {
                ws2.Cells[1, r].Worksheet.Column(r).Width = 15;
            }


            // Title

            ws2.Cells[1, 1, 1, MaxCol2].Merge = true;
            ws2.Cells[1, 1].Value = "LAPORAN NOTA RETUR";


            ws2.Cells[2, 1, 2, MaxCol2].Merge = true;
            ws2.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rdbTgl.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rdbTgl.ToDate);


            //Header
            ws2.Cells[5, 1].Value = "SALES"; ws2.Cells[5, 1, 6, 1].Merge = true;
            ws2.Cells[5, 2].Value = "TGL.RET"; ws2.Cells[5, 2, 6, 2].Merge = true;
            ws2.Cells[5, 3].Value = " NO.RET"; ws2.Cells[5, 3, 6, 3].Merge = true;
            ws2.Cells[5, 4].Value = "NAMA TOKO"; ws2.Cells[5, 4, 6, 4].Merge = true;
            ws2.Cells[5, 5].Value = "ALAMAT"; ws2.Cells[5, 5, 6, 5].Merge = true;
            ws2.Cells[5, 6].Value = "KOTA"; ws2.Cells[5, 6, 6, 6].Merge = true;
            for (int k = 0; k < jenis2; k++)
            {
                int kk = k * 3;
                string namaklp = dtJenisBarang2.Rows[k]["KLP"].ToString();
                ws2.Cells[5, kk + 7].Value = namaklp; ws2.Cells[5, kk + 7, 5, kk + 9].Merge = true;
                ws2.Cells[6, kk + 7].Value = "PCS";
                ws2.Cells[6, kk + 8].Value = "NILAI";
                ws2.Cells[6, kk + 9].Value = "HPP";
                //k++;
            }
            ws2.Cells[5, total2 + 7].Value = "JUMLAH";
            ws2.Cells[6, total2 + 7].Value = "PCS";
            ws2.Cells[6, total2 + 8].Value = "NILAI";
            ws2.Cells[6, total2 + 9].Value = "HPP";
            ws2.Cells[5, total2 + 7, 5, total2 + 9].Merge = true;

            ws2.Cells[5, 1, 6, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[5, 1, 6, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx2 = 7;
            /*DataTable dtklp = dt.DefaultView.ToTable(true, "KLP").Copy();
            DataTable dtData = dt.Copy();
            DataTable dtSales = dt.DefaultView.ToTable(true, "KodeSales").Copy();
            int nilai = 0;
           // int cc = 2;
            foreach (DataRow drsales in dtSales.Rows)
            {
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";
                DataTable dtX = dtData.DefaultView.ToTable().Copy();

                string KodeSales = Convert.ToString(Tools.isNull(drsales["KodeSales"], ""));
                ws.Cells[rowx, 1].Value = KodeSales;
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";

                foreach (DataRow drklp in dtklp.Rows)
                {
                    dtX.DefaultView.RowFilter = "KLP='" + drklp["KLP"].ToString() + "'";
                    DataTable dTY = dtX.DefaultView.ToTable().Copy();


                   
                    //for (int u = 0; u < dTY.Rows.Count; u++)
                    //{

                        //if (dTY.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString())
                        //{
                            for (int cc = 0;cc < dtData.Rows.Count; cc++)
                            {
                                //if (dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString() && dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString())
                                //{
                                if (dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dtData.Columns["KLP"].ToString() == dTY.Columns["KLP"].ToString())
                                {

                                    nilai = Convert.ToInt32(Tools.isNull(dtData.DefaultView.ToTable().Compute("SUM(nilai)", "KodeSales='" + drsales["KodeSales"].ToString() + "'"), 0));
                                    //ws3.Cells[idx3, 3].Value = Oms;
                                    ws.Cells[rowx, cc * 3 + 3].Value = nilai;
                                   // cc++;
                                }
                                //}
                                //else
                                //{
                                //    ws.Cells[rowx, cc * 3 + 3].Value = 0;
                                //    cc++;
                                //}
                                cc++;
                            }
                                        //Convert.ToDouble(dTY.Rows[u]["nilai"].ToString());
                        //}
                        
                      //  u++;
                    //}
                    
                }
                
                rowx++;
            }*/


            ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws2.Cells[6, 1, 6, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border2 = ws2.Cells[5, 1, rowx2 - 1, MaxCol2].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;

            #endregion


            #region sheet 4
            ex.Workbook.Worksheets.Add("Refil");
            ExcelWorksheet ws3 = ex.Workbook.Worksheets[4];

            // Width

            ws3.Cells[1, 1].Worksheet.Column(1).Width = 10;
            ws3.Cells[1, 2].Worksheet.Column(2).Width = 50;
            ws3.Cells[1, 3].Worksheet.Column(3).Width = 25;
            ws3.Cells[1, 4].Worksheet.Column(4).Width = 15;

            ws3.Cells[5, 1, 6, 1].Merge = true;

            //DataTable dtJenisBarang2 = dt.DefaultView.ToTable(true, "KLP").Copy();
            //int jenis2 = dtJenisBarang2.Rows.Count;
            //int total2 = jenis2 * 3;
            int MaxCol3 = 8;

            for (int r = 5; r <= MaxCol3; r++)
            {
                ws2.Cells[1, r].Worksheet.Column(r).Width = 15;
            }


            // Title

            ws3.Cells[1, 1, 1, MaxCol3].Merge = true;
            ws3.Cells[1, 1].Value = "LAPORAN REFIL TOKO";


            ws3.Cells[2, 1, 2, MaxCol3].Merge = true;
            ws3.Cells[2, 1].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", rdbTgl.FromDate) + " s/d " + string.Format("{0:dd MMMM yyyy}", rdbTgl.ToDate);


            //Header
            ws3.Cells[5, 1].Value = "NO"; ws3.Cells[5, 1, 6, 1].Merge = true;
            ws3.Cells[5, 2].Value = "NAMA STOK"; ws3.Cells[5, 2, 6, 2].Merge = true;
            ws3.Cells[5, 3].Value = "ID.BRG"; ws3.Cells[5, 3, 6, 3].Merge = true;
            ws3.Cells[5, 4].Value = "SAT"; ws3.Cells[5, 4, 6, 4].Merge = true;
            ws3.Cells[5, 5].Value = "QTY"; ws3.Cells[5, 5, 5, 7].Merge = true;
            ws3.Cells[6, 5].Value = "Q.JUAL";
            ws3.Cells[6, 6].Value = "Q.JUAL";
            ws3.Cells[6, 7].Value = "JUMLAH";
            ws3.Cells[5, 8].Value = "STOK"; ws3.Cells[5, 8, 6, 8].Merge = true;

            ws3.Cells[5, 1, 6, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws3.Cells[5, 1, 6, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx3 = 7;
            /*DataTable dtklp = dt.DefaultView.ToTable(true, "KLP").Copy();
            DataTable dtData = dt.Copy();
            DataTable dtSales = dt.DefaultView.ToTable(true, "KodeSales").Copy();
            int nilai = 0;
           // int cc = 2;
            foreach (DataRow drsales in dtSales.Rows)
            {
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";
                DataTable dtX = dtData.DefaultView.ToTable().Copy();

                string KodeSales = Convert.ToString(Tools.isNull(drsales["KodeSales"], ""));
                ws.Cells[rowx, 1].Value = KodeSales;
                dtData.DefaultView.RowFilter = "KodeSales='" + drsales["KodeSales"].ToString() + "'";

                foreach (DataRow drklp in dtklp.Rows)
                {
                    dtX.DefaultView.RowFilter = "KLP='" + drklp["KLP"].ToString() + "'";
                    DataTable dTY = dtX.DefaultView.ToTable().Copy();


                   
                    //for (int u = 0; u < dTY.Rows.Count; u++)
                    //{

                        //if (dTY.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString())
                        //{
                            for (int cc = 0;cc < dtData.Rows.Count; cc++)
                            {
                                //if (dTY.Columns["KLP"].ToString() == dtX.Columns["KLP"].ToString() && dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString())
                                //{
                                if (dtData.Columns["KodeSales"].ToString() == dtX.Columns["KodeSales"].ToString() && dtData.Columns["KLP"].ToString() == dTY.Columns["KLP"].ToString())
                                {

                                    nilai = Convert.ToInt32(Tools.isNull(dtData.DefaultView.ToTable().Compute("SUM(nilai)", "KodeSales='" + drsales["KodeSales"].ToString() + "'"), 0));
                                    //ws3.Cells[idx3, 3].Value = Oms;
                                    ws.Cells[rowx, cc * 3 + 3].Value = nilai;
                                   // cc++;
                                }
                                //}
                                //else
                                //{
                                //    ws.Cells[rowx, cc * 3 + 3].Value = 0;
                                //    cc++;
                                //}
                                cc++;
                            }
                                        //Convert.ToDouble(dTY.Rows[u]["nilai"].ToString());
                        //}
                        
                      //  u++;
                    //}
                    
                }
                
                rowx++;
            }*/


            ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws3.Cells[6, 1, 6, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws3.Cells[6, 1, 6, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border3 = ws3.Cells[5, 1, rowx3 - 1, MaxCol3].Style.Border;
            border3.Bottom.Style =
            border3.Top.Style =
            border3.Left.Style =
            border3.Right.Style = ExcelBorderStyle.Thin;

            #endregion

            return ex;
        }
        #endregion

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            prosesRekap();
            NotaJual();
            Retur();
            Refill();
        }
    }
}
