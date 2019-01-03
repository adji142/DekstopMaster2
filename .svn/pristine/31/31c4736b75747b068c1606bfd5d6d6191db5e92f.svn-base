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
using ISA.Trading.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Trading.Penjualan
{
    public partial class frmPotonganNotaBrowse : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        bool filterF3 = false;
        bool filterF4 = false;
        bool filterF5 = false;

        public frmPotonganNotaBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPotonganNotaBrowse_Load(object sender, EventArgs e)
        {
            if (SecurityManager.HasRight("TRD.PENGAJUAN_POTONGAN"))
            {
                cmdAdd.Enabled = true;
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
            }

            dataGridView1.AutoGenerateColumns = false;
            rgbTgl.FromDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            rgbTgl.ToDate = GlobalVar.DateOfServer;

        }

        private void cmdSearch_Click_1(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTgl.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dt;
                filterF3 = false;
                filterF4 = false;
                filterF5 = false;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Now <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                Penjualan.frmPenjualanPotonganUpdateISA ifrmChild = new Penjualan.frmPenjualanPotonganUpdateISA(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //if (SecurityManager.HasRight("TRD.PENGAJUAN_POTONGAN"))
            //{
            //    if (SecurityManager.AskPasswordManager())
            //    {
            //        DeletePenjualanPotongan();
            //    }
            //}
            //else
            //{
                DeletePenjualanPotongan();
            //}
        }

        private void DeletePenjualanPotongan()
        {
            if (dataGridView1.SelectedCells[0].OwningRow.Cells["IdLink"].Value.ToString() == "")
            {
                //tutup sementara
                //if (GlobalVar.DateOfServer != (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value)
                //{
                //    MessageBox.Show("Sudah lewat tanggal");
                //    return;
                //}
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value;
                        if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
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
            }
            else
            {
                MessageBox.Show(Messages.Error.LinkPiutang);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    //GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value;
                    //if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value <= GlobalVar.LastClosingDate)
                    //{
                    //    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    //}

                    if (dataGridView1.SelectedCells[0].OwningRow.Cells["IDLink"].Value.ToString() != "")
                    {
                        MessageBox.Show("Sudah Link ke Piutang, tidak bisa Edit data", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //if (SecurityManager.HasRight("004") || SecurityManager.HasRight("005"))
                    //{
                    //    return;
                    //}

                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Penjualan.frmPenjualanPotonganUpdateISA ifrmChild = new Penjualan.frmPenjualanPotonganUpdateISA(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }

        }

        private void CmdF3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Pengajuan Potongan ?", "Proses", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GeneratePengajuan((DateTime)rgbTgl.FromDate, (DateTime)rgbTgl.ToDate);
            }
        }

        private void GeneratePengajuan(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = PengajuanData(fromDate, toDate);
            if (dt.Rows.Count > 0)
            {
                ExcelPackage ep = PengajuanWorksheets();
                ExcelWorksheet wsOverdue = PotonganWorksheet(dt, ep, fromDate, toDate);
                SavePengajuan(ep);
            }
            else
            {
                MessageBox.Show("Tidak ada pengajuan Retur.");
            }
        }

        private DataTable PengajuanData(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_PengajuanPotongan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private ExcelPackage PengajuanWorksheets()
        {
            ExcelPackage ep = new ExcelPackage();
            ep.Workbook.Worksheets.Add("Potongan");
            foreach (ExcelWorksheet ws in ep.Workbook.Worksheets)
            {
                ws.View.ShowGridLines = false;
                ws.View.PageLayoutView = true;
                ws.View.PageBreakView = true;
                ws.PrinterSettings.FitToPage = true;
            }
            return ep;
        }

        private ExcelWorksheet PotonganWorksheet(DataTable dt, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["Potongan"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN POTONGAN NOTA";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO";
            ws.Cells[4, 2].Value = "NO POT";
            ws.Cells[4, 3].Value = "TGL POT";
            ws.Cells[4, 4].Value = "NO NOTA";
            ws.Cells[4, 5].Value = "TGL NOTA";
            ws.Cells[4, 6].Value = "KD SALES";
            ws.Cells[4, 7].Value = "NAMA TOKO";
            ws.Cells[4, 8].Value = "ALAMAT";
            ws.Cells[4, 9].Value = "KOTA";
            ws.Cells[4, 10].Value = "Rp NET";
            ws.Cells[4, 11].Value = "Rp POTONGAN";
            ws.Cells[4, 12].Value = "CATATAN";
            ws.Cells[4, 13].Value = "KEY";
            ws.Cells[4, 14].Value = "PIN";
            ws.Cells[4, 15].Value = "DI ACC/TOLAK";
            ws.Cells[4, 16].Value = "TGL ACC";
            ws.Cells[4, 17].Value = "CATATAN";

            ws.Column(1).Width = 4;

            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 5;
            int rowCounter = 5;
            int maxCol = 17;
            int Cop = 4;

            foreach (DataRow dr in dt.Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoPot"];
                ws.Cells[rowCounter, 3].Value = dr["TglPot"];
                ws.Cells[rowCounter, 4].Value = dr["NoNota"];
                ws.Cells[rowCounter, 5].Value = dr["TglNota"];
                ws.Cells[rowCounter, 6].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 7].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 8].Value = dr["Alamat"];
                ws.Cells[rowCounter, 9].Value = dr["Kota"];
                ws.Cells[rowCounter, 10].Value = dr["RpNet"];
                ws.Cells[rowCounter, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowCounter, 11].Value = dr["Dil"];
                ws.Cells[rowCounter, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowCounter, 12].Value = dr["Catatan"];
                ws.Cells[rowCounter, 13].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.Potongan);
                rowNo++;
                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 4, maxCol].Style.Font.Bold = true;
            ws.Cells[4, 1, 4, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 4, maxCol].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[Cop, 1, Cop, maxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Cop+1, 1, rowCounter, maxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style = 
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[rowCounter, 1, rowCounter, maxCol].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style = 
            border.Right.Style = ExcelBorderStyle.Thin;
            
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 8, rowCounter, 9].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Center
            ws.Cells[Cop, 1, Cop, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[Cop, 1, Cop, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= maxCol; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private void SavePengajuan(ExcelPackage ep)
        {
            string directory = "C:\\Temp\\";
            string fileName = "Pengajuan_Potongan_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            string filePath = directory + fileName;

            Byte[] bin = ep.GetAsByteArray();

            if (File.Exists(filePath))
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = fileName;
                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    filePath = sf.FileName.ToString();
                }
            }

            File.WriteAllBytes(filePath, bin);
            Process.Start(filePath);
            MessageBox.Show("Pembuatan pengajuan telah selesai dan disimpan di: " + "\n" + filePath);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F11:
                    CmdF11.PerformClick();
                    //GeneratePengajuan((DateTime)rgbTglMPR.FromDate, (DateTime)rgbTglMPR.ToDate);
                    break;
                case Keys.F12:
                    CmdF11.PerformClick();
                    //GeneratePengajuan((DateTime)rgbTglMPR.FromDate, (DateTime)rgbTglMPR.ToDate);
                    break;
            }
        }

        private void CmdF4_Click(object sender, EventArgs e)
        {
            Guid potID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string noPot = dataGridView1.SelectedCells[0].OwningRow.Cells["NoPotJ"].Value.ToString();

            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, potID, GlobalVar.Gudang, PinId.Bagian.Potongan, "Pengajuan Potongan " + noPot);
            ifrmpin.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmpin);
            ifrmpin.Show();
            return;
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
