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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Toko.Penjualan
{
    public partial class frmMPRBrowser : ISA.Toko.BaseForm
    {
        string _NoACC = string.Empty;
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtReturDetail;

        string tipeLokasi;
        bool _acak;
        double jmlHrgRet = 0, netto = 0; 

        public frmMPRBrowser()
        {
            InitializeComponent();
        }

        private void frmMPRBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "MPR";
            this.Text = "Retur Penjualan";
            _acak = true;
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglMPR.FromDate = DateTime.Now;
            rgbTglMPR.ToDate = DateTime.Now;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST")); //cek heri
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                tipeLokasi = Tools.isNull(dtPerusahaan.Rows[0]["TipeLokasi"], "").ToString();
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataReturJual();
        }

        private void rgbTglMPR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataReturJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST_FILTER_TglMPR")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglMPR.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglMPR.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "TglMPR, NoMPR";
                    dataGridHeader.DataSource = dt.DefaultView;
                }

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDataReturJualDetail();
                    dataGridHeader.Focus();
                }
                else
                {
                    DataView dvEmpty = new DataView();
                    dataGridDetail.DataSource = dvEmpty;
                    txtJmlHrg2.Text = "0";
                    txtJmlNet2.Text = "0";
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

        public void RefreshRowDataReturJual(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    RefreshDataReturJual();
                    //dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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

        public void RefreshDataReturJualDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid _headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                if (_headerID==Guid.Empty)
                {
                    return;
                }
                dtReturDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtReturDetail = db.Commands[0].ExecuteDataTable();                    
                }
                dtReturDetail.DefaultView.Sort = "RecordID";
                dataGridDetail.DataSource = dtReturDetail.DefaultView;

                AcakTampilTextBox();

                //// Update nilai retur
                dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiRetur"].Value = netto;
                dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(netto.ToString("#,##0,00"));


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

        public void RefreshRowDataReturJualDetail(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    RefreshDataReturJualDetail();
                    //dataGridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                }

                AcakTampilTextBox();

                //// Update nilai retur
                dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiRetur"].Value = netto;
                dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(netto.ToString("#,##0,00"));                
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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Tab:
                    dataGridDetail.Focus();
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    break;
                case Keys.F3:
                    CetakSPPB();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F11:

                    /*
                    RJ3.frmRptPengajuanRetur ifrmChild = new RJ3.frmRptPengajuanRetur();
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    */

                    GeneratePengajuan((DateTime)rgbTglMPR.FromDate, (DateTime)rgbTglMPR.ToDate);
        
                    break;

            }
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Tab:
                    dataGridHeader.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void CetakSPPB()
        {
            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            Console.WriteLine(rowID);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakSPPB")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data Kosong");
                    return;
                }
                int jml = 1;
                DataTable dt2 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DOKUMENVPG"));
                    dt2 = db.Commands[0].ExecuteDataTable();
                }
                if (dt2.Rows.Count > 0)
                {
                   jml = int.Parse(dt2.Rows[0]["Value"].ToString());
                }

                DisplayReport(dt, "rptSPPB");
                if (jml == 2)
                {
                    DisplayReport(dt, "rptSPPBCopy1");
                }
                //if (jml == 3)
                //{
                //    DisplayReport(dt, "rptSPPB");
                //    DisplayReport(dt, "rptSPPBCopy1");
                //    DisplayReport(dt, "rptSPPBCopy2");
                //}

                //DisplayReport(dt);
                PrintRawSPPB(dt);
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

        public void DisplayReport(DataTable dt, String ReportName)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan." + ReportName + ".rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Print();
            //ifrmReport.Show();
        }

        private void PrintRawSPPB(DataTable dt)
        {
            
            BuildString sppb = new BuildString();
            int No = 0;

            #region Header
            string noMemo = dt.Rows[0]["NoMPR"].ToString();
            string tglMemo = DateTime.Parse(dt.Rows[0]["TglMPR"].ToString()).ToString("dd-MMM-yyyy");
            string namaToko = dt.Rows[0]["NamaToko"].ToString().PadRight(31);
            string alamatKirim = dt.Rows[0]["Alamat"].ToString().PadRight(60);
            string kota = dt.Rows[0]["Kota"].ToString();
            string idWil = dt.Rows[0]["WilID"].ToString();
            string bagianPenjualan = dt.Rows[0]["BagPenjualan"].ToString();

            sppb.Initialize();
            sppb.FontCondensed(false);
            sppb.FontCPI(10);
            sppb.PageLLine(33);
            sppb.LeftMargin(3);
            sppb.FontBold(true);
            sppb.PROW(true, 1, "No." + noMemo + sppb.SPACE(50) + " Tgl." + tglMemo);
            sppb.FontCPI(12);
            sppb.PROW(true, 1, sppb.SPACE(30) + "SURAT PERINTAH PENGAMBILAN BARANG");
            sppb.FontBold(false);
            sppb.LetterQuality(true);
            sppb.LineSpacing("1/8");
            sppb.PROW(true, 1, " ");
            sppb.PROW(true, 1, sppb.SPACE(10) + sppb.PrintTopLeftCorner() + sppb.PrintHorizontalLine(1) + " Nama Toko : " + sppb.PrintHorizontalLine(26) + sppb.PrintTopRightCorner());
            sppb.PROW(true, 1, sppb.SPACE(10) + sppb.PrintVerticalLine() + sppb.SPACE(40) + sppb.PrintVerticalLine());
            sppb.FontBold(true);
            sppb.AddCR();
            sppb.PROW(false, 13, namaToko); 
            sppb.FontBold(false);
            sppb.PROW(true, 1, sppb.SPACE(10) + sppb.PrintVerticalLine() + sppb.SPACE(40) + sppb.PrintVerticalLine());
            sppb.FontCondensed(true);
            sppb.FontItalic(true);
            sppb.AddCR();
            sppb.PROW(false, 22, alamatKirim);
            sppb.FontItalic(false);
            sppb.FontCondensed(false);
            sppb.PROW(true, 1, sppb.SPACE(10) + sppb.PrintVerticalLine() + sppb.SPACE(40) + sppb.PrintVerticalLine());
            sppb.FontItalic(true);
            sppb.AddCR();
            sppb.PROW(false, 13, kota + " (" + idWil + ")");
            sppb.FontItalic(false);
            sppb.PROW(true, 1, sppb.SPACE(10) + sppb.PrintBottomLeftCorner() + sppb.PrintHorizontalLine(40) + sppb.PrintBottomRightCorner());
            sppb.LetterQuality(false);
            sppb.FontCondensed(true);
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, sppb.PrintDoubleLine(154));
            sppb.PROW(true, 1, "No.  N  a  m  a     B  a  r  a  n  g" + sppb.SPACE(45) + "Asal Nota"+ sppb.SPACE(5) + "Qty" + sppb.SPACE(13) + "Sales" + sppb.SPACE(14) + "Alasan Retur" + sppb.SPACE(12));
            sppb.PROW(true, 1, sppb.PrintHorizontalLine(154));
            #endregion

            #region Detail
            string temp = string.Empty;
            string sales = string.Empty;
            string namaStok = string.Empty;
            string asalNota = string.Empty;
            string satuan = string.Empty;
            string catatan = string.Empty;
            int qtyTarik = 0;

            foreach (DataRow dr in dt.Rows)
            {
                No++;
                temp = string.Empty;
                sales = dr["NamaSales"].ToString();
                namaStok = dr["NamaBarang"].ToString();
                asalNota = dr["NotaAsal"].ToString().PadRight(7);
                satuan = dr["Satuan"].ToString();
                catatan = dr["Catatan1"].ToString();
                qtyTarik = int.Parse(dr["QtyTarik"].ToString());

                temp += No.ToString().PadLeft(2, '0') + ".  ";
                temp += namaStok.PadRight(73, '.') + sppb.SPACE(4);
                temp += asalNota + sppb.SPACE(4);
                temp += qtyTarik.ToString().PadLeft(6) + " " + satuan.PadLeft(3) + sppb.SPACE(4);
                temp += sppb.PadCenter(15, sales);
                temp += sppb.PadCenter(30, catatan);

                sppb.PROW(true, 1, temp);
            }

            No++;
            for (int i = No; i <= 15; i++)
            {
                sppb.PROW(true, 1, i.ToString().PadLeft(2, '0') + ". ");
            }

            #endregion

            #region Footer
            sppb.PROW(true, 1, sppb.PrintDoubleLine(154));
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, sppb.SPACE(20) +  "Bag.Penjualan" + sppb.SPACE(90) + "Salesman");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, sppb.SPACE(16) + "(" + sppb.PadCenter(19, bagianPenjualan) + ")" + sppb.SPACE(79) + "(.....................)");
            sppb.Eject();
            #endregion

            sppb.SendToPrinter("sppb.txt");
        }

        public void DisplayReport(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakSPPB.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            //ifrmReport.Print();
            ifrmReport.Show();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            try
            {
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        //if (DateTime.Today <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}
                        Penjualan.frmMPRUpdate ifrmChild = new Penjualan.frmMPRUpdate(this);
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridHeader.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
                        {
                            MessageBox.Show("Sudah dibuat nota retur. Tidak bisa tambah...!!!");
                            return;
                        }
                        //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}

                        Guid _headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Penjualan.frmMPRDetailUpdate ifrmChild2 = new Penjualan.frmMPRDetailUpdate(this, _headerID, frmMPRDetailUpdate.enumFormMode.New);
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.ShowDialog();

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid _rowID;
            try
            {
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridHeader.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
                        {
                            MessageBox.Show("Sudah dibuat nota retur. Tidak bisa di edit...!!!");
                            return;
                        }
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }

                        _rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Penjualan.frmMPRUpdate ifrmChild = new Penjualan.frmMPRUpdate(this, _rowID);
                        ifrmChild.ShowDialog();

                        break;

                    case enumSelectedGrid.DetailSelected:
                        //if (dataGridDetail.SelectedCells.Count == 0)
                        //{
                        //    MessageBox.Show(Messages.Error.RowNotSelected);
                        //    return;
                        //}
                        //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
                        //{
                        //    MessageBox.Show("Sudah dibuat nota retur. Tidak bisa di edit...!!!");
                        //    return;
                        //}
                    
                        //string kodeRetur = dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString().Trim();
                        //if (kodeRetur == "1" )
                        //{
                            /* Note:
                            /* Bila jarak tgl terima dan tgl memo 
                             * belum 60 hari (!CekACCRetur())
                             * maka tidak diperlukan No ACC untuk prosess nota */
                            //if (!CekACCRetur())
                            //{
                            //    MessageBox.Show("Tidak butuh ACC untuk proses nota retur");
                            //    return;
                            //}
                            
                    //    }

                    //    //GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value;
                    //    //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value <= GlobalVar.LastClosingDate)
                    //    //{
                    //    //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    //    //}

                        //_rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        //Penjualan.frmMPRDetailUpdate ifrmChild2 = new Penjualan.frmMPRDetailUpdate(this, _rowID, frmMPRDetailUpdate.enumFormMode.Update);
                        //ifrmChild2.ShowDialog();

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool CekACCRetur()
        {
            DateTime tglTerima, tglRQRetur, tgl;
            double selisihHari;

            tglTerima = DateTime.Parse(dataGridDetail.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString());
            tglRQRetur = DateTime.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRQRetur"].Value.ToString());
            tgl = DateTime.Parse("01/08/2004");

            TimeSpan ts = tglRQRetur.Subtract(tglTerima);
            selisihHari = ts.TotalDays;

            if (tglTerima >= tgl && selisihHari > 60.0)
                return true;
            else
                return false;
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tglmemo = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value).Date;
                DateTime tglserver = GlobalVar.DateTimeOfServer.Date;
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridHeader.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                        }

                        if (tipeLokasi == "G")
                        {
                            MessageBox.Show("Anda tidak punya wewenang hapus data");
                            return;
                        }

                        if (bool.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["isClosed"].Value.ToString()) == true)
                        {
                            MessageBox.Show("Tidak bisa hapus data sudah di audit");
                            return;
                        }

                        //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
                        //{
                        //    MessageBox.Show("Sudah dibuat nota retur. Tidak bisa di hapus...!!!");
                        //    return;
                        //}

                        if (tglmemo != tglserver)
                        {
                            MessageBox.Show("Tidak bisa hapus record. Tanggal server beda dengan Tanggal Memo");
                            return;
                        }

                        if (dataGridDetail.Rows.Count > 0)
                        {
                            MessageBox.Show("Hapus detail dulu...!");
                            return;
                        }
                        if (!SecurityManager.IsManager())
                        {
                            MessageBox.Show("Hapus hanya dapat dilakukan oleh manager");
                            return;
                        }

                        //GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value;
                        //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_DELETE")); //cek heri
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                                    db.Commands[0].ExecuteNonQuery();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataReturJual();
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
                        break;

                    case enumSelectedGrid.DetailSelected:
                        if (dataGridDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }

                        if (tipeLokasi == "G")
                        {
                            MessageBox.Show("Anda tidak punya wewenang hapus data");
                            return;
                        }

                        if (bool.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["isClosed"].Value.ToString()) == true)
                        {
                            MessageBox.Show("Tidak bisa hapus data sudah di audit");
                            return;
                        }

                        //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
                        //{
                        //    MessageBox.Show("Sudah dibuat nota retur. Tidak bisa di hapus...!!!");
                        //    return;
                        //}

                        bool link= (bool)(dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailSyncFlag"].Value);
                        if (link)
                        {
                            MessageBox.Show("Sudah Link ke Piutang, tidak bisa dihapus");
                            return;
                        }

                        if (tglmemo != tglserver)
                        {
                            MessageBox.Show("Tidak bisa hapus record. Tanggal server beda dengan Tanggal Memo");
                            return;
                        }

                        if (!SecurityManager.IsManager())
                        {
                            MessageBox.Show("Hapus hanya dapat dilakukan oleh manager");
                            return;
                        }

                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglMPR"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                            string kodeRetur = dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString();
                            string type_usp_DELETE;

                            if (kodeRetur == "1")
                                type_usp_DELETE = "usp_ReturPenjualanDetail_DELETE"; //cek heri
                            else
                                type_usp_DELETE = "usp_ReturPenjualanTarikanDetail_DELETE"; //cek heri

                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand(type_usp_DELETE));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataReturJualDetail();
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
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double nilairet = double.Parse(Tools.isNull(dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Value, 0).ToString());
            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(nilairet.ToString("#,##0,00"));

            if (dataGridHeader.Rows[e.RowIndex].Cells["TglGudang"].Value.ToString() !="")
            {
                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

           // dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            if (dataGridDetail.RowCount>0)
            {
                _NoACC=dataGridDetail.Rows[e.RowIndex].Cells["NoACC"].Value.ToString();
            }
            if (_NoACC == "XXXXXX")
            {
                //dataGridDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["KodeRetur"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["QtyMemo"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["QtyTarik"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["Satuan"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["HrgJual"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Style.ForeColor = Color.Blue;
                //dataGridDetail.Rows[e.RowIndex].Cells["HrgNettoAck"].Style.ForeColor = Color.Blue;

                for (int i = 0; i < dataGridDetail.ColumnCount;i++ )
                {

                    dataGridDetail.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Blue;
                }
                
            }

            dataGridDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["HrgNettoAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
           
            //Isi Acak
            double harga = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgJual"].Value.ToString());
            double jumlah = double.Parse(Tools.isNull(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrg"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridDetail.Rows[e.RowIndex].Cells["HrgNetto"].Value, 0).ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0.00"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Value = Tools.GetAntiNumeric(jumlah.ToString("#,##0.00"));
            dataGridDetail.Rows[e.RowIndex].Cells["HrgNettoAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0.00"));
        }

        private void AcakTampilHrg()
        {
            bool normal = true;
            dataGridHeader.Columns["NilaiRetur"].DefaultCellStyle.Format = "#,##0.00";

            dataGridDetail.Columns["HrgJual"].DefaultCellStyle.Format = "#,##0.00";
            //dataGridDetail.Columns["JmlHrg"].DefaultCellStyle.Format = "#,##0.00";
            dataGridDetail.Columns["HrgNetto"].DefaultCellStyle.Format = "#,##0.00";

            normal = !_acak;
            dataGridHeader.Columns["NilaiRetur"].Visible = _acak;
            dataGridDetail.Columns["HrgJual"].Visible = _acak;
            //dataGridDetail.Columns["JmlHrg"].Visible = _acak;
            dataGridDetail.Columns["HrgNetto"].Visible = _acak;

            //acak
            dataGridHeader.Columns["NilaiReturAck"].Visible = normal;
            dataGridDetail.Columns["HrgJualAck"].Visible = normal;
            //dataGridDetail.Columns["JmlHrgAck"].Visible = normal;
            dataGridDetail.Columns["HrgNettoAck"].Visible = normal;
            _acak = normal;

            AcakTampilTextBox();
        }

        private void CountNilaiTextBox()
        {
            jmlHrgRet = 0;
            netto = 0;

            int count = dataGridDetail.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                jmlHrgRet = jmlHrgRet + double.Parse(dataGridDetail.Rows[i].Cells["JmlHrg"].Value.ToString());
                netto = netto + double.Parse(dataGridDetail.Rows[i].Cells["HrgNetto"].Value.ToString());

            }
        }

        private void AcakTampilTextBox()
        {
            CountNilaiTextBox();
            //jmlHrgRet = 0;
            //netto = 0;
            //if (dataGridHeader.RowCount > 0)
            //{
            //    if (dataGridDetail.Rows.Count > 0)
            //    {
            //        if (dtReturDetail.Compute("SUM(JmlHrg1)", string.Empty).Equals(string.Empty))
            //        {
            //            jmlHrgRet = 0;
            //        }
            //        else
            //        {
            //            jmlHrgRet = double.Parse(dtReturDetail.Compute("SUM(JmlHrg1)", string.Empty).ToString());
            //        }
            //        if (dtReturDetail.Compute("SUM(HrgNetto1)", string.Empty).ToString().Equals(string.Empty))
            //        {
            //            netto = 0;
            //        }
            //        else
            //        {
            //            netto = double.Parse(dtReturDetail.Compute("SUM(HrgNetto1)", string.Empty).ToString());
            //        }
            //    }
            //}
            if (_acak)
            {
                txtJmlHrg2.Text = Tools.GetAntiNumeric(jmlHrgRet.ToString("#,##0.00"));
                txtJmlNet2.Text = Tools.GetAntiNumeric(netto.ToString("#,##0.00"));
            }
            else
            {
                txtJmlHrg2.Text = jmlHrgRet.ToString("#,##0.00");
                txtJmlNet2.Text = netto.ToString("#,##0.00");
            }   

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                RefreshDataReturJualDetail();
            }
        }
        
        private DataTable PengajuanData(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_PengajuanRetur]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));

                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return dt;
        }

        private ExcelPackage PengajuanWorksheets()
        {
            ExcelPackage ep = new ExcelPackage();

            ep.Workbook.Worksheets.Add("Retur");

            foreach (ExcelWorksheet ws in ep.Workbook.Worksheets)
            {
                ws.View.ShowGridLines = false;
                ws.View.PageLayoutView = true;
                ws.View.PageBreakView = true;
                ws.PrinterSettings.FitToPage = true;
            }

            return ep;
        }

        private ExcelWorksheet ReturWorksheet(DataTable dt, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["Retur"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN RETUR";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO";
            ws.Cells[4, 2].Value = "NO MEMO";
            ws.Cells[4, 3].Value = "TGL MEMO";
            ws.Cells[4, 4].Value = "NO NOTA";
            ws.Cells[4, 5].Value = "TGL NOTA";
            ws.Cells[4, 6].Value = "KD RETUR";
            ws.Cells[4, 7].Value = "KD SALES";
            ws.Cells[4, 8].Value = "NAMA TOKO";
            ws.Cells[4, 9].Value = "ALAMAT";
            ws.Cells[4, 10].Value = "KOTA";
            ws.Cells[4, 11].Value = "ID BRG";
            ws.Cells[4, 12].Value = "NAMA STOK";
            ws.Cells[4, 13].Value = "SAT";
            ws.Cells[4, 14].Value = "RP RETUR";
            ws.Cells[4, 15].Value = "KETERANGAN RETUR";
            ws.Cells[4, 16].Value = "SALES";
            ws.Cells[4, 17].Value = "ALASAN RETUR";
            ws.Cells[4, 18].Value = "KEY";
            ws.Cells[4, 19].Value = "PIN";
            ws.Cells[4, 20].Value = "DI ACC/TOLAK";
            ws.Cells[4, 21].Value = "TGL.ACC";
            ws.Cells[4, 22].Value = "CATATAN";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in dt.Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["nomemo"];
                ws.Cells[rowCounter, 3].Value = dr["tglmemo"];
                ws.Cells[rowCounter, 4].Value = dr["noNota"];
                ws.Cells[rowCounter, 5].Value = dr["tglNota"];
                ws.Cells[rowCounter, 6].Value = dr["KodeRetur"];
                ws.Cells[rowCounter, 7].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 8].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 9].Value = dr["Alamat"];
                ws.Cells[rowCounter, 10].Value = dr["Kota"];
                ws.Cells[rowCounter, 11].Value = dr["BarangID"];
                ws.Cells[rowCounter, 12].Value = dr["NamaStok"];
                ws.Cells[rowCounter, 13].Value = dr["SatJual"];
                ws.Cells[rowCounter, 14].Value = dr["RpRetur"];
                ws.Cells[rowCounter, 15].Value = dr["keteranganretur"];
                ws.Cells[rowCounter, 16].Value = dr["NamaSales"];
                ws.Cells[rowCounter, 17].Value = dr["alasanretur"];
                ws.Cells[rowCounter, 18].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.Retur);

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 22].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 22].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 22].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 5, rowCounter, 5].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 14, rowCounter, 14].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 5, 16].Merge = true;
            ws.Cells[4, 17, 5, 17].Merge = true;
            ws.Cells[4, 18, 5, 18].Merge = true;
            ws.Cells[4, 19, 5, 19].Merge = true;
            ws.Cells[4, 20, 5, 20].Merge = true;
            ws.Cells[4, 21, 5, 21].Merge = true;
            ws.Cells[4, 22, 5, 22].Merge = true;

            ws.Cells[4, 1, 5, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 22; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private void SavePengajuan(ExcelPackage ep)
        {
            string directory = "C:\\Temp\\";
            string fileName = "Pengajuan_Retur_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            string filePath = directory + fileName;

            Byte[] bin = ep.GetAsByteArray();

            if (File.Exists(filePath))
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = fileName;
                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    filePath = sf.FileName.ToString();
                }
            }

            File.WriteAllBytes(filePath, bin);
            Process.Start(filePath);
            MessageBox.Show("Pembuatan pengajuan telah selesai dan disimpan di: " + "\n" + filePath);
        }

        private void GeneratePengajuan(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = PengajuanData(fromDate, toDate);

            if (dt.Rows.Count > 0)
            {
                ExcelPackage ep = PengajuanWorksheets();

                ExcelWorksheet wsOverdue = ReturWorksheet(dt, ep, fromDate, toDate);

                SavePengajuan(ep);
            }
            else
            {
                MessageBox.Show("Tidak ada pengajuan Retur.");
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            CetakSPPB();
        }

        private void dataGridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
    }
}
