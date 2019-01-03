using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Finance.Class
{
    class Inden
    {
        public static DataTable ListDetail(Database db, DateTime fromDate, DateTime toDate)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListSuperDetailByKodeRec(Database db, DateTime fromDate, DateTime toDate, string cabang)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST_ByDate_KodeRec"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@kodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }
        public static DataTable ListSuperDetail(Database db, string headerID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.VarChar, headerID));            
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }


        public static DataTable CekRelasiInden(string namaTable, string namaField, string IndenID, string chbg, string bankID)
        {
            DataTable dtCekRelasi = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CekRelasiInden"));
                db.Commands[0].Parameters.Add(new Parameter("@namaTable", SqlDbType.VarChar, namaTable));
                db.Commands[0].Parameters.Add(new Parameter("@namaField", SqlDbType.VarChar, namaField));
                db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.VarChar, IndenID));
                if (chbg != "")
                    db.Commands[0].Parameters.Add(new Parameter("@chbg", SqlDbType.VarChar, chbg));

                if (bankID != "")
                    db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, bankID));

                
                dtCekRelasi = db.Commands[0].ExecuteDataTable();
            }
            return dtCekRelasi;
        }

        public static DataTable ListRowInden(Database db, Guid RowID)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Inden_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListRowIndenDetail(Database db, Guid RowID)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListRowIndenSubDetail(Database db, Guid RowID)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSubDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListRowIndenSuperDetail(Database db, Guid RowID)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable Listjurnalindenmasihselisih(Database db, DateTime TglInden)
        {
            DataTable dtResult = new DataTable();
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_cekIndenjuranl_byTglInden"));
            db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, TglInden));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListIndenByTgl(Database db, DateTime fromDate, DateTime toDate, string cabang)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST_PostingJurnalV2"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@kodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListSuperDetailbyIndenID(Database db, Guid IndenID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_LIST_ByIndenID"));
            db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, IndenID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }
    }
}
