using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Common;

namespace ISA.Batch
{
    public class MessageSetting
    {
        public static string PortName
        {
            get { return AppSetting.GetRow("SMS_PORT").Value; }
        }

        public static int ResponseTimeout
        {
            get { return Convert.ToInt32(AppSetting.GetRow("SMS_TIMEOUT").Value); }
        }

        public static string JTSubject
        {
            get { return AppSetting.GetRow("SMS_JTTEMPO").Keterangan; }
        }

        public static string JTMsg
        {
            get { return AppSetting.GetRow("SMS_JTTEMPO").Value; }
        }

        public static string PraJTMsg
        {
            get { return AppSetting.GetRow("SMS_PRA_JTTEMPO").Value; }
        }

        public static string PosJTMsg
        {
            get { return AppSetting.GetRow("SMS_POS_JTTEMPO").Value; }
        }

        public static string ParseMsg(string messageSet, DataColumnCollection columns, DataRow row)
        {
            string message = messageSet;

            foreach (DataColumn column in columns)
            {
                if (column.ColumnName.IndexOf("<") == 0 && column.ColumnName.IndexOf(">") > 0)
                {
                    message = message.Replace(column.ColumnName, row[column.ColumnName].ToString());
                }
            }

            return message;
        }
    }
}
