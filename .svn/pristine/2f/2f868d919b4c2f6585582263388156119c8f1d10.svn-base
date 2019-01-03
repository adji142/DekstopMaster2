using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;


namespace ISA.Finance.Hutang.Report
{
    public partial class frmRptHutangPBLokal_Rekap_Psho : ISA.Controls.BaseForm
    {
        int nDay, nMonth, nYear;
        DateTime _fromDate, _toDate;
        SqlGuid HP = SqlGuid.Null;
        Guid _RowIDPerusahaan;

        public frmRptHutangPBLokal_Rekap_Psho()
        {
            InitializeComponent();
        }

        private void frmRptHutangPBLokal_Rekap_Psho_Load(object sender, EventArgs e)
        {
            nYear = DateTime.Now.Year;
            nMonth = DateTime.Now.Month;

            rdbRekap.FromDate = new DateTime(nYear, nMonth, 1);
            rdbRekap.ToDate = DateTime.Now;

            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan2_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, "I"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                    dtPerusahaan.Rows.Add(Guid.Empty);
                }
                if (dtPerusahaan.Rows.Count > 0)
                {
                    //_RowIDPerusahaan = new Guid(dtPerusahaan.Rows[0]["RowID"].ToString());
                    dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                    cboPerusahaan.DataSource = dtPerusahaan;
                    cboPerusahaan.DisplayMember = "Nama";
                    cboPerusahaan.ValueMember = "RowID";

                    //dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                    //cboPerusahaan.ValueMember = "InitPerusahaan";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_HutangBeliLokal_Rekap_All]"));
                    if (lookUpVendor1.RowIDPemasok.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, lookUpVendor1.RowIDPemasok));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rdbRekap.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rdbRekap.ToDate));

                    if (rdoBelum.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, 0));
                    }
                    else if (rdoLunas.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, 1));
                    }
                    if (cboPerusahaan.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDPerusahaan", SqlDbType.UniqueIdentifier, _RowIDPerusahaan));
                    }

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                GenerateExcell(ds);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private bool NotValid()
        {
            bool val = false;
            ErrorProvider err = new ErrorProvider();

            if (!rdbRekap.FromDate.HasValue)
            {
                MessageBox.Show("Tanggal harus diisi");
                val = true;
                rdbRekap.Focus();
            }
            else if (!rdbRekap.ToDate.HasValue)
            {
                MessageBox.Show("Tanggal harus diisi");
                val = true;
                rdbRekap.Focus();
            }
            else if (lookUpVendor1.NamaVendor == "")
            {
                MessageBox.Show("Pemasok harus diisi");
                val = true;
                lookUpVendor1.Focus();
            }
            return val;
        }

        private void GenerateExcell(DataSet ds)
        {
            DataTable dt1 = new DataTable();

            dt1 = ds.Tables[0].Copy();

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "Laporan Saldo Hutang per Invoice";

                p.Workbook.Worksheets.Add("Saldo Hutang per Invoice");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1";
                ws.Cells.Style.Font.Size = 10;
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 10;
                int startH = 9;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 15;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 12;
                
                for (int i = 7; i <= MaxCol; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 20;
                }
                string Title = "Saldo Hutang per Invoice(Lokal)";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Tanggal"; ws.Cells[4, 2].Value = string.Format(" {0} s/d {1}", rdbRekap.FromDate.Value.ToString("dd-MMM-yyyy"), rdbRekap.ToDate.Value.ToString("dd-MMM-yyyy"));
                ws.Cells[5, 1].Value = "Vendor"; ws.Cells[5, 2].Value = lookUpVendor1.PemasokID == "" ? "ALL" : dt1.Rows[0]["NamaVendor"].ToString();
                ws.Cells[6, 1].Value = "Pokok Hutang IDR "; ws.Cells[6, 2].Value = Convert.ToDouble(dt1.Compute("SUM(IDRAmount)", ""));
                ws.Cells[7, 1].Value = "Saldo Hutang (IDR)"; ws.Cells[7, 2].Value = Convert.ToDouble(dt1.Compute("SUM(Saldo)", ""));

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 12;

                for (int i = 1; i <= MaxCol; i++)
                {
                    ws.Cells[9, i, 10, i].Merge = true;
                }


                #region Generate Header
                ws.Cells[startH, 1].Value = "Tgl Invoice";
                ws.Cells[startH, 2].Value = "No Invoice";
                ws.Cells[startH, 3].Value = "Vendor";
                ws.Cells[startH, 4].Value = "MataUang";
                ws.Cells[startH, 5].Value = "Hutang";
                ws.Cells[startH, 6].Value = "Status";
                ws.Cells[startH, 7].Value = "Nominal Invoice (IDR)";
                ws.Cells[startH, 8].Value = "Pembayaran (IDR)";
                ws.Cells[startH, 9].Value = "Biaya Tambahan (IDR)";
                ws.Cells[startH, 10].Value = "Sisa Hutang (IDR)";
                ws.Cells[startH, 1, startH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion


                #region FillData
                int idx = startH + 2;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ws.Cells[idx, 1].Value = dr["TglInvoice"];
                    ws.Cells[idx, 2].Value = dr["InvoiceNo"];
                    ws.Cells[idx, 3].Value = dr["NamaVendor"]; //dr["VendorID"];
                    ws.Cells[idx, 4].Value = dr["MataUangID"];
                    ws.Cells[idx, 5].Value = dr["Flag"];
                    ws.Cells[idx, 6].Value = dr["Category"];
                    ws.Cells[idx, 7].Value = dr["IDRAmount"];
                    ws.Cells[idx, 8].Value = dr["PembIDRAmount"];
                    ws.Cells[idx, 9].Value = dr["IDRTambahan"];
                    ws.Cells[idx, 10].Value = dr["Saldo"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.DodgerBlue);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);
                
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1].Value = "Total";

                for (int i = 7; i <= MaxCol; i++)
                {
                    ws.Cells[idx, i].Formula = "Sum(" + ws.Cells[startH + 1, i].Address +
                           ":" + ws.Cells[idx - 1, i].Address + ")";
                }

                ws.Cells[startH + 1, 6, idx, MaxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 1, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[7, 2].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[7, 2].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                ws.Cells[startH + 1, 6, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 6, idx, MaxCol].Style.WrapText = true;
                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "RekapHutanPerInvoiceLokal.xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerusahaan.Text == "")
            {
                _RowIDPerusahaan = Guid.Empty;
            }
            else
            {
                DataRowView row = (DataRowView)cboPerusahaan.SelectedItem;
                if (row != null)
                {
                    _RowIDPerusahaan = new Guid(row[0].ToString());
                }
            }
        }

    }
}
