using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Finance.DKNForm
{
    public partial class frmDebetKreditNotaBrowse : ISA.Finance.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        string LastClosingGL;
        string _pinKey;
        DataTable dtPengajuanKN;

        public frmDebetKreditNotaBrowse()
        {
            InitializeComponent();
        }

        private void frmDebetKreditNotaBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            gridUtm.AutoGenerateColumns = false;
            gridDetail.AutoGenerateColumns = false;
            LastClosingGL = PeriodeClosing.LastClosingGL;
            RefreshDkn();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDkn();
        }

        public void RefreshDkn()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_DKN_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    gridUtm.DataSource = dtHeader;

                    if (gridUtm.SelectedCells.Count > 0)
                    {
                        RefreshDknDetail();
                    }
                    else
                    {
                        gridDetail.DataSource = null;
                    }
                }
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



        public void RefreshDknDetail()
        {
            try
            {
                Guid _rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKNDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    gridDetail.DataSource = dtDetail;
                }
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

        private void gridUtm_SelectionChanged(object sender, EventArgs e)
        {

            if (gridUtm.SelectedCells.Count > 0)
            {
                if (gridUtm.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshDknDetail();
                }
                prevGrid1Row = gridUtm.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                gridDetail.DataSource = null;
            }
        }

        private void gridUtm_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void gridUtm_Validated(object sender, EventArgs e)
        {
            if (gridUtm.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            string _recordID = gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            DKNForm.frmDebetKreditNotaCetak ifrmChild = new DKNForm.frmDebetKreditNotaCetak(this, _recordID);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void CetakNota()
        {


        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["LinkID"].Value, "").ToString() == "1" &&
            //    Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["Pin"].Value, "").ToString() == "1")
            //{
            //    MessageBox.Show("Sudah Link ke Kasir.");
            //    return;
            //}
 
            if (gridUtm.SelectedCells.Count > 0 && gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString() != GlobalVar.Gudang &&
                gridUtm.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() == "DKN")
            {
                DateTime TglTrans = Convert.ToDateTime(gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                string TahunBulan = TglTrans.Year.ToString() + TglTrans.Month.ToString().PadLeft(2, '0');

                string RecID = gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                string RecIDDetail = gridDetail.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();

                Guid HeaderID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["HeaderID"].Value;
                Guid DetailID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                frmDKNupdate ifrm = new frmDKNupdate(this, HeaderID, DetailID, RecID, RecIDDetail);
                ifrm.Show();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmDKNupdate ifrm = new frmDKNupdate(this);
            ifrm.Show();
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["LinkID"].Value, "").ToString() == "1" &&
                Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["Pin"].Value, "").ToString() == "1")
            {
                MessageBox.Show("Sudah Link ke Kasir.");
                return;
            }

            if (((selectedGrid == enumSelectedGrid.HeaderSelected && gridUtm.SelectedCells.Count > 0) ||
                 (selectedGrid == enumSelectedGrid.DetailSelected && gridDetail.SelectedCells.Count > 0)) &&
                 (gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString() != GlobalVar.Gudang && gridUtm.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() == "DKN"))
            {
                DateTime Tanggal = DateTime.Parse(gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value.ToString());

                if (Tanggal > DateTime.Today.AddDays(DateTime.Today.Day * -1))
                {
                    if (MessageBox.Show("Anda yakin?", "Hapus data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (selectedGrid == enumSelectedGrid.HeaderSelected)
                        {
                            Guid HeaderID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_DKN_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            RefreshDkn();
                        }
                        else
                        {
                            Guid DetailID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_DKNDetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DetailID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            RefreshDknDetail();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tidak boleh Input mundur.");
                    return;
                }
            }
        }

        private void gridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void gridUtm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (gridUtm.SelectedCells.Count > 0 && gridDetail.SelectedCells.Count > 0)
            {
                //if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["LinkID"].Value, "").ToString() == "1" &&
                //    Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["Pin"].Value, "").ToString() == "1")
                //{
                //    MessageBox.Show("Sudah Link ke Kasir.");
                //    return;
                //}

                Guid _rowID = new Guid(Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());
                Guid _rowIDdetail = new Guid(Tools.isNull(gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value, Guid.Empty).ToString());

                //if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value, "").ToString() == "")
                //{
                //    if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["Pin"].Value, "").ToString() != "1")
                //    {
                //        MessageBox.Show("Nomor KN masih Kosong." + "\n" + "Silahkan Pengajuan PIN dan Nomor KN ke HO.");
                //        _pinKey = GetKey(_rowID.ToString(), GlobalVar.Gudang, 31);
                //        PengajuanPinKN(_rowID, _pinKey);
                //        pin.frmPinMd5 ifrmpin = new pin.frmPinMd5(this, _rowID, GlobalVar.Gudang, 31, "Pengajuan Pin dan Nomor KN.");
                //        ifrmpin.ShowDialog();
                //        if (ifrmpin.DialogResult == DialogResult.OK)
                //        {
                //            UpdateFlagPinKN(_rowID, _rowIDdetail);
                //            cmdSearch.PerformClick();
                //            FindHeader("RowID", _rowID.ToString());
                //            FindDetail("RowIDD", _rowIDdetail.ToString());
                //        }
                //        else
                //        {
                //            this.DialogResult = DialogResult.No;
                //            return;
                //        }
                //    }
                //}

                //if (Tools.isNull(gridUtm.SelectedCells[0].OwningRow.Cells["Pin"].Value, "").ToString() == "1")
                //{
                    DateTime TglTrans = Convert.ToDateTime(gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                    string TahunBulan = TglTrans.Year.ToString() + TglTrans.Month.ToString().PadLeft(2, '0');
                    string IsiPin = "1";

                    string RecID = gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                    string RecIDDetail = gridDetail.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();

                    Guid HeaderID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["HeaderID"].Value;
                    Guid DetailID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;

                    frmDKNupdate ifrm = new frmDKNupdate(this, HeaderID, DetailID, RecID, RecIDDetail, IsiPin, _pinKey);
                    ifrm.Show();
                    if (ifrm.DialogResult == DialogResult.OK)
                    {
                        UpdateFlagLinkID(_rowID, _rowIDdetail);
                        cmdSearch.PerformClick();
                        FindHeader("RowID", _rowID.ToString());
                        FindDetail("RowIDD", _rowIDdetail.ToString());
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        return;
                    }
                //}
            }
        }

        public void UpdateFlagPinKN(Guid rowid, Guid rowidd)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKN_PIN_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    db.Commands[0].Parameters.Add(new Parameter("@FPin", SqlDbType.VarChar, "1"));
                    db.Commands[0].ExecuteNonQuery();
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

        public void UpdateFlagLinkID(Guid rowid, Guid rowidd)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKN_LinkID_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    db.Commands[0].Parameters.Add(new Parameter("@FLink", SqlDbType.VarChar, "1"));
                    db.Commands[0].ExecuteNonQuery();
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

        private void PengajuanPinKN(Guid rowid, string pinKey)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKNDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtPengajuanKN = db.Commands[0].ExecuteDataTable();
                    if (dtPengajuanKN.Rows.Count > 0)
                    {
                        DisplayReportToExcell(dtPengajuanKN, pinKey);
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

        private void DisplayReportToExcell(DataTable dtPengajuanKN, string pinkey)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(AjuanPinKN(dtPengajuanKN, pinkey));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "PengajuanPinKN";

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

        private ExcelPackage AjuanPinKN(DataTable dtPengajuanKN, string pinkey)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Penajuan Pin KN";
            ex.Workbook.Properties.SetCustomPropertyValue("PIN KN", "1147");

            ex.Workbook.Worksheets.Add("PIN KN");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 20;      //nodkn
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tgldkn
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;      //bankasal
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;      //bankasal
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //banktujuan
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //nominal
            ws.Cells[1, 9].Worksheet.Column(9).Width = 35;      //namatoko
            ws.Cells[1, 10].Worksheet.Column(10).Width = 50;    //alamat
            ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //kota
            ws.Cells[1, 12].Worksheet.Column(12).Width = 10;    //idwil
            ws.Cells[1, 13].Worksheet.Column(13).Width = 40;    //public key
            ws.Cells[1, 14].Worksheet.Column(14).Width = 40;    //pin
            ws.Cells[1, 15].Worksheet.Column(15).Width = 20;    //Collector

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Pengajuan Pin dan Nomor KN";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

            int MaxCol = 15;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nomor KN ";
            ws.Cells[Rowx, 4].Value = " Tanggal ";
            ws.Cells[Rowx, 5].Value = " Bank Asal ";
            ws.Cells[Rowx, 6].Value = " Lokasi ";
            ws.Cells[Rowx, 7].Value = " Bank Tujuan ";
            ws.Cells[Rowx, 8].Value = " Nominal ";
            ws.Cells[Rowx, 9].Value = " Nama Toko ";
            ws.Cells[Rowx, 10].Value = " Alamat ";
            ws.Cells[Rowx, 11].Value = " Kota ";
            ws.Cells[Rowx, 12].Value = " Idwil ";
            ws.Cells[Rowx, 13].Value = " Public Key ";
            ws.Cells[Rowx, 14].Value = " Pin ";
            ws.Cells[Rowx, 15].Value = " Collector ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nJumlah = 0;

            if (dtPengajuanKN.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtPengajuanKN.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = dr1["NoDKN"].ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["Tanggal"]);
                    ws.Cells[Rowx, 5].Value = dr1["NamaBank"].ToString();
                    ws.Cells[Rowx, 6].Value = dr1["Lokasi"].ToString();
                    ws.Cells[Rowx, 7].Value = dr1["NamaBankTujuan"].ToString();
                    ws.Cells[Rowx, 8].Value = double.Parse(Tools.isNull(dr1["Jumlah"], 0).ToString());
                    ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 9].Value = dr1["NamaToko"].ToString();
                    ws.Cells[Rowx, 10].Value = dr1["Alamat"].ToString();
                    ws.Cells[Rowx, 11].Value = dr1["Kota"].ToString();
                    ws.Cells[Rowx, 12].Value = dr1["Idwil"].ToString();
                    ws.Cells[Rowx, 13].Value = pinkey.ToString();
                    ws.Cells[Rowx, 15].Value = dr1["Nama"].ToString();
                    nJumlah += double.Parse(Tools.isNull(dr1["Jumlah"], 0).ToString());
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 7].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 8].Value = Tools.isNull(nJumlah, 0);
                ws.Cells[Rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 8].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            return ex;
        }

        private string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            string x = kodeGudang.ToString().Trim().Substring(2, 2) + noAjuan.ToString().Trim().PadLeft(2, '0') +
                       rowID.Replace("-", string.Empty).ToUpper();
            return x;
        }

        public void FindHeader(string columnName, string value)
        {
            gridUtm.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            gridDetail.FindRow(columnName, value);
        }

        private void gridUtm_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int rowIndex = 0; rowIndex < gridUtm.Rows.Count; rowIndex++)
            //{
            //    if (gridUtm.Rows[rowIndex].Cells["Pin"].Value.ToString() == "")
            //    {
            //        gridUtm.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            //    }
            //    else if (gridUtm.Rows[rowIndex].Cells["LinkID"].Value.ToString() == "")
            //    {
            //        gridUtm.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Cyan;
            //    }
            //    else
            //    {
            //        gridUtm.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
            //    }
            //}
        }
    }

}

