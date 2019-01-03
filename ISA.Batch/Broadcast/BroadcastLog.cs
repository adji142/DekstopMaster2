using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ISA.DAL;
using ISA.Common;

namespace ISA.Batch
{
    public class BroadcastLog
    {
        private static DataSet LogDataset(Guid processLogRowID)
        {
            DataSet ds;

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("rsp_ProcessLog"));
                db.Commands[0].Parameters.Add(new Parameter("@processLogRowID", SqlDbType.UniqueIdentifier, processLogRowID));

                ds = db.Commands[0].ExecuteDataSet();
            }

            return ds;
        }

        private static ExcelPackage LogWorksheets()
        {
            ExcelPackage ep = new ExcelPackage();

            ep.Workbook.Worksheets.Add("Log");

            foreach (ExcelWorksheet ws in ep.Workbook.Worksheets)
            {
                ws.View.ShowGridLines = false;
                ws.View.PageLayoutView = true;
                ws.View.PageBreakView = true;
                ws.PrinterSettings.FitToPage = true;
            }

            return ep;
        }

        private static ExcelWorksheet LogWorksheet(ExcelPackage ep, DataTable headerData, DataTable detailData)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["Log"];

            #region Header
            ws.Cells[1, 1].Value = "LOG " + headerData.Rows[0]["ProcessName"].ToString();
            ws.Cells[3, 1].Value = "ID:";
            ws.Cells[4, 1].Value = "Tanggal:";
            ws.Cells[5, 1].Value = "Jam:";
            ws.Cells[6, 1].Value = "Status:";

            ws.Cells[3, 2].Value = ((Guid)headerData.Rows[0]["RowID"]).ToString().ToUpper();
            ws.Cells[4, 2].Value = ((DateTime)headerData.Rows[0]["StartDate"]).ToString("dd/MM/yyyy");
            ws.Cells[5, 2].Value = ((DateTime)headerData.Rows[0]["StartDate"]).ToString("HH:mm:ss") + " s/d " + ((DateTime)headerData.Rows[0]["EndDate"]).ToString("HH:mm:ss");
            ws.Cells[6, 2].Value = LogTable.StatusDesc((LogTable.ProcessStatusEnum)headerData.Rows[0]["ProcessStatus"]);
            #endregion

            #region Table header
            ws.Cells[7, 1].Value = "No.";
            ws.Cells[7, 2].Value = "Nama Proses";
            ws.Cells[7, 3].Value = "Pesan Proses";
            ws.Cells[7, 4].Value = "Status Proses";
            ws.Cells[7, 5].Value = "Tanggal Proses";

            ws.Column(1).Width = 8;
            #endregion

            #region Body
            int stDataRow = 8;
            int rowCounter = 8;

            foreach (DataRow dr in detailData.Rows)
            {
                LogTableDetail.ProcessStatusDetailEnum processStatus = (LogTableDetail.ProcessStatusDetailEnum)dr["ProcessStatus"];

                ws.Cells[rowCounter, 1].Value = dr["ProcessSeqNo"];
                ws.Cells[rowCounter, 2].Value = dr["ProcessLocation"];
                ws.Cells[rowCounter, 3].Value = dr["ProcessMessage"];
                ws.Cells[rowCounter, 4].Value = LogTableDetailsProcess.StatusDesc(processStatus);
                ws.Cells[rowCounter, 5].Value = dr["ProcessDate"];

                switch (processStatus)
                {
                    case LogTableDetail.ProcessStatusDetailEnum.Warning:
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                        break;
                    case LogTableDetail.ProcessStatusDetailEnum.Error:
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.BackgroundColor.SetColor(Color.Red);
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Font.Color.SetColor(Color.White);
                        break;
                    case LogTableDetail.ProcessStatusDetailEnum.Fail:
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                        ws.Cells[rowCounter, 1, rowCounter, 5].Style.Font.Color.SetColor(Color.White);
                        break;
                }

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[7, 1, 7, 5].Style.Font.Bold = true;
            ws.Cells[7, 1, 7, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[7, 1, 7, 5].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[7, 1, rowCounter, 5].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 5, rowCounter, 5].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
            #endregion
            #endregion

            #region Alignment
            ws.Cells[3, 1, 6, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[3, 1, 6, 1].Style.Font.Bold = true;
            ws.Cells[7, 1, 7, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 5; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Generated by SMS Scheduler, " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private static bool SaveLog(ExcelPackage ep, string filePath)
        {
            bool isSaved = false;

            try
            {
                Byte[] bin = ep.GetAsByteArray();

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }


                File.WriteAllBytes(filePath, bin);

                isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static LogTableDetail LogSendEmail(Guid processLogRowID, string mailSubject, string mailBody)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = "KIRIM EMAIL";
            logTableDetail.ProcessMessage = string.Empty;

            string attachmentFileName = string.Empty;
            try
            {
                attachmentFileName = AttachmentFileName(processLogRowID);
            }
            catch (Exception ex)
            {
                logTableDetail.ProcessMessage = ex.Message;
                logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.Warning;
            }

            try
            {
                string body = string.Empty;
                if (attachmentFileName != string.Empty)
                {
                    body = mailBody + "\n" +
                        "Silahkan cek attachment untuk lebih detail-nya.";

                    logTableDetail.ProcessMessage = "Pengiriman log melalui email";
                    logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.OK;
                }
                else
                {
                    body = mailBody + "\n" +
                        "Attachment tidak bisa di-generate. Silahkan cek menu Log Monitoring untuk lebih detail-nya.";

                    logTableDetail.ProcessMessage = "Gagal generate attachment. " + logTableDetail.ProcessMessage;
                    logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.Warning;
                }

                LogMail logMail = new LogMail();
                logMail.SendMail(mailSubject, body, attachmentFileName);
            }
            catch (Exception ex)
            {
                logTableDetail.ProcessMessage = logTableDetail.ProcessMessage + "; " + ex.Message;
                logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.Warning;
            }

            logTableDetail.ProcessDate = DateTime.Now;

            return logTableDetail;
        }

        public static LogTableDetail LogStart(Guid processLogRowID, int rowsCount)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = "AWAL PROSES";
            logTableDetail.ProcessMessage = "Jumlah toko yang harus dikirimi SMS: " + rowsCount.ToString();
            logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.OK;
            logTableDetail.ProcessDate = DateTime.Now;

            return logTableDetail;
        }

        public static LogTableDetail LogConnection(Guid processLogRowID, string processMessage, int failedCount)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = "BUKA PORT";
            logTableDetail.ProcessMessage = processMessage;
            if (failedCount == 0)
            {
                logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.OK;
            }
            else
            {
                logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.Fail;
            }
            logTableDetail.ProcessDate = DateTime.Now;

            return logTableDetail;
        }

        public static LogTableDetail LogSend(Guid processLogRowID, string processLocation, string smsMessage, 
            string processCategory, string sourceTable, string sourceID)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = processLocation;
            logTableDetail.ProcessMessage = smsMessage;
            logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.OK;
            logTableDetail.ProcessDate = DateTime.Now;
            logTableDetail.ProcessCategory = processCategory;
            logTableDetail.SourceTable = sourceTable;
            logTableDetail.SourceID = sourceID;

            return logTableDetail;
        }

        public static LogTableDetail LogSend(Guid processLogRowID, string processLocation, string smsMessage, 
            string errMessage, string processCategory, string sourceTable, string sourceID)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = processLocation;
            if (errMessage == string.Empty)
            {
                logTableDetail.ProcessMessage = "Gagal kirim SMS.";
            }
            else
            {
                logTableDetail.ProcessMessage = errMessage;
            }
            logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.Error;
            logTableDetail.ProcessDate = DateTime.Now;
            logTableDetail.ProcessCategory = processCategory;
            logTableDetail.SourceTable = sourceTable;
            logTableDetail.SourceID = sourceID;

            return logTableDetail;
        }

        public static StringBuilder MailBodyBuilder(Guid processLogRowID, string processSummary)
        {
            StringBuilder mailBodyBuilder = new StringBuilder();
            mailBodyBuilder.AppendLine("Dear all,");
            mailBodyBuilder.AppendLine();
            mailBodyBuilder.AppendLine("SMS broadcast sudah selesai dieksekusi dengan hasil akhir sebagai berikut:");
            mailBodyBuilder.AppendLine();
            mailBodyBuilder.AppendLine("ID Proses: " + processLogRowID.ToString().ToUpper());
            mailBodyBuilder.AppendLine();
            mailBodyBuilder.AppendLine(processSummary);
            mailBodyBuilder.AppendLine();
            mailBodyBuilder.AppendLine("Terima kasih.");
            mailBodyBuilder.AppendLine("-SMS Broadcaster-");

            return mailBodyBuilder;
        }

        public static string AttachmentFileName(Guid processLogRowID)
        {
            string filePath = string.Empty;

            try
            {
                DataSet ds = LogDataset(processLogRowID);

                int allRows = 0;
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        allRows += ds.Tables[i].Rows.Count;
                    }
                }

                if (allRows > 0)
                {
                    ExcelPackage ep = LogWorksheets();

                    ExcelWorksheet wsLog = LogWorksheet(ep, ds.Tables[0], ds.Tables[1]);

                    filePath = @"C:\TEMP\LOG_SMS_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".xlsx";

                    SaveLog(ep, filePath);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LogTableDetail LogEnd(Guid processLogRowID, int rowsCount, int sentCount, int failedCount)
        {
            LogTableDetail logTableDetail = new LogTableDetail();
            logTableDetail.ProcessLogRowID = processLogRowID;
            logTableDetail.ProcessLocation = "AKHIR PROSES";
            logTableDetail.ProcessMessage = "Jumlah Berhasil: " + sentCount.ToString() + "; Jumlah Gagal: " + failedCount.ToString() + "; Total: " + rowsCount.ToString();
            logTableDetail.ProcessStatus = LogTableDetail.ProcessStatusDetailEnum.OK;
            logTableDetail.ProcessDate = DateTime.Now;

            return logTableDetail;
        }

        public static LogTableDetails SendEmail(Guid processLogRowID, string subject, string mailBody)
        {
            LogTableDetails logTableDetails = new LogTableDetails();

            LogTableDetail logTableDetail =
                LogSendEmail(processLogRowID,
                            subject,
                            mailBody);

            logTableDetails.Add(logTableDetail);

            return logTableDetails;
        }
    }
}
