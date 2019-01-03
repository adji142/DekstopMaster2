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
using System.Data.SqlTypes;

namespace ISA.Trading.Penjualan
{
    public partial class frmNotaReturJualBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtReturDetail;
        int _jmlQtyTerima = 0, _nCetak;
        bool _acak;
        string PrnAktif = "0";

        double jmlHrgRet = 0, netto = 0; 

        public frmNotaReturJualBrowse()
        {
            InitializeComponent();
        }

        private void frmNotaReturJualBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Nota";
            this.Text = "Retur Penjualan";
            _acak = true;
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;            
            rgbTglMPR.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglMPR.ToDate = DateTime.Now;
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
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST_FILTER_TglMPR"));  //cek by heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglMPR.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglMPR.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridHeader.DataSource = dt;
                }

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDataReturJualDetail();
                    dataGridHeader.Focus();
                }
                else
                {
                    dataGridDetail.DataSource = null;
                    _jmlQtyTerima = 0;
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
                    dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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
                dtReturDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtReturDetail = db.Commands[0].ExecuteDataTable();
                    dataGridDetail.DataSource = dtReturDetail;
                }

                if (dtReturDetail.Rows.Count > 0)
                {
                    string strJmlQtyTerima = dtReturDetail.Compute("SUM(QtyTerima)", string.Empty).ToString();
                    _jmlQtyTerima = int.Parse(strJmlQtyTerima);
                    dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiRetur"].Value = dtReturDetail.Compute("SUM(HrgNetto2)", string.Empty);

                }
                else
                {
                    _jmlQtyTerima = 0;
                    txtJmlHrg2.Text = "0";
                    txtJmlNet2.Text = "0";
                    dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiRetur"].Value = 0;
                    dataGridDetail.DataSource = null;
                }
                AcakTampilTextBox();
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
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                }

                string strJmlQtyTerima = dtReturDetail.Compute("SUM(QtyTerima)", string.Empty).ToString();
                _jmlQtyTerima = int.Parse(strJmlQtyTerima);
                dataGridHeader.SelectedCells[0].OwningRow.Cells["NilaiRetur"].Value = dtReturDetail.Compute("SUM(HrgNetto2)", string.Empty);

                AcakTampilTextBox();
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

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            int _nPrint = (int)dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value;
            bool _isClosed = (bool)dataGridHeader.SelectedCells[0].OwningRow.Cells["isClosed"].Value;
            string _linkID = dataGridHeader.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString().Trim();
            Guid _rowID;
            try
            {
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:

                        //if (_nPrint > 2)
                        //{ 
                        // Minta password manager 
                        //}
                        if (_isClosed == true)
                        {
                            MessageBox.Show("Data sudah diaudit. Tidak bisa di edit");
                            return;
                        }
                        if (_linkID!=string.Empty)
                        {
                            MessageBox.Show("Sudah di Link Ke Piutang !!");
                            return;
                        }
                        if (DateTime.Today <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        _rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        DateTime tglrq_ = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRQRetur"].Value;


                        if (GlobalVar.Gudang != "2808" & GlobalVar.Gudang != "2803")
                        {
                            string _ACCSpv = string.Empty;
                            _ACCSpv = NeedACCSPV(_rowID);
                            if (_ACCSpv.Length > 0)
                            {
                                MessageBox.Show("Retur belum diacc Supervisor.");
                                return;
                            }
                        }

                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803" )
                        {
                            string NeedACC_ = string.Empty;
                            NeedACC_ = NeedACC(_rowID, tglrq_);

                            //accspv
                            //string _ACCSpv = string.Empty;
                            //_ACCSpv = NeedACCSPV(_rowID);

                            if (NeedACC_.Length > 0)
                            {
                                MessageBox.Show("Barang Perlu ACC");

                                /*
                                Pin.frmPin ifrmpin = new Pin.frmPin(this, 0, 5, 10, _rowID, DateTime.Today);
                                ifrmpin.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmpin);
                                ifrmpin.Show();
                                */

                                string noMPR = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoMPR"].Value.ToString();

                                Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _rowID, GlobalVar.Gudang, PinId.Bagian.Retur, "Cegatan Retur " + noMPR);
                                ifrmpin.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmpin);
                                ifrmpin.Show();
                                return;
                                //throw new Exception("Barang Perlu ACC" + System.Environment.NewLine+NeedACC_);

                                //if (_ACCSpv.Length > 0)
                                //{
                                //    MessageBox.Show("Retur Perlu ACC Supervisor");
                                //    return;
                                //}
                            }
                        }

                        Penjualan.frmNotaReturJualUpdate ifrmChild = new Penjualan.frmNotaReturJualUpdate(this, _rowID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                        break;

                    case enumSelectedGrid.DetailSelected:

                        if (dataGridDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        if (_isClosed == true)
                        {
                            MessageBox.Show("Data sudah diaudit. Tidak bisa di koreksi !!!");
                            return;
                        }
                        if (_linkID != string.Empty)
                        {
                            MessageBox.Show("Sudah di Link Ke Piutang !!");
                            return;
                        }
                        //if (_nPrint > 2)
                        //{ 
                        // Minta password manager 
                        //}
                        if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() == "")
                        {
                            MessageBox.Show("Isi dulu tgl masuk gudang");
                            return;
                        }

                        string _noACC = dataGridDetail.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString();
                        if (GlobalVar.Gudang != "2808")
                        {
                            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString() == "3" && _noACC == "")
                            {
                                MessageBox.Show("Harus isi No. ACC dulu...!!!");
                                return;
                            }
                        }

                        if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString() == "1")
                        {
                            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString().Trim() == string.Empty)
                            {
                                throw new Exception("NotaDetail Asal Belum PJ3");
                            }
                            if (GlobalVar.Gudang != "2808")
                            {
                                if (CekACCRetur()
                                    && (_noACC == "" || ((_noACC.Length >= 3) ? _noACC.Substring(0, 3) == "TLK" : true) || _noACC == "XXXXXX"))
                                {
                                    MessageBox.Show("Harus isi No. ACC dulu...!!!");
                                    return;
                                }
                            }
                        }

                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));

                        }

                        _rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Penjualan.frmNotaReturJualDetailUpdate ifrmChild2 = new Penjualan.frmNotaReturJualDetailUpdate(this, _rowID);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
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

            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString().Trim()==string.Empty)
            {
                tglTerima = (DateTime)dataGridDetail.SelectedCells[0].OwningRow.Cells["TglNota"].Value;
            }
            else
            {
                tglTerima = (DateTime)dataGridDetail.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
            }
           
            tglRQRetur = DateTime.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRQRetur"].Value.ToString());
            tgl = DateTime.Parse("01/08/2004");

            TimeSpan ts = tglRQRetur.Subtract(tglTerima);
            selisihHari = ts.TotalDays;

            if (tglTerima >= tgl && selisihHari > 60.0)
                return true;
            else
                return false;
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
                    CekCetakNotaRetur();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
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

        private void CekCetakNotaRetur()
        {
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGudang"].Value.ToString() != "")
            {
                /* if (dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "2"
                     && !"Ask password manager")
                 {
                     return;
                 } */
            }
            else
            {
                MessageBox.Show("Isi dulu tanggal masuk gudang..!");
                return;
            }

            _nCetak = Convert.ToInt32(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString());
            if (_nCetak > 1)
            {
                frmCetakNotaRetur ifrmDialog = new frmCetakNotaRetur();
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    _nCetak = ifrmDialog.Result;
                }
                else
                    return;
            }

            
            CetakNotaRetur();
            dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value = (Convert.ToInt32(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) + 1).ToString();
            this.dataGridHeader.RefreshEdit();
        }

        private void CetakNotaRetur()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "NOTARETURJUAL"));
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


            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakNotaReturJual")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (PrnAktif == "0")
                    PrintRawNotaRetur(dt);
                else
                    DisplayReport(dt);
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

        private void PrintRawNotaRetur(DataTable dt)
        {
            BuildString retur = new BuildString();

            string NoMPR = dt.Rows[0]["NoMPR"].ToString();
            string NoRetur = dt.Rows[0]["NoNotaRetur"].ToString();
            string TglMPR = Convert.ToDateTime(dt.Rows[0]["TglMPR"].ToString()).ToString("dd-MMM-yyyy");
            string TglNota = (Tools.isNull(dt.Rows[0]["TglNotaRetur"],"").ToString()=="")? string.Empty:Convert.ToDateTime(dt.Rows[0]["TglNotaRetur"].ToString()).ToString("dd-MMM-yyyy");
            string NamaToko = dt.Rows[0]["NamaToko"].ToString().PadRight(31);
            string Alamat = dt.Rows[0]["Alamat"].ToString().PadRight(60);
            string Daerah = dt.Rows[0]["Daerah"].ToString().PadRight(25);
            string IdWil = dt.Rows[0]["WilID"].ToString();
            string Kota = dt.Rows[0]["Kota"].ToString();
            string Penerima = dt.Rows[0]["Penerima"].ToString();
            int No = 0;

            string ketCetak = "";
            if (_nCetak > 1)
                ketCetak = "(COPY)";
            if (_nCetak == 9)
                ketCetak = "(REVISI)";

            #region Header
            retur.FontCondensed(false);


            retur.FontCPI(12);
            retur.DoubleHeight(true);
            retur.DoubleWidth(true);
            retur.PROW(true, 1, retur.SPACE(15) + "NOTA RETUR " + ketCetak);
            retur.DoubleWidth(false);
            retur.DoubleHeight(false);
            retur.FontBold(false);

            retur.FontCPI(10);
            retur.PageLLine(33);
            retur.LeftMargin(0);
            retur.FontBold(true);
            retur.PROW(true, 1, "MPR : " + NoMPR.PadRight(7, ' ') + retur.SPACE(47) + "NOTA : " + NoRetur);
            retur.PROW(true, 1, "Tgl.: " + TglMPR + retur.SPACE(43) + "Tgl. : " + TglNota);
            //retur.PROW(true, 1, "");
            retur.FontCPI(12);
            retur.FontBold(false);
            retur.LineSpacing("1/8");
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintTopLeftCorner() + retur.PrintHorizontalLine(1) + " Nama Toko : " + retur.PrintHorizontalLine(26) + retur.PrintTopRightCorner());
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintVerticalLine() + retur.SPACE(40) + retur.PrintVerticalLine());
            retur.FontBold(true);
            retur.AddCR();
            retur.PROW(false, 56, NamaToko);
            retur.FontBold(false);
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintVerticalLine() + retur.SPACE(40) + retur.PrintVerticalLine());
            retur.FontCondensed(true);
            retur.FontItalic(true);
            retur.AddCR();
            retur.PROW(false, 95, Alamat);
            retur.FontItalic(false);
            retur.FontCondensed(false);
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintVerticalLine() + retur.SPACE(40) + retur.PrintVerticalLine());
            retur.FontCondensed(true);
            retur.FontItalic(true);
            retur.AddCR();
            retur.PROW(false, 95, Daerah);
            retur.FontItalic(false);
            retur.FontCondensed(false);
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintVerticalLine() + retur.SPACE(40) + retur.PrintVerticalLine());
            retur.FontItalic(true);
            retur.AddCR();
            retur.PROW(false, 56, Kota + " (" + IdWil + ")");
            retur.FontItalic(false);
            retur.PROW(true, 1, retur.SPACE(53) + retur.PrintBottomLeftCorner() + retur.PrintHorizontalLine(40) + retur.PrintBottomRightCorner());
            retur.LetterQuality(false);
            retur.FontCondensed(true);
            retur.PROW(true, 1, retur.PrintDoubleLine(157));
            retur.PROW(true, 1, "No. N  a  m  a     B  a  r  a  n  g                                           No.Nota    Sales    Qty      Hrg/Sat  Jml.Hrg(Rp)            Kategori          ");
            retur.PROW(true, 1, retur.PrintHorizontalLine(157));
            #endregion

            #region Detail
            string Sales = string.Empty;
            string Keterangan = string.Empty;
            string NamaStok = string.Empty;
            string AsalNota = string.Empty;
            string Satuan = string.Empty;
            string temp = string.Empty;
            string QtyGudang = string.Empty;
            double HargaJual = 0;
            double Net = 0;
            double TotalNet = 0;
            
            foreach (DataRow dr in dt.Rows)
            {
                No++;
                temp = string.Empty;
                Sales = retur.PadCenter(11,dr["NamaSales"].ToString());
                QtyGudang =dr["QtyGudang"].ToString();
                Net = double.Parse(dr["JmlHrg"].ToString());
                HargaJual = double.Parse(dr["HrgJual"].ToString());
                TotalNet += Net;
                NamaStok = dr["NamaBarang"].ToString().PadRight(73,'.');
                AsalNota = dr["NotaAsal"].ToString().PadRight(7);
                Satuan = dr["Satuan"].ToString().PadRight(3);
                Keterangan = dr["Kategori"].ToString();

                temp += No.ToString().PadLeft(2,'0') + ".  ";
                temp += NamaStok + " ";
                temp += AsalNota + " ";
                temp += Sales;
                temp += QtyGudang.PadLeft(4) + " " + Satuan + " ";
                temp += HargaJual.ToString("#,###").PadLeft(9) + " ";
                temp += Net.ToString("#,###").PadLeft(10) + "   ";
                temp += retur.PadCenter(25,Keterangan.Trim());
                retur.PROW(true, 1, temp);
            }
            No++;

            for (int i = No; i <= 15; i++)
            {
                retur.PROW(true, 1, i.ToString().PadLeft(2, '0') + ". ");
            }
            #endregion

            #region Footer
            retur.PROW(true, 1, retur.PrintDoubleLine(157));
            retur.PROW(true, 1, retur.SPACE(104) + "Netto : Rp." + TotalNet.ToString("#,###").PadLeft(10));
            retur.LineSpacing("1/6");
            retur.FontBold(false);
            retur.FontCondensed(false);
            retur.PROW(true, 1, "     Mengetahui :");
            retur.PROW(true, 1, "     Bag. Gudang                                                           Bag. ADMIN  ");
            retur.PROW(true, 1, "");
            retur.PROW(true, 1, "");
            retur.PROW(true, 1, "    (" + retur.PadCenter(12,Penerima.Trim()) + ")                                                        (           )");
            retur.Eject();
            #endregion

            //retur.SendToPrinter("NotaRetur.txt");
            retur.SendToFile("NotaRetur.txt");
        }

        public void DisplayReport(DataTable dt)
        {
            string ketCetak = "";
            if (_nCetak == 1)
                ketCetak = "(COPY)";
            if (_nCetak == 2)
                ketCetak = "(REVISI)";

            string NoMPR = dt.Rows[0]["NoMPR"].ToString();
            string NoRetur = dt.Rows[0]["NoNotaRetur"].ToString();
            DateTime TglMPR = DateTime.Parse(dt.Rows[0]["TglMPR"].ToString());
            string TglNota = (Tools.isNull(dt.Rows[0]["TglNotaRetur"], "").ToString() == "") ? string.Empty : Convert.ToDateTime(dt.Rows[0]["TglNotaRetur"].ToString()).ToString("dd-MMM-yyyy");
            string NamaToko = dt.Rows[0]["NamaToko"].ToString().PadRight(31);
            string Alamat = dt.Rows[0]["Alamat"].ToString().PadRight(60);
            string Daerah = dt.Rows[0]["Daerah"].ToString().PadRight(25);
            string IdWil = dt.Rows[0]["WilID"].ToString();
            string Kota = dt.Rows[0]["Kota"].ToString();
            string Penerima = dt.Rows[0]["Penerima"].ToString();
            string UserID = SecurityManager.UserName.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NoMpr", NoMPR));
            rptParams.Add(new ReportParameter("TglMpr", TglMPR.ToString()));
            rptParams.Add(new ReportParameter("KetCetak", ketCetak));
            rptParams.Add(new ReportParameter("NoNotaRetur", NoRetur));
            rptParams.Add(new ReportParameter("TglNotaRetur", TglNota));
            rptParams.Add(new ReportParameter("NamaToko", NamaToko));
            rptParams.Add(new ReportParameter("Alamat", Alamat));
            rptParams.Add(new ReportParameter("Daerah", Daerah));
            rptParams.Add(new ReportParameter("Kota", Kota));
            rptParams.Add(new ReportParameter("UserID", UserID));


            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaReturJualBaru.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Print();
            //ifrmReport.Show();

            if (PrnAktif == "2" || PrnAktif == "3")
            {
                ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaReturJualBaru_copy1.rdlc", rptParams, dt, "dsReturPenjualan_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
            }
            if (PrnAktif == "3")
            {
                ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaReturJualBaru_copy2.rdlc", rptParams, dt, "dsReturPenjualan_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
            }

        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double nilairet = double.Parse(Tools.isNull(dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Value, 0).ToString());
            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(nilairet.ToString("#,##0.00"));
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
            dataGridDetail.Columns["JmlHrg"].DefaultCellStyle.Format = "#,##0.00";
            dataGridDetail.Columns["HrgNetto"].DefaultCellStyle.Format = "#,##0.00";

            normal = !_acak;
            dataGridHeader.Columns["NilaiRetur"].Visible = _acak;
            dataGridDetail.Columns["HrgJual"].Visible = _acak;
            dataGridDetail.Columns["JmlHrg"].Visible = _acak;
            dataGridDetail.Columns["HrgNetto"].Visible = _acak;

            //acak
            dataGridHeader.Columns["NilaiReturAck"].Visible = normal;
            dataGridDetail.Columns["HrgJualAck"].Visible = normal;
            dataGridDetail.Columns["JmlHrgAck"].Visible = normal;
            dataGridDetail.Columns["HrgNettoAck"].Visible = normal;
            _acak = normal;

            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            if (dataGridDetail.DataSource != null)
            {
                if (dtReturDetail.Compute("SUM(JmlHrg2)", string.Empty).Equals(string.Empty))
                {
                    jmlHrgRet = 0;
                }
                else
                {
                    jmlHrgRet = double.Parse(dtReturDetail.Compute("SUM(JmlHrg2)", string.Empty).ToString());
                }
                if (dtReturDetail.Compute("SUM(HrgNetto2)", string.Empty).ToString().Equals(string.Empty))
                {
                    netto = 0;
                }
                else
                {
                    netto = double.Parse(dtReturDetail.Compute("SUM(HrgNetto2)", string.Empty).ToString());
                }
            }
            else
            {
                jmlHrgRet = 0;
                netto = 0;
            }

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

        private  string NeedACC(Guid RowID_, DateTime TglMPR_)
        {
            string res=string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_ReturPenjualanDetail_ChekACC]")); // cek heri
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID_));
                db.Commands[0].Parameters.Add(new Parameter("@TglMPR", SqlDbType.DateTime, TglMPR_));
                dt = db.Commands[0].ExecuteDataTable();
            }

            foreach (DataRow dr in dt.Rows)
            {
                res = res + dr["NamaStok"].ToString().Trim() + System.Environment.NewLine;
            }
            return res;
        }


        private string NeedACCSPV(Guid RowID_)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_ReturPenjualanCekACCSPV]")); // cek heri
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID_));
                //db.Commands[0].Parameters.Add(new Parameter("@TglMPR", SqlDbType.DateTime, TglMPR_));
                dt = db.Commands[0].ExecuteDataTable();
            }

            foreach (DataRow dr in dt.Rows)
            {
                res = res + dr["NamaStok"].ToString().Trim() + System.Environment.NewLine;
            }
            return res;
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                    RefreshDataReturJualDetail();
            }
        }

        private bool validasiSync(Guid RowID)
        {
            bool hasil = true;
            for (int a = 0; a < dataGridDetail.Rows.Count; ++a)
            {
                int _QtyRetur = Convert.ToInt32(dataGridDetail.Rows[a].Cells["QtyGudang"].Value);
                if (_QtyRetur == 0)
                {
                    MessageBox.Show("Masih Ada Item yang Qty Gudang = 0");
                    hasil = false;
                    return hasil;
                }
               
            }
            using (Database db = new Database())
            {
                DataTable dt;
                db.Commands.Add(db.CreateCommand("usp_cekAG"));
                db.Commands[0].Parameters.Add(new Parameter("@rowIDRetur ", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Retur Sudah Di Sync");
                    hasil = false;
                    return hasil;
                }
            }

            return hasil;
        }

        private void insertAG(Guid _HeaderID,string _HRecID)
        {
            try
            {
                string docNoDO = "NOMOR_ANTAR_GUDANG";
                this.Cursor = Cursors.WaitCursor;
                string _checker = "";
                Guid _RowID = Guid.NewGuid();
                string _recID = _HRecID.ToString();             // Tools.CreateFingerPrint();
                using (Database db = new Database())
                {
                    DataTable ck;
                    db.Commands.Add(db.CreateCommand("usp_Checker_LIST"));
                    ck = db.Commands[0].ExecuteDataTable();

                    if (ck.Rows.Count > 0)
                    {
                        _checker=ck.Rows[0]["FirstName"].ToString();
                    }
                }
                //insert Header AG 2803
                using (Database db = new Database())
                {
                    DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                    int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    string depan = Tools.GeneralInitial();
                    string belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;

                    string _NoAG = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                    
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID ", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID ", SqlDbType.VarChar, _recID));
                    db.Commands[0].Parameters.Add(new Parameter("@DrGudang ", SqlDbType.VarChar, "2803"));
                    db.Commands[0].Parameters.Add(new Parameter("@KeGudang ", SqlDbType.VarChar, "2801"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKirim ", SqlDbType.DateTime, DateTime.Today.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima ", SqlDbType.DateTime, DateTime.Today.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, "2803"));
                    db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@NoAG", SqlDbType.VarChar, _NoAG));
                    db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar, _checker));
                    db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, _checker));
                    db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan ", SqlDbType.VarChar, "Retur Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@NoKendaraan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaSopir", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                }

                //insert Detail AG
                for (int a = 0; a < dataGridDetail.Rows.Count; ++a)
                {
                    int _QtyRetur = Convert.ToInt32(dataGridDetail.Rows[a].Cells["QtyGudang"].Value);
                    string _KodeBarang = Convert.ToString(dataGridDetail.Rows[a].Cells["BarangID"].Value);
                    string _RecordID = _HRecID.Substring(0, 19) + a.ToString().PadLeft(3, '0');
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_Insert"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordID));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, _recID));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, _QtyRetur));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKirim", SqlDbType.Int, _QtyRetur));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, _QtyRetur));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _KodeBarang));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Ongkos", SqlDbType.Int, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                    }
                }
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekAG"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowIDRetur", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@rowIDAG", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@action", SqlDbType.VarChar, "Sync 2801"));
                    db.Commands[0].ExecuteNonQuery();
                }

                for (int a = 0; a < dataGridDetail.Rows.Count; ++a)
                {
                    int _QtyRetur = Convert.ToInt32(dataGridDetail.Rows[a].Cells["QtyGudang"].Value);
                    string _KodeBarang = Convert.ToString(dataGridDetail.Rows[a].Cells["BarangID"].Value);
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_StokGudang2801_Recalculation"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _KodeBarang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil di Sync ke 2801");
                this.DialogResult = DialogResult.OK;

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

        private void cmdSync2801_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                Guid _headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                string _HRecID = dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderReturID"].Value.ToString();
                if (validasiSync(_headerID))
                    insertAG(_headerID,_HRecID);

                cmdSearch.PerformClick();
                FindHeader("HeaderRowID", _headerID.ToString());
            }
            
        }

        private void dataGridHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (GlobalVar.Gudang == "2803")
            {
                for (int rowIndex = 0; rowIndex < dataGridHeader.Rows.Count; rowIndex++)
                {
                    if (dataGridHeader.Rows[rowIndex].Cells["HeaderSyncFlag"].Value.ToString() == "False")
                        dataGridHeader.Rows[rowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                    else
                        dataGridHeader.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;

                }
            }
        }

        private void btnPullWiserDC_Click(object sender, EventArgs e)
        {
            RJ3.frmReturPenjualanSynch frm = new RJ3.frmReturPenjualanSynch();
            frm.ShowDialog();
            //if (frm.Result == DialogResult.OK) RefreshDataBO();
        }
    }
}
