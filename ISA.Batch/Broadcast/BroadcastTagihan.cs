using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO.Ports;
using ISA.DAL;
using ISA.Common;

namespace ISA.Batch
{
    public class BroadcastTagihan
    {

        private static LogTableDetails SendMessage(DataTable dt, Guid processLogRowID)
        {
            const string sourceTable = "Toko";

            int rowsCount = dt.Rows.Count;

            LogTableDetails logTableDetails = new LogTableDetails();

            LogTableDetail logTableDetail = BroadcastLog.LogStart(processLogRowID, rowsCount);
            logTableDetails.Add(logTableDetail);

            SerialPort port = new SerialPort();
            SMS sms = new SMS();
            ShortMessages objShortMessages = new ShortMessages();

            int sentCount = 0;
            int failedCount = 0;
            try
            {
                int responseTimeout = MessageSetting.ResponseTimeout;

                port = sms.OpenPort(MessageSetting.PortName);

                logTableDetails.Add(BroadcastLog.LogConnection(processLogRowID, "Akses " + port.PortName, failedCount));

                string allMessageSet = MessageSetting.JTMsg;
                string praMessageSet = MessageSetting.PraJTMsg;
                string posMessageSet = MessageSetting.PosJTMsg;

                foreach (DataRow dr in dt.Rows)
                {
                    string kodeToko = Tools.isNull(dr["KodeToko"], string.Empty).ToString();
                    string toko = Tools.isNull(dr["NamaToko"], string.Empty).ToString();
                    string willID = Tools.isNull(dr["WilID"], string.Empty).ToString();
                    string hp = Tools.isNull(dr["HP"], string.Empty).ToString();
                    string kategori = Tools.isNull(dr["Kategori"], string.Empty).ToString();
                    string praHari = Tools.isNull(dr["<PraHari>"], string.Empty).ToString();
                    string posHari = Tools.isNull(dr["<PosHari>"], string.Empty).ToString();
                    string praRpSisa = Tools.isNull(dr["<PraRpSisa>"], string.Empty).ToString();
                    string posRpSisa = Tools.isNull(dr["<PosRpSisa>"], string.Empty).ToString();
                    string kontakNoHP = Tools.isNull(dr["<KontakNoHP>"], string.Empty).ToString();
                    if (hp != string.Empty)
                    {
                        string processLocation = "SMS HP: " + hp + ", Toko: " + toko + ", IdWil: " + willID + ", Kode Toko: " + kodeToko;

                        string message = string.Empty;

                        switch (kategori.ToUpper())
                        {
                            case "ALL":
                                message = MessageSetting.ParseMsg(allMessageSet, dt.Columns, dr);
                                break;
                            case "PRA":
                                message = MessageSetting.ParseMsg(praMessageSet, dt.Columns, dr);
                                break;
                            case "POS":
                                message = MessageSetting.ParseMsg(posMessageSet, dt.Columns, dr);
                                break;
                            default:
                                break;
                        }

                        try
                        {
                            if (sms.SendMsg(port, hp, message, responseTimeout))
                            {
                                sentCount++;
                                logTableDetails.Add(BroadcastLog.LogSend(processLogRowID, processLocation, message, kategori, sourceTable, kodeToko));
                            }
                            else
                            {
                                failedCount++;
                                logTableDetails.Add(BroadcastLog.LogSend(processLogRowID, processLocation, message, string.Empty, kategori, sourceTable, kodeToko));
                            }
                        }
                        catch (Exception ex)
                        {
                            failedCount++;
                            logTableDetails.Add(BroadcastLog.LogSend(processLogRowID, processLocation, message, ex.Message, kategori, sourceTable, kodeToko));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                failedCount = rowsCount;

                logTableDetails.Add(BroadcastLog.LogConnection(processLogRowID, ex.Message, failedCount));
            }

            sms.ClosePort(port);

            logTableDetails.Add(BroadcastLog.LogEnd(processLogRowID, rowsCount, sentCount, failedCount));

            return logTableDetails;
        }

        public static void SendMessage()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_SMS_JatuhTempo"));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                string subject = MessageSetting.JTSubject;
                Guid rowID = LogTable.StartLog(subject.ToUpper());

                LogTableDetails logTableDetails = SendMessage(dt, rowID);

                LogTableDetailsProcess.AddLogDetails(logTableDetails);

                LogTable.EndLog(rowID);

                LogTableDetailsProcess.AddLogDetails(
                    BroadcastLog.SendEmail(rowID, subject, BroadcastLog.MailBodyBuilder(rowID, logTableDetails[logTableDetails.Count - 1].ProcessMessage).ToString())
                    , logTableDetails.Count);
            }
        }
    }
}
