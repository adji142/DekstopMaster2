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
using ISA.Trading;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using ISA.Utility;
using System.Web;
using System.Net;
using System.Collections.Specialized;

namespace ISA.Trading.ArusStock
{
    public partial class frmAntarGudang : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        string RowIDheader;
        DataTable dtag;
        DataTable dtDetail;

        #region "Var&   "
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        //for Header
        Guid _RowID;
        Guid _Rowid;
        string _DrGudang, _KeGudang,_RecordID;
        string sflag = "";
        string RecordID_="";
        string PrnAktif = "0";
        int _nCetak = 0;
        string KetDO = "";
        //for Detail
        Guid _RowIDD, _HeaderIDD, _AGHeader;
        int uploadError = 0;
        string uploadErrorMessage = "";
        //string inputX;


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
                    dtDetail = dt.Copy();
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
            //ag.SendToFile("notaJual.txt");
        }

        private void PrintOut()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "DOAG"));
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


            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtA = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_AntarGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                    dtA = db.Commands[0].ExecuteDataTable();
                    if (dtA.Rows.Count > 0)
                    {
                        if (PrnAktif=="0")
                            DisplayReport(dtA);
                        else
                            DisplayReport_Inkjet(dtA);
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


        private void DisplayReport_Inkjet(DataTable dtA)
        {
            string KeGudang = dtA.Rows[0]["KeGudang"].ToString();
            string DrGudang = dtA.Rows[0]["DrGudang"].ToString();
            string NoAG = dtA.Rows[0]["NoAG"].ToString();
            string TglAG = dtA.Rows[0]["TglKirim"].ToString();
            string UserID = SecurityManager.UserName.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("KeGudang", KeGudang));
            rptParams.Add(new ReportParameter("DrGudang", DrGudang));
            rptParams.Add(new ReportParameter("NoAG", NoAG));
            rptParams.Add(new ReportParameter("TglAG", TglAG));

            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptCetakDObaru.rdlc", rptParams, dtA, "AntarGudang_Data");
            ifrmReport.Print();
            //ifrmReport.Show();

            if (Convert.ToInt32(PrnAktif) >= 2)
            {
                ifrmReport = new frmReportViewer("ArusStock.rptCetakDObaru_copy1.rdlc", rptParams, dtA, "AntarGudang_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
            }
            
            if (Convert.ToInt32(PrnAktif) > 2)
            {
                ifrmReport = new frmReportViewer("ArusStock.rptCetakDObaru_copy2.rdlc", rptParams, dtA, "AntarGudang_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
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
            ag.SendToPrinter("NotaAG.txt");
            //ag.SendToFile("NotaAG.txt");
        }

        private void  PrintOut2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BPPAG"));
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
                    if (dtA.Rows.Count > 0)
                    {
                        if (PrnAktif == "0")
                            DisplayReport2(dtA);
                        else
                            DisplayReport2_Inkjet(dtA);
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


        private void DisplayReport2_Inkjet(DataTable dtA)
        {
            string KeGudang = dtA.Rows[0]["KeGudang"].ToString();
            string DrGudang = dtA.Rows[0]["DrGudang"].ToString();
            string NoAG = dtA.Rows[0]["NoAG"].ToString();
            string TglAG = dtA.Rows[0]["TglKirim"].ToString();
            string UserID = SecurityManager.UserName.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("KeGudang", KeGudang));
            rptParams.Add(new ReportParameter("DrGudang", DrGudang));
            rptParams.Add(new ReportParameter("NoAG", NoAG));
            rptParams.Add(new ReportParameter("TglAG", TglAG));

            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptCetakNotaAGbaru.rdlc", rptParams, dtA, "AntarGudang_Data");
            ifrmReport.Print();
            //ifrmReport.Show();

            if (Convert.ToInt32(PrnAktif) >= 2)
            {
                ifrmReport = new frmReportViewer("ArusStock.rptCetakNotaAGbaru_copy1.rdlc", rptParams, dtA, "AntarGudang_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
            }
            
            if (Convert.ToInt32(PrnAktif) > 2)
            {
                ifrmReport = new frmReportViewer("ArusStock.rptCetakNotaAGbaru_copy2.rdlc", rptParams, dtA, "AntarGudang_Data");
                ifrmReport.Print();
                //ifrmReport.Show();
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

            ipProgress = new InPopup(this, panel1);
            #region tutup
            /*sudah dipindah ke nota punjualan*/
            ///*cek Ag belum terima selama 1 minggu dari tgl kirim*/
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        DataTable dt = new DataTable();
            //        db.Commands.Add(db.CreateCommand("usp_AntarGudang_GIT_LIST"));
            //        dt = db.Commands[0].ExecuteDataTable();
            //        if (dt.Rows.Count > 0)
            //        {
            //            MessageBox.Show("Ada GIT AG lebih dari 7 hari");
            //            DateTime d1 = Convert.ToDateTime(dt.Rows[0]["tgl1"].ToString());
            //            DateTime d2 = Convert.ToDateTime(dt.Rows[0]["tgl2"].ToString());
            //            DisplayReport(dt,d1,d2);
            //        }
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
            #endregion
        }


        private void DisplayReport(DataTable dt, DateTime fromDate, DateTime toDate)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(LaporanGitAG(dt, fromDate, toDate));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "rpt_AntarGudangGit";

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

        private ExcelPackage LaporanGitAG(DataTable dt, DateTime fromDate, DateTime toDate)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan GIT Antar Gudang";
            ex.Workbook.Properties.SetCustomPropertyValue("GIT", "1147");

            ex.Workbook.Worksheets.Add("GIT");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 7;       //drgud
            ws.Cells[1, 4].Worksheet.Column(4).Width = 7;       //kegud
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //noag
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tglkirim
            ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //tglterima
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //kodebarang
            ws.Cells[1, 9].Worksheet.Column(9).Width = 73;      //namastok
            ws.Cells[1, 10].Worksheet.Column(10).Width = 6;     //satuan
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //qtykirim
            ws.Cells[1, 12].Worksheet.Column(12).Width = 14;    //hppa
            ws.Cells[1, 13].Worksheet.Column(13).Width = 14;    //jmlah

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan GIT Antar Gudang";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

            int MaxCol = 13;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Dr Gud ";
            ws.Cells[Rowx, 4].Value = " Ke Gud ";
            ws.Cells[Rowx, 5].Value = " No AG ";
            ws.Cells[Rowx, 6].Value = " Tgl Kirim ";
            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            ws.Cells[Rowx, 8].Value = " Kode Barang ";
            ws.Cells[Rowx, 9].Value = " Nama Stok ";
            ws.Cells[Rowx, 10].Value = " Sat ";
            ws.Cells[Rowx, 11].Value = " Qty Kirim ";
            ws.Cells[Rowx, 12].Value = " Hppa ";
            ws.Cells[Rowx, 13].Value = " Jumlah ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["DrGudang"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["KeGudang"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoAG"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglKirim"], ""));
                    ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTerima"], ""));
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["KodeBarang"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["SatJual"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 12].Value = Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 13].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString()) * Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString());
                    ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";

                    nQty += Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    nSaldo += (Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString()) * Convert.ToDouble(Tools.isNull(dr1["Hppa"], "0").ToString()));
                    Rowx++;
                }
                Rowx++;
                ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 11].Value = Tools.isNull(nQty, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

                ws.Cells[Rowx, 13].Value = Tools.isNull(nSaldo, 0);
                ws.Cells[Rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 13].Style.Font.Bold = true;

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
            }
            return ex;
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
                                int wiserid;
                                DateTime dtAG = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                String wsID =  Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["wiserid"].Value,"").ToString();
                                //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["wiserid"].Value.ToString() == "")
                                if (wsID == "")
                                {
                                    wiserid = 0;
                                }
                                else
                                {
                                    wiserid = (int)dataGridHeader.SelectedCells[0].OwningRow.Cells["wiserid"].Value;
                                }
                                if ((DateTime)dtAG <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                FillHeader();
                                //ArusStock.frmAntarGudangUpdate ifrmChild = new ArusStock.frmAntarGudangUpdate(this, _RowID, dtDetail);
                                ArusStock.frmAntarGudangUpdate ifrmChild = new ArusStock.frmAntarGudangUpdate(this, _RowID, dtDetail, wiserid);
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
                 if (e.Control)
                 {
                     switch (e.KeyCode)
                     {
                         case Keys.F1:
                             ArusStock.frmAntarGudang_RiwayatAG_Browse ifrmChild = new ArusStock.frmAntarGudang_RiwayatAG_Browse(rgbTglDO.FromDate.Value, rgbTglDO.ToDate.Value);
                             ifrmChild.MdiParent = Program.MainForm;
                             Program.MainForm.RegisterChild(ifrmChild);
                             ifrmChild.Show();
                             break;
                     }
                 }
                 else
                 {
                     if (e.KeyCode == Keys.F3)
                     {
                         if (!SecurityManager.IsAuditor())
                         {
                             PrintOut();
                         }
                     }

                     else if (e.KeyCode == Keys.F4)
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
                        if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString(), "True") == 0)
                        {
                            MessageBox.Show("Data sudah diupload !, Tidak bisa diedit..");
                            return;
                        }
                        if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString(), GlobalVar.Gudang) != 0)
                        {
                            MessageBox.Show("Hanya Untuk Gudang " + dataGridHeader.SelectedCells[0].OwningRow.Cells["DrGudang"].Value.ToString());
                            return;
                        }
                        //if (String.Compare(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString(), "True") == 0)
                        //{
                        //    {
                        //        MessageBox.Show("Data sudah diupload !, Tidak bisa tambah detail barang..");
                        //        return;
                        //    }
                        //    /*if (!SecurityManager.AskPasswordManager())
                        //    {
                        //        return;
                        //    }*/
                        //}
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
            if (Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value,"").ToString() != "")
            {
                MessageBox.Show("Tanggal Terima sudah terisi, tidak bisa edit.");
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
            if (Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value, "").ToString() != "")
            {
                MessageBox.Show("Tanggal Terima sudah terisi, tidak bisa Delete.");
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
                        //if (dataGridHeader.Rows.Count > 0)
                        //{
                            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        //}
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

        private void dataGridHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int rowIndex = 0; rowIndex < dataGridHeader.Rows.Count; rowIndex++)
            //{
            //    if (Convert.ToDouble(Tools.isNull(dataGridHeader.Rows[rowIndex].Cells["NPrint"], "0").ToString()) == 0)
            //    {
            //        //All column in Row
            //        dataGridHeader.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            //        //One column in Row
            //        //dataGridHeader.Rows[rowIndex].Cells["NamaStok"].Style.BackColor = Color.FromArgb(255, 125, 190);
            //    }
            //    else
            //    {
            //        dataGridHeader.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
            //    }
            //}
        }

        FakeProgress pWiserSync;
        InPopup ipProgress;
        private void btnUploadWiserdc_Click(object sender, EventArgs e)
        {
            ipProgress.OpenDialog(this);
            _AGHeader = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            bwUploadWiserdc.RunWorkerAsync();
        }

        private void bwUploadWiserdc_DoWork(object sender, DoWorkEventArgs e)
        {
            if (pWiserSync == null) pWiserSync = new FakeProgress(progressBar1);
            Form thisx = this;

            uploadError = 0;
            pWiserSync.Start();
            DataTable dtbl = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "WiserDC_Host"));
                dtbl = db.Commands[0].ExecuteDataTable();

                string host = "http://devwiserdc.sas-autoparts.com:8000";
                if (dtbl.Rows.Count > 0) host = dtbl.Rows[0]["Value"].ToString();
                db.Commands.Clear();

                db.Commands.Add(db.CreateCommand("psp_AntarGudang_UPLOAD_WiserDC"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _AGHeader));

                dtbl = db.Commands[0].ExecuteDataTable();

                if (dtbl.Rows.Count > 0)
                {
                    if (dtbl.Rows[0]["Result"].ToString() != "1")
                    {
                        uploadErrorMessage = dtbl.Rows[0]["Msg"].ToString();
                        uploadError = 1;
                        return;
                    }

                    List<string> Hids = new List<string>();
                    JSON hdat = new JSON(JSONType.Array);
                    foreach (DataRow cur in dtbl.Rows)
                    {
                        if (Hids.IndexOf(cur["NoAG"].ToString()) < 0)
                        {
                            JSON cur2 = new JSON(JSONType.Object);
                            cur2.ObjAdd("RowID", new JSON(cur["HRowID"].ToString()));
                            cur2.ObjAdd("NoAG", new JSON(cur["NoAG"]));
                            cur2.ObjAdd("TglAG", new JSON(cur["TglAG"]));
                            cur2.ObjAdd("TglNotaAG", new JSON(cur["TglNotaAG"]));
                            cur2.ObjAdd("TglKirim", new JSON(cur["TglKirim"]));
                            cur2.ObjAdd("DrGudang", new JSON(cur["DrGudang"]));
                            cur2.ObjAdd("KeGudang", new JSON(cur["KeGudang"]));
                            cur2.ObjAdd("Pengirim", new JSON(cur["Pengirim"]));
                            cur2.ObjAdd("Penerima", new JSON(cur["Penerima"]));
                            cur2.ObjAdd("DrCheck1", new JSON(cur["DrCheck1"]));
                            cur2.ObjAdd("DrCheck2", new JSON(cur["DrCheck2"]));
                            cur2.ObjAdd("KeCheck1", new JSON(cur["KeCheck1"]));
                            cur2.ObjAdd("KeCheck2", new JSON(cur["KeCheck2"]));
                            cur2.ObjAdd("Catatan", new JSON(cur["HCatatan"]));
                            cur2.ObjAdd("Expedisi", new JSON(cur["Expedisi"]));
                            cur2.ObjAdd("NoKendaraan", new JSON(cur["NoKendaraan"]));
                            cur2.ObjAdd("NamaSopir", new JSON(cur["NamaSopir"]));
                            cur2.ObjAdd("SyncFlag", new JSON(cur["SyncFlag"]));
                            cur2.ObjAdd("User", new JSON(SecurityManager.UserID));

                            cur2.ObjAdd("Details", new JSON(JSONType.Array));
                            hdat.ArrAdd(cur2);

                            Hids.Add(cur["NoAG"].ToString());
                        }

                        int ix = Hids.IndexOf(cur["NoAG"].ToString());
                        if (ix > -1)
                        {
                            JSON cur3 = new JSON(JSONType.Object);
                            cur3.ObjAdd("RowID", new JSON(cur["DRowID"].ToString()));
                            cur3.ObjAdd("HeaderID", new JSON(cur["HRowID"].ToString()));
                            cur3.ObjAdd("KodeBarang", new JSON(cur["KodeBarang"]));
                            cur3.ObjAdd("QtyAG", new JSON(cur["QtyKirim"]));
                            //cur3.ObjAdd("NoKoli", new JSON(cur["NoKoli"]));
                            cur3.ObjAdd("Catatan", new JSON(cur["DCatatan"]));
                            JSON dmp = hdat[ix]["Details"];
                            hdat[ix]["Details"].ArrAdd(cur3);
                        }
                    }

                    bwUploadWiserdc.ReportProgress(1);
                    int s = 0, f = 0, m = hdat.Count;
                    foreach (int cur in hdat.ArrIndexs)
                    {
                        //inputX = hdat[cur].ToString();
                        //return;
                        string url = host + "/api/transaksi/antargudangv2/create";
                        //url += Uri.EscapeDataString(hdat[cur].ToString());

                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        req.ContentType = "application/json";
                        req.Method = "POST";

                        using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                        {
                            streamWriter.Write(hdat[cur].ToString());
                            streamWriter.Flush();
                            streamWriter.Close();
                        }

                        var res = (HttpWebResponse)req.GetResponse();
                        var resStr = new StreamReader(res.GetResponseStream()).ReadToEnd();

                        JSON jres = JSON.Parse(resStr);
                        if (jres.Type != JSONType.Null)
                        {
                            if (jres["result"].BoolValue) s += 1;
                            else f += 1;
                        }
                        else f += 1;

                        bwUploadWiserdc.ReportProgress((int)(((float)(s + f) / m) * 99) + 1);
                    }

                    if (s <= 0) // no item success
                    {
                        uploadErrorMessage = "Gagal synch wiserdc " + f + " items";
                        uploadError = 1;
                    }
                    else if (f > 0) // have some fails
                    {
                        uploadErrorMessage = "Selesai,\n - Sukses: " + s + "\n - Gagal: " + f;
                    }
                    else uploadErrorMessage = "";
                }
                else
                {
                    uploadErrorMessage = "Tidak ada item untuk di upload";
                    uploadError = 1;
                }
            }
        }

        private void bwUploadWiserdc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                pWiserSync.Done();
                progressBar1.Value = 0;
            }
            else
            {
                float c = ((float)e.ProgressPercentage - 1) / 99;
                progressBar1.Value = (int)(c * progressBar1.Maximum);
            }
        }

        private void bwUploadWiserdc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //textBox1.Text = inputX;
            progressBar1.Value = progressBar1.Maximum;

            if (e.Error != null) uploadErrorMessage = e.Error.Message;
            if (uploadError > 0 || uploadErrorMessage != "")
            {
                MessageBox.Show(uploadErrorMessage);
                uploadErrorMessage = "";
            }
            else 
            {
                SyncSuccess("AG", _AGHeader);
                MessageBox.Show("Upload Berhasil"); 
            }
            ipProgress.Close(true);
            uploadError = 0;
        }

        private void btnPullWiserDC_Click(object sender, EventArgs e)
        {
            ArusStock.frmAntarGudangSynch frm = new ArusStock.frmAntarGudangSynch();
            frm.ShowDialog();
        }

        private void SyncSuccess(string src, Guid RowID)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SynchSuccess_WiserDC"));
                    db.Commands[0].Parameters.Add(new Parameter("@Source", SqlDbType.VarChar, src));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
