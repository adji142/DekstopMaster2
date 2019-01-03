using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Finance.Class
{
    class BBM
    {
        public static void AddBBM(
            Database db,
            Guid RowID,
            string RecordID, 
            DateTime TglBBM, 
            string  NoBBM, 
            string BankID, 
            string Dibukukan, 
            string Diketahui, 
            string Kasir, 
            string Penyetor, 
            double RpGiro, 
            double RpCair, 
            double RpTolak  
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBM_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@TglBBM", SqlDbType.DateTime, TglBBM));
            db.Commands[0].Parameters.Add(new Parameter("@NoBBM", SqlDbType.VarChar, NoBBM));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Dibukukan));
            db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Diketahui));
            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Kasir));
            db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, Penyetor));
            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, RpGiro));
            db.Commands[0].Parameters.Add(new Parameter("@RpCair", SqlDbType.Money, RpCair));
            db.Commands[0].Parameters.Add(new Parameter("@RpTolak", SqlDbType.Money, RpTolak));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void UpdateBBM(
            Database db,
            Guid rowID,            
            string bankID,
            string diBukukan,
            string diKetahui,
            string penyetor
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBM_GiroTolakCair_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, bankID));
            db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, diBukukan));
            db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, diKetahui));  
            db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, penyetor));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static DataTable List(Database db, DateTime fromDate, DateTime toDate)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBM_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));            
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable List(Database db, DateTime fromDate, DateTime toDate, string cabang)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBM_LIST_KodeRec"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@KodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static void DeleteBBM(Database db, Guid RowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BBM_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].ExecuteNonQuery();
        }
    }
}
