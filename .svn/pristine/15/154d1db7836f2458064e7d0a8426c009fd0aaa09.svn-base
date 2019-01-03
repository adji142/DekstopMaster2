using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Class
{
    class Journal
    {
        public static DataTable GetHeader(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_LIST"));

            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));            
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_LIST_ByTanggal"));

            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate ));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));                        
            
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable GetDetail(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListDetail(Database db, Guid headerID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static void AddHeader(Database db, Guid rowID, string recordID, DateTime tanggal, string noReff,string uraian, string src, string kodeGudang, bool syncFlag)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, noReff));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void AddDetail(Database db, Guid rowID, Guid headerID, string recordID, string hrecordID, string noPerkiraan, string uraian, double debet, double kredit,string dk)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hrecordID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, kredit));
            db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, dk));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));            

            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdateHeader(Database db, Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_UPDATE"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, noReff));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void UpdateDetail(Database db, Guid rowID, Guid headerID, string recordID, string hrecordID, string noPerkiraan, string uraian, double debet, double kredit, string dk)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_UPDATE"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hrecordID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, kredit));
            db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, dk));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }


        public static void LinkHeader(Database db, Guid RefRowID, Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_LINK"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, noReff));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }
        public static void LinkHeaderDelete(Database db, Guid RefRowID, Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_LINK_DELETE"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, noReff));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void LinkDetail(Database db, Guid rowID, Guid RefRowID, Guid headerID, string recordID, string hrecordID, string noPerkiraan, string uraian, double debet, double kredit, string dk)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_LINK"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hrecordID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, kredit));
            db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, dk));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeleteHeader(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Journal_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].ExecuteNonQuery();
        }
        public static void DeleteDetail(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_JournalDetail_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static DataTable GetSubJournalHeader(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournal_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListSubJournalHeader(Database db, Guid journalDetailID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournal_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@JournalDetailID", SqlDbType.UniqueIdentifier, journalDetailID));            
            return db.Commands[0].ExecuteDataTable();
        }


        public static void AddSubJournalHeader(Database db, Guid rowID, string recordID, Guid journalDetailID, string journalDetailRecID, string partnerID, string keterangan)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournal_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@JournalDetailID", SqlDbType.UniqueIdentifier, journalDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@JournalDetailRecID", SqlDbType.VarChar, journalDetailRecID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdateSubJournalHeader(Database db, Guid rowID, string recordID, Guid journalDetailID, string journalDetailRecID, string partnerID, string keterangan)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournal_UPDATE"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@JournalDetailID", SqlDbType.UniqueIdentifier, journalDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@JournalDetailRecID", SqlDbType.VarChar, journalDetailRecID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeleteSubJournalHeader(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournal_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void ClearTutupBuku(Database db, string periode)
        {
            DateTime closeDate;
            DateTime lbbDate;
            lbbDate = new DateTime(Convert.ToInt32( periode.Substring(0, 4)), Convert.ToInt32( periode.Substring(4, 2)), 1).AddMonths(1);
            closeDate = lbbDate.AddDays(-1);

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("psp_GL_ClearTutupBuku"));
            db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, periode));
            db.Commands[0].ExecuteNonQuery();
        }

        public static DataTable GetSubJournalDetail(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournalDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListSubJournalDetail(Database db, Guid headerID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournalDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static void AddSubJournalDetail(Database db, Guid rowID, Guid headerID, string recordID, string hRecordID, string partnerID, string partnerNo, string NamaPartner, decimal persen, string currency, double amount)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournalDetail_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));            
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerNo));
            db.Commands[0].Parameters.Add(new Parameter("@NamaPartner", SqlDbType.VarChar, NamaPartner));
            db.Commands[0].Parameters.Add(new Parameter("@Persen", SqlDbType.Decimal, persen));
            db.Commands[0].Parameters.Add(new Parameter("@Currency", SqlDbType.VarChar, currency));
            db.Commands[0].Parameters.Add(new Parameter("@Amount", SqlDbType.Money, amount));            
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdateSubJournalDetail(Database db, Guid rowID, Guid headerID, string recordID, string hRecordID, string partnerID, string partnerNo, string NamaPartner, decimal persen, string currency, double amount)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournalDetail_UPDATE"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerNo));
            db.Commands[0].Parameters.Add(new Parameter("@NamaPartner", SqlDbType.VarChar, NamaPartner));
            db.Commands[0].Parameters.Add(new Parameter("@Persen", SqlDbType.Decimal, persen));
            db.Commands[0].Parameters.Add(new Parameter("@Currency", SqlDbType.VarChar, currency));
            db.Commands[0].Parameters.Add(new Parameter("@Amount", SqlDbType.Money, amount));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeleteSubJournalDetail(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_SubJournalDetail_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].ExecuteNonQuery();
        }


        public static DataTable GetPartner(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListPartner(Database db)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_LIST"));            
            return db.Commands[0].ExecuteDataTable();
        }


        public static void AddPartner(Database db, string partnerID, string uraian)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_INSERT"));            
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdatePartner(Database db, string partnerID, string uraian)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_UPDATE"));
            
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeletePartner(Database db, string partnerID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].ExecuteNonQuery();
        }


        public static DataTable GetPartnerDetail(Database db, Guid rowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PartnerDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            return db.Commands[0].ExecuteDataTable();
        }

        public static DataTable ListPartnerDetail(Database db, string partnerID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PartnerDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            return db.Commands[0].ExecuteDataTable();
        }


        public static void AddPartnerDetail(Database db, string partnerID, string partnerNo, string nama, bool statusAktif, string dstamp, string catatan)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PartnerDetail_INSERT"));
            
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerNo));
            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, nama));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.Bit, statusAktif));
            db.Commands[0].Parameters.Add(new Parameter("@DStamp", SqlDbType.VarChar, dstamp));
            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, catatan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdatePartnerDetail(Database db, string partnerID, string partnerNo, string nama, bool statusAktif, string dstamp, string catatan)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PartnerDetail_UPDATE"));
            
            db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerID));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerNo));
            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, nama));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.Bit, statusAktif));
            db.Commands[0].Parameters.Add(new Parameter("@DStamp", SqlDbType.VarChar, dstamp));
            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, catatan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeletePartnerDetail(Database db,  string partnerNo)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Partner_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerNo));
            db.Commands[0].ExecuteNonQuery();
        }

        public static DataTable CekInden(Guid refRowID)
        {
            DataTable dtCek = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Journal_CekInden"));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowID));
                dtCek = db.Commands[0].ExecuteDataTable();
            }
            return dtCek;
        }

    }
}
