using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Batch
{
    public class LogTable
    {
        public enum ProcessStatusEnum { EndOK, EndWarning, EndError, EndFail, InProgress };

        public static string StatusDesc(ProcessStatusEnum processStatus)
        {
            string desc = string.Empty;

            switch (processStatus)
            {
                case ProcessStatusEnum.EndOK:
                    desc = "Sukses";
                    break;
                case ProcessStatusEnum.EndWarning:
                    desc = "Warning";
                    break;
                case ProcessStatusEnum.EndError:
                    desc = "Error";
                    break;
                case ProcessStatusEnum.EndFail:
                    desc = "Gagal";
                    break;
                case ProcessStatusEnum.InProgress:
                    desc = "In progress";
                    break;
            }

            return desc;
        }

        public static Guid StartLog(string processName)
        {
            Guid rowID;

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_ProcessLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@processName", SqlDbType.VarChar, processName));
                db.Commands[0].Parameters.Add(new Parameter("@processStatus", SqlDbType.Int, ProcessStatusEnum.InProgress));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "SCHEDULER"));
                rowID = (Guid)db.Commands[0].ExecuteScalar();
            }

            return rowID;
        }

        public static void EndLog(Guid rowID)
        {
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_ProcessLog_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "SCHEDULER"));
                db.Commands[0].ExecuteNonQuery();                
            }
        }

        public static DataTable GetLog(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_ProcessLog_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                dt = db.Commands[0].ExecuteDataTable();
            }

            return dt;
        }
    }
}
