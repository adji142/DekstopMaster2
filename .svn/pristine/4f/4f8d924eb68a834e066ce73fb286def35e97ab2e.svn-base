using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;
using ISA.Bengkel.Class;
using ISA.Trading;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;
using ISA.Trading;
using ISA.Utility;

//using System.Linq;
//using ISA.Controls;
//using ISA.Trading.Controls;
//using System.Data.SqlTypes;
//using System.Globalization;
//using ISA.Common;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmServiceBrowser : ISA.Bengkel.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, Detail1Selected, Detail2Selected, Detail3Selected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        string _format;
        string _headerRec;
        Guid RowIDNota_ ;
        string PrnAktif = "0";

        DateTime tanggal;

        DataTable dtHeader, dtDetail1, dtDetail2, dtDetail3;
        DataTable dtprs;

        public frmServiceBrowser()
        {
            InitializeComponent();
        }  

        private void frmServiceBrowser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dgvHeader.AutoGenerateColumns = false;
            dgvDetail2.AutoGenerateColumns = false;
            //rgbTglService.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglService.FromDate = DateTime.Now;
            rgbTglService.ToDate = DateTime.Now;
            RefreshDataService();
            rgbTglService.Focus();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataService();
        }

        public void CetakNota()
        {
            string perbaikan = dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BENGKEL"));
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


            if (PrnAktif == "0")
            {
                try
                {
                    Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string PCab = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value,"").ToString().Substring(0,1);

                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    DataTable dtbarang = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_cetakNotaBengkel"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_cetakNotaBengkelbarang]"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        dtbarang = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count <= 0 || dtbarang.Rows.Count <= 0)
                    {
                        MessageBox.Show("Tidak ada data");
                        return;
                    }

                    DataSet dsGabung = new DataSet();
                    dsGabung.Tables.Add(dt);
                    dsGabung.Tables.Add(dtbarang);
                    if (dsGabung.Tables.Count > 0)
                    {
                        if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) != "28")
                        {
                            CetakNotaRawOtomotif(dsGabung);
                        }
                        else
                        {
                            CetakNotaRawPS(dsGabung);
                            //CetakNotaBengkelPS(dsGabung);
                        }
                    }

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_cetakNotaBengkel_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshDataService();
                    FindRowBkl("RowID", rowID.ToString());

                    string NotaBkl = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["nomor"].Value, "").ToString();
                    string NotaPjl = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value, "").ToString();

                    Parameters prms = new Parameters();
                    prms.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    prms.AddParameter("@PCab", SqlDbType.VarChar, PCab);
                    prms.AddParameter("@userID", SqlDbType.VarChar, SecurityManager.UserID);
                    if (@NotaBkl != "")
                    {
                        prms.AddParameter("@NotaBkl", SqlDbType.VarChar, NotaBkl);
                    }
                    if (@NotaPjl != "")
                    {
                        prms.AddParameter("@NotaPjl", SqlDbType.VarChar, NotaPjl);
                    }

                    DBTools.DBGetScalar("usp_Link_Service2Finance", prms);
                    //if (dgvDetail3.Rows.Count > 0 || dgvDetail3.Rows.Count == 0)
                    //{
                    //    if (MessageBox.Show("Link Penjualan Sparepart luar ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        if (dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString() == "umum") {
                    //            DBTools.DBGetScalar("usp_Link_Service2Finance", prms);
                    //        }
                    //        LinkKS();
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
            else
            {
                try
                {
                    Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string PCab = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value, "").ToString().Substring(0,1);

                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    DataTable dtbarang = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_cetakNotaBengkel_list"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                            CetakNotaRaw_Inkjet(dt);
                    }

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_cetakNotaBengkel_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshDataService();
                    FindRowBkl("RowID", rowID.ToString());

                    string NotaBkl = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["nomor"].Value, "").ToString();
                    string NotaPjl = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value, "").ToString();

                    Parameters prms = new Parameters();
                    prms.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                    prms.AddParameter("@PCab", SqlDbType.VarChar, PCab);
                    prms.AddParameter("@userID", SqlDbType.VarChar, SecurityManager.UserID);
                    if (@NotaBkl != "")
                    {
                        prms.AddParameter("@NotaBkl", SqlDbType.VarChar, NotaBkl);
                    }
                    if (@NotaPjl != "")
                    {
                        prms.AddParameter("@NotaPjl", SqlDbType.VarChar, NotaPjl);
                    }
                    DBTools.DBGetScalar("usp_Link_Service2Finance", prms);
                    //if (dgvDetail3.Rows.Count > 0 || dgvDetail3.Rows.Count == 0)
                    //{
                    //    if (MessageBox.Show("Link Penjualan Sparepart luar ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        LinkKS();
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
        }
        private void CetakNotaRaw_Inkjet(DataTable dt)
        {
            #region cetakInkjet
            double Total = 0;
            double TotalDisc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Double HrgJual = Convert.ToDouble(Tools.isNull(dr["JumlahNet"],0).ToString());
                Total = Total + HrgJual;
            }
            
            try
            {
                Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                dtprs = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_caraiprs"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtprs = db.Commands[0].ExecuteDataTable();
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

            string NamaPrs = "", AlamatPrs = "";
            if (dtprs.Rows.Count > 0)
            {
                NamaPrs = dtprs.Rows[0]["Nama"].ToString();
                AlamatPrs = dtprs.Rows[0]["Alamat"].ToString();
            }

            string Nomor = dt.Rows[0]["nomor"].ToString();
            string NoPolisi = dt.Rows[0]["no_pol"].ToString();
            string Cs = dt.Rows[0]["Sales"].ToString();
            string NoNps = dt.Rows[0]["NoSuratJalan"].ToString();
            string TglNota = ((DateTime)dt.Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy");
            string Nama = dt.Rows[0]["nama_cust"].ToString();
            string Telp = dt.Rows[0]["no_telp"].ToString();
            string Alamat = dt.Rows[0]["alamat"].ToString();
            string Kota = dt.Rows[0]["kota"].ToString();
            string Daerah = dt.Rows[0]["daerah"].ToString();
            string UserID = SecurityManager.UserName.ToString();
            string JumlahTotal = Total.ToString();
            string barcode = dt.Rows[0]["barcode"].ToString();
            string Mekanik = dt.Rows[0]["Mekanik"].ToString();
            string Nps = "";
            string ckp = "";
            string Spm = dt.Rows[0]["Spm"].ToString();
            string Warna = dt.Rows[0]["Warna"].ToString();
            string Tahun = dt.Rows[0]["Tahun"].ToString();
            Int32 Km = Int32.Parse(Tools.isNull(dt.Rows[0]["Km"], "0").ToString());
            Int32 KmNext = Int32.Parse(Tools.isNull(dt.Rows[0]["KmNext"], "0").ToString());
            string AdmBengkel = SecurityManager.UserName;

            int nprint = Convert.ToInt32(Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["nPrint"].Value, "0").ToString().Trim());
            if (nprint > 0)
            {
                ckp = "CP";
            }

            foreach (DataRow drc in dt.Rows)
            {
                if (Tools.isNull(drc["NoSuratJalan"], "").ToString() != "")
                {
                    Nps = drc["NoSuratJalan"].ToString();
                }
            }

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("NamaPrs", NamaPrs));
            rptParams.Add(new ReportParameter("AlamatPrs", AlamatPrs));
            rptParams.Add(new ReportParameter("Nomor", Nomor));
            rptParams.Add(new ReportParameter("NoPolisi", NoPolisi));
            rptParams.Add(new ReportParameter("Cs", Cs));
            rptParams.Add(new ReportParameter("NoNps", NoNps));
            rptParams.Add(new ReportParameter("TglNota", TglNota));
            rptParams.Add(new ReportParameter("Nama", Nama));
            rptParams.Add(new ReportParameter("Alamat", Alamat));
            rptParams.Add(new ReportParameter("Kota", Kota));
            rptParams.Add(new ReportParameter("Telp", Telp));
            rptParams.Add(new ReportParameter("JumlahTotal", JumlahTotal));
            rptParams.Add(new ReportParameter("Nps", Nps));
            rptParams.Add(new ReportParameter("BarcodeBar", "*" + barcode + "*"));
            rptParams.Add(new ReportParameter("Barcode", barcode));
            rptParams.Add(new ReportParameter("Ckp", ckp));
            rptParams.Add(new ReportParameter("Spm", Spm));
            rptParams.Add(new ReportParameter("Warna", Warna));
            rptParams.Add(new ReportParameter("Tahun", Tahun));
            rptParams.Add(new ReportParameter("Km", Km.ToString()));
            rptParams.Add(new ReportParameter("KmNext", KmNext.ToString()));
            rptParams.Add(new ReportParameter("Mekanik", Mekanik));
            rptParams.Add(new ReportParameter("AdmBengkel", AdmBengkel));

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptCetakNotaBengkelbaruPS.rdlc", rptParams, dt, "dsCetakNotaBengkel_Data");
            ifrmReport.Print();
            //ifrmReport.Print(8.5, 6.4);
            //ifrmReport.Show();

            if (Convert.ToInt32(PrnAktif) >= 2)
            {
                ifrmReport = new frmReportViewer("Laporan.rptCetakNotaBengkelbaruPS_Copy1.rdlc", rptParams, dt, "dsCetakNotaBengkel_Data");
                ifrmReport.Print();
                //ifrmReport.Print(8.5, 6.4);
                //ifrmReport.Show();
            }
            if (Convert.ToInt32(PrnAktif) > 2)
            {
                ifrmReport = new frmReportViewer("Laporan.rptCetakNotaBengkelbaruPS_Copy2.rdlc", rptParams, dt, "dsCetakNotaBengkel_Data");
                ifrmReport.Print();
                //ifrmReport.Print(8.5, 6.4);
                //ifrmReport.Show();
            }
            #endregion
        }

        
        private void CetakNotaRaw(DataSet ds)
        {
            #region CetakOld
            BuildString1 data = new BuildString1();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamacust = ds.Tables[0].Rows[0]["nama_cust"].ToString().Trim();
            string scust = sNamacust + data.SPACE(sNamacust.Length + (15 - sNamacust.Length) - 7);
            string sAlamat = ds.Tables[0].Rows[0]["alamat"].ToString().Trim();
            string sDaerah = ds.Tables[0].Rows[0]["daerah"].ToString().Trim();
            string sKota = ds.Tables[0].Rows[0]["kota"].ToString().Trim();
            string sPramuniaga = ds.Tables[1].Rows[0]["KodeSales"].ToString().Trim();

            //string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();
            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }

            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.Cursor = Cursors.WaitCursor;
            DataTable dtprs = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_caraiprs"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                dtprs = db.Commands[0].ExecuteDataTable();
            }
            data.PROW(true, 1, dtprs.Rows[0]["Nama"].ToString().Trim());
            data.PROW(false, 47, "NOTA SERVICE: " + ds.Tables[0].Rows[0]["nomor"].ToString() + "   ");
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dtprs.Rows[0]["Alamat"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, "  " + data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Customer               " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "NO. POLISI   : " + ds.Tables[0].Rows[0]["no_pol"].ToString().PadRight(25));
            data.PROW(false, 53, data.PrintVerticalLine() + scust.PadRight(40) + data.PrintVerticalLine());
            //data.PROW(false, 92, scust.PadRight(60));
            //data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "CUST. SERV.  : " + ds.Tables[0].Rows[0]["CS"].ToString().PadRight(25));
            data.PROW(false, 53, data.PrintVerticalLine() + sAlamat.PadRight(40) + data.PrintVerticalLine());
            //data.PROW(false, 92, sAlamat.PadRight(60));
            data.FontCondensed(false);
            //data.PROW(true, 1, "");
            //data.FontItalic(true);
            //data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            //data.FontItalic(false);
            data.AddCR();

            //data.FontItalic(true);
            //data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            //data.FontItalic(false);
            //data.AddCR();
            //data.PROW(false, 55, sKota);
            data.PROW(true, 1, "No. NPS      : " + ds.Tables[1].Rows[0]["NoSuratJalan"].ToString().PadRight(25));
            data.PROW(false, 53, data.PrintVerticalLine() + sKota.PadRight(40) + data.PrintVerticalLine());
            // data.FontItalic(true);
            // data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            //data.FontItalic(false);
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "Tanggal Nota : " + ((DateTime)ds.Tables[0].Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy"));
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "");
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            //data.FontItalic(false);
            data.PROW(true, 1, "");
            data.FontCondensed(true);

            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "No.   K E T E R A N G A N                                               Q t y    Harga Sat         Disc      Pot      Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            int banyakService = ds.Tables[0].Rows.Count;
            int nUrut1 = nUrut + banyakService;
            string sKet, sSatuan, sTemp, subket, sNmBrg, subNamaBarang;
            double nQty, nHrgSat, nHrgBruto, nOngkosService;
            double nSumHrgBrutoNota = 0, nSumDiscNota = 0, nSumTotServ = 0, nSumPotNota = 0, nTotalHrg = 0, nSumDiscService, nSumPotService;

            #region buat yang service
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nUrut += 1;
                    int panjanghuruf;
                    //sNmBrg = dr["NamaBarang"].ToString();
                    sKet = dr["kategori"].ToString();
                    panjanghuruf = sKet.Length;
                    //panjanghuruf = sNmBrg.Length;
                    if (panjanghuruf >= 52)
                    {
                        //subket = sNmBrg.Substring(0, 52);
                        subket = sKet.Substring(0, 52);
                    }
                    else
                    {
                        //subket = sNmBrg;
                        subket = sKet;
                    }
                    //sKet = dr["kategori"].ToString();
                    //panjanghuruf = sKet.Length;
                    //if (panjanghuruf >= 52)
                    //{
                    //    //subket = sKet.Substring(0, 52);
                    //}
                    //else
                    //{
                    //    subket = sKet;
                    //}
                    nOngkosService = double.Parse(dr["biaya"].ToString());
                    nSumDiscService = double.Parse(dr["DiscService"].ToString());
                    nSumPotService = double.Parse(dr["PotService"].ToString());
                    nSumTotServ = nOngkosService - nSumPotService - nSumPotService;

                    sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";//nomer
                    sTemp = sTemp + subket.PadRight(58, ' ') + "  ";//kategori
                    sTemp = sTemp + "  ".PadLeft(7) + "." + "       ";//qty 
                    sTemp = sTemp + "Rp. " + nOngkosService.ToString("#,###").PadLeft(9);//biaya
                    sTemp = sTemp + nSumDiscService.ToString("#,###").PadLeft(8);//diskon
                    sTemp = sTemp + "Rp. " + nSumPotService.ToString("#,###").PadLeft(8);//potongan
                    sTemp = sTemp + "Rp." + nSumTotServ.ToString("#,###").PadLeft(10);//jmlharga
                    data.PROW(true, 1, sTemp);
                }
            }

            //if (nUrut % banyakService > 0)
            //{
            //    data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //    for (int n = nUrut + 1; n <= nUrut + (banyakService - (nUrut % banyakService)); n++)
            //    {
            //        data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
            //    }
            //}
            #endregion
            

            #region kalo ada yang beli beli
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    nUrut += 1;
                    sNmBrg = dr1["NamaBarang"].ToString();
                    int panjanghuruf = sNmBrg.Length;
                    panjanghuruf = sNmBrg.Length;
                    if (panjanghuruf >= 52)
                    {
                        subNamaBarang = sNmBrg.Substring(0, 52);
                    }
                    else
                    {
                        subNamaBarang = sNmBrg;
                    }
                    sSatuan = dr1["satuan"].ToString();
                    nQty = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"],"0").ToString());
                    nHrgSat = Convert.ToDouble(Tools.isNull(dr1["HrgJual"],"0").ToString());
                    nHrgBruto = nQty * nHrgSat;
                    nSumDiscNota = Convert.ToDouble(Tools.isNull(dr1["DiscNota"],"0").ToString());
                    nSumPotNota = Convert.ToDouble(Tools.isNull(dr1["PotNota"],"0").ToString());
                    nSumHrgBrutoNota = nSumHrgBrutoNota + nHrgBruto - nSumDiscNota - nSumPotNota;

                    sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";//nomer
                    sTemp = sTemp + subNamaBarang.PadRight(58, '.') + "  ";//barang
                    sTemp = sTemp + nQty.ToString("#,###").PadLeft(7) + "." + sSatuan + "    ";//qty+satuan
                    sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);//hrgasatuan
                    sTemp = sTemp + nSumDiscNota.ToString("#,###").PadLeft(8);//disc
                    sTemp = sTemp + "Rp. " + nSumPotNota.ToString("#,###").PadLeft(8);//pot
                    sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10);//jmlharga
                    data.PROW(true, 1, sTemp);
                }
            }

            if (nUrut % 20 > 0)
            {
                data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
                }
            }
            #endregion

            nTotalHrg = nTotalHrg + nSumHrgBrutoNota + nSumTotServ;
            data.FontCondensed(true);
            data.AddCR();
            
            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "*****" + data.SPACE(21)
                + "                                                                      Jumlah         Rp. "
                + nTotalHrg.ToString("#,###").PadLeft(13));
            data.PROW(true, 1, "SARAN");
            data.Eject();
            #endregion // end region detail
            data.SendToFile("notaJualTax.txt");
            //data.SendToPrinter("notaJualTax.txt");


            Guid RowIDP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_nPrint_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDP));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    //MessageBox.Show("Data telah disimpan");
                    //this.Close();
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
            RefreshDataService();
            #endregion
        }


        private void CetakNotaBengkelPS(DataSet ds)
        {
            #region cetak nota 1
            BuildString1 data = new BuildString1();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamacust = ds.Tables[0].Rows[0]["nama_cust"].ToString().Trim();
            string scust = sNamacust + data.SPACE(sNamacust.Length + (15 - sNamacust.Length) - 7);
            string sAlamat = ds.Tables[0].Rows[0]["alamat"].ToString().Trim();
            string sDaerah = ds.Tables[0].Rows[0]["daerah"].ToString().Trim();
            string sKota = ds.Tables[0].Rows[0]["kota"].ToString().Trim();
            string sPramuniaga = ds.Tables[1].Rows[0]["KodeSales"].ToString().Trim();
            string ckp = "";

            if (!CekPrint())
            {
                ckp = "CP";
            }

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }

            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.Cursor = Cursors.WaitCursor;
            DataTable dtprs = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_caraiprs"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                dtprs = db.Commands[0].ExecuteDataTable();
            }
            data.PROW(true, 1, dtprs.Rows[0]["Nama"].ToString().Trim());

            data.PROW(false, 47, "NOTA SERVICE");   // + ds.Tables[0].Rows[0]["nomor"].ToString() + "   " + ckp);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dtprs.Rows[0]["Alamat"].ToString());
            data.FontItalic(true);
            data.PROW(false, 54, " Nomor  : " + ds.Tables[0].Rows[0]["nomor"].ToString() + "   " + ckp);
            //data.PROW(false, 53, "  " + data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Customer               " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);
            //data.PROW(true, 1, "NO. POLISI   : " + ds.Tables[0].Rows[0]["no_pol"].ToString().PadRight(25));
            //data.PROW(false, 53, data.PrintVerticalLine() + scust.PadRight(40) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "CUST. SERV.  : " + ds.Tables[0].Rows[0]["CS"].ToString().PadRight(25));
            //data.PROW(false, 53, data.PrintVerticalLine() + sAlamat.PadRight(40) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "No. NPS      : " + ds.Tables[1].Rows[0]["NoSuratJalan"].ToString().PadRight(25));
            //data.PROW(false, 53, data.PrintVerticalLine() + sKota.PadRight(40) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "Tanggal Nota : " + ((DateTime)ds.Tables[0].Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy"));
            //data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "");
            //data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            //data.PROW(true, 1, "");
            //data.FontCondensed(true);
            //data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //data.PROW(true, 1, "No.   K E T E R A N G A N                                                      Q t y      Harga Sat  Disc  Pot          Jumlah Harga");
            //data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            //#region Detail
            //int nUrut = 0;
            //int banyakService = ds.Tables[0].Rows.Count;
            //int nUrut1 = nUrut + banyakService;
            //string sKet, sSatuan, sTemp, subket, sNmBrg, subNamaBarang, idbrg;
            //double nQty, nHrgSat, nHrgBruto, nOngkosService;
            //double nRpNetto = 0, nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPotRp = 0, nSumBiayaNetto = 0,
            //       nSumTotServ = 0, nTotalHrg = 0, nSumDiscNota = 0, nSumPotNota = 0;

            //#region buat yang service
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        nUrut += 1;
            //        int panjanghuruf;
            //        sKet = dr["kategori"].ToString();
            //        panjanghuruf = sKet.Length;
            //        if (panjanghuruf >= 52)
            //            subket = sKet.Substring(0, 52);
            //        else
            //            subket = sKet;

            //        nOngkosService = double.Parse(Tools.isNull(dr["biaya"], "0").ToString());
            //        nDisc1 = double.Parse(Tools.isNull(dr["disc_1"], "0").ToString());
            //        nDisc2 = double.Parse(Tools.isNull(dr["disc_2"], "0").ToString());
            //        nDisc3 = double.Parse(Tools.isNull(dr["disc_3"], "0").ToString());
            //        nPotRp = double.Parse(Tools.isNull(dr["PotService"], "0").ToString());
            //        nSumBiayaNetto = double.Parse(Tools.isNull(dr["BiayaNetto"], "0").ToString());
            //        nTotalHrg += nSumBiayaNetto;

            //        sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";
            //        sTemp = sTemp + subket.PadRight(68, ' ') + "  ";
            //        sTemp = sTemp + "  ".PadLeft(3) + "        ";
            //        sTemp = sTemp + "Rp. " + nOngkosService.ToString("#,###").PadLeft(9);       //biaya
            //        sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(8);                    //diskon
            //        sTemp = sTemp + "Rp. " + nPotRp.ToString("#,###").PadLeft(8);               //potongan
            //        sTemp = sTemp + "Rp." + nSumBiayaNetto.ToString("#,###").PadLeft(10);       //jmlharga
            //        data.PROW(true, 1, sTemp);
            //    }
            //}
            //#endregion


            //#region kalo ada yang beli beli
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[1].Rows)
            //    {
            //        nUrut += 1;
            //        idbrg = dr1["BarangID"].ToString();
            //        sNmBrg = dr1["NamaBarang"].ToString();
            //        int panjanghuruf = sNmBrg.Length;
            //        panjanghuruf = sNmBrg.Length;
            //        if (panjanghuruf >= 52)
            //        {
            //            subNamaBarang = sNmBrg.Substring(0, 52);
            //        }
            //        else
            //        {
            //            subNamaBarang = sNmBrg;
            //        }
            //        sSatuan = dr1["satuan"].ToString();
            //        nQty = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
            //        nHrgSat = Convert.ToDouble(Tools.isNull(dr1["HrgJual"], "0").ToString());
            //        nDisc1 = double.Parse(Tools.isNull(dr1["disc_1"], "0").ToString());
            //        nDisc2 = double.Parse(Tools.isNull(dr1["disc_2"], "0").ToString());
            //        nDisc3 = double.Parse(Tools.isNull(dr1["disc_3"], "0").ToString());
            //        nPotRp = double.Parse(Tools.isNull(dr1["PotNota"], "0").ToString());

            //        nHrgBruto = nQty * nHrgSat;
            //        nSumDiscNota = Convert.ToDouble(Tools.isNull(dr1["DiscNota"], "0").ToString());
            //        nSumPotNota = Convert.ToDouble(Tools.isNull(dr1["PotNota"], "0").ToString());
            //        nRpNetto = Convert.ToDouble(Tools.isNull(dr1["RpNetto"], "0").ToString());
            //        nTotalHrg += nRpNetto;

            //        sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";                          //nomer
            //        sTemp = sTemp + idbrg + "  ";                                                   //idbrg
            //        sTemp = sTemp + subNamaBarang.PadRight(56, '.') + "  ";                         //barang
            //        sTemp = sTemp + nQty.ToString("#,###").PadLeft(3) + "." + sSatuan + "  ";       //qty+satuan
            //        sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);                  //hrgasatuan
            //        sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(8);                        //disc
            //        sTemp = sTemp + "Rp. " + nPotRp.ToString("#,###").PadLeft(8);                   //pot
            //        sTemp = sTemp + "Rp." + nRpNetto.ToString("#,###").PadLeft(10);                 //jmlharga
            //        data.PROW(true, 1, sTemp);
            //    }
            //}

            //if (nUrut % 20 > 0)
            //{
            //    for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
            //    {
            //        data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
            //    }
            //}
            //#endregion

            //data.FontCondensed(true);
            //data.AddCR();

            //data.PROW(true, 1, data.PrintDoubleLine(134));
            //data.AddCR();
            //data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //data.PROW(true, 1, "Printed by " + SecurityManager.UserName + ", " + DateTime.Now);
            //data.PROW(false, 108, "Jumlah      Rp." + nTotalHrg.ToString("#,###").PadLeft(10));
            //data.PROW(true, 1, "SARAN : ");
            data.Eject();
            data.SendToFile("NotaBengkelPS.txt");
            //#endregion


            //Guid RowIDP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_bkl_nPrint_UPDATE"));
            //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDP));
            //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            //        db.Commands[0].ExecuteNonQuery();
            //        this.DialogResult = DialogResult.OK;
            //        //MessageBox.Show("Data telah disimpan");
            //        //this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            //RefreshDataService();
            #endregion
        }

        private void CetakNotaRawPS(DataSet ds)
        {
            #region cetak nota 1
            BuildString1 data = new BuildString1();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamacust = ds.Tables[0].Rows[0]["nama_cust"].ToString().Trim();
            string scust = sNamacust + data.SPACE(sNamacust.Length + (15 - sNamacust.Length) - 7);
            string sAlamat = ds.Tables[0].Rows[0]["alamat"].ToString().Trim();
            string sDaerah = ds.Tables[0].Rows[0]["daerah"].ToString().Trim();
            string sKota = ds.Tables[0].Rows[0]["kota"].ToString().Trim();
            string sPramuniaga = ds.Tables[1].Rows[0]["KodeSales"].ToString().Trim();
            string ckp = "";

            if (!CekPrint())
            {
                ckp = "CP";
            }

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }

            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.Cursor = Cursors.WaitCursor;
            DataTable dtprs = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_caraiprs"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                dtprs = db.Commands[0].ExecuteDataTable();
            }
            data.PROW(true, 1, dtprs.Rows[0]["Nama"].ToString().Trim());
            data.PROW(false, 47, "NOTA SERVICE: " + ds.Tables[0].Rows[0]["nomor"].ToString() + "   " + ckp);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dtprs.Rows[0]["Alamat"].ToString());
            data.FontItalic(true);
            data.PROW(false, 51, "  " + data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Customer               " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "NO. POLISI   : " + ds.Tables[0].Rows[0]["no_pol"].ToString().PadRight(25));
            data.PROW(false, 51, data.PrintVerticalLine() + scust.PadRight(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "CUST. SERV.  : " + ds.Tables[0].Rows[0]["CS"].ToString().PadRight(25));
            data.PROW(false, 51, data.PrintVerticalLine() + sAlamat.PadRight(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "No. NPS      : " + ds.Tables[1].Rows[0]["NoSuratJalan"].ToString().PadRight(25));
            data.PROW(false, 51, data.PrintVerticalLine() + sKota.PadRight(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "Tanggal Nota : " + ((DateTime)ds.Tables[0].Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy"));
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "");
            data.PROW(false, 51, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.PROW(true, 1, "");
            data.FontCondensed(true);
            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "No.   K E T E R A N G A N                                                      Q t y      Harga Sat  Disc  Pot          Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            int banyakService = ds.Tables[0].Rows.Count;
            int nUrut1 = nUrut + banyakService;
            string sKet, sSatuan, sTemp, subket, sNmBrg, subNamaBarang, idbrg;
            double nQty, nHrgSat, nHrgBruto, nOngkosService;
            double nRpNetto = 0, nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPotRp = 0, nSumBiayaNetto = 0,
                   nSumTotServ = 0, nTotalHrg = 0, nSumDiscNota = 0, nSumPotNota = 0;

            #region buat yang service
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nUrut += 1;
                    int panjanghuruf;
                    sKet = dr["kategori"].ToString();
                    panjanghuruf = sKet.Length;
                    if (panjanghuruf >= 52)
                        subket = sKet.Substring(0, 52);
                    else
                        subket = sKet;

                    nOngkosService = double.Parse(Tools.isNull(dr["biaya"], "0").ToString());
                    nDisc1 = double.Parse(Tools.isNull(dr["disc_1"], "0").ToString());
                    nDisc2 = double.Parse(Tools.isNull(dr["disc_2"], "0").ToString());
                    nDisc3 = double.Parse(Tools.isNull(dr["disc_3"], "0").ToString());
                    nPotRp = double.Parse(Tools.isNull(dr["PotService"], "0").ToString());
                    nSumBiayaNetto = double.Parse(Tools.isNull(dr["BiayaNetto"], "0").ToString());
                    nTotalHrg += nSumBiayaNetto;

                    sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";
                    sTemp = sTemp + subket.PadRight(68, ' ') + "  ";
                    sTemp = sTemp + "  ".PadLeft(3) + "        ";
                    sTemp = sTemp + "Rp. " + nOngkosService.ToString("#,###").PadLeft(9);       //biaya
                    sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(8);                    //diskon
                    sTemp = sTemp + "Rp. " + nPotRp.ToString("#,###").PadLeft(8);               //potongan
                    sTemp = sTemp + "Rp." + nSumBiayaNetto.ToString("#,###").PadLeft(10);       //jmlharga
                    data.PROW(true, 1, sTemp);
                }
            }
            #endregion


            #region kalo ada yang beli beli
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    nUrut += 1;
                    idbrg = dr1["BarangID"].ToString();
                    sNmBrg = dr1["NamaBarang"].ToString();
                    int panjanghuruf = sNmBrg.Length;
                    panjanghuruf = sNmBrg.Length;
                    if (panjanghuruf >= 52)
                    {
                        subNamaBarang = sNmBrg.Substring(0, 52);
                    }
                    else
                    {
                        subNamaBarang = sNmBrg;
                    }
                    sSatuan = dr1["satuan"].ToString();
                    nQty = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                    nHrgSat = Convert.ToDouble(Tools.isNull(dr1["HrgJual"], "0").ToString());
                    nDisc1 = double.Parse(Tools.isNull(dr1["disc_1"], "0").ToString());
                    nDisc2 = double.Parse(Tools.isNull(dr1["disc_2"], "0").ToString());
                    nDisc3 = double.Parse(Tools.isNull(dr1["disc_3"], "0").ToString());
                    nPotRp = double.Parse(Tools.isNull(dr1["PotNota"], "0").ToString());

                    nHrgBruto = nQty * nHrgSat;
                    nSumDiscNota = Convert.ToDouble(Tools.isNull(dr1["DiscNota"], "0").ToString());
                    nSumPotNota = Convert.ToDouble(Tools.isNull(dr1["PotNota"], "0").ToString());
                    nRpNetto = Convert.ToDouble(Tools.isNull(dr1["RpNetto"], "0").ToString());
                    nTotalHrg += nRpNetto;

                    sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ". ";                          //nomer
                    sTemp = sTemp + idbrg + "  ";                                                   //idbrg
                    sTemp = sTemp + subNamaBarang.PadRight(56, '.') + "  ";                         //barang
                    sTemp = sTemp + nQty.ToString("#,###").PadLeft(3) + "." + sSatuan + "  ";       //qty+satuan
                    sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);                  //hrgasatuan
                    sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(8);                        //disc
                    sTemp = sTemp + "Rp. " + nPotRp.ToString("#,###").PadLeft(8);                   //pot
                    sTemp = sTemp + "Rp." + nRpNetto.ToString("#,###").PadLeft(10);                 //jmlharga
                    data.PROW(true, 1, sTemp);
                }
            }

            if (nUrut % 20 > 0)
            {
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
                }
            }
            #endregion

            data.FontCondensed(true);
            data.AddCR();

            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "Printed by " + SecurityManager.UserName + ", " + DateTime.Now);
            data.PROW(false, 108, "Jumlah      Rp." + nTotalHrg.ToString("#,###").PadLeft(10));
            data.PROW(true, 1, "SARAN : ");
            data.Eject();
            data.SendToFile("NotaBengkelPS.txt");
            #endregion


            Guid RowIDP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_nPrint_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDP));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    //MessageBox.Show("Data telah disimpan");
                    //this.Close();
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
            RefreshDataService();
            #endregion
        }


        #region tutup dulu
        //private void CetakNotaBengkelOtomotif(DataSet ds)
        //{
            //BuildString1 data = new BuildString1();
            //string typePrinter = data.GetPrinterName();
            //string sNamacust = ds.Tables[0].Rows[0]["nama_cust"].ToString().Trim();
            //string scust = sNamacust + data.SPACE(sNamacust.Length + (15 - sNamacust.Length) - 7);
            //string sAlamat = ds.Tables[0].Rows[0]["alamat"].ToString().Trim();
            //string sDaerah = ds.Tables[0].Rows[0]["daerah"].ToString().Trim();
            //string sKota = ds.Tables[0].Rows[0]["kota"].ToString().Trim();
            //string sPramuniaga = ds.Tables[1].Rows[0]["cs"].ToString().Trim();
            //string ckp = "";
            //string cKm = ds.Tables[0].Rows[0]["km"].ToString().Trim();
            //string cKe = "";
            //int nKe = int.Parse(ds.Tables[0].Rows[0]["ServiceKe"].ToString());

            //if (nKe > 0 && nKe <= 3)
            //    cKe = nKe.ToString();
            //else
            //    cKe = " ";

            //if (!CekPrint())
            //{
            //    ckp = "CP";
            //}

            //data.Initialize();
            //data.PageLLine(33);
            //data.LeftMargin(1);
            //data.BottomMargin(1);

            //#region Header
            //if (typePrinter.Contains("LX"))
            //{
            //    data.LetterQuality(false);
            //    data.FontBold(true);
            //    data.FontCondensed(true);
            //    data.DoubleHeight(true);
            //}
            //else
            //{
            //    data.LetterQuality(true);
            //    data.FontBold(true);
            //    data.DoubleHeight(true);
            //    data.DoubleWidth(true);
            //}

            //Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //this.Cursor = Cursors.WaitCursor;
            //DataTable dtprs = new DataTable();
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_caraiprs"));
            //    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            //    dtprs = db.Commands[0].ExecuteDataTable();
            //}
            //data.PROW(true, 1,
            //dtprs.Rows[0]["Nama"].ToString().Trim());
            //data.PROW(false, 47, "NOTA SERVICE: " + ds.Tables[0].Rows[0]["nomor"].ToString() + "   " + ckp);
            //data.DoubleHeight(false);
            //data.DoubleWidth(false);
            //data.FontCPI(12);
            //data.LineSpacing("1/8");
            //data.FontCondensed(false);
            //data.LetterQuality(false);
            //data.FontCondensed(false);
            //data.PROW(true, 1, dtprs.Rows[0]["Alamat"].ToString());
            //data.FontItalic(true);
            //data.PROW(false, 53, "  " + data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Customer               " + data.PrintHorizontalLine(12) + data.PrintTopRightCorner());
            //data.FontItalic(false);
            //data.PROW(true, 1, "NO. POLISI   : " + ds.Tables[0].Rows[0]["no_pol"].ToString().PadRight(8) + " / Km : " +cKm + " / Serv ke : " + cKe);
            //data.PROW(false, 53, data.PrintVerticalLine() + scust.PadRight(38) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "CUST. SERV.  : " + ds.Tables[0].Rows[0]["CS"].ToString().PadRight(25));
            //data.PROW(false, 53, data.PrintVerticalLine() + sAlamat.PadRight(38) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "No. NPS      : " + ds.Tables[1].Rows[0]["NoSuratJalan"].ToString().PadRight(25));
            //data.PROW(false, 53, data.PrintVerticalLine() + sKota.PadRight(38) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            //data.PROW(true, 1, "Tanggal Nota : " + ((DateTime)ds.Tables[0].Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy"));
            //data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(38) + data.PrintVerticalLine());
            //data.FontCondensed(false);
            //data.AddCR();
            ////data.PROW(true, 1, "Kilometer         : " + int.Parse(ds.Tables[0].Rows[0]["Km"].ToString()));
            //data.PROW(true, 75, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(54) + data.PrintBottomRightCorner());
            ////data.FontItalic(false);
            //data.FontCondensed(false);  //true

            //data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            ///*                  12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890*/
            ///*                           1         2         3         4         5         6         7         8         9         10        11        12        13        14*/
            //data.PROW(true, 1, " ");
            //data.PROW(true, 1, " NO.  K E T E R A N G A N            PART NUMBER       QTY     HARGA SAT  DISC%  POT         JUMLAH HARGA ");
            ///*                    1.  123456789012345678901234567890 123456789012  111 sat  Rp.9,999,999  99,99  Rp.999,999  Rp.99,999,999*/
            ///*                                 1         2         3          1         5         6   */
            //data.PROW(true, 1, data.PrintDoubleLine(134));
            //#endregion

            //#region Detail
            //int nUrut = 0;
            //int banyakService = ds.Tables[0].Rows.Count;
            //int nUrut1 = nUrut + banyakService;
            //string sKet, sSatuan, sTemp, subket, sNmBrg, subNamaBarang, idbrg, sPartno;
            //double nQty, nHrgSat, nHrgBruto, nOngkosService;
            //double nSumHrgBrutoNota = 0, nSumDiscNota = 0, nSumTotServ = 0, nSumPotNota = 0, nTotalHrg = 0, 
            //       nSumDiscService = 0, nSumPotService = 0, nSumBiayaNetto = 0,
            //       nDisc1 = 0,nDisc2 = 0,nDisc3 = 0, nPot = 0;
            //float disc = 0;

            //#region Biaya Service Spm
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        if (Tools.isNull(dr["kategori"], "").ToString() != "")
            //        {
            //            nUrut += 1;
            //            int panjanghuruf;
            //            sKet = Tools.isNull(dr["kategori"], data.SPACE(52)).ToString();
            //            panjanghuruf = sKet.Trim().Length;
            //            if (panjanghuruf >= 52)
            //                subket = sKet.Substring(0, 52);
            //            else
            //                subket = sKet;

            //            nOngkosService = double.Parse(Tools.isNull(dr["biaya"], "0").ToString());
            //            nDisc1 = double.Parse(Tools.isNull(dr["disc_1"], "0").ToString());
            //            nDisc2 = double.Parse(Tools.isNull(dr["disc_2"], "0").ToString());
            //            nDisc3 = double.Parse(Tools.isNull(dr["disc_3"], "0").ToString());
            //            nSumDiscService = double.Parse(Tools.isNull(dr["DiscService"], "0").ToString());
            //            nSumPotService = double.Parse(Tools.isNull(dr["PotService"], "0").ToString());
            //            nSumTotServ = nOngkosService - nSumPotService - nSumPotService;
            //            nSumBiayaNetto = double.Parse(Tools.isNull(dr["BiayaNetto"], "0").ToString());
            //            nTotalHrg += nSumBiayaNetto;

            //            sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ".  ";                     //nomer
            //            sTemp = sTemp + subket.PadRight(55, '.') + "  ";                              //kategori
            //            sTemp = sTemp + "            " + "    ";                                    //partnumber
            //            sTemp = sTemp + "       " + "  ";                                           //qty 
            //            sTemp = sTemp + "Rp." + nOngkosService.ToString("#,###").PadLeft(9) + "  ";   //biaya
            //            sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(5) + "  ";             //diskon
            //            sTemp = sTemp + "Rp." + nSumPotService.ToString("#,###").PadLeft(7) + "  ";   //potongan
            //            sTemp = sTemp + "Rp." + nSumBiayaNetto.ToString("#,###").PadLeft(10);       //jmlharga
            //            //sTemp = sTemp + "Rp." + nSumTotServ.ToString("#,###").PadLeft(10);          //jmlharga
            //            data.PROW(true, 1, sTemp);
            //        }
            //    }
            //}
            //#endregion


            //#region Pengambilan Spareparts
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    foreach (DataRow dr1 in ds.Tables[1].Rows)
            //    {
            //        int ptext = int.Parse(dr1["BarangID"].ToString().Trim().Length.ToString());
            //        if (ptext != 0)
            //        {
            //            nUrut += 1;
            //            idbrg = dr1["BarangID"].ToString();
            //            sNmBrg = dr1["NamaBarang"].ToString();

            //            int panjanghuruf = sNmBrg.Length;
            //            panjanghuruf = sNmBrg.Length;

            //            if (panjanghuruf >= 55)
            //                subNamaBarang = sNmBrg.Substring(0, 55);
            //            else
            //                subNamaBarang = sNmBrg;

            //            string sPartNumber = "";
            //            sPartNumber = Tools.isNull(dr1["PartNo"], "").ToString().Trim();
            //            if (sPartNumber.Length > 0)
            //            {
            //                if (sPartNumber.Length > 12)
            //                    sPartNumber = sPartNumber.Substring(0, 12);
            //                else
            //                    sPartNumber = dr1["PartNo"].ToString();
            //            }
            //            else
            //            {
            //                sPartNumber = "            ";
            //            }
            //            sSatuan = dr1["satuan"].ToString();
            //            nQty = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
            //            nHrgSat = Convert.ToDouble(Tools.isNull(dr1["HrgJual"], "0").ToString());
            //            nHrgBruto = nQty * nHrgSat;
            //            nSumDiscNota = Convert.ToDouble(Tools.isNull(dr1["DiscNota"], "0").ToString());
            //            nSumPotNota = Convert.ToDouble(Tools.isNull(dr1["PotNota"], "0").ToString());
            //            nSumHrgBrutoNota = nHrgBruto - nSumDiscNota - nSumPotNota;
            //            nTotalHrg += nSumHrgBrutoNota;

            //            sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ".  ";                         //nomer
            //            sTemp = sTemp + subNamaBarang.PadRight(55, '.') + "  ";                         //barang
            //            sTemp = sTemp + sPartNumber + "    ";                                           //partnumber
            //            sTemp = sTemp + nQty.ToString("#,###").PadLeft(3) + "." + Tools.isNull(sSatuan, "   ") + "  ";   //qty+satuan
            //            sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9) + "  ";            //hrgasatuan
            //            sTemp = sTemp + nSumDiscNota.ToString("#,###0.#0").PadLeft(5) + "  ";           //disc
            //            sTemp = sTemp + "Rp." + nSumPotNota.ToString("#,###").PadLeft(7) + "  ";        //pot
            //            sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10);                //jmlharga
            //            data.PROW(true, 1, sTemp);
            //        }
            //    }
            //}

            //if (nUrut % 20 > 0)
            //{
            //    for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
            //    {
            //        data.PROW(true, 1, " ");
            //        //data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
            //    }
            //}
            //#endregion

            //data.FontCondensed(true);
            //data.AddCR();

            //data.PROW(true, 1, data.PrintDoubleLine(134));
            //data.AddCR();
            //data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //data.PROW(true, 1, "Printed by " + SecurityManager.UserName + ", " + DateTime.Now);
            //data.PROW(false, 108, "Jumlah      Rp.");
            //data.DoubleHeight(true);
            //data.FontBold(true);
            //data.PROW(false, 123, nTotalHrg.ToString("#,###").PadLeft(10));
            //data.DoubleHeight(false);
            //data.FontBold(false);
            //data.PROW(true, 1, "SARAN : ");
            //data.Eject();
            //#endregion // end region detail
            //data.SendToFile("NotaBengkel.txt");
            ////data.SendToPrinter("NotaBengkel.txt");


            //Guid RowIDP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_bkl_nPrint_UPDATE"));
            //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDP));
            //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            //        db.Commands[0].ExecuteNonQuery();
            //        this.DialogResult = DialogResult.OK;
            //        //MessageBox.Show("Data telah disimpan");
            //        //this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            //RefreshDataService();
        //}
        #endregion


        private void CetakNotaRawOtomotif(DataSet ds)
        {
            #region cetak nota 2
            BuildString1 data = new BuildString1();
            string typePrinter = data.GetPrinterName();
            string sNamacust = ds.Tables[0].Rows[0]["nama_cust"].ToString().Trim();
            string scust = sNamacust + data.SPACE(sNamacust.Length + (15 - sNamacust.Length) - 7);
            string sAlamat = ds.Tables[0].Rows[0]["alamat"].ToString().Trim();
            string sDaerah = ds.Tables[0].Rows[0]["daerah"].ToString().Trim();
            string sKota = ds.Tables[0].Rows[0]["kota"].ToString().Trim();
            string sPramuniaga = ds.Tables[1].Rows[0]["cs"].ToString().Trim();
            string ckp = "";
            string cKm = ds.Tables[0].Rows[0]["km"].ToString().Trim();
            string cKe = "";
            int nKe = int.Parse(ds.Tables[0].Rows[0]["ServiceKe"].ToString());

            if (nKe > 0 && nKe <= 3)
                cKe = nKe.ToString();
            else
                cKe = " ";

            if (!CekPrint())
            {
                ckp = "CP";
            }

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }

            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.Cursor = Cursors.WaitCursor;
            DataTable dtprs = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_caraiprs"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                dtprs = db.Commands[0].ExecuteDataTable();
            }
            data.PROW(true, 1,
            dtprs.Rows[0]["Nama"].ToString().Trim());
            data.PROW(false, 47, "NOTA SERVICE: " + ds.Tables[0].Rows[0]["nomor"].ToString() + "   " + ckp);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dtprs.Rows[0]["Alamat"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, "  " + data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Customer               " + data.PrintHorizontalLine(12) + data.PrintTopRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "NO. POLISI   : " + ds.Tables[0].Rows[0]["no_pol"].ToString().PadRight(8) + " / Km : " + cKm + " / Serv ke : " + cKe);
            data.PROW(false, 53, data.PrintVerticalLine() + scust.PadRight(38) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "CUST. SERV.  : " + ds.Tables[0].Rows[0]["CS"].ToString().PadRight(25));
            data.PROW(false, 53, data.PrintVerticalLine() + sAlamat.PadRight(38) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "No. NPS      : " + ds.Tables[1].Rows[0]["NoSuratJalan"].ToString().PadRight(25));
            data.PROW(false, 53, data.PrintVerticalLine() + sKota.PadRight(38) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            data.PROW(true, 1, "Tanggal Nota : " + ((DateTime)ds.Tables[0].Rows[0]["tgl_srv"]).ToString("dd-MMM-yyyy"));
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(38) + data.PrintVerticalLine());
            data.FontCondensed(false);
            data.AddCR();
            //data.PROW(true, 1, "Kilometer         : " + int.Parse(ds.Tables[0].Rows[0]["Km"].ToString()));
            data.PROW(true, 75, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(54) + data.PrintBottomRightCorner());
            //data.FontItalic(false);
            data.FontCondensed(true);

            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            /*                  12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890*/
            /*                           1         2         3         4         5         6         7         8         9         10        11        12        13        14*/
            data.PROW(true, 1, " ");
            data.PROW(true, 1, " NO.  K E T E R A N G A N                                      PART NUMBER   Q T Y      HARGA SAT     DISC%  POT         JUMLAH HARGA ");
            /*                    1.  1234567890123456789012345678901234567890123456789012345  123456789012    111 sat  Rp.9,999,999  99,99  Rp.999,999  Rp.99,999,999*/
            /*                                 1         2         3         4         5         6   */
            data.PROW(true, 1, data.PrintDoubleLine(134));

            StrMaker sm = new StrMaker();
            sm.SetSetting("Space", "  ");
            sm.SetSetting("Before", " ");
            sm.SetSetting("After", " ");

            List<StrMakerColumn> cols = new List<StrMakerColumn>();
            cols.AddRange(new StrMakerColumn[] {
                new StrMakerColumn("No", 3, SMCType.Int, SMCAlign.Right),
                new StrMakerColumn("Keterangan", 55, SMCType.String),
                new StrMakerColumn("PartNumber", 12, SMCType.String),
                new StrMakerColumn("Qty", 9, SMCType.String, SMCAlign.Right),
                new StrMakerColumn("HargaSatuan", 12, SMCType.Money),
                new StrMakerColumn("Disc", 5, SMCType.Float),
                new StrMakerColumn("Potongan", 10, SMCType.Money),
                new StrMakerColumn("Jumlah", 13, SMCType.Money)
            });
            cols[0].SetSetting("After", ".");
            sm.AddColumn(cols);
            #endregion

            #region Detail
            int nUrut = 0;
            int banyakService = ds.Tables[0].Rows.Count;
            int nUrut1 = nUrut + banyakService;
            string sKet, sSatuan, sTemp, subket, sNmBrg, subNamaBarang, idbrg, sPartno;
            double nQty, nHrgSat, nHrgBruto, nOngkosService;
            double nRpNetto = 0, nSumDiscNota = 0, nSumTotServ = 0, nSumPotNota = 0, nTotalHrg = 0,
                   nSumDiscService = 0, nSumPotService = 0, nSumBiayaNetto = 0,
                   nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPot = 0;

            #region Biaya Service Spm
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Tools.isNull(dr["kategori"], "").ToString() != "")
                    {
                        nUrut += 1;
                        int panjanghuruf;
                        sKet = Tools.isNull(dr["kategori"], data.SPACE(52)).ToString();
                        panjanghuruf = sKet.Trim().Length;
                        if (panjanghuruf >= 52)
                            subket = sKet.Substring(0, 52);
                        else
                            subket = sKet;

                        nOngkosService = double.Parse(Tools.isNull(dr["biaya"], "0").ToString());
                        nDisc1 = double.Parse(Tools.isNull(dr["disc_1"], "0").ToString());
                        nDisc2 = double.Parse(Tools.isNull(dr["disc_2"], "0").ToString());
                        nDisc3 = double.Parse(Tools.isNull(dr["disc_3"], "0").ToString());
                        nSumDiscService = double.Parse(Tools.isNull(dr["DiscService"], "0").ToString());
                        nSumPotService = double.Parse(Tools.isNull(dr["PotService"], "0").ToString());
                        nSumBiayaNetto = double.Parse(Tools.isNull(dr["BiayaNetto"], "0").ToString());
                        nTotalHrg += nSumBiayaNetto;

                        sTemp = sm.Parse(new object[] {
                            nUrut.ToString().PadLeft(2, '0'),          // nomor
                            subket.PadRight(55, '.'),                  //kategori
                            "",                                        //partnumber
                            "",                                        //qty
                            nOngkosService,                            //biaya
                            nDisc1,                                    //diskon
                            nSumPotService,                            //potongan
                            nSumBiayaNetto                             //jmlharga
                        });

                        /*sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ".  ";                         //nomer
                        sTemp = sTemp + subket.PadRight(55, '.') + "  ";                                //kategori
                        sTemp = sTemp + "            " + "    ";                                        //partnumber
                        sTemp = sTemp + "       " + "  ";                                               //qty 
                        sTemp = sTemp + "Rp." + nOngkosService.ToString("#,###").PadLeft(9) + "  ";     //biaya
                        sTemp = sTemp + nDisc1.ToString("#,##0.#0").PadLeft(5) + "  ";                  //diskon
                        sTemp = sTemp + "Rp." + nSumPotService.ToString("#,###").PadLeft(7) + "  ";     //potongan
                        sTemp = sTemp + "Rp." + nSumBiayaNetto.ToString("#,###").PadLeft(10);           //jmlharga*/
                        data.PROW(true, 1, sTemp);
                    }
                }
            }
            #endregion


            #region Pengambilan Spareparts
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    int ptext = int.Parse(dr1["BarangID"].ToString().Trim().Length.ToString());
                    if (ptext != 0)
                    {
                        nUrut += 1;
                        idbrg = dr1["BarangID"].ToString();
                        sNmBrg = dr1["NamaBarang"].ToString();

                        int panjanghuruf = sNmBrg.Length;
                        panjanghuruf = sNmBrg.Length;

                        if (panjanghuruf >= 55)
                            subNamaBarang = sNmBrg.Substring(0, 55);
                        else
                            subNamaBarang = sNmBrg;

                        string sPartNumber = "";
                        sPartNumber = Tools.isNull(dr1["PartNo"], "").ToString().Trim();
                        if (sPartNumber.Length > 0)
                        {
                            if (sPartNumber.Length > 12)
                                sPartNumber = sPartNumber.Substring(0, 12);
                            else
                                sPartNumber = dr1["PartNo"].ToString();
                        }
                        else
                        {
                            sPartNumber = "            ";
                        }
                        sSatuan = dr1["satuan"].ToString();
                        nQty = Convert.ToDouble(Tools.isNull(dr1["QtySuratJalan"], "0").ToString());
                        nHrgSat = Convert.ToDouble(Tools.isNull(dr1["HrgJual"], "0").ToString());
                        nDisc1 = double.Parse(Tools.isNull(dr1["disc_1"], "0").ToString());
                        nDisc2 = double.Parse(Tools.isNull(dr1["disc_2"], "0").ToString());
                        nDisc3 = double.Parse(Tools.isNull(dr1["disc_3"], "0").ToString());
                        nPot = double.Parse(Tools.isNull(dr1["PotNota"], "0").ToString());
                        nHrgBruto = nQty * nHrgSat;
                        nSumDiscNota = Convert.ToDouble(Tools.isNull(dr1["DiscNota"], "0").ToString());
                        nSumPotNota = Convert.ToDouble(Tools.isNull(dr1["PotNota"], "0").ToString());
                        nRpNetto = double.Parse(Tools.isNull(dr1["RpNetto"], "0").ToString());
                        nTotalHrg += nRpNetto;

                        sTemp = sm.Parse(new object[] {
                            nUrut.ToString().PadLeft(2, '0'),                           // nomor
                            subNamaBarang.PadRight(55, '.'),                            //kategori
                            sPartNumber,                                                //partnumber
                            nQty + " " + Tools.isNull(sSatuan.PadRight(3, ' '), "   "), //qty
                            nHrgSat,                                                    //biaya
                            nDisc1,                                                     //diskon
                            nPot,                                                       //potongan
                            nRpNetto                                                    //jmlharga
                        });
                        /*sTemp = " " + nUrut.ToString().PadLeft(2, '0') + ".  ";                                         //nomer
                        sTemp = sTemp + subNamaBarang.PadRight(55, '.') + "  ";                                         //barang
                        sTemp = sTemp + sPartNumber + "    ";                                                           //partnumber
                        sTemp = sTemp + nQty.ToString("#,###").PadLeft(3) + "." + Tools.isNull(sSatuan, "   ") + "  ";  //qty+satuan
                        sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9) + "  ";                            //hrgasatuan
                        sTemp = sTemp + nDisc1.ToString("#,###0.#0").PadLeft(5) + "  ";                                 //disc
                        sTemp = sTemp + "Rp." + nPot.ToString("#,###").PadLeft(7) + "  ";                               //pot
                        sTemp = sTemp + "Rp." + nRpNetto.ToString("#,###").PadLeft(10);                                 //jmlharga*/
                        data.PROW(true, 1, sTemp);
                    }
                }
            }

            if (nUrut % 20 > 0)
            {
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, " ");
                    //data.PROW(true, 1, " " + n.ToString().PadLeft(2, '0') + ".  ");
                }
            }
            #endregion

            data.FontCondensed(true);
            data.AddCR();

            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "Printed by " + SecurityManager.UserName + ", " + DateTime.Now);
            data.PROW(false, 108, "Jumlah      Rp.");
            data.DoubleHeight(true);
            data.FontBold(true);
            data.PROW(false, 123, nTotalHrg.ToString("#,###").PadLeft(10));
            data.DoubleHeight(false);
            data.FontBold(false);
            data.PROW(true, 1, "SARAN : ");
            data.Eject();
            data.SendToFile("NotaBengkel.txt");
            #endregion

            Guid RowIDP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_nPrint_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDP));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
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
            RefreshDataService();
            #endregion
        }

        


        private void rgbTglRQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataService()
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_service_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_srv_from", SqlDbType.DateTime, rgbTglService.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_srv_to", SqlDbType.DateTime, rgbTglService.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dgvHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    dgvDetail1.DataSource = null;
                    dgvDetail2.DataSource = null;
                    dgvDetail3.DataSource = null;
                }
                else
                {
                    RefreshDataServiceDetail();
                    RefreshDataNotaPOS();
                    RefreshDataJual();
                    dgvHeader.Focus();
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

        public void RefreshDataServiceDetail()
        {
            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));                    
                dtDetail1 = db.Commands[0].ExecuteDataTable();
                dgvDetail1.DataSource = dtDetail1;
            }                                
        }

        public void RefreshDataNotaPOS()
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_notapos"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail2 = db.Commands[0].ExecuteDataTable();
                    dgvDetail2.DataSource = dtDetail2;
                }
            }
        }

        public void RefreshDataJual()
        {
            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_djual_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
                dtDetail3 = db.Commands[0].ExecuteDataTable();
                dgvDetail3.DataSource = dtDetail3;
            }
        }


        private void cmdADD_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                Guid headerID;
                ISA.Bengkel.BaseForm ifrmChild;
                ISA.Trading.BaseForm ifrmChild2;

                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:           //Grid1 : service header
                        ifrmChild = new frmServiceUpdate(this);
                        ifrmChild.ShowDialog();
                        break;

                    case enumSelectedGrid.Detail1Selected:          //Grid2 : jasa service
                        if (!CekPrint())
                        {
                            MessageBox.Show("Nota sudah diPrint, tidak bisa diTambah..");
                            return;
                        }

                        tanggal = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                        
                        if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value < GlobalVar.DateOfServer)
                        {
                            return;
                        }
                        else
                        {
                            //tambah disini parameter nopol spm untuk cek frekwensi service
                            Guid RowID= Guid.NewGuid();
                            headerID  = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string NoPol = (string)Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["no_pol"].Value, "");
                            string HtrID = (string)Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["Idtr"].Value,"");
                            string perb = dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString();
                            ifrmChild = new frmServiceDetailUpdate(this, RowID, headerID, HtrID, FormTools.enumFormMode.New, NoPol,perb);
                            ifrmChild.ShowDialog();
                        }
                        break;

                    case enumSelectedGrid.Detail2Selected:          //Grid3 : pengambilan sparepart
                        if (!CekPrint())
                        {
                            MessageBox.Show("Nota sudah diPrint, tidak bisa diTambah..");
                            return;
                        }
                        tanggal = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                        if (tanggal < GlobalVar.DateOfServer)
                        {
                            return;
                        }
                        else
                        {
                            headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            RowIDNota_ = (Guid)Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["RowIDNota"].Value,Guid.Empty);
                            DateTime TglSrv = (DateTime)Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value,DBNull.Value);
                            DataTable dtJSrv = new DataTable();
                            string RecHeaderID = "", PktService = "", GantiOli = "";

                            /*GetDataKategoriService untuk Promo Service atau Bongkar dengan nominal tertentu.*/
                            try
                            {
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_GetDataKatService"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));
                                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, TglSrv));
                                    dtJSrv = db.Commands[0].ExecuteDataTable();
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                            if (dtJSrv.Rows.Count > 0)
                            {
                                if (int.Parse(Tools.isNull(dtJSrv.Rows[0]["Servis"], "0").ToString()) > 0 )
                                {
                                    PktService = "1";
                                }
                            }

                            ///*GetDataKategoriService untuk promo Service dan pengambilan Oli tertentu*/
                            //DataTable dtsv = new DataTable();
                            //try
                            //{
                            //    using (Database db = new Database())
                            //    {
                            //        db.Commands.Add(db.CreateCommand("usp_GetDataKatServiceOli"));
                            //        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));
                            //        db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, TglSrv));
                            //        dtsv = db.Commands[0].ExecuteDataTable();
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    Error.LogError(ex);
                            //}
                            //if (dtsv.Rows.Count > 0)
                            //{
                            //    PktService = "2";
                            //}

                            if (RowIDNota_ != Guid.Empty)
                            {
                                try
                                {
                                    DataTable dtGetRecID = new DataTable();
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_GetHeaderRecordID"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDNota_));
                                        dtGetRecID = db.Commands[0].ExecuteDataTable();
                                    }
                                    if (dtGetRecID.Rows.Count > 0)
                                    {
                                        RecHeaderID = Convert.ToString(dtGetRecID.Rows[0]["RecordID"]);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                }
                            }

                            string Pbc = "";
                            if (Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value, "").ToString() == "INV" ||
                                Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value, "").ToString() == "KRY"
                                )
                                Pbc = "INV";
                            else if (Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value, "").ToString() == "INSTANSI" ||
                                Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value, "").ToString() == "SEKOLAH")
                                Pbc = "OTH";
                            else
                                Pbc = "UMUM";
                            ISA.Trading.POS.FrmPOSbengkel frmChildPOS;
                            frmChildPOS = new ISA.Trading.POS.FrmPOSbengkel("BENGKEL",headerID,RowIDNota_,
                                          GlobalVar.CabangID, GlobalVar.PerusahaanID, GlobalVar.LastClosingDate,
                                          GlobalVar.Gudang, Pbc, SecurityManager.UserName, RecHeaderID, PktService);

                            frmChildPOS.ShowDialog();
                            RefreshDataNotaPOS();
                            RefreshDataService();
                        }
                        break;

                    case enumSelectedGrid.Detail3Selected:
                        if (!CekPrint())
                        {
                            MessageBox.Show("Nota sudah diPrint, tidak bisa diTambah..");
                            return;
                        }
                        tanggal = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                        if (tanggal < GlobalVar.DateOfServer)
                        {
                            return;
                        }
                        else
                        {
                            Guid RowID = Guid.NewGuid();
                            headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string perbaikan = dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString();
                            string HtrID = (string)dgvHeader.SelectedCells[0].OwningRow.Cells["Idtr"].Value;
                            ifrmChild = new frmServiceJualUpdate(this, RowID, headerID, HtrID, FormTools.enumFormMode.New,perbaikan);
                            ifrmChild.ShowDialog();
                        }
                        break;
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


        public void ifrmChild2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            //if (!CekAddEditDel())
            //{
            //    return;l
            //}
            if (!CekPrint())
            {
                MessageBox.Show("Nota sudah diPrint, tidak bisa diedit..");
                return;
            }
            if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["Tgl_srv"].Value < GlobalVar.DateOfServer)
            {
                MessageBox.Show("Tidak bisa Edit data tanggal sebelumnya.");
                return;
            }

            Guid rowID;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ISA.Bengkel.BaseForm ifrmChild;
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (FormTools.IsRowSelected(dgvHeader))
                        {
                            rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            ifrmChild = new frmServiceUpdate(this, rowID);
                            ifrmChild.ShowDialog();
                        }
                        break;

                    case enumSelectedGrid.Detail1Selected:
                        if (FormTools.IsRowSelected(dgvDetail1))
                        {
                            rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string HtrID = (string)dgvHeader.SelectedCells[0].OwningRow.Cells["Idtr"].Value;
                            string NoPol = (string)Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["no_pol"].Value, "");
                            string perb = dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString();
                            ifrmChild = new frmServiceDetailUpdate(this, rowID, headerID, HtrID, FormTools.enumFormMode.Update, NoPol,perb);
                            ifrmChild.ShowDialog();
                        }
                        break;

                    case enumSelectedGrid.Detail2Selected:
                        if (FormTools.IsRowSelected(dgvDetail2))
                        {
                            Guid detRowID = (Guid)dgvDetail2.SelectedCells[0].OwningRow.Cells["RowIDPart"].Value;
                            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string HtrID = (string)dgvHeader.SelectedCells[0].OwningRow.Cells["Idtr"].Value;

                            ifrmChild = new frmServiceDetailPosUpdate(this, detRowID, headerID, HtrID, FormTools.enumFormMode.Update);
                            ifrmChild.ShowDialog();
                        }
                        break;

                    case enumSelectedGrid.Detail3Selected:
                        if (FormTools.IsRowSelected(dgvDetail3))
                        {
                            rowID = (Guid)dgvDetail3.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                            Guid headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string HtrID = (string)dgvHeader.SelectedCells[0].OwningRow.Cells["Idtr"].Value;
                            string perbaikan = dgvHeader.SelectedCells[0].OwningRow.Cells["perbaikan"].Value.ToString();
                            ifrmChild = new frmServiceJualUpdate(this, rowID, headerID, HtrID, FormTools.enumFormMode.Update,perbaikan);
                            ifrmChild.ShowDialog();
                        }
                        break;
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

        private bool ValidasiTanggal(DateTime Tanggal)
        {
            Boolean result = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LastClosingStok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "STK"));
                    dtc = db.Commands[0].ExecuteDataTable();
                }
                if (dtc.Rows.Count > 0)
                {
                    DateTime TglClosingSTK = (DateTime)Tools.isNull(dtc.Rows[0]["TglAkhir"], "");
                    string cTglcls = TglClosingSTK.ToString("dd/MM/yyyy");
                    DateTime dTglcls = DateTime.ParseExact(cTglcls, "dd/MM/yyyy", null);
                    DateTime TglAG = Tanggal;
                    string cTglAG = TglAG.ToString("dd/MM/yyyy");
                    DateTime dTglAG = DateTime.ParseExact(cTglAG, "dd/MM/yyyy", null);
                    if (dTglAG <= dTglcls)
                    {
                        result = false;
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
            return result;
        }

        private bool CekPrint()
        {
            bool cek = true;
            DataTable dtHeader;
            Guid headerRowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_service_PRINT"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerRowID));
                dtHeader = db.Commands[0].ExecuteDataTable();
            }
            if (dtHeader.Rows.Count > 0)
            {
                int np = 0;
                np = (int)Tools.isNull(dtHeader.Rows[0]["nPrint"],0);
                if (np >= 1)
                {
                    cek = false;
                }
            }
            return cek;
        }


        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (!CekAddEditDel())
            {
                return;
            }
            if (!CekPrint())
            {
                MessageBox.Show("Nota sudah diPrint, tidak bisa dihapus..");
                return;
            }
            if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["Tgl_srv"].Value < GlobalVar.DateOfServer)
            {
                MessageBox.Show("Tidak bisa Delete data tanggal sebelumnya.");
                return;
            }

            Guid rowID;

            switch (selectedGrid)
            {
                #region Header Servis
                case enumSelectedGrid.HeaderSelected:
                    GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                    if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value <= GlobalVar.LastClosingDate)
                    {
                        MessageBox.Show("Sudah closing !, tidak bisa dihapus");
                        return;
                    }

                    if (dgvDetail1.Rows.Count > 0 || dgvDetail2.Rows.Count > 0 || dgvDetail3.Rows.Count > 0)
                    {
                        MessageBox.Show("Data ini sudah mempunyai detail, hapus detail terlebih dahulu");
                        return;
                    }

                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_service_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            RefreshDataService();
                            MessageBox.Show("Record telah dihapus");
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
                #endregion

                #region Jasa Servis
                case enumSelectedGrid.Detail1Selected:
                    if (FormTools.IsRowSelected(dgvDetail1))
                    {
                        GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                        if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value <= GlobalVar.LastClosingDate)
                        {
                            MessageBox.Show("Sudah closing !, tidak bisa dihapus");
                            return;
                        }
                        if (!CekPrint())
                        {
                            MessageBox.Show("Nota sudah diPrint, tidak bisa diedit..");
                            return;
                        }

                        string katService = Tools.isNull(dgvDetail1.SelectedCells[0].OwningRow.Cells["kategori"].Value, "").ToString();
                        Guid RowIDSH = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Guid RowIDSD = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                        DateTime tgls = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;

                        if (!ValidateDeleteService(RowIDSH,RowIDSD,tgls))
                        {
                            MessageBox.Show("Data tidak bisa dihapus..!" + " \n" + "Karena sudah mendapatkan barang bonus");
                            return;
                        }
                        

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                RefreshGridAfterDelete(dgvDetail1);
                                MessageBox.Show("Record telah dihapus");
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
                #endregion

                #region POS
                case enumSelectedGrid.Detail2Selected:
                        if (FormTools.IsRowSelected(dgvDetail2))
                        {
                            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    Guid _DetailPartRowID = (Guid)dgvDetail2.SelectedCells[0].OwningRow.Cells["RowIDPart"].Value;
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_bkl_DetailPart_DELETE"));
                                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _DetailPartRowID));
                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                    //RefreshGridAfterDelete(dgvDetail2);
                                    MessageBox.Show("Data berhasil diHapus.");
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                }
                                finally
                                {
                                    this.Cursor = Cursors.Default;
                                }
                                RefreshDataService();
                            }
                        }
                        break;
                #endregion

                #region Penjualan lain-lain
                case enumSelectedGrid.Detail3Selected:
                    if (FormTools.IsRowSelected(dgvDetail3))
                    {
                        GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                        if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value <= GlobalVar.LastClosingDate)
                        {
                            MessageBox.Show("Sudah closing !, tidak bisa dihapus");
                            return;
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                rowID = (Guid)dgvDetail3.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_bkl_djual_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                RefreshGridAfterDelete(dgvDetail3);
                                MessageBox.Show("Record telah dihapus");
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
                #endregion
            }
        }


        private bool ValidateDeleteService(Guid RowidSH, Guid RowIDSD, DateTime Tgls)
        {
            bool valid = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                int srv = 0, tap = 0, pos = 0;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetDataKategoriService"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowidSH));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, RowIDSD));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, Tgls));
                    ds = db.Commands[0].ExecuteDataSet();

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            srv = int.Parse(Tools.isNull(ds.Tables[1].Rows[0]["servis"], "0").ToString());
                            tap = int.Parse(Tools.isNull(ds.Tables[1].Rows[0]["TapOli"], "0").ToString());
                            pos = int.Parse(Tools.isNull(ds.Tables[1].Rows[0]["Jdo"], "0").ToString());
                            if (srv > 0 && tap > 0 && pos > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                valid = false;
                            }
                        }
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
            return valid;
        }


        private bool CekAddEditDel()
        {
            bool cek = true; 

            if (!FormTools.IsRowSelected(dgvHeader))
            {
                cek = false;
                goto SelesaiCek;
            }

            SelesaiCek:
            return cek;
        }


        
        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (dgvHeader.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(ISA.Bengkel.Helper.Messages.Error.RowNotSelected);
                        return;
                    }
                    //if (!CekPrint())
                    //{
                    //    MessageBox.Show("Nota sudah diPrint !!");
                    //    return;
                    //}
                    CetakNota();
                    break;

                case Keys.Tab:
                    dgvDetail1.Focus();
                    selectedGrid = enumSelectedGrid.Detail1Selected;
                    break;

                case Keys.Delete:
                    if (!CekPrint())
                    {
                        MessageBox.Show("Nota sudah diPrint, tidak bisa diedit..");
                        return;
                    }

                    GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                    if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value <= GlobalVar.LastClosingDate)
                    {
                        //throw new Exception(String.Format(ISA.Bengkel.Helper.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        MessageBox.Show("Sudah Closing !, tidak bisa dihapus.");
                        return;
                    }

                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            if (dgvDetail1.Rows.Count > 0 || dgvDetail2.Rows.Count > 0 || dgvDetail3.Rows.Count > 0)
                            {
                                MessageBox.Show("Data ini sudah mempunyai detail, hapus detail terlebih dahulu");
                            }
                            else
                            {
                                Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_bkl_service_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                RefreshDataService();
                                MessageBox.Show("Record telah dihapus");
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
                    break;
            }
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (!CekPrint())
                    {
                        MessageBox.Show("Nota sudah diPrint, tidak bisa diedit..");
                        return;
                    }
                    break;

            }
            //    case Keys.Tab:
            //        dgvHeader.Focus();
            //        selectedGrid = enumSelectedGrid.HeaderSelected;
            //        break;
            //    case Keys.L:
            //        //CTRL + Shift + L
            //        if (e.Shift && e.Control)
            //        {
            //            GridList_ServiceDetail();
            //        }
            //        break;
            //}
        }

        private void GridList_ServiceDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtDetail1.Rows.Count > 0)
                {
                    //List<ReportParameter> rptParams = new List<ReportParameter>();
                    //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    //rptParams.Add(new ReportParameter("Gudang", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("NoACC", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("Supplier", dataGridHeader.SelectedCells[0].OwningRow.Cells["Supplier"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("TglRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("M", dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderSyncFlag"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("RpEstJual", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHrgJual"].Value.ToString()));
                    ////rptParams.Add(new ReportParameter("Item", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));
                    //rptParams.Add(new ReportParameter("RpEstHPP", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHPP"].Value.ToString()));
                    ////rptParams.Add(new ReportParameter("RpEstTerima", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));

                    //frmReportViewer ifrmReport = new frmReportViewer("gridDetailService.rdlc", rptParams, dtDetail, "dsService_Data");
                    //ifrmReport.Show();
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
        
        /* Laporan order harian */

        private void LaporanOrderHarian()
        {
            Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_ServiceHarian"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                    return;
                }
                else
                {
                    DisplayReport(dt);
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
            DateTime tgl = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
            //construct parameter
            string periode;
            periode = tgl.ToShortDateString();
            //List<ReportParameter> rptParams = new List<ReportParameter>();

            //rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("rptOrderHarian.rdlc", rptParams, dt, "dsService_Data");
            //ifrmReport.Show();

        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }       

        public void FindRow(FormTools.detailIndex idx, string columnName, string value)
        {
            switch(idx)
            {
                case FormTools.detailIndex.detail1:
                    dgvDetail1.FindRow(columnName, value);
                    break;
                case FormTools.detailIndex.detail2:
                    dgvDetail2.FindRow(columnName, value);
                    break;
                case FormTools.detailIndex.detail3:
                    dgvDetail3.FindRow(columnName, value);
                    break;
            }                       
        }


        public void FindRowBkl(string columnName, string value)
        {
            dgvHeader.FindRow(columnName, value);
        }


        public void FindRowNotaJualDetail(string columnName, string value)
        {
            dgvDetail2.FindRow(columnName, value);
        }


        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (FormTools.IsRowSelected(dgvHeader))
            {
                RefreshDataServiceDetail();
                RefreshDataNotaPOS();
                RefreshDataJual();
            }
        }


        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dgvDetail1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail1Selected;
        }

        private void dgvDetail2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail2Selected;
        }

        private void dgvDetail3_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail3Selected;
        }

        private void RefreshGridAfterDelete(Controls.CustomGridView dgv)
        {
            int i = 0;
            int n = 0;
            i = dgv.SelectedCells[0].RowIndex;
            n = dgv.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)dgv.SelectedCells[0].OwningRow.DataBoundItem;

            DataRow dr = dv.Row;

            dr.Delete();
            dtDetail1.AcceptChanges();
            dgv.Focus();
            dgv.RefreshEdit();
            if (dgv.RowCount > 0)
            {
                if (i == 0)
                {
                    dgv.CurrentCell = dgv.Rows[0].Cells[n];
                }
                else
                {
                    dgv.CurrentCell = dgv.Rows[i - 1].Cells[n];
                }

            }

        }

        private void dgvDetail2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (!CekPrint())
                    {
                        MessageBox.Show("Nota sudah diPrint, tidak bisa diHapus..");
                        return;
                    }

                    GlobalVar.LastClosingDate = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
                    if ((DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value <= GlobalVar.LastClosingDate)
                    {
                        MessageBox.Show("Sudah Closing..!, tidak bisa dihapus.");
                        return;
                    }

                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            Guid rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            MessageBox.Show("Record telah dihapus");
                            RefreshGridAfterDelete(dgvDetail1);
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

        private void dataGridDetail2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (!CekPrint())
                    {
                        MessageBox.Show("Nota sudah diPrint, tidak bisa diHapus..");
                        return;
                    }
                    cmdDELETE_Click(sender, e);
                    break;
            }
        }

        private void cmdLink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Link Nota Bengkel ke Piutang ?", "Link", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Parameters prms = new Parameters();
                prms.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
                prms.AddParameter("@userID", SqlDbType.VarChar, SecurityManager.UserID);
                DBTools.DBGetScalar("usp_Link_Service2Finance", prms);
                MessageBox.Show("Proses Link selesai..");
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Cetak Nota Bengkel ?", "Cetak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvHeader.SelectedCells.Count == 0)
                {
                    MessageBox.Show(ISA.Bengkel.Helper.Messages.Error.RowNotSelected);
                    return;
                }
                CetakNota();
            }
       }

        private void dgvHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < dgvHeader.Rows.Count; rowIndex++)
            {
                if (dgvHeader.Rows[rowIndex].Cells["nPrint"].Value.ToString() != "1")
                {
                    dgvHeader.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void dgvDetail2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalVar.Gudang.Substring(0, 2) == "28")  //!= -> setelah ujicoba
            {
                if (e.ColumnIndex == 1)
                {
                    MessageBox.Show("Edit Qty");
                }
                if (e.ColumnIndex == 5)
                {
                    MessageBox.Show("Edit disc1");
                }
                if (e.ColumnIndex == 6)
                {
                    MessageBox.Show("Edit disc2");
                }
                if (e.ColumnIndex == 7)
                {
                    MessageBox.Show("Edit disc3");
                }
            }
        }
        private void LinkKS() {
            Guid RowIDToKP = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Guid RowIDKPD;
            if (dgvDetail1.Rows.Count > 0) {
                RowIDKPD = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
            }
            else if (dgvDetail3.Rows.Count > 0)
            {
                RowIDKPD = (Guid)dgvDetail3.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
            }
            else {
                RowIDKPD = Guid.NewGuid();
            }
            string nonotabengkel = dgvHeader.SelectedCells[0].OwningRow.Cells["nomor"].Value.ToString();
            DateTime tglnota = (DateTime)dgvHeader.SelectedCells[0].OwningRow.Cells["tgl_srv"].Value;
            string mekanik = dgvHeader.SelectedCells[0].OwningRow.Cells["kd_mk"].Value.ToString();
            string CS = dgvHeader.SelectedCells[0].OwningRow.Cells["cs"].Value.ToString();
            string kodetoko = "";
            if (dgvDetail3.Rows.Count > 0)
            {
                kodetoko = Tools.isNull(dgvDetail3.SelectedCells[0].OwningRow.Cells["kd_toko"].Value, "").ToString();
            }
            string NamaCust = dgvHeader.SelectedCells[0].OwningRow.Cells["nama_cust"].Value.ToString();
            string Plat = dgvHeader.SelectedCells[0].OwningRow.Cells["no_pol"].Value.ToString();
            //begin perulangan
            DataTable detail = new DataTable();
            DataTable djual = new DataTable();

            detail = (DataTable)dgvDetail1.DataSource;
            djual = (DataTable)dgvDetail3.DataSource;
            //Int32 qtyjualluar = 0;// = Int32.Parse(Tools.isNull(dgvDetail3.SelectedCells[0].OwningRow.Cells["dataGridViewTextBoxColumn21"].Value,"0").ToString());
            Double hargajualluar = 0;// = Convert.ToDouble(Tools.isNull(dgvDetail3.SelectedCells[0].OwningRow.Cells["dataGridViewTextBoxColumn23"].Value,"0").ToString());
            Double JasaService = 0;// = Convert.ToDouble(Tools.isNull(dgvDetail1.SelectedCells[0].OwningRow.Cells["biaya"].Value,"0").ToString());nettosd
            Double Potongan = 0;

            foreach(DataRow dr in djual.Rows){
                hargajualluar = hargajualluar + (Int32.Parse(Tools.isNull(dr["j_sj"], "0").ToString()) * Convert.ToDouble(Tools.isNull(dr["h_jual"], "0").ToString()));
            }
            foreach (DataRow drx in detail.Rows) {
                JasaService = JasaService + (Convert.ToDouble(Tools.isNull(drx["biaya"], "0").ToString()));
                Potongan = Potongan + (Convert.ToDouble(Tools.isNull(drx["pot_rp"], "0").ToString()));
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LinkKSToKP"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDToKP));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, RowIDKPD));
                    db.Commands[0].Parameters.Add(new Parameter("@NoNotaBengkel", SqlDbType.VarChar, nonotabengkel));
                    db.Commands[0].Parameters.Add(new Parameter("@tglnota", SqlDbType.DateTime, tglnota));
                    db.Commands[0].Parameters.Add(new Parameter("@mekanik", SqlDbType.VarChar, mekanik));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodetoko));
                    db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaCust", SqlDbType.VarChar, NamaCust));
                    //db.Commands[0].Parameters.Add(new Parameter("@qtyjualluar", SqlDbType.Int, qtyjualluar));
                    db.Commands[0].Parameters.Add(new Parameter("@hargajualluar", SqlDbType.Money, hargajualluar));
                    db.Commands[0].Parameters.Add(new Parameter("@JasaService", SqlDbType.Money, JasaService));
                    db.Commands[0].Parameters.Add(new Parameter("@cs", SqlDbType.VarChar, CS));
                    db.Commands[0].Parameters.Add(new Parameter("@Plat", SqlDbType.VarChar, Plat));
                    db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.VarChar, Potongan));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }
    }
}
