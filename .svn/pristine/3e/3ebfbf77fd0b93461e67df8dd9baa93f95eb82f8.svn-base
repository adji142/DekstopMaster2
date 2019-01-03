using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Finance
{
    static class Numerator
    {
        
        public static string GetNumerator(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + String.Format("{0:0000}",dt.Rows[0]["Nomor"]).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd();
            return result;
        }

        public static string GetNextNumerator(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + String.Format("{0:0000}",(Convert.ToInt32(dt.Rows[0]["Nomor"])+1)).TrimEnd()+ "/" + (DateTime.Now.Month.ToString().TrimEnd() + "/" + (DateTime.Now.Year.ToString().TrimEnd()));
            return result;
        }

        public static string BookNumerator(string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + String.Format("{0:0000}", dt.Rows[0]["Nomor"]).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd();
            return result;
        }

        public static string BookNumerator(string doc, DateTime? tgl)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + String.Format("{0:0000}", dt.Rows[0]["Nomor"]).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd();
            return SecurityManager.IsTax() ? BookNumeratorTax(doc, tgl) : result;
        }

        public static string BookNumeratorTax(string doc, DateTime? tgl)
        {
            string result = "";
            DataTable dt = new DataTable();
            DateTime Tanggal = (DateTime)tgl;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LastOfPeriode"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, Tanggal.Year.ToString() + Tanggal.Month.ToString().PadLeft(2, '0')));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0][0].ToString();
            return result;
        }

        public static string GetNumeratorPeriode(string doc)
        {
            string result;
            string periode = GlobalVar.DateOfServer.ToString("yyyyMM");

            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + periode + dt.Rows[0]["Nomor"].ToString().TrimEnd().PadLeft(4, '0');
            return result;
        }

        public static string NumeratorList (string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result =  dt.Rows[0]["Nomor"].ToString().TrimEnd();
            return result;
        }

        public static string BookDKNNumerator(string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + dt.Rows[0]["Nomor"].ToString().TrimEnd() + dt.Rows[0]["Belakang"].ToString().TrimEnd();
            return result;
        }

    }
}
