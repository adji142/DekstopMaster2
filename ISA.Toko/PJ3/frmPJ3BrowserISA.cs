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
using System.Data.SqlTypes;
using ISA.Toko.Class;

namespace ISA.Toko.PJ3
{
    public partial class frmPJ3BrowserISA : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumFormMode { Header, Detail };
        enumFormMode _selectedGrid;
        DataTable dtHeader, dtDetail;
        string _initPrs = GlobalVar.PerusahaanID, _initCab = GlobalVar.CabangID;
        bool _acak;

        DateTime _fromDate, _toDate;

        public frmPJ3BrowserISA()
        {
            InitializeComponent();
        }

        private void frmPJ3BrowserISA_Load(object sender, EventArgs e)
        {
            _acak = false;
            _fromDate = DateTime.Now; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _toDate = DateTime.Now;
            rgbTglPenjualan.FromDate = _fromDate;
            rgbTglPenjualan.ToDate = _toDate;
            dataGridNotaJual.AutoGenerateColumns = false;
            dataGridNotaJualDetail.AutoGenerateColumns = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataNotaJual();
        }        

        private void rgbTglPenjualan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                cmdSearch.PerformClick(); 
            }
        }

        public void RefreshDataNotaJual()
        {
            _fromDate = (DateTime)rgbTglPenjualan.FromDate;
            _toDate = (DateTime)rgbTglPenjualan.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaPenjualan_LIST_FILTER_TglSuratJalan_PJ3]")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridNotaJual.DataSource = dtHeader;

                if (dataGridNotaJual.SelectedCells.Count > 0)
                {
                    dataGridNotaJual.Focus();
                    RefreshDataNotaJualDetail();
                    lblStokDanToko.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                    lblCabPrs.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaHtrID"].Value.ToString().Substring(0, 3);
                }
                else
                {
                    dataGridNotaJualDetail.DataSource = null;
                    lblStokDanToko.Text = "";
                    RefreshLabel();
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

        public void RefreshRowDataNotaJual(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_TglSuratJalan_PJ3")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridNotaJual.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());                  
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

        public void RefreshDataNotaJualDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetail = new DataTable();
                Guid _headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridNotaJualDetail.DataSource = dtDetail;
                }

                RefreshLabel();
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

        public void RefreshRowDataNotaJualDetail(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_RowID")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridNotaJualDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    this.dataGridNotaJualDetail.RefreshEdit();
                }
                RefreshLabel();
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

        private void dataGridNotaJual_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.F5:
                        RefreshDataNotaJual();
                        break;
                    case Keys.K:
                        /*Cetak Nota Koreksi*/
                        CetakNotaKoreksi();
                        break;
                    case Keys.F1:
                        /*Tampilkan histori penjualan*/
                        PJ3.frmHistoryPenjualanBrowser ifrmChild = new PJ3.frmHistoryPenjualanBrowser(_fromDate, _toDate);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                }
            }

            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F9:
                        AcakTampilHrg();
                        break;
                    //case Keys.F12:
                    //    BatalPJ3();
                    //    break;
                    //case Keys.F2:
                    //    /*Link Piutang Masal untuk anak cabang*/
                    //    if (SecurityManager.IsPiutang() || SecurityManager.IsManager())
                    //    {
                    //        PJ3.frmLinkPiutangMasalFilterISA ifrmChild = new PJ3.frmLinkPiutangMasalFilterISA(this, false);
                    //        ifrmChild.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmChild);
                    //        ifrmChild.Show();
                    //    }
                    //    break;
                    //case Keys.F3:
                    //    /*Link Piutang Masal untuk anak cabang per toko*/
                    //    if (SecurityManager.IsPiutang() || SecurityManager.IsManager())
                    //    {
                    //        PJ3.frmLinkPiutangMasalFilterISA ifrmChild2 = new PJ3.frmLinkPiutangMasalFilterISA(this, true);
                    //        ifrmChild2.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmChild2);
                    //        ifrmChild2.Show();
                    //    }
                    //    break;

                    case Keys.Space:
                        //if (dataGridNotaJual.SelectedCells.Count > 0)
                        //{
                        //    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0, 1) == "T")
                        //    {
                        //        if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim() == "ECERAN CASH" &&
                        //            dataGridNotaJual.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString().Trim().Substring(7, 3) != "VIA")
                        //        {
                        //            MessageBox.Show("Transaksi Tunai tidak bisa dilink ke Piutang");
                        //            return;
                        //        }
                        //    }

                        //    string recordID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                        //    if (recordID.Substring(0,3) != GlobalVar.PerusahaanID)
                        //    {
                        //        MessageBox.Show("Nota ini bukan berasal dari cabang/pos " + GlobalVar.PerusahaanID);
                        //        return;
                        //    }
                        //    string tglTerima = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString();
                        //    if (tglTerima == "")
                        //    {
                        //        if (SecurityManager.IsPiutang() || SecurityManager.IsManager())
                        //        {
                        //            ProsesPJ3();
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (MessageBox.Show ("Data sudah di link ke piutang. Link ulang ?","Link", MessageBoxButtons.YesNo ) == DialogResult.Yes)
                        //        {
                        //            if (SecurityManager.AskPasswordManager())
                        //            {                                    
                        //                ProsesPJ3();
                        //            }
                        //        }
                        //    }
                        //}
                        break;
                    case Keys.F11:
                        MessageBox.Show("KOREKSI DILAKUKAN HANYA PADA DETAIL...!");
                        break;
                    case Keys.Delete:
                        MessageBox.Show("PJ3 TIDAK BOLEH HAPUS...!");
                        break;
                    case Keys.Insert:
                        MessageBox.Show("PJ3 TIDAK BOLEH INPUT...!");
                        break;
                    case Keys.Tab:
                        dataGridNotaJualDetail.Focus();
                        break;
                }
            }
        }

        private void CetakNotaKoreksi()
        {
            Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            string noNota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakNotaKoreksiJual")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nota " + noNota + " ini tidak ada koreksi...!");
                }
                else
                {
                    //DisplayReport(dt);
                    PrintRawNotaKoreksi(dt);
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

        private double HitungRpNet2(DataTable dt)
        {
            double retVal = 0;

            foreach (DataRow dr in dt.Rows)
            {
                retVal += (int.Parse(dr["QtyNota"].ToString()) * double.Parse(dr["HrgJual"].ToString())) - double.Parse(dr["Disc"].ToString());
            }

            return retVal;
        }

        private void PrintRawNotaKoreksi(DataTable dt)
        {
            BuildString nota = new BuildString();

            #region Header
            string namaToko = dt.Rows[0]["NamaToko"].ToString();
            string alamat = dt.Rows[0]["Alamat"].ToString().PadRight(60);
            string kota = dt.Rows[0]["Kota"].ToString().PadRight(20);
            string noNota = dt.Rows[0]["NoNota"].ToString();
            string tglNota = DateTime.Parse(dt.Rows[0]["TglNota"].ToString()).ToString("dd-MMM-yyyy");
            double rpNet2 = HitungRpNet2(dt);

            nota.PROW(true,0,"");
            nota.PageLInch(6);
            nota.LeftMargin(3);
            nota.FontCPI(12);    
		    nota.LineSpacing("1/8");
            nota.AddCR();
            nota.PROW(false,0,nota.SPACE(69) + DateTime.Now.ToString("dd-MMM-yyy"));
            nota.PROW(true,0,nota.SPACE(36));
 		    nota.FontBold(true);
            nota.PROW(true,0,"Kepada Yth,");
 		    nota.FontBold(false);
            nota.PROW(true,0, "T o k o : " + namaToko);
            nota.PROW(true,0, nota.SPACE(10) + alamat);
            nota.PROW(true,0, nota.SPACE(10) + kota);
 		    nota.PROW(true,0,nota.SPACE(36));
 		    nota.FontBold(true);
 		    nota.PROW(true,0, "Hal : Koreksi Nota");
 		    nota.FontBold(false);
 		    nota.PROW(true,0,nota.SPACE(36));
 		    nota.PROW(true,0,"Dengan hormat, ");
 		    nota.PROW(true,0,nota.SPACE(36));
 		    nota.PROW(true,0, "Dengan ini kami beritahukan bahwa pada Nota Saudara No. " + noNota + ", tertanggal :  " + tglNota);
            nota.PROW(true, 0, "sejumlah Netto: Rp. " + rpNet2.ToString("#,###") + " terdapat kesalahan.");
            #endregion

            #region Detail Lama
            nota.PROW(true,0,nota.SPACE(36));
 		    nota.PROW(true,0,"Tercetak pada Nota : ");
 		    nota.PROW(true,0,nota.SPACE(36));
            nota.FontCPI(12);
 		    nota.FontCondensed(true);
 		    nota.FontUnderline(true);
 		    nota.PROW(true,0, "No. N  a  m  a     B  a  r  a  n  g" + nota.SPACE(48) + "Qty   Harga/Sat(Rp)  Jumlah Harga" + nota.SPACE(15) + "Discount/Potongan   ");
 		    nota.FontUnderline(false);

            string temp = string.Empty;
            string namaStok = string.Empty;
            string satuan = string.Empty;
            double hargaJual = 0;
            double jumlahHarga = 0;
            double diskon = 0, diskon1 = 0, diskon2 = 0, diskon3 = 0;
            int jumlahNota = 0;
            int No = 0;

            foreach (DataRow dr in dt.Rows)
            {
                No++;
                namaStok = dr["NamaBarang"].ToString();
                jumlahNota =int.Parse(dr["QtyNota"].ToString());
                satuan = dr["Satuan"].ToString();
                hargaJual = double.Parse(dr["HrgJual"].ToString());
                jumlahHarga = double.Parse(dr["JmlHrg"].ToString());
                diskon1 = double.Parse(dr["Disc1"].ToString());
                diskon2 = double.Parse(dr["Disc2"].ToString());
                diskon3 = double.Parse(dr["Disc3"].ToString());
                diskon = double.Parse(dr["Disc"].ToString());

                temp = string.Empty;
                temp += No.ToString().PadLeft(2, '0') + ". " + namaStok.PadRight(73, '.');
                temp += jumlahNota.ToString("#,###").PadLeft(5) + " " + satuan.PadLeft(3);
                temp += hargaJual.ToString("#,###").PadLeft(9);
                temp += "   Rp." + jumlahHarga.ToString("#,###").PadLeft(11) + "   ";
                temp += diskon1.ToString("##,##").PadLeft(7) + "% ";
                temp += diskon2.ToString("##,##").PadLeft(5) + "% ";
                temp += diskon3.ToString("##,##").PadLeft(5) + "% Rp.";
                temp += diskon.ToString("#,###").PadLeft(10);

                nota.PROW(true, 0, "");
                nota.PROW(true, 0, temp);
            }
            
            nota.FontCondensed(true);
 		    nota.FontBold(false);
            #endregion

            #region Detail Koreksi
            nota.PROW(true,0,nota.SPACE(36));
 		    nota.PROW(true,0,"Berturut-turut seharusnya sebagai berikut  : ");
            nota.PROW(true, 0, nota.SPACE(36));
            nota.FontCPI(12);
 		    nota.FontCondensed(true);
 		    nota.FontUnderline(true);
            nota.PROW(true,0, "No. N  a  m  a     B  a  r  a  n  g" + nota.SPACE(48) + "Qty   Harga/Sat(Rp)  Jumlah Harga" + nota.SPACE(15) + "Discount/Potongan   ");
		    nota.FontUnderline(false);

            string tempKoreksi = string.Empty;
            string namaStokKoreksi = string.Empty;
            string satuanKoreksi = string.Empty;
            double hargaJualKoreksi = 0;
            double jumlahHargaKoreksi = 0;
            double diskonKoreksi = 0, diskon1Koreksi = 0, diskon2Koreksi = 0, diskon3Koreksi = 0;
            double totalKoreksi = 0;
            int jumlahNotaKoreksi = 0;
            int NoKoreksi = 0;

            foreach (DataRow dr in dt.Rows)
            {
                NoKoreksi++;
                namaStokKoreksi = dr["NamaBarang"].ToString();
                jumlahNotaKoreksi = int.Parse(dr["QtyNotaBaru"].ToString());
                satuanKoreksi = dr["Satuan"].ToString();
                hargaJualKoreksi = double.Parse(dr["HrgJualBaru"].ToString());
                jumlahHargaKoreksi = double.Parse(dr["JmlHrgKoreksi"].ToString());
                diskon1Koreksi = double.Parse(dr["Disc1"].ToString());
                diskon2Koreksi = double.Parse(dr["Disc2"].ToString());
                diskon3Koreksi = double.Parse(dr["Disc3"].ToString());
                diskonKoreksi = double.Parse(dr["DiscKoreksi"].ToString());

                totalKoreksi += jumlahHargaKoreksi;

                tempKoreksi = string.Empty;
                tempKoreksi += NoKoreksi.ToString().PadLeft(2, '0') + ". " + namaStokKoreksi.PadRight(73, '.');
                tempKoreksi += jumlahNotaKoreksi.ToString("#,###").PadLeft(5) + " " + satuanKoreksi.PadLeft(3);
                tempKoreksi += hargaJualKoreksi.ToString("#,###").PadLeft(9);
                tempKoreksi += "   Rp." + jumlahHargaKoreksi.ToString("#,###").PadLeft(11) + "   ";
                tempKoreksi += diskon1Koreksi.ToString("##,##").PadLeft(7) + "% ";
                tempKoreksi += diskon2Koreksi.ToString("##,##").PadLeft(5) + "% ";
                tempKoreksi += diskon3Koreksi.ToString("##,##").PadLeft(5) + "% Rp.";
                tempKoreksi += diskonKoreksi.ToString("#,###").PadLeft(10);

                nota.PROW(true, 0, "");
                nota.PROW(true, 0, tempKoreksi);
            }
            #endregion

            #region Footer
            nota.FontCPI(12);
 		    nota.FontCondensed(false);
 		    nota.FontBold(false);
		    nota.PROW(true,0,nota.SPACE(36));
 		    nota.PROW(true,0,"Sehingga Nilai Nota yang sebenarnya adalah : ");
		    nota.FontBold(true);
 		    nota.Append("Rp. "+ totalKoreksi.ToString("#,###") +" (Netto)");
		    nota.FontBold(false);
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"Demikian surat pemberitahuan ini. Terima Kasih atas perhatian dan kerjasamanya selama ini." );
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"        Penerima :                                                  Hormat Kami     ");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true, 0, "    (                )                                           (                ) ");
            nota.PROW(true, 0, "  Tanda tangan & Cap Toko                                         Bagian Penjualan  ");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
		    nota.PROW(true,0,"");
            #endregion

            nota.SendToPrinter("NotaKoreksi.txt");
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PJ3.rptCetakNotaKoreksi.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            //ifrmReport.Print();
            ifrmReport.Show();
        }

        private void BatalPJ3()
        {
            if (!CekSudahLinkPiutang())
            {
                MessageBox.Show("NOTA SUDAH LINK KE API...!", "PERHATIAN");
                return;
            }

            if (int.Parse(lblJmlQtyNota.Text) != 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        // Proses batal PJ3
                        for (int i = 0; i < dataGridNotaJualDetail.RowCount; i++)
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE")); //cek heri
                            db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetail.DefaultView[i]["HtrID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DOID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DODetailID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                            // Merubah QtyTerima menjadi 0
                            db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc1"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc2"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc3"]));
                            db.Commands[i].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetail.DefaultView[i]["DiscFormula"]));
                            db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                            db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, 0));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, dtDetail.DefaultView[i]["QtyKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAwal"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAkhir"]));
                            db.Commands[i].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan"]));
                            db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[i].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["KetKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }
                        int _nextIndex = db.Commands.Count;
                        int _headerIndex = dataGridNotaJual.SelectedCells[0].OwningRow.Index;

                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE")); //cek heri
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtHeader.DefaultView[_headerIndex]["RowID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["HtrID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["RecordID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, dtHeader.DefaultView[_headerIndex]["DOID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, ""));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["NoSuratJalan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, dtHeader.DefaultView[_headerIndex]["TglSuratJalan"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang2"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cabang3"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["KodeSales"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["KodeToko"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["alamatKirim"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Kota"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtHeader.DefaultView[_headerIndex]["isClosed"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cat1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cat2"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cat3"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cat4"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Cat5"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["LinkID"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["NPrint"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Checker1"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["Checker2"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, dtHeader.DefaultView[_headerIndex]["TransactionType"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["HariKredit"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["HariKirim"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, dtHeader.DefaultView[_headerIndex]["HariSales"]));
                        db.Commands[_nextIndex].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        for (int j = 0; j < db.Commands.Count; j++)
                        {
                            db.Commands[j].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    Guid headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                    RefreshRowDataNotaJual(headerID.ToString());
                    RefreshDataNotaJualDetail();
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

        private bool CekSudahLinkPiutang()
        {
            Guid recordID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            
            bool cek = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int _a = 0;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Piutang_CHEK"));//cek heri 05 mar 2013
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, recordID));
                    _a = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                }
                if (_a == 0)
                {
                    cek = false;
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
            return cek;
        }

        private void ProsesPJ3()
        {
            string cab1 = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["C1"].Value.ToString();
            string cab2 = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["C2"].Value.ToString();
            string linkID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaLinkID"].Value.ToString();
            string notaRecID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
            

            bool cekValue = GlobalVar.HasKasir;

            if (Tools.Left(notaRecID,3)!=GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Nota Dari Cabang Lain!!!" + System.Environment.NewLine + Tools.Left(notaRecID, 3));
                return;
            }

            //if (_initCab != cab1)
            //{
            //    MessageBox.Show("Initial cabang beda dengan cabang1");
            //    return;
            //}
            //if (cekValue && (linkID == "2" || linkID == "C"))
            //{
            //    MessageBox.Show("Link nota anak cabang gunakan F2");
            //    return;
            //}
            //if (!cekValue && (linkID == "1" || linkID.Trim() == ""))
            //{
            //    MessageBox.Show("Link ID Pos harus -> C");
            //    return;
            //}
            //if (notaRecID.Substring(0, 3) != _initPrs && cab1 == _initCab && cab2 == _initCab)
            //{
            //    MessageBox.Show("Nota Pos isi Tgl Terima di Pos...!");
            //    return;
            //}

            // TODO: Tambah proses ask password manager

            // Proses PJ3
            if (int.Parse(lblJmlQtyNota.Text) == 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        // Proses memindahkan QtySJ ke QtyNota
                        for (int i = 0; i < dataGridNotaJualDetail.RowCount; i++)
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE")); //cek heri 05 mar 2013

                            db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["RowID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtDetail.DefaultView[i]["RecordID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["HeaderID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetail.DefaultView[i]["HtrID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DOID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, dtDetail.DefaultView[i]["DODetailID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                            // Copy QtySJ ke QtyNota
                            db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetail.DefaultView[i]["BarangID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetail.DefaultView[i]["HrgJual"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc1"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc2"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetail.DefaultView[i]["Disc3"]));
                            db.Commands[i].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetail.DefaultView[i]["DiscFormula"]));
                            db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetail.DefaultView[i]["Pot"]));
                            db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtDetail.DefaultView[i]["KodeGudang"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, dtDetail.DefaultView[i]["QtySuratJalan"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, dtDetail.DefaultView[i]["QtyKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAwal"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, dtDetail.DefaultView[i]["KoliAkhir"]));
                            db.Commands[i].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["NoKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetail.DefaultView[i]["Catatan"]));
                            db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[i].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dtDetail.DefaultView[i]["KetKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }

                        db.BeginTransaction();
                        for (int j = 0; j < db.Commands.Count; j++)
                        {
                            db.Commands[j].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    RefreshDataNotaJualDetail();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            } // Isi QtyNota selesai

            //if (!CekRpNet2dan3())
            //{
            //    MessageBox.Show("RP_NET2 BEDA DENGAN RP_NET3...!");
            //    return;
            //}

            Guid _headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            PJ3.frmPJ3UpdateISA ifrmChild = new PJ3.frmPJ3UpdateISA(this, _headerID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private bool CekRpNet2dan3()
        {
            bool cek = true;
            Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtRpNet = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID")); // cek heri 05 mar 2013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRpNet = db.Commands[0].ExecuteDataTable();
                }
                if (Double.Parse(dtRpNet.Rows[0]["RpNet2"].ToString()) != Double.Parse(dtRpNet.Rows[0]["RpNet3"].ToString()))
                {
                    cek = false;
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

            return cek;
        }

        private void dataGridNotaJualDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                //if (SecurityManager.IsAdministrator() || SecurityManager.IsManager())
                //{
                    Koreksi();
                //}
            }

            if (e.KeyCode == Keys.F12)
            {
                
                    if (CekSudahPernahKoreksi())
                    {
                        if (dataGridNotaJualDetail.SelectedCells.Count > 0)
                        {
                            string recID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                            Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                            PJ3.frmKoreksiJualBrowser2 ifrmChild = new PJ3.frmKoreksiJualBrowser2(this, notaDetailID, recID);
                            //ifrmChild.MdiParent = Program.MainForm;
                            //Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.WindowState = FormWindowState.Normal;
                            ifrmChild.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                        }
                    }
                
            }
            
            if (e.KeyCode == Keys.F9)
            {
                AcakTampilHrg();
            }

            if (e.KeyCode == Keys.Delete)
            {
                MessageBox.Show("PJ3 TIDAK BOLEH HAPUS...!");
            }

            if (e.KeyCode == Keys.Insert)
            {
                MessageBox.Show("PJ3 TIDAK BOLEH INPUT...!");
            }

            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("LINK DILAKUKAN HANYA PADA HEADER...!");
            }

            if (e.KeyCode == Keys.Tab)
            {
                dataGridNotaJual.Focus();
            }
        }

        private void Koreksi()
        {
            if (_selectedGrid == enumFormMode.Detail)
            {
                string notaRecID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();

                //if (Tools.Left(notaRecID, 3) != GlobalVar.PerusahaanID)
                //{
                //    MessageBox.Show("Nota Dari Cabang Lain!!!" + System.Environment.NewLine + Tools.Left(notaRecID, 3));
                //    return;
                //}
                if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == "") 
                {
                    MessageBox.Show("Koreksi tidak bisa dilakukan jika Tanggal Terima belum diisi. Silahkan Isi Tanggal Terima toko dahulu.!");
                    return;
                }
                
                string xx = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaLinkID"].Value.ToString();

                //if (xx == "" || xx == "C")
                //{
                //    return;
                //}

                //if (_initPrs != lblCabPrs.Text)
                //{
                //    MessageBox.Show("Koreksi hanya bisa di lakukan untuk kode gudang/init perusahaan yang sama saja!");
                //    return;
                //}

                if (dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["QtyNota"].Value.ToString() == "0")
                {
                    MessageBox.Show("QTY NOTA 0 TIDAK BISA DILAKUKAN KOREKSI !");
                    return;
                }
                //if (CekSudahPernahRetur())
                //{
                //    MessageBox.Show("Record ini sudah pernah diretur, tidak boleh dikoreksi");
                //    return;
                //}
                //if (CekSudahAdaPotongan())
                //{
                //    MessageBox.Show("Nota ini sudah pernah terjadi potongan (DIL), tidak boleh dikoreksi");
                //    return;
                //}

                if (("12").Contains(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaLinkID"].Value.ToString()) == false
                    && dataGridNotaJual.SelectedCells[0].OwningRow.Cells["C1"].Value.ToString() == _initCab)
                {
                    MessageBox.Show("KOREKSI DILAKUKAN SETELAH LINK PIUTANG !");
                    return;
                }



                //if (CekSudahPernahKoreksi())
                //{
                //    MessageBox.Show("Record ini sudah pernah di Koreksi, tidak boleh dikoreksi");
                //    return;
                //}

                /*
                            *!*			IF VAL(RIGHT(cINITPRS,2))<>0 AND Htransj.Id_link=="2"
                *!*				RETURN
                *!*			ENDIF
                *!*			IF Dtransj.J_nota==0
                *!*				MESSAGEBOX("QTY NOTA 0 TIDAK BISA DILAKUKAN KOREKSI !",0+16,"PERINGATAN")
                *!*				RETURN
                *!*			ENDIF
                *!*			IF Dtransj.J_retur>0
                *!*				MESSAGEBOX('Record ini sudah pernah diretur, tidak boleh dikoreksi',16,'Perhatian!')
                *!*				RETURN 
                *!*			ENDIF 
                *!*			IF SEEK(htransj.idtr,'hpotj') AND hpotj.disc_acc>0
                *!*				MESSAGEBOX('Nota ini sudah pernah terjadi potongan (DIL), tidak boleh dikoreksi',16,'Perhatian!')
                *!*				RETURN 
                *!*			ENDIF 
                *!*			IF Htransj.Id_link$"12" OR Htransj.Cab1 <> cINITCAB
                                DO FORM Kor_pj
                *!*			ELSE
                *!*				MESSAGEBOX("KOREKSI DILAKUKAN SETELAH LINK PIUTANG !",0+16,"PERINGATAN")
                *!*			ENDIF
                */
                if (dataGridNotaJualDetail.SelectedCells.Count > 0)
                {
                    string recID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                    Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                    PJ3.frmKoreksiJualBrowser ifrmChild = new PJ3.frmKoreksiJualBrowser(this, notaDetailID, recID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
        }

        public bool CekSudahPernahRetur()
        {
            bool cek = false;
            Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int i=0;
                using (Database db = new Database())
                {
                
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_Chek")); // cek heri 05 mar 2013
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, notaDetailID));
                    i = (int)db.Commands[0].ExecuteScalar();
                   
                }
                if (i > 0)
                {
                    cek = true;
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
            return cek;
        }

        public bool CekSudahPernahKoreksi()
        {
            bool cek = false;
            Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int i = 0;
                using (Database db = new Database())
                {
                   // DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[usp_KoreksiPenjualan_Chek]")); //cek heri 05032013
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, notaDetailID));
                    i = (int)db.Commands[0].ExecuteScalar();
                }
                if (i > 0)
                {
                    cek = true;
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
            return cek;
        }

        public bool CekSudahAdaPotongan()
        {
            bool cek = false;
            int i = 0;
            Guid notaID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_Chek")); //cek heri 05032013
                    db.Commands[0].Parameters.Add(new Parameter("@notaPenjualanID", SqlDbType.UniqueIdentifier, notaID));
                    i = (int)db.Commands[0].ExecuteScalar();
                  
                }

                if (i > 0)
                {
                    cek = true;
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
            return cek;
        }

        private void dataGridNotaJual_Click(object sender, EventArgs e)
        {
            if (dataGridNotaJual.SelectedCells.Count > 0)
            {
                RefreshDataNotaJualDetail();
                lblStokDanToko.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                lblCabPrs.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaHtrID"].Value.ToString().Substring(0, 3);
            }
            else
            {
                dataGridNotaJualDetail.DataSource = null;
                lblStokDanToko.Text = "";
                lblCabPrs.Text = "";
            }
        }

        private void dataGridNotaJualDetail_Click(object sender, EventArgs e)
        {
            if (dataGridNotaJualDetail.SelectedCells.Count != 0)
            {
                lblStokDanToko.Text = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblStokDanToko.Text = "";
            }
        }

        private void dataGridNotaJual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Isi Acak
            double nota = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["RpJual"].Value, 0).ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNet"].Value, 0).ToString());

            dataGridNotaJual.Rows[e.RowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(nota.ToString("#,##0.00"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0.00"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0.00"));

            dataGridNotaJual.Rows[e.RowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dataGridNotaJual.Rows[e.RowIndex].Cells["NotaLinkID"].Value.ToString() != "")
            {
                dataGridNotaJual.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void dataGridNotaJualDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Isi Acak
            double dethrg = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJual"].Value, 0).ToString());
            double detjuml = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgJual"].Value, 0).ToString());
            double detpot = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPot"].Value, 0).ToString());
            double jmlpot = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPot"].Value, 0).ToString());
            double hrgnet = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgNet"].Value, 0).ToString());
            double hpp = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSolo"].Value, 0).ToString());
            double jmlhpp = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSolo"].Value, 0).ToString());
            string nokoreksi = Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["KoreksiID"].Value, 0).ToString();

            //if (!string.IsNullOrEmpty(nokoreksi))
            //{
            //    dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NamaBarang"].Style.BackColor = Color.Blue;
            //    dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NamaBarang"].Style.ForeColor = Color.Yellow;
            //}
            if (dataGridNotaJualDetail.RowCount > 0)
            {
                if (dataGridNotaJualDetail.Rows[e.RowIndex].Cells["IDkoreksi"].Value.ToString() != "")
                {
                    for (int i = 0; i < dataGridNotaJualDetail.ColumnCount; i++)
                    {
                        dataGridNotaJualDetail.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Blue;
                    }
                }

            }
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Value = Tools.GetAntiNumeric(dethrg.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgJualAck"].Value = Tools.GetAntiNumeric(detjuml.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Value = Tools.GetAntiNumeric(detpot.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Value = Tools.GetAntiNumeric(jmlpot.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgNetAck"].Value = Tools.GetAntiNumeric(hrgnet.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Value = Tools.GetAntiNumeric(hpp.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Value = Tools.GetAntiNumeric(jmlhpp.ToString("#,##0.00"));

            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        
        private void AcakTampilHrg()
        {
            bool normal = true;
            //dataGridNotaJual.Columns["RpJual"].DefaultCellStyle.Format = "#,##0.00";
            //dataGridNotaJual.Columns["NotaRpPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJual.Columns["NotaRpNet"].DefaultCellStyle.Format = "#,##0.00";

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNet"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].DefaultCellStyle.Format = "#,##0.00";

            normal = !_acak;
            //dataGridNotaJual.Columns["RpJual"].Visible = _acak;
            //dataGridNotaJual.Columns["NotaRpPot"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpNet"].Visible = true;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].Visible = true;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJual"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailPot"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNet"].Visible = true;
            //dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].Visible = _acak;

            //acak
            //dataGridNotaJual.Columns["RpJualAck"].Visible = normal;
            //dataGridNotaJual.Columns["NotaRpPotAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpNetAck"].Visible = false;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJualAck"].Visible = false;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJualAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailPotAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNetAck"].Visible = false;
            //dataGridNotaJualDetail.Columns["NotaDetailHPPSoloAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSoloAck"].Visible = normal;
            _acak = normal;

            RefreshLabel();
        }

        private void RefreshLabel()
        {
            int _totalQtySJ = 0, _totalQtyNota = 0;
            double _jmlHrg = 0, _jmlNet = 0;
            
            if (dataGridNotaJualDetail.RowCount > 0)
            {
                _totalQtySJ = int.Parse(dtDetail.Compute("SUM(QtySuratJalan)", string.Empty).ToString());
                _totalQtyNota = int.Parse(dtDetail.Compute("SUM(QtyNota)", string.Empty).ToString());
                _jmlHrg = double.Parse(dtDetail.Compute("SUM(JmlHrg3)", string.Empty).ToString());
                _jmlNet = double.Parse(dtDetail.Compute("SUM(HrgNet3)", string.Empty).ToString());                
            }

            lblJmlQtySJ.Text = _totalQtySJ.ToString();
            lblJmlQtyNota.Text = _totalQtyNota.ToString();

            if (_acak)
            {
                lblJmlHrgKotor.Text = Tools.GetAntiNumeric(_jmlHrg.ToString("#,##0"));
                lblJmlHrgBersih.Text = Tools.GetAntiNumeric(_jmlNet.ToString("#,##0"));
            }
            else
            {
                lblJmlHrgKotor.Text = _jmlHrg.ToString("#,##0");
                lblJmlHrgBersih.Text = _jmlNet.ToString("#,##0");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridNotaJual.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridNotaJualDetail.FindRow(columnName, value);
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridNotaJual_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJual.SelectedCells.Count > 0)
            {
                    RefreshDataNotaJualDetail();
                    lblStokDanToko.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                    lblCabPrs.Text = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaHtrID"].Value.ToString().Substring(0, 3);
                
            }
            else
            {
                dataGridNotaJualDetail.DataSource = null;
                lblStokDanToko.Text = "";
                lblCabPrs.Text = "";
            }
        }

        private void dataGridNotaJualDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJualDetail.SelectedCells.Count != 0)
            {
                lblStokDanToko.Text = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblStokDanToko.Text = "";
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Koreksi();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (_selectedGrid == enumFormMode.Header)
            {
                if (dataGridNotaJual.SelectedCells.Count > 0)
                {
                    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0, 1) == "T")
                    {
                        if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim() == "ECERAN CASH" &&
                            dataGridNotaJual.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString().Trim().Substring(7, 3) != "VIA")
                        {
                            MessageBox.Show("Transaksi Tunai tidak bisa dilink ke Piutang");
                            return;
                        }
                    }

                    string recordID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                    if (recordID.Substring(0, 3) != GlobalVar.PerusahaanID)
                    {
                        MessageBox.Show("Nota ini bukan berasal dari cabang/pos " + GlobalVar.PerusahaanID);
                        return;
                    }
                    string tglTerima = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString();
                    if (tglTerima == "")
                    {
                        if (SecurityManager.IsPiutang() || SecurityManager.IsManager())
                        {
                            ProsesPJ3();
                        }
                    }
                    else
                    {
                        DateTime TglTerim = Convert.ToDateTime(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value);
                        if (TglTerim.Month != GlobalVar.DateOfServer.Month)
                        {
                            KotakPesan.Information("Periode bulan tidak sama dengan tanggal server. Tidak bisa edit data.");
                            return;
                        }
                        if (MessageBox.Show("Data sudah di link ke piutang. Link ulang ?", "Link", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (SecurityManager.AskPasswordManager())
                            {
                                ProsesPJ3();
                            }
                        }
                    }
                }
            }
        }

        private void dataGridNotaJual_Enter(object sender, EventArgs e)
        {
            _selectedGrid = enumFormMode.Header;
        }

        private void dataGridNotaJualDetail_Enter(object sender, EventArgs e)
        {
            _selectedGrid = enumFormMode.Detail;
        }
    }
}
