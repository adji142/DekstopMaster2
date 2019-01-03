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
    public partial class frmBKMBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dtBKM = new DataTable(), dtBKMDetail = new DataTable();
        DataTable dt;
        string PrnAktif = "0";

        public frmBKMBrowse()
        {
            InitializeComponent();
        }
        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmBKMUpdate BMKUpdate = new frmBKMUpdate(this);
            BMKUpdate.ShowDialog();
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

            //if (PrnAktif == "0")
            //    cetakLaporan();
            //else 
            switch (AppSetting.GetValue("DOKUMENBKM")) 
            {
                case "2":
                    DisplayReport(dt, "rptCetakBKMbaru");
                    DisplayReport(dt, "rptCetakBKMbaruCopy1");
                    break;
                case "3":
                    DisplayReport(dt, "rptCetakBKMbaru");
                    DisplayReport(dt, "rptCetakBKMbaruCopy1");
                    DisplayReport(dt, "rptCetakBKMbaruCopy2");
                    break;
                default:
                    DisplayReport(dt, "rptCetakBKMbaru");
                    break;
            }
        }



        private void DisplayReport(DataTable dt, String Nama)
        {
            try
            {

                string UserID = SecurityManager.UserName.ToString();
                int i = 0;
                double total = 0, jumlah;
                string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir, _Terbilang;
                Guid _rowID = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _Terima = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["dari"].Value.ToString();
                _NoBukti = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
                _Lampiran = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Lampiran"].Value.ToString();
                _Tanggal = String.Format("{0:dd-MMM-yyyy}", dgHeaderBKM.SelectedCells[0].OwningRow.Cells["tglBukti"].Value);
                _Kasir = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Kasir"].Value.ToString();

                foreach (DataRow dr in dtBKMDetail.Rows)
                {
                    total += Convert.ToDouble(dr["Jumlah"].ToString());
                }
                _Terbilang = Tools.Terbilang(total);

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", UserID + ", " + String.Format("{0:dd/MM/yyyy hh:mm:ss}", DateTime.Now)));
                rptParams.Add(new ReportParameter("Terima", _Terima));
                rptParams.Add(new ReportParameter("NoBukti", _NoBukti));
                rptParams.Add(new ReportParameter("Tanggal", _Tanggal));
                rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
                rptParams.Add(new ReportParameter("Total", total.ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report." + Nama + ".rdlc", rptParams, dtBKMDetail, "dsBukti_Data");
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
            if ((int.Parse(dgHeaderBKM.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0) && (!SecurityManager.IsManager()))
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir;
            Guid _rowID = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _Terima = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["dari"].Value.ToString();
            _NoBukti = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
            _Lampiran = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Lampiran"].Value.ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}", dgHeaderBKM.SelectedCells[0].OwningRow.Cells["tglBukti"].Value);
            _Kasir = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Kasir"].Value.ToString();
            int rowNo = 0;
            int no = 0;

            int ttlData = dtBKMDetail.Rows.Count;
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


                bool cetak = true;

                foreach (DataRow dr in dtBKMDetail.Rows)
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
                        lap.PROW(true, 1, "[BUKTI KAS MASUK]");
                        lap.DoubleWidth(false);

                        lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                            + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "Di Terima Dari : ".PadRight(41) +
                            lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                            _Tanggal).PadRight(30) + ("Hal : " + hal.ToString() + "/" + ttlHal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                            + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                        lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                        lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                    }

                    #endregion


                    jumlah = Convert.ToDouble(dr["Jumlah"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".PadRight(10) + dr["Uraian"].ToString().ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
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
                            + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Terima.Trim()) + ")" +
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
                lap.SendToPrinter("laporanPS.txt");
                //lap.SendToFile("laporanPS.txt");

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

         
        private void frmBKMBrowse_Load(object sender, EventArgs e)
        {
            //rdBKM.FromDate = new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            //rdBKM.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month));
            
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
                dtBKM = new DataTable();
               // using (Database db = new Database("ISADBDepoFinance"))
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtBKM = BKM.ListHeader(db, _fromDate, _toDate);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtBKM.DefaultView.Sort = "TglBukti, Pos, NoBukti";
                dgHeaderBKM.DataSource = dtBKM.DefaultView;
                if (dgHeaderBKM.SelectedCells.Count > 0)
                {
                    DetailRefresh();

                }
                else
                {
                    dtBKMDetail.Clear();
                    dgDetailBKM.DataSource = dtBKMDetail.DefaultView;
                   
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
                dtBKMDetail = new DataTable();
                Guid _rowID = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtBKMDetail = BKM.ListDetail(db, _rowID);
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtBKMDetail.DefaultView.Sort = "RecordID";
                dgDetailBKM.DataSource = dtBKMDetail.DefaultView;

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

        public void HeaderRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKM.ListHeaderperRow(RowID);
            dgHeaderBKM.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }

        public void DetailRowRefresh(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            dtResult = BKM.ListDetailperRow(RowID);
            dgDetailBKM.RefreshDataRow(dtResult.Rows[0], "RowID", RowID.ToString());
        }

        public void FindRowHeader(string column, string value)
        {
            dgHeaderBKM.FindRow(column, value);
        }

        public void FindRowDetail(string column, string value)
        {
            dgDetailBKM.FindRow(column, value);
        }

        public void DetailDeleteRefresh()
        {
            #region "Tambahan"
            int i = 0;
            int n = 0;
            i = dgDetailBKM.SelectedCells[0].RowIndex;
            n = dgDetailBKM.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)dgDetailBKM.SelectedCells[0].OwningRow.DataBoundItem;

            DataRow dr = dv.Row;

            dr.Delete();
            dtBKMDetail.AcceptChanges();
            dgDetailBKM.Focus();
            dgDetailBKM.RefreshEdit();
            if (dgDetailBKM.RowCount > 0)
            {
                if (i == 0)
                {
                    dgDetailBKM.CurrentCell = dgDetailBKM.Rows[0].Cells[n];
                    dgDetailBKM.RefreshEdit();
                }
                else
                {
                    dgDetailBKM.CurrentCell = dgDetailBKM.Rows[i - 1].Cells[n];
                    dgDetailBKM.RefreshEdit();
                }

            }
            #endregion
        }


        private void dgHeaderBKM_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHeaderBKM.SelectedCells.Count > 0)
            {
                if (dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "IN")
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
            if (dgHeaderBKM.SelectedCells.Count > 0)
            {
                if (dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "IN")
                    return;
                DateTime _Tanggal = (DateTime)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (_Tanggal == DateTime.Today)
                {

                    Guid _rowID = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _RecordID, _Terima, _NoBukti, _Lampiran;
                    
                    _RecordID = (String)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RecordID"].Value;
                    _Terima = (String)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["dari"].Value;
                    _NoBukti = (String)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["noBukti"].Value;
                    _Lampiran = Convert.ToString(dgHeaderBKM.SelectedCells[0].OwningRow.Cells["lampiran"].Value);

                    frmBKMUpdate BMKUpdate = new frmBKMUpdate(this, _rowID, _RecordID, _Terima, _NoBukti, _Tanggal, _Lampiran, string.Empty, false, string.Empty);
                    BMKUpdate.ShowDialog();
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
            if (dgHeaderBKM.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() != "IN")
                return;
            if (dgDetailBKM.SelectedCells.Count > 0)
            {
                MessageBox.Show("Anda tidak diperkenankan menghapus data ini");
                return;
            }
            DateTime _Tanggal = (DateTime)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
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

            string ques="No Bukti : "+dgHeaderBKM.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString()+" Akan Dihapus?";
            if ((dgHeaderBKM.SelectedCells.Count > 0)&&(MessageBox.Show(ques,"",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes))
            {
                Guid _rowID = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    { 
                        db.Commands.Add(db.CreateCommand("usp_Bukti_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID",SqlDbType.UniqueIdentifier,_rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    #region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = dgHeaderBKM.SelectedCells[0].RowIndex;
                    n = dgHeaderBKM.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgHeaderBKM.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtBKM.AcceptChanges();
                    dgHeaderBKM.Focus();
                    dgHeaderBKM.RefreshEdit();
                    if (dgHeaderBKM.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgHeaderBKM.CurrentCell = dgHeaderBKM.Rows[0].Cells[n];
                            dgHeaderBKM.RefreshEdit();
                        }
                        else
                        {
                            dgHeaderBKM.CurrentCell = dgHeaderBKM.Rows[i - 1].Cells[n];
                            dgHeaderBKM.RefreshEdit();
                        }

                    }
                    #endregion

                }
                catch(Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    //HeaderRefresh();
                    //DetailRefresh();
                }
               
            }
        }

        private void cmdHI_Click(object sender, EventArgs e)
        {
            string noPerkiraan = dgDetailBKM.SelectedCells[0].OwningRow.Cells["noPerkiraan"].Value.ToString();
            
            Guid _rowIDH = (Guid)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["rowID"].Value;
            Guid _rowIDD = (Guid)dgDetailBKM.SelectedCells[0].OwningRow.Cells["rowIDD"].Value;
            string _noPerk;
            string _recordIDH = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            string _recordIDD = dgDetailBKM.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();
            Double jumlah = Convert.ToDouble(dgDetailBKM.SelectedCells[0].OwningRow.Cells["Jumlah"].Value);
            Double jumlahLink = 0;
            Double jumlahSisa = 0;
            string namaSP = "usp_BuktiDetail_Update";

            try
            {

                string _kode = dgDetailBKM.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString().Trim();
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
                                DKN.UpdateKodeLink(db, _rowIDD, "", namaSP,"?");
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

                DateTime tglBukti = (DateTime)dgHeaderBKM.SelectedCells[0].OwningRow.Cells["tglBukti"].Value;
                string noBukti = dgHeaderBKM.SelectedCells[0].OwningRow.Cells["noBukti"].Value.ToString();
                string uraian = dgDetailBKM.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                jumlahSisa = jumlah - jumlahLink;
                frmBuktiHILink frm = new frmBuktiHILink(this, "K", "BKM", "E", "IND", tglBukti, noBukti, _rowIDH, noPerkiraan, uraian, jumlahSisa, _rowIDD, namaSP, _recordIDH, _recordIDD);
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

        private void dgHeaderBKM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHeaderBKM.Rows.Count > 0)
            {
                if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "IND")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.HotPink;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "BSL")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.DodgerBlue;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "PIK")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.LimeGreen;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "BNK")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Black;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "IN")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Black;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "SLP")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.LightSteelBlue;
                else if (dgHeaderBKM.Rows[e.RowIndex].Cells["Src"].Value.ToString() == "PJT")
                    dgHeaderBKM.Rows[e.RowIndex].Cells["noBukti"].Style.ForeColor = Color.Turquoise;

            }
        }

        private void frmBKMBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) 
            {
                cmdAdd.PerformClick();
            }else if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmdClose.PerformClick();
            }
        }
    }
}
