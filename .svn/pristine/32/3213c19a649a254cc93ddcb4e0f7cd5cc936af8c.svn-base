using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Class
{
    class Perkiraan
    {
        public static DataTable GetPerkiraan(string noPerkiraan)
        {
            DataTable dtResult;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, noPerkiraan));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count == 0)
            {
                throw new Exception(string.Format(Messages.Error.DataNotValid, " Perkiraan " + noPerkiraan));
            }
            return dtResult;
        }


        public static DataTable GetPerkiraanKoneksiDetail(string kodeTrn)
        {
            DataTable dtResult;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeTrn", SqlDbType.VarChar, kodeTrn));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count == 0)
            {
                throw new Exception(string.Format(Messages.Error.DataNotValid, " Perkiraan Koneksi " + kodeTrn));
            }
            return dtResult;
        }

        public static DataTable GetNoPerkiraanKlpBarang(string klpBarang)
        {
            DataTable dtResult;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));

                db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, klpBarang));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count == 0)
            {
                throw new Exception(string.Format(Messages.Error.DataNotValid, " Kelompok Barang " + klpBarang));
            }
            return dtResult;

        }

    }
}
