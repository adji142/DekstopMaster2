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
    public partial class frmBuktiTransferKeluar : ISA.Controls.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumSelectedGrid { HeaderSelected, DetailSelected};
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dt = new DataTable();
        string PrnAktif = "0";

        public frmBuktiTransferKeluar()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
           

            switch (selectedGrid)
            {
            case enumSelectedGrid.HeaderSelected:
                    Kasir.frmBuktiTransferKeluarUpdate ifrmChild = new Kasir.frmBuktiTransferKeluarUpdate(this,string.Empty,false,string.Empty,string.Empty,string.Empty);
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
            	break;
            case enumSelectedGrid.DetailSelected:
                DateTime _Tanggal;
                try
                {
                    _Tanggal = (DateTime)gridUtm.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                }
                catch
                {
                    _Tanggal = DateTime.Today;
                }
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                Guid rowID;
                try
                {
                    rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                }
                catch
                {
                    rowID = Guid.Empty;
                }
                string bankID;
                try
                {
                    bankID = gridUtm.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                }
                catch
                {
                    bankID = "";
                }

                Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, string.Empty, rowID, 0, false, string.Empty, string.Empty, string.Empty, string.Empty,bankID);

                Program.MainForm.RegisterChild(ifrmDetail);
                ifrmDetail.ShowDialog();
                
                   
                break;
            }

            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshBuktiTransfer();
        }

        private void frmBuktiTransferKeluar_Load(object sender, EventArgs e)
        {
            cmdPrint.Enabled = true;
            cmdDelete.Enabled = true;
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            gridUtm.AutoGenerateColumns = false;
            gridDetail.AutoGenerateColumns = false;            
            RefreshBuktiTransfer();
        }

        public void RefreshBuktiTransfer()
        {
            try
            {

                dtHeader = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluar_LIST"));
                    dtHeader = Class.TransferBank.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, "K");
                    
                }
                dtHeader.DefaultView.Sort = "TglBBM Desc";
                gridUtm.DataSource = dtHeader.DefaultView;

                if (gridUtm.SelectedCells.Count > 0)
                {

                    RefreshBuktiTransferDetail();
                }
                else
                {
                    dtDetail.Clear();
                    gridDetail.DataSource = dtDetail.DefaultView;
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

        public void RefreshRowBuktiTransfer(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            dtRefresh = TransferBank.ListHeaderRow(rowID, "K");
            gridUtm.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
        }

        public void RefreshRowBuktiTransferDetail(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            dtRefresh = TransferBank.ListDetailRow(rowID);
            gridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowIDDetail", rowID.ToString());
        } 

        public void RefreshBuktiTransferDetail()
        {
            try
            {
                Guid rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluar_DETAIL"));
                    dtDetail = Class.TransferBank.ListDetail(db, rowID);
                    gridDetail.DataSource = dtDetail.DefaultView;
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

        public void FindRowHeader(string column, string value)
        {
            gridUtm.FindRow(column, value);
        }

        public void FindRowDetail(string column, string value)
        {
            gridDetail.FindRow(column, value);
        }
        


        private void gridUtm_SelectionChanged(object sender, EventArgs e)
        {
            if (gridUtm.SelectedCells.Count > 0)
            {
                if (gridUtm.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshBuktiTransferDetail();
                }
                prevGrid1Row = gridUtm.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                dtDetail.Clear();
                gridDetail.DataSource = dtDetail.DefaultView;
            }
        }

        

        private void gridUtm_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUtm.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
        }


        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DateTime _Tanggal = (DateTime)gridUtm.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
            if (PeriodeClosing.IsKasirClosed(_Tanggal))
            {
                MessageBox.Show("Sudah Closing!");
                return;
            }
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:  
                  
                    if (gridUtm.RowCount > 0)
                    {                        
                        Kasir.frmBuktiTransferKeluarUpdate ifrmChild = new Kasir.frmBuktiTransferKeluarUpdate(this,rowID,false,string.Empty,string.Empty,string.Empty,string.Empty);
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    
                    break;
                case enumSelectedGrid.DetailSelected:

                    Guid rowIDDetail = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                    if(gridDetail.RowCount > 0)
                    {
                        Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, rowIDDetail, rowID, string.Empty, false, string.Empty, string.Empty, string.Empty);
                        Program.MainForm.RegisterChild(ifrmDetail);
                        ifrmDetail.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    

                    break;
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (gridUtm.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridUtm.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                    if (_Tanggal.Date != GlobalVar.DateOfServer.Date)
                    {
                        KotakPesan.Warning("Tanggal server tidak sama dengan tanggal transaksi. \n Tidak bisa hapus transaksi");
                        return;
                    }
                    if (gridDetail.Rows.Count > 0)
                    {
                        KotakPesan.Warning("Sudah ada record di detail, tidak bisa hapus record. \n Silahkan hapus record detail terlebih dahulu.");
                        return;
                    }
                    else if (!SecurityManager.AskPasswordManager())
                    {
                        return;
                    }

                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    Guid headerID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_TransferBank_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                        //gridDetail.Rows.Remove(gridDetail.SelectedCells[0].OwningRow);

                        //RefreshRowBuktiTransfer(headerID); // ini buat apa ?

                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = gridUtm.SelectedCells[0].RowIndex;
                        n = gridUtm.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)gridUtm.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        dtHeader.AcceptChanges();
                        gridUtm.Focus();
                        gridUtm.RefreshEdit();
                        if (gridUtm.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                gridUtm.CurrentCell = gridUtm.Rows[0].Cells[n];
                                gridUtm.RefreshEdit();
                            }
                            else
                            {
                                gridUtm.CurrentCell = gridUtm.Rows[i - 1].Cells[n];
                                gridUtm.RefreshEdit();
                            }

                        }
                        #endregion
                    }
                }
            }
            else
            {
                if (gridDetail.SelectedCells.Count > 0)
                {
                    DateTime _Tanggal = (DateTime)gridUtm.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                    if (_Tanggal.Date != GlobalVar.DateOfServer.Date)
                    {
                        KotakPesan.Warning("Tanggal server tidak sama dengan tanggal transaksi. Tidak bisa hapus transaksi");
                        return;
                    }
                    else if (!SecurityManager.AskPasswordManager())
                    {
                        return;
                    }


                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    Guid headerID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Guid rowID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                    Guid rowIDBank = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDBank"].Value;
                    if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {

                            db.BeginTransaction();
                            Class.TransferBank.DeleteDetail(db, rowID);

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, rowIDBank));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                        //gridDetail.Rows.Remove(gridDetail.SelectedCells[0].OwningRow);

                        RefreshRowBuktiTransfer(headerID);
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
                }
                else
                {
                    MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }


        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                int nprint = (int)gridUtm.SelectedCells[0].OwningRow.Cells["NPrint"].Value;
                int jmlprint = 1;
                if (nprint > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
                {
                    MessageBox.Show(Messages.Error.ConfirmPasswordNotMatch);
                    return;
                }

                DataTable dtLaporan = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("rsp_BuktiTransferKeluar_CETAK"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    dtLaporan = db.Commands[0].ExecuteDataTable();
                    //PrintLaporan(dtLaporan);
                    //RefreshRowBuktiTransfer(rowID);
                }
                this.Cursor = Cursors.Default;

                if (dtLaporan.Rows.Count > 0)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dt = new DataTable();
                        DataTable dt2 = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                            db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BBK"));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DOKUMENBBK"));
                            dt2 = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt2.Rows.Count > 0)
                        {
                            jmlprint = int.Parse(dt2.Rows[0]["Value"].ToString());
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
                    //{
                    //    PrintLaporan(dtLaporan);
                    //    RefreshRowBuktiTransfer(rowID);
                    //}
                    //else
                    //{
                    //    DisplayReport(dtLaporan);
                    //    RefreshRowBuktiTransfer(rowID);
                    //}

                    DisplayReport(dtLaporan, "Kasir.Report.rptCetakBBKbaru.rdlc");
                    if (jmlprint == 2)
                    {
                        DisplayReport(dtLaporan, "Kasir.Report.rptCetakBBKbarucopy.rdlc");
                    }
                    RefreshRowBuktiTransfer(rowID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DisplayReport(DataTable dtLaporan, string rdlc)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir, _Terbilang;

            Guid _RowID = (Guid)dtLaporan.Rows[0]["RowID"];
            //string typePrinter = lap.GetPrinterName();
            string NamaBank = Tools.isNull(dtLaporan.Rows[0]["NamaBank"], "").ToString().Trim();
            string NoBBM = Tools.isNull(dtLaporan.Rows[0]["NoBBM"], "").ToString().Trim();
            string TglBBM = ((DateTime)dtLaporan.Rows[0]["TglBBM"]).ToString("dd-MMM-yyyy").Trim();
            string Pembukuan = Tools.isNull(dtLaporan.Rows[0]["Dibukukan"], "").ToString().Trim();
            string Mengetahui = Tools.isNull(dtLaporan.Rows[0]["Diketahui"], "").ToString().Trim();
            string Kasir = Tools.isNull(dtLaporan.Rows[0]["Kasir"], "").ToString().Trim();
            string Penyetor = Tools.isNull(dtLaporan.Rows[0]["Penyetor"], "").ToString().Trim();
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
            rptParams.Add(new ReportParameter("NamaBank", NamaBank));
            rptParams.Add(new ReportParameter("NoBBM", NoBBM));
            rptParams.Add(new ReportParameter("TglBBM", TglBBM));
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("Total", total.ToString()));
            rptParams.Add(new ReportParameter("Terbilang", _Terbilang));

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptCetakBBKbaru.rdlc", rptParams, dtLaporan, "dsBank_Data2");
            ifrmReport.Print();
            ////ifrmReport.Print(8.5, 6.4);
            ////ifrmReport.Show();
        }


        private void PrintLaporan(DataTable dt)
        {
            BuildString lap = new BuildString();
            Guid _RowID = (Guid)dt.Rows[0]["RowID"];
            string typePrinter = lap.GetPrinterName();
            string NamaBank = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString().Trim();
            string NoBBM = Tools.isNull(dt.Rows[0]["NoBBM"], "").ToString().Trim();
            string TglBBM = ((DateTime)dt.Rows[0]["TglBBM"]).ToString("dd-MM-yyyy").Trim();
            string Pembukuan = Tools.isNull(dt.Rows[0]["Dibukukan"], "").ToString().Trim();
            string Mengetahui = Tools.isNull(dt.Rows[0]["Diketahui"], "").ToString().Trim();
            string Kasir = Tools.isNull(dt.Rows[0]["Kasir"], "").ToString().Trim();
            string Penyetor = Tools.isNull(dt.Rows[0]["Penyetor"], "").ToString().Trim();
            string Nomor = string.Empty;
            string AsalTransfer = string.Empty;
            string Bank = string.Empty;
            string TglBank = string.Empty;
            string TglTransfer = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempJumlah = string.Empty;
            int i = 0;
            int rowNo = 0;
            int no = 0;

            int ttlData = dt.Rows.Count;
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

            //lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(128) + lap.PrintTopRightCorner());
            //lap.PROW(false, 63, lap.PrintTTOp());

            //lap.PROW(true, 1, lap.PrintVerticalLine() + "Diterima Dari: ".PadRight(61) + lap.PrintVerticalLine());
            //lap.PROW(false, 65, "Nomor  : " + NoBBM.PadRight(57) + lap.PrintVerticalLine());

            //lap.PROW(true, 1, lap.PrintVerticalLine() + NamaBank.PadRight(61) + lap.PrintVerticalLine());
            //lap.PROW(false, 65, "Tanggal: " + TglBBM.PadLeft(10) + lap.SPACE(3) + "Hal : " + hal.ToString() + "/" + ttlHal.ToString().PadRight(36)  + lap.PrintVerticalLine());

            //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(128) + lap.PrintTRight());
            //lap.PROW(false, 63, lap.PrintTBottom());
            //lap.PROW(true, 1, lap.PrintVerticalLine() + "Nomor" + lap.SPACE(16) + "Asal Transfer" + lap.SPACE(16) + "Bank" + lap.SPACE(16) + "Tgl.Bank" + lap.SPACE(16) + "Tgl.Trf" + lap.SPACE(15) + "Nilai Tranfer" + lap.PrintVerticalLine());
            //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(129) + lap.PrintTRight());

            bool cetak = true;

            foreach (DataRow dr in dt.Rows)
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
                    lap.PROW(true, 1, "[Bukti Bank Keluar]");
                    lap.DoubleWidth(false);

                    lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                        + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "Kepada : ".PadRight(41) +
                        lap.PrintVerticalLine() + ("Nomor   : " + NoBBM).PadRight(41) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + NamaBank.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                        TglBBM).PadRight(30) + ("Hal : " + hal.ToString() + "/" + ttlHal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                        + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(10, "Nomor") + lap.PadCenter(20, "Asal Transfer") + lap.SPACE(1)
                + lap.PadCenter(11, "Bank") + lap.PadCenter(13, "Tgl. Bank") + lap.PadCenter(13, "Tgl. Trf")
                + lap.PadCenter(15, "Nilai Transfer") + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                }
                #endregion

                Nomor = dr["Nomor"].ToString().Trim();
                AsalTransfer = dr["AsalTransfer"].ToString().Trim();
                Bank = dr["Bank"].ToString().Trim();
                TglBank = ((DateTime)dr["TglBank"]).ToString("dd-MMM-yyyy").Trim();
                TglTransfer = ((DateTime)dr["TglTransfer"]).ToString("dd-MMM-yyyy").Trim();

                Jumlah = double.Parse(dr["Nominal"].ToString());
                sumJumlah = sumJumlah + Jumlah;
                //tempJumlah = Jumlah.ToString("#,##0");

                lap.PROW(true, 1, lap.PrintVerticalLine() + dr["Nomor"].ToString().Trim().PadRight(10) + dr["AsalTransfer"].ToString().ToUpper().PadRight(20).Substring(0, 20) + lap.SPACE(1)
                    + dr["NamaBank"].ToString().PadRight(11).Substring(0, 11) + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["TglBBM"]))
                    + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["TglTransfer"])) + Jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
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
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                        sumJumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(sumJumlah).PadRight(83) + lap.PrintVerticalLine());
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
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Pembukuan) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Mengetahui)
                        + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Kasir) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Penyetor) + ")" +
                        lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                        + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());

                    lap.PROW(true, 1, String.Format("{0:yyyyMMddhh:mm:ss}", DateTime.Now) + " " + SecurityManager.UserName);
                    lap.Eject();

                }



                #endregion

            }

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_TransferBank_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)dt.Rows[0]["NPrint"] + 1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("BBK.txt", lap.GenerateString());
            //lap.SendToPrinter("BBK.txt");

        }
        private void gridUtm_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            
            //cmdDelete.Enabled = false;
            cmdPrint.Enabled = true;
        }

        private void gridDetail_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            //cmdDelete.Enabled = true;
            cmdPrint.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridUtm_Leave(object sender, EventArgs e)
        {
            
        }

      
    }
}
