using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using ISA.Common;
using System.Data;

namespace ISA.FTP
{
    public class FtpEngine
    {
        static string userName;
        static string password;
        static string dirDownload;
        static string dirUpload;
        static string dirInbox;

        public static string DownloadDirectory
        {
            get {
                if (dirDownload == null) Initialize();
                return dirDownload; }
        }

        public static string UploadDirectory
        {
            get {
                if (dirUpload == null) Initialize();
                return dirUpload; }
        }

        public static string InboxDirectory
        {
            get {
                if (dirInbox == null) Initialize();
                return dirInbox; }
        }

        public static void Initialize()
        {
            userName = LookupInfo.GetValue("FTP", "FTP_USER");
            password = Tools.DecodePassword(LookupInfo.GetValue("FTP", "FTP_PASSWORD"));
            dirDownload = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            ValidateDirectory(dirDownload);
            dirUpload = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_UPLOAD");
            ValidateDirectory(dirUpload);
            dirInbox = LookupInfo.GetValue("FTP", "FTP_INBOX");
        }


        public static DataTable GetFileList(string ftpTargetAlias)
        {
            DataTable result = new DataTable();

            result.Columns.Add("FileName", typeof ( System.String));
            result.Columns.Add("FileSize", typeof (double));
            result.Columns.Add("ShortSize", typeof(double));

            DataColumn[] keys = new DataColumn[1];
            keys[0] = result.Columns["FileName"];
            result.PrimaryKey = keys;

            //Initialize();
            //FileInfo fileInf = new FileInfo(fullFileName);
            List<string> strList = new List<string>();
            //string uri = ftpAddress + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(GetAddresList( ftpTargetAlias)));
            reqFTP.Credentials = new NetworkCredential(userName, password);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;

            StreamReader sr = new StreamReader(reqFTP.GetResponse().GetResponseStream());

            string str = sr.ReadLine();
            while (str != null)
            {
                if (str.Replace(".", "").Trim() != "")
                {
                    str = str.Substring(str.IndexOf("/") + 1);
                    strList.Add(str);


                    DataRow newRow = result.NewRow();
                    newRow["FileName"] = str;
                    newRow["FileSize"] = 0;
                    newRow["ShortSize"] = 0;
                    result.Rows.Add(newRow);
                }
                str = sr.ReadLine();
            }

            sr.Close();
            sr = null;            
            reqFTP = null;

            

            foreach (DataRow dr in result.Rows)
            {
                long size = GetFileSize(ftpTargetAlias, dr["FileName"].ToString());
                dr["FileSize"] = (double )size;
                dr["ShortSize"] = Math.Ceiling((double)(size / 1024));
            }

            return result;

        }



        public static bool Upload(string ftpTargetAlias, string fullFileName)
        {
            //Initialize();
            bool success = false;
            FileInfo fileInf = new FileInfo(fullFileName);
            double fileSize = fileInf.Length;

            string uri = GetAddresList (ftpTargetAlias) + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(userName, password);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file
            // to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload
                    // Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();

                double uploadsize = GetFileSize(ftpTargetAlias, fileInf.Name);
                if (uploadsize == fileSize)
                {
                    success = true;
                }
                else
                {
                    FTP.FtpEngine.Delete(ftpTargetAlias, fileInf.Name);                
                }
            }
            finally
            {
                reqFTP = null;
                
            }
            return success;
        }

        public static double Download(string fptTargetAlias, string fileName)
        {
            //Initialize();
            string buffer = "";
            StreamWriter writer = new StreamWriter(dirDownload + "\\" + fileName);
            
            try
            {
                //filePath: The full path where the file is to be created.
                //fileName: Name of the file to be createdNeed not name on
                //          the FTP server. name name()
                //FileStream outputStream = new FileStream(dirDownload + "\\" + fileName, FileMode.Create);

                


                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(GetAddresList(fptTargetAlias) + "/" + fileName));
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(userName, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                buffer = reader.ReadToEnd();

                writer.Write(buffer);

                //Console.WriteLine(reader.ReadToEnd());

                //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);                
                reader.Close();
                response.Close();
            }
            finally
            {
                writer.Close();
            }
            return buffer.Length;
        }


        public static bool Delete(string ftpTargetAlias, string fileName)
        {
            bool deleted = false;
            string status="";
            FtpWebRequest reqFTP;

                //filePath: The full path where the file is to be created.
                //fileName: Name of the file to be createdNeed not name on
                //          the FTP server. name name()
                //FileStream outputStream = new FileStream(dirDownload + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(GetAddresList(ftpTargetAlias) + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                status =   response.StatusDescription;
                response.Close();

                if (status.Substring(0, 3) == "250")
                {
                    deleted = true;
                }
            return deleted;
        }


        public static long GetFileSize(string ftpTargetAlias, string fileName)
        {

            long fsize=0;
            FtpWebRequest reqFTP;
            //filePath: The full path where the file is to be created.
            //fileName: Name of the file to be createdNeed not name on
            //          the FTP server. name name()
            //FileStream outputStream = new FileStream(dirDownload + "\\" + fileName, FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(GetAddresList(ftpTargetAlias) + "/" + fileName));
            reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(userName, password);
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            fsize = response.ContentLength;
            response.Close();
            return fsize;
        }

        public static string GetAddresList(string ftpTargtAlias)
        {
            return LookupInfo.GetValue("FTP_ADDRESSLIST", ftpTargtAlias);
        }

        public static void ValidateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                
            }
        }

        public static bool ConnectionExists()
        {
            bool success;
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                clnt.Close();
                success = true;
            }
            catch
            {
                success = false;   
            }
            return success;
        }


    }
}
