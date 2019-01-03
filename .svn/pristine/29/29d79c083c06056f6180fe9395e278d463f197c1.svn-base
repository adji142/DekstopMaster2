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

namespace ISA.Toko.Kasir
{
    public partial class frmGiroCairTolakBatal : ISA.Controls.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        Guid _bbmID;
        DataTable _dtDetail = new DataTable();
        DataTable _dtHeader = new DataTable();
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;


        public frmGiroCairTolakBatal()
        {
            InitializeComponent();
        }




        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiroCairTolakBatal_Load(object sender, EventArgs e)
        {
            //rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            rangeDateBox1.FromDate = DateTime.Today;
            rangeDateBox1.ToDate = DateTime.Today;
            RefreshBBM();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshBBM();
        }

        public void RefreshBBM()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _dtHeader = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_BBM_GiroTolakCair_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    _dtHeader = db.Commands[0].ExecuteDataTable();                                        
                    
                }

                if (_dtHeader.Rows.Count > 0)
                {
                    gridBBM.DataSource = _dtHeader;
                    RefreshGiro();
                }
                else
                {
                    gridBBM.DataSource = null;
                    gridGiro.DataSource = null;
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

        public void RefreshBBM(Guid bbmID)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt1 = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                   
                    db.Commands.Add(db.CreateCommand("usp_BBM_GiroTolakCair_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BBMID", SqlDbType.UniqueIdentifier,bbmID));                    
                    dt1 = db.Commands[0].ExecuteDataTable();

                    if (dt1.Rows.Count > 0)
                    {
                        gridBBM.DataSource = _dtHeader;
                        gridBBM.RefreshDataRow(dt1.Rows[0], "RowID", bbmID.ToString());
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

        public void RefreshGiro()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _dtDetail = new DataTable();
                _bbmID = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;                                
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Giro_CairTolakBatal"));
                    db.Commands[0].Parameters.Add(new Parameter("@BBMID", SqlDbType.UniqueIdentifier, _bbmID));
                    _dtDetail = db.Commands[0].ExecuteDataTable();
                    
                }
                gridGiro.DataSource = _dtDetail;
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

        public void RefreshGiro(Guid giroID)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //_dtDetail = new DataTable();
                DataTable dtRefresh;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Giro_CairTolakBatal"));
                    db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, giroID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();

                }
                //gridGiro.DataSource = dtRefresh;

                if (dtRefresh.Rows.Count > 0)
                {
                    gridGiro.DataSource = _dtDetail;
                    gridGiro.RefreshDataRow(dtRefresh.Rows[0], "RowIDGiro", giroID.ToString());
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


        public void findrowGiro(string column, string value)
        {
            gridGiro.FindRow2(column, value);
        }

        public void findRowBBM(string column,string value)
        {
            gridBBM.FindRow2(column, value);
        }

        private void gridBBM_SelectionChanged(object sender, EventArgs e)
        {
            if (gridBBM.SelectedCells.Count > 0)
            {
                if (gridBBM.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshGiro();
                }
                prevGrid1Row = gridBBM.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                gridGiro.DataSource = null;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                        Kasir.frmGiroCairTolakBatal_Header_Update ifrmChild1 = new Kasir.frmGiroCairTolakBatal_Header_Update(this);
                        Program.MainForm.RegisterChild(ifrmChild1);
                        ifrmChild1.ShowDialog();

            	    break;
                case enumSelectedGrid.DetailSelected:
                    try
                    {

                        DateTime _Tanggal = (DateTime)gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                        if (PeriodeClosing.IsKasirClosed(_Tanggal))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                        Guid bbmID = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Kasir.frmVoucherTitipanGiro ifrmChild2 = new Kasir.frmVoucherTitipanGiro(this, bbmID);
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }

        }
        

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            

            switch (selectedGrid)
            {
            case enumSelectedGrid.HeaderSelected:

                    if (gridBBM.SelectedCells.Count > 0)
                    {
                        DateTime _Tanggal = (DateTime)gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                        if (PeriodeClosing.IsKasirClosed(_Tanggal))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                    Guid rowID = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Kasir.frmGiroCairTolakBatal_Header_Update ifrmChild1 = new Kasir.frmGiroCairTolakBatal_Header_Update(this,rowID);
                    Program.MainForm.RegisterChild(ifrmChild1);
                    ifrmChild1.ShowDialog();
                    }
                                   

            	break;
            }
        }
        

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime tgl = ((DateTime)gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value).Date;
                DateTime tglServer = GlobalVar.DateOfServer.Date;

                if (tgl != tglServer)
                {
                    MessageBox.Show("Tanggal server tidak sama dengan tanggal transaksi. Tidak bisa hapus transaksi");
                    return;
                }

                switch (selectedGrid)
                {
                    case enumSelectedGrid.DetailSelected:

                        if (gridGiro.SelectedCells.Count > 0)
                        {
                            DateTime _Tanggal = (DateTime)gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                            if (PeriodeClosing.IsKasirClosed(_Tanggal))
                            {
                                MessageBox.Show("Sudah Closing!");
                                return;
                            }
                            if (!SecurityManager.IsManager())
                            {
                                MessageBox.Show("Hapus hanya boleh dilakukan oleh Manager");
                                return;
                            }
                            Guid rowIDBBM = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            Guid giroID = (Guid)gridGiro.SelectedCells[0].OwningRow.Cells["RowIDGiro"].Value;

                            if (MessageBox.Show("Data Ini Akan Dihapus?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DeleteGiroCairTolakBatal(rowIDBBM, giroID);

                                RefreshBBM(rowIDBBM);

                                #region "Tambahan"
                                int i = 0;
                                int n = 0;
                                i = gridGiro.SelectedCells[0].RowIndex;
                                n = gridGiro.SelectedCells[0].ColumnIndex;
                                DataRowView dv = (DataRowView)gridGiro.SelectedCells[0].OwningRow.DataBoundItem;

                                DataRow dr = dv.Row;

                                dr.Delete();
                                _dtDetail.AcceptChanges();
                                gridGiro.Focus();
                                gridGiro.RefreshEdit();
                                if (gridGiro.RowCount > 0)
                                {
                                    if (i == 0)
                                    {
                                        gridGiro.CurrentCell = gridGiro.Rows[0].Cells[n];
                                        gridGiro.RefreshEdit();
                                    }
                                    else
                                    {
                                        gridGiro.CurrentCell = gridGiro.Rows[i - 1].Cells[n];
                                        gridGiro.RefreshEdit();
                                    }

                                }
                                #endregion
                            }

                        }

                        break;

                    case enumSelectedGrid.HeaderSelected:
                        if (gridBBM.SelectedCells.Count > 0)
                        {

                            DateTime _Tanggal = (DateTime)gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value;
                            if (PeriodeClosing.IsKasirClosed(_Tanggal))
                            {
                                MessageBox.Show("Sudah Closing!");
                                return;
                            }
                            Guid rowIDBBM = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            //if ((int)_dtDetail.Compute("count(Nomor)", "") > 0)
                            //{
                            //    MessageBox.Show("Masih ada detail");
                            //    return;
                            //}

                            if (gridGiro.SelectedCells.Count > 0)
                            {
                                MessageBox.Show("Sudah ada record di detail, tidak bisa hapus record. Silahkan hapus record detail terlebih dahulu");
                                return;
                            }

                            if (!SecurityManager.IsManager())
                            {
                                MessageBox.Show("Hapus hanya boleh dilakukan oleh Manager");
                                return;
                            }

                            if (MessageBox.Show("Data Ini Akan Dihapus?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    using (Database db = new Database(GlobalVar.DBFinance))
                                    {
                                        BBM.DeleteBBM(db, rowIDBBM);
                                    }



                                    #region "Tambahan"
                                    int i = 0;
                                    int n = 0;
                                    i = gridBBM.SelectedCells[0].RowIndex;
                                    n = gridBBM.SelectedCells[0].ColumnIndex;
                                    DataRowView dv = (DataRowView)gridBBM.SelectedCells[0].OwningRow.DataBoundItem;

                                    DataRow dr = dv.Row;

                                    dr.Delete();
                                    _dtHeader.AcceptChanges();
                                    gridBBM.Focus();
                                    gridBBM.RefreshEdit();
                                    if (gridBBM.RowCount > 0)
                                    {
                                        if (i == 0)
                                        {
                                            gridBBM.CurrentCell = gridBBM.Rows[0].Cells[n];
                                            gridBBM.RefreshEdit();
                                        }
                                        else
                                        {
                                            gridBBM.CurrentCell = gridBBM.Rows[i - 1].Cells[n];
                                            gridBBM.RefreshEdit();
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
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
 


     private void DeleteGiroCairTolakBatal(Guid rowIDBBM, Guid giroID)
     {
         
         try
         {
             using (Database db = new Database(GlobalVar.DBFinance))
             {
                 db.Commands.Add(db.CreateCommand("usp_Giro_CairTolakBatal_DELETE"));
                 db.Commands[0].Parameters.Add(new Parameter("@RowIDBBM", SqlDbType.UniqueIdentifier, rowIDBBM));
                 db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, giroID));
                 db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                 db.Commands[0].ExecuteNonQuery();

             }
         }
         catch (Exception ex)
         {
             Error.LogError(ex);
         }
     }


     #region CETAK GIRO
     private void cetakGiro(DataTable dtGiro, string CT)
     {

         double total = 0, jumlah;
         string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan, _judul, _tgl="", _h2="";
         
         Guid _RowID = (Guid)gridBBM.SelectedCells[0].OwningRow.Cells["RowID"].Value;
         _Terima = gridBBM.SelectedCells[0].OwningRow.Cells["NamaBank"].Value.ToString();
         _NoBukti = gridBBM.SelectedCells[0].OwningRow.Cells["NoBBM"].Value.ToString();
         _Tanggal = String.Format("{0:dd-MMM-yyyy}",gridBBM.SelectedCells[0].OwningRow.Cells["TglBBM"].Value);
         _Kasir = gridBBM.SelectedCells[0].OwningRow.Cells["Kasir"].Value.ToString();
         _mengetahui = gridBBM.SelectedCells[0].OwningRow.Cells["Diketahui"].Value.ToString();
         _pembukuan = gridBBM.SelectedCells[0].OwningRow.Cells["Dibukukan"].Value.ToString();

         BuildString lap = new BuildString();
         

         if (CT == "C")
         {
             _judul = "[BUKTI BANK MASUK]";
             _tgl = "Tgl. Cair";
             _h2 = "Diterima Oleh :";
         }
         else if(CT == "T")
         
         {
             _judul = "[VOUCHER GIRO TOLAK]";
             _tgl = "Tgl. Tolak";
             _h2 = "Dikeluarkan Oleh :";
         }
         else 
         {
             _judul = "[GIRO BATAL TITIP]";
             _tgl = "Tgl. Batal";
             _h2 = "Dikeluarkan Oleh :";
         }

         int i = 0, j = 1;
         int n = dtGiro.Rows.Count;
         int jmlhal = n / 10;
         int y = 0;
         total = Convert.ToDouble(dtGiro.Compute("Sum(Nominal)", ""));

         if (n % 10 >0)
         {
                jmlhal += 1;
         }

         while (j <= jmlhal)
         {


             lap.Initialize();

             lap.PageLLine(33);
             lap.LeftMargin(1);
             lap.FontCPI(12);
             lap.LineSpacing("1/6");
             lap.DoubleWidth(true);
             lap.PROW(true, 1, _judul);
             lap.DoubleWidth(false);


             lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
             lap.PROW(true, 1, lap.PrintVerticalLine() + _h2.PadRight(41) +
                 lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
             lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                 _Tanggal).PadRight(30) + ("Hal : " + j.ToString() + " / " + jmlhal.ToString()).PadRight(11) + lap.PrintVerticalLine());
             lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                 + lap.PrintHorizontalLine(41) + lap.PrintTRight());
             lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(8, "No. Giro") + lap.PadCenter(20, "Asal Giro") + lap.SPACE(1)
                 + lap.PadCenter(13, "Bank Asal") + lap.PadCenter(13, "Tgl. Giro") + lap.PadCenter(13, "Tgl. J/Tempo")
                 + lap.PadCenter(15, "Nilai Giro Rp") + lap.PrintVerticalLine());
             lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
             y = 0;
             while (i < n && y < 10)
             {
                 jumlah = Convert.ToDouble(dtGiro.Rows[i]["Nominal"].ToString());
                 
                 lap.PROW(true, 1, lap.PrintVerticalLine() + dtGiro.Rows[i]["Nomor"].ToString().Trim().PadRight(8) + dtGiro.Rows[i]["AsalGiro"].ToString().Trim().ToUpper().PadRight(20).Substring(0, 20)
                        + lap.SPACE(1) + dtGiro.Rows[i]["NamaBankGiro"].ToString().Trim().PadRight(13).Substring(0, 13) + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["TglGiro"]))
                        + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dtGiro.Rows[i]["TglCair"])) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    
                 i++;
                 y++;
             }


             j++;

             if (i == n && i % 10 != 0)
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
             lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
             lap.Eject();


         }
         using (Database db = new Database(GlobalVar.DBFinance))
         {
             db.Commands.Add(db.CreateCommand("rsp_CetakBBM"));
             db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
             db.Commands[0].ExecuteNonQuery();
         }
         lap.SendToPrinter("laporan.txt");
     }
     #endregion

     private void gridBBM_KeyDown(object sender, KeyEventArgs e)
     {
         if (e.KeyCode == Keys.F12)
         {
             DataTable dtC = new DataTable();
             DataTable dtT = new DataTable();
             dtC = _dtDetail.Copy();
             dtC.DefaultView.RowFilter = "SUBSTRING(BGC,3,1)='C'";
             if (dtC.DefaultView.Count > 0)
                 cetakGiro(dtC.DefaultView.ToTable(), "C");

             dtT = _dtDetail.Copy();
             dtT.DefaultView.RowFilter = "SUBSTRING(BGC,3,1)='T'";
             if (dtT.DefaultView.Count > 0)
                 cetakGiro(dtT.DefaultView.ToTable(), "T");
         }
     }

     private void gridBBM_Enter(object sender, EventArgs e)
     {
         selectedGrid = enumSelectedGrid.HeaderSelected;
         gridBBM_SelectionChanged(sender, e);
         cmdPrint.Enabled = true;
     }

     private void gridGiro_Enter(object sender, EventArgs e)
     {
         selectedGrid = enumSelectedGrid.DetailSelected;
         cmdPrint.Enabled = false;
     }

     private void cmdPrint_Click(object sender, EventArgs e)
     {
         if (gridBBM.SelectedCells.Count > 0)
         {
             DataTable dtC = new DataTable();
             DataTable dtT = new DataTable();
             DataTable dtB = new DataTable();
             dtC = _dtDetail.Copy();
             dtC.DefaultView.RowFilter = "SUBSTRING(BGC,3,1)='C'";
             if (dtC.DefaultView.Count > 0)
                 cetakGiro(dtC.DefaultView.ToTable(), "C");

             dtT = _dtDetail.Copy();
             dtT.DefaultView.RowFilter = "SUBSTRING(BGC,3,1)='T'";
             if (dtT.DefaultView.Count > 0)
                 cetakGiro(dtT.DefaultView.ToTable(), "T");

             dtB = _dtDetail.Copy();
             dtB.DefaultView.RowFilter = "SUBSTRING(BGC,3,1)='B'";
             if (dtT.DefaultView.Count > 0)
                 cetakGiro(dtT.DefaultView.ToTable(), "B");
         }
     }

     private void gridGiro_CellContentClick(object sender, DataGridViewCellEventArgs e)
     {

     }

 
    }
}
