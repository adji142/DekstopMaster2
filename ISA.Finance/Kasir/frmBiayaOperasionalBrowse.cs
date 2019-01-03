using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

using System.Diagnostics;
using System.Data.SqlTypes;
using OfficeOpenXml.Drawing.Chart;


namespace ISA.Finance.Kasir
{
    public partial class frmBiayaOperasionalBrowse : ISA.Controls.BaseForm
    {
        private enum GridSelection { Header, Detail }
        enum enumModus { Upload, Download, Clear };
        enumModus Modus;
        List<string> files = new List<string>();
        private GridSelection selectedGrid;
        int counter = 0;
        string _Data = "BiayaOperasional";

        public frmBiayaOperasionalBrowse()
        {
            InitializeComponent();
        }

        private void frmBiayaOperasionalBrowse_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            rdbTanggal.FromDate = GlobalVar.DateOfServer;
            rdbTanggal.ToDate = GlobalVar.DateOfServer;

            selectedGrid = GridSelection.Header;

            cmdSearch_Click(sender, e);
            Modus = enumModus.Clear;
            SetEnable();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        private void rdbTanggal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmdSearch_Click(sender, e);
        }

        private void dgvHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = GridSelection.Header;
        }

        private void dgvHeader_SelectionChanged(object sender, EventArgs e)
        {
            dgvHeader_SelectionRowChanged(sender, e);
        }

        private void dgvHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void dgvDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = GridSelection.Detail;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case GridSelection.Header:
                    frmBiayaOperasionalAdd dlg = new frmBiayaOperasionalAdd();
                    dlg.ShowDialog();
                    Guid headerRowId = dlg.HeaderRowId;
                    if (headerRowId != Guid.Empty)
                    {
                        cmdSearch_Click(sender, e);
                        dgvHeader.FindRow("HeaderRowID", headerRowId.ToString());
                    }
                    break;
                case GridSelection.Detail:
                    if (dgvHeader.SelectedCells.Count > 0)
                    {
                        string pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                        if (pin != string.Empty)
                        {
                            MessageBox.Show("Tidak bisa menambah detail. Sudah diisi PIN.");
                            return;
                        }

                        Guid headerRowIdDet = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

                        frmBiayaOperasionalDetailAdd dlgDet = new frmBiayaOperasionalDetailAdd(headerRowIdDet);
                        dlgDet.ShowDialog();
                        Guid detailRowId = dlgDet.RowId;

                        if (detailRowId != Guid.Empty)
                            RefreshDetail();
                    }
                    break;
                default:
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                string pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                if (pin != string.Empty)
                {
                    MessageBox.Show("Tidak bisa diedit. Sudah diisi PIN.");
                    return;
                }
            }

            switch (selectedGrid)
            {
                case GridSelection.Header:
                    if (dgvHeader.SelectedCells.Count > 0)
                    {
                        Guid headerRowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        frmBiayaOperasionalEdit dlg = new frmBiayaOperasionalEdit(headerRowId);
                        dlg.ShowDialog();

                        cmdSearch_Click(sender, e);
                        dgvHeader.FindRow("HeaderRowID", headerRowId.ToString());
                    }
                    break;
                case GridSelection.Detail:
                    if (dgvDetail.SelectedCells.Count > 0)
                    {
                        double RpBiayaAcc = double.Parse(Tools.isNull(dgvDetail.SelectedCells[0].OwningRow.Cells["RpBiayaAcc"].Value, 0).ToString());

                        if (RpBiayaAcc != 0)
                        {
                            MessageBox.Show("Tidak bisa diedit. Sudah diisi Rp Biaya Acc 00");
                            return;
                        }

                        Guid headerRowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Guid detailRowId = (Guid)dgvDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        DateTime Tanggal = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
                        string NoPerkiraan = dgvDetail.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                        string Uraian = dgvDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                        frmBiayaOperasionalDetailEdit dlg = new frmBiayaOperasionalDetailEdit(detailRowId, Tanggal, NoPerkiraan, Uraian);
                        dlg.ShowDialog();

                        cmdSearch_Click(sender, e);
                        dgvHeader.FindRow("HeaderRowID", headerRowId.ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                Guid headerRowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                string pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                if (pin != string.Empty)
                {
                    MessageBox.Show("Tidak bisa dihapus. Sudah diisi PIN.");
                    return;
                }

                if (MessageBox.Show(Messages.Question.AskDelete, "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    switch (selectedGrid)
                    {
                        case GridSelection.Header:
                            if (dgvDetail.Rows.Count > 0)
                            {
                                MessageBox.Show("Tidak bisa dihapus. Masih mempunyai detail.");
                                return;
                            }

                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowId));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                cmdSearch_Click(sender, e);
                            }
                            catch (Exception ex) { Error.LogError(ex); }
                            finally { Cursor.Current = Cursors.Default; }

                            break;
                        case GridSelection.Detail:
                            if (dgvDetail.SelectedCells.Count > 0)
                            {
                                if (double.Parse(Tools.isNull(dgvDetail.SelectedCells[0].OwningRow.Cells["SisaBudget"].Value, 0).ToString()) < 0
                                    && (bool)dgvDetail.SelectedCells[0].OwningRow.Cells["SyncFlag2"].Value)
                                {
                                    MessageBox.Show("Tidak bisa hapus record karena sedang diproses pengajuan 11 atau sudah di acc 11\nHubungi Manager anda");
                                    return;
                                }

                                Guid detailRowId = (Guid)dgvDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;

                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    using (Database db = new Database(GlobalVar.DBName))
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_DELETE"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, detailRowId));
                                        db.Commands[0].ExecuteNonQuery();
                                    }

                                    RefreshDetail();
                                }
                                catch (Exception ex) { Error.LogError(ex); }
                                finally { Cursor.Current = Cursors.Default; }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private string GetPin(Guid headerRowId)
        {
            string validPin = string.Empty;

            string publicKey = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PublicKey"].Value, string.Empty).ToString();

            pin.frmPinVerification dlg = new pin.frmPinVerification(publicKey, "PIN Biaya Operasional");
            dlg.ShowDialog();

            if (dlg.IsValid)
            {
                validPin = dlg.ValidPin;

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowId));
                        db.Commands[0].Parameters.Add(new Parameter("@PIN", SqlDbType.VarChar, validPin));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    validPin = string.Empty;

                    Error.LogError(ex);
                }
                finally { Cursor.Current = Cursors.Default; }
            }

            return validPin;
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            int n = 0;
            for (n = 0; n < dgvDetail.RowCount; n++)
            {
                if (double.Parse(Tools.isNull(dgvDetail.Rows[n].Cells["SisaBudget"].Value, 0).ToString()) < 0 &&
                    Tools.isNull(dgvDetail.Rows[n].Cells["Keterangan11"].Value, "").ToString() == "")
                {
                    MessageBox.Show("Tidak bisa proses isi PIN. Ada record yang nilai Rp. Biaya ACC00 dengan PSHO beda");
                    return;
                }
            }

            if (dgvHeader.SelectedCells.Count > 0)
            {
                Guid headerRowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

                string validPin = GetPin(headerRowID);

                if (validPin != string.Empty)
                {
                    cmdSearch_Click(sender, e);
                    dgvHeader.FindRow("HeaderRowID", headerRowID.ToString());
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataTable ValidateFile(string fileName, DataTable table)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    table = Foxpro.ReadFile(fileName);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }

        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }



        private void ProcessTable(DataSet ds)
        {
            pbDownload.Maximum = ds.Tables.Count * 2;
            counter = 0;
            pbDownload.Value = 0;
            lblProgress.Text = "DELETING DATA ...";
            for (int i = ds.Tables.Count - 1; i >= 0; i--)
            {
                counter++;
                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                ds.Tables[i].DefaultView.RowFilter = "METHOD='DELETE'";
                ImportData(ds.Tables[i]);
                pbDownload.Value = counter;
                //lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }

            lblProgress.Text = "UPDATING DATA ...";
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                dt.DefaultView.RowFilter = "METHOD='UPDATE'";
                ImportData(dt);
                pbDownload.Value = counter;
                //lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
            pbDownload.Value = pbDownload.Maximum;
        }


        private void ImportData(DataTable dt)
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_DOWNLOAD_DIRECTOR_KASIR_ISA"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));

                            lblDownload.Text = dr["TableName"].ToString();
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }

            }
        }

        private void RefreshHeader()
        {
            txtTotalH1.Text = 0.ToString("#,##0");
            txtTotalHAcc1.Text = 0.ToString("#,##0");
            DateTime fromDate = (DateTime)rdbTanggal.FromDate;
            DateTime toDate = (DateTime)rdbTanggal.ToDate;

            DataTable dt = new DataTable();

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, toDate));
                dt = db.Commands[0].ExecuteDataTable();
            }

            dgvHeader.DataSource = dt;
            if (dgvHeader.RowCount > 0)
            {
                int a = 0;
                int total = 0;
                int totalacc = 0;
                for (a = 0; a < dgvHeader.RowCount; a++)
                {
                    total = total + Convert.ToInt32(Tools.isNull(dgvHeader.Rows[a].Cells["TotalBiaya"].Value, "0"));
                    totalacc = totalacc + Convert.ToInt32(Tools.isNull(dgvHeader.Rows[a].Cells["TotalBiayaACC"].Value, "0"));
                }
                txtTotalH1.Text = total.ToString("#,##0");
                txtTotalHAcc1.Text = totalacc.ToString("#,##0");
            }
            RefreshDetail();
        }

        private void RefreshDetail()
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                Guid headerRowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

                txtTotalDAcc1.Text = 0.ToString("#,##0");
                txtTotalD.Text = 0.ToString("#,##0");
                DataTable dt = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BiayaOperasionalRowID", SqlDbType.UniqueIdentifier, headerRowId));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dgvDetail.DataSource = dt;

                if (dgvDetail.RowCount > 0)
                {
                    int a = 0;
                    int total = 0;
                    int totalacc = 0;
                    for (a = 0; a < dgvDetail.RowCount; a++)
                    {
                        total = total + Convert.ToInt32(Tools.isNull(dgvDetail.Rows[a].Cells["RpBiaya"].Value, "0"));
                        totalacc = totalacc + Convert.ToInt32(Tools.isNull(dgvDetail.Rows[a].Cells["RpBiayaAcc"].Value, "0"));
                    }

                    txtTotalDAcc1.Text = totalacc.ToString("#,##0");
                    txtTotalD.Text = total.ToString("#,##0");
                }
            }
            else
            {
                dgvDetail.DataSource = null;
                txtTotalDAcc1.Text = 0.ToString("#,##0");
                txtTotalD.Text = 0.ToString("#,##0");
            }
        }

        private void cmdHapusPin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                Guid headerRowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                int link = int.Parse(Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["Link"].Value, string.Empty).ToString());
                string pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                if (pin == string.Empty)
                {
                    MessageBox.Show("Belum diisi PIN.");
                    return;
                }

                if (link == 1)
                {
                    MessageBox.Show("Biaya Operasional sudah di-link. PIN tidak bisa dihapus.");
                    return;
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PIN", SqlDbType.VarChar, string.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                cmdSearch_Click(sender, e);

                dgvHeader.FindRow("HeaderRowID", headerRowID.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void GenerateExcell(DataSet ds)
        {
            
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "AJUAN PIN BIAYA OPRASIONAL";

                #region sheet1
                p.Workbook.Worksheets.Add("Ajuan Pin Biaya Operasional");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[1];

                DataTable dt1a = new DataTable();
                //DataTable dt1b = new DataTable();
                dt1a = ds.Tables[0].Copy();
                //dt1b = ds.Tables[1].Copy();
                DateTime fromDate = (DateTime)rdbTanggal.FromDate.Value.Date;
                DateTime toDate = (DateTime)rdbTanggal.ToDate.Value.Date;

                ws1.Name = "Sheet1"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";

                string Title = "Ajuan Pin Biaya Operasional";
                string periode = "PERIODE : " + fromDate.Date.ToString("dd-MM-yyyy") + " s/d "+ toDate.Date.ToString("dd-MM-yyyy");

                ws1.Cells[1, 1].Value = Title;
                ws1.Cells[1, 1].Style.Font.Size = 16;
                ws1.Cells[2, 1].Value = periode;
                ws1.Cells[3, 1].Value = "KODE CABANG : " + GlobalVar.Gudang;
                ws1.Cells[4, 1].Value = "TGL PROSES : " + GlobalVar.DateOfServer.Date.ToString("dd-MM-yyyy");
                ws1.Cells[2, 1, 4, 1].Style.Font.Size = 12;

                ws1.Cells[6, 1].Worksheet.Column(1).Width = 12;
                ws1.Cells[6, 2].Worksheet.Column(2).Width = 20;
                ws1.Cells[6, 3].Worksheet.Column(3).Width = 15;
                ws1.Cells[6, 4].Worksheet.Column(4).Width = 30;
                ws1.Cells[6, 5].Worksheet.Column(5).Width = 40;
                ws1.Cells[6, 6].Worksheet.Column(6).Width = 30;
                ws1.Cells[6, 7].Worksheet.Column(7).Width = 15;
                ws1.Cells[6, 8].Worksheet.Column(8).Width = 12;

                //for (int x = 4; x <= toDate.Day + 1; x++)
                //{
                //    ws1.Cells[6, x].Worksheet.Column(x).Width = 12;
                //}


                int startH = 6;
                int MaxC = 9;

                #region Generate Header table 1

                ws1.Cells[startH, 1].Value = "POS";
                ws1.Cells[startH, 1].Merge = true;
                ws1.Cells[startH, 2].Value = "Tanggal";
                ws1.Cells[startH, 2].Merge = true;
                ws1.Cells[startH, 3].Value = "Nomer";
                ws1.Cells[startH, 3].Merge = true;
                ws1.Cells[startH, 4].Value = "Nama";
                ws1.Cells[startH, 4].Merge = true;
                ws1.Cells[startH, 5].Value = "Keperluan";
                ws1.Cells[startH, 5].Merge = true;
                ws1.Cells[startH, 6].Value = "Total Biaya";
                ws1.Cells[startH, 6].Merge = true;
                ws1.Cells[startH, 7].Value = "Public Key";
                ws1.Cells[startH, 7].Merge = true;
                ws1.Cells[startH, 8].Value = "PIN";
                ws1.Cells[startH, 8].Merge = true;
                ws1.Cells[startH, 9].Value = "Kode Gudang";
                ws1.Cells[startH, 9].Merge = true;

                //int xx = 1;
                //for (xx = 1; xx <= hari; xx++)
                //{
                //    ws1.Cells[startH + 1, xx + 3].Value = xx.ToString();
                //}
                //ws1.Cells[startH, hari + 4].Value = "Total";
                //ws1.Cells[startH, hari + 4, startH + 1, hari + 4].Merge = true;

                //ws1.Cells[startH, hari + 5].Value = "Saldo Akhir";
                //ws1.Cells[startH, hari + 5, startH + 1, hari + 5].Merge = true;
                #endregion

                #region FillData table 1
                int idx = 6 + 1;

                foreach (DataRow dr in dt1a.Rows)
                {
                    //ws1.Cells[idx, 1].Value = Tools.isNull(dr["QtyAwal"], 0);
                    ws1.Cells[idx, 1].Value = dr["POS"];
                    ws1.Cells[idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 2].Value = dr["Tanggal"];
                    ws1.Cells[idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 2].Style.Numberformat.Format = "dd-MM-yyyy";
                    ws1.Cells[idx, 3].Value = dr["Nomor"];
                    ws1.Cells[idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 4].Value = dr["Nama"];
                    ws1.Cells[idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 5].Value = dr["Keperluan"];
                    ws1.Cells[idx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 6].Value = dr["TotalBiaya"];
                    ws1.Cells[idx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 7].Value = dr["PublicKey"];
                    ws1.Cells[idx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 8].Value = dr["PIN"];
                    ws1.Cells[idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws1.Cells[idx, 9].Value = dr["KodeGudang"];
                    ws1.Cells[idx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    idx++;


                    //    Formula =
                    //"=Sum(" + ws1.Cells[startH+2, 4].Address +
                    //":" + ws1.Cells[startH+2, hari].Address + ")";
                }
                #endregion
                int btsTbl1 = idx - 1;
                #region Summary & Formatting

                ws1.Cells[1, 1, 1, MaxC].Merge = true;
                ws1.Cells[2, 1, 2, MaxC].Merge = true;
                ws1.Cells[3, 1, 3, MaxC].Merge = true;
                ws1.Cells[4, 1, 4, MaxC].Merge = true;

                //ws1.Cells[1, 1, 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws1.Cells[1, 1, 4, MaxC].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws1.Cells[1, 1, 4, MaxC].Style.Font.Bold = true;


                ws1.Cells[startH, 1, startH, MaxC].Style.Font.Bold = true;
                ws1.Cells[startH, 1, startH, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Font.Bold = true;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws1.Cells[startH, 1, startH, MaxC].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[startH, 1, startH, MaxC].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws1.Cells[btsTbl1 + 3, 1, btsTbl1 + 4, MaxC].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);

                var border = ws1.Cells[6, 1, btsTbl1, MaxC].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;

                //var border1b = ws1.Cells[btsTbl1 + 3, 1, idx, MaxC].Style.Border;
                //border1b.Bottom.Style =
                //border1b.Top.Style =
                //border1b.Left.Style =
                //border1b.Right.Style = ExcelBorderStyle.Thin;

                //ws1.Cells[startH, 1, btsTbl1, 1].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[startH, 3, btsTbl1, MaxC].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 1, idx - 1, 1].Style.Numberformat.Format = "#,###,###";
                //ws1.Cells[btsTbl1 + 5, 3, idx - 1, MaxC].Style.Numberformat.Format = "#,###,###";

                #endregion

                #endregion
                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "AJUAN PIN BIAYA OPRASIONAL " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

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

        private void cmdLinkBKK_Click(object sender, EventArgs e)
        {
            if (dgvHeader.Rows.Count > 0)
            {
                try
                {
                    Guid headerRowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                    int link = int.Parse(Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["Link"].Value, string.Empty).ToString());
                    string pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                    string Nama = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value, string.Empty).ToString();

                    if (pin == string.Empty || pin == "")
                    {
                        try
                        {
                            DateTime fromDate = (DateTime)rdbTanggal.FromDate;
                            DateTime toDate = (DateTime)rdbTanggal.ToDate;
                            DataSet ds = new DataSet();
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, toDate));
                                ds = db.Commands[0].ExecuteDataSet();
                            }
                            GenerateExcell(ds);
                            MessageBox.Show("Belum Isi PIN");
                            return;
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }

                    if (link == 1)
                    {
                        MessageBox.Show("Biaya Operasional sudah di-link..");
                        return;
                    }

                    string _recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    string src = "OUT";


                    _recordID = BKK.GetRecordIDBukti(_recordID, src);

                    DateTime _Tanggal = GlobalVar.DateOfServer.Date;
                    Guid _rowID = Guid.NewGuid();
                    string _noBukti = Numerator.BookNumerator("BKK", _Tanggal);
                    string _recordIDDetail; Guid _rowIDDetail;
                    string noACC = "";
                    string _uraianDetail = "";
                    string _noperkiraan = "";
                    double _rpbiaya = 0;
                    double _rpSisaBudget = 0;
                    //string _attachment = "";

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        //db.BeginTransaction();
                        BKK.AddHeader(db, _rowID, _rowID, _recordID, _noBukti, "", src, _Tanggal, Nama, "", "", SecurityManager.UserName, "", "");

                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            _rpSisaBudget = double.Parse(Tools.isNull(row.Cells["SisaBudget"].Value, "0").ToString());
                            _rpbiaya = double.Parse(Tools.isNull(row.Cells["RpBiayaAcc"].Value, "0").ToString());

                            if (_rpSisaBudget < 0)
                            {
                                _rpbiaya = double.Parse(Tools.isNull(row.Cells["RpBiayaACC11"].Value, "0").ToString());
                            }

                            _noperkiraan = Tools.isNull(row.Cells["NoPerkiraan"].Value, string.Empty).ToString();
                            _uraianDetail = Tools.isNull(row.Cells["Keterangan"].Value, string.Empty).ToString();

                            _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                            _rowIDDetail = Guid.NewGuid();

                            if (_rpbiaya > 0)
                                BKK.AddDetail(db, _rowIDDetail, _rowID, _recordIDDetail, _recordID, "", "", "", noACC, _noperkiraan, _uraianDetail, _rpbiaya.ToString());

                        }
                        //db.CommitTransaction();

                    }


                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Link", SqlDbType.Int, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show("Link data Biaya operasional ke BKK berhasil. Silahkan cek BKK no. " + _noBukti + " tanggal " + _Tanggal.ToString("dd-MM-yyyy"));

                    cmdSearch_Click(sender, e);

                    dgvHeader.FindRow("HeaderRowID", headerRowID.ToString());
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdUPLOAD_Click(object sender, EventArgs e)
        {
            frmBiayaOperasionalUpload dlg = new frmBiayaOperasionalUpload();
            dlg.ShowDialog();
        }

        private void cmdDOWNLOAD_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Download;
            SetEnable();
        }

        private void SetEnable()
        {
            panelDownload.Visible = Modus == enumModus.Download;
            cmdUPLOAD.Enabled = Modus == enumModus.Clear;
            cmdDOWNLOAD.Enabled = Modus == enumModus.Clear;
        }

        private void cmdDownloadClose_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetEnable();
        }

        private void cmdDownloadGo_Click(object sender, EventArgs e)
        {
            string _paths = string.Empty;
            string PilData = _Data;

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\TEMP\\FTP\\DOWNLOAD";   //GlobalVar.DbfDownload;
            openFileDialog1.Filter = "xml files (*.xml)|*" + PilData + "*.xml";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _paths = openFileDialog1.FileName;

                    if (MessageBox.Show("Download Data ini " + openFileDialog1.FileNames[0].ToString() + " ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //lblStatus.Text = "Download file from FTP ...";                                                
                        DataSet ds = ReadData(_paths);

                        //lblStatus.Text = "Upload data to ISA ....";
                        refreshForm();
                        ProcessTable(ds);

                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                        //RefreshBudget();


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
                Modus = enumModus.Clear;
                SetEnable();
                RefreshDetail();
                RefreshHeader();
            }



        }
    }
}
