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
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ISA.Toko.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;



namespace ISA.Toko.Communicator
{
    public partial class frmHargaDownload : ISA.Toko.BaseForm
    {
        DataTable tblBMK;
        DataTable tblHks;
        DataTable tblHksAgen;


        public frmHargaDownload()
        {
            InitializeComponent();
        }

        private void DownloadBMK()
        {
            int counter = 0;

            bool isBmk11 = LookupInfoValue.CekBmk11();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryBMK_DOWNLOAD"));
                foreach (DataRow dr in tblBMK.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@id_hist", SqlDbType.VarChar, Tools.isNull(dr["id_hist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_stok", SqlDbType.VarChar, Tools.isNull(dr["id_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr["tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt_pasif", SqlDbType.DateTime, dr["tmt_pasif"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_std", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_std"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_net", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_net"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_b", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_m", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_m", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_k", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_k"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_k", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_k"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.Int, int.Parse(Tools.isNull(dr["cash"], "0").ToString())));//.Substring(0, Tools.isNull(dr["cash"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.Int, int.Parse(Tools.isNull(dr["top10"], "0").ToString())));//.Substring(0, Tools.isNull(dr["top10"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.Int, int.Parse(Tools.isNull(dr["enduser"], "0").ToString())));//.Substring(0, Tools.isNull(dr["enduser"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_c", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_c"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_t", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_t"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_e", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_e"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@dl", SqlDbType.VarChar, Tools.isNull(dr["dl"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr["nama_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrecstok", SqlDbType.VarChar, Tools.isNull(dr["idrecstok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr["satuan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sts_laba", SqlDbType.VarChar, Tools.isNull(dr["sts_laba"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (isBmk11)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@BmkDari11", SqlDbType.Int, 1));
                    }

                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblBMK.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadHks()
        {
            int counter = 0;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HargaKhusus_DOWNLOAD"));
                foreach (DataRow dr in tblHks.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dr["tmt1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dr["tmt2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@h_cash", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_cash"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_top10", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_top10"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_user", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_user"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@het", SqlDbType.Money, double.Parse(Tools.isNull(dr["het"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@dcash", SqlDbType.Money, double.Parse(Tools.isNull(dr["dcash"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dcash2", SqlDbType.Money, double.Parse(Tools.isNull(dr["dcash2"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dcash3", SqlDbType.Money, double.Parse(Tools.isNull(dr["dcash3"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dtop10", SqlDbType.Money, double.Parse(Tools.isNull(dr["dtop10"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dtop102", SqlDbType.Money, double.Parse(Tools.isNull(dr["dtop102"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dtop103", SqlDbType.Money, double.Parse(Tools.isNull(dr["dtop103"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@duser", SqlDbType.Money, double.Parse(Tools.isNull(dr["duser"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@duser2", SqlDbType.Money, double.Parse(Tools.isNull(dr["duser2"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@duser3", SqlDbType.Money, double.Parse(Tools.isNull(dr["duser3"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@flaghk", SqlDbType.VarChar, Tools.isNull(dr["FlagHK"], "").ToString()));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar2.Increment(1);
                    lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHks.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadHksAgen()
        {
            int counter = 0;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HargaKhususAgen_DOWNLOAD"));
                foreach (DataRow dr in tblHksAgen.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dr["tmt1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dr["tmt2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@h_cash", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_cash"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_top10", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_top10"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_user", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_user"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@het", SqlDbType.Money, double.Parse(Tools.isNull(dr["het"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@dcash", SqlDbType.Money, double.Parse(Tools.isNull(dr["dcash"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@dtop10", SqlDbType.Money, double.Parse(Tools.isNull(dr["dtop10"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@duser", SqlDbType.Money, double.Parse(Tools.isNull(dr["duser"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar2.Increment(1);
                    lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHks.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private bool UnzipFile(string sourceZIPFileName, string FileName1, string FileName2 , string FileName3)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload; // +"\\" + sourceZIPFileName;
            string zipFile = GlobalVar.DbfDownload + "\\" + sourceZIPFileName + ".ZIP";
            if (File.Exists(zipFile))
            {
                if (File.Exists(FileName1))
                {
                    File.Delete(FileName1);
                }

                if (File.Exists(FileName2))
                {
                    File.Delete(FileName2);
                }

                if (File.Exists(FileName3))
                {
                    File.Delete(FileName3);
                }

                Zip.UnZipFiles(zipFile, extractFileLocation, false);
                this.Title = zipFile;
                //this.Text = title;
                //cmdDownload.Enabled = true;
                retVal = true;
            }
            else
            {
                this.Title = "File " + zipFile + " tidak ada.";

                //cmdDownload.Enabled = false;
                MessageBox.Show("File: " + zipFile + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void frmHargaDownload11_Load(object sender, EventArgs e)
        {
            string fileNameBMK = "tmpbmk.DBF";
            string fileNameHks = "hkstmp.DBF";
            string fileNameHksAgen = "Hjualtmp.DBF";
            string fileZIPName = "DBFMATCH";
            
       
            fileNameBMK = GlobalVar.DbfDownload + "\\" + fileNameBMK;
            fileNameHks = GlobalVar.DbfDownload + "\\" + fileNameHks;
            fileNameHksAgen = GlobalVar.DbfDownload + "\\" + fileNameHksAgen;

            if (UnzipFile(fileZIPName, fileNameBMK, fileNameHks, fileNameHksAgen))
            {
                if (File.Exists(fileNameBMK))
                {
                    try
                    {
                        tblBMK = Foxpro.ReadFile(fileNameBMK);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblBMK.Columns.Add(newcol);

                        dataGridView1.DataSource = tblBMK;
                        lblDownloadStatus1.Text = "0/" + tblBMK.Rows.Count.ToString("#,##0");
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = tblBMK.Rows.Count;
                        this.Title = fileNameBMK;
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                if (File.Exists(fileNameHks))
                {
                    try
                    {
                        tblHks = Foxpro.ReadFile(fileNameHks);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblHks.Columns.Add(newcol);

                        dataGridView2.DataSource = tblHks;
                        lblDownloadStatus2.Text = "0/" + tblHks.Rows.Count.ToString("#,##0");
                        progressBar2.Minimum = 0;
                        progressBar2.Maximum = tblHks.Rows.Count;
                        this.Title = fileNameHks;
                        this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }

                if (File.Exists(fileNameHksAgen))
                {
                    try
                    {
                        tblHksAgen = Foxpro.ReadFile(fileNameHksAgen);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblHksAgen.Columns.Add(newcol);

                        //dataGridView2.DataSource = tblHksAgen;
                        //lblDownloadStatus2.Text = "0/" + tblHksAgen.Rows.Count.ToString("#,##0");
                        //progressBar2.Minimum = 0;
                        //progressBar2.Maximum = tblHksAgen.Rows.Count;
                        //this.Title = fileNameHks;
                        //this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView2.AutoGenerateColumns = true;
            }
        }

        private void ExtractFile(string fileName)
        {
            
           // ZipFile file = new ZipFile(fileName);
            

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Data, Make Sure you put dbfmatch.zip in valid path !!!");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    //DisplayReport();
                    DownloadBMK();
                    DownloadHks();
                    DownloadHksAgen();
                    DisplayReport();
                    
                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region generate excel
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PartStation";
            ex.Workbook.Properties.Title = "Dnl_Harga "+ GlobalVar.Gudang;
            int k = 0;
            int rowx = 7;
            double col3 = 0, col7 = 0, col12 = 0;

            #region sheet 1


            ex.Workbook.Worksheets.Add("Harga");
            ExcelWorksheet ws2 = ex.Workbook.Worksheets[1];

            ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;
            ws2.Cells[1, 2].Worksheet.Column(2).Width = 65;
            ws2.Cells[1, 3].Worksheet.Column(3).Width = 20;
            ws2.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws2.Cells[1, 5].Worksheet.Column(5).Width = 10;
            for (int y = 6; y <= 8; y++)
            {
                ws2.Cells[1, y].Worksheet.Column(y).Width = 8;
            }
            for (int x = 9; x <= 11; x++)
            {
                ws2.Cells[1, x].Worksheet.Column(x).Width = 10;
            }
            ws2.Cells[1, 12].Worksheet.Column(12).Width = 15;

            ws2.Cells[1, 1, 1, 12].Merge = true;
            ws2.Cells[2, 1, 2, 12].Merge = true;
            //ws2.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws2.Cells[1, 1].Value = "HASIL DOWNLOAD HARGA DARI HO ";
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            ws2.Cells[2, 1].Value = "Gudang : " + GlobalVar.Gudang;
            ws2.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
           

            ////Header
            ws2.Cells[5, 1].Value = "NO."; ws2.Cells[5, 1, 6, 1].Merge = true;
            ws2.Cells[5, 2].Value = "NAMA STOK"; ws2.Cells[5, 2, 6, 2].Merge = true;
            ws2.Cells[5, 3].Value = "ID. BRG"; ws2.Cells[5, 3, 6, 3].Merge = true;
            ws2.Cells[5, 4].Value = "TMT"; ws2.Cells[5, 4, 6, 4].Merge = true;
            ws2.Cells[5, 5].Value = "HET"; ws2.Cells[5, 5, 6, 5].Merge = true;
            ws2.Cells[5, 6].Value = "CASH %"; ws2.Cells[5, 6, 6, 6].Merge = true;
            ws2.Cells[5, 7].Value = "TOP%"; ws2.Cells[5, 7, 6, 7].Merge = true;
            ws2.Cells[5, 8].Value = "USER %"; ws2.Cells[5, 8, 6, 8].Merge = true;
            ws2.Cells[5, 9].Value = "H. CASH "; ws2.Cells[5, 9, 6, 9].Merge = true;
            ws2.Cells[5, 10].Value = "H. TOP"; ws2.Cells[5, 10, 6, 10].Merge = true;
            ws2.Cells[5, 11].Value = "H. USER"; ws2.Cells[5, 11, 6, 11].Merge = true;
            ws2.Cells[5, 12].Value = " TMT_PASIF "; ws2.Cells[5, 12, 6, 12].Merge = true;

            ws2.Cells[5, 1, 6, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws2.Cells[5, 1, 6, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 7;
            col3 = col7 = col12 = 0;

            int i = 0;
            int nomor = 0;
            for (i = 0; i < tblBMK.Rows.Count; i++)
            {
                nomor = nomor + 1;
                ws2.Cells[rowx, 1].Value = nomor;
                ws2.Cells[rowx, 2].Value = tblBMK.Rows[i]["nama_stok"].ToString();
                ws2.Cells[rowx, 3].Value = tblBMK.Rows[i]["Id_stok"].ToString();
                ws2.Cells[rowx, 4].Value = string.Format("{0:dd-MM-yyyy}", tblBMK.Rows[i]["Tmt"]);
                ws2.Cells[rowx, 5].Value = Convert.ToDouble(tblBMK.Rows[i]["H_net"]);
                ws2.Cells[rowx, 5].Style.Numberformat.Format = "#,##";

                ws2.Cells[rowx, 6].Value = Convert.ToDecimal(tblBMK.Rows[i]["Cash"]);
                ws2.Cells[rowx, 6].Style.Numberformat.Format = "#,##0.00";
                
                ws2.Cells[rowx, 7].Value =Convert.ToDecimal(tblBMK.Rows[i]["Top10"]);
                ws2.Cells[rowx, 7].Style.Numberformat.Format = "#,##0.00";

                ws2.Cells[rowx, 8].Value = Convert.ToDecimal(tblBMK.Rows[i]["Enduser"]);
                ws2.Cells[rowx, 8].Style.Numberformat.Format = "#,##0.00";

                ws2.Cells[rowx, 9].Value = Convert.ToDouble(tblBMK.Rows[i]["Hjual_c"]);
                ws2.Cells[rowx, 9].Style.Numberformat.Format = "#,##";

                ws2.Cells[rowx, 10].Value = Convert.ToDouble(tblBMK.Rows[i]["Hjual_t"]);
                ws2.Cells[rowx, 10].Style.Numberformat.Format = "#,##";

                ws2.Cells[rowx, 11].Value = Convert.ToDouble(tblBMK.Rows[i]["Hjual_e"]);
                ws2.Cells[rowx, 11].Style.Numberformat.Format = "#,##";

                ws2.Cells[rowx, 12].Value = string.Format("{0:dd-MM-yyyy}", tblBMK.Rows[i]["Tmt_pasif"]);
                rowx++;
            }

            var border2 = ws2.Cells[5, 1, rowx, 12].Style.Border;
            border2.Bottom.Style =
            border2.Top.Style =
            border2.Left.Style =
            border2.Right.Style = ExcelBorderStyle.Thin;
            ws2.Cells[5, 1, 6, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws2.Cells[5, 1, 6, 12].Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue    );


            #endregion

            #region sheet 2


            ex.Workbook.Worksheets.Add("Harga Khusus Agen");
            ExcelWorksheet ws = ex.Workbook.Worksheets[2];

            ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 65;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
            for (int y = 3; y <= 5; y++)
            {
                ws.Cells[1, y].Worksheet.Column(y).Width = 10;
            }
            for (int x = 6; x <= 7; x++)
            {
                ws.Cells[1, x].Worksheet.Column(x).Width = 15;
            }
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 15;

            ws.Cells[1, 1, 1, 7].Merge = true;
            ws.Cells[2, 1, 2, 7].Merge = true;
            //ws2.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 1].Value = "HASIL DOWNLOAD HARGA KHUSUS AGEN DARI HO ";
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            ws.Cells[2, 1].Value = "Gudang : " + GlobalVar.Gudang;
            ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ////Header
            ws.Cells[5, 1].Value = "NO."; ws.Cells[5, 1, 6, 1].Merge = true;
            //ws.Cells[5, 2].Value = "NAMA STOK"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 2].Value = "ID. BRG"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "HK_CASH"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "HK_TOP10"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "HK_USER "; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "TMT 1"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "TMT 2"; ws.Cells[5, 7, 6, 7].Merge = true;
            

            ws.Cells[5, 1, 6, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 1, 6, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 7;
            col3 = col7 = col12 = 0;

           // int n = 0;
            int nomor1 = 0;
            for (i = 0; i < tblHksAgen.Rows.Count; i++)
            {
                nomor1 = nomor1 + 1;
                ws.Cells[rowx, 1].Value = nomor1;
                ws.Cells[rowx, 2].Value = tblHksAgen.Rows[i]["Id_brg"].ToString();
                ws.Cells[rowx, 3].Value = Convert.ToDouble(tblHksAgen.Rows[i]["H_cash"]);
                ws.Cells[rowx, 3].Style.Numberformat.Format = "#,##";

                ws.Cells[rowx, 4].Value = Convert.ToDouble(tblHksAgen.Rows[i]["H_top10"]);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##";

                ws.Cells[rowx, 5].Value = Convert.ToDouble(tblHksAgen.Rows[i]["H_user"]);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##";

                ws.Cells[rowx, 6].Value = string.Format("{0:dd-MM-yyyy}", tblHksAgen.Rows[i]["Tmt1"]);
                ws.Cells[rowx, 7].Value = string.Format("{0:dd-MM-yyyy}", tblHksAgen.Rows[i]["Tmt2"]);

                rowx++;
            }

            var border = ws.Cells[5, 1, rowx, 7].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[5, 1, 6, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 1, 6, 7].Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue);


            #endregion

            #region sheet 3


            ex.Workbook.Worksheets.Add("Harga Khusus Non Agen");
            ExcelWorksheet ws1 = ex.Workbook.Worksheets[3];

            ws1.Cells[1, 1].Worksheet.Column(1).Width = 5;
            //ws.Cells[1, 2].Worksheet.Column(2).Width = 65;
            ws1.Cells[1, 2].Worksheet.Column(2).Width = 20;
            //ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
            //ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
            for (int y = 3; y <= 5; y++)
            {
                ws1.Cells[1, y].Worksheet.Column(y).Width = 10;
            }
            for (int x = 6; x <= 7; x++)
            {
                ws1.Cells[1, x].Worksheet.Column(x).Width = 15;
            }
            //ws.Cells[1, 12].Worksheet.Column(12).Width = 15;

            ws1.Cells[1, 1, 1, 7].Merge = true;
            ws1.Cells[2, 1, 2, 7].Merge = true;
            //ws2.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws1.Cells[1, 1].Value = "HASIL DOWNLOAD HARGA KHUSUS NON AGEN DARI HO ";
            ws1.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            ws1.Cells[2, 1].Value = "Gudang : " + GlobalVar.Gudang;
            ws1.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            ////Header
            ws1.Cells[5, 1].Value = "NO."; ws1.Cells[5, 1, 6, 1].Merge = true;
            //ws.Cells[5, 2].Value = "NAMA STOK"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws1.Cells[5, 2].Value = "ID. BRG"; ws1.Cells[5, 2, 6, 2].Merge = true;
            ws1.Cells[5, 3].Value = "HK_CASH"; ws1.Cells[5, 3, 6, 3].Merge = true;
            ws1.Cells[5, 4].Value = "HK_TOP10"; ws1.Cells[5, 4, 6, 4].Merge = true;
            ws1.Cells[5, 5].Value = "HK_USER"; ws1.Cells[5, 5, 6, 5].Merge = true;
            ws1.Cells[5, 6].Value = "TMT 1"; ws1.Cells[5, 6, 6, 6].Merge = true;
            ws1.Cells[5, 7].Value = "TMT 2"; ws1.Cells[5, 7, 6, 7].Merge = true;


            ws1.Cells[5, 1, 6, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws1.Cells[5, 1, 6, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            rowx = 7;
            col3 = col7 = col12 = 0;

            // int n = 0;
            int nomor2 = 0;
            for (i = 0; i < tblHks.Rows.Count; i++)
            {
                nomor2 = nomor2 + 1;
                ws1.Cells[rowx, 1].Value = nomor2;
                ws1.Cells[rowx, 2].Value = tblHks.Rows[i]["Id_brg"].ToString();
                ws1.Cells[rowx, 3].Value = Convert.ToDouble(tblHks.Rows[i]["H_cash"]);
                ws1.Cells[rowx, 3].Style.Numberformat.Format = "#,##";

                ws1.Cells[rowx, 4].Value = Convert.ToDouble(tblHks.Rows[i]["H_top10"]);
                ws1.Cells[rowx, 4].Style.Numberformat.Format = "#,##";

                ws1.Cells[rowx, 5].Value = Convert.ToDouble(tblHks.Rows[i]["H_user"]);
                ws1.Cells[rowx, 5].Style.Numberformat.Format = "#,##";

                ws1.Cells[rowx, 6].Value = string.Format("{0:dd-MM-yyyy}", tblHks.Rows[i]["Tmt1"]);
                ws1.Cells[rowx, 7].Value = string.Format("{0:dd-MM-yyyy}", tblHks.Rows[i]["Tmt2"]);

                rowx++;
            }

            var border1 = ws1.Cells[5, 1, rowx, 7].Style.Border;
            border1.Bottom.Style =
            border1.Top.Style =
            border1.Left.Style =
            border1.Right.Style = ExcelBorderStyle.Thin;
            ws1.Cells[5, 1, 6, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws1.Cells[5, 1, 6, 7].Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue);


            #endregion

            return ex;
        }


        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());
                // exs.Add(Process2());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\Download";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Dnl_Harga- " + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

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
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion
    }
}
