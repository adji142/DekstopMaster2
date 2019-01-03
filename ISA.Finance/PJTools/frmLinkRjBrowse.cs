using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Finance;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.PJTools
{
    public partial class frmLinkRjBrowse : ISA.Finance.BaseForm
    {
        string periode;
        DataTable dtRj = new DataTable();
        
        DateTime fromDate;
        DateTime toDate;
        DataTable dtResultCross = new DataTable();
        DataTable dtResultCurr = new DataTable();
        DataTable PerkGiroTolak;
        DataTable PerkRetBlmIND;

        DataRow[] dtCross;
        DataRow[] dtCurr;

        Guid headerCross = Guid.Empty;
        Guid headerCurr = Guid.Empty;
        string headerRecCross;
        string headerRecCurr;
        string NamaGgd = string.Empty;

        DataTemplates.dsPenjualan.DataDataTable dtRekapRj = new dsPenjualan.DataDataTable();

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();
        int jmlNota = 0;
        double nSelisih = 0;

        DataTable dtc = new DataTable();
        DataSet dsData = new DataSet();

        Guid HeadID;

        public frmLinkRjBrowse()
        {
            InitializeComponent();
        }

        private void SetControl()
        {
            DateTimeFormatInfo formatInfo = new DateTimeFormatInfo();
            foreach (string month in formatInfo.MonthNames)
            {
                cboMonth.Items.Add(month);
            }
            if (cboMonth.Items.Count > 0)
            {
                cboMonth.SelectedIndex = DateTime.Now.AddMonths(-1).Month - 1;
            }

            txtYear.Value = DateTime.Now.AddMonths(-1).Year;
            lookupGudang1.GudangID = GlobalVar.Gudang;
            txtInitPrsh.Text = GlobalVar.PerusahaanID;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lookupGudang1.NamaGudang = Tools.isNull(dt.Rows[0]["NamaGudang"].ToString(), "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmLinkRjBrowse_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ResetValues();

                periode = txtYear.Value.ToString().PadLeft(4, '0') + (cboMonth.SelectedIndex + 1).ToString().PadLeft(2, '0');
                fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);

                //if (ISA.Finance.Class.PeriodeClosing.IsHPPClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsPJTClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))

                if (ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))
                {
                    MessageBox.Show(string.Format(Messages.Error.AlreadyClosingPJT, periode));
                    return;
                }
                
                Rj2gl();

                //if (!DataHasProblem())
                //{
                //    //DISPLAY RESULT
                //    GetRJToolsData();
                //    //PrepareRJDataSplit();
                //    //ProcessRJData(dtResultCross, "CROSS");
                //    //ProcessRJData(dtResultCurr, "CURR");
                //    if (dtJurnalH.Rows.Count == 0)
                //    {
                //        MessageBox.Show("Tidak Ada Data");
                //        return;
                //    }
                //    dtJurnalD.DefaultView.Sort = "HRecordID, DK, NoPerkiraan";                    
                //    DataTable dtRekapJurnal = dtJurnalD.Copy();
                //    frmLinkRjExecute ifrmChild = new frmLinkRjExecute(toDate, lookupGudang1.GudangID, dtJurnalH, dtJurnalD);
                //    //ifrmChild.WindowState = FormWindowState.Maximized; 
                //    ifrmChild.Show();
                //    //DisplayReportRekap(dtRekapJurnal, dtRekapRj);
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


        private void Rj2gl()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetReturJual"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                db.Commands[0].Parameters.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dsData = db.Commands[0].ExecuteDataSet();
            }
            if (dsData.Tables.Count > 0)
            {
                DisplayReport();

                if (nSelisih == 0)
                {
                    bool link = true;
                    if (dsData.Tables[6].Rows.Count > 0 || dsData.Tables[8].Rows.Count > 0 || dsData.Tables[9].Rows.Count > 0)
                        link = false;

                    if (link)
                    {
                        DialogResult jawab = MessageBox.Show("Link ke GL ?", "Konfirmasi", MessageBoxButtons.YesNo);
                        if (jawab == DialogResult.Yes)
                        {
                            Guid RowID_ = Guid.NewGuid();
                            int x = 0;
                            string cHeaderID = "",cNoreff = "",cUraian = "";

                            cHeaderID = GlobalVar.PerusahaanID + string.Format("{0:yyyyMMdd}", toDate) + "12:" + GlobalVar.Gudang + ":RJ3";
                            cNoreff = "ADJRJ" + string.Format("{0:yyyyMMdd}", toDate);
                            cUraian = "RETUR JUAL " + GlobalVar.Gudang + " " + string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) + "-" +
                                      string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4);

                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_RJL_Link_Transact"));

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, cHeaderID));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, cNoreff));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "RJ3"));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }

                            if (dsData.Tables[1].Rows.Count > 0 || dsData.Tables[2].Rows.Count > 0 || dsData.Tables[4].Rows.Count > 0 ||
                                dsData.Tables[3].Rows.Count > 0 || dsData.Tables[5].Rows.Count > 0 || dsData.Tables[7].Rows.Count > 0)
                            {
                                dtc = new DataTable();
                                using (Database dbc = new Database(GlobalVar.DBName))
                                {
                                    dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                    dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, cHeaderID));
                                    dtc = dbc.Commands[0].ExecuteDataTable();
                                }

                                if (dtc.Rows.Count > 0)
                                {
                                    HeadID = (Guid)(dtc.Rows[0]["RowID"]);
                                }
                                else
                                {
                                    HeadID = RowID_;
                                }

                                // Detail : Retur Penjualan Per kelompok barang
                                if (dsData.Tables[1].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[1].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "D" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }

                                // Retur belum Identifikasi : Retur bulan lalu
                                if (dsData.Tables[2].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[2].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "D" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }

                                // Retur jual per wilayah
                                if (dsData.Tables[4].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[4].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "K" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }

                                // Retur diganti Tunai
                                if (dsData.Tables[3].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[3].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "K" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }

                                // Retur belum Identifikasi
                                if (dsData.Tables[5].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[5].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "K" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }

                                // Retur sebagai pengganti Giro Tolak
                                if (dsData.Tables[7].Rows.Count > 0)
                                {
                                    foreach (DataRow drd in dsData.Tables[7].Rows)
                                    {
                                        Guid _RowID = Guid.NewGuid();
                                        x++;
                                        string RecodID_ = cHeaderID.Substring(0, 20) + "K" + x.ToString().PadLeft(2, '0');
                                        using (Database dbd = new Database(GlobalVar.DBName))
                                        {
                                            dbd.Commands.Add(dbd.CreateCommand("usp_PJTools__Link_Journal_Detail"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, cHeaderID));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, cUraian));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                            dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, toDate));

                                            dbd.Commands[0].ExecuteNonQuery();
                                            dbd.CommitTransaction();
                                        }
                                    }
                                }
                            }

                            // Update ClosingStok \\
                            try
                            {
                                DataTable dt = new DataTable();
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_CloseUpdate"));
                                    db.Commands[0].Parameters.Add(new Parameter("@kodetr", SqlDbType.VarChar, "PJT"));
                                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, fromDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, toDate));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }

                            MessageBox.Show("Proses link selesai..");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Perbaiki selisih sebesar Rp." + nSelisih.ToString());
                }
            }
            else
            {
                MessageBox.Show("Data tidak ada..!");
            }
        }

        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(lapRJ2GL());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "RJ2GL" + GlobalVar.Gudang;
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


        private ExcelPackage lapRJ2GL()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "PJTOOLS";
            ex.Workbook.Properties.SetCustomPropertyValue("PJTOOLS", "1147");

            ex.Workbook.Worksheets.Add("Journal");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 40;      //B uraian
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //C no perkiraan
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;      //D debet
            ws.Cells[1, 5].Worksheet.Column(5).Width = 15;      //E kredit


            #region sheet 1 : Retur per kelompok barang
            ws.Cells[2, 2].Value = " JURNAL - RETUR ";
            ws.Cells[2, 2].Style.Font.Bold = true;

            ws.Cells[3, 2].Value = "Periode  : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
            ws.Cells[3, 2].Style.Font.Bold = true;

            ws.Cells[4, 2].Value = " PERKIRAAN ";
            ws.Cells[4, 3].Value = " KODE ";
            ws.Cells[4, 4].Value = " DEBET ";
            ws.Cells[4, 5].Value = " KREDIT ";

            int MaxCol = 5;
            int rowz = 4;
            int rowx = rowz + 1;
            double nDb = 0, nKr = 0;
            nSelisih = 0;

            ws.Cells[4, 2, 4, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[4, 2, 4, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[4, 2, 4, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 2, 4, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            foreach (DataRow dr1 in dsData.Tables[1].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr1["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr1["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr1["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr1["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr1["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr1["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Retur belum identifikasi : Retur bulan lalu
            foreach (DataRow dr2 in dsData.Tables[2].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr2["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr2["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr2["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr2["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr2["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr2["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Retur belum identifikasi : Retur penjualan piutang wilayah
            foreach (DataRow dr4 in dsData.Tables[4].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr4["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr4["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr4["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr4["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr4["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr4["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Retur diganti tunai
            foreach (DataRow dr3 in dsData.Tables[3].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr3["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr3["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr3["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr3["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr3["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr3["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Retur belum identifikasi : Retur belum identifikasi
            foreach (DataRow dr5 in dsData.Tables[5].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr5["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr5["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr5["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr5["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr5["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr5["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Retur sebagai pengganti giro tolak
            foreach (DataRow dr7 in dsData.Tables[7].Rows)
            {
                ws.Cells[rowx, 2].Value = Tools.isNull(dr7["NaPerkiraan"], "");
                ws.Cells[rowx, 3].Value = Tools.isNull(dr7["NoPerkiraan"], "");
                ws.Cells[rowx, 4].Value = Tools.isNull(dr7["debet"], 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Value = Tools.isNull(dr7["kredit"], 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                nDb = nDb + Convert.ToDouble(Tools.isNull(dr7["debet"], 0));
                nKr = nKr + Convert.ToDouble(Tools.isNull(dr7["kredit"], 0));
                rowx++;
            }
            #endregion

            #region sheet 1 : Akumulasi Deebet dan Kredit

            var borderx = ws.Cells[rowz + 1, 2, rowx-1, MaxCol].Style.Border;
            borderx.Bottom.Style =
            borderx.Top.Style = ExcelBorderStyle.None;
            borderx.Left.Style =
            borderx.Right.Style = ExcelBorderStyle.Thin;

            borderx = ws.Cells[rowz, 2, rowz, MaxCol].Style.Border;
            borderx.Bottom.Style =
            borderx.Top.Style =
            borderx.Left.Style =
            borderx.Right.Style = ExcelBorderStyle.Thin;

            borderx = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.None;
            borderx.Top.Style = ExcelBorderStyle.Thin;
            borderx.Left.Style =
            borderx.Right.Style = ExcelBorderStyle.None;

            borderx = ws.Cells[rowx + 1, 2, rowx + 1, MaxCol].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.Thin;
            borderx.Top.Style = ExcelBorderStyle.None;
            borderx.Left.Style =
            borderx.Right.Style = ExcelBorderStyle.None;

            borderx = ws.Cells[rowx, 2, rowx, 2].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.None;
            borderx.Top.Style = ExcelBorderStyle.Thin;
            borderx.Left.Style = ExcelBorderStyle.Thin;
            borderx.Right.Style = ExcelBorderStyle.None;

            borderx = ws.Cells[rowx+1, 2, rowx+1, 2].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.Thin;
            borderx.Top.Style = ExcelBorderStyle.None;
            borderx.Left.Style = ExcelBorderStyle.Thin;
            borderx.Right.Style = ExcelBorderStyle.None;

            borderx = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.None;
            borderx.Top.Style = 
            borderx.Left.Style = 
            borderx.Right.Style = ExcelBorderStyle.Thin;

            borderx = ws.Cells[rowx+1, 4, rowx+1, MaxCol].Style.Border;
            borderx.Bottom.Style = ExcelBorderStyle.Thin;
            borderx.Top.Style = ExcelBorderStyle.None; 
            borderx.Left.Style =
            borderx.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[rowx, 2].Value = "Jumlah";
            ws.Cells[rowx, 2].Style.Font.Bold = true;
            ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
            ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 4].Style.Font.Bold = true;
            ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
            ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 5].Style.Font.Bold = true;
            rowx++;

            nSelisih = nDb - nKr;
            ws.Cells[rowx, 2].Value = "Selisih";
            ws.Cells[rowx, 2].Style.Font.Bold = true;
            ws.Cells[rowx, 5].Value = nSelisih;
            ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
            ws.Cells[rowx, 5].Style.Font.Bold = true;

            #endregion


            #region sheet 1 : Retur tidak ketemu di Api
            if (dsData.Tables[8].Rows.Count > 0)
            {
                rowx++;
                rowx++;
                ws.Cells[rowx, 2].Value = "*** RETUR TIDAK ADA DI DATA PIUTANG ***";
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                rowx++;
                foreach (DataRow dr8 in dsData.Tables[8].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr8["NamaToko"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr8["WilID"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr8["NoNotaRetur"], "");
                    ws.Cells[rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr8["TglNotaRetur"], ""));
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr8["kredit"], 0);
                    ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    rowx++;
                }
            }
            #endregion


            #region sheet 1 : Retur tidak ketemu di Api
            if (dsData.Tables[9].Rows.Count > 0)
            {
                rowx++;
                rowx++;
                ws.Cells[rowx, 2].Value = "*** NILAI RETUR RJ2 BEDA DENGAN RJ3 / API ***";
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                rowx++;
                foreach (DataRow dr9 in dsData.Tables[9].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr9["NamaToko"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr9["WilID"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr9["NoNotaRetur"], "");
                    ws.Cells[rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr9["TglNotaRetur"], ""));
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr9["RpRetur"], 0);
                    ws.Cells[rowx, 6].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 7].Value = Tools.isNull(dr9["RpPiutang"], 0);
                    ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    rowx++;
                }
            }
            #endregion


            #region sheet 1 : Missing Detail - Sasstok
            if (dsData.Tables[6].Rows.Count > 0)
            {
                rowx++;
                rowx++;
                ws.Cells[rowx, 2].Value = "*** MISSING DETAIL (SASSTOK) ***";
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                rowx++;
                foreach (DataRow dr6 in dsData.Tables[6].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr6["NamaStok"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr6["BarangID"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr6["RecordID"], "");
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr6["RpRetur"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    rowx++;
                }
            }
            #endregion


            #region sheet 2 : DetailNota
            if (dsData.Tables[0].Rows.Count > 0)
            {
                ex.Workbook.Worksheets.Add("DetailNota");
                ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;      //B TGL RET
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 10;      //C NO RET
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 12;      //D KD SALES
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 8;       //E IDWIL
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 4;       //F KLP
                ws2.Cells[1, 7].Worksheet.Column(7).Width = 73;      //G NAMA STOK
                ws2.Cells[1, 8].Worksheet.Column(8).Width = 13;      //H NOMINAL
                ws2.Cells[1, 9].Worksheet.Column(9).Width = 15;      //I TGL LINK

                ws2.Cells[2, 2].Style.Font.Bold.ToString();
                ws2.Cells[2, 2].Value = " DETAIL NOTA RETUR ";
                ws2.Cells[2, 2].Style.Font.Bold = true;
                ws2.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws2.Cells[3, 2].Style.Font.Bold = true;

                double nNominal = 0;
                int MaxCol2 = 9;
                int rowy = 4;
                rowx = rowy;

                ws2.Cells[rowx, 2].Value = " TGL RETUR ";
                ws2.Cells[rowx, 3].Value = " NO RETUR ";
                ws2.Cells[rowx, 4].Value = " KD SALES ";
                ws2.Cells[rowx, 5].Value = " IDWIL ";
                ws2.Cells[rowx, 6].Value = " KLP ";
                ws2.Cells[rowx, 7].Value = " NAMA STOK ";
                ws2.Cells[rowx, 8].Value = " NOMINAL ";
                ws2.Cells[rowx, 9].Value = " TGL LINK ";

                ws2.Cells[rowx, 2, rowx, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[rowx, 2, rowx, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws2.Cells[rowx, 2, rowx, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[rowx, 2, rowx, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr0 in dsData.Tables[0].Rows)
                {
                    ws2.Cells[rowx, 2].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglNotaRetur"], ""));
                    ws2.Cells[rowx, 3].Value = Tools.isNull(dr0["NoNotaRetur"], "");
                    ws2.Cells[rowx, 4].Value = Tools.isNull(dr0["KodeSales"], "");
                    ws2.Cells[rowx, 5].Value = Tools.isNull(dr0["WilID"], "");
                    ws2.Cells[rowx, 6].Value = Tools.isNull(dr0["KelompokBrgID"], "");
                    ws2.Cells[rowx, 7].Value = Tools.isNull(dr0["NamaStok"], "");
                    ws2.Cells[rowx, 8].Value = Tools.isNull(dr0["Total"], 0);
                    ws2.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    if (dr0["TglLink"].ToString().Substring(0, 8) != DateTime.Parse("01/01/1900").ToString().Substring(0, 8))
                        ws2.Cells[rowx, 9].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglLink"], ""));
                    else
                        ws2.Cells[rowx, 9].Value = string.Format("{0:dd-MMM-yyyy}", "");

                    nNominal = nNominal + Convert.ToDouble(dr0["Total"]);
                    rowx++;
                }

                ws2.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws2.Cells[rowx, 2].Style.Font.Bold = true;
                ws2.Cells[rowx, 8].Value = Tools.isNull(nNominal, 0);
                ws2.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx, 8].Style.Font.Bold = true;
                ws2.Cells[rowx, 2, rowx, 7].Merge = true;
                ws2.Cells[rowx, 2, rowx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border2 = ws2.Cells[rowy + 1, 2, rowx, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style = ExcelBorderStyle.None;
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                border2 = ws2.Cells[rowy, 2, rowy, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                border2 = ws2.Cells[rowx, 2, rowx, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style = ExcelBorderStyle.Thin;
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.None;

                border2 = ws2.Cells[rowx, 2, rowx, 2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style = ExcelBorderStyle.Thin;
                border2.Right.Style = ExcelBorderStyle.None;

                border2 = ws2.Cells[rowx, 8, rowx, MaxCol2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion
            return ex;
        }



        private DataRow InsertJournalHeader(Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag, double debet, double kredit)
        {
            dsJurnal.JournalRow hdrNew = (dsJurnal.JournalRow)dtJurnalH.NewRow();
            hdrNew.RowID = rowID;
            hdrNew.RecordID = recordID;
            hdrNew.Tanggal = tanggal;
            hdrNew.NoReff = noReff;
            hdrNew.Uraian = uraian;
            hdrNew.Src = src;
            hdrNew.KodeGudang = kodeGudang;
            hdrNew.SyncFlag = syncFlag;
            hdrNew.Debet = debet;
            hdrNew.Kredit = kredit;
            dtJurnalH.Rows.Add(hdrNew);
            return (DataRow)hdrNew;
        }

        private DataRow InsertJournalDetail(Guid rowID, Guid headerID, string recordID, string hRecordID, string noPerkiraan, string uraian, double debet, double kredit, string DK)
        {
            dsJurnal.JournalDetailRow dtlNew = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
            dtlNew.RowID = rowID;
            dtlNew.HeaderID = headerID;
            dtlNew.RecordID = recordID;
            dtlNew.HRecordID = hRecordID;
            dtlNew.NoPerkiraan = noPerkiraan;
            dtlNew.Uraian = uraian;
            dtlNew.Debet = debet;
            dtlNew.Kredit = kredit;
            dtlNew.DK = DK;
            dtJurnalD.Rows.Add(dtlNew);
            return (DataRow)dtlNew;
        }


        private bool DataHasProblem()
        {
            bool valid = false;


            DataTable dtProblem;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetReturBermasalah"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dtProblem = db.Commands[0].ExecuteDataTable();

                //Get Barang Unregistered (done)
                //Nota tanpa ID WIL (done)
                //Nota yang Nol (done)
                //Nota yang tidak punya toko (done)
                //Nota yang nilainya beda dengan piutang (done)
                //Nota missing detail (done)
            }
            if (dtProblem.Rows.Count > 0)
            {
                valid = true;
                //  MessageBox.Show(Messages.Error.PenjualanStillProblem);
                DisplayReportBermasalah(dtProblem);
            }
            return valid;
        }


        private void GetRJToolsData()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetReturPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                //db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dtRj = db.Commands[0].ExecuteDataTable();
                dtRj.DefaultView.Sort = "Kode,NoNotaRetur";
            }
        }

        private void PrepareRJDataSplit()
        {
            PerkGiroTolak = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK");
            PerkRetBlmIND = Perkiraan.GetPerkiraanKoneksiDetail("RET_BLMIND");

            jmlNota = 0;
            if (dtRj.Rows.Count > 0)
            {
                DataRow[] dtCross = dtRj.Select("Kode='CROSS'");
                DataRow[] dtCurr = dtRj.Select("Kode='CURR'");
                
                if (dtCross != null)
                {
                    if (dtCross.Length > 0)
                    {
                        headerCross = Guid.NewGuid();
                        headerRecCross  = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial) + "1";
                        dtResultCross = ConstructDataSplit(dtCross, headerCross, headerRecCross);                        
                    }
                }

                if (dtCurr != null)
                {
                    if (dtCurr.Length > 0)
                    {
                        headerCurr = Guid.NewGuid();
                        headerRecCurr = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial) + "2";
                        dtResultCurr = ConstructDataSplit(dtCurr, headerCurr, headerRecCurr);
                    }
                }                                
            }
        }

        private DataTable ConstructDataSplit(DataRow[] dtSource, Guid headerID, string headerRecID)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("HeaderID", typeof(System.Guid));
            dtResult.Columns.Add("HRecordID", typeof(System.String));
            dtResult.Columns.Add("Kode", typeof(System.String));
            dtResult.Columns.Add("Tipe", typeof(System.String));
            dtResult.Columns.Add("Debet", typeof(System.Double));
            dtResult.Columns.Add("Kredit", typeof(System.Double));
            dtResult.Columns.Add("DK", typeof(System.String));
            dtResult.Columns.Add("NoPerkiraan", typeof(System.String));
            dtResult.Columns.Add("NamaPerkiraan", typeof(System.String));
            DataColumn[] pkResult = new DataColumn[1];
            pkResult[0] = dtResult.Columns["Kode"];
            dtResult.PrimaryKey = pkResult;

            string prevNota = "";
            string curNota = "";

            foreach (DataRow dr in dtSource)
            {
                curNota = dr["NoNotaRetur"].ToString();
                if (prevNota != curNota)
                {                   
                    jmlNota++;
                    DataRow drRekap = dtRekapRj.NewRow();
                    drRekap["NoNotaRetur"] = dr["NoNotaRetur"];
                    drRekap["Kode"] = dr["Kode"];
                    drRekap["Total"] = dtRj.Compute("SUM(Total)","NoNotaRetur='" + dr["NoNotaRetur"].ToString() + "'") ;
                    dtRekapRj.Rows.Add(drRekap);
                }
                prevNota = curNota;

                if (dr["Kode"].ToString() == "CURR")
                {
                    DataRow drBrgFind = dtResult.Rows.Find(dr["KelompokBrgID"]);
                    DataRow drBrgCur = drBrgFind;

                    //DEBET TO Kelompok Barang

                    bool isBrgRegistered = false;
                    if (drBrgFind != null)
                    {
                        if (drBrgFind["Tipe"].ToString() == "KelompokBrgID")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = dr["KelompokBrgID"].ToString();
                        drNew["Tipe"] = "KelompokBrgID";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "D";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = dtKlpBarang.Rows[0]["Noprj"].ToString();
                        drNew["NamaPerkiraan"] = dtKlpBarang.Rows[0]["NamaPerkiraan"].ToString();
                        dtResult.Rows.Add(drNew);
                        drBrgCur = drNew;
                    }
                    drBrgCur["Debet"] = double.Parse(drBrgCur["Debet"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                }
                else if (dr["Kode"].ToString() == "CROSS")
                {
                    //Add to RET_BLM_IND
                    DataRow drRetBlmIndFind = dtResult.Rows.Find("RET_BLMIND");
                    DataRow drRetBlmIndCur = drRetBlmIndFind;


                    bool isBrgRegistered = false;
                    if (drRetBlmIndFind != null)
                    {
                        if (drRetBlmIndFind["Tipe"].ToString() == "RET_BLMIND")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = "RET_BLMIND";
                        drNew["Tipe"] = "RET_BLMIND";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "K";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = PerkRetBlmIND.Rows[0]["NoPerkiraan"].ToString();
                        drNew["NamaPerkiraan"] = PerkRetBlmIND.Rows[0]["Uraian"].ToString();
                        dtResult.Rows.Add(drNew);
                        drRetBlmIndCur = drNew;
                    }
                    double totalRetBlmIND = double.Parse(drRetBlmIndCur["Debet"].ToString()) - double.Parse(drRetBlmIndCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    if (totalRetBlmIND > 0)
                    {
                        drRetBlmIndCur["DK"] = "D";
                        drRetBlmIndCur["Debet"] = totalRetBlmIND;
                        drRetBlmIndCur["Kredit"] = 0;
                    }
                    else if (totalRetBlmIND < 0)
                    {
                        drRetBlmIndCur["DK"] = "K";
                        drRetBlmIndCur["Debet"] = 0;
                        drRetBlmIndCur["Kredit"] = Math.Abs(totalRetBlmIND);
                    }
                    else if (totalRetBlmIND == 0)
                    {
                        drRetBlmIndCur.Delete();
                    }
                }

                //KREDIT TO NON INDEN, PIUTANG, ATAU GIRO TOLAK

                //A. KREDIT TO NON INDEN
                DateTime tglGudang = Convert.ToDateTime(dr["TglGudang"]);
                DateTime tglTransaksi = Convert.ToDateTime((dr["TglTransaksi"] != DBNull.Value ? dr["TglTransaksi"] : "1900/1/1"));

                if (dr["Kode"].ToString() == "CURR" && (dr["LinkID"].ToString().Trim() == "" || (dr["LinkID"].ToString().Trim() != "" && tglTransaksi > toDate)))
                //if (dr["LinkID"].ToString().Trim() == "" || (dr["LinkID"].ToString().Trim() != "" && tglTransaksi > toDate))
                {

                    //Add to RET_BLM_IND
                    DataRow drRetBlmIndFind = dtResult.Rows.Find("RET_BLMIND");
                    DataRow drRetBlmIndCur = drRetBlmIndFind;


                    bool isIndRegistered = false;
                    if (drRetBlmIndFind != null)
                    {
                        if (drRetBlmIndFind["Tipe"].ToString() == "RET_BLMIND")
                        {
                            isIndRegistered = true;
                        }
                    }
                    if (!isIndRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = "RET_BLMIND";
                        drNew["Tipe"] = "RET_BLMIND";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "D";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = PerkRetBlmIND.Rows[0]["NoPerkiraan"].ToString();
                        drNew["NamaPerkiraan"] = PerkRetBlmIND.Rows[0]["Uraian"].ToString();
                        dtResult.Rows.Add(drNew);
                        drRetBlmIndCur = drNew;
                    }

                    double totalRetBlmIND = double.Parse(drRetBlmIndCur["Debet"].ToString()) - double.Parse(drRetBlmIndCur["Kredit"].ToString()) - (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    if (totalRetBlmIND > 0)
                    {
                        drRetBlmIndCur["DK"] = "D";
                        drRetBlmIndCur["Debet"] = totalRetBlmIND;
                        drRetBlmIndCur["Kredit"] = 0;
                    }
                    else if (totalRetBlmIND < 0)
                    {
                        drRetBlmIndCur["DK"] = "K";
                        drRetBlmIndCur["Debet"] = 0;
                        drRetBlmIndCur["Kredit"] = Math.Abs(totalRetBlmIND);
                    }
                    else if (totalRetBlmIND == 0)
                    {
                        drRetBlmIndCur.Delete();
                    }

                }
                else
                {                   
                    if ( dr["LinkID"].ToString().Trim() != "")
                    {
                        //LINK PIUTANG WILAYAH
                        if (dr["GiroTolakID"] == DBNull.Value)
                        {
                            //Retur tidak Link ke Giro Tolak
                            DataRow drWilFind = dtResult.Rows.Find(dr["WilID"].ToString().Substring(0, 1));
                            DataRow drWilCur = drWilFind;


                            bool isWilRegistered = false;
                            if (drWilFind != null)
                            {
                                if (drWilFind["Tipe"].ToString() == "WilID")
                                {
                                    isWilRegistered = true;
                                }
                            }
                            if (!isWilRegistered)
                            {
                                DataRow drNew = dtResult.NewRow();
                                drNew["HeaderID"] = headerID;
                                drNew["HRecordID"] = headerRecID;
                                drNew["Kode"] = dr["WilID"].ToString().Substring(0, 1);
                                drNew["Tipe"] = "WilID";
                                drNew["Debet"] = 0;
                                drNew["Kredit"] = 0;
                                drNew["DK"] = "K";
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    DataTable dtWilPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("COL" + dr["WilID"].ToString().Substring(0, 1));
                                    drNew["NoPerkiraan"] = dtWilPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                                    drNew["NamaPerkiraan"] = dtWilPerkiraan.Rows[0]["Uraian"].ToString();
                                }
                                dtResult.Rows.Add(drNew);
                                drWilCur = drNew;
                            }
                            drWilCur["Kredit"] = double.Parse(drWilCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                        }
                        // LINK GIRO TOLAK
                        else
                        {
                            //Retur  link ke Giro Tolak
                            DataRow drWilFind = dtResult.Rows.Find("BGTLK");
                            DataRow drWilCur = drWilFind;


                            bool isWilRegistered = false;
                            if (drWilFind != null)
                            {
                                if (drWilFind["Tipe"].ToString() == "WilID")
                                {
                                    isWilRegistered = true;
                                }
                            }
                            if (!isWilRegistered)
                            {
                                DataRow drNew = dtResult.NewRow();
                                drNew["HeaderID"] = headerID;
                                drNew["HRecordID"] = headerRecID;
                                drNew["Kode"] = "BGTLK";
                                drNew["Tipe"] = "WilID";
                                drNew["Debet"] = 0;
                                drNew["Kredit"] = 0;
                                drNew["DK"] = "K";
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    drNew["NoPerkiraan"] = PerkGiroTolak.Rows[0]["NoPerkiraan"].ToString();
                                    drNew["NamaPerkiraan"] = PerkGiroTolak.Rows[0]["Uraian"].ToString();
                                }
                                dtResult.Rows.Add(drNew);
                                drWilCur = drNew;
                            }
                            drWilCur["Kredit"] = double.Parse(drWilCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                        }
                    }
                }               
            }
            return dtResult;
        }

        private void ConstructData(DataTable dtResult, DataRow [] dtSource, Guid headerID, string headerRecID)
        {
            string prevNota = "";
            string curNota = "";

            foreach (DataRow dr in dtSource)
            {
                curNota = dr["NoNotaRetur"].ToString();
                if (prevNota != curNota)
                {
                    prevNota = curNota;
                    jmlNota++;
                }

                if (dr["Kode"].ToString() == "CURR" && dr["LinkID"].ToString().Trim() != "")
                {

                    //CHECK Kelompok Barang

                    DataRow drBrgFind = dtResult.Rows.Find(dr["KelompokBrgID"]);
                    DataRow drBrgCur = drBrgFind;


                    bool isBrgRegistered = false;
                    if (drBrgFind != null)
                    {
                        if (drBrgFind["Tipe"].ToString() == "KelompokBrgID")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = dr["KelompokBrgID"].ToString();
                        drNew["Tipe"] = "KelompokBrgID";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "D";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = dtKlpBarang.Rows[0]["Noprj"].ToString();
                        drNew["NamaPerkiraan"] = dtKlpBarang.Rows[0]["NamaPerkiraan"].ToString();
                        dtResult.Rows.Add(drNew);
                        drBrgCur = drNew;
                    }
                    drBrgCur["Debet"] = double.Parse(drBrgCur["Debet"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                }
                else if (dr["Kode"].ToString() == "CURR" && dr["LinkID"].ToString().Trim() == "")
                {
                    //Add to RET_BLM_IND
                    DataRow drRetBlmIndFind = dtResult.Rows.Find("RET_BLMIND");
                    DataRow drRetBlmIndCur = drRetBlmIndFind;


                    bool isBrgRegistered = false;
                    if (drRetBlmIndFind != null)
                    {
                        if (drRetBlmIndFind["Tipe"].ToString() == "RET_BLMIND")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = "RET_BLMIND";
                        drNew["Tipe"] = "RET_BLMIND";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "D";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = PerkRetBlmIND.Rows[0]["NoPerkiraan"].ToString();
                        drNew["NamaPerkiraan"] = PerkRetBlmIND.Rows[0]["Uraian"].ToString();
                        dtResult.Rows.Add(drNew);
                        drRetBlmIndCur = drNew;
                    }

                    double totalRetBlmIND = double.Parse(drRetBlmIndCur["Debet"].ToString()) - double.Parse(drRetBlmIndCur["Kredit"].ToString()) - (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    if (totalRetBlmIND > 0)
                    {
                        drRetBlmIndCur["DK"] = "D";
                        drRetBlmIndCur["Debet"] = totalRetBlmIND;
                        drRetBlmIndCur["Kredit"] = 0;
                    }
                    else if (totalRetBlmIND < 0)
                    {
                        drRetBlmIndCur["DK"] = "K";
                        drRetBlmIndCur["Debet"] = 0;
                        drRetBlmIndCur["Kredit"] = Math.Abs(totalRetBlmIND);
                    }
                    else if (totalRetBlmIND == 0)
                    {
                        drRetBlmIndCur.Delete();
                    }

                }
                //CHECK Link Giro Tolak
                if (dr["Kode"].ToString() == "CURR" && dr["LinkID"].ToString().Trim() != "")
                {
                    if (dr["GiroTolakID"] == DBNull.Value)
                    {
                        //Retur tidak Link ke Giro Tolak
                        DataRow drWilFind = dtResult.Rows.Find(dr["WilID"].ToString().Substring(0, 1));
                        DataRow drWilCur = drWilFind;


                        bool isWilRegistered = false;
                        if (drWilFind != null)
                        {
                            if (drWilFind["Tipe"].ToString() == "WilID")
                            {
                                isWilRegistered = true;
                            }
                        }
                        if (!isWilRegistered)
                        {
                            DataRow drNew = dtResult.NewRow();
                            drNew["HeaderID"] = headerID;
                            drNew["HRecordID"] = headerRecID;
                            drNew["Kode"] = dr["WilID"].ToString().Substring(0, 1);
                            drNew["Tipe"] = "WilID";
                            drNew["Debet"] = 0;
                            drNew["Kredit"] = 0;
                            drNew["DK"] = "K";
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                DataTable dtWilPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("COL" + dr["WilID"].ToString().Substring(0, 1));
                                drNew["NoPerkiraan"] = dtWilPerkiraan.Rows[0]["NoPerkiraan"].ToString();
                                drNew["NamaPerkiraan"] = dtWilPerkiraan.Rows[0]["Uraian"].ToString();
                            }
                            dtResult.Rows.Add(drNew);
                            drWilCur = drNew;
                        }
                        drWilCur["Kredit"] = double.Parse(drWilCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    }
                    else
                    {
                        //Retur  link ke Giro Tolak
                        DataRow drWilFind = dtResult.Rows.Find("BGTLK");
                        DataRow drWilCur = drWilFind;


                        bool isWilRegistered = false;
                        if (drWilFind != null)
                        {
                            if (drWilFind["Tipe"].ToString() == "WilID")
                            {
                                isWilRegistered = true;
                            }
                        }
                        if (!isWilRegistered)
                        {
                            DataRow drNew = dtResult.NewRow();
                            drNew["HeaderID"] = headerID;
                            drNew["HRecordID"] = headerRecID;
                            drNew["Kode"] = "BGTLK";
                            drNew["Tipe"] = "WilID";
                            drNew["Debet"] = 0;
                            drNew["Kredit"] = 0;
                            drNew["DK"] = "K";
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                drNew["NoPerkiraan"] = PerkGiroTolak.Rows[0]["NoPerkiraan"].ToString();
                                drNew["NamaPerkiraan"] = PerkGiroTolak.Rows[0]["Uraian"].ToString();
                            }
                            dtResult.Rows.Add(drNew);
                            drWilCur = drNew;
                        }
                        drWilCur["Kredit"] = double.Parse(drWilCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    }
                }
                //CROSS
                else if (dr["Kode"].ToString() == "CROSS")
                {
                    //Add to RET_BLM_IND
                    DataRow drRetBlmIndFind = dtResult.Rows.Find("RET_BLMIND");
                    DataRow drRetBlmIndCur = drRetBlmIndFind;


                    bool isBrgRegistered = false;
                    if (drRetBlmIndFind != null)
                    {
                        if (drRetBlmIndFind["Tipe"].ToString() == "RET_BLMIND")
                        {
                            isBrgRegistered = true;
                        }
                    }
                    if (!isBrgRegistered)
                    {
                        DataRow drNew = dtResult.NewRow();
                        drNew["HeaderID"] = headerID;
                        drNew["HRecordID"] = headerRecID;
                        drNew["Kode"] = "RET_BLMIND";
                        drNew["Tipe"] = "RET_BLMIND";
                        drNew["Debet"] = 0;
                        drNew["Kredit"] = 0;
                        drNew["DK"] = "K";
                        DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                        drNew["NoPerkiraan"] = PerkRetBlmIND.Rows[0]["NoPerkiraan"].ToString();
                        drNew["NamaPerkiraan"] = PerkRetBlmIND.Rows[0]["Uraian"].ToString();
                        dtResult.Rows.Add(drNew);
                        drRetBlmIndCur = drNew;
                    }
                    double totalRetBlmIND = double.Parse(drRetBlmIndCur["Debet"].ToString()) - double.Parse(drRetBlmIndCur["Kredit"].ToString()) + (double.Parse(dr["HrgJual"].ToString()) * int.Parse(dr["QtyGudang"].ToString()));
                    if (totalRetBlmIND > 0)
                    {
                        drRetBlmIndCur["DK"] = "D";
                        drRetBlmIndCur["Debet"] = totalRetBlmIND;
                        drRetBlmIndCur["Kredit"] = 0;
                    }
                    else if (totalRetBlmIND < 0)
                    {
                        drRetBlmIndCur["DK"] = "K";
                        drRetBlmIndCur["Debet"] = 0;
                        drRetBlmIndCur["Kredit"] = Math.Abs(totalRetBlmIND);
                    }
                    else if (totalRetBlmIND == 0)
                    {
                        drRetBlmIndCur.Delete();
                    }
                }
            }
        }


        private void ProcessRJData(DataTable dtRJProcess, string kode)
        {
            
            
            string hReff = "ADJRJ" + toDate.ToString("yyyyMMdd");
            string hUraian = "RETUR JUAL";
            string hSrc = "RJ3";

            
            if (dtRJProcess.Rows.Count > 0)
            {
                double debet = Convert.ToDouble(dtRJProcess.Compute("SUM(Debet)", ""));
                double kredit = Convert.ToDouble(dtRJProcess.Compute("SUM(Kredit)", ""));
                if (kode == "CROSS" && headerCross != Guid.Empty)
                {
                    hReff = Numerator.GetNextNumerator("ADJ");
                    hUraian = "JB.RETUR BLM IDENTIFIKASI  ";
                    hSrc = "RJ3";
                    InsertJournalHeader(headerCross, headerRecCross, toDate, hReff, hUraian, hSrc, lookupGudang1.GudangID, false, debet, kredit);
                }
                if (kode == "CURR" && headerCurr != Guid.Empty)
                {
                    hReff = "ADJRJ" + toDate.ToString("yyyyMMdd");
                    hUraian = "RETUR JUAL";
                    hSrc = "RJ3";
                    InsertJournalHeader(headerCurr, headerRecCurr, toDate, hReff, hUraian, hSrc, lookupGudang1.GudangID, false, debet, kredit);
                }


                foreach (DataRow dr in dtRJProcess.Rows)
                {
                    Guid dRowID = Guid.NewGuid();
                    Guid headerID = new Guid (dr["HeaderID"].ToString());
                    string headerRecID = dr["HRecordID"].ToString();
                    string dNoPerk = dr["NoPerkiraan"].ToString();
                    string dUraian = dr["NamaPerkiraan"].ToString();
                    double dDebet = Convert.ToDouble(dr["Debet"]);
                    double dKredit = Convert.ToDouble(dr["Kredit"]);
                    string dDK = dr["DK"].ToString();
                    string dRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    InsertJournalDetail(dRowID, headerID, dRecID, headerRecID, dNoPerk, dUraian, dDebet, dKredit, dDK);
                }                
            }            
        }
               
        private void DisplayReportBermasalah(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", fromDate.ToString("dd/MM/yyyy"), toDate.ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PJTools.rptNotaBermasalah.rdlc", rptParams, dt, "dsPenjualan_Data");
            ifrmReport.Show();
        }

        private void ResetValues()
        {
            dtRj = new DataTable();  
            dtResultCross = new DataTable();
            dtResultCurr = new DataTable();

            dtCross = null;
            dtCurr = null;

            headerCross = Guid.Empty;
            headerCurr = Guid.Empty;
            headerRecCross = "";
            headerRecCurr = "";

            dtJurnalH = new dsJurnal.JournalDataTable();
            dtJurnalD = new dsJurnal.JournalDetailDataTable();
        }

        private void DisplayReportRekap(DataTable dtJournal, DataTable dtPenjualan)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", fromDate.ToString("dd/MM/yyyy"), toDate.ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("LbrNota", jmlNota.ToString("#,##0")));

            //List Data Table
            List<DataTable> dtList = new List<DataTable>();
            dtList.Add(dtJournal);
            dtList.Add(dtPenjualan);

            //List DataSet Name
            List<string> datasetName = new List<string>();
            datasetName.Add("dsJurnal_Data");
            datasetName.Add("dsPenjualan_Data");

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PJTools.rptRekapJournalRJ.rdlc", rptParams, dtList, datasetName);

            ifrmReport.Show();
        }

    }
}
