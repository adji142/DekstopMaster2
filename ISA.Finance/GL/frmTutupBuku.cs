using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using ISA.Finance;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.GL
{
    public partial class frmTutupBuku : ISA.Finance.BaseForm
    {
        DateTime tglProses;
        string periode;
        string kodeGudang;
        DataTable dtClosingGL = new DataTable();

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();
        public frmTutupBuku()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (InputIsValid())
            {     
                GetSaldoTutupBuku();
                DisplayExecuteForm();
            }
        }

        private bool InputIsValid()
        {
            bool valid = true;
            if (lookupGudang1.GudangID =="" || lookupGudang1.GudangID=="[CODE]")
            {
                valid = false;
                MessageBox.Show("Silahkan isi dulu Kode Gudang");
            }
            return valid;
        }

        private void frmTutupBuku_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            monthYearBox1.Month = DateTime.Now.Month;
            monthYearBox1.Year = DateTime.Now.Year;
        }

        private void GetSaldoTutupBuku()
        {
            DataTable dtTutupBuku;
            periode = monthYearBox1.Year.ToString().PadRight(4, '0') + monthYearBox1.Month.ToString().PadLeft(2, '0');
            kodeGudang = lookupGudang1.GudangID;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                dtJurnalH.Rows.Clear();
                dtJurnalD.Rows.Clear();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_Get_GL_TutupBuku"));
                    db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, periode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    dtClosingGL = db.Commands[0].ExecuteDataTable();

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_GL_TutupBuku_GetSaldo"));
                    db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, periode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    dtTutupBuku = db.Commands[0].ExecuteDataTable();
                }

                DataTable noPerkLbB = Class.Perkiraan.GetPerkiraanKoneksiDetail("LBBLN");
                DataTable noPerkLbT = Class.Perkiraan.GetPerkiraanKoneksiDetail("LBTHN");
                DataTable noPerkLbDIT = Class.Perkiraan.GetPerkiraanKoneksiDetail("LBDIT");
                double lbBln = 0;

                //Construct CLS
                Guid jID = Guid.NewGuid();
                string jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                DateTime closingDate = new DateTime (monthYearBox1.Year, monthYearBox1.Month, 1).AddMonths(1).AddDays (-1);
                string noReff ="CLS-" + kodeGudang + "/" + closingDate.ToString("MM/yyyy");
                string uraian = "TUTUP BUKU";
                string src = "CLS";
                double tDebet =0;
                double tKredit = 0;
                double.TryParse( dtTutupBuku.Compute ("SUM(Debet)","").ToString(), out tDebet );
                double.TryParse( dtTutupBuku.Compute ("SUM(Kredit)","").ToString(), out tKredit );
                InsertJournalHeader(jID, jrecID, closingDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit); 

                foreach (DataRow dr in dtTutupBuku.Rows)
                {
                    Guid jdID = Guid.NewGuid();
                    string jdRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    InsertJournalDetail(jdID, jID, jdRecID, jrecID, dr["NoPerkiraan"].ToString(), dr["Uraian"].ToString(), Convert.ToDouble(dr["Debet"].ToString()), Convert.ToDouble(dr["Kredit"].ToString()), dr["DK"].ToString());
                    if (dr["NoPerkiraan"].ToString() == noPerkLbB.Rows[0]["NoPerkiraan"].ToString())
                    {
                        lbBln = Convert.ToDouble(dr["Debet"].ToString()) - Convert.ToDouble(dr["Kredit"].ToString());
                    }
                } 
               
                //Construct LBB
                
                
                jID = Guid.NewGuid();
                jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                DateTime lbbDate = closingDate.AddDays(1);
                noReff = lbbDate.ToString("yyyyMMdd" + "LBB" + kodeGudang);
                uraian = "Alokasi laba bulan berjalan " + lbbDate.ToString("dd-MMM-yyyy");
                src = "LBB";
                tDebet = lbBln;
                tKredit = lbBln;
                InsertJournalHeader(jID, jrecID, lbbDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit); 
                

                //INSERT LBBLN
                Guid lbblnID = Guid.NewGuid();
                string lbblnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                string lbblnDK = "D";
                double lbblnDebet = 0;
                double lbblnKredit = 0;

                if (lbBln >= 0)
                {
                    lbblnKredit = Math.Abs(lbBln);
                    lbblnDK = "K";
                }
                else
                {
                    lbblnDebet = Math.Abs(lbBln);
                    lbblnDK = "D";
                }
                InsertJournalDetail(lbblnID, jID, lbblnRecID, jrecID, noPerkLbB.Rows[0]["NoPerkiraan"].ToString(), noPerkLbB.Rows[0]["Uraian"].ToString(), lbblnDebet , lbblnKredit, lbblnDK);

                //INSERT LBTHN
                Guid lbthnID = Guid.NewGuid();
                string lbthnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                string lbthnDK = "D";
                double lbthnDebet = 0;
                double lbthnKredit = 0;

                if (lbBln >= 0)
                {
                    lbthnDebet = Math.Abs(lbBln);
                    lbthnDK = "D";
                }
                else
                {
                    lbthnKredit = Math.Abs(lbBln);
                    lbthnDK = "K";
                }
                InsertJournalDetail(lbthnID, jID, lbthnRecID, jrecID, noPerkLbT.Rows[0]["NoPerkiraan"].ToString(), noPerkLbT.Rows[0]["Uraian"].ToString(), lbthnDebet,lbthnKredit, lbthnDK);
                

                //CONSTRUCT LTB
                if (monthYearBox1.Month == 12)
                {
                    jID = Guid.NewGuid();
                    jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);    
                    noReff = lbbDate.ToString("yyyyMMdd" + "LTB" + kodeGudang);
                    uraian = "JB LABA - RUGI TAHUN " + monthYearBox1.Year.ToString();
                    src = "LTB";

                    DataRow[] findLbThn = dtClosingGL.Select("NoPerkiraan='" + noPerkLbT.Rows[0]["NoPerkiraan"].ToString() + "'");
                    double lbThn = 0;
                    if (findLbThn.Length > 0)
                    {
                        lbThn = Convert.ToDouble(findLbThn[0]["RpAkhir"].ToString()) + lbBln;
                    }
                    tDebet = lbThn;
                    tKredit = lbThn;
                    InsertJournalHeader(jID, jrecID, lbbDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit);

                    //INSERT LBTHN
                    Guid lbthnIDb = Guid.NewGuid();
                    string lbthnRecIDb = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    string lbThnDKb = "D";
                    double lbThnDebetb = 0;
                    double lbThnKreditb = 0;

                    if (lbThn >= 0)
                    {
                        lbThnKreditb = Math.Abs(lbThn);
                        lbThnDKb = "K";
                    }
                    else
                    {
                        lbThnDebetb = Math.Abs(lbThn);
                        lbThnDKb = "D";
                    }
                    InsertJournalDetail(lbthnIDb, jID, lbthnRecIDb, jrecID, noPerkLbT.Rows[0]["NoPerkiraan"].ToString(), noPerkLbT.Rows[0]["Uraian"].ToString(), lbThnDebetb, lbThnKreditb, lbThnDKb);

                    //INSERT LBDIT
                    Guid lbDitID = Guid.NewGuid();
                    string lbDitRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    string lbDitDK = "D";
                    double lbDitDebet = 0;
                    double lbDitKredit = 0;

                    if (lbThn >= 0)
                    {
                        lbDitDebet = Math.Abs(lbThn);
                        lbDitDK = "D";
                    }
                    else
                    {
                        lbDitKredit = Math.Abs(lbThn);
                        lbDitDK = "K";
                    }
                    InsertJournalDetail(lbDitID, jID, lbDitRecID, jrecID, noPerkLbDIT.Rows[0]["NoPerkiraan"].ToString(), noPerkLbDIT.Rows[0]["Uraian"].ToString(), lbDitDebet, lbDitKredit, lbDitDK);
                

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

        private void DisplayExecuteForm()
        {
            GL.frmTutupBukuExecute ifrmChild = new GL.frmTutupBukuExecute(periode, kodeGudang, dtClosingGL, dtJurnalH, dtJurnalD);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.ShowDialog();
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
    }
}
