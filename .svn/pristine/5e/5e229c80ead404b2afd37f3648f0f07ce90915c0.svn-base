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
    public partial class frmBukuBankBrowse : ISA.Finance.BaseForm
    {
        DataTable dtBank, dtBankDetail;
        enum selectMode { header, detail };
        selectMode mode;
        DateTime _fromDate, _toDate;
        public frmBukuBankBrowse()
        {
            InitializeComponent();
        }

        

        private void frmBukuBankBrowse_Load(object sender, EventArgs e)
        {
            mode = selectMode.header;
            cmdPrint.Enabled = false;
            dtBankDetail = new DataTable();
            rdRK.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rdRK.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            HeaderRefresh();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (mode == selectMode.header)
            {
                frmBukuBankUpdate frm = new frmBukuBankUpdate(this);
                frm.ShowDialog();
            }
            else
            {
                Guid rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                frmBukuBankUpdate frm = new frmBukuBankUpdate(this, rowID, dtBank);
                frm.ShowDialog();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (mode == selectMode.header)
            {
                Guid rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                frmBukuBankUpdate frm = new frmBukuBankUpdate(this, rowID);
                frm.ShowDialog();
            }
            else
            {
                Guid rowID, rowIDDetail;
                string noBBK, noBGCH, Debet, Kredit, keterangan;
                DateTime tglBank, tglRK;
                DateTime _Tanggal = (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglBank"].Value;
                if (GlobalVar.Gudang != "2808")
                {
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                }

                rowID= (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                rowIDDetail = (Guid)dgDetailBank.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                noBBK = dgDetailBank.SelectedCells[0].OwningRow.Cells["NoBBKD"].Value.ToString();
                noBGCH = dgDetailBank.SelectedCells[0].OwningRow.Cells["NoBGCH"].Value.ToString();
                Debet = dgDetailBank.SelectedCells[0].OwningRow.Cells["Debet"].Value.ToString();
                Kredit = dgDetailBank.SelectedCells[0].OwningRow.Cells["Kredit"].Value.ToString();
                keterangan = dgDetailBank.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
                tglBank = (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglBank"].Value;
                tglRK = (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglRK"].Value; 

                frmBukuBankUpdate frm = new frmBukuBankUpdate(this, rowID, rowIDDetail,noBBK,noBGCH,tglBank,tglRK,keterangan, Debet,Kredit);
                frm.ShowDialog();
            }
        }


        public void HeaderRefresh()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtBank = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Bank_List"));
                    dtBank = db.Commands[0].ExecuteDataTable();
                }

                
                    dtBank.DefaultView.Sort = "NamaBank";
                    dgHeaderBank.DataSource = dtBank.DefaultView;
                    if (dtBank.Rows.Count > 0)
                        DetailRefresh();
                    else
                    {
                        dtBankDetail.Clear();
                        dgDetailBank.DataSource = dtBankDetail.DefaultView;
                    }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                dgHeaderBank.Focus();
            }
        }

        public void HeaderRefresh(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Bank_LIST_ByRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            dgHeaderBank.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
        }

        public void DetailRefresh()
        {
            Guid rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
            _fromDate = (DateTime)rdRK.FromDate;
            _toDate = (DateTime)rdRK.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtBankDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BankDetail_List_ByTglBank"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtBankDetail = db.Commands[0].ExecuteDataTable();
                }

                dtBankDetail.DefaultView.Sort = "tglBank desc, RecordID desc";
                //dtBankDetail.DefaultView.Sort = "tglBank desc, LastUpdatedTime desc";
                dgDetailBank.DataSource = dtBankDetail.DefaultView;
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

        public void DetailRefresh(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_BankDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dgDetailBank.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            }
        }

        public void HeaderFindRow(string column, string value)
        {
            dgHeaderBank.FindRow(column, value);
            DetailRefresh();
            dgHeaderBank.Focus();
            mode = selectMode.header;
            cmdPrint.Enabled = false;
        }

        public void DetailFindRow(string column, string value)
        {
            dgDetailBank.FindRow(column, value);
            dgDetailBank.Focus();
            mode = selectMode.detail;
            cmdPrint.Enabled = true;
        }

        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region cetak laporan
        public void cetakLaporan()
        {
            if ((int.Parse(dgDetailBank.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0) && (!SecurityManager.IsManager()))
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }


            
            string Keterangan, NoBBK, TglBank, NoBGCH, NamaBank, TglRK, Nilai, Kasir, jnsTran, Tanggal;
            string txtJudul, txtKeterangan, txtNamaBank, txtPenerima;

            Guid _rowID = (Guid)dgDetailBank.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Keterangan= dgDetailBank.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString().Trim();
            NamaBank = dgHeaderBank.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString().Trim();
            Tanggal = String.Format("{0:dd-MMM-yyyy}", (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglBank"].Value);
            TglBank = String.Format("{0:dd-MMM-yyyy}",(DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglBank"].Value);
            NoBBK = dgDetailBank.SelectedCells[0].OwningRow.Cells["NoBBKD"].Value.ToString().Trim();
            NoBGCH = dgDetailBank.SelectedCells[0].OwningRow.Cells["NoBGCH"].Value.ToString().Trim();
            TglRK = String.Format("{0:dd-MMM-yyyy}", (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglRK"].Value);
            jnsTran = dgDetailBank.SelectedCells[0].OwningRow.Cells["JnsTran"].Value.ToString().Trim();
            Kasir = SecurityManager.UserID;

            if (jnsTran == "BBM")
            {
                txtJudul = "BUKTI BANK MASUK";
                txtKeterangan = "Diterima dari : ";
                txtNamaBank = "Asal Transfer";
                txtPenerima = "Penyetor";
                Nilai = String.Format("{0:0,0}",Convert.ToDouble(dgDetailBank.SelectedCells[0].OwningRow.Cells["Debet"].Value));
                
            }
            else
            {
                txtJudul = "BUKTI BANK KELUAR";
                txtKeterangan = "Dibayar kepada : ";
                txtNamaBank = "Transfer Ke";
                txtPenerima = "Penerima";
                Nilai = String.Format("{0:0,0}",Convert.ToDouble(dgDetailBank.SelectedCells[0].OwningRow.Cells["Kredit"].Value));
            }

            try
            {
                BuildString lap = new BuildString();
                lap.Initialize();

                lap.PageLLine(33);
                lap.LeftMargin(1);
                lap.FontCPI(12);
                lap.LineSpacing("1/6");
                lap.DoubleWidth(true);
                lap.PROW(true, 1, txtJudul);
                lap.DoubleWidth(false);

                lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                lap.PROW(true, 1, lap.PrintVerticalLine() + txtKeterangan.PadRight(41) +
                    lap.PrintVerticalLine() + ("Nomor   : " + NoBBK).PadRight(41) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + Keterangan.PadRight(41).Substring(0, 41) + lap.PrintVerticalLine() + ("Tanggal : " +
                    Tanggal).PadRight(30) + "Hal : 1/1".PadRight(11)  + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(15, "Nomor") + lap.PadCenter(16, txtNamaBank) + lap.SPACE(1) + lap.PadCenter(10, "Bank")
                    + lap.PadCenter(13, "Tgl Bank") + lap.PadCenter(13, "Tgl Trf") + lap.PadCenter(15, "Nilai Transfer") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                lap.PROW(true, 1, lap.PrintVerticalLine() + NoBGCH.PadRight(15) + NamaBank.ToString().ToUpper().PadRight(16).Substring(0,16) + lap.SPACE(1) + "".PadRight(10) +
                    lap.PadCenter(13,TglBank) + lap.PadCenter(13,TglRK) 
                    + Nilai.PadLeft(15) + lap.PrintVerticalLine());
                    

                    for (int j = 0; j < 9; j++)
                    {
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                    }
               

                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                    Nilai.PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + ISA.Common.Tools.Terbilang(Convert.ToDouble(Nilai)).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, txtPenerima) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, Kasir) + ")" + lap.PrintVerticalLine() + "(" + lap.SPACE(18) + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, "::  "+String.Format("{0:yyyyMMddhh:mm:ss}", DateTime.Now) + " " + SecurityManager.UserName);
                lap.Eject();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBankDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                //DetailRefresh(_rowID);
                DetailRefresh();
                DetailFindRow("RowID", _rowID.ToString());
                lap.SendToPrinter("laporanPS.txt");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            cetakLaporan();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin menghapus data ini?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Guid rowIDDetail, headerIDBank1, _LinkTransferBankID;
                    string noBBK, noBGCH;

                    rowIDDetail = (Guid)dgDetailBank.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    headerIDBank1 = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                    if (dgDetailBank.SelectedCells[0].OwningRow.Cells["LinkTransferBankID"].Value.ToString() == "")
                        _LinkTransferBankID = Guid.Empty;
                    else
                        _LinkTransferBankID = (Guid)dgDetailBank.SelectedCells[0].OwningRow.Cells["LinkTransferBankID"].Value;
                    noBBK = dgDetailBank.SelectedCells[0].OwningRow.Cells["noBBKD"].Value.ToString();
                    noBGCH = dgDetailBank.SelectedCells[0].OwningRow.Cells["noBGCH"].Value.ToString();

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.BeginTransaction();
                        Bank.DeleteBankDetail(db, rowIDDetail, headerIDBank1, _LinkTransferBankID, noBGCH.Substring(0, 3), noBBK);
                        db.CommitTransaction();
                    }

                    HeaderRefresh(headerIDBank1);
                    //HeaderFindRow("RowIDH", headerIDBank1.ToString());

                    #region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = dgDetailBank.SelectedCells[0].RowIndex;
                    n = dgDetailBank.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgDetailBank.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dtBankDetail.AcceptChanges();
                    dgDetailBank.Focus();
                    dgDetailBank.RefreshEdit();
                    if (dgDetailBank.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgDetailBank.CurrentCell = dgDetailBank.Rows[0].Cells[n];
                            dgDetailBank.RefreshEdit();
                        }
                        else
                        {
                            dgDetailBank.CurrentCell = dgDetailBank.Rows[i - 1].Cells[n];
                            dgDetailBank.RefreshEdit();
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

        private void cmdTB_Click(object sender, EventArgs e)
        {
            frmTransaksiBankBrowse frm = new frmTransaksiBankBrowse();
            frm.ShowDialog();
        }

        private void cmdGiro_Click(object sender, EventArgs e)
        {
            string _bankID=dgHeaderBank.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
            frmGiroInternal frm = new frmGiroInternal(this, _bankID);
            frm.ShowDialog();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DetailRefresh();
        }

        private void dgHeaderBank_Enter(object sender, EventArgs e)
        {
            mode = selectMode.header;
            cmdPrint.Enabled = false;
            cmdDelete.Enabled = false;
            cmdRecalculate.Enabled = true;
        }

        private void dgHeaderBank_SelectionChanged(object sender, EventArgs e)
        {
            if(dgHeaderBank.SelectedCells.Count>0)
                DetailRefresh();
        }

        private void dgDetailBank_Enter(object sender, EventArgs e)
        {
            mode = selectMode.detail;
            cmdPrint.Enabled = true;
            cmdRecalculate.Enabled = false;
        }

        private void cmdRecalculate_Click(object sender, EventArgs e)
        {
            if (dgHeaderBank.SelectedCells.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid _rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("psp_Bank_Reproses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));

                        db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.Commands[1].ExecuteNonQuery();
                        db.CommitTransaction();

                    }

                    HeaderRefresh(_rowID);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dgHeaderBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Guid rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                string namaBank = dgHeaderBank.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString();
                string noAccount = dgHeaderBank.SelectedCells[0].OwningRow.Cells["NoAccount"].Value.ToString();

                Kasir.Report.frmRptBankRekonsiliasi frm = new ISA.Finance.Kasir.Report.frmRptBankRekonsiliasi(this, rowID, namaBank, noAccount);
                frm.ShowDialog();
            }
            else
            if (e.KeyCode == Keys.F4)
            {
                Guid rowID = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                string namaBank = dgHeaderBank.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString();
                string noRek = dgHeaderBank.SelectedCells[0].OwningRow.Cells["NoAccount"].Value.ToString();
                string jnsRek = dgHeaderBank.SelectedCells[0].OwningRow.Cells["JRek"].Value.ToString();

                Kasir.Report.frmRptBukuBank frm = new ISA.Finance.Kasir.Report.frmRptBukuBank(this, rowID, namaBank, noRek,jnsRek);
                frm.ShowDialog();
            }

        }

        private void dgDetailBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgDetailBank.SelectedCells.Count>0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            Guid rowID_ = (Guid)dgDetailBank.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            DateTime dtg = (DateTime)dgDetailBank.SelectedCells[0].OwningRow.Cells["TglRK"].Value;

                            frmBukuBank_UPDATE_Tgl ifrmChild = new frmBukuBank_UPDATE_Tgl(this, dtg, rowID_);
                            ifrmChild.ShowDialog();
                            if (ifrmChild.DialogResult== DialogResult.OK)
                            {

                                dgDetailBank.SelectedCells[0].OwningRow.Cells["TglRK"].Value = ifrmChild.TglRK;
                                dgDetailBank.RefreshEdit();
                                dtBankDetail.AcceptChanges();
                            }
                        }
                        break;
                }
            }
        }

        
    }
}
