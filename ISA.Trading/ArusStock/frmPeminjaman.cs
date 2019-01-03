using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;

namespace ISA.Trading.ArusStock
{

    public partial class frmPeminjaman : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

    #region "Var"
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        //For Header
        Guid _RowID;
        string _RecordID, _NamaSales, _StaffPenjualan,_NoBukti;
        string _TglPinjam, _TglKembali;
        //For Detail
        int _Print;
        Guid _RowIDD, _HeaderIDD;
       
    #endregion

    #region "Procedure & Function"  

        public void FillHeader()
        {
            DateTime a, b;           
            _RowID = (Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _RecordID = dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            _NamaSales = dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            a = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
            b = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglBatas"].Value;
            _Print=Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value);
            _TglPinjam = a.ToString("dd/MM/yyyy");

            _TglKembali = b.ToString("dd/MM/yyyy");
            _NoBukti = dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
            _StaffPenjualan = dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["StaffPenjualan"].Value.ToString();
        }

        public void FillDetail()
        {
            _HeaderIDD = _RowID;
            _RowIDD = (Guid)dataGridPeminjamanDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
        }
        
        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtP = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Peminjaman_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtP = db.Commands[0].ExecuteDataTable();
                    dtP.DefaultView.Sort="RecordID ASC";
                    this.dataGridPeminjaman.DataSource = dtP;

                }

                if (dataGridPeminjaman.SelectedCells.Count > 0)
                {
                    RefreshDetail();
                }
                else
                {
                    dataGridPeminjamanDetail.DataSource = null;
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

        public void RefreshDetail()
        {
            try
            {

                _HeaderIDD = (Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtPD = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dtPD = db.Commands[0].ExecuteDataTable();
                    dtPD.DefaultView.Sort = "RecordID ASC";
                    this.dataGridPeminjamanDetail.DataSource = dtPD;
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

        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            //string periode;
           // periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglDO.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rgbTglDO.ToDate.Value).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
           // rptParams.Add(new ReportParameter("Periode", periode));
           
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptMemoPeminjamanBarang.rdlc", rptParams, dt, "dsPinjam_Data");
            ifrmReport.Show();

        }

        private void PrintOut()
        {
            try
            {
            _HeaderIDD=(Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.Cursor=Cursors.WaitCursor;
            using (Database db = new Database())
                {
                    DataTable dtPD=new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Peminjaman"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtPD=db.Commands[0].ExecuteDataTable();
                    dtPD.Dispose();
                    db.Dispose();

                    //DisplayReport(dtPD);
                    PrintRawMemoPeminjaman(dtPD);
                }
            }
            catch(Exception ex)
            {
            Error.LogError(ex);
            }
            finally
            {
            this.Cursor=Cursors.Default;
            }
        }

        private void PrintRawMemoPeminjaman(DataTable dt)
        {
            BuildString memo = new BuildString();

            string sales = dt.Rows[0]["Sales"].ToString().PadRight(23);
            string tglKeluar = DateTime.Parse(dt.Rows[0]["TglKeluar"].ToString()).ToString("dd-MMM-yyyy");
            string tglBatas = DateTime.Parse(dt.Rows[0]["TglBatas"].ToString()).ToString("dd-MMM-yyyy");
            string noBukti = dt.Rows[0]["NoBukti"].ToString();
            string penjamin = dt.Rows[0]["Penjamin"].ToString().PadRight(10);
            int No=0;

            memo.Initialize();
            memo.PageLLine(33);
            memo.FontCPI(12);
            memo.Append(Convert.ToString((char)27)+Convert.ToString((char)33)+Convert.ToString((char)1));
            memo.PROW(true, 1, memo.PadCenter(88,"MEMO PEMINJAMAN BARANG"));
            memo.PROW(true, 1, "");
            memo.PROW(true, 1, "Nama salesman : " + sales + memo.SPACE(12) + "Tanggal pinjam        : " +  tglKeluar);
            memo.PROW(true, 1, "Nomor pinjam  : " + noBukti.PadRight(10) + memo.SPACE(25) + "Batas tanggal pinjam  : " +  tglBatas);
            memo.PROW(true, 1, "Penjamin      : " + penjamin);
            memo.PROW(true, 1, memo.PrintEqualSymbol(88));
            memo.PROW(true, 1, "No                                   Nama Barang                            Pinjam Kirim");
            memo.PROW(true, 1, memo.PrintMinusSymbol(88));
            
            string namaStok = string.Empty;
            int qtyMemo = 0;

            foreach(DataRow dr in dt.Rows)
            {
                No++;
                namaStok = dr["NamaStok"].ToString().PadRight(73);
                qtyMemo = int.Parse(dr["QtyMemo"].ToString());

                memo.PROW(true, 1, No.ToString().PadLeft(2) + " " + namaStok + "  " + qtyMemo.ToString().PadLeft(3) + "   ...");
            }
            memo.PROW(true, 1, memo.PrintEqualSymbol(88));
            memo.PROW(true, 1, "");
            memo.PROW(true, 1, "");
            memo.PROW(true, 1, "");
            memo.PROW(true, 1, "      Ka.Gudang                Checker 1             Checker 2              Gudang");
            memo.Eject();

            memo.SendToPrinter("MemoPeminjaman.txt");
        }
    #endregion
   
       
        public frmPeminjaman()
        {
            InitializeComponent();
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void frmPeminjamanBarang_Load(object sender, EventArgs e)
        {
            this.dataGridPeminjaman.AutoGenerateColumns = false;
            this.dataGridPeminjamanDetail.AutoGenerateColumns = false;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            selectedGrid = enumSelectedGrid.HeaderSelected;
            rgbTglDO.ToDate = DateTime.Now;
            rgbTglDO.Focus();
            txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void DeleteData()
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:

                    if (dataGridPeminjaman.SelectedCells.Count > 0)
                    {
                        int rc;
                        rc = dataGridPeminjamanDetail.Rows.Count;
                        if (dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1")
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }
                        if (rc != 0)
                        {
                            MessageBox.Show("Hapus Detail Terlebih Dahulu !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                            return;
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                                if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_Peminjaman_Delete"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                this.RefreshHeader();
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
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    break;
                case enumSelectedGrid.DetailSelected:
                    if (dataGridPeminjamanDetail.SelectedCells.Count > 0)
                    {
                        if ((dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1") || Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0)
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                                if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_Delete"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDD));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                
                                this.RefreshHeader();
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
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }

                    break;
            }
        }

        private void dataGridPeminjaman_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridPeminjaman.SelectedCells.Count>0)
            {
                FillHeader();
            }
        }

        private void dataGridPeminjamanDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
           
            if (dataGridPeminjamanDetail.SelectedCells.Count>0)
            {
                FillDetail();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {

            switch (selectedGrid)
            {
            case enumSelectedGrid.HeaderSelected:
                    if (dataGridPeminjaman.SelectedCells.Count > 0||dataGridPeminjaman.SelectedCells.Count==0)
                    {
                        ArusStock.frmPeminjamanUpdate ifrmChild = new ArusStock.frmPeminjamanUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
            	break;
            case enumSelectedGrid.DetailSelected:
                try
                {
                    if (dataGridPeminjaman.SelectedCells.Count > 0)
                    {
                        GlobalVar.LastClosingDate=(DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                        if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        ArusStock.frmPeminjamanDetailUpdate ifrmChild = new ArusStock.frmPeminjamanDetailUpdate(this, _RowID, _RecordID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

                break;
            }
           
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridPeminjaman.SelectedCells.Count > 0)
                        {
                            if ((dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1") || _Print > 0)
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                            ArusStock.frmPeminjamanUpdate ifrmChild = new ArusStock.frmPeminjamanUpdate(this, _RowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridPeminjamanDetail.SelectedCells.Count > 0)
                        {
                            if ((dataGridPeminjamanDetail.SelectedCells[0].OwningRow.Cells["SyncFlagD"].Value.ToString() == "1") || _Print > 0)
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                            ArusStock.frmPeminjamanDetailUpdate ifrmChild = new ArusStock.frmPeminjamanDetailUpdate(this, _RowIDD, _HeaderIDD);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void dataGridPeminjaman_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPeminjaman.SelectedCells.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                    {
                        if (!SecurityManager.IsAuditor())
                        {
                            if (Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0)
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                            PrintOut();
                            RefreshHeader();
                        }
                        break;
                    }
                    case Keys.Delete:
                    {
                        if (!SecurityManager.IsAuditor())
                        {
                            DeleteData();
                        }
                        break;
                    }
                }
               
            }
        }

        private void dataGridPeminjamanDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if(dataGridPeminjamanDetail.SelectedCells.Count>0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                    {
                        DeleteData();
                        break;
                    }
                }
            }
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridPeminjaman.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridPeminjamanDetail.FindRow(columnName, value);
        }

        private void dataGridPeminjamanDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridPeminjaman_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridPeminjaman.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDetail();
            }
        }


    }
}
