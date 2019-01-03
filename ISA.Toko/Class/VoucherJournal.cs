using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Toko;

namespace ISA.Toko.Class
{
    class VoucherJournal
    {
        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate, string tipe)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournal_LIST_BYDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            if (tipe != "")
                db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, tipe));

            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate, string tipe, string cabang)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournal_LIST_BYDATE_KodeRec"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            if (tipe != "")
                db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, tipe));

            db.Commands[0].Parameters.Add(new Parameter("@KodeRec", SqlDbType.VarChar, cabang));


            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListRowHeader(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_VoucherJournal_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dtResult = db.Commands[0].ExecuteDataTable();
            }
            return dtResult;
        }

        public static DataTable ListDetail(Database db, Guid headerID)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournalDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListRowDetail(Guid RowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_VoucherJournalDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dtResult = db.Commands[0].ExecuteDataTable();
            }
            return dtResult;
        }

       public static void AddHeader(
           Database db, 
           Guid rowID, 
           Guid refRowID,
           string recordID, 
           string tipe, 
           DateTime tglVoucher, 
           string noVoucher, 
           string uraian1, 
           string uraian2, 
           string uraian3, 
           string dibuat, 
           string dibukukan, 
           string mengetahui, 
           string BankID, 
	       string NamaBank, 
	       int NPrint,  
           bool syncFlag
    )
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournal_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, tipe));
            db.Commands[0].Parameters.Add(new Parameter("@TglVoucher", SqlDbType.DateTime, tglVoucher));
            db.Commands[0].Parameters.Add(new Parameter("@NoVoucher", SqlDbType.VarChar, noVoucher));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian1", SqlDbType.VarChar, uraian1));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian2", SqlDbType.VarChar, uraian2));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian3", SqlDbType.VarChar, uraian3));
            db.Commands[0].Parameters.Add(new Parameter("@Dibuat", SqlDbType.VarChar, dibuat));
            db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, dibukukan));
            db.Commands[0].Parameters.Add(new Parameter("@Mengetahui", SqlDbType.VarChar, mengetahui));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, NamaBank));
            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, NPrint));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();

        }

        public static void AddDetail(
            Database db,
            Guid rowID,
            Guid headerID,
            string recordID,          
            string hRecordID,
            string kode,
            string sub,
            string voucherType,
            string voucherNo,
            string noPerkiraan,
            string keterangan,
            double debet,
            double kredit,
            bool syncFlag
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournalDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, hRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, sub));
            db.Commands[0].Parameters.Add(new Parameter("@VoucherType", SqlDbType.VarChar, voucherType));
            db.Commands[0].Parameters.Add(new Parameter("@VoucherNo", SqlDbType.VarChar, voucherNo));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, kredit));
            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void UpdateNPrint(Database db, Guid RowID, int nprint)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournal_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, nprint));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeleteVoucherJournal(Database db, Guid RowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_VoucherJournal_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].ExecuteNonQuery();
        }
    }
}
