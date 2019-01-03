using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Finance.Class;
using ISA.DAL;
using ISA.Common;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace ISA.Finance.Kasir
{
    public partial class frmBKKBrowse : ISA.Finance.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dtBKK = new DataTable(), dtBKKDetail = new DataTable();
        DataTable dt = new DataTable();
        string PrnAktif = "0";

        public frmBKKBrowse()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmBKKUpdate bkkupdate = new frmBKKUpdate(this);
            bkkupdate.ShowDialog();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BKK"));
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
            double total = 0, jumlah;
            string _Kepada, _NoBukti, _Tanggal, _Lampiran, _Kasir;
            Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _Kepada = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["dari"].Value.ToString();
            _NoBukti = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
            _Lampiran = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Lampiran"].Value.ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}", dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value);
            _Kasir = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Kasir"].Value.ToString();

            foreach (DataRow dr in dtBKKDetail.Rows)
            {
                total += Convert.ToDouble(dr["Jumlah"].ToString());
            }
            string _Terbilang = ISA.Common.Tools.Terbilang(total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("Kepada", _Kepada));
            rptParams.Add(new ReportParameter("NoBukti", _NoBukti));
            rptParams.Add(new ReportParameter("Tanggal", _Tanggal));
            rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
            rptParams.Add(new ReportParameter("Total", total.ToString()));

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptCetakBKKbaru.rdlc", rptParams, dtBKKDetail, "dsBukti_Data");
            ifrmReport.Print();
            ////ifrmReport.Print(8.5, 6.4);
            ////ifrmReport.Show();

        }


        #region cetak laporan
        public void cetakLaporan()
        {
            if ((int.Parse(dgHeaderBKK.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0) && (!SecurityManager.IsManager()))
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }
            int i = 0;
            
            double total = 0, jumlah;
            string _Kepada, _NoBukti, _Tanggal, _Lampiran, _Kasir;            
            Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _Kepada = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["dari"].Value.ToString();
            _NoBukti = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
            _Lampiran = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Lampiran"].Value.ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}",dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value);
            _Kasir = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Kasir"].Value.ToString();
            int rowNo = 0;
            int no = 0;

            int ttlData = dtBKKDetail.Rows.Count;
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
                //lap.LeftMargin(1);
                //lap.FontCPI(12);
                //lap.LineSpacing("1/8");
                //lap.DoubleWidth(true);
                //lap.PROW(true, 1, "[BUKTI KAS KELUAR]");
                //lap.DoubleWidth(false);
                
                ////lap.FontCondensed(true);
                //lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(46) + lap.PrintTTOp()
                //    + lap.PrintHorizontalLine(46) + lap.PrintTopRightCorner());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + "Kepada  : ".PadRight(46) +
                //    lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(46) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(46) + lap.PrintVerticalLine() + ("Tanggal : " +
                //    _Tanggal).PadRight(30) +( "Hal    : " + hal.ToString() +"/" + ttlHal.ToString()).PadRight(16) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(46) + lap.PrintTBottom()
                //    + lap.PrintHorizontalLine(46) + lap.PrintTRight());
                //lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(70, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(93) + lap.PrintTRight());

                bool cetak = true;

                foreach (DataRow dr in dtBKKDetail.Rows)
                {
                    #region header
                    if(cetak)
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
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "Kepada  : ".PadRight(41) +
                            lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                            _Tanggal).PadRight(30) + ("Hal : " + hal.ToString() + "/" + ttlHal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                    }

                    #endregion

                    jumlah = Convert.ToDouble(dr["Jumlah"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".PadRight(10) + dr["Uraian"].ToString().ToUpper().PadRight(58).Substring(0,58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    total += Convert.ToDouble(dr["Jumlah"].ToString());
                    i++;

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
                    if(ttlData == rowNo || no == 10)
                    {
                        prevHal = hal;
                        hal++;
                        no = 0;
                        cetak = true;

                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                            total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + ISA.Common.Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
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
                            + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kepada.Trim()) + ")" +
                            lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                        lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                        lap.Eject();

                    }

                    #endregion
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBukti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                HeaderRowRefresh(_rowID);

                lap.SendToPrinter("laporanPS.txt", lap.GenerateString());
                //lap.SendToFile("laporanPS.txt");
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        private void frmBKKBrowse_Load(object sender, EventArgs e)
        {
            //rdBKM.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //rdBKM.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            rdBKM.FromDate = DateTime.Today;
            rdBKM.ToDate = DateTime.Today;
            HeaderRefresh();
        }

        private void cmdSeacrh_Click(object sender, EventArgs e)
        {
            HeaderRefresh();
        }

        public void HeaderRefresh()
        {
            _fromDate = (DateTime)rdBKM.FromDate;
            _toDate = (DateTime)rdBKM.ToDate;

            try
            {
                //diremarks oleh halim - javasign..
                //membuat/menambahkan kolom lebih baik tidak menggunakan SP

                //Untuk Menambah kolom Attachment apabila kolom tersebut belum ada
                //using (Database db = new Database(GlobalVar.DBName))
                //{
                //    db.Commands.Add(db.CreateCommand("usp_Bukti_ADDCOLUMN"));
                //    db.Commands[0].ExecuteDataTable();
                //}

                this.Cursor = Cursors.WaitCursor;
                dtBKK = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtBKK = BKK.ListHeader(db, _fromDate, _toDate);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);

                if (dtBKK.Rows.Count > 0)
                {
                    dtBKK.DefaultView.Sort = "TglBukti, Pos, NoBukti";
                    dgHeaderBKK.DataSource = dtBKK.DefaultView;
                    DetailRefresh();

                }
                else
                {
                    dtBKKDetail.Clear();
                    dgDetailBKK.DataSource = dtBKKDetail.DefaultView;

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

        public void DetailRefresh()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtBKKDetail = new DataTable();
                Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtBKKDetail = BKK.ListDetail(db, _rowID);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtBKKDetail.DefaultView.Sort = "RecordID";
                dgDetailBKK.DataSource = dtBKKDetail.DefaultView;

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

        public void DetailDeleteRefresh()
        {
            #region "Tambahan"
            int i = 0;
            int n = 0;
            i = dgDetailBKK.SelectedCells[0].RowIndex;
            n = dgDetailBKK.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)dgDetailBKK.SelectedCells[0].OwningRow.DataBoundItem;

            DataRow dr = dv.Row;

            dr.Delete();
            dtBKKDetail.AcceptChanges();
            dgDetailBKK.Focus();
            dgDetailBKK.RefreshEdit();
            if (dgDetailBKK.RowCount > 0)
            {
                if (i == 0)
                {
                    dgDetailBKK.CurrentCell = dgDetailBKK.Rows[0].Cells[n];
                    dgDetailBKK.RefreshEdit();
                }
                else
                {
                    dgDetailBKK.CurrentCell = dgDetailBKK.Rows[i - 1].Cells[n];
                    dgDetailBKK.RefreshEdit();
                }

            }
            #endregion
        }

        public void HeaderRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKK.ListHeaderperRow(RowID);
            dgHeaderBKK.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }

        public void DetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKK.ListDetailperRow(RowID);
            if (dtResult.Rows.Count > 0) dgDetailBKK.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }

        public void FindRowHeader(string column, string value)
        {
            dgHeaderBKK.FindRow(column, value);
        }

        public void FindRowDetail(string column, string value)
        {
            dgDetailBKK.FindRow(column, value);
        }


        private void dgHeaderBKK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHeaderBKK.SelectedCells.Count > 0)
            {
                if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "OUT")
                {
                    cmdDelete.Enabled = false;
                    cmdEdit.Enabled = false;
                    btnAttachment.Enabled = false;
                }
                else
                {
                    cmdDelete.Enabled = true;
                    cmdEdit.Enabled = true;
                    btnAttachment.Enabled = true;
                }

                DetailRefresh();
            }
        }


        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgHeaderBKK.SelectedCells.Count > 0)
            {
                
                if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "OUT")
                    return;

                DateTime _Tanggal = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                if (GlobalVar.Gudang != "2808")
                {
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                }

                if (_Tanggal == DateTime.Today)
                {

                    Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _RecordID, _Terima, _NoBukti, _Lampiran, _AttachmentBKK;
                    _RecordID = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RecordID"].Value;
                    _Terima = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["dari"].Value;
                    _NoBukti = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value;
                    _Lampiran = Convert.ToString(dgHeaderBKK.SelectedCells[0].OwningRow.Cells["lampiran"].Value);
                    //_AttachmentBKK = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["AttachmentBKK"].Value.ToString();
                    _AttachmentBKK = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["AttachmentSource"].Value.ToString();

                    //MessageBox.Show(_AttachmentBKK);
                    frmBKKUpdate BKKUpdate = new frmBKKUpdate(this, _rowID, _RecordID, _Terima, _NoBukti, _Tanggal, _Lampiran, string.Empty, false, string.Empty, _AttachmentBKK);
                    BKKUpdate.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Maaf, edit transaksi hanya boleh untuk transaksi hari ini saja.");
                    return;
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "OUT")
            //    return;

            DateTime _Tanggal = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
            if (GlobalVar.Gudang != "2808")
            {
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
            }
            string ques = "No Bukti : " + dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString() + " Akan Dihapus?";
            if ((dgHeaderBKK.SelectedCells.Count > 0) && (MessageBox.Show(ques, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Bukti_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    
                    #region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = dgHeaderBKK.SelectedCells[0].RowIndex;
                    n = dgHeaderBKK.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgHeaderBKK.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtBKK.AcceptChanges();
                    dgHeaderBKK.Focus();
                    dgHeaderBKK.RefreshEdit();
                    if (dgHeaderBKK.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgHeaderBKK.CurrentCell = dgHeaderBKK.Rows[0].Cells[n];
                            dgHeaderBKK.RefreshEdit();
                        }
                        else
                        {
                            dgHeaderBKK.CurrentCell = dgHeaderBKK.Rows[i - 1].Cells[n];
                            dgHeaderBKK.RefreshEdit();
                        }

                    }
                    #endregion

                    HeaderRefresh();
                    //di remark                    
                    //HeaderRefresh();
                    //DetailRefresh();
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

       
        private void cmdHI_Click(object sender, EventArgs e)
        {
            try
            {
                string noPerkiraan = dgDetailBKK.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
                Guid _rowIDH = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["rowID"].Value;
                Guid _rowIDD = (Guid)dgDetailBKK.SelectedCells[0].OwningRow.Cells["rowIDD"].Value;
                string _recordIDH = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                string _recordIDD = dgDetailBKK.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();
                Double jumlah = Convert.ToDouble(dgDetailBKK.SelectedCells[0].OwningRow.Cells["Jumlah"].Value);
                Double jumlahLink = 0;
                Double jumlahSisa = 0;
                string namaSP = "usp_BuktiDetail_Update";

                //CEK PERNAH LINK?
                string _kode = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString().Trim();
                if (_kode != "") //PERNAH LINK
                {
                    //AMBIL DATA LINK, CEK JUMLAH YG PERNAH D LINK
                    DataTable dtCek = new DataTable();
                    dtCek = DKN.CekLinkDKNDetail(_rowIDD);
                    jumlahLink = Convert.ToDouble(dtCek.Compute("Sum(Jumlah)", ""));
                    // JIKA JUMLAH SUDAH FULL, UNLINK?
                    DialogResult dr=MessageBox.Show("Sudah di Link. \nBatalkan Link?", "Hapus Link DKN", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        //UNLINK DKN
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.BeginTransaction();
                            DKN.UnlinkDKN(db, _rowIDD);
                            DKN.UpdateKodeLink(db, _rowIDD, "", namaSP, "?");
                            db.CommitTransaction();

                        }
                        MessageBox.Show("Unlink DKN Berhasil.");
                        DetailRowRefresh(_rowIDD);
                        return;
                    }
                    else if(dr==DialogResult.No)
                    {
                        if (jumlahLink >= jumlah)
                        {
                            MessageBox.Show("Sudah Link Full. \nTidak bisa tambah link.");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                string _noPerk;
                _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();
                if (noPerkiraan != _noPerk)
                {
                    if (MessageBox.Show("No Perkiraan Bukan No Perkiraan HI.\nUbah No Perkiraan Menjadi No Perkiraan HI?\n" + _noPerk, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _noPerk));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDD));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        DetailRowRefresh(_rowIDD);
                        noPerkiraan = _noPerk;

                    }
                    else
                    {
                        return;
                    }
                }

                DateTime tglBukti = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                string noBukti = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
                string uraian = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                jumlahSisa = jumlah - jumlahLink;
                frmBuktiHILink frm = new frmBuktiHILink(this, "D", "BKK", "E", "IND", tglBukti, noBukti, _rowIDH, noPerkiraan, uraian, jumlahSisa, _rowIDD, namaSP, _recordIDH, _recordIDD);
                frm.ShowDialog();

                DetailRowRefresh(_rowIDD);

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

        private void dgHeaderBKK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHeaderBKK.Rows.Count > 0)
            {
                if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "IND")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.HotPink;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "BSA" || dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "BSK")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.DodgerBlue;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "PIK")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.LimeGreen;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "BNK")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Black;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "OUT")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Black;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "SLP")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.LightSteelBlue;
                else if (dgHeaderBKK.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "PJT")
                    dgHeaderBKK.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Turquoise;
            }
        }

        private void dgHeaderBKK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgHeaderBKK.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
                {
                    if (dgHeaderBKK.CurrentCell != null && dgHeaderBKK.CurrentCell.Value != null)
                        MessageBox.Show(dgHeaderBKK.CurrentCell.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string noPerkiraan = dgDetailBKK.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
                Guid _rowIDH = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["rowID"].Value;
                Guid _rowIDD = (Guid)dgDetailBKK.SelectedCells[0].OwningRow.Cells["rowIDD"].Value;
                string _recordIDH = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                string _recordIDD = dgDetailBKK.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();
                Double jumlah = Convert.ToDouble(dgDetailBKK.SelectedCells[0].OwningRow.Cells["Jumlah"].Value);
                Double jumlahLink = 0;
                Double jumlahSisa = 0;
                string namaSP = "usp_BuktiDetail_Update";

                //CEK PERNAH LINK?
                string _kode = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString().Trim();
                if (_kode != "") //PERNAH LINK
                {
                    //AMBIL DATA LINK, CEK JUMLAH YG PERNAH D LINK
                    DataTable dtCek = new DataTable();
                    dtCek = DKN.CekLinkDKNDetail(_rowIDD);
                    jumlahLink = Convert.ToDouble(dtCek.Compute("Sum(Jumlah)", ""));
                    // JIKA JUMLAH SUDAH FULL, UNLINK?
                    DialogResult dr = MessageBox.Show("Sudah di Link. \nBatalkan Link?", "Hapus Link DKN", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        //UNLINK DKN
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.BeginTransaction();
                            DKN.UnlinkDKN(db, _rowIDD);
                            DKN.UpdateKodeLink(db, _rowIDD, "", namaSP, "?");
                            db.CommitTransaction();

                        }
                        MessageBox.Show("Unlink DKN Berhasil.");
                        DetailRowRefresh(_rowIDD);
                        return;
                    }
                    else if (dr == DialogResult.No)
                    {
                        if (jumlahLink >= jumlah)
                        {
                            MessageBox.Show("Sudah Link Full. \nTidak bisa tambah link.");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                string _noPerk;
                _noPerk = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();
                if (noPerkiraan != _noPerk)
                {
                    if (MessageBox.Show("No Perkiraan Bukan No Perkiraan HI.\nUbah No Perkiraan Menjadi No Perkiraan HI?\n" + _noPerk, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _noPerk));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDD));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        DetailRowRefresh(_rowIDD);
                        noPerkiraan = _noPerk;

                    }
                    else
                    {
                        return;
                    }
                }

                DateTime tglBukti = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                string noBukti = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
                string uraian = dgDetailBKK.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                jumlahSisa = jumlah - jumlahLink;
                frmBuktiHILink frm = new frmBuktiHILink(this, "D", "BKK", "E", "IND", tglBukti, noBukti, _rowIDH, noPerkiraan, uraian, jumlahSisa, _rowIDD, namaSP, _recordIDH, _recordIDD);
                frm.ShowDialog();

                DetailRowRefresh(_rowIDD);

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

        private string Base64FromImage(string PathImage)
        {
            string strResult = string.Empty;
            using (Image img = Image.FromFile(PathImage))
            {
                using (System.IO.MemoryStream m = new System.IO.MemoryStream())
                {
                    img.Save(m, img.RawFormat);
                    byte[] bit = m.ToArray();

                    strResult = Convert.ToBase64String(bit);
                }
            }
            return strResult;
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            if (dgHeaderBKK.SelectedCells.Count > 0)
            {

                if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "OUT")
                    return;

                DateTime _Tanggal = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                if (GlobalVar.Gudang != "2808")
                {
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                }

                if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["AttachmentBKK"].Value.ToString() == "1")
                {
                    DialogResult dr = MessageBox.Show("Sudah memiliki Attachment. Akan mengganti Attachment?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }

                OpenFileDialog OFD = new OpenFileDialog();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    OFD.Filter = "File Gambar (*.JPEG, *.jpg, *.bmp, *.gif, *.png)|*.JPEG; *.jpg; *.bmp; *.gif; *.png";
                    if (OFD.ShowDialog() == DialogResult.OK)
                    {
                        string strFilename = OFD.SafeFileName;
                        string strPathName = OFD.FileName;

                        System.IO.FileInfo fileSize = new System.IO.FileInfo(strPathName);

                        if (fileSize.Length > 1048576)
                        {
                            MessageBox.Show("Ukuran file terlalu besar. Maksimal 1 MB");
                        }
                        else
                        {
                            string strAttacmentBKK = Base64FromImage(strPathName);
                            Guid RowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string strUser = SecurityManager.UserID;

                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_Bukti_AttachmentBKK_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@AttachmentBKK", SqlDbType.VarChar, strAttacmentBKK));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, strUser));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            HeaderRefresh();
                            MessageBox.Show("ATTACHMENT FILE BERHASIL", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ERROR ATTACHMENT FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    OFD.Dispose();
                }


            }



            
        }

        private void lblAttachmentPath_Click(object sender, EventArgs e)
        {

        }

        private void dgHeaderBKK_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            
        }

        private void dgHeaderBKK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgHeaderBKK.RowCount < 1)
            {
                return;
            }
            try
            {
                if (e.ColumnIndex == 19)
                {
                    string strAttState = dgHeaderBKK.SelectedCells[0].Value.ToString();
                    string strAttSource = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["AttachmentSource"].Value.ToString();
                    string strNoBukti = dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
                    if (strAttState == "1")
                    {
                        //System.Diagnostics.Debug.Print(strAttSource);
                        //MessageBox.Show(strAttState);
                        Image img = Base64ToImage(strAttSource);
                        frmAttachmentPreview frm = new frmAttachmentPreview() { ImageSource = img, Text = strNoBukti };
                        frm.ShowDialog(this);

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERR PREVIEW", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
