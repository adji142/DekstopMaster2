using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Class
{
    class Bank
    {
        public static DataTable List(Database db, string bankID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bank_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, bankID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListDetailByTglBank(Database db, DateTime fromDate, DateTime toDate)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BankDetail_LIST_ByTglBank"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListDetailByTglBank(Database db, DateTime fromDate, DateTime toDate, string cabang)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BankDetail_LIST_ByTglBank_KodeRec"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@KodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static void AddBankDetail(
            Database db,
            Guid RowID,
            Guid LinkBankID,
            string noBBK,
            string noBGCH,
            Guid HeaderID,
            string RegID,
            DateTime TglTran,
            string JnsTran,
            string Keterangan,
            string VTA,
            string Debet,
            string Kredit,
            DateTime TglBank,
            DateTime TglRK,
            string LinkRK,
            string Kode,
            string Sub,
            string Catatan,
            string NoPerkiraan,
            string bankID,
            string recordID
            )
        {
            
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BankDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@LinkTransferBankID", SqlDbType.UniqueIdentifier, LinkBankID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, bankID));
            db.Commands[0].Parameters.Add(new Parameter("@RegID", SqlDbType.VarChar, ""));
            db.Commands[0].Parameters.Add(new Parameter("@TglTran", SqlDbType.DateTime, TglTran));
            db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, noBBK));
            db.Commands[0].Parameters.Add(new Parameter("@JnsTran", SqlDbType.VarChar, JnsTran));
            db.Commands[0].Parameters.Add(new Parameter("@NoBGCH", SqlDbType.VarChar, noBGCH));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, VTA));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Kredit));
            db.Commands[0].Parameters.Add(new Parameter("@TglBank", SqlDbType.DateTime, TglBank));
            db.Commands[0].Parameters.Add(new Parameter("@TglRK", SqlDbType.DateTime, TglRK));
            db.Commands[0].Parameters.Add(new Parameter("@LinkRK", SqlDbType.VarChar, LinkRK));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Sub));
            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Catatan));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));


            db.Commands.Add(db.CreateCommand("usp_Bank_UPDATE"));
            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


            db.Commands[0].ExecuteNonQuery();
            db.Commands[1].ExecuteNonQuery();

        }

        public static void addBank(
            Database db,
            Guid RowID,
            string _BankID,
            string jenisRek,
            string namaBank,
            string namaAccount,
            string noAccount,
            string alamat1,
            string alamat2,
            string kota,
            string telepon,
            string cusService,
            string noGiro,
            string noCheque,
            string noBBK,
            string VTA,
            string saldo,
            string limit,
            DateTime tglRek,
            string kode,
            string sub,
            string mainTitip,
            string subTitip,
            string noPerk,
            string mainPerk
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bank_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, _BankID));
            db.Commands[0].Parameters.Add(new Parameter("@JRek", SqlDbType.VarChar, jenisRek));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, namaBank));
            db.Commands[0].Parameters.Add(new Parameter("@NamaAccount", SqlDbType.VarChar, namaAccount));
            db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, noAccount));
            db.Commands[0].Parameters.Add(new Parameter("@Alamat1", SqlDbType.VarChar, alamat1));
            db.Commands[0].Parameters.Add(new Parameter("@Alamat2", SqlDbType.VarChar, alamat2));
            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, kota));
            db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, telepon));
            db.Commands[0].Parameters.Add(new Parameter("@CService", SqlDbType.VarChar, cusService));
            db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, noGiro));
            db.Commands[0].Parameters.Add(new Parameter("@NoCheck", SqlDbType.VarChar, noCheque));
            db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, noBBK));
            db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, VTA));
            db.Commands[0].Parameters.Add(new Parameter("@Saldo", SqlDbType.Money, saldo));
            db.Commands[0].Parameters.Add(new Parameter("@Limit", SqlDbType.Money, limit));
            db.Commands[0].Parameters.Add(new Parameter("@TglRek", SqlDbType.DateTime, tglRek));
            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, saldo));
            db.Commands[0].Parameters.Add(new Parameter("@SaldoAkhir", SqlDbType.Money, 0));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, sub));
            db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, mainTitip));
            db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, subTitip));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerk));
            db.Commands[0].Parameters.Add(new Parameter("@MainPerkiraan", SqlDbType.VarChar, mainPerk));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }


        public static void DeleteBankDetail(
            Database db,
            Guid rowIDDetail,
            Guid headerIDBank1,
            Guid LinkTransferBankID,
            string noBGCH,
            string noBBK
        )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, headerIDBank1));
            db.Commands[0].Parameters.Add(new Parameter("@LinkTransferBankID", SqlDbType.UniqueIdentifier, LinkTransferBankID));
            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, noBGCH));
            db.Commands[0].Parameters.Add(new Parameter("@noBBK", SqlDbType.VarChar, noBBK));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
            
            db.Commands[0].ExecuteNonQuery();
        }
    }

}
