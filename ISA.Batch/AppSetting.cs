using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Batch
{
    public class AppSettingAttr
    {
        public string Key { get; set; }
        public string Keterangan { get; set; }
        public string Value { get; set; }
    }

    public class AppSetting
    {
        public static AppSettingAttr GetRow(string key)
        {
            AppSettingAttr appSet = new AppSettingAttr();

            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, key));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                appSet.Key = dt.Rows[0]["Key"].ToString();
                appSet.Keterangan = dt.Rows[0]["Keterangan"].ToString();
                appSet.Value = dt.Rows[0]["Value"].ToString();
            }

            return appSet;
        }
    }
}
