using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Toko;

namespace ISA.Toko.Class
{
    class Giro
    {
        public static DataTable List(Database db, Guid giroID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Giro_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, giroID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListByVoucherID(Database db, Guid voucherID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Giro_LIST_ByVoucherID"));
            db.Commands[0].Parameters.Add(new Parameter("@VoucherID", SqlDbType.UniqueIdentifier, voucherID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListByTitipID(Database db, Guid titipID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_GIRO_LIST_ByVoucherID"));
            db.Commands[0].Parameters.Add(new Parameter("@titipID", SqlDbType.UniqueIdentifier, titipID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }
        public static DataTable ListByBBMID(Database db, Guid BBMID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Giro_LIST_ByVoucherID"));
            db.Commands[0].Parameters.Add(new Parameter("@BBMID", SqlDbType.UniqueIdentifier, BBMID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListLookupVoucherGiroTitip(Database db)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Lookup_GIRO_Voucher_Titip"));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static void Add(
            Database db,
            Guid giroID,
            Guid voucherID,
            Guid BBMID,
            Guid titipID,
            string voucherRecID,
            string bbmRecID,
            string titipRecID,
            string giroRecID,
            string kodeToko,
            string namaBank,
            string lokasi,
            string chBG,
            string nomor,
            DateTime tglGiro,
            DateTime tglJth,
            double nominal,
            string CairTolak,
            object tglCair,
            string mainTitip,
            string subTitip,
            string mainPiutang,
            string subPiutang,
            string bankID,
            string namaBanki,
            string noPerkiraan,
            object tglTitip,
            bool syncFlag,
            string noAcc,
            string mainPerkiraan
     )
        {

            //Guid rowid = Guid.NewGuid(); 

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Giro_INSERT"));

            db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, giroID));
            db.Commands[0].Parameters.Add(new Parameter("@VoucherID", SqlDbType.UniqueIdentifier, voucherID));
            db.Commands[0].Parameters.Add(new Parameter("@BBMID", SqlDbType.UniqueIdentifier, BBMID));
            db.Commands[0].Parameters.Add(new Parameter("@TitipID", SqlDbType.UniqueIdentifier, titipID));
            db.Commands[0].Parameters.Add(new Parameter("@VoucherRecID", SqlDbType.VarChar, voucherRecID));
            db.Commands[0].Parameters.Add(new Parameter("@BBMRecID", SqlDbType.VarChar, bbmRecID));
            db.Commands[0].Parameters.Add(new Parameter("@TitipRecID", SqlDbType.VarChar, titipRecID));
            db.Commands[0].Parameters.Add(new Parameter("@GiroRecID", SqlDbType.VarChar, giroRecID));
            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, namaBank));
            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lokasi));
            db.Commands[0].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, chBG));
            db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, nomor));
            db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, tglGiro));
            db.Commands[0].Parameters.Add(new Parameter("@TglJth", SqlDbType.DateTime, tglJth));
            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nominal));
            db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, CairTolak));
            db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, tglCair));
            db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, mainTitip));
            db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, subTitip));
            db.Commands[0].Parameters.Add(new Parameter("@MainPiutang", SqlDbType.VarChar, mainPiutang));
            db.Commands[0].Parameters.Add(new Parameter("@SubPiutang", SqlDbType.VarChar, subPiutang));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, bankID));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBanki", SqlDbType.VarChar, namaBanki));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@TglTitip", SqlDbType.DateTime, tglTitip));

            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, syncFlag));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noAcc));
            db.Commands[0].Parameters.Add(new Parameter("@MainPerkiraan", SqlDbType.VarChar, mainPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[0].ExecuteNonQuery();

        }

        public static string CekGiro_CairTolak(Guid GiroID)
        {
            string cairTolak = "";
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("fsp_CekGiro_CairTolak"));
                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, GiroID));
                cairTolak = db.Commands[0].ExecuteScalar().ToString();
            }
            return cairTolak;
        }

        public static DataTable CekGiro_Voucher_Titip(Guid GiroID)
        {
            DataTable dtGiro;
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("fsp_CekGiro_Voucher_titip"));
                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, GiroID));
                dtGiro = db.Commands[0].ExecuteDataTable();
            }
            return dtGiro;
        }
    }
}
