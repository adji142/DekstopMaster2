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
using System.IO;
using ISA.Trading.Class;
using ISA.Trading;
using ISA.FTP;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using ISA.Pin;

namespace ISA.Trading.PO
{
    public partial class frmPO : ISA.Trading.BaseForm
    {

        DataTable dtH, dtD, dtJadwal, dtUploadHeader, dtUploadDetail;
       // DataSet dsResult = new DataSet();
        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;
        //DateTime _date;
        string hari;
        string _hFileName = "hpoctmp";
        string _dFileName = "dpoctmp";
        string FileNameReportPO = "LaporanAnalisaStockPO";
        Guid HeaderID_;
        string _dialogResult = "";
        bool DepoBaru = false;


        public frmPO()
        {
            InitializeComponent();
        }

        private void frmPO_Load(object sender, EventArgs e)
        {
            gvPOD.AutoGenerateColumns = false;
            gvPOH.AutoGenerateColumns = false;

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = " dd,MMMM,yyyy";
            dtpFrom.ShowUpDown = true;

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = " dd,MMMM,yyyy";
            dtpTo.ShowUpDown = true;

            //_date = dtpFrom.Value;
            txtTglPO.DateValue = GlobalVar.DateOfServer;

            RefreshHeader();
            //RefreshDetail();

        }

        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_POHeader_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtpFrom.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtpTo.Value));
                    dtH = db.Commands[0].ExecuteDataTable();
                }
                gvPOH.DataSource = dtH;
                if (dtH.Rows.Count > 0 && gvPOH.SelectedCells.Count > 0)
                {
                    HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    RefreshDetail(HeaderID_);

                }
                else
                {

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

        public void RefreshDetail(Guid headerRowID)
        {
            try
            {
  
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PODetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRowID", SqlDbType.UniqueIdentifier, headerRowID));
                    dtD = db.Commands[0].ExecuteDataTable();
                }
                gvPOD.DataSource = dtD;

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

        private void customGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void gvPOH_SelectionRowChanged(object sender, EventArgs e)
        {
            if (gvPOH.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                RefreshDetail(HeaderID_);

            }
        }

        public void gvPOH_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
            button1.Enabled = true;
            cmdUpload.Enabled = true;
            cmdDownload.Enabled = true;
            cmdPrint.Enabled = true;
            upload_dbf.Enabled = true;
        }

        //public void jadwal()
        //{

        //    using (Database db = new Database())
        //    {
        //        db.Commands.Clear();
        //        db.Commands.Add(db.CreateCommand("usp_POJadwalDetail"));
        //        db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
        //        dtJadwal = db.Commands[0].ExecuteDataTable();
        //        if (dtJadwal.Rows.Count > 0)
        //        {
        //            _jadwalpo = Tools.isNull(dtJadwal.Rows[0]["hari_po"].ToString(), "").ToString();
        //        }
        //    }
        //}

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        DateTime _tanggal = DateTime.Now;
                        datetoHari(_tanggal);
                        DataTable dtCekJadwalPO = CekJadwalPO();

                        if (dtCekJadwalPO.Rows.Count > 0)
                        {
                            DataTable dtp = new DataTable();
                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("fsp_lastdaypoheader"));
                                dtp = db.Commands[0].ExecuteDataTable();
                            }
                            if (Tools.isNull(dtp.Rows[0]["tanggal"], "").ToString() == "")
                            {
                                DepoBaru = true;
                            }

                            PO.frmPOAdd ifrmChild = new frmPOAdd(this);
                            ifrmChild.ShowDialog();
                            if (ifrmChild.DialogResult == DialogResult.OK)
                                _dialogResult = "OK";
                        }
                        else
                        {
                            DataTable dtJadwal = new DataTable();
                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_POJadwalDetail"));
                                db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                dtJadwal = db.Commands[0].ExecuteDataTable();
                            }

                            string _jadwalpo = Tools.isNull(dtJadwal.Rows[0]["hari_po"].ToString(), "").ToString();
                            if (MessageBox.Show("Jadwal PO " + GlobalVar.Gudang + " adalah hari " + _jadwalpo + " apakah mau dilanjut ? ", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                PO.frmPOAdd ifrmChild = new frmPOAdd(this);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                    _dialogResult = "OK";
                            }
                        }

                        #region tutup
                        //else
                        //{
                        //    using (Database db = new Database())
                        //    {
                        //        db.Commands.Clear();
                        //        db.Commands.Add(db.CreateCommand("usp_POJadwalDetail"));
                        //        db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        //        dtJadwal = db.Commands[0].ExecuteDataTable();
                        //    }
                        //    string _jadwalpo = Tools.isNull(dtJadwal.Rows[0]["hari_po"].ToString(), "").ToString();
                        //    if (MessageBox.Show("Jadwal pembuatan PO " + GlobalVar.Gudang + " adalah hari " + _jadwalpo + " apakah mau dilanjut ? ", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        PO.frmPOAdd ifrmChild = new frmPOAdd(this);
                        //        ifrmChild.ShowDialog();
                        //        if (ifrmChild.DialogResult == DialogResult.OK)
                        //            _dialogResult = "OK";
                        //        //ifrmChild.MdiParent = Program.MainForm;
                        //        //Program.MainForm.RegisterChild(ifrmChild);
                        //        //ifrmChild.Show();
                        //    }
                        //}
                        //PO.frmPOAdd ifrmChild = new frmPOAdd(this);
                        //ifrmChild.ShowDialog();
                        #endregion

                        if (_dialogResult == "OK" && DepoBaru == false)
                        {
                            if (gvPOH.SelectedCells.Count > 0)
                            {
                                Guid rowID = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                string idtr = Convert.ToString(gvPOH.SelectedCells[0].OwningRow.Cells["idtr"].Value.ToString());
                                bool Closing = true;

                                //DataTable dtCekCreatePO = CekCreatePO(rowID);

                                PO.frmGetDetailPO ifrmChild2 = new frmGetDetailPO(this, rowID, Closing, idtr);
                                ifrmChild2.ShowDialog();
                                if (ifrmChild2.DialogResult == DialogResult.No)
                                {
                                    HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                    RefreshDetail(HeaderID_);
                                    if (dtD.Rows.Count > 0)
                                    {
                                        MessageBox.Show("Tidak Dapat menghapus Data");
                                    }
                                    else
                                    {
                                        try
                                        {
                                            using (Database db = new Database())
                                            {
                                                DataTable dth = new DataTable();
                                                db.Commands.Add(db.CreateCommand("usp_POHeader_Delete"));
                                                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, HeaderID_));
                                                db.Commands[0].ExecuteNonQuery();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                    RefreshHeader();
                                    POFindRow("idtr", idtr);
                                }
                            }
                        }
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {
                            if (Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value, "").ToString() == "True")
                            {
                                MessageBox.Show("PO sudah diupload");
                                return;
                            }

                            string RowID_ = gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                            //Guid RowIDc = new Guid(gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                            //try
                            //{
                            //    DataTable dtc = new DataTable();
                            //    using (Database db = new Database())
                            //    {
                            //        db.Commands.Add(db.CreateCommand("usp_PODetailCek_List"));
                            //        db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, RowIDc));
                            //        dtc = db.Commands[0].ExecuteDataTable();
                            //        if (dtc.Rows.Count == 0)
                            //        {
                            //            MessageBox.Show("Gunakan Getdetail untuk PO ke HO");
                            //            return;
                            //        }
                            //    }
                            //}
                            //catch (System.Exception ex)
                            //{
                            //    Error.LogError(ex);
                            //}

                            DataTable dt = new DataTable();
                            dt = dt.Copy();
                            PO.frmPODetailAdd ifrmChild = new frmPODetailAdd(this, RowID_);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;
            }
        }

        private void gvPOD_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            cmdUpload.Enabled = false;
            cmdDownload.Enabled = false;
            cmdPrint.Enabled = false;
            upload_dbf.Enabled = true;
            dgS = enumSelectedGrid.Detail;
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            hapusData();
            RefreshHeader();
        }

        private void hapusData()
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {
                            if (Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value, "").ToString() == "True")
                            {
                                MessageBox.Show("PO sudah diupload");
                                return;
                            }

                            HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            RefreshDetail(HeaderID_);
                            if (dtD.Rows.Count > 0)
                            {
                                MessageBox.Show("Tidak Dapat menghapus Data");
                            }
                            else
                            {
                                //HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                //string NoPo_ = gvPOH.SelectedCells[0].OwningRow.Cells["noPO"].Value.ToString();
                                if (MessageBox.Show("Hapus Data : " + HeaderID_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        using (Database db = new Database())
                                        {
                                            DataTable dt = new DataTable();
                                            db.Commands.Add(db.CreateCommand("usp_POHeader_Delete"));
                                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, HeaderID_));
                                            db.Commands[0].ExecuteNonQuery();
                                        }
                                        MessageBox.Show("Record telah dihapus");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {
                            if (Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value, "").ToString() == "True")
                            {
                                MessageBox.Show("PO sudah diupload");
                                return;
                            }
                            if (gvPOD.SelectedCells.Count > 0)
                            {
                                Guid RowID_ = (Guid)gvPOD.SelectedCells[0].OwningRow.Cells["row_id"].Value;
                                if (MessageBox.Show("Hapus Data : " + RowID_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        using (Database db = new Database())
                                        {
                                            DataTable dt = new DataTable();
                                            db.Commands.Add(db.CreateCommand("usp_PODetail_Delete"));
                                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowID_));
                                            db.Commands[0].ExecuteNonQuery();
                                        }
                                        MessageBox.Show("Record telah dihapus");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid rowID;
            bool Closing_ = false;

            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    if (gvPOH.SelectedCells.Count > 0)
                    {
                        if (Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value, "").ToString() == "True")
                        {
                            MessageBox.Show("PO sudah diupload");
                            return;
                        }
                        rowID = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        PO.frmPOUpdate ifrmChild = new PO.frmPOUpdate(this, rowID, Closing_);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    if (gvPOD.SelectedCells.Count > 0)
                    {
                        if (Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value, "").ToString() == "True")
                        {
                            MessageBox.Show("PO sudah diupload");
                            return;
                        }
                        try
                        {
                            rowID = (Guid)gvPOD.SelectedCells[0].OwningRow.Cells["row_id"].Value;
                            PO.frmPODetailUpdate ifrmChild2 = new PO.frmPODetailUpdate(this, rowID, PO.frmPODetailUpdate.enumFormMode.Insert);
                            ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                    break;
            }
        }

        private void cetak(DataTable dt)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                string tt = string.Format("{0:dd-MMM-yyyy}", gvPOH.SelectedCells[0].OwningRow.Cells["tglPO"].Value);
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("tgl_po", tt.Contains("1900") ? "" : tt));
                rptParams.Add(new ReportParameter("no_po", dt.Rows[0]["no_po"].ToString()));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("PO.cetak.rptCetakPO.rdlc", rptParams, dt, "dsCetakPO_Detail");
                ifrmReport.Text = "Data Pegawai";
                ifrmReport.Show();
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Guid rowID;

            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (gvPOH.Rows.Count > 0)
                        {
                            Guid id = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("rsp_CetakPO"));
                                    db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, id));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show("Data tidak ada");
                                    return;
                                }
                                else
                                {
                                    cetak(dt);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOD.Rows.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mencetak Data dari Tabel Detail");
                        }

                    }
                    break;
            }
        }

        #region Useless
        //private DataSet CekArusStok()
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Clear();
        //        db.Commands.Add(db.CreateCommand("fsp_POCekArus"));
        //        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, _date));
        //        db.Commands[0].Parameters.Add(new Parameter("@gdng", SqlDbType.VarChar, GlobalVar.Gudang));
        //        dt = db.Commands[0].ExecuteDataTable();
        //    }

        //    DataTable dt1 = new DataTable();
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Clear();
        //        db.Commands.Add(db.CreateCommand("fsp_POPembelian"));
        //        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, _date));
        //        db.Commands[0].Parameters.Add(new Parameter("@kdgdg", SqlDbType.VarChar, GlobalVar.Gudang));
        //        dt1 = db.Commands[0].ExecuteDataTable();
        //    }

        //    DataTable dt2 = new DataTable();
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Clear();
        //        db.Commands.Add(db.CreateCommand("fsp_POPenjualan"));
        //        db.Commands[0].Parameters.Add(new Parameter("@Fromdate", SqlDbType.DateTime, _date));
        //        db.Commands[0].Parameters.Add(new Parameter("@kdgdg", SqlDbType.VarChar, GlobalVar.Gudang));
        //        dt2 = db.Commands[0].ExecuteDataTable();

        //    }

        //    if (dt.Rows.Count > 0 && dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
        //    {
        //        GenerateExcell(dt);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Masih ada transaksi yang bermasalah");
        //    }
        //    return ds;
        //}
        #endregion

        private DataSet CekArusStok()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("fsp_POCekArus"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@gdng", SqlDbType.VarChar, GlobalVar.Gudang));
                dt = db.Commands[0].ExecuteDataTable();
            }

            DataTable dt1 = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("fsp_POPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@kdgdg", SqlDbType.VarChar, GlobalVar.Gudang));
                dt1 = db.Commands[0].ExecuteDataTable();
            }

            DataTable dt2 = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("fsp_POPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@Fromdate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@kdgdg", SqlDbType.VarChar, GlobalVar.Gudang));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            ds.Tables.Add(dt);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);

            return ds;
        }

        private bool HasIncompleteData(DataSet ds)
        {
            int count = 0;
            foreach (DataTable dt in ds.Tables)
            {
                count += dt.Rows.Count;
            }

            return count > 0;
        }

        private bool HasValidPin(DataSet ds)
        {
            string createdKey = Generator.CreateKey(GlobalVar.Gudang, PinId.Bagian.UploadPO, GlobalVar.DateOfServer);
            StringBuilder keyDesc = new StringBuilder();
            keyDesc.AppendLine("PIN Upload PO:");


            if (ds.Tables[0].Rows.Count > 0)
            {
                keyDesc.AppendLine("- AG belum diterima atau Qty Kirim <> Qty Terima");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                keyDesc.AppendLine("- Order Pembelian belum menjadi Nota");
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                keyDesc.AppendLine("- Qty Tarikan <> Qty Gudang");
            }

            Pin.frmPinVerification ifrmChild = new Pin.frmPinVerification(createdKey, keyDesc.ToString());
            ifrmChild.ShowDialog(this);
            
            return ifrmChild.IsValid;
        }

        private void GenerateExcell(DataSet ds)
        {
            DateTime fromDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, 1);
            DateTime toDate = new DateTime(fromDate.Year, fromDate.Month, DateTime.DaysInMonth(fromDate.Year, fromDate.Month));

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN PO";

                // Laporan Antar Gudang
                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Antar Gudang"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 16;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 20;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 20;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 20;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 20;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 20;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 20;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 20;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 20;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 20;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 20;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 20;
                ws.Cells[1, 15].Worksheet.Column(15).Width = 20;
                ws.Cells[1, 16].Worksheet.Column(16).Width = 20;
                //ws.Cells[1, 17].Worksheet.Column(17).Width = 20;
                //ws.Cells[1, 18].Worksheet.Column(18).Width = 20;
                //ws.Cells[1, 19].Worksheet.Column(19).Width = 20;

                ws.Cells[1, 1].Value = "LAPORAN ANTAR GUDANG BELUM DITERIMA ATAU QTY KIRIM <> QTY TERIMA";
                ws.Cells[2, 1].Value = string.Format("Periode Kirim {0} s.d. {1}", fromDate.ToString("dd-MM-yyyy"), toDate.ToString("dd-MM-yyyy"));
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws.Cells[4, 1].Value = "KODE BARANG";
                ws.Cells[4, 2].Value = "DARI GUDANG";
                ws.Cells[4, 3].Value = "KE GUDANG";
                ws.Cells[4, 4].Value = "TANGGAL KIRIM";
                ws.Cells[4, 5].Value = "TANGGAL TERIMA";
                ws.Cells[4, 6].Value = "NO ANTAR GUDANG";
                ws.Cells[4, 7].Value = "PENGIRIM";
                ws.Cells[4, 8].Value = "PENERIMA";
                ws.Cells[4, 9].Value = "QUANTITY KIRIM";
                ws.Cells[4, 10].Value = "QUANTITY TERIMA";
                ws.Cells[4, 11].Value = "ONGKOS";
                ws.Cells[4, 12].Value = "QUANTITY DO";
                ws.Cells[4, 13].Value = "KE CEK 1";
                ws.Cells[4, 14].Value = "KE CEK 2";
                ws.Cells[4, 15].Value = "CATATAN";
                ws.Cells[4, 16].Value = "EXSPEDISI";
                //ws.Cells[4, 17].Value = "NOMOR KENDARAAN";
                //ws.Cells[4, 18].Value = "NAMA SOPIR";
                //ws.Cells[4, 19].Value = "ID KIRIM TERIMA";


                ws.Cells[4, 1, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[4, 1, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx = 5;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KodeBarang"];
                    ws.Cells[idx, 2].Value = dr["DrGudang"];
                    ws.Cells[idx, 3].Value = dr["KeGudang"]; 
                    ws.Cells[idx, 4].Value = string.Format("{0:dd MMMM yyyy}", dr["TglKirim"]);
                    ws.Cells[idx, 5].Value = string.Format("{0:dd MMMM yyyy}", dr["TglTerima"]);
                    ws.Cells[idx, 6].Value = dr["NoAG"];
                    ws.Cells[idx, 7].Value = dr["Pengirim"];
                    ws.Cells[idx, 8].Value = dr["Penerima"];
                    ws.Cells[idx, 9].Value = dr["QtyKirim"];
                    ws.Cells[idx, 10].Value = dr["QtyTerima"];
                    ws.Cells[idx, 11].Value = dr["Ongkos"];
                    ws.Cells[idx, 12].Value = dr["QtyDO"];
                    ws.Cells[idx, 13].Value = dr["KeCheck1"];
                    ws.Cells[idx, 14].Value = dr["KeCheck2"];
                    ws.Cells[idx, 15].Value = dr["Catatan"];
                    ws.Cells[idx, 16].Value = dr["expedisi"];
                    //ws.Cells[idx, 17].Value = dr["NoKendaraan"];
                    //ws.Cells[idx, 18].Value = dr["NamaSopir"];
                    //ws.Cells[idx, 19].Value = dr["KirimTerimaID"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[4, 1, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[4, 1, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border = ws.Cells[4, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                //Laporan Pembelian
                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[2];

                ws1.Name = "Pembelian"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";

                int MaxCol1 = 25;

                ws1.Cells[1, 1].Worksheet.Column(1).Width = 20;
                ws1.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws1.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws1.Cells[1, 4].Worksheet.Column(4).Width = 20;
                ws1.Cells[1, 5].Worksheet.Column(5).Width = 20;
                ws1.Cells[1, 6].Worksheet.Column(6).Width = 20;
                ws1.Cells[1, 7].Worksheet.Column(7).Width = 20;
                ws1.Cells[1, 8].Worksheet.Column(8).Width = 20;
                ws1.Cells[1, 9].Worksheet.Column(9).Width = 20;
                ws1.Cells[1, 10].Worksheet.Column(10).Width = 20;
                ws1.Cells[1, 11].Worksheet.Column(11).Width = 20;
                ws1.Cells[1, 12].Worksheet.Column(12).Width = 20;
                ws1.Cells[1, 13].Worksheet.Column(13).Width = 20;
                ws1.Cells[1, 14].Worksheet.Column(14).Width = 20;
                ws1.Cells[1, 15].Worksheet.Column(15).Width = 20;
                ws1.Cells[1, 16].Worksheet.Column(16).Width = 20;
                ws1.Cells[1, 17].Worksheet.Column(17).Width = 20;
                ws1.Cells[1, 18].Worksheet.Column(18).Width = 20;
                ws1.Cells[1, 19].Worksheet.Column(19).Width = 20;
                ws1.Cells[1, 20].Worksheet.Column(20).Width = 20;
                ws1.Cells[1, 21].Worksheet.Column(21).Width = 20;
                ws1.Cells[1, 22].Worksheet.Column(22).Width = 20;
                ws1.Cells[1, 23].Worksheet.Column(23).Width = 20;
                ws1.Cells[1, 24].Worksheet.Column(24).Width = 20;
                ws1.Cells[1, 25].Worksheet.Column(25).Width = 20;

                ws1.Cells[1, 1].Value = "LAPORAN ORDER PEMBELIAN BELUM MENJADI NOTA";
                ws1.Cells[2, 1].Value = string.Format("Periode Surat Jalan {0} s.d. {1}", fromDate.ToString("dd-MM-yyyy"), toDate.ToString("dd-MM-yyyy"));
                ws1.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws1.Cells[1, 1].Style.Font.Size = 14;
                ws1.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws1.Cells[4, 1].Value = "Nomer Request";
                ws1.Cells[4, 2].Value = "Tanggal Request";
                ws1.Cells[4, 3].Value = "Nomer DO";
                ws1.Cells[4, 4].Value = "Tanggal Transaksi";
                ws1.Cells[4, 5].Value = "Nomer Nota";
                ws1.Cells[4, 6].Value = "Tanggal Nota";
                ws1.Cells[4, 7].Value = "Nomer Surat Jalan";
                ws1.Cells[4, 8].Value = "Tanggal Surat Jalan";
                ws1.Cells[4, 9].Value = "Tanggal Terima";
                ws1.Cells[4, 10].Value = "Hari Kredit";
                ws1.Cells[4, 11].Value = "PPN";
                ws1.Cells[4, 12].Value = "Pemasok";
                ws1.Cells[4, 13].Value = "Ekspedisi";
                ws1.Cells[4, 14].Value = "Cabang";
                ws1.Cells[4, 15].Value = "Catatan";
                ws1.Cells[4, 16].Value = "ID Barang";
                ws1.Cells[4, 17].Value = "Quantity Request";
                ws1.Cells[4, 18].Value = "Quantity DO";
                ws1.Cells[4, 19].Value = "Quantity Surat Jalan";
                ws1.Cells[4, 20].Value = "Quantity Nota";
                ws1.Cells[4, 21].Value = "Harga Beli";
                ws1.Cells[4, 22].Value = "Harga Pokok";
                ws1.Cells[4, 23].Value = "HPPSolo";
                ws1.Cells[4, 24].Value = "Potongan";
                ws1.Cells[4, 25].Value = "Kode Gudang";


                ws1.Cells[4, 1, 4, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[4, 1, 4, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData
                int idx1 = 5;
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    ws1.Cells[idx1, 1].Value = dr["NoRequest"];
                    ws1.Cells[idx1, 2].Value = dr["TglRequest"];
                    ws1.Cells[idx1, 3].Value = dr["NoDO"];
                    ws1.Cells[idx1, 4].Value = string.Format("{0:dd MMMM yyyy}", dr["TglTransaksi"]);
                    ws1.Cells[idx1, 5].Value = dr["NoNota"];
                    ws1.Cells[idx1, 6].Value = dr["TglNota"];
                    ws1.Cells[idx1, 7].Value = dr["NoSuratJalan"];
                    ws1.Cells[idx1, 8].Value = string.Format("{0:dd MMMM yyyy}", dr["TglSuratJalan"]);
                    ws1.Cells[idx1, 9].Value = string.Format("{0:dd MMMM yyyy}", dr["TglTerima"]);
                    ws1.Cells[idx1, 10].Value = dr["HariKredit"];
                    ws1.Cells[idx1, 11].Value = dr["PPN"];
                    ws1.Cells[idx1, 12].Value = dr["Pemasok"];
                    ws1.Cells[idx1, 13].Value = dr["Expedisi"];
                    ws1.Cells[idx1, 14].Value = dr["Cabang"];
                    ws1.Cells[idx1, 15].Value = dr["Catatan"];
                    ws1.Cells[idx1, 16].Value = dr["BarangID"];
                    ws1.Cells[idx1, 17].Value = dr["QtyRequest"];
                    ws1.Cells[idx1, 18].Value = dr["QtyDO"];
                    ws1.Cells[idx1, 19].Value = dr["QtySuratJalan"];
                    ws1.Cells[idx1, 20].Value = dr["QtyNota"];
                    ws1.Cells[idx1, 21].Value = dr["Catatan"];
                    ws1.Cells[idx1, 22].Value = dr["HrgBeli"];
                    ws1.Cells[idx1, 22].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws1.Cells[idx1, 23].Value = dr["HrgPokok"];
                    ws1.Cells[idx1, 23].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws1.Cells[idx1, 24].Value = dr["HPPSolo"];
                    ws1.Cells[idx1, 24].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws1.Cells[idx1, 25].Value = dr["Pot"];
                    ws1.Cells[idx1, 25].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    idx1++;
                }
                #endregion

                #region Summary & Formatting
                ws1.Cells[4, 1, 4, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[4, 1, 4, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border1 = ws1.Cells[4, 1, idx1, MaxCol1].Style.Border;
                border1.Bottom.Style =
                border1.Top.Style =
                border1.Left.Style =
                border1.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                //Laporan RETUR PENJUALAN
                p.Workbook.Worksheets.Add("Sheet3");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[3];
                ws2.Name = "Retur Penjualan"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 12; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";
                int MaxCol2 = 14;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 20;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 20;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 20;
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 20;
                ws2.Cells[1, 7].Worksheet.Column(7).Width = 20;
                ws2.Cells[1, 8].Worksheet.Column(8).Width = 20;
                ws2.Cells[1, 9].Worksheet.Column(9).Width = 20;
                ws2.Cells[1, 10].Worksheet.Column(10).Width = 20;
                ws2.Cells[1, 11].Worksheet.Column(11).Width = 20;
                //ws2.Cells[1, 12].Worksheet.Column(12).Width = 20;
                //ws2.Cells[1, 13].Worksheet.Column(13).Width = 20;
                //ws2.Cells[1, 14].Worksheet.Column(14).Width = 20;

                ws2.Cells[1, 1].Value = "LAPORAN RETUR PENJUALAN QTY TARIKAN <> QTY GUDANG";
                ws2.Cells[2, 1].Value = string.Format("Periode Nota Retur {0} s.d. {1}", fromDate.ToString("dd-MM-yyyy"), toDate.ToString("dd-MM-yyyy"));
                ws2.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws2.Cells[1, 1].Style.Font.Size = 14;
                ws2.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws2.Cells[4, 1].Value = "Nota Jual ID";
                ws2.Cells[4, 2].Value = "Retur ID";
                ws2.Cells[4, 3].Value = "Nota Jual Rec ID";
                ws2.Cells[4, 4].Value = "Kode Retur";
                ws2.Cells[4, 5].Value = "Barang ID";
                ws2.Cells[4, 6].Value = "Quantity Memo";
                ws2.Cells[4, 7].Value = "Quantity Tarik";
                ws2.Cells[4, 8].Value = "Quantity Terima";
                ws2.Cells[4, 9].Value = "Quantity Gudang";
                ws2.Cells[4, 10].Value = "Quantity Tolak";
                ws2.Cells[4, 11].Value = "Harga Jual";
                ws2.Cells[4, 12].Value = "Kategori";
                ws2.Cells[4, 13].Value = "Kode Gudang";
                ws2.Cells[4, 14].Value = "Tanggal Nota Retur";
                ws2.Cells[4, 1, 6, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[4, 1, 6, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                #endregion

                #region FillData
                int idx2 = 5;
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    ws2.Cells[idx2, 1].Value = dr["KodeRetur"];
                    ws2.Cells[idx2, 2].Value = dr["BarangID"];
                    ws2.Cells[idx2, 3].Value = dr["QtyMemo"];
                    ws2.Cells[idx2, 4].Value = dr["QtyTarik"];
                    ws2.Cells[idx2, 5].Value = dr["QtyTerima"];
                    ws2.Cells[idx2, 6].Value = dr["QtyGudang"];
                    ws2.Cells[idx2, 7].Value = dr["QtyTolak"];
                    ws2.Cells[idx2, 8].Value = dr["HrgJual"];
                    ws2.Cells[idx2, 8].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws2.Cells[idx2, 9].Value = dr["Kategori"];
                    ws2.Cells[idx2, 10].Value = dr["KodeGudang"];
                    ws2.Cells[idx2, 11].Value = string.Format("{0:dd MMMM yyyy}", dr["TglNotaRetur"]);

                    idx2++;
                }
                #endregion

                #region Summary & Formatting
                ws2.Cells[4, 1, 4, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[4, 1, 4, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border2 = ws2.Cells[4, 1, idx2, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "cekArusStock-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }

        private DataSet GetSyncData()
        {
            DataSet dsSynch = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPO_ISA"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RefilPO";
                if (dt.Rows.Count > 0)
                {
                    dsSynch.Tables.Add(dt);
                }
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPODetail_ISA"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RefilPODetail";
                if (dt.Rows.Count > 0)
                {
                    dsSynch.Tables.Add(dt);
                }
            }
            return dsSynch;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (gvPOH.Rows.Count > 0)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataSet dsArus = CekArusStok();
                                DataSet dsSynch = GetSyncData();
                                if (dsSynch.Tables.Count > 0)
                                {
                                    string pathString = @"c:\temp\upload";
                                    if (!System.IO.Directory.Exists(pathString))
                                    {
                                        System.IO.Directory.CreateDirectory(pathString);
                                    }
                                    string Target = GlobalVar.Gudang;
                                    string fileOuput = pathString + "\\" + "PO-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                                    dsSynch.WriteXml(fileOuput);
                                    MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                                    //update synchflag
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPOUpdateSynchFlag_ISA"));
                                        db.Commands[0].ExecuteDataTable();
                                    }

                                    using (Database db = new Database())
                                    {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPODetailUpdateSynchFlag_ISA"));
                                        db.Commands[0].ExecuteDataTable();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
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
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOD.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Meng-Upload Data dari Tabel Detail");
                        }

                    }
                    break;
            }
        }

        #region "Upload dbf"
        private void upload()
        {


            
        }
        private void ZipFile(string FileName1, string FileName2, String FileName3)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".xlsx";
            string fileIndex = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            //files.Add(fileIndex);

            if (File.Exists(fileIndex))
            {
                File.Delete(fileIndex);
            }

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            //if (File.Exists(fileName1) && File.Exists(fileName2) && File.Exists(fileIndex))
            if (File.Exists(fileName1) && File.Exists(fileName2) && File.Exists(fileName3))
            {
                File.Delete(fileName1);
                File.Delete(fileName2);
                File.Delete(fileName3);
                //File.Delete(fileIndex);
            }
        }

        private void Upload1(String FileName)
        {
            using (Database db = new Database())
            {
                HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                db.Commands.Add(db.CreateCommand("usp_POHeader_UploadDBF"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtpTo.Value));
                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, HeaderID_));
                dtUploadHeader = db.Commands[0].ExecuteDataTable();
            }
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("idtr", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_po", "Tgl_po", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_po", "No_po", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("admin", "Admin", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("gudang", "Gudang", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("tanggal1", "Tanggal1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tanggal2", "Tanggal2", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("tgl_do", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_do", "No_do", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("acc", "Acc", Foxpro.enFoxproTypes.Char, 43));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtUploadHeader, HeaderprogressBar);
        }

        private void Upload2(String FileName)
        {
            using (Database db = new Database())
            {
                HeaderID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                db.Commands.Add(db.CreateCommand("usp_PODetail_UploadDBF"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dtpFrom.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dtpTo.Value));
                db.Commands[0].Parameters.Add(new Parameter("@headerid", SqlDbType.UniqueIdentifier,HeaderID_));
                dtUploadDetail = db.Commands[0].ExecuteDataTable();
            }
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("Idtr", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idrec", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_Brg", "Id_Brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("satuan", "Satuan", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("qrefill", "Qrefill", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qbo", "Qbo", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qspike", "Qspike", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qbuffer", "Qbuffer", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qstok", "Qstok", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qfisik", "Qfisik", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qopnm", "Qopnm", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qpo", "Qpo", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("qtrm", "Qtrm", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("tgl_opnm", "Tgl_opnm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_po", "Tgl_po", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("catatan", "Catatan", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("kd_gdg", "Kd_gdg", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("tgl_do", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("qdo", "Qdo", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("no_ret", "No_ret", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("nm_toko", "Nm_toko", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("tgl_gudang", "Tgl_gudang", Foxpro.enFoxproTypes.DateTime, 8));

            //List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            //index.Add(new Foxpro.IndexStruct("idtr", "IDTR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtUploadDetail, DetailprogressBar);//, index);
        }
        #endregion


        private void GenerateLaporanPO()
        {
            #region LAPORAN ANALISA STOCK PO
            using (ExcelPackage p = new ExcelPackage())
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_AnalisaStock_PO"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.Date, txtTglPO.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws3 = p.Workbook.Worksheets[1];

                ws3.Name = FileNameReportPO; //Setting Sheet's name
                ws3.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws3.Cells.Style.Font.Name = "Calibri";

                int MaxCol3 = 15;

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 7;
                ws3.Cells[1, 2].Worksheet.Column(2).Width = 20;
                ws3.Cells[1, 3].Worksheet.Column(3).Width = 75;
                ws3.Cells[1, 4].Worksheet.Column(4).Width = 10;
                ws3.Cells[1, 5].Worksheet.Column(5).Width = 12;
                ws3.Cells[1, 6].Worksheet.Column(6).Width = 12;
                ws3.Cells[1, 7].Worksheet.Column(7).Width = 12;
                ws3.Cells[1, 8].Worksheet.Column(8).Width = 12;
                ws3.Cells[1, 9].Worksheet.Column(9).Width = 12;
                ws3.Cells[1, 10].Worksheet.Column(10).Width = 12;
                ws3.Cells[1, 11].Worksheet.Column(11).Width = 12;
                ws3.Cells[1, 12].Worksheet.Column(12).Width = 12;
                ws3.Cells[1, 13].Worksheet.Column(13).Width = 30;
                ws3.Cells[1, 14].Worksheet.Column(14).Width = 18;
                ws3.Cells[1, 15].Worksheet.Column(15).Width = 12;

                ws3.Cells[1, 1].Value = "LAPORAN ANALISA STOCK PO";
                ws3.Cells[3, 1].Value = "Periode  : " + Convert.ToDateTime(txtTglPO.DateValue).AddDays(-13).ToString("dd/MM/yyyy") + " s/d " + Convert.ToDateTime(txtTglPO.DateValue).ToString("dd/MM/yyyy");
                ws3.Cells[4, 1].Value = "";
                ws3.Cells[1, 1, 1, MaxCol3].Merge = true;
                ws3.Cells[2, 1, 2, MaxCol3].Merge = true;
                ws3.Cells[1, 1, 2, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.Font.Bold = true;
                ws3.Cells[1, 1].Style.Font.Size = 14;
                ws3.Cells[2, 1].Style.Font.Size = 11;

                // 	  	  	  	  	  



                #region Generate Header

                ws3.Cells[5, 1].Value = "No.";
                ws3.Cells[5, 2].Value = "Kode Barang";
                ws3.Cells[5, 3].Value = "Nama Barang";
                ws3.Cells[5, 4].Value = "Sat";
                ws3.Cells[5, 5].Value = "Stock Akhir";
                ws3.Cells[5, 6].Value = "Qty Fisik";
                ws3.Cells[5, 7].Value = "Buffer";
                ws3.Cells[5, 8].Value = "BO";
                ws3.Cells[5, 9].Value = "Refill";
                ws3.Cells[5, 10].Value = "Spike";
                ws3.Cells[5, 11].Value = "Plan PO";
                ws3.Cells[5, 12].Value = "Real PO";
                ws3.Cells[5, 13].Value = "Keterangan";
                ws3.Cells[5, 14].Value = "Tgl Update Buffer";
                ws3.Cells[5, 15].Value = "BO Depo";


                ws3.Cells[5, 1, 5, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[5, 1, 5, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion


                #region FillData
                int idx = 6;
                int no = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    ws3.Cells[idx, 1].Value = no;
                    ws3.Cells[idx, 2].Value = dr["BarangID"];
                    ws3.Cells[idx, 3].Value = dr["NamaStok"];
                    ws3.Cells[idx, 4].Value = dr["SatJual"];
                    ws3.Cells[idx, 5].Value = dr["qstok"];
                    ws3.Cells[idx, 6].Value = dr["qfisik"];
                    ws3.Cells[idx, 7].Value = dr["qbuffer"];
                    ws3.Cells[idx, 8].Value = dr["qbo"];
                    ws3.Cells[idx, 9].Value = dr["qrefill"];
                    ws3.Cells[idx, 10].Value = dr["qspike"];
                    ws3.Cells[idx, 11].Value = dr["qplanpo"];
                    ws3.Cells[idx, 12].Value = dr["qpo"];
                    ws3.Cells[idx, 13].Value = dr["Keterangan"];
                    ws3.Cells[idx, 14].Value = dr["tmt1"];
                    ws3.Cells[idx, 15].Value = dr["BODepo"];

                    //set numeric
                    ws3.Cells[idx, 5].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 7].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 9].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 10].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 11].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 12].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws3.Cells[idx, 15].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    //ws3.Cells[idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                    ws3.Cells[idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws3.Cells[idx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    no++;
                    idx++;
                }

                #endregion

                #region Summary & Formatting
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border3 = ws3.Cells[5, 1, idx - 1, MaxCol3].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = GlobalVar.DbfUpload + "\\" + FileNameReportPO + ".xlsx";
  
                sf.OverwritePrompt = true;
                string file = sf.FileName.ToString();
                File.WriteAllBytes(file, bin);


                #endregion
            #endregion
            }
        }

        private void upload_dbf_Click(object sender, EventArgs e)
        {
            if (gvPOH.Rows.Count > 0)
            {
                //cek kelompok barang
                string _catatan = gvPOH.SelectedCells[0].OwningRow.Cells["keterangan"].Value.ToString().Trim();
                if (_catatan == "POKE00")
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Guid rowID_ = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DataTable dtc = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PODetail_CekFX"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                            dtc = db.Commands[0].ExecuteDataTable();
                        }
                        if (dtc.Rows.Count > 0)
                        {
                            if (Convert.ToDouble(dtc.Rows[0]["qfx"].ToString()) > 0 && Convert.ToDouble(dtc.Rows[0]["qbe"].ToString()) == 0)
                            {
                                MessageBox.Show("PO khusus untuk barang FX hanya ke PSHO saja");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada detail Po yang akan diupload");
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

                // proses upload
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet dsSynch = GetSyncData();

                    if (dsSynch.Tables.Count > 0)
                    {
                        bool isUploaded = true;

                        DataSet dsArus = CekArusStok();

                        bool isHasIncompleteData = HasIncompleteData(dsArus);
                        if (isHasIncompleteData)
                        {
                            GenerateExcell(dsArus);
                            isUploaded = HasValidPin(dsArus);
                        }

                        if (isUploaded)
                        {
                            GenerateLaporanPO();
                            Upload1(_hFileName);
                            Upload2(_dFileName);

                            ZipFile(_hFileName, _dFileName, FileNameReportPO);

                            this.Cursor = Cursors.Default;
                            MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\dbfmatch.zip");
                            //update synchflag
                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPOUpdateSynchFlag_ISA"));
                                db.Commands[0].ExecuteDataTable();
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("psp_UPLOAD_RefilPODetailUpdateSynchFlag_ISA"));
                                db.Commands[0].ExecuteDataTable();
                            }
                            RefreshHeader();

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
            else
            {
                MessageBox.Show("Tidak data yang diupload");
            }

        }


            

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {

                            PO.PODownload ifrmChild = new PO.PODownload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOD.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Mendownload Data dari Tabel Detail");
                        }
                    }
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid rowID;
            bool Closing = false;
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    {
                        if (gvPOH.SelectedCells.Count > 0)
                        {
                            rowID = (Guid)gvPOH.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string idtr = Convert.ToString(gvPOH.SelectedCells[0].OwningRow.Cells["idtr"].Value.ToString());
                            DateTime tgl1 = Convert.ToDateTime(gvPOH.SelectedCells[0].OwningRow.Cells["periode1"].Value);
                            DateTime tgl2 = Convert.ToDateTime(gvPOH.SelectedCells[0].OwningRow.Cells["Periode2"].Value);

                            DataTable dtCekCreatePO = CekCreatePO(rowID);
                            if (dtCekCreatePO.Rows.Count > 0)
                            {
                                MessageBox.Show("Tidak bisa GetDatail PO ulang");
                                return;
                            }

                            PO.frmGetDetailPO ifrmChild = new frmGetDetailPO(this, rowID, Closing,idtr);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;

                case enumSelectedGrid.Detail:
                    {
                        if (gvPOD.SelectedCells.Count > 0)
                        {
                            MessageBox.Show("Tidak Dapat Diakses Data dari Tabel Detail");
                        }
                    }
                    break;
            }

        }

        public void datetoHari(DateTime tanggal)
        {
            int tgl = Convert.ToInt16(tanggal.DayOfWeek);
            switch (tgl)
            {
                case 0:
                    hari = "MINGGU";
                    break;
                case 1:
                    hari = "SENIN";
                    break;
                case 2:
                    hari = "SELASA";
                    break;
                case 3:
                    hari="RABU";
                    break;
                case 4:
                    hari="KAMIS";
                    break;
                case 5:
                    hari="JUMAT";
                    break;
                case 6 :
                    hari="SABTU";
                    break;

            }
        }

        public DataTable CekJadwalPO()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_POJadwalCekHari"));
                db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, hari));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public DataTable CekCreatePO(Guid rowid)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_POCreateCek"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        private void gvPOD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gvPOH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void gvPOD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void POFindRow(string column, string value)
        {
            //RefreshData();
            gvPOH.FindRow(column, value);
            gvPOH.Focus();
        }

        public void FindRow(string columnName, string value)
        {
            foreach (DataGridViewRow row in gvPOH.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString().ToUpper() == value.ToUpper())
                    {
                        int i = 0;
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Visible == true)
                            {
                                break;
                            }
                        }
                        gvPOH.CurrentCell = row.Cells[i];
                        this.Focus();
                        row.Selected = true;
                        gvPOH.FirstDisplayedCell = gvPOH.CurrentCell;
                        break;
                    }
                }
            }
        }

        private void gvPOH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (gvPOH.SelectedCells.Count > 0)
            {
                string sf = Tools.isNull(gvPOH.SelectedCells[0].OwningRow.Cells["id_match"].Value,"").ToString();
                for (int rowIndex = 0; rowIndex < gvPOH.Rows.Count; rowIndex++)
                {
                    if (sf == "True")
                        gvPOH.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    else
                        gvPOH.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }

}