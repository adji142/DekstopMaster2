using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
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
    public partial class frmLinkAGBrowse : ISA.Finance.BaseForm
    {
        string periode;
        DataTable dtc = new DataTable();
        DataTable dtAG = new DataTable();
        DataTable dtAC1 = new DataTable();
        //DataTable dtAG = new DataTable();
        //DataTable dtAC = new DataTable();
        DataTable dtAGHProcess = new DataTable();
        DataTable dtAGProcess = new DataTable();
        //DataTable dtAGProcess = new DataTable();
        //DataTable dtACProcess = new DataTable();
        DateTime fromDate;
        DateTime toDate;
        int jmlNota;

        DataSet dsData = new DataSet();
        bool link = true;
        string RecodID_ = "";
        Guid HeadID;

        DataTemplates.dsPenjualan.DataDataTable dtRekapAG = new dsPenjualan.DataDataTable();

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();

        public frmLinkAGBrowse()
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

        private void frmLinkAGBrowse_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                periode = txtYear.Value.ToString().PadLeft(4, '0') + (cboMonth.SelectedIndex + 1).ToString().PadLeft(2, '0');
                fromDate = new DateTime(int.Parse(periode.Substring(0, 4)), int.Parse(periode.Substring(4, 2)), 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);

                Api2gl();

                
                //dtJurnalH = new dsJurnal.JournalDataTable();
                //dtJurnalD = new dsJurnal.JournalDetailDataTable();

                //dtAG = new DataTable();
                //dtAC1 = new DataTable();
                //DataTable dtAG = new DataTable();
                //DataTable dtAC = new DataTable();
                //dtAGHProcess = new DataTable();
                //dtAGProcess = new DataTable();
                //dtRekapAG = new dsPenjualan.DataDataTable();

                //if (ISA.Finance.Class.PeriodeClosing.IsHPPClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsPJTClosed(toDate) || 
                //    ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))

                if (ISA.Finance.Class.PeriodeClosing.IsGLClosed(periode, GlobalVar.Gudang))
                {
                    MessageBox.Show(string.Format(Messages.Error.AlreadyClosingPJT, periode));
                    return;
                }
                
                //GET DATA
                //GetAGData();
                //PREPARE DATA
                //PrepareAGData();
                //PROCESS DATA
                //ProcessAGData();
                //if (dtJurnalH.Rows.Count == 0)
                //{
                //    MessageBox.Show("Tidak Ada Data");
                //    return;
                //}

                //cmdOk.Enabled = false;
                //DISPLAY RESULT
                //DisplayReportRekap(dtJurnalD, dtRekapPj);

                //dtJurnalD.DefaultView.Sort = "DK, NoPerkiraan";                
                //frmLinkAGExecute ifrmChild = new frmLinkAGExecute(toDate, lookupGudang1.GudangID, dtJurnalH, dtJurnalD);
                //ifrmChild.Show();

                //DataTable dtRekapJurnal = dtJurnalD.Copy();
                //dtRekapAG.DefaultView.Sort = "NoAG";
                //DisplayReportRekap(dtRekapJurnal, dtRekapAG);
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


        private void Api2gl()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetApi"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                db.Commands[0].Parameters.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dsData = db.Commands[0].ExecuteDataSet();
            }
            
            if (dsData.Tables.Count > 0)
            {
                DisplayReport();

                DialogResult jawab = MessageBox.Show("Link ke GL ?","Konfirmasi", MessageBoxButtons.YesNo);
                if (jawab == DialogResult.Yes)
                {
                    //Guid RowID_ = Guid.NewGuid();
                    int x = 0;

                    #region Link ADJ
                    // LINK TO TRANSACT ADJ \\
                    if (dsData.Tables[1].Rows.Count > 0)
                    {
                        MessageBox.Show("Once");
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr1 in dsData.Tables[1].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr1["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr1["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr1["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr1["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS \\
                        foreach (DataRow drd in dsData.Tables[1].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "001" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion 


                    #region Link KPJ
                    //LINK TO TRANSACT KPJ \\
                    if (dsData.Tables[3].Rows.Count > 0)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr3 in dsData.Tables[3].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr3["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr3["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr3["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr3["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS KPJ \\
                        foreach (DataRow drd in dsData.Tables[3].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "002" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion 


                    #region Link KRJ
                    //LINK TO TRANSACT KRJ \\
                    if (dsData.Tables[5].Rows.Count > 0)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr5 in dsData.Tables[5].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr5["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr5["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr5["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr5["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS KRJ \\
                        foreach (DataRow drd in dsData.Tables[5].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "003" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion 

                
                    #region Link POT
                    //LINK TO TRANSACT POT \\
                    if (dsData.Tables[7].Rows.Count > 0)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr7 in dsData.Tables[7].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr7["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr7["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr7["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr7["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS POT \\
                        foreach (DataRow drd in dsData.Tables[7].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "004" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion


                    #region Link DIL
                    //LINK TO TRANSACT DIL \\
                    if (dsData.Tables[9].Rows.Count > 0)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr9 in dsData.Tables[9].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr9["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr9["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr9["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr9["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS POT \\
                        foreach (DataRow drd in dsData.Tables[9].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "005" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion


                    #region Link PLL
                    //LINK TO TRANSACT PLL \\
                    if (dsData.Tables[11].Rows.Count > 0)
                    {
                        Guid RowID_ = Guid.NewGuid();
                        foreach (DataRow dr11 in dsData.Tables[11].Rows)
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PJTools_PJL_Link_Transact"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(dr11["kdtr"], "").ToString();

                                string NoReff_ = Tools.isNull(dr11["kdtr"], "").ToString() + "-" +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                                 string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2);

                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, toDate));
                                db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, NoReff_));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr11["uraian"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr11["kdtr"], "").ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));

                                db.Commands[0].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                        }

                        // LINK TO JOURNALS POT \\
                        foreach (DataRow drd in dsData.Tables[11].Rows)
                        {
                            dtc = new DataTable();
                            using (Database dbc = new Database(GlobalVar.DBName))
                            {
                                dbc.Commands.Add(dbc.CreateCommand("usp_PJTools_PJL_GetRowID_Journal"));
                                dbc.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecodID_));
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

                            Guid _RowID = Guid.NewGuid();

                            using (Database dbd = new Database(GlobalVar.DBName))
                            {
                                dbd.Commands.Add(dbd.CreateCommand("usp_PJTools_PJL_Link_GIT"));
                                RecodID_ = GlobalVar.PerusahaanID +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(0, 4) +
                                           string.Format("{0:yyyyMMdd}", toDate).Substring(4, 2) +
                                           Tools.isNull(drd["kdtr"], "").ToString();
                                x++;
                                string _RecodID = RecodID_ + Tools.isNull(drd["dk"], "") + "006" + x.ToString().PadLeft(6, '0');

                                dbd.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeadID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecodID));
                                dbd.Commands[0].Parameters.Add(new Parameter("@HRecodID", SqlDbType.VarChar, RecodID_));
                                dbd.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(drd["NoPerkiraan"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(drd["uraian"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(drd["debet"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(drd["kredit"], 0)));
                                dbd.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(drd["dk"], "")));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "Admin"));
                                dbd.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                                dbd.Commands[0].ExecuteNonQuery();
                                dbd.CommitTransaction();
                            }
                        }
                    }
                    #endregion

                }
            }
        }


        private void DisplayReport()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(lapAPI2GL());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "API2GL" + GlobalVar.Gudang;
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


        private ExcelPackage lapAPI2GL()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "PJTOOLS";
            ex.Workbook.Properties.SetCustomPropertyValue("PJTOOLS", "1147");

            ex.Workbook.Worksheets.Add("Journal");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
            ws.Cells[1, 1].Worksheet.Column(2).Width = 15;      //B Kode
            ws.Cells[1, 2].Worksheet.Column(3).Width = 40;      //C Perkiraan
            ws.Cells[1, 3].Worksheet.Column(4).Width = 15;      //D Debet
            ws.Cells[1, 4].Worksheet.Column(5).Width = 15;      //E Kredit
            ws.Cells[1, 5].Worksheet.Column(6).Width = 60;      //F Keterangan

            int rowAdj = 0, nHeader = 0, rowx = 0;

            #region sheet 1 : ADJ
            if (dsData.Tables[1].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL ADJ PIUTANG ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader+1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;
                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr1 in dsData.Tables[1].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr1["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr1["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr1["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr1["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr1["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr1["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr1["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 1 : KPJ
            if (dsData.Tables[3].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL KOREKSI PENJUALAN ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader+1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader+1, 2].Style.Font.Bold = true;

                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr3 in dsData.Tables[3].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr3["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr3["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr3["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr3["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr3["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr3["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr3["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 1 : KRJ
            if (dsData.Tables[5].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL KOREKSI RETUR PENJUALAN ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;

                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr5 in dsData.Tables[5].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr5["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr5["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr5["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr5["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr5["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr5["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr5["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 1 : POT
            if (dsData.Tables[7].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL POTONGAN PENJUALAN ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;

                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr7 in dsData.Tables[7].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr7["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr7["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr7["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr7["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr7["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr7["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr7["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 1 : DIL
            if (dsData.Tables[9].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL DISCOUNT (DIL) ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;

                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr9 in dsData.Tables[9].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr9["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr9["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr9["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr9["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr9["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr9["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr9["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 1 : PLL
            if (dsData.Tables[11].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAdj = nHeader + 2;
                rowx = rowAdj;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " REKAP JOURNAL PENDAPATAN LAIN-LAIN ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;

                int MaxCol = 6;
                double nDb = 0, nKr = 0;

                ws.Cells[rowx, 2].Value = " KODE ";
                ws.Cells[rowx, 3].Value = " PERKIRAAN ";
                ws.Cells[rowx, 4].Value = " DEBET ";
                ws.Cells[rowx, 5].Value = " KREDIT ";
                ws.Cells[rowx, 6].Value = " KETERANGAN ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr11 in dsData.Tables[11].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr11["NoPerkiraan"], "");
                    ws.Cells[rowx, 3].Value = Tools.isNull(dr11["NaPerkiraan"], "");
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr11["debet"], 0);
                    ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr11["kredit"], 0);
                    ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr11["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr11["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr11["kredit"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 4].Value = Tools.isNull(nDb, 0);
                ws.Cells[rowx, 4].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 4].Style.Font.Bold = true;
                ws.Cells[rowx, 5].Value = Tools.isNull(nKr, 0);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 5].Style.Font.Bold = true;

                var border = ws.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion


            #region sheet 2 : ADJ

            int wsn = 1;
            if (dsData.Tables[0].Rows.Count > 0 && dsData.Tables[1].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("ADJ");
                ExcelWorksheet ws2 = ex.Workbook.Worksheets[wsn];

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 30;      //C NAMA TOKO
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws2.Cells[1, 7].Worksheet.Column(7).Width = 12;      //D Debet
                ws2.Cells[1, 8].Worksheet.Column(8).Width = 12;      //E Kredit
                ws2.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws2.Cells[2, 2].Style.Font.Bold.ToString();
                ws2.Cells[2, 2].Value = " ADJ PIUTANG ";
                ws2.Cells[2, 2].Style.Font.Bold = true;
                ws2.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws2.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws2.Cells[rowx, 2].Value = " NO NOTA ";
                ws2.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws2.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws2.Cells[rowx, 5].Value = " ALAMAT ";
                ws2.Cells[rowx, 6].Value = " IDWIL ";
                ws2.Cells[rowx, 7].Value = " DEBET ";
                ws2.Cells[rowx, 8].Value = " KREDIT ";
                ws2.Cells[rowx, 9].Value = " URAIAN ";

                ws2.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws2.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr0 in dsData.Tables[0].Rows)
                {
                    ws2.Cells[rowx, 2].Value = Tools.isNull(dr0["NoTransaksi"], "");
                    ws2.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr0["TglTransaksi"], ""));
                    ws2.Cells[rowx, 4].Value = Tools.isNull(dr0["NamaToko"], "");
                    ws2.Cells[rowx, 5].Value = Tools.isNull(dr0["Alamat"], 0);
                    ws2.Cells[rowx, 6].Value = Tools.isNull(dr0["WilID"], 0);
                    ws2.Cells[rowx, 7].Value = Tools.isNull(dr0["Debet"], 0);
                    ws2.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws2.Cells[rowx, 8].Value = Tools.isNull(dr0["kredit"], 0);
                    ws2.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws2.Cells[rowx, 9].Value = Tools.isNull(dr0["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr0["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr0["kredit"], 0));
                    rowx++;
                }

                ws2.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws2.Cells[rowx, 2].Style.Font.Bold = true;
                ws2.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws2.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx, 7].Style.Font.Bold = true;
                ws2.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws2.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws2.Cells[rowx, 8].Style.Font.Bold = true;
                ws2.Cells[rowx, 2, rowx, 6].Merge = true;
                ws2.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border2 = ws2.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style = ExcelBorderStyle.None;
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                border2 = ws2.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                border2 = ws2.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style = ExcelBorderStyle.Thin;
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.None;

                border2 = ws2.Cells[rowx, 2, rowx, 2].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style = ExcelBorderStyle.Thin;
                border2.Right.Style = ExcelBorderStyle.None;

                border2 = ws2.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion


            #region sheet 2 : KPJ

            if (dsData.Tables[2].Rows.Count > 0 && dsData.Tables[3].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("KPJ");
                ExcelWorksheet ws3 = ex.Workbook.Worksheets[wsn];

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws3.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws3.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws3.Cells[1, 4].Worksheet.Column(4).Width = 35;      //C NAMA TOKO
                ws3.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws3.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws3.Cells[1, 7].Worksheet.Column(7).Width = 15;      //D Debet
                ws3.Cells[1, 8].Worksheet.Column(8).Width = 15;      //E Kredit
                ws3.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws3.Cells[2, 2].Style.Font.Bold.ToString();
                ws3.Cells[2, 2].Value = " KOREKSI PENJUALAN ";
                ws3.Cells[2, 2].Style.Font.Bold = true;
                ws3.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws3.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws3.Cells[rowx, 2].Value = " NO NOTA ";
                ws3.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws3.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws3.Cells[rowx, 5].Value = " ALAMAT ";
                ws3.Cells[rowx, 6].Value = " IDWIL ";
                ws3.Cells[rowx, 7].Value = " DEBET ";
                ws3.Cells[rowx, 8].Value = " KREDIT ";
                ws3.Cells[rowx, 9].Value = " URAIAN ";

                ws3.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws3.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr2 in dsData.Tables[2].Rows)
                {
                    ws3.Cells[rowx, 2].Value = Tools.isNull(dr2["NoSuratJalan"], "");
                    ws3.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr2["TglTransaksi"], ""));
                    ws3.Cells[rowx, 4].Value = Tools.isNull(dr2["NamaToko"], "");
                    ws3.Cells[rowx, 5].Value = Tools.isNull(dr2["Alamat"], 0);
                    ws3.Cells[rowx, 6].Value = Tools.isNull(dr2["WilID"], 0);
                    ws3.Cells[rowx, 7].Value = Tools.isNull(dr2["Debet"], 0);
                    ws3.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws3.Cells[rowx, 8].Value = Tools.isNull(dr2["kredit"], 0);
                    ws3.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws3.Cells[rowx, 9].Value = Tools.isNull(dr2["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr2["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr2["kredit"], 0));
                    rowx++;
                }

                ws3.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws3.Cells[rowx, 2].Style.Font.Bold = true;
                ws3.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws3.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws3.Cells[rowx, 7].Style.Font.Bold = true;
                ws3.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws3.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws3.Cells[rowx, 8].Style.Font.Bold = true;
                ws3.Cells[rowx, 2, rowx, 6].Merge = true;
                ws3.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border3 = ws3.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style = ExcelBorderStyle.None;
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                border3 = ws3.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                border3 = ws3.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style = ExcelBorderStyle.Thin;
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.None;

                border3 = ws3.Cells[rowx, 2, rowx, 2].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style = ExcelBorderStyle.Thin;
                border3.Right.Style = ExcelBorderStyle.None;

                border3 = ws3.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion


            #region sheet 2 : KRJ

            if (dsData.Tables[4].Rows.Count > 0 && dsData.Tables[5].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("KRJ");
                ExcelWorksheet ws4 = ex.Workbook.Worksheets[wsn];

                ws4.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws4.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws4.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws4.Cells[1, 4].Worksheet.Column(4).Width = 35;      //C NAMA TOKO
                ws4.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws4.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws4.Cells[1, 7].Worksheet.Column(7).Width = 15;      //D Debet
                ws4.Cells[1, 8].Worksheet.Column(8).Width = 15;      //E Kredit
                ws4.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws4.Cells[2, 2].Style.Font.Bold.ToString();
                ws4.Cells[2, 2].Value = " KOREKSI RETUR JUAL ";
                ws4.Cells[2, 2].Style.Font.Bold = true;
                ws4.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws4.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws4.Cells[rowx, 2].Value = " NO NOTA ";
                ws4.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws4.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws4.Cells[rowx, 5].Value = " ALAMAT ";
                ws4.Cells[rowx, 6].Value = " IDWIL ";
                ws4.Cells[rowx, 7].Value = " DEBET ";
                ws4.Cells[rowx, 8].Value = " KREDIT ";
                ws4.Cells[rowx, 9].Value = " URAIAN ";

                ws4.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws4.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws4.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws4.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr4 in dsData.Tables[4].Rows)
                {
                    ws4.Cells[rowx, 2].Value = Tools.isNull(dr4["NoNotaRetur"], "");
                    ws4.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr4["TglTransaksi"], ""));
                    ws4.Cells[rowx, 4].Value = Tools.isNull(dr4["NamaToko"], "");
                    ws4.Cells[rowx, 5].Value = Tools.isNull(dr4["Alamat"], 0);
                    ws4.Cells[rowx, 6].Value = Tools.isNull(dr4["WilID"], 0);
                    ws4.Cells[rowx, 7].Value = Tools.isNull(dr4["Debet"], 0);
                    ws4.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws4.Cells[rowx, 8].Value = Tools.isNull(dr4["kredit"], 0);
                    ws4.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws4.Cells[rowx, 9].Value = Tools.isNull(dr4["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr4["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr4["kredit"], 0));
                    rowx++;
                }

                ws4.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws4.Cells[rowx, 2].Style.Font.Bold = true;
                ws4.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws4.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws4.Cells[rowx, 7].Style.Font.Bold = true;
                ws4.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws4.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws4.Cells[rowx, 8].Style.Font.Bold = true;
                ws4.Cells[rowx, 2, rowx, 6].Merge = true;
                ws4.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border4 = ws4.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style = ExcelBorderStyle.None;
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

                border4 = ws4.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

                border4 = ws4.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style = ExcelBorderStyle.Thin;
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.None;

                border4 = ws4.Cells[rowx, 2, rowx, 2].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style = ExcelBorderStyle.Thin;
                border4.Right.Style = ExcelBorderStyle.None;

                border4 = ws4.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border4.Bottom.Style =
                border4.Top.Style =
                border4.Left.Style =
                border4.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion


            #region sheet 2 : POT

            if (dsData.Tables[6].Rows.Count > 0 && dsData.Tables[7].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("POT");
                ExcelWorksheet ws5 = ex.Workbook.Worksheets[wsn];

                ws5.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws5.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws5.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws5.Cells[1, 4].Worksheet.Column(4).Width = 35;      //C NAMA TOKO
                ws5.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws5.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws5.Cells[1, 7].Worksheet.Column(7).Width = 15;      //D Debet
                ws5.Cells[1, 8].Worksheet.Column(8).Width = 15;      //E Kredit
                ws5.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws5.Cells[2, 2].Style.Font.Bold.ToString();
                ws5.Cells[2, 2].Value = " POTONGAN PENJUALAN ";
                ws5.Cells[2, 2].Style.Font.Bold = true;
                ws5.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws5.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws5.Cells[rowx, 2].Value = " NO NOTA ";
                ws5.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws5.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws5.Cells[rowx, 5].Value = " ALAMAT ";
                ws5.Cells[rowx, 6].Value = " IDWIL ";
                ws5.Cells[rowx, 7].Value = " DEBET ";
                ws5.Cells[rowx, 8].Value = " KREDIT ";
                ws5.Cells[rowx, 9].Value = " URAIAN ";

                ws5.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws5.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws5.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws5.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr6 in dsData.Tables[6].Rows)
                {
                    ws5.Cells[rowx, 2].Value = Tools.isNull(dr6["NoTransaksi"], "");
                    ws5.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr6["TglTransaksi"], ""));
                    ws5.Cells[rowx, 4].Value = Tools.isNull(dr6["NamaToko"], "");
                    ws5.Cells[rowx, 5].Value = Tools.isNull(dr6["Alamat"], 0);
                    ws5.Cells[rowx, 6].Value = Tools.isNull(dr6["WilID"], 0);
                    ws5.Cells[rowx, 7].Value = Tools.isNull(dr6["Debet"], 0);
                    ws5.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws5.Cells[rowx, 8].Value = Tools.isNull(dr6["kredit"], 0);
                    ws5.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws5.Cells[rowx, 9].Value = Tools.isNull(dr6["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr6["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr6["kredit"], 0));
                    rowx++;
                }

                ws5.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws5.Cells[rowx, 2].Style.Font.Bold = true;
                ws5.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws5.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws5.Cells[rowx, 7].Style.Font.Bold = true;
                ws5.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws5.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws5.Cells[rowx, 8].Style.Font.Bold = true;
                ws5.Cells[rowx, 2, rowx, 6].Merge = true;
                ws5.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border5 = ws5.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style = ExcelBorderStyle.None;
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

                border5 = ws5.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

                border5 = ws5.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style = ExcelBorderStyle.Thin;
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.None;

                border5 = ws5.Cells[rowx, 2, rowx, 2].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style = ExcelBorderStyle.Thin;
                border5.Right.Style = ExcelBorderStyle.None;

                border5 = ws5.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border5.Bottom.Style =
                border5.Top.Style =
                border5.Left.Style =
                border5.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion


            #region sheet 2 : DIL

            if (dsData.Tables[8].Rows.Count > 0 && dsData.Tables[9].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("DIL");
                ExcelWorksheet ws6 = ex.Workbook.Worksheets[wsn];

                ws6.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws6.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws6.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws6.Cells[1, 4].Worksheet.Column(4).Width = 35;      //C NAMA TOKO
                ws6.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws6.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws6.Cells[1, 7].Worksheet.Column(7).Width = 15;      //D Debet
                ws6.Cells[1, 8].Worksheet.Column(8).Width = 15;      //E Kredit
                ws6.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws6.Cells[2, 2].Style.Font.Bold.ToString();
                ws6.Cells[2, 2].Value = " DISCOUNT PENJUALAN (DIL) ";
                ws6.Cells[2, 2].Style.Font.Bold = true;
                ws6.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws6.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws6.Cells[rowx, 2].Value = " NO NOTA ";
                ws6.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws6.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws6.Cells[rowx, 5].Value = " ALAMAT ";
                ws6.Cells[rowx, 6].Value = " IDWIL ";
                ws6.Cells[rowx, 7].Value = " DEBET ";
                ws6.Cells[rowx, 8].Value = " KREDIT ";
                ws6.Cells[rowx, 9].Value = " URAIAN ";

                ws6.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws6.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws6.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws6.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr8 in dsData.Tables[8].Rows)
                {
                    ws6.Cells[rowx, 2].Value = Tools.isNull(dr8["NoTransaksi"], "");
                    ws6.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr8["TglTransaksi"], ""));
                    ws6.Cells[rowx, 4].Value = Tools.isNull(dr8["NamaToko"], "");
                    ws6.Cells[rowx, 5].Value = Tools.isNull(dr8["Alamat"], 0);
                    ws6.Cells[rowx, 6].Value = Tools.isNull(dr8["WilID"], 0);
                    ws6.Cells[rowx, 7].Value = Tools.isNull(dr8["Debet"], 0);
                    ws6.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws6.Cells[rowx, 8].Value = Tools.isNull(dr8["kredit"], 0);
                    ws6.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws6.Cells[rowx, 9].Value = Tools.isNull(dr8["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr8["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr8["kredit"], 0));
                    rowx++;
                }

                ws6.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws6.Cells[rowx, 2].Style.Font.Bold = true;
                ws6.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws6.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws6.Cells[rowx, 7].Style.Font.Bold = true;
                ws6.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws6.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws6.Cells[rowx, 8].Style.Font.Bold = true;
                ws6.Cells[rowx, 2, rowx, 6].Merge = true;
                ws6.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border6 = ws6.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style = ExcelBorderStyle.None;
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

                border6 = ws6.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style =
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

                border6 = ws6.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style = ExcelBorderStyle.Thin;
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.None;

                border6 = ws6.Cells[rowx, 2, rowx, 2].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style =
                border6.Left.Style = ExcelBorderStyle.Thin;
                border6.Right.Style = ExcelBorderStyle.None;

                border6 = ws6.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border6.Bottom.Style =
                border6.Top.Style =
                border6.Left.Style =
                border6.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion


            #region sheet 2 : PLL

            if (dsData.Tables[10].Rows.Count > 0 && dsData.Tables[11].Rows.Count > 0)
            {
                wsn++;
                ex.Workbook.Worksheets.Add("PLL");
                ExcelWorksheet ws7 = ex.Workbook.Worksheets[wsn];

                ws7.Cells[1, 1].Worksheet.Column(1).Width = 2;       //A Kosong
                ws7.Cells[1, 2].Worksheet.Column(2).Width = 10;      //B NO TR
                ws7.Cells[1, 3].Worksheet.Column(3).Width = 15;      //B TGL TR
                ws7.Cells[1, 4].Worksheet.Column(4).Width = 35;      //C NAMA TOKO
                ws7.Cells[1, 5].Worksheet.Column(5).Width = 60;      //C ALAMAT
                ws7.Cells[1, 6].Worksheet.Column(6).Width = 10;      //C IDWIL
                ws7.Cells[1, 7].Worksheet.Column(7).Width = 15;      //D Debet
                ws7.Cells[1, 8].Worksheet.Column(8).Width = 15;      //E Kredit
                ws7.Cells[1, 9].Worksheet.Column(9).Width = 50;      //F URAIAN

                ws7.Cells[2, 2].Style.Font.Bold.ToString();
                ws7.Cells[2, 2].Value = " PENDAPATAN LAIN-LAIN ";
                ws7.Cells[2, 2].Style.Font.Bold = true;
                ws7.Cells[3, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", fromDate) + " s/d " + string.Format("{0:dd-MMM-yyyy}", toDate);
                ws7.Cells[3, 2].Style.Font.Bold = true;

                int MaxCol = 9;
                double nDb = 0, nKr = 0;
                rowAdj = 4;
                rowx = rowAdj;

                ws7.Cells[rowx, 2].Value = " NO NOTA ";
                ws7.Cells[rowx, 3].Value = " TGL TRANSAKSI ";
                ws7.Cells[rowx, 4].Value = " NAMA TOKO ";
                ws7.Cells[rowx, 5].Value = " ALAMAT ";
                ws7.Cells[rowx, 6].Value = " IDWIL ";
                ws7.Cells[rowx, 7].Value = " DEBET ";
                ws7.Cells[rowx, 8].Value = " KREDIT ";
                ws7.Cells[rowx, 9].Value = " URAIAN ";

                ws7.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws7.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws7.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws7.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr10 in dsData.Tables[10].Rows)
                {
                    ws7.Cells[rowx, 2].Value = Tools.isNull(dr10["NoTransaksi"], "");
                    ws7.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr10["TglTransaksi"], ""));
                    ws7.Cells[rowx, 4].Value = Tools.isNull(dr10["NamaToko"], "");
                    ws7.Cells[rowx, 5].Value = Tools.isNull(dr10["Alamat"], 0);
                    ws7.Cells[rowx, 6].Value = Tools.isNull(dr10["WilID"], 0);
                    ws7.Cells[rowx, 7].Value = Tools.isNull(dr10["Debet"], 0);
                    ws7.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws7.Cells[rowx, 8].Value = Tools.isNull(dr10["kredit"], 0);
                    ws7.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws7.Cells[rowx, 9].Value = Tools.isNull(dr10["Uraian"], "");
                    nDb = nDb + Convert.ToDouble(Tools.isNull(dr10["debet"], 0));
                    nKr = nKr + Convert.ToDouble(Tools.isNull(dr10["kredit"], 0));
                    rowx++;
                }

                ws7.Cells[rowx, 2].Value = "TOTAL".ToString();
                ws7.Cells[rowx, 2].Style.Font.Bold = true;
                ws7.Cells[rowx, 7].Value = Tools.isNull(nDb, 0);
                ws7.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws7.Cells[rowx, 7].Style.Font.Bold = true;
                ws7.Cells[rowx, 8].Value = Tools.isNull(nKr, 0);
                ws7.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws7.Cells[rowx, 8].Style.Font.Bold = true;
                ws7.Cells[rowx, 2, rowx, 6].Merge = true;
                ws7.Cells[rowx, 2, rowx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var border7 = ws7.Cells[rowAdj + 1, 2, rowx, MaxCol].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style = ExcelBorderStyle.None;
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

                border7 = ws7.Cells[rowAdj, 2, rowAdj, MaxCol].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style =
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

                border7 = ws7.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style = ExcelBorderStyle.Thin;
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.None;

                border7 = ws7.Cells[rowx, 2, rowx, 2].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style =
                border7.Left.Style = ExcelBorderStyle.Thin;
                border7.Right.Style = ExcelBorderStyle.None;

                border7 = ws7.Cells[rowx, 7, rowx, MaxCol].Style.Border;
                border7.Bottom.Style =
                border7.Top.Style =
                border7.Left.Style =
                border7.Right.Style = ExcelBorderStyle.Thin;

            }
            #endregion
            return ex;
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


       
        private void GetAGData()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PJTools_GetAntarGudang"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPrsh.Text));
                dtAG = db.Commands[0].ExecuteDataTable();
                dtAG.DefaultView.Sort = "NoAG";
            }
        }

        private void PrepareAGData()
        {
            DataTable dtHResult = new DataTable();
            dtHResult.Columns.Add("RowID", typeof(System.Guid));
            dtHResult.Columns.Add("RecordID", typeof(System.String));
            dtHResult.Columns.Add("DariKe", typeof(System.String));
            dtHResult.Columns.Add("Dari", typeof(System.String));
            dtHResult.Columns.Add("Ke", typeof(System.String));
            DataColumn[] pkHResult = new DataColumn[1];
            pkHResult[0] = dtHResult.Columns["DariKe"];
            dtHResult.PrimaryKey = pkHResult;


            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(System.Guid));            
            dtResult.Columns.Add("HeaderID", typeof(System.Guid));
            dtResult.Columns.Add("HRecordID", typeof(System.String));
            dtResult.Columns.Add("RecordID", typeof(System.String));
            dtResult.Columns.Add("Kode", typeof(System.String));
            dtResult.Columns.Add("DariKe", typeof(System.String));
            dtResult.Columns.Add("Tipe", typeof(System.String));
            dtResult.Columns.Add("Debet", typeof(System.Double));
            dtResult.Columns.Add("Kredit", typeof(System.Double));
            dtResult.Columns.Add("DK", typeof(System.String));
            dtResult.Columns.Add("NoPerkiraan", typeof(System.String));
            dtResult.Columns.Add("NamaPerkiraan", typeof(System.String));
            dtResult.Columns.Add("Uraian", typeof(System.String));
            DataColumn[] pkResult = new DataColumn[1];
            pkResult[0] = dtResult.Columns["Kode"];
            dtResult.PrimaryKey = pkResult;

            string prevNota = "";
            string curNota = "";
            jmlNota = 0;

            DataTable dtGIT = Perkiraan.GetPerkiraanKoneksiDetail("GIT");
            string dariKe;

            foreach (DataRowView dr in dtAG.DefaultView)
            {
                curNota = dr["NoAG"].ToString();
                dariKe = dr["DrGudang"].ToString() + dr["KeGudang"].ToString();
                if (prevNota != curNota)
                {                  
                    jmlNota++;
                    DataRow drRekap = dtRekapAG.NewRow();
                    drRekap["NoAG"] = dr["NoAG"];
                    drRekap["Total"] = dtAG.Compute("SUM(Total)", "NoAG='" + dr["NoAG"].ToString() + "'");
                    dtRekapAG.Rows.Add(drRekap);
                }
                prevNota = curNota;

                Guid headerID = Guid.Empty;
                string hRecordID = string.Empty;
                DataRow drHFind = dtHResult.Rows.Find(dariKe);
                DataRow drHCur = drHFind;
                bool isHRegistered = false;
                if (drHFind != null)
                {
                    if (drHFind["DariKe"].ToString() == dariKe)
                    {
                        isHRegistered = true;
                        headerID = new Guid(drHFind["RowID"].ToString());
                        hRecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    }
                }
                if (!isHRegistered)
                {
                    DataRow drNew = dtHResult.NewRow();
                    headerID = Guid.NewGuid();
                    drNew["RowID"] = headerID;
                    drNew["RecordID"] = hRecordID;
                    drNew["DariKe"] = dariKe;
                    drNew["Dari"] = dr["DrGudang"].ToString();
                    drNew["Ke"] = dr["KeGudang"].ToString();
                    dtHResult.Rows.Add(drNew);
                    drHCur = drNew;
                }


                DataRow drWilFind = dtResult.Rows.Find("GIT" + dariKe);
                DataRow drWilCur = drWilFind;
                

                bool isWilRegistered = false;
                if (drWilFind != null)
                {
                    if (drWilFind["Kode"].ToString() == "GIT" + dariKe)
                    {
                        isWilRegistered = true;
                    }
                }
                if (!isWilRegistered)
                {
                    DataRow drNew = dtResult.NewRow();
                    drNew["RowID"] = Guid.NewGuid();
                    drNew["HeaderID"] = headerID;
                    drNew["HRecordID"] = hRecordID;
                    drNew["RecordID"] = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    drNew["Kode"] = "GIT" + dariKe;
                    drNew["DariKe"] = dariKe;
                    drNew["Tipe"] = "GIT";
                    drNew["Uraian"] = dtGIT.Rows[0]["Uraian"].ToString();
                    drNew["Debet"] = 0;
                    drNew["Kredit"] = 0;
                    drNew["DK"] = "D";
                    drNew["NoPerkiraan"] = dtGIT.Rows[0]["NoPerkiraan"].ToString();
                    drNew["NamaPerkiraan"] = dtGIT.Rows[0]["Uraian"].ToString();
                    dtResult.Rows.Add(drNew);
                    drWilCur = drNew;
                }
                double debet= 0;
                double kredit = 0;
                if (dr["Tipe"].ToString() == "AGK")
                {
                    debet = double.Parse(drWilCur["Debet"].ToString()) + double.Parse(dr["Total"].ToString());
                }
                else if (dr["Tipe"].ToString() == "AGT")
                {
                    kredit = double.Parse(drWilCur["Kredit"].ToString()) + double.Parse(dr["Total"].ToString());
                }

                if (debet >= kredit)
                {
                    drWilCur["DK"] = "D";
                    drWilCur["Debet"] = debet - kredit;

                }
                else
                {
                    drWilCur["DK"] = "K";
                    drWilCur["Kredit"] = kredit - debet;

                }



                //PROCESS DETAIL
                DataRow drBrgFind = dtResult.Rows.Find(dr["KelompokBrgID"] + dariKe + dr["NoAG"].ToString());
                DataRow drBrgCur = drBrgFind;


                bool isBrgRegistered = false;
                if (drBrgFind != null)
                {
                    if (drBrgFind["Kode"].ToString() == dr["KelompokBrgID"] + dariKe + dr["NoAG"].ToString())
                    {
                        isBrgRegistered = true;
                    }
                }
                if (!isBrgRegistered)
                {
                    DataRow drNew = dtResult.NewRow();
                    drNew["RowID"] = Guid.NewGuid();
                    drNew["HeaderID"] = headerID;
                    drNew["HRecordID"] = hRecordID;
                    drNew["RecordID"] = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    drNew["Kode"] = dr["KelompokBrgID"].ToString() + dariKe + dr["NoAG"].ToString();
                    drNew["DariKe"] = dariKe;
                    drNew["Tipe"] = "KelompokBrgID";
                    drNew["Debet"] = 0;
                    drNew["Kredit"] = 0;
                    drNew["DK"] = "K";
                    DataTable dtKlpBarang = Perkiraan.GetNoPerkiraanKlpBarang(dr["KelompokBrgID"].ToString());
                    drNew["NoPerkiraan"] = dtKlpBarang.Rows[0]["NopStk"].ToString();
                    drNew["NamaPerkiraan"] =  Perkiraan.GetPerkiraan( drNew["NoPerkiraan"].ToString()).Rows[0]["NamaPerkiraan"].ToString();
                    drNew["Uraian"] = dr["NoAG"].ToString();
                    dtResult.Rows.Add(drNew);
                    drBrgCur = drNew;
                }
                if (dr["Tipe"].ToString() == "AGK")
                {
                    drBrgCur["DK"] = "K";
                    drBrgCur["Kredit"] = double.Parse(drBrgCur["Kredit"].ToString()) + double.Parse(dr["Total"].ToString());
                }
                else if (dr["Tipe"].ToString() == "AGT")
                {
                    drBrgCur["DK"] = "D";
                    drBrgCur["Debet"] = double.Parse(drBrgCur["Debet"].ToString()) + double.Parse(dr["Total"].ToString());
                }
                



            }
            dtAGHProcess = dtHResult;
            dtAGProcess = dtResult;
        }

        private void ProcessAGData()
        {
            if (dtAGHProcess.Rows.Count > 0)
            {
                foreach (DataRow drH in dtAGHProcess.Rows)
                {
                    Guid headerID = new Guid(drH["RowID"].ToString());
                    string headerRecID = drH["RecordID"].ToString();
                    string hReff = "ADJAG" + toDate.ToString("yyyyMMdd");
                    string hUraian = string.Format("ANTAR GUDANG DARI {0} KE {1}", drH["Dari"].ToString(), drH["Ke"].ToString());
                    string hSrc = "AG";

                    double debet = Convert.ToDouble(dtAGProcess.Compute("SUM(Debet)", "DariKe='" + drH["DariKe"].ToString() + "'" ));
                    double kredit = Convert.ToDouble(dtAGProcess.Compute("SUM(Kredit)", "DariKe='" + drH["DariKe"].ToString() + "'"));

                    InsertJournalHeader(headerID, headerRecID, toDate, hReff, hUraian, hSrc, lookupGudang1.GudangID, false, debet, kredit);
                }
            }
                                    

            if (dtAGProcess.Rows.Count > 0)
            {                               
                foreach (DataRow dr in dtAGProcess.Rows)
                {
                    Guid dRowID = new Guid(dr["RowID"].ToString());
                    Guid headerID = new Guid(dr["HeaderID"].ToString());
                    string dRecID = dr["RecordID"].ToString();
                    string headerRecID = dr["HRecordID"].ToString();

                    string dNoPerk = dr["NoPerkiraan"].ToString();
                    string dUraian = dr["NamaPerkiraan"].ToString().Trim() + " - " + dr["Uraian"].ToString().Trim();
                    double dDebet = Convert.ToDouble(dr["Debet"]);
                    double dKredit = Convert.ToDouble(dr["Kredit"]);
                    string dDK = dr["DK"].ToString();
                    
                    InsertJournalDetail(dRowID, headerID, dRecID, headerRecID, dNoPerk, dUraian, dDebet, dKredit, dDK);
                }
            }
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
            frmReportViewer ifrmReport = new frmReportViewer("PJTools.rptRekapJournalAG.rdlc", rptParams, dtList, datasetName);

            ifrmReport.Show();
        }
    }
}
