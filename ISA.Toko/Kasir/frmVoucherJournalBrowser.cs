using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherJournalBrowser : ISA.Controls.BaseForm
    {
        bool dataLoaded = false;
        DataTable dtHeader, dtDetail;
        DataTable dt;
        string PrnAktif = "0";

        public frmVoucherJournalBrowser()
        {
            InitializeComponent();
        }

        private void SetInitialValues()
        {
            //rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //rangeDateBox1.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );

            rangeDateBox1.FromDate = DateTime.Today;
            rangeDateBox1.ToDate = DateTime.Today;
            cboTipe.Text = cboTipe.Items[0].ToString();
        }

        private void frmVoucherJournalBrowser_Load(object sender, EventArgs e)
        {

        }
        public void RefreshHeader()
        {
            string tipe = "";
            DataTable dt1 = new DataTable(), dt2 = new DataTable(), dt3 = new DataTable();
            if (dataLoaded)
            {
                if (cboTipe.Text == "ALL")
                    tipe = "";
                else if (cboTipe.Text == "Penerimaan Giro")
                    tipe = "PG";
                else if (cboTipe.Text == "Titipan Giro")
                    tipe = "TT";
                else if (cboTipe.Text == "Uang Muka Sementara")
                    tipe = "UM";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        if (tipe == "PG")
                        {
                            dt1 = VoucherJournal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, "PG");
                            dt2 = VoucherJournal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, "CC");
                            dt3 = VoucherJournal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, "DB");

                            dtHeader = dt1;
                            dtHeader.Merge(dt2);
                            dtHeader.Merge(dt3);
                        }
                        else
                        {
                            dtHeader = VoucherJournal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, tipe);
                        }
                    }

                    gridHeader.DataSource = dtHeader.DefaultView;
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
        public void RefreshRowHeader(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();


            dtRefresh = VoucherJournal.ListRowHeader(RowID);
            gridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID.ToString());


        }
        public void RefreshDetail()
        {

            if (dataLoaded)
            {
                if (gridHeader.SelectedCells.Count > 0)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Guid headerID;
                        headerID = new Guid(gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value.ToString());
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_VoucherJournalDetail_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                            dtDetail = db.Commands[0].ExecuteDataTable();
                        }
                        gridDetail.DataSource = dtDetail.DefaultView;
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
        }

        public void FindRowDetail(string column, string value)
        {
            gridDetail.FindRow(column, value);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDetail();
        }

        private void gridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                string tp = gridHeader.SelectedCells[0].OwningRow.Cells["hdrTipe"].Value.ToString().Trim();
                if (tp == "UM")
                    cmdPrint.Enabled = true;
                else
                    cmdPrint.Enabled = false;
                RefreshDetail();
            }
        }

        private void frmVoucherJournalBrowser_Shown(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (!dataLoaded)
                {
                    SetInitialValues();
                    dataLoaded = true;
                    RefreshHeader();
                    RefreshDetail();

                }
            }
        }

        private void cboTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BKM"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    PrnAktif = "0";
                else
                    PrnAktif = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (PrnAktif == "0")
                cetakLaporan();
            else
                DisplayReport(dt);
        }
        private void DisplayReport(DataTable dt)
        {
            string UserID = SecurityManager.UserName.ToString();
            int i = 0;
            int nprint = int.Parse(gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value.ToString());
            if ((nprint > 0) && (!SecurityManager.IsManager()))
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }

            double total = 0, jumlah;
            string _Kepada, _NoBukti, _Tanggal, _Kasir, _Terbilang;
            Guid _rowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;

            string _uraian = gridHeader.SelectedCells[0].OwningRow.Cells["hdrUraian"].Value.ToString().Trim();
            string _dari = gridHeader.SelectedCells[0].OwningRow.Cells["hdrUraian2"].Value.ToString().Split('|').GetValue(0).ToString().Trim();
            _Kepada = gridHeader.SelectedCells[0].OwningRow.Cells["KetBon"].Value.ToString().Trim();
            _Kasir = gridHeader.SelectedCells[0].OwningRow.Cells["hdrDibuat"].Value.ToString();
            _NoBukti = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
            _Tanggal = Convert.ToDateTime(gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value).ToString("dd/MM/yyyy");




            foreach (DataRow dr in dtDetail.Rows)
            {
                total += Convert.ToDouble(dr["Jumlah"].ToString());
            }
            _Terbilang = Tools.Terbilang(total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", UserID));
            //rptParams.Add(new ReportParameter("Terima", _Terima));
            //rptParams.Add(new ReportParameter("NoBukti", _NoBukti));
            //rptParams.Add(new ReportParameter("Tanggal", _Tanggal));
            //rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
            //rptParams.Add(new ReportParameter("Total", total.ToString()));

            //frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptCetakBKMbaru.rdlc", rptParams, dtBKMDetail, "dsBukti_Data");
            //ifrmReport.Print();
            ////ifrmReport.Print(8.5, 6.4);
            ////ifrmReport.Show();

        }
        #region cetak laporan
        public void cetakLaporan()
        {
            int nprint = int.Parse(gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value.ToString());
            if ((nprint > 0) && (!SecurityManager.IsManager()))
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }

            double total = 0, jumlah;
            string _Kepada, _NoBukti, _Tanggal, _Kasir;
            Guid _rowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;

            string _uraian = gridHeader.SelectedCells[0].OwningRow.Cells["hdrUraian"].Value.ToString().Trim();
            string _dari = gridHeader.SelectedCells[0].OwningRow.Cells["hdrUraian2"].Value.ToString().Split('|').GetValue(0).ToString().Trim();
            _Kepada = gridHeader.SelectedCells[0].OwningRow.Cells["KetBon"].Value.ToString().Trim();
            _Kasir = gridHeader.SelectedCells[0].OwningRow.Cells["hdrDibuat"].Value.ToString();
            _NoBukti = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
            _Tanggal = Convert.ToDateTime(gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value).ToString("dd/MM/yyyy");
            int rowNo = 0;
            int no = 0;

            int ttlData = dtDetail.Rows.Count;
            int hal = 1;
            int ttlHal = 0;
            int prevHal = hal;

            if (ttlData % 10 > 0)
            {
                ttlHal = (ttlData / 10) + 1;
            }
            else
            {
                ttlHal = ttlData / 10;
            }


            try
            {
                BuildString lap = new BuildString();
                //lap.Initialize();
                //lap.PageLLine(33);
                //lap.LeftMargin(3);

                //lap.FontCPI(10);
                //lap.DoubleWidth(true);
                //lap.PROW(true, 1, "[BUKTI KAS KELUAR]");
                //lap.DoubleWidth(false);
                //lap.FontCondensed(true);

                //lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(63) + lap.PrintTTOp()
                //    + lap.PrintHorizontalLine(64) + lap.PrintTopRightCorner());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + "Kepada  : ".PadRight(63) +
                //    lap.PrintVerticalLine() + "Nomor   : " + _NoBukti.PadRight(54) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(63) + lap.PrintVerticalLine() + "Tanggal : " +
                //    _Tanggal.PadRight(30) + "Hal    :  " + hal.ToString() + "/" + ttlHal.ToString().PadRight(12) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(63) + lap.PrintTBottom()
                //    + lap.PrintHorizontalLine(64) + lap.PrintTRight());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(15) + lap.PadCenter(98, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(128) + lap.PrintTRight());

                bool cetak = true;

                foreach (DataRow dr in dtDetail.Rows)
                {

                    #region header

                    if (cetak)
                    {
                        lap.Initialize();

                        lap.PageLLine(33);
                        lap.LeftMargin(1);
                        lap.FontCPI(12);
                        lap.LineSpacing("1/6");
                        lap.DoubleWidth(true);
                        lap.PROW(true, 1, "[BUKTI KAS KELUAR]");
                        lap.DoubleWidth(false);

                        //lap.FontCondensed(true);
                        lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                            + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + ("Kepada  : " + _dari.Trim()).PadRight(41) +
                            lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                            _Tanggal).PadRight(30) + ("Hal : " + hal.ToString() + "/" + ttlHal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                    }

                    #endregion


                    jumlah = Convert.ToDouble(dr["Debet"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".PadRight(10) + dr["Keterangan"].ToString().ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    total += Convert.ToDouble(dr["Debet"].ToString());

                    no++;
                    rowNo++;
                    cetak = false;

                    if (hal == ttlHal && 10 - no > 0 && rowNo == ttlData)
                    {
                        for (int j = 0; j < 10 - no; j++)
                        {
                            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                        }
                    }



                    #region footer
                    if (ttlData == rowNo || no == 10)
                    {
                        prevHal = hal;
                        hal++;
                        no = 0;
                        cetak = true;

                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                            total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                            + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                            + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penerima") + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                            + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                            + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                            + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                            + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" +
                            lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                        lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                        lap.Eject();
                    }

                    #endregion


                }

                //UPDATE NPRINT
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    VoucherJournal.UpdateNPrint(db, _rowID, nprint + 1);
                }
                //REFRESH ROW HEADER
                RefreshRowHeader(_rowID);

                lap.SendToPrinter("laporanPS.txt");
                //lap.SendToFile("laporanPS.txt");



            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        private void cmdHI_Click(object sender, EventArgs e)
        {
            string noPerkiraan = gridDetail.SelectedCells[0].OwningRow.Cells["dtlNoPerkiraan"].Value.ToString();
            Guid _rowIDH = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            string tipe = gridHeader.SelectedCells[0].OwningRow.Cells["hdrTipe"].Value.ToString();
            Guid _rowIDD = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["dtlRowID"].Value;
            Double jumlah = Convert.ToDouble(gridDetail.SelectedCells[0].OwningRow.Cells["dtlDebet"].Value.ToString());
            Double jumlahLink = 0;
            Double jumlahSisa = 0;
            string _recordIDH = gridHeader.SelectedCells[0].OwningRow.Cells["hdrRecordID"].Value.ToString();
            string _recordIDD = gridDetail.SelectedCells[0].OwningRow.Cells["dtlRecordID"].Value.ToString();
            string namaSP = "usp_VoucherJournalDetail_Update";
            string _noPerk;
            if (tipe.Trim() != "UM")
                return;

            try
            {
                //CEK PERNAH LINK?
                string _kode = gridDetail.SelectedCells[0].OwningRow.Cells["dtlLKode"].Value.ToString().Trim();
                if (_kode != "") //PERNAH LINK
                {
                    //AMBIL DATA LINK, CEK JUMLAH YG PERNAH D LINK
                    DataTable dtCek = new DataTable();
                    dtCek = DKN.CekLinkDKNDetail(_rowIDD);
                    jumlahLink = Convert.ToDouble(dtCek.Compute("Sum(Jumlah)", ""));
                    // JIKA JUMLAH SUDAH FULL, UNLINK?
                    if (jumlahLink >= jumlah)
                    {
                        if (MessageBox.Show("Sudah di Link Full. \nHapus Link?", "Hapus Link DKN", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            //UNLINK DKN
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.BeginTransaction();
                                DKN.UnlinkDKN(db, _rowIDD);
                                DKN.UpdateKodeLink(db, _rowIDD, "", namaSP, "?");
                                db.CommitTransaction();

                            }
                            MessageBox.Show("Unlink DKN Berhasil.");
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();

                if (noPerkiraan != _noPerk)
                {
                    if (MessageBox.Show("No Perkiraan Bukan No Perkiraan HI.\nUbah No Perkiraan Menjadi No Perkiraan HI?\n" + _noPerk, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_VoucherJournalDetail_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _noPerk));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDD));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        RefreshDetail();
                        FindRowDetail("dtlRowID", _rowIDD.ToString());
                        noPerkiraan = _noPerk;


                    }
                    else
                    {
                        return;
                    }
                }

                DateTime tglBukti = (DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value;
                string noBukti = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
                string uraian = gridDetail.SelectedCells[0].OwningRow.Cells["dtlKeterangan"].Value.ToString();
                jumlahSisa = jumlah - jumlahLink;
                frmBuktiHILink frm = new frmBuktiHILink(this, "D", "VJU", "E", "IND", tglBukti, noBukti, _rowIDH, noPerkiraan, uraian, jumlahSisa, _rowIDD, "usp_VoucherJournalDetail_Update", _recordIDH, _recordIDD);
                frm.ShowDialog();

            }
            catch (SqlException ex)
            {
                Error.LogError(ex);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void gridHeader_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = true;
        }

        private void gridDetail_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = false;
        }





    }
}
