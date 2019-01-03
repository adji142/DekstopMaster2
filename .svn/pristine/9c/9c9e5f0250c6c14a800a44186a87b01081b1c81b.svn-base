using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Toko
{
    static class Numerator
    {
        
        public static string GetNumerator(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
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
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + String.Format("{0:0000}",(Convert.ToInt32(dt.Rows[0]["Nomor"])+1)).TrimEnd()+ "/" + (DateTime.Now.Month.ToString().TrimEnd() + "/" + (DateTime.Now.Year.ToString().TrimEnd()));
            return result;
        }

        public static string GetNextNumeratorNew(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = String.Format("{0:0000000}", (Convert.ToInt32(dt.Rows[0]["Nomor"]) + 1)).TrimEnd();
            return result;
        }

        public static string BookNumerator(string doc)
        {
            string result="";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = String.Format("{0:0000}", dt.Rows[0]["Nomor"]).TrimEnd() + "/" + dt.Rows[0]["Depan"].ToString().TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd() + "" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd();
            return result;
        }

        public static string BookNumeratorNew(string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = String.Format("{0:0000000}", dt.Rows[0]["Nomor"]).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd();
            return result;
        }

        public static string NumeratorList (string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
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
            using (Database db = new Database(GlobalVar.DBFinance))
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
