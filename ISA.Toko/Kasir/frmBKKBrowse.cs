using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.DAL;
using ISA.Common;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace ISA.Toko.Kasir
{
    public partial class frmBKKBrowse : ISA.Toko.BaseForm
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

            //if (PrnAktif == "0")
            //    cetakLaporan();
            //else
            switch (AppSetting.GetValue("DOKUMENBKK"))
            {
                case "2":
                    DisplayReport(dt, "rptCetakBKKbaru");
                    DisplayReport(dt, "rptCetakBKKbaruCopy1");
                    break;
                case "3":
                    DisplayReport(dt, "rptCetakBKKbaru");
                    DisplayReport(dt, "rptCetakBKKbaruCopy1");
                    DisplayReport(dt, "rptCetakBKKbaruCopy2");
                    break;
                default:
                    DisplayReport(dt, "rptCetakBKKbaru");
                    break;
            }
        }


        private void DisplayReport(DataTable dt, String Nama)
        {
            try
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
                string _Terbilang = Tools.Terbilang(total);

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", UserID + ", " + String.Format("{0:dd/MM/yyyy hh:mm:ss}", DateTime.Now)));
                rptParams.Add(new ReportParameter("Kepada", _Kepada));
                rptParams.Add(new ReportParameter("NoBukti", _NoBukti));
                rptParams.Add(new ReportParameter("Tanggal", _Tanggal));
                rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
                rptParams.Add(new ReportParameter("Total", total.ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report." + Nama + ".rdlc", rptParams, dtBKKDetail, "dsBukti_Data");
                ifrmReport.Print();
                ////ifrmReport.Print(8.5, 6.4);
                ////ifrmReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                            + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kepada.Trim()) + ")" +
                            lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                        lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                        lap.Eject();

                    }

                    #endregion
                }

                using (Database db = new Database(GlobalVar.DBFinance))
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
                this.Cursor = Cursors.WaitCursor;
                dtBKK = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
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
                using (Database db = new Database(GlobalVar.DBFinance))
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

                }
                else
                {
                    cmdDelete.Enabled = true;
                    cmdEdit.Enabled = true;
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
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (_Tanggal == DateTime.Today)
                {

                    Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _RecordID, _Terima, _NoBukti, _Lampiran;
                    _RecordID = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RecordID"].Value;
                    _Terima = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["dari"].Value;
                    _NoBukti = (String)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value;
                    _Lampiran = Convert.ToString(dgHeaderBKK.SelectedCells[0].OwningRow.Cells["lampiran"].Value);

                    frmBKKUpdate BKKUpdate = new frmBKKUpdate(this, _rowID, _RecordID, _Terima, _NoBukti, _Tanggal, _Lampiran, string.Empty, false, string.Empty);
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
            if (dgHeaderBKK.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "OUT")
                return;

            DateTime _Tanggal = (DateTime)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;

            if (_Tanggal.Date != GlobalVar.DateOfServer.Date)
            {
                KotakPesan.Warning("Tanggal Bukti transaksi Tidak sama dengan Tanggal server. Tidak bisa hapus record.");
                return;
            }
            if (PeriodeClosing.IsKasirClosed(_Tanggal))
            {
                MessageBox.Show("Sudah Closing!");
                return;
            }
            if (dgDetailBKK.SelectedCells.Count > 0)
            {
                MessageBox.Show("Anda tidak diperkenankan menghapus data ini");
                return;
            }
            string ques = "No Bukti : " + dgHeaderBKK.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString() + " Akan Dihapus?";
            if ((dgHeaderBKK.SelectedCells.Count > 0) && (MessageBox.Show(ques, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Guid _rowID = (Guid)dgHeaderBKK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBFinance))
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
                        using (Database db = new Database(GlobalVar.DBFinance))
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

                        using (Database db = new Database(GlobalVar.DBFinance))
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

        }

        private void frmBKKBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Insert:
                    cmdAdd.PerformClick();
                    break;
                case Keys.Space:
                    cmdEdit.PerformClick();
                    break;
                case Keys.Delete:
                    cmdDelete.PerformClick();
                    break;
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}
