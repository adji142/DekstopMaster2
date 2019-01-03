using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.ArusStock
{
    public partial class frmAntarGudang : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        string RowIDheader;
        DataTable dtag;

        #region "Var&   "
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        //for Header
        Guid _RowID;
        Guid _Rowid;
        string _DrGudang, _KeGudang,_RecordID;
        string sflag = "";
        string RecordID_="";

        //for Detail
        Guid _RowIDD,_HeaderIDD;


        #region "Function"
        private void FillHeader()
        {
            _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _RecordID = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            _DrGudang = dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString();
            _KeGudang=dataGridHeader.SelectedCells[0].OwningRow.Cells["KeGudang"].Value.ToString();
        }

        private Boolean ChekGudang()
            {
            Boolean T=false;

            if (_DrGudang==GlobalVar.Gudang)
            {
                T=true;
            }

            if (_KeGudang==GlobalVar.Gudang)
            {
                T=true;
            }

            return T;
            }

        private void FillDetail()
        {
            _HeaderIDD = _RowID;
            _RowIDD = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
           
        }

        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridHeader.DataSource = dt;
                }

                if (dataGridDetail.SelectedCells.Count > 0)
                {
                    RefreshDetail();
                }
                else
                {
                    dataGridDetail.DataSource = null;
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
                _HeaderIDD = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridDetail.DataSource = dt;
                    
                }
                //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["KeGudang"].Value.ToString() == GlobalVar.Gudang)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        if (dataGridDetail.Rows[i].Cells["QtyTerima"].Value.ToString() == "0")
                //        {

                //        }
                //    }
                //}
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


        private void DisplayReport(DataTable dtA)
        {

            ////construct parameter
            //// periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglDO.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rgbTglDO.ToDate.Value).ToString("dd/MM/yyyy"));
            //List<ReportParameter> rptParams = new List<ReportParameter>();
            //// rptParams.Add(new ReportParameter("Periode", periode));

            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptAntarGudangDO.rdlc", rptParams, dtA, "dsAntarGudang_Data");
            //ifrmReport.Show();

            int i = 0;
            BuildString ag = new BuildString();
            ag.FontCondensed(true);
            ag.LeftMargin(3);
            ag.PROW(true, 1, "BPB-AG");
            ag.PROW(true, 1, "Gud. Tujuan   : " + dtA.Rows[0]["KeGudang"].ToString() + ag.SPACE(50) +
                "No      : " + dtA.Rows[0]["NoAG"].ToString());
            ag.PROW(true, 1, "Gud. Pengirim : " + dtA.Rows[0]["DrGudang"].ToString() + ag.SPACE(50) +
                "Tanggal : " + dtA.Rows[0]["TglKirim"].ToString());
            ag.PROW(true, 1, ag.PrintTopLeftCorner() + ag.PrintHorizontalLine(128) + ag.PrintTopRightCorner());
            ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PadCenter(5, "NO") + ag.PrintVerticalLine() +
                ag.PadCenter(110, "NAMA BARANG") + ag.PrintVerticalLine() + ag.PadCenter(5, "SAT") + ag.PrintVerticalLine() +
                ag.PadCenter(5, "QTY") + ag.PrintVerticalLine());
            ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PrintHorizontalLine(128) + ag.PrintVerticalLine());

            foreach (DataRowView dr in dtA.DefaultView)
            {
                i++;
                ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PadCenter(5, i.ToString()) + ag.PrintVerticalLine() +
                dr["NamaStok"].ToString().PadRight(110) + ag.PrintVerticalLine() + ag.PadCenter(5, dr["Satuan"].ToString()) + ag.PrintVerticalLine() +
                dr["QtyDO"].ToString().PadLeft(5) + ag.PrintVerticalLine());
            }
            ag.PROW(true, 1, ag.PrintBottomLeftCorner() + ag.PrintHorizontalLine(128) + ag.PrintBottomRightCorner());
            ag.PROW(true, 1, ag.PadCenter(30, "Gudang") + ag.SPACE(20) + ag.PadCenter(30, "Checker 1") + ag.SPACE(20) +
                ag.PadCenter(30, "Checker 2"));
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "(" + ag.SPACE(28) + ")" + ag.SPACE(20) + "(" + ag.SPACE(28) + ")" + ag.SPACE(20) +
                "(" + ag.SPACE(28) + ")");
            ag.Eject();
            ag.SendToPrinter("notaJual.txt");
        }

        private void PrintOut()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtA = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_AntarGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                    dtA = db.Commands[0].ExecuteDataTable();
                    DisplayReport(dtA);
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


        private void DisplayReport2(DataTable dtA)
        {

            ////construct parameter
            //// periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglDO.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rgbTglDO.ToDate.Value).ToString("dd/MM/yyyy"));
            //List<ReportParameter> rptParams = new List<ReportParameter>();
            //// rptParams.Add(new ReportParameter("Periode", periode));

            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptAntarGudangNota.rdlc", rptParams, dtA, "dsAntarGudang_Data");
            //ifrmReport.Show();

            int i = 0;
            BuildString ag = new BuildString();
            ag.FontCondensed(true);
            ag.LeftMargin(3);
            ag.PROW(true, 1, "BPB-AG");
            ag.PROW(true, 1, "Gud. Tujuan   : " + dtA.Rows[0]["KeGudang"].ToString() + ag.SPACE(50) +
                "No      : " + dtA.Rows[0]["NoAG"].ToString());
            ag.PROW(true, 1, "Gud. Pengirim : " + dtA.Rows[0]["DrGudang"].ToString() + ag.SPACE(50) +
                "Tanggal : " + dtA.Rows[0]["TglKirim"].ToString());
            ag.PROW(true, 1, ag.PrintTopLeftCorner() + ag.PrintHorizontalLine(128) + ag.PrintTopRightCorner());
            ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PadCenter(5, "NO") + ag.PrintVerticalLine() +
                ag.PadCenter(110, "NAMA BARANG") + ag.PrintVerticalLine() + ag.PadCenter(5, "SAT") + ag.PrintVerticalLine() +
                ag.PadCenter(5, "QTY") + ag.PrintVerticalLine());
            ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PrintHorizontalLine(128) + ag.PrintVerticalLine());

            foreach (DataRowView dr in dtA.DefaultView)
            {
                i++;
                ag.PROW(true, 1, ag.PrintVerticalLine() + ag.PadCenter(5, i.ToString()) + ag.PrintVerticalLine() +
                dr["NamaStok"].ToString().PadRight(110) + ag.PrintVerticalLine() + ag.PadCenter(5, dr["Satuan"].ToString()) + ag.PrintVerticalLine() +
                dr["QtyKirim"].ToString().PadLeft(5) + ag.PrintVerticalLine());
            }
            ag.PROW(true, 1, ag.PrintBottomLeftCorner() + ag.PrintHorizontalLine(128) + ag.PrintBottomRightCorner());
            ag.PROW(true, 1, ag.PadCenter(30, "Gudang") + ag.SPACE(20) + ag.PadCenter(30, "Checker 1") + ag.SPACE(20) +
                ag.PadCenter(30, "Checker 2"));
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "");
            ag.PROW(true, 1, "(" + ag.SPACE(28) + ")" + ag.SPACE(20) + "(" + ag.SPACE(28) + ")" + ag.SPACE(20) +
                "(" + ag.SPACE(28) + ")");
            ag.Eject();
            ag.SendToPrinter("notaJual.txt");
        }

        private void PrintOut2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtA = new DataTable();
                using (Database db = new Database())
                {
                   
                    db.Commands.Add(db.CreateCommand("rsp_AntarGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyKirim", SqlDbType.Int, 0));
                    dtA = db.Commands[0].ExecuteDataTable();
                }
                if (dtA.Rows.Count==0)
                {
                    MessageBox.Show("No Data !!!");
                    return;
                }
                DisplayReport2(dtA);
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
        #endregion
    #endregion

        public frmAntarGudang()
        {
            InitializeComponent();
        }

        private void frmAntarGudang_Load(object sender, EventArgs e)
        {
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            selectedGrid = enumSelectedGrid.HeaderSelected;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
            if (GlobalVar.Gudang != "2803")
            {
                this.cmdCreateDo.Visible = false;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                cmdSearch.PerformClick();
            }
            
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                RowIDheader = dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                //MessageBox.Show(RowIDheader.ToString());
            }
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                FillDetail();
            }
        }

        public void Edit()
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        if (ChekGudang() != false)
                        {

                            try
                            {
                                DateTime dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                if ((DateTime)dtAG <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                FillHeader();
                                ArusStock.frmAntarGudangUpdate ifrmChild = new ArusStock.frmAntarGudangUpdate(this, _RowID);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                            catch (System.Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hanya Untuk Gudang " + _DrGudang + " Atau " + _KeGudang, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    if (dataGridDetail.SelectedCells.Count > 0)
                    {
                        if (ChekGudang() != false)
                        {
                            try
                            {
                                DateTime? dtAG = new DateTime();
                                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString() == GlobalVar.Gudang)
                                {
                                    dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                }
                                else
                                {
                                    dtAG = (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == "") ? DateTime.Now : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                                }

                                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["KeGudang"].Value.ToString() == GlobalVar.Gudang)
                                {
                                    dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;

                                }

                                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1")
                                {
                                    if (!SecurityManager.AskPasswordManager())
                                    {
                                        return;
                                    }
                                }

                                FillDetail();

                                ArusStock.frmAntarGudangDetailUpdate ifrmChild = new ArusStock.frmAntarGudangDetailUpdate(this, _RowIDD, _HeaderIDD);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                            catch (System.Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Hanya Untuk Gudang " + _DrGudang + " Atau " + _KeGudang, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                    break;
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
             if (dataGridHeader.SelectedCells.Count>0)
             {
                if(e.KeyCode ==Keys.F3)
                {
                    if (!SecurityManager.IsAuditor())
                    {
                        PrintOut();
                    }
                }

                 else if (e.KeyCode==Keys.F4)
                 {
                     if (!SecurityManager.IsAuditor())
                     {
                         PrintOut2();
                     }
                 }
                 else if (e.KeyCode == Keys.Insert)
                 {
                    cmdAdd_Click(sender, new EventArgs());
                 }
                 else if (e.KeyCode == Keys.Delete)
                 {
                     cmdDelete_Click(sender, new EventArgs());
                 }
                 else if (e.KeyCode == Keys.Space)
                 {
                     cmdEdit_Click(sender, new EventArgs());
                 }
             }
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDetail();
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.Rows.Count > 0)
                        {

                            CommunicatorISA.AntarGudangDownload ifrmChild = new CommunicatorISA.AntarGudangDownload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            cmdDownload.Visible = false;
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.SelectedCells.Count > 0)
                        {
                            CommunicatorISA.frmAntarGudangUpload ifrmChild = new CommunicatorISA.frmAntarGudangUpload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string filter = string.Empty;
                DataTable dtBarcode = new DataTable();
                using (
                   Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("USP_AntarGudangBarcode"));
                    db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, txtBarcode.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@HEADER", SqlDbType.VarChar, RowIDheader));
                    dtBarcode = db.Commands[0].ExecuteDataTable();
                }

                if (dtBarcode.Rows.Count > 0)
                {
                    dataGridDetail.DataSource = dtBarcode;
                    Edit();
                    txtBarcode.Focus();
                }
                else
                {
                    MessageBox.Show("BARANG TIDAK DITEMUKAN..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarcode.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.Rows.Count > 0)
                        {
                            Communicator.frmAntargudangUpload ifrmChild = new Communicator.frmAntargudangUpload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.Rows.Count > 0)
                        {

                            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count >= 1)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["KeGudang"].Value.ToString() == GlobalVar.Gudang)
                {
                    if (dataGridDetail.Rows[e.RowIndex].Cells["QtyTerima"].Value.ToString() == "0")
                        dataGridDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        dataGridDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (dataGridHeader.SelectedCells.Count > 0 || dataGridHeader.SelectedCells.Count == 0)
                    {
                        ArusStock.frmAntarGudangUpdate ifrmChild = new ArusStock.frmAntarGudangUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString(), GlobalVar.Gudang) != 0)
                        {
                            MessageBox.Show("Hanya Untuk Gudang " + dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString());
                            return;
                        }

                        if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString(), "True") == 0)
                        {
                            {
                                MessageBox.Show("Data sudah diupload !, Tidak bisa tambah detail barang..");
                                return;
                            }
                            /*if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }*/
                        }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                            if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            ArusStock.frmAntarGudangDetailUpdate ifrmChild = new ArusStock.frmAntarGudangDetailUpdate(this, _RowID, _RecordID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                    RefreshDetail();
                    dataGridDetail.Focus();
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString(), "True") == 0)
            {
                MessageBox.Show("Data sudah diupload !, Tidak bisa diedit..");
                return;
            }
            Edit();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //Sudah diupload tidak boleh dihapus
            if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString(), "True") == 0)
            {
                MessageBox.Show("Data sudah diupload !, Tidak bisa dihapus..");
                return;
            }
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        int row = 0;
                        row = dataGridDetail.Rows.Count;
                        if (row > 0)
                        {
                            MessageBox.Show("Hapus Detail Terlebih Dahulu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                            dataGridDetail.Focus();
                            return;
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                DateTime? dtAG = new DateTime();
                                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString() == GlobalVar.Gudang)
                                {
                                    dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                }
                                else
                                {
                                    dtAG = (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == "") ? DateTime.Now : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                                }
                                GlobalVar.LastClosingDate = (DateTime)dtAG;
                                if ((DateTime)dtAG <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                int i = 0;
                                int n = 0;
                                i = dataGridHeader.SelectedCells[0].RowIndex;
                                n = dataGridHeader.SelectedCells[0].ColumnIndex;
                                DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                                DataRow dr = dv.Row;

                                dr.Delete();

                                dataGridHeader.RefreshEdit();
                                if (dataGridHeader.RowCount > 0)
                                {
                                    if (i == 0)
                                    {
                                        dataGridHeader.CurrentCell = dataGridHeader.Rows[0].Cells[n];
                                        dataGridHeader.RefreshEdit();
                                    }
                                    else
                                    {
                                        dataGridHeader.CurrentCell = dataGridHeader.Rows[i - 1].Cells[n];
                                        dataGridHeader.RefreshEdit();
                                    }
                                }
                                dataGridHeader.Focus();
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
                    break;

                case enumSelectedGrid.DetailSelected:
                    if (dataGridDetail.SelectedCells.Count > 0)
                    {
                        if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString(), GlobalVar.Gudang) != 0)
                        {
                            MessageBox.Show("Hanya Untuk Gudang " + dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                            dataGridDetail.Focus();  
                            return;
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                DateTime? dtAG = new DateTime();
                                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString() == GlobalVar.Gudang)
                                {
                                    dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                }
                                else
                                {
                                    dtAG = (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == "") ? DateTime.Now : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                                }
                                GlobalVar.LastClosingDate = (DateTime)dtAG;
                                if ((DateTime)dtAG <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }

                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDD));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                int i = 0;
                                int n = 0;
                                i = dataGridDetail.SelectedCells[0].RowIndex;
                                n = dataGridDetail.SelectedCells[0].ColumnIndex;

                                DataRowView dv = (DataRowView)dataGridDetail.SelectedCells[0].OwningRow.DataBoundItem;
                                DataRow dr = dv.Row;

                                dr.Delete();
                                dataGridDetail.Focus();

                                if (dataGridDetail.RowCount > 0)
                                    {
                                    if (i == 0)
                                    {
                                        dataGridDetail.CurrentCell = dataGridDetail.Rows[0].Cells[n];
                                        dataGridDetail.RefreshEdit();
                                        dataGridDetail.Focus();
                                    }
                                    else
                                    {
                                        dataGridDetail.CurrentCell = dataGridDetail.Rows[i - 1].Cells[n];
                                        dataGridDetail.RefreshEdit();
                                        dataGridDetail.Focus();
                                    }
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

                    }
                    break;
            }
        }


        private void cmdUpload_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.Rows.Count > 0)
                        {
                            Communicator.frmAntargudangUpload ifrmChild = new Communicator.frmAntargudangUpload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }

        private void cmdDownload_Click_1(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        if (dataGridHeader.Rows.Count > 0)
                        {
                            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.DetailSelected:
                    {
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridDetail_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            if (dataGridDetail.Rows.Count > 0)
            {
                if (dataGridDetail.SelectedCells.Count > 0)
                    dataGridDetail.CurrentCell = dataGridDetail.Rows[dataGridDetail.CurrentRow.Index].Cells[0];
            }

        }

        private void dataGridHeader_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridHeader.Rows.Count > 0)
            {
                if (dataGridHeader.SelectedCells.Count > 0)
                    dataGridHeader.Rows[dataGridHeader.CurrentRow.Index].Cells[0].Selected = true;
            }
        }

        private void cmdCreateDo_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                //tutup sementara
                if (validasi())
                {
                    MessageBox.Show("AG ini sudah di create menjadi DO/NOTA");
                    return;
                }

                string inpos = "0";

                DataTable dtag = new DataTable();
                try
                {
                    _Rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    _HeaderIDD = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        //db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_CreateDO_LIST"));
                        db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_CreateDO2803_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                        dtag = db.Commands[0].ExecuteDataTable();
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

                if (dtag.Rows.Count > 0)
                {
                    RecordID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

                    DO.FrmDO2803 ifrmChild = new DO.FrmDO2803(dtag);
                    ifrmChild.ShowDialog();
                    if (ifrmChild.DialogResult == DialogResult.OK)
                    {
                        UpdateFlag();
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang akan dijadikan Do/Nota");
                }
            }
            else
            {
                MessageBox.Show("Data Header masih kosong");
                return;
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (GlobalVar.Gudang == "2803")
                {
                    if (dataGridHeader.Rows[e.RowIndex].Cells["Expedisi"].Value.ToString().Trim() == "1")
                        dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    else
                        dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }


        private bool validasi()
        {
            Boolean lcek;
            string RecID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            DataTable dtg = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_CekDoNota_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, RecID_));
                    dtg = db.Commands[0].ExecuteDataTable();
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

            int nCek = Convert.ToInt32(Tools.isNull(dtg.Rows.Count, 0).ToString());
            if (nCek > 0)
                lcek = true;
            else
                lcek = false;

            return lcek;
        }


        private void UpdateFlag()
        {
            if (validasi())
            {
                DataTable dtf = new DataTable();
                try
                {
                    Guid _Rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_CreateDO_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
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
                cmdSearch.PerformClick();
                FindHeader("RecordID", RecordID_);
            }
        }
    }
}
