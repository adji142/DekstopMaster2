using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Toko;
using System.Data.SqlTypes;

namespace ISA.Toko.Class
{
    class BBK
    {

        public static DataTable ListBBK(Database db, DateTime fromDate, DateTime toDate, Guid RowIDBBK)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBK_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate.Year <= 1900 ? SqlDateTime.Null : fromDate ));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate.Year <= 1900 ? SqlDateTime.Null : toDate));
            db.Commands[0].Parameters.Add(new Parameter("@RowIDBBK", SqlDbType.UniqueIdentifier, RowIDBBK)); 
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListBBK(Database db, Guid RowIDBBK)
        {

            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBK_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@RowIDBBK", SqlDbType.UniqueIdentifier, RowIDBBK));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static void AddBBK(
            Database db,
            Guid RowID,
            string RecordID,
            DateTime TglBBK,
            string NoBBK,
            string BankID,
            string Dibukukan,
            string Diketahui,            
            string Penerima,
            double RpGiro,
            double RpCair,
            double RpTolak
            )
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBK_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@TglBBK", SqlDbType.DateTime, TglBBK));
            db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, NoBBK));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Dibukukan));
            db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Diketahui));
            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Penerima));
            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.VarChar, RpGiro));
            db.Commands[0].Parameters.Add(new Parameter("@RpCair", SqlDbType.VarChar, RpCair));
            db.Commands[0].Parameters.Add(new Parameter("@RpTolak", SqlDbType.VarChar, RpTolak));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            

            db.Commands[0].ExecuteNonQuery();

        }
        public static void DeleteBBK(Database db, Guid RowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBK_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].ExecuteNonQuery();
        }
       
    }
}
