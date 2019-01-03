using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Batch
{
    public class LogTableDetail
    {
        public enum ProcessStatusDetailEnum { OK, Warning, Error, Fail };

        public Guid ProcessLogRowID { get; set; }
        public int ProcessSeqNo { get; set; }
        public string ProcessLocation { get; set; }
        public string ProcessMessage { get; set; }
        public ProcessStatusDetailEnum ProcessStatus { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProcessCategory { get; set; }
        public string SourceTable { get; set; }
        public string SourceID { get; set; }

        public LogTableDetail()
        {
        }
    }

    public class LogTableDetails : List<LogTableDetail>
    {
    }

    public class LogTableDetailsProcess
    {
        public static string StatusDesc(LogTableDetail.ProcessStatusDetailEnum processStatus)
        {
            string desc = string.Empty;

            switch (processStatus)
            {
                case LogTableDetail.ProcessStatusDetailEnum.OK:
                    desc = "Sukses";
                    break;
                case LogTableDetail.ProcessStatusDetailEnum.Warning:
                    desc = "Warning";
                    break;
                case LogTableDetail.ProcessStatusDetailEnum.Error:
                    desc = "Error";
                    break;
                case LogTableDetail.ProcessStatusDetailEnum.Fail:
                    desc = "Gagal";
                    break;
            }

            return desc;
        }

        private static void SaveLogDetails(LogTableDetails logTableDetails, int processSeqNo)
        {
            int seqNo = processSeqNo;
            foreach (LogTableDetail logTableDetail in logTableDetails)
            {
                seqNo++;

                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_ProcessLogDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@processLogRowID", SqlDbType.UniqueIdentifier, logTableDetail.ProcessLogRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@processSeqNo", SqlDbType.VarChar, seqNo));
                    db.Commands[0].Parameters.Add(new Parameter("@processLocation", SqlDbType.VarChar, logTableDetail.ProcessLocation));
                    db.Commands[0].Parameters.Add(new Parameter("@processMessage", SqlDbType.VarChar, logTableDetail.ProcessMessage));
                    db.Commands[0].Parameters.Add(new Parameter("@processStatus", SqlDbType.Int, logTableDetail.ProcessStatus));
                    db.Commands[0].Parameters.Add(new Parameter("@processDate", SqlDbType.DateTime, logTableDetail.ProcessDate));
                    db.Commands[0].Parameters.Add(new Parameter("@processCategory", SqlDbType.VarChar, logTableDetail.ProcessCategory));
                    db.Commands[0].Parameters.Add(new Parameter("@sourceTable", SqlDbType.VarChar, logTableDetail.SourceTable));
                    db.Commands[0].Parameters.Add(new Parameter("@sourceID", SqlDbType.VarChar, logTableDetail.SourceID));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
        }

        public static void AddLogDetails(LogTableDetails logTableDetails)
        {
            SaveLogDetails(logTableDetails, 0);
        }

        public static void AddLogDetails(LogTableDetails logTableDetails, int processSeqNo)
        {
            SaveLogDetails(logTableDetails, processSeqNo);
        }

        public static DataTable GetLogDetails(Guid processLogRowID)
        {
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_ProcessLogDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@processLogRowID", SqlDbType.UniqueIdentifier, processLogRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            return dt;
        }
    }
}
