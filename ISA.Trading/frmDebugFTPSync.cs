using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;
using ISA.Trading.Class;


namespace ISA.Trading
{
    public partial class frmDebugFTPSync : Form
    {
        string uploadDir;
        string globalFileName;
        string globalFullFileName;
        string specialFileName;
        string specialFullFileName;
        string uploadArchiveDir;
        string zipFileExt = ".Zip";


        public frmDebugFTPSync()
        {
            InitializeComponent();
        }

        private void cmdGlobalUpload_Click(object sender, EventArgs e)
        {
            Execute();
        }
        public void Execute()
        {
            //try
            //{
            //    //Initialize Global Var;
            //    uploadDir = FTP.UploadDirectory;
            //    globalFileName = LookupInfo.GetValue("GLOBAL_FILE_NAME", "FTP");
            //    globalFullFileName = uploadDir + "\\" + globalFileName;
            //    specialFileName = LookupInfo.GetValue("SPECIAL_FILE_NAME", "FTP");
            //    specialFullFileName = uploadDir + "\\" + specialFileName;
            //    uploadArchiveDir = LookupInfo.GetValue("DIRECTORY_ARCHIVE_UPLOAD", "FTP");

            //    string lastBatchID;
            //    string batchID = "";

            //    //Get Last Run Date Time
            //    DateTime currentDate = DateTime.Now;
            //    DateTime lastRunDate;
            //    lastRunDate = GetLastRunDate(out lastBatchID);

            //    if (lastBatchID != "")
            //    {
            //        batchID = lastBatchID.Substring(3) ;
            //        batchID = "0000" + (int.Parse(lastBatchID) + 1).ToString();
            //        batchID = "BCH" + batchID.Substring(batchID.Length - 5);
            //    }
            //    else
            //    {
            //        batchID = "BCH00001";
            //    }


            //    //Make new Schedule Entry, getting new batch ID

            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_SyncUpload_INSERT"));
            //        db.Commands[0].Parameters.Add(new Parameter("BatchID", SqlDbType.VarChar, batchID));
            //        db.Commands[0].Parameters.Add(new Parameter("RunDate", SqlDbType.VarChar, currentDate));                    
            //        db.Commands[0].ExecuteNonQuery();
            //        //Do Publish               
            //        GlobalPublish(batchID, lastRunDate, currentDate);
            //        SpecialPublish(batchID, lastRunDate, currentDate);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
        //}

        //private DateTime GetLastRunDate(out string lastBatchID)
        //{
        //    //Get Last Run Time Info
        //    DataTable dt;
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Add(db.CreateCommand("usp_SyncUpload_LAST"));
        //        dt = db.Commands[0].ExecuteDataTable();
        //    }

        //    DateTime lastRunDate;

        //    if (dt.Rows.Count > 0)
        //    {
        //        lastRunDate = DateTime.Parse(dt.Rows[0]["SyncDate"].ToString());
        //        lastBatchID = dt.Rows[0]["BatchID"].ToString();
        //    }
        //    else
        //    {
        //        lastRunDate = DateTime.Now;
        //        lastBatchID = "";
        //    }
        //    return lastRunDate;

        //}

        ////private void GlobalPublish(string batchID, DateTime lastRunDate, DateTime currentDate)
        ////{

        ////    //Get Target Inbox
        ////    List<string> addressList;
        ////    addressList = GetAddressList();

        ////    if (addressList.Count > 0)
        ////    {
        ////        //Get Data
        ////        DataSet ds;
        ////        ds = GetGlobalData(batchID, lastRunDate, currentDate);

        ////        //Write to file           

        ////        if (File.Exists(globalFullFileName))
        ////        {
        ////            File.Delete(globalFullFileName);
        ////        }

        ////        ds.WriteXml(globalFullFileName, XmlWriteMode.IgnoreSchema);
        ////        List<string> fileList = new List<string>();
        ////        fileList.Add(globalFullFileName);
        ////        Zip.ZipFiles(fileList, globalFullFileName + zipFileExt);
        ////        //WriteToFile(fullFileName, DateTime.Now.ToString());

        ////        //Publish Via FTP
        ////        SendFiles(addressList, globalFullFileName + zipFileExt);
        ////        ArchiveGlobalFile(batchID);
        ////    }
        ////}

        ////private void SpecialPublish(string batchID, DateTime lastRunDate, DateTime currentDate)
        ////{
        ////    //Get List Cabang
        ////    List<string> cabangList;
        ////    cabangList = GetCabangList();

        ////    DataSet ds;
        ////    foreach (string cabang in cabangList)
        ////    {

        ////        //Get Data

        ////        ds = GetSpecialData(batchID, lastRunDate, currentDate, cabang);


        ////        //Write to file

        ////        if (File.Exists(specialFullFileName))
        ////        {
        ////            File.Delete(specialFullFileName);
        ////        }

        ////        ds.WriteXml(specialFullFileName, XmlWriteMode.IgnoreSchema);
        ////        List<string> fileList = new List<string>();
        ////        fileList.Add(specialFullFileName);
        ////        Zip.ZipFiles(fileList, specialFullFileName + zipFileExt);
        ////        //WriteToFile(fullFileName, DateTime.Now.ToString());

        ////        //Publish Via FTP
        ////        string address = LookupInfo.GetValue(cabang, "FTP_SPECIAL_SYNC_TARGET");
        ////        SendFile(address, specialFullFileName + zipFileExt);
        ////        ArchiveSpecialFile(batchID, cabang);
        ////    }
        ////}

        ////private DataSet GetGlobalData(string batchID, DateTime lastRunDate, DateTime currentDate)
        ////{
        ////    DataSet result = new DataSet();
        ////    DataTable dtHeader = new DataTable();
        ////    DataTable dtDetail = new DataTable();
        ////    using (Database db = new Database())
        ////    {
        ////        db.Commands.Add(db.CreateCommand("usp_SYNC_UPLOAD_LIST"));
        ////        db.Commands[0].Parameters.Add(new Parameter("@batchID", SqlDbType.VarChar, batchID));
        ////        dtHeader = db.Commands[0].ExecuteDataTable();
        ////        dtHeader.TableName = "Header";

        ////        db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ALL"));
        ////        db.Commands[1].Parameters.Add(new Parameter("@lastRunDate", SqlDbType.DateTime, lastRunDate));
        ////        db.Commands[1].Parameters.Add(new Parameter("@currentDate", SqlDbType.DateTime, currentDate));
        ////        dtDetail = db.Commands[1].ExecuteDataTable();
        ////        dtDetail.TableName = "Detail";

        ////        result.Tables.Add(dtHeader);
        ////        result.Tables.Add(dtDetail);
        ////    }
        ////    return result;
        ////}

        ////private DataSet GetSpecialData(string batchID, DateTime lastRunDate, DateTime currentDate, string cabangID)
        ////{
        ////    DataSet result = new DataSet();
        ////    DataTable dtHeader = new DataTable();
        ////    DataTable dtDetail = new DataTable();
        ////    using (Database db = new Database())
        ////    {
        ////        db.Commands.Add(db.CreateCommand("usp_SYNC_UPLOAD_LIST"));
        ////        db.Commands[0].Parameters.Add(new Parameter("@batchID", SqlDbType.VarChar, batchID));
        ////        dtHeader = db.Commands[0].ExecuteDataTable();
        ////        dtHeader.TableName = "Header";

        ////        db.Commands.Add(db.CreateCommand("usp_Sync_SPECIAL"));
        ////        db.Commands[1].Parameters.Add(new Parameter("@lastRunDate", SqlDbType.DateTime, lastRunDate));
        ////        db.Commands[1].Parameters.Add(new Parameter("@currentDate", SqlDbType.DateTime, currentDate));
        ////        db.Commands[1].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, cabangID));
        ////        dtDetail = db.Commands[1].ExecuteDataTable();
        ////        dtDetail.TableName = "Detail";

        ////        result.Tables.Add(dtHeader);
        ////        result.Tables.Add(dtDetail);
        ////    }
        ////    return result; ;
        ////}


        ////private void WriteToFile(string fullFileName, string contents)
        ////{


        ////    //set up a filestream
        ////    FileStream fs = new
        ////    FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write);

        ////    //set up a streamwriter for adding text

        ////    StreamWriter sw = new StreamWriter(fs);

        ////    //find the end of the underlying filestream

        ////    sw.BaseStream.Seek(0, SeekOrigin.End);

        ////    //add the text 
        ////    sw.WriteLine(contents);
        ////    //add the text to the underlying filestream

        ////    sw.Flush();
        ////    //close the writer
        ////    sw.Close();


        ////}

        ////public List<string> GetAddressList()
        ////{
        ////    List<string> result = new List<string>();
        ////    DataTable dt;
        ////    dt = LookupInfo.GetList("FTP_GLOBAL_SYNC_TARGET");
        ////    foreach (DataRow dr in dt.Rows)
        ////    {
        ////        result.Add(dr["Value"].ToString());
        ////    }
        ////    return result;
        ////}

        ////public void SendFile(string address, string fullFileName)
        ////{
        ////    FTP.Upload(address, fullFileName);
        ////}

        ////public void SendFiles(List<string> addressList, string fullFileName)
        ////{
        ////    foreach (string address in addressList)
        ////    {
        ////        FTP.Upload(address, fullFileName);
        ////    }

        ////}

        ////public string ConfirmUpload(DateTime runDate)
        ////{
        ////    string batchID = "";
        ////    using (Database db = new Database())
        ////    {
        ////        DataTable dt;
        ////        db.Commands.Add(db.CreateCommand("usp_SyncUpload_INSERT"));
        ////        db.Commands[0].Parameters.Add(new Parameter("RunDate", SqlDbType.VarChar, runDate));
        ////        dt = db.Commands[0].ExecuteDataTable();
        ////        if (dt.Rows.Count > 0)
        ////        {
        ////            batchID = dt.Rows[0]["BatchID"].ToString();
        ////        }
        ////    }
        ////    return batchID;
        ////}

        ////private List<string> GetCabangList()
        ////{
        ////    DataTable dt = new DataTable();
        ////    using (Database db = new Database())
        ////    {
        ////        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
        ////        dt = db.Commands[0].ExecuteDataTable();
        ////    }

        ////    List<string> result = new List<string>();
        ////    foreach (DataRow dr in dt.Rows)
        ////    {
        ////        result.Add(dr["CabangID"].ToString());
        ////    }
        ////    return result;
        ////}

        ////private void ArchiveGlobalFile(string batchID)
        ////{
        ////    if (File.Exists(globalFullFileName + zipFileExt))
        ////    {
        ////        string destinationDir = uploadArchiveDir + "\\" + batchID;
        ////        if (Directory.Exists(destinationDir))
        ////        {
        ////            Directory.CreateDirectory(destinationDir);
        ////        }
        ////        File.Copy(globalFullFileName + zipFileExt, destinationDir + globalFileName + zipFileExt);
        ////        File.Delete(globalFullFileName + zipFileExt);
        ////    }

        ////    if (File.Exists(globalFullFileName))
        ////    {
        ////        File.Delete(globalFullFileName);
        ////    }
        ////}

        ////public void ArchiveSpecialFile(string batchID, string cabangID)
        ////{

        ////    if (File.Exists(specialFullFileName + zipFileExt))
        ////    {
        ////        string destinationDir = uploadArchiveDir + "\\" + batchID + "\\" + cabangID;
        ////        if (Directory.Exists(destinationDir))
        ////        {
        ////            Directory.CreateDirectory(destinationDir);
        ////        }
        ////        File.Copy(specialFullFileName + zipFileExt, destinationDir + specialFileName + zipFileExt);
        ////        File.Delete(specialFullFileName + zipFileExt);
        ////    }
        ////    if (File.Exists(specialFullFileName))
        ////    {
        ////        File.Delete(specialFullFileName);
        ////    }
        }
    }
}
