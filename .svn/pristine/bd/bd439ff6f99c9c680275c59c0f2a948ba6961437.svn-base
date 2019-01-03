using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using ISA.DAL;
using System.Data;
using ISA.Common;

namespace ISA.Common
{
    public class FTP
    {
        static string userName;
        static string password;
        static string dirDownload;
        static string dirUpload;
        static string dirInbox;

        public static string DownloadDirectory
        {
            get { return dirDownload; }
        }

        public static string UploadDirectory
        {
            get { return dirUpload; }
        }

        public static string InboxDirectory
        {
            get { return dirInbox; }
        }

        public static void Initialize()
        {
            userName = LookupInfo.GetValue("FTP", "FTP_USER");
            password = Tools.DecodePassword(LookupInfo.GetValue("FTP", "FTP_PASSWORD"));
            dirDownload = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            dirUpload = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_UPLOAD");
            dirInbox = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_INBOX");
        }


        public static void Upload(string ftpAddress, string fullFileName)
        {
            Initialize();
            FileInfo fileInf = new FileInfo(fullFileName);
            string uri = ftpAddress + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + fileInf.Name));
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
            
        }

        public static void Download(string ftpAddress, string fileName)
        {
            Initialize();
            FtpWebRequest reqFTP;

            //filePath: The full path where the file is to be created.
            //fileName: Name of the file to be createdNeed not name on
            //          the FTP server. name name()
            FileStream outputStream = new FileStream(dirDownload + "\\" + fileName, FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + fileName));
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(userName, password);
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            response.Close();
            

        }


        public static void Delete(string ftpAddress, string fileName)
        {
            Initialize();
            FtpWebRequest reqFTP;

            //filePath: The full path where the file is to be created.
            //fileName: Name of the file to be createdNeed not name on
            //          the FTP server. name name()
            FileStream outputStream = new FileStream(dirDownload + "\\" + fileName, FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + fileName));
            reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(userName, password);
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            long cl = response.ContentLength;
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[bufferSize];

            readCount = ftpStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);
                readCount = ftpStream.Read(buffer, 0, bufferSize);
            }

            ftpStream.Close();
            outputStream.Close();
            response.Close();

        }
    }
}
