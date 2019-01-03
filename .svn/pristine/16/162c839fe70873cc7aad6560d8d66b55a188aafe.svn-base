using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Toko.Class
{
    class PeriodeClosing
    {
        public static DateTime LastClosingHPP
        {
            get
            {
                DateTime result;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_GetLastClosingHPP"));
                    result = DateTime.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
                return result;
            }
        }

        public static DateTime LastClosingPJT
        {
            get
            {
                DateTime result;
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_GetLastClosingPJT"));
                    result = DateTime.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
                return result;
            }
        }

        public static DateTime LastClosingKasir
        {
            get
            {
                DateTime result;
                using (Database db = new Database("ISAFinance"))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_GetLastClosingKasir"));
                    result = DateTime.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
                return result;
            }
        }

        public static string LastClosingGL
        {
            get
            {
                string result;
                using (Database db = new Database("ISAFinance"))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_GetLastClosingGL"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    result = db.Commands[0].ExecuteScalar().ToString();
                }
                return result;
            }
        }

        public static bool IsHPPClosed(DateTime checkDatetime)
        {
            bool isClosed = false;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_IsClosingHPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, checkDatetime));
                    isClosed = bool.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return isClosed;
        }



        public static bool IsPJTClosed(DateTime checkDatetime)
        {
            bool isClosed = false;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_IsClosingPJT"));
                    db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, checkDatetime));
                    isClosed = bool.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return isClosed;
        }

        public static bool IsKasirClosed(DateTime checkDateTime)
        {
            bool isClosed = false;
            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_IsClosingKasir"));
                    db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, checkDateTime));
                    isClosed = bool.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return isClosed;
        }

        public static bool IsGLClosed(string checkPeriode, string kodeGudang)
        {
            bool isClosed = false;
            try
            {
                using (Database db = new Database("ISAFinance"))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("fsp_IsClosingGL"));
                    db.Commands[0].Parameters.Add(new Parameter("@checkPeriode", SqlDbType.VarChar, checkPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    isClosed = bool.Parse(db.Commands[0].ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return isClosed;
        }
    }
}
