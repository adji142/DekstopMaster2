using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace ISA.Finance.Kasir
{
    public partial class frmBuktiTransferMasuk : ISA.Finance.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dt = new DataTable();
        string PrnAktif = "0";

        public frmBuktiTransferMasuk()
        {
            InitializeComponent();
        }

        private void frmBuktiTransferMasuk_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            gridUtm.AutoGenerateColumns = false;
            gridDetail.AutoGenerateColumns = false;
            RefreshBuktiTransfer();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshBuktiTransfer();
        }

        private void RefreshBuktiTransfer()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluar_LIST"));
                    dtHeader = Class.TransferBank.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, "M");
                    gridUtm.DataSource = dtHeader.DefaultView ;

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
        private void RefreshRowBuktiTransfer(Guid RowID)
        {
              DataTable dtRefresh = new DataTable();
              dtRefresh = Class.TransferBank.ListHeaderRow(RowID, "M");
              gridUtm.RefreshDataRow(dtRefresh.Rows[0],"RowID",RowID.ToString()); 
            
        }
        private void RefreshBuktiTransferDetail()
        {
            try
            {
                Guid rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluar_DETAIL"));
                    dtDetail = Class.TransferBank.ListDetail(db, rowID);
                    
                }
                gridDetail.DataSource = dtDetail.DefaultView;
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
                    RefreshBuktiTransferDetail();
                }
                prevGrid1Row = gridUtm.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
               // gridDetail.DataSource = null;
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
            Guid rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            int nprint = (int)gridUtm.SelectedCells[0].OwningRow.Cells["NPrint"].Value;
            if (nprint > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
            {
                MessageBox.Show(Messages.Error.ConfirmPasswordNotMatch);
                return;
            }

            DataTable dtLaporan = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_BuktiTransferMasuk_CETAK"));
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
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                        db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BBM"));
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
                {
                    //MessageBox.Show("cetak DotMatrix");
                    PrintLaporan(dtLaporan);
                    RefreshRowBuktiTransfer(rowID);
                }
                else
                {
                    MessageBox.Show("cetak InkJet");
                    DisplayReport(dtLaporan);
                    //PrintLaporan(dtLaporan);
                    RefreshRowBuktiTransfer(rowID);
                }
            }
        }


        private void DisplayReport(DataTable dtLaporan)
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
            _Terbilang = ISA.Common.Tools.Terbilang(total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaBank", NamaBank));
            rptParams.Add(new ReportParameter("NoBBM", NoBBM));
            rptParams.Add(new ReportParameter("TglBBM", TglBBM));
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("Total", total.ToString()));
            rptParams.Add(new ReportParameter("Terbilang", _Terbilang));

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptCetakBBMbaru.rdlc", rptParams, dtLaporan, "dsBank_Data2");
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
            string TglBBM = ((DateTime)dt.Rows[0]["TglBBM"]).ToString("dd-MMM-yyyy").Trim();
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

            //lap.Initialize();
            //lap.PageLLine(33);
            //lap.LeftMargin(3);
            //lap.FontCPI(10);
            //lap.DoubleWidth(true);
            //lap.PROW(true, 1, "[Bukti Bank Masuk]");
            //lap.DoubleWidth(false);
            //lap.FontCondensed(true);
            //lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(128) + lap.PrintTopRightCorner());
            //lap.PROW(false, 63, lap.PrintTTOp());
            //lap.PROW(true, 1, lap.PrintVerticalLine() + "Diterima Dari: ".PadRight(61) + lap.PrintVerticalLine());
            //lap.PROW(false, 65, "Nomor  : " + NoBBM.PadRight(57) + lap.PrintVerticalLine());
            //lap.PROW(true, 1, lap.PrintVerticalLine() + NamaBank.PadRight(61) + lap.PrintVerticalLine());
            //lap.PROW(false, 65, "Tanggal: " + TglBBM.PadLeft(10) + lap.SPACE(3) + "Hal : " + hal.ToString() + "/" + ttlHal.ToString().PadRight(36) + lap.PrintVerticalLine());
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

                    lap.PROW(true, 1, "[Bukti Bank Masuk]");
                    lap.DoubleWidth(false);
                    

                    lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                        + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "Diterima Dari: ".PadRight(41) +
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

                lap.PROW(true, 1, lap.PrintVerticalLine() + Nomor.PadRight(10) + AsalTransfer.ToUpper().PadRight(20).Substring(0, 20) + lap.SPACE(1)
                    + dr["NamaBank"].ToString().PadRight(11).Substring(0, 11) + lap.PadCenter(13, TglBank)
                    + lap.PadCenter(13, TglTransfer) + Jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());

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
            
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_TransferBank_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)dt.Rows[0]["NPrint"] + 1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("BBM.txt", lap.GenerateString());
            //lap.SendToFile("BBM.txt");
        }
    }
}
