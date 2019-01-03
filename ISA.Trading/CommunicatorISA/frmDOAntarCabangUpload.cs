using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.FTP;
using System.IO;
using ISA.Trading.Class;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDOAntarCabangUpload : ISA.Trading.BaseForm
    {
        #region "Global"
        string _hFileName = "Htjtmp";
        string _dFileName = "Dtjtmp";
        string _tFileName = "Ttjtmp";

        DataSet dsResult = new DataSet();        
        string Gudang;
        string cCab = GlobalVar.Gudang;
        //string cCab = GlobalVar.Gudang;
        int counter1 = 0;
        int counter2 = 0;
        DataTable dt = new DataTable();

        #endregion

        public frmDOAntarCabangUpload()
        {
            InitializeComponent();
        }

        private void frmDOAntarCabangUpload_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.Date;
            rangeDateBox1.ToDate = DateTime.Now.Date;
            lookupGudang1.GudangID = string.Empty;
            gridViewNotaPembelian.AutoGenerateColumns = true;
            gridViewNotaPembelianDetail.AutoGenerateColumns = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lookupGudang1.GudangID))
            {
                Gudang = string.Empty;
            }
            else
            {
                Gudang = lookupGudang1.GudangID;
            }
            RefreshData();
        }

        private void RefreshData()
        {
            pbUpload1.Value = 0;
            pbUpload2.Value = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DOAntarCabang_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Cab", SqlDbType.VarChar, cCab));
                    dsResult = db.Commands[0].ExecuteDataSet();

                    if(dsResult.Tables.Count > 0)
                    {
                        gridViewNotaPembelian.DataSource = dsResult.Tables[0];
                        gridViewNotaPembelianDetail.DataSource = dsResult.Tables[1];
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada");
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


        private void GetDataUnUpload()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DOAntarCabang_UnUpload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Cab", SqlDbType.VarChar, cCab));
                    dt = db.Commands[0].ExecuteDataTable();
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


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }


        /*private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_OrderPenjualan_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter1++;
                    pbUpload1.Minimum = 0;
                    pbUpload1.Maximum = ds.Tables[0].Rows.Count;
                    pbUpload1.Increment(1);
                }

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_OrderPenjualanDetail_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    counter2++;
                    pbUpload2.Minimum = 0;
                    pbUpload2.Maximum = ds.Tables[1].Rows.Count;
                    pbUpload2.Increment(1);
                }
            }
            return ds;
        }*/

        private DataSet getDataXML() {
            DataSet ds = new DataSet();
            using (Database db = new Database()) {
                db.Commands.Add(db.CreateCommand("usp_DOAntarCabang_Upload_XML"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@Cab", SqlDbType.VarChar, cCab));
                ds = db.Commands[0].ExecuteDataSet();
            }
            return ds;
        }
        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count == 0)
            {
                cmdSearch.PerformClick();
                return;
            }

            if (dsResult.Tables[0].Rows.Count == 0 || dsResult.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("Tidak data yang diupload");
                return;
            }

            try
            {
                //if (lookupGudang1.GudangID == "2801" || lookupGudang1.GudangID == "93")
                //{
                    this.Cursor = Cursors.WaitCursor;

                    Upload1(_hFileName);
                    Upload2(_dFileName);
                    Upload3(_tFileName);
                    ZipFile(_hFileName, _dFileName,_tFileName);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + Gudang + ".zip");
                //}
                //else {
                //    DataSet ds = getDataXML();
                //    if (ds.Tables.Count > 0)
                //    {
                //        string Target = lookupGudang1.GudangID;
                //        string fileOuput = FtpEngine.UploadDirectory + "\\" + "OPJ-" + cCab + Gudang + " " + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                //        ds.WriteXml(fileOuput);

                //        //if (FTP.FtpEngine.Upload(Target, fileOuput))
                //        //{

                //            MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                //        //}
                //        //else
                //        //{
                //        //    MessageBox.Show(Messages.Confirm.UploadFailed);
                //        //}
                //    }
                //}
                #region ijo2
                /*this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();
                if (ds.Tables.Count > 0)
                {
                    string Target = lookupGudang1.GudangID; 
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "OPJ-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
                    if (FTP.FtpEngine.Upload(Target, fileOuput))
                    {

                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.UploadFailed);
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                }*/
                #endregion 

                GetDataUnUpload();
                if (dt.Rows.Count > 0)
                {
                    DateTime fromdate = rangeDateBox1.FromDate.Value;
                    DateTime todate = rangeDateBox1.ToDate.Value;
                    DisplayReport(dt, fromdate, todate);
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


        private void DisplayReport(DataTable dt, DateTime fromdate_, DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ReportUnUpload(dt, fromdate_, todate_));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_DO_tidak_terupload";

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


        private ExcelPackage ReportUnUpload(DataTable dt, DateTime fromdate_, DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan Do tidak terupload";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan Do tidak terupload", "1147");

            ex.Workbook.Worksheets.Add("Upload Do");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;      //norq
            ws.Cells[1, 3].Worksheet.Column(3).Width = 13;      //tglrq
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      //nodo
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;      //tgldo
            ws.Cells[1, 6].Worksheet.Column(6).Width = 15;      //kodesales
            ws.Cells[1, 7].Worksheet.Column(7).Width = 31;      //toko
            ws.Cells[1, 8].Worksheet.Column(8).Width = 40;      //alamat
            ws.Cells[1, 9].Worksheet.Column(9).Width = 20;      //kota
            ws.Cells[1, 10].Worksheet.Column(10).Width = 5;     //jnstr
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;    //rpnet
            ws.Cells[1, 12].Worksheet.Column(12).Width = 18;    //noacc harga
            ws.Cells[1, 13].Worksheet.Column(13).Width = 18;    //noacc piutang
            ws.Cells[1, 14].Worksheet.Column(14).Width = 18;    //tglacc piutang
            ws.Cells[1, 15].Worksheet.Column(15).Width = 18;    //rpacc piutang
            ws.Cells[1, 16].Worksheet.Column(16).Width = 18;    //sisa plafon

            int nRow = 0, nHeader = 0, Rowx = 0;

            //#region Laporan
            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan Do tidak terupload";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;

            int MaxCol = 16;

            ws.Cells[Rowx, 2].Value = " NO RQ ";
            ws.Cells[Rowx, 3].Value = " TGL RQ ";
            ws.Cells[Rowx, 4].Value = " NO DO ";
            ws.Cells[Rowx, 5].Value = " TGL DO ";
            ws.Cells[Rowx, 6].Value = " SALES ";
            ws.Cells[Rowx, 7].Value = " NAMA TOKO ";
            ws.Cells[Rowx, 8].Value = " ALAMAT ";
            ws.Cells[Rowx, 9].Value = " KOTA ";
            ws.Cells[Rowx, 10].Value = " TR ";
            ws.Cells[Rowx, 11].Value = " Rp DO ";
            ws.Cells[Rowx, 12].Value = " NO ACC HARGA ";
            ws.Cells[Rowx, 13].Value = " NO ACC PIUTANG ";
            ws.Cells[Rowx, 14].Value = " TGL ACC PIUTANG ";
            ws.Cells[Rowx, 15].Value = " Rp ACC PIUTANG ";
            ws.Cells[Rowx, 16].Value = " SISA PLAFON ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            if (dt.Rows.Count > 0)
            {
                int no = 0;
                double Ins1 = 0, Ins2 = 0, Dnda = 0, Jml = 0;

                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = Tools.isNull(dr1["NoRequest"], "").ToString();
                    ws.Cells[Rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglRequest"], ""));
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["NoDO"], "").ToString();
                    ws.Cells[Rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglDO"], ""));
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["AlamatKirim"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], "0").ToString());
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["NoACCPusat"], "").ToString();
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["NoACCPiutang"], "").ToString();
                    ws.Cells[Rowx, 14].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglACCPiutang"], ""));
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 15].Value = Convert.ToDouble(Tools.isNull(dr1["RpACCPiutang"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 16].Value = Convert.ToDouble(Tools.isNull(dr1["RpPlafonToko"], "0").ToString());

                    Jml += (Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], "0").ToString()));
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[Rowx, 11].Value = Tools.isNull(Jml, 0);
                ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[Rowx, 11].Style.Font.Bold = true;

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


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZipFile(string FileName1, string FileName2,string FileName3)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".dbf";
            //string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".dbf";
            //string fileName4 = GlobalVar.DbfUpload + "\\" + FileName4 + ".dbf";
            //string fileIndex = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            //string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";

            string fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang+Gudang + ".zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            //files.Add(fileName3);
            //files.Add(fileName4);
            //files.Add(fileIndex);

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1) && File.Exists(fileName2))
            {
                File.Delete(fileName1);
                File.Delete(fileName2);
                File.Delete(fileName3);
                //File.Delete(fileName3);
                //File.Delete(fileName4);
                //File.Delete(fileIndex);
            }
        }

        private void Upload1(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoSJ", "No_sj", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Namatoko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("SumRpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("SumRpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp2", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp3", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("TglSJ", "tglsj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglTrm", "tgltrm" , Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Rpfee1", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rpfee2", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("checker_1", "checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("checker_2", "checker_2", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("syncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0], pbUpload1);
        }

        private void Upload2(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("SatJual", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Klp", "Klp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtySJ", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Hpokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("HppSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idmatch", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Idkoreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("TglSJ", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], pbUpload2);
        }
        private void Upload3(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("TokoID", "TokoID", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("NamaToko", "NamaToko", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Alamat", "Alamat", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 100));

            fields.Add(new Foxpro.DataStruct("Telp", "Telp", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("WilID", "WilID", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("PenanggungJawab", "PngJwb", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("KodeToko", "KodeToko", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("PiutangB", "PiutangB", Foxpro.enFoxproTypes.Numeric, 20));

            fields.Add(new Foxpro.DataStruct("PiutangJ", "PiutangJ", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Plafon", "Plafon", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("ToJual", "ToJual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("ToRetPot", "ToRetPot", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("JangkaWaktuKredit", "JWKredit", Foxpro.enFoxproTypes.Numeric, 10));

            fields.Add(new Foxpro.DataStruct("Cabang2", "Cabang2", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Tgl1st", "Tgl1st", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Exist", "Exist", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("ClassID", "ClassID", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 200));

            fields.Add(new Foxpro.DataStruct("SyncFlag", "SyncFlag", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("HariKirim", "HKirim", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("KodePos", "KodePos", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Grade", "Grade", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Plafon1st", "Plf_1st", Foxpro.enFoxproTypes.Numeric, 10));

            fields.Add(new Foxpro.DataStruct("Flag", "Flag", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Bentrok", "Bentrok", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("StatusAktif", "StsAktif", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("HariSales", "HSales", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Daerah", "Daerah", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("Propinsi", "Propinsi", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("AlamatRumah", "Alm_Rmh", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Pengelola", "Pnglola", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("TglLahir", "TglLahir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("HP", "HP", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("Status", "Status", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("ThnBerdiri", "ThnBrdr", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("StatusRuko", "StsRuko", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("JmlCabang", "JmlCabang", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("JmlSales", "JmlSales", Foxpro.enFoxproTypes.Numeric, 10));

            fields.Add(new Foxpro.DataStruct("Kinerja", "Kinerja", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("BidangUsaha", "Bdg_Usaha", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("RefSales", "RefSales", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("plf_fb", "plf_fb", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("plf_fx", "plf_fx", Foxpro.enFoxproTypes.Numeric, 10));

            fields.Add(new Foxpro.DataStruct("RefCollector", "RefColl", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("RefSupervisor", "RefSpvsr", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("PlafonSurvey", "Plf_Srvy", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("fax", "fax", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("bangunan", "bangunan", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("habis_kontrak", "hbs_ktrk", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("jenis_produk", "jns_prdk", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("nama_pemilik", "n_pmlik", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("jenis_kelamin", "gender", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("tempat_lhr", "t_lhr", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("email", "email", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("no_rekening", "no_rek", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("nama_bank", "n_bank", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("no_member", "no_member", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("hobi", "hobi", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("no_npwp", "no_npwp", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "LUpddBy", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "LUpdTime", Foxpro.enFoxproTypes.DateTime, 50));
            fields.Add(new Foxpro.DataStruct("Mediabyr", "Mediabyr", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Angsuran", "Angsuran", Foxpro.enFoxproTypes.Numeric, 10));

            fields.Add(new Foxpro.DataStruct("Ketbayar", "Ketbayar", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("JangkaWaktuKreditFX", "JWKFX", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("HariSalesFX", "HSlsFX", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("no_ktp", "no_ktp", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("ft_toko", "ft_toko", Foxpro.enFoxproTypes.Char, 50));

            fields.Add(new Foxpro.DataStruct("JangkaWaktuKreditFAB", "JWKFAB", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("HariSalesFAB", "HSlsFAB", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("VerifiedNIK", "VerNIK", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Cabang", "Cabang", Foxpro.enFoxproTypes.Char, 4));
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[2], pbUpload1);
        }
    }
}
