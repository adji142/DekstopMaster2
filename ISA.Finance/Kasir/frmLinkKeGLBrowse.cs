using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Kasir
{
    public partial class frmLinkKeGLBrowse : ISA.Finance.BaseForm
    {
        DateTime tglProses;
        string tipeJurnaliden = "";

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();

        public frmLinkKeGLBrowse()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtJurnalH.Clear();
                dtJurnalD.Clear();
                DataTable dtCekJournal = new DataTable();
                tglProses = (DateTime)txtTglProses.DateValue;

                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtCekJournal = Journal.ListHeader(db, tglProses, tglProses);
                    if (dtCekJournal.Rows.Count == 0 || (dtCekJournal.Rows.Count > 0 && MessageBox.Show("Sudah Pernah Link, Link Ulang?", "", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        if (tipeJurnaliden == "V2")
                        {
                            if (chkIND.Checked) LinkINDV2(db);
                        }
                        else
                        {
                            if (chkIND.Checked) LinkIND(db);
                        }

                        if (chkBKK.Checked) LinkBKK(db);
                        if (chkBKM.Checked) LinkBKM(db);
                        if (chkBBB.Checked) LinkBBB(db);
                        if (chkVPG.Checked) LinkVPG(db);
                        if (chkVTG.Checked) LinkVTG(db);
                        if (chkBBM.Checked) LinkBBM(db);
                        if (chkVGT.Checked) LinkVGT(db);
                        if (chkVJU.Checked) LinkVJU(db);
                    }
                    else
                        return;
                    
                }

                if (dtJurnalH.Rows.Count == 0)
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                    return;
                }
                frmLinkLeGLExecute ifrmChild = new frmLinkLeGLExecute(tglProses, lookupGudang1.GudangID, dtJurnalH, dtJurnalD);
                ifrmChild.WindowState = FormWindowState.Maximized;
                ifrmChild.ShowDialog();
            }
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }



        private DataRow InsertJournalHeader(Guid rowID,Guid RefRowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag, double debet, double kredit )
        {
            dsJurnal.JournalRow hdrNew = (dsJurnal.JournalRow) dtJurnalH.NewRow();

            hdrNew.RefRowID = RefRowID;
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
            return (DataRow) hdrNew;
        }

        private DataRow InsertJournalDetail(Guid rowID,Guid RefRowID, Guid headerID, string recordID, string hRecordID, string noPerkiraan, string uraian, double debet, double kredit, string DK )
        {
            dsJurnal.JournalDetailRow dtlNew = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();

            dtlNew.RefRowID = RefRowID;
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

        #region LinkBKK
        private void LinkBKK(Database db)
        {
            string src = "BKK";
            string kodeTrnLawan = "KAS";
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN
            DataRow drLawan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrnLawan).Rows[0];
            
            DataTable dtHeader = new DataTable();            
            dtHeader = BKK.ListHeader(db, tglProses, tglProses, GlobalVar.PerusahaanID);

            prgBKK.Maximum = dtHeader.Rows.Count;
            prgBKK.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());                
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime ) drHeader["TglBukti"];
                string hNoBukti = drHeader["NoBukti"].ToString();
                string hUraian = "KAS KELUAR, NO.BUKTI : " + hNoBukti;
                
                
                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = BKK.ListDetail(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow =  (dsJurnal.JournalDetailRow) dtJurnalD.NewRow();
                    if (uraianDetail =="")
                    {
                        uraianDetail = drDetail["Uraian"].ToString();                        
                    }
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid (drDetail["RowID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID =drDetail["RecordID"].ToString() + 'K';
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = drDetail["NoPerkiraan"].ToString();
                    string dUraian = drDetail["Uraian"].ToString();
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "D";
                    double dJumlah =double.Parse( drDetail["Jumlah"].ToString()); 
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;
                    
                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (created)
                {
                    if (uraianDetail != "")
                    {
                        hUraian = uraianDetail;
                    }
                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = RowIDH;
                    string lRecordID = Tools.CreateFingerPrint(GlobalVar.CabangID, SecurityManager.UserInitial);
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = 0;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID,lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;
                    //Update field Uraian on Header
                }
                //INSERT JOURNAL HEADER 
                DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);
                

                prgBKK.Value++;
                this.RefreshForm();
            }

        }
        #endregion

        #region LinkBKM
        private void LinkBKM(Database db)
        {
            string src = "BKM";
            string kodeTrnLawan = "KAS";
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN
            DataRow drLawan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrnLawan).Rows[0];

            DataTable dtHeader = new DataTable();
            dtHeader = BKM.ListHeader(db, tglProses, tglProses, GlobalVar.PerusahaanID);

            prgBKM.Maximum = dtHeader.Rows.Count;
            prgBKM.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime)drHeader["TglBukti"];
                string hNoBukti = drHeader["NoBukti"].ToString();
                string hUraian = "KAS MASUK, NO.BUKTI : " + hNoBukti;
                string _src = drHeader["Src"].ToString();
                string bookRecordID = Tools.CreateFingerPrint(GlobalVar.CabangID, SecurityManager.UserInitial); 


                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = BKM.ListDetail(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    if (uraianDetail == "")
                    {
                        uraianDetail = drDetail["Uraian"].ToString();
                    }
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["RowID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["RecordID"].ToString() + 'M';

                    string LastStringRecord = "";
                    int LenRecordID = drDetail["RecordID"].ToString().Length;
                    if (LenRecordID > 0)
                        LastStringRecord = drDetail["RecordID"].ToString().Substring(LenRecordID - 1, 1);

                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = "";
                    if (_src == "PJT")
                    {
                        string wilID = drHeader["WilID"].ToString();
                        if (LastStringRecord == "1")
                            dNoPerkiraan = drDetail["NoPerkiraan"].ToString();
                        else if (wilID != "")
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("COL" + wilID.Substring(0, 1)).Rows[0]["NoPerkiraan"].ToString();
                    }
                    else
                        dNoPerkiraan = drDetail["NoPerkiraan"].ToString();
                    
                    string dUraian = drDetail["Uraian"].ToString();
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "K";
                    double dJumlah = double.Parse(drDetail["Jumlah"].ToString());
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = bookRecordID;
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = totalD;
                    string lDK = "D";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID,lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);
                }
                prgBKM.Value++;
                this.RefreshForm();
            }

        }
        #endregion

        #region LinkBBB
        private void LinkBBB(Database db)
        {

            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN            

            DataTable dt = new DataTable();
            dt = Bank.ListDetailByTglBank(db, tglProses, tglProses, GlobalVar.PerusahaanID);

            prgBBB.Maximum = dt.Rows.Count;
            prgBBB.Value = 0;

            foreach (DataRow dr in dt.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(dr["RowID"].ToString());
                string hRecordID = dr["RecordID"].ToString();
                string hSrc = double.Parse(dr["Debet"].ToString()) > 0 ? "BBM" : "BBK";
                DateTime hTglBukti = (DateTime)dr["TglBank"];
                string hNoBukti = dr["NoBBK"].ToString();
                string hUraian = dr["Keterangan"].ToString();
                double totalD = 0;
                double totalK = 0;
                bool created = false;


                //if (hRecordID.Length == 22 || (hRecordID.Length == 23 && hRecordID.Substring(22, 1) != "G"))
                if (hRecordID.Length<=22 || (hRecordID.Length==23 && hRecordID.Substring(22, 1) != "G"))
                {
                    //INSERT JOURNAL DETAIL
                    totalD = 0;
                    totalK = 0;
                    created = false;


                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = Guid.NewGuid();
                    Guid dHeaderID = hRowID;
                    string dRecordID = hRecordID.Substring(0, 20) + "1";
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = ("BBM").Contains(dr["JnsTran"].ToString()) ? dr["BankNoPerkiraan"].ToString() : dr["NoPerkiraan"].ToString();
                    string dUraian = (double.Parse(dr["Debet"].ToString()) > 0 ? dr["NoBGCH"].ToString() + ", " : "") + dr["Keterangan"].ToString();
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "D";
                    double dJumlah = double.Parse(dr["Debet"].ToString()) + double.Parse(dr["Kredit"].ToString());
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD, dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (created)
                {
                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID.Substring(0, 20) + "2"; ;
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = ("BBM").Contains(dr["JnsTran"].ToString()) ? dr["NoPerkiraan"].ToString() : dr["BankNoPerkiraan"].ToString();
                    string lUraian =  (double.Parse( dr["Debet"].ToString()) > 0 ? dr["NoBGCH"].ToString() + ", " : "") + dr["Keterangan"].ToString() ;;
                    double lDebet = 0;
                    double lKredit = 0;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, hSrc, gudangID, false, totalD, totalK);

                }

                prgBBB.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkVPG
        private void LinkVPG(Database db)
        {
            string src = "VPG";            
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN 
            DataRow drSelf = Perkiraan.GetPerkiraanKoneksiDetail("BGTRM").Rows[0];
            

            DataTable dtHeader = new DataTable();
            dtHeader = VoucherJournal.ListHeader(db, tglProses, tglProses, "PG", GlobalVar.PerusahaanID);

            prgVPG.Maximum = dtHeader.Rows.Count;
            prgVPG.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime)drHeader["TglVoucher"];
                string hNoBukti = drHeader["NoVoucher"].ToString();
                string hUraian = drHeader["Uraian1"].ToString();
                string dNoPerkiraan = drSelf["NoPerkiraan"].ToString();

                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = Giro.ListByVoucherID(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    if (uraianDetail == "")
                    {
                        uraianDetail = drDetail["AsalGiro"].ToString();
                    }
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["GiroID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["GiroRecID"].ToString() + "D";
                    string dHRecordID = hRecordID;
                    
                    string dUraian = "Link VPG " +  hUraian;
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "D";
                    double dJumlah = double.Parse(drDetail["Nominal"].ToString());
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    DataRow drLawan;
                    if (hRecordID.Trim().Substring(hRecordID.Length - 1, 1) == "B")
                    {
                        drLawan = Perkiraan.GetPerkiraanKoneksiDetail("BGTTP").Rows[0];
                    }
                    else
                    {
                        drLawan = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0];
                    }

                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "P";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = totalD;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);
                }
                


                prgVPG.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkVTG
        private void LinkVTG(Database db)
        {
            string src = "VTG";
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN
            DataRow drSelf = Perkiraan.GetPerkiraanKoneksiDetail("BGTTP").Rows[0];


            DataTable dtHeader = new DataTable();
            dtHeader = VoucherJournal.ListHeader(db, tglProses, tglProses, "TT", GlobalVar.PerusahaanID);

            prgVTG.Maximum = dtHeader.Rows.Count;
            prgVTG.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime)drHeader["TglVoucher"];
                string hNoBukti = drHeader["NoVoucher"].ToString();
                string hUraian = drHeader["Uraian1"].ToString();

                


                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = Giro.ListByTitipID(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    if (uraianDetail == "")
                    {
                        uraianDetail = drDetail["AsalGiro"].ToString();
                    }
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["GiroID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["GiroRecID"].ToString() + 'T';
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = drSelf["NoPerkiraan"].ToString();//drDetail["NoPerkiraan"].ToString();
                    string dUraian = "Link TPG " + hUraian;
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "D";
                    double dJumlah = double.Parse(drDetail["Nominal"].ToString());
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    DataRow drLawan;
                    drLawan = Perkiraan.GetPerkiraanKoneksiDetail("BGTRM").Rows[0];

                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "K";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = totalD;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);
                }
                


                prgVTG.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkBBM
        private void LinkBBM(Database db)
        {
            string src = "BBM";
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN
            DataRow drSelf = Perkiraan.GetPerkiraanKoneksiDetail("BGTRM").Rows[0];


            DataTable dtHeader = new DataTable();
            dtHeader = BBM.List(db, tglProses, tglProses, GlobalVar.PerusahaanID);

            prgBBM.Maximum = dtHeader.Rows.Count;
            prgBBM.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString() + "C";
                DateTime hTglBukti = (DateTime)drHeader["TglBBM"];
                string hNoBukti = drHeader["NoBBM"].ToString();
                string hUraian = drHeader["NamaBank"].ToString();

                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = Giro.ListByBBMID(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    if (drDetail["CairTolak"].ToString() == "C")
                    {                       
                        dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                        if (uraianDetail == "")
                        {
                            uraianDetail = "Link VPG " + hUraian;
                        }
                        Guid RowIDD = Guid.NewGuid();
                        Guid dRowID = new Guid(drDetail["GiroID"].ToString());
                        Guid dHeaderID = hRowID;
                        string dRecordID = drDetail["GiroRecID"].ToString() + "O";
                        string dHRecordID = hRecordID;                        
                        string dNoPerkiraan = drDetail["MainPerkiraan"].ToString();
                        DataTable dtBank = Bank.List(db,drDetail["BankID"].ToString());
                        if (dtBank.Rows.Count > 0)
                        {
                            dNoPerkiraan = dtBank.Rows[0]["NoPerkiraan"].ToString();
                        }

                        string dUraian = drDetail["AsalGiro"].ToString();
                        double dDebet = 0;
                        double dKredit = 0;
                        string dDK = "D";
                        double dJumlah = double.Parse(drDetail["Nominal"].ToString());
                        if (dDK == "D")
                        {
                            dDebet = dJumlah;
                        }
                        else
                        {
                            dKredit = dJumlah;
                        }
                        totalD += dDebet;
                        totalK += dKredit;

                        InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                        created = true;
                    }
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    DataRow drLawan;
                    drLawan = Perkiraan.GetPerkiraanKoneksiDetail("BGTTP").Rows[0];

                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "L";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = totalD;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);

                }
                prgBBM.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkVGT
        private void LinkVGT(Database db)
        {
            string src = "VGT";
            string gudangID = lookupGudang1.GudangID;

            //GET PERKIRAAN LAWAN
            DataRow drSelf = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK").Rows[0];


            DataTable dtHeader = new DataTable();
            dtHeader = BBM.List(db, tglProses, tglProses, GlobalVar.PerusahaanID);

            prgVGT.Maximum = dtHeader.Rows.Count;
            prgVGT.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime)drHeader["TglBBM"];
                string hNoBukti = drHeader["NoBBM"].ToString();
                string hUraian = drHeader["NamaBank"].ToString();

                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = Giro.ListByBBMID(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    if (drDetail["CairTolak"].ToString() == "T")
                    {
                        dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                        if (uraianDetail == "")
                        {
                            uraianDetail = drDetail["AsalGiro"].ToString();
                        }
                        Guid RowIDD = Guid.NewGuid();
                        Guid dRowID = new Guid(drDetail["GiroID"].ToString());
                        Guid dHeaderID = hRowID;
                        string dRecordID = drDetail["GiroRecID"].ToString() + "L";
                        string dHRecordID = hRecordID;
                        //string dNoPerkiraan = drDetail["MainPerkiraan"].ToString();
                        
                        //DataTable dtBank = Bank.List(db, drDetail["BankID"].ToString());
                        //if (dtBank.Rows.Count > 0)
                        //{
                        //    dNoPerkiraan = dtBank.Rows[0]["NoPerkiraan"].ToString();
                        //}
                        string dNoPerkiraan = drSelf["NoPerkiraan"].ToString();
                        string dUraian = "Link VGT " + hUraian;
                        double dDebet = 0;
                        double dKredit = 0;
                        string dDK = "D";
                        double dJumlah = double.Parse(drDetail["Nominal"].ToString());
                        if (dDK == "D")
                        {
                            dDebet = dJumlah;
                        }
                        else
                        {
                            dKredit = dJumlah;
                        }
                        totalD += dDebet;
                        totalK += dKredit;

                        InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                        created = true;
                    }
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    DataRow drLawan;
                    drLawan = Perkiraan.GetPerkiraanKoneksiDetail("BGTTP").Rows[0];

                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "K";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = drLawan["NoPerkiraan"].ToString();
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = totalD;
                    string lDK = "K";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);

                }    
                prgVGT.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkVJU
        private void LinkVJU(Database db)
        {
            string src = "VJU";            
            string gudangID = lookupGudang1.GudangID;


            //DataRow drSelf = Perkiraan.GetPerkiraanKoneksiDetail("BGTRM").Rows[0];
            

            DataTable dtHeader = new DataTable();
            dtHeader = VoucherJournal.ListHeader(db, tglProses, tglProses, "UM", GlobalVar.PerusahaanID);

            prgVJU.Maximum = dtHeader.Rows.Count;
            prgVJU.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = new Guid(drHeader["RowID"].ToString());
                string hRecordID = drHeader["RecordID"].ToString();
                DateTime hTglBukti = (DateTime)drHeader["TglVoucher"];
                string hNoBukti = drHeader["NoVoucher"].ToString();
                string hUraian = drHeader["Uraian1"].ToString();

                //INSERT JOURNAL DETAIL
                string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA
                DataTable dtDetail = VoucherJournal.ListDetail(db, hRowID);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    uraianDetail = drDetail["Keterangan"].ToString();
                    if (uraianDetail == "")
                    {
                        uraianDetail = "Link VJU " + hUraian;
                    }
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["RowID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["RecordID"].ToString();
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = drDetail["NoPerkiraan"].ToString();
                    string dUraian = uraianDetail;
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "D";
                    double dJumlah = double.Parse(drDetail["Debet"].ToString());
                    if (dDK == "D")
                    {
                        dDebet = dJumlah;
                    }
                    else
                    {
                        dKredit = dJumlah;
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (uraianDetail != "")
                {
                    hUraian = uraianDetail;
                }
                if (created)
                {
                    DataTable dtLawan;
                    string bkkRecID = hRecordID.Substring(0, 22) + "1"; 
                    dtLawan = BKK.GetDetailByHRecordID(db, bkkRecID);
                    string lUraian="";
                    string lDK ="";;
                    if (dtLawan.Rows.Count > 0)
                    {
                        lDK = "K";
                        lUraian = dtLawan.Rows[0]["Uraian"].ToString();
                    }

                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "D";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = dtLawan.Rows[0]["NoPerkiraan"].ToString();
                    
                    double lDebet = 0;
                    double lKredit = totalD;
                    ;
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID,lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;
                }
                //INSERT JOURNAL HEADER 
                DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);


                prgVJU.Value++;
                this.RefreshForm();
            }
        }
        #endregion

        #region LinkIND
        private void LinkIND(Database db)
        {
            string src = "IND";
            string gudangID = lookupGudang1.GudangID;

                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = Guid.NewGuid();
                string hRecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial) ;
                DateTime hTglBukti = tglProses;
                string hNoBukti ="IND" + tglProses.ToString("yyyy/MM/dd");
                string hUraian = "IDENTIFIKASI PEMBAYARAN";

                //INSERT JOURNAL DETAIL
               // string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA


                //DataTable dtDetail = Inden.ListSuperDetailByKodeRec(db, tglProses, tglProses, label3.Text);

                DataTable dtDetail = Inden.ListSuperDetailByKodeRec(db, tglProses, tglProses, GlobalVar.PerusahaanID);
                prgIND.Maximum = dtDetail.Rows.Count;
                prgIND.Value = 0;
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    //if (uraianDetail == "")
                    //{
                    //    uraianDetail = drDetail["Uraian"].ToString();
                    //}
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["RowID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["RecordID"].ToString();
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = "";
                    //string dNoPerkiraan = drDetail["NoPerk"].ToString();

                        //switch  (drDetail["Src"].ToString())
                        //{
                        //    case "KP":
                        //            if (drDetail["WilID"].ToString().Trim() != "")
                        //            {
                        //                string kodeTrn = "COL" + drDetail["WilID"].ToString().Substring(0, 1);                                                    
                        //                dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();
                        //            }
                        //            break;
                        //    case "GT":
                        //            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK").Rows[0]["NoPerkiraan"].ToString();
                        //            break;
                        //    default:
                        //            dNoPerkiraan = drDetail["NoPerk"].ToString();
                        //            break;
                        //}

                    //if (drDetail["KodeToko"].ToString() != "")
                    //{
                    //    if (drDetail["WilID"].ToString().Trim() == "")
                    //    {
                    //        created = false;
                    //        MessageBox.Show("Toko : " + drDetail["NamaToko"].ToString() + ", tidak memiliki WilID !");
                    //        return;
                    //    }
                    //    if (drDetail["KPID"].ToString().Trim() == "") //NonNota
                    //        dNoPerkiraan = "719999110";
                    //    else
                    //        dNoPerkiraan = drDetail["NoPerk"].ToString();
                    //}
                    //else //NonPiutang
                    //{
                    //    dNoPerkiraan = "210310200"; 
                    //}

                    switch (drDetail["Src"].ToString())
                    {
                        case "KP":
                            if (drDetail["WilID"].ToString().Trim() != "")
                            {
                                string kodeTrn = "COL" + drDetail["WilID"].ToString().Substring(0, 1);
                                //MessageBox.Show(kodeTrn+"==>"+Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString());          
                                dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();
                            }
                            break;
                        case "GT":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        case "DT":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("DT").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        case "NP":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        default:
                            dNoPerkiraan = drDetail["NoPerk"].ToString();
                            break;
                    }

                        //if (drDetail["KPRecID"].ToString().Trim().Length > 19)
                        //{
                        //    string kodeTrn = "COL" + drDetail["WilID"].ToString().Substring(0, 1);
                        //    dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();
                        //}
                        //else
                        //{
                        //    dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK").Rows[0]["NoPerkiraan"].ToString();
                        //}                    
                    string dUraian = drDetail["NamaToko"].ToString() + " /" + drDetail["WilID"].ToString() + drDetail["NoNota"].ToString();
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "K";
                    double dJumlah = double.Parse(drDetail["RpInden"].ToString());
                    if (dDK == "K")
                    {
                        dKredit = dJumlah;
                    }
                    else
                    {
                        dDebet = dJumlah;
                        
                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD,dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                //if (uraianDetail != "")
                //{
                //    hUraian = uraianDetail;
                //}
                if (created)
                {
                    DataRow dtLawan;
                    string perkLawan;
                    dtLawan = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0];
                    perkLawan = dtLawan["NoPerkiraan"].ToString();


                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "D";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = perkLawan;
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = 0;
                    string lDK = "D";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                //INSERT JOURNAL HEADER 
                DataRow newHeader = InsertJournalHeader(RowIDH, hRowID, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);


                prgIND.Value++;
                this.RefreshForm();
            }
                prgIND.Value = prgIND.Maximum;
        }
        #endregion

        #region LinkIND_v2
        private void LinkINDV2(Database db)
        {
            string src = "IND";
            string gudangID = lookupGudang1.GudangID;

            DataTable dtHeader = Inden.ListIndenByTgl(db, tglProses, tglProses, label3.Text);
            prgIND.Maximum = dtHeader.Rows.Count;
            prgIND.Value = 0;

            foreach (DataRow drHeader in dtHeader.Rows)
            {
                Guid RowIDH = Guid.NewGuid();
                Guid hRowID = Guid.NewGuid();

                Guid hRowIDIden = new Guid(drHeader["RowID"].ToString());

                string hRecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                DateTime hTglBukti = tglProses;
                string hNoBukti = drHeader["NoBukti"].ToString() + " | " + tglProses.ToString("yyyy/MM/dd");
                string hUraian = "IDENTIFIKASI PEMBAYARAN " + drHeader["NoBukti"].ToString();
                //INSERT JOURNAL DETAIL
                // string uraianDetail = "";
                double totalD = 0;
                double totalK = 0;
                bool created = false;

                //GET DETAIL DATA

                DataTable dtDetail = Inden.ListSuperDetailbyIndenID(db, hRowIDIden);
                foreach (DataRow drDetail in dtDetail.Rows)
                {
                    dsJurnal.JournalDetailRow dnewRow = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
                    //if (uraianDetail == "")
                    //{
                    //    uraianDetail = drDetail["Uraian"].ToString();
                    //}
                    Guid RowIDD = Guid.NewGuid();
                    Guid dRowID = new Guid(drDetail["RowID"].ToString());
                    Guid dHeaderID = hRowID;
                    string dRecordID = drDetail["RecordID"].ToString();
                    string dHRecordID = hRecordID;
                    string dNoPerkiraan = "";
                    //string dNoPerkiraan = drDetail["NoPerk"].ToString();

                    switch (drDetail["Src"].ToString())
                    {
                        case "KP":
                            if (drDetail["WilID"].ToString().Trim() != "")
                            {
                                string kodeTrn = "COL" + drDetail["WilID"].ToString().Substring(0, 1);
                                //MessageBox.Show(kodeTrn+"==>"+Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString());          
                                dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();
                            }
                            break;
                        case "GT":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("BGTLK").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        case "DT":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("DT").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        case "NP":
                            dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail("HI11").Rows[0]["NoPerkiraan"].ToString();
                            break;
                        default:
                            dNoPerkiraan = drDetail["NoPerk"].ToString();
                            break;
                    }

                    string dUraian = drDetail["NamaToko"].ToString() + " | " + drDetail["WilID"].ToString() + " | " + drDetail["NoNota"].ToString();
                    double dDebet = 0;
                    double dKredit = 0;
                    string dDK = "K";
                    double dJumlah = double.Parse(drDetail["RpInden"].ToString());
                    if (dDK == "K")
                    {
                        dKredit = dJumlah;
                    }
                    else
                    {
                        dDebet = dJumlah;

                    }
                    totalD += dDebet;
                    totalK += dKredit;

                    InsertJournalDetail(RowIDD, dRowID, RowIDH, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                    created = true;
                }
                if (created)
                {
                    DataRow dtLawan;
                    string perkLawan;
                    dtLawan = Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0];
                    perkLawan = dtLawan["NoPerkiraan"].ToString();


                    //INSERT PERKIRAAN LAWAN
                    Guid lRowID = Guid.NewGuid();
                    Guid lHeaderID = hRowID;
                    string lRecordID = hRecordID + "D";
                    string lHRecordID = hRecordID;
                    string lNoPerkiraan = perkLawan;
                    string lUraian = hUraian;
                    double lDebet = 0;
                    double lKredit = 0;
                    string lDK = "D";
                    if (lDK == "D")
                    {
                        lDebet = totalK;
                    }
                    else
                    {
                        lKredit = totalD;
                    }
                    InsertJournalDetail(lRowID, lRowID, RowIDH, lRecordID, lHRecordID, lNoPerkiraan, lUraian, lDebet, lKredit, lDK);
                    totalD += lDebet;
                    totalK += lKredit;

                    //INSERT JOURNAL HEADER 
                    DataRow newHeader = InsertJournalHeader(RowIDH, hRowIDIden, hRecordID, hTglBukti, hNoBukti, hUraian, src, gudangID, false, totalD, totalK);


                    prgIND.Value++;
                    this.RefreshForm();
                }
            }
            prgIND.Value = prgIND.Maximum;
        }
        #endregion

        private void frmLinkKeGL_Load(object sender, EventArgs e)
        {
            SetControls();
            tipeJurnaliden = AppSetting.GetValue("JurnalIden");
        }

        private void SetControls()
        {
            txtTglProses.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lookupGudang1.GudangID = GlobalVar.Gudang;
            label3.Text = GlobalVar.PerusahaanID;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = chkAll.Checked;
                }
            }
        }

        private void lookupGudang1_SelectData(object sender, EventArgs e)
        {
            string kode = lookupGudang1.GudangID;
            string cabang = lookupGudang1.InitPerusahaan;
            label3.Text = cabang;
            label3.Visible = true;
        }
       
    }
}
