using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.Common;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance.Class
{
    class DKN
    {
        static string _recordID;
        static string _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

        static Guid _rowID;
        public static void DKNInsert(Database db, Guid RowID, string RecordID, string DK, string refTipe, string CD, string src, DateTime tglBukti, string cabang, string refNoBukti, Guid refRowIDHeader)
        {
            string _noDKN = "";
            if (DK == "D")
                _noDKN = numeratorDKN(DK, cabang);
            else
                _noDKN = "";
            
            db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_DKN_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tglBukti));
                db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, _noDKN));
                db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, DK));
                db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, CD));
                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabang));
                db.Commands[0].Parameters.Add(new Parameter("@RefTipe", SqlDbType.VarChar, refTipe));
                db.Commands[0].Parameters.Add(new Parameter("@RefNoBukti", SqlDbType.VarChar, refNoBukti));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDHeader));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            
        }
               
        public static void DKNDetailInsert(Database db, Guid RowID, Guid HeaderID, string HRecordID, string noPerkiraan, string uraian, double jumlah, 
            Guid refRowIDDetail, string refRecordIDDetail, string KodeKolektor, string BankIDtujuan, Guid rowIDBanktujuan, Guid rowIDBankAsal, string kodetoko)
        {
             
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_DKNDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, jumlah));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, refRecordIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@KodeKolektor", SqlDbType.VarChar, KodeKolektor));
            db.Commands[0].Parameters.Add(new Parameter("@BankIDTujuan", SqlDbType.VarChar, BankIDtujuan));
            db.Commands[0].Parameters.Add(new Parameter("@BankTujuanRowID", SqlDbType.UniqueIdentifier, rowIDBanktujuan));
            db.Commands[0].Parameters.Add(new Parameter("@BankKotaRowID", SqlDbType.UniqueIdentifier, rowIDBankAsal));
            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
            db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, ""));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();

        }

        public static void HIInsert(Database db, Guid RowID, string RecordID, string DK, string refTipe, string CD, string src, DateTime tglBukti, string cabang, string refNoBukti, Guid refRowIDHeader)
        {
            //string _noDKN = numeratorDKN(DK, cabang);
            string _noDKN = "None";

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tglBukti));
            db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, _noDKN));
            db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, DK));
            db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, CD));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
            db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabang));
            db.Commands[0].Parameters.Add(new Parameter("@RefTipe", SqlDbType.VarChar, refTipe));
            db.Commands[0].Parameters.Add(new Parameter("@RefNoBukti", SqlDbType.VarChar, refNoBukti));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDHeader));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();

        }

        public static void HIDetailInsert(Database db, Guid HeaderID, string HRecordID, string noPerkiraan, string uraian, double jumlah,
            Guid refRowIDDetail, string refRecordIDDetail)
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_DETAIL_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, refRecordIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, jumlah));
            db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, ""));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();

        }

        public static string numeratorDKN(string DK, string cabang)
        {
            string _noDKN=string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "DKN"));
                dt = db.Commands[0].ExecuteDataTable();
            }

            string nomor = dt.Rows[0]["Nomor"].ToString();

            nomor = nomor.PadLeft(3, '0');
            if (DK=="K")
            {
                _noDKN = nomor.Substring(0, 3) + "KN" + GlobalVar.CabangID.Substring(0, 2) + cabang.Substring(0, 2);
            }
            else
            {
                _noDKN = nomor.ToString().Substring(0, 3) + "DN" + GlobalVar.CabangID.Substring(0, 2) + cabang.Substring(0, 2);
            }
            return _noDKN;
        }

        public static DataTable CekLinkDKN(Guid RefRowID, string Cabang)
        {
            DataTable dtCek = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKN_LinkCek"));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Cabang));
                dtCek = db.Commands[0].ExecuteDataTable();
            }
            return dtCek;
        }

        public static DataTable CekLinkDKNDetail(Guid RefRowID)
        {
            DataTable dtCek = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKNDetail_LinkCek"));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
                dtCek = db.Commands[0].ExecuteDataTable();
            }
            return dtCek;
        }

        public static void UnlinkDKN(Database db, Guid RefRowID)
        {
            db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_DKNDetail_Unlink"));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, RefRowID));
                db.Commands[0].ExecuteNonQuery();
            
        }

        public static void UpdateKodeLink(Database db,Guid RowID, string kode, string namaSP, string noPerkiraan)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand(namaSP));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, kode));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if(noPerkiraan!="")
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));

            db.Commands[0].ExecuteNonQuery();
        }

        
    }
}
