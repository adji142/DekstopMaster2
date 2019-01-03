using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Toko
{
    class LookupInfo
    {
        public static DataTable GetList(string type)
        {
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@lookuptype", SqlDbType.VarChar, type));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static string GetValue(string type, string code)
        {
            string result = "";
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@lookuptype", SqlDbType.VarChar, type));
                db.Commands[0].Parameters.Add(new Parameter("@lookupcode", SqlDbType.VarChar, code));                
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["Value"].ToString();
            }
            return result;
        }

    }
}
