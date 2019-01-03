using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Controls;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Data.SqlClient;


namespace ISA.Trading.Persediaan
{
    public partial class frmCekDataHasilOpname : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();
        DataSet dsdata = new DataSet();
        
        public frmCekDataHasilOpname()
        {
            InitializeComponent();
        }

        private void frmCekDataHasilOpname_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGet_Click(object sender, EventArgs e)
        {
            //Persediaan.frmStokOpnameTransfer_LIST ifrmChild = new Persediaan.frmStokOpnameTransfer_LIST();    //this, 1, _RowID, _RecordID, _NamaBarang);
            //ifrmChild.ShowDialog();

            Persediaan.frmStokOpnameTransfer_LIST frm = new Persediaan.frmStokOpnameTransfer_LIST();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                //RefreshDataTransfer();
                MessageBox.Show("SIP");
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            GetDataTransferOpname();
        }


        private void GetDataTransferOpname()
        {
            //MessageBox.Show("Proses get Data");
            if (MessageBox.Show("Get Data Transfer Opname ?", "Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if (PeriodeClosing.IsHPPClosed(dateTextBox1.DateValue.Value))
                //{
                //    MessageBox.Show("Sudah CLosing HPP");
                //    return;
                //}

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_Opname_Transfer_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dsdata = db.Commands[0].ExecuteDataSet();
                        dt = db.Commands[0].ExecuteDataTable();
                        //cgvOpnameView.DataSource = dt;
                    }
                    if (dsdata.Tables[0].Rows.Count > 0)
                    {
                        dgvOpnameView.DataSource = dt;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada data");
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

                //this.Close();
            }

        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            DisplayReport(dsdata);
        }


        private void DisplayReport(DataSet dsData)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(rptHasilOpname(dsData));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rptStokOpname";

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


        private ExcelPackage rptHasilOpname(DataSet dsData)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Price List";
            ex.Workbook.Properties.SetCustomPropertyValue("Price List", "1147");

            #region Price List

            ex.Workbook.Worksheets.Add("StokOpname");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.Cells[1, 1].Worksheet.Column(1).Width = 1;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;   //No
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;  //Tgl Opname
            ws.Cells[1, 4].Worksheet.Column(4).Width = 16;  //KodeBarang
            ws.Cells[1, 5].Worksheet.Column(5).Width = 73;  //NamaStok
            ws.Cells[1, 6].Worksheet.Column(6).Width = 5;   //Satuan
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;  //QtyOpname
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;  //QtyJual
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;  //Jumlah
            ws.Cells[1,10].Worksheet.Column(10).Width = 30;  //Keterangan

            // Title
            ws.Cells[1, 2].Value = "STOK OPNAME";
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
            ws.Cells[4, 7, 5, 7].Style.WrapText = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4,10, 5,10].Merge = true;

            ws.Cells[4, 2].Value = " NO ";
            ws.Cells[4, 3].Value = " TGL OPNAME ";
            ws.Cells[4, 4].Value = " KODE BARANG ";
            ws.Cells[4, 5].Value = " NAMA BARANG ";
            ws.Cells[4, 6].Value = " SAT ";
            ws.Cells[4, 7].Value = " QTY OPNAME ";
            ws.Cells[4, 8].Value = " QTY JUAL ";
            ws.Cells[4, 9].Value = " JUMLAH ";
            ws.Cells[4,10].Value = " KETERANGAN ";

            int MaxCol = 10;
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
                ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr["TglOpname"], ""));
                ws.Cells[rowx, 4].Value = Tools.isNull(dr["KodeBarang"], "");
                ws.Cells[rowx, 5].Value = Tools.isNull(dr["NamaStok"], "");
                ws.Cells[rowx, 6].Value = Tools.isNull(dr["Satuan"], "");

                ws.Cells[rowx, 7].Value = Tools.isNull(dr["QtyOpname"], 0);
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##0";

                ws.Cells[rowx, 8].Value = Tools.isNull(dr["QtyJual"], 0);
                ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##0";

                ws.Cells[rowx, 9].Value = Tools.isNull(dr["Jumlah"], 0);
                ws.Cells[rowx, 9].Style.Numberformat.Format = "#,##0";

                ws.Cells[rowx,10].Value = Tools.isNull(dr["Keterangan"], "");

                //ws.Cells[rowx, 14].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr["TglAktif"], ""));
                //ws.Cells[rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
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


        private void cmdTransfer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Transfer Opname ?", "Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (PeriodeClosing.IsHPPClosed(dateTextBox1.DateValue.Value))
                {
                    MessageBox.Show("Sudah CLosing HPP");
                    return;
                }

                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Opname_History_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                    }
                    catch (Exception ex) { Error.LogError(ex); }
                    finally { Cursor.Current = Cursors.Default; }


                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        int c = 1;
                        foreach (DataRow dr in dsdata.Tables[0].Rows)
                        {
                            string cRecordID = Tools.CreateFingerPrint().ToString().Substring(0, 17) + c.ToString().PadLeft(5, '0');
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("psp_Opname_Transfer_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, cRecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dr["TglOpname"]));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, dr["KodeBarang"].ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int, int.Parse(Tools.isNull(dr["Jumlah"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                            c++;
                        }
                    }
                    catch (Exception ex) { Error.LogError(ex); }
                    finally { Cursor.Current = Cursors.Default; }

                    MessageBox.Show("Proses selesai");
                    //this.Close();
                }
            }
        }
    }
}
