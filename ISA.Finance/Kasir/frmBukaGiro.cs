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


namespace ISA.Finance.Kasir
{
    public partial class frmBukaGiro : ISA.Finance.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable _dtBBK=new DataTable(), _dtGiroIn=new DataTable();
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        Guid _rowIDBBK, _rowIDGiroIn, _GiroID, _rowIDBank;
        string _Penerima, _bankID, _namaBank, _CairTolak;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        public frmBukaGiro()
        {
            InitializeComponent();
        }

        private void frmBukaGiro_Load(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;
            tbRange.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            tbRange.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            RefreshBBK();
        }

        public void RefreshBBK()
        {
            _fromDate = (DateTime)tbRange.FromDate;
            _toDate = (DateTime)tbRange.ToDate;
            

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _dtBBK = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    _dtBBK = Class.BBK.ListBBK(db,_fromDate, _toDate, Guid.Empty);
                }


                
                    
                    gridBBK.DataSource = _dtBBK;
                    if (_dtBBK.Rows.Count > 0)
                        RefreshGiroInternal();
                    else
                    {
                        
                        _dtGiroIn.Clear();
                        gridGiroIn.DataSource = _dtGiroIn;
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

        public void RefreshBBK(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                dtRefresh = BBK.ListBBK(db, RowID);
            }
            gridBBK.RefreshDataRow(dtRefresh.Rows[0], "RowIDBBK", RowID.ToString());
        }
        public void FindRowBBK(string column, string value)
        {
            gridBBK.FindRow(column, value);
        }

        public void RefreshGiroInternal()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _dtGiroIn = new DataTable();
                _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBK", SqlDbType.UniqueIdentifier, _rowIDBBK));                    
                    _dtGiroIn = db.Commands[0].ExecuteDataTable();
                }


                gridGiroIn.DataSource = _dtGiroIn;

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

        public void RefreshGiroInternal(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST_ByRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowIDGiroIn", SqlDbType.UniqueIdentifier, RowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();                
            }
            gridGiroIn.RefreshDataRow(dtRefresh.Rows[0], "RowIDGiroIn", RowID.ToString());
        }

        public void FindRowGiroIn(string column, string value)
        {
            gridGiroIn.FindRow(column, value);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshBBK();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridBBK_SelectionChanged(object sender, EventArgs e)
        {
            if (gridBBK.SelectedCells.Count > 0)
            {
                if (gridBBK.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshGiroInternal();
                }
                prevGrid1Row = gridBBK.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
            }
        }

       

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:                    
                    Kasir.frmBuktiBankKeluar ifrmChild = new Kasir.frmBuktiBankKeluar(this);
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                break;

                case enumSelectedGrid.DetailSelected:
                DateTime _Tanggal = (DateTime)gridBBK.SelectedCells[0].OwningRow.Cells["TglBBK"].Value;
                if (GlobalVar.Gudang != "2808")
                {
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                }

                _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                _Penerima = gridBBK.SelectedCells[0].OwningRow.Cells["Penerima"].Value.ToString();
                _bankID = gridBBK.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                DateTime tglBBK = (DateTime)gridBBK.SelectedCells[0].OwningRow.Cells["TglBBK"].Value;
                Kasir.frmBukaGiroDetailUpdate ifrmDetail = new Kasir.frmBukaGiroDetailUpdate(this,_rowIDBBK,_Penerima,_bankID,true,tglBBK);
                    Program.MainForm.RegisterChild(ifrmDetail);
                    ifrmDetail.ShowDialog();


                break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            DateTime _Tanggal = (DateTime)gridBBK.SelectedCells[0].OwningRow.Cells["TglBBK"].Value;
            if (GlobalVar.Gudang != "2808")
            {
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
            }

            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:

                    _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                    _bankID = gridBBK.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                    Kasir.frmBuktiBankKeluar ifrmChild = new Kasir.frmBuktiBankKeluar(this,_rowIDBBK,_bankID);
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                    break;

                case enumSelectedGrid.DetailSelected:
                    _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                    _rowIDGiroIn = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["RowIDGiroIn"].Value;
                    _GiroID = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                    _Penerima = gridBBK.SelectedCells[0].OwningRow.Cells["Penerima"].Value.ToString();
                    _bankID = gridBBK.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                    DateTime tglBBK = (DateTime)gridBBK.SelectedCells[0].OwningRow.Cells["TglBBK"].Value;
                    Kasir.frmBukaGiroDetailUpdate ifrmDetail = new Kasir.frmBukaGiroDetailUpdate(this,_rowIDBBK,_rowIDGiroIn,_GiroID,_Penerima,_bankID, true, tglBBK);
                    Program.MainForm.RegisterChild(ifrmDetail);
                    ifrmDetail.ShowDialog();


                    break;
            }
        }


        private void GetInfoBank()
        {
            DataTable dt = new DataTable();
            _bankID = gridBBK.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Bank_LIST"));

                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, _bankID));
                dt = db.Commands[0].ExecuteDataTable();
                _rowIDBank = (Guid)dt.Rows[0]["RowID"];                
            }



        }


        private void GetInfoGiroInternal()
        {
            DataTable dt = new DataTable();
            _rowIDGiroIn = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["RowIDGiroIn"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST_ByRowID"));

                db.Commands[0].Parameters.Add(new Parameter("@RowIDGiroIn", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                dt = db.Commands[0].ExecuteDataTable();
            }
            
            _CairTolak = Tools.isNull(dt.Rows[0]["CairTolak"], "").ToString();
            _GiroID = (Guid)Tools.isNull(dt.Rows[0]["GiroID"], "");


        }


        private void DeleteGiroInternal()
        {
            GetInfoBank();
            GetInfoGiroInternal();
            _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {
                

                db.BeginTransaction();
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_DELETE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                db.Commands[0].ExecuteNonQuery();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, _CairTolak));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));

                db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, _GiroID));                
                db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, _rowIDBank));                
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();                               
                db.CommitTransaction();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DateTime _Tanggal = (DateTime)gridBBK.SelectedCells[0].OwningRow.Cells["TglBBK"].Value;
            if (GlobalVar.Gudang != "2808")
            {
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
            }

            if (selectedGrid == enumSelectedGrid.DetailSelected)
            {
                if (gridGiroIn.SelectedCells.Count > 0)
                {

                    try
                    {
                        if (MessageBox.Show("Data Ini Akan Dihapus ?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                        _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                        DeleteGiroInternal();
                        RefreshBBK(_rowIDBBK);
                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = gridGiroIn.SelectedCells[0].RowIndex;
                        n = gridGiroIn.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)gridGiroIn.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        _dtGiroIn.AcceptChanges();
                        gridGiroIn.Focus();
                        gridGiroIn.RefreshEdit();
                        if (gridGiroIn.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                gridGiroIn.CurrentCell = gridGiroIn.Rows[0].Cells[n];
                                gridGiroIn.RefreshEdit();
                            }
                            else
                            {
                                gridGiroIn.CurrentCell = gridGiroIn.Rows[i - 1].Cells[n];
                                gridGiroIn.RefreshEdit();
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
            else
            {
                if (gridBBK.SelectedCells.Count > 0)
                {
                    Guid rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    if ((int)_dtGiroIn.Compute("count(Nomor)", "") > 0)
                    {
                        MessageBox.Show("Masih ada detail");
                        return;
                    }

                    if (MessageBox.Show("Data Ini Akan Dihapus?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                BBK.DeleteBBK(db, rowIDBBK);
                            }



                            #region "Tambahan"
                            int i = 0;
                            int n = 0;
                            i = gridBBK.SelectedCells[0].RowIndex;
                            n = gridBBK.SelectedCells[0].ColumnIndex;
                            DataRowView dv = (DataRowView)gridBBK.SelectedCells[0].OwningRow.DataBoundItem;

                            DataRow dr = dv.Row;

                            dr.Delete();
                            _dtBBK.AcceptChanges();
                            gridBBK.Focus();
                            gridBBK.RefreshEdit();
                            if (gridBBK.RowCount > 0)
                            {
                                if (i == 0)
                                {
                                    gridBBK.CurrentCell = gridBBK.Rows[0].Cells[n];
                                    gridBBK.RefreshEdit();
                                }
                                else
                                {
                                    gridBBK.CurrentCell = gridBBK.Rows[i - 1].Cells[n];
                                    gridBBK.RefreshEdit();
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


        private void PrintLaporan(DataTable dt)
        {
            BuildString lap = new BuildString();

            string typePrinter = lap.GetPrinterName();
            //string NamaBank = Tools.isNull(dt.Rows[0]["Bank"], "").ToString();
            string NoBBK = Tools.isNull(dt.Rows[0]["NoBBK"], "").ToString().Trim();
            string TglBBK = ((DateTime)dt.Rows[0]["TglBBK"]).ToString("dd-MMM-yyyy").Trim();
            string Pembukuan = Tools.isNull(dt.Rows[0]["Dibukukan"], "").ToString().Trim();
            string Mengetahui = Tools.isNull(dt.Rows[0]["Diketahui"], "").ToString().Trim();
            string Kasir = Tools.isNull(dt.Rows[0]["Kasir"], "").ToString().Trim();
            string Penerima = Tools.isNull(dt.Rows[0]["Penerima"], "").ToString().Trim();
            string Nomor = string.Empty;
            string NamaBank = string.Empty;
            string TglGiro = string.Empty;
            string TglJth = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempJumlah = string.Empty;
            int i=0;

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
            //lap.PROW(true, 1, "[VOUCHER BUKA GIRO]");
            //lap.DoubleWidth(false);
            //lap.FontCondensed(true);
            //lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(64)+lap.PrintTTOp()+ lap.PrintHorizontalLine(63)+ lap.PrintTopRightCorner());
            
            //lap.PROW(true, 1, lap.PrintVerticalLine() + "Dibayarkan Kepada: ".PadRight(64) + lap.PrintVerticalLine()+ ("Nomor  : " + NoBBK).PadRight(63) + lap.PrintVerticalLine());

            //lap.PROW(true, 1, lap.PrintVerticalLine() + Penerima.PadRight(64) + lap.PrintVerticalLine()+ "Tanggal:  " + TglBBK.PadRight(20) + "Hal     :" + hal.ToString() + "/" + ttlHal.ToString().PadRight(22) + lap.PrintVerticalLine());

            //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(64) + lap.PrintTBottom() + lap.PrintHorizontalLine(63) + lap.PrintTRight());
            //lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(15,"Nomor") + lap.PadCenter(51,"Bank") +  lap.PadCenter(21,"Tgl.Giro") +  lap.PadCenter(21,"Tgl.JT") +  lap.PadCenter(20,"Nilai Tranfer")+ lap.PrintVerticalLine());
            //lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(128) + lap.PrintTRight());

            bool cetak = true;

            foreach (DataRow dr in dt.Rows)
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
                    lap.PROW(true, 1, "[VOUCHER BUKA GIRO]");
                    lap.DoubleWidth(false);

                    lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp() + lap.PrintHorizontalLine(41) + 
                        lap.PrintTopRightCorner());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "Dibayarkan Kepada: ".PadRight(41) + lap.PrintVerticalLine() + 
                        ("Nomor  : " + NoBBK).PadRight(41) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + Penerima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal: " + 
                        TglBBK).PadRight(30) + ("Hal : " + hal.ToString() + "/" + ttlHal.ToString()).PadRight(11) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom() + lap.PrintHorizontalLine(41) + 
                        lap.PrintTRight());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(15, "Nomor") + lap.PadCenter(27, "Nama Bank") + 
                        lap.PadCenter(13, "Tgl.Giro") + lap.PadCenter(13, "Tgl.JT") + lap.PadCenter(15, "Nilai Tranfer") + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                }
                #endregion


                Nomor = dr["Nomor"].ToString().Trim();
                NamaBank = dr["Bank"].ToString().Trim();
                TglGiro = ((DateTime)dr["TglGiro"]).ToString("dd-MMM-yyyy").Trim();
                TglJth = ((DateTime)dr["TglJth"]).ToString("dd-MMM-yyyy").Trim();

                Jumlah = double.Parse(dr["Nominal"].ToString());
                sumJumlah = sumJumlah + Jumlah;
                tempJumlah = Jumlah.ToString("#,##0");

                lap.PROW(true, 1, lap.PrintVerticalLine() + Nomor.PadRight(15)+NamaBank.PadRight(27)+lap.PadCenter(13,TglGiro)+lap.PadCenter(13,TglJth)+
                    tempJumlah.PadLeft(15) + lap.PrintVerticalLine());                 
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
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." + sumJumlah.ToString("#,##0").PadLeft(15) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(sumJumlah).PadRight(83) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) +
                        lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());


                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                         + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penerima") + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine() + lap.SPACE(20) + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Pembukuan) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Mengetahui) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Kasir) + ")"
                        + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Penerima) + ")" + lap.PrintVerticalLine());
                    lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) +
                        lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintRightBottomCorner2());


                    lap.PROW(true, 1, String.Format("{0:yyyyMMddhh:mm:ss}", DateTime.Now)+" "+SecurityManager.UserName);
                    lap.Eject();

                }

                #endregion
            }

                        
            lap.SendToPrinter("BBK.txt", lap.GenerateString());

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            int nprint = (int)gridBBK.SelectedCells[0].OwningRow.Cells["NPrint"].Value;
            if (nprint > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
            {
                MessageBox.Show(Messages.Error.ConfirmPasswordNotMatch);
                return;
            }
            try
            {
                _rowIDBBK = (Guid)gridBBK.SelectedCells[0].OwningRow.Cells["RowIDBBK"].Value;
                DataTable dtLaporan = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_VoucherBukaGiro_CETAK"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBK", SqlDbType.UniqueIdentifier, _rowIDBBK));
                    dtLaporan = db.Commands[0].ExecuteDataTable();
                    PrintLaporan(dtLaporan);

                    db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                    db.Commands[1].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, nprint + 1));
                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[1].ExecuteNonQuery();
                }

                RefreshBBK(_rowIDBBK);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void gridBBK_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            cmdDelete.Enabled = false;
        }

        private void gridGiroIn_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            cmdDelete.Enabled = true;
        }

        public void refreshDeleteGiroIn()
        {
            #region "Tambahan"
            int i = 0;
            int n = 0;
            i = gridGiroIn.SelectedCells[0].RowIndex;
            n = gridGiroIn.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)gridGiroIn.SelectedCells[0].OwningRow.DataBoundItem;

            DataRow dr = dv.Row;

            dr.Delete();
            _dtGiroIn.AcceptChanges();
            gridGiroIn.Focus();
            gridGiroIn.RefreshEdit();
            if (gridGiroIn.RowCount > 0)
            {
                if (i == 0)
                {
                    gridGiroIn.CurrentCell = gridGiroIn.Rows[0].Cells[n];
                    gridGiroIn.RefreshEdit();
                }
                else
                {
                    gridGiroIn.CurrentCell = gridGiroIn.Rows[i - 1].Cells[n];
                    gridGiroIn.RefreshEdit();
                }

            }
            #endregion
        }



    }
}
