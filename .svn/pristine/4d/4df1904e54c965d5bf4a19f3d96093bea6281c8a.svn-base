using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Publisher.Class
{
    public class AppSetting
    {
        public static string GetValue(  string _key)
        {
            string result = "false";
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, _key));
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
