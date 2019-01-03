using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;

using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Trading.Master
{
    public partial class frmMasterStokDownload : ISA.Trading.BaseForm
    {
#region "Function & Variable"
        DataTable tblStok;
        DataTable tblStokBarcode;
        DataTable tblStokPart;
        Guid _RowID;


        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload,false);  
        }

        private void DeleteFile(string FileName)
        {

        }
        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            int result2 = 0;
            int result3 = 0;
            using (Database db = new Database())
            {
                // Master Stok
                db.Commands.Add(db.CreateCommand("usp_MasterStok_Download"));
                counter = 0;
                foreach (DataRow dr in tblStok.Rows)
                {
                    //add parameters
                    //counter = 0;
                    _RowID = Guid.NewGuid();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["Idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, Tools.isNull(dr["Idmain"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Tools.isNull(dr["Nm_plist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kendaraan", SqlDbType.VarChar, Tools.isNull(dr["Kendaraan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PartNo", SqlDbType.VarChar, Tools.isNull(dr["partno"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Merek", SqlDbType.VarChar, Tools.isNull(dr["Merek"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SatSolo", SqlDbType.VarChar, Tools.isNull(dr["Satsolo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SatJual", SqlDbType.VarChar, Tools.isNull(dr["Satjual"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    //db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();


                    if (result == 1 || result == 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblStok.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                }


                    //STOKBARCODE

                if (tblStokBarcode != null)
                {
                    db.Commands.Add(db.CreateCommand("usp_StokBarcode_Download"));
                    counter = 0;
                    foreach (DataRow dr1 in tblStokBarcode.Rows)
                    {
                        //counter = 0;
                        //add parameters
                        db.Commands[1].Parameters.Clear();
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[1].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, Tools.isNull(dr1["Id_brgdg"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, Tools.isNull(dr1["Barcode"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@nm_brgdg", SqlDbType.VarChar, Tools.isNull(dr1["Nm_brgdg"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, Tools.isNull(dr1["Kendaraan"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@partno", SqlDbType.VarChar, Tools.isNull(dr1["Partno"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@idlabel", SqlDbType.VarChar, Tools.isNull(dr1["Idlabel"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@groupbc", SqlDbType.VarChar, Tools.isNull(dr1["Groupbc"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@isi", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr1["Isi"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //db.BeginTransaction();

                        result2 = db.Commands[1].ExecuteNonQuery();

                        //grid and form status
                        if (result2 == 0 || result2 == 1)
                        {
                            dr1["cUploaded"] = true;
                            counter++;
                            progressBar2.Increment(1);
                            label7.Text = counter.ToString("#,##0") + "/" + tblStokBarcode.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                }

                if (tblStokPart != null)
                {
                    //STOKPART
                    db.Commands.Add(db.CreateCommand("usp_StokPart_Download"));
                    counter = 0;
                    foreach (DataRow dr2 in tblStokPart.Rows)
                    {
                        //counter = 0;
                        //add parameters
                        db.Commands[2].Parameters.Clear();
                        db.Commands[2].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[2].Parameters.Add(new Parameter("@RowIDStok", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[2].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr2["Id_brg"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr2["Nama_stok"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr2["Idrec"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@sat_jual", SqlDbType.VarChar, Tools.isNull(dr2["Sat_jual"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr2["Merek"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, Tools.isNull(dr2["Jenis"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Tools.isNull(dr2["Kelompok"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@supplier", SqlDbType.VarChar, Tools.isNull(dr2["Supplier"], "").ToString().Trim()));
                        //Convert.ToInt32(Tools.isNull(dr2["Id_tr"], "0").ToString().Trim())))Int32.Parse
                        db.Commands[2].Parameters.Add(new Parameter("@id_tr", SqlDbType.VarChar, Tools.isNull(dr2["Id_tr"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@r1", SqlDbType.NChar, Tools.isNull(dr2["R1"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@r2", SqlDbType.NChar, Tools.isNull(dr2["R2"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@r3", SqlDbType.NChar, Tools.isNull(dr2["R3"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@r4", SqlDbType.NChar, Tools.isNull(dr2["R4"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, Tools.isNull(dr2["Cash"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, Tools.isNull(dr2["Top10"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, Tools.isNull(dr2["Enduser"], "").ToString().Trim()));
                        db.Commands[2].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //db.BeginTransaction();

                        result3 = db.Commands[2].ExecuteNonQuery();

                        //grid and form status
                        if (result3 == 0 || result3 == 1)
                        {
                            dr2["cUploaded"] = true;
                            counter++;
                            progressBar3.Increment(1);
                            label9.Text = counter.ToString("#,##0") + "/" + tblStokPart.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }

                    }
                }
                 //   }
                    
               // }
                //db.CommitTransaction();
            }
        }
                
#endregion
     
        public frmMasterStokDownload()
        {
            InitializeComponent();
        }

        private void frmMasterStokDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\dbfmatch.zip tidak ada");
                return;
            }
           
            string fileNameS = "Stktmp.dbf";
            string fileNameB = "Bctmp.dbf";
            string fileNameP = "Sptmp.dbf"; 

            fileNameS = GlobalVar.DbfDownload + "\\" + fileNameS;
            fileNameB = GlobalVar.DbfDownload + "\\" + fileNameB;
            fileNameP = GlobalVar.DbfDownload + "\\" + fileNameP;

            if (File.Exists(fileNameS))
            {
                try
                {
                    tblStok = Foxpro.ReadFile(fileNameS);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStok.Columns.Add(newcol);

                    dataGridView1.DataSource = tblStok;
                    lblDownloadStatus1.Text = "0/" + tblStok.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblStok.Rows.Count;
                    this.Title = fileNameS;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            { 
                MessageBox.Show("File " + fileNameS + " tidak ada");
                return;
            }

            if (File.Exists(fileNameB))
            {
                try
                {
                    tblStokBarcode = Foxpro.ReadFile(fileNameB);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStokBarcode.Columns.Add(newcol);

                    dataGridView4.DataSource = tblStokBarcode;
                    label7.Text = "0/" + tblStokBarcode.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = tblStokBarcode.Rows.Count;
                    this.Title = fileNameB;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameB + " tidak ada");
                return;
            }

            if (File.Exists(fileNameP))
            {
                try
                {
                    tblStokPart = Foxpro.ReadFile(fileNameP);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStokPart.Columns.Add(newcol);

                    dataGridView5.DataSource = tblStokPart;
                    label9.Text = "0/" + tblStokPart.Rows.Count.ToString("#,##0");
                    progressBar3.Minimum = 0;
                    progressBar3.Maximum = tblStokPart.Rows.Count;
                    this.Title = fileNameP;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameP + " tidak ada");
                return;
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
           if (dataGridView1.RowCount==0)
           {
               MessageBox.Show("Tidak ada data yang didownload");
               return;
           }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Master Stok ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    Download();
                    DisplayReportMasterStok();

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

        private ExcelPackage ProcessMaterStok()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "MasterStok";

            ex.Workbook.Worksheets.Add("Master STok");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 7;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 3;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 70;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 70;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 2, 1, MaxCol].Merge = true;
            ws.Cells[1, 2].Value = "Laporan     : LAPORAN DOWNLOAD MASTER STOK";
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 2, 2, MaxCol].Merge = true;
            ws.Cells[2, 2].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", DateTime.Today);
            ws.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 2].Value = "KODE BARU"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA MASTER BARU"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "SAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "KODE LAMA"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "NAMA MASTER LAMA"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "KETERANGAN"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 2, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 2, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;

            foreach (DataRow dr1 in tblStok.Rows)
            {
                ws.Cells[rowx, 2].Value = dr1["Idmain"];
                ws.Cells[rowx, 3].Value = dr1["Nm_plist"];

                ws.Cells[rowx, 4].Value = dr1["Satsolo"];

                ws.Cells[rowx, 5].Value = dr1["Oldcode"];

                ws.Cells[rowx, 6].Value = dr1["Oldname"];

                ws.Cells[rowx, 7].Value = dr1["Keterangan"];



                rowx++;
            }


            ws.Cells[5, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 2, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            return ex;
        }

        private void DisplayReportMasterStok()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ProcessMaterStok());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Download_SasStok " + GlobalVar.Gudang;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
