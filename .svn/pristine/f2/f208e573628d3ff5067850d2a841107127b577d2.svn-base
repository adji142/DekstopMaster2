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
using System.Diagnostics;
using System.Data.SqlClient;


namespace ISA.Trading.Master
{
    public partial class frmPriceList : ISA.Controls.BaseForm
    {
        DataTable dtBarang;
        DataSet dsData;

        public frmPriceList()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void GetKelompokBarang(string klp)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KlpBarang_LIST"));
                    if (klp != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@klp", SqlDbType.VarChar, cmbKlp.Text));
                    }
                    dtBarang = db.Commands[0].ExecuteDataTable();
                }
                if (dtBarang.Rows.Count == 0)
                {
                    MessageBox.Show("Kelompok Barang tidak ada.....");
                    Close();
                }
                else
                {
                    cmbKlp.Items.Clear();
                    foreach (DataRow datacombo in dtBarang.Rows)
                    {
                        string barang = Convert.ToString(datacombo["KelompokBrgID"]);
                        cmbKlp.Items.Add(barang);
                    }
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


        private void frmPriceList_Load(object sender, EventArgs e)
        {
            GetKelompokBarang("");
        }


        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string cFilter = "";
                if (rbStok.Checked)
                    cFilter = "1";
                else
                    cFilter = "0";

                DataSet dsData = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PriceList_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@klp", SqlDbType.VarChar, cmbKlp.Text.ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.VarChar, cFilter));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
                if (dsData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                DisplayReport(dsData);
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


        private void DisplayReport(DataSet dsData)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(rptPriceListBE(dsData));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "PriceList_depo";

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


        private ExcelPackage rptPriceListBE(DataSet dsData)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Price List";
            ex.Workbook.Properties.SetCustomPropertyValue("Price List", "1147");

            #region Price List

            ex.Workbook.Worksheets.Add("Price List");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.Cells[1, 1].Worksheet.Column(1).Width = 1;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 6;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 17;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 75;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 6;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 7;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 12;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 6;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 12;
            ws.Cells[1,10].Worksheet.Column(10).Width = 6;
            ws.Cells[1,11].Worksheet.Column(11).Width = 12;
            ws.Cells[1,12].Worksheet.Column(12).Width = 6;
            ws.Cells[1,13].Worksheet.Column(13).Width = 13;
            ws.Cells[1,14].Worksheet.Column(14).Width = 14;

            // Title
            ws.Cells[1, 2].Value = "PRICE LIST (BOTTOM PRICE)";
            ws.Cells[1, 2].Style.Font.Size = 12;
            ws.Cells[1, 2].Style.Font.Bold = true;
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //ws.Cells[3, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer); // + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[3, 2].Style.Font.Bold = true;
            ws.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //Header
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;

            ws.Cells[4, 2].Value = " NO ";
            ws.Cells[4, 3].Value = " KODE BARANG ";
            ws.Cells[4, 4].Value = " NAMA BARANG ";
            ws.Cells[4, 5].Value = " SAT ";
            ws.Cells[4, 6].Value = " STOK ";
            ws.Cells[4, 7].Value = " HET ";
            ws.Cells[4, 8].Value = " D.C ";
            ws.Cells[4, 9].Value = " HRG CASH ";
            ws.Cells[4,10].Value = " D.T ";
            ws.Cells[4,11].Value = " HRG TOP10 ";
            ws.Cells[4,12].Value = " D.E ";
            ws.Cells[4,13].Value = " HRG ENDUSER ";
            ws.Cells[4,14].Value = " TGL AKTIF ";

            int MaxCol = 14;
            int rowz = 4;
            int rowx = rowz + 2;
            int no = 0;
            double JmlD = 0, JmlK = 0;

            ws.Cells[4, 2, 5, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[4, 2, 5, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[4, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                no += 1;
                ws.Cells[rowx, 2].Value = no.ToString();
                ws.Cells[rowx, 3].Value = Tools.isNull(dr["BarangID"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr["NamaStok"], "");
                ws.Cells[rowx, 5].Value = Tools.isNull(dr["Satuan"], "");

                ws.Cells[rowx, 6].Value = Tools.isNull(dr["Stok"], 0);
                ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";

                ws.Cells[rowx, 7].Value = Tools.isNull(dr["het"], 0);
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";

                ws.Cells[rowx, 8].Value = Tools.isNull(dr["cash"], 0);
                ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[rowx, 9].Value = Tools.isNull(dr["hjual_c"], 0);
                ws.Cells[rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";

                ws.Cells[rowx, 10].Value = Tools.isNull(dr["top10"], 0);
                ws.Cells[rowx, 10].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[rowx, 11].Value = Tools.isNull(dr["hjual_t"], 0);
                ws.Cells[rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";

                ws.Cells[rowx, 12].Value = Tools.isNull(dr["enduser"], 0);
                ws.Cells[rowx, 12].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[rowx, 13].Value = Tools.isNull(dr["hjual_e"], 0);
                ws.Cells[rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";

                ws.Cells[rowx, 14].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr["TglAktif"], ""));
                ws.Cells[rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                rowx++;
            }

            var border = ws.Cells[rowz + 1, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowz, 2, rowz, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            return ex;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
