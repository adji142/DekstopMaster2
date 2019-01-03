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
using System.Data.SqlTypes;
using ISA.Trading.Class;
using ISA.Common;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.PJ3
{
    public partial class frmPJ3BrowserISA : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        DataTable dtHeader, dtDetail;
        string _initPrs = GlobalVar.PerusahaanID, _initCab = GlobalVar.Gudang;
        bool _acak;
        string PrnAktif = "0";

        DateTime _fromDate, _toDate;

        public frmPJ3BrowserISA()
        {
            InitializeComponent();
        }

        private void frmPJ3BrowserISA_Load(object sender, EventArgs e)
        {
            _acak = true;
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
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID")); //cek heri
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
                    //dataGridNotaJualDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                    //this.dataGridNotaJualDetail.RefreshEdit();
                    Guid RowidHeader = new Guid(dtRefresh.Rows[0]["HeaderID"].ToString());
                    RefreshDataNotaJual();
                    FindHeader("NotaRowID",RowidHeader.ToString());
                    FindDetail("NotaDetailRowID", rowID.ToString());
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

                //    case Keys.Space:
                //        if (dataGridNotaJual.SelectedCells.Count > 0)
                //        {
                //            if (GlobalVar.Gudang != "2808")
                //            {
                //                if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0, 1) == "T")
                //                {
                //                    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim() == "ECERAN CASH" &&
                //                        dataGridNotaJual.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString().Trim().Substring(7, 3) != "VIA")
                //                    {
                //                        MessageBox.Show("Transaksi Tunai tidak bisa dilink ke Piutang");
                //                        return;
                //                    }
                //                }
                //            }

                //            string recordID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                //            if (recordID.Substring(0,3) != GlobalVar.PerusahaanID)
                //            {
                //                MessageBox.Show("Nota ini bukan berasal dari cabang/pos " + GlobalVar.PerusahaanID);
                //                return;
                //            }
                //            string tglTerima = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString();
                //            if (tglTerima == "")
                //            {
                //                if (SecurityManager.IsPiutang() || SecurityManager.IsManager())
                //                {
                //                    ProsesPJ3();
                //                }
                //            }
                //            else
                //            {
                //                if (MessageBox.Show ("Data sudah di link ke piutang. Link ulang ?","Link", MessageBoxButtons.YesNo ) == DialogResult.Yes)
                //                {
                //                    if (SecurityManager.AskPasswordManager())
                //                    {                                    
                //                        ProsesPJ3();
                //                    }
                //                }
                //            }
                //        }
                //        break;
                //    case Keys.F11:
                //        MessageBox.Show("KOREKSI DILAKUKAN HANYA PADA DETAIL...!");
                //        break;
                //    case Keys.Delete:
                //        MessageBox.Show("PJ3 TIDAK BOLEH HAPUS...!");
                //        break;
                //    case Keys.Insert:
                //        MessageBox.Show("PJ3 TIDAK BOLEH INPUT...!");
                //        break;
                //    case Keys.Tab:
                //        dataGridNotaJualDetail.Focus();
                //        break;
                }
            }
        }

        private void CetakNotaKoreksi()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "KoreksiPenjualan"));
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
                    if (PrnAktif == "0")
                    {
                        PrintRawNotaKoreksi(dt);
                    }
                    else
                    {
                        DisplayReport(dt);
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
            string _NoKoreki = Tools.isNull(dt.Rows[0]["NoKoreksi"], "").ToString();
            DateTime _TglKoreksi = DateTime.Parse(Tools.isNull(dt.Rows[0]["TglKoreksi"], DateTime.MinValue).ToString());

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("NoKoreksi", _NoKoreki));
            rptParams.Add(new ReportParameter("TglKoreksi", _TglKoreksi.ToString("dd-MMM-yyyy")));

            Int32 c = 0, _PrnAktif = Int32.Parse(Tools.isNull(PrnAktif, "0").ToString()); 
            if (_PrnAktif > 0)
            {
                c++;
                if (c == 1 && c <= _PrnAktif)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("PJ3.rptCetakNotaKoreksi.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                    c++;
                }
                if (c == 2 && c <= _PrnAktif)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("PJ3.rptCetakNotaKoreksi_copy1.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                    c++;
                }
                if (c == 3 && c <= _PrnAktif)
                {
                    c++;
                    frmReportViewer ifrmReport = new frmReportViewer("PJ3.rptCetakNotaKoreksi_copy2.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }
            }
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

            int hslTryParse;
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

            if (cekValue && (linkID == "2" || linkID == "C"))
            {
                MessageBox.Show("Link nota anak cabang gunakan F2");
                return;
            }
            if (!cekValue && (linkID == "1" || linkID.Trim() == ""))
            {
                MessageBox.Show("Link ID Pos harus -> C");
                return;
            }
            
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

            if (!CekRpNet2dan3())
            {
                MessageBox.Show("RP_NET2 BEDA DENGAN RP_NET3...!");
                return;
            }

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
            if (e.KeyCode == Keys.F5)
            {
                Guid notaHeaderID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                string KoreksiID = Tools.isNull(dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["KoreksiID"].Value,"").ToString();
                string Fkor = Tools.isNull(dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["PLPrint"].Value, "").ToString();

                if (KoreksiID == "" && Fkor != "2")
                {
                    int Kor = 0;
                    if (Fkor != "1")
                        Kor = 1;
                    else
                        Kor = 0;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetailSyncflag_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, notaDetailID));
                            db.Commands[0].Parameters.Add(new Parameter("@FlagKor", SqlDbType.Bit, Kor));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        RefreshDataNotaJual();
                        FindHeader("NotaRowID", notaHeaderID.ToString());
                        FindDetail("NotaDetailRowID", notaDetailID.ToString());
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
                else if (Fkor == "1")
                {
                    MessageBox.Show("Sudah pengajuan Koreksi Penjualan.");
                }
                else
                {
                    MessageBox.Show("Sudah Acc Koreksi Penjualan.");
                }
            }

            if (e.KeyCode == Keys.F6)
            {
                Guid notaHeaderID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                string Fkor = Tools.isNull(dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["PLPrint"].Value,"").ToString();
                if (Fkor == "1")
                {
                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, notaDetailID, GlobalVar.Gudang, PinId.Bagian.KPJ, "Cegatan Koreksi Penjualan ");
                    ifrmpin.WindowState = FormWindowState.Normal;
                    ifrmpin.ShowDialog();
                    if (ifrmpin.DialogResult == DialogResult.OK)
                    {
                        RefreshDataNotaJual();
                        FindHeader("NotaRowID", notaHeaderID.ToString());
                        FindDetail("NotaDetailRowID", notaDetailID.ToString());
                    }
                }
                else if (Fkor == "2")
                {
                    MessageBox.Show("Sudah Acc Koreksi Penjualan.");
                }
                else
                {
                    MessageBox.Show("Belum Pengajuan Koreksi Penjualan ke HO.");
                }
            }

            if (e.KeyCode == Keys.F11)
            {
                Koreksi();
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
            string notaRecID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();

            if (Tools.Left(notaRecID, 3) != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Nota Dari Cabang Lain!!!" + System.Environment.NewLine + Tools.Left(notaRecID, 3));
                return;
            }

            if (dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["QtyNota"].Value.ToString() == "0")
            {
                MessageBox.Show("QTY NOTA 0 TIDAK BISA DILAKUKAN KOREKSI !");
                return;
            }
            if (CekSudahPernahRetur())
            {
                MessageBox.Show("Record ini sudah pernah diretur, tidak boleh dikoreksi");
                return;
            }
            if (CekSudahAdaPotongan())
            {
                MessageBox.Show("Nota ini sudah pernah terjadi potongan (DIL), tidak boleh dikoreksi");
                return;
            }
            if (("12").Contains(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaLinkID"].Value.ToString()) == false
                && dataGridNotaJual.SelectedCells[0].OwningRow.Cells["C1"].Value.ToString() == _initCab)
            {
                MessageBox.Show("KOREKSI DILAKUKAN SETELAH LINK PIUTANG !");
                return;
            }
            if (CekSudahPernahKoreksi())
            {
                MessageBox.Show("Record ini sudah pernah di Koreksi, tidak boleh dikoreksi");
                return;
            }
            if (dataGridNotaJualDetail.SelectedCells.Count > 0)
            {
                string NoSJ = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString();
                Guid notaHeaderID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                Guid notaDetID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                string Fkor = "",FKoreksi = "";

                FKoreksi = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["PLPrint"].Value.ToString();

                if (FKoreksi != "2")
                {

                    for (int rowIndex = 0; rowIndex < dataGridNotaJualDetail.Rows.Count; rowIndex++)
                    {
                        if (dataGridNotaJualDetail.Rows[rowIndex].Cells["PLPrint"].Value.ToString() == "1")
                        {
                            Fkor = "1";
                        }
                    }

                    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang.Substring(0, 2) == "28")
                    {
                        if (Fkor == "1")
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_AjuanKoreksiPenjualan_LIST"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, notaHeaderID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show("Tidak ada data Pengajuan Koreksi Penjualan.");
                                    return;
                                }
                                else
                                {
                                    PengajuanPinKoreksiPenjualan(dt);
                                    RefreshDataNotaJual();
                                    FindHeader("NotaRowID", notaHeaderID.ToString());
                                    FindDetail("NotaDetailRowID", notaDetID.ToString());

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
                            MessageBox.Show("Koreksi Penjualan harus pengajuan Pin ke HO, dan data yang akan diajukan harus diberi tanda dengan menggunakan F5.");
                            //string recID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                            //Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                            //PJ3.frmKoreksiJualBrowser ifrmChild = new PJ3.frmKoreksiJualBrowser(this, notaDetailID, recID);
                            //ifrmChild.MdiParent = Program.MainForm;
                            //Program.MainForm.RegisterChild(ifrmChild);
                            //ifrmChild.Show();
                        }
                    }
                    else
                    {
                        string recID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                        Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                        PJ3.frmKoreksiJualBrowser ifrmChild = new PJ3.frmKoreksiJualBrowser(this, notaDetailID, recID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                }
                else
                {
                    string recID = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRecordID"].Value.ToString();
                    Guid notaDetailID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                    PJ3.frmKoreksiJualBrowser ifrmChild = new PJ3.frmKoreksiJualBrowser(this, notaDetailID, recID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }




        private void PengajuanPinKoreksiPenjualan(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LaporanPengajuanPinKoreksiPenjualan(dt));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_PengajuanKoreksiPenjualan";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage LaporanPengajuanPinKoreksiPenjualan(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Pengajuan Koreksi Penjualan";
            ex.Workbook.Properties.SetCustomPropertyValue("OvdFX", "1147");

            ex.Workbook.Worksheets.Add("Ajuan Koreksi");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 10;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;      //no nota
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //tgl nota
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //kode sales
            ws.Cells[1, 5].Worksheet.Column(5).Width = 27;      //toko
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;      //kota
            ws.Cells[1, 7].Worksheet.Column(7).Width = 10;      //idwil
            ws.Cells[1, 8].Worksheet.Column(8).Width = 40;      //nama barang
            ws.Cells[1, 9].Worksheet.Column(9).Width = 10;      //qty
            ws.Cells[1, 10].Worksheet.Column(10).Width = 10;    //harga
            ws.Cells[1, 11].Worksheet.Column(11).Width = 7;     //disc1
            ws.Cells[1, 12].Worksheet.Column(12).Width = 7;     //disc2
            ws.Cells[1, 13].Worksheet.Column(13).Width = 7;     //disc3
            ws.Cells[1, 14].Worksheet.Column(14).Width = 10;    //pot
            ws.Cells[1, 15].Worksheet.Column(15).Width = 10;    //jumlah
            ws.Cells[1, 16].Worksheet.Column(16).Width = 13;    //hrg koreksi
            ws.Cells[1, 17].Worksheet.Column(17).Width = 40;    //catatan
            ws.Cells[1, 18].Worksheet.Column(18).Width = 40;    //public key
            ws.Cells[1, 19].Worksheet.Column(19).Width = 40;    //pin
            ws.Cells[1, 20].Worksheet.Column(20).Width = 10;    //no acc

            int nRow = 0, nHeader = 1, Rowx = 0, MaxCol = 20;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Pengajuan Koreksi Penjualan";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[Rowx, 2].Value = " No Nota ";
            ws.Cells[Rowx, 3].Value = " Tgl Nota ";
            ws.Cells[Rowx, 4].Value = " Kode Sales ";
            ws.Cells[Rowx, 5].Value = " Nama Toko ";
            ws.Cells[Rowx, 6].Value = " Kota ";
            ws.Cells[Rowx, 7].Value = " Idwil ";
            ws.Cells[Rowx, 8].Value = " Nama Barang ";
            ws.Cells[Rowx, 9].Value = " Qty ";
            ws.Cells[Rowx, 10].Value = " Harga ";
            ws.Cells[Rowx, 11].Value = " Disc1 ";
            ws.Cells[Rowx, 12].Value = " Disc2 ";
            ws.Cells[Rowx, 13].Value = " Disc3 ";
            ws.Cells[Rowx, 14].Value = " Pot ";
            ws.Cells[Rowx, 15].Value = " Jumlah ";
            ws.Cells[Rowx, 16].Value = " Hrg Koreksi ";
            ws.Cells[Rowx, 17].Value = " Catatan ";
            ws.Cells[Rowx, 18].Value = " Public Key ";
            ws.Cells[Rowx, 19].Value = " Pin ";
            ws.Cells[Rowx, 20].Value = " No Acc ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            if (dt.Rows.Count > 0)
            {
                int no = 0;
                double nSaldo = 0;

                foreach (DataRow dr1 in dt.Rows)
                {
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["NoSuratJalan"], "").ToString();
                    ws.Cells[Rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglSuratJalan"], ""));
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Wilid"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["NamaBarang"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Convert.ToInt32(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(Tools.isNull(dr1["HrgJual"], "0").ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["Disc1"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,###.#;";
                    ws.Cells[Rowx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Disc2"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,###.#;";
                    ws.Cells[Rowx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["Disc3"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,###.#;";
                    ws.Cells[Rowx, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 14].Value = Convert.ToDouble(Tools.isNull(dr1["Pot"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["JmlHrg2"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 16].Value = 0.ToString();
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 17].Value = "";
                    ws.Cells[Rowx, 18].Value = Tools.GetKey(dr1["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.KPJ);
                    ws.Cells[Rowx, 19].Value = "";
                    ws.Cells[Rowx, 20].Value = "";
                    Rowx++;
                }
            }

            Rowx++;
            ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //ws.Cells[Rowx, 10].Value = Tools.isNull(nSaldo, 0);
            //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
            //ws.Cells[Rowx, 10].Style.Font.Bold = true;

            var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;
            return ex;
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
            string KoreksiID = Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["KoreksiID"].Value, 0).ToString();

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
                else
                {
                    if (dataGridNotaJualDetail.Rows[e.RowIndex].Cells["PLPrint"].Value.ToString() == "1")
                    {
                        for (int i = 0; i < dataGridNotaJualDetail.ColumnCount; i++)
                        {
                            dataGridNotaJualDetail.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.Yellow;
                        }
                    }
                    else if (dataGridNotaJualDetail.Rows[e.RowIndex].Cells["PLPrint"].Value.ToString() == "2")
                    {
                        for (int i = 0; i < dataGridNotaJualDetail.ColumnCount; i++)
                        {
                            dataGridNotaJualDetail.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.Cyan;
                        }
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
            dataGridNotaJual.Columns["RpJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJual.Columns["NotaRpPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJual.Columns["NotaRpNet"].DefaultCellStyle.Format = "#,##0.00";

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNet"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].DefaultCellStyle.Format = "#,##0.00";

            normal = !_acak;
            dataGridNotaJual.Columns["RpJual"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpPot"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpNet"].Visible = _acak;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJual"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNet"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].Visible = _acak;

            //acak
            dataGridNotaJual.Columns["RpJualAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpPotAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpNetAck"].Visible = normal;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJualAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgJualAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgNetAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailHPPSoloAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSoloAck"].Visible = normal;
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

        private void btnPullWiserDC_Click(object sender, EventArgs e)
        {
            PJ3.frmKoreksiJualSynch frm = new PJ3.frmKoreksiJualSynch();
            frm.ShowDialog();
        }
    }
}
