using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
//using ISA.Trading.DataTemplates;
//using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
//using System.Globalization;
using System.IO;

namespace ISA.Toko.Master
{
    public partial class frmTokoDispensasiUpload : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();
        public frmTokoDispensasiUpload()
        {
            InitializeComponent();
        }

        private void cmbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUpload_Click(object sender, EventArgs e)
        {
            if (lookupToko1.NamaToko == "")
            {
                errorProvider1.SetError(lookupToko1, "Pilih Toko");
                return;
            }
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DisplayReport(dt);
            }
            else
            {
                MessageBox.Show("Tidak Ada Data yang  di upload");
            }
        }

        private void GenerateUpload()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    //DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_GetTokoDispen_upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;

                    //DisplayReport(dt);
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
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1(dt));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Pengajuan Toko Dispensasi " + lookupToko1.NamaToko + "_" + GlobalVar.Gudang;
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


        private ExcelPackage Process1(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Pengajuan Toko Dispensasi " + lookupToko1.NamaToko + "_" + GlobalVar.Gudang;

            #region sheet 1
            ex.Workbook.Worksheets.Add("Ajuan Toko Dispensasi");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 9;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 30;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 50;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 30;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 25;


            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 2, 1, MaxCol].Merge = true;
            ws.Cells[1, 2].Value = "PENGAJUAN TOKO DISPENSASI";
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 2, 2, MaxCol].Merge = true;
            ws.Cells[2, 2].Value = "TANGGAL     : " + string.Format("{0:dd MMMM yyyy}", DateTime.Now);
            ws.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 2].Value = "NO"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "KD TOKO"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "NAMA TOKO"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "ALAMAT"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "KOTA"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "IDWIL"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 8].Value = "KETERANGAN"; ws.Cells[5, 8, 6, 8].Merge = true;
            ws.Cells[5, 9].Value = " JML OVERDUE (Rp)"; ws.Cells[5, 9, 6, 9].Merge = true;

            ws.Cells[5, 2, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 2, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;
            int nomer = 0;
            foreach (DataRow dr1 in dt.Rows)
            {
                nomer = nomer + 1;
                //ws.Cells[rowx, 1].Value = string.Format("{0:dd MMMM yyyy}", dr1["Tanggal"]);
                ws.Cells[rowx, 2].Value = nomer;
                ws.Cells[rowx, 3].Value = dr1["kodetoko"];
                ws.Cells[rowx, 4].Value = dr1["NamaToko"];
                ws.Cells[rowx, 5].Value = dr1["Alamat"];
                ws.Cells[rowx, 6].Value = dr1["Kota"];
                //ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                ws.Cells[rowx, 7].Value = dr1["WilID"];
                ws.Cells[rowx, 8].Value = dr1["Keterangan"];
                ws.Cells[rowx, 9].Value = dr1["overdue"];
                ws.Cells[rowx, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                rowx++;
            }


            ws.Cells[5, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 2, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            #endregion

            return ex;
        }

        private void lookupToko1_Leave(object sender, EventArgs e)
        {
            if (lookupToko1.NamaToko != "" || lookupToko1.KodeToko != "[CODE]")
            {
                GenerateUpload();
            }
        }

        private void frmTokoDispensasiUpload_Load(object sender, EventArgs e)
        {
            lookupToko1.Focus();
        }
    }
}
