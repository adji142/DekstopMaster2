using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherGiroTitipanBrowse : ISA.Toko.BaseForm
    {
        DataTable dtHeader, dtDetail;
        enum enumSelectMode { Header, Detail };
        enumSelectMode selectMode;
        public frmVoucherGiroTitipanBrowse()
        {
            InitializeComponent();
        }

        

        private void frmVoucherGiroTitipanBrowse_Load(object sender, EventArgs e)
        {
            //tbTanggal.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //tbTanggal.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            tbTanggal.FromDate = DateTime.Today;
            tbTanggal.ToDate = DateTime.Today;
            HeaderRefresh();
            //DetailRefresh();
            gridHeader.Focus();
            selectMode = enumSelectMode.Header;
        }

        public void HeaderRefresh()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeader = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtHeader = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "TT");
                }


                dtHeader.DefaultView.Sort = "TglVoucher";
                gridHeader.DataSource = dtHeader.DefaultView;
                gridHeader.Focus();



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
            Guid RowIDHeader = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            try
            {
                dtDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtDetail = Giro.ListByTitipID(db, RowIDHeader);
                }

                
                    dtDetail.DefaultView.Sort = "GiroRecID";
                    gridDetail.DataSource = dtDetail.DefaultView;
                    
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void HeaderRowRefresh(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();
            dtRefresh = VoucherJournal.ListRowHeader(RowID);
            gridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID.ToString());
        }

        public void DetailRowRefresh(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                dtRefresh = Giro.List(db,RowID);
            }
            gridDetail.RefreshDataRow(dtRefresh.Rows[0], "GiroID", RowID.ToString());
        }

        public void HeaderFindRow(string columnName, string value)
        {
            gridHeader.FindRow(columnName, value);
        }

        public void DetailFindRow(string columnName, string value)
        {
            gridDetail.FindRow(columnName, value);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            HeaderRefresh();
            //DetailRefresh();
        }
        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Header)
            {
                frmVoucherGiroTitipUpdate frm = new frmVoucherGiroTitipUpdate(this);
                frm.ShowDialog();
            }
            else
            {
                if (gridHeader.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    string bankID, namaBank, titipRecID, noVoucher, mengetahui;
                    Guid titipID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                    bankID = gridHeader.SelectedCells[0].OwningRow.Cells["hdrBankID"].Value.ToString();
                    namaBank = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNamaBank"].Value.ToString();
                    titipRecID = gridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                    noVoucher = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
                    mengetahui = gridHeader.SelectedCells[0].OwningRow.Cells["hdrMengetahui"].Value.ToString();
                    frmLookupVoucherGiroTitipUpdate frm = new frmLookupVoucherGiroTitipUpdate(this, titipID, titipRecID, bankID, namaBank, noVoucher, mengetahui);
                    frm.ShowDialog();
                    HeaderRowRefresh(titipID);
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectMode == enumSelectMode.Header)
            {
                if (gridHeader.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    Guid titipID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                    DataTable dtEdit = new DataTable();
                    dtEdit = dtHeader.Copy();
                    dtEdit.DefaultView.RowFilter = "RowID='" + titipID + "'";
                    DataView dv = dtEdit.DefaultView;
                    dtEdit = new DataTable();
                    dtEdit = dv.ToTable();
                    frmVoucherGiroTitipUpdate frm = new frmVoucherGiroTitipUpdate(this, dtEdit);
                    frm.ShowDialog();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

            if (selectMode == enumSelectMode.Header)
            {
                if (gridHeader.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value;
                    if (_Tanggal.Date != GlobalVar.DateOfServer.Date)
                    {
                        KotakPesan.Warning("Tanggal server tidak sama dengan tanggal transaksi. \n Tidak bisa hapus transaksi");
                        return;
                    }
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    Guid rowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                    if ((int)dtDetail.Compute("count(Nomor)", "") > 0)
                    {
                        KotakPesan.Warning("Sudah ada record di detail, tidak bisa hapus record. \n Silahkan hapus record detail terlebih dahulu.");
                        return;
                    }

                    if (MessageBox.Show("Data Ini Akan Dihapus?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!SecurityManager.AskPasswordManager())
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                using (Database db = new Database(GlobalVar.DBFinance))
                                {
                                    VoucherJournal.DeleteVoucherJournal(db, rowID);
                                }



                                #region "Tambahan"
                                int i = 0;
                                int n = 0;
                                i = gridHeader.SelectedCells[0].RowIndex;
                                n = gridHeader.SelectedCells[0].ColumnIndex;
                                DataRowView dv = (DataRowView)gridHeader.SelectedCells[0].OwningRow.DataBoundItem;

                                DataRow dr = dv.Row;

                                dr.Delete();
                                dtHeader.AcceptChanges();
                                gridHeader.Focus();
                                gridHeader.RefreshEdit();
                                if (gridHeader.RowCount > 0)
                                {
                                    if (i == 0)
                                    {
                                        gridHeader.CurrentCell = gridHeader.Rows[0].Cells[n];
                                        gridHeader.RefreshEdit();
                                    }
                                    else
                                    {
                                        gridHeader.CurrentCell = gridHeader.Rows[i - 1].Cells[n];
                                        gridHeader.RefreshEdit();
                                    }

                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                    }

                }
            }
            else
            {
                if (gridDetail.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    if (MessageBox.Show("Apakah giro ini tidak jadi dititipkan?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Guid _GiroID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                        Guid _RowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                        try
                        {
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                db.Commands.Add(db.CreateCommand("usp_Giro_BatalTitip"));
                                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            HeaderRowRefresh(_RowID);
                            #region "Tambahan"
                            int i = 0;
                            int n = 0;
                            i = gridDetail.SelectedCells[0].RowIndex;
                            n = gridDetail.SelectedCells[0].ColumnIndex;
                            DataRowView dv = (DataRowView)gridDetail.SelectedCells[0].OwningRow.DataBoundItem;

                            DataRow dr = dv.Row;

                            dr.Delete();
                            dtDetail.AcceptChanges();
                            gridDetail.Focus();
                            gridDetail.RefreshEdit();
                            if (gridDetail.RowCount > 0)
                            {
                                if (i == 0)
                                {
                                    gridDetail.CurrentCell = gridDetail.Rows[0].Cells[n];
                                    gridDetail.RefreshEdit();
                                }
                                else
                                {
                                    gridDetail.CurrentCell = gridDetail.Rows[i - 1].Cells[n];
                                    gridDetail.RefreshEdit();
                                }

                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
            }
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
               int jmlprint = 1;
                if ((int)gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
                    return;


                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt2 = new DataTable();
                   

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DOKUMENVGT"));
                        dt2 = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        jmlprint = int.Parse(dt2.Rows[0]["Value"].ToString());
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

                DisplayReport(dtDetail, "Kasir.Report.rptCetakLapGiro.rdlc", "Voucher Giro Titipan");
                //cetakGiro(dtDetail);
                if(jmlprint==2)
                {
                    DisplayReport(dtDetail, "Kasir.Report.rptCetakLapGirocopy.rdlc", "Voucher Giro Titipan");
                }

                Guid _RowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_VoucherJournal_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value + 1));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }

                HeaderRowRefresh(_RowID);
                
            }
        }

        #region CETAK GIRO
        private void cetakGiro(DataTable dtGiro)
        {
            
            double total = 0, jumlah; 
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan;

            Guid _RowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            string namaBankTitip=gridHeader.SelectedCells[0].OwningRow.Cells["hdrNamaBank"].Value.ToString().Trim();
            _Terima = "TITIP GIRO "+namaBankTitip;
            _NoBukti = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}", gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value);
            _Kasir = gridHeader.SelectedCells[0].OwningRow.Cells["hdrDibuat"].Value.ToString();
            _mengetahui = gridHeader.SelectedCells[0].OwningRow.Cells["hdrMengetahui"].Value.ToString();
            _pembukuan = gridHeader.SelectedCells[0].OwningRow.Cells["hdrDibukukan"].Value.ToString();
            
            total = Convert.ToDouble(dtGiro.Compute("Sum(Nominal)", ""));

            BuildString lap = new BuildString();
            

            int i = 0, j = 1;
            int n = dtGiro.Rows.Count;
            int jmlhal = n / 10;
            int y = 0;

            if (n % 10 >0)
            {
                jmlhal += 1;
            }

            while (j <= jmlhal)
            {
                //HEADER

                lap.Initialize();

                lap.PageLLine(33);
                lap.LeftMargin(1);
                lap.FontCPI(12);
                lap.LineSpacing("1/6");
                lap.DoubleWidth(true);
                lap.PROW(true, 1, "[VOUCHER TITIP GIRO]");
                lap.DoubleWidth(false);
                
                lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Di Terima Dari : ".PadRight(41) +
                    lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                    _Tanggal).PadRight(30) + ("Hal : " + j.ToString()+" / "+jmlhal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(3, "") + lap.PadCenter(8, "No. Giro") + lap.PadCenter(20, "Asal Giro") + lap.SPACE(1)
                    + lap.PadCenter(10, "Bank Asal")  + lap.PadCenter(13, "Tgl. Giro") + lap.PadCenter(13, "Tgl. J/Tempo") 
                    + lap.PadCenter(15, "Nilai Giro Rp") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                y = 0;
                while (i<n && y<10)
                {
                    jumlah = Convert.ToDouble(dtGiro.Rows[i]["Nominal"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(3, dtGiro.Rows[i]["CHBG"].ToString()) + dtGiro.Rows[i]["Nomor"].ToString().Trim().PadRight(8) + dtGiro.Rows[i]["AsalGiro"].ToString().Trim().ToUpper().PadRight(20).Substring(0,20)
                        + lap.SPACE(1) + dtGiro.Rows[i]["NamaBank"].ToString().Trim().PadRight(10).Substring(0,10)  + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["TglGiro"])) 
                        + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["TglJth"])) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    
                    i++;
                    y++;
                }
                j++;              

                if (i==n && i%10!=0)
                {
                    int sisaBaris = 10 - (i % 10);
                    for (int x = 0; x < sisaBaris; x++)
                    {
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                    }
                }
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                    total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penyetor") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _pembukuan.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _mengetahui.Trim())
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)+" "+SecurityManager.UserName);
                lap.Eject();

            }

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_VoucherJournal_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value + 1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }

            HeaderRowRefresh(_RowID);
            lap.SendToPrinter("laporanPS.txt", lap.GenerateString());
            lap.SendToPrinter("laporanPS.txt");
        }
        #endregion

        private void gridHeader_Enter(object sender, EventArgs e)
        {
            selectMode = enumSelectMode.Header;
            cmdEdit.Enabled = true;
            cmdPrint.Enabled = true;
            gridHeader_SelectionChanged(sender, e);
        }

        private void gridDetail_Enter(object sender, EventArgs e)
        {
            selectMode = enumSelectMode.Detail;
            cmdEdit.Enabled = false;
            cmdPrint.Enabled = false;
        }

        private void gridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                DetailRefresh();
            }
        }

        private void gridHeader_Leave(object sender, EventArgs e)
        {
            //cmdPrint.Enabled = false;
        }

        private void DisplayReport(DataTable dtLaporan, string namerdlc, string judul)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir, _Terbilang;
            
            //Guid RowIDHeader = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            //Guid _RowID = (Guid)dtLaporan.Rows[0]["RowID"];
            //string typePrinter = lap.GetPrinterName();
            string NamaBank = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNamaBank"].Value.ToString();
            string NoBBM = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
            string TglBBM = ((DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value).ToString("dd-MMM-yyyy").Trim();
            //string Pembukuan = Tools.isNull(dtLaporan.Rows[0]["Dibukukan"], "").ToString().Trim();
            //string Mengetahui = Tools.isNull(dtLaporan.Rows[0]["Diketahui"], "").ToString().Trim();
            //string Kasir = Tools.isNull(dtLaporan.Rows[0]["Kasir"], "").ToString().Trim();
            //string Penyetor = Tools.isNull(dtLaporan.Rows[0]["Penyetor"], "").ToString().Trim();
            string Nomor = string.Empty;
            string AsalTransfer = string.Empty;
            string Bank = string.Empty;
            string TglBank = string.Empty;
            string TglTransfer = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempJumlah = string.Empty;
            string UserID = SecurityManager.UserName.ToString();

            foreach (DataRow dr in dtLaporan.Rows)
            {
                total += Convert.ToDouble(dr["Nominal"].ToString());
            }
            _Terbilang = Tools.Terbilang(total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", string.Format("{0}, {1:dd/MM/yyyy hh:mm:ss}", SecurityManager.UserName, DateTime.Now)));
            rptParams.Add(new ReportParameter("NamaBank", NamaBank));
            rptParams.Add(new ReportParameter("NoBBM", NoBBM));
            rptParams.Add(new ReportParameter("TglBBM", String.Format("{0:dd-MMM-yyyy}", TglBBM)));
            rptParams.Add(new ReportParameter("Total", total.ToString()));
            rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
            rptParams.Add(new ReportParameter("Judul", judul));

            frmReportViewer ifrmReport = new frmReportViewer(namerdlc, rptParams, dtLaporan, "dsLapGiro_Data");
            ifrmReport.Print();
            ////ifrmReport.Print(8.5, 6.4);
            ////ifrmReport.Show();
        }
  
    }
}
