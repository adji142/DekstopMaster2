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
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ISA.Toko.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Toko.Communicator
{
    public partial class frmOrderSheetDownload : ISA.Controls.BaseForm
    {
        private DataTable _dtHeader;
        private DataTable _dtDetail;

        public frmOrderSheetDownload()
        {
            InitializeComponent();
        }

        private bool UnzipFile(string sourceZIPFileName, string fileName1, string fileName2)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload; // +"\\" + sourceZIPFileName;
            string zipFile = GlobalVar.DbfDownload + "\\" + sourceZIPFileName + ".ZIP";
            if (File.Exists(zipFile))
            {
                if (File.Exists(fileName1))
                {
                    File.Delete(fileName1);
                }

                if (File.Exists(fileName2))
                {
                    File.Delete(fileName2);
                }

                Zip.UnZipFiles(zipFile, extractFileLocation, false);
                this.Title = zipFile;
                retVal = true;
            }
            else
            {
                this.Title = "File " + zipFile + " tidak ada.";

                MessageBox.Show("File: " + zipFile + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void frmOrderSheetDownload_Load(object sender, EventArgs e)
        {
            string headerFileName = "hostmp.dbf";
            string detailFileName = "dostmp.dbf";
            string zipFileName = "DataOS00";


            headerFileName = GlobalVar.DbfDownload + "\\" + headerFileName;
            detailFileName = GlobalVar.DbfDownload + "\\" + detailFileName;

            if (UnzipFile(zipFileName, headerFileName, detailFileName))
            {
                if (File.Exists(headerFileName))
                {
                    try
                    {
                        _dtHeader = Foxpro.ReadFile(headerFileName);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        _dtHeader.Columns.Add(newcol);

                        dgvHeader.DataSource = _dtHeader;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = _dtHeader.Rows.Count;
                        this.Title = headerFileName;
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                if (File.Exists(detailFileName))
                {
                    try
                    {
                        _dtDetail = Foxpro.ReadFile(detailFileName);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        _dtDetail.Columns.Add(newcol);

                        dgvDetail.DataSource = _dtDetail;
                        progressBar2.Minimum = 0;
                        progressBar2.Maximum = _dtDetail.Rows.Count;
                        this.Title = detailFileName;
                        this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }

                dgvHeader.AutoGenerateColumns = true;
                dgvDetail.AutoGenerateColumns = true;
            }
        }

        private void DisplayDetail()
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                string idTr = dgvHeader.Rows[dgvHeader.CurrentRow.Index].Cells["IDTR"].Value.ToString();
                DataView dvDetail = _dtDetail.DefaultView;
                dvDetail.RowFilter = "IDTR = '" + idTr + "'";

                dgvDetail.DataSource = dvDetail.Table;
            }
        }

        private void dgvHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            DisplayDetail();
        }

        #region generate excel
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();

            #region sheet 1
            ex.Workbook.Worksheets.Add("OS");
            ExcelWorksheet ws1 = ex.Workbook.Worksheets[1];

            ws1.Cells[1, 1].Worksheet.Column(1).Width = 12;
            ws1.Cells[1, 2].Worksheet.Column(2).Width = 12;
            ws1.Cells[1, 3].Worksheet.Column(3).Width = 15;
            ws1.Cells[1, 4].Worksheet.Column(4).Width = 60;
            ws1.Cells[1, 5].Worksheet.Column(5).Width = 10;

            // Title
            ws1.Cells[1, 1].Value = "LAPORAN HASIL DOWNLOAD OS"; 
            ws1.Cells[2, 1].Value = "Tanggal " + DateTime.Now.ToString("dd-MMM-yyyy");

            ws1.Cells[1, 1, 2, 1].Style.Font.Size = 14;
            ws1.Cells[1, 1, 2, 1].Style.Font.Bold = true;

            // Header
            ws1.Cells[4, 1].Value = "No. OS";
            ws1.Cells[4, 2].Value = "Tanggal OS";
            ws1.Cells[4, 3].Value = "Pemasok";
            ws1.Cells[4, 4].Value = "Nama Stok";
            ws1.Cells[4, 5].Value = "Satuan";

            ws1.Cells[4, 1, 4, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Detail
            int startRow = 5;
            int lastRow = startRow;

            foreach(DataRow drHeader in _dtHeader.Rows)
            {
                if (!drHeader.IsNull("NO_RQ"))
                    ws1.Cells[lastRow, 1].Value = drHeader["NO_RQ"].ToString();

                if (!drHeader.IsNull("TGL_INFO"))
                    ws1.Cells[lastRow, 2].Value = ((DateTime)drHeader["TGL_INFO"]).ToString("dd-MMM-yyyy");

                if (!drHeader.IsNull("PEMASOK"))
                    ws1.Cells[lastRow, 3].Value = drHeader["PEMASOK"].ToString();

                if (!drHeader.IsNull("IDTR"))
                {
                    string idTr = dgvHeader.Rows[dgvHeader.CurrentRow.Index].Cells["IDTR"].Value.ToString();

                    DataView dvDetail = _dtDetail.DefaultView;
                    dvDetail.RowFilter = "IDTR = '" + idTr + "'";

                    foreach (DataRow drDetail in dvDetail.Table.Rows)
                    {
                        if (!drDetail.IsNull("NAMA_STOK"))
                            ws1.Cells[lastRow, 4].Value = drDetail["NAMA_STOK"].ToString();

                        if (!drDetail.IsNull("SATUAN"))
                            ws1.Cells[lastRow, 5].Value = drDetail["SATUAN"].ToString();

                        lastRow++;
                    }
                }

                lastRow++;
            }

            var border1 = ws1.Cells[4, 1, lastRow, 5].Style.Border;
            border1.Bottom.Style =
            border1.Top.Style =
            border1.Left.Style =
            border1.Right.Style = ExcelBorderStyle.Thin;
            ws1.Cells[4, 1, 4, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[4, 1, 4, 5].Style.Fill.BackgroundColor.SetColor(Color.Cyan);

            lastRow++;
            ws1.Cells[lastRow, 1].Value = SecurityManager.UserID + " " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
            #endregion

            #endregion

            return ex;
        }


        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = GlobalVar.DbfDownload;
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "OS- " + GlobalVar.Gudang + "-" + DateTime.Now.ToString("yyyyMMdd_hhmmss");

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


        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (dgvHeader.Rows.Count > 0 && dgvDetail.Rows.Count > 0)
                {
                    DisplayReport();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
